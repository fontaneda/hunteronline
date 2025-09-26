Imports Telerik.Web.UI

Public Class precioAprobacion
    Inherits System.Web.UI.Page

#Region "EVENTOS DEL FORMULARIO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Session("usuarioPrecio") = "GALVAR"
            If Not IsPostBack Then
                metodos_master("Aprobación de Precio de Venta", 3)
                If Session("usuarioPrecio") IsNot Nothing Then
                    LlenaCombo()
                    IniciarControlesValores()
                    ConsultaInicial(False)
                Else
                    Response.Redirect("./LoginSoporte.aspx", False)
                End If
            Else
                If Not Session("usuarioPrecio") IsNot Nothing Then
                    Response.Redirect("./LoginSoporte.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "EVENTOS DE LOS CONTROLES"

    Private Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBuscar.ServerClick
        'Private Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Dim fecha_ini As Date = rdpFechaInicio.Text
            Dim fecha_fin As Date = rdpFechaFin.Text

            If fecha_ini > fecha_fin Then
                ProveedorMensaje.ShowMessage(rntMsgSistema, "La fecha hasta debe de ser mayor a la fecha desde.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            ConsultaInicial(True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As System.EventArgs) Handles BtnCancelar.ServerClick
        'Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Try
            Me.BtnProcesar.Visible = False
            Me.BtnCancelar.Visible = False
            For Each itemc As GridDataItem In Me.productocliente.MasterTableView.Items
                Dim chkic As CheckBox = TryCast(itemc.FindControl("chkI"), CheckBox)
                If chkic.Checked = True Then
                    AprobacionAdapter.EjecutarProcesoPrecio(Trim(itemc("CODIGO_CLIENTE").Text), Trim(itemc("CODIGO_VEHICULO").Text), Session("usuarioPrecio"), Trim(itemc("TIPO_TRANSACCION").Text), "3")
                End If
            Next
            ConfigMsg(1, "Anulación Realiza con Exito")
            ConsultaInicial(False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnProcesar_Click(sender As Object, e As System.EventArgs) Handles BtnProcesar.ServerClick
        'Private Sub BtnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Try
            Me.BtnProcesar.Visible = False
            Me.BtnCancelar.Visible = False
            For Each itemc As GridDataItem In Me.productocliente.MasterTableView.Items
                Dim chkic As CheckBox = TryCast(itemc.FindControl("chkI"), CheckBox)
                If chkic.Checked = True Then
                    AprobacionAdapter.EjecutarProcesoPrecio(Trim(itemc("CODIGO_CLIENTE").Text), Trim(itemc("CODIGO_VEHICULO").Text), Session("usuarioPrecio"), Trim(itemc("TIPO_TRANSACCION").Text), "2")
                End If
            Next
            ConfigMsg(1, "Aprobación Realiza con Exito")
            'Dim objmail As New MailTrabajos
            'objmail.MailAvisoAprobacion(cliente, vehiculo)
            ConsultaInicial(False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES GENERALES"

    Private Sub LlenaCombo()
        Try
            Dim dTCliente As New System.Data.DataSet
            dTCliente = AprobacionAdapter.ConsultaDatos(5, Session("usuarioPrecio"))
            If dTCliente.Tables(0).Rows.Count > 0 Then
                Me.cbxcliente.DataSource = dTCliente
                Me.cbxcliente.DataTextField = "DESCRIPCION"
                Me.cbxcliente.DataValueField = "CODIGO"
                Me.cbxcliente.DataBind()
            End If
            Dim dTUsuario As New System.Data.DataSet
            dTUsuario = AprobacionAdapter.ConsultaDatos(4, Session("usuarioPrecio"))
            If dTUsuario.Tables(0).Rows.Count > 0 Then
                Me.cbxusuario.DataSource = dTUsuario
                Me.cbxusuario.DataTextField = "DESCRIPCION"
                Me.cbxusuario.DataValueField = "CODIGO"
                Me.cbxusuario.DataBind()
            End If

            Dim dTEstado As New System.Data.DataSet
            dTEstado = AprobacionAdapter.ConsultaDatos(9, Session("usuarioPrecio"))
            If dTUsuario.Tables(0).Rows.Count > 0 Then
                Me.cbxestado.DataSource = dTEstado
                Me.cbxestado.DataTextField = "DESCRIPCION"
                Me.cbxestado.DataValueField = "CODIGO"
                Me.cbxestado.DataBind()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub IniciarControlesValores()
        Session("fecha") = ""
        Session("fecha_ini") = ""
        Session("fecha_fin") = ""
        rdpFechaInicio.Text = DateTime.Parse("1/" & Date.Now.Month & "/" & Date.Now.Year).ToString("yyyy-MM-dd")
        rdpFechaFin.Text = DateTime.Parse(Date.Now.Day & "/" & Date.Now.Month & "/" & Date.Now.Year).ToString("yyyy-MM-dd")
        cbxusuario.Value = ""
        cbxcliente.Value = ""
        cbxestado.Value = "PEN"
    End Sub

    Private Sub ConsultaInicial(ByVal mostrarMensaje As Boolean)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = AprobacionAdapter.ConsultaAprobaciones(cbxusuario.Value, cbxcliente.Value, cbxestado.Value, Session("usuarioPrecio"),
                                                                  rdpFechaInicio.Text.Replace("-", ""), rdpFechaFin.Text.Replace("-", ""))
            Session("General") = dTCstGeneral
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                productocliente.DataSource = dTCstGeneral
                productocliente.DataBind()
                Me.BtnProcesar.Visible = True
                Me.BtnCancelar.Visible = True
            Else
                LimpiaGridConsulta()
                Me.BtnProcesar.Visible = False
                Me.BtnCancelar.Visible = False
                If mostrarMensaje Then
                    ConfigMsg(2, "No existen transacciones pendientes de aprobar")
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub productocliente_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles productocliente.NeedDataSource
        Try
            productocliente.DataSource = Session("General")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigMsg(ByVal opcion As Integer, ByVal custommsg As String)
        Try
            Select Case opcion
                Case 1
                    rntMsgSistema.Text = custommsg
                    rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMsgSistema.TitleIcon = "ok"
                    rntMsgSistema.ContentIcon = "ok"
                    rntMsgSistema.ShowSound = "ok"
                    rntMsgSistema.Width = 400
                    rntMsgSistema.Height = 100
                    rntMsgSistema.Show()
                Case 2
                    rntMsgSistema.Text = custommsg
                    rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMsgSistema.TitleIcon = "warning"
                    rntMsgSistema.ContentIcon = "warning"
                    rntMsgSistema.ShowSound = "warning"
                    rntMsgSistema.Width = 400
                    rntMsgSistema.Height = 100
                    rntMsgSistema.Show()
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LimpiaGridConsulta()
        Try
            Dim dtc As New System.Data.DataSet
            dtc = CType(Session("General"), System.Data.DataSet)
            If Not dtc Is Nothing Then
                dtc.Tables(0).Rows.Clear()
            End If
            productocliente.DataSource = dtc
            productocliente.DataBind()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub chkI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("usuarioPrecio") IsNot Nothing Then
                Dim item As GridDataItem = TryCast(TryCast(sender, CheckBox).Parent, GridTableCell).Item
                Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                If item("ESTADO").Text = "PENDIENTE POR APROBAR" Then
                    chkI.Checked = True
                Else
                    chkI.Checked = False
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub chkH_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("usuarioPrecio") IsNot Nothing Then
                Dim chkH As CheckBox = TryCast(sender, CheckBox)
                For Each item As GridDataItem In Me.productocliente.MasterTableView.Items
                    Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                    If item("ESTADO").Text = "PENDIENTE POR APROBAR" Then
                        chkI.Checked = chkH.Checked
                    Else
                        chkI.Checked = False
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
    End Sub

#End Region

End Class