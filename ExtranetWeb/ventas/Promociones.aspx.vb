Imports Telerik.Web.UI
Imports System.Globalization

Public Class Promociones
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 24/09/2014
    ''' Descr: Evento de carga de la pagina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Session("user") = "0917429565"
                'Session("display_name") = "Cliente Automatico"
                If Request.QueryString("promo") <> Nothing Then
                    If String.Compare(Request.QueryString("promo"), "ok", False) = 0 Then
                        EnviaMensaje("Promoción aplicada con éxito", 1)
                    End If
                End If
                If Not Session("user") Is Nothing Then
                    If Session("promociones_seleccion") Is Nothing Then
                        Session("promociones_seleccion") = ""
                    End If
                    CargaDatos()
                Else
                    EnviaMensaje("Variable de sesión de usuario es [nulo] - redirección a login", 4)
                    Err.Raise(5000, "Load", "No se puede cargar pantalla", "HelpFile.hlp", 0)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 25/09/2014
    ''' DESCR: Setea al control repProductos el codigo de promocion asociado al boton y link
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Promociones_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            Session("promocion") = ""
            Dim promocion As String = e.CommandArgument.ToString()
            Select Case e.CommandName
                Case "Label"
                    If Session("Promociones_lista_N").ToString.Length > 0 Then
                        Session("Promociones_lista") = Session("Promociones_lista_N")
                        Session("promocion") = promocion
                        Page.Response.Redirect("./PromocionesDetalle.aspx", False)
                    End If
                    Exit Select
                Case "Boton"
                    Dim promociones() As String = promocion.Split("/")
                    Dim ds As New System.Data.DataSet
                    ds = PromocionesAdapter.ConsultaDatos(4, Session("user"), promociones(0), promociones(1), promociones(2))
                    If Not ValidaDatosCompra(ds.Tables(0).Rows.Count) Then
                        Exit Sub
                    End If
                    Dim vehiculos As String = ds.Tables(0).Rows(0).Item("CODIGO_VEHICULO")
                    Session("vehiculos_promociones") = vehiculos
                    Session("promocion") = String.Format("{0}/{1}", promocion, vehiculos)
                    If ds.Tables(0).Rows.Count = 1 Then
                        If Not ValidaPromociones(Session("promocion")) Then
                            Exit Sub
                        End If
                        If Not Session("promociones_seleccion").ToString.Contains(Session("promocion").ToString) Then
                            Session("promociones_seleccion") = IIf(String.Compare(Session("promociones_seleccion").ToString, "", False) = 0, _
                                                                   "", Session("promociones_seleccion").ToString & "*") & Session("promocion").ToString
                        End If
                        'ConfigConfir("Está seguro de aplicar promoción?")
                        Page.Response.Redirect("./renovacion.aspx?oid=prm&goback=si", False)
                    ElseIf ds.Tables(0).Rows.Count > 1 Then
                        Session("promocion") = String.Format("{0}/{1}", promocion, "")
                        Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", modalPopupSeleccion.ClientID)
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                        Me.grdmodalautos.DataSource = ds
                        Me.grdmodalautos.DataBind()
                    End If
                    Exit Select
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 25/09/2014
    ''' DESCR: Obtiene del control repVendidos la promocion 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Vendidos_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            Session("promocion") = ""
            Dim promocion As String = e.CommandArgument.ToString()
            Select Case e.CommandName
                Case "Label"
                    If Session("Promociones_lista_V").ToString.Length > 0 Then
                        Session("Promociones_lista") = Session("Promociones_lista_V")
                        Session("promocion") = promocion
                        Page.Response.Redirect("./PromocionesDetalle.aspx", False)
                    End If
                    Exit Select
                Case "Boton"
                    Dim promociones() As String = promocion.Split("/")
                    Dim ds As New System.Data.DataSet
                    ds = PromocionesAdapter.ConsultaDatos(4, Session("user"), promociones(0), promociones(1), promociones(2))
                    If Not ValidaDatosCompra(ds.Tables(0).Rows.Count) Then
                        Exit Sub
                    End If
                    Dim vehiculos As String = ds.Tables(0).Rows(0).Item("CODIGO_VEHICULO")
                    Session("vehiculos_promociones") = vehiculos
                    Session("promocion") = String.Format("{0}/{1}", promocion, vehiculos)
                    If ds.Tables(0).Rows.Count = 1 Then
                        If Not ValidaPromociones(Session("promocion")) Then
                            Exit Sub
                        End If
                        If Not Session("promociones_seleccion").ToString.Contains(Session("promocion").ToString) Then
                            Session("promociones_seleccion") = IIf(String.Compare(Session("promociones_seleccion").ToString, "", False) = 0, "", Session("promociones_seleccion").ToString _
                                                                   & "*") & Session("promocion").ToString
                        End If
                        'ConfigConfir("Está seguro de aplicar promoción?")
                        Page.Response.Redirect("./renovacion.aspx?oid=prm&goback=si", False)
                    ElseIf ds.Tables(0).Rows.Count > 1 Then
                        Session("promocion") = String.Format("{0}/{1}", promocion, "")
                        Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", modalPopupSeleccion.ClientID)
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                        Me.grdmodalautos.DataSource = ds
                        Me.grdmodalautos.DataBind()
                    End If
                    Exit Select
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 25/09/2014
    ''' DESCR: Setea al control repProductos el codigo de promocion asociado al boton y link
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub RepProductos_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim label As LinkButton = TryCast(e.Item.FindControl("lblboxProductosdetallevermas"), LinkButton)
            Dim boton As Button = TryCast(e.Item.FindControl("btnboxProductosDetalleComprar"), Button)
            label.OnClientClick = [String].Format("showValue('{0}');", label.CommandArgument)
            boton.OnClientClick = [String].Format("showValue('{0}');", boton.CommandArgument)
        End If
    End Sub


    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 25/09/2014
    ''' DESCR: Setea al control repVendidos el codigo de promocion asociado al boton y link
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub RepVendidos_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim label As LinkButton = TryCast(e.Item.FindControl("lblboxVendidosdetallevermas"), LinkButton)
            Dim boton As Button = TryCast(e.Item.FindControl("btnboxVendidosDetalleComprar"), Button)
            label.OnClientClick = [String].Format("showValue('{0}');", label.CommandArgument)
            boton.OnClientClick = [String].Format("showValue('{0}');", boton.CommandArgument)
        End If
    End Sub


    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 02/10/2014
    ''' Descr: Evento click del boton para continuar con el pago
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btnmodalacepta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnmodalacepta.Click
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
            If total < 1 Then
                EnviaMensaje("Por favor selecciones un vehículo", 4)
            ElseIf total > 1 Then
                EnviaMensaje("Sólo puede seleccionar 1 vehículo", 4)
            ElseIf total = 1 Then
                Session("vehiculos_promociones") = vehiculos
                Session("promocion") = Session("promocion") & vehiculos
                If Not ValidaPromociones(Session("promocion")) Then
                    Exit Sub
                End If
                If Not Session("promociones_seleccion").ToString.Contains(Session("promocion").ToString) Then
                    Session("promociones_seleccion") = IIf(String.Compare(Session("promociones_seleccion").ToString, "", False) = 0, _
                                                           "", Session("promociones_seleccion").ToString & "*") & Session("promocion")
                End If
                'ConfigConfir("Está seguro de aplicar promoción?")
                Page.Response.Redirect("./renovacion.aspx?oid=prm&goback=si", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"


    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 25/09/2014
    ''' Descr: Llama a todas las cargas de datos iniciales
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaDatos()
        Try
            Carga_Promociones()
            Carga_Promocionesmasvendidas()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 24/09/2014
    ''' DESCR: Carga web-control de promociones
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Carga_Promociones()
        Try
            Session("Promociones_lista") = ""
            Dim ds As New System.Data.DataSet
            ds = PromocionesAdapter.ConsultaDatos(1, Session("user").ToString, "", 0, "")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.rtrpromociones.DataSource = ds
                Me.rtrpromociones.DataBind()
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DirectCast(rtrpromociones.Items(i).FindControl("lblboxProductostitulo"), Label).Text = ds.Tables(0).Rows(i).Item("PRODUCTO")
                    DirectCast(rtrpromociones.Items(i).FindControl("lblboxProductosdetallevalorWeb"), Label).Text = ds.Tables(0).Rows(i).Item("VALOR")
                    DirectCast(rtrpromociones.Items(i).FindControl("lblboxProductosdetallevalorNormal"), Label).Text = ds.Tables(0).Rows(i).Item("VALOR_NORMAL")
                    DirectCast(rtrpromociones.Items(i).FindControl("lbldetalleproductosvalidohasta"), Label).Text = ds.Tables(0).Rows(i).Item("FECHA_FINAL")
                    'DirectCast(rtrpromociones.Items(i).FindControl("lblboxproductosimagen"), Label).Text = ds.Tables(0).Rows(i).Item("CODIGO_PROMOCION")
                    'DirectCast(rtrpromociones.Items(i).FindControl("BoxProductosImagen"), HtmlControl).Attributes("style") = "background-image: url('" & ds.Tables(0).Rows(i).Item("RUTA_IMAGEN") & "');"
                    Dim color1 As String = ds.Tables(0).Rows(i).Item("COLOR_HEXADECIMAL_INICIAL")
                    Dim color2 As String = ds.Tables(0).Rows(i).Item("COLOR_HEXADECIMAL_FINAL")
                    DirectCast(rtrpromociones.Items(i).FindControl("lblboxproductosimagen"), Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(color1)
                    DirectCast(rtrpromociones.Items(i).FindControl("BoxProductosImagen"), HtmlControl).Attributes("style") = "background: " & color1 & "; " & _
                                "background: -moz-linear-gradient(left,  " & color1 & " 0%, " & color2 & " 100%); " & _
                                "background: -webkit-gradient(linear, left top, right top, color-stop(0%," & color1 & "), color-stop(100%," & color2 & ")); " & _
                                "background: -webkit-linear-gradient(left,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: -o-linear-gradient(left,   " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: -ms-linear-gradient(left,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: linear-gradient(to right,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='" & color1 & "', endColorstr='" & color2 & "',GradientType=1 );"
                    Session("Promociones_lista_N") = Session("Promociones_lista_N") & ds.Tables(0).Rows(i).Item("CODIGO_PROMOCION") & _
                                                     "/" & ds.Tables(0).Rows(i).Item("CODIGO_ITEM") & _
                                                     "/" & ds.Tables(0).Rows(i).Item("GRUPO") & _
                                                     "/" & ds.Tables(0).Rows(i).Item("PRODUCTO") & _
                                                    IIf(i < ds.Tables(0).Rows.Count - 1, ",", "")
                    'botones_compras_adquiridas(ds, i, "promociones")
                Next
            Else
                EnviaMensaje("No existen datos de promociones", 2)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Felix Ontaneda C.
    ''' FECHA: 25/09/2014
    ''' DESCR: Carga web-control de promociones mas vendidas
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Carga_Promocionesmasvendidas()
        Try
            Dim ds As New System.Data.DataSet
            ds = PromocionesAdapter.ConsultaDatos(2, 0, "", 0, "")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.rtrvendidos.DataSource = ds
                Me.rtrvendidos.DataBind()
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DirectCast(rtrvendidos.Items(i).FindControl("lblboxVendidostitulo"), Label).Text = ds.Tables(0).Rows(i).Item("PRODUCTO")
                    DirectCast(rtrvendidos.Items(i).FindControl("lblboxVendidosdetallevalorWeb"), Label).Text = ds.Tables(0).Rows(i).Item("VALOR")
                    DirectCast(rtrvendidos.Items(i).FindControl("lblboxVendidosdetallevalorNormal"), Label).Text = ds.Tables(0).Rows(i).Item("VALOR_NORMAL")
                    DirectCast(rtrvendidos.Items(i).FindControl("lbldetallevendidosvalidohasta"), Label).Text = ds.Tables(0).Rows(i).Item("FECHA_FINAL")
                    'DirectCast(rtrvendidos.Items(i).FindControl("lblboxVendidosimagen"), Label).Text = ds.Tables(0).Rows(i).Item("CODIGO_PROMOCION")
                    'DirectCast(rtrvendidos.Items(i).FindControl("BoxVendidosImagen"), HtmlControl).Attributes("style") = "background-image: url('" & ds.Tables(0).Rows(i).Item("RUTA_IMAGEN") & "');"
                    Dim color1 As String = ds.Tables(0).Rows(i).Item("COLOR_HEXADECIMAL_INICIAL")
                    Dim color2 As String = ds.Tables(0).Rows(i).Item("COLOR_HEXADECIMAL_FINAL")
                    DirectCast(rtrvendidos.Items(i).FindControl("lblboxvendidosimagen"), Label).ForeColor = System.Drawing.ColorTranslator.FromHtml(color1)
                    DirectCast(rtrvendidos.Items(i).FindControl("BoxVendidosImagen"), HtmlControl).Attributes("style") = "background: " & color1 & "; " & _
                                "background: -moz-linear-gradient(left,  " & color1 & " 0%, " & color2 & " 100%); " & _
                                "background: -webkit-gradient(linear, left top, right top, color-stop(0%," & color1 & "), color-stop(100%," & color2 & ")); " & _
                                "background: -webkit-linear-gradient(left,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: -o-linear-gradient(left,   " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: -ms-linear-gradient(left,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "background: linear-gradient(to right,  " & color1 & " 0%," & color2 & " 100%); " & _
                                "filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='" & color1 & "', endColorstr='" & color2 & "',GradientType=1 );"
                    Session("Promociones_lista_V") = Session("Promociones_lista_V") & ds.Tables(0).Rows(i).Item("CODIGO_PROMOCION") & _
                                                    "/" & ds.Tables(0).Rows(i).Item("CODIGO_ITEM") & _
                                                    "/" & ds.Tables(0).Rows(i).Item("GRUPO") & _
                                                    "/" & ds.Tables(0).Rows(i).Item("PRODUCTO") & _
                                                    IIf(i < ds.Tables(0).Rows.Count - 1, ",", "")
                    'botones_compras_adquiridas(ds, i, "vendidos")
                Next
            Else
                EnviaMensaje("No existen datos de promociones", 2)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


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


    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 29/09/2014
    ''' Descr: Validacion de controles para proseguir con la compra
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidaDatosCompra(ByVal total As Integer) As Boolean
        ValidaDatosCompra = True
        Try
            If total = 0 Then
                ValidaDatosCompra = False
                EnviaMensaje("Ninguno de sus vehículos aplican a esta promoción", 4)
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
            If Session("promociones_seleccion") Is Nothing Then
                ValidaPromociones = False
                EnviaMensaje("No se reconocen datos", 4)
            ElseIf Not String.Compare(Session("promociones_seleccion").ToString, "", False) = 0 Then
                Dim listado() As String = Session("promociones_seleccion").ToString.Split("*")
                For i As Integer = 0 To listado.Count - 1
                    Dim promoA() As String = listado(i).Split("/")
                    Dim promoB() As String = promo.Split("/")
                    If String.Compare(promoA(2), promoB(2), False) = 0 Then
                        If promoA(4).Contains(promoB(4)) Then
                            ValidaPromociones = False
                            EnviaMensaje("El producto ya tiene otra promoción aplicada", 4)
                        End If
                    End If
                Next
            End If
            Return ValidaPromociones
        Catch ex As Exception
            EnviaMensaje("Por favor recargue el sitio", 4)
            ValidaPromociones = False
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function


    ''' <summary>
    ''' Autor: Felix Ontaneda C.
    ''' Fecha: 23/10/2014
    ''' Descr: Inactiva el boton de la compra adquirida
    ''' </summary>
    ''' <param name="dataset"></param>
    ''' <param name="indice"></param>
    ''' <param name="tipo"></param>
    ''' <remarks></remarks>
    Private Sub BotonesComprasAdquiridas(ByVal dataset As DataSet, ByVal indice As Integer, ByVal tipo As String)
        Try
            If Not String.Compare(Session("promociones_seleccion").ToString, "", False) = 0 Then
                Dim listado() As String = Session("promociones_seleccion").ToString.Split("*")
                For j As Integer = 0 To listado.Count - 1
                    Dim promocion() As String = listado(j).Split("/")
                    If promocion(0) = dataset.Tables(0).Rows(indice).Item("CODIGO_PROMOCION") Then
                        If promocion(1) = dataset.Tables(0).Rows(indice).Item("CODIGO_ITEM") Then
                            If promocion(2) = dataset.Tables(0).Rows(indice).Item("GRUPO") Then
                                If String.Compare(tipo, "promociones", False) = 0 Then
                                    Me.rtrpromociones.InitialItemIndex = indice
                                    DirectCast(rtrpromociones.Items(indice).FindControl("BoxProductosDetalleComprar"), HtmlControl).Attributes("class") = "PromocionesProductosBoxDetallecomprarobtenido"
                                    DirectCast(rtrpromociones.Items(indice).FindControl("btnboxProductosDetalleComprar"), Button).ForeColor = Drawing.Color.Black
                                    DirectCast(rtrpromociones.Items(indice).FindControl("btnboxProductosDetalleComprar"), Button).Enabled = False
                                    DirectCast(rtrpromociones.Items(indice).FindControl("lblboxProductosdetallevermas"), LinkButton).Enabled = False
                                ElseIf String.Compare(tipo, "vendidos", False) = 0 Then
                                    Me.rtrvendidos.InitialItemIndex = indice
                                    DirectCast(rtrvendidos.Items(indice).FindControl("BoxVendidosDetalleComprar"), HtmlControl).Attributes("class") = "PromocionesProductosBoxDetallecomprarobtenido"
                                    DirectCast(rtrvendidos.Items(indice).FindControl("btnboxVendidosDetalleComprar"), Button).ForeColor = Drawing.Color.Black
                                    DirectCast(rtrvendidos.Items(indice).FindControl("btnboxVendidosDetalleComprar"), Button).Enabled = False
                                    DirectCast(rtrvendidos.Items(indice).FindControl("lblboxVendidosdetallevermas"), LinkButton).Enabled = False
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class