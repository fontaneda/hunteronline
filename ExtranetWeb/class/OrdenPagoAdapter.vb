Public Class OrdenPagoAdapter

    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: FUNCIÓN PARA OBTENER EL SECUENCIAL DE LA ORDEN DE PAGO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaSecuenciaOrdenPago() As Decimal
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Dim ordenId As Decimal
        Try
            base.AddParrameter("@PROCESO", "100")
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_ORDEN_PAGO")
            ordenId = Convert.ToDecimal(ds.Tables(0).Rows(0)("SECUENCIA_ORDEN_PAGO"))
        Catch ex As Exception
            Throw ex
        End Try
        Return ordenId
    End Function

    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: FUNCIÓN PARA OBTENER EL SECUENCIAL DE LA ORDEN DE PAGO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaPorcentajeIva() As Decimal
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Dim IVA As Decimal = 0
        Try
            base.AddParrameter("@PROCESO", "106")
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_ORDEN_PAGO")
            IVA = Convert.ToDecimal(ds.Tables(0).Rows(0)("PORCENTAJE_IVA"))
        Catch ex As Exception
            Throw ex
        End Try
        Return IVA
    End Function

    Public Shared Function ConsultaTransaccionesPendientes() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "107")
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_ORDEN_PAGO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: REGISTRO DE PAGO ONLINE
    ''' </summary>
    ''' <param name="OrdenEntity"></param>
    ''' <remarks></remarks>
    Public Shared Sub RegistroPagoOnline(ByVal ordenEntity As OrdenEntity)
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
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@ORDENID", ordenEntity.OrdenId)
            base.AddParrameter("@CLIENTEID", ordenEntity.ClienteId)
            base.AddParrameter("@NUMEROMESES", ordenEntity.NumeroMeses)
            base.AddParrameter("@TIPOTARJETA", ordenEntity.TipoTarjeta)
            base.AddParrameter("@SUBTOTAL", ordenEntity.SubTotal)
            base.AddParrameter("@IVA", ordenEntity.Iva)
            base.AddParrameter("@ICE", ordenEntity.Ice)
            base.AddParrameter("@INTERESES", ordenEntity.Interes)
            base.AddParrameter("@TOTAL", ordenEntity.Total)
            base.AddParrameter("@TIPOPAGO", ordenEntity.TipoPago)
            base.AddParrameter("@TIPOCREDITO", ordenEntity.TipoCredito)
            base.AddParrameter("@CODIGOCONFPAGO", ordenEntity.CodigoConfPago)
            base.AddParrameter("@FACTURANOMBRE", ordenEntity.BillingName)
            base.AddParrameter("@FACTURAIDENTF", ordenEntity.BillingCedula)
            base.AddParrameter("@FACTURADIRECC", ordenEntity.BillingAddress)
            base.AddParrameter("@FACTURATELF", ordenEntity.BillingPhone)
            base.AddParrameter("@FACTURAMOVIL", ordenEntity.BillingMovil)
            base.AddParrameter("@FACTURAEMAIL", ordenEntity.BillingEmail)
            base.AddParrameter("@FACTURATIPOTARJ", ordenEntity.BillingCardType)
            base.AddParrameter("@ESTADOORDEN", ordenEntity.EstadoWebId)
            base.AddParrameter("@USERID", ordenEntity.UsuarioProcesoId)
            base.AddParrameter("@EMISOR_ID", ordenEntity.idemisor)
            base.AddParrameter("@ACCION_COMERCIAL", ordenEntity.AccionComercial)
            base.AddParrameter("@CLIENTE_MONITOREO", ordenEntity.ClienteMonitoreo)
            base.AddParrameter("@USUARIO_SOPORTE", ordenEntity.UsuarioSoporte)

            Dim accioncomercial As String = ordenEntity.AccionComercial
            ' POR DEBITO AUTOMATICO GALVAR
            '*base.AddParrameter("@TARJETA_DA", ordenEntity.tarjeta_da)
            '*base.AddParrameter("@EXPIRA_TARJETA_DA", ordenEntity.expira_tarjeta_da)
            base.EjecutaTransaction(cmd, tran)
            For Each ordenDetalleEntity As OrdenDetalleEntity In ordenEntity.OrdenDetalleEntityCollection
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
                base.AddParrameter("@PROCESO", "102")
                base.AddParrameter("@ORDENID", ordenDetalleEntity.OrdenId)
                base.AddParrameter("@ORDENDETALLEID", ordenDetalleEntity.OrdenDetalleId)
                base.AddParrameter("@VEHICULOID", ordenDetalleEntity.VehiculoId)
                base.AddParrameter("@TRANSACCIONID", ordenDetalleEntity.TransaccionId)
                base.AddParrameter("@FECHAVENCIMIENTO", ordenDetalleEntity.FechaVencimiento)
                base.AddParrameter("@ANIOS", ordenDetalleEntity.Anios)
                base.AddParrameter("@VALORANUAL", ordenDetalleEntity.ValorAnual)
                base.AddParrameter("@CODIGOPROMOCION", ordenDetalleEntity.CodigoPromocion)
                base.AddParrameter("@VALORPROMOCION", ordenDetalleEntity.ValorPromocion)
                base.AddParrameter("@PORCENTAJEDESCUENTO", ordenDetalleEntity.PorcentajeDescuento)
                base.AddParrameter("@DESCUENTO", ordenDetalleEntity.Descuento)
                base.AddParrameter("@SUBTOTAL", ordenDetalleEntity.SubTotal)
                base.AddParrameter("@IVA", ordenDetalleEntity.Iva)
                base.AddParrameter("@TOTAL", ordenDetalleEntity.Total)
                base.AddParrameter("@MARCADOLOJACK", ordenDetalleEntity.MarcadoLojack)
                base.AddParrameter("@USERID", ordenDetalleEntity.UsuarioProcesoId)
                base.AddParrameter("@ESDEBITO", ordenDetalleEntity.EsDebito)
                base.AddParrameter("@FECHAINIDEBITO", ordenDetalleEntity.Fecha_Ini_Debito)
                base.AddParrameter("@FECHAFINDEBITO", ordenDetalleEntity.Fecha_Fin_Debito)
                base.AddParrameter("@PRODUCTODA", ordenDetalleEntity.Producto_Debito)
                base.AddParrameter("@ACCION_COMERCIAL", ordenEntity.AccionComercial)
                base.AddParrameter("@ITEM", ordenDetalleEntity.Item)
                base.AddParrameter("@EJECUTIVA", ordenDetalleEntity.Ejecutiva)
                base.EjecutaTransaction(cmd, tran)
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

    Public Shared Sub RegistroPagoOnlineFormaPago(ByVal ordenEntity As OrdenEntity, ByVal forma As DataTable)
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
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@ORDENID", ordenEntity.OrdenId)
            base.AddParrameter("@CLIENTEID", ordenEntity.ClienteId)
            base.AddParrameter("@NUMEROMESES", ordenEntity.NumeroMeses)
            base.AddParrameter("@TIPOTARJETA", ordenEntity.TipoTarjeta)
            base.AddParrameter("@SUBTOTAL", ordenEntity.SubTotal)
            base.AddParrameter("@IVA", ordenEntity.Iva)
            base.AddParrameter("@ICE", ordenEntity.Ice)
            base.AddParrameter("@INTERESES", ordenEntity.Interes)
            base.AddParrameter("@TOTAL", ordenEntity.Total)
            base.AddParrameter("@TIPOPAGO", ordenEntity.TipoPago)
            base.AddParrameter("@TIPOCREDITO", ordenEntity.TipoCredito)
            base.AddParrameter("@CODIGOCONFPAGO", ordenEntity.CodigoConfPago)
            base.AddParrameter("@FACTURANOMBRE", ordenEntity.BillingName)
            base.AddParrameter("@FACTURAIDENTF", ordenEntity.BillingCedula)
            base.AddParrameter("@FACTURADIRECC", ordenEntity.BillingAddress)
            base.AddParrameter("@FACTURATELF", ordenEntity.BillingPhone)
            base.AddParrameter("@FACTURAMOVIL", ordenEntity.BillingMovil)
            base.AddParrameter("@FACTURAEMAIL", ordenEntity.BillingEmail)
            base.AddParrameter("@FACTURATIPOTARJ", ordenEntity.BillingCardType)
            base.AddParrameter("@ESTADOORDEN", ordenEntity.EstadoWebId)
            base.AddParrameter("@USERID", ordenEntity.UsuarioProcesoId)
            base.AddParrameter("@EMISOR_ID", ordenEntity.idemisor)
            base.AddParrameter("@ACCION_COMERCIAL", ordenEntity.AccionComercial)
            base.AddParrameter("@CLIENTE_MONITOREO", ordenEntity.ClienteMonitoreo)
            base.AddParrameter("@USUARIO_SOPORTE", ordenEntity.UsuarioSoporte)
            Dim accioncomercial As String = ordenEntity.AccionComercial
            ' POR DEBITO AUTOMATICO GALVAR
            '*base.AddParrameter("@TARJETA_DA", ordenEntity.tarjeta_da)
            '*base.AddParrameter("@EXPIRA_TARJETA_DA", ordenEntity.expira_tarjeta_da)
            base.EjecutaTransaction(cmd, tran)
            For Each ordenDetalleEntity As OrdenDetalleEntity In ordenEntity.OrdenDetalleEntityCollection
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
                base.AddParrameter("@PROCESO", "102")
                base.AddParrameter("@ORDENID", ordenDetalleEntity.OrdenId)
                base.AddParrameter("@ORDENDETALLEID", ordenDetalleEntity.OrdenDetalleId)
                base.AddParrameter("@VEHICULOID", ordenDetalleEntity.VehiculoId)
                base.AddParrameter("@TRANSACCIONID", ordenDetalleEntity.TransaccionId)
                base.AddParrameter("@FECHAVENCIMIENTO", ordenDetalleEntity.FechaVencimiento)
                base.AddParrameter("@ANIOS", ordenDetalleEntity.Anios)
                base.AddParrameter("@VALORANUAL", ordenDetalleEntity.ValorAnual)
                base.AddParrameter("@CODIGOPROMOCION", ordenDetalleEntity.CodigoPromocion)
                base.AddParrameter("@VALORPROMOCION", ordenDetalleEntity.ValorPromocion)
                base.AddParrameter("@PORCENTAJEDESCUENTO", ordenDetalleEntity.PorcentajeDescuento)
                base.AddParrameter("@DESCUENTO", ordenDetalleEntity.Descuento)
                base.AddParrameter("@SUBTOTAL", ordenDetalleEntity.SubTotal)
                base.AddParrameter("@IVA", ordenDetalleEntity.Iva)
                base.AddParrameter("@TOTAL", ordenDetalleEntity.Total)
                base.AddParrameter("@MARCADOLOJACK", ordenDetalleEntity.MarcadoLojack)
                base.AddParrameter("@USERID", ordenDetalleEntity.UsuarioProcesoId)
                base.AddParrameter("@ACCION_COMERCIAL", ordenEntity.AccionComercial)
                ' POR DEBITO AUTOMATICO GALVAR
                '*base.AddParrameter("@ESDEBITO", ordenDetalleEntity.EsDebito)
                '*base.AddParrameter("@FECHAINIDEBITO", ordenDetalleEntity.Fecha_Ini_Debito)
                '*base.AddParrameter("@FECHAFINDEBITO", ordenDetalleEntity.Fecha_Fin_Debito)
                '*base.AddParrameter("@PRODUCTODA", ordenDetalleEntity.Producto_Debito)
                base.EjecutaTransaction(cmd, tran)
            Next
            For i As Integer = 0 To forma.Rows.Count - 1
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
                base.AddParrameter("@PROCESO", "108")
                base.AddParrameter("@ORDENID", ordenEntity.OrdenId)
                base.AddParrameter("@VALOR", forma.Rows(i).Item("VALOR").ToString())
                base.AddParrameter("@SECUENCIA", forma.Rows(i).Item("DETALLE_ID").ToString())
                base.AddParrameter("@BANCO_ID", forma.Rows(i).Item("CODIGO_BANCO").ToString())
                base.AddParrameter("@FORMA_ID", forma.Rows(i).Item("CODIGO_FORMA").ToString())
                base.AddParrameter("@PLAZO", forma.Rows(i).Item("PLAZO").ToString())
                base.AddParrameter("@VOUCHER", forma.Rows(i).Item("VOUCHER").ToString())
                base.AddParrameter("@DOCUMENTO", forma.Rows(i).Item("DOCUMENTO").ToString())
                base.AddParrameter("@FECHA_CHEQUE", forma.Rows(i).Item("FECHA_CHEQUE").ToString())
                base.EjecutaTransaction(cmd, tran)
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: CONFIRMACION DE DATOS DE CLIENTE PARA EL PAGO
    ''' </summary>
    ''' <param name="OrdenEntity"></param>
    ''' <remarks></remarks>
    Public Shared Sub ConfirmoPagoOnline(ByVal ordenEntity As OrdenEntity)
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
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
            base.AddParrameter("@PROCESO", "103")
            base.AddParrameter("@ORDENID", ordenEntity.OrdenId)
            base.AddParrameter("@CLIENTEID", ordenEntity.ClienteId)
            base.AddParrameter("@NUMEROMESES", ordenEntity.NumeroMeses)
            base.AddParrameter("@TIPOTARJETA", ordenEntity.TipoTarjeta)
            base.AddParrameter("@SUBTOTAL", ordenEntity.SubTotal)
            base.AddParrameter("@IVA", ordenEntity.Iva)
            base.AddParrameter("@ICE", ordenEntity.Ice)
            base.AddParrameter("@INTERESES", ordenEntity.Interes)
            base.AddParrameter("@TOTAL", ordenEntity.Total)
            base.AddParrameter("@TIPOPAGO", ordenEntity.TipoPago)
            base.AddParrameter("@TIPOCREDITO", ordenEntity.TipoCredito)
            base.AddParrameter("@CODIGOCONFPAGO", ordenEntity.CodigoConfPago)
            base.AddParrameter("@FACTURANOMBRE", ordenEntity.BillingName)
            base.AddParrameter("@FACTURAIDENTF", ordenEntity.BillingCedula)
            base.AddParrameter("@FACTURADIRECC", ordenEntity.BillingAddress)
            base.AddParrameter("@FACTURATELF", ordenEntity.BillingPhone)
            base.AddParrameter("@FACTURAMOVIL", ordenEntity.BillingMovil)
            base.AddParrameter("@FACTURAEMAIL", ordenEntity.BillingEmail)
            base.AddParrameter("@FACTURATIPOTARJ", ordenEntity.BillingCardType)
            base.AddParrameter("@ESTADOORDEN", ordenEntity.EstadoWebId)
            base.AddParrameter("@USERID", ordenEntity.UsuarioProcesoId)
            base.AddParrameter("@ACCION_COMERCIAL", ordenEntity.AccionComercial)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: PROCESA ACTUALIZACION DE ESTADO DE PROCESO VPOS
    ''' </summary>
    ''' <param name="ordensec"></param>
    ''' <param name="origen"></param>
    ''' <param name="userid"></param>
    ''' <param name="estadoid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcesoActEstOrdenVpos(ByVal ordensec As Int32, ByVal origen As Integer, ByVal userid As Integer, ByVal estadoid As Integer)
        ProcesoActEstOrdenVpos = 0
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
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_PAGO"
            base.AddParrameter("@PROCESO", "104")
            base.AddParrameter("@ORDENID", ordensec)
            base.AddParrameter("@ORIGEN", origen)
            base.AddParrameter("@USERID", userid)
            base.AddParrameter("@ESTADOORDEN", estadoid)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            ProcesoActEstOrdenVpos = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <param name="estadoordenproceso"></param>
    ''' <param name="codconfirmpago"></param>
    ''' <param name="ordensec"></param>
    ''' <param name="numeromeses"></param>
    ''' <param name="tipotarjeta"></param> 
    ''' <param name="ice"></param>
    ''' <param name="intereses"></param>
    ''' <param name="total"></param>
    ''' <param name="tipocredito"></param>
    ''' <param name="userid"></param>
    ''' <param name="transaccion_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ActualizaEstadoPagoOnline(ByVal opcion As Integer, ByVal estadoordenproceso As String, ByVal codconfirmpago As String, ByVal ordensec As Int32,
                                                     ByVal numeromeses As Integer, ByVal tipotarjeta As String, ByVal ice As Decimal, ByVal intereses As Decimal,
                                                     ByVal total As Decimal, ByVal tipocredito As String, ByVal userid As String, ByVal transaccion_id As String,
                                                     ByVal banco As String, ByVal bin As String, ByVal trama As String) As Boolean
        ActualizaEstadoPagoOnline = 0
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
            base.ProcedureName = "SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE"
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@ESTADOORDENPOSPROCESO", estadoordenproceso)
            base.AddParrameter("@CODIGOCONFPAGO", codconfirmpago)
            base.AddParrameter("@ORDENSEC", ordensec)
            base.AddParrameter("@NUMEROMESES", IIf(numeromeses = 0, 1, numeromeses))
            base.AddParrameter("@TIPOTARJETA", tipotarjeta)
            base.AddParrameter("@ICE", ice)
            base.AddParrameter("@INTERESES", intereses)
            base.AddParrameter("@TOTAL", total)
            base.AddParrameter("@TIPOCREDITO", tipocredito)
            base.AddParrameter("@USERID", userid)
            base.AddParrameter("@TRANSACCION_ID", transaccion_id)
            base.AddParrameter("@BANCO", banco)
            base.AddParrameter("@BIN", bin)
            base.AddParrameter("@TRAMA", trama)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
            ActualizaEstadoPagoOnline = 1
        Catch ex As Exception
            ActualizaEstadoPagoOnline = 0
            tran.Rollback()
            Throw ex
        End Try
    End Function

    Public Shared Function ActualizaEstadoPagoOnlineCodigo(ByVal codconfirmpago As String, ByVal ordensec As String)
        ActualizaEstadoPagoOnlineCodigo = 0
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
            base.ProcedureName = "SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE"
            base.AddParrameter("@OPCION", 15)
            base.AddParrameter("@CODIGOCONFPAGO", codconfirmpago)
            base.AddParrameter("@ORDENSEC", ordensec)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            ActualizaEstadoPagoOnlineCodigo = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <param name="ordenpago"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InfoOrdenResultado(ByVal opcion As Integer, ByVal ordenpago As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@ORDENSEC", ordenpago)
            ds = base.Consulta("dbo.SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 01/02/2019
    ''' DESCR: GUARDA LO RETORNADO EN EL HEADER RESPONSE POR PARTE DE PAYMENTEZ, REQUERIMIENTO SOLICITADO POR EL EQUIPO DEL BOTON DE PAGOS
    ''' EN EL CUAL DEVUELVEN DATOS EXTRAS DE LA TRANSACCION REALIZADA
    ''' </summary>
    ''' <param name="retorno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GuardaRetornoInternoPaymentez(ByVal retorno As String)
        GuardaRetornoInternoPaymentez = 0
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
            base.ProcedureName = "SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE"
            base.AddParrameter("@OPCION", 15)
            base.AddParrameter("@RETORNO_PAYMENTEZ", retorno)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            GuardaRetornoInternoPaymentez = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 24/02/2019
    ''' DESCR: PROCESO PARA EL REEMBOLSO DE TRANSACCIONES
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Reembolso_transaccion(ByVal id As String)
        Reembolso_transaccion = 0
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
            base.ProcedureName = "SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE"
            base.AddParrameter("@OPCION", 16)
            base.AddParrameter("@CODIGOCONFPAGO", id)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            Reembolso_transaccion = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    Public Shared Function IngresaDebito(ByVal ordenid As Integer, ByVal clienteid As String, ByVal estado As String, ByVal token As String,
                                         ByVal referencia As String, ByVal tipotarjeta As String, ByVal origen As String, ByVal aliasid As String,
                                         idtarjeta As String, mensaje As String, usuarioid As String, codigo_extra As String)
        IngresaDebito = 1
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
            base.ProcedureName = "dbo.SP_INGRESA_REFERENCIA_DEBITO"
            base.AddParrameter("@CLIENTEID", clienteid)
            base.AddParrameter("@ORDEN", ordenid)
            base.AddParrameter("@ESTADO", IIf(estado = "valid", "1", IIf(estado = "review", "3", "2")))
            base.AddParrameter("@REFERENCIA", referencia)
            base.AddParrameter("@TOKEN", token)
            base.AddParrameter("@TIPO", tipotarjeta)
            base.AddParrameter("@ORIGEN", origen)
            base.AddParrameter("@ALIAS", aliasid)
            base.AddParrameter("@IDTARJETA", aliasid)
            base.AddParrameter("@MENSAJE", aliasid)
            base.AddParrameter("@USUARIO", usuarioid)
            base.AddParrameter("@CODIGO_EXTRA", codigo_extra)
            base.AddParrameter("@PROCESO", 1)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            IngresaDebito = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    Public Shared Function ConsultaTarjetasDebito(ByVal clienteid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 2)
            base.AddParrameter("@CLIENTEID", clienteid)
            ds = base.Consulta("dbo.SP_INGRESA_REFERENCIA_DEBITO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function EliminaTarjetasDebito(ByVal clienteid As String, ByVal aliasid As String, ByVal ordenid As String)
        EliminaTarjetasDebito = 0
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
            base.ProcedureName = "dbo.SP_INGRESA_REFERENCIA_DEBITO"
            base.AddParrameter("@PROCESO", 3)
            base.AddParrameter("@CLIENTEID", clienteid)
            base.AddParrameter("@REFERENCIA", aliasid)
            base.AddParrameter("@ORDEN", ordenid)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            EliminaTarjetasDebito = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    Public Shared Function ConsultaExtra(ByVal clienteid As String, secuencia As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 4)
            base.AddParrameter("@CLIENTEID", clienteid)
            base.AddParrameter("@SECUENCIA", secuencia)
            ds = base.Consulta("dbo.SP_INGRESA_REFERENCIA_DEBITO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ActualizaPagoRelacionNS(ByVal ordensec As String, trama_ns As String, vehiculo As String, accion As String, mensaje As String)
        ActualizaPagoRelacionNS = 0
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
            base.ProcedureName = "SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE"
            base.AddParrameter("@OPCION", 16)
            base.AddParrameter("@ORDENSEC", ordensec)
            base.AddParrameter("@VEHICULOID", vehiculo)
            base.AddParrameter("@ACCION_COMERCIAL", accion)
            base.AddParrameter("@RELACION_NS", trama_ns)
            base.AddParrameter("@DSC_ARC_CSV", mensaje)

            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            ActualizaPagoRelacionNS = -1
            tran.Rollback()
            Throw ex
        End Try
    End Function

    Public Shared Function VerificaRelacionNS(ByVal ordensec As String) As Boolean
        VerificaRelacionNS = 0
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 17)
            base.AddParrameter("@ORDENSEC", ordensec)
            ds = base.Consulta("dbo.SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    VerificaRelacionNS = ds.Tables(0).Rows(0).Item(0).ToString
                End If
            End If
        Catch ex As Exception
            VerificaRelacionNS = 1
            Throw ex
        End Try
        Return VerificaRelacionNS
    End Function

End Class