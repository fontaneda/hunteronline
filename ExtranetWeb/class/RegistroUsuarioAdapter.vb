Public Class RegistroUsuarioAdapter

    Public Shared Function VerificaUsuarioExiste(ByVal idcliente As String, ByVal opcion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", opcion)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Function ConsultaEmail(ByVal idcliente As String) As DataTable
        ConsultaEmail = New DataTable
        Try
            Dim datos As New DataBaseApp.CommandApp
            datos.AddParrameter("@PROCESO", "133")
            datos.AddParrameter("@ID_CLIENTE", idcliente)
            ConsultaEmail.Load(datos.ConsultaReader("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS"))
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function VerificaChasisMotorExiste(ByVal idcliente As String, ByVal chasismotor As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "114")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@CHASIS_MOTOR", chasismotor)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPreguntasSeguridad() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "099")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPreguntasSeguridad(ByVal preguntaId As Int32) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "099")
            base.AddParrameter("@PREGUNTAID", preguntaId)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPreguntasAleatorias() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ListaAnios() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "103")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ListaMeses() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ListaDias(ByVal valueanio As Integer, ByVal valuemes As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@ANIO", valueanio)
            base.AddParrameter("@MES", valuemes)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ListaPaises() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "104")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ListaProvincias() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ListaCiudad(ByVal provincia As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "106")
            base.AddParrameter("@PROVINCIA", provincia)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function GeneraLinkActivacion() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "110")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function GeneraLinkActivacionUsuario() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "116")
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmailSiExiste(ByVal email As String, ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "112")
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmailSiExisteActualizacion(ByVal email As String, ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "118")
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function GeneraEmailActivacion(ByVal idcliente As String, ByVal email As String, ByVal nombre01 As String, ByVal nombre02 As String, ByVal linkAct As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "111")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@NOMBRE_01", nombre01)
            base.AddParrameter("@APELLIDO_01", nombre02)
            base.AddParrameter("@LINK_ACT", linkAct)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function GeneraEmailActivacionUsuario(ByVal idcliente As String, ByVal email As String, ByVal nombre01 As String, ByVal nombre02 As String, ByVal linkAct As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "117")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@NOMBRE_01", nombre01)
            base.AddParrameter("@APELLIDO_01", nombre02)
            base.AddParrameter("@LINK_ACT", linkAct)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Public Shared Function CargaDatosCliente(ByVal idcliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "113")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            ds = base.Consulta("Extranet.EXT_SP_NETSUITE_HO_USUARIOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    Function RegistroDatosPersonalesUsuarioWeb(ByVal idcliente As String, ByVal nombre As String, ByVal apellido As String, ByVal password As String, ByVal dia As Integer, ByVal mes As Integer, _
                                               ByVal anio As Integer, ByVal email1 As String, ByVal telefono1 As String, ByVal stringPrgRsp01 As String, ByVal valueCondServPolt As Integer, _
                                               ByVal valueInfoProdServ As Integer, ByVal tipocliente As Integer, ByVal telefono2 As String, ByVal chasisMotor As String) As Int64
        RegistroDatosPersonalesUsuarioWeb = 0
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
            base.ProcedureName = "Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS"
            base.AddParrameter("@PROCESO", 107)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@NOMBRE_01", nombre)
            base.AddParrameter("@APELLIDO_01", apellido)
            base.AddParrameter("@DIA", dia)
            base.AddParrameter("@MES", mes)
            base.AddParrameter("@ANIO", anio)
            base.AddParrameter("@EMAIL1", email1)
            base.AddParrameter("@PASSWORD", password)
            'base.AddParrameter("@PAIS", pais)
            'base.AddParrameter("@PROVINCIA", provincia)
            'base.AddParrameter("@CIUDAD", ciudad)
            base.AddParrameter("@TELEFONO1", telefono1)
            base.AddParrameter("@VALUE_COND_SERV_POLT", valueCondServPolt)
            base.AddParrameter("@VALUE_INFO_PROD_SERV", valueInfoProdServ)
            base.AddParrameter("@TIPO_CLIENTE", tipocliente)
            base.AddParrameter("@TELEFONO_2", telefono2)
            base.AddParrameter("@CHASIS_MOTOR", chasisMotor)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
            'If RegistroDatosPersonalesUsuarioWeb = 0 Then
            '    Try
            '        dtListPrgRsp = GeneraListaPrgRsp(stringPrgRsp01)
            '        For i As Integer = 0 To dtListPrgRsp.Rows.Count - 1
            '            valuePregunta = Convert.ToInt32(dtListPrgRsp.Rows(i)("pregunta"))
            '            valueRespuesta = Convert.ToString(dtListPrgRsp.Rows(i)("respuesta"))
            '            cmd = New SqlClient.SqlCommand
            '            cnn = base.Connection
            '            cnn.Open()
            '            cmd.CommandTimeout = 1000
            '            cmd.Connection = cnn
            '            Tran = cnn.BeginTransaction()
            '            base.ClearParrameter(cmd)
            '            base.ProcedureName = "Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS"
            '            base.AddParrameter("@PROCESO", 108)
            '            base.AddParrameter("@ID_CLIENTE", idcliente)
            '            base.AddParrameter("@PREGUNTAID", valuePregunta)
            '            base.AddParrameter("@RESPUESTADESC", valueRespuesta)
            '            base.EjecutaTransaction(cmd, Tran)
            '            Tran.Commit()
            '        Next
            '    Catch ex As Exception
            '        RegistroDatosPersonalesUsuarioWeb = -1
            '        Tran.Rollback()
            '        Throw ex
            '        ExceptionHandler.Captura_Error(ex)
            '    End Try
            'End If
        Catch ex As Exception
            RegistroDatosPersonalesUsuarioWeb = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Function RegistroDatosPersonalesUsuarioWeb_Rol(ByVal idcliente As String, ByVal cliente_referencial As String, ByVal nombre As String, _
                                                   ByVal apellido As String, ByVal email1 As String, ByVal password As String, _
                                                   ByVal telefono1 As String, ByVal valueCondServPolt As Integer, ByVal fecha_expira As Date)
        RegistroDatosPersonalesUsuarioWeb_Rol = 0
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
            base.ProcedureName = "Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS_ROL"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@CLIENTE_REFERENCIAL", cliente_referencial)
            base.AddParrameter("@NOMBRE_01", nombre)
            base.AddParrameter("@APELLIDO_01", apellido)
            base.AddParrameter("@EMAIL1", email1)
            base.AddParrameter("@PASSWORD", password)
            base.AddParrameter("@TELEFONO1", telefono1)
            base.AddParrameter("@VALUE_COND_SERV_POLT", valueCondServPolt)
            base.AddParrameter("@FECHA_EXPIRA", fecha_expira)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            RegistroDatosPersonalesUsuarioWeb_Rol = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Function RegistroClientePotencialWeb(ByVal idcliente As String, ByVal nombre As String, ByVal apellido As String, ByVal celular As String, ByVal telefono As String, ByVal usuario As String) As Int64
        RegistroClientePotencialWeb = 0
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
            base.ProcedureName = "Extranet.EXT_SP_PROMOCION_REFERIDO_WEB"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@CODIGO_CLIENTE", usuario)
            base.AddParrameter("@CODIGO_REFERIDO", idcliente)
            base.AddParrameter("@NOMBRE", nombre)
            base.AddParrameter("@APELLIDO", apellido)
            base.AddParrameter("@CELULAR", celular)
            base.AddParrameter("@TELEFONO", telefono)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            RegistroClientePotencialWeb = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Function RegistroQS(ByVal identificador As String, ByVal baja As String, ByVal qs As String, Optional ByVal origen As String = "REG") As Int64
        RegistroQS = 0
        If identificador Is Nothing Then
            identificador = "0"
        End If
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
            base.ProcedureName = "Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS"
            base.AddParrameter("@PROCESO", 115)
            base.AddParrameter("@ID_CLIENTE", identificador)
            base.AddParrameter("@BODY_ACT", baja)
            base.AddParrameter("@LINK_ACT", qs)
            base.AddParrameter("@RESPUESTADESC", origen)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            RegistroQS = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Function ActualizaDatosPersonalesUsuarioWeb(ByVal idcliente As String, ByVal password As String, ByVal celular As String, ByVal stringPrgRsp01 As String, ByVal valueCondServPolt As Integer, _
                                                ByVal valueInfoProdServ As Integer, ByVal email1 As String) As Int64
        ActualizaDatosPersonalesUsuarioWeb = 0
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
            base.ProcedureName = "Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS"
            base.AddParrameter("@PROCESO", 131)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@PASSWORD", password)
            base.AddParrameter("@TELEFONO1", celular)
            base.AddParrameter("@EMAIL1", email1)
            base.AddParrameter("@VALUE_COND_SERV_POLT", valueCondServPolt)
            base.AddParrameter("@VALUE_INFO_PROD_SERV", valueInfoProdServ)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
            'If ActualizaDatosPersonalesUsuarioWeb = 0 Then
            '    Try
            '        dtListPrgRsp = GeneraListaPrgRsp(stringPrgRsp01)
            '        For i As Integer = 0 To dtListPrgRsp.Rows.Count - 1
            '            valuePregunta = Convert.ToInt32(dtListPrgRsp.Rows(i)("pregunta"))
            '            valueRespuesta = Convert.ToString(dtListPrgRsp.Rows(i)("respuesta"))
            '            cmd = New SqlClient.SqlCommand
            '            cnn = base.Connection
            '            cnn.Open()
            '            cmd.CommandTimeout = 1000
            '            cmd.Connection = cnn
            '            tran = cnn.BeginTransaction()
            '            base.ClearParrameter(cmd)
            '            base.ProcedureName = "Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS"
            '            base.AddParrameter("@PROCESO", 108)
            '            base.AddParrameter("@ID_CLIENTE", idcliente)
            '            base.AddParrameter("@PREGUNTAID", valuePregunta)
            '            base.AddParrameter("@RESPUESTADESC", valueRespuesta)
            '            base.EjecutaTransaction(cmd, tran)
            '            tran.Commit()
            '        Next
            '    Catch ex As Exception
            '        ActualizaDatosPersonalesUsuarioWeb = -1
            '        tran.Rollback()
            '        Throw ex
            '        ExceptionHandler.Captura_Error(ex)
            '    End Try
            'End If
        Catch ex As Exception
            ActualizaDatosPersonalesUsuarioWeb = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Public Shared Function GeneraEmailActivacionMantenimiento(ByVal idcliente As String, ByVal email As String, ByVal nombre01 As String, ByVal nombre02 As String, ByVal linkAct As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "165")
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@EMAIL1", email)
            base.AddParrameter("@NOMBRE_01", nombre01)
            base.AddParrameter("@APELLIDO_01", nombre02)
            base.AddParrameter("@LINK_ACT", linkAct)
            ds = base.Consulta("Extranet.EXT_SP_GRABA_USUARIOS_NUEVOS")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

End Class
