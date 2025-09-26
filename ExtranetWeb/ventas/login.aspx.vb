Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

'Imports System.Drawing

Public Class login
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                GrabaQs()
                dvseleccioningreso.Visible = False
                'diverror.Visible = False
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Protected Sub BtnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Login.Click
        Try
            Session.Clear()
            'diverror.Visible = False
            LoginUsuario()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnenlacechequeo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnenlacechequeo.ServerClick
        Response.Redirect("vehiculorol.aspx", False)
    End Sub

    Private Sub btnenlacenormal_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnenlacenormal.ServerClick
        Response.Redirect("renovacion.aspx", False)
    End Sub

#End Region

#Region "Procedimientos"

    Private Function FechaSistema()
        Dim day, month As Integer
        Dim dayStr, monthStr, yearStr, hora, minuto As String
        Dim fechaStr As String = ""
        Try
            day = Now.Day
            If day <= 9 Then
                dayStr = "0" & day
            Else
                dayStr = day.ToString
            End If
            month = Now.Month
            If month <= 9 Then
                monthStr = "0" & month
            Else
                monthStr = month.ToString
            End If
            yearStr = Now.Year.ToString
            hora = DateTime.Now.ToString("HH")
            minuto = DateTime.Now.ToString("mm")
            fechaStr = yearStr & monthStr & dayStr & " " & hora & minuto
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return fechaStr
    End Function

    Private Sub GrabaQs()
        Try
            Dim valorTransaccion As Integer = 0
            Dim identificador, ruta, origen As String
            Dim objregusu As New LoginAdapter
            ruta = Request.QueryString.ToString
            If Request.QueryString("Id") <> Nothing Then
                If Request.QueryString("Origen") <> Nothing Then
                    identificador = DecryptQueryString(Request.QueryString("Id"))
                    origen = Request.QueryString("Origen")
                Else
                    identificador = Request.QueryString("Id")
                    origen = "LOGIN"
                End If
                valorTransaccion = objregusu.RegistroQSLogin(identificador, "NO", ruta, origen)
                If valorTransaccion < 0 Then
                    Throw New System.Exception("Querystring no se guardo con éxito por favor verificar QS:" & ruta)
                End If
            End If
            Dim valueFecha As String
            Dim strReq As String = ""
            Dim strVeh As String = ""
            strReq = Request.RawUrl
            Dim strDat As String = ""
            strDat = Request.RawUrl
            Dim strClv As String = ""
            If Request.QueryString("prmdtt") <> Nothing Or Request.QueryString("userkey") <> Nothing Or Request.QueryString("prmclv") <> Nothing Then
                strClv = Request.RawUrl
                strDat = Request.QueryString("prmdtt").ToString
                strReq = Request.QueryString("userkey").ToString
                strClv = Request.QueryString("prmclv").ToString
                If Not strDat.Equals("") Or Not strReq.Equals("") Or Not strClv.Equals("") Then
                    Session("strDat") = DecryptQueryString(strDat)
                    valueFecha = FechaSistema()
                    Dim fecha As String = valueFecha.Substring(0, 8)
                    Dim hora As String = valueFecha.Substring(9, 4)
                    If Session("strDat").Substring(0, 8) = fecha Then
                        If Session("strDat").Substring(9, 4) > hora Then
                            Session("userkey") = DecryptQueryString(strReq)
                            Session("strClv") = DecryptQueryString(strClv)
                            txt_Usuario.Text = Session("userkey")
                            Response.Redirect("cambiocontrasena.aspx", False)
                            '    'Dim script As String = "function f(){$find(""" + cambioclavecliente.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                            '    'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                        Else
                            mensaje_err(0, "Su contraseña temporal ya caduco...")
                        End If
                    Else
                        mensaje_err(0, "Su contraseña temporal ya caduco..")
                    End If
                End If
            Else
                If Request.QueryString("userkeyami") <> Nothing Or Request.QueryString("dttami") <> Nothing Then
                    strClv = Request.RawUrl
                    strDat = Request.QueryString("dttami").ToString
                    strReq = Request.QueryString("userkeyami").ToString
                    If Not strDat.Equals("") Or Not strReq.Equals("") Or Not strClv.Equals("") Then
                        Session("strDat") = DecryptQueryString(strDat)
                        valueFecha = FechaSistema()
                        Dim fecha As String = valueFecha.Substring(0, 8)
                        Dim hora As String = valueFecha.Substring(9, 4)
                        Session("userkey") = DecryptQueryString(strReq)
                        Dim dtLoginUsuarioAmi As New System.Data.DataSet
                        dtLoginUsuarioAmi = Nothing
                        dtLoginUsuarioAmi = LoginAdapter.DatosMenuExtranet(Session("userkey"), "104")
                        If dtLoginUsuarioAmi.Tables(0).Rows.Count <= 0 Then
                            mensaje_err(0, "No se puede iniciar la sesión")
                        Else
                            InfoUsuario()
                            Session("user") = dtLoginUsuarioAmi.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("user_id") = dtLoginUsuarioAmi.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuarioAmi.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = dtLoginUsuarioAmi.Tables(0).Rows(0).Item("EMAIL").ToString()
                            Session("TotalMaster") = "0"
                            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                            Session("SubtotalMaster") = "0"
                            Session("CantidadMaster") = "0"
                            Session("IvaMaster") = "0"
                            Session("PrecioUnitarioMaster") = "0"
                            Session("ValorPromocionMaster") = "0"
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "LOADAMI", "USUARIO AMI INGRESO SATISFACTORIO", Session("iphost"))
                            FormularioAdapter.RegistroLog(17, Session("user_id"), 7)
                            Response.Redirect("RenovacionExterna.aspx", False)

                        End If
                    End If
                Else
                    If Request.QueryString("userkeyprod") <> Nothing Or Request.QueryString("keyveh") <> Nothing Then
                        strClv = Request.RawUrl
                        strReq = Request.QueryString("userkeyprod").ToString
                        strVeh = Request.QueryString("keyveh").ToString
                        If Not strReq.Equals("") Or Not strClv.Equals("") Then
                            Session("userkey") = DecryptQueryString(strReq)
                            Session("userveh") = DecryptQueryString(strVeh)
                            Dim dtLoginUsuarioAmi As New System.Data.DataSet
                            dtLoginUsuarioAmi = Nothing
                            dtLoginUsuarioAmi = LoginAdapter.DatosMenuExtranet(Session("userkey"), "104")
                            If dtLoginUsuarioAmi.Tables(0).Rows.Count <= 0 Then
                                mensaje_err(0, "No se puede iniciar la sesión")
                            Else
                                InfoUsuario()
                                Session("user") = dtLoginUsuarioAmi.Tables(0).Rows(0)("USUARIO_ID").ToString()
                                Session("user_id") = dtLoginUsuarioAmi.Tables(0).Rows(0)("USUARIO_ID").ToString()
                                Session("display_name") = dtLoginUsuarioAmi.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                                Session("Email") = dtLoginUsuarioAmi.Tables(0).Rows(0).Item("EMAIL").ToString()
                                Session("TotalMaster") = "0"
                                Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                                Session("SubtotalMaster") = "0"
                                Session("CantidadMaster") = "0"
                                Session("IvaMaster") = "0"
                                Session("PrecioUnitarioMaster") = "0"
                                Session("ValorPromocionMaster") = "0"
                                Session("Pantalla_info") = ""
                                FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "LOADAMI", "USUARIO AMI INGRESO SATISFACTORIO", Session("iphost"))
                                FormularioAdapter.RegistroLog(17, Session("user_id"), 7)
                                Response.Redirect("RenovacionExterna.aspx", False)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function DecryptQueryString(strQueryString As String) As String
        Dim qs As String = ""
        Try
            Dim obt As New GeneraDataCphr
            qs = obt.Descifrar(strQueryString, "r0b1nr0y")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return qs
    End Function

    Private Sub LoginUsuario()
        Try
            Dim dtLoginUsuario As New System.Data.DataSet

            If (validador()) Then
                dtLoginUsuario = Nothing
                dtLoginUsuario = LoginAdapter.LoginUsuario(Me.txt_Usuario.Text.Trim(), Me.txt_Password.Text.Trim())
                If dtLoginUsuario.Tables.Count > 0 Then
                    If dtLoginUsuario.Tables(0).Rows.Count <= 0 Then
                        mensaje_err(0, "No se puede iniciar la sesión")
                    Else
                        Dim msg As String = dtLoginUsuario.Tables(0).Rows(0).Item("MSG").ToString()
                        Session("Administrador") = msg
                        Session("Iva_terremoto") = "NO"
                        If msg = "UNE" Then
                            mensaje_err(1, "* El usuario no existe en el sistema.")
                        ElseIf msg = "UNA" Then
                            mensaje_err(1, "* El usuario no se encuentra en estado ACTIVO.")
                        ElseIf msg = "PIN" Then
                            mensaje_err(2, "* La contraseña es incorrecta.")
                        ElseIf msg = "NES" Then
                            mensaje_err(1, "* Usted no puede realizar un inicio de sesión por el momento.")
                        ElseIf msg = "PCD" Then
                            mensaje_err(2, "* Su contraseña ha caducado.")
                        End If

                        If Not usuario_ns() Then
                            mensaje_err(2, "* Cliente no existe en Netsuite.")
                            Exit Sub
                        End If

                        If msg = "ACT" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = ""
                            Session("Celular") = ""
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "LOAD", "USUARIO REDIRIGIDO A ACTUALIZAR DATOS", Session("iphost"))
                            FormularioAdapter.RegistroLog(17, Session("user_id"), 7)
                            'ObtenerDatosCarroCompra()
                            Response.Redirect("actualizacliente.aspx", False)
                        End If
                        If msg = "PCR" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = dtLoginUsuario.Tables(0).Rows(0).Item("EMAIL").ToString()
                            Session("Celular") = dtLoginUsuario.Tables(0).Rows(0).Item("TELEFONO_CLIENTE").ToString()
                            Session("TotalMaster") = "0"
                            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                            Session("SubtotalMaster") = "0"
                            Session("CantidadMaster") = "0"
                            Session("IvaMaster") = "0"
                            Session("PrecioUnitarioMaster") = "0"
                            Session("ValorPromocionMaster") = "0"
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "LOAD", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            FormularioAdapter.RegistroLog(17, Session("user_id"), 7)
                            'ObtenerDatosCarroCompra()
                            Dim nav As String = Request.Browser.Browser
                            Dim objmail As New MailTrabajos
                            'objmail.MailAvisoIngreso(Session("user"), nav.ToString)
                            Response.Redirect("renovacion.aspx", False)
                        End If
                        If msg = "ADM" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = ""
                            Session("Celular") = ""
                            Session("TotalMaster") = "0"
                            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                            Session("SubtotalMaster") = "0"
                            Session("CantidadMaster") = "0"
                            Session("IvaMaster") = "0"
                            Session("PrecioUnitarioMaster") = "0"
                            Session("ValorPromocionMaster") = "0"
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "ADMIN", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            Response.Redirect("renovacion.aspx", False)
                        End If
                        If msg = "CON" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = ""
                            Session("Celular") = ""
                            Session("TotalMaster") = "0"
                            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                            Session("SubtotalMaster") = "0"
                            Session("CantidadMaster") = "0"
                            Session("IvaMaster") = "0"
                            Session("PrecioUnitarioMaster") = "0"
                            Session("ValorPromocionMaster") = "0"
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "CON", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            Response.Redirect("renovacion.aspx", False)
                        End If
                        If msg = "PRV" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = ""
                            Session("Celular") = ""
                            Session("TotalMaster") = "0"
                            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                            Session("SubtotalMaster") = "0"
                            Session("CantidadMaster") = "0"
                            Session("IvaMaster") = "0"
                            Session("PrecioUnitarioMaster") = "0"
                            Session("ValorPromocionMaster") = "0"
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "PRV", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            Response.Redirect("documentos_electronicos.aspx", False)
                        End If
                        If msg = "TUR" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("CLIENTE_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = ""
                            Session("Celular") = ""
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "CON", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            Response.Redirect("vehiculorol.aspx", False)
                        End If
                        If msg = "CTU" Then
                            InfoUsuario()
                            Session("user") = Me.txt_Usuario.Text.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("CLIENTE_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("Email") = ""
                            Session("Celular") = ""
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "CON", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            dvseleccioningreso.Visible = True
                        End If
                    End If
                Else
                    mensaje_err(0, "No se puede iniciar la sesión...")
                End If
            Else
                'diverror.Visible = False
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub InfoUsuario()
        Try
            Dim computerName As String()
            Dim valueIphost As String = String.Empty
            Dim valuePchost As String = String.Empty
            valueIphost = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.ServerVariables("REMOTE_ADDR")
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.UserHostAddress
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then valueIphost = String.Empty
            If valuePchost = "" Or valuePchost Is Nothing Then valuePchost = String.Empty
            Session("iphost") = valueIphost
            Session("pchost") = valuePchost
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function GetInternetExplorerVersion() As Single
        Dim rv As Single = -1
        Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
        If browser.Browser = "IE" Then
            rv = CSng(browser.MajorVersion + browser.MinorVersion)
        End If
        Return rv
    End Function

    Private Sub mensaje_err(control As Integer, mensaje As String)
        txtmensajeerror.Text = ""
        txt_Usuario.CssClass = ""
        txt_Password.CssClass = ""
        txtmensajeerror.Text = mensaje
        If control = 1 Then
            txt_Usuario.CssClass = "input-field error-input"
        ElseIf control = 2 Then
            txt_Password.CssClass = "input-field error-input"
        End If
        'diverror.Visible = True
    End Sub

    Private Function validador() As Boolean
        Dim valido As Boolean = True
        If txt_Usuario.Text.Trim() = "" Then
            mensaje_err(1, "* Debe de ingresar Ruc o Cédula")
            valido = False
        ElseIf txt_Password.Text.Trim() = "" Then
            mensaje_err(2, "* Debe de ingresar el password")
            valido = False
        End If
        Return valido
    End Function

    Private Function usuario_ns() As Boolean
        Dim retorno As Boolean = False
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosPersonales As DataTable

            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", Me.txt_Usuario.Text.Trim(), "", "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
                retorno = True
            Else
                dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "C-EC-" & Me.txt_Usuario.Text.Trim(), "", "", "", ""))
                If dTDatosPersonales.Rows.Count > 0 Then
                    Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
                    retorno = True
                End If
            End If
        Catch ex As Exception
            retorno = False
        End Try
        Return retorno
    End Function

#End Region

End Class