Imports System.IO

Public Class Libreria


    Public Shared Function Parse(ByVal input As String) As Decimal
        Return Decimal.Parse(Regex.Replace(input, "[^\d.]", ""))
    End Function


    Public Shared Function ReadFile(ByVal file As String) As String
        Dim reader As New StreamReader(file)
        Return reader.ReadToEnd
    End Function

End Class