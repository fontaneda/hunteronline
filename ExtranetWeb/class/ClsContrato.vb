Public Class ClsContrato

    Public Shared Function DatosCliente(ByVal cliente As String, ByVal vehiculo As String, ByVal opcion As Int32, ByVal dispnombre As String, ByVal producto As String, ByVal plataforma As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@ID_CLIENTE", cliente)
            base.AddParrameter("@ID_VEHICULO", vehiculo)
            base.AddParrameter("@DISPOSITIVO", dispnombre)
            base.AddParrameter("@PLATAFORMA", plataforma)
            base.AddParrameter("@CODPRODUCTO", producto)
            ds = base.Consulta("Taller.SP_APPTALLER_CONTRATO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function



    Public Shared Function Consultacontrato(ByVal opcion As Int32, ByVal criterio As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@CRIT_BUSQ", criterio)
            ds = base.Consulta("Taller.SP_APPTALLER_CONTRATO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    ' ClsContrato.EjecutarEnvio(, , , Trim(itemc("ORDEN_SERVICIO").Text), Trim(itemc("ORDEN_TRABAJO").Text), "REEN", "2")

    Public Shared Sub EjecutarEnvio(ByVal cliente As String, ByVal vehiculo As String, ByVal grupo As String, ByVal servicio As String, ByVal trabajo As String, ByVal tipo As String, ByVal usuario As String)
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
            base.ProcedureName = "dbo.RPT_SP_EMAIL_INSTALACION_CLIENTE"
            base.AddParrameter("@ORDEN_TRABAJO", trabajo)
            base.AddParrameter("@ORDEN_SERVICIO", servicio)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@CLIENTE", cliente)
            base.AddParrameter("@GRUPO", grupo)
            base.AddParrameter("@USUARIO", usuario)
            base.AddParrameter("@TIPO", tipo)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

End Class
