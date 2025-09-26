Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class RoundedBorders
    Implements IPdfPCellEvent

    ''' <summary>
    ''' FECHA: 04/04/2018
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: DIBUJA CELDAS CON BORDES PARA EL DOCUMENTO PDF
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <param name="position"></param>
    ''' <param name="canvases"></param>
    ''' <remarks></remarks>
    Public Sub CellLayout(ByVal cell As iTextSharp.text.pdf.PdfPCell, ByVal position As iTextSharp.text.Rectangle, ByVal canvases() As iTextSharp.text.pdf.PdfContentByte) Implements iTextSharp.text.pdf.IPdfPCellEvent.CellLayout
        Dim cb As PdfContentByte = canvases(PdfPTable.BACKGROUNDCANVAS)
        Dim gris_oscuro As New BaseColor(128, 128, 128)

        cb.RoundRectangle(position.GetLeft(-1.0F), position.GetBottom(0.0F), 72.8F, 21.0F, 4)
        cb.SetLineWidth(2.2F)
        cb.SetColorStroke(gris_oscuro)
        cb.Stroke()
    End Sub

End Class