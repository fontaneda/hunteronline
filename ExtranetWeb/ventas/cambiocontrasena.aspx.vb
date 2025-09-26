Imports Telerik.Web.UI
'Imports System.Net.Mail

Public Class cambiocontrasena

    Inherits System.Web.UI.Page
    Dim lblusuario As String
    Dim dTEmailAct As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("userkey") = "" Then
                    'Me.lblusuario = Session("display_name")
                    'Session("pantalla") = Nothing
                    Response.Redirect("login.aspx", False)
                Else
                    Session.Item("user") = Session("userkey")
                    'Me.txt_regusu_clave1.Text = Session("strClv")
                    'Session("clave") = Me.txt_regusu_clave1.Text
                    Dim dTCliente As DataSet
                    dTCliente = Contraseña.ConsultaClave(Session.Item("user"))
                    Session("Email") = dTCliente.Tables(0).Rows(0)("EMAIL1")
                    Session("display_name") = dTCliente.Tables(0).Rows(0)("DISPLAYNAME")
                    Session("apellido") = dTCliente.Tables(0).Rows(0)("APELLIDO")
                    Session("user_id") = Session.Item("user")
                    Me.lblusuario = Session("display_name")
                    Session("pantalla") = Nothing
                    'Me.txt_regusu_clave1.Enabled = False
                    'Me.pass.Disabled = "True"
                    'Me.div1.Visible = False
                    'Me.div2.Visible = False
                    'Me.Label1.Text = ""
                End If
                'txt_regusu_clave1.TextMode = TextBoxMode.Password
                txt_regusu_clave2.TextMode = TextBoxMode.Password
                txt_regusu_clave3.TextMode = TextBoxMode.Password
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub VerificaContraseña()
        'IsNullOrBlank(Me.txt_regusu_identificacion.Text.Trim()) = False Then
        If Session("userkey") = "" Then
            'If Me.txt_regusu_clave1.Text.Trim() = "" Or Me.txt_regusu_clave2.Text.Trim() = "" Or Me.txt_regusu_clave3.Text.Trim() Then
            '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseñas, no deben estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
            '    Exit Sub
            'End If
            'If Me.txt_regusu_clave1.Text.Length < 8 Then
            '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseñas, no deben estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
            '    Exit Sub
            'End If
        End If
        If Me.txt_regusu_clave2.Text <> Me.txt_regusu_clave3.Text Then
            'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar los password que no son iguales", ProveedorMensaje.MessageStyle.OperacionInvalida)
            Exit Sub
        End If
    End Sub

    Protected Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Try
            ' Dim cliente, usuario, sesion_administrador, nombres_completos As String
            If Session("userkey") = "" Then
                'If Me.txt_regusu_clave1.Text.Trim() = "" Then
                '    'Me.lblmensaje.Text = "Por favor verificar contraseñas, no deben estar en blanco"
                '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña actual, no debe estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    Me.pass.Checked = "False"
                '    txt_regusu_clave1.Focus()
                '    Exit Sub
                'End If
                'If Me.txt_regusu_clave1.Text.Length < 8 Or Me.txt_regusu_clave1.Text.Length > 16 Then
                '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor contraseña actual, debe tener entre 8 y 16 caracteres", ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    Me.pass.Checked = "False"
                '    txt_regusu_clave1.Focus()
                '    Exit Sub
                'End If
            End If
            If Me.txt_regusu_clave2.Text.Trim() = "" Then
                'Me.lblmensaje.Text = "Por favor verificar contraseñas, no deben estar en blanco"
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña nueva, no debe estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
                'Me.pass2.Checked = "False"
                txt_regusu_clave2.Focus()
                Exit Sub
            End If
            If Me.txt_regusu_clave2.Text.Length < 8 Or Me.txt_regusu_clave2.Text.Length > 16 Then
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor contraseña nueva, debe tener entre 8 y 16 caracteres", ProveedorMensaje.MessageStyle.OperacionInvalida)
                'Me.pass2.Checked = "False"
                txt_regusu_clave2.Focus()
                Exit Sub
            End If
            If Me.txt_regusu_clave3.Text.Trim() = "" Then
                'Me.lblmensaje.Text = "Por favor verificar contraseñas, no deben estar en blanco"
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña nueva, no debe estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
                'Me.pass3.Checked = "False"
                txt_regusu_clave3.Focus()
                Exit Sub
            End If
            If Me.txt_regusu_clave3.Text.Length < 8 Or Me.txt_regusu_clave3.Text.Length > 16 Then
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor contraseña nueva, debe tener entre 8 y 16 caracteres", ProveedorMensaje.MessageStyle.OperacionInvalida)
                'Me.pass3.Checked = "False"
                txt_regusu_clave3.Focus()
                Exit Sub
            End If
            If Session("userkey") = "" Then
                Dim dTCliente As DataSet
                dTCliente = Contraseña.ConsultaClave(Session.Item("user"))
                'If Me.txt_regusu_clave1.Text <> dTCliente.Tables(0).Rows(0)("CLAVE") Then
                '    'If DTCliente.Tables(0).Rows.Count > 0 Then
                '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Esta cuenta de correo <b style=""font-weight: bold"">" + txt_regusu_email01.Text.Trim + "</b> ya se encuentra registrada.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña actual es incorrecta.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    Me.pass.Checked = "False"
                '    txt_regusu_clave1.Focus()
                '    Exit Sub
                'End If
                'If Me.txt_regusu_clave1.Text = Me.txt_regusu_clave2.Text Then
                '    'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña nueva debe ser diferente a contraseña actual", ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    Me.pass2.Checked = "False"
                '    txt_regusu_clave2.Focus()
                '    Exit Sub
                'End If
            End If
            If Me.txt_regusu_clave2.Text <> Me.txt_regusu_clave3.Text Then
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar las contraseñas nuevas no son iguales", ProveedorMensaje.MessageStyle.OperacionInvalida)
                'Me.pass2.Checked = "False"
                txt_regusu_clave2.Focus()
                Exit Sub
            End If
            RegistroClaveNueva()
            GeneraEmail()
            Me.txt_regusu_clave2.Text = ""
            Me.txt_regusu_clave3.Text = ""
            'Me.txt_regusu_clave1.Text = ""
            'Me.pass.Checked = "False"
            'Me.pass2.Checked = "False"
            'Me.pass3.Checked = "False"
            CargaNuevaSesion()
            'Response.Redirect("login.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub RegistroClaveNueva()
        'Dim objregusu As New Contraseña
        Dim valueRegistro As Integer
        If Session("userkey") = "" Then
            'valueRegistro = Contraseña.RegistroClaveNueva(Session.Item("user"), Me.txt_regusu_clave1.Text, Me.txt_regusu_clave2.Text)
        Else
            valueRegistro = Contraseña.RegistroClaveNueva(Session.Item("user"), Session("strClv"), Me.txt_regusu_clave2.Text)
        End If
        If valueRegistro = 0 Then
            'ProveedorMensaje.ShowMessage(rntMensajes, "Cambio Contraseña realizado con éxito, Gracias por preferirnos.", ProveedorMensaje.MessageStyle.OperacionExitosa, 12000)
        Else
            'ProveedorMensaje.ShowMessage(rntMensajes, "No se ha podido cambiar contraseña correctamente", ProveedorMensaje.MessageStyle.OperacionInvalida)
        End If
    End Sub

    Private Sub GeneraEmail()
        Try
            Dim strMailMsg, strMailTitle As String
            'url_contraseña,
            dTEmailAct = Contraseña.GeneraEmailCambioContrasenia(Session.Item("user"), Session("Email"), Session("display_name"), Session("apellido"), Session("clave"))
            If dTEmailAct.Tables(0).Rows.Count > 0 Then
                strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                'str_mail_title = DTEmailAct.Tables(0).Rows(0)("TITLE_HTML") 
                strMailTitle = dTEmailAct.Tables(0).Rows(0)("CIUDAD") + ": " + dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                EnvioEmailExterno(Session("Email"), strMailTitle, strMailMsg)
            Else
                'ConfigMsg(2, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña")
                'ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Cambio de Contraseña.", ProveedorMensaje.MessageStyle.OperacionInvalida)
            End If
            'Dim mailMessage As New MailMessage()
            'Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            'mailMessage.From = mailAddress
            'mailMessage.IsBodyHtml = True
            ''Dim mailToCollection As [String]() = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString().Split(";")
            'Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
            'For Each mailTo As String In mailToCollection
            '    mailMessage.To.Add(mailTo)
            'Next
            ''mailMessage.Subject = Me.txt_asunto.Text.ToUpper()
            'mailMessage.Subject = "Cambio Contraseña"
            'mailMessage.Body = MailBody(Session("display_name"))
            'mailMessage.Priority = MailPriority.High
            'Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            'smtpClient.Send(mailMessage)
            'mailMessage.Dispose()
            'Dim mailMessage_cl As New MailMessage()
            'Dim mailAddress_cl As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            'mailMessage_cl.From = mailAddress_cl
            'mailMessage_cl.IsBodyHtml = True
            ''Dim mailToCollection As [String]() = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString().Split(";")
            'Dim mailToCollection_cl As String = Session("Email")
            ''CType(Application("soporteextranet"), String).Split(",")
            ''For Each mailTo As String In mailToCollection_cl
            ''    mailMessage_cl.To.Add(mailTo)
            ''Next
            'mailMessage_cl.To.Add(Session("Email"))
            ''mailMessage.Subject = Me.txt_asunto.Text.ToUpper()
            'mailMessage_cl.Subject = "Cambio Contraseña"
            'mailMessage_cl.Body = MailBody(Session("display_name"))
            'mailMessage_cl.Priority = MailPriority.High
            'Dim smtpClient_cl As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            'smtpClient_cl.Send(mailMessage_cl)
            'mailMessage_cl.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    'Private Shared Function MailBody(username As String) As String
    '    Dim builder As New StringBuilder()
    '    Try
    '        builder.Append("<html><head><title>")
    '        builder.Append("</title><meta http-equiv=""Content-Type""")
    '        builder.Append("</head><body>")
    '        builder.Append("<br/><br/><br/>")
    '        builder.Append("<img scr=""http://www.hunter.com.ec/img/LogoHunterOnlineEamil.png""  />")
    '        builder.Append("<br/><br/><br/>")
    '        builder.Append("<img src=""http://www.hunter.com.ec/img/sfs_icon_twitter.png""  />")
    '        builder.Append("<br/><br/><br/>")
    '        builder.Append("<img src=""http://www.hunter.com.ec/img/sfs_icon_youtube.png"" />")
    '        builder.Append("<br/><br/><br/>")
    '        builder.Append("<h1 class=""h1"">Cambio de Contraseña</h1> <p><strong>Señor(a)(ita)</strong>  <strong>")
    '        builder.Append("</strong> </p> <p> <strong>" + username)
    '        'builder.Append("HttpContext.Current.Session(""user"").ToString()")
    '        builder.Append("</strong> <br/> </p> <p><br/> <strong>Estimado(a) Cliente:</strong> <br/> Usted ha modificado su contraseña satisfactoriamente.")
    '        builder.Append("</strong> <br/> </p> <p><br/> <strong>Su usuario registrado es: </strong> " + HttpContext.Current.Session("user").ToString())
    '        'builder.Append("S&#237;guenos en Twitter</a> </div> </td> </tr> <tr mc:hideable> <td align=""left"" valign=""middle"" width=""32""> <br/>")
    '        builder.Append("<br/><br/><br/> <a title=""Descargar Manual de Usuario"" href=""https://www.hunteronline.com.ec/extranet/manual/ManualUsuarioHOnline.pdf"" target=""_blank"">Descargar Manual de Usuario de HunterOnline </a>")
    '        '<a class="linkmanualcss" href="https://www.hunteronline.com.ec/extranet/manual/ManualUsuarioHOnline.pdf" target="_blank">
    '        builder.Append("<br/> <br/> <h2 class=""h2"">Nota: Favor no responder este email.</h2> <p> <br/> <br/> ")
    '        builder.Append("Copyright &copy; 2020 Carseg S.A., Todos los derechos reservados.")
    '        builder.Append("</body></html>")
    '        ' o con tilde  &#243;
    '        'builder.Append("<html><head><title>")
    '        'builder.Append("</title><meta http-equiv=""Content-Type""")
    '        'builder.Append("content=""text/html"";charset=""iso-8859-1""><style type=""text/css"">")
    '        'builder.Append("<!--.basix {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 9px;")
    '        'builder.Append("}.header1 {font-family: Verdana, Arial, Helvetica, sans-serif;")
    '        'builder.Append("font-size: 11px; color: #000000;}.tlbbkground1")
    '        'builder.Append(" {background-color: #EDEADF;border: 1px solid #EDEADF;}--></style></head><body>")
    '        'builder.Append("<table width=""70%"" border=""0"" align=""center"" cellpadding = ""5""")
    '        'builder.Append("cellspacing=""1"" class=""tlbbkground1""><tr bgcolor=""#EDEADF"">")
    '        'builder.Append("<td colspan=""2"" class=""header1""><div align=""center"">")
    '        'builder.Append("Soporte al Cliente : '").Append(ConfigurationManager.AppSettings.Get("ProyectName").ToString()).Append("', Cliente sin autenticar</div></tr>")
    '        'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
    '        'builder.Append(" nowrap>Fecha y Hora</td>")
    '        'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"))
    '        'builder.Append("</td></tr>")
    '        'If HttpContext.Current.Session("Idcliente").ToString() <> "0000000000000" Then
    '        '    builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
    '        '    builder.Append(" nowrap>Usuario</td>")
    '        '    builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Idcliente").ToString() + " " + HttpContext.Current.Session("cliente").ToString())
    '        '    builder.Append("</td></tr>")
    '        'End If
    '        'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
    '        'builder.Append(" nowrap>Asunto</td>")
    '        'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Asunto").ToString())
    '        'builder.Append("</td></tr>")
    '        'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
    '        'builder.Append(" nowrap>Correo</td>")
    '        'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Correo").ToString())
    '        'builder.Append("</td></tr>")
    '        'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
    '        'builder.Append(" nowrap>Comentario</td>")
    '        'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Comentario").ToString())
    '        'builder.Append("</td></tr>")
    '        'builder.Append("</table></body></html>")
    '    Catch exc As Exception
    '        Throw exc
    '    End Try
    '    Return builder.ToString()
    'End Function


    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: GENERACION DEL CORREO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmailExterno(ByVal email As String, ByVal titulo As String, ByVal bodyhtml As String)
        Dim correo = New System.Net.Mail.MailMessage()
        'correo.From = New System.Net.Mail.MailAddress("galvarado@carsegsa.com")
        correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
        'email = "galvarado@carsegsa.com"
        'Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
        'For Each mailTo As String In mailToCollection
        '    mailMessage.To.Add(mailTo)
        'Next
        correo.To.Add(email)
        'Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
        'For Each mailTo As String In mailToCollection
        '    mailMessage.To.Add(mailTo)
        'Next
        'Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("soporteextranet").ToString()
        'Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("RegistroUsuarioMailToBcc").ToString()
        Dim mailToBccCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")  '   mailToBcc.Split(";")
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
        'smtp.Host = "10.100.89.4"
        'smtp.Credentials = New System.Net.NetworkCredential("galvarado", "12345")
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

    ''Private Sub btncancelar_Click(sender As Object, e As System.EventArgs) Handles btncancelar.Click
    ''    Me.txt_regusu_clave1.Text = ""
    ''    Me.txt_regusu_clave2.Text = ""
    ''    Me.txt_regusu_clave3.Text = ""
    ''    Session.Clear()
    ''End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As System.EventArgs) Handles BtnLimpiar.Click
        Me.txt_regusu_clave2.Text = ""
        Me.txt_regusu_clave3.Text = ""
        'Me.pass2.Checked = "False"
        'Me.pass3.Checked = "False"
        If Session("userkey") = "" Then
            'Me.txt_regusu_clave1.Text = ""
            'Me.pass.Checked = "False"
        End If
    End Sub

    Private Sub CargaNuevaSesion()
        Try
            FormularioAdapter.RegistroLogFormulario(108, Session("user_id"), "LOAD", "USUARIO CAMBIO DE CONTRASEÑA", Session("iphost"))
            Response.Redirect("login.aspx", False)
            'Session.Clear()
            'Session.Abandon()
            'Dim script As String = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRedirect());</script>"
            'RadScriptManager.RegisterStartupScript(Me, Me.GetType(), "CloseAndRedirect()", script, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '' Protected Sub BtnVer_Click(sender As Object, e As EventArgs)
    '''Private Sub BtnVer_Click(sender As Object, e As System.EventArgs)  Handles BtnVer.Click
    ''    Try
    ''        'txt_regusu_clave1.TextMode = TextBoxMode.SingleLine
    ''        'txt_regusu_clave1.TextMode = Telerik.Web.UI.InputMode.SingleLine
    ''        txt_regusu_clave1.Attributes.Add("type", "text")
    ''        Me.BtnVer.Visible = False
    ''        Me.BtnOcultar.Visible = True
    ''    Catch ex As Exception
    ''        Throw ex
    ''    End Try
    ''End Sub


    ''Protected Sub BtnOcultar_Click(sender As Object, e As EventArgs)
    '''Private Sub BtnOcultar_Click(sender As Object, e As System.EventArgs) Handles BtnOcultar.Click
    ''    Try
    ''        'Dim texto1 As String = txt_regusu_clave1.Text
    ''        'txt_regusu_clave1.TextMode = TextBoxMode.Password
    ''        'txt_regusu_clave1.TextMode = Telerik.Web.UI.InputMode.Password 
    ''        'txt_regusu_clave1.Attributes.Add("value","password")
    ''        'txt_regusu_clave1.Attributes.Add("value","pass")
    ''        'txt_regusu_clave1.Text = "opreuba"
    ''        txt_regusu_clave1.Attributes.Add("type", "password")
    ''        Me.BtnVer.Visible = True
    ''        Me.BtnOcultar.Visible = False
    ''        ' txt_regusu_clave1.Text = "opreuba"
    ''    Catch ex As Exception
    ''        Throw ex
    ''    End Try
    ''End Sub


End Class