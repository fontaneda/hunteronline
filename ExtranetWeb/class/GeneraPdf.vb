Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class GeneraPdf

    Public Sub GuiaRecepcion(cliente As String, orden As String, ByVal archivo As String)
        Try
            Dim imagepath As String = "\\10.100.107.14\GUIARECEPCION\"
            Dim fontpath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Fonts)
            Dim customfont As BaseFont = BaseFont.CreateFont(fontpath + "\39251.ttf", BaseFont.CP1252, BaseFont.EMBEDDED)
            Dim fontcodigos As Font = New Font(customfont, 11)
            Dim fontgeneral As iTextSharp.text.Font = FontFactory.GetFont("Arial", 6, Font.NORMAL, New BaseColor(0, 0, 0))
            Dim fontsmall As iTextSharp.text.Font = FontFactory.GetFont("Arial", 5, Font.NORMAL, New BaseColor(0, 0, 0))
            Dim fontordenes As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, Font.BOLD, New BaseColor(0, 0, 0))
            Dim documento As New Document(PageSize.A4, 5.0F, 12.0F, 100.0F, 0.0F)

            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(archivo, FileMode.Create))
            Dim ev As New CreacionPdfFormato()

            documento.Open()
            writer.PageEvent = ev

            Dim androidTurnos As New VehiculoTurnoAdapter
            Dim dTDatos As DataSet
            dTDatos = androidTurnos.ConsultaDatosRecepcion(cliente, orden)
            If dTDatos.Tables.Count > 0 Then
                If dTDatos.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 1 To 2
                        documento.NewPage()
                        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagepath + "fondo_recepcion_vehiculo.png")
                        logo.Alignment = iTextSharp.text.Image.UNDERLYING
                        logo.ScaleAbsolute(580, 420)
                        documento.Add(logo)

                        Dim tabladatoscliente As New PdfPTable(1)
                        tabladatoscliente.TotalWidth = 250.0F
                        tabladatoscliente.LockedWidth = True
                        tabladatoscliente.HorizontalAlignment = Element.ALIGN_LEFT
                        Dim datosclientefecha As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("LUGAR_FECHA"), fontgeneral))
                        datosclientefecha.Border = 0
                        datosclientefecha.PaddingTop = 49
                        datosclientefecha.PaddingLeft = 65
                        datosclientefecha.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatoscliente.AddCell(datosclientefecha)
                        Dim datosclientenombre As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("CLIENTE"), fontgeneral))
                        datosclientenombre.Border = 0
                        datosclientenombre.FixedHeight = 18.0F
                        datosclientenombre.PaddingTop = -1
                        datosclientenombre.PaddingLeft = 65
                        datosclientenombre.HorizontalAlignment = Element.ALIGN_LEFT
                        datosclientenombre.VerticalAlignment = Element.ALIGN_TOP
                        tabladatoscliente.AddCell(datosclientenombre)
                        Dim datosclientetelefono As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("TELEFONO"), fontgeneral))
                        datosclientetelefono.Border = 0
                        datosclientetelefono.PaddingTop = 9
                        datosclientetelefono.PaddingLeft = 65
                        datosclientetelefono.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatoscliente.AddCell(datosclientetelefono)
                        documento.Add(tabladatoscliente)

                        Dim tabladatosvehiculo As New PdfPTable(1)
                        tabladatosvehiculo.TotalWidth = 250.0F
                        tabladatosvehiculo.LockedWidth = True
                        tabladatosvehiculo.HorizontalAlignment = Element.ALIGN_LEFT
                        Dim datosvehiculoplacacolor As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("PLACA_COLOR"), fontgeneral))
                        datosvehiculoplacacolor.Border = 0
                        datosvehiculoplacacolor.PaddingTop = 28
                        datosvehiculoplacacolor.PaddingLeft = 65
                        datosvehiculoplacacolor.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatosvehiculo.AddCell(datosvehiculoplacacolor)
                        Dim datosvehiculomotor As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("NO_MOTOR"), fontgeneral))
                        datosvehiculomotor.Border = 0
                        datosvehiculomotor.PaddingTop = -2
                        datosvehiculomotor.PaddingLeft = 185
                        datosvehiculomotor.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatosvehiculo.AddCell(datosvehiculomotor)
                        Dim datosvehiculoseriechasis As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("SERIE_CHASIS"), fontgeneral))
                        datosvehiculoseriechasis.Border = 0
                        datosvehiculoseriechasis.PaddingTop = -2
                        datosvehiculoseriechasis.PaddingLeft = 65
                        datosvehiculoseriechasis.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatosvehiculo.AddCell(datosvehiculoseriechasis)
                        Dim datosvehiculomarcmodtip As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("MARC_MOD_TIP"), fontsmall))
                        datosvehiculomarcmodtip.Border = 0
                        datosvehiculomarcmodtip.PaddingTop = 5
                        datosvehiculomarcmodtip.PaddingLeft = 95
                        datosvehiculomarcmodtip.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatosvehiculo.AddCell(datosvehiculomarcmodtip)
                        documento.Add(tabladatosvehiculo)

                        Dim tablatrabajosvehiculo As New PdfPTable(1)
                        tablatrabajosvehiculo.TotalWidth = 250.0F
                        tablatrabajosvehiculo.LockedWidth = True
                        tablatrabajosvehiculo.HorizontalAlignment = Element.ALIGN_LEFT
                        Dim datostrabajosvehiculo As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("TRABAJO"), fontgeneral))
                        datostrabajosvehiculo.Border = 0
                        datostrabajosvehiculo.PaddingTop = 24
                        datostrabajosvehiculo.PaddingLeft = 20
                        datostrabajosvehiculo.HorizontalAlignment = Element.ALIGN_LEFT
                        tablatrabajosvehiculo.AddCell(datostrabajosvehiculo)
                        documento.Add(tablatrabajosvehiculo)

                        Dim fechaDocumento As String = FormatDateTime(Date.Now, DateFormat.ShortDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime)
                        Dim tabladatosreservado As New PdfPTable(1)
                        tabladatosreservado.TotalWidth = 250.0F
                        tabladatosreservado.LockedWidth = True
                        tabladatosreservado.HorizontalAlignment = Element.ALIGN_RIGHT
                        Dim datospaginareservado As New PdfPCell(New Phrase("Turno reservado en HunterOnline", fontgeneral))
                        datospaginareservado.Border = 0
                        datospaginareservado.PaddingTop = -170
                        datospaginareservado.PaddingRight = 100
                        datospaginareservado.HorizontalAlignment = Element.ALIGN_RIGHT
                        tabladatosreservado.AddCell(datospaginareservado)
                        Dim datospaginafechareservado As New PdfPCell(New Phrase(fechaDocumento, fontgeneral))
                        datospaginafechareservado.Border = 0
                        datospaginafechareservado.PaddingTop = -162
                        datospaginafechareservado.PaddingRight = 100
                        datospaginafechareservado.HorizontalAlignment = Element.ALIGN_RIGHT
                        tabladatosreservado.AddCell(datospaginafechareservado)
                        documento.Add(tabladatosreservado)

                        Dim tabladatostipoguia As New PdfPTable(1)
                        tabladatostipoguia.TotalWidth = 63.0F
                        tabladatostipoguia.LockedWidth = True
                        tabladatostipoguia.HorizontalAlignment = Element.ALIGN_RIGHT
                        Dim tipoguia As String = ""
                        If i = 1 Then
                            tipoguia = "Original: Cliente"
                        ElseIf i = 2 Then
                            tipoguia = "Copia: Talleres"
                        End If
                        Dim datospaginatipo As New PdfPCell(New Phrase(tipoguia, fontsmall))
                        datospaginatipo.Border = 0
                        datospaginatipo.PaddingTop = -150
                        datospaginatipo.PaddingLeft = 0
                        datospaginatipo.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatostipoguia.AddCell(datospaginatipo)
                        documento.Add(tabladatostipoguia)

                        Dim tabladatosorden As New PdfPTable(1)
                        tabladatosorden.TotalWidth = 285.0F
                        tabladatosorden.LockedWidth = True
                        tabladatosorden.HorizontalAlignment = Element.ALIGN_RIGHT
                        Dim datosclienteorden As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("O_S"), fontordenes))
                        datosclienteorden.Border = 0
                        datosclienteorden.PaddingTop = -140
                        datosclienteorden.PaddingLeft = 0
                        datosclienteorden.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatosorden.AddCell(datosclienteorden)
                        documento.Add(tabladatosorden)

                        Dim tabladatosordencodigo As New PdfPTable(1)
                        tabladatosordencodigo.TotalWidth = 315.0F
                        tabladatosordencodigo.LockedWidth = True
                        tabladatosordencodigo.HorizontalAlignment = Element.ALIGN_RIGHT
                        Dim datosclienteordencodigo As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("O_S"), fontcodigos))
                        datosclienteordencodigo.Border = 0
                        datosclienteordencodigo.PaddingTop = -125
                        datosclienteordencodigo.PaddingLeft = 0
                        datosclienteordencodigo.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatosordencodigo.AddCell(datosclienteordencodigo)
                        documento.Add(tabladatosordencodigo)

                        Dim tabladatostrabajo As New PdfPTable(1)
                        tabladatostrabajo.TotalWidth = 285.0F
                        tabladatostrabajo.LockedWidth = True
                        tabladatostrabajo.HorizontalAlignment = Element.ALIGN_RIGHT
                        Dim datosclientetrabajo As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("O_T"), fontordenes))
                        datosclientetrabajo.Border = 0
                        datosclientetrabajo.PaddingTop = 11
                        datosclientetrabajo.PaddingLeft = 0
                        datosclientetrabajo.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatostrabajo.AddCell(datosclientetrabajo)
                        documento.Add(tabladatostrabajo)

                        Dim tabladatostrabajocodigo As New PdfPTable(1)
                        tabladatostrabajocodigo.TotalWidth = 315.0F
                        tabladatostrabajocodigo.LockedWidth = True
                        tabladatostrabajocodigo.HorizontalAlignment = Element.ALIGN_RIGHT
                        Dim datosclientetrabajocodigo As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("O_T"), fontcodigos))
                        datosclientetrabajocodigo.Border = 0
                        datosclientetrabajocodigo.PaddingTop = 5
                        datosclientetrabajocodigo.PaddingLeft = 0
                        datosclientetrabajocodigo.HorizontalAlignment = Element.ALIGN_LEFT
                        tabladatostrabajocodigo.AddCell(datosclientetrabajocodigo)
                        documento.Add(tabladatostrabajocodigo)
                    Next
                    documento.NewPage()
                    Dim imgTerminos As Image = Image.GetInstance(imagepath + "Terminos.png")
                    imgTerminos.Alignment = iTextSharp.text.Image.UNDERLYING
                    imgTerminos.ScaleAbsolute(580, 420)
                    documento.Add(imgTerminos)
                End If
            End If
            documento.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
