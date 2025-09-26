Imports Telerik.Web.UI

Public Class vehiculochequeo
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                    metodos_master("Bienes protegidos", 2, "Bienes datos de chequeos")
                    mensajeria_error("", "")
                    CargaDatos()
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

    Private Sub btnregresar_Click(sender As Object, e As System.EventArgs) Handles btnregresar.Click
        Try
            Response.Redirect("./vehiculo.aspx", False)
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub CargaDatos()
        Try
            Dim dTVehiculo As DataTable
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultacobertura").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamCobertura").ToString()
            dTVehiculo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", Session("id_vehiculo"), "", Session("user_netsuite"), "", "", "", "", ""))
            If dTVehiculo.Rows.Count > 0 Then
                Rpt_productos.DataSource = dTVehiculo
                Rpt_productos.DataBind()
                Rpt_productos.Visible = True
            Else
                Rpt_productos.DataSource = Nothing
                Rpt_productos.DataBind()
                Rpt_productos.Visible = False
                mensajeria_error("error", "No existen productos relacionados")
            End If

            Dim dTDatosChequeo As DataTable
            id_script = ConfigurationManager.AppSettings.Get("NSConsultaChequeos").ToString()
            parametro = ConfigurationManager.AppSettings.Get("NSParamChequeos").ToString()
            dTDatosChequeo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", Session("id_vehiculo"), "", "", "", "", "", ""))
            If dTDatosChequeo.Rows.Count > 0 Then
                Rpt_chequeos.DataSource = dTDatosChequeo
                Rpt_chequeos.DataBind()
                Rpt_chequeos.Visible = True
            Else
                Rpt_chequeos.DataSource = Nothing
                Rpt_chequeos.DataBind()
                Rpt_chequeos.Visible = False
                mensajeria_error("error", "No existen chequeos realizados")
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class