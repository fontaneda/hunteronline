Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
'Imports System.Text

Public Class DocumentosPdf

    Public Sub GenerarDocumento(ByVal codigo As String, ByVal nombre As String, ByVal ruta As String)
        Try
            Dim dtParametros As New System.Data.DataSet
            dtParametros = DocumentosAdapter.ConsultaParametrosFactura(104, codigo)
            If dtParametros.Tables(0).Rows.Count > 0 Then
                Dim codigoSucursal As String = dtParametros.Tables(0).Rows(0)("CODIGO_SUCURSAL").ToString()
                Dim codigoEmpresa As String = dtParametros.Tables(0).Rows(0)("CODIGO_EMPRESA").ToString()
                Dim numeroMovimiento As String = dtParametros.Tables(0).Rows(0)("NUMERO_MOVIMIENTO").ToString()

                Dim dtCabecera As New System.Data.DataSet
                dtCabecera = DocumentosAdapter.ConsultaFactura(100, codigoSucursal, codigoEmpresa, numeroMovimiento)

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
                Dim file As String = String.Format("{0}Anexo_{1}", ruta, nombre)
                Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
                Dim paragraph As New iTextSharp.text.Paragraph(" ")
                Dim ev As New CreacionPdf()

                documento.Open()
                documento.NewPage()
                writer.PageEvent = ev
                documento.Add(paragraph)

                'DATOS DE LA FACTURA
                'documento.Add(Chunk.NEWLINE)
                'documento.Add(Chunk.NEWLINE)
                Dim tablaFactura As New PdfPTable(2)
                tablaFactura.SetWidths(New Single() {70.0F, 30.0F})
                'TITULO DEL DOCUMENTO
                Dim tituloFac0 As New PdfPCell(New Phrase(" ", fontcabecera))
                tituloFac0.Border = 0
                tituloFac0.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFactura.AddCell(tituloFac0)
                Dim tituloFac1 As New PdfPCell(New Phrase("Anexo de factura         ", fonttitulo))
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
                tituloFac5.Phrase.Add(New Chunk("Factura        ", fontBold))
                tituloFac5.Phrase.Add(New Chunk(dtCabecera.Tables(0).Rows(0)("REFERENCIA").ToString(), fontcabeceradetalle))
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
                Dim tituloFac7 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(0)("CLIENTE").ToString(), fontcabeceradetalle))
                tituloFac7.Border = 0
                tituloFac7.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(tituloFac7)
                'IDENTIFICACION DEL CLIENTE
                Dim tituloFac8 As New PdfPCell(New Phrase("Identificación", fontcabecera))
                tituloFac8.Border = 0
                tituloFac8.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(tituloFac8)
                Dim tituloFac9 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(0)("ID_CLIENTE").ToString(), fontcabeceradetalle))
                tituloFac9.Border = 0
                tituloFac9.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(tituloFac9)
                'FECHA FACTURA
                Dim tituloFac10 As New PdfPCell(New Phrase("Fecha de Factura", fontcabecera))
                tituloFac10.Border = 0
                tituloFac10.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(tituloFac10)
                Dim tituloFac11 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(0)("FECHA").ToString(), fontcabeceradetalle))
                tituloFac11.Border = 0
                tituloFac11.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(tituloFac11)
                documento.Add(tablaFacturacabecera)

                'DATOS DE FORMA DE PAGO
                documento.Add(Chunk.NEWLINE)
                'TITULO
                Dim tablatitulo1 As New PdfPTable(1)
                tablatitulo1.SetWidths(New Single() {100.0F})
                Dim titulot1 As New PdfPCell(New Phrase("Detalle de formas de pago", fontcabeceratabla))
                titulot1.Border = 0
                titulot1.BackgroundColor = New BaseColor(255, 255, 255)
                titulot1.HorizontalAlignment = Element.ALIGN_LEFT
                tablatitulo1.AddCell(titulot1)
                documento.Add(tablatitulo1)
                'DETALLE
                Dim tablacabecera As New PdfPTable(3)
                tablacabecera.SetWidths(New Single() {35.0F, 40.0F, 15.0F})
                Dim titulocab1 As New PdfPCell(New Phrase("Forma de Pago", fontcabeceratabla))
                titulocab1.Border = 0
                titulocab1.BackgroundColor = New BaseColor(217, 217, 217)
                titulocab1.BorderColor = New BaseColor(217, 217, 217)
                titulocab1.HorizontalAlignment = Element.ALIGN_CENTER
                tablacabecera.AddCell(titulocab1)
                Dim titulocab2 As New PdfPCell(New Phrase("Fecha Vencimiento", fontcabeceratabla))
                titulocab2.Border = 0
                titulocab2.BackgroundColor = New BaseColor(217, 217, 217)
                titulocab2.BorderColor = New BaseColor(217, 217, 217)
                titulocab2.HorizontalAlignment = Element.ALIGN_CENTER
                tablacabecera.AddCell(titulocab2)
                Dim titulocab3 As New PdfPCell(New Phrase("Valor", fontcabeceratabla))
                titulocab3.Border = 0
                titulocab3.BackgroundColor = New BaseColor(217, 217, 217)
                titulocab3.BorderColor = New BaseColor(217, 217, 217)
                titulocab3.HorizontalAlignment = Element.ALIGN_CENTER
                tablacabecera.AddCell(titulocab3)
                If dtCabecera.Tables(1).Rows.Count > 0 Then
                    For i = 0 To dtCabecera.Tables(1).Rows.Count - 1
                        Dim detalleform1 As New PdfPCell(New Phrase(dtCabecera.Tables(1).Rows(i)("DESC_FORMA_PAGO").ToString(), fontdetalletabla))
                        detalleform1.Border = 0
                        detalleform1.HorizontalAlignment = Element.ALIGN_LEFT
                        tablacabecera.AddCell(detalleform1)

                        Dim detalleform2 As New PdfPCell(New Phrase(dtCabecera.Tables(1).Rows(i)("FECHA_VENCIMIENTO").ToString(), fontdetalletabla))
                        detalleform2.Border = 0
                        detalleform2.HorizontalAlignment = Element.ALIGN_CENTER
                        tablacabecera.AddCell(detalleform2)

                        Dim detalleform3 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(1).Rows(i)("VALOR").ToString(), 2), fontdetalletabla))
                        detalleform3.Border = 0
                        detalleform3.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablacabecera.AddCell(detalleform3)
                    Next
                End If
                documento.Add(tablacabecera)

                'DATOS DE DETALLE DE CUOTAS
                documento.Add(Chunk.NEWLINE)
                'TITULO
                Dim tablatitulo2 As New PdfPTable(1)
                tablatitulo2.SetWidths(New Single() {100.0F})
                Dim titulot2 As New PdfPCell(New Phrase("Detalle de cuotas", fontcabeceratabla))
                titulot2.Border = 0
                titulot2.BackgroundColor = New BaseColor(255, 255, 255)
                titulot2.HorizontalAlignment = Element.ALIGN_LEFT
                tablatitulo2.AddCell(titulot2)
                documento.Add(tablatitulo2)
                'DETALLE
                Dim detallecabecera As New PdfPTable(4)
                Dim totalAbonado As Decimal = 0
                detallecabecera.SetWidths(New Single() {13.0F, 26.0F, 26.0F, 35.0F})
                Dim titulodet1 As New PdfPCell(New Phrase("No. Cuota", fontcabeceratabla))
                titulodet1.Border = 0
                titulodet1.BackgroundColor = New BaseColor(217, 217, 217)
                titulodet1.BorderColor = New BaseColor(217, 217, 217)
                titulodet1.HorizontalAlignment = Element.ALIGN_RIGHT
                detallecabecera.AddCell(titulodet1)
                Dim titulodet2 As New PdfPCell(New Phrase("Detalle de Cuotas", fontcabeceratabla))
                titulodet2.Border = 0
                titulodet2.BackgroundColor = New BaseColor(217, 217, 217)
                titulodet2.BorderColor = New BaseColor(217, 217, 217)
                titulodet2.HorizontalAlignment = Element.ALIGN_CENTER
                detallecabecera.AddCell(titulodet2)
                Dim titulodet3 As New PdfPCell(New Phrase("Valor acumulado", fontcabeceratabla))
                titulodet3.Border = 0
                titulodet3.BackgroundColor = New BaseColor(217, 217, 217)
                titulodet3.BorderColor = New BaseColor(217, 217, 217)
                titulodet3.HorizontalAlignment = Element.ALIGN_CENTER
                detallecabecera.AddCell(titulodet3)
                Dim titulodet4 As New PdfPCell(New Phrase("F. Vencimiento", fontcabeceratabla))
                titulodet4.Border = 0
                titulodet4.BackgroundColor = New BaseColor(217, 217, 217)
                titulodet4.BorderColor = New BaseColor(217, 217, 217)
                titulodet4.HorizontalAlignment = Element.ALIGN_CENTER
                detallecabecera.AddCell(titulodet4)
                If dtCabecera.Tables(2).Rows.Count > 0 Then
                    For i = 0 To dtCabecera.Tables(2).Rows.Count - 1
                        totalAbonado = totalAbonado + Convert.ToDecimal(dtCabecera.Tables(2).Rows(i)("VALOR"))
                        Dim detalleCuota1 As New PdfPCell(New Phrase(dtCabecera.Tables(2).Rows(i)("CUOTAS").ToString() & Space(8), fontdetalletabla))
                        detalleCuota1.Border = 0
                        detalleCuota1.HorizontalAlignment = Element.ALIGN_RIGHT
                        detalleCuota1.PaddingLeft = 50
                        detallecabecera.AddCell(detalleCuota1)

                        Dim detalleCuota2 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(2).Rows(i)("VALOR").ToString(), 2) & Space(5), fontdetalletabla))
                        detalleCuota2.Border = 0
                        detalleCuota2.HorizontalAlignment = Element.ALIGN_RIGHT
                        detalleCuota2.PaddingRight = 30
                        detallecabecera.AddCell(detalleCuota2)

                        Dim detalleCuota3 As New PdfPCell(New Phrase(Convert.ToString(FormatNumber(totalAbonado, 2)) & Space(5), fontdetalletabla))
                        detalleCuota3.Border = 0
                        detalleCuota3.HorizontalAlignment = Element.ALIGN_RIGHT
                        detalleCuota3.PaddingRight = 35
                        detallecabecera.AddCell(detalleCuota3)

                        Dim detalleCuota4 As New PdfPCell(New Phrase(dtCabecera.Tables(2).Rows(i)("FECHA").ToString() & Space(5), fontdetalletabla))
                        detalleCuota4.Border = 0
                        detalleCuota4.HorizontalAlignment = Element.ALIGN_RIGHT
                        detalleCuota4.PaddingRight = 45
                        detallecabecera.AddCell(detalleCuota4)
                    Next
                End If
                documento.Add(detallecabecera)

                'DATOS DE VEHICULOS
                documento.Add(Chunk.NEWLINE)
                'TITULO
                Dim tablatitulo3 As New PdfPTable(1)
                tablatitulo3.SetWidths(New Single() {100.0F})
                Dim titulot3 As New PdfPCell(New Phrase("Detalle de Vehículos", fontcabeceratabla))
                titulot3.Border = 0
                titulot3.BackgroundColor = New BaseColor(255, 255, 255)
                titulot3.HorizontalAlignment = Element.ALIGN_LEFT
                tablatitulo3.AddCell(titulot3)
                documento.Add(tablatitulo3)
                'DETALLE
                Dim totalveh As Int64 = dtCabecera.Tables(4).Rows(0)("TOTAL")
                Dim totalacum As Decimal = dtCabecera.Tables(4).Rows(0)("MONTO_ACUMULADO")
                Dim detallevehiculo As New PdfPTable(3)
                detallevehiculo.SetWidths(New Single() {67.0F, 10.0F, 23.0F})
                Dim tituloveh0 As New PdfPCell(New Phrase(String.Format("Vehículos ({0})", totalveh), fontcabeceratabla))
                tituloveh0.Border = 0
                tituloveh0.BackgroundColor = New BaseColor(217, 217, 217)
                tituloveh0.BorderColor = New BaseColor(217, 217, 217)
                tituloveh0.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(tituloveh0)
                Dim tituloveh1 As New PdfPCell(New Phrase("Monto", fontcabeceratabla))
                tituloveh1.Border = 0
                tituloveh1.BackgroundColor = New BaseColor(217, 217, 217)
                tituloveh1.BorderColor = New BaseColor(217, 217, 217)
                tituloveh1.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(tituloveh1)
                Dim tituloveh2 As New PdfPCell(New Phrase("Vencimientos de Coberturas", fontcabeceratabla))
                tituloveh2.Border = 0
                tituloveh2.BackgroundColor = New BaseColor(217, 217, 217)
                tituloveh2.BorderColor = New BaseColor(217, 217, 217)
                tituloveh2.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(tituloveh2)
                Dim tituloveh3 As New PdfPCell(New Phrase("[Marca / Modelo / Chasis / Motor / Placa / Orden Servicio]", fontdetalle))
                tituloveh3.Border = 0
                tituloveh3.PaddingBottom = 3
                tituloveh3.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(tituloveh3)
                Dim tituloveh4 As New PdfPCell(New Phrase(" ", fontdetalle))
                tituloveh4.Border = 0
                tituloveh4.PaddingBottom = 3
                tituloveh4.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(tituloveh4)
                Dim tituloveh5 As New PdfPCell(New Phrase("[Fecha final de cobertura]", fontdetalle))
                tituloveh5.Border = 0
                tituloveh5.PaddingBottom = 3
                tituloveh5.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(tituloveh5)
                Dim contador As Integer = 0
                Dim veces As Integer = 0
                Dim maximocontador As Integer = 43
                If dtCabecera.Tables(3).Rows.Count > 0 Then
                    For i = 0 To dtCabecera.Tables(3).Rows.Count - 1
                        Dim detVehiculo0 As New PdfPCell(New Phrase())
                        detVehiculo0.Phrase.Add(New Chunk(Trim(dtCabecera.Tables(3).Rows(i)("DESCRIPCION").ToString()), fontdetalleveh))
                        detVehiculo0.Phrase.Add(New Chunk(Trim(dtCabecera.Tables(3).Rows(i)("ORDEN").ToString()), fontnegro))
                        detVehiculo0.Border = 0
                        detVehiculo0.PaddingBottom = 1
                        detVehiculo0.HorizontalAlignment = Element.ALIGN_LEFT
                        detallevehiculo.AddCell(detVehiculo0)
                        Dim detVehiculo1 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(3).Rows(i)("MONTO").ToString(), 2), fontdetalleveh))
                        detVehiculo1.Border = 0
                        detVehiculo1.PaddingBottom = 1
                        detVehiculo1.HorizontalAlignment = Element.ALIGN_RIGHT
                        detallevehiculo.AddCell(detVehiculo1)
                        Dim detVehiculo2 As New PdfPCell(New Phrase(dtCabecera.Tables(3).Rows(i)("FECHA_FIN_COBERTURA").ToString(), fontdetalleveh))
                        detVehiculo2.Border = 0
                        detVehiculo2.PaddingBottom = 1
                        detVehiculo2.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(detVehiculo2)

                        contador = contador + 1
                        If contador = maximocontador Then
                            'Dim tituloveh10 As New PdfPCell(New Phrase(String.Format("Vehículos ({0})", totalveh), fontcabeceratabla))
                            tituloveh0.Border = 0
                            tituloveh0.BackgroundColor = New BaseColor(217, 217, 217)
                            tituloveh0.BorderColor = New BaseColor(217, 217, 217)
                            tituloveh0.HorizontalAlignment = Element.ALIGN_CENTER
                            detallevehiculo.AddCell(tituloveh0)
                            'Dim tituloveh11 As New PdfPCell(New Phrase("Monto", fontcabeceratabla))
                            tituloveh1.Border = 0
                            tituloveh1.BackgroundColor = New BaseColor(217, 217, 217)
                            tituloveh1.BorderColor = New BaseColor(217, 217, 217)
                            tituloveh1.HorizontalAlignment = Element.ALIGN_CENTER
                            detallevehiculo.AddCell(tituloveh1)
                            'Dim tituloveh12 As New PdfPCell(New Phrase("Vencimientos de Coberturas", fontcabeceratabla))
                            tituloveh2.Border = 0
                            tituloveh2.BackgroundColor = New BaseColor(217, 217, 217)
                            tituloveh2.BorderColor = New BaseColor(217, 217, 217)
                            tituloveh2.HorizontalAlignment = Element.ALIGN_CENTER
                            detallevehiculo.AddCell(tituloveh2)
                            'Dim tituloveh13 As New PdfPCell(New Phrase("[Marca / Modelo / Chasis / Motor / Placa / Orden Servicio]", fontdetalle))
                            tituloveh3.Border = 0
                            tituloveh3.PaddingBottom = 3
                            tituloveh3.HorizontalAlignment = Element.ALIGN_CENTER
                            detallevehiculo.AddCell(tituloveh3)
                            'Dim tituloveh14 As New PdfPCell(New Phrase(" ", fontdetalle))
                            tituloveh4.Border = 0
                            tituloveh4.PaddingBottom = 3
                            tituloveh4.HorizontalAlignment = Element.ALIGN_CENTER
                            detallevehiculo.AddCell(tituloveh4)
                            'Dim tituloveh15 As New PdfPCell(New Phrase("[Fecha final de cobertura]", fontdetalle))
                            tituloveh5.Border = 0
                            tituloveh5.PaddingBottom = 3
                            tituloveh5.HorizontalAlignment = Element.ALIGN_CENTER
                            detallevehiculo.AddCell(tituloveh5)

                            contador = 0
                            veces = veces + 1
                            If veces > 0 Then
                                maximocontador = 76
                            End If
                        End If

                    Next
                End If
                Dim detVehtot0 As New PdfPCell(New Phrase())
                detVehtot0.Phrase.Add(New Chunk(String.Format("Son {0} vehículos", totalveh), fontdetalleveh))
                detVehtot0.Border = 0
                detVehtot0.BorderColorTop = New BaseColor(217, 217, 217)
                detVehtot0.BorderWidthTop = 1
                detVehtot0.PaddingBottom = 1
                detVehtot0.HorizontalAlignment = Element.ALIGN_LEFT
                detallevehiculo.AddCell(detVehtot0)
                Dim detVehtot1 As New PdfPCell(New Phrase(FormatNumber(totalacum.ToString, 2), fontdetalleveh))
                detVehtot1.Border = 0
                detVehtot1.BorderColorTop = New BaseColor(217, 217, 217)
                detVehtot1.BorderWidthTop = 1
                detVehtot1.PaddingBottom = 1
                detVehtot1.HorizontalAlignment = Element.ALIGN_RIGHT
                detallevehiculo.AddCell(detVehtot1)
                Dim detVehtot2 As New PdfPCell(New Phrase(" ", fontdetalleveh))
                detVehtot2.Border = 0
                detVehtot2.PaddingBottom = 1
                detVehtot2.HorizontalAlignment = Element.ALIGN_CENTER
                detallevehiculo.AddCell(detVehtot2)

                documento.Add(detallevehiculo)
                documento.Close()
            End If
        Catch ex As Exception
            ' Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Public Function GenerarDocumento2(ByVal codigo As String, ByVal nombre As String, ByVal ruta As String) As Boolean
        Dim retorno As Boolean = True
        Try
            Dim dtParametros As New System.Data.DataSet
            dtParametros = DocumentosAdapter.ConsultaParametrosFactura(104, codigo)
            If dtParametros.Tables(0).Rows.Count > 0 Then
                Dim codigoSucursal As String = dtParametros.Tables(0).Rows(0)("CODIGO_SUCURSAL").ToString()
                Dim codigoEmpresa As String = dtParametros.Tables(0).Rows(0)("CODIGO_EMPRESA").ToString()
                Dim numeroMovimiento As String = dtParametros.Tables(0).Rows(0)("NUMERO_MOVIMIENTO").ToString()
                Dim dtCabecera As New System.Data.DataSet
                dtCabecera = DocumentosAdapter.ConsultaFactura(100, codigoSucursal, codigoEmpresa, numeroMovimiento)
                If dtCabecera.Tables.Count > 0 Then
                    If dtCabecera.Tables(0).Rows.Count > 0 Then
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
                        Dim file As String = String.Format("{0}Anexo_{1}", ruta, nombre)
                        Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
                        Dim paragraph As New iTextSharp.text.Paragraph(" ")
                        Dim ev As New CreacionPdf()

                        documento.Open()
                        documento.NewPage()
                        writer.PageEvent = ev
                        documento.Add(paragraph)

                        'DATOS DE LA FACTURA
                        'documento.Add(Chunk.NEWLINE)
                        'documento.Add(Chunk.NEWLINE)
                        Dim tablaFactura As New PdfPTable(2)
                        tablaFactura.SetWidths(New Single() {70.0F, 30.0F})
                        'TITULO DEL DOCUMENTO
                        Dim tituloFac0 As New PdfPCell(New Phrase(" ", fontcabecera))
                        tituloFac0.Border = 0
                        tituloFac0.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaFactura.AddCell(tituloFac0)
                        Dim tituloFac1 As New PdfPCell(New Phrase("Anexo de factura         ", fonttitulo))
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
                        tituloFac5.Phrase.Add(New Chunk("Factura        ", fontBold))
                        tituloFac5.Phrase.Add(New Chunk(dtCabecera.Tables(0).Rows(0)("REFERENCIA").ToString(), fontcabeceradetalle))
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
                        Dim tituloFac7 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(0)("CLIENTE").ToString(), fontcabeceradetalle))
                        tituloFac7.Border = 0
                        tituloFac7.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaFacturacabecera.AddCell(tituloFac7)
                        'IDENTIFICACION DEL CLIENTE
                        Dim tituloFac8 As New PdfPCell(New Phrase("Identificación", fontcabecera))
                        tituloFac8.Border = 0
                        tituloFac8.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaFacturacabecera.AddCell(tituloFac8)
                        Dim tituloFac9 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(0)("ID_CLIENTE").ToString(), fontcabeceradetalle))
                        tituloFac9.Border = 0
                        tituloFac9.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaFacturacabecera.AddCell(tituloFac9)
                        'FECHA FACTURA
                        Dim tituloFac10 As New PdfPCell(New Phrase("Fecha de Factura", fontcabecera))
                        tituloFac10.Border = 0
                        tituloFac10.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaFacturacabecera.AddCell(tituloFac10)
                        Dim tituloFac11 As New PdfPCell(New Phrase(dtCabecera.Tables(0).Rows(0)("FECHA").ToString(), fontcabeceradetalle))
                        tituloFac11.Border = 0
                        tituloFac11.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaFacturacabecera.AddCell(tituloFac11)
                        documento.Add(tablaFacturacabecera)

                        'DATOS DE FORMA DE PAGO
                        documento.Add(Chunk.NEWLINE)
                        'TITULO
                        Dim tablatitulo1 As New PdfPTable(1)
                        tablatitulo1.SetWidths(New Single() {100.0F})
                        Dim titulot1 As New PdfPCell(New Phrase("Detalle de formas de pago", fontcabeceratabla))
                        titulot1.Border = 0
                        titulot1.BackgroundColor = New BaseColor(255, 255, 255)
                        titulot1.HorizontalAlignment = Element.ALIGN_LEFT
                        tablatitulo1.AddCell(titulot1)
                        documento.Add(tablatitulo1)
                        'DETALLE
                        Dim tablacabecera As New PdfPTable(3)
                        tablacabecera.SetWidths(New Single() {35.0F, 40.0F, 15.0F})
                        Dim titulocab1 As New PdfPCell(New Phrase("Forma de Pago", fontcabeceratabla))
                        titulocab1.Border = 0
                        titulocab1.BackgroundColor = New BaseColor(217, 217, 217)
                        titulocab1.BorderColor = New BaseColor(217, 217, 217)
                        titulocab1.HorizontalAlignment = Element.ALIGN_CENTER
                        tablacabecera.AddCell(titulocab1)
                        Dim titulocab2 As New PdfPCell(New Phrase("Fecha Vencimiento", fontcabeceratabla))
                        titulocab2.Border = 0
                        titulocab2.BackgroundColor = New BaseColor(217, 217, 217)
                        titulocab2.BorderColor = New BaseColor(217, 217, 217)
                        titulocab2.HorizontalAlignment = Element.ALIGN_CENTER
                        tablacabecera.AddCell(titulocab2)
                        Dim titulocab3 As New PdfPCell(New Phrase("Valor", fontcabeceratabla))
                        titulocab3.Border = 0
                        titulocab3.BackgroundColor = New BaseColor(217, 217, 217)
                        titulocab3.BorderColor = New BaseColor(217, 217, 217)
                        titulocab3.HorizontalAlignment = Element.ALIGN_CENTER
                        tablacabecera.AddCell(titulocab3)
                        If dtCabecera.Tables(1).Rows.Count > 0 Then
                            For i = 0 To dtCabecera.Tables(1).Rows.Count - 1
                                Dim detalleform1 As New PdfPCell(New Phrase(dtCabecera.Tables(1).Rows(i)("DESC_FORMA_PAGO").ToString(), fontdetalletabla))
                                detalleform1.Border = 0
                                detalleform1.HorizontalAlignment = Element.ALIGN_LEFT
                                tablacabecera.AddCell(detalleform1)

                                Dim detalleform2 As New PdfPCell(New Phrase(dtCabecera.Tables(1).Rows(i)("FECHA_VENCIMIENTO").ToString(), fontdetalletabla))
                                detalleform2.Border = 0
                                detalleform2.HorizontalAlignment = Element.ALIGN_CENTER
                                tablacabecera.AddCell(detalleform2)

                                Dim detalleform3 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(1).Rows(i)("VALOR").ToString(), 2), fontdetalletabla))
                                detalleform3.Border = 0
                                detalleform3.HorizontalAlignment = Element.ALIGN_RIGHT
                                tablacabecera.AddCell(detalleform3)
                            Next
                        End If
                        documento.Add(tablacabecera)

                        'DATOS DE DETALLE DE CUOTAS
                        documento.Add(Chunk.NEWLINE)
                        'TITULO
                        Dim tablatitulo2 As New PdfPTable(1)
                        tablatitulo2.SetWidths(New Single() {100.0F})
                        Dim titulot2 As New PdfPCell(New Phrase("Detalle de cuotas", fontcabeceratabla))
                        titulot2.Border = 0
                        titulot2.BackgroundColor = New BaseColor(255, 255, 255)
                        titulot2.HorizontalAlignment = Element.ALIGN_LEFT
                        tablatitulo2.AddCell(titulot2)
                        documento.Add(tablatitulo2)
                        'DETALLE
                        Dim detallecabecera As New PdfPTable(4)
                        Dim totalAbonado As Decimal = 0
                        detallecabecera.SetWidths(New Single() {13.0F, 26.0F, 26.0F, 35.0F})
                        Dim titulodet1 As New PdfPCell(New Phrase("No. Cuota", fontcabeceratabla))
                        titulodet1.Border = 0
                        titulodet1.BackgroundColor = New BaseColor(217, 217, 217)
                        titulodet1.BorderColor = New BaseColor(217, 217, 217)
                        titulodet1.HorizontalAlignment = Element.ALIGN_RIGHT
                        detallecabecera.AddCell(titulodet1)
                        Dim titulodet2 As New PdfPCell(New Phrase("Detalle de Cuotas", fontcabeceratabla))
                        titulodet2.Border = 0
                        titulodet2.BackgroundColor = New BaseColor(217, 217, 217)
                        titulodet2.BorderColor = New BaseColor(217, 217, 217)
                        titulodet2.HorizontalAlignment = Element.ALIGN_CENTER
                        detallecabecera.AddCell(titulodet2)
                        Dim titulodet3 As New PdfPCell(New Phrase("Valor acumulado", fontcabeceratabla))
                        titulodet3.Border = 0
                        titulodet3.BackgroundColor = New BaseColor(217, 217, 217)
                        titulodet3.BorderColor = New BaseColor(217, 217, 217)
                        titulodet3.HorizontalAlignment = Element.ALIGN_CENTER
                        detallecabecera.AddCell(titulodet3)
                        Dim titulodet4 As New PdfPCell(New Phrase("F. Vencimiento", fontcabeceratabla))
                        titulodet4.Border = 0
                        titulodet4.BackgroundColor = New BaseColor(217, 217, 217)
                        titulodet4.BorderColor = New BaseColor(217, 217, 217)
                        titulodet4.HorizontalAlignment = Element.ALIGN_CENTER
                        detallecabecera.AddCell(titulodet4)
                        If dtCabecera.Tables(2).Rows.Count > 0 Then
                            For i = 0 To dtCabecera.Tables(2).Rows.Count - 1
                                totalAbonado = totalAbonado + Convert.ToDecimal(dtCabecera.Tables(2).Rows(i)("VALOR"))
                                Dim detalleCuota1 As New PdfPCell(New Phrase(dtCabecera.Tables(2).Rows(i)("CUOTAS").ToString() & Space(8), fontdetalletabla))
                                detalleCuota1.Border = 0
                                detalleCuota1.HorizontalAlignment = Element.ALIGN_RIGHT
                                detalleCuota1.PaddingLeft = 50
                                detallecabecera.AddCell(detalleCuota1)

                                Dim detalleCuota2 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(2).Rows(i)("VALOR").ToString(), 2) & Space(5), fontdetalletabla))
                                detalleCuota2.Border = 0
                                detalleCuota2.HorizontalAlignment = Element.ALIGN_RIGHT
                                detalleCuota2.PaddingRight = 30
                                detallecabecera.AddCell(detalleCuota2)

                                Dim detalleCuota3 As New PdfPCell(New Phrase(Convert.ToString(FormatNumber(totalAbonado, 2)) & Space(5), fontdetalletabla))
                                detalleCuota3.Border = 0
                                detalleCuota3.HorizontalAlignment = Element.ALIGN_RIGHT
                                detalleCuota3.PaddingRight = 35
                                detallecabecera.AddCell(detalleCuota3)

                                Dim detalleCuota4 As New PdfPCell(New Phrase(dtCabecera.Tables(2).Rows(i)("FECHA").ToString() & Space(5), fontdetalletabla))
                                detalleCuota4.Border = 0
                                detalleCuota4.HorizontalAlignment = Element.ALIGN_RIGHT
                                detalleCuota4.PaddingRight = 45
                                detallecabecera.AddCell(detalleCuota4)
                            Next
                        End If
                        documento.Add(detallecabecera)

                        'DATOS DE VEHICULOS
                        documento.Add(Chunk.NEWLINE)
                        'TITULO
                        Dim tablatitulo3 As New PdfPTable(1)
                        tablatitulo3.SetWidths(New Single() {100.0F})
                        Dim titulot3 As New PdfPCell(New Phrase("Detalle de Vehículos", fontcabeceratabla))
                        titulot3.Border = 0
                        titulot3.BackgroundColor = New BaseColor(255, 255, 255)
                        titulot3.HorizontalAlignment = Element.ALIGN_LEFT
                        tablatitulo3.AddCell(titulot3)
                        documento.Add(tablatitulo3)
                        'DETALLE
                        Dim totalveh As Int64 = dtCabecera.Tables(4).Rows(0)("TOTAL")
                        Dim totalacum As Decimal = dtCabecera.Tables(4).Rows(0)("MONTO_ACUMULADO")
                        Dim detallevehiculo As New PdfPTable(3)
                        detallevehiculo.SetWidths(New Single() {67.0F, 10.0F, 23.0F})
                        Dim tituloveh0 As New PdfPCell(New Phrase(String.Format("Vehículos ({0})", totalveh), fontcabeceratabla))
                        tituloveh0.Border = 0
                        tituloveh0.BackgroundColor = New BaseColor(217, 217, 217)
                        tituloveh0.BorderColor = New BaseColor(217, 217, 217)
                        tituloveh0.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(tituloveh0)
                        Dim tituloveh1 As New PdfPCell(New Phrase("Monto", fontcabeceratabla))
                        tituloveh1.Border = 0
                        tituloveh1.BackgroundColor = New BaseColor(217, 217, 217)
                        tituloveh1.BorderColor = New BaseColor(217, 217, 217)
                        tituloveh1.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(tituloveh1)
                        Dim tituloveh2 As New PdfPCell(New Phrase("Vencimientos de Coberturas", fontcabeceratabla))
                        tituloveh2.Border = 0
                        tituloveh2.BackgroundColor = New BaseColor(217, 217, 217)
                        tituloveh2.BorderColor = New BaseColor(217, 217, 217)
                        tituloveh2.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(tituloveh2)
                        Dim tituloveh3 As New PdfPCell(New Phrase("[Marca / Modelo / Chasis / Motor / Placa / Orden Servicio]", fontdetalle))
                        tituloveh3.Border = 0
                        tituloveh3.PaddingBottom = 3
                        tituloveh3.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(tituloveh3)
                        Dim tituloveh4 As New PdfPCell(New Phrase(" ", fontdetalle))
                        tituloveh4.Border = 0
                        tituloveh4.PaddingBottom = 3
                        tituloveh4.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(tituloveh4)
                        Dim tituloveh5 As New PdfPCell(New Phrase("[Fecha final de cobertura]", fontdetalle))
                        tituloveh5.Border = 0
                        tituloveh5.PaddingBottom = 3
                        tituloveh5.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(tituloveh5)
                        Dim contador As Integer = 0
                        Dim veces As Integer = 0
                        Dim maximocontador As Integer = 43
                        If dtCabecera.Tables(3).Rows.Count > 0 Then
                            For i = 0 To dtCabecera.Tables(3).Rows.Count - 1
                                Dim detVehiculo0 As New PdfPCell(New Phrase())
                                detVehiculo0.Phrase.Add(New Chunk(Trim(dtCabecera.Tables(3).Rows(i)("DESCRIPCION").ToString()), fontdetalleveh))
                                detVehiculo0.Phrase.Add(New Chunk(Trim(dtCabecera.Tables(3).Rows(i)("ORDEN").ToString()), fontnegro))
                                detVehiculo0.Border = 0
                                detVehiculo0.PaddingBottom = 1
                                detVehiculo0.HorizontalAlignment = Element.ALIGN_LEFT
                                detallevehiculo.AddCell(detVehiculo0)
                                Dim detVehiculo1 As New PdfPCell(New Phrase(FormatNumber(dtCabecera.Tables(3).Rows(i)("MONTO").ToString(), 2), fontdetalleveh))
                                detVehiculo1.Border = 0
                                detVehiculo1.PaddingBottom = 1
                                detVehiculo1.HorizontalAlignment = Element.ALIGN_RIGHT
                                detallevehiculo.AddCell(detVehiculo1)
                                Dim detVehiculo2 As New PdfPCell(New Phrase(dtCabecera.Tables(3).Rows(i)("FECHA_FIN_COBERTURA").ToString(), fontdetalleveh))
                                detVehiculo2.Border = 0
                                detVehiculo2.PaddingBottom = 1
                                detVehiculo2.HorizontalAlignment = Element.ALIGN_CENTER
                                detallevehiculo.AddCell(detVehiculo2)

                                contador = contador + 1
                                If contador = maximocontador Then
                                    'Dim tituloveh10 As New PdfPCell(New Phrase(String.Format("Vehículos ({0})", totalveh), fontcabeceratabla))
                                    tituloveh0.Border = 0
                                    tituloveh0.BackgroundColor = New BaseColor(217, 217, 217)
                                    tituloveh0.BorderColor = New BaseColor(217, 217, 217)
                                    tituloveh0.HorizontalAlignment = Element.ALIGN_CENTER
                                    detallevehiculo.AddCell(tituloveh0)
                                    'Dim tituloveh11 As New PdfPCell(New Phrase("Monto", fontcabeceratabla))
                                    tituloveh1.Border = 0
                                    tituloveh1.BackgroundColor = New BaseColor(217, 217, 217)
                                    tituloveh1.BorderColor = New BaseColor(217, 217, 217)
                                    tituloveh1.HorizontalAlignment = Element.ALIGN_CENTER
                                    detallevehiculo.AddCell(tituloveh1)
                                    'Dim tituloveh12 As New PdfPCell(New Phrase("Vencimientos de Coberturas", fontcabeceratabla))
                                    tituloveh2.Border = 0
                                    tituloveh2.BackgroundColor = New BaseColor(217, 217, 217)
                                    tituloveh2.BorderColor = New BaseColor(217, 217, 217)
                                    tituloveh2.HorizontalAlignment = Element.ALIGN_CENTER
                                    detallevehiculo.AddCell(tituloveh2)
                                    'Dim tituloveh13 As New PdfPCell(New Phrase("[Marca / Modelo / Chasis / Motor / Placa / Orden Servicio]", fontdetalle))
                                    tituloveh3.Border = 0
                                    tituloveh3.PaddingBottom = 3
                                    tituloveh3.HorizontalAlignment = Element.ALIGN_CENTER
                                    detallevehiculo.AddCell(tituloveh3)
                                    'Dim tituloveh14 As New PdfPCell(New Phrase(" ", fontdetalle))
                                    tituloveh4.Border = 0
                                    tituloveh4.PaddingBottom = 3
                                    tituloveh4.HorizontalAlignment = Element.ALIGN_CENTER
                                    detallevehiculo.AddCell(tituloveh4)
                                    'Dim tituloveh15 As New PdfPCell(New Phrase("[Fecha final de cobertura]", fontdetalle))
                                    tituloveh5.Border = 0
                                    tituloveh5.PaddingBottom = 3
                                    tituloveh5.HorizontalAlignment = Element.ALIGN_CENTER
                                    detallevehiculo.AddCell(tituloveh5)

                                    contador = 0
                                    veces = veces + 1
                                    If veces > 0 Then
                                        maximocontador = 76
                                    End If
                                End If

                            Next
                        End If
                        Dim detVehtot0 As New PdfPCell(New Phrase())
                        detVehtot0.Phrase.Add(New Chunk(String.Format("Son {0} vehículos", totalveh), fontdetalleveh))
                        detVehtot0.Border = 0
                        detVehtot0.BorderColorTop = New BaseColor(217, 217, 217)
                        detVehtot0.BorderWidthTop = 1
                        detVehtot0.PaddingBottom = 1
                        detVehtot0.HorizontalAlignment = Element.ALIGN_LEFT
                        detallevehiculo.AddCell(detVehtot0)
                        Dim detVehtot1 As New PdfPCell(New Phrase(FormatNumber(totalacum.ToString, 2), fontdetalleveh))
                        detVehtot1.Border = 0
                        detVehtot1.BorderColorTop = New BaseColor(217, 217, 217)
                        detVehtot1.BorderWidthTop = 1
                        detVehtot1.PaddingBottom = 1
                        detVehtot1.HorizontalAlignment = Element.ALIGN_RIGHT
                        detallevehiculo.AddCell(detVehtot1)
                        Dim detVehtot2 As New PdfPCell(New Phrase(" ", fontdetalleveh))
                        detVehtot2.Border = 0
                        detVehtot2.PaddingBottom = 1
                        detVehtot2.HorizontalAlignment = Element.ALIGN_CENTER
                        detallevehiculo.AddCell(detVehtot2)

                        documento.Add(detallevehiculo)
                        documento.Close()
                    Else
                        retorno = False
                    End If
                Else
                    retorno = False
                End If
            Else
                retorno = False
            End If
        Catch ex As Exception
            retorno = False
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function

End Class
