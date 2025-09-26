Imports Telerik.Web.UI
Imports System
Imports System.IO
Imports System.Net.Security
Imports System.Security.Cryptography
Imports Telerik.Web.UI.PivotGrid.Core

Public Class cotizadorweburltecnico
    Inherits System.Web.UI.Page

#Region "Declaracion de variables"
    Public postbk As Integer = 0
    Public turl As String = ""
    Private retorno As String = "mistransacciones.aspx"
#End Region

#Region "Eventos del formulario"

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            postbk = 0
            llena_controles()
            Proceso()
            imgregresoinicio.Visible = True
            btnregresoinicio.Visible = False
        Else
            postbk = 1
            If Page.Request.Params("__EVENTTARGET") = "btn" Then
                If Not Page.Request.Params("__EVENTARGUMENT") Is Nothing Then
                    If Page.Request.Params("__EVENTARGUMENT") <> "" Then
                        genera_pago(Page.Request.Params("__EVENTARGUMENT"))
                        imgregresoinicio.Visible = False
                        btnregresoinicio.Visible = True
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "Eventos controles"

    Private Sub btngenerar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerar.ServerClick
    End Sub

    Protected Sub btnregresoinicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregresoinicio.ServerClick
        Try
            If Session("origen_ordenes") = "WEB" Then
                Response.Redirect(retorno, False)
            Else
                Response.Redirect("pagoretorno.aspx", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub Proceso()
        EMailHandler.EMailProcesoPago(asunto_mail("1", "APERTURA BOTON DE PAGOS", Session("OrdenID")), Nothing, Session("iphost"), Session("iphost"))
        Dim url As String = ConfigurationManager.AppSettings.Get("DinersRuta").ToString()
        Try
            Dim jsonData As String = ""
            jsonData = DataJson()
            Dim objXmlHttp As Object
            Dim jsonhttp As Object
            jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
            jsonhttp.open("POST", url, False)
            jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
            jsonhttp.setRequestHeader("Content-Type", "application/json")
            jsonhttp.send(jsonData)
            objXmlHttp = jsonhttp.Responsetext

            Dim respuestaHTTP As String = objXmlHttp.ToString
            Dim requestid As String = descompone_retorno("requestId", respuestaHTTP)
            Dim processUrl As String = descompone_retorno("processUrl", respuestaHTTP)
            Dim value_actestadoorden As Integer = 0
            Dim ORDEN As Decimal = Session("OrdenID")
            value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnlineCodigo(requestid, ORDEN)

            processUrl = processUrl.Replace("\", "").Replace("https", "https:")
            Dim status As String = descompone_retorno("status", respuestaHTTP)
            jsonhttp = Nothing
            If processUrl <> "" And status = "OK" Then
                turl = processUrl
            Else
                MostrarMensaje("No se ha podido enlazar con pasarela de pagos")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub llena_controles()
        Dim DTSetInfoURLTecnico As New DataTable()
        DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
        Dim cedula As String = DTSetInfoURLTecnico.Rows(1)("datatecnica")
        Dim document As String = cedula
        Dim name As String = DTSetInfoURLTecnico.Rows(2)("datatecnica")
        Dim email As String = DTSetInfoURLTecnico.Rows(5)("datatecnica")
        Dim documentType As String = "CC"
        Dim mobile As String = DTSetInfoURLTecnico.Rows(4)("datatecnica")
        Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
        Dim iva_porcentaje As String = OrdenPagoAdapter.ConsultaPorcentajeIva
        Dim total As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
        Dim subtotal As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
        Dim orden As String = DTSetInfoURLTecnico.Rows(0)("datatecnica")

        obcliennombre.Text = name
        obmailcliente.Text = email
        obordennumero.Text = orden
        obidencliente.Text = document
        obvalorconiva.Text = total
        obimpuestoval.Text = iva
        obvalorclient.Text = subtotal

        lblfecha.Text = Date.Now.ToLongDateString
    End Sub

    Public Sub genera_pago(ByVal resultado As String)
        estado_controles(False)
        resultado = resultado.Replace("""", "")
        Dim tNo_value_final As String = descompone_retorno("reference", resultado)
        Dim id_transaccion As String = descompone_retorno("requestId", resultado)
        Dim estado_pago As String = descompone_retorno("status", resultado)
        Dim estado As String = ""
        Dim log_mensaje As String = ""
        Dim log_opcion As Integer = 0
        EMailHandler.EMailProcesoPago(asunto_mail("2", "Estado(" & estado_pago & ") Trama(" & resultado & ")", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
        If estado_pago = "APPROVED" Then
            log_mensaje = "Transacción Exitosa, Por favor revise su email con el detalle de la transacción."
            log_opcion = 20
            estado = "O"
        ElseIf estado_pago = "PENDING" Then
            log_mensaje = "La transacción se encuentra en un estado pendiente, espere unos minutos a que la misma se resuelva.."
            log_opcion = 19
            estado = "R"
        Else
            log_mensaje = "Transacción no realizada, por favor comunicarse con su banco emisor."
            log_opcion = 19
            estado = "X"
        End If
        Session("respuesta_link") = log_mensaje
        genera_ordenes(tNo_value_final, log_mensaje, estado, id_transaccion)
        FormularioAdapter.RegistroLog(log_opcion, Session("user"), 1, log_mensaje)
    End Sub

    Private Sub genera_ordenes(ByVal tNo_value_final As String, ByVal log_mensaje As String, ByVal estado_obtenido As String, ByVal id_transaccion As String)
        Dim resultado As String = retorna_resultado(id_transaccion, tNo_value_final)
        EMailHandler.EMailProcesoPago(asunto_mail("3", "Trama Detalle(" & resultado & ")", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
        Dim value_actestadoorden As Integer = 0
        Dim estado As String = descompone_retorno("status", resultado)
        Dim mensaje As String = descompone_retorno("message", resultado)
        Dim meses As String = descompone_retorno("installments", resultado)
        Dim numero_meses_ns As String = meses + "M"
        Dim id_grupo As String = descompone_retorno("groupCode", resultado)
        Dim banco As String = descompone_retorno("issuerName", resultado)
        Dim bin As String = descompone_subretorno("bin", resultado)
        Dim estado_texto As String = ""
        Dim opcion_email As String = ""
        Dim DTSetInfoURLTecnico As New DataTable()
        DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
        Dim total_con_iva As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
        Dim valor_total As String = DTSetInfoURLTecnico.Rows(8)("datatecnica") 'descompone_subretorno("totalAmount", resultado)
        Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
        Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
        Dim subtotal As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
        Dim usuario_ns As String = Session("user_netsuite")
        Dim usuario_3s As String = Session("user")
        Dim id_metodopago_ns As String = Session("id_metodopago_ns")
        Dim IdOrdenVpos As String = Session("IdOrdenVpos")
        Dim id_emisor_ns As String = Session("id_emisor_ns")
        Session("origen_ordenes") = DTSetInfoURLTecnico.Rows(18)("datatecnica")
        Dim formapago As String = "30"
        Try
            If tNo_value_final = "" Or estado = "" Or mensaje = "" Or meses = "" Or id_grupo = "" Or valor_total = "" Or banco = "" Or bin = "" Then
                EMailHandler.EMailProcesoPago(asunto_mail("X", "**ERROR EN CAPTURA DE DATOS", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
                Exit Try
            End If
            value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estado_obtenido, id_transaccion, tNo_value_final, meses,
                                                                              "DN", 0, 0, valor_total, 0, usuario_3s,
                                                                              id_transaccion, banco, bin, resultado)
            EMailHandler.EMailProcesoPago(asunto_mail("4", "ORDEN DE PAGO ACTUALIZADA", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
            Dim mensaje_mail As String = ""
            Dim objmail As New MailTrabajos
            If estado_obtenido = "O" Then
                estado_texto = "Aprobado"
                opcion_email = "100"
                mensaje_mail = String.Format("{0} - Email {1}", accion, estado_texto)
                If accion = "REN" Then
                    Dim tbl_table As New System.Data.DataTable
                    tbl_table = CType(Session("tblrenovaciones"), DataTable)
                    Dim i As Integer = 0
                    While tbl_table.Rows.Count > 0
                        Dim dRFila() As DataRow
                        Dim vehiculo As String = tbl_table.Rows(i).Item("VEHICULO")
                        Dim sentencia As String = String.Format("VEHICULO = '{0}' ", vehiculo)
                        dRFila = tbl_table.Select(sentencia)
                        Dim item_array As String = ""
                        Dim anio_array As String = ""
                        Dim ejecutiva_array As String = ""
                        Dim iva_array As String = ""
                        Dim subtotal_array As String = ""
                        Dim total_array As String = ""
                        For j As Integer = 0 To dRFila.Count - 1
                            Dim dRFila_ As DataRow = dRFila(j)
                            item_array = item_array & IIf(item_array <> "", ",", "") & dRFila.GetValue(j)("IDITEM")
                            anio_array = anio_array & IIf(anio_array <> "", ",", "") & dRFila.GetValue(j)("ANIO")
                            ejecutiva_array = IIf(ejecutiva_array <> "", ",", "") & dRFila.GetValue(j)("IDEJECUTIVO")
                            iva_array = iva_array & IIf(iva_array <> "", ",", "") & dRFila.GetValue(j)("IVA")
                            subtotal_array = subtotal_array & IIf(subtotal_array <> "", ",", "") & dRFila.GetValue(j)("PRECIO_VENTA")
                            total_array = total_array & IIf(total_array <> "", ",", "") & dRFila.GetValue(j)("PRECIO_CLIENTE")
                            tbl_table.Rows.Remove(dRFila_)
                        Next
                        Dim tbl_tablefac As New System.Data.DataTable
                        tbl_tablefac = CType(Session("tblfacturacion"), DataTable)
                        Dim clientefac As String = tbl_tablefac.Rows(0).Item(0).ToString
                        RenovacionAdapter.genera_renovacion(tNo_value_final, iva_array, subtotal_array, item_array, usuario_ns, vehiculo, ejecutiva_array, total_array,
                                      usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), anio_array, formapago, numero_meses_ns,
                                      Session("DTCodigoIva"), clientefac, bin, total_con_iva)
                    End While
                    estado_texto = "Transaccion Netsuite OK"
                    objmail.EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))
                ElseIf accion = "COB" Then
                    RenovacionAdapter.genera_cobro(tNo_value_final, usuario_3s, usuario_ns, valor_total, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), numero_meses_ns, bin, meses)
                    estado_texto = "Transaccion OK"
                    objmail.EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))
                ElseIf accion = "VEN" Then
                    'RenovacionAdapter.genera_venta(DTSetInfoURLTecnico, tNo_value_final, iva, subtotal, valor_total, usuario_ns, vehiculo_ns, fecha_set(), ejecutiva,
                    '             valor_total, usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"))
                    'Dim objmail2 As New MailTrabajos
                    'objmail2.EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))
                End If
                EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
            ElseIf estado_obtenido = "X" Then
                estado_texto = "Pendiente"
                opcion_email = "300"
                EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
            Else
                estado_texto = "Rechazado"
                opcion_email = "200"
                EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
            End If
            mensaje_pantalla(True, estado_texto)
            obestadoconf.Text = estado_texto
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function retorna_resultado(ByVal referencia As String, ByVal orden As String)
        retorna_resultado = ""
        Try
            Dim app_code As String = System.Configuration.ConfigurationManager.AppSettings("DinersLogin").ToString
            Dim app_key As String = System.Configuration.ConfigurationManager.AppSettings("DinersClave").ToString
            Dim url As String = System.Configuration.ConfigurationManager.AppSettings("DinersRuta").ToString & "/" & referencia
            Dim jsonData As String = ""
            Dim objXmlHttp As Object
            Dim jsonhttp As Object
            jsonData = DataJsonConsulta(app_code, app_key)
            jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
            jsonhttp.open("POST", url, False)
            jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
            jsonhttp.setRequestHeader("Content-Type", "application/json")
            jsonhttp.send(jsonData)
            objXmlHttp = jsonhttp.Responsetext
            retorna_resultado = objXmlHttp.ToString
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorna_resultado
    End Function

    Private Function DescomponeNombres(ByVal opcion As Integer, ByVal identificacion As String) As String
        DescomponeNombres = ""
        Dim dtDatos As DataSet
        dtDatos = VentasAdapter.ConsultaDatosVenta(0, identificacion, 7)
        If dtDatos.Tables.Count > 0 Then
            If opcion = 1 Then
                'Nombres
                DescomponeNombres = (dtDatos.Tables(0).Rows(0).Item("PRIMER_NOMBRE").ToString)
            ElseIf opcion = 2 Then
                'Apellidos
                DescomponeNombres = (dtDatos.Tables(0).Rows(0).Item("PRIMER_APELLIDO").ToString)
            End If
        Else

        End If
        Return DescomponeNombres
    End Function

    Private Function descompone_retorno(ByVal etiqueta As String, ByVal trama As String) As String
        Dim seccion As String = ""
        If trama.IndexOf(etiqueta) > -1 Then
            seccion = trama.Substring(trama.IndexOf(etiqueta))
            seccion = seccion.Substring(seccion.IndexOf(":"), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(":"))
            seccion = seccion.Replace(etiqueta, "").Replace(Chr(34), "").Replace(":", "").Replace("{", "").Replace("}", "")
            seccion = seccion.Trim
        End If
        Return seccion
    End Function

    Private Function descompone_subretorno(ByVal etiqueta As String, ByVal trama As String) As String
        Dim seccion As String = ""
        If trama.IndexOf(etiqueta) > -1 Then
            If etiqueta = "bin" Then
                seccion = trama.Substring(trama.IndexOf(etiqueta) - 28)
                seccion = seccion.Substring(seccion.IndexOf("value"))
                seccion = seccion.Substring(seccion.IndexOf(""""), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(""""))
            ElseIf etiqueta = "totalAmount" Then
                seccion = trama.Substring(trama.IndexOf(etiqueta) - 28)
                seccion = seccion.Substring(seccion.IndexOf("value"))
                seccion = seccion.Substring(seccion.IndexOf(""""), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(""""))
            Else
                seccion = trama.Substring(trama.IndexOf(etiqueta))
                seccion = seccion.Substring(seccion.IndexOf(""""), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(""""))
            End If
            seccion = seccion.Replace(etiqueta, "").Replace(Chr(34), "").Replace(":", "").Replace("{", "").Replace("}", "")
        End If
        Return seccion
    End Function

    Private Sub MostrarMensaje(ByVal mensaje As String)
        Try
            Me.lbltitulo.Text = mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub mensaje_pantalla(ByVal estado As Boolean, ByVal log_mensaje As String)
        If estado Then
            Me.lbltitulo.Text = "TRANSACCION EXITOSA"
            Me.imageResultado.ImageUrl = "~/images/icons/24x24/pagoOk.png"
        Else
            Me.lbltitulo.Text = "TRANSACCION NO REALIZADA"
            Me.imageResultado.ImageUrl = "~/images/icons/24x24/alerterror1.png"
        End If

        Me.lblemailresult.Text = log_mensaje
        Session("DTCarroCompraMasterTableView") = Nothing
    End Sub

    Private Sub estado_controles(ByVal estado As Boolean)
        'Me.btngenerar.Visible = estado
        Me.btnregresoinicio.Visible = Not estado
    End Sub

    Private Sub guarda_trama_pagos(ByVal orden As String, ByVal trama As String)
        Try
            'TRAMA PARA CAPTURAR DATOS DEVUELTOS POR EL V-POS EN ARCHIVO TXT
            Dim path As String = String.Format("D:\DOCUMENTOS\RETORNO_PAGOS\OrdenP2P_{0}_{1}.txt", orden, fecha_set())
            Dim fs As FileStream = File.Create(path)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(trama)
            fs.Write(info, 0, info.Length)
            fs.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Function fecha_set() As String
        Dim retorno As String = ""
        retorno = Date.Now.Day
        retorno &= Date.Now.Month
        retorno &= Date.Now.Year
        retorno &= Date.Now.Hour
        retorno &= Date.Now.Minute
        retorno &= Date.Now.Second
        Return retorno
    End Function

    Private Function asunto_mail(ByVal num_mail As String, ByVal tipo As String, ByVal orden As String) As String
        Dim resultado As String = ""
        resultado = String.Format("EMAIL {0}ºº {1} ENVIADO // P2P({2})", num_mail, tipo, orden)
        Return resultado
    End Function

#End Region

#Region "Eventos Pasarela"

    Private Function DataJson() As String
        DataJson = ""
        Dim DTSetInfoURLTecnico As New DataTable()
        DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
        Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
        Dim proceso As String = ""

        If accion = "REN" Then
            proceso = "Renovación de servcicios"
        ElseIf accion = "VEN" Then
            proceso = "Venta de productos/servcicios"
        ElseIf accion = "COB" Then
            proceso = "Cobro de productos/servcicios"
        End If

        If Not DTSetInfoURLTecnico Is Nothing Then
            Dim tablaAuth As New DataTable
            tablaAuth.Columns.Add("login", GetType(String))
            tablaAuth.Columns.Add("tranKey", GetType(String))
            tablaAuth.Columns.Add("nonce", GetType(String))
            tablaAuth.Columns.Add("seed", GetType(String))
            Dim login As String = ConfigurationManager.AppSettings.Get("DinersLogin").ToString()
            Dim tranKey As String = ConfigurationManager.AppSettings.Get("DinersClave").ToString()
            Dim nonce As String = GetNonce()
            Dim seed As String = FormatoFecha(Date.Now)
            Dim trankeyencr As String = encriptar_sha1_64(String.Format("{0}{1}{2}", nonce, seed, tranKey)) 'EncriptarBase64(EncriptarSHA1(nonce & seed & tranKey))
            Dim nonceencr As String = EncriptarBase64(nonce)
            tablaAuth.Rows.Add(login, trankeyencr, nonceencr, seed)
            Dim auth As String = SerializarJson(tablaAuth)
            auth = auth.Replace("[", "").Replace("]", "")

            Dim tablaTaxes As New DataTable
            tablaTaxes.Columns.Add("kind", GetType(String))
            tablaTaxes.Columns.Add("amount", GetType(String))
            tablaTaxes.Columns.Add("base", GetType(String))
            Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
            Dim iva_porcentaje As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
            tablaTaxes.Rows.Add("valueAddedTax", iva, iva_porcentaje)
            Dim taxes As String = SerializarJson(tablaTaxes)
            taxes = taxes.Replace(String.Format("""{0}""", iva), String.Format("""{0}""", iva).Replace("""", ""))
            taxes = taxes.Replace(String.Format("""{0}""", iva_porcentaje), String.Format("""{0}""", iva_porcentaje).Replace("""", ""))

            Dim tablaAmount As New DataTable
            tablaAmount.Columns.Add("taxes", GetType(String))
            tablaAmount.Columns.Add("currency", GetType(String))
            tablaAmount.Columns.Add("total", GetType(String))
            Dim currency As String = ConfigurationManager.AppSettings.Get("DinersMoneda").ToString()
            Dim total As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
            total = total.Replace(",", "")
            tablaAmount.Rows.Add(taxes, currency, total)
            Dim amount As String = SerializarJson(tablaAmount)
            amount = amount.Replace("]""", "]")
            amount = amount.Replace("""[", "[")
            amount = amount.Substring(1, amount.Length - 2)
            amount = amount.Replace(String.Format("""{0}""", total), String.Format("""{0}""", total).Replace("""", ""))

            Dim tablaPayment As New DataTable
            tablaPayment.Columns.Add("reference", GetType(String))
            tablaPayment.Columns.Add("descripcion", GetType(String))
            tablaPayment.Columns.Add("amount", GetType(String))
            tablaPayment.Columns.Add("allowPartial", GetType(String))
            Dim reference As String = DTSetInfoURLTecnico.Rows(0)("datatecnica")
            Dim allowPartial As String = "false"
            tablaPayment.Rows.Add(reference, proceso, amount, allowPartial)
            Dim payment As String = SerializarJson(tablaPayment)
            payment = payment.Replace("""false""", "false")
            payment = payment.Substring(1, payment.Length - 2)

            Dim tablaBuyer As New DataTable
            tablaBuyer.Columns.Add("name", GetType(String))
            tablaBuyer.Columns.Add("surname", GetType(String))
            tablaBuyer.Columns.Add("email", GetType(String))
            tablaBuyer.Columns.Add("document", GetType(String))
            tablaBuyer.Columns.Add("documentType", GetType(String))
            tablaBuyer.Columns.Add("mobile", GetType(String))
            Dim cedula As String = DTSetInfoURLTecnico.Rows(1)("datatecnica")
            Dim document As String = cedula
            Dim name As String = DescomponeNombres(1, cedula)
            Dim surname As String = DescomponeNombres(2, cedula)
            Dim email As String = DTSetInfoURLTecnico.Rows(5)("datatecnica")
            Dim documentType As String = "CI"
            Dim mobile As String = DTSetInfoURLTecnico.Rows(4)("datatecnica")
            tablaBuyer.Rows.Add(name, surname, email, document, documentType, mobile)
            Dim buyer As String = SerializarJson(tablaBuyer)
            buyer = buyer.Replace("[", "").Replace("]", "")

            Dim tablaJson As New DataTable
            tablaJson.Columns.Add("locale", GetType(String))
            tablaJson.Columns.Add("buyer", GetType(String))
            tablaJson.Columns.Add("payment", GetType(String))
            tablaJson.Columns.Add("expiration", GetType(String))
            tablaJson.Columns.Add("ipAddress", GetType(String))
            tablaJson.Columns.Add("returnUrl", GetType(String))
            tablaJson.Columns.Add("userAgent", GetType(String))
            tablaJson.Columns.Add("paymentMethod", GetType(String))
            tablaJson.Columns.Add("auth", GetType(String))
            Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
            Dim lenguaje As String = ConfigurationManager.AppSettings.Get("DinersLenguaje").ToString()
            Dim fechaexpira As String = FormatoFecha(DateAdd(DateInterval.Minute, 8, Date.Now))
            Dim ip As String = Request.ServerVariables("REMOTE_ADDR")
            Dim navegador As String = browser.Browser & "/" & browser.Version
            Dim urlretorno As String = ConfigurationManager.AppSettings.Get("DinersRetorno").ToString()
            tablaJson.Rows.Add(lenguaje, buyer, payment, fechaexpira, ip, urlretorno, navegador, "null", auth)
            DataJson = SerializarJson(tablaJson)
            DataJson = DataJson.Replace("\", "").Replace("}""", "}").Replace("""{", "{").Replace("""null""", "null")
            DataJson = DataJson.Substring(1, DataJson.Length - 2)
        End If
        Return DataJson
    End Function

    Private Function DataJsonConsulta(ByVal login As String, ByVal trankey As String) As String
        DataJsonConsulta = ""
        Dim DTSetInfoURLTecnico As New DataTable()

        If Not DTSetInfoURLTecnico Is Nothing Then
            Dim nonce As String = GetNonce()
            Dim seed As String = FormatoFecha(Date.Now)
            Dim trankeyencr As String = encriptar_sha1_64(String.Format("{0}{1}{2}", nonce, seed, trankey))
            Dim nonceencr As String = EncriptarBase64(nonce)
            Dim auth As String = SerializarJsonConsulta(login, seed, nonceencr, trankeyencr)
            DataJsonConsulta = auth
        End If

        Return DataJsonConsulta
    End Function

    Private Function FormatoFecha(ByVal fecha As DateTime) As String
        FormatoFecha = ""
        FormatoFecha = FormatoFecha & Convert.ToString(fecha.Year) & "-"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Month), 2) & "-"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Day), 2) & "T"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Hour), 2) & ":"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Minute), 2) & ":"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Second), 2) & "-05:00"
        Return FormatoFecha
    End Function

    Private Function GetNonce() As String
        GetNonce = ""
        Dim Generator As System.Random = New System.Random()
        Dim randomN As Integer = Generator.Next(0, Int32.MaxValue)
        GetNonce = randomN.GetHashCode.ToString
        Return GetNonce
    End Function

    Public Function SerializarJson(ByVal firstTable As DataTable) As String
        Try
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))
            Dim row As Dictionary(Of String, Object)

            For Each dr As DataRow In firstTable.Rows
                row = New Dictionary(Of String, Object)
                For Each col As DataColumn In firstTable.Columns
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SerializarJsonConsulta(ByVal login As String, ByVal seed As String, ByVal nonce As String, ByVal trankey As String) As String
        SerializarJsonConsulta = ""
        Try
            SerializarJsonConsulta = "{""auth"":{""login"": """ & login & _
                                     """,""seed"": """ & seed & _
                                     """,""nonce"": """ & nonce & _
                                     """,""tranKey"": """ & trankey & """}}"
        Catch ex As Exception
            'Throw ex
        End Try
        Return SerializarJsonConsulta
    End Function

#End Region

#Region "Encriptaciones"

    Public Function EncriptarSHA256(ByVal ClearString As String) As String
        Dim sourceBytes = ASCIIEncoding.ASCII.GetBytes(ClearString)
        Dim SHA256Obj As New System.Security.Cryptography.SHA256CryptoServiceProvider
        Dim byteHash = SHA256Obj.ComputeHash(sourceBytes)
        Dim result As String = ""
        For Each b As Byte In byteHash
            result += b.ToString("x2")
        Next
        Return result
    End Function

    Private Function EncriptarSHA1(ByVal ClearString As String) As String
        EncriptarSHA1 = ""
        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(ClearString)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        For Each b As Byte In bytesToHash
            EncriptarSHA1 += b.ToString("x2")
        Next
        Return EncriptarSHA1
    End Function

    Private Function EncriptarBase64(ByVal ClearString As String) As String
        EncriptarBase64 = ""
        EncriptarBase64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(ClearString))
        Return EncriptarBase64
    End Function

    Private Function encriptar_sha1_64(ByVal ClearString As String) As String
        encriptar_sha1_64 = ""

        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(ClearString)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        encriptar_sha1_64 = System.Convert.ToBase64String(bytesToHash)

        Return encriptar_sha1_64
    End Function

#End Region

End Class