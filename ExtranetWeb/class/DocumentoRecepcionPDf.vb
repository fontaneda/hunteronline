Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Imports MessagingToolkit.Barcode

Public Class DocumentoRecepcionPDf

    Public Sub GuiaRecepcion(cliente As String, orden As String, ByVal archivo As String, ByVal fecha As String, ByVal lugar As String, ByVal taller As String)
        'Dim retorno As String = ""
        Try
            'Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Arial", 14, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fonttexto As iTextSharp.text.Font = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)
            Dim fonttextonegrita As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fonttitulo As iTextSharp.text.Font = FontFactory.GetFont("Arial", 16, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontSalto As iTextSharp.text.Font = FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fonttextonegritafin As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fonttexto2 As iTextSharp.text.Font = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)
            Dim fonttextonegrita2 As iTextSharp.text.Font = FontFactory.GetFont("Arial", 11, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fonttextonuevo As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, Font.NORMAL, New BaseColor(128, 128, 128))

            'CREACION DE DOCUMENTO
            Dim documento As New Document(PageSize.A4, 5.0F, 0.0F, 0.0F, 0.0F)
            'Dim documento As New Document(PageSize.A4, 5.0F, 12.0F, 100.0F, 0.0F)
            'Dim nombreFile As String = "Recepción_Vehículo_" & cliente & "_" & Date.Now.ToString("yyyyMMdd") & "_" & Date.Now.ToString("HHmmss") & ".pdf"
            'Dim file As String = String.Format("{0}{1}", ConsultaRuta(), nombreFile)
            'Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(archivo, FileMode.Create))
            'Dim paragraph As New iTextSharp.text.Paragraph(" ")
            Dim ev As New CreacionPdfDocumento()
            'Dim ev As New CreacionPdfCertificados()

            'APERTURA DEL DOCUMENTO
            documento.Open()
            'documento.NewPage()
            writer.PageEvent = ev
            'documento.Add(paragraph)

            Dim androidTurnos As New VehiculoTurnoAdapter
            Dim dTDatos As DataSet
            dTDatos = androidTurnos.ConsultaDatosRecepcion(cliente, orden)
            If dTDatos.Tables.Count > 0 Then
                If dTDatos.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 1 To 2
                        documento.NewPage()
                        Dim tablaDocumento As New PdfPTable(2)
                        tablaDocumento.SetWidths(New Single() {32.0F, 68.0F})
                        'TITULO DEL DOCUMENTO
                        Dim tituloFac0 As New PdfPCell(New Phrase("  ", fonttitulo))
                        tituloFac0.Border = 0
                        tituloFac0.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaDocumento.AddCell(tituloFac0)
                        tablaDocumento.AddCell(tituloFac0)

                        tablaDocumento.AddCell(tituloFac0)
                        Dim tituloFac1 As New PdfPCell(New Phrase("CARRO SEGURO CARSEG S.A. ", fonttitulo))
                        tituloFac1.Border = 0
                        tituloFac1.PaddingTop = 14
                        tituloFac1.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaDocumento.AddCell(tituloFac1)

                        tablaDocumento.AddCell(tituloFac0)
                        'Dim tituloFac2 As New PdfPCell(New Phrase("Cdla. Vernaza Norte Mz. 12 S. 200, Guayaquil, 22/04/2020 11:37 ", fonttexto))
                        Dim tituloFac2 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("LUGAR_FECHA"), fonttexto))
                        tituloFac2.Border = 1
                        tituloFac2.BorderColor = New BaseColor(128, 128, 128)
                        tituloFac2.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaDocumento.AddCell(tituloFac2)

                        tablaDocumento.AddCell(tituloFac0)
                        tablaDocumento.AddCell(tituloFac0)

                        Dim codimagen As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("https://www.hunteronline.com.ec/IMGCOTIZADORWEB/Imagenescampanias/Logo_hunter_turno.png")
                        codimagen.ScalePercent(86.0F)
                        Dim cellimagen As New PdfPCell(codimagen)
                        cellimagen.Border = 0
                        cellimagen.Colspan = 2
                        tablaDocumento.AddCell(cellimagen)
                       
                        Dim tituloFac01 As New PdfPCell(New Phrase("  ", fontSalto))
                        tituloFac01.Border = 0
                        tituloFac01.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaDocumento.AddCell(tituloFac01)
                        tablaDocumento.AddCell(tituloFac01)

                        tablaDocumento.AddCell(tituloFac0)
                        tablaDocumento.AddCell(tituloFac0)

                        'Dim tituloFac3 As New PdfPCell(New Phrase(" Información Adicional ", fontcabecera))
                        Dim tituloFac3 As New PdfPCell(New Phrase("Estimado Cliente", fonttextonegrita))
                        tituloFac3.Border = 0
                        tituloFac3.Colspan = 2
                        'tituloFac3.BackgroundColor = New BaseColor(230, 230, 230)
                        'tituloFac3.HorizontalAlignment = Element.ALIGN_CENTER
                        tituloFac3.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento.AddCell(tituloFac3)

                        'Dim tituloFac4 As New PdfPCell(New Phrase("  ", fontSalto))
                        'tituloFac4.Border = 1
                        'tituloFac4.BorderColor = New BaseColor(128, 128, 128)
                        Dim tituloFac4 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("CLIENTE"), fonttexto))
                        tituloFac4.Border = 0
                        tituloFac4.Colspan = 2
                        'tituloFac4.HorizontalAlignment = Element.ALIGN_CENTER
                        tituloFac4.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento.AddCell(tituloFac4)

                        tablaDocumento.AddCell(tituloFac01)
                        tablaDocumento.AddCell(tituloFac01)

                        tablaDocumento.AddCell(tituloFac01)
                        tablaDocumento.AddCell(tituloFac01)

                        'Dim tituloFac5 As New PdfPCell(New Phrase("Gracias por utilizar nuestro servicio de turnos para realizar su " + dTDatos.Tables(0).Rows(0).Item("TRABAJO") + ", confirmamos su fecha y hora de atención es:", fonttextonuevo))
                        Dim trabajo As String = dTDatos.Tables(0).Rows(0).Item("TRABAJO")
                        Dim phrase5 As Phrase = Nothing
                        phrase5 = New Phrase()
                        phrase5.Add(New Chunk("Gracias por utilizar nuestro servicio de turnos para realizar su ", fonttextonuevo))
                        phrase5.Add(New Chunk(trabajo, fonttextonegrita))
                        phrase5.Add(New Chunk(", confirmamos su fecha y hora de atención es:", fonttextonuevo))
                        Dim tituloFac5 As New PdfPCell(phrase5)
                        tituloFac5.Border = 0
                        tituloFac5.Colspan = 2
                        tituloFac5.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento.AddCell(tituloFac5)

                        tablaDocumento.AddCell(tituloFac01)
                        tablaDocumento.AddCell(tituloFac01)

                      

                        documento.Add(tablaDocumento)

                        Dim tablaDocumento2 As New PdfPTable(4)
                        tablaDocumento2.SetWidths(New Single() {14.0F, 36.0F, 9.0F, 41.0F})
                        'Dim tituloDet1 As New PdfPCell(New Phrase("Nombre:", fonttextonegrita))
                        'tituloDet1.Border = 0
                        'tituloDet1.HorizontalAlignment = Element.ALIGN_LEFT
                        'tablaDocumento2.AddCell(tituloDet1)
                        ''Dim tituloDet2 As New PdfPCell(New Phrase("0912345678 – PEPITA PEREZ", fonttexto))
                        'Dim tituloDet2 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("CLIENTE"), fonttexto))
                        'tituloDet2.Border = 0
                        'tituloDet2.Colspan = 3
                        'tituloDet2.HorizontalAlignment = Element.ALIGN_LEFT
                        'tablaDocumento2.AddCell(tituloDet2)


                        Dim tituloDet1 As New PdfPCell(New Phrase("Fecha:", fonttextonegrita))
                        tituloDet1.Border = 0
                        tituloDet1.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet1)
                        Dim tituloDet01 As New PdfPCell(New Phrase(fecha, fonttexto))
                        tituloDet01.Border = 0
                        tituloDet01.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet01)
                        Dim tituloDet05 As New PdfPCell(New Phrase("Taller:", fonttextonegrita))
                        tituloDet05.Border = 0
                        tituloDet05.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet05)
                        Dim tituloDet06 As New PdfPCell(New Phrase(taller, fonttexto))
                        tituloDet06.Border = 0
                        tituloDet06.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet06)

                        Dim tituloDet03 As New PdfPCell(New Phrase("Lugar:", fonttextonegrita))
                        tituloDet03.Border = 0
                        tituloDet03.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet03)
                        Dim tituloDet04 As New PdfPCell(New Phrase(lugar, fonttexto))
                        tituloDet04.Border = 0
                        tituloDet04.Colspan = 3
                        tituloDet04.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet04)
                      


                        Dim tituloDet3 As New PdfPCell(New Phrase("Vehículo:", fonttextonegrita))
                        tituloDet3.Border = 0
                        tituloDet3.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet3)
                        Dim tituloDet4 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("MARC_MOD_TIP"), fonttexto))
                        tituloDet4.Border = 0
                        tituloDet4.Colspan = 3
                        tituloDet4.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet4)

                        Dim tituloDet5 As New PdfPCell(New Phrase("Email:", fonttextonegrita))
                        tituloDet5.Border = 0
                        tituloDet5.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet5)
                        Dim tituloDet6 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("EMAIL"), fonttexto))
                        tituloDet6.Border = 0
                        tituloDet6.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet6)
                        Dim tituloDet7 As New PdfPCell(New Phrase("Placa:", fonttextonegrita))
                        tituloDet7.Border = 0
                        tituloDet7.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet7)
                        Dim tituloDet8 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("PLACA"), fonttexto))
                        tituloDet8.Border = 0
                        tituloDet8.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet8)


                        Dim tituloDet9 As New PdfPCell(New Phrase("Telf. Fijo:", fonttextonegrita))
                        tituloDet9.Border = 0
                        tituloDet9.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet9)
                        Dim tituloDet10 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("TELEFONO"), fonttexto))
                        tituloDet10.Border = 0
                        tituloDet10.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet10)
                        Dim tituloDet11 As New PdfPCell(New Phrase("Chasis:", fonttextonegrita))
                        tituloDet11.Border = 0
                        tituloDet11.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet11)
                        Dim tituloDet12 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("SERIE_CHASIS"), fonttexto))
                        tituloDet12.Border = 0
                        tituloDet12.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet12)


                        Dim tituloDet13 As New PdfPCell(New Phrase("Telf. Celular:", fonttextonegrita))
                        tituloDet13.Border = 0
                        tituloDet13.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet13)
                        Dim tituloDet14 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("CELULAR"), fonttexto))
                        tituloDet14.Border = 0
                        tituloDet14.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet14)
                        Dim tituloDet15 As New PdfPCell(New Phrase("Motor:", fonttextonegrita))
                        tituloDet15.Border = 0
                        tituloDet15.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet15)
                        Dim tituloDet16 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("NO_MOTOR"), fonttexto))
                        tituloDet16.Border = 0
                        tituloDet16.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento2.AddCell(tituloDet16)

                        documento.Add(tablaDocumento2)

                        Dim tablaDocumento5 As New PdfPTable(1)
                        tablaDocumento5.SetWidths(New Single() {100.0F})

                        Dim grupo1Form30 As New PdfPCell(New Phrase("Quien suscribe la presente acta, en su calidad de propietario del vehículo o ne representación del mismo, declara que las condiciones del vehículo ingresado hoy a los talleres de Carseg S.A., constantes en la presente acta, fueron leídos, revisadas y aceptadas por éste. Para constancia, la presente acta se remitirá al correo electrónico del cliente, acompañando fotos del proceso de recepción, para su respaldo. ", fonttextonuevo))
                        grupo1Form30.Border = 0
                        grupo1Form30.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento5.AddCell(grupo1Form30)
                        tablaDocumento5.AddCell(tituloFac01)

                        Dim grupo1Form31 As New PdfPCell(New Phrase("Recuerde: ", fonttextonuevo))
                        grupo1Form31.Border = 0
                        grupo1Form31.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento5.AddCell(grupo1Form31)

                        Dim grupo1Form32 As New PdfPCell(New Phrase("  - Para retirar el vehículo, acérquese 30 minutos antes a Sericios al cliente, a fin de regularizar documentos y/o realizar pagos.", fonttextonuevo))
                        grupo1Form32.Border = 0
                        grupo1Form32.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento5.AddCell(grupo1Form32)

                        Dim grupo1Form33 As New PdfPCell(New Phrase("  - La hora de entrega del vehículo es proporcionada por nuestro Asesor de Servicios, consulte el horario de cierre del taller y evite inconvenientes. ", fonttextonuevo))
                        grupo1Form33.Border = 0
                        grupo1Form33.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento5.AddCell(grupo1Form33)
                        tablaDocumento5.AddCell(tituloFac01)

                        documento.Add(tablaDocumento5)

                        ' Imprime el codigo de barra
                        Dim tablaDocumento3 As New PdfPTable(1)
                        tablaDocumento3.SetWidths(New Single() {100.0F})

                        tablaDocumento3.AddCell(tituloFac01)
                        ' tablaDocumento3.AddCell(tituloFac0)

                        Dim phrase2 As Phrase = Nothing
                        phrase2 = New Phrase()
                        phrase2.Add(New Chunk("ORDEN DE SERVICIO #  ", fonttextonegrita2))
                        phrase2.Add(New Chunk(orden, fonttexto2))
                        Dim grupo1Form2 As New PdfPCell(phrase2)
                        grupo1Form2.Border = 0
                        grupo1Form2.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento3.AddCell(grupo1Form2)
                        documento.Add(tablaDocumento3)

                        ' Imprime el codigo de barra
                        If orden <> "" Then
                            Dim data As String = orden
                            If String.IsNullOrEmpty(data) Then
                                'imgqrgenerator.Visible = False
                                Return
                            End If
                            Dim fmt As BarcodeFormat = BarcodeFormat.QRCode
                            Dim tempFileName As String = String.Empty
                            Dim image As System.Drawing.Image = barcodeEncoder.Encode(fmt, data)
                            'tempFileName = "\\10.100.107.14\Qpr\" + GenerateRandomFileName("~/")
                            tempFileName = dTDatos.Tables(0).Rows(0).Item("RUTAQR") + orden + ".jpg"
                            barcodeEncoder.SaveImage(tempFileName, SaveOptions.Png)
                            Dim codbarra As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tempFileName)
                            codbarra.ScalePercent(65.0F)
                            'codbarra.ScaleToFit(250.0F, 250.0F)
                            'codbarra.ScalePercent(75.0F)
                            'codbarra.Border = 0
                            codbarra.Alignment = Element.ALIGN_CENTER
                            documento.Add(codbarra)
                            'tablaDocumento3.AddCell(codbarra)
                        End If

                        Dim tablaDocumento4 As New PdfPTable(1)
                        tablaDocumento4.SetWidths(New Single() {100.0F})
                        'tablaDocumento4.AddCell(tituloFac0)

                        'Dim grupo1Form3 As New PdfPCell(New Phrase("Servicio Contratado", fonttextonegrita2))
                        ''grupo1Form3.Border = 5
                        'grupo1Form3.BorderColor = New BaseColor(128, 128, 128)
                        ''grupo1Form3.BackgroundColor = New BaseColor(230, 230, 230)
                        ''grupo1Form3.Colspan = 2
                        'grupo1Form3.HorizontalAlignment = Element.ALIGN_LEFT
                        'tablaDocumento4.AddCell(grupo1Form3)

                        ''Dim grupo1Form3 As New PdfPCell(New Phrase("Para su comodidad recuerde que nuestro Call Center (04) 6004640 y número de WhatsApp 0994408582 están a su disposición para cambios de fecha y hora o si prefiere comuníquese con su ejecutiva de cuenta. ", fonttextonuevo))
                        Dim phrase3 As Phrase = Nothing
                        phrase3 = New Phrase()
                        phrase3.Add(New Chunk("Para su comodidad recuerde que nuestro Call Center ", fonttextonuevo))
                        phrase3.Add(New Chunk(" (04) 6004640 ", fonttextonegrita2))
                        phrase3.Add(New Chunk(" y número de WhatsApp ", fonttextonuevo))
                        phrase3.Add(New Chunk(" 0994408582 ", fonttextonegrita2))
                        phrase3.Add(New Chunk(" están a su disposición para cambios de fecha y hora o si prefiere comuníquese con su ejecutiva de cuenta. ", fonttextonuevo))

                        Dim grupo1Form3 As New PdfPCell(phrase3)
                        grupo1Form3.Border = 0
                        grupo1Form3.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaDocumento4.AddCell(grupo1Form3)


                        'Dim grupo1Form4 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("TRABAJO"), fonttexto2))
                        ''grupo1Form4.Border = 5
                        'grupo1Form4.BorderColor = New BaseColor(128, 128, 128)
                        ''grupo1Form4.Colspan = 2
                        'grupo1Form4.HorizontalAlignment = Element.ALIGN_LEFT
                        'tablaDocumento4.AddCell(grupo1Form4)
                        ''tablaDocumento3.AddCell(tituloFac0)
                        'tablaDocumento4.AddCell(tituloFac0)

                        Dim grupo1Form5 As New PdfPCell(New Phrase("Turno Reservado en HunterOnline.com", fonttextonegritafin))
                        grupo1Form5.Border = 0
                        'grupo1Form5.Colspan = 2
                        grupo1Form5.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaDocumento4.AddCell(grupo1Form5)
                        documento.Add(tablaDocumento4)

                        documento.NewPage()
                        'documento.Add(Chunk.NEWLINE)

                     
                        Dim imagepath As String = "\\10.100.107.14\GUIARECEPCION\"
                        Dim imgTerminos As Image = Image.GetInstance(imagepath + "Terminos2.png")
                        imgTerminos.Alignment = iTextSharp.text.Image.UNDERLYING
                        'imgTerminos.ScaleAbsolute(580, 420)
                        imgTerminos.ScaleAbsolute(540, 410)
                        documento.Add(imgTerminos)
                        'SE CIERRA EL DOCUMENTO
                        documento.Close()

                        If orden <> "" Then
                            GenerarPdfQpr(dTDatos.Tables(0).Rows(0).Item("RUTAQR"), orden, dTDatos.Tables(0).Rows(0).Item("NOMBREPDF"))
                        End If
                    Next
                End If
            End If
            'retorno = nombreFile
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        'Return retorno
    End Sub


    Private Sub GenerarPdfQpr(ByVal ruta As String, ByVal orden As String, ByVal cliente As String)
        'Try
        '    Dim fontordenes As iTextSharp.text.Font = FontFactory.GetFont("Arial", 38, iTextSharp.text.Font.BOLD, New BaseColor(255, 255, 255))
        '    Dim nombreFile As String = "OS_" & orden & ".pdf"
        '    Dim file As String = String.Format("{0}{1}", ruta, nombreFile)

        '    '//Page site and margin left, right, top, bottom is defined
        '    Dim documento As New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)
        '    Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
        '    Dim ev As New CreacioPdfTurno()
        '    documento.Open()
        '    writer.PageEvent = ev
        '    documento.NewPage()
        '    Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("https://www.hunteronline.com.ec/IMGCOTIZADORWEB/Imagenescampanias/FondoTurnoLogo.png")
        '    logo.Alignment = iTextSharp.text.Image.UNDERLYING
        '    logo.ScaleAbsolute(600, 846)
        '    documento.Add(logo)

        '    Dim tabladatosorden As New PdfPTable(1)
        '    tabladatosorden.TotalWidth = 550.0F
        '    tabladatosorden.LockedWidth = True
        '    tabladatosorden.HorizontalAlignment = Element.ALIGN_RIGHT

        '    Dim datosnombre As New PdfPCell(New Phrase(cliente, fontordenes))
        '    datosnombre.Border = 0
        '    datosnombre.PaddingTop = 120
        '    datosnombre.PaddingLeft = 20
        '    datosnombre.HorizontalAlignment = Element.ALIGN_LEFT
        '    tabladatosorden.AddCell(datosnombre)

        '    Dim datosnombreorden As New PdfPCell(New Phrase("Orden de Servicio", fontordenes))
        '    datosnombreorden.Border = 0
        '    datosnombreorden.PaddingTop = 180
        '    datosnombreorden.PaddingLeft = 4
        '    datosnombreorden.HorizontalAlignment = Element.ALIGN_CENTER
        '    tabladatosorden.AddCell(datosnombreorden)

        '    Dim datosorden As New PdfPCell(New Phrase("# " + orden, fontordenes))
        '    datosorden.Border = 0
        '    datosorden.PaddingTop = 2
        '    datosorden.PaddingLeft = 4
        '    datosorden.HorizontalAlignment = Element.ALIGN_CENTER
        '    tabladatosorden.AddCell(datosorden)

        '    Dim imgQpr As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("https://www.hunteronline.com.ec/Qr/" & orden & ".jpg")
        '    imgQpr.ScalePercent(140.0F)
        '    Dim datosclientetrabajoimagen As New PdfPCell(imgQpr)
        '    datosclientetrabajoimagen.Border = 0
        '    datosclientetrabajoimagen.PaddingTop = 42
        '    datosclientetrabajoimagen.PaddingLeft = -20
        '    datosclientetrabajoimagen.HorizontalAlignment = Element.ALIGN_CENTER
        '    tabladatosorden.AddCell(datosclientetrabajoimagen)
        '    documento.Add(tabladatosorden)

        '    documento.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try

    End Sub


    Private Function ConsultaRuta() As String
        Dim retorno As String = ""
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = DocumentosAdapter.ConsultaRutaPdfDA
            retorno = dTCstGeneral.Tables(0).Rows(0)("RUTA_FILE")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function


    Private Shared barcodeFormats As New Dictionary(Of String, BarcodeFormat)() From { _
   {"QR Code", BarcodeFormat.QRCode}, _
   {"Data Matrix", BarcodeFormat.DataMatrix}, _
   {"PDF417", BarcodeFormat.PDF417}, _
   {"Aztec", BarcodeFormat.Aztec}, _
   {"Bookland/ISBN", BarcodeFormat.Bookland}, _
   {"Codabar", BarcodeFormat.Codabar}, _
   {"Code 11", BarcodeFormat.Code11}, _
   {"Code 128", BarcodeFormat.Code128}, _
   {"Code 128-A", BarcodeFormat.Code128A}, _
   {"Code 128-B", BarcodeFormat.Code128B}, _
   {"Code 128-C", BarcodeFormat.Code128C}, _
   {"Code 39", BarcodeFormat.Code39}, _
   {"Code 39 Extended", BarcodeFormat.Code39Extended}, _
   {"Code 93", BarcodeFormat.Code93}, _
   {"EAN-13", BarcodeFormat.EAN13}, _
   {"EAN-8", BarcodeFormat.EAN8}, _
   {"FIM", BarcodeFormat.FIM}, _
   {"Interleaved 2 of 5", BarcodeFormat.Interleaved2of5}, _
   {"ITF-14", BarcodeFormat.ITF14}, _
   {"LOGMARS", BarcodeFormat.LOGMARS}, _
   {"MSI 2 Mod 10", BarcodeFormat.MSI2Mod10}, _
   {"MSI Mod 10", BarcodeFormat.MSIMod10}, _
   {"MSI Mod 11", BarcodeFormat.MSIMod11}, _
   {"MSI Mod 11 Mod 10", BarcodeFormat.MSIMod11Mod10}, _
   {"PostNet", BarcodeFormat.PostNet}, _
   {"Plessey", BarcodeFormat.ModifiedPlessey}, _
   {"Standard 2 of 5", BarcodeFormat.Standard2of5}, _
   {"Telepen", BarcodeFormat.Telepen}, _
   {"UPC 2 Digit Ext.", BarcodeFormat.UPCSupplemental2Digit}, _
   {"UPC 5 Digit Ext.", BarcodeFormat.UPCSupplemental5Digit}, _
   {"UPC-A", BarcodeFormat.UPCA}, _
   {"UPC-E", BarcodeFormat.UPCE} _
  }

    Private barcodeEncoder As New BarcodeEncoder()

    Private Function GenerateRandomFileName(ByVal folderPath As String) As String
        Dim chars As String = "2346789ABCDEFGHJKLMNPQRTUVWXYZabcdefghjkmnpqrtuvwxyz"
        Dim rnd As New Random()
        Dim name As String
        Do
            name = String.Empty
            While name.Length < 5
                name += chars.Substring(rnd.[Next](chars.Length), 1)
            End While
            name += ".jpg"
        Loop While file.Exists(folderPath & name)
        Return name
    End Function

End Class
