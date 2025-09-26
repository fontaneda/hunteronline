Imports System.Security.Cryptography

Public Class Password

    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: FUNCIÓN PARA ENCRIPTAR LA CONTRASEÑA
    ''' </summary>
    ''' <param name="password"></param>
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


End Class
