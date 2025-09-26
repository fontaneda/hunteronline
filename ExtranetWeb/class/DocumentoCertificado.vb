Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class DocumentoCertificado

    ''' <summary>
    ''' FECHA: 04/04/2018
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: CODIGO PARA CREAR Y GUARDAR ARCHIVO PDF
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="contrato"></param>
    ''' <param name="ruta"></param>
    ''' <remarks></remarks>
    Public Sub GenerarDocumento(ByVal usuario As String, ByVal contrato As String, ByVal ruta As String)
        Try
            Dim dtCabecera As New System.Data.DataSet
            dtCabecera = DocumentosAdapter.ConsultaDocumentosMaresa(usuario, contrato, 2)
            If dtCabecera.Tables(0).Rows.Count > 0 Then
                'DATOS DESDE BASE
                Dim codigoVehiculo As String = dtCabecera.Tables(0).Rows(0)("CODIGO_VEHICULO").ToString()
                Dim cliente As String = dtCabecera.Tables(0).Rows(0)("CLIENTE_NUEVO").ToString()
                Dim producto As String = dtCabecera.Tables(0).Rows(0)("PRODUCTO").ToString()
                Dim cobertura As String = dtCabecera.Tables(0).Rows(0)("COBERTURA").ToString()
                Dim total As String = dtCabecera.Tables(0).Rows(0)("PAGAR_CLIENTE").ToString()
                Dim marca As String = dtCabecera.Tables(0).Rows(0)("MARCA").ToString()
                Dim modelo As String = dtCabecera.Tables(0).Rows(0)("MODELO").ToString()
                Dim tipo As String = dtCabecera.Tables(0).Rows(0)("TIPO").ToString()
                Dim color As String = dtCabecera.Tables(0).Rows(0)("COLOR").ToString()
                Dim anio As String = dtCabecera.Tables(0).Rows(0)("ANIO").ToString()
                Dim placa As String = dtCabecera.Tables(0).Rows(0)("PLACA").ToString()
                Dim chasis As String = dtCabecera.Tables(0).Rows(0)("CHASIS").ToString()
                Dim motor As String = dtCabecera.Tables(0).Rows(0)("MOTOR").ToString()
                Dim lugar_fecha As String = dtCabecera.Tables(0).Rows(0)("LUGAR_FECHA").ToString()

                'FUENTES
                Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, Font.NORMAL, New BaseColor(0, 0, 0))
                Dim fontcabeceraBold As iTextSharp.text.Font = FontFactory.GetFont("Arial", 7, Font.BOLD, New BaseColor(0, 0, 0))
                Dim fontcabeceraBoldunderline As iTextSharp.text.Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, New BaseColor(0, 0, 0))
                Dim fonttextopequeño As iTextSharp.text.Font = FontFactory.GetFont("Arial", 6, Font.NORMAL, New BaseColor(0, 0, 0))

                'COLORES
                Dim gris As New BaseColor(192, 192, 192)
                Dim blanco As New BaseColor(255, 255, 255)

                'CREACION DE DOCUMENTO
                Dim documento As New Document(PageSize.A4, 0.0F, 0.0F, 100.0F, 30.0F)
                Dim file As String = String.Format("{0}Certificado_{1}.PDF", ruta, contrato)
                Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
                Dim paragraph As New iTextSharp.text.Paragraph(" ")
                Dim ev As New CreacionPdfCertificados()

                'APERTURA DEL DOCUMENTO
                documento.Open()
                documento.NewPage()
                writer.PageEvent = ev
                documento.Add(paragraph)

                'DATOS DEL CERTIFICADO LINEA 1 CONTRATO Y CV
                Dim tablaCabecera0 As New PdfPTable(3)
                tablaCabecera0.SetWidths(New Single() {20.0F, 65.0F, 15.0F})
                Dim DatosCab0 As New PdfPCell(New Phrase("CONT. No.", fontcabecera))
                DatosCab0.Border = 0
                DatosCab0.HorizontalAlignment = Element.ALIGN_LEFT
                tablaCabecera0.AddCell(DatosCab0)
                Dim DatosCab1 As New PdfPCell(New Phrase(contrato, fontcabeceraBold))
                DatosCab1.Border = 0
                DatosCab1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaCabecera0.AddCell(DatosCab1)
                Dim DatosCab2 As New PdfPCell(New Phrase("C.V. " & codigoVehiculo, fontcabeceraBold))
                DatosCab2.FixedHeight = 20.0F
                DatosCab2.BackgroundColor = gris
                DatosCab2.Border = PdfPCell.NO_BORDER
                DatosCab2.CellEvent = New RoundedBorders()
                DatosCab2.HorizontalAlignment = Element.ALIGN_CENTER
                DatosCab2.VerticalAlignment = Element.ALIGN_MIDDLE
                tablaCabecera0.AddCell(DatosCab2)
                documento.Add(tablaCabecera0)

                'DATOS DEL NOMBRE DEL CLIENTE
                Dim tablaCabecera1 As New PdfPTable(1)
                tablaCabecera1.SetWidths(New Single() {100.0F})
                Dim DatosNom0 As New PdfPCell(New Phrase("Certifica que el Sr. (a). " & cliente.ToUpper, fontcabecera))
                DatosNom0.Border = 0
                DatosNom0.HorizontalAlignment = Element.ALIGN_LEFT
                DatosNom0.PaddingTop = 5.0F
                tablaCabecera1.AddCell(DatosNom0)
                documento.Add(tablaCabecera1)

                'TEXTO ANTES DEL SERVICIO
                Dim tablaCabecera2 As New PdfPTable(1)
                tablaCabecera2.SetWidths(New Single() {100.0F})
                Dim DatosMen0 As New PdfPCell(New Phrase("Ha adquirido los siguientes sistemas: ", fontcabecera))
                DatosMen0.Border = 0
                DatosMen0.HorizontalAlignment = Element.ALIGN_LEFT
                DatosMen0.PaddingTop = 10.0F
                tablaCabecera2.AddCell(DatosMen0)
                documento.Add(tablaCabecera2)

                'DATOS DEL SERVICIO
                documento.Add(Chunk.NEWLINE)
                Dim tablaServicio As New PdfPTable(4)
                tablaServicio.SetWidths(New Single() {64.0F, 18.0F, 6.0F, 12.0F})
                tablaServicio.DefaultCell.Border = PdfPCell.NO_BORDER
                tablaServicio.DefaultCell.CellEvent = New RoundedBorders

                'fontcabeceraBoldunderline.SetStyle(Font.UNDERLINE)
                Dim DatosServ0 As New PdfPCell(New Phrase("PRODUCTO", fontcabeceraBoldunderline))
                DatosServ0.Border = 0
                DatosServ0.HorizontalAlignment = Element.ALIGN_CENTER
                tablaServicio.AddCell(DatosServ0)
                Dim DatosServ1 As New PdfPCell(New Phrase("COBERTURA", fontcabeceraBoldunderline))
                DatosServ1.Border = 0
                DatosServ1.HorizontalAlignment = Element.ALIGN_CENTER
                tablaServicio.AddCell(DatosServ1)

                '----------------------------------------------
                Dim DatosServ1_5 As New PdfPCell(New Phrase(" ", fontcabecera))
                DatosServ1_5.Border = 0
                DatosServ1_5.HorizontalAlignment = Element.ALIGN_CENTER
                tablaServicio.AddCell(DatosServ1_5)
                '----------------------------------------------


                Dim DatosServ2 As New PdfPCell(New Phrase("P.V.P + IVA", fontcabeceraBoldunderline))
                DatosServ2.Border = 0
                DatosServ2.HorizontalAlignment = Element.ALIGN_CENTER
                tablaServicio.AddCell(DatosServ2)

                Dim DatosServ3 As New PdfPCell(New Phrase(producto, fontcabecera))
                DatosServ3.PaddingLeft = 10.0F
                DatosServ3.PaddingTop = 5.0F
                DatosServ3.Border = 0
                DatosServ3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaServicio.AddCell(DatosServ3)
                Dim DatosServ4 As New PdfPCell(New Phrase(cobertura, fontcabecera))
                DatosServ4.PaddingTop = 5.0F
                DatosServ4.Border = 0
                DatosServ4.HorizontalAlignment = Element.ALIGN_CENTER
                tablaServicio.AddCell(DatosServ4)


                '----------------------------------------------
                Dim DatosServ4_5 As New PdfPCell(New Phrase("$", fontcabecera))
                DatosServ4_5.PaddingTop = 5.0F
                DatosServ4_5.Border = 0
                DatosServ4_5.HorizontalAlignment = Element.ALIGN_RIGHT
                tablaServicio.AddCell(DatosServ4_5)
                '----------------------------------------------


                Dim DatosServ5 As New PdfPCell(New Phrase(total, fontcabecera))
                DatosServ5.PaddingTop = 5.0F
                DatosServ5.Border = 0
                DatosServ5.HorizontalAlignment = Element.ALIGN_CENTER
                tablaServicio.AddCell(DatosServ5)
                documento.Add(tablaServicio)

                'TEXTO ANTES DE DATOS DEL VEHICULO
                documento.Add(Chunk.NEWLINE)
                Dim tablaMsg As New PdfPTable(1)
                tablaMsg.SetWidths(New Single() {100.0F})
                Dim DatosMsj0 As New PdfPCell(New Phrase("Estos sistemas se encuentran instalados en el (Vehículo/Barco/Avión/Cajero) con las siguientes características: ", fontcabecera))
                DatosMsj0.Border = 0
                DatosMsj0.HorizontalAlignment = Element.ALIGN_LEFT
                DatosMsj0.PaddingTop = 10.0F
                tablaMsg.AddCell(DatosMsj0)
                documento.Add(tablaMsg)

                'DATOS DEL VEHICULO
                Dim DatosVeh As New PdfPTable(6)
                DatosVeh.SetWidths(New Single() {13.0F, 1.0F, 47.0F, 13.0F, 1.0F, 25.0F})
                Dim DatosVeh0 As New PdfPCell(New Phrase("MARCA", fontcabeceraBold))
                DatosVeh0.PaddingLeft = 20.0F
                DatosVeh0.PaddingTop = 20.0F
                DatosVeh0.Border = 0
                DatosVeh0.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh0)
                Dim DatosVehc0 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc0.PaddingTop = 20.0F
                DatosVehc0.Border = 0
                DatosVehc0.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc0)
                Dim DatosVeh1 As New PdfPCell(New Phrase(marca, fontcabecera))
                DatosVeh1.PaddingTop = 20.0F
                DatosVeh1.Border = 0
                DatosVeh1.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh1)
                Dim DatosVeh2 As New PdfPCell(New Phrase("AÑO", fontcabeceraBold))
                DatosVeh2.PaddingTop = 20.0F
                DatosVeh2.Border = 0
                DatosVeh2.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh2)
                Dim DatosVehc1 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc1.PaddingTop = 20.0F
                DatosVehc1.Border = 0
                DatosVehc1.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc1)
                Dim DatosVeh3 As New PdfPCell(New Phrase(anio, fontcabecera))
                DatosVeh3.PaddingTop = 20.0F
                DatosVeh3.Border = 0
                DatosVeh3.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh3)
                '
                Dim DatosVeh4 As New PdfPCell(New Phrase("MODELO", fontcabeceraBold))
                DatosVeh4.PaddingLeft = 20.0F
                DatosVeh4.PaddingTop = 10.0F
                DatosVeh4.Border = 0
                DatosVeh4.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh4)
                Dim DatosVehc2 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc2.PaddingTop = 10.0F
                DatosVehc2.Border = 0
                DatosVehc2.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc2)
                Dim DatosVeh5 As New PdfPCell(New Phrase(modelo, fontcabecera))
                DatosVeh5.PaddingTop = 10.0F
                DatosVeh5.Border = 0
                DatosVeh5.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh5)
                Dim DatosVeh6 As New PdfPCell(New Phrase("PLACA", fontcabeceraBold))
                DatosVeh6.PaddingTop = 10.0F
                DatosVeh6.Border = 0
                DatosVeh6.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh6)
                Dim DatosVehc3 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc3.PaddingTop = 10.0F
                DatosVehc3.Border = 0
                DatosVehc3.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc3)
                Dim DatosVeh7 As New PdfPCell(New Phrase(placa, fontcabecera))
                DatosVeh7.PaddingTop = 10.0F
                DatosVeh7.Border = 0
                DatosVeh7.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh7)
                '
                Dim DatosVeh8 As New PdfPCell(New Phrase("TIPO", fontcabeceraBold))
                DatosVeh8.PaddingLeft = 20.0F
                DatosVeh8.PaddingTop = 10.0F
                DatosVeh8.Border = 0
                DatosVeh8.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh8)
                Dim DatosVehc4 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc4.PaddingTop = 10.0F
                DatosVehc4.Border = 0
                DatosVehc4.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc4)
                Dim DatosVeh9 As New PdfPCell(New Phrase(tipo, fontcabecera))
                DatosVeh9.PaddingTop = 10.0F
                DatosVeh9.Border = 0
                DatosVeh9.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh9)
                Dim DatosVeh10 As New PdfPCell(New Phrase("CHASIS", fontcabeceraBold))
                DatosVeh10.PaddingTop = 10.0F
                DatosVeh10.Border = 0
                DatosVeh10.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh10)
                Dim DatosVehc5 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc5.PaddingTop = 10.0F
                DatosVehc5.Border = 0
                DatosVehc5.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc5)
                Dim DatosVeh11 As New PdfPCell(New Phrase(chasis, fontcabecera))
                DatosVeh11.PaddingTop = 10.0F
                DatosVeh11.Border = 0
                DatosVeh11.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh11)
                '
                Dim DatosVeh12 As New PdfPCell(New Phrase("COLOR", fontcabeceraBold))
                DatosVeh12.PaddingLeft = 20.0F
                DatosVeh12.PaddingTop = 10.0F
                DatosVeh12.Border = 0
                DatosVeh12.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh12)
                Dim DatosVehc6 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc6.PaddingTop = 10.0F
                DatosVehc6.Border = 0
                DatosVehc6.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc6)
                Dim DatosVeh13 As New PdfPCell(New Phrase(color, fontcabecera))
                DatosVeh13.PaddingTop = 10.0F
                DatosVeh13.Border = 0
                DatosVeh13.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh13)
                Dim DatosVeh14 As New PdfPCell(New Phrase("MOTOR", fontcabeceraBold))
                DatosVeh14.PaddingTop = 10.0F
                DatosVeh14.Border = 0
                DatosVeh14.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh14)
                Dim DatosVehc7 As New PdfPCell(New Phrase(":", fontcabecera))
                DatosVehc7.PaddingTop = 10.0F
                DatosVehc7.Border = 0
                DatosVehc7.HorizontalAlignment = Element.ALIGN_CENTER
                DatosVeh.AddCell(DatosVehc7)
                Dim DatosVeh15 As New PdfPCell(New Phrase(motor, fontcabecera))
                DatosVeh15.PaddingTop = 10.0F
                DatosVeh15.Border = 0
                DatosVeh15.HorizontalAlignment = Element.ALIGN_LEFT
                DatosVeh.AddCell(DatosVeh15)
                documento.Add(DatosVeh)

                'TEXTO ANTES DE DATOS DEL VEHICULO
                Dim tablaMsg2 As New PdfPTable(1)
                tablaMsg2.SetWidths(New Single() {100.0F})
                Dim DatosMsj1 As New PdfPCell(New Phrase(lugar_fecha, fonttextopequeño))
                DatosMsj1.Border = 0
                DatosMsj1.HorizontalAlignment = Element.ALIGN_LEFT
                DatosMsj1.PaddingTop = 10.0F
                tablaMsg2.AddCell(DatosMsj1)
                documento.Add(tablaMsg2)

                'IMAGEN PARA TABLA DE BORDE REDONDO
                Dim cuadro_redondeado As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("https://www.hunteronline.com.ec/extranetdesarrollo/images/logo/CuadroRedondeado.png")
                cuadro_redondeado.ScaleAbsolute(475.0F, 60.0F)
                cuadro_redondeado.Alignment = iTextSharp.text.Image.UNDERLYING
                cuadro_redondeado.SetAbsolutePosition(62, 585)
                documento.Add(cuadro_redondeado)

                'SE CIERRA EL DOCUMENTO
                documento.Close()
                'writer.Flush()
                'writer.Close()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class
