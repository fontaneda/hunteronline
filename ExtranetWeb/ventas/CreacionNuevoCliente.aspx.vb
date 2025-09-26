Public Class CreacionNuevoCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mensajeria_error("", "")
            llenar_combos_fact()
        End If
    End Sub

#Region "Eventos de los controles"

    Private Sub cmbprovinciaclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbprovinciaclientefac.SelectedIndexChanged
        LlenaComboCiudad()
    End Sub

    Private Sub cmbciudadclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbciudadclientefac.SelectedIndexChanged
        LlenaComboParroquia()
    End Sub

    Private Sub btnnuevocliente_ServerClick(sender As Object, e As System.EventArgs) Handles btnnuevocliente.ServerClick
        Try
            If Not validar() Then
                Dim ClienteEntity As New ClienteEntity
                Dim ClienteDetalleEntity As ClienteDetalleEntity
                Dim ClienteDetalleEntityCollection As New ClienteDetalleEntityCollection
                ClienteEntity = New ClienteEntity
                'DATOS CLIENTES
                ClienteEntity.ClienteId = txtcedulaclientefac.Value
                ClienteEntity.ClienteTipoIdentificacion = cmbcedulaclientefac.SelectedValue
                ClienteEntity.ClienteNacimiento = txtfechanacimientoclientefac.Text
                ClienteEntity.ClienteApellidoPadre = txtapellido1clientefac.Value
                ClienteEntity.ClienteApellidoMadre = txtapellido2clientefac.Value
                ClienteEntity.ClienteNombrePrimero = txtnombre1clientefac.Value
                ClienteEntity.ClienteNombreSegundo = txtnombre2clientefac.Value
                ClienteEntity.ClienteSexo = cmbsexoclientefac.SelectedValue
                'DATOS DIRECCION
                ClienteDetalleEntity = New ClienteDetalleEntity
                ClienteDetalleEntity.DireccionSectorId = cmbsectorclientefac.SelectedValue
                ClienteDetalleEntity.DireccionProvinciaId = cmbprovinciaclientefac.SelectedValue
                ClienteDetalleEntity.DireccionCiudadId = cmbciudadclientefac.SelectedValue
                ClienteDetalleEntity.DireccionParroquiaId = cmbparroquiaclientefac.SelectedValue
                ClienteDetalleEntity.Direccion = txtdireccionclientefac.Value
                ClienteDetalleEntity.DireccionInterseccion = txtinterseccionclientefac.Value
                ClienteDetalleEntity.DireccionNumero = txtnumeroclientefac.Value
                'DATOS TELEFONO
                ClienteDetalleEntity.Telefono = txttelefonoclientefac.Value
                ClienteDetalleEntity.TelefonoCelular = txtcelularclientefac.Value
                'DATOS REFERENCIA BANCARIA
                ClienteDetalleEntity.EmailPrincipal = txtemailclientefac.Value
                ClienteDetalleEntity.EmailAlerta = ""

                ClienteDetalleEntityCollection.Add(ClienteDetalleEntity)
                ClienteEntity.ClienteDetalleEntityCollection = ClienteDetalleEntityCollection
                If DatosPersonalesAdapter.RegistroClienteFACTURA(ClienteEntity) Then
                    RegistroDatosNuevoUsuario()
                    Dim cedula As String = txtcedulaclientefac.Value
                    Dim cliente As String = "Cliente soporte: " & _
                                            txtnombre1clientefac.Value _
                                            & " " _
                                            & txtnombre2clientefac.Value _
                                            & " " _
                                            & txtapellido1clientefac.Value _
                                            & " " _
                                            & txtapellido2clientefac.Value
                    Dim usuariosoporte As String = ""
                    Dim usuarioprecio As String = ""
                    If Session("Administrador") = "MOD" Then
                        usuariosoporte = Session("display_soporte")
                    ElseIf Session("Administrador") = "APV" Then
                        usuarioprecio = Session("usuarioPrecio")
                        usuariosoporte = Session("display_soporte")
                    ElseIf Session("Administrador") = "ADM" Then
                        usuarioprecio = Session("usuarioPrecio")
                    Else
                        usuariosoporte = ""
                    End If
                    Session("usuarioPrecio") = usuarioprecio
                    Dim celular As String = txtcelularclientefac.Value
                    Dim email As String = txtemailclientefac.Value
                    Dim direccion As String = txtdireccionclientefac.Value
                    Dim telefono As String = txttelefonoclientefac.Value

                    CargaNuevaSesion(Session("usuario"), cedula, cliente, Session("Administrador"), usuariosoporte, email, celular, direccion, telefono)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Usuario, " & mensaje
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
        ElseIf tipo = "" Then
            dvdmensajes.Visible = False
        End If
    End Sub

    Private Sub llenar_combos_fact()
        Try
            'CONSULTA TRAE VARIAS TABLAS CON RESULTADOS
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaCatalogosMonitoreo()

            poblar_combo(cmbcedulaclientefac, dTDatosCliente.Tables(0))
            poblar_combo(cmbsexoclientefac, dTDatosCliente.Tables(8))
            poblar_combo(cmbprovinciaclientefac, dTDatosCliente.Tables(11))
            poblar_combo(cmbciudadclientefac, dTDatosCliente.Tables(12))
            poblar_combo(cmbparroquiaclientefac, dTDatosCliente.Tables(13))
            poblar_combo(cmbsectorclientefac, dTDatosCliente.Tables(14))
            Dim dTDatosProvincia As New DataSet
            dTDatosProvincia = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("120", "001", "", "", "")
            poblar_combo(cmbprovinciaclientefac, dTDatosProvincia.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub poblar_combo(ByVal combo As DropDownList, ByVal tabla As DataTable)
        Try
            combo.DataSource = tabla
            combo.DataTextField = "DESCRIPCION"
            combo.DataValueField = "CODIGO"
            combo.DataBind()
            combo.SelectedIndex = 0
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LlenaComboCiudad()
        Try
            cmbciudadclientefac.DataSource = ""
            cmbciudadclientefac.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("121", "001", cmbprovinciaclientefac.SelectedValue, "", "")
            poblar_combo(cmbciudadclientefac, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LlenaComboParroquia()
        Try
            cmbparroquiaclientefac.DataSource = ""
            cmbparroquiaclientefac.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("122", "", cmbprovinciaclientefac.SelectedValue, cmbciudadclientefac.SelectedValue, "")
            poblar_combo(cmbparroquiaclientefac, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function validar() As Boolean
        Dim retorno As Boolean = False

        If cmbcedulaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbcedulaclientefac.Focus()
            mensajeria_error("error", "Por favor seleccionar un tipo de identificación")
        ElseIf txtapellido1clientefac.Value = "" Then
            retorno = True
            txtapellido1clientefac.Focus()
            mensajeria_error("error", "Por favor ingresar apellido paterno")
        ElseIf txtapellido2clientefac.Value = "" Then
            retorno = True
            txtapellido2clientefac.Focus()
            mensajeria_error("error", "Por favor ingresar apellido materno")
        ElseIf txtnombre1clientefac.Value = "" Then
            retorno = True
            txtnombre1clientefac.Focus()
            mensajeria_error("error", "Por favor ingresar primer nombre")
        ElseIf txtnombre2clientefac.Value = "" Then
            retorno = True
            txtnombre2clientefac.Focus()
            mensajeria_error("error", "Por favor ingresar segundo nombre")
        ElseIf txtcedulaclientefac.Value = "" Then
            retorno = True
            txtcedulaclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar identificación del cliente")
        ElseIf txtdireccionclientefac.Value = "" Then
            retorno = True
            txtdireccionclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar dirección")
        ElseIf txtinterseccionclientefac.Value = "" Then
            retorno = True
            txtinterseccionclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar intersección de dirección")
        ElseIf txtcelularclientefac.Value.Substring(0, 1) <> "0" Then
            retorno = True
            txtcelularclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar número de teléfono celular válido")
        ElseIf txtcelularclientefac.Value.Length < 10 Then
            retorno = True
            txtcelularclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar número de teléfono celular válido")
        ElseIf txttelefonoclientefac.Value = "" Then
            retorno = True
            txttelefonoclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar número de teléfono fijo")
        ElseIf txttelefonoclientefac.Value.Length > 10 Or txttelefonoclientefac.Value.Length < 7 Then
            retorno = True
            txttelefonoclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar número de teléfono fijo válido")
        ElseIf txtemailclientefac.Value = "" Then
            retorno = True
            txtemailclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar email principal")
        ElseIf Not txtemailclientefac.Value.Contains("@") Then
            retorno = True
            txtemailclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar email principal válido")
        ElseIf Not txtemailclientefac.Value.Contains(".") Then
            retorno = True
            txtemailclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar email principal válido")
        ElseIf cmbsexoclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbsexoclientefac.Focus()
            mensajeria_error("error", "Por favor seleccionar un género")
        ElseIf cmbciudadclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbciudadclientefac.Focus()
            mensajeria_error("error", "Por favor seleccionar una ciudad")
            'ElseIf cmbparroquiaclientefac.SelectedIndex < 1 Then
            '    retorno = True
            '    cmbparroquiaclientefac.Focus()
            '    mensajeria_error("error", "Por favor seleccionar una parroquia")
        ElseIf cmbprovinciaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbprovinciaclientefac.Focus()
            mensajeria_error("error", "Por favor seleccionar una provincia")
        ElseIf cmbsectorclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbsectorclientefac.Focus()
            mensajeria_error("error", "Por favor seleccionar un sector")
        ElseIf txtfechanacimientoclientefac.Text > DateAdd(DateInterval.Year, -18, Date.Now) Then
            retorno = True
            txtfechanacimientoclientefac.Focus()
            mensajeria_error("error", "Por favor ingrese fecha nacimiento del cliente válido")
        ElseIf (cmbcedulaclientefac.SelectedValue = "001" Or cmbcedulaclientefac.SelectedValue = "002") _
            And (txtcedulaclientefac.Value.Length < 10 Or txtcedulaclientefac.Value.Length > 13) Then
            retorno = True
            txtcedulaclientefac.Focus()
            mensajeria_error("error", "Por favor ingresar identificación válida")
        ElseIf digito_verificador(txtcedulaclientefac.Value) = False Then
            retorno = True
            txtcedulaclientefac.Focus()
            mensajeria_error("error", "Por favor ingrese una identificación válida")
        Else
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreo(txtcedulaclientefac.Value)
            If dTDatosCliente.Tables.Count > 0 Then
                If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                    retorno = True
                    txtcedulaclientefac.Focus()
                    mensajeria_error("error", "Identificación del cliente ya existe")
                End If
            End If
        End If

        Return retorno
    End Function

    Private Function digito_verificador(texto As String) As Boolean
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

    Private Sub CargaNuevaSesion(ByVal usuario As String, ByVal cliente As String, ByVal nombresCompletos As String, _
                                 ByVal msg As String, ByVal usuariosoporte As String, ByVal email As String, _
                                 ByVal celular As String, direccion As String, telefono As String)
        Try
            InfoUsuario()
            Session("Administrador") = msg
            Session("user") = cliente
            Session("usuario") = usuario
            Session("user_id") = cliente
            Session("display_name") = nombresCompletos
            Session("display_soporte") = usuariosoporte
            Session("Email") = email
            Session("Celular") = celular
            Session("Direccion") = direccion
            Session("Telefono") = telefono
            'FormularioAdapter.RegistroLogFormulario(107, Session("user_id"), Session("usuario"), "USUARIO CON LOGIN SATISFACTORIO - RELOAD SOPORTE", Session("iphost"))
            'Response.Redirect("Cobro.aspx", False)
            Response.Redirect("actualizacliente.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub InfoUsuario()
        Try
            'Dim computerName As String()
            Dim valueIphost As String = String.Empty
            Dim valuePchost As String = String.Empty
            valueIphost = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.ServerVariables("REMOTE_ADDR")
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.UserHostAddress
            End If
            'If Not String.IsNullOrEmpty(valueIphost) Then
            '    If Not System.Net.Dns.GetHostEntry(valueIphost).HostName Is Nothing Then
            '        computerName = System.Net.Dns.GetHostEntry(valueIphost).HostName.Split(New [Char]() {"."c})
            '        valuePchost = computerName(0).ToString()
            '    End If
            'Else
            valuePchost = System.Environment.MachineName
            'End If
            If valueIphost = "" Or valueIphost Is Nothing Then valueIphost = String.Empty
            If valuePchost = "" Or valuePchost Is Nothing Then valuePchost = String.Empty
            Session("iphost") = valueIphost
            Session("pchost") = valuePchost
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub RegistroDatosNuevoUsuario()
        Try
            Dim idcliente, nombre, apellido, password, telefono1, email1, telefono2, chasisMotor As String
            Dim fecha_nacimiento As Date = txtfechanacimientoclientefac.Text
            Dim dia, mes, anio, valueRegistroUsuario As Integer
            Dim valueCondServPolt As Integer = 0
            Dim valueInfoProdServ As Integer = 0
            Dim objregusu As New RegistroUsuarioAdapter
            idcliente = txtcedulaclientefac.Value
            email1 = txtemailclientefac.Value
            Session("password") = "12345678"
            password = "12345678"
            nombre = txtnombre1clientefac.Value _
                   & " " _
                   & txtnombre2clientefac.Value
            apellido = txtapellido1clientefac.Value _
                     & " " _
                     & txtapellido2clientefac.Value
            dia = fecha_nacimiento.Day
            mes = fecha_nacimiento.Month
            anio = fecha_nacimiento.Year
            telefono1 = txtcelularclientefac.Value
            valueCondServPolt = 1
            valueInfoProdServ = 1
            telefono2 = txttelefonoclientefac.Value
            chasisMotor = ""
            valueRegistroUsuario = objregusu.RegistroDatosPersonalesUsuarioWeb(idcliente, nombre, apellido, Session("password"), dia, mes, anio, email1, _
                                                                               telefono1, "", valueCondServPolt, valueInfoProdServ, _
                                                                               Session("tipo_cliente"), telefono2, chasisMotor)
            If Not valueRegistroUsuario = 0 Then
                mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
            End If
        Catch ex As Exception
            mensajeria_error("error", "No se ha podido registrar el usuario correctamente")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class