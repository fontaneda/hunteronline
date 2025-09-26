'Imports Telerik.Web.UI

Public Class Vehiculoespecifico
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Bienes protegidos", 2, "Bienes datos especificos")
                    mensajeria_error("", "")
                    carga_inicial()
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btncancelar_Click(sender As Object, e As System.EventArgs) Handles btncancelar.Click
        Try
            Response.Redirect("./vehiculo.aspx", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btngrabardatos_Click(sender As Object, e As System.EventArgs) Handles btngrabardatos.Click
        Try
            If validar() Then
                Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
                Dim parametro_ns As String = ConfigurationManager.AppSettings.Get("NSParamUpdateBienes").ToString()
                parametro_ns = String.Format(parametro_ns, "200", txtveh_placa.Text, txtveh_anio.Text, cmbveh_aseguradora.SelectedValue, Session("id_vehiculo"))
                parametro_ns = "{" & parametro_ns & "}"
                Dim mensaje As String = VehiculoAdapter.GrabaDatosVehiculo(id_script, parametro_ns)
                mensajeria_error("informacion", mensaje)
                txtveh_placa.Enabled = False
                txtveh_anio.Enabled = False
                cmbveh_aseguradora.Enabled = False
                cmbveh_color.Enabled = False
                btngrabardatos.Enabled = False

                'Dim guardar As Boolean = True
                'Dim dtConsulPlaca As New System.Data.DataSet
                'dtConsulPlaca = VehiculoAdapter.ConsultaPlaca(lblveh_codigo.Text, txtveh_placa.Text)
                'If dtConsulPlaca.Tables(0).Rows.Count > 0 Then
                '    guardar = False
                '    mensajeria_error("error", "La Placa repetida en el Cliente " + dtConsulPlaca.Tables(0).Rows(0)("NOMBRE_CLIENTE"))
                'End If
                'If guardar Then
                '    Dim dtConsulMotor As New System.Data.DataSet
                '    dtConsulMotor = VehiculoAdapter.ConsultaMotor(lblveh_chasis.Text, lblveh_motor.Text)
                '    If dtConsulMotor.Tables(0).Rows.Count > 0 Then
                '        guardar = False
                '        mensajeria_error("error", "El Motor repetida en el Cliente " + dtConsulMotor.Tables(0).Rows(0)("NOMBRE_CLIENTE"))
                '    End If
                'End If
                'If guardar Then
                '    Dim dtConsulChasis As New System.Data.DataSet
                '    dtConsulChasis = VehiculoAdapter.ConsultaChasis(lblveh_codigo.Text, lblveh_chasis.Text)
                '    If dtConsulChasis.Tables(0).Rows.Count > 0 Then
                '        guardar = False
                '        mensajeria_error("error", "El Motor repetida en el Cliente " + dtConsulChasis.Tables(0).Rows(0)("NOMBRE_CLIENTE"))
                '    End If
                'End If
                'If guardar Then
                'Dim dTCstenviar As New System.Data.DataSet
                'dTCstenviar = VehiculoAdapter.GrabaDatosVehiculo(lblveh_codigo.Text, txtveh_placa.Text, lblveh_motor.Text, lblveh_chasis.Text, txtveh_anio.Text, "", cmbveh_color.SelectedValue,
                '                                                 cmbveh_marca.SelectedValue, cmbveh_modelo.SelectedValue, Session.Item("user").ToString(), cmbveh_aseguradora.SelectedValue)
                '    If dTCstenviar.Tables(0).Rows.Count > 0 Then
                '        If dTCstenviar.Tables(0).Rows(0).Item(0).ToString.ToUpper = "CORRECTO" Then
                '            EnviaEMailConfirmacion()
                '            mensajeria_error("informacion", "Registro grabado correctamente")
                '            Response.Redirect("./vehiculo.aspx", False)
                '        Else
                '            mensajeria_error("error", "dTCstenviar.Tables(0).Rows(0).Item(0)")
                '        End If
                '    Else
                '        mensajeria_error("error", "No se pudo grabar el registro de vehícul")
                '    End If
                'End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub cmbveh_marca_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbveh_marca.SelectedIndexChanged
        Try
            CargaDatosModelo()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub chkveh_cambiopropietario_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkveh_cambiopropietario.CheckedChanged
        Try
            If chkveh_cambiopropietario.Checked Then
                txtveh_nuevopropietario.Enabled = True
                txtveh_celular.Enabled = True
            Else
               txtveh_nuevopropietario.Enabled = False
                txtveh_celular.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub carga_inicial()
        Dim dtmarca As New System.Data.DataTable
        Dim dtmodelo As New System.Data.DataTable
        Dim dtaseguradora As New System.Data.DataTable
        Dim dtcolor As New System.Data.DataTable
        Dim dtvehiculo As New System.Data.DataTable
        Dim id_script As String = ""
        Dim parametro As String = ""
        If Session("id_vehiculo") Is Nothing Then
            btngrabardatos.Enabled = False
        Else
            id_script = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            parametro = ConfigurationManager.AppSettings.Get("NSParamCatalogosBienes").ToString()
            dtmarca = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "MAR", "", "", "", "", "", ""))
            cmbveh_marca.DataSource = dtmarca
            cmbveh_marca.DataValueField = "Id"
            cmbveh_marca.DataTextField = "Descripcion"
            cmbveh_marca.DataBind()

            parametro = ConfigurationManager.AppSettings.Get("NSParamCatalogosCompanias").ToString()
            dtaseguradora = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "ASE", "", "", ""))
            cmbveh_aseguradora.DataSource = dtaseguradora
            cmbveh_aseguradora.DataValueField = "Id"
            cmbveh_aseguradora.DataTextField = "Descripcion"
            cmbveh_aseguradora.DataBind()

            parametro = ConfigurationManager.AppSettings.Get("NSParamCatalogosColor").ToString()
            dtcolor = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "COL", ""))
            cmbveh_color.DataSource = dtcolor
            cmbveh_color.DataValueField = "Id"
            cmbveh_color.DataTextField = "Descripcion"
            cmbveh_color.DataBind()

            id_script = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
            parametro = ConfigurationManager.AppSettings.Get("NSParamDatosVehiculos").ToString()
            dtvehiculo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", Session("id_vehiculo"), "", "", Session("user_netsuite"), "", "", ""))
            If dtvehiculo.Rows.Count > 0 Then
                lblveh_codigo.Text = dtvehiculo.Rows(0).Item("CodigoVehiculo").ToString
                txtveh_placa.Text = dtvehiculo.Rows(0).Item("Placa").ToString
                lblveh_motor.Text = dtvehiculo.Rows(0).Item("Motor").ToString
                lblveh_chasis.Text = dtvehiculo.Rows(0).Item("Chasis").ToString
                txtveh_anio.Text = dtvehiculo.Rows(0).Item("Anio").ToString
                cmbveh_color.SelectedValue = dtvehiculo.Rows(0).Item("IdColorFabricante").ToString
                cmbveh_marca.SelectedValue = dtvehiculo.Rows(0).Item("IdMarca").ToString
                cmbveh_aseguradora.SelectedValue = dtvehiculo.Rows(0).Item("IdAseguradora").ToString
                Dim modelo As String = dtvehiculo.Rows(0).Item("IdModelo").ToString
                CargaDatosModelo(modelo)
            End If
        End If
        Controles()
    End Sub

    Private Sub Controles()
        Try
            cmbveh_modelo.Enabled = False
            cmbveh_marca.Enabled = False
            cmbveh_color.Enabled = True
            txtveh_nuevopropietario.Enabled = False
            txtveh_celular.Enabled = False
            chkveh_cambiopropietario.Visible = False
            txtveh_nuevopropietario.Visible = False
            txtveh_celular.Visible = False
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
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

    Private Function validar() As Boolean
        Dim retorno As Boolean = True
        If txtveh_anio.Text = "" Then
            retorno = False
            mensajeria_error("error", "por favor ingrese año del vehículo")
        ElseIf txtveh_placa.Text = "" Then
            retorno = False
            mensajeria_error("error", "por favor ingrese placa del vehículo")
        End If
        If chkveh_cambiopropietario.Checked = True Then
            If txtveh_nuevopropietario.Text = "" Then
                retorno = False
                mensajeria_error("error", "por favor ingrese nuevo propietario del vehículo")
            ElseIf txtveh_celular.Text = "" Then
                retorno = False
                mensajeria_error("error", "por favor ingrese celular del nuevo propietario del vehículo")
            End If
        End If
        Return retorno
    End Function

    'Private Sub EnviaEMailConfirmacion()
    '    Try
    '        Dim ciudad As String
    '        Dim mensaje As String
    '        ciudad = VehiculoAdapter.ConsultaCiudad(Session("id_vehiculo").ToString, "200")
    '        mensaje = VehiculoAdapter.ConsultaEmail(Session("id_vehiculo").ToString, "100")
    '        EMailHandler.EMailActivacionVehiculo(mensaje, ciudad)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub CargaDatosModelo(Optional modelo As String = "")
        Try
            Dim dtmodelo As New System.Data.DataTable
            Dim id_script As String = ""
            Dim parametro As String = ""
            id_script = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            parametro = ConfigurationManager.AppSettings.Get("NSParamCatalogosBienes").ToString()
            dtmodelo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "MDA", cmbveh_marca.SelectedValue, "", "", "", "", ""))
            cmbveh_modelo.DataSource = dtmodelo
            cmbveh_modelo.DataValueField = "IdModelo"
            cmbveh_modelo.DataTextField = "Modelo"
            cmbveh_modelo.DataBind()
            If Not modelo = "" Then
                cmbveh_modelo.SelectedValue = Session("veh_modelo")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class