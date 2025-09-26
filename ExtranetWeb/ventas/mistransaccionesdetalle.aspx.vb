
'Imports Telerik.Web.UI
'Imports System.Globalization
'Imports System.Net.Mail
'Imports System.IO
'Imports Novacode
'Imports System.Drawing


Public Class mistransaccionesdetalle
    Inherits System.Web.UI.Page

#Region "Declaracion de variables"

#End Region

    '#Region "Eventos de la pagina"

    '    ''' <summary>
    '    ''' FECHA: 28/04/2014
    '    ''' AUTOR: FELIX ONTANEDA
    '    ''' COMENTARIO: EVENTO LOAD DEL FORMULARIO DE DETALLE DE ORDEN DE PAGO
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    ''' <remarks></remarks>
    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        Try
    '            If Not IsPostBack Then
    '                If Session.Item("user") IsNot Nothing Then
    '                    If Not Session("tipo") Is Nothing Then
    '                        ConsultaDetalle(Session("tipo").ToString, Session("fecha").ToString, _
    '                                        Session("fecha_ini").ToString, Session("fecha_fin").ToString, _
    '                                        Session.Item("user").ToString)
    '                    End If
    '                End If
    '            End If

    '        Catch ex As Exception
    '            ExceptionHandler.Captura_Error(ex)
    '        End Try
    '    End Sub

    '#End Region

    '#Region "Eventos de los controles"

    '    Protected Sub btnregresaproductos_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregresaproductos.Click
    '        Try
    '            Response.Redirect("mistransacciones.aspx", False)
    '        Catch ex As Exception
    '            ExceptionHandler.Captura_Error(ex)
    '        End Try
    '    End Sub

    '#End Region

    '#Region "Procedimientos generales"

    '    ''' <summary>
    '    ''' FECHA: 29/04/2014
    '    ''' AUTOR: FELIX ONTANEDA
    '    ''' COMENTARIO: MÉTODO PARA LA CONSULTA GENERAL DE DETALLE AL INICIAR EL FORMULARIO
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub ConsultaDetalle(ByVal tipo As Integer, ByVal fecha As String, ByVal fecha_ini As String, _
    '                                ByVal fecha_fin As String, ByVal usuario As String)
    '        Try
    '            Dim DTCstGeneral As New System.Data.DataSet
    '            If tipo = 999 Then
    '                DTCstGeneral = MisTransaccionesAdapter.ConsultaDetallesintipo(usuario, tipo, fecha)

    '            Else
    '                DTCstGeneral = MisTransaccionesAdapter.ConsultaDetallecontipo(usuario, tipo, fecha_ini, fecha_fin)

    '            End If

    '            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
    '                Me.rgdcotizadordetalle.DataSource = DTCstGeneral
    '                Me.rgdcotizadordetalle.DataBind()
    '            Else
    '                rntMensajes.Text = "No existen datos de detalle"
    '                rntMensajes.Title = "Mensaje de la Aplicación Extranet"
    '                rntMensajes.TitleIcon = "warning"
    '                rntMensajes.ContentIcon = "warning"
    '                rntMensajes.ShowSound = "warning"
    '                rntMensajes.Width = 400
    '                rntMensajes.Height = 100
    '                rntMensajes.Show()
    '            End If
    '        Catch ex As Exception
    '            ExceptionHandler.Captura_Error(ex)
    '        End Try
    '    End Sub

    '#End Region

End Class
