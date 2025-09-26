Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Drawing

Public Class RenovacionExterna
    Inherits System.Web.UI.Page

#Region "Declaracion de variables"
    Dim zerovalue As String = "0.00"
    Dim zerovalueconsigno As String = "$0.00"
#End Region

#Region "Eventos de la pagina"
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Session("user") = "0916517956"
            'Session("user_id") = "0916517956"
            'Session("display_name") = "Felix Ontaneda"
            'Session("Email") = "fontaneda@carsegsa.com"
            'Session("userveh") = "1001068378"

            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    mensajeria_error("", "")
                    Session("DTPorcentajeIva") = RenovacionAdapter.ConsultaPorcentajeIva()
                    Session("tblrenovaciones") = Nothing
                    ConsultaProductoCliente()
                    llena_info_factura()
                    llenainfodatos()
                    Session("IdTarjetaVpos") = ""
                    Session("IdTipoPagoVpos") = ""
                    FormularioAdapter.RegistroLogFormulario(107, Session("user_id"), Session("usuario"), "USUARIO CON LOGIN SATISFACTORIO - RELOAD SOPORTE", Session("iphost"))

                    FormularioAdapter.RegistroLogFormulario(103, Session("user"), Session("user"), "RENOVACION DE PRODUCTOS DESDE AMI", Session("iphost"))
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            Else
                'MaintainScrollPositionOnPostBack = False

                If Session("user") Is Nothing Then
                    Response.Redirect("./login.aspx", False)
                End If
                'If Session("errorbandera") = "0" Then
                '    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "ShowPopup();", True)
                'End If

                'Page.SetFocus(txtdireccionclientefac.ClientID)

                'txtFormaPagoDireccion.Focus()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Controles"

    Private Sub btnfiltrar_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltrar.ServerClick
        Try
            ConsultaProductoCliente()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub chkI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try
            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                carro_compras("0.00", 0)
                Session("tblrenovaciones") = Nothing
                CalculaItemsSeleccionados()
                resumen_compra()
                carro_compra()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub cmbaniorenovar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            carro_compras("0.00", 0)
            Session("tblrenovaciones") = Nothing
            CalculaItemsSeleccionados()
            resumen_compra()
            carro_compra()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
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

    Private Sub btnpagar_Click(sender As Object, e As System.EventArgs) Handles btnpagar.Click
        If validaciones_pago() Then
            Try
                genera_orden_web()
            Catch ex As Exception
                ExceptionHandler.Captura_Error(ex)
            End Try
        End If
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub ConsultaProductoCliente()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = RenovacionAdapter.ConsultaProductoClienteAux(Session.Item("user"), Session("userveh"), "T")
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                Session("DTProductoCliente") = dTCstGeneral
                Me.Rpt_renovacion.DataSource = dTCstGeneral.Tables(0)
                Me.Rpt_renovacion.DataBind()
                For Each item As RepeaterItem In Rpt_renovacion.Items
                    Dim rptitm As Repeater = CType(item.FindControl("Rpt_renovacion_items"), Repeater)
                    Dim lblgrupo As Label = CType(item.FindControl("lblgrupoitem0"), Label)
                    Dim vehiculo_itm As String = lblgrupo.Text
                    Dim tblitm As New System.Data.DataTable
                    tblitm = dTCstGeneral.Tables(1).Clone()
                    dTCstGeneral.Tables(1).Select("CODIGO_VEHICULO=" & vehiculo_itm).CopyToDataTable(tblitm, LoadOption.OverwriteChanges)
                    rptitm.DataSource = tblitm
                    rptitm.DataBind()
                Next
            Else
                mensajeria_error("error", "Usted no registra servicios pendientes de pago.")
                Session("DTProductoCliente") = Nothing
                Me.Rpt_renovacion.DataSource = Nothing
                Me.Rpt_renovacion.DataBind()
            End If

            For Each item As RepeaterItem In Rpt_renovacion.Items
                Dim rptitm As Repeater = CType(item.FindControl("Rpt_renovacion_items"), Repeater)
                Dim lblvehiculo As Label = CType(item.FindControl("lblgrupoitem0"), Label)
                For Each sub_item As RepeaterItem In rptitm.Items
                    Dim vehiculo_itm As String = lblvehiculo.Text
                    Dim lblproducto As Label = CType(sub_item.FindControl("lblproductocodigo0"), Label)
                    Dim cmbanio As DropDownList = CType(sub_item.FindControl("cmbanticipado0"), DropDownList)
                    Dim dTCstGeneralAnio As New System.Data.DataSet
                    dTCstGeneralAnio = RenovacionAdapter.ConsultaListadoAnioRenovacion(vehiculo_itm, lblproducto.Text)
                    If dTCstGeneralAnio.Tables(0).Rows.Count > 0 Then
                        cmbanio.DataSource = dTCstGeneralAnio
                        cmbanio.DataValueField = "ANIO"
                        cmbanio.DataTextField = "ANIO"
                        cmbanio.DataBind()
                        cmbanio.SelectedIndex = 0
                    End If
                Next
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CalculaItemsSeleccionados()
        Try
            Dim valueCantidadRenovar As Integer
            Dim valueTotalRenovar As Decimal
            Dim valueCellPrecioVenta As Decimal
            Dim valueCellPromocionCodigo As String
            Dim valueCellPromocionValor As Decimal
            Dim valueCellDescuentoValor As Decimal
            Dim valueCellPrecioTotal As Decimal
            Dim valueCellIvaValor As Decimal
            Dim valueCellPrecioCliente As Decimal
            Dim valuecontador As Integer = 0
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = Session("DTProductoCliente")

            Dim table As New System.Data.DataTable
            Dim row As DataRow
            table = TablaRenovaciones()
            For Each item As RepeaterItem In Rpt_renovacion.Items
                Dim rptitm As Repeater = CType(item.FindControl("Rpt_renovacion_items"), Repeater)
                Dim lblgrupo As Label = CType(item.FindControl("lblgrupoitem0"), Label)
                Dim lblvehiculonombre As Label = CType(item.FindControl("lblnombreitem0"), Label)
                Dim vehiculo_itm As String = lblgrupo.Text
                Dim vehiculo_nombre As String = lblvehiculonombre.Text

                For Each sub_item As RepeaterItem In rptitm.Items
                    Dim chkI As CheckBox = CType(sub_item.FindControl("chkitem00"), CheckBox)
                    Dim lblvalor As Label = CType(sub_item.FindControl("lbltotalitem0"), Label)
                    Dim lblproducto As Label = CType(sub_item.FindControl("lblproductocodigo0"), Label)
                    Dim cmbanio As DropDownList = CType(sub_item.FindControl("cmbanticipado0"), DropDownList)
                    Dim lblpromo As Label = CType(sub_item.FindControl("lblpromo0"), Label)
                    Dim lblgruponombre As Label = CType(sub_item.FindControl("lblproductoitem0"), Label)
                    Dim lblfechavencimiento As Label = CType(sub_item.FindControl("lblfechavencimiento0"), Label)
                    If chkI.Checked Then
                        If cmbanio.SelectedValue > 0 Then
                            Dim dTCstPrecio As New System.Data.DataSet
                            dTCstPrecio = RenovacionAdapter.ConsultaPrecioProducto(vehiculo_itm, lblproducto.Text, cmbanio.SelectedValue, "", "NO", "")
                            If dTCstPrecio.Tables(0).Rows.Count > 0 Then
                                valuecontador += 1
                                valueCellPrecioVenta = dTCstPrecio.Tables(0).Rows(0)("PRECIO_VENTA")
                                valueCellPromocionCodigo = dTCstPrecio.Tables(0).Rows(0)("CODIGO_PROMOCION")
                                valueCellPromocionValor = dTCstPrecio.Tables(0).Rows(0)("VALOR_PROMOCION")
                                valueCellDescuentoValor = dTCstPrecio.Tables(0).Rows(0)("VALOR_DESCUENTO")
                                valueCellPrecioTotal = dTCstPrecio.Tables(0).Rows(0)("PRECIO_TOTAL")
                                valueCellIvaValor = dTCstPrecio.Tables(0).Rows(0)("IVA")
                                valueCellPrecioCliente = dTCstPrecio.Tables(0).Rows(0)("PRECIO_CLIENTE")
                                lblvalor.Text = If(valueCellPrecioVenta = 0, zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", valueCellPrecioVenta))
                                lblpromo.Text = ""

                                If (valueCellIvaValor > 0) Then
                                    If Session("DTPorcentajeIva") = Nothing Then Session("DTPorcentajeIva") = RenovacionAdapter.ConsultaPorcentajeIva()
                                    Dim porcentajeIva As Decimal = Session("DTPorcentajeIva")
                                    valueCellIvaValor = Math.Round((valueCellPrecioTotal * porcentajeIva), 2, MidpointRounding.AwayFromZero)
                                    valueCellPrecioCliente = valueCellPrecioTotal + valueCellIvaValor
                                End If

                                valueCantidadRenovar = CInt(lblcantidadcarrito.Text)
                                lblcantidadcarrito.Text = valueCantidadRenovar + 1
                                valueTotalRenovar = Convert.ToDecimal(lblTotalCompra.Text)
                                lblTotalCompra.Text = valueTotalRenovar + valueCellPrecioCliente

                                row = table.NewRow()
                                row("INDICE") = valuecontador
                                row("VEHICULO") = vehiculo_itm
                                row("PRODUCTO") = lblproducto.Text
                                row("PRECIO_VENTA") = valueCellPrecioVenta
                                row("CODIGO_PROMOCION") = valueCellPromocionCodigo
                                row("VALOR_PROMOCION") = valueCellPromocionValor
                                row("VALOR_DESCUENTO") = valueCellDescuentoValor
                                row("PRECIO_TOTAL") = valueCellPrecioTotal
                                row("IVA") = valueCellIvaValor
                                row("PRECIO_CLIENTE") = valueCellPrecioCliente
                                row("VEHICULO_NOMBRE") = vehiculo_nombre
                                row("GRUPO_DESCRIPCION") = lblgruponombre.Text
                                row("ANIO") = cmbanio.SelectedValue
                                row("FECHAFIN") = lblfechavencimiento.Text
                                table.Rows.Add(row)
                            End If
                        Else
                            chkI.Checked = False
                        End If
                    Else
                        lblvalor.Text = "0.00"
                        lblpromo.Text = ""
                    End If
                Next
            Next
            Session("tblrenovaciones") = table
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function TablaRenovaciones() As DataTable
        Dim table As New System.Data.DataTable
        Dim column As DataColumn
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Int32")
        column.ColumnName = "INDICE"
        column.AutoIncrement = True
        column.Caption = "INDICE"
        column.[ReadOnly] = True
        column.Unique = True
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "VEHICULO"
        column.AutoIncrement = False
        column.Caption = "VEHICULO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "PRODUCTO"
        column.AutoIncrement = False
        column.Caption = "PRODUCTO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "PRECIO_VENTA"
        column.AutoIncrement = False
        column.Caption = "PRECIO_VENTA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "CODIGO_PROMOCION"
        column.AutoIncrement = False
        column.Caption = "CODIGO_PROMOCION"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "VALOR_PROMOCION"
        column.AutoIncrement = False
        column.Caption = "VALOR_PROMOCION"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "VALOR_DESCUENTO"
        column.AutoIncrement = False
        column.Caption = "VALOR_DESCUENTO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "PRECIO_TOTAL"
        column.AutoIncrement = False
        column.Caption = "PRECIO_TOTAL"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "IVA"
        column.AutoIncrement = False
        column.Caption = "IVA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "PRECIO_CLIENTE"
        column.AutoIncrement = False
        column.Caption = "PRECIO_CLIENTE"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "VEHICULO_NOMBRE"
        column.AutoIncrement = False
        column.Caption = "VEHICULO_NOMBRE"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "GRUPO_DESCRIPCION"
        column.AutoIncrement = False
        column.Caption = "GRUPO_DESCRIPCION"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Int32")
        column.ColumnName = "ANIO"
        column.AutoIncrement = False
        column.Caption = "ANIO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FECHAFIN"
        column.AutoIncrement = False
        column.Caption = "FECHAFIN"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        Return table
    End Function

    Public Shared Sub RegistroCarroCompra()
        Try
            If Not HttpContext.Current.Session("DTCarroCompraMasterTableView") Is Nothing Then
                '                Dim ordenEntity As New OrdenEntity
                '                Dim ordenDetalleEntity As OrdenDetalleEntity
                '                Dim ordenDetalleEntityCollection As New OrdenDetalleEntityCollection
                '                Dim valueCellPrecioTotal As Decimal
                '                Dim valueCellIvaValor As Decimal
                '                Dim valueCellPrecioCliente As Decimal
                '                Dim gridTableView As GridTableView = HttpContext.Current.Session("DTCarroCompraMasterTableView")
                '                Dim gridTableViewDefault As GridTableView = HttpContext.Current.Session("DTCarroCompraMasterTableViewDefault")
                '                Dim indice As Int32 = 0
                '                Dim secuencia As Int32 = 0
                '                Dim bandera As Boolean = False
                '                If gridTableView.Items.Count = gridTableViewDefault.Items.Count Then
                '                    While indice <= gridTableView.Items.Count - 1
                '                        Dim itemActual As GridDataItem = gridTableView.Items(indice)
                '                        Dim chkIActual As CheckBox = TryCast(itemActual.FindControl("chkI"), CheckBox)
                '                        Dim cmbaniorenovarActual As RadComboBox = DirectCast(itemActual.FindControl("cmbaniorenovar"), RadComboBox)
                '                        Dim txtpromocionActual As RadTextBox = TryCast(itemActual.FindControl("txtpromocion"), RadTextBox)
                '                        Dim itemDefault As GridDataItem = gridTableViewDefault.Items(indice)
                '                        Dim chkIDefault As CheckBox = TryCast(itemDefault.FindControl("chkI"), CheckBox)
                '                        Dim cmbaniorenovarDefault As RadComboBox = DirectCast(itemDefault.FindControl("cmbaniorenovar"), RadComboBox)
                '                        Dim txtpromocionDefault As RadTextBox = TryCast(itemDefault.FindControl("txtpromocion"), RadTextBox)
                '                        If Not (chkIActual.Checked = chkIDefault.Checked AndAlso _
                '                            cmbaniorenovarActual.SelectedValue = cmbaniorenovarDefault.SelectedValue AndAlso _
                '                            txtpromocionActual.Text = txtpromocionDefault.Text AndAlso _
                '                            itemActual("CODIGO_VEHICULO").Text = itemDefault("CODIGO_VEHICULO").Text AndAlso _
                '                            itemActual("PRODUCTO").Text = itemDefault("PRODUCTO").Text) Then
                '                            bandera = True
                '                            Exit While
                '                        End If
                '                        indice += 1
                '                    End While
                '                End If
                '                For Each item As GridDataItem In gridTableView.Items
                '                    Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                '                    'Dim cmbaniorenovar As RadComboBox = DirectCast(item.FindControl("cmbaniorenovar"), RadComboBox)
                '                    'Dim txtpromocion As RadTextBox = TryCast(item.FindControl("txtpromocion"), RadTextBox)
                '                    If chkI.Checked = True And Libreria.Parse(item("PRECIO_VENTA").Text) > 0 Then
                '                        valueCellPrecioTotal = valueCellPrecioTotal + Convert.ToDecimal(Libreria.Parse(item("PRECIO_TOTAL").Text))
                '                        valueCellIvaValor = valueCellIvaValor + Convert.ToDecimal(Libreria.Parse(item("IVA").Text))
                '                        valueCellPrecioCliente = valueCellPrecioCliente + Convert.ToDecimal(Libreria.Parse(item("PRECIO_CLIENTE").Text))
                '                    End If
                '                Next
                '                'Calculamos el nuevo iva
                '                If (valueCellIvaValor > 0) Then
                '                    Dim porcentajeIva As Decimal = RenovacionAdapter.ConsultaPorcentajeIva()
                '                    valueCellIvaValor = Math.Round((valueCellPrecioTotal * porcentajeIva), 2)
                '                    valueCellPrecioCliente = valueCellPrecioTotal + valueCellIvaValor
                '                End If
                '                CarroCompraAdapter.EliminoCarroCompra(HttpContext.Current.Session("user"))
                '                If valueCellPrecioCliente > 0 Then
                '                    ordenEntity.ClienteId = HttpContext.Current.Session("user")
                '                    ordenEntity.SubTotal = valueCellPrecioTotal
                '                    ordenEntity.Iva = valueCellIvaValor
                '                    ordenEntity.Total = valueCellPrecioCliente
                '                    ordenEntity.EstadoWebId = 1
                '                    ordenEntity.UsuarioProcesoId = 0
                '                    secuencia = 1
                '                    For Each item As GridDataItem In gridTableView.Items
                '                        Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                '                        Dim cmbaniorenovar As RadComboBox = DirectCast(item.FindControl("cmbaniorenovar"), RadComboBox)
                '                        Dim txtpromocion As RadTextBox = TryCast(item.FindControl("txtpromocion"), RadTextBox)
                '                        If chkI.Checked = True And Libreria.Parse(item("PRECIO_VENTA").Text) > 0 Then
                '                            ordenDetalleEntity = New OrdenDetalleEntity
                '                            ordenDetalleEntity.OrdenDetalleId = secuencia
                '                            ordenDetalleEntity.VehiculoId = item("CODIGO_VEHICULO").Text
                '                            ordenDetalleEntity.TransaccionId = item("PRODUCTO").Text
                '                            ordenDetalleEntity.FechaVencimiento = DateTime.ParseExact(item("FECHA_FIN").Text, "dd/MMM/yyyy", Nothing).Date
                '                            ordenDetalleEntity.Anios = cmbaniorenovar.SelectedValue
                '                            ordenDetalleEntity.ValorAnual = Libreria.Parse(item("PRECIO_VENTA").Text)
                '                            ordenDetalleEntity.CodigoPromocion = txtpromocion.Text
                '                            ordenDetalleEntity.ValorPromocion = Libreria.Parse(item("VALOR_PROMOCION").Text)
                '                            ordenDetalleEntity.PorcentajeDescuento = 0
                '                            ordenDetalleEntity.Descuento = 0
                '                            ordenDetalleEntity.SubTotal = Libreria.Parse(item("PRECIO_TOTAL").Text)
                '                            ordenDetalleEntity.Iva = Libreria.Parse(item("IVA").Text)
                '                            ordenDetalleEntity.Total = Libreria.Parse(item("PRECIO_CLIENTE").Text)
                '                            ordenDetalleEntity.UsuarioProcesoId = 0
                '                            ordenDetalleEntityCollection.Add(ordenDetalleEntity)
                '                            secuencia = secuencia + 1
                '                        End If
                '                    Next
                '                    ordenEntity.OrdenDetalleEntityCollection = ordenDetalleEntityCollection
                '                    CarroCompraAdapter.RegistroCarroCompra(ordenEntity)
                '                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub carro_compras(valor As String, cantidad As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        lblcantidadcarrito.Text = cantidad
        lblTotalCompra.Text = valor
    End Sub

    Private Function valida_controles() As Boolean
        Dim retorno As Boolean = True
        Dim table As New System.Data.DataTable
        table = CType(Session("tblrenovaciones"), DataTable)

        If table.Rows.Count = 0 Then
            retorno = False
            mensajeria_error("error", "no existen productos a renovar, por favor verificar")
        ElseIf Not chkemisoramerican.Checked And Not chkemisordiners.Checked _
            And Not chkemisordiscover.Checked And Not chkemisormastercard.Checked _
            And Not chkemisorpacificard.Checked And Not chkemisortitanium.Checked And Not chkemisorvisa.Checked Then
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
            lblUserName.Text = Session("display_name")
            lblUserEmail.Text = dTCstFactura.Tables(0).Rows(0)("EMAIL")
            lblUserCelular.Text = dTCstFactura.Tables(0).Rows(0)("CELULAR")
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
        Return retorno
    End Function

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
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

    Private Sub numero_orden()
        lblnumeroorden.Text = OrdenPagoAdapter.ConsultaSecuenciaOrdenPago()
    End Sub

    Private Sub carro_compra()
        Dim table As New System.Data.DataTable
        Dim valueCantidadRenovar As Integer = 0
        Dim valueCellPrecioUnitario As Decimal = 0
        Dim valueCellPrecioPromocion As Decimal = 0
        Dim valueCellPrecioSubtotal As Decimal = 0
        Dim valueCellPrecioIva As Decimal = 0
        Dim valueCellPrecioCliente As Decimal = 0
        table = CType(Session("tblrenovaciones"), DataTable)
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                valueCantidadRenovar += 1
                valueCellPrecioUnitario += table.Rows(i)("PRECIO_VENTA")
                valueCellPrecioPromocion += table.Rows(i)("VALOR_PROMOCION")
                valueCellPrecioSubtotal += table.Rows(i)("PRECIO_TOTAL")
                valueCellPrecioIva += table.Rows(i)("IVA")
                valueCellPrecioCliente += table.Rows(i)("PRECIO_CLIENTE")
            Next
            carro_compras(valueCellPrecioCliente, valueCantidadRenovar)
            lblresumencantidad.Text = valueCantidadRenovar
            lblresumentotal.Text = valueCellPrecioUnitario
            lblresumenpromocion.Text = valueCellPrecioPromocion
            lblresumensubtotal.Text = valueCellPrecioSubtotal
            lblresumeniva.Text = valueCellPrecioIva
            lblresumenpreciocliente.Text = valueCellPrecioCliente
        End If
    End Sub

    Private Sub resumen_compra()
        Dim table As New System.Data.DataTable
        Dim i As Integer = 0
        table = CType(Session("tblrenovaciones"), DataTable)
        Dim vistatbl As DataView = New DataView(table)
        Dim distinctValues As DataTable = vistatbl.ToTable(True, "VEHICULO_NOMBRE", "VEHICULO")
        Me.Rpt_resumen_renovacion.DataSource = distinctValues
        Me.Rpt_resumen_renovacion.DataBind()
        For Each item As RepeaterItem In Rpt_resumen_renovacion.Items
            Dim rptitm As Repeater = CType(item.FindControl("Rpt_resumen_renovacion_itm"), Repeater)
            Dim tblitm As New System.Data.DataTable
            tblitm = table.Clone()
            table.Select("VEHICULO=" & distinctValues.Rows(i).Item("VEHICULO")).CopyToDataTable(tblitm, LoadOption.OverwriteChanges)
            rptitm.DataSource = tblitm
            rptitm.DataBind()
            i += 1
        Next
    End Sub

    Private Function validaciones_pago() As Boolean
        Dim retorno As Boolean = True

        If Session("IdTarjetaVpos") = "" Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo una tarjeta.")
        ElseIf Session("IdTipoPagoVpos") = "" Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo un tipo de pago.")
        ElseIf Libreria.Parse(lblcantidadcarrito.Text) = 0 Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo un servicio.")
        ElseIf Libreria.Parse(lblresumencantidad.Text) = 0 Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo un servicio.")
        ElseIf secuencial_emisor(Session("IdTarjetaVpos")) = "" Then
            retorno = False
            mensajeria_error("error", "no se pudo obtener datos de tarjeta.")
        ElseIf txtFormaPagoIdentificacion.Text = "" Or txtFormaPagoDireccion.Text = "" Or txtFormaPagoTelefono.Text = "" _
            Or txtFormaPagoCelular.Text = "" Or txtFormaPagoEmail.Text = "" Then
            retorno = False
            mensajeria_error("error", "por favor completar datos de facturación.")
        End If

        Return retorno
    End Function

    Private Sub genera_orden_web()
        Dim ordenEntity As New OrdenEntity
        Dim ordenDetalleEntity As OrdenDetalleEntity
        Dim ordenDetalleEntityCollection As New OrdenDetalleEntityCollection
        Dim datosVpos As String = secuencial_emisor(Session("IdTarjetaVpos"))
        Dim idemisor As String = datosVpos.Substring(2, 3)
        Dim secuencialemisor As Integer = datosVpos.Substring(2, 3)
        Dim secuencialsh As String = "000"

        Dim tablefac As New System.Data.DataTable
        Dim valueFormaPagoNomb As String = ""
        Dim valueFormaPagoIdnt As String = ""
        Dim valueFormaPagoDirc As String = ""
        Dim valueFormaPagoTelf As String = ""
        Dim valueFormaPagoCell As String = ""
        Dim valueFormaPagoEmail As String = ""
        valueFormaPagoNomb = txtFormaPagoNombre.Text
        valueFormaPagoIdnt = txtFormaPagoIdentificacion.Text
        valueFormaPagoDirc = txtFormaPagoDireccion.Text
        valueFormaPagoTelf = txtFormaPagoTelefono.Text
        valueFormaPagoCell = txtFormaPagoCelular.Text
        valueFormaPagoEmail = txtFormaPagoEmail.Text
        If Session("IdTarjetaVpos") = "PC" Then
            Session("Pacificard") = "1"
        Else
            Session("Pacificard") = "0"
        End If
        ordenEntity.OrdenId = 0
        ordenEntity.ClienteId = Session("user_id")
        ordenEntity.NumeroMeses = 1
        ordenEntity.TipoTarjeta = VposAnterior(Session("IdTarjetaVpos"))
        ordenEntity.SubTotal = lblresumensubtotal.Text
        ordenEntity.Iva = lblresumeniva.Text
        ordenEntity.Ice = 0
        ordenEntity.Interes = 0
        ordenEntity.Total = Libreria.Parse(lblresumenpreciocliente.Text)
        ordenEntity.TipoPago = 1
        ordenEntity.TipoCredito = "00"
        ordenEntity.CodigoConfPago = 0
        ordenEntity.BillingName = valueFormaPagoNomb
        ordenEntity.BillingCedula = valueFormaPagoIdnt
        ordenEntity.BillingAddress = valueFormaPagoDirc
        ordenEntity.BillingPhone = valueFormaPagoTelf
        ordenEntity.BillingMovil = valueFormaPagoCell
        ordenEntity.BillingEmail = valueFormaPagoEmail
        ordenEntity.BillingCardType = 0
        ordenEntity.EstadoWebId = 1
        ordenEntity.UsuarioProcesoId = 0
        ordenEntity.AccionComercial = "REN"
        OrdenPagoAdapter.ConfirmoPagoOnline(ordenEntity)
        ordenEntity = New OrdenEntity
        numero_orden()
        Dim ordenId As String = lblnumeroorden.Text
        ordenEntity.OrdenId = ordenId
        ordenEntity.ClienteId = Session("user_id")
        ordenEntity.idemisor = secuencialemisor
        ordenEntity.NumeroMeses = 1
        ordenEntity.TipoTarjeta = Session("IdTarjetaVpos")
        ordenEntity.SubTotal = lblresumensubtotal.Text
        ordenEntity.Iva = lblresumeniva.Text
        ordenEntity.Ice = 0
        ordenEntity.Interes = 0
        ordenEntity.Total = Libreria.Parse(lblresumenpreciocliente.Text)
        ordenEntity.TipoPago = 1
        ordenEntity.TipoCredito = "00"
        ordenEntity.CodigoConfPago = 0
        ordenEntity.BillingName = valueFormaPagoNomb
        ordenEntity.BillingCedula = valueFormaPagoIdnt
        ordenEntity.BillingAddress = valueFormaPagoDirc
        ordenEntity.BillingPhone = valueFormaPagoTelf
        ordenEntity.BillingMovil = valueFormaPagoCell
        ordenEntity.BillingEmail = valueFormaPagoEmail
        ordenEntity.BillingCardType = 0
        ordenEntity.EstadoWebId = 1
        ordenEntity.UsuarioProcesoId = 0
        ordenEntity.AccionComercial = "REN"
        ordenEntity.UsuarioSoporte = IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE")
        Dim table As New System.Data.DataTable
        table = CType(Session("tblrenovaciones"), DataTable)
        For i As Integer = 0 To table.Rows.Count - 1
            ordenDetalleEntity = New OrdenDetalleEntity
            ordenDetalleEntity.OrdenDetalleId = 0
            ordenDetalleEntity.OrdenId = ordenEntity.OrdenId
            ordenDetalleEntity.VehiculoId = table.Rows(i).Item("VEHICULO")
            ordenDetalleEntity.TransaccionId = table.Rows(i).Item("PRODUCTO")
            ordenDetalleEntity.FechaVencimiento = table.Rows(i).Item("FECHAFIN")
            ordenDetalleEntity.Anios = table.Rows(i).Item("ANIO")
            ordenDetalleEntity.ValorAnual = table.Rows(i).Item("PRECIO_VENTA")
            ordenDetalleEntity.CodigoPromocion = "000"
            ordenDetalleEntity.ValorPromocion = table.Rows(i).Item("VALOR_PROMOCION")
            ordenDetalleEntity.PorcentajeDescuento = 0
            ordenDetalleEntity.Descuento = 0
            ordenDetalleEntity.SubTotal = table.Rows(i).Item("PRECIO_TOTAL")
            ordenDetalleEntity.Iva = table.Rows(i).Item("IVA")
            ordenDetalleEntity.Total = table.Rows(i).Item("PRECIO_CLIENTE")
            ordenDetalleEntity.MarcadoLojack = ""
            ordenDetalleEntity.UsuarioProcesoId = 0
            ordenDetalleEntityCollection.Add(ordenDetalleEntity)
        Next

        ordenEntity.OrdenDetalleEntityCollection = ordenDetalleEntityCollection
        Session("OrdenID") = ordenEntity.OrdenId
        lblnumeroorden.Text = ordenEntity.OrdenId
        OrdenPagoAdapter.RegistroPagoOnline(ordenEntity)

        Dim dTGetInfoUrlTecnico As New DataTable()
        dTGetInfoUrlTecnico.Columns.Add("datatecnica", GetType(String))
        dTGetInfoUrlTecnico.Rows.Add(ordenEntity.OrdenId)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoIdnt)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoNomb)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoDirc)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoCell)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoEmail)
        dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))
        dTGetInfoUrlTecnico.Rows.Add(Libreria.Parse(lblresumenpreciocliente.Text))
        dTGetInfoUrlTecnico.Rows.Add(lblresumensubtotal.Text)
        dTGetInfoUrlTecnico.Rows.Add(0) 'descuentos
        dTGetInfoUrlTecnico.Rows.Add(0) 'promociones
        dTGetInfoUrlTecnico.Rows.Add(lblresumeniva.Text)
        dTGetInfoUrlTecnico.Rows.Add(idemisor)
        dTGetInfoUrlTecnico.Rows.Add("REN")
        dTGetInfoUrlTecnico.Rows.Add(Date.Now)
        dTGetInfoUrlTecnico.Rows.Add("00:00")
        dTGetInfoUrlTecnico.Rows.Add(0)
        dTGetInfoUrlTecnico.Rows.Add(IIf(Session("IdTipoPagoVpos") = 1, 0, Session("IdTipoPagoVpos")))
        EMailHandler.EMailGeneracionOrdenPago("Hunter Online", "Registro de orden de pago exitoso <<inicio boton de pago>>.", Session("OrdenID"), Session("iphost"))
        Session("DTGetInfoURLTecnico") = dTGetInfoUrlTecnico

        If VposAnterior(Session("IdTarjetaVpos")) = "MC" Or VposAnterior(Session("IdTarjetaVpos")) = "VI" Then
            Response.Redirect("cotizadorweburltecnicopaymentez.aspx", False)
        ElseIf VposAnterior(Session("IdTarjetaVpos")) = "DN" Then
            Response.Redirect("cotizadorweburltecnico.aspx", False)
        End If
    End Sub

    Private Function secuencial_emisor(id_emisor As String) As String
        Dim retorno As String = ""

        Dim dTCstEmisor As New System.Data.DataSet
        dTCstEmisor = RenovacionAdapter.ConsultaEmisorDetalleVpos(id_emisor, "NO")
        If dTCstEmisor.Tables(0).Rows.Count > 0 Then
            retorno = dTCstEmisor.Tables(0).Rows(0).Item("SECUENCIAL")
        Else
            retorno = ""
        End If

        Return retorno
    End Function

    Private Function VposAnterior(id_emisor As String) As String
        Dim retorno As String = ""

        If id_emisor = "VI" Then
            retorno = "VI"
        ElseIf id_emisor = "MC" Then
            retorno = "MC"
        ElseIf id_emisor = "DN" Then
            retorno = "DN"
        ElseIf id_emisor = "DI" Then
            retorno = "DN"
        ElseIf id_emisor = "PC" Then
            retorno = "PC"
        ElseIf id_emisor = "AM" Then
            retorno = "AM"
        ElseIf id_emisor = "TI" Then
            retorno = "PI"
        ElseIf id_emisor = "PI" Then
            retorno = "PI"
        End If

        Return retorno
    End Function

#End Region

End Class