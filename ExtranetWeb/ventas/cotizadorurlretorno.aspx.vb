'Imports PlugInClient
'Imports System.Net.Mail

Public Class cotizadorurlretorno
    Inherits System.Web.UI.Page


    'Public firmaCorrecta As Boolean
    'Public plugInClientRecive As PlugInClientRecive
    'Dim aut_value_final As String
    'Dim tNo_value_final As String
    'Dim TransaccionID As String
    'Dim TransaccionValue As String
    'Dim Referencia1 As String
    'Dim Referencia2 As String
    'Dim Referencia3 As String
    'Dim Referencia4 As String
    'Dim Referencia5 As String
    'Dim TaxValue1 As String
    'Dim TaxValue2 As String
    'Dim TipValue As String
    'Dim codigoError As String
    'Dim codigoDesc As String
    'Dim estadoAutorizacion As String
    'Dim value_actestadoorden As Integer
    'Dim opcion As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                EMailHandler.EMailProcesoPago("EMAIL 6 ºº RETORNO // Dinners", Nothing, Session("iphost"), Session("iphost"))
                'Dim mensaje As String = Request.QueryString("resultado")
                'Dim idmensaje As String = Request.QueryString("codigo")
                'Dim confirmacion As String = Request.QueryString("confirmacion")

                'If mensaje <> Nothing Then
                '    If idmensaje = 0 Then
                '        ProveedorMensaje.ShowMessage(rntMensajes, mensaje, ProveedorMensaje.MessageStyle.OperacionExitosa)
                '    ElseIf idmensaje = 1 Then
                '        ProveedorMensaje.ShowMessage(rntMensajes, mensaje, ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    ElseIf idmensaje = 2 Then
                '        ProveedorMensaje.ShowMessage(rntMensajes, mensaje, ProveedorMensaje.MessageStyle.AvisoImportante)
                '    End If
                'End If

                'Dim jsonhttp As Object
                'jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
                'jsonhttp.open("POST", url, False)
                'jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
                'jsonhttp.setRequestHeader("Content-Type", "application/json")
                ''jsonhttp.setRequestHeader("Auth-Token", auth_token)
                'jsonhttp.send(jsonData)
                'objXmlHttp = jsonhttp.Responsetext
                'Dim respuestaHTTP As String = objXmlHttp.ToString
                'Dim requestid As String = descompone_retorno("requestId", respuestaHTTP)
                'Dim processUrl As String = descompone_retorno("processUrl", respuestaHTTP)
                'processUrl = processUrl.Replace("\", "").Replace("https", "https:")
                'Dim status As String = descompone_retorno("status", respuestaHTTP)
                'jsonhttp = Nothing
                'If processUrl <> "" And status = "OK" Then
                '    Response.Redirect(processUrl)
                'Else
                '    MostrarMensaje("No se ha podido enlazar con el banco emisor")
                'End If


                Dim DTSetInfoURLTecnico As New DataTable()
                DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
                Dim cedula As String = DTSetInfoURLTecnico.Rows(1)("datatecnica")
                Dim document As String = cedula
                Dim name As String = DTSetInfoURLTecnico.Rows(2)("datatecnica")
                Dim email As String = DTSetInfoURLTecnico.Rows(5)("datatecnica")
                Dim documentType As String = "CC"
                Dim mobile As String = DTSetInfoURLTecnico.Rows(4)("datatecnica")
                Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
                Dim iva_porcentaje As String = OrdenPagoAdapter.ConsultaPorcentajeIva
                Dim total As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
                Dim subtotal As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
                Dim orden As String = DTSetInfoURLTecnico.Rows(0)("datatecnica")

                lblordenpago.Text = orden
                lblcotizacion.Text = orden
                lblnombre.Text = name
                lblidentificacion.Text = cedula
                lblsubtotal.Text = subtotal
                lbltotal.Text = total
                lbliva.Text = iva
                'lblcodcnfpago.Text = confirmacion



                'EMailHandler.EMailProcesoPago("EMAIL 6 ºº RETORNO // Dinners", Nothing, Session("iphost"), Session("iphost"))
                'Dim vector As String = Libreria.ReadFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyVector").ToString()))
                'Dim xmlGenerateKey As String = Request.Params("XMLGENERATEKEY")
                'plugInClientRecive = New PlugInClientRecive()
                'plugInClientRecive.setIV(vector)
                'plugInClientRecive.setSignPublicKey(RSAEncryption.readFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPublicaFirmaInterDin").ToString())))
                'plugInClientRecive.setCipherPrivateKeyFromFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPrivadaCifradoEstablecimiento").ToString()))
                'plugInClientRecive.setXMLGENERATEKEY(xmlGenerateKey)
                'Dim cadeEnc As String = Request.Params("XMLRESPONSE")
                ''JCOLOMA        17/02/2014      LINEA ADICIONAL PARA ENVIAR MSG POR EMAIL
                'EMailHandler.EMailProcesoPago("EMAIL 7 ºº RETORNO // " & cadeEnc, Nothing, Session("iphost"), Session("iphost"))
                'firmaCorrecta = plugInClientRecive.XMLProcess(cadeEnc, Request.Params("XMLDIGITALSIGN"))
                'TransaccionID = plugInClientRecive.getTransacctionID()
                'TransaccionValue = plugInClientRecive.getTransacctionValue
                'TaxValue1 = plugInClientRecive.getTaxValue1
                'TaxValue2 = plugInClientRecive.getTaxValue2
                'TipValue = plugInClientRecive.getTipValue
                'Referencia1 = plugInClientRecive.getReferencia1
                'Referencia2 = plugInClientRecive.getReferencia2
                'Referencia3 = plugInClientRecive.getReferencia3
                'Referencia4 = plugInClientRecive.getReferencia4
                'Referencia5 = plugInClientRecive.getReferencia5
                'codigoError = plugInClientRecive.getErrorCode
                'codigoDesc = plugInClientRecive.getErrorDetails
                'estadoAutorizacion = plugInClientRecive.getAuthorizationState
                'Me.lbltaxvalue2.Text = TaxValue2
                'Me.lblreferencia1.Text = Referencia1
                'Me.lblreferencia2.Text = Referencia2
                'Me.lblreferencia3.Text = Referencia3
                'Me.lblreferencia4.Text = Referencia4
                'Me.lblreferencia5.Text = Referencia5
                'Me.lblestadoautorizacion.Text = estadoAutorizacion
                'tNo_value_final = TransaccionID
                ''JCOLOMA        17/02/2014      LINEA ADICIONAL PARA ENVIAR MSG POR EMAIL
                'EMailHandler.EMailProcesoPago("EMAIL 8 ºº RETORNO// " & codigoError & "//" & codigoDesc, Nothing, Session("iphost"), Session("iphost"))
                'opcion = 3
                'value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(opcion, estadoAutorizacion, aut_value_final, tNo_value_final, 0, "", 0, 0, 0, 0, "", "")
                'If estadoAutorizacion = "Y" Then
                '    Session("DTCarroCompraMasterTableView") = Nothing
                '    Try
                '        Dim DTSetInfoURLTecnico As New DataTable()
                '        DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
                '        Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
                '        If accion = "REN" Then
                '            RenovacionAdapter.GeneraOrdenServicio(tNo_value_final)
                '            Promocion()
                '        ElseIf accion = "VEN" Then
                '            Dim taller As Integer = DTSetInfoURLTecnico.Rows(14)("datatecnica")
                '            Dim fecha As Date = DTSetInfoURLTecnico.Rows(15)("datatecnica")
                '            Dim hora As String = DTSetInfoURLTecnico.Rows(16)("datatecnica")

                '            VentasAdapter.GeneraOrdenServicio(tNo_value_final, hora, fecha, taller)
                '        End If
                '    Catch ex As Exception
                '        ExceptionHandler.Captura_Error(ex, " **ERROR AL GENERAR O/S DEL SH CON PAGO Nº." + tNo_value_final + "** ")
                '    End Try

                '    Me.BtnVerPago.Visible = True
                '    Me.lbltitulo.Text = "Transacción Exitosa"

                '    Dim objmail As New MailTrabajos
                '    lblemailresult.Text = objmail.EnvioEmailConfirmaciónPago(100, CType(tNo_value_final, Decimal))
                '    'EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))

                '    Me.lblemailresult.Text = "Envío de email de confirmación satisfactorio"
                '    Me.imageResultado.ImageUrl = "~/images/icons/24x24/pagoOk.png"
                '    Me.imageResultado.Visible = True
                '    Try
                '        FormularioAdapter.RegistroLog(20, Session.Item("user"), 1, "Transacción Exitosa, Envío de email de confirmación de pago satisfactorio.")
                '    Catch ex As Exception
                '        ExceptionHandler.Captura_Error(ex)
                '    End Try
                'Else
                '    Me.BtnVerPago.Visible = False
                '    Me.lbltitulo.Text = "Transacción no realizada"

                '    Dim objmail As New MailTrabajos
                '    lblemailresult.Text = objmail.EnvioEmailConfirmaciónPago(200, CType(tNo_value_final, Decimal))
                '    'EnvioEmailConfirmaciónPago("200", CType(tNo_value_final, Decimal))

                '    Me.lblemailresult.Text = "Transacción rechazada, por favor comunicarse con su banco emisor."
                '    Me.imageResultado.ImageUrl = "~/images/icons/24x24/alerterror1.png"
                '    Me.imageResultado.Visible = True
                '    Try
                '        FormularioAdapter.RegistroLog(19, Session.Item("user"), 1, "Transacción rechazada, por favor comunicarse con su banco emisor.")
                '    Catch ex As Exception
                '        ExceptionHandler.Captura_Error(ex)
                '    End Try
                'End If
                'Me.lbltaxvalue2.Visible = False
                'Me.lblreferencia1.Visible = False
                'Me.lblreferencia2.Visible = False
                'Me.lblreferencia3.Visible = False
                'Me.lblreferencia4.Visible = False
                'Me.lblreferencia5.Visible = False
                'Me.lblestadoautorizacion.Visible = False
                'opcion = 11
                'Dim dTInfoResult As DataSet
                'dTInfoResult = OrdenPagoAdapter.InfoOrdenResultado(opcion, tNo_value_final)
                'If dTInfoResult.Tables(0).Rows.Count > 0 Then
                '    Me.lblordenpago.Text = dTInfoResult.Tables(0).Rows(0)("ORDEN_ID")
                '    Me.lblcotizacion.Text = dTInfoResult.Tables(0).Rows(0)("COTIZACIONID")
                '    Me.lblidentificacion.Text = dTInfoResult.Tables(0).Rows(0)("BILLINGCEDULA")
                '    Me.lblnombre.Text = dTInfoResult.Tables(0).Rows(0)("BILLINGNAME")
                '    Me.lblmeses.Text = dTInfoResult.Tables(0).Rows(0)("NUMERO_MESES")
                '    Me.lblsubtotal.Text = dTInfoResult.Tables(0).Rows(0)("SUBTOTAL")
                '    Me.lbliva.Text = dTInfoResult.Tables(0).Rows(0)("IVA")
                '    Me.lblintereses.Text = dTInfoResult.Tables(0).Rows(0)("INTERESES")
                '    Me.lbltotal.Text = dTInfoResult.Tables(0).Rows(0)("TOTAL")
                '    Me.lblcodcnfpago.Text = dTInfoResult.Tables(0).Rows(0)("CODIGO_CONF_PAGO")
                'Else
                '    ProveedorMensaje.ShowMessage(rntMensajes, "Se presentó un problema al cargar la información de la orden de pago, comunicarse con Sistemas.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                'End If
            End If
        Catch ex As Exception
            'opcion = 3
            'value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(opcion, estadoAutorizacion, aut_value_final, tNo_value_final, 0, "", 0, 0, 0, 0, "", "")
            ProveedorMensaje.ShowMessage(rntMensajes, "Se presentó un problema al cargar la información de la orden de pago, comunicarse con Sistemas.", ProveedorMensaje.MessageStyle.OperacionInvalida)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    'Private Sub Promocion()
    '    Dim dTPromocion As DataSet
    '    Dim strMailMsg, strMailTitle, strMail As String
    '    Dim dTEmailAct As DataSet
    '    dTPromocion = DatosPersonalesAdapter.ConsultaPromocion(Date.Now, "RENSER")
    '    If dTPromocion.Tables(0).Rows.Count > 0 Then
    '        Me.BtnReferido.Visible = False
    '        Me.mensaje.Visible = False
    '        Dim tipoPromocion As String = dTPromocion.Tables(0).Rows(0)("TIPO_ID")
    '        Dim promocionId As String = dTPromocion.Tables(0).Rows(0)("PROMOCION_ID")
    '        Dim resultado As String = SolicitudActualizacionAdapter.RegistroPromocion(Session.Item("user"), "W", tipoPromocion, promocionId, Session("VehiculoOrden"), Session("OrdenID"))
    '        ' IMAGEN DE PROMOCION Y CORREO
    '        If resultado <> "" Then
    '            'If promocionId = "PBWEE" Then
    '            'If promocionId = "PALAR" Then
    '            '    Label4.Text = resultado
    '            'Else
    '            '    Dim arregloCodigos() As String = resultado.Split(",")
    '            '    lblcodigo.Text = arregloCodigos(0)
    '            '    lblcodigo2.Text = arregloCodigos(1)
    '            '    Label1.Text = arregloCodigos(0)
    '            '    Label2.Text = arregloCodigos(1)
    '            'End If
    '            dTEmailAct = DatosPersonalesAdapter.GeneraEmailPromocion(Session.Item("user"), resultado, tipoPromocion, Session("OrdenID"), promocionId)
    '            If dTEmailAct.Tables.Count > 0 Then
    '                If dTEmailAct.Tables(0).Rows.Count > 0 Then
    '                    strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
    '                    strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
    '                    strMail = dTEmailAct.Tables(0).Rows(0)("EMAIL")
    '                    EnvioEmailPromocion(strMail, strMailTitle, strMailMsg)
    '                    'If promocionId = "PBWEE" Then
    '                    'If promocionId = "PALAR" Then
    '                    '    Dim promocion As String = "function f(){$find(""" + modalPromocion2.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
    '                    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", promocion, True)
    '                    'Else
    '                    Dim promocion As String = "function f(){$find(""" + modalPromocion.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
    '                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", promocion, True)
    '                    '    If Session("Actualizacion") = "1" Then
    '                    '        ActualizacionPromocion("002", promocionId)
    '                    '    End If
    '                    'End If
    '                    Session("VehiculoOrden") = Nothing
    '                    Session("OrdenID") = Nothing
    '                Else
    '                    ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '                End If
    '            Else
    '                ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '            End If
    '        End If

    '    End If

    'End Sub

    'Private Sub ActualizacionPromocion(ByVal tipo As String, ByVal promocionId As String)
    '    Try
    '        Dim strMailMsg, strMailTitle, strMail As String
    '        Dim dTEmailAct As DataSet
    '        Dim tipoPromocion As String = tipo
    '        Dim resultado As String = SolicitudActualizacionAdapter.RegistroPromocion(Session.Item("user"), "W", tipoPromocion, promocionId, Session("VehiculoOrden"), Session("OrdenID"))
    '        If resultado <> "" Then
    '            Label3.Text = resultado
    '            dTEmailAct = DatosPersonalesAdapter.GeneraEmailPromocion(Session.Item("user"), resultado, tipoPromocion, "", promocionId)
    '            If dTEmailAct.Tables.Count > 0 Then
    '                If dTEmailAct.Tables(0).Rows.Count > 0 Then
    '                    strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
    '                    strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
    '                    strMail = dTEmailAct.Tables(0).Rows(0)("EMAIL")
    '                    EnvioEmailPromocion(strMail, strMailTitle, strMailMsg)
    '                    Dim promocion As String = "function f(){$find(""" + modalPromocion1.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
    '                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", promocion, True)
    '                    Session("Actualizacion") = "0"
    '                Else
    '                    ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '                End If
    '            Else
    '                ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Private Sub EnvioEmailConfirmaciónPago(ByVal proceso As String, ByVal ordenId As Decimal)
    '    Try
    '        Dim emailBody, emailBodyCopias As String
    '        Dim emailAddres, emailAddresCopias As String
    '        Dim dTCstGeneral, dTCstGeneralCopias As New System.Data.DataSet
    '        'ENVIA EMAIL A CLIENTE
    '        dTCstGeneral = RenovacionAdapter.ConsultaEmail(ordenId, Proceso, True)
    '        emailBody = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("HTMLBODY"))
    '        emailAddres = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("BILLINGEMAIL"))
    '        EMailHandler.EMailConfirmacionPagoCliente(emailBody, emailAddres, Proceso)
    '        'ENVIA MAIL COPIAS
    '        dTCstGeneralCopias = RenovacionAdapter.ConsultaEmail(ordenId, Proceso, False)
    '        emailBodyCopias = Convert.ToString(dTCstGeneralCopias.Tables(0).Rows(0)("HTMLBODY"))
    '        emailAddresCopias = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC")
    '        EMailHandler.EMailConfirmacionPagoCliente(emailBodyCopias, emailAddresCopias, Proceso)
    '    Catch ex As Exception
    '        Me.lblemailresult.Text = "Ocurrió un error al enviar el email de confirmación"
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Private Sub EnvioEmailPromocion(ByVal email As String, ByVal titulo As String, ByVal mensaje As String)
    '    Dim correo = New System.Net.Mail.MailMessage()
    '    correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
    '    Dim mailTo As [String]() = email.ToString().Split(";")
    '    For Each mailTooBcc As String In mailTo
    '        If EMailHandler.ValidarEMail(mailTooBcc) Then
    '            correo.To.Add(mailTooBcc)
    '        End If
    '    Next
    '    'correo.To.Add(email)
    '    Dim mailToBccCollection As [String]() = ConfigurationManager.AppSettings.Get("PromocionMailToBcc").ToString().Split(";")
    '    For Each mailTooBcc As String In mailToBccCollection
    '        If EMailHandler.ValidarEMail(mailTooBcc) Then
    '            correo.Bcc.Add(mailTooBcc)
    '        End If
    '    Next
    '    correo.Subject = titulo
    '    titulo &= vbCrLf & vbCrLf & "Fecha y hora GMT: " & DateTime.Now.ToUniversalTime.ToString("dd/MM/yyyy HH:mm:ss")
    '    correo.Body = mensaje
    '    correo.IsBodyHtml = True
    '    Dim smtp As New System.Net.Mail.SmtpClient
    '    '---------------------------------------------
    '    ' Estos datos debes rellanarlos correctamente
    '    '---------------------------------------------
    '    smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
    '    smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
    '    smtp.EnableSsl = False
    '    Try
    '        smtp.Send(correo)
    '        correo.Dispose()
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    Protected Sub Btnregresarinicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btnregresarinicio.Click
        Try
            Response.Redirect("renovacion.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub BtnVerPago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVerPago.Click
        Try
            'Session("OrdeId") = Me.lblordenpago.Text
            Response.Redirect("transacciondetalle.aspx?OrderId=" + Me.lblordenpago.Text, False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class