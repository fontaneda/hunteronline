Public Class vehiculobien
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            metodos_master("Bienes protegidos", 2, "Bienes datos de vehiculo")
            mensajeria_error("", "")
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    Session("id_vehiculo") = ""
                    CargaDatos("")
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

    Private Sub txtfiltroveh_ServerChange(sender As Object, e As System.EventArgs) Handles txtfiltroveh.ServerChange
        Try
            Dim filtro As String = txtfiltroveh.Value
            Dim dtcgridbien As New System.Data.DataSet
            If filtro = "" Then
                CargaDatos("")
            Else
                CargaDatos(filtro)
            End If
            If dtcgridbien.Tables(0).Rows.Count > 0 Then
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

    Protected Sub clk_rpt_item_det(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
        Session("id_vehiculo") = lblvehiculo.Text
        Page.Response.Redirect("./vehiculoespecifico.aspx")
    End Sub

    Protected Sub clk_rpt_item_chk(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
        Session("id_vehiculo") = lblvehiculo.Text
        Page.Response.Redirect("./vehiculochequeo.aspx")
    End Sub

    Protected Sub clk_rpt_item_tur(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
        Session("id_vehiculo") = lblvehiculo.Text
        Page.Response.Redirect("./vehiculoTurno.aspx")
    End Sub

#End Region

#Region "Procedimientos"

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

    Private Sub CargaDatos(filtro As String)
        Try
            Dim dTDatosConsulta As DataTable
            Dim dTDatosVehiculo As DataTable
            Dim dtrow As DataRow()
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosVehiculos").ToString()
            dTDatosConsulta = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", "", "", Session("user_netsuite"), "", "", ""))

            dTDatosVehiculo = dTDatosConsulta.Clone
            dtrow = dTDatosConsulta.Select("IdTipoBien > 1", "")

            For Each dr As DataRow In dtrow
                dTDatosVehiculo.ImportRow(dr)
            Next

            If dTDatosVehiculo.Rows.Count > 0 Then
                Rpt_bienes.DataSource = dTDatosVehiculo
                Rpt_bienes.DataBind()
                Rpt_bienes.Visible = True
                For Each item As RepeaterItem In Rpt_bienes.Items
                    Dim lblchequeo As Label = CType(item.FindControl("lblultimochequeveh"), Label)
                    Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
                    Dim dTDatosChequeo As DataTable
                    id_script = ConfigurationManager.AppSettings.Get("NSConsultaChequeos").ToString()
                    parametro = ConfigurationManager.AppSettings.Get("NSParamChequeos").ToString()
                    dTDatosChequeo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", lblvehiculo.Text, "", "", "", "", filtro, ""))
                    If dTDatosChequeo.Rows.Count > 0 Then
                        dTDatosChequeo.DefaultView.Sort = "FechaOt DESC"
                        lblchequeo.Text = dTDatosChequeo.Rows(0)("FechaOt").ToString
                    Else
                        lblchequeo.Text = "No registra"
                    End If
                Next
            Else
                Rpt_bienes.DataSource = Nothing
                Rpt_bienes.DataBind()
                Rpt_bienes.Visible = False
                mensajeria_error("error", "No existen otros bienes relacionados")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class