Imports Telerik.Web.UI

Public Class busquedaclientefac
    Inherits System.Web.UI.Page

#Region "DECLARACION DE VARIABLES"
    Dim idcliente As String = ""
#End Region

#Region "EVENTOS DEL FORMULARIO"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: EVENTO LOAD DEL FORM
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                controles_limpiar(True, "")
                controles_estados(False)
                llenar_combos()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "EVENTOS DE LOS CONTROLES"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CLICK DEL BOTON DE CONSULTA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BtnConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnConsulta.Click
        Try
            If Len(Me.txtbusqueda.Text) > 2 Then
                Dim dTDatosCliente As New DataSet
                dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreo(Me.txtbusqueda.Text)
                If dTDatosCliente Is Nothing Then
                    idcliente = ""
                    MostrarMensaje("Cliente no encontrado, verifique identificación o proceda a crearlo")
                    Me.rgdconsulta.DataSource = ""
                    Me.rgdconsulta.DataBind()
                    controles_estados(True)
                    controles_botones("consultavacia")
                Else
                    If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                        rgdconsulta.DataSource = dTDatosCliente
                        rgdconsulta.DataBind()
                        idcliente = Me.txtbusqueda.Text
                        controles_botones("consultaok")
                    Else
                        MostrarMensaje("Cliente no encontrado, verifique identificación o proceda a crearlo")
                        Me.rgdconsulta.DataSource = ""
                        Me.rgdconsulta.DataBind()
                        controles_estados(True)
                        controles_botones("consultavacia")
                    End If
                End If
            Else
                MostrarMensaje("Por favor ingresar identificación del cliente")
                Me.rgdconsulta.DataSource = ""
                Me.rgdconsulta.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CLICK DEL BOTON NUEVO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        controles_botones("nuevo")
        controles_estados(True)
        txtregistro.Text = "NUEVO"
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CLICK DEL BOTON GUARDAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnguarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnguarda.Click
        Try
            If Not validar() Then
                Dim ClienteEntity As New ClienteEntity
                Dim ClienteDetalleEntity As ClienteDetalleEntity
                Dim ClienteDetalleEntityCollection As New ClienteDetalleEntityCollection
                ClienteEntity = New ClienteEntity
                idcliente = txtdatoidcliente.Text
                'DATOS CLIENTES
                ClienteEntity.ClienteId = idcliente
                ClienteEntity.ClienteTipoIdentificacion = cmbdatotipoidcliente.SelectedValue
                ClienteEntity.ClienteNacimiento = dtpdatofechanacimiento.SelectedDate
                ClienteEntity.ClienteApellidoPadre = txtdatoapellidopadre.Text
                ClienteEntity.ClienteApellidoMadre = txtdatoapellidomadre.Text
                ClienteEntity.ClienteNombrePrimero = txtdatonombreprimero.Text
                ClienteEntity.ClienteNombreSegundo = txtdatonombresegundo.Text
                ClienteEntity.ClienteSexo = cmbdatosexo.SelectedValue
                'DATOS DIRECCION
                ClienteDetalleEntity = New ClienteDetalleEntity
                ClienteDetalleEntity.DireccionSectorId = cmbdireccionsector.SelectedValue
                ClienteDetalleEntity.DireccionProvinciaId = cmbdireccionprovincia.SelectedValue
                ClienteDetalleEntity.DireccionCiudadId = cmbdireccionciudad.SelectedValue
                ClienteDetalleEntity.DireccionParroquiaId = cmbdireccionparroquia.SelectedValue
                ClienteDetalleEntity.Direccion = txtdireccionprincipal.Text
                ClienteDetalleEntity.DireccionInterseccion = txtdireccioninterseccion.Text
                ClienteDetalleEntity.DireccionNumero = txtdireccionnumero.Text
                'DATOS TELEFONO
                ClienteDetalleEntity.Telefono = txttelefono.Text
                ClienteDetalleEntity.TelefonoCelular = txttelefonocelular.Text
                'DATOS REFERENCIA BANCARIA
                ClienteDetalleEntity.EmailPrincipal = txtemailprincipal.Text
                ClienteDetalleEntity.EmailAlerta = ""

                ClienteDetalleEntityCollection.Add(ClienteDetalleEntity)
                ClienteEntity.ClienteDetalleEntityCollection = ClienteDetalleEntityCollection
                If DatosPersonalesAdapter.RegistroClienteFACTURA(ClienteEntity) Then
                    txtclientefacturacion.Text = String.Format("{0} - {1} {2}", txtdatoidcliente.Text, txtdatoapellidopadre.Text, txtdatonombreprimero.Text)
                    MostrarMensaje("Cliente de monitoreo guardado con éxito")
                    controles_botones("guardar")
                    controles_estados(False)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: INDEXCHANGE DEL COMBO PROVINCIA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbdireccionprovincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbdireccionprovincia.SelectedIndexChanged
        LlenaComboCiudad()
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: INDEXCHANGE DEL BOTON CIUDAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbdireccionciudad_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbdireccionciudad.SelectedIndexChanged
        LlenaComboParroquia()
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: COLOCA DATOS DEL CLIENTE EN MODO DE EDICION PARA DESPUES GUARDAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnmodificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        If rgdconsulta.SelectedItems.Count > 0 Then
            Dim item As GridDataItem = CType(rgdconsulta.SelectedItems(0), GridDataItem)
            Dim id As String = item("ID_CLIENTE").Text
            llena_datos_modificar(id)
        Else
            MostrarMensaje("Por favor seleccione un cliente de la lista.")
        End If
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: LIMPIA LA PANTALLA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnlimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlimpiar.Click
        controles_botones("inicio")
        controles_estados(False)
        controles_limpiar(True, "")
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: EVENTO CLICK DEL CHECK PARA INDICAR QUE EL CLIENTE DE MONITOREO ES EL MISMO DE INICIO DE SESION
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub chkclientefacturacion_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkclientefacturacion.CheckedChanged
        Try
            If chkclientefacturacion.Checked Then
                controles_botones("inicio")
                controles_estados(False)
                controles_limpiar(True, "")
                txtclientefacturacion.Text = Session("user_id") & " - " & Session("display_name")
                txtbusqueda.Text = Session("user_id")
                BtnConsulta_Click(sender, e)

                llena_datos_modificar(Session("user_id"))
            Else
                txtclientefacturacion.Text = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON DEL MENU PARA CARGAR EL CLIENTE CONSULTADO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Try
            If rgdconsulta.SelectedItems.Count > 0 Then
                Dim item As GridDataItem = CType(rgdconsulta.SelectedItems(0), GridDataItem)
                Dim id As String = item("ID_CLIENTE").Text
                Dim nombre As String = String.Format("{0} - {1} {2}", id, item("PRIMER_NOMBRE").Text, item("APELLIDO_PATERNO").Text)
                If Not id Is Nothing Or id <> "" Then
                    controles_botones("inicio")
                    controles_estados(False)
                    txtclientefacturacion.Text = nombre
                    llena_datos_modificar(id)
                Else
                    id = ""
                    MostrarMensaje("Problemas al extraer datos del cliente.")
                    controles_estados(True)
                    controles_botones("consultavacia")
                End If
            Else
                MostrarMensaje("Por favor seleccione un cliente de la lista.")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON PARA ACEPTAR TODOS LOS DATOS REQUERIDOS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        Try
            If txtclientefacturacion.Text = "" Then
                MostrarMensaje("Por favor seleccione una cliente de monitoreo.")
                txtclientefacturacion.Focus()
                Exit Sub
            End If
            Dim texto_nombres As String = String.Format("{0} {1} {2} {3}" _
                                                        , txtdatonombreprimero.Text _
                                                        , txtdatonombresegundo.Text _
                                                        , txtdatoapellidopadre.Text _
                                                        , txtdatoapellidomadre.Text)
            Dim texto_envio As String = String.Format("{0} % {1} % {2} % {3} % {4} % {5}" _
                                                      , texto_nombres _
                                                      , txtdatoidcliente.Text _
                                                      , txtdireccionprincipal.Text _
                                                      , txttelefono.Text _
                                                      , txttelefonocelular.Text _
                                                      , txtemailprincipal.Text)

            Dim script As String = "function f(){returnToParent('" & texto_envio & "'); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTOS GENERALES"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: MUESTRA CUADRO EMERGENTE PARA NOTIFICACIONES
    ''' </summary>
    ''' <param name="mensaje"></param>
    ''' <remarks></remarks>
    Private Sub MostrarMensaje(ByVal mensaje As String)
        Try
            rntMensajes.Text = mensaje
            rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
            rntMensajes.TitleIcon = "warning"
            rntMensajes.ContentIcon = "warning"
            rntMensajes.ShowSound = "warning"
            rntMensajes.Width = 400
            rntMensajes.Height = 100
            rntMensajes.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: ESTADO DE LOS BOTONES DEL MENU SEGUN ACTIVACIONES
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <remarks></remarks>
    Private Sub controles_botones(ByVal opcion As String)
        If opcion = "consultaok" Then
            divBtnAceptar.Visible = True
            divbtnmodificar.Visible = True
            divbtnnuevo.Visible = False
            divBtnConsulta.Visible = True
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = True
        ElseIf opcion = "consultavacia" Then
            divBtnAceptar.Visible = False
            divbtnmodificar.Visible = False
            divbtnnuevo.Visible = True
            divBtnConsulta.Visible = True
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = True
        ElseIf opcion = "nuevo" Then
            divBtnAceptar.Visible = False
            divbtnmodificar.Visible = False
            divbtnnuevo.Visible = False
            divBtnConsulta.Visible = False
            divbtnguarda.Visible = True
            divbtnlimpiar.Visible = True
        ElseIf opcion = "modifica" Then
            divBtnAceptar.Visible = False
            divbtnmodificar.Visible = False
            divbtnnuevo.Visible = False
            divBtnConsulta.Visible = False
            divbtnguarda.Visible = True
            divbtnlimpiar.Visible = True
        ElseIf opcion = "guardar" Then
            divBtnAceptar.Visible = False
            divbtnmodificar.Visible = False
            divbtnnuevo.Visible = True
            divBtnConsulta.Visible = True
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = False
        ElseIf opcion = "inicio" Then
            divBtnConsulta.Visible = True
            divbtnmodificar.Visible = False
            divbtnnuevo.Visible = True
            divBtnAceptar.Visible = False
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: ESTADOS DE LOS CONTROLES DEL FORM - ENABLED
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <remarks></remarks>
    Private Sub controles_estados(ByVal estado As Boolean)
        txtbusqueda.Enabled = Not estado
        txtdatoidcliente.Enabled = estado
        txtdatoapellidomadre.Enabled = estado
        txtdatoapellidopadre.Enabled = estado
        txtdatonombreprimero.Enabled = estado
        txtdatonombresegundo.Enabled = estado
        txtdireccionprincipal.Enabled = estado
        txtdireccioninterseccion.Enabled = estado
        txtdireccionnumero.Enabled = estado
        txttelefono.Enabled = estado
        txttelefonocelular.Enabled = estado
        txtemailprincipal.Enabled = estado
        cmbdatotipoidcliente.Enabled = estado
        cmbdatosexo.Enabled = estado
        cmbdireccionprovincia.Enabled = estado
        cmbdireccionsector.Enabled = estado
        cmbdireccionparroquia.Enabled = estado
        cmbdireccionciudad.Enabled = estado
        dtpdatofechanacimiento.Enabled = estado
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: ENCERAR CONTROLES DEL FORM
    ''' </summary>
    ''' <param name="todo"></param>
    ''' <remarks></remarks>
    Private Sub controles_limpiar(ByVal todo As Boolean, ByVal cliente As String)
        txtbusqueda.Text = cliente
        txtdatoidcliente.Text = ""
        txtdatoapellidomadre.Text = ""
        txtdatoapellidopadre.Text = ""
        txtdatonombreprimero.Text = ""
        txtdatonombresegundo.Text = ""
        txtdireccionprincipal.Text = ""
        txtdireccioninterseccion.Text = ""
        txtdireccionnumero.Text = ""
        txttelefono.Text = ""
        txttelefonocelular.Text = ""
        txtemailprincipal.Text = ""
        cmbdatotipoidcliente.SelectedIndex = 0
        cmbdatosexo.SelectedIndex = 0
        cmbdireccionprovincia.SelectedIndex = 0
        cmbdireccionsector.SelectedIndex = 0
        cmbdireccionciudad.SelectedIndex = 0
        cmbdireccionparroquia.SelectedIndex = 0
        dtpdatofechanacimiento.MaxDate = DateAdd(DateInterval.Year, -1, Date.Now)
        dtpdatofechanacimiento.SelectedDate = DateAdd(DateInterval.Year, -18, Date.Now)
        If todo Then
            controles_botones("inicio")
            Me.rgdconsulta.DataSource = ""
            Me.rgdconsulta.DataBind()
            idcliente = ""
        End If
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: LLAMA EL POBLADO DE LOS COMBOS DEL FORM Y CONSULTA LA DATA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub llenar_combos()
        Try
            'CONSULTA TRAE VARIAS TABLAS CON RESULTADOS
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaCatalogosMonitoreo()
            'TIPO IDENTIFICACION
            poblar_combo(cmbdatotipoidcliente, dTDatosCliente.Tables(0))
            poblar_combo(cmbdatosexo, dTDatosCliente.Tables(8))
            poblar_combo(cmbdireccionprovincia, dTDatosCliente.Tables(11))
            poblar_combo(cmbdireccionciudad, dTDatosCliente.Tables(12))
            poblar_combo(cmbdireccionparroquia, dTDatosCliente.Tables(13))
            poblar_combo(cmbdireccionsector, dTDatosCliente.Tables(14))

            Dim dTDatosProvincia As New DataSet
            dTDatosProvincia = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("120", "001", "", "", "")
            poblar_combo(cmbdireccionprovincia, dTDatosProvincia.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: OBTIENE EL COMBO Y LOS DATOS PARA HACER EL POBLADO
    ''' </summary>
    ''' <param name="combo"></param>
    ''' <param name="tabla"></param>
    ''' <remarks></remarks>
    Private Sub poblar_combo(ByVal combo As Telerik.Web.UI.RadComboBox, ByVal tabla As DataTable)
        Try
            combo.DataSource = tabla
            combo.DataTextField = "DESCRIPCION"
            combo.DataValueField = "CODIGO"
            combo.DataBind()
            combo.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: VALIDA CONTROLES PARA PROCEDER A GUARDAR
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function validar() As Boolean
        Dim retorno As Boolean = False

        If txtdatoapellidopadre.Text = "" Then
            retorno = True
            txtdatoapellidopadre.Focus()
            MostrarMensaje("Por favor ingresar apellido paterno")
        ElseIf txtdatoapellidomadre.Text = "" Then
            retorno = True
            txtdatoapellidomadre.Focus()
            MostrarMensaje("Por favor ingresar apellido materno")
        ElseIf txtdatonombreprimero.Text = "" Then
            retorno = True
            txtdatonombreprimero.Focus()
            MostrarMensaje("Por favor ingresar primer nombre")
        ElseIf txtdatonombresegundo.Text = "" Then
            retorno = True
            txtdatonombresegundo.Focus()
            MostrarMensaje("Por favor ingresar segundo nombre")
        ElseIf txtdatoidcliente.Text = "" Then
            retorno = True
            txtdatoidcliente.Focus()
            MostrarMensaje("Por favor ingresar identificación del cliente")
        ElseIf txtdireccionprincipal.Text = "" Then
            retorno = True
            txtdireccionprincipal.Focus()
            MostrarMensaje("Por favor ingresar dirección")
        ElseIf txtdireccioninterseccion.Text = "" Then
            retorno = True
            txtdireccioninterseccion.Focus()
            MostrarMensaje("Por favor ingresar intersección de dirección")
        ElseIf txtdireccionprincipal.Text = "" Then
            retorno = True
            txtdireccionprincipal.Focus()
            MostrarMensaje("Por favor ingresar número de dirección")
        ElseIf txttelefonocelular.Text = "" Then
            retorno = True
            txttelefonocelular.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono celular")
        ElseIf txttelefonocelular.Text.Substring(0, 1) <> "0" Then
            retorno = True
            txttelefonocelular.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono celular válido")
        ElseIf txttelefonocelular.Text.Length < 10 Then
            retorno = True
            txttelefonocelular.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono celular válido")
        ElseIf txttelefono.Text = "" Then
            retorno = True
            txttelefono.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono fijo")
        ElseIf txttelefono.Text.Length > 9 Or txttelefono.Text.Length < 7 Then
            retorno = True
            txttelefono.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono fijo válido")
        ElseIf txtemailprincipal.Text = "" Then
            retorno = True
            txtemailprincipal.Focus()
            MostrarMensaje("Por favor ingresar email principal")
        ElseIf Not txtemailprincipal.Text.Contains("@") Then
            retorno = True
            txtemailprincipal.Focus()
            MostrarMensaje("Por favor ingresar email principal válido")
        ElseIf Not txtemailprincipal.Text.Contains(".") Then
            retorno = True
            txtemailprincipal.Focus()
            MostrarMensaje("Por favor ingresar email principal válido")
        ElseIf cmbdatosexo.SelectedIndex < 1 Then
            retorno = True
            cmbdatosexo.Focus()
            MostrarMensaje("Por favor seleccionar un género")
        ElseIf cmbdatotipoidcliente.SelectedIndex < 1 Then
            retorno = True
            cmbdatotipoidcliente.Focus()
            MostrarMensaje("Por favor seleccionar un tipo de identificación")
        ElseIf cmbdireccionciudad.SelectedIndex < 1 Then
            retorno = True
            cmbdireccionciudad.Focus()
            MostrarMensaje("Por favor seleccionar una ciudad")
        ElseIf cmbdireccionparroquia.SelectedIndex < 1 Then
            retorno = True
            cmbdireccionparroquia.Focus()
            MostrarMensaje("Por favor seleccionar una parroquia")
        ElseIf cmbdireccionprovincia.SelectedIndex < 1 Then
            retorno = True
            cmbdireccionprovincia.Focus()
            MostrarMensaje("Por favor seleccionar una provincia")
        ElseIf cmbdireccionsector.SelectedIndex < 1 Then
            retorno = True
            cmbdireccionsector.Focus()
            MostrarMensaje("Por favor seleccionar un sector")
        ElseIf dtpdatofechanacimiento.SelectedDate > DateAdd(DateInterval.Year, -18, Date.Now) Then
            retorno = True
            dtpdatofechanacimiento.Focus()
            MostrarMensaje("Por favor ingrese fecha nacimiento del cliente válida")
        End If

        If cmbdatotipoidcliente.SelectedValue = "001" Or cmbdatotipoidcliente.SelectedValue = "002" Then
            If txtdatoidcliente.Text.Length < 10 Or txtdatoidcliente.Text.Length > 13 Then
                retorno = True
                txtdatoidcliente.Focus()
                MostrarMensaje("Por favor ingresar identificación válida")
            End If
        End If

        Return retorno
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: LLENA COMBO DE DATOS DE CIUDAD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LlenaComboCiudad()
        Try
            Me.cmbdireccionciudad.DataSource = ""
            Me.cmbdireccionciudad.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("121", "001", cmbdireccionprovincia.SelectedValue, "", "")
            poblar_combo(cmbdireccionciudad, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: LLENA COMBO DE DATOS DE PARROQUIA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LlenaComboParroquia()
        Try
            Me.cmbdireccionparroquia.DataSource = ""
            Me.cmbdireccionparroquia.DataBind()
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("122", "", cmbdireccionprovincia.SelectedValue, cmbdireccionciudad.SelectedValue, "")
            poblar_combo(cmbdireccionparroquia, dTDatosCliente.Tables(0))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: LLENA LOS CONTROLES DE MODIFICACION DE CLIENTE
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Private Sub llena_datos_modificar(ByVal ID As String)
        If Not ID Is Nothing Or ID <> "" Then
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreoDatos(ID)
            If Not dTDatosCliente Is Nothing Then
                controles_botones("modifica")
                controles_estados(True)
                txtregistro.Text = "MODIFICA"

                txtdatoidcliente.Text = ID
                txtdatoapellidomadre.Text = dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_MATERNO").ToString
                txtdatoapellidopadre.Text = dTDatosCliente.Tables(0).Rows(0).Item("APELLIDO_PATERNO").ToString
                txtdatonombreprimero.Text = dTDatosCliente.Tables(0).Rows(0).Item("PRIMER_NOMBRE").ToString
                txtdatonombresegundo.Text = dTDatosCliente.Tables(0).Rows(0).Item("SEGUNDO_NOMBRE").ToString
                dtpdatofechanacimiento.SelectedDate = dTDatosCliente.Tables(0).Rows(0).Item("FECHA_NACIMIENTO").ToString
                dtpdatofechanacimiento.DateInput.DisplayText = dTDatosCliente.Tables(0).Rows(0).Item("FECHA_NACIMIENTO").ToString
                cmbdatotipoidcliente.SelectedValue = dTDatosCliente.Tables(0).Rows(0).Item("TIPO_ID").ToString
                cmbdatosexo.SelectedValue = dTDatosCliente.Tables(0).Rows(0).Item("SEXO").ToString
                cmbdireccionprovincia.SelectedValue = dTDatosCliente.Tables(0).Rows(0).Item("PROVINCIA").ToString
                LlenaComboCiudad()
                cmbdireccionciudad.SelectedValue = dTDatosCliente.Tables(0).Rows(0).Item("CIUDAD").ToString
                LlenaComboParroquia()
                cmbdireccionparroquia.SelectedValue = dTDatosCliente.Tables(0).Rows(0).Item("PARROQUIA").ToString
                cmbdireccionsector.SelectedValue = dTDatosCliente.Tables(0).Rows(0).Item("SECTOR").ToString
                txtdireccionprincipal.Text = dTDatosCliente.Tables(0).Rows(0).Item("DIRECCION").ToString
                txtdireccioninterseccion.Text = dTDatosCliente.Tables(0).Rows(0).Item("INTERSECCION").ToString
                txtdireccionnumero.Text = dTDatosCliente.Tables(0).Rows(0).Item("NUMERO").ToString
                txttelefonocelular.Text = dTDatosCliente.Tables(0).Rows(0).Item("CELULAR").ToString
                txttelefono.Text = dTDatosCliente.Tables(0).Rows(0).Item("TELEFONO").ToString
                txtemailprincipal.Text = dTDatosCliente.Tables(0).Rows(0).Item("EMAILPRINCIPAL").ToString
                txtdatoidcliente.Enabled = False
            Else
                ID = ""
                MostrarMensaje("Problemas al extraer datos del cliente.")
                controles_estados(True)
                controles_botones("consultavacia")
            End If
        End If
    End Sub

#End Region

End Class