Imports System.Security.Cryptography
Imports DevExpress.Utils
'Imports Microsoft.Office.Interop.Excel
Imports Org.BouncyCastle.Ocsp
Imports Org.BouncyCastle.X509
Imports Telerik.Web.UI.PivotGrid.Core
Imports Telerik.Web.UI.Scheduler.Views

Public Class RenovacionPago
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                metodos_master("Renovación de Servicios", 3, "Renovacion proceso de pago")
                mensajeria_error("", "")
                carro_compra()
                resumen_compra()
                If VposAnterior(Session("IdTarjetaVpos")) = "DN" Then
                    divp2p.Visible = True
                Else
                    divp2p.Visible = False
                End If
                If Session("Administrador") = "ADM" Or Session("Administrador") = "APV" Or Session("Administrador") = "USR" Then
                    btnlink.Visible = True
                End If
                btnpagar.Visible = True
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btnpagar_Click(sender As Object, e As System.EventArgs) Handles btnpagar.Click
        If validaciones_pago() Then
            Try
                genera_orden_web()
                If (VposAnterior(Session("IdTarjetaVpos")) = "MC" Or VposAnterior(Session("IdTarjetaVpos")) = "VI" _
                Or VposAnterior(Session("IdTarjetaVpos")) = "PC") Then 'And Session("IdTipoPagoVpos") <> 3
                    Response.Redirect("cotizadorweburltecnicopaymentez.aspx", False)
                ElseIf (VposAnterior(Session("IdTarjetaVpos")) = "DN" Or VposAnterior(Session("IdTarjetaVpos")) = "DI" _
                Or VposAnterior(Session("IdTarjetaVpos")) = "AM" Or VposAnterior(Session("IdTarjetaVpos")) = "TI" _
                Or VposAnterior(Session("IdTarjetaVpos")) = "PI") Then 'And Session("IdTipoPagoVpos") <> 3
                    Response.Redirect("cotizadorweburltecnico.aspx", False)
                End If
            Catch ex As Exception
                ExceptionHandler.Captura_Error(ex)
            End Try
        End If
    End Sub

    Private Sub btnlink_Click(sender As Object, e As EventArgs) Handles btnlink.Click
        genera_orden_web()
        Dim encryptedValue As String = Encriptar(Session("OrdenID"))
        Dim url As String = "https://www.hunteronline.com.ec/extranet/ventas/pagoproceso.aspx?ow=" & HttpUtility.UrlEncode(encryptedValue)
        encryptedValue = Encriptar(Session("IdTipoPagoVpos"))
        url += "&tp=" & HttpUtility.UrlEncode(encryptedValue)

        txtlinkpago.Text = url
        txtlinkpago.Visible = True
        btnpagar.Enabled = False
        btnlink.Enabled = False
        Dim objmail As New MailTrabajos
        'objmail.EnvioEmailLinkPago(Session("OrdenID"), url)
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub numero_orden()
        lblnumeroorden.Text = OrdenPagoAdapter.ConsultaSecuenciaOrdenPago()
    End Sub

    Private Sub carro_compra()
        Dim table As New System.Data.DataTable
        Dim valueCantidadRenovar As Integer = 0
        Dim valueCellPrecioUnitario As Decimal = 0
        Dim valueCellPrecioPromocion As Decimal = 0
        Dim valueCellPrecioSubtotal As Decimal = 0
        Dim valueCellPrecioIva As Decimal = 0
        Dim valueCellPrecioCliente As Decimal = 0
        table = CType(Session("tblrenovaciones"), DataTable)
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                valueCantidadRenovar += 1
                valueCellPrecioUnitario += table.Rows(i)("PRECIO_VENTA")
                valueCellPrecioPromocion += table.Rows(i)("VALOR_PROMOCION")
                valueCellPrecioSubtotal += table.Rows(i)("PRECIO_TOTAL")
                valueCellPrecioIva += table.Rows(i)("IVA")
                valueCellPrecioCliente += table.Rows(i)("PRECIO_CLIENTE")
            Next
            carro_compras(valueCellPrecioCliente, valueCantidadRenovar)
            lblresumencantidad.Text = valueCantidadRenovar
            lblresumentotal.Text = Format(valueCellPrecioUnitario, "N2")
            lblresumenpromocion.Text = Format(valueCellPrecioPromocion, "N2")
            lblresumensubtotal.Text = Format(valueCellPrecioSubtotal, "N2")
            lblresumeniva.Text = Format(valueCellPrecioIva, "N2")
            lblresumenpreciocliente.Text = Format(valueCellPrecioCliente, "N2")
        End If
    End Sub

    Private Sub resumen_compra()
        Dim table As New System.Data.DataTable
        Dim i As Integer = 0
        table = CType(Session("tblrenovaciones"), DataTable)
        Dim vistatbl As DataView = New DataView(table)
        Dim distinctValues As DataTable = vistatbl.ToTable(True, "VEHICULO_NOMBRE", "VEHICULO")
        Me.Rpt_resumen_renovacion.DataSource = distinctValues
        Me.Rpt_resumen_renovacion.DataBind()
        For Each item As RepeaterItem In Rpt_resumen_renovacion.Items
            Dim rptitm As Repeater = CType(item.FindControl("Rpt_resumen_renovacion_itm"), Repeater)
            Dim tblitm As New System.Data.DataTable
            tblitm = table.Clone()
            table.Select("VEHICULO=" & distinctValues.Rows(i).Item("VEHICULO")).CopyToDataTable(tblitm, LoadOption.OverwriteChanges)
            rptitm.DataSource = tblitm
            rptitm.DataBind()
            i += 1
        Next
    End Sub

    Private Function validaciones_pago() As Boolean
        Dim retorno As Boolean = True
        Dim tablefac As New System.Data.DataTable
        Dim myMasterPage As master = CType(Page.Master, master)
        tablefac = CType(Session("tblfacturacion"), DataTable)

        If Session("IdTarjetaVpos") = "" Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo una tarjeta.")
        ElseIf Session("IdTipoPagoVpos") = "" Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo un tipo de pago.")
        ElseIf Libreria.Parse(myMasterPage.cantidadMaster) = 0 Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo un servicio.")
        ElseIf Libreria.Parse(lblresumencantidad.Text) = 0 Then
            retorno = False
            mensajeria_error("error", "para continuar usted debe seleccionar mínimo un servicio.")
        ElseIf secuencial_emisor(Session("IdTarjetaVpos")) = "" Then
            retorno = False
            mensajeria_error("error", "no se pudo obtener datos de tarjeta.")
        ElseIf tablefac.Rows.Count = 0 Then
            retorno = False
            mensajeria_error("error", "por favor completar datos de facturación.")
        End If

        Return retorno
    End Function

    Private Sub genera_orden_web()
        Try
            Dim ordenEntity As New OrdenEntity
            Dim ordenDetalleEntity As OrdenDetalleEntity
            Dim ordenDetalleEntityCollection As New OrdenDetalleEntityCollection
            Dim datosVpos As String = secuencial_emisor(Session("IdTarjetaVpos"))
            Dim idemisor As String = datosVpos.Substring(2, 3)
            Dim secuencialemisor As Integer = Session("bancoseleccionado") ' datosVpos.Substring(2, 3)
            Dim secuencialsh As String = "000"
            Dim origen As String = "REN" 'IIf(Session("IdTipoPagoVpos") = 3, "DEB", "REN")
            Dim valueFormaPagoNomb As String = ""
            Dim valueFormaPagoIdnt As String = ""
            Dim valueFormaPagoDirc As String = ""
            Dim valueFormaPagoTelf As String = ""
            Dim valueFormaPagoCell As String = ""
            Dim valueFormaPagoEmail As String = ""

            Dim tablefac As New System.Data.DataTable
            tablefac = CType(Session("tblfacturacion"), DataTable)
            If tablefac.Rows.Count > 0 Then
                For i As Integer = 0 To tablefac.Rows.Count - 1
                    valueFormaPagoNomb = tablefac.Rows(i)("FormaPagoNombre")
                    valueFormaPagoIdnt = tablefac.Rows(i)("FormaPagoIdentificacion")
                    valueFormaPagoDirc = tablefac.Rows(i)("FormaPagoDireccion")
                    valueFormaPagoTelf = tablefac.Rows(i)("FormaPagoTelefono")
                    valueFormaPagoCell = tablefac.Rows(i)("FormaPagoCelular")
                    valueFormaPagoEmail = tablefac.Rows(i)("FormaPagoEmail")
                Next
            End If
            If Session("IdTarjetaVpos") = "PC" Then
                Session("Pacificard") = "1"
            Else
                Session("Pacificard") = "0"
            End If
            ordenEntity.OrdenId = 0
            ordenEntity.ClienteId = Session("user_id")
            ordenEntity.NumeroMeses = 1
            ordenEntity.TipoTarjeta = VposAnterior(Session("IdTarjetaVpos"))
            ordenEntity.SubTotal = lblresumensubtotal.Text
            ordenEntity.Iva = lblresumeniva.Text
            ordenEntity.Ice = 0
            ordenEntity.Interes = 0
            ordenEntity.Total = Libreria.Parse(lblresumenpreciocliente.Text)
            ordenEntity.TipoPago = 0
            ordenEntity.TipoCredito = "00"
            ordenEntity.CodigoConfPago = 0
            ordenEntity.BillingName = valueFormaPagoNomb
            ordenEntity.BillingCedula = valueFormaPagoIdnt
            ordenEntity.BillingAddress = valueFormaPagoDirc
            ordenEntity.BillingPhone = valueFormaPagoTelf
            ordenEntity.BillingMovil = valueFormaPagoCell
            ordenEntity.BillingEmail = valueFormaPagoEmail
            ordenEntity.BillingCardType = 0
            ordenEntity.EstadoWebId = 1
            ordenEntity.UsuarioProcesoId = 0
            ordenEntity.AccionComercial = origen
            ordenEntity.UsuarioSoporte = IIf(Session("Administrador") = "ADM", Session("usuario"), "CLIENTE")
            OrdenPagoAdapter.ConfirmoPagoOnline(ordenEntity)
            ordenEntity = New OrdenEntity
            numero_orden()
            Dim ordenId As String = lblnumeroorden.Text
            ordenEntity.OrdenId = ordenId
            ordenEntity.ClienteId = Session("user_id")
            ordenEntity.idemisor = secuencialemisor
            ordenEntity.NumeroMeses = 1
            ordenEntity.TipoTarjeta = VposAnterior(Session("IdTarjetaVpos"))
            ordenEntity.SubTotal = lblresumensubtotal.Text
            ordenEntity.Iva = lblresumeniva.Text
            ordenEntity.Ice = 0
            ordenEntity.Interes = 0
            ordenEntity.Total = Libreria.Parse(lblresumenpreciocliente.Text)
            ordenEntity.TipoPago = 0
            ordenEntity.TipoCredito = "00"
            ordenEntity.CodigoConfPago = 0
            ordenEntity.BillingName = valueFormaPagoNomb
            ordenEntity.BillingCedula = valueFormaPagoIdnt
            ordenEntity.BillingAddress = valueFormaPagoDirc
            ordenEntity.BillingPhone = valueFormaPagoTelf
            ordenEntity.BillingMovil = valueFormaPagoCell
            ordenEntity.BillingEmail = valueFormaPagoEmail
            ordenEntity.BillingCardType = 0
            ordenEntity.EstadoWebId = 1
            ordenEntity.UsuarioProcesoId = 0
            ordenEntity.AccionComercial = origen
            ordenEntity.UsuarioSoporte = IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE")
            Dim table As New System.Data.DataTable
            table = CType(Session("tblrenovaciones"), DataTable)
            For i As Integer = 0 To table.Rows.Count - 1
                ordenDetalleEntity = New OrdenDetalleEntity
                ordenDetalleEntity.OrdenDetalleId = 0
                ordenDetalleEntity.OrdenId = ordenEntity.OrdenId
                ordenDetalleEntity.VehiculoId = table.Rows(i).Item("VEHICULO")
                ordenDetalleEntity.TransaccionId = table.Rows(i).Item("PRODUCTO")
                ordenDetalleEntity.FechaVencimiento = table.Rows(i).Item("FECHAFIN")
                ordenDetalleEntity.Anios = table.Rows(i).Item("ANIO")
                ordenDetalleEntity.ValorAnual = table.Rows(i).Item("PRECIO_VENTA")
                ordenDetalleEntity.CodigoPromocion = "000" 'IIf(Session("IdTipoPagoVpos") = 3, table.Rows(i).Item("CODIGO_PROMOCION"), "000")
                ordenDetalleEntity.ValorPromocion = table.Rows(i).Item("VALOR_PROMOCION")
                ordenDetalleEntity.PorcentajeDescuento = 0
                ordenDetalleEntity.Descuento = 0
                ordenDetalleEntity.SubTotal = table.Rows(i).Item("PRECIO_TOTAL")
                ordenDetalleEntity.Iva = table.Rows(i).Item("IVA")
                ordenDetalleEntity.Total = table.Rows(i).Item("PRECIO_CLIENTE")
                ordenDetalleEntity.MarcadoLojack = "NO"
                ordenDetalleEntity.UsuarioProcesoId = 0
                ordenDetalleEntity.Producto_Debito = "" 'table.Rows(i).Item("PRODUCTODA")
                ordenDetalleEntity.Fecha_Ini_Debito = "" 'table.Rows(i).Item("FECHAINIDA")
                ordenDetalleEntity.Fecha_Fin_Debito = "" 'table.Rows(i).Item("FECHAFINDA")
                ordenDetalleEntity.EsDebito = "N" 'IIf(Session("IdTipoPagoVpos") = 3, "S", "N")
                ordenDetalleEntity.Item = table.Rows(i).Item("IDITEM")
                ordenDetalleEntity.Ejecutiva = table.Rows(i).Item("IDEJECUTIVO")
                ordenDetalleEntityCollection.Add(ordenDetalleEntity)
            Next
            ordenEntity.OrdenDetalleEntityCollection = ordenDetalleEntityCollection
            Session("OrdenID") = ordenEntity.OrdenId
            lblnumeroorden.Text = ordenEntity.OrdenId

            OrdenPagoAdapter.RegistroPagoOnline(ordenEntity)
            Dim dTGetInfoUrlTecnico As New DataTable()
            dTGetInfoUrlTecnico.Columns.Add("datatecnica", GetType(String))
            dTGetInfoUrlTecnico.Rows.Add(ordenEntity.OrdenId)       '0
            dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoIdnt)        '1
            dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoNomb)        '2
            dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoDirc)        '3
            dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoCell)        '4
            dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoEmail)       '5
            dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))        '6
            dTGetInfoUrlTecnico.Rows.Add(Libreria.Parse(lblresumenpreciocliente.Text))
            dTGetInfoUrlTecnico.Rows.Add(lblresumensubtotal.Text)   '8
            dTGetInfoUrlTecnico.Rows.Add(0) 'descuentos             '9
            dTGetInfoUrlTecnico.Rows.Add(0) 'IIf(Session("IdTipoPagoVpos") = 3, 1313, 0)) 'promociones
            dTGetInfoUrlTecnico.Rows.Add(lblresumeniva.Text)        '11
            dTGetInfoUrlTecnico.Rows.Add(idemisor)                  '12
            dTGetInfoUrlTecnico.Rows.Add(origen)                    '13
            dTGetInfoUrlTecnico.Rows.Add(Date.Now)                  '14
            dTGetInfoUrlTecnico.Rows.Add("00:00")                   '15
            dTGetInfoUrlTecnico.Rows.Add(0)                         '16
            dTGetInfoUrlTecnico.Rows.Add(Session("IdTipoPagoVpos")) 'IIf(Session("IdTipoPagoVpos") = 1, 0, 3))
            dTGetInfoUrlTecnico.Rows.Add("WEB")                     '18
            EMailHandler.EMailGeneracionOrdenPago("Hunter Online", "Registro de orden de pago exitoso <<inicio boton de pago>>.", Session("OrdenID"), Session("iphost"))
            Session("DTGetInfoURLTecnico") = dTGetInfoUrlTecnico

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function secuencial_emisor(id_emisor As String) As String
        Dim retorno As String = ""

        Dim dTCstEmisor As New System.Data.DataSet
        dTCstEmisor = RenovacionAdapter.ConsultaEmisorDetalleVpos(id_emisor, "NO")
        If dTCstEmisor.Tables(0).Rows.Count > 0 Then
            retorno = dTCstEmisor.Tables(0).Rows(0).Item("SECUENCIAL")
            Session("id_metodopago_ns") = dTCstEmisor.Tables(0).Rows(0).Item("RELACION_NS")
            Session("id_emisor_ns") = dTCstEmisor.Tables(0).Rows(0).Item("EMISOR_NS")
        Else
            retorno = ""
        End If

        Return retorno
    End Function

    Private Function VposAnterior(id_emisor As String) As String
        Dim retorno As String = ""

        If id_emisor = "VI" Then
            retorno = "VI"
        ElseIf id_emisor = "MC" Then
            retorno = "MC"
        ElseIf id_emisor = "DN" Then
            retorno = "DN"
        ElseIf id_emisor = "DI" Then
            retorno = "DN"
        ElseIf id_emisor = "PC" Then
            retorno = "PC"
        ElseIf id_emisor = "AM" Then
            retorno = "AM"
        ElseIf id_emisor = "TI" Then
            retorno = "PI"
        ElseIf id_emisor = "PI" Then
            retorno = "PI"
        End If

        Return retorno
    End Function

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        If tipo = "error" Then
            dvdmensajes.Attributes.Add("class", "messages error")
            dvdmensajes.Visible = True
        ElseIf tipo = "alerta" Then
            dvdmensajes.Attributes.Add("class", "messages alert")
            dvdmensajes.Visible = True
        ElseIf tipo = "informacion" Then
            dvdmensajes.Attributes.Add("class", "messages sucess")
            dvdmensajes.Visible = True
        ElseIf tipo = "" Then
            dvdmensajes.Visible = False
        End If
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub carro_compras(valor As String, cantidad As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.cantidadMaster = cantidad
        myMasterPage.totalMaster = valor
    End Sub

    Public Function Encriptar(clearText As String) As String
        Dim var_key As String = ConfigurationManager.AppSettings.Get("KeyEncr").ToString()
        Dim EncryptionKey As String = var_key
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New System.IO.MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

#End Region

#Region "Impulso manual"

    'Dim cadena_prueba As String = "{""requestId"":57294841,""status"":{""status"":""APPROVED""},""request"":{""payment"":{""reference"":""72114""}}}"
    'Dim cadena_prueba As String = "{""transaction"":{""id"":""MD-11113491"",""status"":""success"",""current_status"":""APPROVED"",""status_detail"":3,""installments"":3,""message"":""APROBADO"",""authorization_code"":""029521"",""dev_reference"":""71354"",""carrier"":""Medianet"",""product_description"":""Renovacion de productos/servcicios"",""payment_method_type"":""0""},""card"":{""bin"":""492418"",""type"":""vi"",""transaction_reference"":""MD-11113491"",""bank_name"":""Banco Bolivariano C.A""}"
    'Dim cadena_prueba As String = "{""requestId"":57502594,""status"":{""status"":""APPROVED"",""reason"":""00"",""message"":""La petici\u00f3n ha sido aprobada exitosamente"",""date"":""2025-08-04T14:56:19-05:00""},""request"":{""locale"":""es_EC"",""buyer"":{""document"":""0912223732"",""documentType"":""CI"",""email"":""mips1976@hotmail.com""},""payer"":{""document"":""0912223732"",""documentType"":""CI"",""name"":""CARLOS"",""surname"":""MU\u00d1OZ ARREAGA"",""email"":""mips1976@hotmail.com"",""mobile"":""+593990057367""},""payment"":{""reference"":""72235"",""amount"":{""taxes"":[{""kind"":""valueAddedTax"",""amount"":43.2,""base"":288}],""currency"":""USD"",""total"":331.2},""allowPartial"":false,""subscribe"":false},""fields"":[{""keyword"":""_processUrl_"",""value"":""https:\/\/checkout.placetopay.ec\/spa\/session\/57502594\/cfd5da4feab410a9d620d14e89d6a69a"",""displayOn"":""none""},{""keyword"":""_session_"",""value"":57502594,""displayOn"":""none""}],""returnUrl"":""https:\/\/www.hunteronline.com.ec\/extranetretorno\/api\/return\/JSReadReference"",""ipAddress"":""186.5.38.8"",""userAgent"":""Chrome\/138.0"",""expiration"":""2025-08-04T14:49:11-05:00""},""payment"":[{""amount"":{""to"":{""total"":331.2,""currency"":""USD""},""from"":{""total"":331.2,""currency"":""USD""},""factor"":1},""status"":{""date"":""2025-08-04T14:43:44-05:00"",""reason"":""00"",""status"":""APPROVED"",""message"":""Aprobada""},""receipt"":""266306"",""refunded"":false,""franchise"":""ID_DN"",""reference"":""72235"",""issuerName"":""BANCO DINERS"",""authorization"":""913713"",""paymentMethod"":""diners"",""processorFields"":[{""value"":""0404062"",""keyword"":""merchantCode"",""displayOn"":""none""},{""value"":""00990099"",""keyword"":""terminalNumber"",""displayOn"":""none""},{""value"":{""code"":""1"",""type"":""03"",""groupCode"":""X"",""installments"":6},""keyword"":""credit"",""displayOn"":""none""},{""value"":331.2,""keyword"":""totalAmount"",""displayOn"":""none""},{""value"":0,""keyword"":""interestAmount"",""displayOn"":""none""},{""value"":55.2,""keyword"":""installmentAmount"",""displayOn"":""none""},{""value"":0,""keyword"":""iceAmount"",""displayOn"":""none""},{""value"":""360857"",""keyword"":""bin"",""displayOn"":""none""},{""value"":""1026"",""keyword"":""expiration"",""displayOn"":""none""},{""value"":""4469"",""keyword"":""lastDigits"",""displayOn"":""none""},{""value"":""85a359bb8e67eb83a1ebe09fc634c995"",""keyword"":""id"",""displayOn"":""none""},{""value"":""00"",""keyword"":""b24"",""displayOn"":""none""}],""internalReference"":81266306,""paymentMethodName"":""Diners""}],""subscription"":null}"
    'genera_pago(cadena_prueba)

#Region "PMTZ"

    'Public Sub genera_pago(ByVal resultado As String)
    '    resultado = resultado.Replace("""", "")
    '    Dim tNo_value_final As String = valor(resultado, "dev_reference")
    '    Dim autorizacion_rs As String = valor(resultado, "status")
    '    Dim numero_autorizacion As String = valor(resultado, "authorization_code")
    '    Dim log_mensaje As String = ""
    '    Dim log_opcion As Integer = 0

    '    If autorizacion_rs = "success" And numero_autorizacion <> "null" Then
    '        log_mensaje = "Transacción Exitosa, Por favor revise su email con el detalle de la transacción."
    '        log_opcion = 20
    '        genera_ordenes(tNo_value_final, log_mensaje, resultado, numero_autorizacion)
    '    Else
    '        log_mensaje = "Transacción no realizada, por favor comunicarse con su banco emisor."
    '        log_opcion = 19
    '        'cancela_ordenes(tNo_value_final, log_mensaje, resultado)
    '    End If

    '    Try
    '        FormularioAdapter.RegistroLog(log_opcion, Session("user"), 1, log_mensaje)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Private Sub genera_ordenes(ByVal orden_trabajada As String, ByVal log_mensaje As String, ByVal resultado As String, ByVal numero_autorizacion As String)
    '    Dim value_actestadoorden As Integer = 0
    '    Dim numero_meses As String = valor(resultado, "installments")
    '    Dim numero_meses_ns As String = numero_meses + "M"
    '    Dim tipo_tarjeta As String = valor(resultado, "type")
    '    Dim mensaje As String = valor(resultado, "message")
    '    Dim id_transaccion As String = valor(resultado, "transaction_reference")
    '    Dim banco As String = valor(resultado, "bank_name")
    '    Dim bintarjeta As String = valor(resultado, "bin")
    '    Dim DTSetInfoURLTecnico As New DataTable()
    '    DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
    '    Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
    '    Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
    '    Dim total_con_iva As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
    '    Dim TransaccionValue As String = DTSetInfoURLTecnico.Rows(8)("datatecnica") 'valor(resultado, "amount")
    '    Dim subtotal As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
    '    Dim usuario_ns As String = Session("user_netsuite")
    '    Dim usuario_3s As String = Session("user")
    '    Dim id_metodopago_ns As String = Session("id_metodopago_ns")
    '    Dim IdOrdenVpos As String = orden_trabajada
    '    Dim id_emisor_ns As String = Session("id_emisor_ns")
    '    Dim formapago As String = "30"
    '    Dim estado_texto As String = ""
    '    Try
    '        value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, "O", numero_autorizacion, orden_trabajada, numero_meses,
    '                                                                          tipo_tarjeta, 0, 0, TransaccionValue, 0, Session("user"),
    '                                                                          id_transaccion, banco, bintarjeta, resultado)
    '        Dim mensaje_mail As String = ""
    '        Dim objmail As New MailTrabajos
    '        If accion = "REN" Then
    '            Dim tbl_table As New System.Data.DataTable
    '            tbl_table = CType(Session("tblrenovaciones"), DataTable)
    '            Dim i As Integer = 0
    '            While tbl_table.Rows.Count > 0
    '                Dim dRFila() As DataRow
    '                Dim vehiculo As String = tbl_table.Rows(i).Item("VEHICULO")
    '                Dim sentencia As String = String.Format("VEHICULO = '{0}' ", vehiculo)
    '                dRFila = tbl_table.Select(sentencia)
    '                Dim item_array As String = ""
    '                Dim anio_array As String = ""
    '                Dim ejecutiva_array As String = ""
    '                Dim iva_array As String = ""
    '                Dim subtotal_array As String = ""
    '                Dim total_array As String = ""
    '                For j As Integer = 0 To dRFila.Count - 1
    '                    Dim dRFila_ As DataRow = dRFila(j)
    '                    item_array = item_array & IIf(item_array <> "", ",", "") & dRFila.GetValue(j)("IDITEM")
    '                    anio_array = anio_array & IIf(anio_array <> "", ",", "") & dRFila.GetValue(j)("ANIO")
    '                    ejecutiva_array = IIf(ejecutiva_array <> "", ",", "") & dRFila.GetValue(j)("IDEJECUTIVO")
    '                    iva_array = iva_array & IIf(iva_array <> "", ",", "") & dRFila.GetValue(j)("IVA")
    '                    subtotal_array = subtotal_array & IIf(subtotal_array <> "", ",", "") & dRFila.GetValue(j)("PRECIO_VENTA")
    '                    total_array = total_array & IIf(total_array <> "", ",", "") & dRFila.GetValue(j)("PRECIO_CLIENTE")
    '                    tbl_table.Rows.Remove(dRFila_)
    '                Next
    '                Dim tbl_tablefac As New System.Data.DataTable
    '                tbl_tablefac = CType(Session("tblfacturacion"), DataTable)
    '                Dim clientefac As String = tbl_tablefac.Rows(0).Item(0).ToString
    '                RenovacionAdapter.genera_renovacion(orden_trabajada, iva_array, subtotal_array, item_array, usuario_ns, vehiculo, ejecutiva_array, total_array,
    '                                  usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), anio_array, formapago, numero_meses_ns,
    '                                  Session("DTCodigoIva"), clientefac, bintarjeta, total_con_iva)
    '            End While
    '            estado_texto = "Transaccion Netsuite OK"
    '            objmail.EnvioEmailConfirmaciónPago("100", CType(orden_trabajada, Decimal))
    '        ElseIf accion = "COB" Then
    '            RenovacionAdapter.genera_cobro(orden_trabajada, usuario_3s, usuario_ns, TransaccionValue, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), numero_meses_ns, bintarjeta, numero_meses)
    '            estado_texto = "Transaccion OK"
    '            objmail.EnvioEmailConfirmaciónPago("100", CType(orden_trabajada, Decimal))
    '        ElseIf accion = "VEN" Then
    '            'Dim table As New System.Data.DataTable
    '            'table = CType(Session("tblrenovaciones"), DataTable)
    '            'For i As Integer = 0 To table.Rows.Count - 1
    '            '    Dim vehiculo_ns As String = table.Rows(i).Item("VEHICULO")
    '            '    Dim item As String = table.Rows(i)("IDITEM")
    '            '    Dim ejecutiva As String = table.Rows(i)("IDEJECUTIVO")
    '            '    RenovacionAdapter.genera_venta(DTSetInfoURLTecnico, orden_trabajada, iva, subtotal, item, usuario_ns, vehiculo_ns, fecha_set(), ejecutiva,
    '            '                 TransaccionValue, usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"))
    '            '    Dim objmail2 As New MailTrabajos
    '            '    objmail2.EnvioEmailConfirmaciónPago("100", CType(orden_trabajada, Decimal))
    '            'Next
    '        End If
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Private Function valor(ByVal cadena As String, ByVal item As String) As String
    '    Dim resultado As String = ""
    '    cadena = cadena.Replace("\", "")
    '    Dim ini As Integer = cadena.IndexOf(item & ":")

    '    If ini > -1 Then
    '        Dim fin As Integer = cadena.Substring(ini).IndexOf(",")
    '        If fin < 0 Then
    '            fin = cadena.Substring(ini).IndexOf("}")
    '        End If

    '        resultado = cadena.Substring(ini, fin)
    '        resultado = resultado.Replace(item & ":", "").Replace("{", "").Replace("}", "")
    '    End If

    '    Return resultado
    'End Function

#End Region

#Region "INTERDIN"

    'Public Sub genera_pago(ByVal resultado As String)
    '    resultado = resultado.Replace("""", "")
    '    Dim tNo_value_final As String = descompone_retorno("reference", resultado)
    '    Dim id_transaccion As String = descompone_retorno("requestId", resultado)
    '    Dim estado_pago As String = descompone_retorno("status", resultado)
    '    Dim estado As String = ""
    '    Dim log_mensaje As String = ""
    '    Dim log_opcion As Integer = 0
    '    If estado_pago = "APPROVED" Then
    '        log_mensaje = "Transacción Exitosa, Por favor revise su email con el detalle de la transacción."
    '        log_opcion = 20
    '        estado = "O"
    '    ElseIf estado_pago = "PENDING" Then
    '        log_mensaje = "La transacción se encuentra en un estado pendiente, espere unos minutos a que la misma se resuelva.."
    '        log_opcion = 19
    '        estado = "R"
    '    Else
    '        log_mensaje = "Transacción no realizada, por favor comunicarse con su banco emisor."
    '        log_opcion = 19
    '        estado = "X"
    '    End If
    '    genera_ordenes(tNo_value_final, log_mensaje, estado, id_transaccion)
    '    FormularioAdapter.RegistroLog(log_opcion, Session("user"), 1, log_mensaje)
    'End Sub

    'Private Sub genera_ordenes(ByVal tNo_value_final As String, ByVal log_mensaje As String, ByVal estado_obtenido As String, ByVal id_transaccion As String)
    '    Dim resultado As String = retorna_resultado(id_transaccion, tNo_value_final)
    '    'EMailHandler.EMailProcesoPago(asunto_mail("3", "Trama Detalle(" & resultado & ")", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
    '    Dim value_actestadoorden As Integer = 0
    '    Dim estado As String = descompone_retorno("status", resultado)
    '    Dim mensaje As String = descompone_retorno("message", resultado)
    '    Dim meses As String = descompone_retorno("installments", resultado)
    '    Dim numero_meses_ns As String = meses + "M"
    '    Dim id_grupo As String = descompone_retorno("groupCode", resultado)
    '    Dim banco As String = descompone_retorno("issuerName", resultado)
    '    Dim bin As String = descompone_subretorno("bin", resultado)
    '    Dim estado_texto As String = ""
    '    Dim opcion_email As String = ""
    '    Dim DTSetInfoURLTecnico As New DataTable()
    '    DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
    '    Dim valor_total As String = DTSetInfoURLTecnico.Rows(8)("datatecnica") 'descompone_subretorno("totalAmount", resultado)
    '    Dim total_con_iva As String = DTSetInfoURLTecnico.Rows(7)("datatecnica")
    '    Dim accion As String = DTSetInfoURLTecnico.Rows(13)("datatecnica")
    '    Dim iva As String = DTSetInfoURLTecnico.Rows(11)("datatecnica")
    '    Dim subtotal As String = DTSetInfoURLTecnico.Rows(8)("datatecnica")
    '    Dim usuario_ns As String = Session("user_netsuite")
    '    Dim usuario_3s As String = Session("user")
    '    Dim id_metodopago_ns As String = Session("id_metodopago_ns")
    '    Dim IdOrdenVpos As String = Session("IdOrdenVpos")
    '    Dim id_emisor_ns As String = Session("id_emisor_ns")
    '    Dim formapago As String = "30"
    '    Try
    '        If tNo_value_final = "" Or estado = "" Or mensaje = "" Or meses = "" Or id_grupo = "" Or valor_total = "" Or banco = "" Or bin = "" Then
    '            'EMailHandler.EMailProcesoPago(asunto_mail("X", "**ERROR EN CAPTURA DE DATOS", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
    '            Exit Try
    '        End If
    '        value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estado_obtenido, id_transaccion, tNo_value_final, meses,
    '                                                                          "DN", 0, 0, valor_total, 0, usuario_3s,
    '                                                                          id_transaccion, banco, bin, "") ' resultado)
    '        'EMailHandler.EMailProcesoPago(asunto_mail("4", "ORDEN DE PAGO ACTUALIZADA", tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
    '        Dim mensaje_mail As String = ""
    '        Dim objmail As New MailTrabajos
    '        If estado_obtenido = "O" Then
    '            estado_texto = "Aprobado"
    '            opcion_email = "100"
    '            mensaje_mail = String.Format("{0} - Email {1}", accion, estado_texto)
    '            If accion = "REN" Then
    '                Dim tbl_table As New System.Data.DataTable
    '                tbl_table = CType(Session("tblrenovaciones"), DataTable)
    '                Dim i As Integer = 0
    '                While tbl_table.Rows.Count > 0
    '                    Dim dRFila() As DataRow
    '                    Dim vehiculo As String = tbl_table.Rows(i).Item("VEHICULO")
    '                    Dim sentencia As String = String.Format("VEHICULO = '{0}' ", vehiculo)
    '                    dRFila = tbl_table.Select(sentencia)
    '                    Dim item_array As String = ""
    '                    Dim anio_array As String = ""
    '                    Dim ejecutiva_array As String = ""
    '                    Dim iva_array As String = ""
    '                    Dim subtotal_array As String = ""
    '                    Dim total_array As String = ""
    '                    For j As Integer = 0 To dRFila.Count - 1
    '                        Dim dRFila_ As DataRow = dRFila(j)
    '                        item_array = item_array & IIf(item_array <> "", ",", "") & dRFila.GetValue(j)("IDITEM")
    '                        anio_array = anio_array & IIf(anio_array <> "", ",", "") & dRFila.GetValue(j)("ANIO")
    '                        ejecutiva_array = IIf(ejecutiva_array <> "", ",", "") & dRFila.GetValue(j)("IDEJECUTIVO")
    '                        iva_array = iva_array & IIf(iva_array <> "", ",", "") & dRFila.GetValue(j)("IVA")
    '                        subtotal_array = subtotal_array & IIf(subtotal_array <> "", ",", "") & dRFila.GetValue(j)("PRECIO_VENTA")
    '                        total_array = total_array & IIf(total_array <> "", ",", "") & dRFila.GetValue(j)("PRECIO_CLIENTE")
    '                        tbl_table.Rows.Remove(dRFila_)
    '                    Next
    '                    Dim tbl_tablefac As New System.Data.DataTable
    '                    tbl_tablefac = CType(Session("tblfacturacion"), DataTable)
    '                    Dim clientefac As String = tbl_tablefac.Rows(0).Item(0).ToString
    '                    RenovacionAdapter.genera_renovacion(tNo_value_final, iva_array, subtotal_array, item_array, usuario_ns, vehiculo, ejecutiva_array, total_array,
    '                                  usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), anio_array, formapago, numero_meses_ns,
    '                                  Session("DTCodigoIva"), clientefac, bin, total_con_iva)
    '                End While
    '                estado_texto = "Transaccion Netsuite OK"
    '                objmail.EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))
    '            ElseIf accion = "COB" Then
    '                RenovacionAdapter.genera_cobro(tNo_value_final, usuario_3s, usuario_ns, valor_total, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"), numero_meses_ns, bin, meses)
    '                estado_texto = "Transaccion OK"
    '                objmail.EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))
    '            ElseIf accion = "VEN" Then
    '                'RenovacionAdapter.genera_venta(DTSetInfoURLTecnico, tNo_value_final, iva, subtotal, valor_total, usuario_ns, vehiculo_ns, fecha_set(), ejecutiva,
    '                '             valor_total, usuario_3s, id_metodopago_ns, IdOrdenVpos, id_emisor_ns, Session("iphost"))
    '                'Dim objmail2 As New MailTrabajos
    '                'objmail2.EnvioEmailConfirmaciónPago("100", CType(tNo_value_final, Decimal))
    '            End If
    '            'EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
    '        ElseIf estado_obtenido = "X" Then
    '            estado_texto = "Pendiente"
    '            opcion_email = "300"
    '            'EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
    '        Else
    '            estado_texto = "Rechazado"
    '            opcion_email = "200"
    '            'EMailHandler.EMailProcesoPago(asunto_mail("6", mensaje_mail, tNo_value_final), Nothing, Session("iphost"), Session("iphost"))
    '        End If

    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    'Private Function descompone_retorno(ByVal etiqueta As String, ByVal trama As String) As String
    '    Dim seccion As String = ""
    '    If trama.IndexOf(etiqueta) > -1 Then
    '        seccion = trama.Substring(trama.IndexOf(etiqueta))
    '        seccion = seccion.Substring(seccion.IndexOf(":"), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(":"))
    '        seccion = seccion.Replace(etiqueta, "").Replace(Chr(34), "").Replace(":", "").Replace("{", "").Replace("}", "")
    '        seccion = seccion.Trim
    '    End If
    '    Return seccion
    'End Function

    'Private Function descompone_subretorno(ByVal etiqueta As String, ByVal trama As String) As String
    '    Dim seccion As String = ""
    '    If trama.IndexOf(etiqueta) > -1 Then
    '        If etiqueta = "bin" Then
    '            seccion = trama.Substring(trama.IndexOf(etiqueta) - 28)
    '            seccion = seccion.Substring(seccion.IndexOf("value"))
    '            seccion = seccion.Substring(seccion.IndexOf(""""), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(""""))
    '        ElseIf etiqueta = "totalAmount" Then
    '            seccion = trama.Substring(trama.IndexOf(etiqueta) - 28)
    '            seccion = seccion.Substring(seccion.IndexOf("value"))
    '            seccion = seccion.Substring(seccion.IndexOf(""""), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(""""))
    '        Else
    '            seccion = trama.Substring(trama.IndexOf(etiqueta))
    '            seccion = seccion.Substring(seccion.IndexOf(""""), IIf(seccion.IndexOf(",") < 0, seccion.Length - 1, seccion.IndexOf(",")) - seccion.IndexOf(""""))
    '        End If
    '        seccion = seccion.Replace(etiqueta, "").Replace(Chr(34), "").Replace(":", "").Replace("{", "").Replace("}", "")
    '    End If
    '    Return seccion
    'End Function

    'Private Function retorna_resultado(ByVal referencia As String, ByVal orden As String)
    '    retorna_resultado = ""
    '    Try
    '        Dim app_code As String = System.Configuration.ConfigurationManager.AppSettings("DinersLogin").ToString
    '        Dim app_key As String = System.Configuration.ConfigurationManager.AppSettings("DinersClave").ToString
    '        Dim url As String = System.Configuration.ConfigurationManager.AppSettings("DinersRuta").ToString & "/" & referencia
    '        Dim jsonData As String = ""
    '        Dim objXmlHttp As Object
    '        Dim jsonhttp As Object
    '        jsonData = DataJsonConsulta(app_code, app_key)
    '        jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
    '        jsonhttp.open("POST", url, False)
    '        jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
    '        jsonhttp.setRequestHeader("Content-Type", "application/json")
    '        jsonhttp.send(jsonData)
    '        objXmlHttp = jsonhttp.Responsetext
    '        retorna_resultado = objXmlHttp.ToString
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    '    Return retorna_resultado
    'End Function

    'Private Function DataJsonConsulta(ByVal login As String, ByVal trankey As String) As String
    '    DataJsonConsulta = ""
    '    Dim DTSetInfoURLTecnico As New DataTable()

    '    If Not DTSetInfoURLTecnico Is Nothing Then
    '        Dim nonce As String = GetNonce()
    '        Dim seed As String = FormatoFecha(Date.Now)
    '        Dim trankeyencr As String = encriptar_sha1_64(String.Format("{0}{1}{2}", nonce, seed, trankey))
    '        Dim nonceencr As String = EncriptarBase64(nonce)
    '        Dim auth As String = SerializarJsonConsulta(login, seed, nonceencr, trankeyencr)
    '        DataJsonConsulta = auth
    '    End If

    '    Return DataJsonConsulta
    'End Function

    'Private Function FormatoFecha(ByVal fecha As DateTime) As String
    '    FormatoFecha = ""
    '    FormatoFecha = FormatoFecha & Convert.ToString(fecha.Year) & "-"
    '    FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Month), 2) & "-"
    '    FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Day), 2) & "T"
    '    FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Hour), 2) & ":"
    '    FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Minute), 2) & ":"
    '    FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Second), 2) & "-05:00"
    '    Return FormatoFecha
    'End Function

    'Private Function GetNonce() As String
    '    GetNonce = ""
    '    Dim Generator As System.Random = New System.Random()
    '    Dim randomN As Integer = Generator.Next(0, Int32.MaxValue)
    '    GetNonce = randomN.GetHashCode.ToString
    '    Return GetNonce
    'End Function

    'Public Function SerializarJson(ByVal firstTable As DataTable) As String
    '    Try
    '        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
    '        Dim rows As New List(Of Dictionary(Of String, Object))
    '        Dim row As Dictionary(Of String, Object)

    '        For Each dr As DataRow In firstTable.Rows
    '            row = New Dictionary(Of String, Object)
    '            For Each col As DataColumn In firstTable.Columns
    '                row.Add(col.ColumnName, dr(col))
    '            Next
    '            rows.Add(row)
    '        Next
    '        Return serializer.Serialize(rows).ToString
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function SerializarJsonConsulta(ByVal login As String, ByVal seed As String, ByVal nonce As String, ByVal trankey As String) As String
    '    SerializarJsonConsulta = ""
    '    Try
    '        SerializarJsonConsulta = "{""auth"":{""login"": """ & login &
    '                                 """,""seed"": """ & seed &
    '                                 """,""nonce"": """ & nonce &
    '                                 """,""tranKey"": """ & trankey & """}}"
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return SerializarJsonConsulta
    'End Function

    'Public Function EncriptarSHA256(ByVal ClearString As String) As String
    '    Dim sourceBytes = ASCIIEncoding.ASCII.GetBytes(ClearString)
    '    Dim SHA256Obj As New System.Security.Cryptography.SHA256CryptoServiceProvider
    '    Dim byteHash = SHA256Obj.ComputeHash(sourceBytes)
    '    Dim result As String = ""
    '    For Each b As Byte In byteHash
    '        result += b.ToString("x2")
    '    Next
    '    Return result
    'End Function

    'Private Function EncriptarSHA1(ByVal ClearString As String) As String
    '    EncriptarSHA1 = ""
    '    Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
    '    Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(ClearString)
    '    bytesToHash = sha1Obj.ComputeHash(bytesToHash)

    '    For Each b As Byte In bytesToHash
    '        EncriptarSHA1 += b.ToString("x2")
    '    Next
    '    Return EncriptarSHA1
    'End Function

    'Private Function EncriptarBase64(ByVal ClearString As String) As String
    '    EncriptarBase64 = ""
    '    EncriptarBase64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(ClearString))
    '    Return EncriptarBase64
    'End Function

    'Private Function encriptar_sha1_64(ByVal ClearString As String) As String
    '    encriptar_sha1_64 = ""

    '    Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
    '    Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(ClearString)
    '    bytesToHash = sha1Obj.ComputeHash(bytesToHash)

    '    encriptar_sha1_64 = System.Convert.ToBase64String(bytesToHash)

    '    Return encriptar_sha1_64
    'End Function

#End Region

#End Region

End Class