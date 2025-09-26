Public Class RenovacionFormaConfirmacion
    Inherits System.Web.UI.Page


#Region "Eventos del formulario"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MetodosMaster("Renovación de Servicios por Forma de Pago", 3, "Renovacion proceso de pago")
                MensajeriaError("", "")
                CarroCompra()
                ResumenCompra()

            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub
#End Region


#Region "Eventos de los controles"

    Private Sub btnpagar_Click(sender As Object, e As System.EventArgs) Handles btnpagar.Click
        If ValidacionesPago() Then
            Try
                GeneraOrdenWeb()
                btnpagar.Enabled = False
            Catch ex As Exception
                ExceptionHandler.Captura_Error(ex)
            End Try
        End If
    End Sub


#End Region


#Region "Procedimientos"

    Private Sub NumeroOrden()
        lblnumeroorden.Text = OrdenPagoAdapter.ConsultaSecuenciaOrdenPago()
    End Sub

    Private Sub CarroCompra()
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
            CarroCompras(valueCellPrecioCliente, valueCantidadRenovar)
            lblresumencantidad.Text = valueCantidadRenovar
            lblresumentotal.Text = valueCellPrecioUnitario
            lblresumenpromocion.Text = valueCellPrecioPromocion
            lblresumensubtotal.Text = valueCellPrecioSubtotal
            lblresumeniva.Text = valueCellPrecioIva
            lblresumenpreciocliente.Text = valueCellPrecioCliente
        End If

        Dim tableForma As New System.Data.DataTable
        tableForma = CType(Session("DetalleForma"), DataTable)
        Me.RptdetalleForma.DataSource = tableForma
        Me.RptdetalleForma.DataBind()
    End Sub

    Private Sub ResumenCompra()
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

    Private Function ValidacionesPago() As Boolean
        Dim retorno As Boolean = True
        Dim tablefac As New System.Data.DataTable
        Dim myMasterPage As master = CType(Page.Master, master)
        tablefac = CType(Session("tblfacturacion"), DataTable)

        'If Session("IdTarjetaVpos") = "" Then
        '    retorno = False
        '    mensajeria_error("error", "para continuar usted debe seleccionar mínimo una tarjeta.")
        'ElseIf Session("IdTipoPagoVpos") = "" Then
        '    retorno = False
        '    mensajeria_error("error", "para continuar usted debe seleccionar mínimo un tipo de pago.")
        If Libreria.Parse(myMasterPage.cantidadMaster) = 0 Then
            retorno = False
            MensajeriaError("error", "para continuar usted debe seleccionar mínimo un servicio.")
        ElseIf Libreria.Parse(lblresumencantidad.Text) = 0 Then
            retorno = False
            MensajeriaError("error", "para continuar usted debe seleccionar mínimo un servicio.")
            'ElseIf secuencial_emisor(Session("IdTarjetaVpos")) = "" Then
            '    retorno = False
            '    mensajeria_error("error", "no se pudo obtener datos de tarjeta.")
        ElseIf tablefac.Rows.Count = 0 Then
            retorno = False
            MensajeriaError("error", "por favor completar datos de facturación.")
        End If

        Return retorno
    End Function

    Private Sub GeneraOrdenWeb()
        Dim ordenEntity As New OrdenEntity
        Dim ordenDetalleEntity As OrdenDetalleEntity
        Dim ordenDetalleEntityCollection As New OrdenDetalleEntityCollection
        'Dim datosVpos As String = secuencial_emisor(Session("IdTarjetaVpos"))
        'Dim idemisor As String = datosVpos.Substring(2, 3)
        'Dim secuencialemisor As Integer = datosVpos.Substring(2, 3)
        'Dim secuencialsh As String = "000"

        Dim tablefac As New System.Data.DataTable
        Dim valueFormaPagoNomb As String = ""
        Dim valueFormaPagoIdnt As String = ""
        Dim valueFormaPagoDirc As String = ""
        Dim valueFormaPagoTelf As String = ""
        Dim valueFormaPagoCell As String = ""
        Dim valueFormaPagoEmail As String = ""
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
        'If Session("IdTarjetaVpos") = "PC" Then
        '    Session("Pacificard") = "1"
        'Else
        '    Session("Pacificard") = "0"
        'End If
        OrdenEntity.OrdenId = 0
        OrdenEntity.ClienteId = Session("user_id")
        OrdenEntity.NumeroMeses = 1
        ordenEntity.TipoTarjeta = ""
        OrdenEntity.SubTotal = lblresumensubtotal.Text
        OrdenEntity.Iva = lblresumeniva.Text
        OrdenEntity.Ice = 0
        OrdenEntity.Interes = 0
        OrdenEntity.Total = Libreria.Parse(lblresumenpreciocliente.Text)
        OrdenEntity.TipoPago = 0
        OrdenEntity.TipoCredito = "00"
        OrdenEntity.CodigoConfPago = 0
        OrdenEntity.BillingName = valueFormaPagoNomb
        OrdenEntity.BillingCedula = valueFormaPagoIdnt
        OrdenEntity.BillingAddress = valueFormaPagoDirc
        OrdenEntity.BillingPhone = valueFormaPagoTelf
        OrdenEntity.BillingMovil = valueFormaPagoCell
        OrdenEntity.BillingEmail = valueFormaPagoEmail
        OrdenEntity.BillingCardType = 0
        OrdenEntity.EstadoWebId = 1
        OrdenEntity.UsuarioProcesoId = 0
        OrdenEntity.AccionComercial = "REN"
        OrdenPagoAdapter.ConfirmoPagoOnline(OrdenEntity)
        OrdenEntity = New OrdenEntity
        NumeroOrden()
        Dim ordenId As String = lblnumeroorden.Text
        ordenEntity.OrdenId = ordenId
        ordenEntity.ClienteId = Session("user_id")
        ordenEntity.idemisor = ""
        ordenEntity.NumeroMeses = 1
        ordenEntity.TipoTarjeta = ""
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
        ordenEntity.AccionComercial = "REN"
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
            ordenDetalleEntity.CodigoPromocion = "000"
            ordenDetalleEntity.ValorPromocion = table.Rows(i).Item("VALOR_PROMOCION")
            ordenDetalleEntity.PorcentajeDescuento = 0
            ordenDetalleEntity.Descuento = 0
            ordenDetalleEntity.SubTotal = table.Rows(i).Item("PRECIO_TOTAL")
            ordenDetalleEntity.Iva = table.Rows(i).Item("IVA")
            ordenDetalleEntity.Total = table.Rows(i).Item("PRECIO_CLIENTE")
            ordenDetalleEntity.MarcadoLojack = "NO"
            ordenDetalleEntity.UsuarioProcesoId = 0
            ordenDetalleEntityCollection.Add(ordenDetalleEntity)
        Next

        ordenEntity.OrdenDetalleEntityCollection = ordenDetalleEntityCollection
        Session("OrdenID") = ordenEntity.OrdenId
        lblnumeroorden.Text = ordenEntity.OrdenId
        OrdenPagoAdapter.RegistroPagoOnlineFormaPago(ordenEntity, Session("DetalleForma"))

        'Dim dTGetInfoUrlTecnico As New DataTable()
        'dTGetInfoUrlTecnico.Columns.Add("datatecnica", GetType(String))
        'dTGetInfoUrlTecnico.Rows.Add(ordenEntity.OrdenId)
        'dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoIdnt)
        'dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoNomb)
        'dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoDirc)
        'dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoCell)
        'dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoEmail)
        'dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))
        'dTGetInfoUrlTecnico.Rows.Add(Libreria.Parse(lblresumenpreciocliente.Text))
        'dTGetInfoUrlTecnico.Rows.Add(lblresumensubtotal.Text)
        'dTGetInfoUrlTecnico.Rows.Add(0) 'descuentos
        'dTGetInfoUrlTecnico.Rows.Add(0) 'promociones
        'dTGetInfoUrlTecnico.Rows.Add(lblresumeniva.Text)
        'dTGetInfoUrlTecnico.Rows.Add(idemisor)
        'dTGetInfoUrlTecnico.Rows.Add("REN")
        'dTGetInfoUrlTecnico.Rows.Add(Date.Now)
        'dTGetInfoUrlTecnico.Rows.Add("00:00")
        'dTGetInfoUrlTecnico.Rows.Add(0)
        'dTGetInfoUrlTecnico.Rows.Add(IIf(Session("IdTipoPagoVpos") = 1, 0, 3))
        'EMailHandler.EMailGeneracionOrdenPago("Registro de orden de pago exitoso <<inicio boton de pago>>.", Session("OrdenID"), Session("iphost"))
        'Session("DTGetInfoURLTecnico") = dTGetInfoUrlTecnico

        'If VposAnterior(Session("IdTarjetaVpos")) = "MC" Or VposAnterior(Session("IdTarjetaVpos")) = "VI" Then
        '    Response.Redirect("cotizadorweburltecnicopaymentez.aspx", False)
        'ElseIf VposAnterior(Session("IdTarjetaVpos")) = "DN" Then
        '    Response.Redirect("cotizadorweburltecnico.aspx", False)
        'End If

        'GENERA ORDENES SIN PASAR POR PAGOS PARA DESARROLLO

        'RenovacionAdapter.GeneraOrdenServicioPorFormaPago(lblnumeroorden.Text)

        If RenovacionAdapter.GeneraOrdenServicioPorFormaPago(lblnumeroorden.Text) Then
            EMailHandler.EMailProcesoPago(asunto_mail("5", "OS GENERADA", lblnumeroorden.Text), Nothing, Session("iphost"), Session("iphost"))
        Else
            EMailHandler.EMailProcesoPago(asunto_mail("5", "OS FALLÓ", lblnumeroorden.Text), Nothing, Session("iphost"), Session("iphost"))
        End If
    End Sub


    Private Function asunto_mail(ByVal numMail As String, ByVal tipo As String, ByVal orden As String) As String
        Dim resultado As String = ""
        resultado = String.Format("EMAIL {0}ºº {1} ENVIADO // ", numMail, tipo, orden)
        Return resultado
    End Function

    'Private Function secuencial_emisor(id_emisor As String) As String
    '    Dim retorno As String = ""

    '    Dim dTCstEmisor As New System.Data.DataSet
    '    dTCstEmisor = RenovacionAdapter.ConsultaEmisorDetalleVpos(id_emisor, "NO")
    '    If dTCstEmisor.Tables(0).Rows.Count > 0 Then
    '        retorno = dTCstEmisor.Tables(0).Rows(0).Item("SECUENCIAL")
    '    Else
    '        retorno = ""
    '    End If

    '    Return retorno
    'End Function

    'Private Function VposAnterior(id_emisor As String) As String
    '    Dim retorno As String = ""

    '    If id_emisor = "VI" Then
    '        retorno = "VI"
    '    ElseIf id_emisor = "MC" Then
    '        retorno = "MC"
    '    ElseIf id_emisor = "DN" Then
    '        retorno = "DN"
    '    ElseIf id_emisor = "DI" Then
    '        retorno = "DN"
    '    ElseIf id_emisor = "PC" Then
    '        retorno = "VI"
    '    ElseIf id_emisor = "AM" Then
    '        retorno = "DN"
    '    ElseIf id_emisor = "TI" Then
    '        retorno = "DN"
    '    End If

    '    Return retorno
    'End Function

    Private Sub MensajeriaError(tipo As String, mensaje As String)
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

    Private Sub MetodosMaster(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub CarroCompras(valor As String, cantidad As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.cantidadMaster = cantidad
        myMasterPage.totalMaster = valor
    End Sub

#End Region



End Class