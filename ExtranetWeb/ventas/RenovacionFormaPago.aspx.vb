Public Class RenovacionFormaPago
    Inherits System.Web.UI.Page

    Dim valorTotal As Double


#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MetodosMaster("Renovación de Servicios por Forma de Pago", 3, "Formas de Pago")
                MensajeriaError("", "")
                CarroCompra()
                LlenaInfoFactura()
                llenainfodatos()
                LimpiaControles()
                Habilita_Control(False, "1")
                CargarListas()
                InicializarControl()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



#End Region

#Region "Procedimientos Generales"

    Protected Sub Habilita_Control(ByVal valor As Boolean, ByVal opcion As String)
        Try

            If opcion = "1" Then
                'Cbxforma.Enabled = valor
                Cbxbanco.Enabled = valor
                Cbxplazo.Enabled = valor
                txtvalor.Enabled = valor
                txtdocumento.Enabled = valor
                txtvoucher.Enabled = valor
                'btnagregardatos.Enabled = valor
            End If

            If opcion = "2" Then
                Cbxbanco.Enabled = valor
                txtvalor.Enabled = valor
                txtdocumento.Enabled = valor

            End If

            If opcion = "4" Then

                Cbxforma.Enabled = valor
                txtvalor.Enabled = valor
                Cbxbanco.Enabled = valor
                txtdocumento.Enabled = valor
                'btnagregardatos.Enabled = valor

            End If
            If opcion = "5" Then
                txtvalor.Enabled = valor
                Cbxbanco.Enabled = Not valor
                Cbxplazo.Enabled = Not valor
                txtdocumento.Enabled = Not valor
                txtvoucher.Enabled = Not valor

                'btnagregardatos.Enabled = valor
            End If
            If opcion = "6" Then
                Cbxforma.Enabled = valor
                txtvalor.Enabled = valor
                Cbxbanco.Enabled = valor
                Cbxplazo.Enabled = valor
                txtdocumento.Enabled = valor
                txtvoucher.Enabled = valor
                'btnagregardatos.Enabled = valor
            End If

            If opcion = "8" Then
                Cbxplazo.Enabled = valor
                txtvoucher.Enabled = valor
            End If

            If opcion = "10" Then
                txtdocumento.Enabled = valor
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



    Private Sub MetodosMaster(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub


    Private Sub MensajeriaError(tipo As String, mensaje As String)
        lblmensajeexternoerror.InnerText = "Estimado Cliente, " & mensaje
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


    Private Function Tablafacturacion() As DataTable
        Dim table As New System.Data.DataTable
        Dim column As DataColumn
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoIdentificacion"
        column.AutoIncrement = False
        column.Caption = "FormaPagoIdentificacion"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoNombre"
        column.AutoIncrement = False
        column.Caption = "FormaPagoNombre"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoDireccion"
        column.AutoIncrement = False
        column.Caption = "FormaPagoDireccion"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoTelefono"
        column.AutoIncrement = False
        column.Caption = "FormaPagoTelefono"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoCelular"
        column.AutoIncrement = False
        column.Caption = "FormaPagoCelular"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoEmail"
        column.AutoIncrement = False
        column.Caption = "FormaPagoEmail"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        Return table
    End Function


    Private Sub CargarListas()
        Try
            Dim dtListas As DataSet
            dtListas = RenovacionAdapter.CargaForma("21")
            If dTListas.Tables(0).Rows.Count > 0 Then
                Me.Cbxforma.DataSource = dTListas
                Me.Cbxforma.DataTextField = "DESCRIPCION"
                Me.Cbxforma.DataValueField = "CODIGO"
                Cbxforma.DataBind()
            End If

            Dim dtPlazo As DataSet
            dTPlazo = RenovacionAdapter.CargaForma("17")
            If dTPlazo.Tables(0).Rows.Count > 0 Then
                Me.Cbxplazo.DataSource = dTPlazo
                Me.Cbxplazo.DataTextField = "DESCRIPCION"
                Me.Cbxplazo.DataValueField = "CODIGO"
                Cbxplazo.DataBind()
            End If

            CargaBanco()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargaBanco()
        Try
            Dim dtBanco As DataSet
            dtBanco = RenovacionAdapter.CargaForma("2")
            If dtBanco.Tables(0).Rows.Count > 0 Then
                Me.Cbxbanco.DataSource = dtBanco
                Me.Cbxbanco.DataTextField = "DESCRIPCION"
                Me.Cbxbanco.DataValueField = "CODIGO"
                Cbxbanco.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub CargaTarjeta()
        Try
            Dim dtBanco As DataSet
            dtBanco = RenovacionAdapter.CargaForma("3")
            If dtBanco.Tables(0).Rows.Count > 0 Then
                Me.Cbxbanco.DataSource = dtBanco
                Me.Cbxbanco.DataTextField = "DESCRIPCION"
                Me.Cbxbanco.DataValueField = "CODIGO"
                Cbxbanco.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub InicializarControl()
        Try
            Cbxforma.SelectedValue = "NN"
            Cbxbanco.SelectedValue = "NN"
            Cbxplazo.SelectedValue = "NN"
            txtfecha.Text = DateTime.Parse(Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year).ToString("yyyy-MM-dd")
            Dim dtDetalle As New DataTable()
            dtDetalle.Columns.Add("DETALLE_ID", GetType(String))
            dtDetalle.Columns.Add("CODIGO_FORMA", GetType(String))
            dtDetalle.Columns.Add("FORMA_PAGO", GetType(String))
            dtDetalle.Columns.Add("CODIGO_BANCO", GetType(String))
            dtDetalle.Columns.Add("BANCO", GetType(String))
            dtDetalle.Columns.Add("VALOR", GetType(Decimal))
            dtDetalle.Columns.Add("DOCUMENTO", GetType(String))
            dtDetalle.Columns.Add("PLAZO", GetType(String))
            dtDetalle.Columns.Add("VOUCHER", GetType(String))
            dtDetalle.Columns.Add("FECHA_CHEQUE", GetType(String))

            Session("DetalleForma") = dtDetalle
            RptdetalleForma.DataSource = dtDetalle
            RptdetalleForma.DataBind()

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LimpiaControles()
        Try
            txtvalor.Text = 0
            txtdocumento.Text = ""
            txtvoucher.Text = ""
            lblbanco.Text = "Banco "
            lbltotal.Text = "0"
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub AdicionarRegistro()
        Try
            Dim dtDetalle As New DataTable()
            Dim dtv As DataRow
            dtDetalle = Session("DetalleForma")
            Dim validacion As Boolean = True
            For i As Integer = 0 To dtDetalle.Rows.Count - 1
                If dtDetalle.Rows(i).Item("VALOR") = txtvalor.Text And dtDetalle.Rows(i).Item("CODIGO_FORMA") = Cbxforma.SelectedValue And dtDetalle.Rows(i).Item("FORMA_PAGO") = Cbxforma.SelectedItem.Text _
                   And dtDetalle.Rows(i).Item("VOUCHER") = txtvoucher.Text And dtDetalle.Rows(i).Item("BANCO") = Cbxbanco.SelectedItem.Text And dtDetalle.Rows(i).Item("DOCUMENTO") = txtdocumento.Text Then
                    Me.RptdetalleForma.DataSource = dtDetalle
                    Me.RptdetalleForma.DataBind()
                    validacion = False
                    Exit For
                Else
                    validacion = True
                End If
            Next
            If validacion Then
                dtv = dtDetalle.NewRow()
                dtv("CODIGO_FORMA") = Cbxforma.SelectedValue
                dtv("FORMA_PAGO") = Cbxforma.SelectedItem.Text

                dtv("FECHA_CHEQUE") = "1900-01-01"
                If Cbxforma.SelectedValue = "DE" Then
                    dtv("CODIGO_BANCO") = ""
                Else
                    dtv("CODIGO_BANCO") = Cbxbanco.SelectedValue
                End If

                If Cbxforma.SelectedValue = "CP" Then 'Cheque a fecha
                    Session("tiponuevo") = "RTC"
                End If
                If Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Then 'Cheque a Vista O Cheque a fecha
                    'dtv("FECHA_CHEQUE") = txtfecha.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "-")
                    dtv("FECHA_CHEQUE") = txtfecha.Text.Replace("/", "-")
                End If
                If Cbxbanco.SelectedValue = "NN" Then
                    dtv("CODIGO_BANCO") = ""
                End If
                If Cbxplazo.SelectedValue = "NN" Then
                    dtv("PLAZO") = ""
                Else
                    dtv("PLAZO") = Cbxplazo.SelectedValue
                End If
                
                dtv("VOUCHER") = txtvoucher.Text
                dtv("BANCO") = Cbxbanco.SelectedItem.Text
                dtv("VALOR") = Convert.ToDecimal(txtvalor.Text).ToString("#,##0.00")
                dtv("DOCUMENTO") = txtdocumento.Text
                dtv("DETALLE_ID") = dtDetalle.Rows.Count + 1
                dtDetalle.Rows.Add(dtv)

                For i As Integer = 0 To dtDetalle.Rows.Count - 1
                    valorTotal += dtDetalle.Rows(i).Item("VALOR")
                Next
                lbltotal.Text = valorTotal.ToString("#,##0.00")

                Me.RptdetalleForma.DataSource = dtDetalle
                Me.RptdetalleForma.DataBind()
                Session("DetalleForma") = dtDetalle
                txtvalor.Text = 0
                txtdocumento.Text = ""
                Cbxforma.SelectedValue = "NN"
                Cbxbanco.SelectedValue = "NN"
                Cbxplazo.SelectedValue = "NN"
                txtvoucher.Text = ""
                txtfecha.Text = DateTime.Parse(Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year).ToString("yyyy-MM-dd")
                MensajeriaError("", "")

            Else
                MensajeriaError("error", "Datos no pueden ser repetidos")
            End If
           
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub CarroCompra()
        Dim table As New System.Data.DataTable
        Dim valueCantidadRenovar As Integer = 0
        Dim valueCellPrecioCliente As Decimal = 0
        table = CType(Session("tblrenovaciones"), DataTable)
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                valueCantidadRenovar += 1
                valueCellPrecioCliente += table.Rows(i)("PRECIO_CLIENTE")
            Next
            CarroCompras(valueCellPrecioCliente, valueCantidadRenovar)
        End If
    End Sub


    Private Sub CarroCompras(valor As String, cantidad As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.cantidadMaster = cantidad
        myMasterPage.totalMaster = valor
    End Sub


    Private Sub LlenaInfoFactura()
        Dim dTCstFactura As New System.Data.DataSet
        dTCstFactura = RenovacionAdapter.ConsultaDatosCliente(Session.Item("user"))
        If dTCstFactura.Tables(0).Rows.Count > 0 Then
            txtFormaPagoNombre.Text = dTCstFactura.Tables(0).Rows(0)("NOMBRE_COMPLETO")
            txtFormaPagoIdentificacion.Text = dTCstFactura.Tables(0).Rows(0)("ID_CLIENTE")
            txtFormaPagoDireccion.Text = dTCstFactura.Tables(0).Rows(0)("DIRECCION")
            txtFormaPagoTelefono.Text = dTCstFactura.Tables(0).Rows(0)("TELEFONO")
            txtFormaPagoCelular.Text = dTCstFactura.Tables(0).Rows(0)("CELULAR")
            txtFormaPagoEmail.Text = dTCstFactura.Tables(0).Rows(0)("EMAIL")
        End If
    End Sub

    Private Sub LlenaInfoDatos()
        Try
            'CLIENTE
            LlenarCombosFact()
            'DIRECCION
            Dim dTDatosDireccion As New DataSet
            dTDatosDireccion = DatosPersonalesAdapter.ConsultaDatosDireccionCliente(Session.Item("user"))
            If dTDatosDireccion.Tables(0).Rows.Count > 0 Then
                Rptdireccionfac.DataSource = dTDatosDireccion
                Rptdireccionfac.DataBind()
            Else
                Rptdireccionfac.DataSource = Nothing
                Rptdireccionfac.DataBind()
            End If
            'TELEFONO
            Dim dTDatotelefono As New DataSet
            dTDatotelefono = DatosPersonalesAdapter.ConsultaDatosTelefonoCliente(Session.Item("user"), "001")
            If dTDatotelefono.Tables(0).Rows.Count > 0 Then
                Rpttelefonofac.DataSource = dTDatotelefono
                Rpttelefonofac.DataBind()
            Else
                Rpttelefonofac.DataSource = Nothing
                Rpttelefonofac.DataBind()
            End If
            'CELULAR
            Dim dTDatoscelular As New DataSet
            dTDatoscelular = DatosPersonalesAdapter.ConsultaDatosTelefonoCliente(Session.Item("user"), "004")
            If dTDatoscelular.Tables(0).Rows.Count > 0 Then
                Rptcelularfac.DataSource = dTDatoscelular
                Rptcelularfac.DataBind()
            Else
                Rptcelularfac.DataSource = Nothing
                Rptcelularfac.DataBind()
            End If
            'EMAIL
            Dim dTDatosEMail As New DataSet
            dTDatosEMail = DatosPersonalesAdapter.ConsultaDatosEmailCliente(Session.Item("user"))
            If dTDatosEMail.Tables(0).Rows.Count > 0 Then
                Rptemailfac.DataSource = dTDatosEMail
                Rptemailfac.DataBind()
            Else
                Rptemailfac.DataSource = Nothing
                Rptemailfac.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub LlenarCombosFact()
        Try
            'CONSULTA TRAE VARIAS TABLAS CON RESULTADOS
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaCatalogosMonitoreo()
            'TIPO IDENTIFICACION
            PoblarCombo(cmbcedulaclientefac, dTDatosCliente.Tables(0))
            PoblarCombo(cmbsexoclientefac, dTDatosCliente.Tables(8))
            PoblarCombo(cmbprovinciaclientefac, dTDatosCliente.Tables(11))
            PoblarCombo(cmbciudadclientefac, dTDatosCliente.Tables(12))
            PoblarCombo(cmbparroquiaclientefac, dTDatosCliente.Tables(13))
            PoblarCombo(cmbsectorclientefac, dTDatosCliente.Tables(14))
            Dim dTDatosProvincia As New DataSet
            dTDatosProvincia = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("120", "001", "", "", "")
            PoblarCombo(cmbprovinciaclientefac, dTDatosProvincia.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub LlenaComboCiudad()
        Try
            cmbciudadclientefac.DataSource = ""
            cmbciudadclientefac.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("121", "001", cmbprovinciaclientefac.SelectedValue, "", "")
            PoblarCombo(cmbciudadclientefac, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LlenaComboParroquia()
        Try
            cmbparroquiaclientefac.DataSource = ""
            cmbparroquiaclientefac.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("122", "", cmbprovinciaclientefac.SelectedValue, cmbciudadclientefac.SelectedValue, "")
            PoblarCombo(cmbparroquiaclientefac, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub PoblarCombo(ByVal combo As DropDownList, ByVal tabla As DataTable)
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


    Private Sub PasarDatosExiste(ByVal id As String)
        If Not ID Is Nothing Or ID <> "" Then
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreoDatos(ID)
            If Not dTDatosCliente Is Nothing Then
                txtFormaPagoIdentificacion.Text = ID
                txtFormaPagoNombre.Text = dTDatosCliente.Tables(0).Rows(0).Item("PRIMER_NOMBRE").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("SEGUNDO_NOMBRE").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_PATERNO").ToString _
                                        & " " _
                                        & dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_MATERNO").ToString
                txtFormaPagoDireccion.Text = dTDatosCliente.Tables(0).Rows(0).Item("DIRECCION").ToString
                txtFormaPagoCelular.Text = dTDatosCliente.Tables(0).Rows(0).Item("CELULAR").ToString
                txtFormaPagoTelefono.Text = dTDatosCliente.Tables(0).Rows(0).Item("TELEFONO").ToString
                txtFormaPagoEmail.Text = dTDatosCliente.Tables(0).Rows(0).Item("EMAILPRINCIPAL").ToString
            End If
        End If
    End Sub

#End Region


#Region "Eventos de los controles"

    Private Sub btnagregardatos_Click(sender As Object, e As System.EventArgs) Handles btnagregardatos.Click
        Try
            btnagregardatos.Enabled = False
            Dim myMasterPage As master = CType(Page.Master, master)
            Dim valor As Double = Convert.ToDecimal(lbltotal.Text).ToString("#,##0.00")
            Dim valor2 As Double = Convert.ToDecimal(txtvalor.Text).ToString("#,##0.00")
            Dim totalValor As Double = valor + valor2
            If valor2 > myMasterPage.totalMaster Then
                MensajeriaError("error", "El Valor ingresado no puede ser mayor al Total de Venta que tiene seleccionado.")
            ElseIf totalValor > myMasterPage.totalMaster Then
                MensajeriaError("error", "El Total ingresado no puede ser mayor al Total de Venta que tiene seleccionado.")
            ElseIf Cbxforma.SelectedValue = "DE" Then
                If txtvalor.Text = 0 Or txtvalor.Text = "" Then
                    MensajeriaError("error", "Debe de Ingresar el valor entregado.")
                Else
                    AdicionarRegistro()
                    Habilita_Control(False, "2")
                    Habilita_Control(False, "10")
                    btnagregardatos.Enabled = True
                End If
            ElseIf Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Or Cbxforma.SelectedValue = "PD" Then ' cheque vista, cheque fecha, papeleta deposito
                If Cbxforma.SelectedValue = "PD" Then
                    Habilita_Control(False, "10")
                End If
                If txtdocumento.Text = "" And Cbxforma.SelectedValue <> "PD" Then
                    MensajeriaError("error", "Debe de Ingresar el numero de documento.")
                ElseIf txtvoucher.Text = "" And Cbxforma.SelectedValue = "CP" Then
                    MensajeriaError("error", "Debe de Ingresar el numero de cuenta.")
                ElseIf Cbxbanco.SelectedValue = "NN" Then
                    MensajeriaError("error", "Debe de Ingresar el Banco.")
                ElseIf Cbxforma.SelectedValue = "CP" And Me.txtfecha.Text = Format(Date.Now, "yyyy-MM-dd") Then
                    MensajeriaError("error", "Para Cheque a fecha  no puede tener la misma fecha de hoy.")
                ElseIf txtvalor.Text = 0 Or txtvalor.Text = "" Then
                    MensajeriaError("error", "Debe de Ingresar el valor entregado.")
                Else
                    AdicionarRegistro()
                    Habilita_Control(False, "2")
                    btnagregardatos.Enabled = True
                End If
            ElseIf Cbxforma.SelectedValue = "TJ" Or Cbxforma.SelectedValue = "TI" Or Cbxforma.SelectedValue = "TD" Then ' Tarjeta de credito sin interes, con interes, debito
                If Cbxbanco.SelectedValue = "NN" Then
                    MensajeriaError("error", "Debe de Ingresar la tarjeta.")
                ElseIf txtvalor.Text = 0 Or txtvalor.Text = "" Then
                    MensajeriaError("error", "Debe de Ingresar el valor entregado.")
                ElseIf txtvoucher.Text = "" Then
                    MensajeriaError("error", "Debe de Ingresar el Voucher.")
                ElseIf txtdocumento.Text = "" And (Cbxforma.SelectedValue = "TJ" Or Cbxforma.SelectedValue = "TI") Then
                    MensajeriaError("error", "Debe de Ingresar el documento.")
                Else
                    AdicionarRegistro()
                    Habilita_Control(False, "2")
                    Habilita_Control(False, "8")
                    Habilita_Control(False, "10")
                    btnagregardatos.Enabled = True
                End If
            Else
                MensajeriaError("error", "Debe selecionar una forma de pago.")
            End If
            btnagregardatos.Enabled = True
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Function Validar() As Boolean
        Dim retorno As Boolean = False

        If txtapellido1clientefac.Value = "" Then
            retorno = True
            txtapellido1clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar apellido paterno"
        ElseIf txtapellido2clientefac.Value = "" Then
            retorno = True
            txtapellido2clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar apellido materno"
        ElseIf txtnombre1clientefac.Value = "" Then
            retorno = True
            txtnombre1clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar primer nombre"
        ElseIf txtnombre2clientefac.Value = "" Then
            retorno = True
            txtnombre2clientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar segundo nombre"
        ElseIf txtcedulaclientefac.Value = "" Then
            retorno = True
            txtcedulaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar identificación del cliente"
        ElseIf txtdireccionclientefac.Value = "" Then
            retorno = True
            txtdireccionclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar dirección"
        ElseIf txtinterseccionclientefac.Value = "" Then
            retorno = True
            txtinterseccionclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar intersección de dirección"
        ElseIf txtcelularclientefac.Value.Substring(0, 1) <> "0" Then
            retorno = True
            txtcelularclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono celular válido"
        ElseIf txtcelularclientefac.Value.Length < 10 Then
            retorno = True
            txtcelularclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono celular válido"
        ElseIf txttelefonoclientefac.Value = "" Then
            retorno = True
            txttelefonoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono fijo"
        ElseIf txttelefonoclientefac.Value.Length > 9 Or txttelefonoclientefac.Value.Length < 7 Then
            retorno = True
            txttelefonoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar número de teléfono fijo válido"
        ElseIf txtemailclientefac.Value = "" Then
            retorno = True
            txtemailclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal"
        ElseIf Not txtemailclientefac.Value.Contains("@") Then
            retorno = True
            txtemailclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal válido"
        ElseIf Not txtemailclientefac.Value.Contains(".") Then
            retorno = True
            txtemailclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingresar email principal válido"
        ElseIf cmbsexoclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbsexoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un género"
        ElseIf cmbcedulaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbcedulaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un tipo de identificación"
        ElseIf cmbciudadclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbciudadclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una ciudad"
        ElseIf cmbparroquiaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbparroquiaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una parroquia"
        ElseIf cmbprovinciaclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbprovinciaclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar una provincia"
        ElseIf cmbsectorclientefac.SelectedIndex < 1 Then
            retorno = True
            cmbsectorclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor seleccionar un sector"
        ElseIf txtfechanacimientoclientefac.Text > DateAdd(DateInterval.Year, -18, Date.Now) Then
            retorno = True
            txtfechanacimientoclientefac.Focus()
            lblmensajeerror.InnerText = "Por favor ingrese fecha nacimiento del cliente válid"
        End If

        If cmbcedulaclientefac.SelectedValue = "001" Or cmbcedulaclientefac.SelectedValue = "002" Then
            If txtcedulaclientefac.Value.Length < 10 Or txtcedulaclientefac.Value.Length > 13 Then
                retorno = True
                txtcedulaclientefac.Focus()
                lblmensajeerror.InnerText = "Por favor ingresar identificación válida"
            End If
        End If
        Return retorno
    End Function


    Private Sub Cbxforma_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Cbxforma.SelectedIndexChanged
        Try

            Label13.Text = "Plazo"
            Label1.Text = "Nro. Voucher"
            Cbxplazo.Visible = True
            txtfecha.Visible = False
            Cbxbanco.SelectedValue = "NN"
            Cbxplazo.SelectedValue = "NN"
            If Cbxforma.SelectedValue = "NN" Then
                Habilita_Control(False, "1")
                Habilita_Control(False, "10")
            ElseIf Cbxforma.SelectedValue = "DE" Then 'efectivo
                txtdocumento.MaxLength = 10
                Habilita_Control(True, "5")
                Habilita_Control(False, "10")
            ElseIf Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Or Cbxforma.SelectedValue = "PD" Or Cbxforma.SelectedValue = "TD" Then 'cheque vista, cheque fecha, Papeleta Deposito, tarjeta debito
                Habilita_Control(True, "1")
                Habilita_Control(False, "10")
                If Cbxforma.SelectedValue = "TD" Then
                    txtdocumento.MaxLength = 20
                    txtvoucher.Enabled = True
                    Cbxplazo.Enabled = False
                    Cbxplazo.SelectedValue = "01M"
                Else
                    txtdocumento.MaxLength = 10
                    Habilita_Control(False, "8")
                End If
                If Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Then
                    Habilita_Control(True, "10")
                    Cbxplazo.Visible = False
                    Label13.Text = "Fecha Cheque"
                    txtfecha.Visible = True
                    txtvoucher.Enabled = True
                    Label1.Text = "Nro. Cuenta"
                End If
                CargaBanco()
                Cbxbanco.SelectedValue = "NN"
            ElseIf Cbxforma.SelectedValue = "TJ" Or Cbxforma.SelectedValue = "TI" Then 'tarjeta con interes y sin interes
                lblbanco.Text = "Tarjeta "
                txtdocumento.MaxLength = 20
                Habilita_Control(True, "2")
                Habilita_Control(True, "8")
                Habilita_Control(False, "10")
                CargaTarjeta()
                txtdocumento.Enabled = True
                Cbxbanco.SelectedValue = "NN"
            End If
            txtvalor.Text = 0
            txtdocumento.Text = ""
            txtvoucher.Text = ""
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_eliminar(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblforma As Label = CType(item.FindControl("lbldetforma"), Label)
            Dim lblbanco As Label = CType(item.FindControl("lbldetbanco"), Label)
            Dim lblvalor As Label = CType(item.FindControl("lbldetvalor"), Label)
            Dim lbldocumento As Label = CType(item.FindControl("lbldetdocumento"), Label)
            Dim lblvoucher As Label = CType(item.FindControl("lbldetvoucher"), Label)
            Dim valor2 As Double = Convert.ToDecimal(lblvalor.Text).ToString("#,##0.00")
            Dim valor1 As Double = Convert.ToDecimal(lbltotal.Text).ToString("#,##0.00")
            Dim valorEliminado As Double
            Dim dtDetalle As New DataTable()
            'Dim dtv As DataRow
            dtDetalle = Session("DetalleForma")
            For i As Integer = 0 To dtDetalle.Rows.Count - 1
                Dim dr As DataRow = dtDetalle.Rows(i)
                If dr("FORMA_PAGO") = lblforma.Text And dr("VALOR") = lblvalor.Text And dr("BANCO") = lblbanco.Text And
                    dr("DOCUMENTO") = lbldocumento.Text And dr("VOUCHER") = lblvoucher.Text Then
                    dr.Delete()
                    If valor1 > 0 Then
                        valorEliminado = valor1 - valor2
                        lbltotal.Text = valorEliminado.ToString("#,##0.00")
                    End If
                    dtDetalle.AcceptChanges()
                    Exit For
                End If
            Next

            If dtDetalle.Rows.Count > 0 Then
                For b As Integer = 0 To dtDetalle.Rows.Count - 1
                    dtDetalle.Rows(b).Item("DETALLE_ID") = b + 1
                Next
            End If
            Me.RptdetalleForma.DataSource = dtDetalle
            Me.RptdetalleForma.DataBind()
            Session("DetalleForma") = dtDetalle
            
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



    Protected Sub clk_rpt_clientefac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblcliente As Label = CType(item.FindControl("lblcodigoclientesfac"), Label)
            PasarDatosExiste(lblcliente.Text)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub clk_rpt_direccionfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lbldireccion As Label = CType(item.FindControl("lbldireccionfac"), Label)
            txtFormaPagoDireccion.Text = lbldireccion.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_telefonofac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lbltelefono As Label = CType(item.FindControl("lbltelefonofac"), Label)
            txtFormaPagoTelefono.Text = lbltelefono.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_celularfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblcelular As Label = CType(item.FindControl("lblcelularfac"), Label)
            txtFormaPagoCelular.Text = lblcelular.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_emailfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblemail As Label = CType(item.FindControl("lblemailfac"), Label)
            txtFormaPagoEmail.Text = lblemail.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub txtbusquedaclientefac_ServerChange(sender As Object, e As System.EventArgs) Handles txtbusquedaclientefac.ServerChange
        Try
            If Len(txtbusquedaclientefac.Value) > 0 Then
                Dim dTDatosCliente As New DataSet
                dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreo(txtbusquedaclientefac.Value)
                If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                    Rptclientesfac.DataSource = dTDatosCliente
                    Rptclientesfac.DataBind()
                Else
                    Rptclientesfac.DataSource = Nothing
                    Rptclientesfac.DataBind()
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnnuevoclientefac_ServerClick(sender As Object, e As System.EventArgs) Handles btnnuevoclientefac.ServerClick
        If Not validar() Then
            Try
                If Not validar() Then
                    Dim clienteEntity As New ClienteEntity
                    Dim clienteDetalleEntity As ClienteDetalleEntity
                    Dim clienteDetalleEntityCollection As New ClienteDetalleEntityCollection
                    ClienteEntity = New ClienteEntity
                    'DATOS CLIENTES
                    ClienteEntity.ClienteId = txtcedulaclientefac.Value
                    ClienteEntity.ClienteTipoIdentificacion = cmbcedulaclientefac.SelectedValue
                    ClienteEntity.ClienteNacimiento = txtfechanacimientoclientefac.Text
                    ClienteEntity.ClienteApellidoPadre = txtapellido1clientefac.Value
                    ClienteEntity.ClienteApellidoMadre = txtapellido2clientefac.Value
                    ClienteEntity.ClienteNombrePrimero = txtnombre1clientefac.Value
                    ClienteEntity.ClienteNombreSegundo = txtnombre2clientefac.Value
                    ClienteEntity.ClienteSexo = cmbsexoclientefac.SelectedValue
                    'DATOS DIRECCION
                    ClienteDetalleEntity = New ClienteDetalleEntity
                    ClienteDetalleEntity.DireccionSectorId = cmbsectorclientefac.SelectedValue
                    ClienteDetalleEntity.DireccionProvinciaId = cmbprovinciaclientefac.SelectedValue
                    ClienteDetalleEntity.DireccionCiudadId = cmbciudadclientefac.SelectedValue
                    ClienteDetalleEntity.DireccionParroquiaId = cmbparroquiaclientefac.SelectedValue
                    ClienteDetalleEntity.Direccion = txtdireccionclientefac.Value
                    ClienteDetalleEntity.DireccionInterseccion = txtinterseccionclientefac.Value
                    ClienteDetalleEntity.DireccionNumero = txtnumeroclientefac.Value
                    'DATOS TELEFONO
                    ClienteDetalleEntity.Telefono = txttelefonoclientefac.Value
                    ClienteDetalleEntity.TelefonoCelular = txtcelularclientefac.Value
                    'DATOS REFERENCIA BANCARIA
                    ClienteDetalleEntity.EmailPrincipal = txtemailclientefac.Value
                    ClienteDetalleEntity.EmailAlerta = ""

                    ClienteDetalleEntityCollection.Add(ClienteDetalleEntity)
                    ClienteEntity.ClienteDetalleEntityCollection = ClienteDetalleEntityCollection
                    If DatosPersonalesAdapter.RegistroClienteFACTURA(ClienteEntity) Then
                        txtFormaPagoIdentificacion.Text = txtcedulaclientefac.Value
                        txtFormaPagoNombre.Text = txtnombre1clientefac.Value _
                                                & " " _
                                                & txtnombre2clientefac.Value _
                                                & " " _
                                                & txtapellido1clientefac.Value _
                                                & " " _
                                                & txtapellido2clientefac.Value
                        txtFormaPagoDireccion.Text = txtdireccionclientefac.Value
                        txtFormaPagoCelular.Text = txttelefonoclientefac.Value
                        txtFormaPagoTelefono.Text = txtcelularclientefac.Value
                        txtFormaPagoEmail.Text = txtemailclientefac.Value
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Private Sub cmbprovinciaclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbprovinciaclientefac.SelectedIndexChanged
        LlenaComboCiudad()
    End Sub

    Private Sub cmbciudadclientefac_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbciudadclientefac.SelectedIndexChanged
        LlenaComboParroquia()
    End Sub

    Private Sub btncontinuar_ServerClick(sender As Object, e As System.EventArgs) Handles btncontinuar.ServerClick
        If ValidaControles() Then
            Dim table As New System.Data.DataTable
            Dim row As DataRow
            table = Tablafacturacion()
            row = table.NewRow()
            row("FormaPagoIdentificacion") = txtFormaPagoIdentificacion.Text.ToString
            row("FormaPagoNombre") = txtFormaPagoNombre.Text
            row("FormaPagoDireccion") = txtFormaPagoDireccion.Text
            row("FormaPagoTelefono") = txtFormaPagoTelefono.Text
            row("FormaPagoCelular") = txtFormaPagoCelular.Text
            row("FormaPagoEmail") = txtFormaPagoEmail.Text.ToLower
            table.Rows.Add(row)
            Session("tblfacturacion") = table
            Response.Redirect("RenovacionFormaConfirmacion.aspx", False)
        End If
    End Sub


    Private Function ValidaControles() As Boolean
        Dim retorno As Boolean = True
        Dim valorGeneral As Double
        Dim table As New System.Data.DataTable
        table = CType(Session("tblrenovaciones"), DataTable)

        Dim valueCellPrecioCliente As Decimal = 0
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To table.Rows.Count - 1
                valueCellPrecioCliente += table.Rows(i)("PRECIO_CLIENTE")
            Next
            valorGeneral = valueCellPrecioCliente.ToString("#,##0.00")
        End If

        If table.Rows.Count = 0 Then
            retorno = False
            MensajeriaError("error", "no existen productos a renovar, por favor verificar")
        ElseIf valorGeneral > Convert.ToDecimal(lbltotal.Text).ToString("#,##0.00") Or valorGeneral < Convert.ToDecimal(lbltotal.Text).ToString("#,##0.00") Then
            MensajeriaError("error", "el valor de forma de pago no puedes distinto al valor de renovacion")
            retorno = False
        ElseIf lbltotal.Text = 0 Then
            MensajeriaError("error", "por favor seleccione una forma de Pago")
            retorno = False
        ElseIf txtFormaPagoNombre.Text = "" And txtFormaPagoIdentificacion.Text = "" _
            And txtFormaPagoDireccion.Text = "" And txtFormaPagoTelefono.Text = "" _
            And txtFormaPagoCelular.Text = "" And txtFormaPagoEmail.Text = "" Then
            MensajeriaError("error", "datos de facturación incompletos, por favor completar")
            retorno = False
        End If
        Return retorno
    End Function

#End Region


  
End Class