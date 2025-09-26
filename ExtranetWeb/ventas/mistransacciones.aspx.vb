'Imports Telerik.Web.UI
'Imports System.IO
'Imports System.Net
'Imports System.Net.Security
'Imports System.Security.Cryptography.X509Certificates

Public Class mistransacciones
    Inherits System.Web.UI.Page

#Region "EVENTOS DE LA PAGINA"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    metodos_master("Mis transacciones", 4, "Transacciones")
                    mensajeria_error("", "")
                    txtdesdemtr.Text = DateTime.Parse("1/" & Date.Now.Month & "/" & Date.Now.Year).ToString("yyyy-MM-dd")
                    txthastamtr.Text = DateTime.Parse(Date.Now.Day & "/" & Date.Now.Month & "/" & Date.Now.Year).ToString("yyyy-MM-dd")
                    ConsultaInicial(True)
                    botones_filtro("transacciones")
                    Dim dTConsultar As New System.Data.DataSet
                    dTConsultar = clsencuesta.ConsultaEncuesta("2", Session("user"), "")
                    If Not dTConsultar.Tables(0).Rows.Count > 1 Then
                        RedirectNew("Encuesta.aspx", "_blank", "")
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



    Public Shared Sub RedirectNew(ByVal url As String, ByVal target As String, ByVal windowFeatures As String)
        Dim context As HttpContext = HttpContext.Current
        If (String.IsNullOrEmpty(target) OrElse target.Equals("_self", StringComparison.OrdinalIgnoreCase)) AndAlso String.IsNullOrEmpty(windowFeatures) Then
            context.Response.Redirect(url)
        Else
            Dim page As Page = CType(context.Handler, Page)
            If page Is Nothing Then
                Throw New InvalidOperationException("Cannot redirect to new window outside Page context.")
            End If
            url = page.ResolveClientUrl(url)
            Dim script As String
            If (Not String.IsNullOrEmpty(windowFeatures)) Then
                script = "window.open(""{0}"", ""{1}"", ""{2}"");"
            Else
                script = "window.open(""{0}"", ""{1}"");"
            End If
            script = String.Format(script, url, target, windowFeatures)
            ScriptManager.RegisterStartupScript(page, GetType(Page), "Redirect", script, True)
        End If
    End Sub

#End Region

#Region "EVENTOS DE LOS CONTROLES"

    Private Sub btnfiltro_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltro.ServerClick
        Try
            If DateTime.Parse(txthastamtr.Text) < DateTime.Parse(txtdesdemtr.Text) Then
                mensajeria_error("error", "La fecha hasta debe de ser mayor a la fecha desde.")
                Exit Sub
            End If
            ConsultaInicial(True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnfiltroaccesos_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltroaccesos.ServerClick
        ConsultaAccesos(True)
        botones_filtro("accesos")
    End Sub

    Private Sub btnfiltrotransacciones_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltrotransacciones.ServerClick
        ConsultaInicial(True)
        botones_filtro("transacciones")
    End Sub
#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES GENERALES"

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

    Private Sub ConsultaInicial(ByVal mostrarMensaje As Boolean)
        Try
            divpagos.Visible = True
            divaccesos.Visible = False
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = TransaccionAdapter.ConsultaOrdenPagoConfirmadas(Session.Item("user"), txtdesdemtr.Text.Replace("-", ""), txthastamtr.Text.Replace("-", ""))
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                Rpt_transacciones.DataSource = dTCstGeneral
                Rpt_transacciones.DataBind()
            Else
                Rpt_transacciones.DataSource = Nothing
                Rpt_transacciones.DataBind()
                mensajeria_error("", "no existen transacciones relacionadas del cliente")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConsultaAccesos(ByVal mostrarMensaje As Boolean)
        Try
            divpagos.Visible = False
            divaccesos.Visible = True
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = MisTransaccionesAdapter.ConsultaDetallecontipo(Session.Item("user"), 999, txtdesdemtr.Text.Replace("-", ""), txthastamtr.Text.Replace("-", ""))
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                Rpt_accesos.DataSource = dTCstGeneral
                Rpt_accesos.DataBind()
            Else
                Rpt_accesos.DataSource = Nothing
                Rpt_accesos.DataBind()
                mensajeria_error("", "no existen transacciones relacionadas del cliente")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub botones_filtro(boton As String)
        btnfiltroaccesos.Attributes.Add("class", "")
        btnfiltrotransacciones.Attributes.Add("class", "")
        If boton = "transacciones" Then
            btnfiltrotransacciones.Attributes.Add("class", "show")
        ElseIf boton = "accesos" Then
            btnfiltroaccesos.Attributes.Add("class", "show")
        End If
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

#End Region

End Class