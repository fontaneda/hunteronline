Public Class clsPagos

    Public Shared Function ConsultaTransaccion(ByVal orden_id As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 18)
            base.AddParrameter("@ORDENSEC", orden_id)
            ds = base.Consulta("dbo.SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


End Class
