Imports System.IO

Public Class cotizadorurlretornodebito
    Inherits System.Web.UI.Page

#Region "DECLARACION DE VARIABLES"
    Dim tNo_value_final As String = "0"
    Dim numero_autorizacion As String
    Dim TransaccionValue As String
    Dim tipo_tarjeta As String
    Dim numero_meses As String
    Dim error_descripcion As String
    Dim error_codigo As String
    Dim resultado_autorizacion As String
    Dim estadoAutorizacion As String
    Dim value_actestadoorden As Integer
    Dim opcion_mail As String
    Dim log_opcion As Integer
    Dim log_mensaje As String
#End Region

#Region "EVENTOS DE LA PAGINA"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 16/01/2017
    ''' DESCR: EVENTO LOAD DEL PAGE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    genera_debito()
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub genera_debito()
        Try
            tNo_value_final = Session("IdOrdenVpos")
            TransaccionValue = Session("ValorPagarExtranet")
            tipo_tarjeta = Session("IdTarjetaVpos")
            EMailHandler.EMailProcesoPago(asunto("6", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
            Dim DTSetInfoURLTecnico As New DataTable()
            DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
            Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
            'TRAMA PARA CREAR ORDEN DE SERVICIO
            If accion = "REN" Then
                If RenovacionAdapter.GeneraOrdenServicio(tNo_value_final) Then
                    EMailHandler.EMailProcesoPago(asunto("7", "OS Generada - " & tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
                    'ACTUALIZA ESTADO, VALOR, INFO DE TARJETA Y CODIGO DE CONFIRMACION EN LA TABLA ORDEN DE ESTRANET
                    value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, "Y", 1, tNo_value_final, 1, _
                                                                                       tipo_tarjeta, 0, 0, TransaccionValue, _
                                                                                       0, Session("user"), "", "", "", "")
                    EMailHandler.EMailProcesoPago(asunto("8", "Orden pago actualizada - " & tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
                    'ENVIO DE EMAIL DE CONFIRMACION DE PAGO
                    Dim objmail As New MailTrabajos
                    lblemailresult.Text = objmail.EnvioEmailConfirmaciónPago(opcion_mail, CType(tNo_value_final, Decimal))
                    EMailHandler.EMailProcesoPago(asunto("9", "Email enviado - " & tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
                    'OBTENCION DE DATOS DE LA ORDEN DE LA EXTRANET
                    Dim DTInfoResult As DataSet
                    DTInfoResult = OrdenPagoAdapter.InfoOrdenResultado(11, tNo_value_final)
                    'SETEO DE CONTROLES DE LA PAGINA CON LOS VALORES OBTENIDOS DE LA ORDEN DE EXTRANET
                    If DTInfoResult.Tables(0).Rows.Count > 0 Then
                        Me.lblordenpago.Text = DTInfoResult.Tables(0).Rows(0)("ORDEN_ID")
                        Me.lblnombre.Text = DTInfoResult.Tables(0).Rows(0)("BILLINGNAME")
                        Dim orden As String = tNo_value_final
                        Dim vehiculosid As String = Session("vehiculos_da")
                        Dim ObjDocumento As New DocumentosContratos
                        Dim nombre As String = ObjDocumento.GenerarDocumentoDA(orden, vehiculosid)
                        myframe.Attributes.Add("src", "https://www.hunteronline.com.ec/IMGCOTIZADORWEB/ImagenesDocumentos/" & nombre)
                    Else
                        ProveedorMensaje.ShowMessage(rntMensajes, "Se presentó un problema al cargar la información de la orden de pago, comunicarse con Sistemas.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                    End If
                    estados(True)
                Else
                    estados(False)
                    ProveedorMensaje.ShowMessage(rntMensajes, String.Format(" **ERROR AL GENERAR O/S DEL SH CON PAGO Nº.{0}** ", tNo_value_final), ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
            value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estadoAutorizacion, numero_autorizacion, tNo_value_final, 0, "", 0, 0, 0, 0, "", "", "", "", "")
            ExceptionHandler.Captura_Error(ex, String.Format("Se presentó un problema al cargar la información de la orden de pago No: {0}, comunicarse con Sistemas.", tNo_value_final))
        End Try
    End Sub

    Private Function asunto(ByVal numero As String, ByVal orden As String) As String
        Dim resultado As String = ""
        resultado = String.Format("EMAIL {0}ºº - RETORNO - Pmtz D.A. ({1})", orden)

        Return resultado
    End Function

    Private Sub estados(ByVal estado As Boolean)
        If estado Then
            Me.imageResultado.Visible = True
            Session("DTCarroCompraMasterTableView") = Nothing
            Me.imageResultado.ImageUrl = "~/images/icons/24x24/pagoOk.png"
            Me.lblemailresult.Text = "Envío de email de confirmación satisfactorio"
        Else
            Me.imageResultado.Visible = True
            Me.imageResultado.ImageUrl = "~/images/icons/24x24/alerterror1.png"
            Me.lblemailresult.Text = "Transacción anulada, por favor comunicarse con su banco emisor."
        End If
    End Sub

#End Region

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 28/11/2014
    ' ''' DESCR: PROCEDIMIENTO PARA EL ENVIO DE MAIL
    ' ''' </summary>
    ' ''' <param name="Proceso"></param>
    ' ''' <param name="OrdenId"></param>
    ' ''' <remarks></remarks>
    'Private Sub EnvioEmailConfirmaciónPago(ByVal Proceso As String, ByVal OrdenId As Decimal)
    '    Try
    '        Dim EmailBody, EmailBodyCopias As String
    '        Dim EmailAddres, EmailAddresCopias As String
    '        Dim DTCstGeneral, DTCstGeneralCopias As New System.Data.DataSet

    '        'ENVIA EMAIL A CLIENTE
    '        DTCstGeneral = RenovacionAdapter.ConsultaEmail(OrdenId, Proceso, True)
    '        EmailBody = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("HTMLBODY"))
    '        EmailAddres = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("BILLINGEMAIL"))
    '        EMailHandler.EMailConfirmacionPagoCliente(EmailBody, EmailAddres, Proceso)

    '        'ENVIA MAIL COPIAS
    '        DTCstGeneralCopias = RenovacionAdapter.ConsultaEmail(OrdenId, Proceso, False)
    '        EmailBodyCopias = Convert.ToString(DTCstGeneralCopias.Tables(0).Rows(0)("HTMLBODY"))
    '        EmailAddresCopias = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC")
    '        EMailHandler.EMailConfirmacionPagoCliente(EmailBodyCopias, EmailAddresCopias, Proceso)

    '    Catch ex As Exception
    '        Me.lblemailresult.Text = "Ocurrió un error al enviar el email de confirmación"
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

End Class