Public Class PromocionesAdapter

    Public Shared Function ConsultaDatos(ByVal proceso As Integer, ByVal codigoCliente As String, ByVal promocion As String, ByVal item As Int64, ByVal producto As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CLIENTE", codigoCliente)
            base.AddParrameter("@PROMOCION", promocion)
            base.AddParrameter("@ITEM", item)
            base.AddParrameter("@PRODUCTO", producto)
            ds = base.Consulta("EXTRANET.SP_CONSULTA_PROMOCIONES_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


End Class
