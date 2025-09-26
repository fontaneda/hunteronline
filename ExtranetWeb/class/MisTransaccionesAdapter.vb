Public Class MisTransaccionesAdapter


    Public Shared Function ConsultaTipoTransaccion() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 6)
            ds = base.Consulta("EXTRANET.ext_sp_gestiona_transacciones")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaTransacciones(ByVal usuario As String, ByVal tipotrans As Integer, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 2)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@TIPO_TRANSACCION_ID", tipotrans)
            base.AddParrameter("@FECHA_INI", fechaini)
            base.AddParrameter("@FECHA_FIN", fechafin)
            ds = base.Consulta("Extranet.ext_sp_gestiona_transacciones")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaDetallecontipo(ByVal usuario As String, ByVal tipotrans As Integer, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 3)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@TIPO_TRANSACCION_ID", tipotrans)
            base.AddParrameter("@FECHA_INI", fechaini)
            base.AddParrameter("@FECHA_FIN", fechafin)
            ds = base.Consulta("Extranet.ext_sp_gestiona_transacciones")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaDetallesintipo(ByVal usuario As String, ByVal tipotrans As Integer, ByVal fecha As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 4)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@TIPO_TRANSACCION_ID", tipotrans)
            base.AddParrameter("@FECHACONS", fecha)
            ds = base.Consulta("Extranet.ext_sp_gestiona_transacciones")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


End Class
