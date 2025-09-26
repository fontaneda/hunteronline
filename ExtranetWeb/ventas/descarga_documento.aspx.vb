Public Class descarga_documento
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Autor: Felix Ontaneda Cotero
    ''' Fecha: 11/02/2015
    ''' Descr: Evento load para descarga automatica de archivos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Response.Clear()
            If Request.QueryString("COD") = "1" Then
                Response.ContentType = "Application/XML"
            Else
                Response.ContentType = "Application/PDF"
            End If
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & Request.QueryString("FILENAME"))
            Response.WriteFile(Request.QueryString("RUTA"))
            Response.Flush()
            Response.Close()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class