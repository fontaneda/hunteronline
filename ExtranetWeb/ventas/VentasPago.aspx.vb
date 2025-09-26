Public Class VentasPago
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Venta de Productos/Servicios", 8, "Ventas proceso de pagos")
                    mensajeria_error("", "")
                    seccextras_cabecera.Visible = False
                    seccextras.Visible = False
                    carro_compra()
                    resumen_compra()
                    llenainfodatos()
                    'Session("idpantalla") = ""
                    'Session("isPostBack01") = "0"
                    'Session("idpantalla") = "0"
                End If
            Else
                If Session("errorbandera") = "0" Then
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "ShowPopup();", True)
                End If
                'Session("isPostBack01") = "1"
                'If Session("idpantalla") = "1" Then
                '    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "ShowPopupTurno();", True)
                'ElseIf Session("idpantalla") = "2" Then

                'End If
                'Session("idpantalla") = "0"
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Protected Sub clk_rpt_clientemon(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Session("errorbandera") = "10"
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblcliente As Label = CType(item.FindControl("lblcodigoclientesfac"), Label)
            pasar_datos_existe(lblcliente.Text)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnpagar_Click(sender As Object, e As System.EventArgs) Handles btnpagar.Click
        If validaciones_pago() Then
            Try
                genera_orden_web()
            Catch ex As Exception
                ExceptionHandler.Captura_Error(ex)
            End Try
        End If
    End Sub

    Private Sub txtbusquedaclientefac_ServerChange(sender As Object, e As System.EventArgs) Handles txtcmbuscacliente.ServerChange
        Try
            If Len(txtcmbuscacliente.Value) > 0 Then
                Dim dTDatosCliente As New DataSet
                dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreo(txtcmbuscacliente.Value)
                If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                    rpt_clientemonitoreo.DataSource = dTDatosCliente
                    rpt_clientemonitoreo.DataBind()
                Else
                    rpt_clientemonitoreo.DataSource = Nothing
                    rpt_clientemonitoreo.DataBind()
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btncmbuscacliente_ServerClick(sender As Object, e As System.EventArgs) Handles btncmbuscacliente.ServerClick
        Try
            If Not validar() Then
                Dim ClienteEntity As New ClienteEntity
                Dim ClienteDetalleEntity As ClienteDetalleEntity
                Dim ClienteDetalleEntityCollection As New ClienteDetalleEntityCollection
                ClienteEntity = New ClienteEntity
                'DATOS CLIENTES
                ClienteEntity.ClienteId = txtcmidentificacion.Value
                ClienteEntity.ClienteTipoIdentificacion = cmbcmidentificacion.SelectedValue
                ClienteEntity.ClienteNacimiento = txtcmnfechanac1.Text
                ClienteEntity.ClienteApellidoPadre = txtcmapellido1.Value
                ClienteEntity.ClienteApellidoMadre = txtcmapellido2.Value
                ClienteEntity.ClienteNombrePrimero = txtcmnombre1.Value
                ClienteEntity.ClienteNombreSegundo = txtcmnombre2.Value
                ClienteEntity.ClienteSexo = cmbcmsexo.SelectedValue
                'DATOS DIRECCION
                ClienteDetalleEntity = New ClienteDetalleEntity
                ClienteDetalleEntity.DireccionSectorId = cmbcmsector.SelectedValue
                ClienteDetalleEntity.DireccionProvinciaId = cmbcmprovincia.SelectedValue
                ClienteDetalleEntity.DireccionCiudadId = cmbcmciudad.SelectedValue
                ClienteDetalleEntity.DireccionParroquiaId = cmbcmparroquia.SelectedValue
                ClienteDetalleEntity.Direccion = txtcmdireccion.Value
                ClienteDetalleEntity.DireccionInterseccion = txtcminterseccion.Value
                ClienteDetalleEntity.DireccionNumero = txtcmnumerodomicilio.Value
                'DATOS TELEFONO
                ClienteDetalleEntity.Telefono = txtcmtelefono.Value
                ClienteDetalleEntity.TelefonoCelular = txtcmcelular.Value
                'DATOS REFERENCIA BANCARIA
                ClienteDetalleEntity.EmailPrincipal = txtcmemail.Value
                ClienteDetalleEntity.EmailAlerta = ""

                ClienteDetalleEntityCollection.Add(ClienteDetalleEntity)
                ClienteEntity.ClienteDetalleEntityCollection = ClienteDetalleEntityCollection
                If DatosPersonalesAdapter.RegistroClienteFACTURA(ClienteEntity) Then
                    Session("errorbandera") = "10"
                    txtDatoClientemonitoreo.Text = txtcmidentificacion.Value
                    txtNombreClientemonitoreo.Text = txtcmnombre1.Value _
                                                    & " " _
                                                    & txtcmnombre2.Value _
                                                    & " " _
                                                    & txtcmapellido1.Value _
                                                    & " " _
                                                    & txtcmapellido2.Value
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbprovinciaclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbcmprovincia.SelectedIndexChanged
        LlenaComboCiudad()
    End Sub

    Private Sub cmbciudadclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbcmciudad.SelectedIndexChanged
        LlenaComboParroquia()
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub numero_orden()
        lblnumeroorden.Text = OrdenPagoAdapter.ConsultaSecuenciaOrdenPago()
    End Sub

    Private Sub llenar_taller_turno(vehiculo As String)
        Dim dtcVehTaller As New System.Data.DataSet
        dtcVehTaller = VehiculoTurnoAdapter.ConsultaControles(5, vehiculo)
        cmbtallertur.DataSource = dtcVehTaller
        cmbtallertur.DataTextField = "DESCRIPCION"
        cmbtallertur.DataValueField = "CODIGO"
        cmbtallertur.DataBind()
    End Sub

    Private Sub carro_compra()
        Dim table As New System.Data.DataTable
        Dim valueCantidadRenovar As Integer = 0
        Dim valueCellPrecioUnitario As Decimal = 0
        Dim valueCellPrecioPromocion As Decimal = 0
        Dim valueCellPrecioSubtotal As Decimal = 0
        Dim valueCellPrecioIva As Decimal = 0
        Dim valueCellPrecioCliente As Decimal = 0
        Dim valueCellProducto As String = ""
        table = CType(Session("tblventas"), DataTable)
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                valueCantidadRenovar += 1
                valueCellPrecioUnitario += table.Rows(i)("PRECIO_VENTA")
                valueCellPrecioPromocion += table.Rows(i)("VALOR_PROMOCION")
                valueCellPrecioSubtotal += table.Rows(i)("PRECIO_TOTAL")
                valueCellPrecioIva += table.Rows(i)("IVA")
                valueCellPrecioCliente += table.Rows(i)("PRECIO_CLIENTE")
                valueCellProducto = table.Rows(i)("PRODUCTO")
                If valueCellProducto = "CC" Or valueCellProducto = "CM" Or valueCellProducto = "CH" Then
                    seccextras_cabecera.Visible = True
                    seccextras.Visible = True
                End If
            Next
            carro_compras(valueCellPrecioCliente, valueCantidadRenovar)
            lblresumencantidad.Text = valueCantidadRenovar
            lblresumentotal.Text = valueCellPrecioUnitario
            lblresumenpromocion.Text = valueCellPrecioPromocion
            lblresumensubtotal.Text = valueCellPrecioSubtotal
            lblresumeniva.Text = valueCellPrecioIva
            lblresumenpreciocliente.Text = valueCellPrecioCliente
        End If
    End Sub

    Private Sub resumen_compra()
        Dim table As New System.Data.DataTable
        Dim i As Integer = 0
        table = CType(Session("tblventas"), DataTable)
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
            llenar_taller_turno(distinctValues.Rows(i).Item("VEHICULO"))
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
            'ElseIf cmbtallertur.SelectedIndex = 0 Then
            '    retorno = False
            '    mensajeria_error("error", "por favor completar datos de taller del turno.")
            'ElseIf txttallerfecha.Text = "" Then
            '    retorno = False
            '    mensajeria_error("error", "por favor completar datos de fecha del turno.")
            'ElseIf txttallerhora.Text = "" Then
            '    retorno = False
            '    mensajeria_error("error", "por favor completar datos de hora del turno.")
        End If

        Return retorno
    End Function

    Private Function validar() As Boolean
        Dim retorno As Boolean = False

        If txtcmapellido1.Value = "" Then
            retorno = True
            txtcmapellido1.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar apellido paterno"
        ElseIf txtcmapellido2.Value = "" Then
            retorno = True
            txtcmapellido2.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar apellido materno"
        ElseIf txtcmnombre1.Value = "" Then
            retorno = True
            txtcmnombre1.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar primer nombre"
        ElseIf txtcmnombre2.Value = "" Then
            retorno = True
            txtcmnombre2.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar segundo nombre"
        ElseIf txtcmidentificacion.Value = "" Then
            retorno = True
            txtcmidentificacion.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar identificación del cliente"
        ElseIf txtcmdireccion.Value = "" Then
            retorno = True
            txtcmdireccion.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar dirección"
        ElseIf txtcminterseccion.Value = "" Then
            retorno = True
            txtcminterseccion.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar intersección de dirección"
        ElseIf txtcmcelular.Value.Substring(0, 1) <> "0" Then
            retorno = True
            txtcmcelular.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono celular válido"
        ElseIf txtcmcelular.Value.Length < 10 Then
            retorno = True
            txtcmcelular.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono celular válido"
        ElseIf txtcmtelefono.Value = "" Then
            retorno = True
            txtcmtelefono.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono fijo"
        ElseIf txtcmtelefono.Value.Length > 9 Or txtcmtelefono.Value.Length < 7 Then
            retorno = True
            txtcmtelefono.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono fijo válido"
        ElseIf txtcmemail.Value = "" Then
            retorno = True
            txtcmemail.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal"
        ElseIf Not txtcmemail.Value.Contains("@") Then
            retorno = True
            txtcmemail.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal válido"
        ElseIf Not txtcmemail.Value.Contains(".") Then
            retorno = True
            txtcmemail.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal válido"
        ElseIf cmbcmsexo.SelectedIndex < 1 Then
            retorno = True
            cmbcmsexo.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un género"
        ElseIf cmbcmidentificacion.SelectedIndex < 1 Then
            retorno = True
            cmbcmidentificacion.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un tipo de identificación"
        ElseIf cmbcmciudad.SelectedIndex < 1 Then
            retorno = True
            cmbcmciudad.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una ciudad"
        ElseIf cmbcmparroquia.SelectedIndex < 1 Then
            retorno = True
            cmbcmparroquia.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una parroquia"
        ElseIf cmbcmprovincia.SelectedIndex < 1 Then
            retorno = True
            cmbcmprovincia.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una provincia"
        ElseIf cmbcmsector.SelectedIndex < 1 Then
            retorno = True
            cmbcmsector.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un sector"
        ElseIf txtcmnfechanac1.Text > DateAdd(DateInterval.Year, -18, Date.Now) Then
            retorno = True
            txtcmnfechanac1.Focus()
            lblmensajeerror.InnerText = "Por favor ingrese fecha nacimiento del cliente válid"
        End If

        If cmbcmidentificacion.SelectedValue = "001" Or cmbcmidentificacion.SelectedValue = "002" Then
            If txtcmidentificacion.Value.Length < 10 Or txtcmidentificacion.Value.Length > 13 Then
                retorno = True
                txtcmidentificacion.Focus()
                lblmensajeerror.InnerText = "Por favor ingresar identificación válida"
            End If
        End If
        Return retorno
    End Function

    Private Sub genera_orden_web()
        Dim ordenEntity As New OrdenEntity
        Dim ordenDetalleEntity As OrdenDetalleEntity
        Dim ordenDetalleEntityCollection As New OrdenDetalleEntityCollection
        Dim datosVpos As String = secuencial_emisor(Session("IdTarjetaVpos"))
        Dim idemisor As String = datosVpos.Substring(2, 3)
        Dim secuencialemisor As Integer = datosVpos.Substring(2, 3)
        Dim secuencialsh As String = "000"
        Dim clientemonitoreo As String = Trim(txtDatoClientemonitoreo.Text)

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
        If Session("IdTarjetaVpos") = "PC" Then
            Session("Pacificard") = "1"
        Else
            Session("Pacificard") = "0"
        End If
        ordenEntity.OrdenId = 0
        ordenEntity.ClienteId = Session("user")
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
        ordenEntity.AccionComercial = "VEN"
        ordenEntity.ClienteMonitoreo = IIf(clientemonitoreo = "Cédula", "", clientemonitoreo)
        OrdenPagoAdapter.ConfirmoPagoOnline(ordenEntity)
        ordenEntity = New OrdenEntity
        numero_orden()
        Dim ordenId As String = lblnumeroorden.Text
        ordenEntity.OrdenId = ordenId
        ordenEntity.ClienteId = Session("user_id")
        ordenEntity.idemisor = secuencialemisor
        ordenEntity.NumeroMeses = 1
        ordenEntity.TipoTarjeta = Session("IdTarjetaVpos")
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
        ordenEntity.AccionComercial = "VEN"
        ordenEntity.ClienteMonitoreo = clientemonitoreo
        ordenEntity.UsuarioSoporte = IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE")
        Dim table As New System.Data.DataTable
        table = CType(Session("tblventas"), DataTable)
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
            ordenDetalleEntity.FechaVencimiento = Date.Now
            ordenDetalleEntityCollection.Add(ordenDetalleEntity)
        Next
        ordenEntity.OrdenDetalleEntityCollection = ordenDetalleEntityCollection
        Session("OrdenID") = ordenEntity.OrdenId
        lblnumeroorden.Text = ordenEntity.OrdenId
        OrdenPagoAdapter.RegistroPagoOnline(ordenEntity)

        Dim dTGetInfoUrlTecnico As New DataTable()
        dTGetInfoUrlTecnico.Columns.Add("datatecnica", GetType(String))
        dTGetInfoUrlTecnico.Rows.Add(ordenEntity.OrdenId)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoIdnt)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoNomb)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoDirc)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoCell)
        dTGetInfoUrlTecnico.Rows.Add(valueFormaPagoEmail)
        dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))
        dTGetInfoUrlTecnico.Rows.Add(Libreria.Parse(lblresumenpreciocliente.Text))
        dTGetInfoUrlTecnico.Rows.Add(lblresumensubtotal.Text)
        dTGetInfoUrlTecnico.Rows.Add(0) 'descuentos
        dTGetInfoUrlTecnico.Rows.Add(0) 'promociones
        dTGetInfoUrlTecnico.Rows.Add(lblresumeniva.Text)
        dTGetInfoUrlTecnico.Rows.Add(idemisor)
        dTGetInfoUrlTecnico.Rows.Add("VEN")
        If cmbtallertur.SelectedIndex > 0 Then
            Dim fecha As String = txttallerfecha.Text
            Dim hora As String = txttallerhora.Text
            Dim datetimestr As String = fecha & " " & hora
            Dim TurnoDateTime As Date = datetimestr '#1/27/2001 5:04:23 PM#

            dTGetInfoUrlTecnico.Rows.Add(Date.Now)
            dTGetInfoUrlTecnico.Rows.Add(txttallerhora.Text)
            dTGetInfoUrlTecnico.Rows.Add(cmbtallertur.SelectedIndex)
        Else
            dTGetInfoUrlTecnico.Rows.Add(Date.Now)
            dTGetInfoUrlTecnico.Rows.Add("00:00")
            dTGetInfoUrlTecnico.Rows.Add(0)
        End If
        dTGetInfoUrlTecnico.Rows.Add(IIf(Session("IdTipoPagoVpos") = 1, 0, Session("IdTipoPagoVpos")))

        'EMailHandler.EMailGeneracionOrdenPago("Registro de orden de pago exitoso <<inicio boton de pago>>.", Session("OrdenID"), Session("iphost"))
        Session("DTGetInfoURLTecnico") = dTGetInfoUrlTecnico

        'If VposAnterior(Session("IdTarjetaVpos")) = "MC" Or VposAnterior(Session("IdTarjetaVpos")) = "VI" Then
        '    Response.Redirect("cotizadorweburltecnicopaymentez.aspx", False)
        'ElseIf VposAnterior(Session("IdTarjetaVpos")) = "DN" Then
        '    Response.Redirect("cotizadorweburltecnico.aspx", False)
        'End If

        Try
            'GENERA ORDENES SIN PASAR POR PAGOS PARA DESARROLLO
            Dim estado As String = 6
            Dim mensaje As String = "OK"
            Dim id_transaccion As String = "7777777"
            Dim tNo_value_final As String = Session("OrdenID")
            Dim log_opcion As Integer = 0
            Dim opcion_mail As String = ""
            Dim estadoAutorizacion As String = ""
            Dim log_mensaje As String = ""
            Dim valor As Decimal = lblresumenpreciocliente.Text
            Dim value_actestadoorden As Integer = 0
            estado = "Aprobado"
            log_opcion = 20
            opcion_mail = "100"
            estadoAutorizacion = "O"
            log_mensaje = "Transacción Exitosa, Por favor revise su email con el detalle de la transacción."
            Session("DTCarroCompraMasterTableView") = Nothing
            value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estadoAutorizacion, id_transaccion, _
                                                                            tNo_value_final, "1", "DN", 0, 0, _
                                                                            valor, 0, Session("user"), id_transaccion, "BANCO PRUEBA", "1234", "PRUEBA{}")
            RenovacionAdapter.GeneraOrdenServicio(tNo_value_final)
            Response.Redirect("mistransacciones.aspx", False)
        Catch ex As Exception
            mensajeria_error("error", ex.Message.ToString)
        End Try

    End Sub

    Private Function secuencial_emisor(id_emisor As String) As String
        Dim retorno As String = ""

        Dim dTCstEmisor As New System.Data.DataSet
        dTCstEmisor = RenovacionAdapter.ConsultaEmisorDetalleVpos(id_emisor, "NO")
        If dTCstEmisor.Tables(0).Rows.Count > 0 Then
            retorno = dTCstEmisor.Tables(0).Rows(0).Item("SECUENCIAL")
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
            retorno = "DI"
        ElseIf id_emisor = "PC" Then
            retorno = "VI"
        ElseIf id_emisor = "AM" Then
            retorno = "DN"
        ElseIf id_emisor = "TI" Then
            retorno = "DN"
        End If

        Return retorno
    End Function

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        If tipo = "error" Then
            dvdmensajes.Attributes.Add("class", "messages error")
            dvdmensajes.Visible = True
            Session("errorbandera") = "1"
        ElseIf tipo = "alerta" Then
            dvdmensajes.Attributes.Add("class", "messages alert")
            dvdmensajes.Visible = True
            Session("errorbandera") = "1"
        ElseIf tipo = "informacion" Then
            dvdmensajes.Attributes.Add("class", "messages sucess")
            dvdmensajes.Visible = True
            Session("errorbandera") = "1"
        ElseIf tipo = "" Then
            dvdmensajes.Visible = False
            Session("errorbandera") = "0"
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

    Private Sub LlenaComboCiudad()
        Try
            cmbcmciudad.DataSource = ""
            cmbcmciudad.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("121", "001", cmbcmprovincia.SelectedValue, "", "")
            poblar_combo(cmbcmciudad, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LlenaComboParroquia()
        Try
            cmbcmparroquia.DataSource = ""
            cmbcmparroquia.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("122", "", cmbcmparroquia.SelectedValue, cmbcmciudad.SelectedValue, "")
            poblar_combo(cmbcmparroquia, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub poblar_combo(ByVal combo As DropDownList, ByVal tabla As DataTable)
        Try
            combo.DataSource = tabla
            combo.DataTextField = "DESCRIPCION"
            combo.DataValueField = "CODIGO"
            combo.DataBind()
            combo.SelectedIndex = 0
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub llenainfodatos()
        Try
            'CLIENTE
            llenar_combos_fact()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub llenar_combos_fact()
        Try
            'CONSULTA TRAE VARIAS TABLAS CON RESULTADOS
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaCatalogosMonitoreo()
            'TIPO IDENTIFICACION
            poblar_combo(cmbcmidentificacion, dTDatosCliente.Tables(0))
            poblar_combo(cmbcmsexo, dTDatosCliente.Tables(8))
            poblar_combo(cmbcmprovincia, dTDatosCliente.Tables(11))
            poblar_combo(cmbcmciudad, dTDatosCliente.Tables(12))
            poblar_combo(cmbcmparroquia, dTDatosCliente.Tables(13))
            poblar_combo(cmbcmsector, dTDatosCliente.Tables(14))
            Dim dTDatosProvincia As New DataSet
            dTDatosProvincia = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("120", "001", "", "", "")
            poblar_combo(cmbcmprovincia, dTDatosProvincia.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub pasar_datos_existe(ByVal ID As String)
        If Not ID Is Nothing Or ID <> "" Then
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreoDatos(ID)
            If Not dTDatosCliente Is Nothing Then
                txtDatoClientemonitoreo.Text = ID
                txtNombreClientemonitoreo.Text = dTDatosCliente.Tables(0).Rows(0).Item("PRIMER_NOMBRE").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("SEGUNDO_NOMBRE").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_PATERNO").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_MATERNO").ToString
            End If
        End If
    End Sub

#End Region

End Class