Public Class CarroCompraAdapter


    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: CONSULTA EL CARRO DE COMPRA DEL CLIENTE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaCarroCompra(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CARRO_COMPRA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: REGISTRO DEL CARRO DE COMPRA DEL CLIENTE
    ''' </summary>
    ''' <param name="OrdenEntity"></param>
    ''' <remarks></remarks>
    Public Shared Sub RegistroCarroCompra(ByVal ordenEntity As OrdenEntity)
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
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_CARRO_COMPRA"
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@CLIENTEID", OrdenEntity.ClienteId)
            base.AddParrameter("@SUBTOTAL", OrdenEntity.SubTotal)
            base.AddParrameter("@IVA", OrdenEntity.Iva)
            base.AddParrameter("@TOTAL", OrdenEntity.Total)
            base.AddParrameter("@USERID", OrdenEntity.UsuarioProcesoId)
            base.EjecutaTransaction(cmd, tran)
            For Each ordenDetalleEntity As OrdenDetalleEntity In ordenEntity.OrdenDetalleEntityCollection
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.EXT_SP_GRABA_CARRO_COMPRA"
                base.AddParrameter("@PROCESO", "101")
                base.AddParrameter("@CLIENTEID", ordenEntity.ClienteId)
                base.AddParrameter("@SECUENCIAID", ordenDetalleEntity.OrdenDetalleId)
                base.AddParrameter("@VEHICULOID", ordenDetalleEntity.VehiculoId)
                base.AddParrameter("@TRANSACCIONID", ordenDetalleEntity.TransaccionId)
                base.AddParrameter("@ANIOS", ordenDetalleEntity.Anios)
                base.AddParrameter("@VALORANUAL", ordenDetalleEntity.ValorAnual)
                base.AddParrameter("@CODIGOPROMOCION", ordenDetalleEntity.CodigoPromocion)
                base.AddParrameter("@VALORPROMOCION", ordenDetalleEntity.ValorPromocion)
                base.AddParrameter("@PORCENTAJEDESCUENTO", ordenDetalleEntity.PorcentajeDescuento)
                base.AddParrameter("@DESCUENTO", ordenDetalleEntity.Descuento)
                base.AddParrameter("@SUBTOTAL", ordenDetalleEntity.SubTotal)
                base.AddParrameter("@IVA", ordenDetalleEntity.Iva)
                base.AddParrameter("@TOTAL", ordenDetalleEntity.Total)
                base.AddParrameter("@USERID", ordenDetalleEntity.UsuarioProcesoId)
                base.EjecutaTransaction(cmd, tran)
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: ELIMINO EL CARRO DE COMPRA DEL CLIENTE
    ''' </summary>
    ''' <param name="ClienteId"></param>
    ''' <remarks></remarks>
    Public Shared Sub EliminoCarroCompra(ByVal clienteId As String)
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
            base.ProcedureName = "EXTRANET.EXT_SP_GRABA_CARRO_COMPRA"
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@CLIENTEID", clienteId)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

End Class