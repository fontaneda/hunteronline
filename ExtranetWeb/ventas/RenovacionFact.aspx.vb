Public Class RenovacionFact
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing Then
                    metodos_master("Renovación de Servicios", 3, "Renovacion datos de factura")
                    mensajeria_error("", "")
                    carro_compra()
                    llena_info_factura()
                    llenainfodatos()
                    Session("IdTarjetaVpos") = ""
                    Session("IdTipoPagoVpos") = ""
                End If
            Else
                If Session("errorbandera") = "0" Then
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
            Dim clientefact As String = cliente_ns(txtFormaPagoIdentificacion.Text.ToString)
            row("FormaPagoIdentificacion") = IIf(clientefact = "", Session("user_netsuite"), clientefact)
            row("FormaPagoNombre") = txtFormaPagoNombre.Text
            row("FormaPagoDireccion") = txtFormaPagoDireccion.Text
            row("FormaPagoTelefono") = txtFormaPagoTelefono.Text
            row("FormaPagoCelular") = txtFormaPagoCelular.Text
            row("FormaPagoEmail") = txtFormaPagoEmail.Text.ToLower
            table.Rows.Add(row)
            Session("tblfacturacion") = table
            Session("bancoseleccionado") = cmbbancos.SelectedValue
            Response.Redirect("RenovacionPago.aspx", False)
        End If
    End Sub

    Private Sub chkemisoramerican_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisoramerican.CheckedChanged
        If chkemisoramerican.Checked Then
            Session("IdTarjetaVpos") = "AM"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisordiners_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisordiners.CheckedChanged
        If chkemisordiners.Checked Then
            Session("IdTarjetaVpos") = "DN"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisordiscover_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisordiscover.CheckedChanged
        If chkemisordiscover.Checked Then
            Session("IdTarjetaVpos") = "DI"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisormastercard_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisormastercard.CheckedChanged
        If chkemisormastercard.Checked Then
            Session("IdTarjetaVpos") = "MC"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisorpacificard_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisorpacificard.CheckedChanged
        If chkemisorpacificard.Checked Then
            Session("IdTarjetaVpos") = "PC"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisortitanium_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisortitanium.CheckedChanged
        If chkemisortitanium.Checked Then
            Session("IdTarjetaVpos") = "TI"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisorvisa_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisorvisa.CheckedChanged
        If chkemisorvisa.Checked Then
            Session("IdTarjetaVpos") = "VI"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub chkemisorpichincha_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkemisorpichincha.CheckedChanged
        If chkemisorpichincha.Checked Then
            Session("IdTarjetaVpos") = "PI"
            LlenaComboBanco(Session("IdTarjetaVpos"))
        End If
    End Sub

    Private Sub cmbtipopago_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbtipopago.SelectedIndexChanged
        'If cmbtipopago.SelectedValue = 4 Then
        '    Response.Redirect("RenovacionFormaPago.aspx", False)
        'Else
        If cmbtipopago.SelectedIndex > 0 Then
                Session("IdTipoPagoVpos") = cmbtipopago.SelectedValue
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
        Try
            If Len(txtbusquedaclientefac.Value) > 0 Then
                Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
                Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
                Dim dTDatosCliente As New DataTable
                dTDatosCliente = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "100", txtbusquedaclientefac.Value, "", "", "", ""))
                If dTDatosCliente.Rows.Count > 0 Then
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

    'Private Sub btnnuevoclientefac_ServerClick(sender As Object, e As System.EventArgs) Handles btnnuevoclientefac.ServerClick
    '    Try
    '        If Not validar() Then
    '            Dim ClienteEntity As New ClienteEntity
    '            Dim ClienteDetalleEntity As ClienteDetalleEntity
    '            Dim ClienteDetalleEntityCollection As New ClienteDetalleEntityCollection
    '            ClienteEntity = New ClienteEntity
    '            'DATOS CLIENTES
    '            ClienteEntity.ClienteId = txtcedulaclientefac.Value
    '            ClienteEntity.ClienteTipoIdentificacion = cmbcedulaclientefac.SelectedValue
    '            ClienteEntity.ClienteNacimiento = txtfechanacimientoclientefac.Text
    '            ClienteEntity.ClienteApellidoPadre = txtapellido1clientefac.Value
    '            ClienteEntity.ClienteApellidoMadre = txtapellido2clientefac.Value
    '            ClienteEntity.ClienteNombrePrimero = txtnombre1clientefac.Value
    '            ClienteEntity.ClienteNombreSegundo = txtnombre2clientefac.Value
    '            ClienteEntity.ClienteSexo = cmbsexoclientefac.SelectedValue
    '            'DATOS DIRECCION
    '            ClienteDetalleEntity = New ClienteDetalleEntity
    '            'ClienteDetalleEntity.DireccionSectorId = cmbsectorclientefac.SelectedValue
    '            ClienteDetalleEntity.DireccionProvinciaId = cmbprovinciaclientefac.SelectedValue
    '            ClienteDetalleEntity.DireccionCiudadId = cmbciudadclientefac.SelectedValue
    '            ClienteDetalleEntity.DireccionParroquiaId = cmbparroquiaclientefac.SelectedValue
    '            ClienteDetalleEntity.Direccion = txtdireccionclientefac.Value
    '            'ClienteDetalleEntity.DireccionInterseccion = txtinterseccionclientefac.Value
    '            'ClienteDetalleEntity.DireccionNumero = txtnumeroclientefac.Value
    '            'DATOS TELEFONO
    '            ClienteDetalleEntity.Telefono = txttelefonoclientefac.Value
    '            ClienteDetalleEntity.TelefonoCelular = txtcelularclientefac.Value
    '            'DATOS REFERENCIA BANCARIA
    '            ClienteDetalleEntity.EmailPrincipal = txtemailclientefac.Value
    '            ClienteDetalleEntity.EmailAlerta = ""

    '            ClienteDetalleEntityCollection.Add(ClienteDetalleEntity)
    '            ClienteEntity.ClienteDetalleEntityCollection = ClienteDetalleEntityCollection
    '            If DatosPersonalesAdapter.RegistroClienteFACTURA(ClienteEntity) Then
    '                txtFormaPagoIdentificacion.Text = txtcedulaclientefac.Value
    '                txtFormaPagoNombre.Text = txtnombre1clientefac.Value _
    '                                        & " " _
    '                                        & txtnombre2clientefac.Value _
    '                                        & " " _
    '                                        & txtapellido1clientefac.Value _
    '                                        & " " _
    '                                        & txtapellido2clientefac.Value
    '                txtFormaPagoDireccion.Text = txtdireccionclientefac.Value
    '                txtFormaPagoCelular.Text = txttelefonoclientefac.Value
    '                txtFormaPagoTelefono.Text = txtcelularclientefac.Value
    '                txtFormaPagoEmail.Text = txtemailclientefac.Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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
        table = CType(Session("tblrenovaciones"), DataTable)

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
            'ElseIf cmbtipopago.SelectedIndex = 3 And Not (Session("IdTarjetaVpos") = "VI" _
            '    Or Session("IdTarjetaVpos") = "MC") Then
            '    mensajeria_error("error", "la forma de pago seleccionada no se permite para esa tarjeta")
            '    retorno = False
            'ElseIf cmbtipopago.SelectedIndex = 4 Then
            '    mensajeria_error("error", "esa forma de pago no puede seleccionar")
            '    retorno = False
        ElseIf txtFormaPagoNombre.Text = "" And txtFormaPagoIdentificacion.Text = "" _
            And txtFormaPagoDireccion.Text = "" And txtFormaPagoTelefono.Text = "" _
            And txtFormaPagoCelular.Text = "" And txtFormaPagoEmail.Text = "" Then

            mensajeria_error("error", "datos de facturación incompletos, por favor completar")
            retorno = False
        ElseIf cmbbancos.SelectedIndex <= 0 Then
            mensajeria_error("error", "por favor seleccione un banco")
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
        table = CType(Session("tblrenovaciones"), DataTable)
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
            Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosDireccion As New DataTable
            dTDatosDireccion = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "101", "", Session("user_netsuite"), "", "", ""))
            If dTDatosDireccion.Rows.Count > 0 Then
                Rptdireccionfac.DataSource = dTDatosDireccion
                Rptdireccionfac.DataBind()
            Else
                Rptdireccionfac.DataSource = Nothing
                Rptdireccionfac.DataBind()
            End If
            Dim dTDatotelefono As New DataTable
            Dim dTtelefono As New DataTable
            dTtelefono = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "102", "", Session("user_netsuite"), "", "", ""))
            If dTtelefono.Rows.Count > 0 Then
                If dTtelefono.Select("IdTipoTelefono in(10,18)").Count > 0 Then
                    dTDatotelefono = dTtelefono.Select("IdTipoTelefono in(10,18)").CopyToDataTable().DefaultView.ToTable
                End If
                If dTDatotelefono.Rows.Count > 0 Then
                    Rpttelefonofac.DataSource = dTDatotelefono
                    Rpttelefonofac.DataBind()
                    Dim dTDatoscelular As New DataTable
                    If dTtelefono.Select("IdTipoTelefono in(4,19)").Count > 0 Then
                        dTDatoscelular = dTtelefono.Select("IdTipoTelefono in(4,19)").CopyToDataTable().DefaultView.ToTable
                    End If
                    If dTDatoscelular.Rows.Count > 0 Then
                        Rptcelularfac.DataSource = dTDatoscelular
                        Rptcelularfac.DataBind()
                    Else
                        Rptcelularfac.DataSource = Nothing
                        Rptcelularfac.DataBind()
                    End If
                End If
            Else
                Rpttelefonofac.DataSource = Nothing
                Rpttelefonofac.DataBind()
            End If
            Dim dTDatosEMail As New DataTable
            Dim dTEMail As New DataTable
            dTEMail = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "103", "", Session("user_netsuite"), "", "", ""))
            If dTEMail.Rows.Count > 0 Then
                If dTEMail.Select("IdTipoCorreo in(1,6,5,7)").Count > 0 Then
                    dTDatosEMail = dTEMail.Select("IdTipoCorreo in(1,6,5,7)").CopyToDataTable().DefaultView.ToTable
                End If
                If dTDatosEMail.Rows.Count > 0 Then
                    Rptemailfac.DataSource = dTDatosEMail
                    Rptemailfac.DataBind()
                Else
                    Rptemailfac.DataSource = Nothing
                    Rptemailfac.DataBind()
                End If
            End If

            'TIPO PAGO
            Dim dTDatostipoPago As New DataSet
            dTDatostipoPago = RenovacionAdapter.ConsultaTipoPago()
            If dTDatostipoPago.Tables(0).Rows.Count > 0 Then
                cmbtipopago.DataSource = dTDatostipoPago
                cmbtipopago.DataValueField = "CODIGO"
                cmbtipopago.DataTextField = "DESCRIPCION"
                cmbtipopago.DataBind()
            Else
                cmbtipopago.DataSource = Nothing
                cmbtipopago.DataBind()
            End If
            'If Not Session("IdTipoPagoVpos") Is Nothing Then
            '    If Session("IdTipoPagoVpos") = "3" Then
            '        cmbtipopago.SelectedIndex = 3
            '        cmbtipopago.Enabled = False
            '        chkemisoramerican.Enabled = False
            '        chkemisordiners.Enabled = False
            '        chkemisordiscover.Enabled = False
            '        chkemisorpacificard.Enabled = False
            '        chkemisorpichincha.Enabled = False
            '        chkemisortitanium.Enabled = False
            '    Else
            '        cmbtipopago.Items.RemoveAt(3)
            '        cmbtipopago.Enabled = True
            '    End If
            'Else
            '    Response.Redirect("Renovacion.aspx", False)
            'End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub llenar_combos_fact()
        Try
            Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamCatalogosClientes").ToString()
            'TIPO DE IDENTIFICACIOON
            Dim dTTipoIdentificacion As New DataTable
            dTTipoIdentificacion = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "TID", "", "", "", "", ""))
            poblar_combo_ns(cmbcedulaclientefac, dTTipoIdentificacion)
            'SEXO
            Dim dTSexo As New DataTable
            dTSexo = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "SEX", "", "", "", "", ""))
            poblar_combo_ns(cmbsexoclientefac, dTSexo)
            'PROVINCIA
            Dim dTDatosProvincia As New DataTable
            dTDatosProvincia = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "PROV", "", "", "", "", ""))
            poblar_combo_ns(cmbprovinciaclientefac, dTDatosProvincia)
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

    Private Sub poblar_combo_ns(ByVal combo As DropDownList, ByVal tabla As DataTable)
        Try
            combo.DataSource = tabla
            combo.DataTextField = "Descripcion"
            combo.DataValueField = "Id"
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
            Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamCatalogosClientes").ToString()
            Dim dTDatosCliente As New DataTable
            dTDatosCliente = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "CIU", cmbprovinciaclientefac.SelectedValue, "", "", "", ""))
            poblar_combo_ns(cmbciudadclientefac, dTDatosCliente)
            If dTDatosCliente.Rows.Count > 0 Then
                LlenaComboParroquia()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LlenaComboParroquia()
        Try
            cmbparroquiaclientefac.DataSource = ""
            cmbparroquiaclientefac.DataBind()
            Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamCatalogosClientes").ToString()
            Dim dTDatosCliente As New DataTable
            dTDatosCliente = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "PARR", cmbprovinciaclientefac.SelectedValue, cmbciudadclientefac.SelectedValue, "", "", ""))
            poblar_combo_ns(cmbparroquiaclientefac, dTDatosCliente)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LlenaComboBanco(ByVal emisorid As String)
        Try
            cmbbancos.DataSource = ""
            cmbbancos.DataBind()
            Dim dTDatosBanco As New DataSet
            dTDatosBanco = DatosPersonalesAdapter.ConsultaBanco(emisorid)
            poblar_combo(cmbbancos, dTDatosBanco.Tables(0))
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
        ElseIf cmbsexoclientefac.SelectedIndex < 0 Then
            retorno = True
            cmbsexoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un género"
        ElseIf cmbcedulaclientefac.SelectedIndex < 0 Then
            retorno = True
            cmbcedulaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un tipo de identificación"
        ElseIf cmbciudadclientefac.SelectedIndex < 0 Then
            retorno = True
            cmbciudadclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una ciudad"
        ElseIf cmbparroquiaclientefac.SelectedIndex < 0 Then
            retorno = True
            cmbparroquiaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una parroquia"
        ElseIf cmbprovinciaclientefac.SelectedIndex < 0 Then
            retorno = True
            cmbprovinciaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una provincia"
        ElseIf txtfechanacimientoclientefac.Text > DateAdd(DateInterval.Year, -18, Date.Now) Then
            retorno = True
            txtfechanacimientoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingrese fecha nacimiento del cliente válidO"
        End If
        If cmbcedulaclientefac.SelectedValue = "1" Or cmbcedulaclientefac.SelectedValue = "2" Then
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

    Private Function cliente_ns(cliente) As String
        Dim retorno As String = ""
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosPersonales As DataTable
            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", cliente, "", "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                retorno = dTDatosPersonales.Rows(0)("IdCliente").ToString
            End If
        Catch ex As Exception
            retorno = ""
        End Try
        Return retorno
    End Function

#End Region

End Class