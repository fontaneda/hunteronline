Public Class CreacionNuevoVehiculo
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Crear Vehículo", 2, "Bienes")
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

    Private Sub cmbveh_marca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbveh_marca.SelectedIndexChanged
        Try
            Dim dato As New System.Data.DataSet
            dato = VehiculoAdapter.ConsultaCatalogoModeloVehiculosNuevo(cmbveh_marca.SelectedValue)

            If dato.Tables.Count > 0 Then
                cmbveh_modelo.DataSource = dato.Tables(0)
                cmbveh_modelo.DataValueField = "CODIGO"
                cmbveh_modelo.DataTextField = "DESCRIPCION"
                cmbveh_modelo.DataBind()
            End If
        Catch ex As Exception
            mensajeria_error("error", "ocurrió un inconventiente al cargar, por favor reintente en unos minutos")
        End Try
    End Sub

    Private Sub cmbveh_modelo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbveh_modelo.SelectedIndexChanged
        Try
            Dim dato As New System.Data.DataSet
            dato = VehiculoAdapter.ConsultaCatalogoTipoVehiculosNuevo(cmbveh_marca.SelectedValue, cmbveh_modelo.SelectedValue)

            If dato.Tables.Count > 0 Then
                cmbveh_tipo.DataSource = dato.Tables(0)
                cmbveh_tipo.DataValueField = "CODIGO"
                cmbveh_tipo.DataTextField = "DESCRIPCION"
                cmbveh_tipo.DataBind()
                cmbveh_tipo.SelectedIndex = 1
            End If
        Catch ex As Exception
            mensajeria_error("error", "ocurrió un inconventiente al cargar, por favor reintente en unos minutos")
        End Try
    End Sub

    Private Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Try
            Response.Redirect("Ventas.aspx", False)
        Catch ex As Exception
            mensajeria_error("error", "ocurrió un inconventiente al cargar, por favor reintente en unos minutos")
        End Try
    End Sub

    Private Sub btngrabardatos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabardatos.Click
        Try
            If verificar_datos() Then
                Dim dTCstenviar As New System.Data.DataSet
                If VehiculoAdapter.GrabaDatosVehiculoVenta(txtveh_placa.Text, cmbveh_financiera.SelectedValue, cmbveh_aseguradora.SelectedValue, _
                                                                      cmbveh_concesionario.SelectedValue, cmbveh_marca.SelectedValue, cmbveh_modelo.SelectedValue, _
                                                                      cmbveh_tipo.SelectedValue, cmbveh_color.SelectedValue, txtveh_motor.Text, txtveh_chasis.Text, _
                                                                      cmbveh_transmision.SelectedValue, cmbveh_combustible.SelectedValue, cmbveh_version.SelectedValue, _
                                                                      cmbveh_cabina.SelectedValue, cmbveh_cilindraje.SelectedValue, cmbveh_traccion.SelectedValue, _
                                                                      IIf(chkveh_airesi.Checked, "Si", "No"), cmbveh_puertas.SelectedValue, cmbveh_anio.SelectedValue, Session("user")) Then
                    mensajeria_error("informacion", "Vehículo guardado con éxito")
                    btngrabardatos.Enabled = False
                Else
                    mensajeria_error("error", "no se pudo grabar el registro de vehículo")
                End If
            End If
        Catch ex As Exception
            mensajeria_error("error", "ocurrió un inconventiente al cargar, " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub carga_inicial()
        Try
            Dim dato As New System.Data.DataSet
            dato = VehiculoAdapter.ConsultaCatalogoVehiculosNuevo

            If dato.Tables.Count = 14 Then
                cmbveh_marca.DataSource = dato.Tables(0)
                cmbveh_marca.DataValueField = "CODIGO"
                cmbveh_marca.DataTextField = "DESCRIPCION"
                cmbveh_marca.DataBind()
                cmbveh_cilindraje.DataSource = dato.Tables(1)
                cmbveh_cilindraje.DataValueField = "CODIGO"
                cmbveh_cilindraje.DataTextField = "DESCRIPCION"
                cmbveh_cilindraje.DataBind()
                cmbveh_combustible.DataSource = dato.Tables(2)
                cmbveh_combustible.DataValueField = "CODIGO"
                cmbveh_combustible.DataTextField = "DESCRIPCION"
                cmbveh_combustible.DataBind()
                cmbveh_combustible.SelectedValue = "001"
                cmbveh_version.DataSource = dato.Tables(3)
                cmbveh_version.DataValueField = "CODIGO"
                cmbveh_version.DataTextField = "DESCRIPCION"
                cmbveh_version.DataBind()
                cmbveh_color.DataSource = dato.Tables(4)
                cmbveh_color.DataValueField = "CODIGO"
                cmbveh_color.DataTextField = "DESCRIPCION"
                cmbveh_color.DataBind()
                cmbveh_traccion.DataSource = dato.Tables(5)
                cmbveh_traccion.DataValueField = "CODIGO"
                cmbveh_traccion.DataTextField = "DESCRIPCION"
                cmbveh_traccion.DataBind()
                cmbveh_transmision.DataSource = dato.Tables(6)
                cmbveh_transmision.DataValueField = "CODIGO"
                cmbveh_transmision.DataTextField = "DESCRIPCION"
                cmbveh_transmision.DataBind()
                cmbveh_transmision.SelectedValue = "MAN"
                cmbveh_cabina.DataSource = dato.Tables(7)
                cmbveh_cabina.DataValueField = "CODIGO"
                cmbveh_cabina.DataTextField = "DESCRIPCION"
                cmbveh_cabina.DataBind()
                cmbveh_financiera.DataSource = dato.Tables(8)
                cmbveh_financiera.DataValueField = "CODIGO"
                cmbveh_financiera.DataTextField = "DESCRIPCION"
                cmbveh_financiera.DataBind()
                cmbveh_aseguradora.DataSource = dato.Tables(9)
                cmbveh_aseguradora.DataValueField = "CODIGO"
                cmbveh_aseguradora.DataTextField = "DESCRIPCION"
                cmbveh_aseguradora.DataBind()
                cmbveh_concesionario.DataSource = dato.Tables(10)
                cmbveh_concesionario.DataValueField = "CODIGO"
                cmbveh_concesionario.DataTextField = "DESCRIPCION"
                cmbveh_concesionario.DataBind()
                'cmbveh_aire.DataSource = dato.Tables(11)
                'cmbveh_aire.DataValueField = "CODIGO"
                'cmbveh_aire.DataTextField = "DESCRIPCION"
                'cmbveh_aire.DataBind()
                cmbveh_puertas.DataSource = dato.Tables(12)
                cmbveh_puertas.DataValueField = "CODIGO"
                cmbveh_puertas.DataTextField = "DESCRIPCION"
                cmbveh_puertas.DataBind()
                cmbveh_puertas.SelectedValue = 4
                cmbveh_anio.DataSource = dato.Tables(13)
                cmbveh_anio.DataValueField = "CODIGO"
                cmbveh_anio.DataTextField = "DESCRIPCION"
                cmbveh_anio.DataBind()
            Else
                mensajeria_error("error", "datos no se pudieron cargar, por favor reintente en unos minutos")
            End If
        Catch ex As Exception
            mensajeria_error("error", "ocurrió un inconventiente al cargar, por favor reintente en unos minutos")
        End Try
    End Sub

    Private Function verificar_datos() As Boolean
        Dim retorno As Boolean = True
        Dim _error As String = ""

        If cmbveh_marca.SelectedIndex <= 0 Then
            retorno = False
            _error = "marca"
        ElseIf cmbveh_modelo.SelectedIndex <= 0 Then
            retorno = False
            _error = "modelo"
        ElseIf cmbveh_cilindraje.SelectedIndex < 0 Then
            retorno = False
            _error = "cilindraje"
        ElseIf cmbveh_combustible.SelectedIndex < 0 Then
            retorno = False
            _error = "combustible"
        ElseIf cmbveh_tipo.SelectedIndex < 0 Then
            retorno = False
            _error = "tipo de vehículo"
        ElseIf cmbveh_version.SelectedIndex < 0 Then
            retorno = False
            _error = "version"
        ElseIf cmbveh_color.SelectedIndex <= 0 Then
            retorno = False
            _error = "color"
        ElseIf cmbveh_cabina.SelectedIndex < 0 Then
            retorno = False
            _error = "tipo de cabina"
        ElseIf cmbveh_transmision.SelectedIndex < 0 Then
            retorno = False
            _error = "transmision"
        ElseIf cmbveh_traccion.SelectedIndex < 0 Then
            retorno = False
            _error = "tracción"
        ElseIf cmbveh_financiera.SelectedIndex < 0 Then
            retorno = False
            _error = "financiera"
        ElseIf cmbveh_aseguradora.SelectedIndex < 0 Then
            retorno = False
            _error = "aseguradora"
        ElseIf cmbveh_concesionario.SelectedIndex < 0 Then
            retorno = False
            _error = "concesionario"
        ElseIf Not chkveh_airesi.Checked And Not chkveh_aireno.Checked Then
            'ElseIf cmbveh_aire.SelectedIndex <= 0 Then
            retorno = False
            _error = "tiene aire acondicionado"
        ElseIf cmbveh_puertas.SelectedIndex < 0 Then
            retorno = False
            _error = "número de puertas"
        ElseIf cmbveh_anio.SelectedIndex <= 0 Then
            retorno = False
            _error = "año de fabricación"
        ElseIf txtveh_chasis.Text = "" Then
            retorno = False
            _error = "chasis"
        ElseIf txtveh_motor.Text = "" Then
            retorno = False
            _error = "motor"
        ElseIf txtveh_placa.Text = "" Then
            retorno = False
            _error = "placa"
        ElseIf txtveh_chasis.Text.Length < 8 Then
            retorno = False
            _error = "chasis con formato correcto"
        ElseIf txtveh_motor.Text.Length < 5 Then
            retorno = False
            _error = "motor con formato correcto"
        ElseIf txtveh_placa.Text.Length < 5 Then
            retorno = False
            _error = "placa con formato correcto"
        End If

        If Not retorno Then
            mensajeria_error("error", String.Format("{0}{1}", "por favor complete, ", _error.ToUpper))
        End If

        Return retorno
    End Function

    Private Sub mensajeria_error(ByVal tipo As String, ByVal mensaje As String)
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

    Private Sub metodos_master(ByVal titulo As String, ByVal itemmnu As Integer, ByVal ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

#End Region

End Class