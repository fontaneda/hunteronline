Public Class Contraseña


    Public Shared Function VerificaUsuarioExiste(ByVal email As String, ByVal telefono As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "3")
            If telefono <> "" Then base.AddParrameter("@TELEFONO1", telefono)
            If email <> "" Then base.AddParrameter("@EMAIL1", email)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaPreguntasAleatorias(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "2")
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


    Public Shared Function VerificaComparar(ByVal cliente As String, ByVal idpregunta As String, ByVal respuesta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "1")
            base.AddParrameter("@ID_CLIENTE", cliente)
            base.AddParrameter("@PREGUNTAID", idpregunta)
            base.AddParrameter("@RESPUESTADESC", respuesta)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


    Public Shared Function GeneraLinkContrasenia() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "4")
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


    Public Shared Function GeneraEmailActivacion(ByVal idcliente As String, ByVal email As String, ByVal nombre01 As String, _
                                                 ByVal nombre02 As String, ByVal linkAct As String, ByVal clave As String, ByVal opcion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", opcion)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@NOMBRE", nombre01)
            base.AddParrameter("@APELLIDO", nombre02)
            base.AddParrameter("@LINK_ACT", linkAct)
            base.AddParrameter("@CLAVE", clave)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaClave(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "10")
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function



    Public Shared Function RegistroClaveNueva(ByVal cliente As String, ByVal claveant As String, ByVal clavenue As String) As Int64
        RegistroClaveNueva = 0
        Dim base As New DataBaseApp.CommandApp
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Dim cnn As SqlClient.SqlConnection = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.AddParrameter("@PROCESO", "11")
            base.AddParrameter("@ID_CLIENTE", cliente)
            base.AddParrameter("@CLAVE_ANT", claveant)
            base.AddParrameter("@CLAVE_NUE", clavenue)
            base.ProcedureName = "Extranet.EXT_SP_RECUPERA_CONTRASENIA"
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            RegistroClaveNueva = -1
            tran.Rollback()
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function


    Public Shared Function ConsultaPreguntasRespuestas(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "12")
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


    Public Shared Function RegistroSoporteCliente(ByVal cliente As String, ByVal clavecliente As String, ByVal usuario As String, ByVal pregunta As String, ByVal archivo As String) As Int64
        RegistroSoporteCliente = 0
        Dim base As New DataBaseApp.CommandApp
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Dim cnn As SqlClient.SqlConnection = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.AddParrameter("@PROCESO", "13")
            base.AddParrameter("@ID_CLIENTE", cliente)
            base.AddParrameter("@RESPUESTADESC", pregunta)
            base.AddParrameter("@USUARIO_SOPORTE", usuario)
            base.AddParrameter("@PASS_DEFAULT", clavecliente)
            base.AddParrameter("@LINK_ACT", archivo)
            base.ProcedureName = "Extranet.EXT_SP_RECUPERA_CONTRASENIA"
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            RegistroSoporteCliente = -1
            tran.Rollback()
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function


    Public Shared Function GeneraEmailCambioContrasenia(ByVal idcliente As String, ByVal email As String, ByVal nombre01 As String, ByVal nombre02 As String, ByVal clave As String) As DataSet
        'ByVal link_act As String,
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "14")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@NOMBRE", nombre01)
            base.AddParrameter("@APELLIDO", nombre02)
            'base.AddParrameter("@LINK_ACT", link_act)
            base.AddParrameter("@CLAVE", clave)
            ds = base.Consulta("Extranet.EXT_SP_RECUPERA_CONTRASENIA")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function


End Class
