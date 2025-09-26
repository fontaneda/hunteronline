Imports System.Globalization

Public Class RenovacionForma
    Inherits System.Web.UI.Page

#Region "Declaracion de variables"
    Dim zerovalue As String = "0.00"
    Dim zerovalueconsigno As String = "$0.00"
#End Region

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Renovación de Servicios Forma de Pago", 3, "Renovacion seleccion de productos")
                    mensajeria_error("", "")
                    Session("DTPorcentajeIva") = RenovacionAdapter.ConsultaPorcentajeIva()
                    Session("tblrenovaciones") = Nothing
                    ConsultaProductoCliente()

                Else
                    Response.Redirect("./login.aspx", False)
                End If
            Else
                If Not Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



#End Region

#Region "Eventos de los controles"

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
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btncontinuar_ServerClick(sender As Object, e As System.EventArgs) Handles btncontinuar.ServerClick
        Dim table As New System.Data.DataTable
        table = CType(Session("tblrenovaciones"), DataTable)
        If table.Rows.Count > 0 Then
            Response.Redirect("RenovacionFormaPago.aspx", False)
        End If
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub ConsultaProductoCliente()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = RenovacionAdapter.ConsultaProductoClienteAux(Session.Item("user"), txtfiltrar.Text.Trim, "T")
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

                                Dim myMasterPage As master = CType(Page.Master, master)
                                valueCantidadRenovar = CInt(myMasterPage.cantidadMaster)
                                myMasterPage.cantidadMaster = valueCantidadRenovar + 1
                                valueTotalRenovar = Convert.ToDecimal(myMasterPage.totalMaster)
                                myMasterPage.totalMaster = valueTotalRenovar + valueCellPrecioCliente

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
        ElseIf tipo = "" Then
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

#End Region

End Class