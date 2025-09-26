Public Class VentasFac
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Venta de Productos/Servicios", 8, "Venta datos de facturacion")
                    mensajeria_error("", "")
                    carro_compra()
                    llena_info_factura()
                    llenainfodatos()
                    Session("IdTarjetaVpos") = ""
                    Session("IdTipoPagoVpos") = ""
                End If
            Else
                If Session("errorbandera") = "0" Then
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "ShowPopup();", True)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btncontinuar_ServerClick(sender As Object, e As System.EventArgs) Handles btncontinuar.ServerClick
        If valida_controles() Then
            Dim table As New System.Data.DataTable
            Dim row As DataRow
            table = Tablafacturacion()
            row = table.NewRow()
            row("FormaPagoIdentificacion") = txtFormaPagoIdentificacion.Text.ToString
            row("FormaPagoNombre") = txtFormaPagoNombre.Text
            row("FormaPagoDireccion") = txtFormaPagoDireccion.Text
            row("FormaPagoTelefono") = txtFormaPagoTelefono.Text
            row("FormaPagoCelular") = txtFormaPagoCelular.Text
            row("FormaPagoEmail") = txtFormaPagoEmail.Text.ToLower
            table.Rows.Add(row)
            Session("tblfacturacion") = table
            Response.Redirect("VentasPago.aspx", False)
        End If
    End Sub

    Private Sub chkemisoramerican_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisoramerican.ServerChange
        If chkemisoramerican.Checked Then
            Session("IdTarjetaVpos") = "AM"
        End If
    End Sub

    Private Sub chkemisordiners_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisordiners.ServerChange
        If chkemisordiners.Checked Then
            Session("IdTarjetaVpos") = "DN"
        End If
    End Sub

    Private Sub chkemisordiscover_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisordiscover.ServerChange
        If chkemisordiscover.Checked Then
            Session("IdTarjetaVpos") = "DI"
        End If
    End Sub

    Private Sub chkemisormastercard_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisormastercard.ServerChange
        If chkemisormastercard.Checked Then
            Session("IdTarjetaVpos") = "MC"
        End If
    End Sub

    Private Sub chkemisorpacificard_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisorpacificard.ServerChange
        If chkemisorpacificard.Checked Then
            Session("IdTarjetaVpos") = "PC"
        End If
    End Sub

    Private Sub chkemisortitanium_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisortitanium.ServerChange
        If chkemisortitanium.Checked Then
            Session("IdTarjetaVpos") = "TI"
        End If
    End Sub

    Private Sub chkemisorvisa_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisorvisa.ServerChange
        If chkemisorvisa.Checked Then
            Session("IdTarjetaVpos") = "VI"
        End If
    End Sub

    Private Sub chkemisorpichincha_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisorpichincha.ServerChange
        If chkemisorpichincha.Checked Then
            Session("IdTarjetaVpos") = "DN"
        End If
    End Sub

    Private Sub cmbtipopago_ServerChange(sender As Object, e As System.EventArgs) Handles cmbtipopago.ServerChange
        If cmbtipopago.SelectedIndex > 0 Then
            Session("IdTipoPagoVpos") = cmbtipopago.Value
        Else
            Session("IdTipoPagoVpos") = ""
        End If
    End Sub

    Protected Sub clk_rpt_clientefac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblcliente As Label = CType(item.FindControl("lblcodigoclientesfac"), Label)
            pasar_datos_existe(lblcliente.Text)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_direccionfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lbldireccion As Label = CType(item.FindControl("lbldireccionfac"), Label)
            txtFormaPagoDireccion.Text = lbldireccion.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_telefonofac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lbltelefono As Label = CType(item.FindControl("lbltelefonofac"), Label)
            txtFormaPagoTelefono.Text = lbltelefono.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_celularfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblcelular As Label = CType(item.FindControl("lblcelularfac"), Label)
            txtFormaPagoCelular.Text = lblcelular.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_emailfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblemail As Label = CType(item.FindControl("lblemailfac"), Label)
            txtFormaPagoEmail.Text = lblemail.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub txtbusquedaclientefac_ServerChange(sender As Object, e As System.EventArgs) Handles txtbusquedaclientefac.ServerChange
        buscar_cliente_fac()
    End Sub

    Private Sub btnbuscarclientefac_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscarclientefac.ServerClick
        buscar_cliente_fac()
    End Sub

    Private Sub btnnuevoclientefac_ServerClick(sender As Object, e As System.EventArgs) Handles btnnuevoclientefac.ServerClick
        If Not validar() Then
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
                        txtFormaPagoIdentificacion.Text = txtcedulaclientefac.Value
                        txtFormaPagoNombre.Text = txtnombre1clientefac.Value _
                                                & " " _
                                                & txtnombre2clientefac.Value _
                                                & " " _
                                                & txtapellido1clientefac.Value _
                                                & " " _
                                                & txtapellido2clientefac.Value
                        txtFormaPagoDireccion.Text = txtdireccionclientefac.Value
                        txtFormaPagoCelular.Text = txttelefonoclientefac.Value
                        txtFormaPagoTelefono.Text = txtcelularclientefac.Value
                        txtFormaPagoEmail.Text = txtemailclientefac.Value
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Private Sub cmbprovinciaclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbprovinciaclientefac.SelectedIndexChanged
        LlenaComboCiudad()
    End Sub

    Private Sub cmbciudadclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbciudadclientefac.SelectedIndexChanged
        LlenaComboParroquia()
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Function valida_controles() As Boolean
        Dim retorno As Boolean = True
        Dim table As New System.Data.DataTable
        table = CType(Session("tblventas"), DataTable)

        If table.Rows.Count = 0 Then
            retorno = False
            mensajeria_error("error", "no existen productos a renovar, por favor verificar")
        ElseIf Not chkemisoramerican.Checked And Not chkemisordiners.Checked _
            And Not chkemisordiscover.Checked And Not chkemisormastercard.Checked _
            And Not chkemisorpacificard.Checked And Not chkemisortitanium.Checked _
            And Not chkemisorvisa.Checked And Not chkemisorpichincha.Checked Then
            mensajeria_error("error", "por favor seleccione una tarjeta")
            retorno = False
        ElseIf cmbtipopago.SelectedIndex = 0 Then
            mensajeria_error("error", "por favor seleccione un tipo de pago")
            retorno = False
        ElseIf txtFormaPagoNombre.Text = "" And txtFormaPagoIdentificacion.Text = "" _
            And txtFormaPagoDireccion.Text = "" And txtFormaPagoTelefono.Text = "" _
            And txtFormaPagoCelular.Text = "" And txtFormaPagoEmail.Text = "" Then

            mensajeria_error("error", "datos de facturación incompletos, por favor completar")
            retorno = False
        End If
        Return retorno
    End Function

    Private Sub llena_info_factura()
        Dim dTCstFactura As New System.Data.DataSet
        dTCstFactura = RenovacionAdapter.ConsultaDatosCliente(Session.Item("user"))
        If dTCstFactura.Tables(0).Rows.Count > 0 Then
            txtFormaPagoNombre.Text = dTCstFactura.Tables(0).Rows(0)("NOMBRE_COMPLETO")
            txtFormaPagoIdentificacion.Text = dTCstFactura.Tables(0).Rows(0)("ID_CLIENTE")
            txtFormaPagoDireccion.Text = dTCstFactura.Tables(0).Rows(0)("DIRECCION")
            txtFormaPagoTelefono.Text = dTCstFactura.Tables(0).Rows(0)("TELEFONO")
            txtFormaPagoCelular.Text = dTCstFactura.Tables(0).Rows(0)("CELULAR")
            txtFormaPagoEmail.Text = dTCstFactura.Tables(0).Rows(0)("EMAIL")
        End If
    End Sub

    Private Sub carro_compra()
        Dim table As New System.Data.DataTable
        Dim valueCantidadRenovar As Integer = 0
        Dim valueCellPrecioCliente As Decimal = 0
        table = CType(Session("tblventas"), DataTable)
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                valueCantidadRenovar += 1
                valueCellPrecioCliente += table.Rows(i)("PRECIO_CLIENTE")
            Next
            carro_compras(valueCellPrecioCliente, valueCantidadRenovar)
        End If
    End Sub

    Private Function Tablafacturacion() As DataTable
        Dim table As New System.Data.DataTable
        Dim column As DataColumn
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoIdentificacion"
        column.AutoIncrement = False
        column.Caption = "FormaPagoIdentificacion"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoNombre"
        column.AutoIncrement = False
        column.Caption = "FormaPagoNombre"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoDireccion"
        column.AutoIncrement = False
        column.Caption = "FormaPagoDireccion"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoTelefono"
        column.AutoIncrement = False
        column.Caption = "FormaPagoTelefono"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoCelular"
        column.AutoIncrement = False
        column.Caption = "FormaPagoCelular"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoEmail"
        column.AutoIncrement = False
        column.Caption = "FormaPagoEmail"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        Return table
    End Function

    Private Sub llenainfodatos()
        Try
            'CLIENTE
            llenar_combos_fact()
            'DIRECCION
            Dim dTDatosDireccion As New DataSet
            dTDatosDireccion = DatosPersonalesAdapter.ConsultaDatosDireccionCliente(Session.Item("user"))
            If dTDatosDireccion.Tables(0).Rows.Count > 0 Then
                Rptdireccionfac.DataSource = dTDatosDireccion
                Rptdireccionfac.DataBind()
            Else
                Rptdireccionfac.DataSource = Nothing
                Rptdireccionfac.DataBind()
            End If
            'TELEFONO
            Dim dTDatotelefono As New DataSet
            dTDatotelefono = DatosPersonalesAdapter.ConsultaDatosTelefonoCliente(Session.Item("user"), "001")
            If dTDatotelefono.Tables(0).Rows.Count > 0 Then
                Rpttelefonofac.DataSource = dTDatotelefono
                Rpttelefonofac.DataBind()
            Else
                Rpttelefonofac.DataSource = Nothing
                Rpttelefonofac.DataBind()
            End If
            'CELULAR
            Dim dTDatoscelular As New DataSet
            dTDatoscelular = DatosPersonalesAdapter.ConsultaDatosTelefonoCliente(Session.Item("user"), "004")
            If dTDatoscelular.Tables(0).Rows.Count > 0 Then
                Rptcelularfac.DataSource = dTDatoscelular
                Rptcelularfac.DataBind()
            Else
                Rptcelularfac.DataSource = Nothing
                Rptcelularfac.DataBind()
            End If
            'EMAIL
            Dim dTDatosEMail As New DataSet
            dTDatosEMail = DatosPersonalesAdapter.ConsultaDatosEmailCliente(Session.Item("user"))
            If dTDatosEMail.Tables(0).Rows.Count > 0 Then
                Rptemailfac.DataSource = dTDatosEMail
                Rptemailfac.DataBind()
            Else
                Rptemailfac.DataSource = Nothing
                Rptemailfac.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub llenar_combos_fact()
        Try
            'CONSULTA TRAE VARIAS TABLAS CON RESULTADOS
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaCatalogosMonitoreo()
            'TIPO IDENTIFICACION
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

    Private Sub pasar_datos_existe(ByVal ID As String)
        If Not ID Is Nothing Or ID <> "" Then
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreoDatos(ID)
            If Not dTDatosCliente Is Nothing Then
                txtFormaPagoIdentificacion.Text = ID
                txtFormaPagoNombre.Text = dTDatosCliente.Tables(0).Rows(0).Item("PRIMER_NOMBRE").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("SEGUNDO_NOMBRE").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_PATERNO").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_MATERNO").ToString
                txtFormaPagoDireccion.Text = dTDatosCliente.Tables(0).Rows(0).Item("DIRECCION").ToString
                txtFormaPagoCelular.Text = dTDatosCliente.Tables(0).Rows(0).Item("CELULAR").ToString
                txtFormaPagoTelefono.Text = dTDatosCliente.Tables(0).Rows(0).Item("TELEFONO").ToString
                txtFormaPagoEmail.Text = dTDatosCliente.Tables(0).Rows(0).Item("EMAILPRINCIPAL").ToString
            End If
        End If
    End Sub

    Private Function validar() As Boolean
        Dim retorno As Boolean = False

        If txtapellido1clientefac.Value = "" Then
            retorno = True
            txtapellido1clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar apellido paterno"
        ElseIf txtapellido2clientefac.Value = "" Then
            retorno = True
            txtapellido2clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar apellido materno"
        ElseIf txtnombre1clientefac.Value = "" Then
            retorno = True
            txtnombre1clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar primer nombre"
        ElseIf txtnombre2clientefac.Value = "" Then
            retorno = True
            txtnombre2clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar segundo nombre"
        ElseIf txtcedulaclientefac.Value = "" Then
            retorno = True
            txtcedulaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar identificación del cliente"
        ElseIf txtdireccionclientefac.Value = "" Then
            retorno = True
            txtdireccionclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar dirección"
        ElseIf txtinterseccionclientefac.Value = "" Then
            retorno = True
            txtinterseccionclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar intersección de dirección"
        ElseIf txtcelularclientefac.Value.Substring(0, 1) <> "0" Then
            retorno = True
            txtcelularclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono celular válido"
        ElseIf txtcelularclientefac.Value.Length < 10 Then
            retorno = True
            txtcelularclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono celular válido"
        ElseIf txttelefonoclientefac.Value = "" Then
            retorno = True
            txttelefonoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono fijo"
        ElseIf txttelefonoclientefac.Value.Length > 9 Or txttelefonoclientefac.Value.Length < 7 Then
            retorno = True
            txttelefonoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono fijo válido"
        ElseIf txtemailclientefac.Value = "" Then
            retorno = True
            txtemailclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal"
        ElseIf Not txtemailclientefac.Value.Contains("@") Then
            retorno = True
            txtemailclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal válido"
        ElseIf Not txtemailclientefac.Value.Contains(".") Then
            retorno = True
            txtemailclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal válido"
        ElseIf cmbsexoclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbsexoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un género"
        ElseIf cmbcedulaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbcedulaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un tipo de identificación"
        ElseIf cmbciudadclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbciudadclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una ciudad"
        ElseIf cmbparroquiaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbparroquiaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una parroquia"
        ElseIf cmbprovinciaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbprovinciaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una provincia"
        ElseIf cmbsectorclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbsectorclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un sector"
        ElseIf txtfechanacimientoclientefac.Text > DateAdd(DateInterval.Year, -18, Date.Now) Then
            retorno = True
            txtfechanacimientoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingrese fecha nacimiento del cliente válid"
        End If

        If cmbcedulaclientefac.SelectedValue = "001" Or cmbcedulaclientefac.SelectedValue = "002" Then
            If txtcedulaclientefac.Value.Length < 10 Or txtcedulaclientefac.Value.Length > 13 Then
                retorno = True
                txtcedulaclientefac.Focus()
                lblmensajeerror.InnerText = "Por favor ingresar identificación válida"
            End If
        End If

        If digito_verificador(txtcedulaclientefac.Value) = False Then
            retorno = True
            txtcedulaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingrese una identificación válida"
        End If

        Return retorno
    End Function

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeexternoerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        If tipo = "error" Then
            Session("errorbandera") = "1"
            dvdmensajes.Attributes.Add("class", "messages error")
            dvdmensajes.Visible = True
        ElseIf tipo = "alerta" Then
            Session("errorbandera") = "1"
            dvdmensajes.Attributes.Add("class", "messages alert")
            dvdmensajes.Visible = True
        ElseIf tipo = "informacion" Then
            Session("errorbandera") = "1"
            dvdmensajes.Attributes.Add("class", "messages sucess")
            dvdmensajes.Visible = True
        ElseIf tipo = "" Then
            Session("errorbandera") = "0"
            dvdmensajes.Visible = False
        End If
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub carro_compras(valor As String, cantidad As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.cantidadMaster = cantidad
        myMasterPage.totalMaster = valor
    End Sub

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

    Private Sub buscar_cliente_fac()
        Try
            If Len(txtbusquedaclientefac.Value) > 0 Then
                Dim dTDatosCliente As New DataSet
                dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreo(txtbusquedaclientefac.Value)
                If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                    Rptclientesfac.DataSource = dTDatosCliente
                    Rptclientesfac.DataBind()
                Else
                    Rptclientesfac.DataSource = Nothing
                    Rptclientesfac.DataBind()
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class