Public Class EstadoCuentaAdapter

    Public Shared Function ConsultaEstadosCuenta(ByVal cliente As String, ByVal fechadesde As String, ByVal fechahasta As String, _
                                                 ByVal documento As String, ByVal opcion As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@FECHA_INI", fechadesde)
            base.AddParrameter("@FECHA_FIN", fechahasta)
            base.AddParrameter("@CLIENTE", cliente)
            base.AddParrameter("@DOCUMENTO", documento)
            ds = base.Consulta("EXTRANET.MANTENIMIENTO_ESTADO_CUENTA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

End Class
