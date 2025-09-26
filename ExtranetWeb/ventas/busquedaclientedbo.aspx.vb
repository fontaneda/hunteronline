Imports Telerik.Web.UI

Public Class busquedaclientedbo
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
                Dim cliente As String = Request.QueryString("climon")

                If cliente.IndexOf(" ") > 0 Then
                    cliente = cliente.Substring(0, cliente.IndexOf(" "))
                End If

                txtdatoidcliente.Text = cliente
                txtventasclientemonitoreo.Text = cliente
                Session("clientemonitoreoenvio") = cliente
                Proc_Consulta()
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
    ''' <remarks></remarks>
    Protected Sub Proc_Consulta()
        Try
            Dim dTDatosCliente As New DataSet
            dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaClienteMonitoreo(Session("clientemonitoreoenvio"))
            If dTDatosCliente Is Nothing Then
                idcliente = Session("clientemonitoreoenvio")
                MostrarMensaje("Cliente no encontrado, puede proceder a crearlo")
                controles_estados(True)
                controles_botones("nuevo")
            Else
                If dTDatosCliente.Tables(0).Rows.Count > 0 Then
                    idcliente = Session("clientemonitoreoenvio")
                    llena_datos_modificar(idcliente)
                Else
                    MostrarMensaje("Cliente no encontrado, puede proceder a crearlo")
                    controles_estados(True)
                    controles_botones("nuevo")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
                'ClienteEntity.ClienteTipo = "001" 'cmbdatotipocliente.SelectedValue
                'ClienteEntity.ClienteActividad = "" 'cmbdatoactividad.SelectedValue
                'ClienteEntity.ClienteProfesion = cmbdatoprofesion.SelectedValue
                'ClienteEntity.ClienteEstadocivil = "000" 'cmbdatoestadocivil.SelectedValue
                ClienteEntity.ClienteSexo = cmbdatosexo.SelectedValue
                'DATOS DIRECCION
                ClienteDetalleEntity = New ClienteDetalleEntity
                'ClienteDetalleEntity.DireccionTipo = "001" 'cmbdirecciontipo.SelectedValue
                ClienteDetalleEntity.DireccionSectorId = cmbdireccionsector.SelectedValue
                'ClienteDetalleEntity.DireccionPaisId = "001" 'cmbdireccionpais.SelectedValue
                ClienteDetalleEntity.DireccionProvinciaId = cmbdireccionprovincia.SelectedValue
                ClienteDetalleEntity.DireccionCiudadId = cmbdireccionciudad.SelectedValue
                ClienteDetalleEntity.DireccionParroquiaId = cmbdireccionparroquia.SelectedValue
                ClienteDetalleEntity.Direccion = txtdireccionprincipal.Text
                ClienteDetalleEntity.DireccionInterseccion = txtdireccioninterseccion.Text
                ClienteDetalleEntity.DireccionNumero = txtdireccionnumero.Text
                'DATOS TELEFONO
                'ClienteDetalleEntity.TelefonoTipo = "004" 'cmbtelefonotipo.SelectedValue
                ClienteDetalleEntity.Telefono = txttelefononumero.Text
                'ClienteDetalleEntity.TelefonoExtension = "0" 'txttelefonoextension.Text
                'DATOS PARIENTE
                'ClienteDetalleEntity.ParienteTipo = cmbparientetipo.SelectedValue
                'ClienteDetalleEntity.ParienteFechaNacimiento = dtpparientenacimiento.SelectedDate
                'ClienteDetalleEntity.ParienteApellidoPaterno = txtparienteapellidopadre.Text
                'ClienteDetalleEntity.ParienteApellidoMaterno = txtparienteapellidomadre.Text
                'ClienteDetalleEntity.ParienteNombres = txtparientenombre.Text
                'ClienteDetalleEntity.ParienteDireccion = txtparientedireccion.Text
                'ClienteDetalleEntity.ParienteTelefono = txtparientetelefono.Text
                'DATOS REFERENCIA BANCARIA
                'ClienteDetalleEntity.EntidadTipo = cmbreferenciatipo.SelectedValue
                'ClienteDetalleEntity.Entidad = cmbreferenciacuenta.SelectedValue
                'ClienteDetalleEntity.EntidadNumero = txtreferenciacuenta.Text
                ClienteDetalleEntity.EmailPrincipal = txtemailprincipal.Text
                ClienteDetalleEntity.EmailAlerta = txtemailprincipal.Text

                ClienteDetalleEntityCollection.Add(ClienteDetalleEntity)
                ClienteEntity.ClienteDetalleEntityCollection = ClienteDetalleEntityCollection
                If DatosPersonalesAdapter.RegistroCliente(ClienteEntity) Then
                    txtventasclientemonitoreo.Text = String.Format("{0} - {1} {2}", txtdatoidcliente.Text, txtdatoapellidopadre.Text, txtdatonombreprimero.Text)
                    MostrarMensaje("Cliente de monitoreo guardado con éxito")
                    'controles_limpiar(True, idcliente)
                    'BtnConsulta_Click(sender, e)
                    controles_botones("guardar")
                    controles_estados(False)

                    Dim texto_envio As String = String.Format("{0} {1}", Session("clientemonitoreoenvio"), Session("clientemonitoreo_nombres"))
                    Dim script As String = "function f(){returnToParent('" & texto_envio & "'); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)

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
        If txtdatoidcliente.Text <> "" Then
            'Dim id As String = item("ID_CLIENTE").Text
            'llena_datos_modificar(id)
            controles_estados("modifica")
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
    ''' COMENTARIO: EVENTO CLICK DEL BOTON PARA ACEPTAR TODOS LOS DATOS REQUERIDOS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        Try
            Dim texto_envio As String = String.Format("{0}", Session("clientemonitoreoenvio"))

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
            divbtnmodificar.Visible = True
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = True
        ElseIf opcion = "consultavacia" Then
            divbtnmodificar.Visible = False
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = True
        ElseIf opcion = "nuevo" Then
             divbtnmodificar.Visible = False
            divbtnguarda.Visible = True
            divbtnlimpiar.Visible = True
        ElseIf opcion = "modifica" Then
            divbtnmodificar.Visible = False
            divbtnguarda.Visible = True
            divbtnlimpiar.Visible = True
        ElseIf opcion = "guardar" Then
            divbtnmodificar.Visible = False
            divbtnguarda.Visible = False
            divbtnlimpiar.Visible = False
        ElseIf opcion = "inicio" Then
            divbtnmodificar.Visible = False
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
        txtdatoidcliente.Enabled = False
        txtdatoapellidomadre.Enabled = estado
        txtdatoapellidopadre.Enabled = estado
        txtdatonombreprimero.Enabled = estado
        txtdatonombresegundo.Enabled = estado
        txtdireccionprincipal.Enabled = estado
        txtdireccioninterseccion.Enabled = estado
        txtdireccionnumero.Enabled = estado
        'txtparienteapellidomadre.Enabled = estado
        'txtparienteapellidopadre.Enabled = estado
        'txtparientedireccion.Enabled = estado
        'txtparientenombre.Enabled = estado
        'txtparientetelefono.Enabled = estado
        'txtreferenciacuenta.Enabled = estado
        'txttelefonoextension.Enabled = estado
        txttelefononumero.Enabled = estado
        txtemailprincipal.Enabled = estado
        'txtemailalertas.Enabled = estado
        cmbdatotipoidcliente.Enabled = estado
        'cmbdatoactividad.Enabled = estado
        'cmbdatoprofesion.Enabled = estado
        'cmbdatoestadocivil.Enabled = estado
        cmbdatosexo.Enabled = estado
        'cmbdatotipocliente.Enabled = estado
        'cmbdireccionpais.Enabled = estado
        cmbdireccionprovincia.Enabled = estado
        cmbdireccionsector.Enabled = estado
        'cmbdirecciontipo.Enabled = estado
        cmbdireccionparroquia.Enabled = estado
        cmbdireccionciudad.Enabled = estado
        'cmbparientetipo.Enabled = estado
        'cmbreferenciacuenta.Enabled = estado
        'cmbreferenciatipo.Enabled = estado
        'cmbtelefonotipo.Enabled = estado
        dtpdatofechanacimiento.Enabled = estado
        'dtpparientenacimiento.Enabled = estado
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: ENCERAR CONTROLES DEL FORM
    ''' </summary>
    ''' <param name="todo"></param>
    ''' <remarks></remarks>
    Private Sub controles_limpiar(ByVal todo As Boolean, ByVal cliente As String)
        txtdatoidcliente.Text = ""
        txtdatoapellidomadre.Text = ""
        txtdatoapellidopadre.Text = ""
        txtdatonombreprimero.Text = ""
        txtdatonombresegundo.Text = ""
        txtdireccionprincipal.Text = ""
        txtdireccioninterseccion.Text = ""
        txtdireccionnumero.Text = ""
        'txtparienteapellidomadre.Text = ""
        'txtparienteapellidopadre.Text = ""
        'txtparientedireccion.Text = ""
        'txtparientenombre.Text = ""
        'txtparientetelefono.Text = ""
        'txtreferenciacuenta.Text = ""
        'txttelefonoextension.Text = ""
        txttelefononumero.Text = ""
        txtemailprincipal.Text = ""
        'txtemailalertas.Text = ""
        cmbdatotipoidcliente.SelectedIndex = 0
        'cmbdatoactividad.SelectedIndex = 0
        'cmbdatoprofesion.SelectedIndex = 0
        'cmbdatoestadocivil.SelectedIndex = 0
        cmbdatosexo.SelectedIndex = 0
        'cmbdatotipocliente.SelectedIndex = 0
        'cmbdireccionpais.SelectedIndex = 0
        cmbdireccionprovincia.SelectedIndex = 0
        cmbdireccionsector.SelectedIndex = 0
        'cmbdirecciontipo.SelectedIndex = 0
        cmbdireccionciudad.SelectedIndex = 0
        cmbdireccionparroquia.SelectedIndex = 0
        'cmbparientetipo.SelectedIndex = 0
        'cmbreferenciacuenta.SelectedIndex = 0
        'cmbreferenciatipo.SelectedIndex = 0
        'cmbtelefonotipo.SelectedIndex = 0
        dtpdatofechanacimiento.MaxDate = DateAdd(DateInterval.Year, -1, Date.Now)
        dtpdatofechanacimiento.SelectedDate = DateAdd(DateInterval.Year, -18, Date.Now)
        'dtpparientenacimiento.MaxDate = DateAdd(DateInterval.Year, -18, Date.Now)
        'dtpparientenacimiento.SelectedDate = DateAdd(DateInterval.Year, -18, Date.Now)
        If todo Then
            controles_botones("inicio")
            idcliente = Session("clientemonitoreoenvio")
        End If

        'If Session("ES_AMI") = "NO" Then
        '    Me.Div6.Visible = False
        'End If
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
            'poblar_combo(cmbdatotipocliente, dTDatosCliente.Tables(1))
            'poblar_combo(cmbdatoestadocivil, dTDatosCliente.Tables(2))
            'poblar_combo(cmbdatoactividad, dTDatosCliente.Tables(3))
            'poblar_combo(cmbdatoprofesion, dTDatosCliente.Tables(4))
            'poblar_combo(cmbdirecciontipo, dTDatosCliente.Tables(5))
            'poblar_combo(cmbtelefonotipo, dTDatosCliente.Tables(6))
            'poblar_combo(cmbparientetipo, dTDatosCliente.Tables(7))
            poblar_combo(cmbdatosexo, dTDatosCliente.Tables(8))
            'poblar_combo(cmbreferenciatipo, dTDatosCliente.Tables(9))
            'poblar_combo(cmbdireccionpais, dTDatosCliente.Tables(10))
            poblar_combo(cmbdireccionprovincia, dTDatosCliente.Tables(11))
            poblar_combo(cmbdireccionciudad, dTDatosCliente.Tables(12))
            poblar_combo(cmbdireccionparroquia, dTDatosCliente.Tables(13))
            poblar_combo(cmbdireccionsector, dTDatosCliente.Tables(14))
            'poblar_combo(cmbreferenciacuenta, dTDatosCliente.Tables(15))

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
        ElseIf txttelefononumero.Text = "" Then
            retorno = True
            txttelefononumero.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono")
        ElseIf txttelefononumero.Text.Substring(0, 1) <> "0" Then
            retorno = True
            txttelefononumero.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono válido")
        ElseIf txttelefononumero.Text.Length < 10 Then
            retorno = True
            txttelefononumero.Focus()
            MostrarMensaje("Por favor ingresar número de teléfono válido")
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

        'If Session("ES_AMI") = "SI" Then
        '    If txtemailalertas.Text = "" And Session("ES_AMI") = "SI" Then
        '        retorno = True
        '        txtemailalertas.Focus()
        '        MostrarMensaje("Por favor ingresar email de alertas")
        '    ElseIf txtemailalertas.Text = txtemailprincipal.Text Then
        '        retorno = True
        '        txtemailalertas.Focus()
        '        MostrarMensaje("Email principal y de alerta no pueden ser iguales")
        '    ElseIf Not txtemailalertas.Text.Contains("@") Then
        '        retorno = True
        '        txtemailalertas.Focus()
        '        MostrarMensaje("Por favor ingresar email principal válido")
        '    ElseIf Not txtemailalertas.Text.Contains(".") Then
        '        retorno = True
        '        txtemailalertas.Focus()
        '        MostrarMensaje("Por favor ingresar email principal válido")
        '    End If
        'End If

        'ElseIf txttelefonoextension.Text = "" Then
        '    retorno = True
        '    txttelefonoextension.Text = "0"
        'ElseIf txtparienteapellidomadre.Text = "" Then
        '    retorno = True
        '    txtparienteapellidomadre.Focus()
        '    MostrarMensaje("Por favor ingresar apellido materno de pariente")
        'ElseIf txtparienteapellidopadre.Text = "" Then
        '    retorno = True
        '    txtparienteapellidopadre.Focus()
        '    MostrarMensaje("Por favor ingresar apellido paterno de pariente")
        'ElseIf txtparientedireccion.Text = "" Then
        '    retorno = True
        '    txtparientedireccion.Focus()
        '    MostrarMensaje("Por favor ingresar dirección de pariente")
        'ElseIf txtparientenombre.Text = "" Then
        '    retorno = True
        '    txtparientenombre.Focus()
        '    MostrarMensaje("Por favor ingresar nombres de pariente")
        'ElseIf txtparientetelefono.Text = "" Then
        '    retorno = True
        '    txtparientetelefono.Focus()
        '    MostrarMensaje("Por favor ingresar teléfono de pariente")
        'ElseIf txtreferenciacuenta.Text = "" Then
        '    retorno = True
        '    txtreferenciacuenta.Focus()
        '    MostrarMensaje("Por favor ingresar cuenta de referencia")
        'ElseIf cmbdatoactividad.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbdatoactividad.Focus()
        '    MostrarMensaje("Por favor seleccionar una actividad")
        'ElseIf cmbdatoestadocivil.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbdatoestadocivil.Focus()
        '    MostrarMensaje("Por favor seleccionar un estado civil")
        'ElseIf cmbdatoprofesion.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbdatoprofesion.Focus()
        '    MostrarMensaje("Por favor seleccionar una profesion")
        'ElseIf cmbdatotipocliente.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbdatotipocliente.Focus()
        '    MostrarMensaje("Por favor seleccionar un tipo de cliente")
        'ElseIf cmbdireccionpais.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbdireccionpais.Focus()
        '    MostrarMensaje("Por favor seleccionar un país")
        'ElseIf cmbdirecciontipo.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbdirecciontipo.Focus()
        '    MostrarMensaje("Por favor seleccionar un tipo de dirección")
        'ElseIf cmbparientetipo.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbparientetipo.Focus()
        '    MostrarMensaje("Por favor seleccionar un tipo de pariente")
        'ElseIf cmbreferenciacuenta.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbreferenciacuenta.Focus()
        '    MostrarMensaje("Por favor seleccionar un banco/tarjeta")
        'ElseIf cmbreferenciatipo.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbreferenciatipo.Focus()
        '    MostrarMensaje("Por favor seleccionar un tipo de cuenta")
        'ElseIf cmbtelefonotipo.SelectedIndex < 1 Then
        '    retorno = True
        '    cmbtelefonotipo.Focus()
        '    MostrarMensaje("Por favor seleccionar un tipo de teléfono")
        'ElseIf dtpparientenacimiento.SelectedDate > DateAdd(DateInterval.Year, -18, Date.Now) Then
        '    retorno = True
        '    dtpparientenacimiento.Focus()
        '    MostrarMensaje("Por favor ingrese fecha nacimiento de pariente válida")
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
                txttelefononumero.Text = dTDatosCliente.Tables(0).Rows(0).Item("CELULAR").ToString
                txtemailprincipal.Text = dTDatosCliente.Tables(0).Rows(0).Item("EMAILPRINCIPAL").ToString
                'txtemailalertas.Text = dTDatosCliente.Tables(0).Rows(0).Item("EMAILALERTA").ToString
                Session("clientemonitoreo_nombres") = dTDatosCliente.Tables(0).Rows(0).Item("NOMBRE_COMPLETO").ToString
            Else
                ID = ""
                MostrarMensaje("Problemas al extraer datos del cliente.")
                controles_estados(True)
                controles_botones("consultavacia")
            End If
        End If
    End Sub

#End Region


    '    ' ''' <summary>
    '    ' ''' AUTOR: FELIX ONTANEDA C.
    '    ' ''' DESCR: INDEXCHANGE DEL COMBO TIPO CUENTA
    '    ' ''' </summary>
    '    ' ''' <param name="sender"></param>
    '    ' ''' <param name="e"></param>
    '    ' ''' <remarks></remarks>
    '    'Private Sub cmbreferenciatipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbreferenciatipo.SelectedIndexChanged
    '    '    Try
    '    '        Me.cmbreferenciacuenta.DataSource = ""
    '    '        Me.cmbreferenciacuenta.DataBind()
    '    '        Dim dTDatosCliente As New DataSet
    '    '        dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("123", "", "", "", cmbreferenciatipo.SelectedValue)
    '    '        poblar_combo(cmbreferenciacuenta, dTDatosCliente.Tables(0))
    '    '    Catch ex As Exception

    '    '    End Try
    '    'End Sub

    '    ' ''' <summary>
    '    ' ''' AUTOR: FELIX ONTANEDA C.
    '    ' ''' DESCR: INDEXCHANGE DEL COMBO PAIS
    '    ' ''' </summary>
    '    ' ''' <param name="sender"></param>
    '    ' ''' <param name="e"></param>
    '    ' ''' <remarks></remarks>
    '    'Private Sub cmbdireccionpais_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbdireccionpais.SelectedIndexChanged
    '    '    Try
    '    '        Me.cmbdireccionprovincia.DataSource = ""
    '    '        Me.cmbdireccionprovincia.DataBind()
    '    '        Dim dTDatosCliente As New DataSet
    '    '        dTDatosCliente = DatosPersonalesAdapter.ConsultaBusquedaSubCatalogosMonitoreo("120", cmbdireccionpais.SelectedValue, "", "", "")
    '    '        poblar_combo(cmbdireccionprovincia, dTDatosCliente.Tables(0))
    '    '    Catch ex As Exception

    '    '    End Try
    '    'End Sub


End Class