Public Class ConciliacionPagoAdapter

    Public Shared Function ConsultaDataCsvConciliacion(ByVal rucEmpresa As String, ByVal fecha As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@RUCEMPRESA", rucEmpresa)
            base.AddParrameter("@FECHA", fecha)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CONCILIACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

End Class