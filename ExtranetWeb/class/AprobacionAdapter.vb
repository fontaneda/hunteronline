Public Class AprobacionAdapter

    Public Shared Function ConsultaDatos(ByVal proceso As String, ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@USUARIO_ID", usuario)
            ds = base.Consulta("Extranet.EXT_SP_APROBACION_PRECIO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaAprobaciones(ByVal ejecutiva As String, ByVal cliente As String, ByVal estado As String,
                                                ByVal usuario As String, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 1)
            base.AddParrameter("@CODIGO_EJECUTIVA", ejecutiva)
            base.AddParrameter("@CODIGO_CLIENTE", cliente)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@ESTADO", estado)
            base.AddParrameter("@FECHA_INI", fechaini)
            base.AddParrameter("@FECHA_FIN", fechafin)
            ds = base.Consulta("Extranet.EXT_SP_APROBACION_PRECIO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultarDatos(ByVal vehiculo As String, ByVal cliente As String, ByVal opcion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", opcion)
            base.AddParrameter("@CODIGO_VEHICULO", vehiculo)
            base.AddParrameter("@CODIGO_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_APROBACION_PRECIO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Sub EjecutarProcesoPrecio(ByVal cliente As String, ByVal vehiculo As String, ByVal usuario As String, ByVal tipo As String, ByVal proceso As String)
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
            base.ProcedureName = "Extranet.EXT_SP_APROBACION_PRECIO"
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CODIGO_CLIENTE", cliente)
            base.AddParrameter("@CODIGO_VEHICULO", vehiculo)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@TIPO_TRANSACCION", tipo)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub


    Public Shared Sub GuardarPrecio(ByVal cliente As String, ByVal vehiculo As String, ByVal usuario As String,
                                    ByVal tipo As String, ByVal proceso As String, ByVal fecha As String,
                                    ByVal valor As Double, ByVal producto As String, ByVal origen As String)
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
            base.ProcedureName = "Extranet.EXT_SP_APROBACION_PRECIO"
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CODIGO_CLIENTE", cliente)
            base.AddParrameter("@CODIGO_VEHICULO", vehiculo)
            base.AddParrameter("@FECHA_INI", fecha)
            base.AddParrameter("@TIPO_TRANSACCION", tipo)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@VALOR", valor)
            base.AddParrameter("@PRODUCTO", producto)
            base.AddParrameter("@ORIGEN", origen)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

End Class
