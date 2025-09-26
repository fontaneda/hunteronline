Imports Telerik.Web.UI
Imports System.Net.Mail

Public Class estadocuenta
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("user") = "0916517956"
        'Session("user_id") = "0916517956"
        'Session("display_name") = "YO"
        'Session("Email") = "fontaneda@carsegsa.com"
        'Session("usuario") = "fontan"
        'Session("Administrador") = "CLI"
        If Not IsPostBack Then
            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                Me.rdpFechaInicio.MinDate = "1/1/2012"
                Me.rdpFechaInicio.MaxDate = "31/12/" & Date.Now.Year
                Me.rdpFechaFin.MinDate = "1/1/2012"
                Me.rdpFechaFin.MaxDate = "31/12/" & Date.Now.Year
                Me.rdpFechaInicio.SelectedDate = Now.AddDays((Now.Day - 1) * -1)
                Me.rdpFechaFin.SelectedDate = Date.Now.Date
                control_email.Visible = False
            Else
                Response.Redirect("./login.aspx", False)
            End If
        End If

    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub rgdverifordenestado_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rgdverifordenestado.SelectedIndexChanged
        Dim item As GridDataItem = Nothing
        Dim documento As String = ""
        Dim cliente As String = ""
        Dim identificacion As String = ""
        Dim fecha As String = ""
        If rgdverifordenestado.SelectedItems.Count > 0 Then
            item = rgdverifordenestado.SelectedItems(0)
            documento = item("DOCUMENTO").Text.Trim.ToString
            cliente = item("CLIENTE_NOMBRE").Text.Trim.ToString
            identificacion = Session("user_id") 'item("CLIENTE").Text.Trim.ToString
            fecha = item("FECHA").Text.Trim.ToString
            Session("DOCUMENTO_CUENTA") = documento
        End If
        If documento <> "" Then
            Genera_Documento(documento, cliente, identificacion, fecha)
            control_email.Visible = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            If Me.rdpFechaInicio.SelectedDate > Me.rdpFechaFin.SelectedDate Then
                ProveedorMensaje.ShowMessage(rntMsgSistema, "La fecha hasta debe de ser mayor a la fecha desde.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            ConsultaInicial(True, 1, 0)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnEnviar_Click(sender As Object, e As System.EventArgs) Handles BtnEnviar.Click
        If Me.txtemail.Text <> "" Then
            Dim rex As Regex = New Regex("^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$")
            Dim dtcstGeneral As New System.Data.DataSet
            dtcstGeneral = DocumentosAdapter.EnvioFacturaCorreo(Session.Item("user"), Session("CODIGO_ID"), Me.txtemail.Text, 107, 0)
            Session("Email") = Nothing
            Session("Email") = dtcstGeneral
            If dtcstGeneral.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dtcstGeneral.Tables(0).Rows
                    If rex.IsMatch(row("Item").ToString()) = False Then
                        Dim mensaje_error As String = "Email es incorrecto. El separador de correo es "";""<br /> Formato: tucorreo@tudominio <br /><strong> " & row("Item").ToString() & "</strong>"
                        ProveedorMensaje.ShowMessage(rntMsgSistema, mensaje_error, ProveedorMensaje.MessageStyle.OperacionInvalida)
                        Exit Sub
                    End If
                Next
            End If
            EnvioEmailPdf(txtemail.Text, Session("DOCUMENTO_CUENTA"))
        Else
            ProveedorMensaje.ShowMessage(rntMsgSistema, "Email no puede quedar en blanco.", ProveedorMensaje.MessageStyle.OperacionInvalida)
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As System.EventArgs) Handles BtnCancelar.Click
        txtemail.Text = ""
        control_email.Visible = False
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub ConsultaInicial(ByVal mostrarMensaje As Boolean, opcion As Integer, documento As Integer)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = EstadoCuentaAdapter.ConsultaEstadosCuenta(Session.Item("user"), _
                                                                     rdpFechaInicio.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), _
                                                                     rdpFechaFin.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), _
                                                                     documento, opcion)
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                rgdverifordenestado.DataSource = dTCstGeneral
                rgdverifordenestado.DataBind()
            Else
                rgdverifordenestado.DataSource = Nothing
                rgdverifordenestado.DataBind()
                If mostrarMensaje Then
                    
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function Consultadocumento(opcion As Integer, documento As String) As DataSet
        Dim dTCstGeneral As New System.Data.DataSet
        Try
            dTCstGeneral = EstadoCuentaAdapter.ConsultaEstadosCuenta(Session.Item("user"), _
                                                                     rdpFechaInicio.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), _
                                                                     rdpFechaFin.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), _
                                                                     documento, opcion)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return dTCstGeneral
    End Function

    Private Sub Genera_Documento(documento As String, cliente As String, identificacion As String, fecha As String)
        Try
            Dim ruta_file As String = "\\10.100.107.14\ImagenesDocumentos\"
            Dim nombre_archivo As String = "estadocuenta_" & Session.Item("user") & ".pdf"
            Dim destino As String = ruta_file & nombre_archivo
            If (System.IO.File.Exists(destino)) Then
                System.IO.File.Delete(destino)
            End If
            Dim objDocumento As New DocumentosEstadoCuenta
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = Consultadocumento(2, documento)
            objDocumento.GenerarDocumento(documento, nombre_archivo, ruta_file, dTCstGeneral, cliente, identificacion, fecha)

            Dim file As String = "https://www.hunteronline.com.ec/IMGCOTIZADORWEB/ImagenesDocumentos/" & nombre_archivo
            Session("RutaEstadoCuenta") = file
            myframe.Attributes.Add("src", Session("RutaEstadoCuenta"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnvioEmailPdf(email_cadena As String, documento As String)
        Try
            Dim correo As New System.Net.Mail.MailMessage()
            Dim mailTo As String = email_cadena
            Dim mailToCollection As [String]() = mailTo.Split(";")
            Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
            Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
            Dim rutaestadocuenta As String = Session("RutaEstadoCuenta")

            correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            For Each mailToo As String In mailToCollection
                If EMailHandler.ValidarEMail(mailToo) Then
                    correo.To.Add(mailToo)
                End If
            Next
            For Each mailTooBcc As String In mailToBccCollection
                If EMailHandler.ValidarEMail(mailTooBcc) Then
                    correo.Bcc.Add(mailTooBcc)
                End If
            Next
            correo.Attachments.Add(New Attachment(rutaestadocuenta))
            correo.Subject = "Reenvío de Estado de cuenta desde HunterOnline"
            Dim dTCstData As New System.Data.DataSet
            dTCstData = Consultadocumento(3, documento)
            Dim htmlbody As String = dTCstData.Tables(0).Rows(0)("HTMLBODY")
            correo.Body = htmlbody
            correo.Priority = MailPriority.High
            correo.IsBodyHtml = True

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
            smtp.EnableSsl = False
            smtp.Send(correo)
            correo.Dispose()
            ProveedorMensaje.ShowMessage(rntMsgSistema, "Email enviado satisfactoriamente a: <strong> " & Me.txtemail.Text & "</strong>", ProveedorMensaje.MessageStyle.OperacionInvalida)
            Me.txtemail.Enabled = False
            Me.BtnEnviar.Enabled = False
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
            mensajes("No se pudo enviar, por favor intente en unos minutos")
        End Try
    End Sub

    Private Sub mensajes(mensaje As String)
        rntMsgSistema.Text = mensaje
        rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
        rntMsgSistema.TitleIcon = "warning"
        rntMsgSistema.ContentIcon = "warning"
        rntMsgSistema.ShowSound = "warning"
        rntMsgSistema.Width = 400
        rntMsgSistema.Height = 100
        rntMsgSistema.Show()
    End Sub

#End Region

End Class