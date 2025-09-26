Public Class WebForm2
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Session("textflag") = "0"
            If Not IsPostBack Then
                If Session("usuarioPrecio") IsNot Nothing Then
                    mensajeria_error("", "")
                Else
                    Response.Redirect("./loginsoporte.aspx", False)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub txtfiltrocliente_ServerChange(sender As Object, e As System.EventArgs) Handles txtfiltrocliente.ServerChange
        Try
            Session("textflag") = "1"
            Session("errorbandera") = "2"
            If Len(txtfiltrocliente.Value) > 2 Then
                Dim dTDatosCliente As New DataSet
                dTDatosCliente = DatosPersonalesAdapter.ConsultaDatosCliente(txtfiltrocliente.Value)
                Rptclientesoporte.DataSource = dTDatosCliente
                Rptclientesoporte.DataBind()
                txtfiltrocliente.Disabled = True
            Else
                mensajeria_error("error", "Por favor ingresar al menos tres caracteres para iniciar la busqueda")
                Rptclientesoporte.DataSource = Nothing
                Rptclientesoporte.DataBind()
            End If
        Catch ex As Exception
            mensajeria_error("error", "Cliente no existe")

        End Try
    End Sub

    Protected Sub clk_rpt_clientesoporte(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblcliente As Label = CType(item.FindControl("lblidentificacionsoporte"), Label)
            Dim lblnombres As Label = CType(item.FindControl("lblclientesoporte"), Label)
            Dim lblemail As Label = CType(item.FindControl("lblemailsoporte"), Label)
            Dim lblcelular As Label = CType(item.FindControl("lbltelefonosoporte"), Label)

            If lblcliente.Text <> "" Then
                Dim cliente, usuario, sesionAdministrador, nombresCompletos, usuariosoporte, _
                    usuarioprecio, email, celular As String
                usuariosoporte = ""
                usuarioprecio = ""
                usuario = Session("usuario")
                sesionAdministrador = Session("Administrador")
                cliente = lblcliente.Text.Trim.ToString
                nombresCompletos = "Cliente soporte: " & lblnombres.Text.Trim.ToString
                email = lblemail.Text.Trim.ToString
                celular = lblcelular.Text.Trim.ToString
                If Session("Administrador") = "MOD" Then
                    usuariosoporte = Session("display_soporte")
                    usuarioprecio = Session("usuarioPrecio")
                ElseIf Session("Administrador") = "APV" Then
                    usuarioprecio = Session("usuarioPrecio")
                    usuariosoporte = Session("display_soporte")
                ElseIf Session("Administrador") = "ADM" Then
                    usuarioprecio = Session("usuarioPrecio")
                Else
                    usuariosoporte = ""
                End If
                Session.Clear()
                Session("usuarioPrecio") = usuarioprecio
                CargaNuevaSesion(usuario, cliente, nombresCompletos, sesionAdministrador, usuariosoporte, email, celular)
            Else
                mensajeria_error("error", "por favor seleccione un cliente válido")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnactualizar_Click(sender As Object, e As System.EventArgs) Handles btnactualizar.Click
        If Session("textflag") = "0" Then
            Response.Redirect("CambioClienteSoporte.aspx", False)
        End If
    End Sub

    Private Sub btningresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btningresar.Click
        Try
            Session("textflag") = "1"
            If Len(txtfiltrocliente.Value) > 2 Then
                Session("errorbandera") = "0"
                Dim dTDatosCliente As New DataSet
                dTDatosCliente = DatosPersonalesAdapter.ConsultaDatosCliente(txtfiltrocliente.Value)
                Rptclientesoporte.DataSource = dTDatosCliente
                Rptclientesoporte.DataBind()
                txtfiltrocliente.Disabled = True
            Else
                mensajeria_error("error", "Por favor ingresar al menos tres caracteres para iniciar la busqueda")
                Rptclientesoporte.DataSource = Nothing
                Rptclientesoporte.DataBind()
            End If
        Catch ex As Exception
            mensajeria_error("error", "Cliente no existe")
        End Try
    End Sub

    Private Sub btncrear_Click(sender As Object, e As System.EventArgs) Handles btncrear.Click
        Response.Redirect("CreacionNuevoCliente.aspx", False)
    End Sub

#End Region

#Region "Procedimientos Generales"

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Usuario, " & mensaje
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

    Private Sub CargaNuevaSesion(ByVal usuario As String, ByVal cliente As String, ByVal nombresCompletos As String, _
                                 ByVal msg As String, ByVal usuariosoporte As String, ByVal email As String, _
                                 ByVal celular As String)
        Try
            InfoUsuario()
            Session("Administrador") = msg
            Session("user") = cliente
            Session("usuario") = usuario
            Session("user_id") = cliente
            Session("display_name") = nombresCompletos
            Session("display_soporte") = usuariosoporte
            Session("Email") = email
            Session("Celular") = celular
            FormularioAdapter.RegistroLogFormulario(107, Session("user_id"), Session("usuario"), "USUARIO CON LOGIN SATISFACTORIO - RELOAD SOPORTE", Session("iphost"))
            usuario_ns(Session("user_id"))
            Response.Redirect("renovacion.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub InfoUsuario()
        Try
            'Dim computerName As String()
            Dim valueIphost As String = String.Empty
            Dim valuePchost As String = String.Empty
            valueIphost = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.ServerVariables("REMOTE_ADDR")
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.UserHostAddress
            End If
            'If Not String.IsNullOrEmpty(valueIphost) Then
            '    If Not System.Net.Dns.GetHostEntry(valueIphost).HostName Is Nothing Then
            '        computerName = System.Net.Dns.GetHostEntry(valueIphost).HostName.Split(New [Char]() {"."c})
            '        valuePchost = computerName(0).ToString()
            '    End If
            'Else
            valuePchost = System.Environment.MachineName
            'End If
            If valueIphost = "" Or valueIphost Is Nothing Then valueIphost = String.Empty
            If valuePchost = "" Or valuePchost Is Nothing Then valuePchost = String.Empty
            Session("iphost") = valueIphost
            Session("pchost") = valuePchost
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function usuario_ns(usuario) As Boolean
        Dim retorno As Boolean = False
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosPersonales As DataTable

            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", usuario, "", "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
                retorno = True
            End If
        Catch ex As Exception
            retorno = False
        End Try
        Return retorno
    End Function

#End Region

End Class