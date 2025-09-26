Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Net.Mail
Imports System.IO
Imports Novacode
Imports System.Drawing

'renovacion20140217
Public Class renovacion2
    Inherits System.Web.UI.Page

    Dim value_iphost, value_pchost, cadenaitems, identificacion As String
    Dim opcion, value_usuarioid, userid, newrow, newcolumn As Integer
    Dim iva As Decimal = 0.12D
    Dim zerovalue As String = "$0.00"
    Dim zerovalue1 As String = "0.00"
    Dim value_cell_cantidad_renovar As Integer
    Dim value_cell_valor As Decimal
    Dim value_cell_subtotal As Decimal
    Dim value_cell_total As Decimal
    Dim value_cell_iva As Decimal
    Dim value_cell_totalpagar As Decimal

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO LOAD DEL FORMULARIO DE RENOVACION
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                If Session.Item("user") IsNot Nothing Then
                    ConsultaProductoCliente(Session.Item("user"))
                End If
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA LA CONSULTA DE PRODUCTOS A RENOVAR DEL CLIENTE AL INICIAR EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConsultaProductoCliente(ByVal identificacion As String)
        Try

            Dim DTCstGeneral As New System.Data.DataSet

            DTCstGeneral = RenovacionAdapter.ConsultaProductoCliente(identificacion)

            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                Session("DTProductoCliente") = DTCstGeneral
                Me.productocliente.DataSource = DTCstGeneral
                Me.productocliente.DataBind()
            Else
                rntMensajes.Text = "No existen datos de productos de cliente"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO PRERENDER DEL GRID
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rgdproductocliente_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles productocliente.PreRender
        Try

            If Not IsPostBack Then
                For Each item As GridDataItem In Me.productocliente.MasterTableView.Items

                    Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                    Dim cmbaniorenovar As RadComboBox = DirectCast(item.FindControl("cmbaniorenovar"), RadComboBox)

                    'cmbaniorenovar.Items.Add(New RadComboBoxItem("1", 1))
                    'cmbaniorenovar.Items.Add(New RadComboBoxItem("2", 2))
                    'cmbaniorenovar.Items.Add(New RadComboBoxItem("3", 3))
                    'cmbaniorenovar.Items.Add(New RadComboBoxItem("4", 4))
                    'cmbaniorenovar.Items.Add(New RadComboBoxItem("5", 5))
                    'cmbaniorenovar.SelectedValue = 1

                    Dim DTCstGeneral As New System.Data.DataSet

                    DTCstGeneral = RenovacionAdapter.ConsultaListadoAnioRenovacion(item("PRODUCTO").Text)

                    If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                        cmbaniorenovar.DataSource = DTCstGeneral
                        cmbaniorenovar.DataValueField = "ANIO"
                        cmbaniorenovar.DataTextField = "ANIO"
                        cmbaniorenovar.DataBind()
                        cmbaniorenovar.SelectedValue = 1
                    End If

                Next
                cmbaniorenovar_SelectedIndexChanged(Nothing, Nothing)
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CHECKED DEL CHECKBOX POR FILA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub chkI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            CalcularTotales()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO DEL COMBOBOX AÑOS A RENOVAR PARA ACTUALIZAR LOS VALORES DE LA FILA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cmbaniorenovar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For Each item As GridDataItem In Me.productocliente.MasterTableView.Items

                Dim cmbaniorenovar As RadComboBox = DirectCast(item.FindControl("cmbaniorenovar"), RadComboBox)

                If cmbaniorenovar.SelectedValue = 0 Then
                    item("VALOR").Text = zerovalue1
                    item("SUBTOTAL").Text = zerovalue1
                    item("TOTAL").Text = zerovalue1
                Else
                    Dim DTCstGeneral As New System.Data.DataSet

                    DTCstGeneral = RenovacionAdapter.ConsultaPrecioProducto(item("PRODUCTO").Text, cmbaniorenovar.SelectedValue)

                    If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                        value_cell_valor = DTCstGeneral.Tables(0).Rows(0)("PRECIO")
                        value_cell_subtotal = DTCstGeneral.Tables(0).Rows(0)("PRECIO")
                        value_cell_total = DTCstGeneral.Tables(0).Rows(0)("PRECIO")

                        item("VALOR").Text = If(value_cell_valor = 0, zerovalue, value_cell_valor)
                        item("SUBTOTAL").Text = If(value_cell_subtotal = 0, zerovalue, value_cell_subtotal)
                        item("TOTAL").Text = If(value_cell_total = 0, zerovalue, value_cell_total)
                    End If
                End If
            Next
            CalcularTotales()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA CALCULAR LOS TOTALES DE LA RENOVACION
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CalcularTotales()
        Try

            value_cell_total = 0
            value_cell_iva = 0
            value_cell_totalpagar = 0
            value_cell_cantidad_renovar = 0

            For Each item As GridDataItem In Me.productocliente.MasterTableView.Items

                Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)

                If chkI.Checked = True Then
                    value_cell_total = value_cell_total + Convert.ToDecimal(Libreria.Parse(item("TOTAL").Text))
                    value_cell_iva = value_cell_iva + (Convert.ToDecimal(Libreria.Parse(item("TOTAL").Text)) * iva)
                    value_cell_totalpagar = value_cell_total + value_cell_iva
                    value_cell_cantidad_renovar = value_cell_cantidad_renovar + 1
                End If
            Next

            lblCantidadProducto.Text = value_cell_cantidad_renovar.ToString()
            lblsubtotal.Text = If((value_cell_total = 0), zerovalue1, Math.Round(value_cell_total, 2))
            lbliva.Text = If((value_cell_iva = 0), zerovalue1, Math.Round(value_cell_iva, 2))
            lbltotal.Text = If((value_cell_totalpagar = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", value_cell_totalpagar))
            lblTotalCompra1.Text = "Total de su Compra: " + If((value_cell_totalpagar = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", value_cell_totalpagar))
            lblTotalCompra2.Text = "Total de su Compra: " + If((value_cell_totalpagar = 0), zerovalue, String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", value_cell_totalpagar))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON CONTINUAR DE LA FICHA CONFIRMAR DATO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnConfirmarDatoContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmarDatoContinuar.Click
        Try
            If Libreria.Parse(lbltotal.Text) = 0 Then
                rntMensajes.Text = "Debe seleccionar minimo un producto para continuar"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
                Exit Sub
            End If

            RadTabPrincipal.Tabs(0).Enabled = False
            RadTabPrincipal.Tabs(1).Enabled = True
            RadTabPrincipal.Tabs(2).Enabled = False

            RadTabPrincipal.SelectedIndex = 1
            RadMultiPage1.SelectedIndex = 1
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON CONTINUAR DE LA FICHA FORMA PAGO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnFormaPagoContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFormaPagoContinuar.Click
        Try
            If String.IsNullOrEmpty(txtFormaPagoNombre.Text.Trim) Then
                rntMensajes.Text = "Debe ingresar el Nombre del dueño de la Tarjeta de Crédito"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
                txtFormaPagoNombre.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtFormaPagoIdentificacion.Text.Trim) Then
                rntMensajes.Text = "Debe ingresar la Identificación del dueño de la Tarjeta de Crédito"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
                txtFormaPagoIdentificacion.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtFormaPagoDireccion.Text.Trim) Then
                rntMensajes.Text = "Debe ingresar la dirección del dueño de la Tarjeta de Crédito"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
                txtFormaPagoDireccion.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtFormaPagoTelefono.Text.Trim) Then
                rntMensajes.Text = "Debe ingresar el Teléfono del dueño de la Tarjeta de Crédito"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
                txtFormaPagoTelefono.Focus()
                Exit Sub
            End If

            If chkTerminosCondiciones.Checked = False Then
                rntMensajes.Text = "Debe aceptar los términos y condiciones de renovación para continuar"
                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
                chkTerminosCondiciones.Focus()
                Exit Sub
            End If

            RadTabPrincipal.Tabs(0).Enabled = False
            RadTabPrincipal.Tabs(1).Enabled = False
            RadTabPrincipal.Tabs(2).Enabled = True

            CreateDataSetClienteVehiculoRenovacion()
            RadTabPrincipal.SelectedIndex = 2
            RadMultiPage1.SelectedIndex = 2
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON REGRESAR DE LA FICHA FORMA PAGO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnFormaPagoRegresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFormaPagoRegresar.Click
        Try
            RadTabPrincipal.Tabs(0).Enabled = True
            RadTabPrincipal.Tabs(1).Enabled = False
            RadTabPrincipal.Tabs(2).Enabled = False

            RadTabPrincipal.SelectedIndex = 0
            RadMultiPage1.SelectedIndex = 0
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON REGRESAR DE LA FICHA CONFIRMAR PEDIDO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnConfirmarPedidoRegresar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmarPedidoRegresar.Click
        Try
            RadTabPrincipal.Tabs(0).Enabled = False
            RadTabPrincipal.Tabs(1).Enabled = True
            RadTabPrincipal.Tabs(2).Enabled = False

            RadTabPrincipal.SelectedIndex = 1
            RadMultiPage1.SelectedIndex = 1
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON CANCELAR DE LA FICHA CONFIRMAR PEDIDO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnConfirmarPedidoCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmarPedidoCancelar.Click
        RadTabPrincipal.Tabs(0).Enabled = True
        RadTabPrincipal.Tabs(1).Enabled = False
        RadTabPrincipal.Tabs(2).Enabled = False

        RadTabPrincipal.SelectedIndex = 0
        RadMultiPage1.SelectedIndex = 0

        rntMensajes.Text = "Ha cancelado el proceso de compra. Por favor inténtalo nuevamente."
        rntMensajes.Title = "Renovación Cancelada"
        rntMensajes.TitleIcon = "warning"
        rntMensajes.ContentIcon = "warning"
        rntMensajes.ShowSound = "warning"
        rntMensajes.Width = 400
        rntMensajes.Height = 100
        rntMensajes.Show()
        Exit Sub
    End Sub

    ''' <summary>
    ''' FECHA: 17/02/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON IR A PAGAR DE LA FICHA CONFIRMAR PEDIDO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnConfirmarPedidoIrAPagar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConfirmarPedidoIrAPagar.Click
        RadTabPrincipal.Tabs(0).Enabled = False
        RadTabPrincipal.Tabs(1).Enabled = False
        RadTabPrincipal.Tabs(2).Enabled = True

        RadTabPrincipal.SelectedIndex = 2
        RadMultiPage1.SelectedIndex = 2

        rntMensajes.Text = "Su pago de renovación de productos ha sido efectuada exitosamente!"
        rntMensajes.Title = "Mensaje de la Aplicación Extranet"
        rntMensajes.TitleIcon = "warning"
        rntMensajes.ContentIcon = "warning"
        rntMensajes.ShowSound = "warning"
        rntMensajes.Width = 400
        rntMensajes.Height = 100
        rntMensajes.Show()
        Exit Sub
    End Sub

    ''' <summary>
    ''' FECHA: 15/01/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: METODO PARA LA CREACION DEL DATASET DE PRODUCTOS SELECCIONADOS A RENOVAR DEL CLIENTE 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateDataSetClienteVehiculoRenovacion()
        Try
            Dim DTCstGeneral As New System.Data.DataSet
            Dim DTDataTable As New DataTable

            DTDataTable.Columns.Add("CODIGO_VEHICULO", GetType(Decimal))
            DTDataTable.Columns.Add("GRUPO_NOMBRE", GetType(String))
            DTDataTable.Columns.Add("PRODUCTO_NOMBRE", GetType(String))
            DTDataTable.Columns.Add("FECHA_FIN", GetType(DateTime))
            DTDataTable.Columns.Add("VALOR", GetType(Decimal))
            DTDataTable.Columns.Add("SUBTOTAL", GetType(Decimal))
            DTDataTable.Columns.Add("ANIO", GetType(Integer))
            DTDataTable.Columns.Add("TOTAL", GetType(Decimal))


            For Each item As GridDataItem In Me.productocliente.MasterTableView.Items
                Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                Dim cmbaniorenovar As RadComboBox = DirectCast(item.FindControl("cmbaniorenovar"), RadComboBox)

                If chkI.Checked = True Then
                    DTDataTable.Rows.Add(item("CODIGO_VEHICULO").Text,
                                         item("GRUPO_NOMBRE").Text,
                                         item("PRODUCTO_NOMBRE").Text,
                                         item("FECHA_FIN").Text,
                                         Libreria.Parse(item("VALOR").Text),
                                         Libreria.Parse(item("SUBTOTAL").Text),
                                         cmbaniorenovar.SelectedValue,
                                         Libreria.Parse(item("TOTAL").Text))
                End If
            Next

            DTCstGeneral.Tables.Add(DTDataTable)
            Session("DTProductoClienteRenovacion") = DTCstGeneral
            Me.rgdproductoclienterenovacion.DataSource = DTCstGeneral
            Me.rgdproductoclienterenovacion.DataBind()
            Me.lblConfirmarPedidoSubtotal.Text = Me.lblsubtotal.Text
            Me.lblConfirmarPedidoIva.Text = Me.lbliva.Text
            Me.lblConfirmarPedidoCantidadProducto.Text = Me.lblCantidadProducto.Text
            Me.lblConfirmarPedidoTotalPagar.Text = Me.lbltotal.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 15/01/2014
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO SELECTEDINDEXCHANGED DE LA LISTA DE IDENTIFICACIONES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub rblTipoIdentificacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rblTipoIdentificacion.SelectedIndexChanged
        'If rblTipoIdentificacion.SelectedValue = "1" Then txtFormaPagoIdentificacion.MaxLength = 10
        'If rblTipoIdentificacion.SelectedValue = "2" Then txtFormaPagoIdentificacion.MaxLength = 13
        'If rblTipoIdentificacion.SelectedValue = "3" Then txtFormaPagoIdentificacion.MaxLength = 20

        'Dim RegExpTextBoxSetting As New RegExpTextBoxSetting
        'RegExpTextBoxSetting.BehaviorID = "RegExpTextBoxSetting"
        'RegExpTextBoxSetting.ErrorMessage = "Enter more than 6 figures"
        'RegExpTextBoxSetting.Validation.IsRequired = True
        'RegExpTextBoxSetting.ValidationExpression = "[0-9]{10}"
        'RegExpTextBoxSetting.TargetControls.Add(New TargetInput("txtFormaPagoIdentificacion", True))
        'RadInputManager1.InputSettings.Add(New RegExpTextBoxSetting())

    End Sub

End Class