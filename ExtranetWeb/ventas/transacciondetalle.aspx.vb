Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Net.Mail
Imports System.IO
Imports Novacode
Imports System.Drawing

Public Class transacciondetalle

    Inherits System.Web.UI.Page
    Dim valueIphost, valuePchost, cadenaitems, identificacion As String
    Dim opcion, valueUsuarioid, userid, newrow, newcolumn As Integer

#Region "Eventos de la pagina"

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO LOAD DEL FORMULARIO DE DETALLE DE ORDEN DE PAGO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session.Item("user") IsNot Nothing Then
                    If Not Request.QueryString("OrderId") Is Nothing Then
                        ConsultaOrdenPagoCabecera(Request.QueryString("OrderId"))
                        ConsultaOrdenPagoDetalle(Request.QueryString("OrderId"))
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA LA CONSULTA GENERAL DE ORDEN DE PAGO AL INICIAR EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConsultaOrdenPagoCabecera(ByVal ordenpago As Decimal)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = TransaccionAdapter.ConsultaOrdenPagoCabecera(ordenpago)
            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                txtorderid.Text = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("ORDERID"))
                txtidentificacion.Text = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("BILLINGIDENTIFICATION"))
                txtnombre.Text = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("BILLINGNAME"))
                txtfechapago.SelectedDate = Convert.ToDateTime(DTCstGeneral.Tables(0).Rows(0)("DATEPLACED"))
                txthorapago.SelectedDate = Convert.ToDateTime(DTCstGeneral.Tables(0).Rows(0)("DATEPLACED"))
                txtformapago.Text = "Tarjeta de crédito"
                txttipotarjeta.Text = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("BILLINGCARDTYPEDESC"))
                txtnumeroautorizacion.Text = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("PAYMENTCONFIRMATIONCODE"))
                lblsubtotal.Text = String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", Convert.ToDecimal(DTCstGeneral.Tables(0).Rows(0)("SUBTOTAL")))
                lbliva.Text = String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", Convert.ToDecimal(DTCstGeneral.Tables(0).Rows(0)("TAX")))
                lblintereses.Text = String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", Convert.ToDecimal(DTCstGeneral.Tables(0).Rows(0)("INTERESES")))
                lbltotal.Text = String.Format(CultureInfo.GetCultureInfo(1033), "{0:C2}", Convert.ToDecimal(DTCstGeneral.Tables(0).Rows(0)("TOTAL")))
            Else
                rntMensajes.Text = "No existen datos de cabecera de orden de pago"
                rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
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
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA LA CONSULTA GENERAL DE ORDEN DE PAGO AL INICIAR EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConsultaOrdenPagoDetalle(ByVal ordenpago As Decimal)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            DTCstGeneral = TransaccionAdapter.ConsultaOrdenPagoDetalle(ordenpago)
            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                Me.rgdcotizadordetalle.DataSource = DTCstGeneral
                Me.rgdcotizadordetalle.DataBind()
            Else
                rntMensajes.Text = "No existen datos de detalle de orden de pago"
                rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
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

#End Region

#Region "botones"

    Protected Sub btnregresaproductos_Click(sender As Object, e As EventArgs) Handles btnregresaproductos.Click
        Try
            Response.Redirect("transaccion.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class