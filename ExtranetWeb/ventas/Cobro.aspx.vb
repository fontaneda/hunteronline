Imports Telerik.Web.UI
Imports System.Drawing
Imports System.Globalization
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography

Public Class Cobro
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                metodos_master("Pago de Facturas pendientes", 7, "Cobro de facturas")
                mensajeria_error("", "")
                'txtdesdemtr.Text = DateTime.Parse("1/1/" & Date.Now.Year).ToString("yyyy-MM-dd")
                'txthastamtr.Text = DateTime.Parse(Date.Now.Day & "/" & Date.Now.Month & "/" & Date.Now.Year).ToString("yyyy-MM-dd")
                If Session("Administrador") = "ADM" Or Session("Administrador") = "APV" Or Session("Administrador") = "USR" Then
                    btnlink.Visible = True
                Else
                    btnlink.Visible = False
                End If
                consulta_inicial()
            Else
                Response.Redirect("./login.aspx", False)
            End If
        End If
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub chkemisoramerican_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisoramerican.ServerChange
        If chkemisoramerican.Checked Then
            Session("IdTarjetaVpos") = "AM"
        End If
    End Sub

    Private Sub chkemisordiners_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisordiners.ServerChange
        If chkemisordiners.Checked Then
            Session("IdTarjetaVpos") = "DN"
        End If
    End Sub

    Private Sub chkemisordiscover_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisordiscover.ServerChange
        If chkemisordiscover.Checked Then
            Session("IdTarjetaVpos") = "DN"
        End If
    End Sub

    Private Sub chkemisormastercard_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisormastercard.ServerChange
        If chkemisormastercard.Checked Then
            Session("IdTarjetaVpos") = "MC"
        End If
    End Sub

    Private Sub chkemisorpacificard_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisorpacificard.ServerChange
        If chkemisorpacificard.Checked Then
            Session("IdTarjetaVpos") = "PC"
        End If
    End Sub

    Private Sub chkemisortitanium_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisortitanium.ServerChange
        If chkemisortitanium.Checked Then
            Session("IdTarjetaVpos") = "TI"
        End If
    End Sub

    Private Sub chkemisorvisa_ServerChange(sender As Object, e As System.EventArgs) Handles chkemisorvisa.ServerChange
        If chkemisorvisa.Checked Then
            Session("IdTarjetaVpos") = "VI"
        End If
    End Sub

    'Private Sub btnfiltro_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltro.ServerClick
    '    consulta_inicial()
    'End Sub

    Private Sub cmbtipopago_ServerChange(sender As Object, e As System.EventArgs) Handles cmbtipopago.ServerChange
        If cmbtipopago.SelectedIndex > 0 Then
            Session("IdTipoPagoVpos") = cmbtipopago.Value
        Else
            Session("IdTipoPagoVpos") = ""
        End If
    End Sub

    Private Sub btnpagar_Click(sender As Object, e As System.EventArgs) Handles btnpagar.Click
        Try
            genera_orden_web()
            If (VposAnterior(Session("IdTarjetaVpos")) = "MC" Or VposAnterior(Session("IdTarjetaVpos")) = "VI" _
                Or VposAnterior(Session("IdTarjetaVpos")) = "PC") Then
                Response.Redirect("cotizadorweburltecnicopaymentez.aspx", False)
            ElseIf (VposAnterior(Session("IdTarjetaVpos")) = "DN" Or VposAnterior(Session("IdTarjetaVpos")) = "DI" _
                        Or VposAnterior(Session("IdTarjetaVpos")) = "AM" Or VposAnterior(Session("IdTarjetaVpos")) = "TI" _
                        Or VposAnterior(Session("IdTarjetaVpos")) = "PI") Then
                Response.Redirect("cotizadorweburltecnico.aspx", False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

#Region "Consultas generales"

    Private Sub consulta_inicial()
        Dim dTDatostipoPago As New DataSet
        dTDatostipoPago = RenovacionAdapter.ConsultaTipoPago()
        If dTDatostipoPago.Tables(0).Rows.Count > 0 Then
            cmbtipopago.DataSource = dTDatostipoPago
            cmbtipopago.DataValueField = "CODIGO"
            cmbtipopago.DataTextField = "DESCRIPCION"
            cmbtipopago.DataBind()
        Else
            cmbtipopago.DataSource = Nothing
            cmbtipopago.DataBind()
        End If

        Dim dTDatosDeudas As DataTable
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaDeudas").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDeudas").ToString()
        dTDatosDeudas = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "cons_saldo_cliente", Session("user_netsuite"), ""))
        If dTDatosDeudas.Rows.Count > 0 Then
            lblresumencantidad.Text = "$ " & dTDatosDeudas.Rows(0).Item("importeporpagar").ToString
            Me.Rpt_cobros.DataSource = dTDatosDeudas
            Me.Rpt_cobros.DataBind()
        Else
            txtmonto.Attributes.Add("placeholder", "$ 0.00")
            mensajeria_error("alerta", "usted no registra facturas pendientes de pago.")
        End If
    End Sub

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

    Private Function secuencial_emisor(id_emisor As String) As String
        Dim retorno As String = ""

        Dim dTCstEmisor As New System.Data.DataSet
        dTCstEmisor = RenovacionAdapter.ConsultaEmisorDetalleVpos(id_emisor, "NO")
        If dTCstEmisor.Tables(0).Rows.Count > 0 Then
            retorno = dTCstEmisor.Tables(0).Rows(0).Item("SECUENCIAL")
            Session("id_metodopago_ns") = dTCstEmisor.Tables(0).Rows(0).Item("RELACION_NS")
            Session("id_emisor_ns") = dTCstEmisor.Tables(0).Rows(0).Item("EMISOR_NS")
        Else
            Session("id_metodopago_ns") = ""
            Session("id_emisor_ns") = ""
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

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Function datos_info_factura(tipo As String) As String
        Dim retorno As String = ""
        Try
            Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            'CLIENTE
            If tipo = "NOMBRE_COMPLETO" Then
                Dim dTDatosDireccion As New DataTable
                dTDatosDireccion = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "101", "", Session("user_netsuite"), "", "", ""))
                If dTDatosDireccion.Rows.Count > 0 Then
                    retorno = dTDatosDireccion.Rows(0)("NombreCliente")
                End If
            End If
            'DIRECCION
            If tipo = "DIRECCION" Then
                Dim dTDatosDireccion As New DataTable
                dTDatosDireccion = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "101", "", Session("user_netsuite"), "", "", ""))
                If dTDatosDireccion.Rows.Count > 0 Then
                    retorno = dTDatosDireccion.Rows(0)("Direccion1")
                End If
            End If
            'TELEFONO
            If tipo = "TELEFONO" Then
                Dim dTDatotelefono As New DataTable
                Dim dTtelefono As New DataTable
                dTtelefono = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "102", "", Session("user_netsuite"), "", "", ""))
                If dTtelefono.Rows.Count > 0 Then
                    If dTtelefono.Select("IdTipoTelefono in(10,18)").Count > 0 Then
                        dTDatotelefono = dTtelefono.Select("IdTipoTelefono in(10,18)").CopyToDataTable().DefaultView.ToTable
                        retorno = dTDatotelefono.Rows(0)("Telefono")
                    End If
                End If
            End If
            'CELULAR
            If tipo = "CELULAR" Then
                Dim dTDatoscelular As New DataTable
                Dim dTtelefono As New DataTable
                dTtelefono = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "102", "", Session("user_netsuite"), "", "", ""))
                If dTtelefono.Rows.Count > 0 Then
                    If dTtelefono.Select("IdTipoTelefono in(4,19)").Count > 0 Then
                        dTDatoscelular = dTtelefono.Select("IdTipoTelefono in(4,19)").CopyToDataTable().DefaultView.ToTable
                        retorno = dTDatoscelular.Rows(0)("Telefono")
                    End If
                End If
            End If
            'EMAIL
            If tipo = "EMAIL" Then
                Dim dTDatosEMail As New DataTable
                Dim dTEMail As New DataTable
                dTEMail = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "103", "", Session("user_netsuite"), "", "", ""))
                If dTEMail.Rows.Count > 0 Then
                    If dTEMail.Select("IdTipoCorreo in(1,6,5,7)").Count > 0 Then
                        dTDatosEMail = dTEMail.Select("IdTipoCorreo in(1,6,5,7)").CopyToDataTable().DefaultView.ToTable
                        retorno = dTDatosEMail.Rows(0)("Email")
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function

    Private Sub genera_orden_web()
        Try
            Dim conv_valor_total As Decimal = 0
            Dim conv_valor_abono As Decimal = 0
            Dim monto_minimo_abono As Decimal = 10
            Dim dTGetInfoUrlTecnico As New DataTable()

            If txtmonto.Text = "" Then
                txtmonto.Text = 0
            End If

            If lblresumencantidad.Text = "$ " Then
                conv_valor_total = 0
            Else
                conv_valor_total = Convert.ToDecimal(Trim(lblresumencantidad.Text.Replace("$", "")))
            End If
            conv_valor_abono = Convert.ToDecimal(Trim(txtmonto.Text.Replace("$", "")))

            If Not (Session("Administrador") = "ADM" Or Session("Administrador") = "USR" Or Session("Administrador") = "CON" Or Session("Administrador") = "APV") Then
                If conv_valor_abono > conv_valor_total Then
                    mensajeria_error("error", "monto abonar no puede ser mayor a deuda total.")
                    Exit Sub
                End If
            End If
            If conv_valor_abono < monto_minimo_abono Then
                mensajeria_error("error", "monto abonar no tiene el monto minimo requerido(" & Convert.ToString(monto_minimo_abono) & ").")
                Exit Sub
            ElseIf cmbtipopago.SelectedIndex <= 0 Then
                mensajeria_error("error", "<<Para continuar usted debe seleccionar mínimo un Banco Emisor.>>")
                Exit Sub
            Else
                Dim ordenId As String = OrdenPagoAdapter.ConsultaSecuenciaOrdenPago()
                Session("IdOrdenVpos") = ordenId

                If Session("IdTarjetaVpos") = "PC" Then
                    Session("Pacificard") = "1"
                Else
                    Session("Pacificard") = "0"
                End If
                Dim ordenEntity As New OrdenEntity
                Dim ordenDetalleEntityCollection As New OrdenDetalleEntityCollection
                Dim datosVpos As String = secuencial_emisor(Session("IdTarjetaVpos"))
                Dim idemisor As String = datosVpos.Substring(2, 3)
                Dim secuencialemisor As Integer = datosVpos.Substring(2, 3)
                Dim secuencialsh As String = "000"
                Dim porcentaje_iva As Decimal = OrdenPagoAdapter.ConsultaPorcentajeIva()
                Dim valor_subtotal As Decimal = conv_valor_abono
                Dim valor_iva As Decimal = 0
                Dim valor_total As Decimal = conv_valor_abono
                Dim pago_nombre, pago_direccion, pago_telefono, pago_celular, pago_email, pago_cliente As String

                pago_nombre = datos_info_factura("NOMBRE_COMPLETO")
                pago_direccion = datos_info_factura("DIRECCION")
                pago_telefono = datos_info_factura("TELEFONO")
                pago_celular = datos_info_factura("CELULAR")
                pago_email = datos_info_factura("EMAIL")

                If pago_direccion = "" Or pago_telefono = "" Or pago_celular = "" Or pago_email = "" Then
                    If (Session("Administrador") = "ADM" Or Session("Administrador") = "USR" Or Session("Administrador") = "CON" Or Session("Administrador") = "APV") Then
                        If Session("Direccion") <> "" Or Session("Telefono") <> "" Or Session("Celular") <> "" Or Session("Email") <> "" Then
                            pago_direccion = IIf(pago_direccion = "", Session("Direccion"), pago_direccion)
                            pago_telefono = IIf(pago_telefono = "", Session("Celular"), pago_telefono)
                            pago_celular = IIf(pago_celular = "", Session("Celular"), pago_celular)
                            pago_email = IIf(pago_email = "", Session("Email"), pago_email)
                        End If
                    Else
                        mensajeria_error("error", "no se pudo obtener sus datos.")
                        Exit Sub
                    End If
                End If

                ordenEntity = New OrdenEntity
                ordenEntity.OrdenId = ordenId
                ordenEntity.ClienteId = Session("user_id")
                ordenEntity.idemisor = secuencialemisor
                ordenEntity.NumeroMeses = 1
                ordenEntity.TipoTarjeta = VposAnterior(Session("IdTarjetaVpos"))
                ordenEntity.SubTotal = valor_subtotal
                ordenEntity.Iva = valor_iva
                ordenEntity.Ice = 0
                ordenEntity.Interes = 0
                ordenEntity.Total = valor_total
                ordenEntity.TipoPago = 0
                ordenEntity.TipoCredito = "00"
                ordenEntity.CodigoConfPago = 0
                ordenEntity.BillingName = pago_nombre
                ordenEntity.BillingCedula = Session("user_id")
                ordenEntity.BillingAddress = pago_direccion
                ordenEntity.BillingPhone = pago_telefono
                ordenEntity.BillingMovil = pago_celular
                ordenEntity.BillingEmail = pago_email
                ordenEntity.BillingCardType = 0
                ordenEntity.EstadoWebId = 1
                ordenEntity.UsuarioProcesoId = 0
                ordenEntity.AccionComercial = "COB"
                ordenEntity.UsuarioSoporte = IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE")
                CobroAdapter.RegistroPagoOnline(ordenEntity)

                Session("OrdenID") = ordenEntity.OrdenId
                dTGetInfoUrlTecnico.Columns.Add("datatecnica", GetType(String))
                dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))
                dTGetInfoUrlTecnico.Rows.Add(Session("user_id"))
                dTGetInfoUrlTecnico.Rows.Add(pago_nombre)
                dTGetInfoUrlTecnico.Rows.Add(pago_direccion)
                dTGetInfoUrlTecnico.Rows.Add(pago_celular)
                dTGetInfoUrlTecnico.Rows.Add(pago_email)
                dTGetInfoUrlTecnico.Rows.Add(ordenId)
                dTGetInfoUrlTecnico.Rows.Add(valor_total)
                dTGetInfoUrlTecnico.Rows.Add(valor_total)
                dTGetInfoUrlTecnico.Rows.Add(0)
                dTGetInfoUrlTecnico.Rows.Add(0)
                dTGetInfoUrlTecnico.Rows.Add(valor_iva)
                dTGetInfoUrlTecnico.Rows.Add(idemisor)
                dTGetInfoUrlTecnico.Rows.Add("COB")
                dTGetInfoUrlTecnico.Rows.Add(Date.Now)
                dTGetInfoUrlTecnico.Rows.Add("00:00")
                dTGetInfoUrlTecnico.Rows.Add(0)
                dTGetInfoUrlTecnico.Rows.Add(Session("IdTipoPagoVpos")) 'IIf(Session("IdTipoPagoVpos") = 1, 0, 3))
                dTGetInfoUrlTecnico.Rows.Add("WEB")                     '18
                EMailHandler.EMailGeneracionOrdenPago("Hunter Online", "Registro de orden de pago exitoso <<inicio boton de pago>>.", Session("IdOrdenVpos"), Session("iphost"))
                Session("DTGetInfoURLTecnico") = dTGetInfoUrlTecnico
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
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

End Class