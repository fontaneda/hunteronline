Imports Telerik.Web.UI

Public Class contratoenvio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("usuarioPrecio") IsNot Nothing Then
                    metodos_master("Reenvío de Contrato por Email", 3)
                    Me.BtnProcesar.Visible = False
                    Me.txtbusqueda.Text = ""
                    Me.ConsultaInicial("")
                Else
                    Response.Redirect("./LoginSoporte.aspx", False)
                End If
            End If
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
    Private Sub ConsultaInicial(ByVal criterio As String)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = ClsContrato.Consultacontrato(6, criterio)
            Session("General") = dTCstGeneral
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                contratocliente.DataSource = dTCstGeneral
                contratocliente.VirtualItemCount = dTCstGeneral.Tables(0).Rows.Count
                contratocliente.DataBind()
                Me.BtnProcesar.Visible = True
                BtnCancelar.Visible = True
                'Me.txtbusqueda.Text = ""
            Else
                LimpiaGridConsulta()
                ConfigMsg(2, "No existen contratos para reenviar")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub BtnBusquedaAvanzada_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBusquedaAvanzada.Click
        Try
            'ConfigEstilos(0)
            'ConsultaAvanzada(Session.Item("user"), Me.txtbusqueda.Text, 2)
            ConsultaInicial(Me.txtbusqueda.Text)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    'Protected Sub txtcedula_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtcedula.TextChanged
    'Private Sub txtbusqueda_TextChanged(sender As Object, e As System.EventArgs) Handles txtbusqueda.TextChanged
    '    Try
    '        'ConfigEstilos(0)
    '        'ConsultaAvanzada(Session.Item("user"), Me.txtbusqueda.Text, 2)
    '        ConsultaInicial(Me.txtbusqueda.Text)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    Private Sub LimpiaGridConsulta()
        Try
            Dim dtc As New System.Data.DataSet
            dtc = CType(Session("General"), System.Data.DataSet)
            If Not dtc Is Nothing Then
                dtc.Tables(0).Rows.Clear()
            End If
            contratocliente.DataSource = dtc
            Me.contratocliente.VirtualItemCount = dtc.Tables(0).Rows.Count
            contratocliente.DataBind()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



    Private Sub BtnProcesar_Click(sender As Object, e As System.EventArgs) Handles BtnProcesar.Click
        Try
            For Each itemc As GridDataItem In Me.contratocliente.MasterTableView.Items
                Dim chkic As CheckBox = TryCast(itemc.FindControl("chkI"), CheckBox)
                If chkic.Checked = True Then
                    If (Trim(itemc("EMAIL").Text) = "&nbsp;") Then
                        ConfigMsg(2, "No se puede reenviar el contrato xq no tiene un correo")
                    Else
                        ClsContrato.EjecutarEnvio(Trim(itemc("CODIGO_CLIENTE").Text), Trim(itemc("CODIGO_VEHICULO").Text), Trim(itemc("GRUPO").Text), Trim(itemc("ORDEN_SERVICIO").Text), Trim(itemc("ORDEN_TRABAJO").Text), "REEN", Session("usuarioPrecio"))
                        Me.txtbusqueda.Text = ""
                        Me.ConsultaInicial("")
                        ConfigMsg(1, "Correo para aceptación de contrato enviado con éxito")
                    End If
                End If
            Next
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


    Protected Sub chkH_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("usuarioPrecio") IsNot Nothing Then
                Dim chkH As CheckBox = TryCast(sender, CheckBox)
                For Each item As GridDataItem In Me.contratocliente.MasterTableView.Items
                    Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                    'If item("ESTADO").Text = "PENDIENTE POR APROBAR" Then
                    'chkI.Checked = chkH.Checked
                    'Else
                    '    chkI.Checked = False
                    'End If
                    If item("EMAIL").Text = "&nbsp;" Then
                        chkI.Checked = False
                        ConfigMsg(2, "No se puede reenviar el contrato xq no tiene un correo")
                    Else
                        chkI.Checked = True
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub chkI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("usuarioPrecio") IsNot Nothing Then
                Dim item As GridDataItem = TryCast(TryCast(sender, CheckBox).Parent, GridTableCell).Item
                Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                If item("EMAIL").Text = "&nbsp;" Then
                    chkI.Checked = False
                    ConfigMsg(2, "No se puede reenviar el contrato xq no tiene un correo")
                Else
                    chkI.Checked = True
                End If
                'chkI.Checked = chkI.Checked
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub BtnCancelar_Click(sender As Object, e As System.EventArgs) Handles BtnCancelar.Click
        Try
            Me.txtbusqueda.Text = ""
            Me.ConsultaInicial("")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
    End Sub

   
End Class