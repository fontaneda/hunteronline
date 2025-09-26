Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class CreacioPdfTurno
    Inherits PdfPageEventHelper


    Protected ReadOnly Property Footer() As Font
        Get
            Dim grey As New BaseColor(128, 128, 128)
            Dim font1 As Font = FontFactory.GetFont("Arial", 9, Font.NORMAL, grey)
            Return font1
        End Get
    End Property


    Public Overrides Sub OnEndPage(writer As PdfWriter, doc As Document)
        Try

            '**********************************************
            ' encabezado de pagina
            '**********************************************
            Dim headerTbl As New PdfPTable(1)
            headerTbl.TotalWidth = doc.PageSize.Width

            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height), writer.DirectContent)

            '**********************************************
            ' pie de pagina
            '**********************************************

            '***********************************************************************
            ' linea separador
            '***********************************************************************

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class
