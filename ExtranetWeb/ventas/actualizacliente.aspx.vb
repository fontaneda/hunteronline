'Imports Telerik.Web.UI

Public Class actualizacliente

    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Evento load de la pagina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                LimpiaControles()
                ConfigControles(1)
                CargaDatosCliente()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Evento Click del boton salir
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnregresareg_ServerClick(sender As Object, e As System.EventArgs) Handles btnregresareg.ServerClick
        Try
            Session.Clear()
            Session.Abandon()
            Response.Redirect("login.aspx", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Evento Click del boton aceptar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BtnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btncrearreg.Click
        Try
            If Me.txt_regusu_contrasenia01.Text <> Me.txt_regusu_contrasenia02.Text Then
                mensajeria_error("error", "Por favor verificar las contraseñas que no son iguales")
                Exit Sub
            End If
            If Me.txt_regusu_contrasenia01.Text = "" Then
                mensajeria_error("error", "Por favor verificar la contraseña nueva")
                txt_regusu_contrasenia01.Focus()
                Exit Sub
            End If
            If Me.txt_regusu_contrasenia02.Text = "" Then
                mensajeria_error("error", "Por favor verificar la confirmación de la contraseña")
                txt_regusu_contrasenia02.Focus()
                Exit Sub
            End If
            If Me.txt_regusu_celular.Text = "" Then
                mensajeria_error("error", "Por favor verificar el celular de contacto")
                txt_regusu_celular.Focus()
                Exit Sub
            End If
            ActualizaDatosNuevoUsuario()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Procedimiento para configurar controles al cargar pantalla
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <remarks></remarks>
    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    txt_regusu_contrasenia01.Enabled = True
                    txt_regusu_contrasenia02.Enabled = True
                    txt_regusu_nombre.Enabled = False
                    txt_regusu_apellido.Enabled = False
                    txt_regusu_celular.Enabled = True
                    'chk_acuerdo.Enabled = True
                    Me.chk_acuerdo.Disabled = "False"
                    chk_suscripcion.Disabled = "False"
                    Me.btncrearreg.Enabled = True
                Case 2
                    txt_regusu_contrasenia01.Enabled = False
                    txt_regusu_contrasenia02.Enabled = False
                    txt_regusu_email01.Enabled = False
                    txt_regusu_nombre.Enabled = False
                    txt_regusu_apellido.Enabled = False
                    txt_regusu_celular.Enabled = False
                    Me.chk_acuerdo.Disabled = "True"
                    chk_suscripcion.Disabled = "True"
                    Me.btncrearreg.Enabled = False
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Procedimiento para encerar controles
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LimpiaControles()
        Try
            txt_regusu_identificacion.Text = ""
            txt_regusu_contrasenia01.Text = ""
            txt_regusu_contrasenia02.Text = ""
            txt_regusu_nombre.Text = ""
            txt_regusu_apellido.Text = ""
            txt_regusu_celular.Text = ""
            txt_regusu_email01.Text = ""
            dvdmensajes.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Procedimiento para cargar datos del cliente
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaDatosCliente()
        Try
            Dim dTDatosCliente As DataSet
            dTDatosCliente = RegistroUsuarioAdapter.CargaDatosCliente(Session("user"))
            If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                Me.txt_regusu_identificacion.Text = Session("user")
                Me.txt_regusu_nombre.Text = dTDatosCliente.Tables(0).Rows(0)("NOMBRES")
                Me.txt_regusu_apellido.Text = dTDatosCliente.Tables(0).Rows(0)("APELLIDOS")
                Me.txt_regusu_email01.Text = dTDatosCliente.Tables(0).Rows(0)("EMAIL")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    '''' <summary>
    '''' Autor: Felix Ontaneda
    '''' Fecha: 03/12/2014
    '''' Descr: Procedimiento para actualizar usuario
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub ActualizaDatosNuevoUsuario()
        Try
            Dim objregusu As New RegistroUsuarioAdapter
            Dim idcliente, password, nombre, apellido, email, celular As String
            Dim valueCondServPolt As Integer = 0
            Dim valueInfoProdServ As Integer = 0
            Dim valueRegistroUsuario As Integer
            idcliente = txt_regusu_identificacion.Text.Trim()
            password = txt_regusu_contrasenia01.Text
            nombre = txt_regusu_nombre.Text
            apellido = txt_regusu_apellido.Text
            email = txt_regusu_email01.Text
            celular = txt_regusu_celular.Text
            valueCondServPolt = If(chk_acuerdo.Checked = True, 1, 0)
            valueInfoProdServ = If(chk_suscripcion.Checked = True, 1, 0)
            If Not txt_regusu_email01.Text = "" Then
                valueRegistroUsuario = objregusu.ActualizaDatosPersonalesUsuarioWeb(idcliente, password, celular, "", valueCondServPolt, valueInfoProdServ, email)
            Else
                mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
                Exit Sub
            End If
            If valueRegistroUsuario = 0 Then
                GeneraEmailActivacion()
                mensajeria_error("error", "")
                ConfigControles(2)
                Promocion(idcliente)
            Else
                mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
            End If
        Catch ex As Exception
            mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 03/12/2014
    ''' Descr: Procedimiento para generar el mail de activacion del usuario
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraEmailActivacion()
        Try
            Dim dTLinkActiv, dTEmailAct As DataSet
            Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, urlActivacion As String
            Dim valueFecha, valueCfr02, urlFechaparm, valueCfr03, urlPromocion As String
            Dim strMailMsg, strMailTitle As String
            If HttpContext.Current IsNot Nothing Then
                dTLinkActiv = RegistroUsuarioAdapter.GeneraLinkActivacion
                If dTLinkActiv.Tables.Count > 0 Then
                    If dTLinkActiv.Tables(0).Rows.Count > 0 Then
                        strDominio = dTLinkActiv.Tables(0).Rows(0)("FORM_DOMINIO")
                        strFormulario = dTLinkActiv.Tables(0).Rows(0)("FORM_ASP")
                        strPrm01 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO")
                        strPrm02 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO02")
                        strPrm03 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO03")
                        valueCfr01 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(Me.txt_regusu_identificacion.Text.Trim())))
                        urlActivacion = strDominio & strFormulario & strPrm01 & valueCfr01
                        valueFecha = FechaSistema()
                        valueCfr02 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(valueFecha)))
                        urlFechaparm = strPrm02 & valueCfr02
                        valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(0)("PROMOCION"))))
                        urlPromocion = strPrm03 & valueCfr03
                        urlActivacion = String.Format("{0}&{1}&{2}", urlActivacion, urlFechaparm, urlPromocion)
                        dTEmailAct = RegistroUsuarioAdapter.GeneraEmailActivacion(Me.txt_regusu_identificacion.Text.Trim(), Me.txt_regusu_email01.Text,
                                                                                              Me.txt_regusu_nombre.Text, Me.txt_regusu_apellido.Text, urlActivacion)
                        If dTEmailAct.Tables.Count > 0 Then
                            If dTEmailAct.Tables(0).Rows.Count > 0 Then
                                strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                                strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                                EnvioEmailExterno(Me.txt_regusu_email01.Text, strMailTitle, strMailMsg)
                            Else
                                mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de activación")
                            End If
                        Else
                            mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de activación")
                        End If
                    Else
                        mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de activación")
                    End If
                Else
                    mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de activación")
                End If
            End If
        Catch ex As Exception
            mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de activación")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Fecha: 03/08/2016
    ''' Descr: Procedimiento para promocion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Promocion(ByVal idcliente As String)
        Try
            Dim dTEmailAct As DataSet
            Dim dTPromocion As DataSet
            dTPromocion = DatosPersonalesAdapter.ConsultaPromocion(Date.Now, "CREUSU")
            If dTPromocion.Tables(0).Rows.Count > 0 Then
                Dim tipoPromocion As String = dTPromocion.Tables(0).Rows(0)("TIPO_ID")
                Dim promocionId As String = dTPromocion.Tables(0).Rows(0)("PROMOCION_ID")
                Dim resultado As String = SolicitudActualizacionAdapter.RegistroPromocion(idcliente, "W", tipoPromocion, promocionId, "0", "0")
                If resultado <> "" Then
                    Dim lblcodigo As String = resultado
                    dTEmailAct = DatosPersonalesAdapter.GeneraEmailPromocion(idcliente, lblcodigo, tipoPromocion, "", promocionId)
                    If dTEmailAct.Tables.Count > 0 Then
                        If dTEmailAct.Tables(0).Rows.Count > 0 Then
                            Dim strMailMsg, strMailTitle, strMail As String
                            strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                            strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                            strMail = dTEmailAct.Tables(0).Rows(0)("EMAIL")
                            EnvioEmailPromocion(strMail, strMailTitle, strMailMsg)
                            'Dim promocion As String = "function f(){$find(""" + modalPromocion.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                            'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", promocion, True)
                        Else
                            mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de Promoción")
                        End If
                    Else
                        mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de Promoción")
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Procedimiento para encriptar query string
    ''' </summary>
    ''' <param name="strQueryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EncryptQueryString(ByVal strQueryString As String) As String
        Dim cifrado As String = String.Empty
        Dim obt As New GeneraDataCphr
        Try
            cifrado = obt.Cifrar(strQueryString, "r0b1nr0y")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return cifrado
    End Function

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 02/12/2014
    ''' Descr: Procedimiento para setear fecha del sistema
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FechaSistema()
        Try
            Dim day, month As Integer
            Dim dayStr, monthStr, yearStr, fechaStr As String
            day = Now.Day
            If day <= 9 Then
                dayStr = "0" & day
            Else
                dayStr = day.ToString
            End If
            month = Now.Month
            If month <= 9 Then
                monthStr = "0" & month
            Else
                monthStr = month.ToString
            End If
            yearStr = Now.Year.ToString
            fechaStr = yearStr & monthStr & dayStr
            Return fechaStr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 03/12/2014
    ''' Descr: Procedimiento para enviar mail
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmailExterno(ByVal email As String, ByVal titulo As String, ByVal mensaje As String)
        Dim correo = New System.Net.Mail.MailMessage()
        correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
        correo.To.Add(email)
        Dim mailToBccCollection As [String]() = ConfigurationManager.AppSettings.Get("RegistroUsuarioMailToBcc").ToString().Split(";")
        For Each mailTooBcc As String In mailToBccCollection
            If EMailHandler.ValidarEMail(mailTooBcc) Then
                correo.Bcc.Add(mailTooBcc)
            End If
        Next
        correo.Subject = titulo
        titulo &= vbCrLf & vbCrLf & "Fecha y hora GMT: " & DateTime.Now.ToUniversalTime.ToString("dd/MM/yyyy HH:mm:ss")
        correo.Body = mensaje
        correo.IsBodyHtml = True
        Dim smtp As New System.Net.Mail.SmtpClient
        '---------------------------------------------
        ' Estos datos debes rellanarlos correctamente
        '---------------------------------------------
        smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
        smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
        smtp.EnableSsl = False
        Try
            smtp.Send(correo)
            correo.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Fecha: 03/08/2016
    ''' Descr:Envio de Mail de Promocion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmailPromocion(ByVal email As String, ByVal titulo As String, ByVal mensaje As String)
        Dim correo = New System.Net.Mail.MailMessage()
        correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
        Dim mailTo As [String]() = email.ToString().Split(";")
        For Each mailTooBcc As String In mailTo
            If EMailHandler.ValidarEMail(mailTooBcc) Then
                correo.To.Add(mailTooBcc)
            End If
        Next
        Dim mailToBccCollection As [String]() = ConfigurationManager.AppSettings.Get("PromocionMailToBcc").ToString().Split(";")
        For Each mailTooBcc As String In mailToBccCollection
            If EMailHandler.ValidarEMail(mailTooBcc) Then
                correo.Bcc.Add(mailTooBcc)
            End If
        Next
        correo.Subject = titulo
        titulo &= vbCrLf & vbCrLf & "Fecha y hora GMT: " & DateTime.Now.ToUniversalTime.ToString("dd/MM/yyyy HH:mm:ss")
        correo.Body = mensaje
        correo.IsBodyHtml = True
        Dim smtp As New System.Net.Mail.SmtpClient
        '---------------------------------------------
        ' Estos datos debes rellenarlos correctamente
        '---------------------------------------------
        smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
        smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
        smtp.EnableSsl = False
        Try
            smtp.Send(correo)
            correo.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        If tipo = "error" Then
            dvdmensajes.Attributes.Add("class", "messages error")
            dvdmensajes.Visible = True
        ElseIf tipo = "alerta" Then
            dvdmensajes.Attributes.Add("class", "messages alert")
            dvdmensajes.Visible = True
        ElseIf tipo = "informacion" Then
            dvdmensajes.Attributes.Add("class", "messages sucess")
            dvdmensajes.Visible = True
        End If
    End Sub

#End Region

End Class