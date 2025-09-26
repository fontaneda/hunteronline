Public Class RegistraLogLecturaMail
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 19/09/2014
    ''' Descr: Evento load del formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Registraloglecturamail()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Fecha: 19/09/2014
    ''' Descr: Llama a clase de insercion de datos en base
    ''' </summary>
    Private Sub Registraloglecturamail()
        Dim usuario, email As String
        Dim orden As Integer
        Const Opcion As String = "1"
        Try
            If Request.QueryString("OrdenId") <> Nothing Then
                If Request.QueryString("Usuario") <> Nothing Then
                    If Request.QueryString("Email") <> Nothing Then
                        orden = Request.QueryString("OrdenId")
                        usuario = Request.QueryString("Usuario")
                        email = Request.QueryString("Email")
                        If RenovacionAdapter.RegistraLogLecturaMail(orden, usuario, email, Opcion) Then
                            Exit Sub
                        End If
                    End If
                End If
            End If
            Throw New System.Exception("Querystring no se guardo con éxito por favor verificar QS:" & Request.QueryString.ToString)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class