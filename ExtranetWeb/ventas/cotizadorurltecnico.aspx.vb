Imports PlugInClient
Imports System.Globalization

Public Class cotizadorurltecnico
    Inherits System.Web.UI.Page

    Dim opcion, value_usuarioid As Integer

    Dim DTSetInfoPagoOnline As New DataTable
    Dim DTGetInfoURLTecnico As New DataTable()

    Dim value_prev_idcotizacion As Integer
    Dim value_prev_identificacion As String
    Dim value_prev_nombre As String
    Dim value_prev_telf01 As String

    Dim value_prev_total As Decimal
    Dim value_prev_subtotal As Decimal
    Dim value_prev_descuento As Decimal
    Dim value_prev_promocion As Decimal
    Dim value_prev_iva As Decimal

    Dim value_prev_email As String

    Dim tipotarjeta As String = "DN"
    Dim tipocredito As String = "00"

    Dim DtSecOrdenPago As DataSet

    Dim result_inginicial As Integer
    Dim estadoorden As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If Not IsPostBack Then

                DataTarjetasCredito()
                CargaValoresFinales()
                SecuenciaOrdenPago()

            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

    Private Sub SecuenciaOrdenPago()

        'Try

        '    opcion = 4
        '    DtSecOrdenPago = OrdenPagoAdapter.ConsultaSecuenciaOrdenPago(opcion)

        '    If DtSecOrdenPago.Tables(0).Rows.Count > 0 Then

        '        Me.lblordenpago.Text = DtSecOrdenPago.Tables(0).Rows(0)("SECUENCIA_ORDEN_PAGO")

        '    Else

        '        Me.lblordenpago.Text = 0

        '    End If


        'Catch ex As Exception
        '    Captura_Error(ex)
        'End Try

    End Sub

    Private Sub IngresaOrdenPagoPreliminar()

        'Try

        '    opcion = 2
        '    estadoorden = 1
        '    result_inginicial = OrdenPagoAdapter.RegistroPagoOnline(opcion, lblordenpago.Text, lblcotizacion_idcliente.Text, 1, Me.cbxtarjeta.SelectedValue, lblpago_subtotal.Text, lblpago_iva.Text, 0, 0, lblpago_total.Text, 0, tipocredito, 0, lblcotizacion_descliente.Text, _
        '                                                           lblcotizacion_idcliente.Text, txtcotizacion_direccion.Text, lblcotizacion_telf.Text, 0, estadoorden, lblcotizacion_idcliente.Text, lblcotizacion_id.Text)

        '    If result_inginicial = 0 Then
        '        email.MsgEmail("Registro de orden de pago inicial exitoso", Nothing, Session("iphost"), Session("iphost"))
        '    End If

        'Catch ex As Exception
        '    Captura_Error(ex)
        'End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataTarjetasCredito()

        Try

            Dim DTTarjCred As New DataTable()
            DTTarjCred.Columns.Add("Text", GetType(String))
            DTTarjCred.Columns.Add("Value", GetType(String))
            DTTarjCred.Columns.Add("ImageUrl", GetType(String))

            DTTarjCred.Rows.Add("Visa", "VI", "~/images/icons/64X64/visa.png")
            DTTarjCred.Rows.Add("MasterCard", "MA", "~/images/icons/64X64/mastercard.png")
            DTTarjCred.Rows.Add("Diners Club", "DN", "~/images/icons/64X64/dinersclub.png")
            DTTarjCred.Rows.Add("Discover", "DI", "~/images/icons/64X64/discover.png")

            Session("DTTarjCred") = DTTarjCred

            Me.cbxtarjeta.DataSource = Session("DTTarjCred")
            cbxtarjeta.DataTextField = "Text"
            cbxtarjeta.DataValueField = "Value"
            cbxtarjeta.DataBind()

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

    ''' <summary>
    ''' FECHA: 05/02/2014
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: EVENTO "SELECTEDINDEXCHANGED" DEL COMBOBOX PARA VISUALIZAR LA TARJETA SELECCIONADA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxtarjeta_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbxtarjeta.SelectedIndexChanged

        Try

            Dim valuetarjeta As String = Me.cbxtarjeta.SelectedValue
            imgtarjeta.Visible = True

            Select Case valuetarjeta

                Case "VI"

                    imgtarjeta.ImageUrl = "~/images/icons/64X64/visa.png"

                Case "MA"

                    imgtarjeta.ImageUrl = "~/images/icons/64X64/mastercard.png"

                Case "DN"

                    imgtarjeta.ImageUrl = "~/images/icons/64X64/dinersclub.png"

                Case "DI"

                    imgtarjeta.ImageUrl = "~/images/icons/64X64/discover.png"

            End Select

            imgtarjeta.DataBind()

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

    Protected Sub btnregresadetalleproductos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregresadetalleproductos.Click

        Try

            Response.Redirect("cotizadordetalle.aspx", False)

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

    Protected Sub btnsiguienteurltecnica_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsiguienteurltecnica.Click

        Try

            GeneraValoresURLTecnico()
            IngresaOrdenPagoPreliminar()
            Response.Redirect("cotizadorweburltecnico.aspx", False)

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

    Private Sub GeneraValoresURLTecnico()

        Try

            DTGetInfoURLTecnico.Columns.Add("datatecnica", GetType(String))

            DTGetInfoURLTecnico.Rows.Add(lblcotizacion_id.Text)
            DTGetInfoURLTecnico.Rows.Add(lblcotizacion_idcliente.Text)
            DTGetInfoURLTecnico.Rows.Add(lblcotizacion_descliente.Text)
            DTGetInfoURLTecnico.Rows.Add(txtcotizacion_direccion.Text)
            DTGetInfoURLTecnico.Rows.Add(lblcotizacion_telf.Text)
            DTGetInfoURLTecnico.Rows.Add(lblcotizacion_email.Text)
            DTGetInfoURLTecnico.Rows.Add(lblordenpago.Text)
            DTGetInfoURLTecnico.Rows.Add(lblpago_total.Text)
            DTGetInfoURLTecnico.Rows.Add(lblpago_subtotal.Text)
            DTGetInfoURLTecnico.Rows.Add(lblpago_descuentos.Text)
            DTGetInfoURLTecnico.Rows.Add(lblpago_promociones.Text)
            DTGetInfoURLTecnico.Rows.Add(lblpago_iva.Text)

            Session("DTGetInfoURLTecnico") = DTGetInfoURLTecnico

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try


    End Sub

    Private Sub CargaValoresFinales()

        Try

            DTSetInfoPagoOnline = Session("DTGetInfoPagoOnline")

            value_prev_idcotizacion = DTSetInfoPagoOnline.Rows(0)("data")
            value_prev_identificacion = DTSetInfoPagoOnline.Rows(1)("data")
            value_prev_nombre = DTSetInfoPagoOnline.Rows(2)("data")
            value_prev_telf01 = DTSetInfoPagoOnline.Rows(3)("data")
            value_prev_total = Parse(DTSetInfoPagoOnline.Rows(4)("data"))
            value_prev_subtotal = Parse(DTSetInfoPagoOnline.Rows(5)("data"))
            value_prev_descuento = Parse(DTSetInfoPagoOnline.Rows(6)("data"))
            value_prev_promocion = Parse(DTSetInfoPagoOnline.Rows(7)("data"))
            value_prev_iva = Parse(DTSetInfoPagoOnline.Rows(8)("data"))
            value_prev_email = DTSetInfoPagoOnline.Rows(9)("data")

            Me.lblcotizacion_id.Text = value_prev_idcotizacion
            Me.lblcotizacion_idcliente.Text = value_prev_identificacion
            Me.lblcotizacion_descliente.Text = value_prev_nombre
            Me.lblcotizacion_telf.Text = value_prev_telf01

            lblpago_total.Text = value_prev_total
            lblpago_subtotal.Text = value_prev_subtotal
            lblpago_descuentos.Text = value_prev_descuento
            lblpago_promociones.Text = value_prev_promocion
            lblpago_iva.Text = value_prev_iva

            Me.lblcotizacion_email.Text = value_prev_email

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

    Public Shared Function Parse(ByVal input As String) As Decimal
        Return Decimal.Parse(Regex.Replace(input, "[^\d.]", ""))
    End Function

End Class