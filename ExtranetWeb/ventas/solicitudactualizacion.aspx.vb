Imports System.Web.Services.Description

Public Class solicitudactualizacion
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                metodos_master("Mi cuenta - Editar", 1, "Nodificacion de datos personales")
                mensajeria_error("", "")

                CargaListaProvincias()
                CargaDatosPersonales()
                CargaDatosDirecciones()
                CargaDatosTelefonos()
                carga_datos_facturacion_ns()

                If txtdfa_email01.Text = "" Then
                    carga_datos_facturacion_3s()
                End If

                Session("CORREO") = Me.txtdtp_email01.Text
                Session("CELULARDOMI") = Me.txtdmc_telefono02.Text.ToString
                Session("CELULAROFI") = Me.txtdof_telefono02.Text.ToString
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub CargaDatosPersonales()
        Try
            Dim dTDatosPersonales As DataTable
            Dim dTDatosPersonales_aux As DataSet
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()

            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", Session("user_netsuite"), "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                lbldtp_identificacion.Text = dTDatosPersonales.Rows(0)("Cedula_Ruc")
                lbldtp_nombres.Text = dTDatosPersonales.Rows(0)("NombreCompleto").ToString.ToUpper
                'lbldtp_email1.Text = dTDatosPersonales.Rows(0)("email")
            End If
            dTDatosPersonales_aux = DatosPersonalesAdapter.ConsultaDatosPersonalesCliente(Session.Item("user"))
            If dTDatosPersonales_aux.Tables(0).Rows.Count > 0 Then
                If dTDatosPersonales_aux.Tables(0).Rows(0)("TIPO_CLIENTE") = "001" Then
                    labeldtp_fechanacimiento.Text = "Fecha de Nacimiento"
                Else
                    labeldtp_fechanacimiento.Text = "Fecha de Constitución"
                End If
                Me.txtdtp_fechanac01.Text = DateTime.Parse(dTDatosPersonales_aux.Tables(0).Rows(0)("FECHA_CREACION")).ToString("yyyy-MM-dd")
                txtdtp_email01.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("EMAIL")
                txtdtp_email02.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("EMAIL_SECUNDARIO")
                lbl_emailregistro.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("EMAIL_REGISTRO")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargaDatosDirecciones()
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosDirecciones As DataTable
            dTDatosDirecciones = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "101", "", Session("user_netsuite"), "", "", ""))
            If dTDatosDirecciones.Rows.Count > 0 Then
                For i As Integer = 0 To dTDatosDirecciones.Rows.Count - 1
                    If dTDatosDirecciones.Rows(i)("IdTipoDireccion").ToString = "6" Then
                        CbxdmcProvincia01.SelectedValue = dTDatosDirecciones.Rows(i)("IdProvincia")
                        CargaListaCiudades(CbxdmcProvincia01.SelectedValue, "domicilio")
                        cbxdmc_ciudad01.SelectedValue = dTDatosDirecciones.Rows(i)("IdCanton")
                        txtdmc_calleprincipal01.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                        txtdmc_iddireccion.Text = dTDatosDirecciones.Rows(i)("IdDireccionNs")
                        txtdmc_iddirecciondet.Text = dTDatosDirecciones.Rows(i)("IdDireccionDetNs")
                        txtdmc_telefono01.Text = dTDatosDirecciones.Rows(i)("Telefono")
                        txtdmc_numerocalle01.Text &= "D"
                    End If
                    If dTDatosDirecciones.Rows(i)("IdTipoDireccion").ToString = "17" Then
                        CbxdofProvincia01.SelectedValue = dTDatosDirecciones.Rows(0)("IdProvincia")
                        CargaListaCiudades(CbxdofProvincia01.SelectedValue, "oficina")
                        cbxdof_ciudad01.SelectedValue = dTDatosDirecciones.Rows(i)("IdCanton")
                        txtdof_calleprincipal01.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                        txtdof_iddireccion.Text = dTDatosDirecciones.Rows(i)("IdDireccionNs")
                        txtdof_iddirecciondet.Text = dTDatosDirecciones.Rows(i)("IdDireccionDetNs")
                        txtdof_telefono01.Text = dTDatosDirecciones.Rows(i)("Telefono")
                        txtdof_numerocalle01.Text &= "D"
                    End If
                    If dTDatosDirecciones.Rows(i)("IdTipoDireccion").ToString = "4" Then
                        CbxdfaProvincia01.SelectedValue = dTDatosDirecciones.Rows(0)("IdProvincia")
                        CargaListaCiudades(CbxdfaProvincia01.SelectedValue, "factura")
                        cbxdfa_ciudad01.SelectedValue = dTDatosDirecciones.Rows(i)("IdCanton")
                        txtdfa_calleprincipal01.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                        txtdfa_iddireccion.Text = dTDatosDirecciones.Rows(i)("IdDireccionNs")
                        txtdfa_iddirecciondet.Text = dTDatosDirecciones.Rows(i)("IdDireccionDetNs")
                        txtdfa_telefono01.Text = dTDatosDirecciones.Rows(i)("Telefono")
                        txtdfa_numerocalle01.Text &= "D"
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargaDatosTelefonos()
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosTelefonos As DataTable
            dTDatosTelefonos = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "102", "", Session("user_netsuite"), "", "", ""))
            If dTDatosTelefonos.Rows.Count > 0 Then
                For i As Integer = 0 To dTDatosTelefonos.Rows.Count - 1
                    If dTDatosTelefonos.Rows(i)("IdTipoTelefono").ToString = "4" Then
                        txtdmc_telefono02.Text = dTDatosTelefonos.Rows(i)("Telefono")
                        txtdof_telefono02.Text = dTDatosTelefonos.Rows(i)("Telefono")
                        txtdfa_telefono02.Text = dTDatosTelefonos.Rows(i)("Telefono")
                        txtdmc_idtelefono.Text = dTDatosTelefonos.Rows(i)("Id")
                        txtdmc_numerocalle01.Text &= "C"
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub carga_datos_facturacion_3s()
        'Try
        '    Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        '    Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        '    Dim dTDatosEmail As DataTable
        '    dTDatosEmail = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "103", "", Session("user_netsuite"), "", "", ""))
        '    If dTDatosEmail.Rows.Count > 0 Then
        '        txtdfa_email01.Text = dTDatosEmail.Rows(0)("Email")
        '    End If
        'Catch ex As Exception
        '    ExceptionHandler.Captura_Error(ex)
        'End Try
    End Sub

    Private Sub carga_datos_facturacion_ns()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        Dim dTDatosFacturacion As DataTable
        dTDatosFacturacion = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "103", "", Session("user_netsuite"), "", "", ""))
        If dTDatosFacturacion.Rows.Count > 0 Then
            For i As Integer = 0 To dTDatosFacturacion.Rows.Count - 1
                If dTDatosFacturacion.Rows(i)("IdTipoCorreo").ToString = "5" Then
                    txtdfa_email01.Text = dTDatosFacturacion.Rows(0)("Email")
                    txtdmc_idemail.Text = dTDatosFacturacion.Rows(0)("Id")
                    txtdfa_numerocalle01.Text &= "E"
                End If
            Next
        End If
    End Sub

    Private Sub CargaListaProvincias()
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamCatalogosClientes").ToString()
            Dim dTListaProvincias As DataTable
            dTListaProvincias = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "PROV", "", "", "", "", ""))
            If dTListaProvincias.Rows.Count > 0 Then
                Me.CbxdmcProvincia01.DataSource = dTListaProvincias
                Me.CbxdmcProvincia01.DataTextField = "Descripcion"
                Me.CbxdmcProvincia01.DataValueField = "Id"
                CbxdmcProvincia01.DataBind()
                Me.CbxdofProvincia01.DataSource = dTListaProvincias
                Me.CbxdofProvincia01.DataTextField = "Descripcion"
                Me.CbxdofProvincia01.DataValueField = "Id"
                CbxdofProvincia01.DataBind()
                Me.CbxdfaProvincia01.DataSource = dTListaProvincias
                Me.CbxdfaProvincia01.DataTextField = "Descripcion"
                Me.CbxdfaProvincia01.DataValueField = "Id"
                CbxdfaProvincia01.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargaListaCiudades(ByVal provinciaid As String, tipo As String)
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamCatalogosClientes").ToString()
            Dim dTListaCiudades As DataTable
            dTListaCiudades = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "CIU", provinciaid, "", "", "", ""))
            If dTListaCiudades.Rows.Count > 0 And tipo = "domicilio" Then
                Me.cbxdmc_ciudad01.DataSource = dTListaCiudades
                Me.cbxdmc_ciudad01.DataTextField = "Descripcion"
                Me.cbxdmc_ciudad01.DataValueField = "Id"
                cbxdmc_ciudad01.DataBind()
            ElseIf dTListaCiudades.Rows.Count > 0 And tipo = "oficina" Then
                Me.cbxdof_ciudad01.DataSource = dTListaCiudades
                Me.cbxdof_ciudad01.DataTextField = "Descripcion"
                Me.cbxdof_ciudad01.DataValueField = "Id"
                cbxdof_ciudad01.DataBind()
            ElseIf dTListaCiudades.Rows.Count > 0 And tipo = "factura" Then
                Me.cbxdfa_ciudad01.DataSource = dTListaCiudades
                Me.cbxdfa_ciudad01.DataTextField = "Descripcion"
                Me.cbxdfa_ciudad01.DataValueField = "Id"
                cbxdfa_ciudad01.DataBind()
            End If
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

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

#End Region

#Region "Combos"

    Protected Sub CbxdmcProvincia01_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbxdmcProvincia01.SelectedIndexChanged
        Try
            CargaListaCiudades(CbxdmcProvincia01.SelectedValue, "domicilio")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub CbxdofProvincia01_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbxdofProvincia01.SelectedIndexChanged
        Try
            CargaListaCiudades(CbxdofProvincia01.SelectedValue, "oficina")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub CbxdfaProvincia01_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbxdfaProvincia01.SelectedIndexChanged
        Try
            CargaListaCiudades(CbxdfaProvincia01.SelectedValue, "factura")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "botones - controles"

    Protected Sub btngrabardatos_Click(sender As Object, e As EventArgs) Handles btngrabardatos.Click
        Try
            If RegistroValidar() Then
                RegistroDatosDirecciones()
                RegistroDatosTelefonos()
                RegistroDatosEmails()
                mensajeria_error("informacion", "datos personales, guardados con éxito")
                'btngrabardatos.Enabled = False
            End If
        Catch ex As Exception
            mensajeria_error("error", "no se pudo guardar datos.")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Registros Datos"

    Private Sub RegistroDatosDirecciones()
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro_ns As String = ""
            Dim mensaje As String = ""
            If txtdmc_numerocalle01.Text.Contains("D") Then
                parametro_ns = ConfigurationManager.AppSettings.Get("NSParamUpdateDireccion").ToString()
                parametro_ns = String.Format(parametro_ns, "DIR", Session("user_netsuite"), txtdmc_iddireccion.Text, txtdmc_iddirecciondet.Text, txtdmc_calleprincipal01.Text, txtdmc_calleprincipal01.Text, "EC", txtdmc_telefono01.Text, "6", CbxdmcProvincia01.SelectedValue, cbxdmc_ciudad01.SelectedValue, "")
                parametro_ns = "{" & parametro_ns & "}"
                mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "update")
                If txtdof_numerocalle01.Text.Contains("D") Then
                    parametro_ns = ConfigurationManager.AppSettings.Get("NSParamUpdateDireccion").ToString()
                    parametro_ns = String.Format(parametro_ns, "DIR", Session("user_netsuite"), txtdof_iddireccion.Text, txtdof_iddirecciondet.Text, txtdof_calleprincipal01.Text, txtdof_calleprincipal01.Text, "EC", txtdof_telefono01.Text, "17", CbxdofProvincia01.SelectedValue, cbxdof_ciudad01.SelectedValue, "")
                    parametro_ns = "{" & parametro_ns & "}"
                    mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "update")
                    If txtdfa_numerocalle01.Text.Contains("D") Then
                        parametro_ns = ConfigurationManager.AppSettings.Get("NSParamUpdateDireccion").ToString()
                        parametro_ns = String.Format(parametro_ns, "DIR", Session("user_netsuite"), txtdfa_iddireccion.Text, txtdfa_iddirecciondet.Text, txtdfa_calleprincipal01.Text, txtdfa_calleprincipal01.Text, "EC", txtdfa_telefono01.Text, "4", CbxdfaProvincia01.SelectedValue, cbxdfa_ciudad01.SelectedValue, "")
                        parametro_ns = "{" & parametro_ns & "}"
                        mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "update")
                    Else
                        parametro_ns = ConfigurationManager.AppSettings.Get("NSParamInsertDireccion").ToString()
                        parametro_ns = String.Format(parametro_ns, "DIR", Session("user_netsuite"), txtdmc_iddireccion.Text, txtdmc_iddirecciondet.Text, "EC", txtdmc_telefono01.Text, "6", CbxdmcProvincia01.SelectedValue, cbxdmc_ciudad01.SelectedValue, "", False, False)
                        parametro_ns = "{" & parametro_ns & "}"
                        mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "insert")
                    End If
                Else
                    parametro_ns = ConfigurationManager.AppSettings.Get("NSParamInsertDireccion").ToString()
                    parametro_ns = String.Format(parametro_ns, "DIR", Session("user_netsuite"), txtdof_iddireccion.Text, txtdof_iddirecciondet.Text, "EC", txtdof_telefono01.Text, "17", CbxdofProvincia01.SelectedValue, cbxdof_ciudad01.SelectedValue, "", False, False)
                    parametro_ns = "{" & parametro_ns & "}"
                    mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "insert")
                End If
            Else
                parametro_ns = ConfigurationManager.AppSettings.Get("NSParamInsertDireccion").ToString()
                parametro_ns = String.Format(parametro_ns, "DIR", Session("user_netsuite"), txtdfa_iddireccion.Text, txtdfa_iddirecciondet.Text, "EC", txtdfa_telefono01.Text, "4", CbxdfaProvincia01.SelectedValue, cbxdfa_ciudad01.SelectedValue, "", False, False)
                parametro_ns = "{" & parametro_ns & "}"
                mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "insert")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub RegistroDatosTelefonos()
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro_ns As String = ""
            Dim mensaje As String = ""
            If txtdmc_numerocalle01.Text.Contains("C") Then
                parametro_ns = ConfigurationManager.AppSettings.Get("NSParamUpdateTelefono").ToString()
                parametro_ns = String.Format(parametro_ns, "TEL", txtdmc_idtelefono.Text, txtdmc_telefono02.Text, "f", "4")
                parametro_ns = "{" & parametro_ns & "}"
                mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "update")
            Else
                parametro_ns = ConfigurationManager.AppSettings.Get("NSParamInsertTelefono").ToString()
                parametro_ns = String.Format(parametro_ns, "TEL", Session("user_netsuite"), txtdmc_telefono02.Text, "f", "4")
                parametro_ns = "{" & parametro_ns & "}"
                mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "insert")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub RegistroDatosEmails()
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro_ns As String = ""
            Dim mensaje As String = ""
            If txtdfa_numerocalle01.Text.Contains("E") Then
                parametro_ns = ConfigurationManager.AppSettings.Get("NSParamUpdateEmail").ToString()
                parametro_ns = String.Format(parametro_ns, "MAIL", txtdmc_idemail.Text, txtdfa_email01.Text, "f", "5")
                parametro_ns = "{" & parametro_ns & "}"
                mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "update")
            Else
                parametro_ns = ConfigurationManager.AppSettings.Get("NSParamInsertEmail").ToString()
                parametro_ns = String.Format(parametro_ns, "MAIL", Session("user_netsuite"), txtdfa_email01.Text, "f", "5")
                parametro_ns = "{" & parametro_ns & "}"
                mensaje = SolicitudActualizacionAdapter.RegistroDatosDireccion(id_script, parametro_ns, "update")
            End If
        Catch ex As Exception
            'ConfigMsg(2, "Ocurrió un error al actualizar la información del cliente")
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function RegistroValidar() As Boolean
        Dim retorno As Boolean = True
        Try
            If txtdmc_calleprincipal01.Text = "" Or txtdof_calleprincipal01.Text = "" Or txtdfa_calleprincipal01.Text = "" Then
                retorno = False
                mensajeria_error("error", "por favor ingrese direccion de facturación")
            ElseIf txtdfa_email01.Text = "" Then
                retorno = False
                mensajeria_error("error", "por favor ingrese email")
            ElseIf txtdmc_telefono01.Text = "" Or txtdof_telefono01.Text = "" Or txtdfa_telefono01.Text = "" Then
                retorno = False
                mensajeria_error("error", "por favor ingrese teléfono")
            ElseIf txtdmc_telefono02.Text = "" Then
                retorno = False
                mensajeria_error("error", "por favor ingrese celular")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function

#End Region

End Class