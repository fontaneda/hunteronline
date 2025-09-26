Public Class LoginSoporte
    Inherits System.Web.UI.Page

#Region "Variables"
    Dim cliente As String = ""
#End Region

#Region "Eventos formularios"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'poblar_terminos()
                Session("Direccion") = ""
                Session("Telefono") = ""
                Session("Celular") = ""
                Session("Email") = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try

    End Sub

#End Region

#Region "Eventos controles"

    Protected Sub BtnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Login.Click
        Try
            Session.Clear()
            LoginUsuario()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub LoginUsuario()
        Try
            Dim dtLoginUsuario As New System.Data.DataSet
            Dim validador As Boolean = True
            If Me.txt_Usuario.Text.Trim() = "" Then
                mensaje_err(1, "* Debe de ingresar Ruc o Cédula")
                validador = False
            ElseIf Me.txt_Password.Text.Trim() = "" Then
                mensaje_err(2, "* Debe de ingresar el password")
                validador = False
            End If
            If (validador) Then
                dtLoginUsuario = LoginAdapter.LoginUsuario2(Me.txt_Usuario.Text.Trim(), Me.txt_Password.Text.Trim(), cliente)
                If dtLoginUsuario.Tables.Count > 0 Then
                    If dtLoginUsuario.Tables(0).Rows.Count <= 0 Then
                        mensaje_err(0, "No se puede iniciar la sesión")
                    Else
                        Dim msg As String = dtLoginUsuario.Tables(0).Rows(0).Item("MSG").ToString()
                        Session("Administrador") = msg
                        If msg = "UNE" Then
                            mensaje_err(1, "* El usuario no existe en el sistema.")
                        ElseIf msg = "UNA" Then
                            mensaje_err(1, "* El usuario no se encuentra en estado ACTIVO.")
                            Session("Administrador") = msg
                        End If
                        If msg = "USA" Then
                            mensaje_err(1, "El Usuario no tiene permiso de acceso")
                        End If
                        If msg = "USU" Then
                            mensaje_err(2, "El Usuario ha ingresado mal la contraseña")
                        End If

                        'If Not usuario_ns() Then
                        '    mensaje_err(2, "* Cliente no existe en Netsuite.")
                        '    Exit Sub
                        'End If

                        If msg = "USR" Or msg = "ADM" Or msg = "CON" Or msg = "MOD" Or msg = "APV" Then
                            InfoUsuario()
                            Session("user") = cliente
                            Session("usuario") = Me.txt_Usuario.Text.ToUpper.Trim()
                            Session("usuarioPrecio") = Me.txt_Usuario.Text.ToUpper.Trim()
                            Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                            Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Session("TotalMaster") = "0"
                            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
                            Session("SubtotalMaster") = "0"
                            Session("CantidadMaster") = "0"
                            Session("IvaMaster") = "0"
                            Session("PrecioUnitarioMaster") = "0"
                            Session("ValorPromocionMaster") = "0"
                            Session("Pantalla_info") = ""
                            FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), Session("usuario"), "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                            'FormularioAdapter.RegistroLog(17, Session("user_id"), 7)
                            'If msg = "MOD" Then
                            '    Session("display_soporte") = Session("display_name")
                            '    Response.Redirect("Modificacioncliente.aspx", False)
                            'ElseIf msg = "APV" Then
                            '    Session("display_soporte") = Session("display_name")
                            '    Response.Redirect("precioAprobacion.aspx", False)
                            'Else
                            '    Response.Redirect("CambioClienteSoporte.aspx", False)
                            'End If
                            'Response.Redirect("datospersonales.aspx", False)

                            Response.Redirect("CambioClienteSoporte.aspx", False)
                        End If
                    End If
                Else
                    mensaje_err(1, "No se puede iniciar la sesión...")
                End If
            Else
                txtmensajeerror.Text = ""
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

    'Private Function usuario_ns() As Boolean
    '    Dim retorno As Boolean = False
    '    Try
    '        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
    '        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
    '        Dim dTDatosPersonales As DataTable

    '        dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", Me.txt_Usuario.Text.Trim(), "", "", "", ""))
    '        If dTDatosPersonales.Rows.Count > 0 Then
    '            Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
    '            retorno = True
    '        Else
    '            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "C-EC-" & Me.txt_Usuario.Text.Trim(), "", "", "", ""))
    '            If dTDatosPersonales.Rows.Count > 0 Then
    '                Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
    '                retorno = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        retorno = False
    '    End Try
    '    Return retorno
    'End Function

#End Region

End Class