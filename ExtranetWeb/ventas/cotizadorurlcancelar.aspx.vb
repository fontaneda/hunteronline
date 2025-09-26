Public Class cotizadorurlcancelar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("UrlCancelar") = "SI"
            Response.Redirect("renovacion.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class