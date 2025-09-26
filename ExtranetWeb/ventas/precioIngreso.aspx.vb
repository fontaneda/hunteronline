Imports Telerik.Web.UI

Public Class precioIngreso
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Session("usuarioPrecio") = "FONTAN"
            'Session("user") = "0916517956"


            'Session("user") = "0916517956"
            'Session("user_id") = "0916517956"
            'Session("usuario") = "0916517956"
            'Session("usuarioPrecio") = "FONTAN"
            'Session("user_netsuite") = "25"


            If Not IsPostBack Then
                metodos_master("Ingreso de Precio de Venta", 3, "Ingreso de Precio de Venta")
                If Session("usuarioPrecio") IsNot Nothing Then
                    IniciarControlesValores(1)
                    LimpiaGridConsulta()
                Else
                    Response.Redirect("./LoginSoporte.aspx", False)
                End If
            Else
                If Session("usuarioPrecio") Is Nothing Then
                    Response.Redirect("./LoginSoporte.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES GENERALES"

    Private Sub IniciarControlesValores(ByVal opcion As Integer)
        Try
            txtorden.Value = ""
            txtproducto.Value = ""
            txtprecio.Value = "0"
            txtpropuesta.Value = "0"
            lblfecha.Text = ""
            lbltransaccion.Text = ""
            lblproducto.Text = ""
            lblorigen.Text = ""
            If opcion = 1 Then
                txtIdentificacion.Value = ""
                txtNombre.Value = ""
                txtcodigovehiculo.Value = "0"
                txtdescripcion.Value = ""
                btnGrabar.Visible = False
            End If
            If opcion = 2 Then
                btnGrabar.Visible = False
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigMsg(ByVal opcion As Integer, ByVal custommsg As String)
        Try
            Select Case opcion
                Case 1
                    rntMsgSistema.Text = custommsg
                    rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMsgSistema.TitleIcon = "ok"
                    rntMsgSistema.ContentIcon = "ok"
                    rntMsgSistema.ShowSound = "ok"
                    rntMsgSistema.Width = 400
                    rntMsgSistema.Height = 100
                    rntMsgSistema.Show()
                Case 2
                    rntMsgSistema.Text = custommsg
                    rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMsgSistema.TitleIcon = "warning"
                    rntMsgSistema.ContentIcon = "warning"
                    rntMsgSistema.ShowSound = "warning"
                    rntMsgSistema.Width = 400
                    rntMsgSistema.Height = 100
                    rntMsgSistema.Show()
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LimpiaGridConsulta()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = AprobacionAdapter.ConsultarDatos("0", "", "6")
            Session("General") = dTCstGeneral
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                consultacliente.DataSource = dTCstGeneral
                consultacliente.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub Guardardatos()
        Try
            AprobacionAdapter.GuardarPrecio(Trim(txtIdentificacion.Value), Trim(txtcodigovehiculo.Value), Session("usuarioPrecio"),
                                                   Trim(lbltransaccion.Text), "8", Trim(lblfecha.Text), Trim(txtpropuesta.Value),
                                                   Trim(lblproducto.Text), Trim(lblorigen.Text))

            IniciarControlesValores(2)
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = AprobacionAdapter.ConsultarDatos(txtcodigovehiculo.Value, txtIdentificacion.Value, "7")
            Session("General") = dTCstGeneral
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                consultacliente.DataSource = dTCstGeneral
                consultacliente.DataBind()
                btnGrabar.Visible = False
                ConfigMsg(1, "Guardado con exito")
            Else
                LimpiaGridConsulta()
                btnGrabar.Visible = False
                ConfigMsg(2, "Error en el proceso de Guardar")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "EVENTOS DE LOS CONTROLES"

    Private Sub btnCliente_Click(sender As Object, e As System.EventArgs) Handles btnCliente.Click
        Try
            IniciarControlesValores(1)
            Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", modalpopupcliente.ClientID)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnVehiculo_Click(sender As Object, e As System.EventArgs) Handles btnVehiculo.Click
        Try
            IniciarControlesValores(1)

            Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", modalpopupclientevehiculo.ClientID)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.ServerClick
        Try
            If txtIdentificacion.Value = "" And txtcodigovehiculo.Value = "0" Then
                ConfigMsg(2, "Ingrese el cliente o vehículo para poder realizar la busqueda")
            Else
                Dim dTCstGeneral As New System.Data.DataSet
                dTCstGeneral = AprobacionAdapter.ConsultarDatos(txtcodigovehiculo.Value, txtIdentificacion.Value, "7")
                Session("General") = dTCstGeneral
                If dTCstGeneral.Tables.Count > 0 Then
                    If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                        consultacliente.DataSource = dTCstGeneral
                        consultacliente.DataBind()
                        btnGrabar.Visible = False
                    Else
                        LimpiaGridConsulta()
                        btnGrabar.Visible = False
                        ConfigMsg(2, "No existen datos")
                    End If
                    If dTCstGeneral.Tables.Count > 1 Then
                        Dim productos As String = ""
                        If dTCstGeneral.Tables(1).Rows.Count > 0 Then
                            For i As Integer = 0 To dTCstGeneral.Tables(1).Rows.Count - 1
                                productos = productos &
                                dTCstGeneral.Tables(1).Rows(i).Item("Producto") &
                                ","
                            Next
                            If productos.Substring(productos.Length - 1, 1) = "," Then
                                productos = productos.Substring(0, productos.Length - 2)
                                ConfigMsg(2, "El/Los producto(s) " & productos & ", ya tienen aprobaciones")
                            End If
                        End If
                    End If
                Else
                    LimpiaGridConsulta()
                    btnGrabar.Visible = False
                    ConfigMsg(2, "No existen datos")
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As System.EventArgs) Handles BtnLimpiar.ServerClick
        Try
            IniciarControlesValores(1)
            LimpiaGridConsulta()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.ServerClick
        Try
            If txtpropuesta.Value <> "0" Then
                If lblorigen.Text = "ING" And txtpropuesta.Value > 0 Then
                    Guardardatos()
                ElseIf lblorigen.Text = "ANT" And txtpropuesta.Value > 0 Then
                    Guardardatos()
                ElseIf lblorigen.Text = "NUE" And txtpropuesta.Value > 0 Then
                    Guardardatos()
                ElseIf txtpropuesta.Value > 0 And lblorigen.Text = "REN" Then
                    Guardardatos()
                Else
                    ConfigMsg(2, "Verificar datos")
                End If
            Else
                ConfigMsg(2, "Ingrese un valor")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub consultacliente_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles consultacliente.NeedDataSource
        Try
            consultacliente.DataSource = Session("General")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub consultacliente_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles consultacliente.SelectedIndexChanged
        Try
            IniciarControlesValores(2)
            Dim continuar As Boolean = False
            Dim item As GridDataItem = Nothing
            item = consultacliente.SelectedItems(0)
            If item("NUMERO_GENERAL").Text.Trim.ToString <> "&nbsp;" Then
                txtorden.Value = item("NUMERO_GENERAL").Text.Trim.ToString
                txtproducto.Value = item("PRODUCTO_NOMBRE").Text.Trim.ToString
                txtprecio.Value = item("TOTAL_ITEM").Text.Trim.ToString
                txtpropuesta.Value = item("ITEM_PROPUESTA").Text.Trim.ToString
                lblfecha.Text = item("FECHA").Text.Trim.ToString
                lbltransaccion.Text = item("TIPO_TRANSACCION").Text.Trim.ToString
                lblorigen.Text = item("ORIGEN").Text.Trim.ToString
                lblproducto.Text = item("PRODUCTO").Text.Trim.ToString
                Dim idVehiculo As String = item("CODIGO_VEHICULO").Text.Trim.ToString
                Dim idCliente As String = item("CODIGO_CLIENTE").Text.Trim.ToString
                If txtcodigovehiculo.Value = "0" Then
                    txtcodigovehiculo.Value = idVehiculo
                    txtdescripcion.Value = item("VEHICULO").Text.Trim.ToString
                    continuar = True
                ElseIf txtcodigovehiculo.Value = idVehiculo Then
                    continuar = True
                ElseIf txtcodigovehiculo.Value <> "0" Then
                    txtcodigovehiculo.Value = idVehiculo
                    txtdescripcion.Value = item("VEHICULO").Text.Trim.ToString
                    continuar = True
                Else
                    ConfigMsg(2, "verifique los datos del vehiculo")
                    continuar = False
                End If
                If txtIdentificacion.Value = "" Then
                    txtIdentificacion.Value = idCliente
                    txtNombre.Value = item("CLIENTE").Text.Trim.ToString
                ElseIf txtIdentificacion.Value = idCliente Then
                    continuar = True
                ElseIf txtIdentificacion.Value <> "" Then
                    txtIdentificacion.Value = idCliente
                    txtNombre.Value = item("CLIENTE").Text.Trim.ToString
                Else
                    ConfigMsg(2, "verifique los datos del cliente")
                    continuar = False
                End If
            End If

            If continuar Then
                btnGrabar.Visible = True
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

#End Region

End Class