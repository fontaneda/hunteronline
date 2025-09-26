Imports System.IO
Imports VPOS20_PLUGIN
Imports System.Collections.Specialized

Public Class cotizadorurlretornoalignet
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

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 28/11/2014
    ' ''' DESCR: EVENTO LOAD DEL PAGE
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Try
    '        If Not IsPostBack Then
    '            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
    '                EMailHandler.EMailProcesoPago("EMAIL 6 ºº RETORNO // Alignet", Nothing, Session("iphost"), Session("iphost"))

    '                Dim vector As String = Libreria.ReadFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyVectorAlignet").ToString()))
    '                Dim coll As New NameValueCollection()

    '                'OBTIENE PARAMETROS ENVIADOS POR ALIGNET
    '                coll = Request.Params
    '                Dim sIDACQUIRER As [String] = coll.[Get]("IDACQUIRER")
    '                Dim sIDCOMMERCE As [String] = coll.[Get]("IDCOMMERCE")
    '                Dim sXMLRES As [String] = coll.[Get]("XMLRES")
    '                Dim sSESSIONKEY As [String] = coll.[Get]("SESSIONKEY")
    '                Dim sDIGITALSIGN As [String] = coll.[Get]("DIGITALSIGN")
    '                Dim oVPOSBean As New VPOSBean()

    '                'LLENA VARIABLES DE CIFRADO
    '                oVPOSBean.cipheredXML = sXMLRES
    '                oVPOSBean.cipheredSessionKey = sSESSIONKEY
    '                oVPOSBean.cipheredSignature = sDIGITALSIGN
    '                Dim srVPOSLlaveFirmaPublica As New StreamReader(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaFirmaPublicaAlignet")))
    '                Dim srComercioLlaveCifradoPrivada As New StreamReader(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPrivadaCifradoAlignet")))
    '                Dim oVPOSReceive As New VPOSReceive(srVPOSLlaveFirmaPublica, srComercioLlaveCifradoPrivada, vector)

    '                EMailHandler.EMailProcesoPago("EMAIL 7 ºº RETORNO Alignet// " & sIDCOMMERCE, Nothing, Session("iphost"), Session("iphost"))

    '                'EJECUPA EL PLUGIN DEL VPOS PARA OBTENER DATOS
    '                oVPOSReceive.execute(oVPOSBean)

    '                'OBTIENE DATOS DEL PLUGIN
    '                resultado_autorizacion = oVPOSBean.authorizationResult
    '                numero_autorizacion = oVPOSBean.authorizationCode
    '                error_codigo = oVPOSBean.errorCode
    '                error_descripcion = oVPOSBean.errorMessage
    '                tipo_tarjeta = devuelve_codigo_tipotarjeta(oVPOSBean.cardType)
    '                numero_meses = "1"
    '                tNo_value_final = oVPOSBean.purchaseOperationNumber

    '                Dim purchase_amount As String = oVPOSBean.purchaseAmount
    '                Dim TransaccionValue As String = purchase_amount.Substring(0, purchase_amount.Length - 2) & _
    '                                                 "." & _
    '                                                 purchase_amount.Substring(purchase_amount.Length - 2, purchase_amount.Length - 1)

    '                TransaccionValue = Session("ValorPagarExtranet")

    '                'TRAMA PARA CAPTURAR DATOS DEVUELTOS POR EL V-POS EN ARCHIVO TXT
    '                Dim path As String = "C:\DOCUMENTOS\RETORNO_PAGOS\Orden_" & tNo_value_final & ".txt"
    '                Dim fs As FileStream = File.Create(path)
    '                Dim info As Byte() = New UTF8Encoding(True).GetBytes("authorizationResult:          " & oVPOSBean.authorizationResult & _
    '                                                                    vbCrLf & _
    '                                                                    "authorizationCode:             " & oVPOSBean.authorizationCode & _
    '                                                                    vbCrLf & _
    '                                                                    "errorCode:                     " & oVPOSBean.errorCode & _
    '                                                                    vbCrLf & _
    '                                                                    "errorMessage:                  " & oVPOSBean.errorMessage & _
    '                                                                    vbCrLf & _
    '                                                                    "cardType:                      " & oVPOSBean.cardType & _
    '                                                                    vbCrLf & _
    '                                                                    "purchaseOperationNumber:       " & oVPOSBean.purchaseOperationNumber & _
    '                                                                    vbCrLf & _
    '                                                                    "purchaseCommerceAmount:        " & oVPOSBean.purchaseAmount)
    '                fs.Write(info, 0, info.Length)
    '                fs.Close()

    '                'ENVIO DE MAIL CON LOS CODIGOS Y MENSAJES DEVUELTOS POR ALIGNET
    '                EMailHandler.EMailProcesoPago(String.Format("Alignet 8 ºº RETORNO// {0}//{1}", error_codigo, error_descripcion), Nothing, Session("iphost"), Session("iphost"))

    '                'SETEO DE VARIABLES DEPENDIENDO DEL CODIGO DE ERROR DEVUELTO
    '                If resultado_autorizacion = "00" Then
    '                    'If numero_autorizacion > 0 Then
    '                    log_opcion = 20
    '                    opcion_mail = "100"
    '                    estadoAutorizacion = "Y"
    '                    Me.imageResultado.Visible = True
    '                    Me.lbltitulo.Text = "Transacción Exitosa"
    '                    numero_autorizacion = numero_autorizacion
    '                    Session("DTCarroCompraMasterTableView") = Nothing
    '                    Me.imageResultado.ImageUrl = "~/images/icons/24x24/pagoOk.png"
    '                    Me.lblemailresult.Text = "Envío de email de confirmación satisfactorio"
    '                    log_mensaje = "Transacción Exitosa, Envío de email de confirmación de pago satisfactorio."
    '                ElseIf resultado_autorizacion = "01" Then
    '                    log_opcion = 19
    '                    opcion_mail = "200"
    '                    numero_autorizacion = 0
    '                    estadoAutorizacion = "R"
    '                    Me.imageResultado.Visible = True
    '                    Me.lbltitulo.Text = "Transacción no realizada"
    '                    Me.imageResultado.ImageUrl = "~/images/icons/24x24/alerterror1.png"
    '                    log_mensaje = "Transacción no realizada, por favor comunicarse con su banco emisor."
    '                    Me.lblemailresult.Text = "Transacción denegada, por favor comunicarse con su banco emisor."
    '                ElseIf resultado_autorizacion = "05" Then
    '                    log_opcion = 19
    '                    opcion_mail = "200"
    '                    numero_autorizacion = 0
    '                    estadoAutorizacion = "N"
    '                    Me.imageResultado.Visible = True
    '                    Me.lbltitulo.Text = "Transacción cancelada"
    '                    Me.imageResultado.ImageUrl = "~/images/icons/24x24/alerterror1.png"
    '                    log_mensaje = "Transacción cancelada, por favor comunicarse con su banco emisor."
    '                    Me.lblemailresult.Text = "Transacción rechazada, por favor comunicarse con su banco emisor."
    '                Else
    '                    log_opcion = 19
    '                    opcion_mail = "200"
    '                    numero_autorizacion = 0
    '                    estadoAutorizacion = "N"
    '                    Me.imageResultado.Visible = True
    '                    Me.lbltitulo.Text = "Transacción anulada"
    '                    Me.imageResultado.ImageUrl = "~/images/icons/24x24/alerterror1.png"
    '                    log_mensaje = "Transacción anulada, por favor comunicarse con su banco emisor."
    '                    Me.lblemailresult.Text = "Transacción anulada, por favor comunicarse con su banco emisor."
    '                End If

    '                'ACTUALIZA ESTADO, VALOR, INFO DE TARJETA Y CODIGO DE CONFIRMACION EN LA TABLA ORDEN DE ESTRANET
    '                value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estadoAutorizacion, Convert.ToInt64(numero_autorizacion), _
    '                                                                                  tNo_value_final, numero_meses, tipo_tarjeta, 0, 0, _
    '                                                                                  TransaccionValue, 0, Session("user"), "", "", "")

    '                'TRAMA PARA CREAR ORDEN DE SERVICIO
    '                If resultado_autorizacion = "00" And numero_autorizacion > 0 Then
    '                    Try
    '                        Dim DTSetInfoURLTecnico As New DataTable()
    '                        DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
    '                        Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")

    '                        If accion = "REN" Then
    '                            RenovacionAdapter.GeneraOrdenServicio(tNo_value_final)
    '                        ElseIf accion = "VEN" Then
    '                            Dim taller As Integer = DTSetInfoURLTecnico.Rows(14)("datatecnica")
    '                            Dim fecha As Date = DTSetInfoURLTecnico.Rows(15)("datatecnica")
    '                            Dim hora As String = DTSetInfoURLTecnico.Rows(16)("datatecnica")

    '                            VentasAdapter.GeneraOrdenServicio(tNo_value_final, hora, fecha, taller)
    '                            promocion()
    '                        End If
    '                    Catch ex As Exception
    '                        ExceptionHandler.Captura_Error(ex, String.Format(" **ERROR AL GENERAR O/S DEL SH CON PAGO Nº.{0}** ", tNo_value_final))
    '                    End Try
    '                End If

    '                'ENVIO DE EMAIL DE CONFIRMACION DE PAGO
    '                Dim objmail As New MailTrabajos
    '                lblemailresult.Text = objmail.EnvioEmailConfirmaciónPago(opcion_mail, CType(tNo_value_final, Decimal))

    '                ''TRAMA PARA REGISTRO DEL LOG DE LA PAGINA
    '                Try
    '                    FormularioAdapter.RegistroLog(log_opcion, Session("user"), 1, log_mensaje)
    '                Catch ex As Exception
    '                    ExceptionHandler.Captura_Error(ex)
    '                End Try

    '                'OBTENCION DE DATOS DE LA ORDEN DE LA EXTRANET
    '                Dim DTInfoResult As DataSet
    '                DTInfoResult = OrdenPagoAdapter.InfoOrdenResultado(11, tNo_value_final)

    '                'SETEO DE CONTROLES DE LA PAGINA CON LOS VALORES OBTENIDOS DE LA ORDEN DE EXTRANET
    '                If DTInfoResult.Tables(0).Rows.Count > 0 Then
    '                    Me.lblordenpago.Text = DTInfoResult.Tables(0).Rows(0)("ORDEN_ID")
    '                    Me.lblcotizacion.Text = DTInfoResult.Tables(0).Rows(0)("COTIZACIONID")
    '                    Me.lblidentificacion.Text = DTInfoResult.Tables(0).Rows(0)("BILLINGCEDULA")
    '                    Me.lblnombre.Text = DTInfoResult.Tables(0).Rows(0)("BILLINGNAME")
    '                    Me.lblmeses.Text = DTInfoResult.Tables(0).Rows(0)("NUMERO_MESES")
    '                    Me.lblsubtotal.Text = DTInfoResult.Tables(0).Rows(0)("SUBTOTAL")
    '                    Me.lbliva.Text = DTInfoResult.Tables(0).Rows(0)("IVA")
    '                    Me.lblintereses.Text = DTInfoResult.Tables(0).Rows(0)("INTERESES")
    '                    Me.lbltotal.Text = DTInfoResult.Tables(0).Rows(0)("TOTAL")
    '                    Me.lblcodcnfpago.Text = DTInfoResult.Tables(0).Rows(0)("CODIGO_CONF_PAGO")
    '                Else
    '                    ProveedorMensaje.ShowMessage(rntMensajes, "Se presentó un problema al cargar la información de la orden de pago, comunicarse con Sistemas.", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estadoAutorizacion, numero_autorizacion, tNo_value_final, 0, "", 0, 0, 0, 0, "", "", "", "")
    '        ProveedorMensaje.ShowMessage(rntMensajes, String.Format("Se presentó un problema al cargar la información de la orden de pago No: {0}, comunicarse con Sistemas.", tNo_value_final), ProveedorMensaje.MessageStyle.OperacionInvalida)
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

#End Region

    'Private Sub promocion()
    '    Dim dTPromocion As DataSet
    '    Dim strMailMsg, strMailTitle, strMail As String
    '    Dim DTEmailAct As DataSet
    '    dTPromocion = DatosPersonalesAdapter.ConsultaPromocion(Date.Now, "RENSER")
    '    If dTPromocion.Tables(0).Rows.Count > 0 Then
    '        Dim tipoPromocion As String = dTPromocion.Tables(0).Rows(0)("TIPO_ID")
    '        Dim promocionId As String = dTPromocion.Tables(0).Rows(0)("PROMOCION_ID")
    '        Dim resultado As String = SolicitudActualizacionAdapter.RegistroPromocion(Session.Item("user"), "W", tipoPromocion, promocionId, Session("VehiculoOrden"), Session("OrdenID"))
    '        ' IMAGEN DE PROMOCION Y CORREO
    '        If resultado <> "" Then
    '            Dim arregloCodigos() As String = resultado.Split(",")
    '            lblcodigo.Text = arregloCodigos(0)
    '            lblcodigo2.Text = arregloCodigos(1)
    '            Label1.Text = arregloCodigos(0)
    '            Label2.Text = arregloCodigos(1)
    '            DTEmailAct = DatosPersonalesAdapter.GeneraEmailPromocion(Session.Item("user"), resultado, tipoPromocion, Session("OrdenID"), promocionId)
    '            If DTEmailAct.Tables.Count > 0 Then
    '                If DTEmailAct.Tables(0).Rows.Count > 0 Then
    '                    strMailMsg = DTEmailAct.Tables(0).Rows(0)("BODY_HTML")
    '                    strMailTitle = DTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
    '                    strMail = DTEmailAct.Tables(0).Rows(0)("EMAIL")
    '                    EnvioEmailPromocion(strMail, strMailTitle, strMailMsg)
    '                    Dim promocion As String = "function f(){$find(""" + modalPromocion.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
    '                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", promocion, True)
    '                    If Session("Actualizacion") = "1" Then
    '                        ActualizacionPromocion("002", promocionId)
    '                    End If
    '                    Session("VehiculoOrden") = Nothing
    '                    Session("OrdenID") = Nothing
    '                Else
    '                    ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '                End If
    '            Else
    '                ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '            End If
    '        End If

    '    End If
    'End Sub


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


    'Private Sub ActualizacionPromocion(ByVal tipo As String, ByVal promocionId As String)
    '    Try
    '        Dim strMailMsg, strMailTitle, strMail As String
    '        Dim dTEmailAct As DataSet
    '        Dim tipoPromocion As String = tipo
    '        Dim resultado As String = SolicitudActualizacionAdapter.RegistroPromocion(Session.Item("user"), "W", tipoPromocion, promocionId, Session("VehiculoOrden"), Session("OrdenID"))
    '        If resultado <> "" Then
    '            Label3.Text = resultado
    '            dTEmailAct = DatosPersonalesAdapter.GeneraEmailPromocion(Session.Item("user"), resultado, tipoPromocion, "", promocionId)
    '            If dTEmailAct.Tables.Count > 0 Then
    '                If dTEmailAct.Tables(0).Rows.Count > 0 Then
    '                    strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
    '                    strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
    '                    strMail = dTEmailAct.Tables(0).Rows(0)("EMAIL")
    '                    EnvioEmailPromocion(strMail, strMailTitle, strMailMsg)
    '                    Dim promocion As String = "function f(){$find(""" + modalPromocion1.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
    '                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", promocion, True)
    '                    Session("Actualizacion") = "0"
    '                Else
    '                    ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '                End If
    '            Else
    '                ProveedorMensaje.ShowMessage(rntMensajes, "Ocurrió un inconveniente al enviarse el email de Promoción", ProveedorMensaje.MessageStyle.OperacionInvalida)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Private Sub EnvioEmailPromocion(ByVal email As String, ByVal titulo As String, ByVal mensaje As String)
    '    Dim correo = New System.Net.Mail.MailMessage()
    '    correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
    '    Dim mailTo As [String]() = email.ToString().Split(";")
    '    For Each mailTooBcc As String In mailTo
    '        If EMailHandler.ValidarEMail(mailTooBcc) Then
    '            correo.To.Add(mailTooBcc)
    '        End If
    '    Next
    '    'correo.To.Add(email)
    '    Dim mailToBccCollection As [String]() = ConfigurationManager.AppSettings.Get("PromocionMailToBcc").ToString().Split(";")
    '    For Each mailTooBcc As String In mailToBccCollection
    '        If EMailHandler.ValidarEMail(mailTooBcc) Then
    '            correo.Bcc.Add(mailTooBcc)
    '        End If
    '    Next
    '    correo.Subject = titulo
    '    titulo &= vbCrLf & vbCrLf & "Fecha y hora GMT: " & DateTime.Now.ToUniversalTime.ToString("dd/MM/yyyy HH:mm:ss")
    '    correo.Body = mensaje
    '    correo.IsBodyHtml = True
    '    Dim smtp As New System.Net.Mail.SmtpClient
    '    '---------------------------------------------
    '    ' Estos datos debes rellanarlos correctamente
    '    '---------------------------------------------
    '    smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
    '    smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
    '    smtp.EnableSsl = False
    '    Try
    '        smtp.Send(correo)
    '        correo.Dispose()
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

#Region "EVENTO DE LOS CONTROLES"

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 28/11/2014
    ' ''' DESCR: EVENTO CLICK DEL BOTON INICIO PARA RETORNAR AL PAGE DE RENOVACION
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Protected Sub btnregresarinicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregresarinicio.Click
    '    Try
    '        Response.Redirect("renovacion.aspx", False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 28/11/2014
    ' ''' DESCR: EVENTO CLICK DEL BOTON DE VER PAGO PARA RETORNAR AL DETALLE DE PAGOS
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Protected Sub btnVerPago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerPago.Click
    '    Try
    '        Response.Redirect("transacciondetalle.aspx?OrderId=" + Me.lblordenpago.Text, False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

#End Region

#Region "PROCEDIMIENTOS GENERALES"

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 28/11/2014
    ' ''' DESCR: PROCEDIMIENTO PARA DEVOLVER EL CODIGO DEL TIPO DE TARJETA USADO
    ' ''' </summary>
    ' ''' <param name="tipotarjeta"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function devuelve_codigo_tipotarjeta(ByVal tipotarjeta As String) As String
    '    devuelve_codigo_tipotarjeta = "ND"
    '    Try
    '        If tipotarjeta = "VISA" Then
    '            devuelve_codigo_tipotarjeta = "VI"
    '        ElseIf tipotarjeta = "MASTERCARD" Then
    '            devuelve_codigo_tipotarjeta = "MC"
    '        End If
    '    Catch ex As Exception
    '        devuelve_codigo_tipotarjeta = "ND"
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    '    Return devuelve_codigo_tipotarjeta
    'End Function

#End Region

End Class