Public Class bajadecliente

    Inherits System.Web.UI.Page
    Dim objregusu As New RegistroUsuarioAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                GrabaQs()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub GrabaQs()
        Try
            Dim valorTransaccion As Integer = 0
            Dim identificador, ruta, baja, origen As String
            ruta = Request.QueryString.ToString
            origen = "REG"
            If Request.QueryString("Id") <> Nothing Then
                If Request.QueryString("Origen") <> Nothing Then
                    origen = Request.QueryString("Origen")
                End If
                identificador = Request.QueryString("Id")
                baja = Request.QueryString("Baja")
                valorTransaccion = objregusu.RegistroQS(identificador, "SI", ruta, origen)
                If valorTransaccion < 0 Then
                    Throw New System.Exception("Querystring no se guardo con éxito por favor verificar QS:" & ruta)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class