Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class DocumentosEstadoCuenta
    Public Sub GenerarDocumento(ByVal codigo As String, ByVal nombre As String, ByVal ruta As String, datos As DataSet, _
        cliente As String, identificacion As String, fecha_doc As String)
        Try
            Dim numeroMovimiento As String = codigo
            Dim dtCabecera As New System.Data.DataSet
            Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontcabeceradetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fontcabeceratabla As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, Font.NORMAL, New BaseColor(51, 51, 51))
            Dim fontdetalletabla As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 7, Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fontdetalleveh As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 6, Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fonttitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 12, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontBold As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontdetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 5, Font.NORMAL, BaseColor.GRAY)
            Dim fontnegro As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 5, Font.NORMAL, BaseColor.BLACK)
            Dim documento As New Document(PageSize.A4, -40.0F, -40.0F, 100.0F, 30.0F)
            Dim file As String = String.Format("{0}{1}", ruta, nombre)
            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim paragraph As New iTextSharp.text.Paragraph(" ")
            Dim ev As New CreacionPdf()

            dtCabecera = datos
            documento.Open()
            documento.NewPage()
            writer.PageEvent = ev
            documento.Add(paragraph)

            'DATOS DE LA FACTURA
            Dim tablaFactura As New PdfPTable(2)
            tablaFactura.SetWidths(New Single() {70.0F, 30.0F})
            'TITULO DEL DOCUMENTO
            Dim tituloFac0 As New PdfPCell(New Phrase(" ", fontcabecera))
            tituloFac0.Border = 0
            tituloFac0.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFactura.AddCell(tituloFac0)
            Dim tituloFac1 As New PdfPCell(New Phrase("Estado de cuenta         ", fonttitulo))
            tituloFac1.Border = 0
            tituloFac1.HorizontalAlignment = Element.ALIGN_RIGHT
            tablaFactura.AddCell(tituloFac1)
            'FECHA Y HORA DE IMPRESION
            Dim tituloFac0A As New PdfPCell(New Phrase(" ", fontcabecera))
            tituloFac0A.Border = 0
            tituloFac0A.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFactura.AddCell(tituloFac0A)
            'LINEA EN BLANCO
            Dim tituloFac2 As New PdfPCell(New Phrase(" ", fontcabecera))
            tituloFac2.Border = 0
            tituloFac2.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFactura.AddCell(tituloFac2)
            'Dim tituloFac3 As New PdfPCell(New Phrase(" ", fontcabecera))
            'tituloFac3.Border = 0
            'tituloFac3.HorizontalAlignment = Element.ALIGN_RIGHT
            'tablaFactura.AddCell(tituloFac3)
            'NUMERO DEL DOCUMENTO
            Dim tituloFac4 As New PdfPCell(New Phrase(" ", fontcabecera))
            tituloFac4.Border = 0
            tituloFac4.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFactura.AddCell(tituloFac4)
            Dim tituloFac5 As New PdfPCell(New Phrase())
            tituloFac5.Phrase.Add(New Chunk("Documento        ", fontBold))
            tituloFac5.Phrase.Add(New Chunk(codigo, fontcabeceradetalle))
            tituloFac5.Border = 0
            tituloFac5.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFactura.AddCell(tituloFac5)
            documento.Add(tablaFactura)

            Dim tablaFacturacabecera As New PdfPTable(2)
            tablaFacturacabecera.SetWidths(New Single() {20.0F, 80.0F})
            'NOMBRE DEL CLIENTE
            Dim tituloFac6 As New PdfPCell(New Phrase("Cliente", fontcabecera))
            tituloFac6.Border = 0
            tituloFac6.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(tituloFac6)
            Dim tituloFac7 As New PdfPCell(New Phrase(cliente, fontcabeceradetalle))
            tituloFac7.Border = 0
            tituloFac7.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(tituloFac7)
            'IDENTIFICACION DEL CLIENTE
            Dim tituloFac8 As New PdfPCell(New Phrase("Identificación", fontcabecera))
            tituloFac8.Border = 0
            tituloFac8.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(tituloFac8)
            Dim tituloFac9 As New PdfPCell(New Phrase(identificacion, fontcabeceradetalle))
            tituloFac9.Border = 0
            tituloFac9.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(tituloFac9)
            'FECHA FACTURA
            Dim tituloFac10 As New PdfPCell(New Phrase("Fecha de Documento", fontcabecera))
            tituloFac10.Border = 0
            tituloFac10.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(tituloFac10)
            Dim tituloFac11 As New PdfPCell(New Phrase(fecha_doc, fontcabeceradetalle))
            tituloFac11.Border = 0
            tituloFac11.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(tituloFac11)
            documento.Add(tablaFacturacabecera)

            'DATOS DE FORMA DE PAGO
            documento.Add(Chunk.NEWLINE)
            'TITULO
            Dim tablatitulo1 As New PdfPTable(1)
            tablatitulo1.SetWidths(New Single() {100.0F})
            Dim titulot1 As New PdfPCell(New Phrase("Detalle de pago", fontcabeceratabla))
            titulot1.Border = 0
            titulot1.BackgroundColor = New BaseColor(255, 255, 255)
            titulot1.HorizontalAlignment = Element.ALIGN_LEFT
            tablatitulo1.AddCell(titulot1)
            documento.Add(tablatitulo1)
            'DETALLE
            Dim tablacabecera As New PdfPTable(5)
            tablacabecera.SetWidths(New Single() {12.5F, 12.5F, 25.0F, 25.0F, 25.0F})
            Dim titulocab0 As New PdfPCell(New Phrase("Número Letra", fontcabeceratabla))
            titulocab0.Border = 0
            titulocab0.BackgroundColor = New BaseColor(217, 217, 217)
            titulocab0.BorderColor = New BaseColor(217, 217, 217)
            titulocab0.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab0)
            Dim titulocab1 As New PdfPCell(New Phrase("Fecha Vencimiento", fontcabeceratabla))
            titulocab1.Border = 0
            titulocab1.BackgroundColor = New BaseColor(217, 217, 217)
            titulocab1.BorderColor = New BaseColor(217, 217, 217)
            titulocab1.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab1)
            Dim titulocab2 As New PdfPCell(New Phrase("Valor", fontcabeceratabla))
            titulocab2.Border = 0
            titulocab2.BackgroundColor = New BaseColor(217, 217, 217)
            titulocab2.BorderColor = New BaseColor(217, 217, 217)
            titulocab2.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab2)
            Dim titulocab3 As New PdfPCell(New Phrase("Saldo vencer", fontcabeceratabla))
            titulocab3.Border = 0
            titulocab3.BackgroundColor = New BaseColor(217, 217, 217)
            titulocab3.BorderColor = New BaseColor(217, 217, 217)
            titulocab3.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab3)
            Dim titulocab4 As New PdfPCell(New Phrase("Saldo total", fontcabeceratabla))
            titulocab4.Border = 0
            titulocab4.BackgroundColor = New BaseColor(217, 217, 217)
            titulocab4.BorderColor = New BaseColor(217, 217, 217)
            titulocab4.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab4)
            If dtCabecera.Tables(0).Rows.Count > 0 Then
                For i = 0 To dtCabecera.Tables(0).Rows.Count - 1
                    Dim detalleform0 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(i)("NUMERO_LETRA").ToString(), fontdetalletabla))
                    detalleform0.Border = 0
                    detalleform0.HorizontalAlignment = Element.ALIGN_RIGHT
                    tablacabecera.AddCell(detalleform0)

                    Dim detalleform1 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(i)("FECHA").ToString(), fontdetalletabla))
                    detalleform1.Border = 0
                    detalleform1.HorizontalAlignment = Element.ALIGN_LEFT
                    tablacabecera.AddCell(detalleform1)

                    Dim detalleform2 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(i)("VALOR").ToString(), fontdetalletabla))
                    detalleform2.Border = 0
                    detalleform2.HorizontalAlignment = Element.ALIGN_RIGHT
                    tablacabecera.AddCell(detalleform2)

                    Dim detalleform3 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(0).Rows(i)("SALDO_VENCER").ToString(), 2), fontdetalletabla))
                    detalleform3.Border = 0
                    detalleform3.HorizontalAlignment = Element.ALIGN_RIGHT
                    tablacabecera.AddCell(detalleform3)

                    Dim detalleform4 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(0).Rows(i)("SALDO_TOTAL").ToString(), 2), fontdetalletabla))
                    detalleform4.Border = 0
                    detalleform4.HorizontalAlignment = Element.ALIGN_RIGHT
                    tablacabecera.AddCell(detalleform4)
                Next
            End If
            documento.Add(tablacabecera)
            documento.Close()

        Catch ex As Exception
            ' Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub
End Class
