Imports System.Net
Imports CrystalDecisions.Shared
Imports DevExpress.Web
Imports Org.BouncyCastle.Asn1.Cmp
Imports Org.BouncyCastle.Asn1.Crmf
Imports Telerik.Web.UI
Imports RestSharp
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Text.Json.Serialization
Imports Json.Net

Public Class datospersonales
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                    metodos_master("Mi cuenta", 1, "Datos de cliente")
                    carga_datos_cliente()
                    carga_datos_direccion()
                    carga_datos_telefono()
                    carga_datos_facturacion_ns()
                    If lbldfa_email1.Text = "" Then
                        carga_datos_facturacion_3s()
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
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

    Private Sub carga_datos_cliente()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        Dim dTDatosPersonales As DataTable
        Dim dTDatosPersonales_aux As DataSet
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
            lbldtp_fechanacimiento.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("FECHA_CREACION")
            lbldtp_email1.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("EMAIL")
            lbldtp_email2.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("EMAIL_SECUNDARIO")
            lbl_emailregistro.Text = dTDatosPersonales_aux.Tables(0).Rows(0)("EMAIL_REGISTRO")
        End If
    End Sub

    Private Sub carga_datos_direccion()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        Dim dTDatosDirecciones As DataTable
        dTDatosDirecciones = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "101", "", Session("user_netsuite"), "", "", ""))
        If dTDatosDirecciones.Rows.Count > 0 Then
            For i As Integer = 0 To dTDatosDirecciones.Rows.Count - 1
                If dTDatosDirecciones.Rows(i)("IdTipoDireccion").ToString = "6" Then
                    lbldmc_provincia.Text = dTDatosDirecciones.Rows(i)("Provincia")
                    lbldmc_ciudad.Text = dTDatosDirecciones.Rows(i)("Canton")
                    lbldmc_calleprincipal.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                    'lbldmc_callenumero.Text = dTDatosDirecciones.Rows(i)("NUMERO")
                    'lbldmc_calleinterseccion.Text = dTDatosDirecciones.Rows(i)("INTERSECCION")
                End If
                If dTDatosDirecciones.Rows(i)("IdTipoDireccion").ToString = "001" Then
                    lbldof_provincia.Text = dTDatosDirecciones.Rows(i)("Provincia")
                    lbldof_ciudad.Text = dTDatosDirecciones.Rows(i)("Canton")
                    lbldof_calleprincipal.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                    lbldfa_provincia.Text = dTDatosDirecciones.Rows(i)("Provincia")
                    lbldfa_ciudad.Text = dTDatosDirecciones.Rows(i)("Canton")
                    lbldfa_calleprincipal.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                    'lbldof_callenumero.Text = dTDatosDirecciones.Rows(i)("NUMERO")
                    'lbldof_calleinterseccion.Text = dTDatosDirecciones.Rows(i)("INTERSECCION")
                End If
                If dTDatosDirecciones.Rows(i)("IdTipoDireccion").ToString = "018" Then
                    lbldfa_provincia.Text = dTDatosDirecciones.Rows(i)("Provincia")
                    lbldfa_ciudad.Text = dTDatosDirecciones.Rows(i)("Canton")
                    lbldfa_calleprincipal.Text = dTDatosDirecciones.Rows(i)("Direccion1")
                    'lbldfa_callenumero.Text = dTDatosDirecciones.Rows(i)("NUMERO")
                    'lbldfa_calleinterseccion.Text = dTDatosDirecciones.Rows(i)("INTERSECCION")
                End If
            Next
        End If
    End Sub

    Private Sub carga_datos_telefono()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        Dim dTDatosTelefonos As DataTable
        dTDatosTelefonos = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "102", "", Session("user_netsuite"), "", "", ""))
        If dTDatosTelefonos.Rows.Count > 0 Then
            For i As Integer = 0 To dTDatosTelefonos.Rows.Count - 1
                If dTDatosTelefonos.Rows(i)("IdTipoTelefono").ToString = "4" Then
                    lbldmc_telefonocelular.Text = dTDatosTelefonos.Rows(i)("Telefono")
                    lbldof_telefonocelular.Text = dTDatosTelefonos.Rows(i)("Telefono")
                    lbldfa_telefonocelular.Text = dTDatosTelefonos.Rows(i)("Telefono")
                End If
                If dTDatosTelefonos.Rows(i)("IdTipoTelefono").ToString = "8" Then
                    lbldof_telefonofijo.Text = dTDatosTelefonos.Rows(i)("Telefono")
                End If
                If dTDatosTelefonos.Rows(i)("IdTipoTelefono").ToString = "10" Then
                    lbldmc_telefonofijo.Text = dTDatosTelefonos.Rows(i)("Telefono")
                End If
            Next
            For i As Integer = 0 To dTDatosTelefonos.Rows.Count - 1
            Next
        End If
    End Sub

    Private Sub carga_datos_facturacion_ns()
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        Dim dTDatosEmail As DataTable
        dTDatosEmail = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "103", "", Session("user_netsuite"), "", "", ""))
        If dTDatosEmail.Rows.Count > 0 Then
            lbldfa_email1.Text = dTDatosEmail.Rows(0)("Email")
        End If
    End Sub

    Private Sub carga_datos_facturacion_3s()
        'Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        'Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        'Dim dTDatosFacturacion As DataSet
        'dTDatosFacturacion = DatosPersonalesAdapter.ConsultaDatosFacturacionCliente(Session.Item("user"))
        'If dTDatosFacturacion.Tables(0).Rows.Count > 0 Then
        '    lbldfa_email1.Text = dTDatosFacturacion.Tables(0).Rows(0)("EMAIL_FACTURACION")
        'End If
    End Sub

#End Region

End Class