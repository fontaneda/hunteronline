Imports Telerik.Web.UI

Public Class recuperar
    Inherits System.Web.UI.Page


#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ConfigControles(1)

                Dim objmail As New MailTrabajos
                'objmail.EnvioEmailConfirmaciónPago("100", CType(62807, Decimal))
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Protected Sub txtcedula_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtcedula.TextChanged
        Try
            'Dim rex As Regex = New Regex("((\(\d{10}\) ?)|(\d{10}))")
            'If rex.IsMatch(Me.txtcedula.Text.Trim()) = False Then
            '    ConfigControles(1)
            '    ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente, por favor ingrese una identificación correcta", ProveedorMensaje.MessageStyle.OperacionInvalida)
            '    Exit Sub
            'End If
            If String.IsNullOrEmpty(Me.txtcedula.Text.Trim()) Then

                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente, por favor ingrese su identificación .", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            VerificaUsuarioExiste()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnenviar_ServerClick(sender As Object, e As System.EventArgs) Handles btnenviar.ServerClick
        Try
            ''RadCaptcha1.Validate()
            ''Page.Validate()
            'If (Page.IsValid And RadCaptcha1.IsValid) Then
            Dim listaEmail As String = cmbemail.Value
                If Len(listaEmail) > 0 Then
                    ConfigControles(1)
                    Session("listaEmail") = listaEmail
                    GeneraEmailActivacion()
                    txtcedula.Enabled = False
                    btnenviar.Disabled = True
                    ' ProveedorMensaje.ShowMessage(rntMensajes, "Se envió el password a el correo. " & listaEmail, ProveedorMensaje.MessageStyle.OperacionExitosa)
                Else
                    ' ProveedorMensaje.ShowMessage(rntMensajes, "Seleccione un correo para el envió.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            'Else
            'If Not (Page.IsValid) Then
            'ProveedorMensaje.ShowMessage(rntMensajes, "Verificar los datos ingresados.", ProveedorMensaje.MessageStyle.OperacionInvalida)
            'ElseIf Not (RadCaptcha1.IsValid) Then
            '    ProveedorMensaje.ShowMessage(rntMensajes, "El código es incorrectamente.", ProveedorMensaje.MessageStyle.OperacionInvalida)
            'End If
            'End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    Me.btnenviar.Disabled = True
                    cmbemail.Disabled = True
                    'RadCaptcha1.Enabled = False
                    txtcedula.Enabled = True
                Case 2
                    Me.btnenviar.Disabled = False
                    cmbemail.Disabled = False
                    'RadCaptcha1.Enabled = True
                    txtcedula.Enabled = False
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub VerificaUsuarioExiste()
        Try
            If IsNullOrBlank(Me.txtcedula.Text.Trim()) = False Then
                Dim dTUserExiste As DataTable
                dTUserExiste = RegistroUsuarioAdapter.VerificaUsuarioExiste(txtcedula.Text.Trim(), 132).Tables(0)
                If dTUserExiste.Rows.Count > 0 Then
                    If dTUserExiste.Rows(0)("VALOR") = 1 Then
                        Dim dTUserCampo As DataTable
                        dTUserCampo = RegistroUsuarioAdapter.VerificaUsuarioExiste(txtcedula.Text.Trim(), 135).Tables(0)
                        If dTUserCampo.Rows.Count > 0 Then
                            Session("id_cliente") = dTUserCampo.Rows(0)("CODIGO_REFERENCIAL")
                            Session("contraseña") = dTUserCampo.Rows(0)("CONTRASEÑA")
                            ConsultaEmail()
                            ConfigControles(2)
                            Me.cmbemail.SelectedIndex = -1
                        Else
                            '            ConfigControles(1)
                            ''ProveedorMensaje.ShowMessage(rntMensajes, "Usuario no existe por favor verificar.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                        End If
                    ElseIf dTUserExiste.Rows(0)("VALOR") = 2 Then
                        Session("user") = Me.txtcedula.Text.Trim()
                        Response.Redirect("actualizacliente.aspx", False)
                    Else
                        ConfigControles(1)
                        'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente, su <strong>identificación</strong> no esta registrada en Hunter, le pedimos disculpa por la novedad presentada.</br>Para mayor información por favor comuníquese a nuestro Call center 04-600-4640 ó 1800-Hunter.", ProveedorMensaje.MessageStyle.OperacionInvalida, 9000)
                    End If

                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Sub ConsultaEmail()
        Try
            Dim datos As New RegistroUsuarioAdapter
            Dim dt As New DataTable
            dt.Load(datos.ConsultaEmail(txtcedula.Text.Trim()).CreateDataReader)
            cmbemail.DataSource = dt
            cmbemail.DataValueField = "CODIGO"
            cmbemail.DataTextField = "EMAIL"
            cmbemail.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GeneraEmailActivacion()
        Try
            Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, urlContraseña, valueCfr02, valueCfr03, urlFechaparm, urlClave, valueFecha As String
            Dim strMailMsg, strMailTitle As String
            If HttpContext.Current IsNot Nothing Then
                Dim valueRegistro As Integer = 0
                If valueRegistro = 0 Then
                    Dim dTLinkActiv As DataSet
                    dTLinkActiv = RegistroUsuarioAdapter.VerificaUsuarioExiste("", "134")
                    If dTLinkActiv.Tables(0).Rows.Count > 0 Then
                        strDominio = dTLinkActiv.Tables(0).Rows(0)("FORM_DOMINIO")
                        strFormulario = dTLinkActiv.Tables(0).Rows(0)("FORM_ASP")
                        strPrm01 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO")
                        strPrm02 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO02")
                        strPrm03 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO03")
                        valueCfr01 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(Session("id_cliente"))))
                        urlContraseña = strDominio & strFormulario & strPrm01 & valueCfr01
                        valueFecha = FechaSistema()
                        valueCfr02 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(valueFecha)))
                        urlFechaparm = strPrm02 & valueCfr02
                        valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(Session("contraseña"))))
                        urlClave = strPrm03 & valueCfr03
                        urlContraseña = urlContraseña & "&" & urlFechaparm & "&" & urlClave
                        Dim dTEmailAct As DataSet
                        dTEmailAct = Contraseña.GeneraEmailActivacion(Session("id_cliente"), Session("listaEmail"), "", "", urlContraseña, Session("contraseña"), "15")
                        If dTEmailAct.Tables(0).Rows.Count > 0 Then
                            strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                            strMailTitle = dTEmailAct.Tables(0).Rows(0)("CIUDAD") + ": " + dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                            EnvioEmailExterno(Session("listaEmail"), strMailTitle, strMailMsg)
                        Else
                            'ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                        End If
                    Else
                        'ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                    End If
                Else
                    'ProveedorMensaje.ShowMessage(rntMensajes, "No se ha podido cambiar contraseña correctamente", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
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
        Dim fechaStr As String = String.Empty
        Try
            Dim day, month As Integer
            Dim dayStr, monthStr, yearStr, hora, horaStr, minuto As String
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
            'Dim hora, minuto As String
            hora = DateTime.Now.ToString("HH") + 1
            If hora <= 9 Then
                horaStr = "0" & hora
            Else
                horaStr = hora.ToString
            End If
            minuto = DateTime.Now.ToString("mm")
            'fechaStr = hora & minuto
            fechaStr = yearStr & monthStr & dayStr & " " & horaStr & minuto
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return fechaStr
    End Function

    Public Function IsNullOrBlank(ByVal str As String) As Boolean
        Try
            If String.IsNullOrEmpty(str) Then
                Return True
            End If
            For Each c In str
                If Not Char.IsWhiteSpace(c) Then
                    Return False
                End If
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return True
    End Function

    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: GENERACION DEL CORREO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmailExterno(ByVal email As String, ByVal titulo As String, ByVal bodyhtml As String)
        Dim correo = New System.Net.Mail.MailMessage()
        correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
        Dim emailBccCollection As [String]() = email.Split(";")
        For Each mailTo As String In emailBccCollection
            If EMailHandler.ValidarEMail(mailTo) Then
                correo.To.Add(mailTo)
            End If
        Next
        'correo.To.Add(email)
        Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("RegistroUsuarioMailToBcc").ToString()
        Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
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