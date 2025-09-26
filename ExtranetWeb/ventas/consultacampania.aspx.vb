Imports Telerik.Web.UI

Public Class consultacampania

    Inherits System.Web.UI.Page
    Dim producto As String
    Public Modifica As String
    'Public codigovehiculo As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    If Session("Administrador") = "CON" Then
                        'Me.btnretroceder.Enabled = False
                        Session("DTRetorno") = "1"
                    End If
                    Dim idVehiculo As String = "1"   'Session("id_vehiculo").ToString
                    If idVehiculo <> "" Then
                        ' Para consultar las campañas
                        Dim dTCampania As New System.Data.DataSet
                        dTCampania = CampaniaAdapter.ConsultaDatosCampanias(Session.Item("user"), idVehiculo)
                        If dTCampania.Tables(0).Rows.Count > 0 Then
                            Session("DTTransaccion") = dTCampania
                            Me.RgdProductos.DataSource = dTCampania
                            Me.RgdProductos.VirtualItemCount = dTCampania.Tables(0).Rows.Count
                            txt_regusu_identificacion.Text = dTCampania.Tables(0).Rows(0)("NOMBRE_CAMPANIA")
                            txt_regusu_fecha.Text = dTCampania.Tables(0).Rows(0)("FECHA_INICIAL")  '& "   " & DTCampania.Tables(0).Rows(0)("FECHA_FINAL")
                            rdpdtp_fecha_Ini.SelectedDate = dTCampania.Tables(0).Rows(0)("FEC_I")
                            Txt_regusu_fecha_f.Text = dTCampania.Tables(0).Rows(0)("FECHA_FINAL")
                            txt_regusu_ruta.Text = dTCampania.Tables(0).Rows(0)("RUTA_IMAGEN")
                            img_promo.Src = dTCampania.Tables(0).Rows(0)("RUTA_IMAGEN")
                            Me.RgdProductos.DataBind()
                            producto = dTCampania.Tables(0).Rows(0).Item(0).ToString
                        Else
                            Me.RgdProductos.DataSource = dTCampania
                            Me.RgdProductos.VirtualItemCount = dTCampania.Tables(0).Rows.Count
                            Me.RgdProductos.DataBind()
                            producto = ""
                            ConfigMsg(2, "No existen campañas activas ")
                        End If
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub RgdProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RgdProductos.SelectedIndexChanged
        Try
            Dim item As GridDataItem = Nothing
            item = RgdProductos.SelectedItems(0)
            txt_regusu_identificacion.Text = item("NOMBRE_CAMPANIA").Text.Trim.ToString
            'txt_regusu_fecha.Text = item("FECHA_INICIAL").Text.Trim.ToString '& "   " & item("FECHA_FINAL").Text.Trim.ToString
            'Txt_regusu_fecha_f.Text = item("FECHA_FINAL").Text.Trim.ToString
            txt_regusu_ruta.Text = item("RUTA_IMAGEN").Text.Trim.ToString
            img_promo.Src = item("RUTA_IMAGEN").Text.Trim.ToString
            '    "https://www.hunteronline.com.ec/extranetdesarrollo/images/background_nuevo/Promo_rumbo_rusia_sorteo.png"
            txt_regusu_fecha.Visible = False
            Txt_regusu_fecha_f.Visible = False
            rdpdtp_fecha_Ini.Visible = True
            rdpdtp_fecha_fin.Visible = True
            Dim dTCesp As New System.Data.DataSet
            dTCesp = CampaniaAdapter.ConsultaDatosCampaniaEspecifico(Session.Item("user"), item("NOMBRE_CAMPANIA").Text.Trim.ToString)
            rdpdtp_fecha_Ini.SelectedDate = DTCesp.Tables(0).Rows(0)("FEC_I")
            rdpdtp_fecha_fin.SelectedDate = DTCesp.Tables(0).Rows(0)("FEC_F")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#Region "Procedimientos"

    Private Sub ConfigMsg(ByVal opcion As Integer, ByVal custommsg As String)
        Try
            Select Case opcion
                Case 1
                    'Mensajes tipo "OK"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMensajes.TitleIcon = "ok"
                    rntMensajes.ContentIcon = "ok"
                    rntMensajes.ShowSound = "ok"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
                Case 2
                    'Mensajes tipo "WARNING"
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMensajes.TitleIcon = "warning"
                    rntMensajes.ContentIcon = "warning"
                    rntMensajes.ShowSound = "warning"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos"
    ''' <summary>
    ''' COMENTARIO: EVENTO CHECKED DEL CHECKBOX DEL HEADER
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ChkH_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                'VerificaHunterLojack()
                'productocliente
                Dim chkH As CheckBox = TryCast(sender, CheckBox)
                For Each item As GridDataItem In Me.RgdProductos.MasterTableView.Items
                    Dim chkI As CheckBox = TryCast(item.FindControl("chkI"), CheckBox)
                    chkI.Checked = chkH.Checked
                Next
                ConfigMsg(1, "campañas activas ")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' COMENTARIO: EVENTO CHECKED DEL CHECKBOX POR FILA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ChkI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                'VerificaHunterLojack()
                Dim item As GridDataItem = TryCast(TryCast(sender, CheckBox).Parent, GridTableCell).Item
                ConfigMsg(1, "Existen campañas activas ")
                Modifica = 1
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub
#End Region

#Region "Botones"

    Protected Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Try
            txt_regusu_identificacion.Text = ""
            txt_regusu_ruta.Text = ""
            txt_regusu_fecha.Text = ""
            Txt_regusu_fecha_f.Text = ""
            img_promo.Src = ""
            txt_regusu_identificacion.Enabled = True
            txt_regusu_ruta.Enabled = True
            txt_regusu_fecha.Enabled = True
            Txt_regusu_fecha_f.Enabled = True
            BtnGraba.Visible = True
            BtnGraba.Enabled = True
            BtnNuevo.Visible = False
            BtnNuevo.Enabled = False
            rdpdtp_fecha_Ini.SelectedDate = Date.Now.Date
            rdpdtp_fecha_Ini.Visible = True
            rdpdtp_fecha_fin.SelectedDate = Date.Now.Date
            rdpdtp_fecha_fin.Visible = True
            txt_regusu_fecha.Visible = False
            Txt_regusu_fecha_f.Visible = False
            txt_regusu_ruta.Visible = False
            RadUpDocumento.Visible = True
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub BtnGraba_Click(sender As Object, e As EventArgs) Handles BtnGraba.Click
        Try
            txt_regusu_identificacion.Enabled = False
            txt_regusu_ruta.Enabled = False
            txt_regusu_fecha.Enabled = False
            Txt_regusu_fecha_f.Enabled = False
            BtnGraba.Visible = False
            BtnNuevo.Visible = True
            Dim codigo As String = ""
            ' Para grabar campañas nuevas    Session.Item("user")
            txt_regusu_fecha.Text = rdpdtp_fecha_Ini.SelectedDate
            Txt_regusu_fecha_f.Text = rdpdtp_fecha_fin.SelectedDate
            Dim dTC As New System.Data.DataSet
            dTC = CampaniaAdapter.GrabaDatosCampanias(codigo, txt_regusu_identificacion.Text, txt_regusu_fecha.Text, Txt_regusu_fecha_f.Text, txt_regusu_ruta.Text)
            If dTC.Tables(0).Rows.Count > 0 And dTC.Tables(0).Rows(0)("MENSAJE").ToString.ToUpper = "CORRECTO" Then
                ConfigMsg(1, " Registro grabado correctamente ")
                'Response.Redirect("solicitudactualizacion.aspx", False)
            Else
                ConfigMsg(2, dTC.Tables(0).Rows(0)("MENSAJE"))
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


#End Region

End Class