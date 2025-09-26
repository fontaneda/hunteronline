Public Class Vehiculoespecificobien
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    carga_inicial()
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Botones"

    ' PARA GRABAR LOS DATOS DE UN VEHICULO ,  MOTOR, PLACA, CHASIS, COLOR, INFORMACION-ADICIONAL, ANIO. MARCA
    Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click
        Try
            'Dim dTCstenvio As New System.Data.DataSet
            'If Chkbdarbaja.Checked = True Then
            '    dTCstenvio = VehiculoAdapter.GrabaBajaVehiculo(txtcodigo.Text, 2, Session.Item("user").ToString)
            '    If dTCstenvio.Tables(0).Rows.Count > 0 Then
            '        Session("DTTransac") = dTCstenvio
            '    End If
            '    'Chkbdarbaja.Focus()
            'Else
            '    'Dim dTCstenvio As New System.Data.DataSet
            '    dTCstenvio = VehiculoAdapter.GrabaBajaVehiculo(txtcodigo.Text, 1, Session.Item("user").ToString)
            '    If dTCstenvio.Tables(0).Rows.Count > 0 Then
            '        Session("DTTransac") = dTCstenvio
            '    End If
            'End If
            'Dim dTCstenviar As New System.Data.DataSet
            ''DTCstenviar = VehiculoAdapter.GrabaDatosVehiculo(txtcodigo.Text, txtplacabien.Text, txtmotorbien.Text, txtchasisbien.Text, txtaniobien.Text, txtobservacionbien.Text, rcbcolorbien.SelectedValue, _
            ''                                                 rcbmarcabien.SelectedValue, rcbmodelobien.SelectedValue, Session.Item("user").ToString(), rcbaseguradorabien.SelectedValue)
            'dTCstenviar = VehiculoAdapter.GrabaDatosVehiculo(txtcodigo.Text, txtplacabien.Text, " ", " -", txtaniobien.Text, txtobservacionbien.Text, "000",
            '                                                 "000", "000", Session.Item("user").ToString(), "9980000000005")
            ''DTCstenviar = VehiculoAdapter.GrabaDatosVehiculo(txtcodigo.Text, txtplacabien.Text, txtmotorbien.Text, " -", txtaniobien.Text, txtobservacionbien.Text, "000", _
            ''                                                 "000", "000", Session.Item("user").ToString(), "9980000000005")
            'If dTCstenviar.Tables(0).Rows.Count > 0 Then
            '    EnviaEMailConfirmacion()
            '    'Session("DTTransaccion") = DTCstenviar
            '    'Me.rgdVehiculo.DataSource = DTCstenviar
            '    'Me.rgdVehiculo.DataBind()
            '    ConfigMsg(1, "Registro grabado correctamente")
            '    'Dim cadena As String = ""
            '    'cadena = "./vehiculo.aspx"
            '    'Page.Response.Redirect("./vehiculo.aspx")
            '    Response.Redirect("./vehiculo.aspx", False)
            'Else
            '    ConfigMsg(2, "No se pudo grabar el registro de vehículo")
            'End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancelar.Click
        Try
            'Dim cadena As String = ""
            'cadena = "./vehiculo.aspx"
            'Page.Response.Redirect(cadena)
            'Response.Redirect("./vehiculo.aspx", False)
            If Session("retorno") = 0 Then
                If Session("callback") = "Vehiculochequeo" Then
                    Session("retorno") = 1
                    Response.Redirect("./vehiculochequeo.aspx", False)
                ElseIf Session("callback") = "Vehiculoespecifico" Then
                    Response.Redirect("./Vehiculoespecifico.aspx", False)
                ElseIf Session("callback") = "Vehiculo" Then
                    Response.Redirect("./vehiculo.aspx", False)
                End If
            Else
                Response.Redirect("./vehiculo.aspx", False)
            End If
            Session("callback") = "Vehiculoespecificobien"
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
            Throw ex
        End Try
    End Sub

    Protected Sub BtnDetalle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDetalle.Click
        Try
            'Page.Response.Redirect("./vehiculochequeo.aspx")
            Session("callback") = "Vehiculoespecificobien"
            Session("retorno") = 0
            Response.Redirect("./vehiculochequeo.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
            Throw ex
        End Try
    End Sub

    'Protected Sub rcbmarcabien_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles rcbmarcabien.SelectedIndexChanged
    'item = RadComboBoxSelectedIndexChangedEventArgs.Equals
    'sender.set_text("You selected " + item.get_text());
    'Dim datomodelo2 As New System.Data.DataSet
    'datomodelo2 = VehiculoAdapter.ConsultaDatosVehiculosModelo(Session("id_vehiculo").ToString, rcbmarcabien.SelectedValue)
    'rcbmodelobien.DataSource = datomodelo2
    'rcbmodelobien.DataValueField = "CODIGO"   'datocolor.Tables(0).Columns("CODIGO").ToString
    'rcbmodelobien.DataTextField = "DESCRIPCION" 'datocolor.Tables(0).Columns("DESCRIPCION").ToString
    'rcbmodelobien.DataBind()
    'End Sub

#End Region

#Region "Procedimientos"

    Private Sub EnviaEMailConfirmacion()
        Try
            Dim ciudad As String
            ciudad = VehiculoAdapter.ConsultaCiudad(Session("id_vehiculo").ToString, "200")
            Dim mensaje As String
            mensaje = VehiculoAdapter.ConsultaEmail(Session("id_vehiculo").ToString, "100")
            EMailHandler.EMailActivacionVehiculo(mensaje, ciudad)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigMsg(ByVal opcion As Integer, ByVal custommsg As String)
        Try
            Select Case opcion
                Case 1
                    'Mensajes tipo "OK"
                    rntmensaje.Text = custommsg
                    rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
                    rntmensaje.TitleIcon = "ok"
                    rntmensaje.ContentIcon = "ok"
                    rntmensaje.ShowSound = "ok"
                    rntmensaje.Width = 400
                    rntmensaje.Height = 100
                    rntmensaje.Show()
                Case 2
                    'Mensajes tipo "WARNING"
                    rntmensaje.Text = custommsg
                    rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
                    rntmensaje.TitleIcon = "warning"
                    rntmensaje.ContentIcon = "warning"
                    rntmensaje.ShowSound = "warning"
                    rntmensaje.Width = 400
                    rntmensaje.Height = 100
                    rntmensaje.Show()
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub carga_inicial()
        Dim idVehiculo As String = Session("id_vehiculo").ToString
        If idVehiculo <> "" Then
            Dim dtvehiculo As New System.Data.DataTable
            Dim id_script As String = ""
            Dim parametro As String = ""
            id_script = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
            parametro = ConfigurationManager.AppSettings.Get("NSParamDatosVehiculos").ToString()
            dtvehiculo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", Session("id_vehiculo"), "", Session("user_netsuite"), "", "", ""))
            If dtvehiculo.Rows.Count > 0 Then
                txtcodigo.Text = dtvehiculo.Rows(0).Item("CodigoVehiculo").ToString
                txtplacabien.Text = dtvehiculo.Rows(0).Item("Placa").ToString
                txtmotorbien.Text = dtvehiculo.Rows(0).Item("Motor").ToString
                txtaniobien.Text = dtvehiculo.Rows(0).Item("Anio").ToString
                Txtconcesionario.Text = dtvehiculo.Rows(0).Item("Concesionario").ToString
                Txtfechacreacion.Text = "1900-01-01" 'dtvehiculo.Rows(0).Item("Concesionario").ToString
                txtobservacionbien.Text = dtvehiculo.Rows(0).Item("VehiculoNombre").ToString '
                Txtfechaactualizacion.Text = "1900-01-01" 'dtvehiculo.Rows(0).Item("Concesionario").ToString
            End If
            'Dim datovehiculobaja As New System.Data.DataSet
            'datovehiculobaja = VehiculoAdapter.ConsultaDatosVehiculosBaja(idVehiculo)
            'If datovehiculobaja.Tables(0).Rows.Count > 0 Then
            '    If datovehiculobaja.Tables(0).Rows(0).Item(1).ToString = 2 Then
            '        Chkbdarbaja.Checked = True
            '    Else
            '        Chkbdarbaja.Checked = False
            '    End If
            'Else
            '    Chkbdarbaja.Checked = False
            'End If
        End If
        If Session("Administrador") = "ADM" Or Session("Administrador") = "USR" Then
            Me.BtnEnviar.Enabled = False
        End If
    End Sub

#End Region

End Class