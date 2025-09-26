Imports Telerik.Web.UI
Imports System.Globalization

Public Class PromocionesDetalle
    Inherits System.Web.UI.Page

#Region "Propiedades Texto del Masterform"
    Private Function GetlblTotalCompraMasterA() As Label
        Dim lblText As Label = Me.Master.FindControl("lblTotalCompraMasterA")
        Return lblText
    End Function
    Private Function GetlblTotalCompraMasterB() As Label
        Dim lblText As Label = Me.Master.FindControl("lblTotalCompraMasterB")
        Return lblText
    End Function
    Private Function GetlblCantidadProductoMaster() As Label
        Dim lblText As Label = Me.Master.FindControl("lblCantidadProductoMaster")
        Return lblText
    End Function
    Private Function GetlblpreciounitarioMaster() As Label
        Dim lblText As Label = Me.Master.FindControl("lblpreciounitarioMaster")
        Return lblText
    End Function
    Private Function GetlblvalorpromocionMaster() As Label
        Dim lblText As Label = Me.Master.FindControl("lblvalorpromocionMaster")
        Return lblText
    End Function
    Private Function GetlblsubtotalMaster() As Label
        Dim lblText As Label = Me.Master.FindControl("lblsubtotalMaster")
        Return lblText
    End Function
    Private Function GetlblivaMaster() As Label
        Dim lblText As Label = Me.Master.FindControl("lblivaMaster")
        Return lblText
    End Function
    Private Function GetlbltotalMaster() As Label
        Dim lblText As Label = Me.Master.FindControl("lbltotalMaster")
        Return lblText
    End Function
    Private Function GetlbltotalCarrito() As Label
        Dim lblText As Label = Me.Master.FindControl("lblcantidadcarrito")
        Return lblText
    End Function
#End Region

#Region "Declaracion de Variables"
    Dim valueCellPrecioVenta, valueCellPromocionValor, valueCellDescuentoValor, _
        valueCellPrecioTotal, valueCellIvaValor, valueCellPrecioCliente As Decimal
    Dim valueTotalPrecioVenta, valueTotalPromocionValor, valueTotalPrecioTotal, _
        valueTotalIvaValor, valueTotalPrecioCliente As Decimal
    Dim valueTotalContador As Integer = 0
    Dim valueTotalRenovar As Integer
    Dim valueCellPromocionCodigo As String
    Dim zerovalue As String = "0.00"
    Dim zerovalueconsigno As String = "$0.00"
#End Region

#Region "Eventos de la pagina"

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 26/09/2014
    ''' Descr: Evento load de la pagina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Session("user") = "1801618776"
                ''Session("id_vehiculo") = "1001058799"
                'Session("display_name") = "Cliente Automatico"
                CargaPantalla()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 26/09/2014
    ''' Descr: Regresa a la pagina inicial
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbldetallecatalogo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbldetallecatalogo.Click
        Try
            Page.Response.Redirect("./Promociones.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 26/09/2014
    ''' Descr: Regresa a la pagina anterior
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btndetalleanterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetalleanterior.Click
        Try
            Dim promocion As String = Session("promocion")
            Dim promocionesLista() As String = Session("Promociones_lista").ToString.Split(",")
            Dim indice As String = 0
            Dim total As Integer = promocionesLista.Count - 1
            For i As Integer = 0 To total
                If promocionesLista(i) = promocion Then
                    indice = i
                    Exit For
                End If
            Next
            If indice = 0 Then
                indice = total
            Else
                indice = indice - 1
            End If
            Session("promocion") = promocionesLista(indice)
            CargaPantalla()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 26/09/2014
    ''' Descr: Avanza a la siguiente pagina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btndetallesiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetallesiguiente.Click
        Try
            Dim promocion As String = Session("promocion")
            Dim promocionesLista() As String = Session("Promociones_lista").ToString.Split(",")
            Dim indice As String = 0
            Dim total As Integer = promocionesLista.Count - 1
            For i As Integer = 0 To total
                If promocionesLista(i) = promocion Then
                    indice = i
                    Exit For
                End If
            Next
            If indice = total Then
                indice = 0
            Else
                indice = indice + 1
            End If
            Session("promocion") = promocionesLista(indice)
            CargaPantalla()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 29/09/2014
    ''' Descr: Evento click del boton comprar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDetalleComprar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetalleComprar.Click
        Try
            Dim promociones() As String = Session("promocion").ToString.Split("/")
            Dim ds As New System.Data.DataSet
            ds = PromocionesAdapter.ConsultaDatos(4, Session("user"), promociones(0), 0, promociones(2))
            If Not ValidaDatosCompra(ds.Tables(0).Rows.Count) Then
                Exit Sub
            End If
            If ds.Tables(0).Rows.Count = 1 Then
                Dim vehiculos As String = ds.Tables(0).Rows(0).Item("CODIGO_VEHICULO")
                Session("vehiculos_promociones") = vehiculos
                Session("promocion") = String.Format("{0}/{1}", Session("promocion"), vehiculos)
                If Not ValidaDatosCompra(Session("promocion").ToString) Then
                    Exit Sub
                End If
                If Not Session("promociones_seleccion").ToString.Contains(Session("promocion").ToString) Then
                    Session("promociones_seleccion") = IIf(Session("promociones_seleccion").ToString = "", "", Session("promociones_seleccion").ToString _
                                                           & "*") & Session("promocion").ToString
                End If
                Page.Response.Redirect("./renovacion.aspx?oid=prm", False)
            ElseIf ds.Tables(0).Rows.Count > 1 Then
                Dim script As String = "function f(){$find(""" + modalPopupSeleccion.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                Me.grdmodalautos.DataSource = ds
                Me.grdmodalautos.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 29/09/2014
    ''' Descr: Evento click del boton para continuar con el pago
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnmodalacepta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmodalacepta.Click
        Try
            Dim total As Integer = 0
            Dim vehiculos As String = ""
            For Each item As GridDataItem In Me.grdmodalautos.MasterTableView.Items
                Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                Dim vehiculo As String = item("CODIGO_VEHICULO").Text
                If chkI.Checked Then
                    vehiculos &= vehiculo & ","
                    total += 1
                End If
            Next
            vehiculos = vehiculos.Substring(0, vehiculos.Length - IIf(vehiculos.Contains(","), 1, 0))
            If total < CInt(txtdetallecantidad.Text) Then
                EnviaMensaje(String.Format("Aún tiene cantidades disponibles ({0})", CInt(txtdetallecantidad.Text) - total), 4)
            ElseIf total > CInt(txtdetallecantidad.Text) Then
                EnviaMensaje(String.Format("No tiene tantas cantidades disponibles"), 4)
            ElseIf total = CInt(txtdetallecantidad.Text) Then
                Session("vehiculos_promociones") = vehiculos
                Session("promocion") = String.Format("{0}/{1}", Session("promocion"), vehiculos)
                If Not ValidaPromociones(Session("promocion").ToString) Then
                    Exit Sub
                End If
                If Not Session("promociones_seleccion").ToString.Contains(Session("promocion").ToString) Then
                    Session("promociones_seleccion") = IIf(Session("promociones_seleccion").ToString = "", "", Session("promociones_seleccion").ToString _
                                                           & "*") & Session("promocion").ToString
                End If
                Page.Response.Redirect("./renovacion.aspx?oid=prm", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 29/09/2014
    ''' Descr: Graba el carro de compra del cliente
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RegistroCarroCompra(ByVal vehiculos As String)
        Try
            Dim vehiculosLista() As String = vehiculos.ToString.Split(",")
            Dim promociones() As String = Session("promocion").ToString.Split("/")
            Dim dTCstGeneral As New System.Data.DataSet
            For i As Integer = 0 To vehiculosLista.Count - 1
                dTCstGeneral = RenovacionAdapter.ConsultaPrecioProducto(vehiculosLista(i), promociones(2), 1, promociones(0), "NO", "")
                If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                    valueCellPrecioVenta = dTCstGeneral.Tables(0).Rows(0)("PRECIO_VENTA")
                    valueCellPromocionCodigo = dTCstGeneral.Tables(0).Rows(0)("CODIGO_PROMOCION")
                    valueCellPromocionValor = dTCstGeneral.Tables(0).Rows(0)("VALOR_PROMOCION")
                    valueCellDescuentoValor = dTCstGeneral.Tables(0).Rows(0)("VALOR_DESCUENTO")
                    valueCellPrecioTotal = dTCstGeneral.Tables(0).Rows(0)("PRECIO_TOTAL")
                    valueCellIvaValor = dTCstGeneral.Tables(0).Rows(0)("IVA")
                    valueCellPrecioCliente = dTCstGeneral.Tables(0).Rows(0)("PRECIO_CLIENTE")
                    valueTotalContador = valueTotalContador + 1
                    valueTotalPrecioVenta = valueTotalPrecioVenta + valueCellPrecioVenta
                    valueTotalPromocionValor = valueTotalPromocionValor + valueCellPromocionValor
                    valueTotalPrecioTotal = valueTotalPrecioTotal + valueCellPrecioTotal
                    valueTotalIvaValor = valueTotalIvaValor + valueCellIvaValor
                    valueTotalPrecioCliente = valueTotalPrecioCliente + valueCellPrecioCliente
                    valueTotalRenovar = valueTotalRenovar + 1
                    If (valueCellIvaValor > 0) Then
                        If Session("DTPorcentajeIva") = Nothing Then Session("DTPorcentajeIva") = RenovacionAdapter.ConsultaPorcentajeIva()
                        Dim porcentajeIva As Decimal = Session("DTPorcentajeIva")
                        valueCellIvaValor = Math.Round((valueCellPrecioTotal * porcentajeIva), 2)
                        valueCellPrecioCliente = valueCellPrecioTotal + valueCellIvaValor
                    End If
                Else
                    valueCellPrecioVenta = 0
                    valueCellPromocionCodigo = ""
                    valueCellPromocionValor = 0
                    valueCellDescuentoValor = 0
                    valueCellPrecioTotal = 0
                    valueCellIvaValor = 0
                    valueCellPrecioCliente = 0
                    EMailHandler.EMailProductoError(String.Format("{0} {1} {2} PRODUCTO SIN PRECIO", vehiculosLista(i), promociones(2), 1), Nothing, Session("iphost"), Session("iphost"))
                End If
            Next
            If valueTotalContador > 0 Then
                Dim lblTotal1 As Label = GetlblTotalCompraMasterA()
                Dim lblTotal2 As Label = GetlblTotalCompraMasterB()
                Dim lblcantidad As Label = GetlblCantidadProductoMaster()
                Dim lblprecio As Label = GetlblpreciounitarioMaster()
                Dim lblpromocion As Label = GetlblvalorpromocionMaster()
                Dim lblsubtotal As Label = GetlblsubtotalMaster()
                Dim lbliva As Label = GetlblivaMaster()
                Dim lbltotal As Label = GetlbltotalMaster()
                Dim lblcantcarrito As Label = GetlbltotalCarrito()
                Dim ram As RadAjaxManager = Me.RadAjaxManager1
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblTotal1)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblTotal2)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblcantidad)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblprecio)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblpromocion)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblsubtotal)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lbliva)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lbltotal)
                ram.AjaxSettings.AddAjaxSetting(btnmodalacepta, lblcantcarrito)
                lblTotal1.Text = "Total &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp " + If((valueCellPrecioCliente = 0), zerovalueconsigno, String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", valueTotalPrecioCliente))
                lblTotal2.Text = "Cerrar"
                lblcantidad.Text = valueTotalRenovar.ToString()
                lblprecio.Text = If((valueTotalPrecioVenta = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalPrecioVenta, 2)))
                lblpromocion.Text = If((valueTotalPromocionValor = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalPromocionValor, 2)))
                lblsubtotal.Text = If((valueTotalPrecioTotal = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalPrecioTotal, 2)))
                lbliva.Text = If((valueTotalIvaValor = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalIvaValor, 2)))
                lbltotal.Text = If((valueTotalPrecioCliente = 0), zerovalueconsigno, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", valueTotalPrecioCliente))
                lblcantcarrito.Text = valueTotalRenovar.ToString()
                Session("TotalMaster") = If((valueTotalPrecioCliente = 0), zerovalueconsigno, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", valueTotalPrecioCliente))
                Session("TotalCompraMaster") = "Total &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp " + If((valueTotalPrecioCliente = 0), zerovalueconsigno, String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", valueTotalPrecioCliente))
                Session("SubtotalMaster") = If((valueTotalPrecioTotal = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalPrecioTotal, 2)))
                Session("CantidadMaster") = valueTotalRenovar.ToString()
                Session("IvaMaster") = If((valueTotalIvaValor = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalIvaValor, 2)))
                Session("PrecioUnitarioMaster") = If((valueTotalPrecioVenta = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalPrecioVenta, 2)))
                Session("ValorPromocionMaster") = If((valueTotalPromocionValor = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:N2}", Math.Round(valueTotalPromocionValor, 2)))
                Session("DTCarroCompraCantidadProducto") = valueTotalRenovar
                Session("DTCarroCompraPrecioUnitario") = valueTotalPrecioVenta
                Session("DTCarroCompraValorPromocion") = valueTotalPromocionValor
                Session("DTCarroCompraSubTotal") = valueTotalPrecioTotal
                Session("DTCarroCompraIva") = valueTotalIvaValor
                Session("DTCarroCompraTotal") = valueTotalPrecioCliente
                Session("DTUltimoPedido") = Nothing
                'Session("DTCarroCompraMasterTableView") = Me.productocliente.MasterTableView
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 26/09/2014
    ''' Descr: Setea controles con valores traidos de tabla
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaPantalla()
        Try
            Dim ds As New System.Data.DataSet
            Dim promociones() As String = Session("promocion").ToString.Split("/")
            ds = PromocionesAdapter.ConsultaDatos(3, "", promociones(0), CInt(promociones(1)), "")
            Me.lbldetalletitulo.Text = ds.Tables(0).Rows(0).Item("PRODUCTO")
            Me.lbldetalletituloimagen.Text = ds.Tables(0).Rows(0).Item("PRODUCTO")
            Me.lbldetallevalorWeb.Text = ds.Tables(0).Rows(0).Item("VALOR")
            Me.lbldetallevalorNormal.Text = ds.Tables(0).Rows(0).Item("VALOR_NORMAL")
            'Me.txtdetallefichatecnica.Text = vbCrLf & ds.Tables(0).Rows(0).Item("FICHA_DESCRIPCION")
            Me.imgdetallefichatecnica.ImageUrl = ds.Tables(0).Rows(0).Item("FICHA")
            Me.lbldetallevalidohasta.Text = ds.Tables(0).Rows(0).Item("FECHA_FINAL")
            Me.lbldetalleimagen.Text = ds.Tables(0).Rows(0).Item("CODIGO_PROMOCION")
            Me.txtmodaltitulo.Text = Me.lbldetalletitulo.Text
            Me.txtdetallecantidad.Text = 0
            Dim color1 As String = ds.Tables(0).Rows(0).Item("COLOR_HEXADECIMAL_INICIAL")
            Dim color2 As String = ds.Tables(0).Rows(0).Item("COLOR_HEXADECIMAL_FINAL")
            Me.lbldetalleimagen.ForeColor = System.Drawing.ColorTranslator.FromHtml(color1)
            DirectCast(Me.DetallerImagen, HtmlControl).Attributes("style") = "background: " & color1 & "; " & _
                                "background: -moz-linear-gradient(left,  " & color1 & " 0%, " & color2 & " 100%); " & _
                                "background: -webkit-gradient(linear, left top, right top, color-stop(0%," & color1 & "), color-stop(100%," & color2 & ")); " & _
                                "background: -webkit-linear-gradient(left,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: -o-linear-gradient(left,   " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: -ms-linear-gradient(left,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: linear-gradient(to right,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='" & color1 & "', endColorstr='" & color2 & "',GradientType=1 );"
            valueTotalContador = 0
            valueTotalPrecioVenta = 0
            valueTotalPromocionValor = 0
            valueTotalPrecioTotal = 0
            valueTotalIvaValor = 0
            valueTotalPrecioCliente = 0
            valueTotalRenovar = 0
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 29/09/2014
    ''' Descr: Validacion de controles para proseguir con la compra
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidaDatosCompra(ByVal total As Integer) As Boolean
        ValidaDatosCompra = True
        Try
            If Me.txtdetallecantidad.Text = "" Or Me.txtdetallecantidad.Text = "0" Then
                ValidaDatosCompra = False
                EnviaMensaje("Por favor, ingrese cantidad", 4)
            Else
                If total = 0 Then
                    ValidaDatosCompra = False
                    EnviaMensaje("Ninguno de sus vehículos aplican a esta promoción", 4)
                ElseIf CInt(Me.txtdetallecantidad.Text) > total Then
                    ValidaDatosCompra = False
                    EnviaMensaje("Cantidad ingresada es mayor a la de sus vehículos disponibles para transaccionar", 4)
                End If
            End If
            Return ValidaDatosCompra
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 07/10/2014
    ''' Descr: Validacion de promociones ya seleccionadas para proseguir con la compra
    ''' </summary>
    ''' <param name="promo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidaPromociones(ByVal promo As String) As Boolean
        ValidaPromociones = True
        Try
            If Not Session("promociones_seleccion").ToString = "" Then
                Dim listado() As String = Session("promociones_seleccion").ToString.Split("*")
                For i As Integer = 0 To listado.Count - 1
                    Dim promoA() As String = listado(i).Split("/")
                    Dim promoB() As String = promo.Split("/")
                    If promoA(2) = promoB(2) Then
                        If promoA(4).Contains(promoB(4)) Then
                            ValidaPromociones = False
                            EnviaMensaje("El producto ya tiene otra promoción aplicada", 4)
                        End If
                    End If
                Next
            End If
            Return ValidaPromociones
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 24/09/2014
    ''' DESCR: Envío de mensajes a pantalla
    ''' </summary>
    ''' <param name="custommsg"></param>
    ''' <param name="tipo"></param>
    ''' <remarks></remarks>
    Private Sub EnviaMensaje(ByVal custommsg As String, ByVal tipo As Integer)
        Try
            rntmensaje.Text = custommsg
            rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
            If tipo = 1 Then
                rntmensaje.TitleIcon = "info"
                rntmensaje.ContentIcon = "info"
                rntmensaje.ShowSound = "info"
            ElseIf tipo = 2 Then
                rntmensaje.TitleIcon = "warning"
                rntmensaje.ContentIcon = "warning"
                rntmensaje.ShowSound = "warning"
            ElseIf tipo = 3 Then
                rntmensaje.TitleIcon = "delete"
                rntmensaje.ContentIcon = "delete"
                rntmensaje.ShowSound = "delete"
            ElseIf tipo = 4 Then
                rntmensaje.TitleIcon = "deny"
                rntmensaje.ContentIcon = "deny"
                rntmensaje.ShowSound = "deny"
            End If
            rntmensaje.AutoCloseDelay = "1700"
            rntmensaje.Width = 400
            rntmensaje.Height = 100
            rntmensaje.Show()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class