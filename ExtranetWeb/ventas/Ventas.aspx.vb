Imports System.Globalization

Public Class Ventas
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
                    metodos_master("Venta de Productos/Servicios", 8, "Ventas Selección de productos")
                    mensajeria_error("", "")
                    Session("DTPorcentajeIva") = RenovacionAdapter.ConsultaPorcentajeIva()
                    Session("tblventas") = Nothing
                    ConsultaProductoCliente()
                    If Session("Administrador") = "ADM" Then
                        FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), "ADMIN", "RENOVACION DE PRODUCTOS", Session("iphost"))
                    ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
                        FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), Session("usuario"), "RENOVACION DE PRODUCTOS", Session("iphost"))
                    Else
                        FormularioAdapter.RegistroLogFormulario(103, Session.Item("user"), "LOAD", "RENOVACION DE PRODUCTOS", Session("iphost"))
                    End If
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
                Session("tblventas") = Nothing
                CalculaItemsSeleccionados()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btncontinuar_ServerClick(sender As Object, e As System.EventArgs) Handles btncontinuar.ServerClick
        If Not Session("tblventas") Is Nothing Then
            Dim table As New System.Data.DataTable
            table = CType(Session("tblventas"), DataTable)
            If table.Rows.Count > 0 Then
                Response.Redirect("VentasFac.aspx", False)
            Else
                mensajeria_error("error", "por favor seleccione al menos un producto/servicio")
            End If
        Else
            mensajeria_error("error", "por favor seleccione al menos un producto/servicio")
        End If

    End Sub

#End Region

#Region "Procedimientos"

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

    Private Sub ConsultaProductoCliente()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = VentasAdapter.ConsultaProductoCliente(Session.Item("user"), txtfiltrar.Text, 1)
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                'Session("DTProductoCliente") = dTCstGeneral
                Me.Rpt_venta.DataSource = dTCstGeneral.Tables(0)
                Me.Rpt_venta.DataBind()
                For Each item As RepeaterItem In Rpt_venta.Items
                    Dim rptitm As Repeater = CType(item.FindControl("Rpt_venta_items"), Repeater)
                    Dim lblgrupo As Label = CType(item.FindControl("lblgrupoitem0"), Label)
                    Dim vehiculo_itm As String = lblgrupo.Text

                    Dim dTCstGeneralitm As New System.Data.DataSet
                    dTCstGeneralitm = VentasAdapter.ConsultaProductoCliente(Session.Item("user"), vehiculo_itm, 8)
                    If dTCstGeneralitm.Tables(0).Rows.Count > 0 Then
                        rptitm.DataSource = dTCstGeneralitm
                        rptitm.DataBind()
                    Else
                        rptitm.DataSource = Nothing
                        rptitm.DataBind()
                    End If
                Next
            Else
                mensajeria_error("error", "usted no registra servicios/productos para venta, comuníquese con su ejecutiva.")
                'Session("DTProductoCliente") = Nothing
                Me.Rpt_venta.DataSource = Nothing
                Me.Rpt_venta.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
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
            'Dim dTCstGeneral As New System.Data.DataSet
            'dTCstGeneral = Session("DTProductoCliente")

            Dim table As New System.Data.DataTable
            Dim row As DataRow
            table = TablaVentas()
            For Each item As RepeaterItem In Rpt_venta.Items
                Dim rptitm As Repeater = CType(item.FindControl("Rpt_venta_items"), Repeater)
                Dim lblvehiculo As Label = CType(item.FindControl("lblgrupoitem0"), Label)
                Dim lblvehiculonombre As Label = CType(item.FindControl("lblnombreitem0"), Label)
                Dim vehiculo As String = lblvehiculo.Text

                For Each sub_item As RepeaterItem In rptitm.Items
                    Dim chkI As CheckBox = CType(sub_item.FindControl("chkitem00"), CheckBox)
                    Dim lblvalor As Label = CType(sub_item.FindControl("lbltotalitem0"), Label)
                    Dim lblgrupo As Label = CType(sub_item.FindControl("lblproductocodigo0"), Label)
                    Dim lblpromo As Label = CType(sub_item.FindControl("lblpromo0"), Label)
                    Dim lblgruponombre As Label = CType(sub_item.FindControl("lblproductoitem0"), Label)
                    If chkI.Checked Then
                        Dim dTCstPrecio As New System.Data.DataSet
                        dTCstPrecio = VentasAdapter.ConsultaProductoCliente(Session.Item("user"), lblgrupo.Text, 3)
                        If dTCstPrecio.Tables(0).Rows.Count > 0 Then
                            valuecontador += 1
                            valueCellPrecioVenta = dTCstPrecio.Tables(0).Rows(0)("PRECIO_VENTA")
                            valueCellPromocionCodigo = dTCstPrecio.Tables(0).Rows(0)("CODIGO_PROMOCION")
                            valueCellPromocionValor = dTCstPrecio.Tables(0).Rows(0)("VALOR_PROMOCION")
                            valueCellPrecioTotal = dTCstPrecio.Tables(0).Rows(0)("PRECIO_TOTAL")
                            valueCellIvaValor = dTCstPrecio.Tables(0).Rows(0)("IVA")
                            valueCellPrecioCliente = dTCstPrecio.Tables(0).Rows(0)("PRECIO_CLIENTE")
                            valueCellPromocionCodigo = dTCstPrecio.Tables(0).Rows(0)("CODIGO_PROMOCION")
                            valueCellDescuentoValor = dTCstPrecio.Tables(0).Rows(0)("VALOR_DESCUENTO")
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

                            row = Table.NewRow()
                            row("INDICE") = valuecontador
                            row("VEHICULO") = vehiculo
                            row("PRODUCTO") = lblgrupo.Text
                            row("PRECIO_VENTA") = valueCellPrecioVenta
                            row("CODIGO_PROMOCION") = valueCellPromocionCodigo
                            row("VALOR_PROMOCION") = valueCellPromocionValor
                            row("VALOR_DESCUENTO") = valueCellDescuentoValor
                            row("PRECIO_TOTAL") = valueCellPrecioTotal
                            row("IVA") = valueCellIvaValor
                            row("PRECIO_CLIENTE") = valueCellPrecioCliente
                            row("VEHICULO_NOMBRE") = lblvehiculonombre.Text
                            row("GRUPO_DESCRIPCION") = lblgruponombre.Text
                            row("ANIO") = 1
                            row("FECHAFIN") = Date.Now.ToShortDateString
                            row("PRODUCTOSERVICIO") = dTCstPrecio.Tables(0).Rows(0)("PRODUCTO_SERVICIO")
                            Table.Rows.Add(row)
                        End If
                        Else
                            lblvalor.Text = "0.00"
                            lblpromo.Text = ""
                    End If
                Next
            Next
            Session("tblventas") = table
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function TablaVentas() As DataTable
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
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "PRODUCTOSERVICIO"
        column.AutoIncrement = False
        column.Caption = "PRODUCTOSERVICIO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        Return table
    End Function

#End Region

    Private Sub btncrearvehiculo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncrearvehiculo.ServerClick
        Response.Redirect("CreacionNuevoVehiculo.aspx", False)
    End Sub

End Class