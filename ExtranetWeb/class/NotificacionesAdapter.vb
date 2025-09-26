Public Class NotificacionesAdapter


    Public Shared Function ConsultaNoticaciones(ByVal usuario As String, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 1)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@FECHA_INI", fechaini)
            base.AddParrameter("@FECHA_FIN", fechafin)
            ds = base.Consulta("Extranet.EXT_SP_GESTIONA_NOTIFICACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaAvanzada(ByVal usuario As String, ByVal criterio As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 2)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@CRIT_BUSQ", criterio)
            ds = base.Consulta("Extranet.EXT_SP_GESTIONA_NOTIFICACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaHtml(ByVal codigo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 3)
            base.AddParrameter("@NOTIFICACION_ID", codigo)
            ds = base.Consulta("Extranet.EXT_SP_GESTIONA_NOTIFICACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaHtmlInicial(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 4)
            base.AddParrameter("@USUARIO_ID", usuario)
            ds = base.Consulta("Extranet.EXT_SP_GESTIONA_NOTIFICACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Sub RegistroLectura(ByVal codigo As String)
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
            base.ProcedureName = "Extranet.EXT_SP_GESTIONA_NOTIFICACION"
            base.AddParrameter("@PROCESO", 5)
            base.AddParrameter("@NOTIFICACION_ID", codigo)
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            Throw ex
        End Try
    End Sub


End Class
