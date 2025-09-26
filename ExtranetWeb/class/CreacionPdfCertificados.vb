Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class CreacionPdfCertificados
    Inherits PdfPageEventHelper

    ''' <summary>
    ''' FECHA: 04/04/2018
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: PROPIEDAD DEE FUENTES PARA EL PIE DE PAGINA
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Footer() As Font
        Get
            Dim grey As New BaseColor(0, 0, 0)
            Dim font1 As Font = FontFactory.GetFont("Arial", 8, Font.NORMAL, grey)
            Return font1
        End Get
    End Property

    ''' <summary>
    ''' FECHA: 04/04/2018
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: COLOCAR CABECERA Y PIE DE PAGINA EN DOCUMENTO PDF
    ''' </summary>
    ''' <param name="writer"></param>
    ''' <param name="doc"></param>
    ''' <remarks></remarks>
    Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal doc As Document)
        Try
            '**********************************************
            ' encabezado de pagina
            '**********************************************
            Dim headerTbl As New PdfPTable(1)
            headerTbl.TotalWidth = doc.PageSize.Width
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/CertificadoCabecera.jpg")
            logo.ScaleAbsolute(540.0F, 65.0F)
            Dim cell As New PdfPCell(logo)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.PaddingTop = 25
            cell.PaddingLeft = 20
            cell.PaddingRight = 20
            cell.Border = 0
            headerTbl.AddCell(cell)
            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height), writer.DirectContent)

            '**********************************************
            ' pie de pagina
            '**********************************************
            Dim logopie As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/Certificadopie.jpg")
            Dim para0 As New iTextSharp.text.Paragraph("Fecha Imp.     " & Format(Date.Now, "dd/MM/yyyy"), Footer)
            Dim footerTbl As New PdfPTable(1)
            footerTbl.TotalWidth = doc.PageSize.Width
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER
            logopie.ScaleAbsolute(540.0F, 30.0F)

            Dim cellpie0 As New PdfPCell(para0)
            cellpie0.HorizontalAlignment = Element.ALIGN_RIGHT
            cellpie0.Border = 0
            cellpie0.PaddingRight = 30
            footerTbl.AddCell(cellpie0)

            Dim cellpie1 As New PdfPCell(logopie)
            cellpie1.HorizontalAlignment = Element.ALIGN_CENTER
            cellpie1.Border = 0
            cellpie1.PaddingTop = 5
            cellpie1.PaddingBottom = 25
            cellpie1.PaddingLeft = 20
            cellpie1.PaddingRight = 20
            footerTbl.AddCell(cellpie1)
            footerTbl.WriteSelectedRows(0, -1, 0, 60, writer.DirectContent)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class
