Public Class LoginExterno
    Inherits System.Web.UI.Page

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim coll As NameValueCollection
            coll = Request.Form
            Dim arr1 As String() = coll.AllKeys
            'Dim loop1 As Integer
            'For loop1 = 0 To arr1.Length - 1
            '    Response.Write("Form: " & arr1(loop1) & "<br>")
            'Next
            Dim parametro_recibido = arr1(0)
            Session("variable") = parametro_recibido
            Dim dtLoginUsuario As New System.Data.DataSet
            dtLoginUsuario = Nothing
            dtLoginUsuario = LoginAdapter.DatosLoginUsuario(parametro_recibido)
            If dtLoginUsuario.Tables.Count > 0 Then
                If dtLoginUsuario.Tables(0).Rows.Count > 0 Then
                    lblusuario.InnerText = dtLoginUsuario.Tables(0).Rows(0).Item(0)
                Else
                    MuestraMensaje("Cliente no se encuentra registrado o activo", 2)
                End If
            Else
                MuestraMensaje("Cliente no se encuentra registrado o activo", 2)
            End If
        End If
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btningresa_ServerClick(sender As Object, e As System.EventArgs) Handles btningresa.ServerClick
        LoginUsuario()
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub LoginUsuario()
        Try
            Dim dtLoginUsuario As New System.Data.DataSet
            Dim validador As Boolean = True
            If Me.txt_password.Value.Trim = "" Then
                MuestraMensaje("Debe ingresar un password", 2)
                Exit Sub
            End If
            dtLoginUsuario = Nothing
            dtLoginUsuario = LoginAdapter.LoginUsuario(Session("variable"), Me.txt_password.Value.Trim())
            If dtLoginUsuario.Tables.Count > 0 Then
                If dtLoginUsuario.Tables(0).Rows.Count <= 0 Then
                    MuestraMensaje("No se pueden cargar los datos, intente mas tarde", 2)
                Else
                    Dim msg As String = dtLoginUsuario.Tables(0).Rows(0).Item("MSG").ToString()
                    Session("Administrador") = msg
                    Session("Iva_terremoto") = "NO"
                    If msg = "UNE" Then
                        MuestraMensaje("El usuario no existe en el sistema.", 2)
                        Me.txt_password.Value = ""
                    End If
                    If msg = "UNA" Then
                        MuestraMensaje("El usuario no se encuentra en estado ACTIVO.", 2)
                        Me.txt_password.Value = ""
                    End If
                    If msg = "PIN" Then

                        MuestraMensaje("La contraseña es incorrecta.", 2)
                        Me.txt_password.Value = ""
                    End If
                    If msg = "NES" Then
                        MuestraMensaje("Usted no puede realizar un inicio de sesión por el momento.", 2)
                        Me.txt_password.Value = ""
                    End If
                    If msg = "PCD" Then
                        MuestraMensaje("Su contraseña ha caducado.", 2)
                        Me.txt_password.Value = ""
                    End If
                    If msg = "ACT" Then
                        InfoUsuario()
                        Session("user") = Session("variable")
                        Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                        Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                        Session("Pantalla_info") = ""
                        FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "LOAD", "USUARIO REDIRIGIDO A ACTUALIZAR DATOS", Session("iphost"))
                        FormularioAdapter.RegistroLog(17, Session("user_id"), 7)
                        ObtenerDatosCarroCompra()
                        Response.Redirect("actualizacliente.aspx", False)
                    End If
                    If msg = "PCR" Then
                        InfoUsuario()
                        Session("user") = Session("variable")
                        Session("user_id") = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                        Session("display_name") = dtLoginUsuario.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                        Session("Email") = dtLoginUsuario.Tables(0).Rows(0).Item("EMAIL").ToString()
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
                        ObtenerDatosCarroCompra()
                        Response.Redirect("datospersonales.aspx", False)
                    End If
                    If msg = "ADM" Then
                        InfoUsuario()
                        Session("user") = Session("variable")
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
                        FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "ADMIN", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                        Response.Redirect("datospersonales.aspx", False)
                    End If
                    If msg = "CON" Then
                        InfoUsuario()
                        Session("user") = Session("variable")
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
                        FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "CON", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                        Response.Redirect("datospersonales.aspx", False)
                    End If
                    If msg = "PRV" Then
                        InfoUsuario()
                        Session("user") = Session("variable")
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
                        FormularioAdapter.RegistroLogFormulario(100, Session("user_id"), "PRV", "USUARIO CON LOGIN SATISFACTORIO", Session("iphost"))
                        Response.Redirect("documentos_electronicos.aspx", False)
                    End If
                End If
            Else
                MuestraMensaje("No se pueden cargar los datos, intente mas tarde", 2)
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
            If Not String.IsNullOrEmpty(valueIphost) Then
                If Not System.Net.Dns.GetHostEntry(valueIphost).HostName Is Nothing Then
                    computerName = System.Net.Dns.GetHostEntry(valueIphost).HostName.Split(New [Char]() {"."c})
                    valuePchost = computerName(0).ToString()
                End If
            Else
                valuePchost = System.Environment.MachineName
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then valueIphost = String.Empty
            If valuePchost = "" Or valuePchost Is Nothing Then valuePchost = String.Empty
            Session("iphost") = valueIphost
            Session("pchost") = valuePchost
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub MuestraMensaje(ByVal custommsg As String, ByVal tipo As Integer)
        Try
            rntMensajes.Text = custommsg
            rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
            If tipo = 1 Then
                rntMensajes.TitleIcon = "info"
                rntMensajes.ContentIcon = "info"
                rntMensajes.ShowSound = "info"
            ElseIf tipo = 2 Then
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
            ElseIf tipo = 3 Then
                rntMensajes.TitleIcon = "delete"
                rntMensajes.ContentIcon = "delete"
                rntMensajes.ShowSound = "delete"
            ElseIf tipo = 4 Then
                rntMensajes.TitleIcon = "deny"
                rntMensajes.ContentIcon = "deny"
                rntMensajes.ShowSound = "deny"
            End If
            rntMensajes.AutoCloseDelay = "1700"
            rntMensajes.Width = 400
            rntMensajes.Height = 100
            rntMensajes.Show()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ObtenerDatosCarroCompra()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = CarroCompraAdapter.ConsultaCarroCompra(Session.Item("user"))
            Session("DTCarroCompraCantidadProducto") = 0
            Session("DTCarroCompraPrecioUnitario") = 0
            Session("DTCarroCompraValorPromocion") = 0
            Session("DTCarroCompraSubTotal") = 0
            Session("DTCarroCompraIva") = 0
            Session("DTCarroCompraTotal") = 0
            Session("DTUltimoPedido") = Nothing
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                Session("DTCarroCompraCantidadProducto") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_CANTIDAD_PRODUCTO")
                Session("DTCarroCompraPrecioUnitario") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_PRECIO_UNITARIO")
                Session("DTCarroCompraValorPromocion") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_PROMOCION")
                Session("DTCarroCompraSubTotal") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_SUBTOTAL")
                Session("DTCarroCompraIva") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_IVA")
                Session("DTCarroCompraTotal") = dTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("DTUltimoPedido") = dTCstGeneral
                Session("TotalMaster") = dTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("TotalCompraMaster") = "Total &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp $" & dTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("SubtotalMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_SUBTOTAL")
                Session("CantidadMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_CANTIDAD_PRODUCTO")
                Session("IvaMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_IVA")
                Session("PrecioUnitarioMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_PRECIO_UNITARIO")
                Session("ValorPromocionMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_PROMOCION")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class