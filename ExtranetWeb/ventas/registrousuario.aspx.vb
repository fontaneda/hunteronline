'Imports Telerik.Web.UI

Public Class registrousuario
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ConfigControles(1)
                ListaGeneralAnios()
                ListaGeneralMeses()
                DefineFechaDefault()
                ListaGeneralDias(ObtenerMesSeleccionado, ObtenerAnioSeleccionado)
                dtpfechadia.SelectedValue = DateTime.Now.Day
                dtpfechames.SelectedValue = DateTime.Now.Month
                dtpfechaanio.SelectedValue = DateTime.Now.Year
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub txtcedula01reg_TextChanged(sender As Object, e As System.EventArgs) Handles txtcedula01reg.TextChanged
        Try
            'Dim rex As Regex = New Regex("((\(\d{10}\) ?)|(\d{10}))")
            'If rex.IsMatch(Me.txtcedula01reg.Text.Trim()) = False Then
            '    ConfigControles(1)
            '    mensajeria_error("error", "por favor ingrese una identificación correcta.")
            '    Exit Sub
            'End If

            If String.IsNullOrEmpty(Me.txtcedula01reg.Text.Trim()) Then
                mensajeria_error("error", "por favor ingrese su identificación.")
                Exit Sub
            End If

            VerificaUsuarioExiste()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub dtpfechaanio_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dtpfechaanio.SelectedIndexChanged
        Try
            ListaGeneralDias(ObtenerMesSeleccionado, ObtenerAnioSeleccionado)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub dtpfechames_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dtpfechames.SelectedIndexChanged
        Try
            ListaGeneralDias(ObtenerMesSeleccionado, ObtenerAnioSeleccionado)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btncrearreg_Click(sender As Object, e As System.EventArgs) Handles btncrearreg.Click
        Try
            If validar() Then
                RegistroDatosNuevoUsuario()
            End If          
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnregresareg_ServerClick(sender As Object, e As System.EventArgs) Handles btnregresareg.ServerClick
        Try
            Session.Clear()
            Session.Abandon()
            Response.Redirect("login.aspx", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    Private Sub VerificaUsuarioExiste()
        Try
            If IsNullOrBlank(txtcedula01reg.Text.Trim()) = False Then
                Dim dTUserExiste As DataTable
                dTUserExiste = RegistroUsuarioAdapter.VerificaUsuarioExiste(txtcedula01reg.Text.Trim(), 109).Tables(0)
                If dTUserExiste.Rows.Count > 0 Then
                    Dim valueExisteUsuario As Integer
                    valueExisteUsuario = dTUserExiste.Rows(0)("VALOR")
                    Session("tipo_cliente") = dTUserExiste.Rows(0)("VALOR")
                    If valueExisteUsuario = 1 Then
                        ConfigControles(1)
                        mensajeria_error("alerta", "su identificación ya ha sido registrado anteriormente en el sistema.")
                    ElseIf valueExisteUsuario = 2 Then
                        ConfigControles(2)
                        VerificaYCargaDatos()
                    ElseIf valueExisteUsuario = 3 Then
                        ConfigControles(1)
                        mensajeria_error("error", "su identificación no esta registrada en Hunter, le pedimos disculpa por la novedad presentada.</br>Para mayor información por favor comuníquese a nuestro Call center 04-600-4640 ó 1800-Hunter.")
                    ElseIf valueExisteUsuario = 4 Then
                        Session("user") = Me.txtcedula01reg.Text.Trim()
                        Response.Redirect("actualizacliente.aspx", False)
                    End If
                End If
            End If
        Catch ex As Exception
            ConfigControles(1)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub VerificaYCargaDatos()
        Try
            If VerificaUsuarioChasisMotorExiste() Then
                ConfigControles(2)
                CargaDatosCliente()
            Else
                txtemailreg.Value = String.Empty
                txtnombrereg.Value = String.Empty
                txtapellidoreg.Value = String.Empty
                ListaGeneralAnios()
                ListaGeneralMeses()
                DefineFechaDefault()
                ListaGeneralDias(ObtenerMesSeleccionado, ObtenerAnioSeleccionado)
                txtccelularreg.Value = String.Empty
                txttelefonoreg.Value = String.Empty
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function VerificaUsuarioChasisMotorExiste() As Boolean
        Dim bandera As Boolean = False
        Dim valueExisteUsuario As Integer = 0
        Try
            If Not String.IsNullOrEmpty(Me.txtcedula01reg.Text.Trim()) Then
                Dim dTUserExiste As DataTable
                dTUserExiste = RegistroUsuarioAdapter.VerificaUsuarioExiste(txtcedula01reg.Text.Trim(), 109).Tables(0)
                If dTUserExiste.Rows.Count > 0 Then
                    valueExisteUsuario = dTUserExiste.Rows(0)("VALOR")
                End If
            End If
            If valueExisteUsuario = 2 Then
                bandera = True
            End If
        Catch ex As Exception
            ConfigControles(1)
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return bandera
    End Function

    Private Sub CargaDatosCliente()


        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosPersonales As DataTable

            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", txtcedula01reg.Text.Trim(), "", "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
                txtemailreg.Value = dTDatosPersonales.Rows(0)("EMAIL")
                txtnombrereg.Value = dTDatosPersonales.Rows(0)("PRIMERNOMBRE")
                txtapellidoreg.Value = dTDatosPersonales.Rows(0)("APELLIDOPATERNO")
                'dtpfechadia.SelectedValue = Convert.ToDateTime(dTDatosPersonales.Rows(0)("FECHA_NACIMIENTO")).Day
                'dtpfechames.SelectedValue = Convert.ToDateTime(dTDatosPersonales.Rows(0)("FECHA_NACIMIENTO")).Month
                'dtpfechaanio.SelectedValue = Convert.ToDateTime(dTDatosPersonales.Rows(0)("FECHA_NACIMIENTO")).Year
                txtccelularreg.Value = dTDatosPersonales.Rows(0)("TELEFONO")
                txttelefonoreg.Value = dTDatosPersonales.Rows(0)("TELEFONOPARTICULAR")
            End If
        Catch ex As Exception

        End Try



        'Dim dTDatosCliente As DataSet
        'dTDatosCliente = RegistroUsuarioAdapter.CargaDatosCliente(txtcedula01reg.Text.Trim())
        'If DTDatosCliente.Tables(0).Rows.Count > 0 Then
        '    txtemailreg.Value = dTDatosCliente.Tables(0).Rows(0)("EMAIL")
        '    txtnombrereg.Value = dTDatosCliente.Tables(0).Rows(0)("NOMBRES")
        '    txtapellidoreg.Value = dTDatosCliente.Tables(0).Rows(0)("APELLIDOS")
        '    dtpfechadia.SelectedValue = Convert.ToDateTime(dTDatosCliente.Tables(0).Rows(0)("FECHA_NACIMIENTO")).Day
        '    dtpfechames.SelectedValue = Convert.ToDateTime(dTDatosCliente.Tables(0).Rows(0)("FECHA_NACIMIENTO")).Month
        '    dtpfechaanio.SelectedValue = Convert.ToDateTime(dTDatosCliente.Tables(0).Rows(0)("FECHA_NACIMIENTO")).Year
        '    txtccelularreg.Value = dTDatosCliente.Tables(0).Rows(0)("CELULAR")
        '    txttelefonoreg.Value = dTDatosCliente.Tables(0).Rows(0)("CONVENCIONAL")
        'End If
    End Sub

    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    'al momento del load
                    txtcedula01reg.Enabled = True
                    txtemailreg.Disabled = True
                    txtnombrereg.Disabled = True
                    txtapellidoreg.Disabled = True
                    txtclavereg.Disabled = True
                    txtclaveconfirmarreg.Disabled = True
                    dtpfechadia.Enabled = False
                    dtpfechames.Enabled = False
                    dtpfechaanio.Enabled = False
                    txtccelularreg.Disabled = True
                    txttelefonoreg.Disabled = True
                    chkaceptarreg.Disabled = True
                    chkcorreoreg.Disabled = True
                    btncrearreg.Enabled = False
                    dvdmensajes.Visible = False
                Case 2
                    'al verificar que el cliente no existe
                    txtcedula01reg.Enabled = False
                    txtemailreg.Disabled = False
                    txtnombrereg.Disabled = False
                    txtapellidoreg.Disabled = False
                    txtclavereg.Disabled = False
                    txtclaveconfirmarreg.Disabled = False
                    dtpfechadia.Enabled = True
                    dtpfechames.Enabled = True
                    dtpfechaanio.Enabled = True
                    txtccelularreg.Disabled = False
                    txttelefonoreg.Disabled = False
                    chkaceptarreg.Disabled = False
                    chkcorreoreg.Disabled = False
                    btncrearreg.Enabled = True
                    dvdmensajes.Visible = False
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ListaGeneralAnios()
        Try
            Dim dTListaAnios As DataSet
            dTListaAnios = RegistroUsuarioAdapter.ListaAnios
            If dTListaAnios.Tables(0).Rows.Count > 0 Then
                dtpfechaanio.DataSource = dTListaAnios
                dtpfechaanio.DataTextField = "DESCRIPCION"
                dtpfechaanio.DataValueField = "VALOR"
                dtpfechaanio.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ListaGeneralMeses()
        Try
            Dim dTListaMeses As DataSet
            dTListaMeses = RegistroUsuarioAdapter.ListaMeses
            If dTListaMeses.Tables(0).Rows.Count > 0 Then
                dtpfechames.DataSource = dTListaMeses
                dtpfechames.DataTextField = "DESCRIPCION"
                dtpfechames.DataValueField = "VALOR"
                dtpfechames.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ListaGeneralDias(ByVal valuemes As Integer, ByVal valueanio As Integer)
        Try
            Dim dTListaDias As DataSet
            dTListaDias = RegistroUsuarioAdapter.ListaDias(valueanio, valuemes)
            If dTListaDias.Tables(0).Rows.Count > 0 Then
                dtpfechadia.DataSource = dTListaDias
                dtpfechadia.DataTextField = "DESCRIPCION"
                dtpfechadia.DataValueField = "VALOR"
                dtpfechadia.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DefineFechaDefault()
        Try
            For i = 0 To dtpfechaanio.Items.Count - 1
                If dtpfechaanio.Items(i).Value = 2000 Then
                    dtpfechaanio.Items(i).Selected = True
                    Exit For
                End If
            Next
            For i = 0 To Me.dtpfechames.Items.Count - 1
                If dtpfechames.Items(i).Value = 1 Then
                    dtpfechames.Items(i).Selected = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ObtenerMesSeleccionado()
        Try
            Dim idmesSelected As Integer
            For i = 0 To dtpfechames.Items.Count - 1
                If dtpfechames.Items(i).Selected = True Then
                    idmesSelected = dtpfechames.Items(i).Value
                    Exit For
                End If
            Next
            Return idmesSelected
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ObtenerAnioSeleccionado()
        Try
            Dim idanioSelected As Integer
            For i = 0 To dtpfechaanio.Items.Count - 1
                If dtpfechaanio.Items(i).Selected = True Then
                    idanioSelected = dtpfechaanio.Items(i).Value
                    Exit For
                End If
            Next
            Return idanioSelected
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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
        If Me.txttelefonoreg.Value = "" Then
            mensajeria_error("error", "Por favor verificar el telefono de contacto")
            txttelefonoreg.Focus()
            retorno = False
        End If
        'If (Date.Now.Year - (dtpfechaanio.SelectedValue)) < 18 Or (Date.Now.Year - (dtpfechaanio.SelectedValue)) > 95 Then
        '    mensajeria_error("error", "Por favor verifique, Fecha de Nacimiento Incorrecta, verificar debe se Mayor de 18 años y Menor a 95 años.")
        '    retorno = False
        'End If
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
            Dim idcliente, nombre, apellido, password, telefono1, email1, telefono2, chasisMotor As String
            Dim dia, mes, anio, valueRegistroUsuario As Integer
            Dim valueCondServPolt As Integer = 0
            Dim valueInfoProdServ As Integer = 0
            Dim objregusu As New RegistroUsuarioAdapter
            idcliente = txtcedula01reg.Text.Trim()
            email1 = txtemailreg.Value
            Session("email1") = email1
            Session("password") = txtclavereg.Value
            password = txtclavereg.Value
            nombre = txtnombrereg.Value
            apellido = txtapellidoreg.Value
            dia = dtpfechadia.SelectedValue
            mes = dtpfechames.SelectedValue
            anio = dtpfechaanio.SelectedValue
            telefono1 = txtccelularreg.Value
            valueCondServPolt = If(chkaceptarreg.Checked = True, 1, 0)
            valueInfoProdServ = If(chkcorreoreg.Checked = True, 1, 0)
            telefono2 = txttelefonoreg.Value
            chasisMotor = ""
            valueRegistroUsuario = objregusu.RegistroDatosPersonalesUsuarioWeb(idcliente, nombre, apellido, Session("password"), dia, mes, anio, email1, _
                                                                               telefono1, "", valueCondServPolt, valueInfoProdServ, _
                                                                               Session("tipo_cliente"), telefono2, chasisMotor)
            If valueRegistroUsuario = 0 Then
                GeneraEmailActivacion()
                LimpiaControles()
                ConfigControles(1)
                Promocion(idcliente)
                mensajeria_error("informacion", "Para concluir con el proceso de registro, confirme el correo que hemos enviado a su e-mail: " & Session("email1").ToString.Trim & ", Gracias por preferirnos.")
            Else
                mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
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
            txttelefonoreg.Value = ""
            dtpfechadia.SelectedValue = DateTime.Now.Day
            dtpfechames.SelectedValue = DateTime.Now.Month
            dtpfechaanio.SelectedValue = DateTime.Now.Year
            chkaceptarreg.Checked = False
            chkcorreoreg.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Promocion(ByVal idcliente As String)
        Try
            Dim dTPromocion As DataSet
            dTPromocion = DatosPersonalesAdapter.ConsultaPromocion(Date.Now, "CREUSU")
            If dTPromocion.Tables(0).Rows.Count > 0 Then
                Dim tipoPromocion As String = dTPromocion.Tables(0).Rows(0)("TIPO_ID")
                Dim promocionId As String = dTPromocion.Tables(0).Rows(0)("PROMOCION_ID")
                Dim resultado As String = SolicitudActualizacionAdapter.RegistroPromocion(idcliente, "W", tipoPromocion, promocionId, "0", "0")
                If resultado <> "" Then
                    Dim dTEmailAct As DataSet
                    DTEmailAct = DatosPersonalesAdapter.GeneraEmailPromocion(idcliente, resultado, tipoPromocion, "", promocionId)
                    If DTEmailAct.Tables.Count > 0 Then
                        If dTEmailAct.Tables(0).Rows.Count > 0 Then
                            Dim strMailMsg, strMailTitle, strMail As String
                            strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                            strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                            strMail = dTEmailAct.Tables(0).Rows(0)("EMAIL")
                            EnvioEmailPromocion(strMail, strMailTitle, strMailMsg)
                        Else
                            mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de Promoción")
                        End If
                    Else
                        mensajeria_error("error", "Ocurrió un inconveniente al enviarse el email de Promoción")
                   End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub EnvioEmailPromocion(ByVal email As String, ByVal titulo As String, ByVal mensaje As String)
        Dim correo = New System.Net.Mail.MailMessage()
        correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
        Dim mailTo As [String]() = email.ToString().Split(";")
        For Each mailTooBcc As String In mailTo
            If EMailHandler.ValidarEMail(mailTooBcc) Then
                correo.To.Add(mailTooBcc)
            End If
        Next
        'correo.To.Add(email)
        Dim mailToBccCollection As [String]() = ConfigurationManager.AppSettings.Get("PromocionMailToBcc").ToString().Split(";")
        For Each mailTooBcc As String In mailToBccCollection
            If EMailHandler.ValidarEMail(mailTooBcc) Then
                correo.Bcc.Add(mailTooBcc)
            End If
        Next
        correo.Subject = titulo
        titulo &= vbCrLf & vbCrLf & "Fecha y hora GMT: " & DateTime.Now.ToUniversalTime.ToString("dd/MM/yyyy HH:mm:ss")
        correo.Body = mensaje
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

    Private Sub GeneraEmailActivacion()
        Try
            If HttpContext.Current IsNot Nothing Then
                Dim dTLinkActiv As DataSet
                DTLinkActiv = RegistroUsuarioAdapter.GeneraLinkActivacion
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

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
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

#End Region

End Class