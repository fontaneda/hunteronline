Imports PlugInClient
Imports System.Net.Mail

Public Class cotizadorurlretorno1
    'Inherits System.Web.UI.Page

    'Public firmaCorrecta As Boolean
    'Public plugInClientRecive As PlugInClientRecive

    'Dim aut_value_final As String
    'Dim tNo_value_final As String
    'Dim TransaccionID As String
    'Dim TransaccionValue As String
    'Dim Referencia1 As String
    'Dim Referencia2 As String
    'Dim Referencia3 As String
    'Dim Referencia4 As String
    'Dim Referencia5 As String
    'Dim TaxValue1 As String
    'Dim TaxValue2 As String
    'Dim TipValue As String
    'Dim codigoError As String
    'Dim codigoDesc As String
    'Dim estadoAutorizacion As String
    'Dim value_actestadoorden As Integer
    'Dim opcion As Integer

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    'Try
    '    If Not IsPostBack Then
    '        'Dim vector As String = ConfigurationManager.AppSettings.Get("Vector").ToString()
    '        Dim vector As String = Libreria.ReadFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyVector").ToString()))
    '        Dim xmlGenerateKey As String = Request.Params("XMLGENERATEKEY")

    '        plugInClientRecive = New PlugInClientRecive()
    '        plugInClientRecive.setIV(vector)
    '        'plugInClientRecive.setSignPublicKey(RSAEncryption.readFile(Server.MapPath("/keys/PUBLICA_FIRMA_INTERDIN.pem")))
    '        'plugInClientRecive.setCipherPrivateKeyFromFile(Server.MapPath("/keys/PRIVADA_CIFRADA_ESTABLECIMIENTO.pem"))
    '        plugInClientRecive.setSignPublicKey(RSAEncryption.readFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPublicaFirmaInterDin").ToString())))
    '        plugInClientRecive.setCipherPrivateKeyFromFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPrivadaCifradoEstablecimiento").ToString()))
    '        plugInClientRecive.setXMLGENERATEKEY(xmlGenerateKey)

    '        Dim cadeEnc As String = Request.Params("XMLRESPONSE")

    '        'JCOLOMA        17/02/2014      LINEA ADICIONAL PARA ENVIAR MSG POR EMAIL
    '        EMailHandler.EMailProcesoPago("EMAIL 7 ºº RETORNO // " & cadeEnc, Nothing, Session("iphost"), Session("iphost"))

    '        firmaCorrecta = plugInClientRecive.XMLProcess(cadeEnc, Request.Params("XMLDIGITALSIGN"))
    '        TransaccionID = plugInClientRecive.getTransacctionID()
    '        TransaccionValue = plugInClientRecive.getTransacctionValue
    '        TaxValue1 = plugInClientRecive.getTaxValue1
    '        TaxValue2 = plugInClientRecive.getTaxValue2
    '        TipValue = plugInClientRecive.getTipValue
    '        Referencia1 = plugInClientRecive.getReferencia1
    '        Referencia2 = plugInClientRecive.getReferencia2
    '        Referencia3 = plugInClientRecive.getReferencia3
    '        Referencia4 = plugInClientRecive.getReferencia4
    '        Referencia5 = plugInClientRecive.getReferencia5
    '        codigoError = plugInClientRecive.getErrorCode
    '        codigoDesc = plugInClientRecive.getErrorDetails
    '        estadoAutorizacion = plugInClientRecive.getAuthorizationState

    '        Me.lbltaxvalue2.Text = TaxValue2
    '        Me.lblreferencia1.Text = Referencia1
    '        Me.lblreferencia2.Text = Referencia2
    '        Me.lblreferencia3.Text = Referencia3
    '        Me.lblreferencia4.Text = Referencia4
    '        Me.lblreferencia5.Text = Referencia5
    '        Me.lblestadoautorizacion.Text = estadoAutorizacion

    '        tNo_value_final = TransaccionID

    '        'JCOLOMA        17/02/2014      LINEA ADICIONAL PARA ENVIAR MSG POR EMAIL
    '        EMailHandler.EMailProcesoPago("EMAIL 8 ºº RETORNO// " & codigoError & "//" & codigoDesc, Nothing, Session("iphost"), Session("iphost"))

    '        opcion = 3
    '        value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(opcion, estadoAutorizacion, aut_value_final, tNo_value_final, 0, "", 0, 0, 0, 0, "", "", "", "")

    '        If estadoAutorizacion = "Y" Then
    '            Me.btnVerPago.Visible = True
    '            Me.lbltitulo.Text = "Transacción Exitosa"

    '            Dim objmail As New MailTrabajos
    '            lblemailresult.Text = objmail.EnvioEmailConfirmaciónPago(100, CType(tNo_value_final, Decimal))
    '            'EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))

    '            Me.lblemailresult.Text = "Envío de email de confirmación satisfactorio"
    '            Try
    '                Dim DTSetInfoURLTecnico As New DataTable()
    '                DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
    '                Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
    '                If accion = "REN" Then
    '                    RenovacionAdapter.GeneraOrdenServicio(tNo_value_final)
    '                ElseIf accion = "VEN" Then
    '                    Dim taller As Integer = DTSetInfoURLTecnico.Rows(14)("datatecnica")
    '                    Dim fecha As Date = DTSetInfoURLTecnico.Rows(15)("datatecnica")
    '                    Dim hora As String = DTSetInfoURLTecnico.Rows(16)("datatecnica")

    '                    VentasAdapter.GeneraOrdenServicio(tNo_value_final, hora, fecha, taller)
    '                End If
    '            Catch ex As Exception
    '                ExceptionHandler.Captura_Error(ex, " **ERROR AL GENERAR O/S DEL SH CON PAGO Nº." + tNo_value_final + "** ")
    '            End Try
    '        Else
    '            Me.btnVerPago.Visible = False
    '            Me.lbltitulo.Text = "Transacción no realizada"

    '            Dim objmail As New MailTrabajos
    '            lblemailresult.Text = objmail.EnvioEmailConfirmaciónPago(200, CType(tNo_value_final, Decimal))
    '            'EnvioEmailConfirmaciónPago("200", CType(tNo_value_final, Decimal))

    '            Me.lblemailresult.Text = "Transacción rechazada, por favor comunicarse con su banco emisor."
    '        End If

    '        Me.lbltaxvalue2.Visible = False
    '        Me.lblreferencia1.Visible = False
    '        Me.lblreferencia2.Visible = False
    '        Me.lblreferencia3.Visible = False
    '        Me.lblreferencia4.Visible = False
    '        Me.lblreferencia5.Visible = False
    '        Me.lblestadoautorizacion.Visible = False

    '        opcion = 11
    '        Dim DTInfoResult As DataSet
    '        DTInfoResult = OrdenPagoAdapter.InfoOrdenResultado(opcion, tNo_value_final)

    '        If DTInfoResult.Tables(0).Rows.Count > 0 Then
    '            Me.lblordenpago.Text = DTInfoResult.Tables(0).Rows(0)("ORDEN_ID")
    '            Me.lblcotizacion.Text = DTInfoResult.Tables(0).Rows(0)("COTIZACIONID")
    '            Me.lblidentificacion.Text = DTInfoResult.Tables(0).Rows(0)("BILLINGCEDULA")
    '            Me.lblnombre.Text = DTInfoResult.Tables(0).Rows(0)("BILLINGNAME")
    '            Me.lblmeses.Text = DTInfoResult.Tables(0).Rows(0)("NUMERO_MESES")
    '            Me.lblsubtotal.Text = DTInfoResult.Tables(0).Rows(0)("SUBTOTAL")
    '            Me.lbliva.Text = DTInfoResult.Tables(0).Rows(0)("IVA")
    '            Me.lblintereses.Text = DTInfoResult.Tables(0).Rows(0)("INTERESES")
    '            Me.lbltotal.Text = DTInfoResult.Tables(0).Rows(0)("TOTAL")
    '            Me.lblcodcnfpago.Text = DTInfoResult.Tables(0).Rows(0)("CODIGO_CONF_PAGO")
    '        Else
    '            ProveedorMensaje.ShowMessage(rntMensajes, "Se presentó un problema al cargar la información de la orden de pago, comunicarse con Sistemas.", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '        End If
    '    End If
    'Catch ex As Exception
    '    opcion = 3
    '    value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(opcion, estadoAutorizacion, aut_value_final, tNo_value_final, 0, "", 0, 0, 0, 0, "", "", "", "")
    '    ProveedorMensaje.ShowMessage(rntMensajes, "Se presentó un problema al cargar la información de la orden de pago, comunicarse con Sistemas.", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '    ExceptionHandler.Captura_Error(ex)
    'End Try
    'End Sub

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

    'Protected Sub btnregresarinicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregresarinicio.Click
    '    Try
    '        Response.Redirect("renovacion4.aspx", False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Protected Sub btnVerPago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerPago.Click
    '    Try
    '        'Session("OrdeId") = Me.lblordenpago.Text
    '        Response.Redirect("transacciondetalle.aspx?OrderId=" + Me.lblordenpago.Text, False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

End Class