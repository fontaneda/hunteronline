Imports Telerik.Web.UI
Imports System.Drawing.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports System.Net.Mail

Public Class ConsultaControlTaller
    Inherits System.Web.UI.Page

#Region "Eventos de pagina"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA COTERO
    ''' DESCR: EVENTO LOAD DE LA PANTALLA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConsultaControlTaller_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("qs") <> Nothing Then
                Dim retorno As String = Request.QueryString("qs")
                Dim orden As String = DecryptQueryString(retorno) 'retorno ' 
                CargaConsultaPrincipal(orden)
            End If
        End If
    End Sub

#End Region

#Region "Eventos de los controles"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA COTERO
    ''' DESCR: EVENTO CLICK DEL BOTON DE DESCARGAR EL CUAL LLAMA A UN JAVASCRIPT QUE PERMITIRA HACER DESCARGAS
    '''     POR CADA UNO DE LOS ARCHIVOS SIN EMPAQUETAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub LinkDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkDescargar.Click
        Try
            Dim script As String = ""
            script = "<script language='javascript'>fnOpen('" & Session("nombre_doc") & "','" & Session("archivo_server") & "','0');</script>;"
            'script = script.Replace("\", "\\")
            ClientScript.RegisterStartupScript(Me.GetType(), "key", script)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        Try
            If Me.txtemail.Text <> "" Then
                Dim rex As Regex = New Regex("^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$")
                Dim mailToCollection As [String]() = txtemail.Text.Split(";")
                For Each mailToo As String In mailToCollection
                    If EMailHandler.ValidarEMail(mailToo) Then
                        If rex.IsMatch(mailToo) = False Then
                            MostrarMensaje("Email es incorrecto. El separador de correo es "";""<br /> Formato: tucorreo@tudominio <br /><strong> " & mailToo & "</strong>")
                            Exit Sub
                        End If
                    End If
                Next
                EnvioEmailPdf()
            Else
                MostrarMensaje("El correo eletrónico no puede quedar vacío ")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub LinkReenviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkReenviar.Click
        Try
            ConfigControles(2)
            Me.txtemail.Text = ""
            Me.txtemail.Enabled = True
            Me.BtnEnviar.Enabled = True
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub CargaConsultaPrincipal(orden As String)
        Try
            Session("nombre_doc") = "ORDEN_" & orden & ".pdf" '& "_" & Date.Now.ToLongTimeString & ".pdf"
            Dim ruta As String = ConsultaRuta()
            Session("archivo_web") = "https://www.hunteronline.com.ec/IMGCOTIZADORWEB/ImagenesDocumentos/" & Session("nombre_doc")
            Session("archivo_server") = ruta & Session("nombre_doc")

            If (System.IO.File.Exists(Session("archivo_server"))) Then
                System.IO.File.Delete(Session("archivo_server"))
            End If

            Writefile2(orden, Session("nombre_doc"), ruta)
            myframe.Attributes.Add("src", Session("archivo_web"))
            ConfigControles(1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MostrarMensaje(ByVal mensaje As String)
        Try
            RnMensajesError.Text = mensaje
            RnMensajesError.Title = "Mensaje de la Aplicación HunterOnline"
            RnMensajesError.TitleIcon = "warning"
            RnMensajesError.ContentIcon = "warning"
            RnMensajesError.ShowSound = "warning"
            RnMensajesError.Width = 400
            RnMensajesError.Height = 100
            RnMensajesError.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function DecryptQueryString(ByVal strQueryString As String) As String
        Dim cifrado As String = String.Empty
        Dim obt As New GeneraDataCphr
        Try
            cifrado = obt.Descifrar(strQueryString, "r0b1nr0y")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return cifrado
    End Function

    Public Sub Writefile2(orden As String, nombre_doc As String, ruta As String)
        Try
            Dim objDocumento As New CreacionPdfControlCalidad
            objDocumento.GenerarDocumento(orden, nombre_doc, ruta)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    LinkReenviar.Enabled = True
                    LinkDescargar.Visible = False
                    LinkEmail.Visible = False
                    txtemail.Visible = False
                    BtnEnviar.Visible = False
                    BtnCancelar.Visible = False
                Case 2
                    LinkEmail.Visible = True
                    LinkReenviar.Visible = False
                    txtemail.Visible = True
                    BtnEnviar.Visible = True
                    BtnCancelar.Visible = True
                    LinkDescargar.Visible = False
                    LinkReenviar.Visible = False
                    Label11.Visible = False
            End Select
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
            Throw ex
        End Try
    End Sub

    Private Function ConsultaRuta() As String
        Dim retorno As String = ""
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = DocumentosAdapter.ConsultaRuta()
            retorno = dTCstGeneral.Tables(0).Rows(0)("RUTA_FILE")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function

    Private Sub EnvioEmailPdf()
        Dim verAnexo As Boolean = True
        Dim verXml As Boolean = True
        Dim verPdf As Boolean = True
        Try
            Dim correo As New System.Net.Mail.MailMessage()
            correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            Dim mailToCollection As [String]() = Me.txtemail.Text.Split(";")
            For Each mailToo As String In mailToCollection
                If EMailHandler.ValidarEMail(mailToo) Then
                    correo.To.Add(mailToo)
                End If
            Next
            Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
            Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
            For Each mailTooBcc As String In mailToBccCollection
                If EMailHandler.ValidarEMail(mailTooBcc) Then
                    correo.Bcc.Add(mailTooBcc)
                End If
            Next
            correo.Attachments.Add(New Attachment(Session("archivo_server")))
            correo.Subject = "Reenvío de Documento de control de talleres"
            Dim htmlbody As String = cuerpo_html()
            correo.Body = htmlbody
            correo.Priority = MailPriority.High
            correo.IsBodyHtml = True
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
            smtp.EnableSsl = False
            smtp.Send(correo)
            correo.Dispose()
            MostrarMensaje("Email enviado satisfactoriamente a: <strong> " & Me.txtemail.Text & "</strong>")
            Me.txtemail.Enabled = False
            Me.BtnEnviar.Enabled = False
        Catch ex As Exception
            MostrarMensaje("No existen el documento para ser Reenviado PDF")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function cuerpo_html() As String
        Dim html As String = ""
        html = html & "<html>"
        html = html & "<head>"
        html = html & "<meta http-equiv=""Content-Type\"" content=\""text/html; charset=UTF-8\"" />"
        html = html & "<meta property=""og:title"" content=""*|MC:SUBJECT|*"" />"
        html = html & "<style type=""text/css"" > "
        html = html & "	#outlook a{padding:0;} "
        html = html & "	body{width:100% !important;} "
        html = html & "	.ReadMsgBody{width:100%;} "
        html = html & "	.ExternalClass{width:100%;} "
        html = html & "	body{-webkit-text-size-adjust:none;} "
        html = html & "	body{margin:0; padding:0;} "
        html = html & "	img{border:0; height:auto; line-height:100%; outline:none; text-decoration:none;} "
        html = html & "	table td{border-collapse:collapse;} "
        html = html & "	#backgroundTable{height:100% !important; margin:0; padding:0; width:100% !important;} "
        html = html & "	body, #backgroundTable{background-color:#FAFAFA;} "
        html = html & "	#templateContainer{border: 1px solid #DDDDDD;} "
        html = html & "	h2, .h2{color:#202020; display:block; font-family:Arial; font-size:30px; font-weight:bold; line-height:100%; margin-top:0;	margin-right:0; margin-bottom:10px; margin-left:0; text-align:left;} "
        html = html & "	#templatePreheader{background-color:#FAFAFA;} "
        html = html & "	.headerContent{color:#202020; font-family:Arial; font-size:34px; font-weight:bold; line-height:100%; padding:0; text-align:center; vertical-align:middle;} "
        html = html & "	#headerImage{height:auto; max-width:600px;} "
        html = html & "	#templateContainer, .bodyContent{background-color:#FFFFFF;} "
        html = html & "	.bodyContent div{color:#505050; font-family:Arial; font-size:14px; line-height:150%; text-align:left;} "
        html = html & "	.bodyContent div a:link, .bodyContent div a:visited, .bodyContent div a .yshortcuts{color:#336699; font-weight:normal; text-decoration:underline;} "
        html = html & "	.sidebarContent div{color:#505050; font-family:Arial; font-size:12px; line-height:150%; text-align:left;} "
        html = html & "	.sidebarContent div a:link, .sidebarContent div a:visited,.sidebarContent div a .yshortcuts {color:#336699; font-weight:normal;	text-decoration:underline;} "
        html = html & "	.footerContent div{color:#707070; font-family:Arial; font-size:12px; line-height:125%; text-align:left;} "
        html = html & "	.footerContent img{display:inline; text-align:center;} "
        html = html & "	#social div{text-align:center;}"
        html = html & " </style>"
        html = html & " </head>"
        html = html & " <body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" >"
        html = html & " <center>"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""backgroundTable"" >"
        html = html & " <tr>"
        html = html & " <td align=""center"" valign=""top"">"
        html = html & " <table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""600"" id=""templatePreheader"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"" class=""preheaderContent"">"
        html = html & " <table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""100%"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"" >"
        html = html & " </td>"
        html = html & " <td valign=""top"" width=""190"" >"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateContainer"" >"
        html = html & " <tr>"
        html = html & " <td align=""center"" valign=""top"">"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateHeader"" >"
        html = html & " <tr>"
        html = html & " <td class=""headerContent"">"
        html = html & " <img src=""http://www.hunter.com.ec/img/LogoHunterOnlineEamil.png"" style=""max-width:800px;"" id=""headerImage campaign-icon"" mc:label=""header_image"" mc:edit=""header_image"" mc:allowdesigner mc:allowtext />"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " <tr>"
        html = html & " <td align=""center"" valign=""top"">"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" id=""templateBody"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"">"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"" class=""bodyContent"">"
        html = html & " <table border=""0"" cellpadding=""20"" cellspacing=""0"" width=""100%"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"">"
        html = html & " <div mc:edit=""std_content00"">"
        html = html & " <h2 class=""h2"" >"
        html = html & " Reenvío de documento de taller"
        html = html & " </h2>"
        html = html & " <p>"
        html = html & " <br/>"
        html = html & " <strong>"
        html = html & " Estimado(a) Cliente:"
        html = html & " </strong>"
        html = html & " <br/>"
        html = html & " <br/>"
        html = html & " S&#237;rvase usted, encontrar el documento solicitado como archivo adjunto en este email."
        html = html & " <br/>"
        html = html & " <br/>"
        html = html & " <br/>"
        html = html & " <em>"
        html = html & " <strong> "
        html = html & " Nota: Favor no responder este email. "
        html = html & " </strong>"
        html = html & " </em>"
        html = html & " </p>"
        html = html & " </div>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " <td valign=""top"" width=""200"" id=""templateSidebar"">"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""200"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"" class=""sidebarContent"">"
        html = html & " <table border=""0"" cellpadding=""20"" cellspacing=""0"" width=""100%"" >"
        html = html & " <tr mc:repeatable>"
        html = html & " <td height=""115"" align=""center"" valign=""top"">"
        html = html & " <img src=""http://www.hunter.com.ec/img/activekey.png"" style=""max-width:100px;"" mc:label=""image"" mc:edit=""tiwc200_image00""/>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"" style=""padding-top:10px; padding-right:20px; padding-left:20px;"">"
        html = html & " <table width=""169"" border=""0"" cellpadding=""0"" cellspacing=""4"" >"
        html = html & " <tr mc:hideable>"
        html = html & " <td align=""left"" valign=""middle"" width=""32"">"
        html = html & " <img src=""http://www.hunter.com.ec/img/sfs_icon_facebook.png"" style=""margin:0 !important;""/>"
        html = html & " </td>"
        html = html & " <td width=""122"" align=""left"" valign=""top"">"
        html = html & " <div mc:edit=""sbwi_link_one"">"
        html = html & " <a href=""https://www.facebook.com/hunterecuador"" target=""_blank"" >"
        html = html & " S&#237;guenos Facebook"
        html = html & " </a>"
        html = html & " </div>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " <tr mc:hideable>"
        html = html & " <td align=""left"" valign=""middle"" width=""32"">"
        html = html & " <img src=""http://www.hunter.com.ec/img/sfs_icon_twitter.png"" style=""margin:0 !important;""/>"
        html = html & " </td>"
        html = html & " <td align=""left"" valign=""top"">"
        html = html & " <div mc:edit=""sbwi_link_two"">"
        html = html & " <a href=""http://twitter.com/hunterEcuador"" target=""_blank"" >"
        html = html & " S&#237;guenos en Twitter"
        html = html & " </a>"
        html = html & " </div>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " <tr mc:hideable>"
        html = html & " <td align=""left"" valign=""middle"" width=""32"">"
        html = html & " <img src=""http://www.hunter.com.ec/img/sfs_icon_youtube.png"" style=""margin:0 !important;""/>"
        html = html & " </td>"
        html = html & " <td align=""left"" valign=""top"">"
        html = html & " <div mc:edit=""sbwi_link_three"">"
        html = html & " <a href=""http://www.youtube.com/user/huntercarsegec"" target=""_blank"" >"
        html = html & " S&#237;guenos en YouTube"
        html = html & " </a>"
        html = html & " </div>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " <tr>"
        html = html & " <td align=""center"" valign=""top"">"
        html = html & " <table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""600"" id=""templateFooter"" >"
        html = html & " <tr>"
        html = html & " <td valign=""top"" class=""footerContent"">"
        html = html & " <table border=""0"" cellpadding=""10"" cellspacing=""0"" width=""100%"" > "
        html = html & " <tr>"
        html = html & " <td colspan=""2"" valign=""middle"" id=""social"">"
        html = html & " <div mc:edit=""std_footer"" >"
        html = html & " <em>"
        html = html & " Copyright &copy; 2020 Carseg S.A. , Todos los derechos reservados."
        html = html & " </em>"
        html = html & " <br/>"
        html = html & " </div>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table>"
        html = html & " <br/>"
        html = html & " </td>"
        html = html & " </tr>"
        html = html & " </table> "
        html = html & " </center>"
        html = html & " </body>"
        html = html & " </html>"

        Return html
    End Function

#End Region

End Class