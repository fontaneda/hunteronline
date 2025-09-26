Public Class LoginSoporteOld
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO LOAD EL FORMULARIO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Me.txtUsuario.Focus()
                Dim ver As Double = getInternetExplorerVersion()
                Dim nav As String = Request.Browser.Browser
                'Me.Image1.Visible = False
                'Me.Image2.Visible = False
                ' graba_qs()
                If nav <> "Chrome" And nav <> "Firefox" Then
                    Dim script As String = "function f(){$find(""" + modalPopupNavegador.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                    'Me.Image1.Visible = True
                    'Me.Image2.Visible = True
                    'Me.navegatorwrong.Visible = True
                Else
                    'Me.navegatorwrong.Visible = False
                    If ver > 0.0 Then
                        If ver > 9.0 Then
                            'Me.lblMsg002.Text = ""
                        Else
                            Dim script As String = "function f(){$find(""" + modalPopupIE.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                            'Me.lblMsg002.Text = "Usted está usando una <strong> versión inferior </strong> de Internet Explorer <br/> Por favor actualicela para que el portal web funcione correctamente"
                            'Me.Image1.Visible = True
                            'Me.Image2.Visible = True
                        End If
                    Else
                        'msg = "You're not using Internet Explorer."
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

 
    'Private Sub graba_qs()
    '    Try
    '        Dim valor_transaccion As Integer = 0
    '        Dim identificador, ruta, origen As String
    '        Dim objregusu As New LoginAdapter
    '        ruta = Request.QueryString.ToString
    '        If Request.QueryString("Id") <> Nothing Then
    '            If Request.QueryString("Origen") <> Nothing Then
    '                identificador = DecryptQueryString(Request.QueryString("Id"))
    '                origen = Request.QueryString("Origen")
    '            Else
    '                identificador = Request.QueryString("Id")
    '                origen = "LOGIN"
    '            End If
    '            valor_transaccion = objregusu.RegistroQSLogin(identificador, "NO", ruta, origen)
    '            If valor_transaccion < 0 Then
    '                Throw New System.Exception("Querystring no se guardo con éxito por favor verificar QS:" & ruta)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub


    'Private Function DecryptQueryString(strQueryString As String) As String
    '    Try
    '        Dim obt As New GeneraDataCphr
    '        Return obt.Descifrar(strQueryString, "r0b1nr0y")
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Function

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTÓN PARA REALIZAR LOGIN
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        Try
            Session.Clear()
            LoginUsuario()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA VALIDAR EL LOGIN DEL USUARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoginUsuario()
        Try
            Dim dtLoginUsuario As New System.Data.DataSet

            dtLoginUsuario = LoginAdapter.LoginUsuario2(Me.txtUsuario.Text.Trim(), Me.txtPassword.Text.Trim(), Me.txtCliente.Text.Trim())
            If dtLoginUsuario.Tables(0).Rows.Count <= 0 Then
                rntMsgSistema.Text = "No se puede iniciar la sesión"
                rntMsgSistema.Title = "Mensaje del Sitio Comercial Hunter"
                rntMsgSistema.Show()
            Else
                Dim msg As String = dtLoginUsuario.Tables(0).Rows(0).Item("MSG").ToString()
                Session("Administrador") = msg
                If msg = "UNE" Then
                    Me.lblMsg001.Visible = True
                    Me.lblMsg001.Text = "El Cliente no existe en el sistema"
                    Me.txtPassword.Text = ""
                    Me.txtUsuario.Focus()
                    Me.txtCliente.Text = ""
                End If

                If msg = "UNA" Then
                    'Me.lblMsg001.Visible = True
                    'Me.lblMsg001.Text = "El Cliente no se encuentra en estado ACTIVO"
                    'Me.txtPassword.Text = ""
                    'Me.txtUsuario.Focus()
                    'Me.txtCliente.Text = ""
                    msg = "USR"
                    Session("Administrador") = msg
                End If

                If msg = "USA" Then
                    Me.lblMsg001.Visible = True
                    Me.lblMsg001.Text = "El Usuario no tiene permiso de acceso"
                    Me.txtPassword.Text = ""
                    Me.txtUsuario.Focus()
                End If

                If msg = "USU" Then
                    Me.lblMsg001.Visible = True
                    Me.lblMsg001.Text = "El Usuario ha ingresado mal la contraseña"
                    Me.txtPassword.Text = ""
                    Me.txtUsuario.Focus()
                    Me.txtCliente.Text = ""
                End If

                If msg = "USR" Or msg = "ADM" Then
                    InfoUsuario()
                    Session("user") = Me.txtCliente.Text.Trim()
                    Session("usuario") = Me.txtUsuario.Text.ToUpper.Trim()
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
                    ObtenerDatosCarroCompra()
                    Response.Redirect("datospersonales.aspx", False)
                End If

            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA OBTENER LA IP Y HOSTNAME DEL EQUIPO VISITANTE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InfoUsuario()
        Try
            Dim computer_name As String()
            Dim value_iphost As String = String.Empty
            Dim value_pchost As String = String.Empty
            value_iphost = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If value_iphost = "" Or value_iphost Is Nothing Then
                value_iphost = Request.ServerVariables("REMOTE_ADDR")
            End If
            If value_iphost = "" Or value_iphost Is Nothing Then
                value_iphost = Request.UserHostAddress
            End If

            If Not String.IsNullOrEmpty(value_iphost) Then
                If Not System.Net.Dns.GetHostEntry(value_iphost).HostName Is Nothing Then
                    computer_name = System.Net.Dns.GetHostEntry(value_iphost).HostName.Split(New [Char]() {"."c})
                    value_pchost = computer_name(0).ToString()
                End If
            Else
                value_pchost = System.Environment.MachineName
            End If

            If value_iphost = "" Or value_iphost Is Nothing Then value_iphost = String.Empty
            If value_pchost = "" Or value_pchost Is Nothing Then value_pchost = String.Empty

            Session("iphost") = value_iphost
            Session("pchost") = value_pchost
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA OBTENER LA VERSION DEL EXPLORER
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getInternetExplorerVersion() As Single
        ' Returns the version of Internet Explorer or a -1
        ' (indicating the use of another browser).
        Dim rv As Single = -1
        Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
        If browser.Browser = "IE" Then
            rv = CSng(browser.MajorVersion + browser.MinorVersion)
        End If
        Return rv
    End Function

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA OBTENER EL ULTIMO PEDIDO DEL CLIENTE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ObtenerDatosCarroCompra()
        Try
            Dim DTCstGeneral As New System.Data.DataSet
            DTCstGeneral = CarroCompraAdapter.ConsultaCarroCompra(Session.Item("user"))

            Session("DTCarroCompraCantidadProducto") = 0
            Session("DTCarroCompraPrecioUnitario") = 0
            Session("DTCarroCompraValorPromocion") = 0
            Session("DTCarroCompraSubTotal") = 0
            Session("DTCarroCompraIva") = 0
            Session("DTCarroCompraTotal") = 0
            Session("DTUltimoPedido") = Nothing

            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                Session("DTCarroCompraCantidadProducto") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_CANTIDAD_PRODUCTO")
                Session("DTCarroCompraPrecioUnitario") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_PRECIO_UNITARIO")
                Session("DTCarroCompraValorPromocion") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_PROMOCION")
                Session("DTCarroCompraSubTotal") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_SUBTOTAL")
                Session("DTCarroCompraIva") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_IVA")
                Session("DTCarroCompraTotal") = DTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("DTUltimoPedido") = DTCstGeneral

                Session("TotalMaster") = DTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("TotalCompraMaster") = "Total &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp $" & DTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("SubtotalMaster") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_SUBTOTAL")
                Session("CantidadMaster") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_CANTIDAD_PRODUCTO")
                Session("IvaMaster") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_IVA")
                Session("PrecioUnitarioMaster") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_PRECIO_UNITARIO")
                Session("ValorPromocionMaster") = DTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_PROMOCION")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


End Class