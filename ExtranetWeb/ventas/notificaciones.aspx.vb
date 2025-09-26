'Imports Telerik.Web.UI
'Imports Telerik.Web

Public Class notificaciones

    Inherits System.Web.UI.Page

#Region "Eventos de pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    Session("Pantalla_info") = "Notificaciones"
                    ' Session.Item("user") = "1801618776"
                    Me.rdpFechaInicio.SelectedDate = Now.AddDays((Now.Day - 1) * -1)
                    Me.rdpFechaFin.SelectedDate = Date.Now.Date
                    ConfigControles(2)
                    ConsultaInicial(False)
                    Session("id_notificacion") = Nothing
                    Session("DatosHtml") = Nothing
                    Session("Consulta") = 1
                    If Session("Administrador") = "ADM" Then
                        FormularioAdapter.RegistroLogFormulario(106, Session.Item("user"), "ADMIN", "VISUALIZACION DE NOTIFICACION", Session("iphost"))
                    ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
                        FormularioAdapter.RegistroLogFormulario(106, Session.Item("user_ID"), Session.Item("usuario"), "VISUALIZACION DE NOTIFICACION", Session("iphost"))
                    Else
                        FormularioAdapter.RegistroLogFormulario(106, Session.Item("user"), "LOAD", "VISUALIZACION DE NOTIFICACION", Session("iphost"))
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            Else
                Me.RadListView1.DataSource = Session("General")
                Me.RadListView1.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region


#Region "Procesos"

    Private Sub LimpiaGridConsulta()
        Try
            Dim dtc As New System.Data.DataSet
            dtc = CType(Session("General"), System.Data.DataSet)
            If Not dtc Is Nothing Then
                dtc.Tables(0).Rows.Clear()
            End If
            RadListView1.DataSource = dtc
            Me.RadListView1.VirtualItemCount = dtc.Tables(0).Rows.Count
            RadListView1.DataBind()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' FECHA: 08/08/2014
    ''' AUTOR: GALO ALVARADO
    ''' COMENTARIO: CONSULTA DE DATOS
    ''' </summary>
    ''' <param name="MostrarMensaje"></param>
    ''' <remarks></remarks>
    Private Sub ConsultaInicial(ByVal mostrarMensaje As Boolean)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = NotificacionesAdapter.ConsultaNoticaciones(Session.Item("user"), rdpFechaInicio.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), _
                                                                        rdpFechaFin.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""))
            Session("General") = dTCstGeneral
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                RadListView1.DataSource = dTCstGeneral
                RadListView1.VirtualItemCount = dTCstGeneral.Tables(0).Rows.Count
                RadListView1.DataBind()
            Else
                LimpiaGridConsulta()
                If mostrarMensaje Then
                    rntMsgSistema.Text = "No existen notificaciones relacionadas al cliente"
                    rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMsgSistema.TitleIcon = "warning"
                    rntMsgSistema.ContentIcon = "warning"
                    rntMsgSistema.ShowSound = "warning"
                    rntMsgSistema.Width = 400
                    rntMsgSistema.Height = 100
                    rntMsgSistema.Show()
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigControles(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    RadListView1.Visible = False
                    txtbusqueda.Visible = False
                    LinkVencidos.Visible = False
                    LinkVigentes.Visible = False
                    caracter.Visible = False
                    BtnbusquedaAvanzada.Visible = False
                    RadEditor1.Visible = True
                    BtnRegresar.Visible = True
                Case 2
                    RadListView1.Visible = True
                    txtbusqueda.Visible = True
                    LinkVencidos.Visible = True
                    LinkVigentes.Visible = True
                    caracter.Visible = True
                    BtnbusquedaAvanzada.Visible = True
                    RadEditor1.Visible = False
                    BtnRegresar.Visible = False
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region


#Region "Controles"


    Protected Sub BtnbusquedaAvanzada_Click(sender As Object, e As EventArgs) Handles BtnbusquedaAvanzada.Click
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = NotificacionesAdapter.ConsultaAvanzada(Session.Item("user"), Me.txtbusqueda.Text)
            Session("General") = dTCstGeneral
            Session("Consulta") = 2
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                RadListView1.DataSource = dTCstGeneral
                'Me.rgdnotificaciones.VirtualItemCount = DTCstGeneral.Tables(0).Rows.Count
                RadListView1.VirtualItemCount = dTCstGeneral.Tables(0).Rows.Count
                RadListView1.DataBind()
            Else
                LimpiaGridConsulta()
                rntMsgSistema.Text = "No existen notificaciones según el criterio de busqueda"
                rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                rntMsgSistema.TitleIcon = "warning"
                rntMsgSistema.ContentIcon = "warning"
                rntMsgSistema.ShowSound = "warning"
                rntMsgSistema.Width = 400
                rntMsgSistema.Height = 100
                rntMsgSistema.Show()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub LinkVencidos_Click(sender As Object, e As EventArgs) Handles LinkVencidos.Click
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = NotificacionesAdapter.ConsultaAvanzada(Session.Item("user"), Me.LinkVencidos.Text)
            Session("General") = dTCstGeneral
            Session("Consulta") = 3
            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                RadListView1.DataSource = dTCstGeneral
                RadListView1.VirtualItemCount = dTCstGeneral.Tables(0).Rows.Count
                RadListView1.DataBind()
            Else
                LimpiaGridConsulta()
                rntMsgSistema.Text = "No existen notificaciones según el criterio de busqueda"
                rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                rntMsgSistema.TitleIcon = "warning"
                rntMsgSistema.ContentIcon = "warning"
                rntMsgSistema.ShowSound = "warning"
                rntMsgSistema.Width = 400
                rntMsgSistema.Height = 100
                rntMsgSistema.Show()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub LinkVigentes_Click(sender As Object, e As EventArgs) Handles LinkVigentes.Click
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = NotificacionesAdapter.ConsultaAvanzada(Session.Item("user"), Me.LinkVigentes.Text)
            Session("General") = dTCstGeneral
            Session("Consulta") = 4
            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                RadListView1.DataSource = dTCstGeneral
                RadListView1.VirtualItemCount = DTCstGeneral.Tables(0).Rows.Count
                RadListView1.DataBind()
            Else
                LimpiaGridConsulta()
                rntMsgSistema.Text = "No existen notificaciones según el criterio de busqueda"
                rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                rntMsgSistema.TitleIcon = "warning"
                rntMsgSistema.ContentIcon = "warning"
                rntMsgSistema.ShowSound = "warning"
                rntMsgSistema.Width = 400
                rntMsgSistema.Height = 100
                rntMsgSistema.Show()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            If Session("Consulta") = 1 Then
                dTCstGeneral = NotificacionesAdapter.ConsultaNoticaciones(Session.Item("user"), rdpFechaInicio.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), _
                                                                            rdpFechaFin.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""))
            ElseIf Session("Consulta") = 2 Then
                dTCstGeneral = NotificacionesAdapter.ConsultaAvanzada(Session.Item("user"), Me.txtbusqueda.Text)
            ElseIf Session("Consulta") = 3 Then
                dTCstGeneral = NotificacionesAdapter.ConsultaAvanzada(Session.Item("user"), Me.LinkVencidos.Text)
            ElseIf Session("Consulta") = 4 Then
                dTCstGeneral = NotificacionesAdapter.ConsultaAvanzada(Session.Item("user"), Me.LinkVigentes.Text)
            End If
            Session("General") = dTCstGeneral
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                RadListView1.DataSource = dTCstGeneral
                RadListView1.VirtualItemCount = dTCstGeneral.Tables(0).Rows.Count
                RadListView1.DataBind()
            Else
                LimpiaGridConsulta()
            End If
            ConfigControles(2)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


#End Region

    

#Region "Controles listView"


    Protected Sub RadListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListView1.SelectedIndexChanged
        Try
            Dim values As New Hashtable()
            If RadListView1.SelectedItems.Count = 0 Then
                RadListView1.ClearSelectedItems()
                RadListView1.Rebind()
                Return
            End If
            RadListView1.SelectedItems(0).ExtractValues(values)
            'Dim codigoid As String = values("NOTIFICACION_ID").ToString()
            'Dim comentario As String = values("COMENTARIO").ToString()
            Session("id_notificacion") = values("NOTIFICACION_ID").ToString()
            If Session("id_notificacion") IsNot Nothing Then
                NotificacionesAdapter.RegistroLectura(Session("id_notificacion"))
                Dim dTConsulta As New System.Data.DataSet
                dTConsulta = NotificacionesAdapter.ConsultaHtml(Session("id_notificacion"))
                Session("DatosHtml") = DTConsulta.Tables(0).Rows(0)("BODY_HTML")
                If Session("DatosHtml") IsNot Nothing Then
                    ConfigControles(1)
                    RadEditor1.Content = Session("DatosHtml")
                Else
                    ConfigControles(2)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub RadListView1_NeedDataSource(sender As Object, e As Telerik.Web.UI.RadListViewNeedDataSourceEventArgs) Handles RadListView1.NeedDataSource
        Try
            Me.RadListView1.DataSource = Session("General")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region



End Class