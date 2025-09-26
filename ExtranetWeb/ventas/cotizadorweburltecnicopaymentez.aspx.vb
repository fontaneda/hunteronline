Imports System.Globalization
Imports System.IO

Public Class cotizadorweburltecnicopaymentez
    Inherits System.Web.UI.Page

#Region "DECLARACION DE VARIABLES"
    Dim DTSetInfoURLTecnico As New DataTable()
    Public appcod As String
    Public appkey As String
    Public appurl As String
    Public entorno As String
    Public lenguaje As String
    Public postbk As Integer = 0
    Private retorno As String = "mistransacciones.aspx"
#End Region

#Region "EVENTOS DE LA PAGINA"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 01/11/2017
    ''' DESCR: EVENTO LOAD DEL PAGE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then
                postbk = 1
                If Page.Request.Params("__EVENTTARGET") = "btn" Then
                    If Not Page.Request.Params("__EVENTARGUMENT") Is Nothing Then
                        If Page.Request.Params("__EVENTARGUMENT") <> "" Then
                            genera_pago(Page.Request.Params("__EVENTARGUMENT"))
                        End If
                    End If
                End If
            Else
                postbk = 0
                CargaDatos()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "EVENTOS DE LOS CONTROLES"

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

#Region "PROCEDIMIENTOS GENERALES"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 03/05/2018
    ''' DESCR: FUNCION PARA CARGAR VALOR DEL NOMBRE DE PRODUCTO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaDatos()
        Try
            EMailHandler.EMailProcesoPago(asunto_mail("1", "APERTURA BOTON DE PAGOS", Session("OrdenID")), Nothing, Session("iphost"), Session("iphost"))
            Dim entorno_titulo_str As String
            If Session("Pacificard") = "0" Then
                entorno_titulo_str = "Paymentez"
                appcod = ConfigurationManager.AppSettings.Get("UsrServerPaymentez").ToString()
                appkey = ConfigurationManager.AppSettings.Get("KeyServerPaymentez").ToString()
            Else
                entorno_titulo_str = "Paymentez - Pacificard"
                appcod = ConfigurationManager.AppSettings.Get("UsrServerPaymentezPCF").ToString()
                appkey = ConfigurationManager.AppSettings.Get("KeyServerPaymentezPCF").ToString()
            End If
            appurl = ConfigurationManager.AppSettings.Get("UrlPaymentez").ToString()
            entorno = ConfigurationManager.AppSettings.Get("IdEntornoPaymentez").ToString()
            lenguaje = ConfigurationManager.AppSettings.Get("IdLenguajePaymentez").ToString()
            Dim iva_porcentaje As String = OrdenPagoAdapter.ConsultaPorcentajeIva
            DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
            If Not DTSetInfoURLTecnico Is Nothing Then
                If DTSetInfoURLTecnico.Rows(13)("datatecnica") = "REN" Then
                    obdescrproduc.Text = "Renovación de servcicios"
                ElseIf DTSetInfoURLTecnico.Rows(13)("datatecnica") = "VEN" Then
                    obdescrproduc.Text = "Venta de productos/servcicios"
                ElseIf DTSetInfoURLTecnico.Rows(13)("datatecnica") = "COB" Then
                    obdescrproduc.Text = "Cobro de productos/servcicios"
                    iva_porcentaje = 0
                End If
                obordennumero.Text = DTSetInfoURLTecnico.Rows(0)("datatecnica")
                obcliennombre.Text = DTSetInfoURLTecnico.Rows(2)("datatecnica")
                obidencliente.Text = DTSetInfoURLTecnico.Rows(1)("datatecnica")
                obcellcliente.Text = DTSetInfoURLTecnico.Rows(4)("datatecnica")
                obmailcliente.Text = DTSetInfoURLTecnico.Rows(5)("datatecnica")
                obvalorconiva.Text = DTSetInfoURLTecnico.Rows(7)("datatecnica")
                obvalorclient.Text = DTSetInfoURLTecnico.Rows(8)("datatecnica")
                obimpuestoval.Text = DTSetInfoURLTecnico.Rows(11)("datatecnica")
                obtipdiferido.Text = DTSetInfoURLTecnico.Rows(17)("datatecnica")
                obimpuestopor.Text = iva_porcentaje
                'obtipdiferido.Text = 3
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' DESCR: LLAMADO DE PROCESOS PARA LA GENERACION DEL PAGO
    ''' FECHA: 05/02/2019
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub genera_pago(ByVal resultado As String)
        estado_controles(False)
        resultado = resultado.Replace("""", "")
        Dim tNo_value_final As String = valor(resultado, "dev_reference")
        Dim autorizacion_rs As String = valor(resultado, "status")
        Dim numero_autorizacion As String = valor(resultado, "authorization_code")
        Dim log_mensaje As String = ""
        Dim log_opcion As Integer = 0

        EMailHandler.EMailProcesoPago(asunto_mail("2", "Estado(" & autorizacion_rs & ") Trama(" & resultado & ")", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))

        If autorizacion_rs = "success" And numero_autorizacion <> "null" Then
            log_mensaje = "Transacción Exitosa, Por favor revise su email con el detalle de la transacción."
            log_opcion = 20
            Session("respuesta_link") = log_mensaje
            genera_ordenes(tNo_value_final, log_mensaje, resultado, numero_autorizacion)
        Else
            log_mensaje = "Transacción no realizada, por favor comunicarse con su banco emisor."
            log_opcion = 19
            Session("respuesta_link") = log_mensaje
            cancela_ordenes(tNo_value_final, log_mensaje, resultado)
        End If

        Try
            'TRAMA PARA REGISTRO DEL LOG DE LA PAGINA
            FormularioAdapter.RegistroLog(log_opcion, Session("user"), 1, log_mensaje)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' DESCR: EXTRAE EL VALOR DE UN ITEM ESPECIFICO DENTRO DE LA CADENA JSON
    ''' FECHA: 05/02/2019
    ''' </summary>
    ''' <param name="cadena"></param>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function valor(ByVal cadena As String, ByVal item As String) As String
        Dim resultado As String = ""
        cadena = cadena.Replace("\", "")
        Dim ini As Integer = cadena.IndexOf(item & ":")

        If ini > -1 Then
            Dim fin As Integer = cadena.Substring(ini).IndexOf(",")
            If fin < 0 Then
                fin = cadena.Substring(ini).IndexOf("}")
            End If

            resultado = cadena.Substring(ini, fin)
            resultado = resultado.Replace(item & ":", "").Replace("{", "").Replace("}", "")
        End If

        Return resultado
    End Function

    Private Sub genera_ordenes(ByVal orden_trabajada As String, ByVal log_mensaje As String, ByVal resultado As String, ByVal numero_autorizacion As String)
        Dim value_actestadoorden As Integer = 0
        Dim numero_meses As String = valor(resultado, "installments")
        Dim numero_meses_ns As String = numero_meses + "M"
        Dim tipo_tarjeta As String = valor(resultado, "type")
        Dim mensaje As String = valor(resultado, "message")
        Dim id_transaccion As String = valor(resultado, "transaction_reference")
        Dim banco As String = valor(resultado, "bank_name")
        Dim bintarjeta As String = valor(resultado, "bin")
        Dim DTSetInfoURLTecnico As New DataTable()
        DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
        Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
        Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
        Dim total_con_iva As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
        Dim TransaccionValue As String = DTSetInfoURLTecnico.Rows(8)("datatecnica") 'valor(resultado, "amount")
        Dim subtotal As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
        Dim usuario_ns As String = Session("user_netsuite")
        Dim usuario_3s As String = Session("user")
        Dim id_metodopago_ns As String = Session("id_metodopago_ns")
        Dim IdOrdenVpos As String = Session("IdOrdenVpos")
        Dim id_emisor_ns As String = Session("id_emisor_ns")
        Dim formapago As String = "30"
        orden_trabajada = DTSetInfoURLTecnico.Rows(0)("datatecnica")
        Dim estado_texto As String = ""
        Session("origen_ordenes") = DTSetInfoURLTecnico.Rows(18)("datatecnica")
        Try
            mensaje_pantalla(True, log_mensaje)
            'ACTUALIZA ESTADO, VALOR, INFO DE TARJETA Y CODIGO DE CONFIRMACION EN LA TABLA ORDEN DE EXTRANET
            value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, "O", numero_autorizacion, orden_trabajada, numero_meses,
                                                                              tipo_tarjeta, 0, 0, TransaccionValue, 0, Session("user"),
                                                                              id_transaccion, banco, bintarjeta, resultado)
            EMailHandler.EMailProcesoPago(asunto_mail("3", "ORDEN DE PAGO ACTUALIZADA", orden_trabajada), Nothing, Session("iphost"), Session("iphost"))
            'TRAMA PARA CREAR ORDEN DE SERVICIO
            Dim mensaje_mail As String = ""
            Dim objmail As New MailTrabajos
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
                    RenovacionAdapter.genera_renovacion(orden_trabajada, iva_array, subtotal_array, item_array, usuario_ns, vehiculo, ejecutiva_array, total_array,
                                      usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), anio_array, formapago, numero_meses_ns,
                                      Session("DTCodigoIva"), clientefac, bintarjeta, total_con_iva)
                End While
                estado_texto = "Transaccion Netsuite OK"
                objmail.EnvioEmailConfirmaciónPago("100", CType(orden_trabajada, Decimal))
            ElseIf accion = "COB" Then
                RenovacionAdapter.genera_cobro(orden_trabajada, usuario_3s, usuario_ns, TransaccionValue, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), numero_meses_ns, bintarjeta, numero_meses)
                estado_texto = "Transaccion OK"
                objmail.EnvioEmailConfirmaciónPago("100", CType(orden_trabajada, Decimal))
            ElseIf accion = "VEN" Then
                '            Dim table As New System.Data.DataTable
                '            table = CType(Session("tblrenovaciones"), DataTable)
                '            For i As Integer = 0 To table.Rows.Count - 1
                '                Dim vehiculo_ns As String = table.Rows(i).Item("VEHICULO")
                '                Dim item As String = table.Rows(i)("IDITEM")
                '                Dim ejecutiva As String = table.Rows(i)("IDEJECUTIVO")
                'RenovacionAdapter.genera_venta(DTSetInfoURLTecnico, orden_trabajada, iva, subtotal, item, usuario_ns, vehiculo_ns, fecha_set(), ejecutiva,
                '             TransaccionValue, usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"))
                'Dim objmail2 As New MailTrabajos
                'objmail2.EnvioEmailConfirmaciónPago("100", CType(orden_trabajada, Decimal))
                '            Next
            End If
            mensaje_pantalla(True, estado_texto)
            EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, orden_trabajada), Nothing, Session("iphost"), Session("iphost"))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub cancela_ordenes(ByVal orden_trabajada As String, ByVal log_mensaje As String, ByVal resultado As String)
        Try
            Dim value_actestadoorden As Integer = 0
            Dim numero_autorizacion As String = valor(resultado, "authorization_code")
            Dim numero_meses As String = valor(resultado, "installments")
            Dim tipo_tarjeta As String = valor(resultado, "type")
            Dim TransaccionValue As String = valor(resultado, "amount")
            Dim id_transaccion As String = valor(resultado, "transaction_reference")

            mensaje_pantalla(False, log_mensaje)
            'ACTUALIZA ESTADO, VALOR, INFO DE TARJETA Y CODIGO DE CONFIRMACION EN LA TABLA ORDEN DE EXTRANET
            value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, "R", numero_autorizacion, orden_trabajada, _
                                                                              numero_meses, tipo_tarjeta, 0, 0, TransaccionValue, _
                                                                              0, Session("user"), id_transaccion, "", "", "")

            EMailHandler.EMailProcesoPago(asunto_mail("5", "ORDEN DE PAGO ACTUALIZADA", orden_trabajada), Nothing, Session("iphost"), Session("iphost"))
            Dim DTSetInfoURLTecnico As New DataTable()
            DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
            Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")

            'ENVIO DE EMAIL DE CONFIRMACION DE PAGO
            If accion = "REN" Then
                Dim objmail As New MailTrabajos
                objmail.EnvioEmailConfirmaciónPago("200", CType(orden_trabajada, Decimal))
                EMailHandler.EMailProcesoPago(asunto_mail("6", "REN", orden_trabajada), Nothing, Session("iphost"), Session("iphost"))
            ElseIf accion = "COB" Then
                Dim objmail As New CobroAdapter
                objmail.EnvioEmailConfirmaciónPago("200", CType(orden_trabajada, Decimal))
                EMailHandler.EMailProcesoPago(asunto_mail("6", "COB", orden_trabajada), Nothing, Session("iphost"), Session("iphost"))
            ElseIf accion = "VEN" Then
                Dim objmail2 As New MailTrabajos
                objmail2.EnvioEmailConfirmaciónPago("200", CType(orden_trabajada, Decimal))
                EMailHandler.EMailProcesoPago(asunto_mail("7", "VEN", orden_trabajada), Nothing, Session("iphost"), Session("iphost"))
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub estado_controles(ByVal estado As Boolean)
        'Me.btnpagar.Visible = estado
        Me.btngenerar.Visible = estado
        Me.btnregresoinicio.Visible = Not estado
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

    Private Function asunto_mail(ByVal num_mail As String, ByVal tipo As String, ByVal orden As String) As String
        Dim resultado As String = ""
        resultado = String.Format("EMAIL {0}ºº {1} ENVIADO // Paymentez({2})", num_mail, tipo, orden)
        Return resultado
    End Function

    Private Sub guarda_trama_pagos(ByVal orden As String, ByVal trama As String)
        Try
            'TRAMA PARA CAPTURAR DATOS DEVUELTOS POR EL V-POS EN ARCHIVO TXT
            Dim path As String = String.Format("D:\DOCUMENTOS\RETORNO_PAGOS\OrdenPM_{0}_{1}.txt", orden, fecha_set())
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

    Private Function extrae_oficina(id_cliente As String) As String
        Dim retorno As String = ""
        Dim dtresultado As New System.Data.DataTable
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        dtresultado = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", id_cliente, "", "", "", ""))

        If dtresultado.Rows.Count > 0 Then
            retorno = dtresultado.Rows(0)("IdOficina").ToString.ToUpper
        End If

        Return retorno
    End Function

    Private Function extrae_nombre(id_cliente As String) As String
        Dim retorno As String = ""
        Dim dtresultado As New System.Data.DataTable
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        dtresultado = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", id_cliente, "", "", "", ""))

        If dtresultado.Rows.Count > 0 Then
            retorno = dtresultado.Rows(0)("NombreCompleto").ToString.ToUpper
        End If

        Return retorno
    End Function

    Private Function fecha_ns_() As String
        Dim anio As String = Date.Now.Year.ToString
        Dim mes As String = "0" & Date.Now.Month.ToString
        Dim dia As String = "0" & Date.Now.Month.ToString
        mes = mes.Substring(0, 2)
        dia = dia.Substring(0, 2)

        Dim retorno As String = String.Format("{0}/{1}/{2}", anio, mes, dia)
        Return retorno
    End Function

#End Region

End Class