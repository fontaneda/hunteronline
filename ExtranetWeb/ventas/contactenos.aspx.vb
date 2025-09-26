Imports System
Imports System.Web
'Imports System.Net
'Imports System.Net.NetworkInformation
Imports System.Net.Mail
'Imports Libreria

Public Class contactenos

    Inherits System.Web.UI.Page
    Dim dTEmailAct As DataSet
    Dim dTDatosCorreo As DataSet


#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    Session("Pantalla_info") = "Contactenos"
                    LimpiarDatos()
                    ConsultaDatos()
                    CargaListaMotivo()
                    'If Session("Administrador") = "ADM" And Session.Item("user") = "1801618776" Then
                    'If Session.Item("user") = "1801618776" Then
                    '    If Session("Administrador") = "CON" Then
                    '        BtnMail.Visible = False
                    '    Else
                    '        BtnMail.Visible = True
                    '    End If
                    'Else
                    '    BtnMail.Visible = False
                    'End If
                    'If Session("Administrador") = "ADM" Or Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
                    '    BtnEnviar.Enabled = False
                    'End If
                    If Session("Administrador") = "ADM" Then
                        BtnEnviar.Enabled = False
                        FormularioAdapter.RegistroLogFormulario(111, Session.Item("user_ID"), "ADMIN", "CONTACTENOS", Session("iphost"))
                    ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
                        BtnEnviar.Enabled = False
                        FormularioAdapter.RegistroLogFormulario(111, Session.Item("user_ID"), Session.Item("usuario"), "CONTACTENOS", Session("iphost"))
                    Else
                        If Session.Item("user") = "1801618776" Then
                            If Session("Administrador") = "CON" Then
                                BtnMail.Visible = False
                            Else
                                BtnMail.Visible = True
                            End If
                        Else
                            BtnMail.Visible = False
                        End If
                        FormularioAdapter.RegistroLogFormulario(111, Session.Item("user_ID"), "LOAD", "CONTACTENOS", Session("iphost"))
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
            'lbl_caracteres.Text = "1000"
            txtcontenido.Attributes.Add("onKeyDown", "javascript:contadorTitulo(this.form.lbl_caracteres, 1000);")
            txtcontenido.Attributes.Add("onKeyUp", "javascript:contadorTitulo(this.form.lbl_caracteres, 1000);")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Proceso"


    Private Sub ConsultaDatos()
        Try
            dTDatosCorreo = ContactosAdapter.ConsultaCorreo(Session.Item("user"))
            If dTDatosCorreo.Tables(0).Rows.Count > 0 Then
                Session("Correo") = dTDatosCorreo.Tables(0).Rows(0)("MAIL")
                'Session("Ciudad") = "REQ0I, " + DTDatosCorreo.Tables(0).Rows(0)("CIUDAD")
                If dTDatosCorreo.Tables(0).Rows(0)("CIUDAD").ToString <> "" Then
                    Session("Ciudad") = "REQ-I, " + dTDatosCorreo.Tables(0).Rows(0)("CIUDAD")
                Else
                    Session("Ciudad") = "REQ-I, GUAYAS, GUAYAQUIL"
                End If
            Else
                Session("Correo") = ""
                Session("Ciudad") = "REQ-I, GUAYAS, GUAYAQUIL"
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub CargaListaMotivo()
        Try
            Dim dTListaMotivo As DataSet
            dTListaMotivo = ContactosAdapter.ConsultaMotivo()
            If dTListaMotivo.Tables(0).Rows.Count > 0 Then
                Me.cbm_motivo.DataSource = dTListaMotivo
                Me.cbm_motivo.DataTextField = "MOTIVO"
                Me.cbm_motivo.DataValueField = "MOTIVO_ID"
                cbm_motivo.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub LimpiarDatos()
        Try
            'Me.txt_telefono.Text = ""
            'Me.txt_asunto.Text = ""
            Me.txtcontenido.Text = ""
            Me.cbm_motivo.SelectedValue = 0
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub ConfigMsg(ByVal opcion As Integer, ByVal custommsg As String)
        Try
            Select Case opcion
                Case 1
                    'Mensajes tipo "OK"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje del Aplicativo HunterOnline"
                    rntMensajes.TitleIcon = "ok"
                    rntMensajes.ContentIcon = "ok"
                    rntMensajes.ShowSound = "ok"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
                Case 2
                    'Mensajes tipo "WARNING"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje del Aplicativo HunterOnline"
                    rntMensajes.TitleIcon = "warning"
                    rntMensajes.ContentIcon = "warning"
                    rntMensajes.ShowSound = "warning"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
                Case 3
                    'Mensajes tipo "ERROR"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje del Aplicativo HunterOnline"
                    rntMensajes.TitleIcon = "error"
                    rntMensajes.ContentIcon = "error"
                    rntMensajes.ShowSound = "error"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Botones"


    Protected Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        Try
            'Session("Telefono") = Me.txt_telefono.Text
            Session("Telefono") = "0"
            Session("Comentario") = Me.txtcontenido.Text.ToUpper()
            'Session("Asunto") = Me.txt_asunto.Text.ToUpper()
            Session("Asunto") = String.Format("{0} - {1}", cbm_motivo.Text, HttpContext.Current.Session("display_name"))
            'ContactosAdapter.RegistroDatos(Session.Item("user"), Session("Telefono"), Session("Asunto"), Session("Comentario"), CType(Application("soporteextranet"), String))
            ContactosAdapter.RegistroDatos(Session.Item("user"), Session("Telefono"), Session("Asunto"), Session("Comentario"), ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            ConfigMsg(1, "Mensaje enviado correctamente")
            GeneraEmail()
            'GeneraTicket()
            LimpiarDatos()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Correo"


    ''' <summary>
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: GENERACION DEL MAIL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraEmail()
        Try
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            'Dim mailToCollection As [String]() = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString().Split(";")
            Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
            For Each mailTo As String In mailToCollection
                mailMessage.To.Add(mailTo)
            Next
            'mailMessage.Subject = Me.txt_asunto.Text.ToUpper()
            mailMessage.Subject = String.Format("{2}: {0} - {1}", cbm_motivo.Text, HttpContext.Current.Session("display_name"), HttpContext.Current.Session("Ciudad"))
            mailMessage.Body = MailBody()
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Shared Function MailBody() As String
        Dim builder As New StringBuilder()
        Try
            builder.Append("<html><head><title>")
            builder.Append("</title><meta http-equiv=""Content-Type""")
            builder.Append("content=""text/html"";charset=""iso-8859-1""><style type=""text/css"">")
            builder.Append("<!--.basix {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 9px;")
            builder.Append("}.header1 {font-family: Verdana, Arial, Helvetica, sans-serif;")
            builder.Append("font-size: 11px; color: #000000;}.tlbbkground1")
            builder.Append(" {background-color: #EDEADF;border: 1px solid #EDEADF;}--></style></head><body>")
            builder.Append("<table width=""70%"" border=""0"" align=""center"" cellpadding = ""5""")
            builder.Append("cellspacing=""1"" class=""tlbbkground1""><tr bgcolor=""#EDEADF"">")
            builder.Append("<td colspan=""2"" class=""header1""><div align=""center"">")
            builder.Append("Soporte al Cliente : '").Append(ConfigurationManager.AppSettings.Get("ProyectName").ToString()).Append("', Cliente autenticado</div></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Fecha y Hora</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"))
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Usuario</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("user").ToString() + " - " + HttpContext.Current.Session("display_name").ToString())
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Asunto</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Asunto").ToString())
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Teléfono</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Telefono").ToString())
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Correo</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Correo").ToString())
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Comentario</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Comentario").ToString())
            builder.Append("</td></tr>")
            builder.Append("</table></body></html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function


    ''' <summary>
    ''' AUTOR: Felix Ontaneda
    ''' FECHA: 16/07/2014
    ''' COMENTARIO: GENERACION DEL TICKET - SE SEPARA DE LA CREACION NORMAL DEL MAIL DEBIDO AL CODIGO HTML QUE POSEE EL OTRO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraTicket()
        Try
            Dim mailMessage As New MailMessage()
            Dim correo As String = HttpContext.Current.Session("Correo").ToString()
            correo = IIf(correo.Length > 0, correo.Substring(0, IIf(correo.Contains(","), correo.IndexOf(","), correo.Length - 1)), "FONTANEDA@CARSEGSA.COM")
            Dim mailAddress As New MailAddress(correo)
            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            Dim mailToCollection As [String]() = CType(Application("Ticketextranet"), String).Split(",")
            For Each mailTo As String In mailToCollection
                mailMessage.To.Add(mailTo)
            Next
            mailMessage.Subject = String.Format("{0} - {1}", cbm_motivo.Text, HttpContext.Current.Session("display_name"))
            mailMessage.Body = MailBodyTicket()
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Shared Function MailBodyTicket() As String
        Dim builder As New StringBuilder()
        Try
            builder.Append("|Fecha: ").Append(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"))
            builder.AppendLine(" |Cliente: ").Append(String.Format("{0} - {1}", HttpContext.Current.Session("user"), HttpContext.Current.Session("display_name")))
            builder.AppendLine(" |Telefono: ").Append(HttpContext.Current.Session("Telefono").ToString())
            builder.AppendLine(" |Correo: ").Append(HttpContext.Current.Session("Correo").ToString())
            builder.AppendLine(Space(100))
            builder.AppendLine(" |Comentario: ").Append(HttpContext.Current.Session("Comentario").ToString())
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function

#End Region


#Region "Correo a usuario no activos"

    Protected Sub BtnMail_Click(sender As Object, e As EventArgs) Handles BtnMail.Click
        Try
            Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, valueCfr02, valueCfr03, urlActivacion, urlFechaparm, urlPromocion, valueFecha As String
            Dim strMailMsg, strMailTitle, strMail As String
            Dim dTLinkActiv As DataSet
            If HttpContext.Current IsNot Nothing Then
                dTLinkActiv = RegistroUsuarioAdapter.GeneraLinkActivacionUsuario
                If dTLinkActiv.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To dTLinkActiv.Tables(0).Rows.Count - 1
                        strDominio = dTLinkActiv.Tables(0).Rows(i)("FORM_DOMINIO")
                        strFormulario = dTLinkActiv.Tables(0).Rows(i)("FORM_ASP")
                        strPrm01 = dTLinkActiv.Tables(0).Rows(i)("FORM_PARAMETRO")
                        strPrm02 = dTLinkActiv.Tables(0).Rows(i)("FORM_PARAMETRO02")
                        strPrm03 = dTLinkActiv.Tables(0).Rows(i)("FORM_PARAMETRO03")
                        valueCfr01 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(i)("CODIGO_REFERENCIAL"))))
                        urlActivacion = strDominio & strFormulario & strPrm01 & valueCfr01
                        valueFecha = FechaSistema()
                        valueCfr02 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(valueFecha)))
                        urlFechaparm = strPrm02 & valueCfr02
                        valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(i)("PROMOCION"))))
                        urlPromocion = strPrm03 & valueCfr03
                        urlActivacion = urlActivacion & "&" & urlFechaparm & "&" & urlPromocion
                        dTEmailAct = RegistroUsuarioAdapter.GeneraEmailActivacionUsuario(dTLinkActiv.Tables(0).Rows(i)("CODIGO_REFERENCIAL"), dTLinkActiv.Tables(0).Rows(i)("EMAIL1"), _
                                                                                         dTLinkActiv.Tables(0).Rows(i)("PRIMER_NOMBRE"), dTLinkActiv.Tables(0).Rows(i)("PRIMER_APELLIDO"), _
                                                                                         urlActivacion)
                        If dTEmailAct.Tables(0).Rows.Count > 0 Then
                            strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                            strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                            strMail = dTLinkActiv.Tables(0).Rows(i)("EMAIL1")
                            EnvioEmailExterno(strMail, strMailTitle, strMailMsg)
                        Else
                            ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de activación", ProveedorMensaje.MessageStyle.OperacionInvalida)
                        End If
                    Next
                    ConfigMsg(1, "Mensaje enviado correctamente")
                Else
                    ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de activación", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
            ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de activación", ProveedorMensaje.MessageStyle.OperacionInvalida)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


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


    Private Sub EnvioEmailExterno(ByVal email As String, ByVal titulo As String, ByVal bodyhtml As String)
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
        correo.Body = bodyhtml
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

#End Region


End Class