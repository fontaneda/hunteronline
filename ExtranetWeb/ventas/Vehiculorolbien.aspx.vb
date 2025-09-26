Public Class Vehiculorolbien
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            llena_info()
            PintarElementomnu()
            mensajeria_error("", "")
            If Not IsPostBack Then
                If Session("user_id") IsNot Nothing Then
                    Session("id_vehiculo") = ""
                    Dim cnsBienes As New System.Data.DataSet
                    cnsBienes = VehiculoAdapter.ConsultaDatosVehiculosBienessinbaja(Session("user_id"))
                    If cnsBienes.Tables(0).Rows.Count > 0 Then
                        Rpt_bienes.DataSource = cnsBienes
                        Rpt_bienes.DataBind()
                    Else
                        Rpt_bienes.DataSource = Nothing
                        Rpt_bienes.DataBind()
                        mensajeria_error("error", "no existen bienes relacionadas")
                    End If
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

    Private Sub txtfiltroveh_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfiltroveh.ServerChange
        Try
            Dim filtro As String = txtfiltroveh.Value
            Dim dtcgridbien As New System.Data.DataSet
            If filtro = "" Then
                ' cuando no ha ingresado ningún dato, va a buscar todos los vehiculos del cliente
                dtcgridbien = VehiculoAdapter.ConsultaDatosVehiculosGridBien(Session("user_id"), "")
            Else
                'cuando ha ingresado algun dato, va a buscar los vehiculos que concuerden con el filtro ingresado
                dtcgridbien = VehiculoAdapter.ConsultaDatosVehiculosGridBien(Session("user_id"), filtro)
            End If
            If dtcgridbien.Tables(0).Rows.Count > 0 Then
                'Session("DTTransaccion") = dTCstespecifica
                Rpt_bienes.DataSource = dtcgridbien
                Rpt_bienes.DataBind()
            Else
                Rpt_bienes.DataSource = Nothing
                Rpt_bienes.DataBind()
                mensajeria_error("error", "no existen bienes relacionados")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_item_tur(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblchasis As Label = CType(item.FindControl("lblchasisveh"), Label)
        Dim lblcodigo As Label = CType(item.FindControl("lblcodigoveh"), Label)
        'Dim codigo As String = VehiculoAdapter.ConsultaCodigoVehiculo(lblchasis.Text)
        Session("id_vehiculo") = lblcodigo.Text
        Page.Response.Redirect("./vehiculoTurnorol.aspx")
    End Sub

#End Region

#Region "Procedimientos"

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

    Private Sub salida()
        Try
            If Session("Administrador") <> "ADM" And Session("Administrador") <> "USR" And Session("Administrador") <> "MOD" Then
                FormularioAdapter.RegistroLog(18, Session("user_id"), 7)
            End If
            If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Or Session("Administrador") = "MOD" Or Session("Administrador") = "APV" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("LoginSoporte.aspx", False)
            ElseIf Session("Administrador") = "CON" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("login.aspx", False)
            Else
                Session.Clear()
                Session.Abandon()
                Response.Redirect("login.aspx", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Propiedades Texto del Masterform"

    Public Sub PintarElementomnu()
        lielement02.Attributes.Add("class", "")
        licellelement02.Attributes.Add("class", "")
        h1titulomaster.Attributes.Add("class", "")
        sectiontitulomaster.Attributes.Add("class", "")
        lielement02.Attributes.Add("class", "current-option bienes-option")
        licellelement02.Attributes.Add("class", "current-option bienes-option")
        h1titulomaster.Attributes.Add("class", "mis-bienes")
        sectiontitulomaster.Attributes.Add("class", "title-content orange-border")
        lblcantidadmaster.Text = "0"
        lbltotalmaster.Text = "0"
        lbltitulomaster.Text = ""
        lbltitulomaster.Text = "Bienes Protegidos"
    End Sub

    Public Sub log_autitoria(ByVal pantalla As String)
        If Session("Administrador") = "ADM" Then
            FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), "ADMIN", pantalla, Session("iphost"))
        ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
            FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), Session("usuario"), pantalla, Session("iphost"))
        Else
            FormularioAdapter.RegistroLogFormulario(103, Session.Item("user"), "LOAD", pantalla, Session("iphost"))
        End If
    End Sub

    Private Sub llena_info()
        Dim dTCstFactura As New System.Data.DataSet
        dTCstFactura = RenovacionAdapter.ConsultaDatosCliente(Session("user_id"))
        If dTCstFactura.Tables(0).Rows.Count > 0 Then
            lblnombresmaster.Text = Session("display_name")
            lblemailmaster.Text = dTCstFactura.Tables(0).Rows(0)("NOMBRE_SOPORTE")
            'lblcelularmaster.Text = dTCstFactura.Tables(0).Rows(0)("CELULAR")
        End If
    End Sub

    Private Sub btnsalirweb_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsalirweb.ServerClick
        salida()
    End Sub

    Private Sub hrefsalir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrefsalir.ServerClick
        salida()
    End Sub

#End Region

End Class