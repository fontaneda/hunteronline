Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class DocumentosPdfOriginal
    Public Sub GenerarDocumento()

        Try
            Dim fontNormal As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, Font.NORMAL)
            Dim fontBold As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, Font.BOLD)
            Dim fontTitulo As iTextSharp.text.Font = FontFactory.GetFont("Arial", 12, Font.UNDERLINE)
            Dim fontSubtotal As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, Font.NORMAL)
            Dim fontSubtotalBold As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, Font.BOLD)

            Dim documento As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
            'Dim pdfFilePath As String = Server.MapPath(".") + "/PDFFiles"
            Dim file As String = "C:\Users\galvarado\Downloads\Panel.pdf"
            'Dim file As String = "\\10.100.107.14\ImagenesDocumentos\Panel.pdf" '//ruta del servidor
            'Dim file As String = "\\10.100.107.242\compartido\Documento.pdf" '//ruta de felix
            'Dim file As String = "\\10.100.107.242\compartido\Nuevo" & Session("NombreFactura") & ".pdf"
            'Dim writer As PdfWriter = PdfAWriter.GetInstance(doc, New FileStream(pdfFilePath & Convert.ToString("/Default.pdf"), FileMode.Create))
            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim paragraph As New iTextSharp.text.Paragraph("Getting Started ITextSharp.")
            'Dim imageURL As String = Server.MapPath(".") + "/image2.jpg"
            'Dim imageURL As String = "C:\Users\galvarado\Downloads\master_container_background_email.jpg"
            'Dim jpg As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imageURL)
            'Dim encab As New Chunk(" LISTA DE PRODUCTOS CODIFICADOS EN ", FontFactory.GetFont("COURIER", 12))
            'Dim titleFont As New Font(Font.NORMAL, 14, Font.BOLD)
            'Dim titleFont As Font = FontFactory.GetFont("Arial", 16, Font.NORMAL)
            'Dim SubtitleFont As Font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.UNDERLINE)
            'Dim grey As New BaseColor(128, 128, 128)
            'Dim SubtitleFont As Font = FontFactory.GetFont("Arial", 9, Font.UNDERLINE)
            ' various fonts
            'Dim bf_helv As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, "Cp1252", False)
            'Dim bf_times As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "Cp1252", False)
            'Dim bf_courier As BaseFont = BaseFont.CreateFont(BaseFont.COURIER, "Cp1252", False)
            'Dim bf_symbol As BaseFont = BaseFont.CreateFont(BaseFont.SYMBOL, "Cp1252", False)
            Dim ev As New CreacionPdf()
            documento.Open()
            documento.NewPage()
            writer.PageEvent = ev
            ''InsertarTabla(documento, Session("General").table(0), New Single() {1.0F, 2.0F}, True)
            'Resize image depend upon your need
            'jpg.ScaleToFit(580.0F, 100.0F)
            ''Give space before image
            'jpg.SpacingBefore = 1.0F
            ''Give some space after the image
            'jpg.SpacingAfter = 1.0F
            ' ''jpg.ScalePercent(100.0F)
            'jpg.Alignment = Element.ALIGN_LEFT
            'documento.Add(jpg)
            documento.Add(paragraph)

            'documento.NewPage()
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)
            Dim tablacabecera As New PdfPTable(6)
            tablacabecera.SetWidths(New Single() {4.0F, 3.0F, 22.0F, 4.0F, 4.0F, 4.0F})
            'tablacabecera.LockedWidth = True
            'tablacabecera.HorizontalAlignment = 0
            Dim titulocab1 As New PdfPCell(New Phrase("COD.", fontBold))
            titulocab1.Border = 0
            titulocab1.BackgroundColor = New BaseColor(230, 230, 230)
            titulocab1.BorderColor = New BaseColor(230, 230, 230)
            titulocab1.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab1)
            Dim titulocab2 As New PdfPCell(New Phrase("CANT.", fontBold))
            titulocab2.Border = 0
            titulocab2.BackgroundColor = New BaseColor(230, 230, 230)
            titulocab2.BorderColor = New BaseColor(230, 230, 230)
            titulocab2.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab2)
            Dim titulocab3 As New PdfPCell(New Phrase("DESCRIPCION", fontBold))
            titulocab3.Border = 0
            titulocab3.BackgroundColor = New BaseColor(230, 230, 230)
            titulocab3.BorderColor = New BaseColor(230, 230, 230)
            titulocab3.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab3)
            Dim titulocab4 As New PdfPCell(New Phrase("PRECIO", fontBold))
            titulocab4.Border = 0
            titulocab4.BackgroundColor = New BaseColor(230, 230, 230)
            titulocab4.BorderColor = New BaseColor(230, 230, 230)
            titulocab4.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab4)
            Dim titulocab5 As New PdfPCell(New Phrase("DESC.", fontBold))
            titulocab5.Border = 0
            titulocab5.BackgroundColor = New BaseColor(230, 230, 230)
            titulocab5.BorderColor = New BaseColor(230, 230, 230)
            titulocab5.HorizontalAlignment = Element.ALIGN_CENTER
            tablacabecera.AddCell(titulocab5)
            Dim titulocab6 As New PdfPCell(New Phrase("TOTAL", fontBold))
            titulocab6.BackgroundColor = New BaseColor(230, 230, 230)
            titulocab6.BorderColor = New BaseColor(230, 230, 230)
            titulocab6.Border = 0
            titulocab6.HorizontalAlignment = Element.ALIGN_CENTER
            'titulocab6.VerticalAlignment = CELL.A
            tablacabecera.AddCell(titulocab6)
            'titulocab6.VerticalAlignment = Cell.ALIGN_LEFT
            'titulocab6.HorizontalAlignment = Cell.ALIGN_LEFT
            ' FOR PARA PODER BARRE EL DETALLE
            'For i = 0 To dtcstSucursal.Tables(0).Rows.Count - 1
            Dim detalle1 As New PdfPCell(New Phrase("92470", fontNormal))
            detalle1.Border = 0
            tablacabecera.AddCell(detalle1)
            Dim detalle2 As New PdfPCell(New Phrase("10", fontNormal))
            detalle2.Border = 0
            tablacabecera.AddCell(detalle2)
            Dim detalle3 As New PdfPCell(New Phrase("VENT. HUNTER LOJACK DISPOSITIVO", fontNormal))
            detalle3.Border = 0
            tablacabecera.AddCell(detalle3)
            Dim detalle4 As New PdfPCell(New Phrase("200.00", fontNormal))
            detalle4.Border = 0
            tablacabecera.AddCell(detalle4)
            Dim detalle5 As New PdfPCell(New Phrase("100.00", fontNormal))
            detalle5.Border = 0
            tablacabecera.AddCell(detalle5)
            Dim detalle6 As New PdfPCell(New Phrase("1900.00", fontNormal))
            detalle6.Border = 0
            detalle6.HorizontalAlignment = Element.ALIGN_RIGHT
            tablacabecera.AddCell(detalle6)
            ' FIN DEL FOR
            ' Next

            'Dim cb As PdfContentByte = writer.getDirectContent()
            'Dim pdfContent As PdfContentByte
            'pdfContent = writer.DirectContent
            'pdfContent.MoveTo(228, 810)
            'pdfContent.LineTo(338, 810)
            'pdfContent.Stroke()

            Dim espacioA5 As New PdfPCell(New Phrase("  ", fontNormal))
            'Dim espacioA6 As New PdfPCell(New Phrase("  ", fontNormal))
            espacioA5.Border = 0
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            'espacioA6.BorderColorBottom = New BaseColor(230, 230, 230)
            'espacioA6.BorderColorLeft = New BaseColor(230, 230, 230)
            'espacioA6.bo()
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            'Dim line1 As New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)
            'tablacabecera.AddCell.Add(New Chunk(line1))

            'FOR PARA TRAER LOS TOTALES
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            Dim detallepie1 As New PdfPCell(New Phrase("Subtotal", fontSubtotal))
            detallepie1.Border = 0
            detallepie1.Colspan = 2
            tablacabecera.AddCell(detallepie1)
            Dim detallepie2 As New PdfPCell(New Phrase("1900.00", fontNormal))
            detallepie2.Border = 0
            detallepie2.HorizontalAlignment = Element.ALIGN_RIGHT
            tablacabecera.AddCell(detallepie2)

            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            Dim detallepie3 As New PdfPCell(New Phrase("Subtotal 0%", fontSubtotal))
            detallepie3.Border = 0
            detallepie3.Colspan = 2
            tablacabecera.AddCell(detallepie3)
            Dim detallepie4 As New PdfPCell(New Phrase("0.00", fontNormal))
            detallepie4.Border = 0
            detallepie4.HorizontalAlignment = Element.ALIGN_RIGHT
            tablacabecera.AddCell(detallepie4)

            'tablacabecera.AddCell(espacioA5)
            'tablacabecera.AddCell(espacioA5)
            'tablacabecera.AddCell(espacioA5)
            'Dim detallepie5 As New PdfPCell(New Phrase("Subtotal sin descuento", fontSubtotal))
            'detallepie5.Border = 0
            'detallepie5.Colspan = 2
            'tablacabecera.AddCell(detallepie5)
            'Dim detallepie6 As New PdfPCell(New Phrase("700.00", fontNormal))
            'detallepie6.Border = 0
            'tablacabecera.AddCell(detallepie6)

            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            Dim detallepie7 As New PdfPCell(New Phrase("Descuento", fontSubtotal))
            detallepie7.Border = 0
            detallepie7.Colspan = 2
            tablacabecera.AddCell(detallepie7)
            Dim detallepie8 As New PdfPCell(New Phrase("100.00", fontNormal))
            detallepie8.Border = 0
            detallepie8.HorizontalAlignment = Element.ALIGN_RIGHT
            tablacabecera.AddCell(detallepie8)

            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            Dim detallepie9 As New PdfPCell(New Phrase("I.V.A", fontSubtotal))
            detallepie9.Border = 0
            detallepie9.Colspan = 2
            tablacabecera.AddCell(detallepie9)
            Dim detallepie10 As New PdfPCell(New Phrase("288.00", fontNormal))
            detallepie10.Border = 0
            detallepie10.HorizontalAlignment = Element.ALIGN_RIGHT
            tablacabecera.AddCell(detallepie10)

            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            tablacabecera.AddCell(espacioA5)
            Dim detallepie11 As New PdfPCell(New Phrase("TOTAL", fontSubtotalBold))
            detallepie11.Border = 0
            detallepie11.Colspan = 2
            detallepie11.BackgroundColor = New BaseColor(230, 230, 230)
            detallepie11.BorderColor = New BaseColor(230, 230, 230)
            tablacabecera.AddCell(detallepie11)
            Dim detallepie12 As New PdfPCell(New Phrase("2128.00", fontSubtotalBold))
            detallepie12.Border = 0
            detallepie12.BackgroundColor = New BaseColor(230, 230, 230)
            detallepie12.BorderColor = New BaseColor(230, 230, 230)
            detallepie12.HorizontalAlignment = Element.ALIGN_RIGHT
            tablacabecera.AddCell(detallepie12)
            ' FIN DEL FOR
            documento.Add(tablacabecera)

            'pagina 2 visualizacion de datos
            documento.NewPage()
            'jpg.ScaleToFit(580.0F, 100.0F)
            'jpg.SpacingBefore = 1.0F
            'jpg.SpacingAfter = 1.0F
            'jpg.Alignment = Element.ALIGN_LEFT
            'documento.Add(jpg)
            'documento.Add(paragraph)
            'Dim Titulo2 As New [String]("   Sucursales Hunter" & vbLf & vbLf & vbLf)
            'documento.Add(New Paragraph(Titulo2, titleFont))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk(vbCrLf))
            documento.Add(New Chunk("       "))
            documento.Add(New Chunk("Sucursales Hunter", FontFactory.GetFont("Arial", 16, Font.BOLD)))
            documento.Add(New Chunk(vbCrLf))
            'documento.Add(New Chunk(vbCrLf))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            Dim dtcstSucursal As New System.Data.DataSet
            dtcstSucursal = DocumentosAdapter.ConsultaSucursal(112)
            If dtcstSucursal.Tables(0).Rows.Count > 0 Then

                'For Each row As DataRow In DTCstSucursal.Tables(0).Rows
                For i = 0 To dtcstSucursal.Tables(0).Rows.Count - 1
                    'documento.Add(New Chunk("               "))
                    'documento.Add(New Chunk(row("DESCRIPCION").ToString(), FontFactory.GetFont("Arial", 12, Font.UNDERLINE)))
                    'documento.Add(New Chunk(vbCrLf))
                    'documento.Add(New Chunk("               "))
                    'documento.Add(New Chunk("Dirección: ", FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    'documento.Add(New Chunk(row("DIRECCION").ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    'documento.Add(New Chunk(vbCrLf))
                    'documento.Add(New Chunk("                "))
                    'documento.Add(New Chunk("Teléfono: ", FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    'documento.Add(New Chunk(row("TELEFONOS").ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    'documento.Add(New Chunk(vbCrLf))
                    'If row("FAX").ToString() <> "" Then
                    '    documento.Add(New Chunk("               "))
                    '    documento.Add(New Chunk("Fax: ", FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    '    documento.Add(New Chunk(row("FAX").ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    '    documento.Add(New Chunk(vbCrLf))
                    'End If

                    'documento.Add(Chunk.NEWLINE)

                    Dim table As New PdfPTable(4)
                    table.SetWidths(New Single() {2.5F, 8.0F, 2.5F, 8.0F})

                    Dim titulo1 As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("DESCRIPCION").ToString(), fontTitulo))
                    titulo1.Border = 0
                    titulo1.Colspan = 2
                    table.AddCell(titulo1)

                    'table.AddCell("Col 2 Row 1")
                    'table.AddCell("Col 2 Row 1")
                    Dim descripcion As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        descripcion = ""
                    Else
                        descripcion = dtcstSucursal.Tables(0).Rows(i + 1)("DESCRIPCION").ToString()
                    End If
                    Dim tituloB1 As New PdfPCell(New Phrase(descripcion, fontTitulo))
                    tituloB1.Border = 0
                    tituloB1.Colspan = 2
                    table.AddCell(tituloB1)

                    Dim titulo2 As New PdfPCell(New Phrase("Dirección: ", fontBold))
                    titulo2.Border = 0
                    'titulo2.Width = 30.0F
                    table.AddCell(titulo2)
                    Dim direc As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("DIRECCION").ToString(), fontNormal))
                    direc.Border = 0
                    table.AddCell(direc)

                    'table.AddCell("Col 2 Row 2")
                    'table.AddCell("Col 2 Row 2")
                    Dim direccion As String
                    Dim titulodireccion As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        direccion = ""
                        titulodireccion = ""
                    Else
                        direccion = dtcstSucursal.Tables(0).Rows(i + 1)("DIRECCION").ToString()
                        titulodireccion = "Dirección: "
                    End If
                    Dim tituloB2 As New PdfPCell(New Phrase(titulodireccion, fontBold))
                    tituloB2.Border = 0
                    'tituloB2.Width = 30.0F
                    table.AddCell(tituloB2)
                    Dim direcB2 As New PdfPCell(New Phrase(direccion, fontNormal))
                    direcB2.Border = 0
                    table.AddCell(direcB2)

                    Dim titulo3 As New PdfPCell(New Phrase("Teléfono: ", fontBold))
                    titulo3.Border = 0
                    'titulo3.Width = 30.0F
                    table.AddCell(titulo3)
                    Dim telef As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("TELEFONOS").ToString(), fontNormal))
                    telef.Border = 0
                    table.AddCell(telef)

                    'table.AddCell("Col 2 Row 3")
                    'table.AddCell("Col 2 Row 3")
                    Dim telefono As String
                    Dim titulotelefono As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        telefono = ""
                        titulotelefono = ""
                    Else
                        telefono = dtcstSucursal.Tables(0).Rows(i + 1)("TELEFONOS").ToString()
                        titulotelefono = "Teléfono: "
                    End If
                    Dim tituloB3 As New PdfPCell(New Phrase(titulotelefono, fontBold))
                    tituloB3.Border = 0
                    'tituloB3.Width = 30.0F
                    table.AddCell(tituloB3)
                    Dim telefB3 As New PdfPCell(New Phrase(telefono, fontNormal))
                    telefB3.Border = 0
                    table.AddCell(telefB3)

                    'If DTCstSucursal.Tables(0).Rows(i)("FAX").ToString() <> "" Then
                    Dim titulo4 As New PdfPCell(New Phrase("Fax: ", fontBold))
                    titulo4.Border = 0
                    'titulo4.Width = 30.0F
                    table.AddCell(titulo4)
                    Dim fax As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("FAX").ToString(), fontNormal))
                    fax.Border = 0
                    table.AddCell(fax)
                    'End If

                    'If DTCstSucursal.Tables(0).Rows(i + 1)("FAX").ToString() <> "" Then
                    'table.AddCell("Col 2 Row 4")
                    'table.AddCell("Col 2 Row 4")
                    Dim numerofax As String
                    Dim titulofax As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        numerofax = ""
                        titulofax = ""
                    Else
                        numerofax = dtcstSucursal.Tables(0).Rows(i + 1)("FAX").ToString()
                        titulofax = "Fax: "
                    End If
                    Dim tituloB4 As New PdfPCell(New Phrase(titulofax, fontBold))
                    tituloB4.Border = 0
                    'tituloB4.Width = 30.0F
                    table.AddCell(tituloB4)
                    Dim faxB4 As New PdfPCell(New Phrase(numerofax, fontNormal))
                    faxB4.Border = 0
                    table.AddCell(faxB4)
                    'End If

                    Dim espacioB5 As New PdfPCell(New Phrase("  ", fontNormal))
                    espacioB5.Border = 0
                    table.AddCell(espacioB5)
                    table.AddCell(espacioB5)
                    table.AddCell(espacioB5)
                    table.AddCell(espacioB5)

                    documento.Add(table)
                    ' documento.Add(Chunk.NEWLINE)
                    'documento.Add(New Chunk(vbCrLf))
                    i += 1

                Next
            End If
            'documento.Add(Chunk.NEWLINE)
            dtcstSucursal = Nothing
            dtcstSucursal = DocumentosAdapter.ConsultaSucursal(113)
            If dtcstSucursal.Tables(0).Rows.Count > 0 Then
                For i = 0 To dtcstSucursal.Tables(0).Rows.Count - 1
                    Dim table As New PdfPTable(4)
                    table.SetWidths(New Single() {2.5F, 8.0F, 2.5F, 8.0F})
                    Dim titulo1 As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("DESCRIPCION").ToString(), FontFactory.GetFont("Arial", 12, Font.UNDERLINE)))
                    titulo1.Border = 0
                    titulo1.Colspan = 2
                    table.AddCell(titulo1)

                    'table.AddCell("Col 2 Row 1")
                    'table.AddCell("Col 2 Row 1")
                    Dim descripcion As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        descripcion = ""
                    Else
                        descripcion = dtcstSucursal.Tables(0).Rows(i + 1)("DESCRIPCION").ToString()
                    End If
                    Dim tituloB1 As New PdfPCell(New Phrase(descripcion, FontFactory.GetFont("Arial", 12, Font.UNDERLINE)))
                    tituloB1.Border = 0
                    tituloB1.Colspan = 2
                    table.AddCell(tituloB1)

                    Dim titulo2 As New PdfPCell(New Phrase("Dirección: ", FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    titulo2.Border = 0
                    table.AddCell(titulo2)
                    Dim direc As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("DIRECCION").ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    direc.Border = 0
                    table.AddCell(direc)

                    'table.AddCell("Col 2 Row 2")
                    'table.AddCell("Col 2 Row 2")
                    Dim direccion As String
                    Dim titulodireccion As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        direccion = ""
                        titulodireccion = ""
                    Else
                        direccion = dtcstSucursal.Tables(0).Rows(i + 1)("DIRECCION").ToString()
                        titulodireccion = "Dirección: "
                    End If
                    Dim tituloB2 As New PdfPCell(New Phrase(titulodireccion, FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    tituloB2.Border = 0
                    table.AddCell(tituloB2)
                    Dim direcB2 As New PdfPCell(New Phrase(direccion, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    direcB2.Border = 0
                    table.AddCell(direcB2)


                    Dim titulo3 As New PdfPCell(New Phrase("Teléfono: ", FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    titulo3.Border = 0
                    table.AddCell(titulo3)
                    Dim telef As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("TELEFONOS").ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    telef.Border = 0
                    table.AddCell(telef)

                    'table.AddCell("Col 2 Row 3")
                    'table.AddCell("Col 2 Row 3")
                    Dim telefono As String
                    Dim titulotelefono As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        telefono = ""
                        titulotelefono = ""
                    Else
                        telefono = dtcstSucursal.Tables(0).Rows(i + 1)("TELEFONOS").ToString()
                        titulotelefono = "Teléfono: "
                    End If
                    Dim tituloB3 As New PdfPCell(New Phrase(titulotelefono, FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    tituloB3.Border = 0
                    table.AddCell(tituloB3)
                    Dim telefB3 As New PdfPCell(New Phrase(telefono, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    telefB3.Border = 0
                    table.AddCell(telefB3)


                    Dim titulo4 As New PdfPCell(New Phrase("Fax: ", FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    titulo4.Border = 0
                    table.AddCell(titulo4)
                    Dim fax As New PdfPCell(New Phrase(dtcstSucursal.Tables(0).Rows(i)("FAX").ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    fax.Border = 0
                    table.AddCell(fax)

                    'table.AddCell("Col 2 Row 4")
                    'table.AddCell("Col 2 Row 4")
                    Dim numerofax As String
                    Dim titulofax As String
                    If (i + 1) > dtcstSucursal.Tables(0).Rows.Count - 1 Then
                        numerofax = ""
                        titulofax = ""
                    Else
                        numerofax = dtcstSucursal.Tables(0).Rows(i + 1)("FAX").ToString()
                        titulofax = "Fax: "
                    End If
                    Dim tituloB4 As New PdfPCell(New Phrase(titulofax, FontFactory.GetFont("Arial", 9, Font.BOLD)))
                    tituloB4.Border = 0
                    table.AddCell(tituloB4)
                    Dim faxB4 As New PdfPCell(New Phrase(numerofax, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    faxB4.Border = 0
                    table.AddCell(faxB4)

                    Dim espacioB5 As New PdfPCell(New Phrase("  ", FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                    espacioB5.Border = 0
                    table.AddCell(espacioB5)
                    table.AddCell(espacioB5)
                    table.AddCell(espacioB5)
                    table.AddCell(espacioB5)

                    documento.Add(table)
                    ' documento.Add(Chunk.NEWLINE)
                    ' documento.Add(New Chunk(vbCrLf))
                    i += 1

                Next
            End If




            'documento.setSpacingAfter(30.0F)
            'documento.Add(New Phrase("This is a header without a page number", New Font(bf_courier)))
            'Dim header As New HeaderFooter(New Phrase("This is a header without a page number", New Font(bf_symbol)), False)

            'pagina 3 visualizacion de datos
            documento.NewPage()
            'jpg.ScaleToFit(580.0F, 100.0F)
            'jpg.SpacingBefore = 1.0F
            'jpg.SpacingAfter = 1.0F
            'jpg.Alignment = Element.ALIGN_LEFT
            'documento.Add(jpg)
            'documento.Add(paragraph)
            'Dim Titulo3 As New [String]("   Avisos Importantes" & vbCrLf)
            'Dim Titulo4 As New [String](vbTab & "           La Importancia del Chequeo" & vbCrLf)
            'Dim Titulo4 As New iTextSharp.text.Paragraph("         La Importancia del Chequeo" & vbCrLf, SubtitleFont)
            'documento.Add(New Paragraph(Titulo3, titleFont))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("       "))
            documento.Add(New Chunk("Avisos Importantes", FontFactory.GetFont("Arial", 16, Font.BOLD)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            'documento.Add(Titulo4)
            'documento.Add(New Paragraph(Titulo4, titleFont))
            'documento.Add(New Chunk("underline", FontFactory.GetFont(FontFactory.HELVETICA, Font.DEFAULTSIZE, Font.UNDERLINE)))
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("La Importancia del Chequeo", FontFactory.GetFont("Arial", 10, Font.UNDERLINE)))
            ' documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("Información que se visualizara a acuerdo a la datos que den", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("dasdasdadasdasdasdasdasdasdasdasdasdasdasdasd", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("Novedades o Notificaciones empresariales", FontFactory.GetFont("Arial", 10, Font.UNDERLINE)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("Información de novedades o notificaciones qeu se den para visualizar los datos", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("dasdasdadasdasdasdasdasdasdasdasdasdasdasdasd", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("Números Teléfonicos importantes", FontFactory.GetFont("Arial", 10, Font.UNDERLINE)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(New Chunk("               "))
            documento.Add(New Chunk("dasdasdadasdasdasdasdasdasdasdasdasdasdasdasd", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
            'documento.Add(New Chunk(vbCrLf))
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)


            'Dim cb2 As PdfContentByte = writer.DirectContentUnder
            'Dim baseFont2 As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED)
            'cb2.BeginText()
            'cb2.SetFontAndSize(baseFont2, 10)
            'cb2.ShowTextAligned(Element.ALIGN_CENTER, "NO VALIDA PARA EFECTOS TRIBUTARIOS", 0, 0, 0)
            'cb2.EndText()



            documento.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
