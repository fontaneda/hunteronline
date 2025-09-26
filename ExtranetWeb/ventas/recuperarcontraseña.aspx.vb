Public Class recuperarcontraseña

    Inherits System.Web.UI.Page
    Dim dTPreguntasAleatorias As DataSet
    Dim dTUserExiste As DataTable
    Dim dTComparar As DataTable
    Dim dTLinkActiv As DataSet
    Dim dTEmailAct As DataSet

#Region "Eventos de la pagina"

    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: EVENTO LOAD EL FORMULARIO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ConfigControles(1)
                LimpiarControl()
                Session("id_cliente") = Nothing
                'Else
                '    If Not CType(Session("id_cliente"), DataSet) Is Nothing Then
                '        If CType(Session("id_cliente"), DataSet).Tables.Count > 0 Then
                '        End If
                '    End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: VERIFICA SI EL USUARIO EXISTE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VerificaUsuarioExiste()
        Try
            ' If IsNullOrBlank(Me.txt_regusu_email01.Text) = False Or IsNullOrBlank(Me.txt_regusu_celular.Text) = False Then
            If IsNullOrBlank(Me.txt_regusu_email01.Text) = False Then
                'DTUserExiste = Contraseña.VerificaUsuarioExiste(Me.txt_regusu_email01.Text, Me.txt_regusu_celular.Text).Tables(0)
                dTUserExiste = Contraseña.VerificaUsuarioExiste(Me.txt_regusu_email01.Text, "").Tables(0)
                If dTUserExiste.Rows.Count > 0 Then
                    Session("id_cliente") = dTUserExiste.Rows(0)("CODIGO_REFERENCIAL")
                    Session("nombre") = dTUserExiste.Rows(0)("NOMBRE")
                    Session("apellido") = dTUserExiste.Rows(0)("APELLIDO")
                    Session("contraseña") = dTUserExiste.Rows(0)("CONTRASEÑA")
                    Session("clave") = dTUserExiste.Rows(0)("CLAVE")
                    CargaPreguntasAleatorias()
                    'If IsNullOrBlank(Me.txt_regusu_email01.Text) Then
                    '    'Me.txt_regusu_email01.Text = "0"
                    '    Me.vld_txt_regusu_email01.ControlToValidate = "txt_regusu_celular"
                    'End If
                    'If IsNullOrBlank(Me.txt_regusu_celular.Text) Then
                    '    'Me.txt_regusu_celular.Text = "0"
                    '    Me.vld_txt_regusu_celular.ControlToValidate = "txt_regusu_email01"
                    'End If
                    ConfigControles(2)
                Else
                    ConfigControles(1)
                    'ConfigMsg(2, "Usuario no existe por favor verificar")
                    ProveedorMensaje.ShowMessage(rntMensajes, "Usuario no existe por favor verificar.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LimpiarControl()
        Try
            txt_regusu_respuesta01.Text = ""
            txt_regusu_email01.Text = ""
            'txt_regusu_celular.Text = ""
            'txt_regusu_RadCaptcha.Text = ""
            Me.vld_txt_regusu_email01.ControlToValidate = "txt_regusu_email01"
            'Me.vld_txt_regusu_celular.ControlToValidate = "txt_regusu_celular"
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: CARGA LA PREGUNTA ALEATORIAMENTE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaPreguntasAleatorias()
        Try
            dTPreguntasAleatorias = Contraseña.ConsultaPreguntasAleatorias(Session("id_cliente"))
            If dTPreguntasAleatorias.Tables(0).Rows.Count > 0 Then
                Me.lbl_prg_id_01.Text = dTPreguntasAleatorias.Tables(0).Rows(0)("PREGUNTA_ID")
                Me.lbl_regusu_pregunta01.Text = dTPreguntasAleatorias.Tables(0).Rows(0)("DESCRIPCION")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: CONFIGURACION DE CONTROLES
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    Me.lbl_prg_id_01.Visible = False
                    Me.lbl_regusu_pregunta01.Visible = False
                    txt_regusu_respuesta01.Enabled = False
                    'txt_regusu_email01.Enabled = False
                    Me.Btnrecordar.Enabled = False
                    Me.Btnproxima.Enabled = False
                    RadCaptcha1.Enabled = False
                    txt_regusu_email01.Enabled = True
                    ' txt_regusu_celular.Enabled = True
                    'txt_regusu_celular.Visible = False
                    Me.btn_RadCaptcha.Enabled = False
                Case 2
                    Me.lbl_regusu_pregunta01.Visible = True
                    txt_regusu_respuesta01.Enabled = True
                    'txt_regusu_email01.Enabled = True
                    Me.Btnrecordar.Enabled = True
                    Me.Btnproxima.Enabled = True
                    RadCaptcha1.Enabled = True
                    txt_regusu_email01.Enabled = False
                    'txt_regusu_celular.Visible = False
                    Me.btn_RadCaptcha.Enabled = True

            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Controles"

    'Protected Sub txt_regusu_celular_TextChanged(sender As Object, e As EventArgs) Handles txt_regusu_celular.TextChanged
    '    Try
    '        If Session("id_cliente") = Nothing Then
    '            VerificaUsuarioExiste()
    '        End If
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    Protected Sub txt_regusu_email01_TextChanged(sender As Object, e As EventArgs) Handles txt_regusu_email01.TextChanged
        Try
            If Session("id_cliente") = Nothing Then
                VerificaUsuarioExiste()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Botones"


    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: EVENTO BOTON RECORDAR ENVIA LOS DATOS INGRESADOS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Btnrecordar_Click(sender As Object, e As EventArgs) Handles Btnrecordar.Click
        Try
            RadCaptcha1.Validate()
            Page.Validate()
            If (Page.IsValid And RadCaptcha1.IsValid) Then
                dTComparar = Contraseña.VerificaComparar(Session("id_cliente"), Me.lbl_prg_id_01.Text, Me.txt_regusu_respuesta01.Text).Tables(0)
                If dTComparar.Rows.Count > 0 Then
                    ConfigControles(1)
                    Me.lbl_regusu_pregunta01.Visible = True
                    Me.txt_regusu_email01.Enabled = False
                    'Me.txt_regusu_celular.Enabled = False
                    GeneraEmailActivacion()
                    LimpiarControl()
                    'Me.vld_txt_regusu_email01.ControlToValidate = "txt_regusu_email01"
                    'Me.vld_txt_regusu_celular.ControlToValidate = "txt_regusu_celular"
                    'ConfigMsg(1, "Se envió el password a su correo")
                    ProveedorMensaje.ShowMessage(rntMensajes, "Se envió el password a su correo.", ProveedorMensaje.MessageStyle.OperacionExitosa)
                Else
                    'ConfigMsg(2, "La Respuesta es Incorrecta intente de nuevo")
                    ProveedorMensaje.ShowMessage(rntMensajes, "La Respuesta es Incorrecta intente de nuevo.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            Else
                If Not (Page.IsValid) Then
                    'ConfigMsg(3, "Verificar los datos ingresados ")
                    ProveedorMensaje.ShowMessage(rntMensajes, "Verificar los datos ingresados.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                ElseIf Not (RadCaptcha1.IsValid) Then
                    'ConfigMsg(3, "El código es incorrectamente ")
                    ProveedorMensaje.ShowMessage(rntMensajes, "El código es incorrectamente.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: EVENTO BOTON PROXIMA PREGUNTA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Btnproxima_Click(sender As Object, e As EventArgs) Handles Btnproxima.Click
        Try
            CargaPreguntasAleatorias()
            ' LimpiarControl()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub Btnlimpiar_Click(sender As Object, e As EventArgs) Handles Btnlimpiar.Click
        Try
            LimpiarControl()
            ConfigControles(1)
            Session("id_cliente") = Nothing
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            Session.Clear()
            Session.Abandon()
            'Response.Redirect("login.aspx", False)
            Response.Redirect("login.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Correo"


    ''' <summary>
    ''' FECHA: 17/03/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: GENERACION DEL MAIL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraEmailActivacion()
        Try
            'Dim obt As New GeneraDataCphr
            Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, valueCfr02, valueCfr03, urlContraseña, urlFechaparm, urlClave, valueFecha As String
            Dim strMailMsg, strMailTitle As String
            If HttpContext.Current IsNot Nothing Then
                dTLinkActiv = Contraseña.GeneraLinkContrasenia()
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
                    valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(Session("clave"))))
                    urlClave = strPrm03 & valueCfr03
                    urlContraseña = urlContraseña & "&" & urlFechaparm & "&" & urlClave
                    dTEmailAct = Contraseña.GeneraEmailActivacion(Session("id_cliente"), Me.txt_regusu_email01.Text, Session("nombre"), Session("apellido"), urlContraseña, Session("clave"), "5")
                    If dTEmailAct.Tables(0).Rows.Count > 0 Then
                        strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                        'str_mail_title = DTEmailAct.Tables(0).Rows(0)("TITLE_HTML") 
                        strMailTitle = dTEmailAct.Tables(0).Rows(0)("CIUDAD") + ": " + dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                        EnvioEmailExterno(Me.txt_regusu_email01.Text, strMailTitle, strMailMsg)
                    Else
                        'ConfigMsg(2, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña")
                        ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                    End If
                Else
                    'ConfigMsg(2, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña")
                    ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Recuperación de Contraseña.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


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
        correo.To.Add(email)
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

#End Region

#Region "Funciones"

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
            Dim dayStr, monthStr, yearStr As String
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

#End Region



End Class