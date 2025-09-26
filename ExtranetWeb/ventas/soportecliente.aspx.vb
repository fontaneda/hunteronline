Imports System.Net.Mail
Imports System
Imports System.Web
Imports System.Net
Imports System.Net.NetworkInformation
Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Principal
Imports System.IO
Imports System.Drawing
Imports Libreria


Public Class soportecliente

    Inherits System.Web.UI.Page
    Dim dTUserExiste As DataTable
    Dim dTPreguntasAleatorias As DataSet


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not (IsPostBack) Then
                Me.HabilitaControl(False)
                'Me.RadUpArchivo.Enabled = True
                Dim extension(0) As String
                Me.RadUpArchivo.AllowedFileExtensions = extension
                'For Each item As Telerik.Web.UI.UploadedFile In Me.RadUpImagen.UploadedFiles
                '    nombreArchivo = item.GetName
                '    rutaImg = Session("rutaImg") & nombreArchivo
                'Next
                'If Me.RadUpImagen.UploadedFiles.Count = 0 Then
                '    ' nombreArchivo = Me.lblRadImagen.Text
                '    nombreArchivo = Session("lblRadImagen")
                '    rutaImg = Session("rutaImg") & nombreArchivo
                'End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Public Sub HabilitaControl(ByVal Flag As Boolean)
        Try
            Me.RadUpArchivo.Enabled = Not Flag
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Private Sub ValidarDatos()
        Try
            ' If IsNullOrBlank(Me.txt_regusu_email01.Text) = False Or IsNullOrBlank(Me.txt_regusu_celular.Text) = False Then
            If txt_regusu_identificacion.Text = "" Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Debe ingresar identificacion del cliente.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            Else
                If txt_regusu_clave.Text = "" Then
                    ProveedorMensaje.ShowMessage(rntMensajes, "Debe ingresar clave del cliente.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Else
                    If txt_regusu_usuario.Text = "" Then
                        ProveedorMensaje.ShowMessage(rntMensajes, "Debe ingresar usuario soporte.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                    Else
                        'DTUserExiste = Contraseña.VerificaUsuarioExiste(Me.txt_regusu_email01.Text, Me.txt_regusu_celular.Text).Tables(0)
                        dTUserExiste = Contraseña.ConsultaClave(Me.txt_regusu_identificacion.Text).Tables(0)
                        If dTUserExiste.Rows.Count > 0 Then
                            'If dTUserExiste.Rows(0)("CLAVE") <> Me.txt_regusu_clave.Text Then
                            'End If
                            Me.txt_regusu_nombre.Text = dTUserExiste.Rows(0)("APELLIDO") + " " + dTUserExiste.Rows(0)("NOMBRE")
                            Session("id_cliente") = Me.txt_regusu_identificacion.Text
                            Session("nombre") = dTUserExiste.Rows(0)("NOMBRE")
                            Session("apellido") = dTUserExiste.Rows(0)("APELLIDO")
                            Session("contraseña") = dTUserExiste.Rows(0)("CONTRASENIA")
                            Session("clave") = dTUserExiste.Rows(0)("CLAVE")
                            Session("correo") = dTUserExiste.Rows(0)("EMAIL1")
                            CargaPreguntasAleatorias()
                            'ConfigControles(2)
                        Else
                            'ConfigControles(1)
                            'ConfigMsg(2, "Usuario no existe por favor verificar")
                            ProveedorMensaje.ShowMessage(rntMensajes, "Cliente no existe por favor verificar.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub Btnverifica_Click(sender As Object, e As System.EventArgs) Handles BtnVerificar.Click
        Try
            ValidarDatos()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub CargaPreguntasAleatorias()
        Try
            DTPreguntasAleatorias = Contraseña.ConsultaPreguntasRespuestas(Session("id_cliente"))
            If DTPreguntasAleatorias.Tables(0).Rows.Count > 0 Then
                Me.cbx_regusu_pregunta_011.Text = DTPreguntasAleatorias.Tables(0).Rows(0)("DESCRIPCION")
                'Me.lbl_prg_id_01.Text = DTPreguntasAleatorias.Tables(0).Rows(0)("PREGUNTA_ID")
                Me.txt_regusu_respuesta01.Text = DTPreguntasAleatorias.Tables(0).Rows(0)("RESPUESTA_DESC")
                'Me.lbl_regusu_pregunta01.Text = DTPreguntasAleatorias.Tables(0).Rows(0)("DESCRIPCION")
                If DTPreguntasAleatorias.Tables(0).Rows.Count = 2 Then
                    Me.cbx_regusu_pregunta_022.Text = DTPreguntasAleatorias.Tables(0).Rows(1)("DESCRIPCION")
                    Me.txt_regusu_respuesta02.Text = DTPreguntasAleatorias.Tables(0).Rows(1)("RESPUESTA_DESC")
                End If
                If DTPreguntasAleatorias.Tables(0).Rows.Count = 3 Then
                    Me.cbx_regusu_pregunta_033.Text = DTPreguntasAleatorias.Tables(0).Rows(2)("DESCRIPCION")
                    Me.txt_regusu_respuesta03.Text = DTPreguntasAleatorias.Tables(0).Rows(2)("RESPUESTA_DESC")
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub Btncancelar_Click(sender As Object, e As System.EventArgs) Handles Btncancelar.Click
        Me.txt_regusu_usuario.Text = ""
        Me.txt_regusu_clave.Text = ""
        Me.txt_regusu_identificacion.Text = ""
        Me.txt_regusu_nombre.Text = ""
        Me.cbx_regusu_pregunta_011.Text = ""
        Me.cbx_regusu_pregunta_022.Text = ""
        Me.cbx_regusu_pregunta_033.Text = ""
        Me.txt_regusu_respuesta01.Text = ""
        Me.txt_regusu_respuesta02.Text = ""
        Me.txt_regusu_respuesta03.Text = ""
        'Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalir.Click
        'Try
        Session.Clear()
        Session.Abandon()
        Response.Redirect("login.aspx", False)
        'Catch ex As Exception
        ''ExceptionHandler.Captura_Error(ex)
        'End Try
    End Sub


    Private Sub Btngrabar_Click(sender As Object, e As System.EventArgs) Handles Btngrabar.Click
        'Dim objregusu As New Contraseña
        'me.lblarchivo.text     Me.lblImagenVisualiza.Text
        Dim valueRegistro As Integer = 0
        'value_registro = objregusu.RegistroSoporteCliente(Me.txt_regusu_identificacion.Text, Me.txt_regusu_clave.Text, Me.txt_regusu_usuario.Text, Me.cbx_regusu_pregunta_011.Text + " " + Me.txt_regusu_respuesta01.Text, _
        '                                  Me.txt_regusu_respuesta01.Text)
        If valueRegistro = 0 Then
            ProveedorMensaje.ShowMessage(rntMensajes, "Se ha enviado el correo " + txt_regusu_identificacion.Text.Trim, ProveedorMensaje.MessageStyle.OperacionExitosa, 2000)
            If Me.RadUpArchivo.InitialFileInputsCount = 0 Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Se ha enviado el correo " + txt_regusu_identificacion.Text.Trim, ProveedorMensaje.MessageStyle.OperacionExitosa, 2000)
            End If
            GeneraEmail()
        Else
            ProveedorMensaje.ShowMessage(rntMensajes, "No se ha podido registrar el usuario correctamente", ProveedorMensaje.MessageStyle.OperacionInvalida)
        End If
    End Sub


    Private Sub GeneraEmail()
        Try
            'Dim file As String = "\\10.100.107.14\ImagenesDocumentos\Comoactivarunacuentaycomoimprimirunafactura.docx"
            Dim mensaje As New StringBuilder
            'Dim nombreArchivo As String = ""
            'Dim rutaImg As String = ""
            Dim file As String = ""
            For Each item As Telerik.Web.UI.UploadedFile In Me.RadUpload1.UploadedFiles
                file = item.GetName
            Next
            If Me.RadUpArchivo.UploadedFiles.Count = 0 Then
                ProveedorMensaje.ShowMessage(rntMensajes, "No tiene archivo adjunto", ProveedorMensaje.MessageStyle.OperacionInvalida, 2000)
            End If
            Me.RadUpArchivo.DataBind()
            For Each item As Telerik.Web.UI.UploadedFile In Me.RadUpArchivo.UploadedFiles
                If item.GetExtension.ToUpper <> Session("extDoumento") Then
                    mensaje.Append("Extensión de documento debe ser: ").Append(Session("extDoumento"))
                    Throw New Exception(mensaje.ToString)
                End If
                If item.ContentLength > Session("tamDocumento") Then
                    ' mensaje.Append("Tamaño de documento debe ser hasta: ").Append(Session("tamDocumento")).Append(" bytes")
                    mensaje.Append("Tamaño de documento debe ser hasta: ").Append(Math.Round(((Session("tamDocumento") / 1024) / 1024))).Append(" Mb")
                    Throw New Exception(mensaje.ToString)
                End If
            Next
            For Each item As Telerik.Web.UI.UploadedFile In Me.RadUpArchivo.UploadedFiles
                file = item.GetName
                'rutaImg = Session("rutaImg") & nombreArchivo
            Next
            'Dim file As String = "\\10.100.107.216\tmp\Comoactivarunacuentaycomoimprimirunafactura.docx"
            Session("nombrepdf") = file
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            'Dim mailToCollection As [String]() = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString().Split(";")
            Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
            For Each mailTo As String In mailToCollection
                mailMessage.To.Add(mailTo)
            Next
            mailMessage.To.Add(HttpContext.Current.Session("correo").ToString())
            'mailMessage.Subject = Me.txt_asunto.Text.ToUpper()
            mailMessage.Subject = "Soporte al Cliente sitio Web"
            Dim attachment As New Attachment(Session("nombrepdf"))
            mailMessage.Attachments.Add(attachment)
            'mailMessage.Bcc.Add("fontaneda@carsegsa.com")
            'mailMessage.Bcc.Add("galvarado@carsegsa.com")
            mailMessage.Body = MailBody(Me.txt_regusu_nombre.Text.ToUpper(), Me.txt_regusu_contenido.Text, Me.txt_regusu_identificacion.Text)
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Shared Function MailBody(username As String, contenido As String, identificacion As String) As String
        Dim builder As New StringBuilder()
        Try
            builder.Append("<html><head><title>")
            builder.Append("</title><meta http-equiv=""Content-Type""")
            builder.Append("</head><body>")
            builder.Append("<h2 class=""h2""> </h2> <p><strong>Señor(a)(ita)</strong>  <strong>")
            builder.Append("</strong> </p> <p> <strong>" + username)
            'builder.Append("HttpContext.Current.Session(""user"").ToString()")
            builder.Append("</strong> <br/> </p> <p><br/> Estimado(a) Cliente: <br/> Estamos respondiendo a su inquietud ")
            builder.Append("</strong> <br/> </p> <p><br/> Su usuario registrado es:  " + identificacion)
            'builder.Append("S&#237;guenos en Twitter</a> </div> </td> </tr> <tr mc:hideable> <td align=""left"" valign=""middle"" width=""32""> <br/>")
            builder.Append("</strong> <br/> </p> <p><br/> <strong> </strong> ").Append(contenido)
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Comentario").ToString())
            builder.Append("<br/><br/><br/> <a title=""Descargar Manual de Usuario"" href=""https://www.hunteronline.com.ec/extranet/manual/ManualUsuarioHOnline.pdf"" target=""_blank"">Descargar Manual de Usuario de HunterOnline </a>")
            '<a class="linkmanualcss" href="https://www.hunteronline.com.ec/extranet/manual/ManualUsuarioHOnline.pdf" target="_blank">
            'builder.Append("<br/> <br/> <h2 class=""h2"">Nota: Favor no responder este email.</h2> <p> <br/> <br/> ")
            builder.Append("<br/> <br/> <br/> Copyright &copy; 2020 Carseg S.A., Todos los derechos reservados.")
            builder.Append("</body></html>")
            ' o con tilde  &#243;
            'builder.Append("<html><head><title>")
            'builder.Append("</title><meta http-equiv=""Content-Type""")
            'builder.Append("content=""text/html"";charset=""iso-8859-1""><style type=""text/css"">")
            'builder.Append("<!--.basix {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 9px;")
            'builder.Append("}.header1 {font-family: Verdana, Arial, Helvetica, sans-serif;")
            'builder.Append("font-size: 11px; color: #000000;}.tlbbkground1")
            'builder.Append(" {background-color: #EDEADF;border: 1px solid #EDEADF;}--></style></head><body>")
            'builder.Append("<table width=""70%"" border=""0"" align=""center"" cellpadding = ""5""")
            'builder.Append("cellspacing=""1"" class=""tlbbkground1""><tr bgcolor=""#EDEADF"">")
            'builder.Append("<td colspan=""2"" class=""header1""><div align=""center"">")
            'builder.Append("Soporte al Cliente : '").Append(ConfigurationManager.AppSettings.Get("ProyectName").ToString()).Append("', Cliente sin autenticar</div></tr>")
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Fecha y Hora</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"))
            'builder.Append("</td></tr>")
            'If HttpContext.Current.Session("Idcliente").ToString() <> "0000000000000" Then
            '    builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            '    builder.Append(" nowrap>Usuario</td>")
            '    builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Idcliente").ToString() + " " + HttpContext.Current.Session("cliente").ToString())
            '    builder.Append("</td></tr>")
            'End If
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Asunto</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Asunto").ToString())
            'builder.Append("</td></tr>")
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Correo</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Correo").ToString())
            'builder.Append("</td></tr>")
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Comentario</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Comentario").ToString())
            'builder.Append("</td></tr>")
            'builder.Append("</table></body></html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function


    Private Sub RadUpImagen_ValidatingFile(sender As Object, e As Telerik.Web.UI.Upload.ValidateFileEventArgs) Handles RadUpArchivo.ValidatingFile
        Try
            If e.UploadedFile.ContentLength > Session("tamDocumento") Then
                Session("tamanio") = e.UploadedFile.ContentLength
                e.IsValid = False
            Else
                Session("tamanio") = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class