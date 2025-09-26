Public Class ContactosAdapter


    Public Shared Function ConsultaCorreo(ByVal idcliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_DATOS_CONTACTOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaCorreoEjecutiva(ByVal vehiculo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "103")
            base.AddParrameter("@ID_VEHICULO", vehiculo)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_DATOS_CONTACTOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaCorreoEjecutivaSoporte(ByVal referencia As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "104")
            base.AddParrameter("@ASIGNADO", referencia)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_DATOS_CONTACTOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaMotivo() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_DATOS_CONTACTOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function Consultacliente(ByVal idcliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_DATOS_CONTACTOS_CLIENTES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function Consultaprovinciacliente(ByVal correo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@EMAIL", correo)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_DATOS_CONTACTOS_CLIENTES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Sub RegistroDatos(ByVal idcliente As String, ByVal telefono As String, ByVal asunto As String, ByVal comentario As String, ByVal destino As String)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        'Dim numcotizacion As Int64 = 0
        'Dim codigoerror As Int64 = 0
        'Dim msgerror As String = ""
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.EXT_SP_GRABA_DATOS_CONTACTOS"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@TELEFONO", telefono)
            base.AddParrameter("@ASUNTO", asunto)
            base.AddParrameter("@COMENTARIO", comentario)
            base.AddParrameter("@ASIGNADO", destino)
            ''base.AddParrameter("@FECHA_NACIMIENTO", fechanacimiento)
            'base.AddParrameter("@ORIGEN", "D")
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            Throw ex
        End Try
    End Sub


    Public Shared Sub RegistroDatosCliente(ByVal idcliente As String, ByVal email As String, ByVal asunto As String, ByVal comentario As String, ByVal destino As String)
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
            base.ProcedureName = "Extranet.EXT_SP_GRABA_DATOS_CONTACTOS_CLIENTES"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@EMAIL", email)
            base.AddParrameter("@ASUNTO", asunto)
            base.AddParrameter("@COMENTARIO", comentario)
            base.AddParrameter("@ASIGNADO", destino)
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            Throw ex
        End Try
    End Sub

End Class
