Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class CreacionPdfFormato
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

            Dim imagepath As String = "\\10.100.107.14\GUIARECEPCION\"
            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height), writer.DirectContent)

            Dim pdfContent As PdfContentByte
            Dim cb2 As PdfContentByte = writer.DirectContentUnder
            Dim baseFont2 As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED)
            cb2.BeginText()
            cb2.SetColorFill(BaseColor.LIGHT_GRAY)
            cb2.SetFontAndSize(baseFont2, 10)
            cb2.EndText()

            pdfContent = writer.DirectContent
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
