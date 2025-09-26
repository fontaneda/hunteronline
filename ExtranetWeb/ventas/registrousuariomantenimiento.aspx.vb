Public Class registrousuariomantenimiento
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Creación usuarios", 9, "Crear usuarios para chequeos")
                    mensajeria_error("", "")
                    ConfigControles(1)
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

    Private Sub txtcedula01reg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcedula01reg.TextChanged
        Try
            Dim rex As Regex = New Regex("((\(\d{10}\) ?)|(\d{10}))")
            If rex.IsMatch(Me.txtcedula01reg.Text.Trim()) = False Then
                ConfigControles(1)
                mensajeria_error("error", "por favor ingrese una identificación correcta.")
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.txtcedula01reg.Text.Trim()) Then
                mensajeria_error("error", "por favor ingrese su identificación.")
                Exit Sub
            End If

            VerificaUsuarioExiste()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btncrearreg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncrearreg.Click
        Try
            If validar() Then
                RegistroDatosNuevoUsuario()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    Private Sub VerificaUsuarioExiste()
        Try
            If IsNullOrBlank(txtcedula01reg.Text.Trim()) = False Then
                Dim dTUserExiste As DataTable
                dTUserExiste = RegistroUsuarioAdapter.VerificaUsuarioExiste(txtcedula01reg.Text.Trim(), 165).Tables(0)
                Session("tipoexistenciausuario") = ""
                If dTUserExiste.Rows.Count > 0 Then
                    Dim valueExisteUsuario As Integer = dTUserExiste.Rows(0)("VALOR")
                    Dim valueEmail As String = dTUserExiste.Rows(0)("EMAIL1")
                    Dim valueNombres As String = dTUserExiste.Rows(0)("PRIMER_NOMBRE")
                    Dim valueApellidos As String = dTUserExiste.Rows(0)("PRIMER_APELLIDO")
                    Dim valuecelular As String = dTUserExiste.Rows(0)("TELEFONO_1")
                    If valueExisteUsuario = 1 Then
                        Session("tipoexistenciausuario") = "nuevorol"
                        ConfigControles(2)
                        mensajeria_error("alerta", "su identificación ya tiene vehículos propios, se agregará un nuevo rol.")
                        VerificaYCargaDatos(valueEmail, valueNombres, valueApellidos, valuecelular)
                    ElseIf valueExisteUsuario = 2 Or valueExisteUsuario = 3 Then
                        Session("tipoexistenciausuario") = "nuevo"
                        ConfigControles(1)
                    ElseIf valueExisteUsuario = 4 Then
                        Session("tipoexistenciausuario") = "inactivo"
                        ConfigControles(3)
                        mensajeria_error("error", "el usuario aun no ha sido activado, debe completar ese proceso pendiente.")
                        VerificaYCargaDatos(valueEmail, valueNombres, valueApellidos, valuecelular)
                    End If
                End If
            End If
        Catch ex As Exception
            ConfigControles(1)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub VerificaYCargaDatos(ByVal email As String, ByVal nombre As String, ByVal apellido As String, ByVal celular As String)
        Try
            txtemailreg.Value = email
            txtnombrereg.Value = nombre
            txtapellidoreg.Value = apellido
            txtccelularreg.Value = celular
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    txtcedula01reg.Enabled = True
                    txtemailreg.Disabled = False
                    txtnombrereg.Disabled = False
                    txtapellidoreg.Disabled = False
                    txtclavereg.Disabled = False
                    txtclaveconfirmarreg.Disabled = False
                    txtccelularreg.Disabled = False
                    txtfechaexpira.Enabled = True
                    btncrearreg.Enabled = True
                    dvdmensajes.Visible = False
                Case 2
                    txtcedula01reg.Enabled = False
                    txtemailreg.Disabled = True
                    txtnombrereg.Disabled = True
                    txtapellidoreg.Disabled = True
                    txtclavereg.Disabled = False
                    txtclaveconfirmarreg.Disabled = False
                    txtccelularreg.Disabled = True
                    txtfechaexpira.Enabled = True
                    btncrearreg.Enabled = True
                    dvdmensajes.Visible = False
                Case 3
                    txtcedula01reg.Enabled = False
                    txtemailreg.Disabled = True
                    txtnombrereg.Disabled = True
                    txtapellidoreg.Disabled = True
                    txtclavereg.Disabled = True
                    txtclaveconfirmarreg.Disabled = True
                    txtccelularreg.Disabled = True
                    txtfechaexpira.Enabled = False
                    btncrearreg.Enabled = False
                    dvdmensajes.Visible = False
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function validar() As Boolean
        Dim retorno As Boolean = True
        If Me.txtclavereg.Value <> Me.txtclaveconfirmarreg.Value Then
            mensajeria_error("error", "Por favor verificar las contraseñas, no son iguales")
            retorno = False
        End If
        If Me.txtclavereg.Value = "" Then
            mensajeria_error("error", "Por favor verificar la contraseña nueva")
            txtclavereg.Focus()
            retorno = False
        End If
        If Me.txtclaveconfirmarreg.Value = "" Then
            mensajeria_error("error", "Por favor verificar la confirmación de la contraseña")
            txtclaveconfirmarreg.Focus()
            retorno = False
        End If
        If Me.txtccelularreg.Value = "" Then
            mensajeria_error("error", "Por favor verificar el celular de contacto")
            txtccelularreg.Focus()
            retorno = False
        End If
        If Convert.ToDateTime(txtfechaexpira.Text) <= Date.Now Then
            mensajeria_error("error", "Por favor verificar la fecha de expiración")
            txtfechaexpira.Focus()
            retorno = False
        End If

        Return retorno
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
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub RegistroDatosNuevoUsuario()
        Try
            Dim idcliente, nombre, apellido, password, telefono1, email1 As String
            Dim valueRegistroUsuario As Integer
            Dim valueCondServPolt As Integer = 0
            Dim objregusu As New RegistroUsuarioAdapter
            Dim fecha_expira As Date = txtfechaexpira.Text
            idcliente = txtcedula01reg.Text.Trim()
            email1 = txtemailreg.Value
            Session("password") = txtclavereg.Value
            password = txtclavereg.Value
            nombre = txtnombrereg.Value
            apellido = txtapellidoreg.Value
            telefono1 = txtccelularreg.Value
            valueCondServPolt = If(chkaceptarreg.Checked = True, 1, 0)

            If digito_verificador(idcliente) Then
                valueRegistroUsuario = objregusu.RegistroDatosPersonalesUsuarioWeb_Rol(idcliente, Session("user_id"), nombre, apellido, _
                                                                                       email1, Session("password"), telefono1, _
                                                                                       valueCondServPolt, fecha_expira)
                If valueRegistroUsuario = 0 Then
                    If Not Session("tipoexistenciausuario") = "nuevorol" Then
                        GeneraEmailActivacionMantenimiento()
                    End If
                    GeneraEmailActivacion()
                    LimpiaControles()
                    ConfigControles(1)
                    mensajeria_error("informacion", "Para concluir con el proceso de registro, confirme el correo que hemos enviado al email registrado, Gracias por preferirnos.")
                Else
                    mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
                End If
            Else
                lblmensajeerror.InnerText = "Por favor ingrese una identificación válida"
                Exit Sub
            End If
        Catch ex As Exception
            mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LimpiaControles()
        Try
            txtcedula01reg.Text = ""
            txtemailreg.Value = ""
            txtclavereg.Value = ""
            txtclaveconfirmarreg.Value = ""
            txtnombrereg.Value = ""
            txtapellidoreg.Value = ""
            txtccelularreg.Value = ""
            mensajeria_error("", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GeneraEmailActivacion()
        Try
            If HttpContext.Current IsNot Nothing Then
                Dim dTLinkActiv As DataSet
                dTLinkActiv = RegistroUsuarioAdapter.GeneraLinkActivacion
                If dTLinkActiv.Tables(0).Rows.Count > 0 Then
                    Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, valueCfr02, valueCfr03, urlActivacion, valueFecha, urlFechaparm, urlPromocion As String
                    strDominio = dTLinkActiv.Tables(0).Rows(0)("FORM_DOMINIO")
                    strFormulario = dTLinkActiv.Tables(0).Rows(0)("FORM_ASP")
                    strPrm01 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO")
                    strPrm02 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO02")
                    strPrm03 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO03")
                    valueCfr01 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(Me.txtcedula01reg.Text.Trim())))
                    urlActivacion = strDominio & strFormulario & strPrm01 & valueCfr01
                    valueFecha = FechaSistema()
                    valueCfr02 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(valueFecha)))
                    urlFechaparm = strPrm02 & valueCfr02
                    valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(0)("PROMOCION"))))
                    urlPromocion = strPrm03 & valueCfr03
                    urlActivacion = urlActivacion & "&" & urlFechaparm & "&" & urlPromocion
                    Dim dTEmailAct As DataSet
                    dTEmailAct = RegistroUsuarioAdapter.GeneraEmailActivacion(Me.txtcedula01reg.Text.Trim(), txtemailreg.Value, _
                                                                              Me.txtnombrereg.Value, Me.txtapellidoreg.Value, urlActivacion)
                    If dTEmailAct.Tables(0).Rows.Count > 0 Then
                        Dim strMailMsg, strMailTitle As String
                        strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                        strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                        EnvioEmailExterno(Me.txtemailreg.Value, strMailTitle, strMailMsg)
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

    Private Sub GeneraEmailActivacionMantenimiento()
        Try
            If HttpContext.Current IsNot Nothing Then
                Dim dTLinkActiv As DataSet
                dTLinkActiv = RegistroUsuarioAdapter.GeneraLinkActivacion
                If dTLinkActiv.Tables(0).Rows.Count > 0 Then
                    Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, valueCfr02, valueCfr03, _
                        valueFecha, urlFechaparm, urlPromocion As String
                    'urlActivacion
                    strDominio = dTLinkActiv.Tables(0).Rows(0)("FORM_DOMINIO")
                    strFormulario = dTLinkActiv.Tables(0).Rows(0)("FORM_ASP")
                    strPrm01 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO")
                    strPrm02 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO02")
                    strPrm03 = dTLinkActiv.Tables(0).Rows(0)("FORM_PARAMETRO03")
                    valueCfr01 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(Me.txtcedula01reg.Text.Trim())))
                    'urlActivacion = strDominio & strFormulario & strPrm01 & valueCfr01
                    valueFecha = FechaSistema()
                    valueCfr02 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(valueFecha)))
                    urlFechaparm = strPrm02 & valueCfr02
                    valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(0)("PROMOCION"))))
                    urlPromocion = strPrm03 & valueCfr03
                    'urlActivacion = urlActivacion & "&" & urlFechaparm & "&" & urlPromocion
                    Dim dTEmailAct As DataSet
                    dTEmailAct = RegistroUsuarioAdapter.GeneraEmailActivacionMantenimiento(Me.txtcedula01reg.Text.Trim(), txtemailreg.Value, _
                                                                              Me.txtnombrereg.Value, Me.txtapellidoreg.Value, "")
                    If dTEmailAct.Tables(0).Rows.Count > 0 Then
                        Dim strMailMsg, strMailTitle As String
                        strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                        strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                        EnvioEmailExterno(Me.txtemailreg.Value, strMailTitle, strMailMsg)
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

    Private Sub mensajeria_error(ByVal tipo As String, ByVal mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        dvdmensajes.Visible = False
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

    Private Function digito_verificador(ByVal texto As String) As Boolean
        Dim retorno As Boolean = False

        Dim dTValidaId As New DataSet
        dTValidaId = DatosPersonalesAdapter.ValidaCedula(texto)
        If dTValidaId.Tables(0).Rows.Count > 0 Then
            If dTValidaId.Tables(0).Rows(0).Item(0) = "1" Then
                retorno = True
            End If
        End If

        Return retorno
    End Function

    Private Sub metodos_master(ByVal titulo As String, ByVal itemmnu As Integer, ByVal ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

#End Region


End Class