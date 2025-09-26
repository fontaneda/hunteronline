Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class CreacionPdfControlCalidad
    Inherits PdfPageEventHelper

    Public Sub GenerarDocumento(ByVal codigo As String, ByVal nombre As String, ByVal ruta As String)
        Try
            Dim dtParametros As New System.Data.DataSet
            Dim obj As New ControlTaller
            dtParametros = obj.ConsultaDocumento(4, codigo)
            If dtParametros.Tables.Count = 3 Then
                Dim empresa_nom As String = dtParametros.Tables(0).Rows(0)("EMPRESA").ToString()
                Dim titulo_docu As String = dtParametros.Tables(0).Rows(0)("TITULO").ToString()
                Dim cliente_nom As String = dtParametros.Tables(0).Rows(0)("CLIENTE").ToString()
                Dim fecha_lugar As String = dtParametros.Tables(0).Rows(0)("FECHA").ToString()
                Dim cliente_tel As String = dtParametros.Tables(0).Rows(0)("TELEFONO").ToString()
                Dim placa_autom As String = dtParametros.Tables(0).Rows(0)("PLACA").ToString()
                Dim vehiculo_id As String = dtParametros.Tables(0).Rows(0)("VEHICULO").ToString()
                Dim chasi_autom As String = dtParametros.Tables(0).Rows(0)("CHASIS").ToString()
                Dim motor_autom As String = dtParametros.Tables(0).Rows(0)("MOTOR").ToString()
                Dim color_autom As String = dtParametros.Tables(0).Rows(0)("COLOR").ToString()
                Dim mar_mod_tip As String = dtParametros.Tables(0).Rows(0)("MAR_MOD_TIP").ToString
                Dim trabajo_act As String = dtParametros.Tables(0).Rows(0)("TRABAJO").ToString
                Dim odometro_vh As String = dtParametros.Tables(0).Rows(0)("ODOMETRO").ToString
                Dim gasolina_vh As String = dtParametros.Tables(0).Rows(0)("COMBUSTIBLE").ToString
                Dim llave_autom As String = dtParametros.Tables(0).Rows(0)("LLAVE").ToString
                Dim control_veh As String = dtParametros.Tables(0).Rows(0)("CONTROL").ToString
                Dim recepcion_t As String = dtParametros.Tables(0).Rows(0)("RECEPCION").ToString
                Dim novedad_veh As String = dtParametros.Tables(0).Rows(0)("NOVEDADES").ToString
                Dim firma_tecni As String = dtParametros.Tables(0).Rows(0)("FIRMA_TECNICO").ToString
                Dim tecnico_rec As String = dtParametros.Tables(0).Rows(0)("TECNICO_RECIBE").ToString
                Dim usuario_ret As String = dtParametros.Tables(0).Rows(0)("USUARIO_RETIRA").ToString

                'cliente_nom = cliente_nom.Remove(3, 4)
                'cliente_nom = cliente_nom.Insert(3, "xxxx")
                'cliente_tel = cliente_tel.Remove(3, 4)
                'cliente_tel = cliente_tel.Insert(3, "xxxx")
                'placa_autom = placa_autom.Remove(5, 3)
                'placa_autom = placa_autom.Insert(5, "xxx")
                'chasi_autom = chasi_autom.Remove(5, 5)
                'chasi_autom = chasi_autom.Insert(5, "xxxxx")
                'motor_autom = motor_autom.Remove(5, 5)
                'motor_autom = motor_autom.Insert(5, "xxxxx")
                'usuario_ret = usuario_ret.Remove(3, 4)
                'usuario_ret = usuario_ret.Insert(3, "xxxx")

                Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 8, Font.BOLD, New BaseColor(128, 128, 128))
                Dim fonttitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 12, Font.BOLD, New BaseColor(0, 0, 0))
                Dim fontcabeceradetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 8, Font.BOLD, New BaseColor(128, 128, 128))
                Dim fontdetalletabla As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 7, Font.NORMAL, New BaseColor(0, 0, 0))
                Dim fontdetalletabla_rojo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 7, Font.NORMAL, New BaseColor(233, 38, 18))
                Dim fontdetalletabla_verde As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 7, Font.NORMAL, New BaseColor(45, 194, 25))
                Dim fontdetalletablafuerte As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 7, Font.BOLD, New BaseColor(0, 0, 0))
                Dim fontdetalletabla_gris As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 7, Font.BOLD, New BaseColor(128, 128, 128))

                Dim documento As New Document(PageSize.A4, -40.0F, -40.0F, 100.0F, 30.0F)
                Dim file As String = String.Format("{0}{1}", ruta, nombre)
                Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
                Dim paragraph As New iTextSharp.text.Paragraph(" ")
                Dim ev As New CreacionPdf()
                documento.Open()
                documento.NewPage()
                writer.PageEvent = ev
                documento.Add(paragraph)

                Dim tablacabecera As New PdfPTable(1)
                tablacabecera.SetWidths(New Single() {100.0F})
                Dim tablacabeceratitulo1 As New PdfPCell(New Phrase(empresa_nom, fontcabecera))
                tablacabeceratitulo1.Border = 0
                tablacabeceratitulo1.HorizontalAlignment = Element.ALIGN_LEFT
                tablacabecera.AddCell(tablacabeceratitulo1)
                Dim tablacabeceratitulo2 As New PdfPCell(New Phrase(titulo_docu, fonttitulo))
                tablacabeceratitulo2.Border = 0
                tablacabeceratitulo2.HorizontalAlignment = Element.ALIGN_LEFT
                tablacabecera.AddCell(tablacabeceratitulo2)
                documento.Add(tablacabecera)

                documento.Add(paragraph)
                Dim tabladatos_c As New PdfPTable(4)
                tabladatos_c.SetWidths(New Single() {45.0F, 1.0F, 27.0F, 27.0F})
                Dim tabladatosfil1col1 As New PdfPCell(New Phrase("DATOS GENERALES ", fontcabeceradetalle))
                tabladatosfil1col1.Border = 0
                tabladatosfil1col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil1col1.BorderWidthLeft = 0.5F
                tabladatosfil1col1.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil1col1.BorderWidthRight = 0.5F
                tabladatosfil1col1.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil1col1.BorderWidthTop = 0.5F
                tabladatosfil1col1.PaddingTop = 3.0F
                tabladatosfil1col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_c.AddCell(tabladatosfil1col1)
                Dim tabladatosfil1col2 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil1col2.Border = 0
                tabladatosfil1col2.PaddingTop = 3.0F
                tabladatosfil1col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_c.AddCell(tabladatosfil1col2)
                Dim tabladatosfil1col3 As New PdfPCell(New Phrase("DATOS DEL VEHICULO ", fontcabeceradetalle))
                tabladatosfil1col3.Border = 0
                tabladatosfil1col3.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil1col3.BorderWidthLeft = 0.5F
                tabladatosfil1col3.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil1col3.BorderWidthTop = 0.5F
                tabladatosfil1col3.PaddingTop = 3.0F
                tabladatosfil1col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_c.AddCell(tabladatosfil1col3)
                Dim tabladatosfil1col4 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil1col4.Border = 0
                tabladatosfil1col4.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil1col4.BorderWidthRight = 0.5F
                tabladatosfil1col4.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil1col4.BorderWidthTop = 0.5F
                tabladatosfil1col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_c.AddCell(tabladatosfil1col4)
                documento.Add(tabladatos_c)

                Dim tabladatos As New PdfPTable(7)
                tabladatos.SetWidths(New Single() {12.0F, 33.0F, 1.0F, 10.0F, 17.0F, 10.0F, 17.0F})
                Dim tabladatosfil2col1 As New PdfPCell(New Phrase("Lugar y fecha", fontcabeceradetalle))
                tabladatosfil2col1.Border = 0
                tabladatosfil2col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil2col1.BorderWidthLeft = 0.5F
                tabladatosfil2col1.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil2col1.BorderWidthTop = 0.5F
                tabladatosfil2col1.PaddingTop = 3.0F
                tabladatosfil2col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col1)
                Dim tabladatosfil2col2 As New PdfPCell(New Phrase(fecha_lugar, fontdetalletabla))
                tabladatosfil2col2.Border = 0
                tabladatosfil2col2.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil2col2.BorderWidthRight = 0.5F
                tabladatosfil2col2.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil2col2.BorderWidthTop = 0.5F
                tabladatosfil2col2.PaddingTop = 4.0F
                tabladatosfil2col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col2)
                Dim tabladatosfil2col3 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil2col3.Border = 0
                tabladatosfil2col3.PaddingTop = 3.0F
                tabladatosfil2col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col3)
                Dim tabladatosfil2col4 As New PdfPCell(New Phrase("Placa", fontcabeceradetalle))
                tabladatosfil2col4.Border = 0
                tabladatosfil2col4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil2col4.BorderWidthLeft = 0.5F
                tabladatosfil2col4.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil2col4.BorderWidthTop = 0.5F
                tabladatosfil2col4.PaddingTop = 3.0F
                tabladatosfil2col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col4)
                Dim tabladatosfil2col5 As New PdfPCell(New Phrase(placa_autom, fontdetalletabla))
                tabladatosfil2col5.Border = 0
                tabladatosfil2col5.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil2col5.BorderWidthTop = 0.5F
                tabladatosfil2col5.PaddingTop = 4.0F
                tabladatosfil2col5.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col5)
                Dim tabladatosfil2col6 As New PdfPCell(New Phrase("Color", fontcabeceradetalle))
                tabladatosfil2col6.Border = 0
                tabladatosfil2col6.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil2col6.BorderWidthTop = 0.5F
                tabladatosfil2col6.PaddingTop = 3.0F
                tabladatosfil2col6.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col6)
                Dim tabladatosfil2col7 As New PdfPCell(New Phrase(color_autom, fontdetalletabla))
                tabladatosfil2col7.Border = 0
                tabladatosfil2col7.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil2col7.BorderWidthRight = 0.5F
                tabladatosfil2col7.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladatosfil2col7.BorderWidthTop = 0.5F
                tabladatosfil2col7.PaddingTop = 4.0F
                tabladatosfil2col7.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil2col7)
                Dim tabladatosfil3col1 As New PdfPCell(New Phrase("Cliente", fontcabeceradetalle))
                tabladatosfil3col1.Border = 0
                tabladatosfil3col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil3col1.BorderWidthLeft = 0.5F
                tabladatosfil3col1.PaddingTop = 3.0F
                tabladatosfil3col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col1)
                Dim tabladatosfil3col2 As New PdfPCell(New Phrase(cliente_nom, fontdetalletablafuerte))
                tabladatosfil3col2.Border = 0
                tabladatosfil3col2.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil3col2.BorderWidthRight = 0.5F
                tabladatosfil3col2.PaddingTop = 4.0F
                tabladatosfil3col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col2)
                Dim tabladatosfil3col3 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil3col3.Border = 0
                tabladatosfil3col3.PaddingTop = 3.0F
                tabladatosfil3col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col3)
                Dim tabladatosfil3col4 As New PdfPCell(New Phrase("Chasis", fontcabeceradetalle))
                tabladatosfil3col4.Border = 0
                tabladatosfil3col4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil3col4.BorderWidthLeft = 0.5F
                tabladatosfil3col4.PaddingTop = 3.0F
                tabladatosfil3col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col4)
                Dim tabladatosfil3col5 As New PdfPCell(New Phrase(chasi_autom, fontdetalletabla))
                tabladatosfil3col5.Border = 0
                tabladatosfil3col5.PaddingTop = 4.0F
                tabladatosfil3col5.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col5)
                Dim tabladatosfil3col6 As New PdfPCell(New Phrase("Motor", fontcabeceradetalle))
                tabladatosfil3col6.Border = 0
                tabladatosfil3col6.PaddingTop = 3.0F
                tabladatosfil3col6.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col6)
                Dim tabladatosfil3col7 As New PdfPCell(New Phrase(motor_autom, fontdetalletabla))
                tabladatosfil3col7.Border = 0
                tabladatosfil3col7.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil3col7.BorderWidthRight = 0.5F
                tabladatosfil3col7.PaddingTop = 4.0F
                tabladatosfil3col7.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil3col7)
                Dim tabladatosfil4col1 As New PdfPCell(New Phrase("Telefono", fontcabeceradetalle))
                tabladatosfil4col1.Border = 0
                tabladatosfil4col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil4col1.BorderWidthLeft = 0.5F
                tabladatosfil4col1.PaddingTop = 3.0F
                tabladatosfil4col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col1)
                Dim tabladatosfil4col2 As New PdfPCell(New Phrase(cliente_tel, fontdetalletabla))
                tabladatosfil4col2.Border = 0
                tabladatosfil4col2.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil4col2.BorderWidthRight = 0.5F
                tabladatosfil4col2.PaddingTop = 4.0F
                tabladatosfil4col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col2)
                Dim tabladatosfil4col3 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil4col3.Border = 0
                tabladatosfil4col3.PaddingTop = 3.0F
                tabladatosfil4col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col3)
                Dim tabladatosfil4col4 As New PdfPCell(New Phrase("Llaves", fontcabeceradetalle))
                tabladatosfil4col4.Border = 0
                tabladatosfil4col4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil4col4.BorderWidthLeft = 0.5F
                tabladatosfil4col4.PaddingTop = 3.0F
                tabladatosfil4col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col4)
                Dim tabladatosfil4col5 As New PdfPCell(New Phrase(llave_autom, fontdetalletabla))
                tabladatosfil4col5.Border = 0
                tabladatosfil4col5.PaddingTop = 4.0F
                tabladatosfil4col5.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col5)
                Dim tabladatosfil4col6 As New PdfPCell(New Phrase("Controles", fontcabeceradetalle))
                tabladatosfil4col6.Border = 0
                tabladatosfil4col6.PaddingTop = 3.0F
                tabladatosfil4col6.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col6)
                Dim tabladatosfil4col7 As New PdfPCell(New Phrase(control_veh, fontdetalletabla))
                tabladatosfil4col7.Border = 0
                tabladatosfil4col7.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil4col7.BorderWidthRight = 0.5F
                tabladatosfil4col7.PaddingTop = 4.0F
                tabladatosfil4col7.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil4col7)
                Dim tabladatosfil5col1 As New PdfPCell(New Phrase("Recepcion", fontcabeceradetalle))
                tabladatosfil5col1.Border = 0
                tabladatosfil5col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil5col1.BorderWidthLeft = 0.5F
                tabladatosfil5col1.PaddingTop = 3.0F
                tabladatosfil5col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col1)
                Dim tabladatosfil5col2 As New PdfPCell(New Phrase(recepcion_t, fontdetalletabla))
                tabladatosfil5col2.Border = 0
                tabladatosfil5col2.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil5col2.BorderWidthRight = 0.5F
                tabladatosfil5col2.PaddingTop = 4.0F
                tabladatosfil5col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col2)
                Dim tabladatosfil5col3 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil5col3.Border = 0
                tabladatosfil5col3.PaddingTop = 3.0F
                tabladatosfil5col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col3)
                Dim tabladatosfil5col4 As New PdfPCell(New Phrase("Odometro", fontcabeceradetalle))
                tabladatosfil5col4.Border = 0
                tabladatosfil5col4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil5col4.BorderWidthLeft = 0.5F
                tabladatosfil5col4.PaddingTop = 3.0F
                tabladatosfil5col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col4)
                Dim tabladatosfil5col5 As New PdfPCell(New Phrase(FormatNumber(odometro_vh, 2), fontdetalletabla))
                tabladatosfil5col5.Border = 0
                tabladatosfil5col5.PaddingTop = 4.0F
                tabladatosfil5col5.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col5)
                Dim tabladatosfil5col6 As New PdfPCell(New Phrase("Combustible", fontcabeceradetalle))
                tabladatosfil5col6.Border = 0
                tabladatosfil5col6.PaddingTop = 3.0F
                tabladatosfil5col6.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col6)
                Dim tabladatosfil5col7 As New PdfPCell(New Phrase(gasolina_vh, fontdetalletabla))
                tabladatosfil5col7.Border = 0
                tabladatosfil5col7.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil5col7.BorderWidthRight = 0.5F
                tabladatosfil5col7.PaddingTop = 4.0F
                tabladatosfil5col7.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos.AddCell(tabladatosfil5col7)
                documento.Add(tabladatos)

                Dim tabladatos_p As New PdfPTable(5)
                tabladatos_p.SetWidths(New Single() {12.0F, 33.0F, 1.0F, 20.0F, 34.0F})
                Dim tabladatosfil6col1 As New PdfPCell(New Phrase("Trabajo", fontcabeceradetalle))
                tabladatosfil6col1.Border = 0
                tabladatosfil6col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil6col1.BorderWidthLeft = 0.5F
                tabladatosfil6col1.PaddingTop = 3.0F
                tabladatosfil6col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil6col1)
                Dim tabladatosfil6col2 As New PdfPCell(New Phrase(trabajo_act, fontdetalletabla_verde))
                tabladatosfil6col2.Border = 0
                tabladatosfil6col2.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil6col2.BorderWidthRight = 0.5F
                tabladatosfil6col2.PaddingTop = 4.0F
                tabladatosfil6col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil6col2)
                Dim tabladatosfil6col3 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil6col3.Border = 0
                tabladatosfil6col3.PaddingTop = 3.0F
                tabladatosfil6col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil6col3)
                Dim tabladatosfil6col4 As New PdfPCell(New Phrase("Marca/Modelo/Version", fontcabeceradetalle))
                tabladatosfil6col4.Border = 0
                tabladatosfil6col4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil6col4.BorderWidthLeft = 0.5F
                tabladatosfil6col4.PaddingTop = 3.0F
                tabladatosfil6col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil6col4)
                Dim tabladatosfil6col5 As New PdfPCell(New Phrase(mar_mod_tip, fontdetalletabla))
                tabladatosfil6col5.Border = 0
                tabladatosfil6col5.PaddingTop = 4.0F
                tabladatosfil6col5.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil6col5.BorderWidthRight = 0.5F
                tabladatosfil6col5.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil6col5)
                Dim tabladatosfil7col1 As New PdfPCell(New Phrase("Retira", fontcabeceradetalle))
                tabladatosfil7col1.Border = 0
                tabladatosfil7col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil7col1.BorderWidthLeft = 0.5F
                tabladatosfil7col1.PaddingTop = 3.0F
                tabladatosfil7col1.BorderColorBottom = BaseColor.LIGHT_GRAY
                tabladatosfil7col1.BorderWidthBottom = 0.5F
                tabladatosfil7col1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil7col1)
                Dim tabladatosfil7col2 As New PdfPCell(New Phrase(usuario_ret, fontdetalletabla))
                tabladatosfil7col2.Border = 0
                tabladatosfil7col2.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil7col2.BorderWidthRight = 0.5F
                tabladatosfil7col2.BorderColorBottom = BaseColor.LIGHT_GRAY
                tabladatosfil7col2.BorderWidthBottom = 0.5F
                tabladatosfil7col2.PaddingTop = 4.0F
                tabladatosfil7col2.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil7col2)
                Dim tabladatosfil7col3 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil7col3.Border = 0
                tabladatosfil7col3.PaddingTop = 3.0F
                tabladatosfil7col3.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil7col3)
                Dim tabladatosfil7col4 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
                tabladatosfil7col4.Border = 0
                tabladatosfil7col4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladatosfil7col4.BorderWidthLeft = 0.5F
                tabladatosfil7col4.BorderColorBottom = BaseColor.LIGHT_GRAY
                tabladatosfil7col4.BorderWidthBottom = 0.5F
                tabladatosfil7col4.PaddingTop = 3.0F
                tabladatosfil7col4.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil7col4)
                Dim tabladatosfil7col5 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tabladatosfil7col5.Border = 0
                tabladatosfil7col5.PaddingTop = 4.0F
                tabladatosfil7col5.BorderColorBottom = BaseColor.LIGHT_GRAY
                tabladatosfil7col5.BorderWidthBottom = 0.5F
                tabladatosfil7col5.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladatosfil7col5.BorderWidthRight = 0.5F
                tabladatosfil7col5.HorizontalAlignment = Element.ALIGN_LEFT
                tabladatos_p.AddCell(tabladatosfil7col5)
                documento.Add(tabladatos_p)

                documento.Add(paragraph)
                Dim tablacomentario As New PdfPTable(1)
                tablacomentario.SetWidths(New Single() {100.0F})
                Dim tablacomentariofil1col1 As New PdfPCell(New Phrase("NOVEDADES", fontcabecera))
                tablacomentariofil1col1.Border = 0
                tablacomentariofil1col1.PaddingTop = 3.0F
                tablacomentariofil1col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablacomentariofil1col1.BorderWidthLeft = 0.5F
                tablacomentariofil1col1.BorderColorTop = BaseColor.LIGHT_GRAY
                tablacomentariofil1col1.BorderWidthTop = 0.5F
                tablacomentariofil1col1.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablacomentariofil1col1.BorderWidthBottom = 0.5F
                tablacomentariofil1col1.HorizontalAlignment = Element.ALIGN_LEFT
                tablacomentariofil1col1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablacomentariofil1col1.BorderWidthRight = 0.5F
                tablacomentario.AddCell(tablacomentariofil1col1)
                Dim tablacomentariofil2col1 As New PdfPCell(New Phrase(novedad_veh, fontdetalletabla))
                tablacomentariofil2col1.Border = 0
                tablacomentariofil2col1.PaddingTop = 7.0F
                tablacomentariofil2col1.PaddingBottom = 7.0F
                tablacomentariofil2col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablacomentariofil2col1.BorderWidthLeft = 0.5F
                tablacomentariofil2col1.BorderColorTop = BaseColor.LIGHT_GRAY
                tablacomentariofil2col1.BorderWidthTop = 0.5F
                tablacomentariofil2col1.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablacomentariofil2col1.BorderWidthBottom = 0.5F
                tablacomentariofil2col1.HorizontalAlignment = Element.ALIGN_LEFT
                tablacomentariofil2col1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablacomentariofil2col1.BorderWidthRight = 0.5F
                tablacomentario.AddCell(tablacomentariofil2col1)
                documento.Add(tablacomentario)

                documento.Add(paragraph)
                Dim tablatrabajos As New PdfPTable(4)
                tablatrabajos.SetWidths(New Single() {35.0F, 15.0F, 35.0F, 15.0F})
                Dim tablatrabajosfil1col1 As New PdfPCell(New Phrase("ACCESORIOS", fontcabecera))
                tablatrabajosfil1col1.Border = 0
                tablatrabajosfil1col1.PaddingTop = 3.0F
                tablatrabajosfil1col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col1.BorderWidthLeft = 0.5F
                tablatrabajosfil1col1.BorderColorTop = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col1.BorderWidthTop = 0.5F
                tablatrabajosfil1col1.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col1.BorderWidthBottom = 0.5F
                tablatrabajosfil1col1.HorizontalAlignment = Element.ALIGN_LEFT
                tablatrabajos.AddCell(tablatrabajosfil1col1)
                Dim tablatrabajosfil1col2 As New PdfPCell(New Phrase(" ", fontcabecera))
                tablatrabajosfil1col2.Border = 0
                tablatrabajosfil1col2.PaddingTop = 3.0F
                tablatrabajosfil1col2.BorderColorTop = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col2.BorderWidthTop = 0.5F
                tablatrabajosfil1col2.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col2.BorderWidthBottom = 0.5F
                tablatrabajos.AddCell(tablatrabajosfil1col2)
                Dim tablatrabajosfil1col3 As New PdfPCell(New Phrase(" ", fontcabecera))
                tablatrabajosfil1col3.Border = 0
                tablatrabajosfil1col3.PaddingTop = 3.0F
                tablatrabajosfil1col3.BorderColorTop = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col3.BorderWidthTop = 0.5F
                tablatrabajosfil1col3.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col3.BorderWidthBottom = 0.5F
                tablatrabajos.AddCell(tablatrabajosfil1col3)
                Dim tablatrabajosfil1col4 As New PdfPCell(New Phrase(" ", fontcabecera))
                tablatrabajosfil1col4.Border = 0
                tablatrabajosfil1col4.PaddingTop = 3.0F
                tablatrabajosfil1col4.BorderColorTop = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col4.BorderWidthTop = 0.5F
                tablatrabajosfil1col4.BorderColorRight = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col4.BorderWidthRight = 0.5F
                tablatrabajosfil1col4.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablatrabajosfil1col4.BorderWidthBottom = 0.5F
                tablatrabajos.AddCell(tablatrabajosfil1col4)
                For i As Integer = 0 To dtParametros.Tables(1).Rows.Count - 1
                    Dim parametro As String = dtParametros.Tables(1).Rows(i)("DESCRIPCION").ToString()
                    Dim calificacion As String = dtParametros.Tables(1).Rows(i)("ESTADO").ToString()
                    Dim bandera As Boolean = False
                    Dim tablatrabajoscolA As New PdfPCell(New Phrase(parametro, fontdetalletabla))
                    tablatrabajoscolA.Border = 0
                    tablatrabajoscolA.PaddingTop = 3.0F
                    tablatrabajoscolA.BorderColorLeft = BaseColor.LIGHT_GRAY
                    tablatrabajoscolA.BorderWidthLeft = 0.5F
                    tablatrabajoscolA.HorizontalAlignment = Element.ALIGN_LEFT
                    Dim tablatrabajoscolB As New PdfPCell(New Phrase(calificacion, IIf(calificacion.Contains("OK"), fontdetalletabla_verde, fontdetalletabla_rojo)))
                    tablatrabajoscolB.Border = 0
                    tablatrabajoscolB.PaddingTop = 3.0F
                    tablatrabajoscolB.BorderColorRight = BaseColor.LIGHT_GRAY
                    tablatrabajoscolB.BorderWidthRight = 0.5F
                    tablatrabajoscolB.HorizontalAlignment = Element.ALIGN_LEFT
                    If (i = dtParametros.Tables(1).Rows.Count - 1) Then
                        If ((dtParametros.Tables(1).Rows.Count) Mod 2 <> 0) Then
                            bandera = True
                            tablatrabajoscolA.BorderColorBottom = BaseColor.LIGHT_GRAY
                            tablatrabajoscolA.BorderWidthBottom = 0.5F
                            tablatrabajoscolB.BorderColorBottom = BaseColor.LIGHT_GRAY
                            tablatrabajoscolB.BorderWidthBottom = 0.5F
                        Else
                            tablatrabajoscolA.BorderColorBottom = BaseColor.LIGHT_GRAY
                            tablatrabajoscolA.BorderWidthBottom = 0.5F
                            'tablatrabajoscolA.BorderColorRight = BaseColor.LIGHT_GRAY
                            'tablatrabajoscolA.BorderWidthRight = 0.5F
                            tablatrabajoscolB.BorderColorBottom = BaseColor.LIGHT_GRAY
                            tablatrabajoscolB.BorderWidthBottom = 0.5F
                            tablatrabajoscolB.BorderColorRight = BaseColor.LIGHT_GRAY
                            tablatrabajoscolB.BorderWidthRight = 0.5F
                        End If
                    ElseIf (i = dtParametros.Tables(1).Rows.Count - 2) And (dtParametros.Tables(1).Rows.Count Mod 2 = 0) Then
                        tablatrabajoscolA.BorderColorBottom = BaseColor.LIGHT_GRAY
                        tablatrabajoscolA.BorderWidthBottom = 0.5F
                        tablatrabajoscolB.BorderColorBottom = BaseColor.LIGHT_GRAY
                        tablatrabajoscolB.BorderWidthBottom = 0.5F
                    ElseIf i = 0 Then
                        tablatrabajoscolA.BorderColorLeft = BaseColor.LIGHT_GRAY
                        tablatrabajoscolA.BorderWidthLeft = 0.5F
                        tablatrabajoscolB.BorderColorRight = BaseColor.LIGHT_GRAY
                        tablatrabajoscolB.BorderWidthRight = 0.5F
                    End If
                    tablatrabajos.AddCell(tablatrabajoscolA)
                    tablatrabajos.AddCell(tablatrabajoscolB)
                    If bandera Then
                        Dim tablatrabajoscolA_aux As New PdfPCell(New Phrase(" ", fontdetalletabla))
                        tablatrabajoscolA_aux.Border = 0
                        tablatrabajoscolA_aux.BorderColorBottom = BaseColor.LIGHT_GRAY
                        tablatrabajoscolA_aux.BorderWidthBottom = 0.5F
                        tablatrabajos.AddCell(tablatrabajoscolA_aux)
                        Dim tablatrabajoscolB_aux As New PdfPCell(New Phrase(" ", fontdetalletabla))
                        tablatrabajoscolB_aux.Border = 0
                        tablatrabajoscolB_aux.BorderColorBottom = BaseColor.LIGHT_GRAY
                        tablatrabajoscolB_aux.BorderWidthBottom = 0.5F
                        tablatrabajoscolB_aux.BorderColorRight = BaseColor.LIGHT_GRAY
                        tablatrabajoscolB_aux.BorderWidthRight = 0.5F
                        tablatrabajos.AddCell(tablatrabajoscolB_aux)
                    End If
                Next
                documento.Add(tablatrabajos)

                documento.Add(paragraph)
                Dim tabladeclaracion As New PdfPTable(1)
                tabladeclaracion.SetWidths(New Single() {100.0F})
                Dim tabladeclaracioncol1fil1 As New PdfPCell(New Phrase("Quien suscribe la presente acta, en su calidad de propietario del vehículo o en representación del mismo, declara que las condiciones del vehículo ingresado hoy a los talleres de Carseg S.A., constantes en la presente acta, fueron leídas, revisadas y aceptadas por éste.  Para constancia, la presente acta se remitirá al correo electrónico del cliente, acompañando fotos del proceso de recepción, para su respaldo.", fontdetalletabla))
                tabladeclaracioncol1fil1.Border = 0
                tabladeclaracioncol1fil1.HorizontalAlignment = Element.ALIGN_LEFT
                tabladeclaracioncol1fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tabladeclaracioncol1fil1.BorderWidthLeft = 0.5F
                tabladeclaracioncol1fil1.BorderColorTop = BaseColor.LIGHT_GRAY
                tabladeclaracioncol1fil1.BorderWidthTop = 0.5F
                tabladeclaracioncol1fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tabladeclaracioncol1fil1.BorderWidthRight = 0.5F
                tabladeclaracion.AddCell(tabladeclaracioncol1fil1)
                documento.Add(tabladeclaracion)
                Dim tablafirmas As New PdfPTable(5)
                tablafirmas.SetWidths(New Single() {7.0F, 39.0F, 8.0F, 39.0F, 7.0F})
                Dim tablafirmascol1fil1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol1fil1.Border = 0
                tablafirmascol1fil1.PaddingTop = 15
                tablafirmascol1fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablafirmascol1fil1.BorderWidthLeft = 0.5F
                tablafirmas.AddCell(tablafirmascol1fil1)
                Dim tablafirmascol2fil1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol2fil1.Border = 0
                tablafirmascol2fil1.PaddingTop = 15
                tablafirmas.AddCell(tablafirmascol2fil1)
                Dim tablafirmascol3fil1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol3fil1.Border = 0
                tablafirmascol3fil1.PaddingTop = 15
                tablafirmas.AddCell(tablafirmascol3fil1)
                Dim tablafirmascol4fil1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol4fil1.Border = 0
                tablafirmascol4fil1.PaddingTop = 15
                tablafirmas.AddCell(tablafirmascol4fil1)
                Dim tablafirmascol5fil1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol5fil1.Border = 0
                tablafirmascol5fil1.PaddingTop = 15
                tablafirmascol5fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablafirmascol5fil1.BorderWidthRight = 0.5F
                tablafirmas.AddCell(tablafirmascol5fil1)
                Dim tablafirmascol1fil2 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol1fil2.Border = 0
                tablafirmascol1fil2.HorizontalAlignment = Element.ALIGN_LEFT
                tablafirmascol1fil2.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablafirmascol1fil2.BorderWidthLeft = 0.5F
                tablafirmas.AddCell(tablafirmascol1fil2)
                Dim tablafirmascol2fil2 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol2fil2.Border = 0
                tablafirmascol2fil2.BorderColorBottom = BaseColor.BLACK
                tablafirmascol2fil2.BorderWidthBottom = 0.5F
                tablafirmascol2fil2.HorizontalAlignment = Element.ALIGN_LEFT
                tablafirmas.AddCell(tablafirmascol2fil2)
                Dim tablafirmascol3fil2 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol3fil2.Border = 0
                tablafirmascol3fil2.HorizontalAlignment = Element.ALIGN_LEFT
                tablafirmas.AddCell(tablafirmascol3fil2)
                'If firma_tecni = "" Then
                Dim tablafirmascol4fil2 As New PdfPCell(New Phrase(tecnico_rec, fontdetalletabla))
                tablafirmascol4fil2.Border = 0
                tablafirmascol4fil2.BorderColorBottom = BaseColor.BLACK
                tablafirmascol4fil2.BorderWidthBottom = 0.5F
                tablafirmascol4fil2.HorizontalAlignment = Element.ALIGN_CENTER
                tablafirmas.AddCell(tablafirmascol4fil2)
                'Else
                '    Dim imagen_firma As iTextSharp.text.Image = Nothing
                '    Dim base64firmastring As String = CreateImageFromString(firma_tecni)
                '    Dim bytesfirma As Byte() = Convert.FromBase64String(base64firmastring)
                '    imagen_firma = iTextSharp.text.Image.GetInstance(bytesfirma)
                '    imagen_firma.Alignment = iTextSharp.text.Image.ALIGN_CENTER
                '    imagen_firma.Border = iTextSharp.text.Rectangle.NO_BORDER
                '    imagen_firma.BorderColorBottom = BaseColor.WHITE
                '    imagen_firma.BorderWidthBottom = 0.0F
                '    imagen_firma.BorderColorBottom = BaseColor.WHITE
                '    imagen_firma.BorderWidthBottom = 0.0F
                '    imagen_firma.BorderColorBottom = BaseColor.WHITE
                '    imagen_firma.BorderWidthBottom = 0.0F
                '    imagen_firma.BorderColorBottom = BaseColor.WHITE
                '    imagen_firma.BorderWidthBottom = 0.0F
                '    'imagen.ScaleToFit(500.0F, 455.0F)
                '    tablafirmas.AddCell(imagen_firma)
                'End If
                Dim tablafirmascol5fil2 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol5fil2.Border = 0
                tablafirmascol5fil2.BorderColorRight = BaseColor.LIGHT_GRAY
                tablafirmascol5fil2.BorderWidthRight = 0.5F
                tablafirmas.AddCell(tablafirmascol5fil2)
                Dim tablafirmascol1fil3 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol1fil3.Border = 0
                tablafirmascol1fil3.HorizontalAlignment = Element.ALIGN_LEFT
                tablafirmascol1fil3.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablafirmascol1fil3.BorderWidthLeft = 0.5F
                tablafirmas.AddCell(tablafirmascol1fil3)
                Dim tablafirmascol2fil3 As New PdfPCell(New Phrase("Cliente", fontdetalletabla))
                tablafirmascol2fil3.Border = 0
                tablafirmascol2fil3.HorizontalAlignment = Element.ALIGN_CENTER
                tablafirmas.AddCell(tablafirmascol2fil3)
                Dim tablafirmascol3fil3 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol3fil3.Border = 0
                tablafirmascol3fil3.HorizontalAlignment = Element.ALIGN_LEFT
                tablafirmas.AddCell(tablafirmascol3fil3)
                Dim tablafirmascol4fil3 As New PdfPCell(New Phrase("Asesor de Servicio CARSEG S.A.", fontdetalletabla))
                tablafirmascol4fil3.Border = 0
                tablafirmascol4fil3.HorizontalAlignment = Element.ALIGN_CENTER
                tablafirmas.AddCell(tablafirmascol4fil3)
                Dim tablafirmascol5fil3 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablafirmascol5fil3.Border = 0
                tablafirmascol5fil3.BorderColorRight = BaseColor.LIGHT_GRAY
                tablafirmascol5fil3.BorderWidthRight = 0.5F
                tablafirmas.AddCell(tablafirmascol5fil3)
                documento.Add(tablafirmas)

                Dim tablatelefonos As New PdfPTable(1)
                tablatelefonos.SetWidths(New Single() {100.0F})
                Dim tablatelefonoscol1fil0 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablatelefonoscol1fil0.Border = 0
                tablatelefonoscol1fil0.HorizontalAlignment = Element.ALIGN_CENTER
                tablatelefonoscol1fil0.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablatelefonoscol1fil0.BorderWidthLeft = 0.5F
                tablatelefonoscol1fil0.BorderColorRight = BaseColor.LIGHT_GRAY
                tablatelefonoscol1fil0.BorderWidthRight = 0.5F
                tablatelefonos.AddCell(tablatelefonoscol1fil0)
                Dim tablatelefonoscol1fil1 As New PdfPCell(New Phrase("Contactos:   Pbx/046011450   Whatsapp/0994408582   Callcenter/046004640   Emergencias/0985454544", fontdetalletabla_gris))
                tablatelefonoscol1fil1.Border = 0
                tablatelefonoscol1fil1.HorizontalAlignment = Element.ALIGN_CENTER
                tablatelefonoscol1fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablatelefonoscol1fil1.BorderWidthLeft = 0.5F
                tablatelefonoscol1fil1.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablatelefonoscol1fil1.BorderWidthBottom = 0.5F
                tablatelefonoscol1fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablatelefonoscol1fil1.BorderWidthRight = 0.5F
                tablatelefonos.AddCell(tablatelefonoscol1fil1)
                documento.Add(tablatelefonos)


                documento.Add(paragraph)
                Dim tablanota As New PdfPTable(1)
                tablanota.SetWidths(New Single() {100.0F})
                Dim tablanotacol1fil1 As New PdfPCell(New Phrase("Recuerde:", fontdetalletabla))
                tablanotacol1fil1.Border = 0
                tablanotacol1fil1.HorizontalAlignment = Element.ALIGN_LEFT
                tablanotacol1fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablanotacol1fil1.BorderWidthLeft = 0.5F
                tablanotacol1fil1.BorderColorTop = BaseColor.LIGHT_GRAY
                tablanotacol1fil1.BorderWidthTop = 0.5F
                tablanotacol1fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablanotacol1fil1.BorderWidthRight = 0.5F
                tablanota.AddCell(tablanotacol1fil1)
                Dim tablanotacol2fil1 As New PdfPCell(New Phrase("-	Para retirar el vehículo, acérquese 30 minutos antes a Servicios al Cliente, a fin de regularizar documentos y/o realizar pagos.", fontdetalletabla))
                tablanotacol2fil1.Border = 0
                tablanotacol2fil1.HorizontalAlignment = Element.ALIGN_LEFT
                tablanotacol2fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablanotacol2fil1.BorderWidthLeft = 0.5F
                tablanotacol2fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablanotacol2fil1.BorderWidthRight = 0.5F
                tablanota.AddCell(tablanotacol2fil1)
                Dim tablanotacol3fil1 As New PdfPCell(New Phrase("-	La hora de entrega del vehículo es proporcionada por nuestro Asesor de Servicios, consulte el horario de cierre del taller y evite inconvenientes.", fontdetalletabla))
                tablanotacol3fil1.Border = 0
                tablanotacol3fil1.HorizontalAlignment = Element.ALIGN_LEFT
                tablanotacol3fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablanotacol3fil1.BorderWidthLeft = 0.5F
                tablanotacol3fil1.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablanotacol3fil1.BorderWidthBottom = 0.5F
                tablanotacol3fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablanotacol3fil1.BorderWidthRight = 0.5F
                tablanota.AddCell(tablanotacol3fil1)
                documento.Add(tablanota)

                documento.NewPage()
                documento.Add(paragraph)
                Dim tablaimportante As New PdfPTable(2)
                tablaimportante.SetWidths(New Single() {3.0F, 97.0F})
                Dim tablaimportantecol0fil0 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                tablaimportantecol0fil0.Border = 0
                tablaimportantecol0fil0.HorizontalAlignment = Element.ALIGN_CENTER
                tablaimportantecol0fil0.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil0.BorderWidthLeft = 0.5F
                tablaimportantecol0fil0.BorderColorTop = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil0.BorderWidthTop = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil0)
                Dim tablaimportantecol1fil0 As New PdfPCell(New Phrase("Importante", fontdetalletabla))
                tablaimportantecol1fil0.Border = 0
                tablaimportantecol1fil0.HorizontalAlignment = Element.ALIGN_CENTER
                tablaimportantecol1fil0.BorderColorTop = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil0.BorderWidthTop = 0.5F
                tablaimportantecol1fil0.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil0.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil0)
                Dim tablaimportantecol0fil1 As New PdfPCell(New Phrase("1.", fontdetalletabla))
                tablaimportantecol0fil1.Border = 0
                tablaimportantecol0fil1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil1.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil1.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil1)
                Dim tablaimportantecol1fil1 As New PdfPCell(New Phrase("CARSEG se compromete a realizar el trabajo contratado, bajo las especificaciones detalladas y aceptadas por el cliente en la presente acta.", fontdetalletabla))
                tablaimportantecol1fil1.Border = 0
                tablaimportantecol1fil1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil1.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil1.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil1)
                Dim tablaimportantecol0fil2 As New PdfPCell(New Phrase("2.", fontdetalletabla))
                tablaimportantecol0fil2.Border = 0
                tablaimportantecol0fil2.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil2.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil2.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil2)
                Dim tablaimportantecol1fil2 As New PdfPCell(New Phrase("Previo el ingreso del vehículo a los talleres de CARSEG,  LA EMPRESA procederá a elaborar un inventario de todos los objetos y accesorios que se encuentren en el interior y exterior del mismo. Las partes dejan expresa constancia, que CARSEG no será responsable de las pérdidas y/o daños de accesorios, documentos, prendas y/u objetos en general, que no consten en el detalle del inventario efectuado por CARSEG.", fontdetalletabla))
                tablaimportantecol1fil2.Border = 0
                tablaimportantecol1fil2.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil2.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil2.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil2)
                Dim tablaimportantecol0fil3 As New PdfPCell(New Phrase("3.", fontdetalletabla))
                tablaimportantecol0fil3.Border = 0
                tablaimportantecol0fil3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil3.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil3.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil3)
                Dim tablaimportantecol1fil3 As New PdfPCell(New Phrase("El cliente se compromete a retirar el vehículo de los talleres de CARSEG, donde haya ingresado, a la hora determinada en el presente documento; caso contrario, podrá ser retirado el siguiente día laborable, en horarios de oficina.", fontdetalletabla))
                tablaimportantecol1fil3.Border = 0
                tablaimportantecol1fil3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil3.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil3.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil3)
                Dim tablaimportantecol0fil4 As New PdfPCell(New Phrase("4.", fontdetalletabla))
                tablaimportantecol0fil4.Border = 0
                tablaimportantecol0fil4.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil4.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil4.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil4)
                Dim tablaimportantecol1fil4 As New PdfPCell(New Phrase("El cliente se compromete a cancelar a CARSEG, el costo de los repuestos que hayan sido necesarios para la ejecución del trabajo contratado.", fontdetalletabla))
                tablaimportantecol1fil4.Border = 0
                tablaimportantecol1fil4.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil4.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil4.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil4)
                Dim tablaimportantecol0fil5 As New PdfPCell(New Phrase("5.", fontdetalletabla))
                tablaimportantecol0fil5.Border = 0
                tablaimportantecol0fil5.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil5.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil5.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil5)
                Dim tablaimportantecol1fil5 As New PdfPCell(New Phrase("Mientras el cliente no cancele el valor total del trabajo contratado, CARSEG se reservará el derecho de mantener el vehículo bajo su custodia.", fontdetalletabla))
                tablaimportantecol1fil5.Border = 0
                tablaimportantecol1fil5.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil5.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil5.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil5)
                Dim tablaimportantecol0fil6 As New PdfPCell(New Phrase("6.", fontdetalletabla))
                tablaimportantecol0fil6.Border = 0
                tablaimportantecol0fil6.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil6.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil6.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil6)
                Dim tablaimportantecol1fil6 As New PdfPCell(New Phrase("El cliente declara y acepta que CARDEG no será responsable de los daños que se verifiquen en el vehículo, cuando estos sean producto de fuerza mayor o caso fortuito; o, cuando el vehículo no ha sido retirado de los talleres de CARSEG, después de la fecha y hora de entrega establecidas.", fontdetalletabla))
                tablaimportantecol1fil6.Border = 0
                tablaimportantecol1fil6.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil6.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil6.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil6)
                Dim tablaimportantecol0fil7 As New PdfPCell(New Phrase("7.", fontdetalletabla))
                tablaimportantecol0fil7.Border = 0
                tablaimportantecol0fil7.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil7.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil7.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil7)
                Dim tablaimportantecol1fil7 As New PdfPCell(New Phrase("CARSEG no se responsabiliza  por los daños causados por sustancia peligrosa, explosivas, inflamables, tóxicas, no permitidas que ingresen en los vehículos, y no hayan sido declaradas por el cliente a CARSEG, a la entrega-recepción del mismo. El cliente será responsable de los daños humanos o materiales que estas sustancias pudieran ocasionar.", fontdetalletabla))
                tablaimportantecol1fil7.Border = 0
                tablaimportantecol1fil7.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil7.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil7.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil7)
                Dim tablaimportantecol0il8 As New PdfPCell(New Phrase("8.", fontdetalletabla))
                tablaimportantecol0il8.Border = 0
                tablaimportantecol0il8.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0il8.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0il8.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0il8)
                Dim tablaimportantecol1fil8 As New PdfPCell(New Phrase("El cliente tiene la obligación de revisar que su vehículo se encuentre en las condiciones detalladas en esta acta; una vez retirado de los talleres de LA EMPRESA, no se aceptará reclamo alguno.", fontdetalletabla))
                tablaimportantecol1fil8.Border = 0
                tablaimportantecol1fil8.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil8.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil8.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil8)
                Dim tablaimportantecol0fil9 As New PdfPCell(New Phrase("9.", fontdetalletabla))
                tablaimportantecol0fil9.Border = 0
                tablaimportantecol0fil9.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil9.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil9.BorderWidthLeft = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil9)
                Dim tablaimportantecol1fil9 As New PdfPCell(New Phrase("Es obligación del cliente entregar original o copia de la matrícula del vehículo, al ingreso del mismo en los talleres de CARSEG. Este documento quedará en custodia de LA EMPRESA, hasta la entrega del vehículo.", fontdetalletabla))
                tablaimportantecol1fil9.Border = 0
                tablaimportantecol1fil9.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil9.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil9.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil9)
                Dim tablaimportantecol0fil10 As New PdfPCell(New Phrase("10.", fontdetalletabla))
                tablaimportantecol0fil10.Border = 0
                tablaimportantecol0fil10.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol0fil10.BorderColorLeft = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil10.BorderWidthLeft = 0.5F
                tablaimportantecol0fil10.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablaimportantecol0fil10.BorderWidthBottom = 0.5F
                tablaimportante.AddCell(tablaimportantecol0fil10)
                Dim tablaimportantecol1fil10 As New PdfPCell(New Phrase("El cliente declara que entrega a CARSEG el vehículo en perfectas condiciones mecánicas y eléctricas; las fallas que se presenten en los sistemas de aire acondicionado, dirección, suspensión, frenos, motor, caja de cambios, embrague, o cualquier otro sistema mecánico, hidráulico, neumático, no serán responsabilidad de CARSEG, pues el trabajo a realizar se limita a la parte eléctrica del vehículo.", fontdetalletabla))
                tablaimportantecol1fil10.Border = 0
                tablaimportantecol1fil10.HorizontalAlignment = Element.ALIGN_LEFT
                tablaimportantecol1fil10.BorderColorBottom = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil10.BorderWidthBottom = 0.5F
                tablaimportantecol1fil10.BorderColorRight = BaseColor.LIGHT_GRAY
                tablaimportantecol1fil10.BorderWidthRight = 0.5F
                tablaimportante.AddCell(tablaimportantecol1fil10)
                documento.Add(tablaimportante)

                For i As Integer = 0 To dtParametros.Tables(2).Rows.Count - 1
                    documento.NewPage()
                    Dim tablaimagenes As New PdfPTable(1)
                    tablaimagenes.SetWidths(New Single() {100.0F})
                    Dim tablaimagenesfil1col1 As New PdfPCell(New Phrase("FOTO No. " & Convert.ToString(i + 1) & " de " & Convert.ToString(dtParametros.Tables(2).Rows.Count), fontcabecera))
                    tablaimagenesfil1col1.Border = 0
                    tablaimagenesfil1col1.PaddingTop = 3.0F
                    tablaimagenesfil1col1.BorderColorLeft = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1col1.BorderWidthLeft = 0.5F
                    tablaimagenesfil1col1.BorderColorTop = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1col1.BorderWidthTop = 0.5F
                    tablaimagenesfil1col1.BorderColorBottom = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1col1.BorderWidthBottom = 0.5F
                    tablaimagenesfil1col1.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaimagenesfil1col1.BorderColorRight = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1col1.BorderWidthRight = 0.5F
                    tablaimagenes.AddCell(tablaimagenesfil1col1)
                    documento.Add(tablaimagenes)

                    Dim imagen_str As String = dtParametros.Tables(2).Rows(i)("IMAGEN").ToString()
                    Dim novedad As String = dtParametros.Tables(2).Rows(i)("NOVEDAD").ToString()
                    Dim imagen As iTextSharp.text.Image = Nothing
                    Dim base64string As String = CreateImageFromString(imagen_str)
                    Dim bytes As Byte() = Convert.FromBase64String(base64string)
                    imagen = iTextSharp.text.Image.GetInstance(bytes)
                    imagen.Alignment = iTextSharp.text.Image.ALIGN_CENTER
                    imagen.Border = iTextSharp.text.Rectangle.NO_BORDER
                    imagen.BorderColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    imagen.BorderColorLeft = BaseColor.LIGHT_GRAY
                    imagen.BorderWidthLeft = 0.5F
                    imagen.BorderColorTop = BaseColor.LIGHT_GRAY
                    imagen.BorderWidthTop = 0.5F
                    imagen.BorderColorBottom = BaseColor.LIGHT_GRAY
                    imagen.BorderWidthBottom = 0.5F
                    imagen.BorderColorRight = BaseColor.LIGHT_GRAY
                    imagen.BorderWidthRight = 0.5F
                    imagen.ScaleToFit(498.0F, 455.0F)
                    documento.Add(imagen)

                    Dim tablaimagenesnov As New PdfPTable(3)
                    tablaimagenesnov.SetWidths(New Single() {4.0F, 96.0F, 4.0F})
                    Dim tablaimagenesfil1N1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil1N1.Border = 0
                    tablaimagenesnov.AddCell(tablaimagenesfil1N1)
                    Dim tablaimagenesfil1N2 As New PdfPCell(New Phrase("Comentario: ", fontdetalletabla))
                    tablaimagenesfil1N2.Border = 0
                    tablaimagenesfil1N2.Indent = 10
                    tablaimagenesfil1N2.PaddingTop = 3.0F
                    tablaimagenesfil1N2.BorderColorLeft = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1N2.BorderWidthLeft = 0.5F
                    tablaimagenesfil1N2.BorderColorTop = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1N2.BorderWidthTop = 0.5F
                    tablaimagenesfil1N2.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaimagenesfil1N2.BorderColorRight = BaseColor.LIGHT_GRAY
                    tablaimagenesfil1N2.BorderWidthRight = 0.5F
                    tablaimagenesnov.AddCell(tablaimagenesfil1N2)
                    Dim tablaimagenesfil1N3 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil1N3.Border = 0
                    tablaimagenesnov.AddCell(tablaimagenesfil1N3)
                    Dim tablaimagenesfil2N1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil2N1.Border = 0
                    tablaimagenesnov.AddCell(tablaimagenesfil2N1)
                    Dim tablaimagenesfil2N2 As New PdfPCell(New Phrase(novedad.ToUpper, fontdetalletabla))
                    tablaimagenesfil2N2.Border = 0
                    tablaimagenesfil2N2.Indent = 10
                    tablaimagenesfil2N2.PaddingTop = 3.0F
                    tablaimagenesfil2N2.BorderColorLeft = BaseColor.LIGHT_GRAY
                    tablaimagenesfil2N2.BorderWidthLeft = 0.5F
                    tablaimagenesfil2N2.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaimagenesfil2N2.BorderColorRight = BaseColor.LIGHT_GRAY
                    tablaimagenesfil2N2.BorderWidthRight = 0.5F
                    tablaimagenesnov.AddCell(tablaimagenesfil2N2)
                    Dim tablaimagenesfil2N3 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil2N3.Border = 0
                    tablaimagenesnov.AddCell(tablaimagenesfil2N3)
                    Dim tablaimagenesfil3N1 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil3N1.Border = 0
                    tablaimagenesnov.AddCell(tablaimagenesfil3N1)
                    Dim tablaimagenesfil3N2 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil3N2.Border = 0
                    tablaimagenesfil3N2.Indent = 10
                    tablaimagenesfil3N2.PaddingTop = 3.0F
                    tablaimagenesfil3N2.BorderColorLeft = BaseColor.LIGHT_GRAY
                    tablaimagenesfil3N2.BorderWidthLeft = 0.5F
                    tablaimagenesfil3N2.BorderColorBottom = BaseColor.LIGHT_GRAY
                    tablaimagenesfil3N2.BorderWidthBottom = 0.5F
                    tablaimagenesfil3N2.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaimagenesfil3N2.BorderColorRight = BaseColor.LIGHT_GRAY
                    tablaimagenesfil3N2.BorderWidthRight = 0.5F
                    tablaimagenesnov.AddCell(tablaimagenesfil3N2)
                    Dim tablaimagenesfil3N3 As New PdfPCell(New Phrase(" ", fontdetalletabla))
                    tablaimagenesfil3N3.Border = 0
                    tablaimagenesnov.AddCell(tablaimagenesfil3N3)
                    documento.Add(tablaimagenesnov)
                Next

                documento.Close()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Public Function CreateImageFromString(ByVal strImage As String) As String
        Dim bytes() As Byte = Convert.FromBase64String(strImage)
        Dim ms5 As New System.IO.MemoryStream(bytes)
        Dim base64Data = Convert.ToBase64String(ms5.ToArray())
        Return base64Data
    End Function

End Class
