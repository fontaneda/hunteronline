Public Class FormularioAdapter


    Public Shared Sub RegistroLogFormulario(ByVal formularioid As Integer, ByVal usuarioid As String, ByVal fase As String, ByVal comentario As String, ip As String)
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
            base.ProcedureName = "DBO.SP_LOG_FORMULARIO_EXTRANET"
            base.AddParrameter("@FORMULARIO_ID", formularioid)
            base.AddParrameter("@USUARIO_ID", usuarioid)
            base.AddParrameter("@FASE", fase)
            base.AddParrameter("@COMENTARIO", comentario)
            base.AddParrameter("@IPREMOTA", ip)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub


    Public Shared Sub RegistroLog(ByVal tipotransaccion As String, ByVal usuarioid As String, ByVal proceso As Integer)
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
            base.ProcedureName = "Extranet.ext_sp_gestiona_transacciones"
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@USUARIO_ID", usuarioid)
            base.AddParrameter("@TIPO_TRANSACCION_ID ", tipotransaccion)
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            Throw ex
        End Try
    End Sub


    Public Shared Sub RegistroLog(ByVal tipotransaccion As String, ByVal usuarioid As String, ByVal proceso As Integer, ByVal descripcion As String)
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
            base.ProcedureName = "Extranet.ext_sp_gestiona_transacciones"
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@USUARIO_ID", usuarioid)
            base.AddParrameter("@TIPO_TRANSACCION_ID ", tipotransaccion)
            base.AddParrameter("@DESCRIPCION ", descripcion)
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            Throw ex
        End Try
    End Sub

End Class