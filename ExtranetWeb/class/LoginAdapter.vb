Imports System.Security.Cryptography

Public Class LoginAdapter

    Public Shared Function LoginUsuario(ByVal usuario As String, ByVal password As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@USUARIO", usuario)
            base.AddParrameter("@PASSWORD", password)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_LOGIN")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function LoginUsuario2(ByVal usuario As String, ByVal password As String, ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Dim obj As New LoginAdapter
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@USER", usuario)
            'base.AddParrameter("@PASSWORD", password)
            base.AddParrameter("@PASSWORD", obj.Encriptar3S(password))
            base.AddParrameter("@CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_LOGIN_USUARIO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' Autor: MNAREA
    ''' Motivo ENCRIPTAR CONTRASENIA METODO 3S
    ''' Fecha: 14/06/2012
    ''' </summary>
    ''' <param name="Password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Encriptar3S(ByVal password As String) As Byte()
        Encriptar3S = Nothing
        Dim objSha256 As New SHA256Managed
        Dim objTemporal As Byte()
        Try
            objTemporal = System.Text.Encoding.UTF8.GetBytes(password)
            objTemporal = objSha256.ComputeHash(objTemporal)
            Return objTemporal
        Catch ex As Exception
            Throw
        Finally
            objSha256.Clear()
        End Try
    End Function

    Public Shared Function DatosLoginUsuario(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@USUARIO", usuario)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_LOGIN")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function DatosMenuExtranet(ByVal usuario As String, ByVal proceso As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@USUARIO", usuario)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_LOGIN")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Function RegistroQSLogin(ByVal identificador As String, ByVal baja As String, ByVal qs As String, ByVal origen As String) As Int64
        RegistroQSLogin = 0
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
            base.EjecutaTransaction(cmd, Tran)
            tran.Commit()
        Catch ex As Exception
            RegistroQSLogin = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

End Class