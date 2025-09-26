Public Class CobroAdapter

    Public Shared Function ConsultaProductoCliente(ByVal cliente As String, ByVal filtrolike As String, _
                                                   ByVal fecha_ini As String, ByVal fecha_fin As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 1)
            base.AddParrameter("@CLIENTE", cliente)
            base.AddParrameter("@FECHA_INI", fecha_ini)
            base.AddParrameter("@FECHA_FIN", fecha_fin)
            If Not String.IsNullOrEmpty(filtrolike) Then
                filtrolike = "%" + filtrolike + "%"
                base.AddParrameter("@FILTROLIKE", filtrolike)
            End If
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_COBRO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

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
            base.EjecutaTransaction(cmd, tran)
            
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

    Public Shared Function GeneraCobroCliente(ByVal orden_id As String) As Boolean
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
            base.ProcedureName = "EXTRANET.EXT_SP_CONSULTA_COBRO"
            base.AddParrameter("@PROCESO", 2)
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@SUCURSAL", "001")
            base.AddParrameter("@ORDENID", orden_id)
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

    Public Shared Function GeneraCobroClienteNs(ByVal script_id As String, parametro As String) As String
        Dim retorno As String = ClaseConexionNetsuite.IngresaNs(script_id, parametro, "2")
        Return retorno
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 26/05/2020
    ''' DESCR: PROCEDIMIENTO PARA EL ENVIO DE MAIL
    ''' </summary>
    ''' <param name="Proceso"></param>
    ''' <param name="OrdenId"></param>
    ''' <remarks></remarks>
    Public Function EnvioEmailConfirmaciónPago(ByVal proceso As String, ByVal ordenId As Decimal) As String
        EnvioEmailConfirmaciónPago = ""
        Try
            Dim emailBody, emailBodyCopias As String
            Dim emailAddres, emailAddresCopias As String
            Dim dTCstGeneral, dTCstGeneralCopias As New System.Data.DataSet

            'ENVIA EMAIL A CLIENTE
            dTCstGeneral = ConsultaEmail(ordenId, proceso, True)
            emailBody = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("HTMLBODY"))
            emailAddres = Convert.ToString(dTCstGeneral.Tables(0).Rows(0)("BILLINGEMAIL"))
            EMailConfirmacionPagoCliente(emailBody, emailAddres, proceso)

            'ENVIA MAIL COPIAS
            dTCstGeneralCopias = ConsultaEmail(ordenId, proceso, False)
            emailBodyCopias = Convert.ToString(dTCstGeneralCopias.Tables(0).Rows(0)("HTMLBODY"))
            emailAddresCopias = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC")
            EMailConfirmacionPagoCliente(emailBodyCopias, emailAddresCopias, proceso)
            EnvioEmailConfirmaciónPago = "Envío de email correcto"
        Catch ex As Exception
            EnvioEmailConfirmaciónPago = "Ocurrió un error al enviar el email de confirmación"
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Public Shared Function ConsultaEmail(ByVal orden As Decimal, ByVal proceso As String, ByVal escliente As Boolean) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@ORDEN", orden)
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@ESCLIENTE", IIf(escliente, "1", "0"))
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_EMAIL_COBRO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Sub EMailConfirmacionPagoCliente(ByVal mensaje As String, ByVal mailTo As String, ByVal proceso As String)
        Try
            Dim asunto As String
            If proceso = "100" Then
                asunto = "Confirmación de monto abonado Online realizado desde el aplicativo HunterOnline"
            ElseIf proceso = "300" Then
                asunto = "Monto abonado pendiente de Pago Online realizado desde el aplicativo HunterOnline"
            Else
                asunto = "Cancelación/Reverso de monto abonado Online realizado desde el aplicativo HunterOnline"
            End If
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString()
            Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
            'Dim MailToBcc As String = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, mailToBcc, String.Empty, String.Empty, asunto, mensaje, True)
        Catch ex As Exception
        End Try
    End Sub

End Class
