Public Class RenovacionAdapter

    Public Shared Function ConsultaProductoCliente(ByVal cliente As String, ByVal filtrolike As String, ByVal tipoconsulta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            If Not String.IsNullOrEmpty(filtrolike) Then
                filtrolike = "%" + filtrolike + "%"
                base.AddParrameter("@FILTROLIKE", filtrolike)
            End If
            base.AddParrameter("@TIPO", tipoconsulta)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosCliente(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPorcentajeIva() As Decimal
        Dim porcentajeiva As Decimal = 0
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@EMPRESA", "001")
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
            porcentajeiva = Convert.ToString(ds.Tables(0).Rows(0)("PORCENTAJEIVA"))
        Catch ex As Exception
            Throw ex
        End Try
        Return porcentajeiva
    End Function

    Public Shared Function ConsultaUltimoPedido(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "103")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaListadoAnioRenovacion(ByVal vehiculo As String, ByVal producto As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@PRODUCTO", producto)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VALOR_PRODUCTO2")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPrecioProducto(ByVal vehiculo As String, ByVal producto As String, ByVal anio As Integer,
                                                  ByVal codigopromocion As String, ByVal marcadolojack As String,
                                                  ByVal listadoPromociones As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "200")
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@PRODUCTO", producto)
            base.AddParrameter("@ANIO_RENOVAR", anio)
            base.AddParrameter("@CODIGO_PROMOCION", codigopromocion)
            base.AddParrameter("@MARCADO_LOJACK", marcadolojack)
            base.AddParrameter("@LISTA_PROMOCIONES", listadoPromociones)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VALOR_PRODUCTO2")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmail(ByVal orden As Decimal, ByVal proceso As String, ByVal escliente As Boolean) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@ORDEN", orden)
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@ESCLIENTE", IIf(escliente, "1", "0"))
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_EMAIL_ORDEN_PAGO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmailLink(ByVal orden As Decimal, ByVal url As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@ORDEN", orden)
            base.AddParrameter("@LINK", url)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_EMAIL_LINK")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function RegistraLogLecturaMail(ByVal orden As Int64, ByVal usuario As String, ByVal mail As String, ByVal proceso As Integer) As Boolean
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "EXTRANET.SP_MANTENEDOR_LOG_NOTIFICACION_LECTURA"
            base.AddParrameter("@ORDEN", orden)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@MAIL", mail)
            base.AddParrameter("@PROCESO", proceso)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
            Return True
        Catch ex As Exception
            tran.Rollback()
            Return False
        End Try
    End Function

    Public Shared Sub ActualizaFechaEnvioEmail(ByVal orden As Decimal)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_EMAIL_ORDEN_PAGO"
            base.AddParrameter("@ORDEN", orden)
            base.AddParrameter("@PROCESO", "100")
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

    Public Shared Function EsValidaInformacionCliente(ByVal cliente As String) As Boolean
        Dim ds As New DataSet
        Dim esValido As Boolean = True
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@USUARIO", cliente)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_INFO_USUARIO_COMPLETA")
            esValido = IIf(ds.Tables(0).Rows(0)("RESULTADO").ToString() = "1", True, False)
        Catch ex As Exception
            Throw ex
        End Try
        Return esValido
    End Function

    Public Shared Function GeneraOrdenServicio(ByVal ordenpagoid As Decimal) As Boolean
        Dim retorno As Boolean = False
        Try
            If GeneraOrdenServicio_Web(ordenpagoid, "100") Then
                If GeneraOrdenServicio_Web(ordenpagoid, "200") Then
                    If GeneraOrdenServicio_Web(ordenpagoid, "300") Then
                        'Generacion de comprobante de facturacion
                        GeneraComprobante(ordenpagoid)
                        retorno = True
                    Else
                        retorno = False
                    End If
                Else
                    retorno = False
                End If
            Else
                retorno = False
            End If
        Catch ex As Exception
            retorno = False
            Throw ex
        End Try
        Return retorno
    End Function

    Public Shared Function GeneraOrdenServicio_Web(ByVal ordenpagoid As Decimal, ByVal proceso As String) As Boolean
        Dim retorno As Boolean = False
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_SERVICIO_WEB"
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@SUCURSAL", "001")
            base.AddParrameter("@ORDENID", ordenpagoid)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
            retorno = True
        Catch ex As Exception
            retorno = False
            tran.Rollback()
            Throw ex
        End Try
        Return retorno
    End Function

    Public Shared Function GeneraComprobante(ByVal ordenpagoid As Decimal) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@ORDENID", ordenpagoid)
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@SUCURSAL", "001")
            base.AddParrameter("@PROCESO", "100")
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_ORDEN_SERVICIO_COMPROBANTE")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaBienesParaPromocion(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@CLIENTE", cliente)
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@PROCESO", "104")
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Sub GeneraOrdenServicioCortesia(ByVal clienteid As String, ByVal vehiculoid As String)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_SERVICIO_CORTESIA"
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@SUCURSAL", "001")
            base.AddParrameter("@CLIENTEID", clienteid)
            base.AddParrameter("@VEHICULOID", vehiculoid)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try

    End Sub

    Public Shared Function ConsultaEmisor() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@EMPRESA", "001")
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmisorDetalle(ByVal idemisor As Integer, permiteDa As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "106")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@IDEMISOR", idemisor)
            base.AddParrameter("@PERMITE_DA", permiteDa)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmisorDetalleVpos(ByVal idemisor As String, permiteDa As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "112")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@FILTROLIKE", idemisor)
            base.AddParrameter("@PERMITE_DA", permiteDa)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmisorDetalleVpos2(ByVal idemisor As String, permiteDa As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "114")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@FILTROLIKE", idemisor)
            base.AddParrameter("@PERMITE_DA", permiteDa)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaProductoClienteRenoExt(ByVal cliente As String, ByVal filtrolike As String, ByVal tipoconsulta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "110")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            If Not String.IsNullOrEmpty(filtrolike) Then
                filtrolike = "%" + filtrolike + "%"
                base.AddParrameter("@FILTROLIKE", filtrolike)
            End If
            base.AddParrameter("@TIPO", tipoconsulta)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaProductoClienteAux(ByVal cliente As String, ByVal filtrolike As String, ByVal tipoconsulta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "111")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            If Not String.IsNullOrEmpty(filtrolike) Then
                filtrolike = "%" + filtrolike + "%"
                base.AddParrameter("@FILTROLIKE", filtrolike)
            End If
            base.AddParrameter("@TIPO", tipoconsulta)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaOrden(orden As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", "18")
            base.AddParrameter("@ORDENSEC", orden)
            ds = base.Consulta("dbo.SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPagoTarjeta() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", "22")
            ds = base.Consulta("dbo.SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaOrdenDetalle(orden As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", "19")
            base.AddParrameter("@ORDENSEC", orden)
            ds = base.Consulta("dbo.SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaTipoPago() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "113")
            base.AddParrameter("@EMPRESA", "001")
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function CargaForma(ByVal opcion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function GeneraOrdenServicioPorFormaPago(ByVal ordenpagoid As Decimal) As Boolean
        'Public Shared Sub GeneraOrdenServicioPorFormaPago(ByVal ordenpagoid As Decimal) as boolean
        'Dim base As New DataBaseApp.CommandApp
        'Dim cnn As SqlClient.SqlConnection = Nothing
        'Dim cmd As SqlClient.SqlCommand = Nothing
        'Dim tran As SqlClient.SqlTransaction = Nothing
        'Try
        '    cmd = New SqlClient.SqlCommand
        '    cnn = base.Connection
        '    cnn.Open()
        '    cmd.CommandTimeout = 1000
        '    cmd.Connection = cnn
        '    'tran = cnn.BeginTransaction()
        '    base.ClearParrameter(cmd)
        '    base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_SERVICIO_FORMA_PAGO"
        '    base.AddParrameter("@PROCESO", "100")
        '    base.AddParrameter("@EMPRESA", "001")
        '    base.AddParrameter("@SUCURSAL", "001")
        '    base.AddParrameter("@ORDENID", ordenpagoid)
        '    base.EjecutaTransaction(cmd, tran)
        '    'tran.Commit()
        '    'Generacion de comprobante de facturacion
        '    'GeneraComprobante(ordenpagoid)
        'Catch ex As Exception
        '    'tran.Rollback()
        '    Throw ex
        'End Try
        Dim retorno As Boolean = False
        Try
            If GeneraOrdenServicio_Web(ordenpagoid, "100") Then
                If GeneraOrdenServicio_Web(ordenpagoid, "300") Then
                    retorno = True
                Else
                    retorno = False
                End If
            Else
                retorno = False
            End If
        Catch ex As Exception
            retorno = False
        End Try
        Return retorno
    End Function

    Public Shared Sub genera_renovacion(orden_id As String, iva As String, subtotal As String, ByVal items As String,
                                        ByVal usuario_ns As String, ByVal vehiculo As String, ByVal ejecutivas As String,
                                        ByVal total As String, ByVal usuario_3s As String, ByVal id_metodo_pago As String,
                                        ByVal id_orden_vpos As String, ByVal id_emisor_ns As String, ByVal iphost As String,
                                        ByVal anios As String, ByVal formapago As String, ByVal meses As String, ByVal codigo_iva As String,
                                        ByVal clientefacturar As String, bin As String, valor_total As Decimal)
        If OrdenPagoAdapter.VerificaRelacionNS(orden_id) Then
            Exit Sub
        End If
        Dim ubicacion As String = extrae_oficina(usuario_ns)
        Dim fecha_ns As String = fecha_ns_()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSIngresaOrden").ToString()
        Dim parametro_item As String = ""
        Dim items_() As String = items.Split(",")
        Dim anios_() As String = anios.Split(",")
        Dim iva_() As String = iva.Split(",")
        Dim subtotal_() As String = subtotal.Split(",")
        Dim total_() As String = total.Split(",")
        Dim id_tarjeta As String = id_tarjeta_ns(meses, id_emisor_ns, id_metodo_pago)
        ejecutivas = ejecutivas.Replace(",", "")
        For i As Integer = 0 To items_.Count - 1
            Dim parametroitem As String = ConfigurationManager.AppSettings.Get("NSParamCatITEM").ToString()
            Dim retorno_item As DataTable = ClaseConexionNetsuite.ConsultaNS("1070", String.Format(parametroitem, items_(i)))
            Dim descripcion_item As String = retorno_item.Rows(0).Item("TipoTransaccion")
            Dim parametroitm3 As String = "||""item"": ""{0}"",""cantidad"": ""{1}"",""ubicacion"": ""{2}"",""unidad"": ""{3}"",""nivelPrecio"": ""{4}"",""precio"": ""{5}"",""monto"": ""{6}"",""codigoImpuesto"": ""{7}"",""importeImpuesto"": ""{8}"",""importeBruto"": ""{9}"",""descripcion"": ""{10}"",""transmision"": ""{11}"",""undcobertura"": ""{12}"",""clienteMonitoreo"": ""{13}""|!"
            parametroitm3 = String.Format(parametroitm3, items_(i), "1", ubicacion, "2", "-1", subtotal_(i), subtotal_(i), codigo_iva, iva_(i), total_(i), descripcion_item, "12", "2", "")
            parametro_item = parametro_item & IIf(parametro_item <> "", ",", "") & parametroitm3
        Next
        Dim parametro As String = "||""accion"": ""{0}"",""cliente"": ""{1}"",""bien"": ""{2}"",""fecha"": ""{3}"",""numeroOperacion"": ""{4}"",""nota"": ""{5}"",""representanteVenta"": ""{6}"",""centroCosto"": ""{7}"",""ubicacion"": ""{8}"",""aprobacionventa"": ""{9}"",""aprobacioncartera"": ""{10}"",""formapago"": ""{11}"",""novedades"": ""{12}"",""consideracionTecnica"": ""{13}"",""origen"": ""{18}"",""ejecutivagestion"": ""{14}"",""ejecutivareferencia"": ""{15}"",""clientefacturar"": ""{16}"",""aprobar"": ""{19}"",""items"":[{17}]|!"
        parametro = String.Format(parametro, "ordendeservicio", usuario_ns, vehiculo, fecha_ns, "", "HunterOnline", ejecutivas, "", ubicacion, "1", "1",
                                  formapago, "Generado desde HunterOnline", "", ejecutivas, ejecutivas, clientefacturar, parametro_item, "22", "B")

        parametro = parametro.Replace("||", "{").Replace("|!", "}")
        Dim retorno As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro, 1)
        OrdenPagoAdapter.ActualizaPagoRelacionNS(orden_id, retorno, vehiculo, "REN", "CREACION DE DATOS EN NETSUITE - ORDEN SERVICIO")

        If retorno.Contains("ordendeservicio") Then
            Dim ordengenerada_ns As String = retorno.Replace(Chr(34), "")
            ordengenerada_ns = retorno.Substring(retorno.IndexOf("response") + 10, 10)
            ordengenerada_ns = ordengenerada_ns.Substring(0, ordengenerada_ns.IndexOf(","))
            id_script = ConfigurationManager.AppSettings.Get("NSIngresaDeposito").ToString()
            Dim parametro_ns As String = ConfigurationManager.AppSettings.Get("NSParamInsertDeposito").ToString()
            Dim mensaje_deposito As String = String.Format("Hunter Online - Depósito cliente C-EC-{0} {1}", usuario_3s, extrae_nombre(usuario_ns))
            parametro_ns = String.Format(parametro_ns, "198", usuario_3s, valor_total, mensaje_deposito, id_metodo_pago, fecha_ns, "14",
                                            extrae_oficina(usuario_ns), "2", "OPERAD", "HT", meses, "true", bin, orden_id, "",
                                            id_emisor_ns, mensaje_deposito)
            parametro_ns = "{" & parametro_ns & "}"
            Dim pago_ns As String = CobroAdapter.GeneraCobroClienteNs(id_script, parametro_ns)
            OrdenPagoAdapter.ActualizaPagoRelacionNS(orden_id, pago_ns, vehiculo, "REN", "CREACION DE DATOS EN NETSUITE - DEPOSITO")
            If pago_ns <> "" Then
                Dim parametro_facns As String = ConfigurationManager.AppSettings.Get("NSParamInsertfactura").ToString()
                id_script = ConfigurationManager.AppSettings.Get("NSIngresaOrden").ToString()
                parametro_facns = String.Format(parametro_facns, "factura", ordengenerada_ns)
                parametro_facns = "{" & parametro_facns & "}"
                Dim facturacion As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro_facns, 1)
                OrdenPagoAdapter.ActualizaPagoRelacionNS(orden_id, facturacion, vehiculo, "REN", "CREACION DE DATOS EN NETSUITE - FACTURA")
                If facturacion.Contains("factura") Then
                    Dim facturagenerada_ns As String = facturacion.Replace(Chr(34), "")
                    facturagenerada_ns = facturacion.Substring(facturacion.IndexOf("response") + 10, 10)
                    facturagenerada_ns = facturagenerada_ns.Substring(0, facturagenerada_ns.IndexOf(","))
                    mensaje_deposito = mensaje_deposito.Replace("Depósito", "Aplicación Depósito")
                    Dim parametro_aplica As String = ConfigurationManager.AppSettings.Get("NSParamAplicaDeposito").ToString()
                    id_script = ConfigurationManager.AppSettings.Get("NSAplicaDeposito").ToString()
                    parametro_aplica = String.Format(parametro_aplica, pago_ns, facturagenerada_ns, usuario_ns, "2",
                                                     valor_total, mensaje_deposito, "2", "14", extrae_oficina(usuario_ns))
                    parametro_aplica = "{" & parametro_aplica & "}"
                    Dim aplica_ns As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro_aplica, 1)
                    aplica_ns = aplica_ns.Replace(Chr(34), "")
                    OrdenPagoAdapter.ActualizaPagoRelacionNS(orden_id, aplica_ns, vehiculo, "REN", "CREACION DE DATOS EN NETSUITE - APLICACION")
                End If
            End If
        End If
        EMailHandler.EMailProcesoPago(asunto_mail("6", "OS NETSUITE OK", orden_id), Nothing, iphost, iphost)
    End Sub

    Public Shared Sub genera_cobro(orden_id As String, usuario_3s As String, usuario_ns As String, total As String, id_metodo_pago As String, id_orden_vpos As String,
                             id_emisor_ns As String, iphost As String, ByVal meses As String, bin As String, meses_n As String)
        Dim fecha_ns As String = fecha_ns_()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSIngresaDeposito").ToString()
        Dim parametro_ns As String = ConfigurationManager.AppSettings.Get("NSParamInsertDeposito").ToString()
        Dim mensaje_deposito As String = String.Format("Hunter Online - Depósito cliente C-EC-{0} {1}", usuario_3s, extrae_nombre(usuario_ns))
        Dim id_tarjeta As String = id_tarjeta_ns(meses, id_emisor_ns, id_metodo_pago)

        parametro_ns = String.Format(parametro_ns, "198", usuario_3s, total, mensaje_deposito, id_tarjeta, fecha_ns, "14",
                                            extrae_oficina(usuario_ns), "2", "OPERAD", "HT", meses, "true", bin, id_orden_vpos, "",
                                            id_emisor_ns, mensaje_deposito)
        parametro_ns = "{" & parametro_ns & "}"
        Dim pago_ns As String = CobroAdapter.GeneraCobroClienteNs(id_script, parametro_ns)
        OrdenPagoAdapter.ActualizaPagoRelacionNS(orden_id, pago_ns, 0, "COB", "CREACION DE DATOS EN NETSUITE - DEPOSITO")
        If pago_ns <> "" Then
            EMailHandler.EMailProcesoPago(asunto_mail("5", "TRAMAS DE COBROS OK", orden_id), Nothing, iphost, iphost)
        Else
            EMailHandler.EMailProcesoPago(asunto_mail("5", "ERROR EN TRAMAS DE COBROS", orden_id), Nothing, iphost, iphost)
            Exit Sub
        End If
    End Sub

    Public Shared Sub genera_venta(DTSetInfoURLTecnico As DataTable, orden_id As String, iva As Decimal, subtotal As Decimal, ByVal item As String,
                             ByVal usuario_ns As String, ByVal vehiculo As String, ByVal fecha As String,
                             ByVal ejecutiva As String, ByVal total As String, ByVal usuario_3s As String, ByVal id_metodo_pago As String,
                             ByVal id_orden_vpos As String, ByVal id_emisor_ns As String, iphost As String)
        Dim taller As Integer = DTSetInfoURLTecnico.Rows(14)("datatecnica")
        Dim fecha_tur As Date = DTSetInfoURLTecnico.Rows(15)("datatecnica")
        Dim hora As String = DTSetInfoURLTecnico.Rows(16)("datatecnica")
        Dim ubicacion As String = extrae_oficina(usuario_ns)
        'Dim dtDatos As DataSet
        'If VentasAdapter.GeneraOrdenServicio(orden_id, hora, fecha_tur.ToShortDateString, taller) Then
        '    EMailHandler.EMailProcesoPago(asunto_mail("5", "OS VENTA GENERADA", orden_id), Nothing, iphost, iphost)
        '    dtDatos = VentasAdapter.ConsultaDatosVenta(orden_id, usuario_3s, 6)
        '    If dtDatos.Tables(0).Rows.Count > 0 And taller > 0 Then
        '        Dim placa As String = dtDatos.Tables(0).Rows(0)("PLACA")
        '        Dim ordens As String = dtDatos.Tables(0).Rows(0)("ORDEN_SERVICIO_ID")
        '        Dim turno As String = dtDatos.Tables(0).Rows(0)("TURNO")
        '        Dim ciudad As String = dtDatos.Tables(0).Rows(0)("CIUDAD")
        '        Dim direccion As String = dtDatos.Tables(0).Rows(0)("DIRECCION")
        '        Dim objmail1 As New MailTrabajos
        '        objmail1.MailAvisoTurno(fecha_tur.ToString("dd/MMM/yyyy"), hora, ciudad, "", "Ventas", "", "", placa, True,
        '                                False, False, ciudad, direccion, turno, ordens, usuario_3s, "Instalacion", 0, "")
        '        EMailHandler.EMailProcesoPago(asunto_mail("5", "EMAIL TURNO ENVIADO", orden_id), Nothing, iphost, iphost)
        '    Else
        '        FormularioAdapter.RegistroLog(19, usuario_3s, 1, "Venta - Mail de turno no se pudo enviar")
        '    End If

        '    EMailHandler.EMailProcesoPago(asunto_mail("5", "OS REN GENERADA", orden_id), Nothing, iphost, iphost)
        '    Dim id_script As String = ConfigurationManager.AppSettings.Get("NSIngresaOrden").ToString()
        '    Dim parametroitm3 As String = ConfigurationManager.AppSettings.Get("NSParamInsertOSitem3").ToString()
        '    parametroitm3 = String.Format(parametroitm3, item, "1", ubicacion, "2", "1", subtotal, subtotal, "10", iva, total, item)
        '    Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamInsertOS").ToString()
        '    parametro = String.Format(parametro, "ordendeservicio", usuario_ns, vehiculo, fecha, "", "HunterOnline", ejecutiva, "", ubicacion, "", "1", "1", parametroitm3)
        '    parametro = parametro.Replace("||", "{").Replace("|!", "}")
        '    Dim retorno As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro, 1)

        '    If retorno.Contains("ordendeservicio") Then
        '        id_script = ConfigurationManager.AppSettings.Get("NSIngresaDeposito").ToString()
        '        Dim parametro_ns As String = ConfigurationManager.AppSettings.Get("NSParamInsertDeposito").ToString()
        '        Dim mensaje_deposito As String = String.Format("Hunter Online - Depósito cliente C-EC-{0} {1}", usuario_3s, extrae_nombre(usuario_ns))
        '        Dim fecha_ns As String = fecha_ns_()

        '        parametro_ns = String.Format(parametro_ns, "67", usuario_3s, total, mensaje_deposito, id_metodo_pago, fecha_ns, "14",
        '                                    extrae_oficina(usuario_ns), "2", "OPERAD", "HT", "12M", "true", "123491234", id_orden_vpos, "",
        '                                    id_emisor_ns, mensaje_deposito)
        '        parametro_ns = "{" & parametro_ns & "}"
        '        Dim pago_ns As String = CobroAdapter.GeneraCobroClienteNs(id_script, parametro_ns)
        '        OrdenPagoAdapter.ActualizaPagoRelacionNS(orden_id, pago_ns, 0, "VEN")
        '    End If
        '    EMailHandler.EMailProcesoPago(asunto_mail("6", "OS NETSUITE", orden_id), Nothing, iphost, iphost)
        'End If
    End Sub

    Public Shared Function extrae_oficina(id_cliente As String) As String
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

    Public Shared Function extrae_nombre(id_cliente As String) As String
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

    Public Shared Function fecha_ns_() As String
        Dim anio As String = Date.Now.Year.ToString
        Dim mes As String = Date.Now.Month.ToString
        Dim dia As String = Date.Now.Day.ToString
        mes = IIf(mes.Length = 1, "0", "") & mes
        dia = IIf(dia.Length = 1, "0", "") & dia

        Dim retorno As String = String.Format("{0}/{1}/{2}", anio, mes, dia)
        Return retorno
    End Function

    Public Shared Function asunto_mail(ByVal num_mail As String, ByVal tipo As String, ByVal orden As String) As String
        Dim resultado As String = ""
        resultado = String.Format("EMAIL {0}ºº {1} ENVIADO // Paymentez({2})", num_mail, tipo, orden)
        Return resultado
    End Function

    Public Shared Function id_tarjeta_ns(meses As String, id_emisor As Integer, tarjeta As Integer) As Integer
        Dim retorno As Integer = 0
        If tarjeta = 47 Or tarjeta = 23 Then
            retorno = 47
        End If
        If id_emisor = 1 Then
            retorno = 7
        End If
        meses = meses.Replace("M", "")
        If meses = "1" Then
            If id_emisor = 2 Then
                retorno = 15
            ElseIf id_emisor = 3 Then
                retorno = 22
            ElseIf id_emisor = 4 Then
                retorno = 42
            End If
        ElseIf meses = "3" Then
            If id_emisor = 2 Then
                retorno = 16
            ElseIf id_emisor = 3 Then
                retorno = 89
            ElseIf id_emisor = 4 Then
                retorno = 54
            End If
        ElseIf meses = "6" Then
            If id_emisor = 2 Then
                retorno = 16
            ElseIf id_emisor = 3 Then
                retorno = 89
            ElseIf id_emisor = 4 Then
                retorno = 55
            End If
        ElseIf meses = "9" Then
            If id_emisor = 2 Then
                retorno = 16
            ElseIf id_emisor = 3 Then
                retorno = 89
            ElseIf id_emisor = 4 Then
                retorno = 93
            End If
        ElseIf meses = "12" Then
            If id_emisor = 2 Then
                retorno = 16
            ElseIf id_emisor = 3 Then
                retorno = 89
            ElseIf id_emisor = 4 Then
                retorno = 81
            End If
        Else
            If id_emisor = 2 Then
                retorno = 16
            ElseIf id_emisor = 3 Then
                retorno = 89
            ElseIf id_emisor = 4 Then
                retorno = 81
            End If
        End If

        Return retorno
    End Function

End Class