'Imports Telerik.Web.UI
Imports System.Net.Mail

Public Class master

    Inherits System.Web.UI.MasterPage

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'If Request("btnenviarcont") IsNot Nothing Then
                '    set_data_server()
                'End If
                lblnombresmaster.Text = Session("display_name")
                lblemailmaster.Text = Session("Email")
                lblcelularmaster.Text = Session("Celular")
                'txtmensajecont.Value = ""
                'CargaListaMotivo()
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                    Dim someScript As String = ""
                    If (Session("Administrador") = "ADM" Or Session("Administrador") = "USR" Or Session("Administrador") = "CON" Or Session("Administrador") = "APV") Then
                        If Session("user") = "" Then
                            Response.Redirect("./CambioClienteSoporte.aspx", False)
                        End If
                        someScript = "<script language='javascript'>MostrarSettings();</script>"
                    ElseIf (Session("Administrador") = "MOD") Then
                        someScript = "<script language='javascript'>OcultarSettings();</script>"
                    ElseIf (Session("Administrador") = "APV") Then
                        someScript = "<script language='javascript'>MostrarSettings();</script>"
                    Else
                        someScript = "<script language='javascript'>OcultarSettings();</script>"
                    End If
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", someScript)
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btnsalirweb_ServerClick(sender As Object, e As System.EventArgs) Handles btnsalirweb.ServerClick
        salida()
    End Sub

    Private Sub hrefsalir_ServerClick(sender As Object, e As System.EventArgs) Handles hrefsalir.ServerClick
        salida()
    End Sub

    Public Sub set_data_server()
        Try
            'Dim motivo As String = cmbmotivoscont.SelectedValue
            'Dim asunto As String = String.Format("{0} - {1}", motivo, HttpContext.Current.Session("display_name"))
            '        Dim nombres As String = HttpContext.Current.Session("display_name")
            '        Dim usuario As String = HttpContext.Current.Session("user")
            '        Dim correo As String = HttpContext.Current.Session("Email")
            '        Dim telefono As String = HttpContext.Current.Session("Celular")
            '        Dim comentario As String = txtmensajecont.InnerText
            '        GeneraEmail(usuario, nombres, asunto, telefono, correo, comentario)
            '        LimpiarDatos()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    Private Sub salida()
        Try
            If Session("Administrador") <> "ADM" And Session("Administrador") <> "USR" And Session("Administrador") <> "MOD" Then
                FormularioAdapter.RegistroLog(18, Session("user_id"), 7)
            End If
            If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Or Session("Administrador") = "MOD" Or Session("Administrador") = "APV" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("LoginSoporte.aspx", False)
            ElseIf Session("Administrador") = "CON" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("login.aspx", False)
            Else
                Session.Clear()
                Session.Abandon()
                Response.Redirect("login.aspx", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub GeneraEmail(usuario As String, nombres As String, asunto As String, telefono As String,
                                     correo As String, comentario As String)
        Try
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
            For Each mailTo As String In mailToCollection
                mailMessage.To.Add(mailTo)
            Next
            mailMessage.Subject = String.Format("{2}: {0} - {1}", asunto, HttpContext.Current.Session("display_name"), HttpContext.Current.Session("Ciudad"))
            mailMessage.Body = MailBody(usuario, nombres, asunto, telefono, correo, comentario)
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Shared Function MailBody(usuario As String, nombres As String, asunto As String, telefono As String, _
                                     correo As String, comentario As String) As String
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
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(usuario + " - " + nombres)
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Asunto</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(asunto)
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Teléfono</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(telefono)
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Correo</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(correo)
            builder.Append("</td></tr>")
            builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            builder.Append(" nowrap>Comentario</td>")
            builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(comentario)
            builder.Append("</td></tr>")
            builder.Append("</table></body></html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function

#End Region

#Region "Propiedades Texto del Masterform"

    Public Property tituloMaster() As String
        Get
            Return lbltitulomaster.Text
        End Get
        Set(ByVal Value As String)
            lbltitulomaster.Text = Value
        End Set
    End Property

    Public Property totalMaster() As String
        Get
            Return lbltotalmaster.Text
        End Get
        Set(ByVal Value As String)
            lbltotalmaster.Text = Value
        End Set
    End Property

    Public Property cantidadMaster() As String
        Get
            Return lblcantidadmaster.Text
        End Get
        Set(ByVal Value As String)
            lblcantidadmaster.Text = Value
        End Set
    End Property

    Public Sub PintarElementomnu(indice As Integer)
        lielement01.Attributes.Add("class", "")
        lielement02.Attributes.Add("class", "")
        lielement03.Attributes.Add("class", "")
        lielement04.Attributes.Add("class", "")
        lielement05.Attributes.Add("class", "")
        lielement06.Attributes.Add("class", "")
        'lielement07.Attributes.Add("class", "")
        'lielement09.Attributes.Add("class", "")
        licellelement01.Attributes.Add("class", "")
        licellelement02.Attributes.Add("class", "")
        licellelement03.Attributes.Add("class", "")
        licellelement04.Attributes.Add("class", "")
        licellelement05.Attributes.Add("class", "")
        licellelement06.Attributes.Add("class", "")
        licellelement07.Attributes.Add("class", "")
        licellelement08.Attributes.Add("class", "")
        'licellelement09.Attributes.Add("class", "")
        h1titulomaster.Attributes.Add("class", "")
        sectiontitulomaster.Attributes.Add("class", "")

        If indice = 1 Then
            lielement01.Attributes.Add("class", "current-option cuenta-option")
            licellelement01.Attributes.Add("class", "current-option cuenta-option")
            h1titulomaster.Attributes.Add("class", "mi-cuenta")
            sectiontitulomaster.Attributes.Add("class", "title-content red-border")
        ElseIf indice = 2 Then
            lielement02.Attributes.Add("class", "current-option bienes-option")
            licellelement02.Attributes.Add("class", "current-option bienes-option")
            h1titulomaster.Attributes.Add("class", "mis-bienes")
            sectiontitulomaster.Attributes.Add("class", "title-content orange-border")
        ElseIf indice = 3 Then
            lielement03.Attributes.Add("class", "current-option pagos-option")
            licellelement03.Attributes.Add("class", "current-option pagos-option")
            h1titulomaster.Attributes.Add("class", "pagos")
            sectiontitulomaster.Attributes.Add("class", "title-content cyan-border")
        ElseIf indice = 4 Then
            lielement04.Attributes.Add("class", "current-option transac-option")
            licellelement04.Attributes.Add("class", "current-option transac-option")
            h1titulomaster.Attributes.Add("class", "mis-transacciones")
            sectiontitulomaster.Attributes.Add("class", "title-content green-border")
        ElseIf indice = 5 Then
            lielement05.Attributes.Add("class", "current-option documentos-option")
            licellelement05.Attributes.Add("class", "current-option documentos-option")
            h1titulomaster.Attributes.Add("class", "documentos")
            sectiontitulomaster.Attributes.Add("class", "title-content darkgreen-border")
        ElseIf indice = 6 Then
            licellelement06.Attributes.Add("class", "current-option turno-option")
            h1titulomaster.Attributes.Add("class", "turnos")
            sectiontitulomaster.Attributes.Add("class", "title-content blue-border")
        ElseIf indice = 7 Then
            lielement06.Attributes.Add("class", "current-option pagos-option")
            licellelement07.Attributes.Add("class", "current-option pagos-option")
            h1titulomaster.Attributes.Add("class", "pagos")
            sectiontitulomaster.Attributes.Add("class", "title-content cyan-border")
            'ElseIf indice = 8 Then
            'lielement07.Attributes.Add("class", "current-option pagos-option")
            'licellelement08.Attributes.Add("class", "current-option pagos-option")
            'h1titulomaster.Attributes.Add("class", "pagos")
            'sectiontitulomaster.Attributes.Add("class", "title-content cyan-border")
            'ElseIf indice = 9 Then
            '    lielement09.Attributes.Add("class", "current-option transac-option")
            '    licellelement09.Attributes.Add("class", "current-option transac-option")
            '    h1titulomaster.Attributes.Add("class", "mis-transacciones")
            '    sectiontitulomaster.Attributes.Add("class", "title-content green-border")
        End If
    End Sub

    Public Sub log_autitoria(pantalla As String)
        If Session("Administrador") = "ADM" Then
            FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), "ADMIN", pantalla, Session("iphost"))
        ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
            FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), Session("usuario"), pantalla, Session("iphost"))
        Else
            FormularioAdapter.RegistroLogFormulario(103, Session.Item("user"), "LOAD", pantalla, Session("iphost"))
        End If
    End Sub

#End Region

End Class