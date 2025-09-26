Imports System
Imports System.Web
Imports System.Net.Mail

Public Class ContactenosCliente

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                LimpiarDatos()
            End If
            txtcontenido.Attributes.Add("onKeyDown", "javascript:contadorTitulo(this.form.lbl_caracteres, 1000);")
            txtcontenido.Attributes.Add("onKeyUp", "javascript:contadorTitulo(this.form.lbl_caracteres, 1000);")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#Region "Proceso"

    Private Sub LimpiarDatos()
        Try
            Me.txtcontenido.Text = ""
            Me.txt_regusu_identificacion.Text = ""
            Me.txt_regusu_email01.Text = ""
            Me.txt_regusu_factura.Text = ""
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
                    rntMensajes.Title = "Mensaje de la HunterOnline"
                    rntMensajes.TitleIcon = "ok"
                    rntMensajes.ContentIcon = "ok"
                    rntMensajes.ShowSound = "ok"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
                Case 2
                    'Mensajes tipo "WARNING"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje de la HunterOnline"
                    rntMensajes.TitleIcon = "warning"
                    rntMensajes.ContentIcon = "warning"
                    rntMensajes.ShowSound = "warning"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
                Case 3
                    'Mensajes tipo "ERROR"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje de la HunterOnline"
                    'rntMensajes.TitleIcon = "error"
                    'rntMensajes.ContentIcon = "error"
                    'rntMensajes.ShowSound = "error"
                    rntMensajes.TitleIcon = "warning"
                    rntMensajes.ContentIcon = "warning"
                    rntMensajes.ShowSound = "warning"
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
            'Session("Telefono") = "0"
            Session("Comentario") = Me.txtcontenido.Text.ToUpper()
            Dim dTProvinciaCiudadCliente As DataSet
            dTProvinciaCiudadCliente = ContactosAdapter.Consultaprovinciacliente(Me.txt_regusu_email01.Text)
            Dim provincia As String = "REQ-E, GUAYAS, GUAYAQUIL"
            If dTProvinciaCiudadCliente.Tables(0).Rows.Count > 0 Then
                provincia = "REQ-E, " + dTProvinciaCiudadCliente.Tables(0).Rows(0)("CIUDAD")
            End If

            Dim dTContactoCliente As DataSet
            ' Antes se puso 0000000000000 en ruc
            Me.txt_regusu_identificacion.Text = Me.txt_regusu_identificacion.Text + ";" + Me.txt_regusu_factura.Text
            dTContactoCliente = ContactosAdapter.Consultacliente(Me.txt_regusu_identificacion.Text)
            If dTContactoCliente.Tables(0).Rows.Count > 0 Then
                Session("Asunto") = provincia + ": " + "Cliente Solicita Información"
                'Session("Asunto") = DTContactoCliente.Tables(0).Rows(0)("CIUDAD")+"   Cliente Solicita Información"
                Session("cliente") = dTContactoCliente.Tables(0).Rows(0)("NOMBRE_COMPLETO")
            Else
                Session("Asunto") = provincia + ": " + "Solicita Información"
                Session("cliente") = ""
            End If
            Session("Idcliente") = Me.txt_regusu_identificacion.Text.ToUpper()
            Session("Correo") = Me.txt_regusu_email01.Text
            ContactosAdapter.RegistroDatosCliente(Session("Idcliente"), Session("Correo"), Session("Asunto"), Session("Comentario"), CType(Application("soporteextranet"), String))
            ConfigMsg(1, "Información enviada correctamente")
            GeneraEmail()
            LimpiarDatos()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


#End Region

#Region "Correo"


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
            mailMessage.Subject = Session("Asunto")
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
            builder.Append("Soporte al Cliente : '").Append(ConfigurationManager.AppSettings.Get("ProyectName").ToString()).Append("', Cliente sin autenticar</div></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Fecha y Hora</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"))
            builder.Append("</td></tr>")
            If HttpContext.Current.Session("Idcliente").ToString() <> "0000000000000" Then
                builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
                builder.Append(" nowrap>Usuario</td>")
                builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Idcliente").ToString() + " " + HttpContext.Current.Session("cliente").ToString())
                builder.Append("</td></tr>")
            End If
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Asunto</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Asunto").ToString())
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

#End Region


End Class