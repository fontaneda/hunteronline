Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
'Imports System.Text

Public Class DocumentosContratos

    Public Function GenerarDocumento(ByVal idCliente As String, cliente As String, idVehiculo As String) As String
        Dim retorno As String = ""
        Try
            Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 11, Font.BOLD, BaseColor.BLACK)
            Dim fontcabeceradetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)
            Dim fontcabeceradetallenegrita As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)
            Dim documento As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 50.0F)
            Dim nombreFile As String = "Contrato_" & idCliente & "_" & Date.Now.ToString("yyyyMMdd") & "_" & Date.Now.ToString("HHmmss") & ".pdf"
            Dim file As String = String.Format("{0}{1}", ConsultaRuta(), nombreFile)
            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim paragraph As New iTextSharp.text.Paragraph(" ")
            Dim ev As New CreacionPdf()
            documento.Open()
            documento.NewPage()
            writer.PageEvent = ev
            documento.Add(paragraph)

            'DATOS DE LA CABECERA
            Dim tablacontrato As New PdfPTable(1)
            tablacontrato.SetWidths(New Single() {100.0F})
            'TITULO DEL DOCUMENTO
            Dim titulocon1 As New PdfPCell(New Phrase("CONTRATO DE SERVICIOS", fontcabecera))
            titulocon1.Border = 0
            titulocon1.HorizontalAlignment = Element.ALIGN_CENTER
            tablacontrato.AddCell(titulocon1)
            'LINEA EN BLANCO
            Dim titulocon2 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
            titulocon2.Border = 0
            titulocon2.HorizontalAlignment = Element.ALIGN_CENTER
            tablacontrato.AddCell(titulocon2)
            tablacontrato.AddCell(titulocon2)
            'TEXTO PRINCIPAL
            Dim titulocon3 As New PdfPCell(New Phrase("Conste por el presente instrumento un contrato de servicios de que se otorga al tenor de las cláusulas y declaraciones siguientes: ", fontcabeceradetalle))
            titulocon3.Border = 0
            titulocon3.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon3)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon4 As New PdfPCell(New Phrase("CLAUSULA PRIMERA:  COMPARECIENTES. ", fontcabeceradetallenegrita))
            titulocon4.Border = 0
            titulocon4.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon4)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon5 As New PdfPCell(New Phrase("A) Por una parte, la compañía CARRO SEGURO CARSEG S. A., por la interpuesta persona de su representante legal, parte a la que en adelante y para los efectos del presente instrumento se podrá denominar simplemente ""CARSEG"" y/o ""LA EMPRESA""; y,", fontcabeceradetalle))
            titulocon5.Border = 0
            titulocon5.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            titulocon5.PaddingLeft = 20.0F
            tablacontrato.AddCell(titulocon5)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon6 As New PdfPCell(New Phrase())
            titulocon6.Phrase.Add(New Chunk("B) Por otra parte, la persona que suscribe el presente contrato, ", fontcabeceradetalle))
            titulocon6.Phrase.Add(New Chunk(cliente, fontcabeceradetallenegrita))
            titulocon6.Phrase.Add(New Chunk(" con C.I. ", fontcabeceradetalle))
            titulocon6.Phrase.Add(New Chunk(idcliente, fontcabeceradetallenegrita))
            titulocon6.Phrase.Add(New Chunk(", por sus propios derechos o por los que representa, a quien en adelante y para los efectos del presente contrato, se podrá denominar simplemente ""EL CLIENTE"". ", fontcabeceradetalle))
            titulocon6.Border = 0
            titulocon6.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            titulocon6.PaddingLeft = 20.0F
            tablacontrato.AddCell(titulocon6)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon7 As New PdfPCell(New Phrase("CLAUSULA SEGUNDA:  ANTECEDENTES.-", fontcabeceradetallenegrita))
            titulocon7.Border = 0
            titulocon7.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon7)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon8 As New PdfPCell(New Phrase("1) CARRO SEGURO CARSEG S. A., es una compañía ecuatoriana dedicada a la importación, distribución exclusiva, venta e instalación de un sistema de rastreo y monitoreo de vehículos robados, identificado con el 	nombre comercial ""Hunter"".  Inmediatamente localizados los vehículos siniestrados, por parte de CARSEG, pueden ser recuperados por la Autoridad Competente. En consecuencia, el sistema antes esbozado, consiste en un dispositivo de rastreo instalado en el vehículo, que es activado solo remotamente, esto es, al momento en que EL CLIENTE denuncie el siniestro de su vehículo a la central de CARSEG, expresando su código secreto.", fontcabeceradetalle))
            titulocon8.Border = 0
            titulocon8.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            titulocon8.PaddingLeft = 20.0F
            tablacontrato.AddCell(titulocon8)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon9 As New PdfPCell(New Phrase("2) EL CLIENTE es actual y legítimo propietario del vehículo cuyas características se encuentran determinadas en la cláusula ""Condiciones Particulares"" del presente contrato.", fontcabeceradetalle))
            titulocon9.Border = 0
            titulocon9.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            titulocon9.PaddingLeft = 20.0F
            tablacontrato.AddCell(titulocon9)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon10 As New PdfPCell(New Phrase())
            titulocon10.Phrase.Add(New Chunk("CLAUSULA TERCERA:  OBJETO DEL CONTRATO.- ", fontcabeceradetallenegrita))
            titulocon10.Phrase.Add(New Chunk("Con estos antecedentes, la compañía CARRO SEGURO CARSEG S. A., instala el dispositivo HUNTER, que en esta misma fecha ha adquirido el CLIENTE, en el vehículo de su propiedad. CARSEG se compromete con el CLIENTE que adquiere el sistema HUNTER, a iniciar, ya sea de manera directa, o a través de terceras personas, el rastreo del vehículo robado una vez que se active el dispositivo, momento en el cual empezará el rastreo del mismo. Localizado el vehículo, se iniciará la fase de recuperación del mismo, que es de exclusiva responsabilidad de la Autoridad Competente, no obstante el apoyo logístico que en esta fase pueda prestar CARSEG, por sí o a través de terceras personas.", fontcabeceradetalle))
            titulocon10.Border = 0
            titulocon10.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon10)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon11 As New PdfPCell(New Phrase("Los vehículos recuperados por la Autoridad Competente, de conformidad con la ley, serán movilizados, salvo excepciones fuera de control, a los patios de la Policía Nacional y permanecerán allá hasta que bajo providencia u orden de la Autoridad Competente, previa presentación de la documentación que respalde la propiedad, puedan ser entregados a los CLIENTES propietarios o a quien legalmente corresponda, sin perjuicio de que, previamente a la entrega antes referida, el CLIENTE pague los valores que de conformidad con la ley correspondan a cualquiera de las entidades de la fuerza pública, por concepto de grúas, tasas por custodia, etc.  Así también, EL CLIENTE se obliga a pagar a CARSEG el valor correspondiente, por concepto de reprogramación, chequeo y limpieza del sistema, vigente a esa fecha.", fontcabeceradetalle))
            titulocon11.Border = 0
            titulocon11.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon11)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon12 As New PdfPCell(New Phrase("Se deja expresa constancia que CARSEG no asume responsabilidad alguna por el estado en que el vehículo sea recuperado.", fontcabeceradetalle))
            titulocon12.Border = 0
            titulocon12.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon12)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon13 As New PdfPCell(New Phrase())
            titulocon13.Phrase.Add(New Chunk("CLAUSULA CUARTA:  PLAZO.-  ", fontcabeceradetallenegrita))
            titulocon13.Phrase.Add(New Chunk("El plazo de duración del presente contrato es el determinado en la cláusula ""Condiciones Particulares"", mismo que se contará a partir de la suscripción de este instrumento.", fontcabeceradetalle))
            titulocon13.Border = 0
            titulocon13.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon13)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon14 As New PdfPCell(New Phrase("El presente contrato podrá ser renovado en los mismos términos y condiciones, por igual plazo o por uno superior, y así sucesivamente, a menos que medie una comunicación escrita por parte del CLIENTE, por lo menos con quince (15) días de anticipación a su vencimiento o última renovación.", fontcabeceradetalle))
            titulocon14.Border = 0
            titulocon14.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon14)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon15 As New PdfPCell(New Phrase("Para efectos de la renovación automática antes aludida, el CLIENTE no deberá pagar valor alguno por el sistema ""HUNTER"" instalado en su vehículo; sin perjuicio de lo cual, por cada renovación, el CLIENTE se obliga a pagar el valor correspondiente al servicio de rastreo que contrate.", fontcabeceradetalle))
            titulocon15.Border = 0
            titulocon15.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon15)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon16 As New PdfPCell(New Phrase())
            titulocon16.Phrase.Add(New Chunk("CLAUSULA QUINTA: PRECIO.- ", fontcabeceradetallenegrita))
            titulocon16.Phrase.Add(New Chunk("El valor del sistema HUNTER y del servicio de rastreo, así como la forma de pago de los mismos, se encuentran determinados en la cláusula ""Condiciones Particulares"" del presente contrato.", fontcabeceradetalle))
            titulocon16.Border = 0
            titulocon16.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon16)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon17 As New PdfPCell(New Phrase())
            titulocon17.Phrase.Add(New Chunk("CLAUSULA SEXTA:  OBLIGACIONES DEL CLIENTE.-  ", fontcabeceradetallenegrita))
            titulocon17.Phrase.Add(New Chunk("En caso de que el vehículo del CLIENTE sufra algún choque, volcamiento o cualquier otro siniestro, aquel deberá comunicar este particular a CARSEG, con el objeto de que ésta revise el dispositivo, para que en caso de que éste se haya destruido a causa del accidente, aquella proceda a instalar uno nuevo, siempre y cuando el CLIENTE asuma el valor del mismo.  EL CLIENTE está obligado a comunicar a CARSEG de la instalación de equipos adicionales al vehículo, tales como, equipos de sonido, parlantes, aire acondicionado, ecualizadores, amplificadores, etc., así como de las reparaciones o enderezamiento que se realice, en las estructuras o sistema eléctrico del vehículo y que puedan comprometer al dispositivo que se encuentra ubicado en el vehículo.  Así también, el CLIENTE se encuentra obligado a realizar cada seis (6) meses, y siempre que CARSEG así se lo requiera, una revisión del dispositivo en las instalaciones de CARSEG.  Al efecto, EL CLIENTE se obliga a cancelar a LA EMPRESA, los costos que generare la revisión del dispositivo; así como el de las partes o piezas que hayan requerido reparación o reemplazo.", fontcabeceradetalle))
            titulocon17.Border = 0
            titulocon17.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon17)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon18 As New PdfPCell(New Phrase("Es obligación del CLIENTE notificar el cambio de domicilio, teléfono o compañía de seguro, así como modificaciones en el color de su vehículo, para ser actualizado en la base de datos de CARSEG. ", fontcabeceradetalle))
            titulocon18.Border = 0
            titulocon18.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon18)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon19 As New PdfPCell(New Phrase("Así también, EL CLIENTE se obliga a declarar el destino para el cual será utilizado el vehículo donde se instala el dispositivo HUNTER.", fontcabeceradetalle))
            titulocon19.Border = 0
            titulocon19.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon19)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon20 As New PdfPCell(New Phrase())
            titulocon20.Phrase.Add(New Chunk("CLAUSULA SEPTIMA: SUSPENSIÓN DEL SERVICIO DE RASTREO.- ", fontcabeceradetallenegrita))
            titulocon20.Phrase.Add(New Chunk("A más de los casos previstos en la Ley y en el presente contrato, el servicio de rastreo se suspenderá si uno de los pagos recibidos por CARSEG, por el dispositivo HUNTER o por la renovación del servicio, se efectúa con un cheque y éste fuere protestado o devuelto por cualquier motivo que no implique negligencia de CARSEG; o, en caso de que EL CLIENTE se encuentre en mora de al menos dos de los pagos que debe efectuar a CARSEG.Â  La suspensión del servicio de rastreo antes referido, tendrá al inicio el carácter de temporal durante un lapso de setenta y dos (72) horas.  Fenecido este plazo y, si el CLIENTE no hubiere subsanado la causal de suspensión, la misma tendrá el carácter de definitiva, quedando consecuentemente resuelto el presente contrato. El cliente reconoce y acepta de manera expresa, que dentro del lapso de la suspensión temporal, CARSEG no prestará el servicio de rastreo, por lo que en el evento de que el vehículo del CLIENTE sea robado en este lapso, CARSEG quedará exenta de toda responsabilidad con el CLIENTE y/o terceros perjudicados. Así también, el cliente reconoce y acepta que no será responsabilidad de CARSEG, el notificarle de la suspensión temporal o definitiva del servicio, en el evento de que el CLIENTE no se encuentre al día en los pagos del mismo.", fontcabeceradetalle))
            titulocon20.Border = 0
            titulocon20.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon20)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon21 As New PdfPCell(New Phrase())
            titulocon21.Phrase.Add(New Chunk("CLAUSULA OCTAVA:  ", fontcabeceradetallenegrita))
            titulocon21.Phrase.Add(New Chunk("DE LAS TRANSFERENCIAS Y DESINSTALACIONES.-  EL CLIENTE podrá, en caso de transferir el dominio de su vehículo, hacerlo con el dispositivo HUNTER, debiendo para este efecto, comunicar el particular a CARSEG, mediante la entrega de una copia legalizada de la respectiva carta de venta.  En este evento, el adquiriente del vehículo, se deberá subrogar en todos y cada uno de los derechos y obligaciones que emanan del presente contrato, para cuyo efecto, deberá acudir a las oficinas de CARSEG, a fin de instrumentar la subrogación.  Mientras dicha subrogación no se efectúe, CARSEG no prestará el servicio de rastreo, eximiéndose consecuentemente, de toda responsabilidad frente al CLIENTE, el nuevo propietario y/o terceros perjudicados.", fontcabeceradetalle))
            titulocon21.Border = 0
            titulocon21.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon21)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon22 As New PdfPCell(New Phrase("Sin perjuicio de lo anterior, en caso de que EL CLIENTE transfiera la propiedad de su vehículo y no notifique el particular a CARSEG, bastará que el nuevo propietario presente a ésta la carta de venta debidamente legalizada, para que se proceda a la subrogación mencionada en el párrafo precedente, entendiéndose que el vehículo fue transferido conjuntamente con el dispositivo. Si la falta de notificación en cualquiera de los casos antes mencionados, generare perjuicios a CARSEG, EL CLIENTE se responsabiliza desde ya a resarcirlos pecuniariamente; así como, a cubrir los gastos legales en que incurra LA EMPRESA, dentro de cualquier controversia que se inicie por esta causa.", fontcabeceradetalle))
            titulocon22.Border = 0
            titulocon22.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon22)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon23 As New PdfPCell(New Phrase("EL CLIENTE conoce y acepta que podrá solicitar a CARSEG, hasta tres (3) desinstalaciones de su dispositivo HUNTER, para que éste sea instalado en otros vehículos de su propiedad.  Al efecto, EL CLIENTE se obliga a pagar a CARSEG, el costo que a la fecha de la solicitud, se haya fijado para el servicio de desinstalación. Así también, EL CLIENTE declara y acepta que no podrá solicitar desinstalaciones adicionales; sin embargo, en caso de así requerirlo, CARSEG no será responsable por el deterioro o daño del dispositivo, y estará exenta del pago de las indemnizaciones establecidas en este instrumento, por la no recuperación del vehículo.", fontcabeceradetalle))
            titulocon23.Border = 0
            titulocon23.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon23)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon24 As New PdfPCell(New Phrase())
            titulocon24.Phrase.Add(New Chunk("CLAUSULA NOVENA: GARANTIA.- ", fontcabeceradetallenegrita))
            titulocon24.Phrase.Add(New Chunk("CARSEG otorga a favor del CLIENTE, garantía de un (1) año, sobre el dispositivo HUNTER vendido.  El plazo de la garantía se contará a partir de la instalación del sistema.  Esta garantía cubre, exclusivamente, defectos de fábrica; pero en ningún caso, CARSEG será responsable por el deterioro, daño o robo que sufra el dispositivo, cuando dicho deterioro o daño provenga de la culpa o negligencia del CLIENTE, sus dependientes y/o terceros no autorizados.", fontcabeceradetalle))
            titulocon24.Border = 0
            titulocon24.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon24)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon25 As New PdfPCell(New Phrase())
            titulocon25.Phrase.Add(New Chunk("CLAUSULA DÉCIMA:  INDEMNIZACIONES.- ", fontcabeceradetallenegrita))
            titulocon25.Phrase.Add(New Chunk("Si el vehículo del CLIENTE es robado y ha transcurrido un período de tiempo superior a cuarenta y cinco (45) días, desde la activación del dispositivo HUNTER instalado en el mismo, sin que CARSEG directa o indirectamente haya podido localizarlo, y por ende no se pueda realizar la recuperación por parte de las Autoridades Competentes, CARSEG se compromete a devolver el valor total pagado por el sistema HUNTER o, el total de la última cuota anual del servicio de rastreo y mantenimiento pagada por concepto de renovación del contrato, a elección de CARSEG, menos los costos en que CARSEG haya incurrido en el rastreo del vehículo, quedando consecuentemente resuelto el presente contrato. ", fontcabeceradetalle))
            titulocon25.Border = 0
            titulocon25.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon25)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon26 As New PdfPCell(New Phrase("En caso de que EL CLIENTE reporte el robo del vehículo, luego de tres (3) días de ocurrido el hecho, CARSEG no será responsable por la no recuperación del vehículo, y no estará obligada al pago de la indemnización establecida en esta cláusula o de ningún otra.", fontcabeceradetalle))
            titulocon26.Border = 0
            titulocon26.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon26)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon27 As New PdfPCell(New Phrase("EL CLIENTE declara y acepta, que en caso de que el vehículo donde se encuentra instalado el dispositivo HUNTER sea robado, y dicho vehículo haya venido siendo utilizado comercialmente, esto es el destinado a transporte de pasajeros, la denuncia del siniestro deberá ser presentada dentro de las cuatro (4) horas siguientes de verificado el hecho, caso contrario CARSEG no será responsable por la no recuperación del vehículo y no estará obligada al pago de la indemnización establecida en esta cláusula o de ningún otra.", fontcabeceradetalle))
            titulocon27.Border = 0
            titulocon27.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon27)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon28 As New PdfPCell(New Phrase("Así también, EL CLIENTE conoce y acepta, que de comprobarse que el destino del vehículo no es el declarado en el presente instrumento, CARSEG estará exenta del pago de la indemnización establecida en esta cláusula y/o de cualquier otra por la no recuperación del mismo.", fontcabeceradetalle))
            titulocon28.Border = 0
            titulocon28.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon28)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon29 As New PdfPCell(New Phrase("Las indemnizaciones aquí estipuladas tendrán plena vigencia, siempre y cuando el CLIENTE haya solicitado la activación del sistema de manera oportuna y diligente; y, haya cumplido con las obligaciones constantes en este instrumento.", fontcabeceradetalle))
            titulocon29.Border = 0
            titulocon29.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon29)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon30 As New PdfPCell(New Phrase())
            titulocon30.Phrase.Add(New Chunk("CLAUSULA UNDECIMA: CUSTODIA.- ", fontcabeceradetallenegrita))
            titulocon30.Phrase.Add(New Chunk("EL CLIENTE declara de manera voluntaria, incondicional e irrevocable, que en caso de solicitar la desinstalación del dispositivo HUNTER del vehículo de su propiedad, sin disponer su inmediata reinstalación, LA EMPRESA será la única autorizada a mantener en su custodia el dispositivo desinstalado, sin que por este servicio, el CLIENTE está obligado al pago de valor alguno. ", fontcabeceradetalle))
            titulocon30.Border = 0
            titulocon30.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon30)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon31 As New PdfPCell(New Phrase("EL CLIENTE declara y acepta, que por motivos de seguridad, no podrá retirar el dispositivo HUNTER de las bodegas de CARSEG, sino únicamente ordenar su reinstalación en otro vehículo de su propiedad, manteniendo sus derechos como legítimo propietario del mismo.", fontcabeceradetalle))
            titulocon31.Border = 0
            titulocon31.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon31)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon32 As New PdfPCell(New Phrase("CARSEG se responsabiliza del buen funcionamiento del dispositivo HUNTER del CLIENTE, hasta los noventa (90) días siguientes a la fecha de remoción del mismo; transcurrido este plazo, LA EMPRESA estará exenta de responsabilidad por el estado de funcionamiento en que se encuentre el dispositivo, cuando EL CLIENTE solicite su reinstalación.", fontcabeceradetalle))
            titulocon32.Border = 0
            titulocon32.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon32)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon33 As New PdfPCell(New Phrase())
            titulocon33.Phrase.Add(New Chunk("CLAUSULA DUODECIMA: RIESGO CAMBIARIO.- ", fontcabeceradetallenegrita))
            titulocon33.Phrase.Add(New Chunk("Las partes acuerdan que el riesgo cambiario del presente contrato es de cargo del CLIENTE, quien  deberá hacer sus pagos a CARSEG en Dólares de los Estados Unidos de América. En este sentido, sin excepción alguna, todas y cada una de las obligaciones económicas contempladas en este contrato a cargo del CLIENTE a favor de CARSEG, deberán ser cumplidas, satisfechas, canceladas, restituidas y/o pagadas en Dólares de los Estados Unidos de América.", fontcabeceradetalle))
            titulocon33.Border = 0
            titulocon33.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon33)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon34 As New PdfPCell(New Phrase("En el evento de que cualquier legislación vigente o emitida en el futuro  (ley, reglamento u otra) dispusiese el cambio del régimen monetario, o el Ecuador asuma otra moneda distinta al Dólar de los Estados Unidos América como de curso legal único o alternativo del Ecuador, EL CLIENTE renuncia a todos y cualquier derecho, pasado, actual o futuro que le permita o llegue a permitir, satisfacer, cancelar, restituir y/o pagar sus obligaciones previstas en el presente contrato en una monea distinta al Dólar de los Estados Unidos de América.", fontcabeceradetalle))
            titulocon34.Border = 0
            titulocon34.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon34)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon35 As New PdfPCell(New Phrase())
            titulocon35.Phrase.Add(New Chunk("CLAUSULA DECIMA TERCERA: AUTORIZACIÓN.- ", fontcabeceradetallenegrita))
            titulocon35.Phrase.Add(New Chunk("EL CLIENTE autoriza expresamente a CARSEG, para que obtenga de cualquier fuente de información, incluida la Central de Riesgos, sus referencias e información personal sobre su comportamiento crediticio, manejo de cuentas, corrientes, de ahorro, tarjetas de crédito, etc., y en general sobre el cumplimiento de sus obligaciones y demás activos, pasivos y datos personales. Así también, autoriza expresamente a CARSEG para que pueda utilizar, transferir o entregar dicha información a autoridades competentes, organismos de control, Burós de Información Crediticia y otras instituciones o personas jurídicas, legales o reglamentariamente facultadas, así como para que pueda hacer público su comportamiento crediticio.", fontcabeceradetalle))
            titulocon35.Border = 0
            titulocon35.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon35)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon36 As New PdfPCell(New Phrase("Así también, EL CLIENTE autoriza expresamente a CARSEG, a informar a la compañía de seguros, con la que mantenga un contrato de seguros vigente, los antecedentes, circunstancias y resultados del operativo de rastreo de su vehículo, cuando haya sido objeto de robo.", fontcabeceradetalle))
            titulocon36.Border = 0
            titulocon36.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon36)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon37 As New PdfPCell(New Phrase("", fontcabeceradetalle))
            titulocon37.Phrase.Add(New Chunk("CLAUSULA DÉCIMA CUARTA: ACTIVACION DEL SISTEMA.- ", fontcabeceradetallenegrita))
            titulocon37.Phrase.Add(New Chunk("La efectividad del sistema HUNTER se encuentra garantizada únicamente por la rápida llamada de auxilio del CLIENTE, siendo para ello necesario que el CLIENTE se comunique con CARRO SEGURO CARSEG S.A.: En Guayaquil, ""METRO"" a los números 2563-500 y/o ""Buscapersonas"" 2208-641 solicitando un mensaje para HUNTER y proporcionando inmediatamente el código o clave secreta que le será asignado.  En caso de imposibilidad en las comunicaciones con ""METRO"" y/o ""Busca personas"" el CLIENTE podrá llamar a los números celulares:  099404757 (Guayaquil), 099831961 (Quito), 099831961 (Tumbaco), 099428300 (Machala), 095153358 (Cuenca), 099423662 (Manta), 099421422 (Ambato), 097907484 (Quevedo), 098281011 (Salinas), 097907442 (Ibarra), 099489914 (Sto. Domingo), 099428300 (Loja), y/o a los teléfonos que durante la vigencia del presente contrato determine CARSEG.  El CLIENTE acepta y manifiesta su conformidad, para que las llamadas de denuncia que sean por él efectuadas o por su cuenta, sean grabadas en cintas magnetofónicas o por cualquier otro medio, siendo éstas y sus transcripciones escritas, confidenciales.  Si la denuncia la realiza un tercero a nombre del propietario, sin conocer el código  secreto, debe aquel acercarse personalmente a las oficinas de CARSEG portando su cédula de ciudadanía o identidad, para firmar la responsabilidad de su denuncia. El mal uso de la activación o llamada de auxilio, es decir, que se dé una falsa alarma, generará una multa pecuniaria para el CLIENTE, cuya cuantía será determinada por CARSEG y, que desde ya, la acepta el CLIENTE.Â  Si éste no cancelare la sanción pecuniaria dentro de un plazo de tres días hábiles desde su emisión, CARSEG procederá y así lo acepta el CLIENTE, a dar por terminado el contrato y a la suspensión definitiva del servicio, sin responsabilidad alguna para CARSEG.  Para determinar el mal uso de activación o de una falsa llamada que produce la falsa alarma, CARSEG podrá hacer uso de la grabación de la llamada efectuada, mediante la cual se acreditará suficientemente tal hecho.  Si como consecuencia del mal uso del sistema HUNTER, por parte del CLIENTE, resultare afectada la integridad personal o material del CLIENTE propietario o de cualquier tercera persona, CARSEG o las personas que efectúen la labor de rastreo del vehículo estarán exentas de responsabilidad.", fontcabeceradetalle))
            titulocon37.Border = 0
            titulocon37.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon37)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon38 As New PdfPCell(New Phrase("Si en el operativo de rastreo del vehículo robado se inmiscuye el CLIENTE, familiares o allegados al mismo, CARSEG estará facultada a no iniciarlo o a suspenderlo, de ser el caso.  La fase de recuperación del vehículo del CLIENTE que haya sido localizado por CARSEG, ya sea directamente o a través de terceras personas, es exclusiva competencia y responsabilidad de las Autoridades Competentes.  El CLIENTE no tiene derecho a conocer el lugar estratégico donde se encuentra instalado el dispositivo HUNTER en su vehículo, manipularlo de ninguna forma o desinstalarlo, pues las únicas personas autorizadas para hacerlo son los técnicos de CARSEG. La inobservancia de esta disposición producirá la pérdida de la garantía del dispositivo y, de ser el caso, la suspensión definitiva del servicio y terminación del contrato, por parte de CARSEG. CARSEG no será responsable por el robo, deterioro o daño de las pertenencias del CLIENTE y/o accesorios de su vehículo, que se encuentren en el mismo al momento de ocurrir el robo y posterior recuperación del mismo.", fontcabeceradetalle))
            titulocon38.Border = 0
            titulocon38.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon38)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon39 As New PdfPCell(New Phrase("CLAUSULA DÉCIMA QUINTA: CONDICIONES PARTICULARES.-", fontcabeceradetallenegrita))
            titulocon39.Border = 0
            titulocon39.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tablacontrato.AddCell(titulocon39)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon40 As New PdfPCell(New Phrase())
            titulocon40.Phrase.Add(New Chunk("1. Cliente: ", fontcabeceradetalle))
            titulocon40.Phrase.Add(New Chunk(cliente, fontcabeceradetalle))
            titulocon40.Border = 0
            titulocon40.HorizontalAlignment = Element.ALIGN_LEFT
            tablacontrato.AddCell(titulocon40)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon41 As New PdfPCell(New Phrase())
            titulocon41.Phrase.Add(New Chunk("2. Características del vehículo donde se instala el dispositivo HUNTER: ", fontcabeceradetalle))
            titulocon41.Border = 0
            titulocon41.HorizontalAlignment = Element.ALIGN_LEFT
            tablacontrato.AddCell(titulocon41)
            tablacontrato.AddCell(titulocon2)
            documento.Add(tablacontrato)

            Dim dtParametros As New System.Data.DataSet
            dtParametros = DocumentosAdapter.ConsultaDatosDA("107", idCliente, idVehiculo)
            If dtParametros.Tables(0).Rows.Count > 0 Then
                Dim tablavehiculo As New PdfPTable(4)
                tablavehiculo.SetWidths(New Single() {20.0F, 30.0F, 20.0F, 30.0F})
                'DATOS VEHÍCULO
                Dim tituloconA1 As New PdfPCell(New Phrase("Marca", fontcabeceradetallenegrita))
                tituloconA1.Border = 0
                tituloconA1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconA1)
                Dim tituloconA2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("MARCA").ToString(), fontcabeceradetalle))
                tituloconA2.Border = 0
                tituloconA2.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconA2)
                Dim tituloconA3 As New PdfPCell(New Phrase("Modelo", fontcabeceradetallenegrita))
                tituloconA3.Border = 0
                tituloconA3.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconA3)
                Dim tituloconA4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("MODELO").ToString(), fontcabeceradetalle))
                tituloconA4.Border = 0
                tituloconA4.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconA4)
                Dim tituloconB1 As New PdfPCell(New Phrase("Tipo", fontcabeceradetallenegrita))
                tituloconB1.Border = 0
                tituloconB1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconB1)
                Dim tituloconB2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("TIPO").ToString(), fontcabeceradetalle))
                tituloconB2.Border = 0
                tituloconB2.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconB2)
                Dim tituloconB3 As New PdfPCell(New Phrase("Color", fontcabeceradetallenegrita))
                tituloconB3.Border = 0
                tituloconB3.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconB3)
                Dim tituloconB4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("COLOR").ToString(), fontcabeceradetalle))
                tituloconB4.Border = 0
                tituloconB4.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconB4)
                Dim tituloconC1 As New PdfPCell(New Phrase("Motor", fontcabeceradetallenegrita))
                tituloconC1.Border = 0
                tituloconC1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconC1)
                Dim tituloconC2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("MOTOR").ToString(), fontcabeceradetalle))
                tituloconC2.Border = 0
                tituloconC2.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconC2)
                Dim tituloconC3 As New PdfPCell(New Phrase("AÑO", fontcabeceradetallenegrita))
                tituloconC3.Border = 0
                tituloconC3.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconC3)
                Dim tituloconC4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("ANIO").ToString(), fontcabeceradetalle))
                tituloconC4.Border = 0
                tituloconC4.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconC4)
                Dim tituloconD1 As New PdfPCell(New Phrase("Chasis", fontcabeceradetallenegrita))
                tituloconD1.Border = 0
                tituloconD1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconD1)
                Dim tituloconD2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("CHASIS").ToString(), fontcabeceradetalle))
                tituloconD2.Border = 0
                tituloconD2.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconD2)
                Dim tituloconD3 As New PdfPCell(New Phrase("Placa", fontcabeceradetallenegrita))
                tituloconD3.Border = 0
                tituloconD3.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconD3)
                Dim tituloconD4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("PLACA").ToString(), fontcabeceradetalle))
                tituloconD4.Border = 0
                tituloconD4.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculo.AddCell(tituloconD4)
                documento.Add(tablavehiculo)

                Dim tablavehiculovalores As New PdfPTable(1)
                tablavehiculovalores.SetWidths(New Single() {100.0F})
                Dim tituloconE1 As New PdfPCell(New Phrase())
                tituloconE1.Phrase.Add(New Chunk("3. Destino del vehículo: ", fontcabeceradetalle))
                tituloconE1.Phrase.Add(New Chunk("Particular( ", fontcabeceradetalle))
                tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("TIPO_USO").ToString() & ")     ", fontcabeceradetalle))
                tituloconE1.Phrase.Add(New Chunk("Comercial(", fontcabeceradetalle))
                tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("USO").ToString() & ")", fontcabeceradetalle))
                tituloconE1.Border = 0
                tituloconE1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(titulocon2)
                tablavehiculovalores.AddCell(tituloconE1)
                tablavehiculovalores.AddCell(titulocon2)

                Dim tituloconG1 As New PdfPCell(New Phrase())
                tituloconG1.Phrase.Add(New Chunk("4. Clave asignada: ", fontcabeceradetalle))
                tituloconG1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("CLIENTE").ToString(), fontcabeceradetalle))
                tituloconG1.Border = 0
                tituloconG1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconG1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconH1 As New PdfPCell(New Phrase("5. Precio: ", fontcabeceradetalle))
                tituloconH1.Border = 0
                tituloconH1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconH1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconI1 As New PdfPCell(New Phrase())
                tituloconI1.Phrase.Add(New Chunk("Dispositivo HUNTER más un año de servicio de rastreo:  $", fontcabeceradetalle))
                tituloconI1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("MAS_DE_ANIO").ToString(), fontcabeceradetalle))
                tituloconI1.Border = 0
                tituloconI1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconI1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconJ1 As New PdfPCell(New Phrase())
                tituloconJ1.Phrase.Add(New Chunk("Dispositivo HUNTER:  $", fontcabeceradetalle))
                tituloconJ1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("VALOR_DISPOSITIVO").ToString(), fontcabeceradetalle))
                tituloconJ1.Phrase.Add(New Chunk(" Costo mensual del servicio de rastreo: $", fontcabeceradetalle))
                tituloconJ1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("COSTO_SERVICIO").ToString(), fontcabeceradetalle))
                tituloconJ1.Border = 0
                tituloconJ1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconJ1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconK1 As New PdfPCell(New Phrase("6. Forma de pago: ", fontcabeceradetalle))
                tituloconK1.Border = 0
                tituloconK1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconK1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconL1 As New PdfPCell(New Phrase("Efectivo (___)  Débito Cuenta Corriente o Ahorros (___)  Débito Tarjeta de Crédito (___)", fontcabeceradetalle))
                tituloconL1.Border = 0
                tituloconL1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconL1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconM1 As New PdfPCell(New Phrase())
                tituloconM1.Phrase.Add(New Chunk("7. Plazo del contrato: ", fontcabeceradetalle))
                tituloconM1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("PLAZO").ToString(), fontcabeceradetalle))
                tituloconM1.Border = 0
                tituloconM1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconM1)
                tablavehiculovalores.AddCell(titulocon2)
                Dim tituloconN1 As New PdfPCell(New Phrase())
                tituloconN1.Phrase.Add(New Chunk("8. Precio de la primera renovación anual del servicio de rastreo:  $", fontcabeceradetalle))
                tituloconN1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("PRIMER_ANIO").ToString(), fontcabeceradetalle))
                tituloconN1.Border = 0
                tituloconN1.HorizontalAlignment = Element.ALIGN_LEFT
                tablavehiculovalores.AddCell(tituloconN1)
                tablavehiculovalores.AddCell(titulocon2)

                documento.Add(tablavehiculovalores)
            End If

            Dim tablafechas As New PdfPTable(1)
            tablafechas.SetWidths(New Single() {100.0F})
            Dim titulocon42 As New PdfPCell(New Phrase())
            titulocon42.Phrase.Add(New Chunk("Cualquier divergencia motivada por la aplicación de este contrato, será tratada por uno de los jueces de Guayaquil y por la vía verbal sumaria.  Para constancia y aceptación de todo lo anterior, se suscribe este contrato en dos ejemplares de igual tenor y valor en ", fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("CIUDAD").ToString(), fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(", a los ", fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("DIA_FECHA").ToString(), fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(" días, del mes de ", fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("MES_FECHA").ToString(), fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(" del ", fontcabeceradetalle))
            titulocon42.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("ANIO_FECHA").ToString(), fontcabeceradetalle))
            titulocon42.Border = 0
            titulocon42.HorizontalAlignment = Element.ALIGN_LEFT
            tablafechas.AddCell(titulocon42)
            tablafechas.AddCell(titulocon2)
            documento.Add(tablafechas)

            Dim tablafirmas As New PdfPTable(2)
            tablafirmas.SetWidths(New Single() {50.0F, 50.0F})
            Dim titulocon431 As New PdfPCell(New Phrase("p. CARRO SEGURO CARSEG ", fontcabeceradetalle))
            titulocon431.Border = 0
            titulocon431.FixedHeight = 50.0F
            titulocon431.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon431)
            Dim titulocon432 As New PdfPCell(New Phrase("EL CLIENTE", fontcabeceradetalle))
            titulocon432.Border = 0
            titulocon432.FixedHeight = 50.0F
            titulocon432.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon432)
            Dim titulocon441 As New PdfPCell(New Phrase("___________________________", fontcabeceradetalle))
            titulocon441.Border = 0
            titulocon441.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon441)
            Dim titulocon442 As New PdfPCell(New Phrase("___________________________", fontcabeceradetalle))
            titulocon442.Border = 0
            titulocon442.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon442)
            Dim titulocon451 As New PdfPCell(New Phrase("Firma Autorizada", fontcabeceradetalle))
            titulocon451.Border = 0
            titulocon451.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon451)
            Dim titulocon452 As New PdfPCell(New Phrase(cliente, fontcabeceradetalle))
            titulocon452.Border = 0
            titulocon452.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon452)
            Dim titulocon461 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
            titulocon461.Border = 0
            titulocon461.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon461)
            Dim titulocon462 As New PdfPCell(New Phrase())
            titulocon462.Phrase.Add(New Chunk("C.I. ", fontcabeceradetalle))
            titulocon462.Phrase.Add(New Chunk(idcliente, fontcabeceradetalle))
            titulocon462.Border = 0
            titulocon462.HorizontalAlignment = Element.ALIGN_CENTER
            tablafirmas.AddCell(titulocon462)
            documento.Add(tablafirmas)

            Dim tablaacepto As New PdfPTable(1)
            tablaacepto.SetWidths(New Single() {100.0F})
            Dim titulocon47 As New PdfPCell(New Phrase("Declaro de manera expresa que he leído todas y cada unas de las cláusulas que anteceden y me encuentro en completo acuerdo con las mismas.", fontcabeceradetalle))
            titulocon47.Border = 0
            titulocon47.HorizontalAlignment = Element.ALIGN_LEFT
            tablaacepto.AddCell(titulocon2)
            tablaacepto.AddCell(titulocon2)
            tablaacepto.AddCell(titulocon2)
            tablaacepto.AddCell(titulocon47)
            tablaacepto.AddCell(titulocon2)
            tablaacepto.AddCell(titulocon2)
            Dim titulocon48 As New PdfPCell(New Phrase("f)________________________", fontcabeceradetalle))
            titulocon48.Border = 0
            titulocon48.HorizontalAlignment = Element.ALIGN_LEFT
            tablaacepto.AddCell(titulocon48)
            Dim titulocon49 As New PdfPCell(New Phrase(cliente, fontcabeceradetalle))
            titulocon49.Border = 0
            titulocon49.HorizontalAlignment = Element.ALIGN_LEFT
            tablaacepto.AddCell(titulocon49)
            Dim titulocon50 As New PdfPCell(New Phrase())
            titulocon50.Phrase.Add(New Chunk("C.I. ", fontcabeceradetalle))
            titulocon50.Phrase.Add(New Chunk(idcliente, fontcabeceradetalle))
            titulocon50.Border = 0
            titulocon50.HorizontalAlignment = Element.ALIGN_LEFT
            tablaacepto.AddCell(titulocon50)

            documento.Add(tablaacepto)
            documento.Close()
            retorno = nombreFile
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function


    Public Function GenerarDocumentoDA(ByVal orden As String, vehiculos As String) As String
        Dim retorno As String = ""
        Try
            Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 11, Font.BOLD, BaseColor.BLACK)
            Dim fontcabeceradetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)
            Dim fontcabeceradetallenegrita As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)
            Dim documento As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 50.0F)
            Dim nombreFile As String = "ContratoDA_" & orden & "_" & Date.Now.ToString("yyyyMMdd") & "_" & Date.Now.ToString("HHmmss") & ".pdf"
            Dim file As String = String.Format("{0}{1}", ConsultaRuta(), nombreFile)

            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim paragraph As New iTextSharp.text.Paragraph(" ")
            Dim ev As New CreacionPdf()

            documento.Open()
            documento.NewPage()
            writer.PageEvent = ev
            documento.Add(paragraph)

            Dim dtParametros As New System.Data.DataSet
            dtParametros = DocumentosAdapter.ConsultaDatosDocDA("109", orden, vehiculos)

            'DATOS DE LA CABECERA
            Dim tablacontrato As New PdfPTable(1)
            tablacontrato.SetWidths(New Single() {100.0F})
            'TITULO DEL DOCUMENTO
            Dim titulocon1 As New PdfPCell(New Phrase("AUTORIZACIÓN DÉBITO BANCARIO", fontcabecera))
            titulocon1.Border = 0
            titulocon1.HorizontalAlignment = Element.ALIGN_CENTER
            tablacontrato.AddCell(titulocon1)
            'LINEA EN BLANCO
            Dim titulocon2 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
            titulocon2.Border = 0
            titulocon2.HorizontalAlignment = Element.ALIGN_CENTER
            tablacontrato.AddCell(titulocon2)
            tablacontrato.AddCell(titulocon2)
            Dim titulocon3 As New PdfPCell(New Phrase("DATOS DEL CLIENTE", fontcabecera))
            titulocon3.Border = 0
            titulocon3.HorizontalAlignment = Element.ALIGN_CENTER
            tablacontrato.AddCell(titulocon3)
            documento.Add(tablacontrato)

            Dim tablacliente As New PdfPTable(4)
            tablacliente.SetWidths(New Single() {15.0F, 35.0F, 15.0F, 35.0F})
            'DATOS CLIENTE
            Dim tituloconA1 As New PdfPCell(New Phrase("Fecha", fontcabeceradetallenegrita))
            tituloconA1.Border = 0
            tituloconA1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconA1)
            Dim tituloconA2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("FECHA").ToString(), fontcabeceradetalle))
            tituloconA2.Border = 0
            tituloconA2.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconA2)
            Dim tituloconA3 As New PdfPCell(New Phrase("Ciudad", fontcabeceradetallenegrita))
            tituloconA3.Border = 0
            tituloconA3.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconA3)
            Dim tituloconA4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("CIUDAD").ToString(), fontcabeceradetalle))
            tituloconA4.Border = 0
            tituloconA4.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconA4)
            Dim tituloconB1 As New PdfPCell(New Phrase("Nombres", fontcabeceradetallenegrita))
            tituloconB1.Border = 0
            tituloconB1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconB1)
            Dim tituloconB2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("NOMBRES").ToString(), fontcabeceradetalle))
            tituloconB2.Border = 0
            tituloconB2.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconB2)
            Dim tituloconB3 As New PdfPCell(New Phrase("Apellidos", fontcabeceradetallenegrita))
            tituloconB3.Border = 0
            tituloconB3.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconB3)
            Dim tituloconB4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("APELLIDOS").ToString(), fontcabeceradetalle))
            tituloconB4.Border = 0
            tituloconB4.HorizontalAlignment = Element.ALIGN_LEFT
            tablacliente.AddCell(tituloconB4)
            documento.Add(tablacliente)

            'TITULO 2
            Dim tablatitulo2 As New PdfPTable(1)
            tablatitulo2.SetWidths(New Single() {100.0F})
            'TITULO 2
            Dim titulocon4 As New PdfPCell(New Phrase("DATOS DEL VEHÍCULO", fontcabecera))
            titulocon4.Border = 0
            titulocon4.HorizontalAlignment = Element.ALIGN_CENTER
            tablatitulo2.AddCell(titulocon2)
            tablatitulo2.AddCell(titulocon4)
            Dim titulocon5 As New PdfPCell(New Phrase())
            titulocon5.Phrase.Add(New Chunk("Concesionario   ", fontcabeceradetalle))
            titulocon5.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("CONCESIONARIO").ToString(), fontcabeceradetallenegrita))
            titulocon5.Border = 0
            titulocon5.HorizontalAlignment = Element.ALIGN_LEFT
            tablatitulo2.AddCell(titulocon5)
            documento.Add(tablatitulo2)

            Dim tablavehiculo As New PdfPTable(4)
            tablavehiculo.SetWidths(New Single() {15.0F, 35.0F, 15.0F, 35.0F})
            'DATOS CLIENTE
            'DATOS VEHICULO
            Dim titulovehA1 As New PdfPCell(New Phrase("Marca", fontcabeceradetallenegrita))
            titulovehA1.Border = 0
            titulovehA1.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehA1)
            Dim titulovehA2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("MARCA").ToString(), fontcabeceradetalle))
            titulovehA2.Border = 0
            titulovehA2.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehA2)
            Dim titulovehA3 As New PdfPCell(New Phrase("Modelo", fontcabeceradetallenegrita))
            titulovehA3.Border = 0
            titulovehA3.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehA3)
            Dim titulovehA4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("MODELO").ToString(), fontcabeceradetalle))
            titulovehA4.Border = 0
            titulovehA4.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehA4)
            Dim titulovehA5 As New PdfPCell(New Phrase("Tipo", fontcabeceradetallenegrita))
            titulovehA5.Border = 0
            titulovehA5.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehA5)
            Dim titulovehA6 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("TIPO").ToString(), fontcabeceradetalle))
            titulovehA6.Border = 0
            titulovehA6.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehA6)
            Dim titulovehB1 As New PdfPCell(New Phrase("Color", fontcabeceradetallenegrita))
            titulovehB1.Border = 0
            titulovehB1.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehB1)
            Dim titulovehB2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("COLOR").ToString(), fontcabeceradetalle))
            titulovehB2.Border = 0
            titulovehB2.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehB2)
            Dim titulovehB3 As New PdfPCell(New Phrase("Año", fontcabeceradetallenegrita))
            titulovehB3.Border = 0
            titulovehB3.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehB3)
            Dim titulovehB4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("ANIO").ToString(), fontcabeceradetalle))
            titulovehB4.Border = 0
            titulovehB4.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehB4)
            Dim titulovehB5 As New PdfPCell(New Phrase("Placa", fontcabeceradetallenegrita))
            titulovehB5.Border = 0
            titulovehB5.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehB5)
            Dim titulovehB6 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("PLACA").ToString(), fontcabeceradetalle))
            titulovehB6.Border = 0
            titulovehB6.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehB6)
            Dim titulovehC1 As New PdfPCell(New Phrase("Motor", fontcabeceradetallenegrita))
            titulovehC1.Border = 0
            titulovehC1.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehC1)
            Dim titulovehC2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("MOTOR").ToString(), fontcabeceradetalle))
            titulovehC2.Border = 0
            titulovehC2.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehC2)
            Dim titulovehC3 As New PdfPCell(New Phrase("Chasis", fontcabeceradetallenegrita))
            titulovehC3.Border = 0
            titulovehC3.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehC3)
            Dim titulovehC4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("CHASIS").ToString(), fontcabeceradetalle))
            titulovehC4.Border = 0
            titulovehC4.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehC4)
            Dim titulovehC5 As New PdfPCell(New Phrase(" ", fontcabeceradetallenegrita))
            titulovehC5.Border = 0
            titulovehC5.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehC5)
            Dim titulovehC6 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
            titulovehC6.Border = 0
            titulovehC6.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehC6)
            Dim titulovehD1 As New PdfPCell(New Phrase("O/S", fontcabeceradetallenegrita))
            titulovehD1.Border = 0
            titulovehD1.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehD1)
            Dim titulovehD2 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("ORDEN_SERVICIO").ToString(), fontcabeceradetalle))
            titulovehD2.Border = 0
            titulovehD2.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehD2)
            Dim titulovehD3 As New PdfPCell(New Phrase("Cod. Veh.", fontcabeceradetallenegrita))
            titulovehD3.Border = 0
            titulovehD3.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehD3)
            Dim titulovehD4 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("CODIGO").ToString(), fontcabeceradetalle))
            titulovehD4.Border = 0
            titulovehD4.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehD4)
            Dim titulovehD5 As New PdfPCell(New Phrase(" ", fontcabeceradetallenegrita))
            titulovehD5.Border = 0
            titulovehD5.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehD5)
            Dim titulovehD6 As New PdfPCell(New Phrase(" ", fontcabeceradetalle))
            titulovehD6.Border = 0
            titulovehD6.HorizontalAlignment = Element.ALIGN_LEFT
            tablavehiculo.AddCell(titulovehD6)
            documento.Add(tablavehiculo)


            Dim tablacuerpo As New PdfPTable(1)
            tablacuerpo.SetWidths(New Single() {100.0F})
            Dim tituloconE1 As New PdfPCell(New Phrase())
            tituloconE1.Phrase.Add(New Chunk("Autorizo libre y voluntariamente al ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("EMISOR").ToString(), fontcabeceradetallenegrita))
            tituloconE1.Phrase.Add(New Chunk(", debitar de la ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("TIPO_CUENTA").ToString(), fontcabeceradetallenegrita))
            tituloconE1.Phrase.Add(New Chunk(" No ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("TARJETA_DA").ToString(), fontcabeceradetallenegrita))
            tituloconE1.Phrase.Add(New Chunk(" a nombre de  ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("NOMBRES").ToString(), fontcabeceradetallenegrita))
            tituloconE1.Phrase.Add(New Chunk(" ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("APELLIDOS").ToString(), fontcabeceradetallenegrita))
            tituloconE1.Phrase.Add(New Chunk(" de manera mensual  el valor de  ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("VALOR").ToString(), fontcabeceradetallenegrita))
            tituloconE1.Phrase.Add(New Chunk(", incluido IVA, por concepto del servicio de forma indefinida, hasta que el cliente realice la suspensión del mismo con 15 días de anticipación.", fontcabeceradetalle))
            tituloconE1.Border = 0
            tituloconE1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(titulocon2)
            tablacuerpo.AddCell(tituloconE1)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconF1 As New PdfPCell(New Phrase("Como cliente de CARSEG S.A. me comprometo a mantener en mi cuenta corriente o de ahorros el monto correspondiente al consumo realizado, para poder gozar de los servicios prestados.", fontcabeceradetalle))
            tituloconF1.Border = 0
            tituloconF1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconF1)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconG1 As New PdfPCell(New Phrase())
            tituloconE1.Phrase.Add(New Chunk("Cualquier instrucción para que se invalide esta autorización la presentaré por escrito con 30 días de anticipación al Banco y CARSEG S.A. siempre y cuando mantenga mi cuenta y mis pagos al día, .por lo que libero de toda responsabilidad al ", fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("EMISOR").ToString(), fontcabeceradetalle))
            tituloconE1.Phrase.Add(New Chunk(" por los cargos efectuados en base a la presente autorización.", fontcabeceradetalle))
            tituloconG1.Border = 0
            tituloconG1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconG1)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconH1 As New PdfPCell(New Phrase("Adicionalmente autorizamos a CARSEG S.A. para que obtenga de cualquier fuente de información, incluida la Central de Riesgo, sus referencias e información personal(es) sobre mi (nuestro) comportamiento crediticio, manejo de mi(nuestras) cuenta(s), corriente(s), de ahorro, tarjeta(s) de crédito, etc., y en general sobre el cumplimiento de mi(nuestras) obligaciones y demás activos, pasivos y datos personales.  De igual forma CARSEG S.A. queda expresamente autorizado para que pueda utilizar, transferir o entregar dicha información a autoridades competentes, organismos de control, Burós de Información Crediticia y otras instituciones o personas jurídicas, legal o reglamentariamente facultadas, así como para que pueda hacer público mi(nuestro) comportamiento crediticio.", fontcabeceradetalle))
            tituloconH1.Border = 0
            tituloconH1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconH1)
            tablacuerpo.AddCell(titulocon2)
            tablacuerpo.AddCell(titulocon2)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconI1 As New PdfPCell(New Phrase("Atentamente,", fontcabeceradetalle))
            tituloconI1.Border = 0
            tituloconI1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconI1)
            tablacuerpo.AddCell(titulocon2)
            tablacuerpo.AddCell(titulocon2)
            tablacuerpo.AddCell(titulocon2)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconJ1 As New PdfPCell(New Phrase("________________________", fontcabeceradetalle))
            tituloconJ1.Border = 0
            tituloconJ1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconJ1)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconK1 As New PdfPCell(New Phrase())
            tituloconK1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("NOMBRES").ToString(), fontcabeceradetallenegrita))
            tituloconK1.Phrase.Add(New Chunk(" ", fontcabeceradetalle))
            tituloconK1.Phrase.Add(New Chunk(dtParametros.Tables(0).Rows(0)("APELLIDOS").ToString(), fontcabeceradetallenegrita))
            tituloconK1.Border = 0
            tituloconK1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconK1)
            tablacuerpo.AddCell(titulocon2)
            Dim tituloconM1 As New PdfPCell(New Phrase(dtParametros.Tables(0).Rows(0)("CLIENTE").ToString(), fontcabeceradetallenegrita))
            tituloconM1.Border = 0
            tituloconM1.HorizontalAlignment = Element.ALIGN_LEFT
            tablacuerpo.AddCell(tituloconM1)
            tablacuerpo.AddCell(titulocon2)

            documento.Add(tablacuerpo)
            documento.Close()
            retorno = nombreFile
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function


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

End Class
