Imports System.Net.Mail
Imports System.IO

Public Class MailTrabajos

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 28/11/2014
    ''' DESCR: PROCEDIMIENTO PARA EL ENVIO DE MAIL
    ''' </summary>
    ''' <param name="Proceso"></param>
    ''' <param name="OrdenId"></param>
    ''' <remarks></remarks>
    Public Function EnvioEmailConfirmaciónPago(ByVal proceso As String, ByVal ordenId As Decimal) As String
        EnvioEmailConfirmaciónPago = ""
        Try
            Dim emailBody, emailBodyCopias As String
            Dim emailAddres, emailAddresCopias As String
            Dim dTCstGeneral, dTCstGeneralCopias As New System.Data.DataSet

            'ENVIA EMAIL A CLIENTE
            dTCstGeneral = RenovacionAdapter.ConsultaEmail(OrdenId, Proceso, True)
            emailBody = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("HTMLBODY"))
            emailAddres = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("BILLINGEMAIL"))
            EMailHandler.EMailConfirmacionPagoCliente(emailBody, emailAddres, Proceso)

            'ENVIA MAIL COPIAS
            dTCstGeneralCopias = RenovacionAdapter.ConsultaEmail(OrdenId, Proceso, False)
            emailBodyCopias = Convert.ToString(dTCstGeneralCopias.Tables(0).Rows(0)("HTMLBODY"))
            emailAddresCopias = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC")
            EMailHandler.EMailConfirmacionPagoCliente(emailBodyCopias, emailAddresCopias, Proceso)
            EnvioEmailConfirmaciónPago = "Envío de email correcto"
        Catch ex As Exception
            EnvioEmailConfirmaciónPago = "Ocurrió un error al enviar el email de confirmación"
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 05/08/2014
    ''' DESCR: ENVIO DE MENSAJES A MAIL
    ''' </summary>
    ''' <remarks></remarks>
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MailAvisoTurno(ByVal fecha As String, ByVal hora As String, ByVal taller As String, ByVal direccion As String, _
                              ByVal referencia As String, ByVal contacto As String, ByVal telefono As String, ByVal placa As String, _
                              ByVal mailCreacion As Boolean, ByVal actualizacion As Boolean, ByVal fuera As Boolean, ByVal ciudad As String, _
                              ByVal tallerDireccion As String, ByVal idTurno As String, ByVal orden As String, ByVal cliente As String, _
                              ByVal tipo_turno As String, ByVal vehiculo As String, ByVal soporte As String)
        Try
            Dim atachmentGenerado As String = ""
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            Dim correo As String = ConsultaCorreo(cliente)
            Dim nombrecliente As String = EncriptaCliente(cliente)
            Dim clienteTurno As String = HttpContext.Current.Session("user_id")
            'Session("id_cliente_turno").ToString 
            Dim aplicacion As String = HttpContext.Current.Application("soporteextranet")
            'CType(Application("soporteextranet"), String)

            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            If correo.IndexOf(",") > 0 Then
                correo = correo.Substring(0, correo.IndexOf(","))
            End If
            Dim mailAddressto As New MailAddress(correo)
            mailMessage.To.Add(mailAddressto)
            Dim mailcco As String = aplicacion
            Dim mailToCollectionCco As [String]() = mailcco.Split(",")
            For Each mailTo As String In mailToCollectionCco
                mailMessage.Bcc.Add(mailTo)
            Next

            Dim dssoporte As DataSet
            dssoporte = ContactosAdapter.ConsultaCorreoEjecutivaSoporte(soporte)
            If dssoporte.Tables.Count > 0 Then
                If dssoporte.Tables(0).Rows.Count > 0 Then
                    Dim correo_soporte As String = dssoporte.Tables(0).Rows(0).Item(0)
                    mailMessage.Bcc.Add(correo_soporte)
                End If
            End If

            Dim dsejecutiva As DataSet
            dsejecutiva = ContactosAdapter.ConsultaCorreoEjecutiva(vehiculo)
            If dsejecutiva.Tables.Count > 0 Then
                If dsejecutiva.Tables(0).Rows.Count > 0 Then
                    Dim correo_ejecutiva As String = dsejecutiva.Tables(0).Rows(0).Item(0)
                    mailMessage.Bcc.Add(correo_ejecutiva)
                End If
            End If

            If mailCreacion Then
                'Dim androidTurnosPdf As New GeneraPdf
                'cambio pendiente por confirmar GALVAR
                Dim androidTurnosPdf As New DocumentoRecepcionPDf
                Dim ruta As String = ConsultaRuta()
                Dim archivo As String = String.Format("{0}Acta_Recepcion_OS_{1}.pdf", ruta, orden)
                If File.Exists(archivo) Then
                    File.Delete(archivo)
                End If
                androidTurnosPdf.GuiaRecepcion(clienteTurno, orden, archivo, String.Format("{0} {1}", fecha, hora.Substring(0, 5)), tallerDireccion, taller)

                mailMessage.Attachments.Add(New Attachment(archivo))
                mailMessage.Subject = "Turno agendado desde HunterOnline"
            ElseIf actualizacion Then
                mailMessage.Subject = "Turno actualizado desde HunterOnline"
            ElseIf Not mailCreacion Then
                mailMessage.Subject = "Turno eliminado desde HunterOnline"
            End If
            mailMessage.Body = MailBodyTurno(String.Format("{0} {1}", fecha, hora.Substring(0, 5)), taller, direccion, referencia, contacto, telefono, placa, _
                                             ciudad, mailCreacion, actualizacion, fuera, tallerDireccion, idTurno, orden, nombrecliente, tipo_turno)
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            VehiculoTurnoAdapter.GuardaLogMail(clienteTurno, mailMessage.Body.ToString, mailMessage.Subject.ToString, mailAddressto.ToString)
            mailMessage.Dispose()
            If File.Exists(atachmentGenerado) Then
                File.Delete(atachmentGenerado)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 05/08/2014
    ''' DESCR: SETEA CUERPO DEL MENSAJE DE MAIL
    ''' </summary>
    ''' <remarks></remarks>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function MailBodyTurno(ByVal fecha As String, ByVal taller As String, ByVal direccion As String, ByVal referencia As String, _
                                        ByVal contacto As String, ByVal telefono As String, ByVal placa As String, ByVal ciudad As String, _
                                        ByVal mailCreacion As Boolean, ByVal actualizacion As Boolean, ByVal fuera As Boolean, _
                                        ByVal tallerDireccion As String, ByVal idTurno As String, ByVal orden As String, ByVal encriptado As String, _
                                        ByVal tipo_turno As String) As String
        Dim builder As New StringBuilder()

        Try
            'Dim ipMaquina As String = String.Empty
            'If Not HttpContext.Current.Session("iphost") Is Nothing Then ipMaquina = HttpContext.Current.Session("iphost").ToString()
            builder.Append("<html>")
            builder.Append("    <head>")
            builder.Append("    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">")
            builder.Append("    <title>")
            If mailCreacion Then
                builder.Append("        <title>Confirmación de Turno</title>")
            ElseIf actualizacion Then
                builder.Append("        <title>Turno Actualizado</title>")
            ElseIf Not mailCreacion Then
                builder.Append("        <title>Turno Eliminado</title>")
            End If
            builder.Append("    </title>")
            builder.Append("    <style type=""text/css"">")
            builder.Append("        .headerContent{color: #202020;font-family: Arial;font-size: 34px;font-weight: bold;line-height: 100%;padding: 0;text-align: center;vertical-align: middle;} ")
            builder.Append("        .bodyContent div{color: #505050;font-family: Arial;font-size: 14px;line-height: 150%;text-align: left;} ")
            builder.Append("        .bodyContent div a:link, .bodyContent div a:visited, .bodyContent div a .yshortcuts{color: #31A79C;font-weight: bold; text-decoration: underline;} ")
            builder.Append("        .footerContent div{color: #707070;font-family: Arial;font-size: 12px;line-height: 125%;text-align: left;} ")
            builder.Append("        .footerContent img{display: inline;text-align: center;}  ")
            builder.Append("        body{margin: 0; padding: 0;} ")
            builder.Append("        #outlook a{padding: 0;}")
            builder.Append("        body{ width: 100% !important;}")
            builder.Append("        .ReadMsgBody{width: 100%;}")
            builder.Append("        .ExternalClass{width: 100%;}")
            builder.Append("        body{-webkit-text-size-adjust: none;}")
            builder.Append("        img{border: 0;height: auto;line-height: 100%;outline: none;text-decoration: none;}")
            builder.Append("        Table td{border-collapse: collapse;}")
            builder.Append("        #templateBody{width: 656px;}")
            builder.Append("        .color_font{color: #31A79C;text-decoration: none; font-weight:bold;}")
            builder.Append("        .letra_texto{font-size: 12px;font-family: Arial, Helvetica, sans-serif;color: #3f4042;padding-bottom:20px;}")
            builder.Append("        .tipo_border{ border: solid 1px #cccccc;-webkit-border-radius: 5px;-moz-border-radius: 5px;border-radius: 5px;}")
            builder.Append("        .codigobarra{color: #000; font-size: 20px !important; font-family: ""39251"" !important; font-weight:normal !important;}")
            builder.Append("        .codigoorden{color: #000; font-size: 14px !important; font-weight:normal !important;}")
            builder.Append("    </style>")
            builder.Append("    </head>")
            builder.Append("    <body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">")
            builder.Append("    	<center>")
            builder.Append("        	<table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""backgroundTable"">")
            builder.Append("            	<tr>")
            builder.Append("                <td align=""center"" valign=""top"">")
            builder.Append("                		<table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""600"" id=""templatePreheader"">")
            builder.Append("                            <tr>")
            builder.Append("                                <td valign=""top"" class=""preheaderContent"">")
            builder.Append("                                    <table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""100%"">")
            builder.Append("                                        <tr>")
            builder.Append("                                            <td valign=""top"">")
            builder.Append("                                            </td>")
            builder.Append("                                            <td valign=""top"" width=""190"">")
            builder.Append("                                            </td>")
            builder.Append("                                        </tr>")
            builder.Append("                                    </table>")
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                        </table>")
            builder.Append("                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"">")
            builder.Append("                       	    <tr>")
            builder.Append("                            	<td align=""center"" valign=""top"">")
            builder.Append("                                	<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateHeader"">")
            builder.Append("                                    	<tr>")
            builder.Append("                                        	<td class=""headerContent"">")
            builder.Append("                                            	<img src=""http://www.hunter.com.ec/img/LogoHunterOnlineEamil.png""")
            builder.Append("                                                	style=""max-width: 800px;""id=""headerImage campaign-icon"" mc:label=""header_image"" mc:edit=""header_image""")
            builder.Append("                                                    mc:allowdesigner mc:allowtext />")
            builder.Append("                                                <div style=""width:100%; height:35px; background-color:#EBEBEB; margin-top:0px; border:none;"">")
            builder.Append("                                                	<div style=""text-align:right; font-size:17px; color:#474747;height:35px;"">")
            If mailCreacion Then
                builder.Append("                                                                AVISO DE RESERVACIÓN DE TURNOS &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp")
            ElseIf actualizacion Then
                builder.Append("                                                                AVISO DE ACTUALIZACIÓN DE TURNOS &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp")
            ElseIf Not mailCreacion Then
                builder.Append("                                                                AVISO DE CANCELACIÓN DE TURNOS &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp")
            End If
            builder.Append("                                                    </div>")
            builder.Append("                                                </div>")
            builder.Append("                                            </td>")
            builder.Append("                                      	</tr>")
            builder.Append("                                  	</table>")
            builder.Append("                              	</td>")
            builder.Append("                         	</tr>")
            builder.Append("                            <tr>")
            builder.Append("                            	<td align=""center"" valign=""top"">")
            builder.Append("                                	<table border=""0"" cellpadding=""0"" cellspacing=""0"" id=""templateBody"">")
            builder.Append("                                    	<tr>")
            builder.Append("                                        	<td valign=""top"">")
            builder.Append("                                            	<table border=""0"" cellpadding=""0"" cellspacing=""0"">")
            builder.Append("                                                    <tr>")
            builder.Append("                                                        <td valign=""top"" class=""bodyContent"">")
            builder.Append("                                                            <table border=""0"" cellpadding=""20"" cellspacing=""0"" style=""width: 95%"">")
            builder.Append("                                                                <tr>")
            builder.Append("                                                                    <td valign=""top"">")
            builder.Append("                                                                        <div mc:edit=""std_content00""><br />")
            builder.Append("                                                                            <p>")
            'builder.Append("                                                                                Estimado Sr(a): ")
            builder.Append("                                                                                Estimado/a cliente, ")
            'builder.Append("                                                                                ").Append(HttpContext.Current.Session("display_name").ToString())
            builder.Append("                                                                                " & encriptado)
            builder.Append("                                                                            </p>")
            If mailCreacion Then
                ' builder.Append("                                                                            Gracias por utilizar nuestro servicio en línea, confirmamos su reservación del turno para realizar su <strong>Chequeo Express</strong>,  Por favor imprima el documento adjunto a este correo y el día de su cita preséntelo al asesor de servicio (original y copia), para una mejor atención es preferible que asista 5 minutos antes de la hora establecida.")
                'builder.Append("                                                                            Gracias por utilizar nuestro servicio en línea, confirmamos su reservación del turno para realizar su <strong>Chequeo Express</strong>,  por favor descargue el documento adjunto en este correo en su dispositivo móvil y el día de su cita preséntelo al asesor de servicio, para una mejor atención es preferible que asista 5 minutos antes de la hora establecida.")
                builder.Append("                                                                          Gracias por utilizar nuestro servicio de reservación de turnos.  Confirmamos que para realizar su <strong>" & tipo_turno & "</strong>,  tenemos el siguiente cupo reservado para usted:")
            ElseIf actualizacion Then
                builder.Append("                                                                            Gracias por utilizar nuestro servicio en línea, confirmamos su modificación del turno para realizar su <strong>" & tipo_turno & "</strong>,  Por favor imprima el documento adjunto a este correo y el día de su cita preséntelo al asesor de servicio (original y copia), para una mejor atención es preferible que asista 5 minutos antes de la hora establecida.")
            ElseIf Not mailCreacion Then
                builder.Append("                                                                            Gracias por utilizar nuestro servicio en línea, confirmamos su eliminación del turno.")
            End If
            builder.Append("                                                                            <br />")
            builder.Append("                                                                            <br />")
            builder.Append("                                                                            <div style=""text-align:left; font-size:12px; margin:7px 60px 0px 0px; color:#474747;"">")
            builder.Append("                                                                                <strong>")
            builder.Append("                                                                                Confirmación de turno # " & idTurno)
            builder.Append("                                                                                </strong>")
            builder.Append("                                                                            </div>")
            builder.Append("                                                                            <table border=""0"" bordercolor=""#FFFFFF"" style=""width: 650px; border-width:0px; border-style:none; font-size:13px; background-color:#F2F2F2; border-radius:5px; margin:15px 0px 0px 0px;"">")
            builder.Append("                                                                               <tr>")
            builder.Append("                                                                                    <td width=""180"" style=""color: #474747; text-align:right; padding-bottom:5px;"")>")
            builder.Append("                                                                                        <strong>")
            builder.Append("                                                                                            Vehículo &nbsp; ")
            builder.Append("                                                                                        </strong>")
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                                    <td width=""370"" class=""letra_texto"" style=""padding-bottom:5px;"">")
            builder.Append("                                                                                        ").Append(placa)
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                               </tr>")
            builder.Append("                                                                               <tr>")
            builder.Append("                                                                                    <td width=""180"" style=""color: #474747; text-align:right; padding-bottom:5px;"">")
            builder.Append("                                                                                        <strong>")
            builder.Append("                                                                                            Fecha y Hora de atención &nbsp;")
            builder.Append("                                                                                        </strong>")
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                                    <td width=""370"" class=""letra_texto"" style=""padding-bottom:5px;"">")
            builder.Append("                                                                                        ").Append(fecha.Replace(":", "H"))
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                               </tr>")
            builder.Append("                                                                               <tr>")
            builder.Append("                                                                                    <td width=""180"" style=""color: #474747; text-align:right; padding-bottom:5px;"">")
            builder.Append("                                                                                        <strong>")
            builder.Append("                                                                                            Lugar de atención &nbsp;")
            builder.Append("                                                                                        </strong>")
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                                    <td width=""370"" class=""letra_texto"" style=""padding-bottom:5px;"">")
            builder.Append("                                                                                        ").Append(tallerDireccion)
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                               </tr>")
            builder.Append("                                                                               <tr>")
            builder.Append("                                                                                    <td width=""180"" style=""color: #474747; text-align:right; padding-bottom:5px;"">")
            builder.Append("                                                                                        <strong>")
            builder.Append("                                                                                            Taller de atención &nbsp; ")
            builder.Append("                                                                                        </strong>")
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                                    <td width=""370"" class=""letra_texto"" style=""padding-bottom:5px;"">")
            builder.Append("                                                                                        ").Append(taller)
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                               </tr>")
            builder.Append("                                                                               <tr>")
            builder.Append("                                                                                    <td width=""180"" style=""color: #474747; text-align:right; padding-bottom:5px;"">")
            builder.Append("                                                                                        <strong>")
            builder.Append("                                                                                            Orden de Servicio &nbsp; ")
            builder.Append("                                                                                        </strong>")
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                                    <td width=""370"" class=""letra_texto"" style=""padding-bottom:5px;"">")
            builder.Append("                                                                                        <span class=""codigoorden"">").Append(orden)
            builder.Append("                                                                                        </span> &nbsp &nbsp <span class=""codigobarra"">").Append(orden)
            builder.Append("                                                                                        </span></div>")
            builder.Append("                                                                                    </td>")
            builder.Append("                                                                               </tr>")
            builder.Append("                                                                            </table>  ")
            builder.Append("                                                                            <br />")
            builder.Append("                                                                            <br />")
            builder.Append("                                                                            <em>")
            builder.Append("                                                                                Recuerde, si desea modificar o cancelar su turno, lo puede realizar mínimo con 24 horas de anticipación, ingresando con su usuario y contraseña al sitio web www.hunteronline.com.ec en la sección bienes protegidos.<br /><br />")
            builder.Append("                                                                                Este correo ha sido generado automáticamente, por favor no responder al mismo.")
            builder.Append("                                                                                <br /><br /><br />")
            builder.Append("                                                                                Documento creado el ").Append(Date.Now.ToString("dd/MMM/yyyy HH:mm").Replace(":", "H"))
            builder.Append("                                                                            </em>")
            builder.Append("                                                                        </div>")
            builder.Append("                                                                    </td>")
            builder.Append("                                                                </tr>")
            builder.Append("                                                            </table>")
            builder.Append("                                                        </td>")
            builder.Append("                                                    </tr>")
            builder.Append("                                     		    </table>")
            builder.Append("                                  		    </td>")
            builder.Append("                               		    </tr>")
            builder.Append("                          		    </table>")
            builder.Append("                           	    </td>")
            builder.Append("                     	    </tr>")
            builder.Append("                   	    </table>")
            builder.Append("                        <br />")
            builder.Append("          		    </td>")
            builder.Append("           	    </tr>")
            builder.Append("      	    </table>")
            builder.Append("	    </center>")
            builder.Append("    </body> ")
            builder.Append("</html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 15/08/2014
    ''' DESCR: CONSULTA COREO CLIENTE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConsultaCorreo(ByVal clienteid As String) As String
        ConsultaCorreo = ""
        Try
            Dim dtDatosCorreo As DataSet
            dtDatosCorreo = ContactosAdapter.ConsultaCorreo(clienteid)
            If dtDatosCorreo.Tables(0).Rows.Count > 0 Then
                ConsultaCorreo = dtDatosCorreo.Tables(0).Rows(0)("MAIL")
            Else
                ConsultaCorreo = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Private Function ConsultaCorreoEjecutiva(ByVal Vehiculo As String) As String
        ConsultaCorreoEjecutiva = ""
        Try
            Dim dtDatosCorreo As DataSet
            dtDatosCorreo = ContactosAdapter.ConsultaCorreoEjecutiva(Vehiculo)
            If dtDatosCorreo.Tables(0).Rows.Count > 0 Then
                ConsultaCorreoEjecutiva = dtDatosCorreo.Tables(0).Rows(0)("MAIL")
            Else
                ConsultaCorreoEjecutiva = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function


    Private Function EncriptaCliente(ByVal clienteid As String) As String
        EncriptaCliente = ""
        Try
            Dim dtDatosCliente As DataSet
            dtDatosCliente = ContactosAdapter.ConsultaCorreo(clienteid)
            If dtDatosCliente.Tables(0).Rows.Count > 0 Then
                EncriptaCliente = dtDatosCliente.Tables(0).Rows(0)("ENCRIPTA")
            Else
                EncriptaCliente = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 27/07/2014
    ''' DESCR: CONSULTA RUTA DONDE SE ALOJARA EL ARCHIVO DE RECEPCION TEMPORAL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConsultaRuta() As String
        ConsultaRuta = ""
        Try
            Dim androidTurnos As New VehiculoTurnoAdapter
            ConsultaRuta = androidTurnos.ConsultaRuta()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Public Sub MailAvisoBaja(ByVal cliente As String, vehiculo As String, nuevo_cliente As String, telefono As String)
        Try
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            Dim correo As String = ConsultaCorreoEjecutiva(vehiculo)
            Dim aplicacion As String = HttpContext.Current.Application("soporteextranet")
            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True

            Dim mailToCollection As [String]() = correo.Split(";")
            For Each mailToo As String In mailToCollection
                If EMailHandler.ValidarEMail(mailToo) Then
                    mailMessage.To.Add(mailToo)
                End If
            Next

            Dim mailcco As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc")
            Dim mailToCollectionCco As [String]() = mailcco.Split(";")
            For Each mailTo As String In mailToCollectionCco
                mailMessage.Bcc.Add(mailTo)
            Next

            mailMessage.Subject = "Solicitud de baja de vehículo"
            mailMessage.Body = MailBodyBaja(cliente, vehiculo, nuevo_cliente, telefono)
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function MailBodyBaja(cliente As String, vehiculo As String, nuevopropietario As String, celular As String) As String
        Dim builder As New StringBuilder()

        Try
            builder.Append("<html>")
            builder.Append("    <head>")
            builder.Append("        <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">")
            builder.Append("        <title>Has ingresado a HunterOnline</title>")
            builder.Append("        <style type=""text/css"">")
            builder.Append("            .divprincipal{background-color: #F2F2F2; font-size: 14px; font-weight:normal; width:658px; display:block; height:auto;}")
            builder.Append("			.divcontenedor{background-color:#fff; width:650px; height:auto; display:block;}")
            builder.Append("			.divtitulo{font-size:2em; color:#333; padding:25px 0 0 10px;}")
            builder.Append("			.divseparador{background-color: #F2F2F2; height:1px; margin:25px 100px 5px 100px;}")
            builder.Append("			.divdatos{font-size:1.2em; padding-left:150px; padding-right:150px; margin:25px;}")
            builder.Append("			.divdatosc1{color:#333; text-align:left; width:175px;}")
            builder.Append("			.divdatosc2{color:#999; text-align:right;width:175px;}")
            builder.Append("			.divinfo{font-size:1em; margin:15px; background-color:#FFFFCC; color:#09F; width:450px; height:30px;}")
            builder.Append("        </style>")
            builder.Append("    </head>")
            builder.Append("	<body>")
            builder.Append("		<center>")
            builder.Append("			<div class=""divprincipal"">")
            builder.Append("				<img src=""https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/HOCABECERAMAIL.png""/>")
            builder.Append("                <div class=""divcontenedor"">")
            builder.Append("                    <div class=""divtitulo"">")
            builder.Append("                        Solicitud de baja de vehículo")
            builder.Append("                    </div>")
            builder.Append("                    <div class=""divseparador"">")
            builder.Append("                	</div>")
            builder.Append("                    <div class=""divdatos"">")
            builder.Append("                        <table class=""tftable"" border=""0"">")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Vehículo:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & vehiculo)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Cliente:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & cliente)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Fecha:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & Date.Now.ToShortDateString)
            builder.Append("                                </td>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Hora:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & Date.Now.ToShortTimeString)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Nuevo cliente indicado:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & nuevopropietario)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Contacto indicado:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & celular)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                        </table>")
            builder.Append("                	</div>")
            builder.Append("                    <br	/><br	/><br	/><br	/>")
            builder.Append("                    <div class=""divseparador"">")
            builder.Append("                	</div>")
            builder.Append("                    <div class=""divinfo"">")
            builder.Append("                     	Requerimiento impulsado por el cliente desde Hunter Online.")
            builder.Append("                	</div>")
            builder.Append("                    <div class=""divseparador"">")
            builder.Append("                	</div>")
            builder.Append("                </div>")
            builder.Append("				<img src=""https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/HOPIEMAIL.png""/>")
            builder.Append("			</div>")
            builder.Append("    	</center>")
            builder.Append("	</body> ")
            builder.Append("</html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function

    Public Sub MailAvisoIngreso(ByVal cliente As String, navegador As String)
        Try
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            Dim correo As String = ConsultaCorreo(cliente)
            Dim aplicacion As String = HttpContext.Current.Application("soporteextranet")

            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            If correo.IndexOf(",") > 0 Then
                correo = correo.Substring(0, correo.IndexOf(","))
            End If
            Dim mailAddressto As New MailAddress(correo)
            mailMessage.To.Add(mailAddressto)
            'Dim mailcco As String = aplicacion
            'Dim mailToCollectionCco As [String]() = mailcco.Split(",")
            'For Each mailTo As String In mailToCollectionCco
            '    mailMessage.Bcc.Add(mailTo)
            'Next
            mailMessage.Subject = "Has ingresado a HunterOnline"
            mailMessage.Body = MailBodyIngreso(cliente, navegador)
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function MailBodyIngreso(cliente As String, navegador As String) As String
        Dim builder As New StringBuilder()
        
        Try
            builder.Append("<html>")
            builder.Append("    <head>")
            builder.Append("        <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">")
            builder.Append("        <title>Has ingresado a HunterOnline</title>")
            builder.Append("        <style type=""text/css"">")
            builder.Append("            .divprincipal{background-color: #F2F2F2; font-size: 14px; font-weight:normal; width:658px; display:block; height:auto;}")
            builder.Append("			.divcontenedor{background-color:#fff; width:650px; height:auto; display:block;}")
            builder.Append("			.divtitulo{font-size:2em; color:#333; padding:25px 0 0 10px;}")
            builder.Append("			.divseparador{background-color: #F2F2F2; height:1px; margin:25px 100px 5px 100px;}")
            builder.Append("			.divdatos{font-size:1.2em; padding-left:150px; padding-right:150px; margin:25px;}")
            builder.Append("			.divdatosc1{color:#333; text-align:left; width:175px;}")
            builder.Append("			.divdatosc2{color:#999; text-align:right;width:175px;}")
            builder.Append("			.divinfo{font-size:1em; margin:15px; background-color:#FFFFCC; color:#09F; width:450px; height:30px;}")
            builder.Append("        </style>")
            builder.Append("    </head>")
            builder.Append("	<body>")
            builder.Append("		<center>")
            builder.Append("			<div class=""divprincipal"">")
            builder.Append("				<img src=""https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/HOCABECERAMAIL.png""/>")
            builder.Append("                <div class=""divcontenedor"">")
            builder.Append("                    <div class=""divtitulo"">")
            builder.Append("                        ¡Ingreso Exitoso!")
            builder.Append("                    </div>")
            builder.Append("                    <div class=""divseparador"">")
            builder.Append("                	</div>")
            builder.Append("                    <div class=""divdatos"">")
            builder.Append("                        <table class=""tftable"" border=""0"">")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Tipo de acceso:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & navegador)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Cliente:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & encripta_cedula(cliente))
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Fecha:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & Date.Now.ToShortDateString)
            builder.Append("                                </td>")
            builder.Append("                            <tr>")
            builder.Append("                                <td class=""divdatosc1"">")
            builder.Append("                                    Hora:")
            builder.Append("                                </td>")
            builder.Append("                                <td class=""divdatosc2"">")
            builder.Append("                                    " & Date.Now.ToShortTimeString)
            builder.Append("                                </td>")
            builder.Append("                            </tr>")
            builder.Append("                        </table>")
            builder.Append("                	</div>")
            builder.Append("                    <br	/><br	/><br	/><br	/>")
            builder.Append("                    <div class=""divseparador"">")
            builder.Append("                	</div>")
            builder.Append("                    <div class=""divinfo"">")
            builder.Append("                     	Si usted no realizó este ingreso, por favor comuníquese con nosotros.")
            builder.Append("                	</div>")
            builder.Append("                    <div class=""divseparador"">")
            builder.Append("                	</div>")
            builder.Append("                </div>")
            builder.Append("				<img src=""https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/HOPIEMAIL.png""/>")
            builder.Append("			</div>")
            builder.Append("    	</center>")
            builder.Append("	</body> ")
            builder.Append("</html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function

    Public Sub MailAvisoAprobacion(ByVal cliente As String, ByVal vehiculo As String)
        Try
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            Dim correo As String = ConsultaCorreo(cliente)

            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            If correo.IndexOf(",") > 0 Then
                correo = correo.Substring(0, correo.IndexOf(","))
            End If
            Dim mailAddressto As New MailAddress(correo)
            mailMessage.To.Add(mailAddressto)
            'Dim mailcco As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc")
            'Dim mailToCollectionCco As [String]() = mailcco.Split(",")
            'For Each mailTo As String In mailToCollectionCco
            '    mailMessage.Bcc.Add(mailTo)
            'Next
            mailMessage.Subject = "Usted tiene un precio aprobado en HunterOnline"
            mailMessage.Body = MailBodyAprobado(cliente, vehiculo)
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function MailBodyAprobado(ByVal cliente As String, ByVal vehiculo As String) As String
        Dim builder As New StringBuilder()
        Dim nombrecliente As String = EncriptaCliente(cliente)
        Dim fecha As String = FormatDateTime(Date.Now, DateFormat.ShortDate) & _
                            " " & FormatDateTime(Date.Now, DateFormat.ShortTime).Replace(":", "H")
        builder.Append("<html>")
        builder.Append("    <head>")
        builder.Append("    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">")
        builder.Append("    <title>")
        builder.Append("		Aprobación de precios desde HunterOnline")
        builder.Append("    </title>")
        builder.Append("    <style type=""text/css"">")
        builder.Append("        .headerContent{color: #202020;font-family: Arial;font-size: 34px;font-weight: bold;line-height: 100%;padding: 0;text-align: center;vertical-align: middle;} ")
        builder.Append("        .bodyContent div{color: #505050;font-family: Arial;font-size: 14px;line-height: 150%;text-align: left;} ")
        builder.Append("        .bodyContent div a:link, .bodyContent div a:visited, .bodyContent div a .yshortcuts{color: #31A79C;font-weight: bold; text-decoration: underline;} ")
        builder.Append("        .footerContent div{color: #707070;font-family: Arial;font-size: 12px;line-height: 125%;text-align: left;} ")
        builder.Append("        .footerContent img{display: inline;text-align: center;}  ")
        builder.Append("        body{margin: 0; padding: 0;} ")
        builder.Append("        #outlook a{padding: 0;}")
        builder.Append("        body{ width: 100% !important;}")
        builder.Append("        .ReadMsgBody{width: 100%;}")
        builder.Append("        .ExternalClass{width: 100%;}")
        builder.Append("        body{-webkit-text-size-adjust: none;}")
        builder.Append("        img{border: 0;height: auto;line-height: 100%;outline: none;text-decoration: none;}")
        builder.Append("        Table td{border-collapse: collapse;}")
        builder.Append("        #templateBody{width: 656px;}")
        builder.Append("        .color_font{color: #31A79C;text-decoration: none; font-weight:bold;}")
        builder.Append("        .letra_texto{font-size: 12px;font-family: Arial, Helvetica, sans-serif;color: #3f4042;padding-bottom:20px;}")
        builder.Append("        .tipo_border{ border: solid 1px #cccccc;-webkit-border-radius: 5px;-moz-border-radius: 5px;border-radius: 5px;}")
        builder.Append("    </style>")
        builder.Append("    </head>")
        builder.Append("    <body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">")
        builder.Append("    	<center>")
        builder.Append("        	<table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""backgroundTable"">")
        builder.Append("            	<tr>")
        builder.Append("                <td align=""center"" valign=""top"">")
        builder.Append("                		<table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""600"" id=""templatePreheader"">")
        builder.Append("                            <tr>")
        builder.Append("                                <td valign=""top"" class=""preheaderContent"">")
        builder.Append("                                    <table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""100%"">")
        builder.Append("                                        <tr>")
        builder.Append("                                            <td valign=""top"">")
        builder.Append("                                            </td>")
        builder.Append("                                            <td valign=""top"" width=""190"">")
        builder.Append("                                            </td>")
        builder.Append("                                        </tr>")
        builder.Append("                                    </table>")
        builder.Append("                                </td>")
        builder.Append("                            </tr>")
        builder.Append("                        </table>")
        builder.Append("                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"">")
        builder.Append("                       	    <tr>")
        builder.Append("                            	<td align=""center"" valign=""top"">")
        builder.Append("                                	<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateHeader"">")
        builder.Append("                                    	<tr>")
        builder.Append("                                        	<td class=""headerContent"">")
        builder.Append("                                            	<img src=""http://www.hunter.com.ec/img/LogoHunterOnlineEamil.png""")
        builder.Append("                                                	style=""max-width: 800px;""id=""headerImage campaign-icon"" mc:label=""header_image"" mc:edit=""header_image""")
        builder.Append("                                                    mc:allowdesigner mc:allowtext />")
        builder.Append("                                                <div style=""width:100%; height:35px; background-color:#EBEBEB; margin-top:0px; border:none;"">")
        builder.Append("                                                	<div style=""text-align:right; font-size:17px; color:#474747;height:35px;"">")
        builder.Append("														Precio Preferencial")
        builder.Append("                                                    </div>")
        builder.Append("                                                </div>")
        builder.Append("                                            </td>")
        builder.Append("                                      	</tr>")
        builder.Append("                                  	</table>")
        builder.Append("                              	</td>")
        builder.Append("                         	</tr>")
        builder.Append("                            <tr>")
        builder.Append("                            	<td align=""center"" valign=""top"">")
        builder.Append("                                	<table border=""0"" cellpadding=""0"" cellspacing=""0"" id=""templateBody"">")
        builder.Append("                                    	<tr>")
        builder.Append("                                        	<td valign=""top"">")
        builder.Append("                                            	<table border=""0"" cellpadding=""0"" cellspacing=""0"">")
        builder.Append("                                                    <tr>")
        builder.Append("                                                        <td valign=""top"" class=""bodyContent"">")
        builder.Append("                                                            <table border=""0"" cellpadding=""20"" cellspacing=""0"" style=""width: 95%"">")
        builder.Append("                                                                <tr>")
        builder.Append("                                                                    <td valign=""top"">")
        builder.Append("                                                                        <div mc:edit=""std_content00""><br />")
        builder.Append("                                                                            <p>")
        builder.Append("                                                                                Estimado/a cliente, " & nombrecliente)
        builder.Append("                                                                            <br /><br />")
        builder.Append("                                                                             Gracias por preferir nuestros productos, lo invitamos muy cordialmente a realizar la renovación de su servicio. <br /> Se le ha otorgado un descuento especial, por favor ingrese a nuestro portal de servicios <a href=""https://www.hunteronline.com.ec"">www.hunteronline.com.ec</a>, tenemos un exelente precio para usted.")
        builder.Append("                                                                            </p> ")
        builder.Append("                                                                            <br />")
        builder.Append("                                                                            <br />")
        builder.Append("                                                                            <table border=""0"" bordercolor=""#FFFFFF"" style=""width: 650px; border-width:0px; border-style:none; font-size:13px; background-color:#F2F2F2; border-radius:5px; margin:15px 0px 0px 0px;"">")
        builder.Append("                                                                               <tr>")
        builder.Append("                                                                                    <td width=""180"" style=""color: #474747; text-align:right; padding-bottom:5px;"">")
        builder.Append("                                                                                        <strong>")
        builder.Append("                                                                                            Vehículo(s) &nbsp; ")
        builder.Append("                                                                                        </strong>")
        builder.Append("                                                                                    </td>")
        builder.Append("                                                                                    <td width=""370"" class=""letra_texto"" style=""padding-bottom:5px;"">")
        builder.Append("                                                                                    " & vehiculo)
        builder.Append("                                                                                    </td>")
        builder.Append("                                                                               </tr>")
        builder.Append("                                                                            </table>")
        builder.Append("                                                                            <br />")
        builder.Append("                                                                            <br />")
        builder.Append("                                                                            <em>")
        builder.Append("                                                                                Este correo ha sido generado automáticamente, por favor no responder al mismo.")
        builder.Append("                                                                                <br /><br /><br />")
        builder.Append("                                                                                Documento creado el " & fecha)
        builder.Append("                                                                            </em>")
        builder.Append("                                                                        </div>")
        builder.Append("                                                                    </td>")
        builder.Append("                                                                </tr>")
        builder.Append("                                                            </table>")
        builder.Append("                                                        </td>")
        builder.Append("                                                    </tr>")
        builder.Append("                                     		    </table>")
        builder.Append("                                  		    </td>")
        builder.Append("                               		    </tr>")
        builder.Append("                          		    </table>")
        builder.Append("                           	    </td>")
        builder.Append("                     	    </tr>")
        builder.Append("                   	    </table>")
        builder.Append("                        <br />")
        builder.Append("          		    </td>")
        builder.Append("           	    </tr>")
        builder.Append("      	    </table>")
        builder.Append("	    </center>")
        builder.Append("    </body> ")
        builder.Append("</html>")



    End Function

    Private Function encripta_cedula(cliente As String)
        Dim retorno As String = ""

        If cliente.Length >= 10 Then
            retorno = cliente.Remove(3, cliente.Length - 5)
            retorno = retorno.Insert(3, IIf(cliente.Length > 10, "********", "*****"))
        Else
            retorno = cliente.Remove(2, 3)
            retorno = retorno.Insert(2, "***")
        End If

        Return retorno
    End Function

    Public Function EnvioEmailLinkPago(ByVal ordenId As String, link As String) As String
        EnvioEmailLinkPago = ""
        Try
            Dim emailBody As String
            Dim emailAddres As String
            Dim dTCstGeneral As New System.Data.DataSet

            dTCstGeneral = RenovacionAdapter.ConsultaEmailLink(ordenId, link)
            emailBody = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("HTMLBODY"))
            emailAddres = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("BILLINGEMAIL"))
            EMailHandler.EMailLink(emailBody, emailAddres)
        Catch ex As Exception
            EnvioEmailLinkPago = "Ocurrió un error al enviar el email de confirmación"
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

End Class
