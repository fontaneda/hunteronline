Imports Telerik.Web.UI

Public Class Modificacioncliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("usuario") IsNot Nothing Then
                    metodos_master("Modificación de Cliente", 3, "Modificacion de datos cliente")
                    rdpdtp_fechanacimiento.MinDate = "1/1/" & Date.Now.Year - 95
                    rdpdtp_fechanacimiento.MaxDate = "31/12/" & Date.Now.Year
                    ConfigControles(False, 1)
                    ConfigControles(False, 2)
                    InicializarControles(1)
                    lblusuario.Text = Session("usuario")
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#Region "Controles"


    Protected Sub BtnBuscar_Click(sender As Object, e As System.EventArgs) Handles BtnBuscar.Click
        Try
            If txtcodigo.Text <> "" Then
                'If Len(txtcodigo.Text) > 7 And Len(txtcodigo.Text) < 14 Then
                InicializarControles(3)
                ConfigControles(True, 1)
                CargaDatosPersonales(txtcodigo.Text)
                Me.BtnBuscar.Visible = False
                Me.BtnCancelarTab1.Visible = True
                Me.txtcodigo.Enabled = False
                'Else
                '    'ProveedorMensaje.ShowMessage(rntMensajes, "Ingrese el correcta Cedula o Ruc", ProveedorMensaje.MessageStyle.OperacionInvalida)
                '    ConfigMsg(2, "Ingrese el correcta Cedula o Ruc")
                'End If
            Else
            'ProveedorMensaje.ShowMessage(rntMensajes, "Por favor ingrese el dato requerido para la cosnsulta", ProveedorMensaje.MessageStyle.OperacionInvalida)
            ConfigMsg(2, "Por favor ingrese el dato requerido para la cosnsulta")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub RgdVehiculo_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RgdVehiculo.NeedDataSource
        Try
            Me.RgdVehiculo.DataSource = Session("DTVehiculo")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub RgdVehiculo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RgdVehiculo.SelectedIndexChanged
        Try
            Dim item As GridDataItem = Nothing
            item = RgdVehiculo.SelectedItems(0)
            Dim codigo As String = item("CODIGO").Text.Trim.ToString
            If codigo <> "" Then
                lblcodigo.Text = item("CODIGO").Text.Trim.ToString
                lblmotor.Text = item("MOTOR").Text.Trim.ToString
                lblchasis.Text = item("CHASIS").Text.Trim.ToString
                lblproducto.Text = item("PRODUCTOS").Text.Trim.ToString
                'txt_placa.Text = item("PLACA").Text.Trim.ToString.Replace("-", "")
                txt_placa.Text = item("PLACA").Text.Trim.ToString
                lblplaca.Text = item("PLACA").Text.Trim.ToString
                lblnombrecompleto.Text = item("NOMBRE_COMPLETO").Text.Trim.ToString
                Rcbaseguradora.SelectedValue = item("CIA_SEGUROS").Text.Trim.ToString
                Rcbconcesionario.SelectedValue = item("CODIGO_CONCESIONARIO").Text.Trim.ToString
                Rcbfinanciera.SelectedValue = item("CODIGO_FINANCIADOR").Text.Trim.ToString
                Rcbbroker.SelectedValue = item("CODIGO_BROKE").Text.Trim.ToString
                lblconcesionaria.Text = item("CONCESIONARIO").Text.Trim.ToString
                lblaseguradora.Text = item("ASEGURADORA").Text.Trim.ToString
                lblfinanciera.Text = item("FINANCIERA").Text.Trim.ToString
                lblbroker.Text = item("BROKE").Text.Trim.ToString
                ConfigControles(True, 2)
            Else
                ConfigControles(False, 2)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub Chkfacebook_CheckedChanged(sender As Object, e As EventArgs) Handles Chkfacebook.CheckedChanged
        If Chkfacebook.Checked = True Then
            txt_facebook.Enabled = True
        Else
            txt_facebook.Enabled = False
        End If
    End Sub


    Private Sub Chkinstagram_CheckedChanged(sender As Object, e As System.EventArgs) Handles Chkinstagram.CheckedChanged
        If Chkinstagram.Checked = True Then
            txt_instagram.Enabled = True
        Else
            txt_instagram.Enabled = False
        End If
    End Sub


    Private Sub Chksnapchat_CheckedChanged(sender As Object, e As System.EventArgs) Handles Chksnapchat.CheckedChanged
        If Chksnapchat.Checked = True Then
            txt_snapchat.Enabled = True
        Else
            txt_snapchat.Enabled = False
        End If
    End Sub

    Private Sub Chktwiter_CheckedChanged(sender As Object, e As System.EventArgs) Handles Chktwiter.CheckedChanged
        If Chktwiter.Checked = True Then
            txt_twiter.Enabled = True
        Else
            txt_twiter.Enabled = False
        End If
    End Sub


    'Private Sub Radtabdatosconsulta_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles Radtabdatosconsulta.TabClick
    '    Try
    '        'If txtcodigo.Text <> "" Then
    '        '    If Me.Radtabdatosconsulta.SelectedIndex = 0 Then
    '        '        ConfigMsg(2, "No se olvide de Grabar los cambios en cada Tab")
    '        '    End If
    '        '    If Me.Radtabdatosconsulta.SelectedIndex = 1 Then
    '        '        ConfigMsg(2, "No se olvide de Grabar los cambios en cada Tab ")
    '        '    End If
    '        '    If Me.Radtabdatosconsulta.SelectedIndex = 2 Then
    '        '        ConfigMsg(2, "No se olvide de Grabar los cambios en cada Tab ")
    '        '    End If
    '        '    If Me.Radtabdatosconsulta.SelectedIndex = 3 Then
    '        '        ConfigMsg(2, "No se olvide de Grabar los cambios en cada Tab ")
    '        '    End If
    '        '    If Me.Radtabdatosconsulta.SelectedIndex = 4 Then
    '        '        ConfigMsg(2, "No se olvide de Grabar los cambios en cada Tab ")
    '        '    End If
    '        'End If
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Protected Sub BtnGrabarTab1_Click(sender As Object, e As System.EventArgs) Handles BtnGrabarTab1.Click
        Try
            If (Date.Now.Year - Year(rdpdtp_fechanacimiento.SelectedDate)) > 18 And (Date.Now.Year - Year(rdpdtp_fechanacimiento.SelectedDate)) < 95 Then
                Dim fechanacimiento As DateTime = rdpdtp_fechanacimiento.SelectedDate
                Dim dtDatos As New DataTable
                dtDatos.Columns.Add("tipo")
                dtDatos.Columns.Add("referencia")
                dtDatos.Columns.Add("campo")
                Dim dr As DataRow
                dr = dtDatos.NewRow()
                dr("tipo") = "FEC"
                dr("referencia") = ""
                dr("campo") = fechanacimiento.ToString("dd/MM/yyyy")
                dtDatos.Rows.Add(dr)
                If dtDatos.Rows.Count > 0 Then
                    DatosPersonalesAdapter.ModificarClienteWeb(dtDatos, txtcodigo.Text.Trim, lblusuario.Text)
                    ConfigMsg(1, "Datos Modificados con exito ")
                    Me.BtnGrabarTab1.Enabled = False
                    rdpdtp_fechanacimiento.Enabled = False
                End If
            Else
                ConfigMsg(2, "Fecha de Nacimiento Incorrecta, verificar debe se Mayor de 18 años y Menor a 95 años")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    'Protected Sub BtnCancelarTab1_Click(sender As Object, e As System.EventArgs) Handles BtnCancelarTab1.Click 
    Protected Sub BtnCancelarTab1_Click(sender As Object, e As System.EventArgs)
        Try
            If Session("dtVehActualiza") Is Nothing Then
                ConfigControles(False, 1)
                ConfigControles(False, 2)
                InicializarControles(1)
                Me.BtnBuscar.Visible = True
                Me.BtnCancelarTab1.Visible = False
                Me.txtcodigo.Enabled = True
            Else
                ConfigMsg(2, "No se ha Guardado los Vehiculos, verificar ")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

   
    Protected Sub BtnGrabarTab2_Click(sender As Object, e As EventArgs) Handles BtnGrabarTab2.Click
        Try
            Dim dtDatos As New DataTable
            dtDatos.Columns.Add("tipo")
            dtDatos.Columns.Add("referencia")
            dtDatos.Columns.Add("campo")
            Dim dr As DataRow
            If txt_convencional.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "TEL"
                dr("referencia") = "001"
                dr("campo") = txt_convencional.Text
                dtDatos.Rows.Add(dr)
            End If
            If txt_convencionalextra.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "TEL"
                dr("referencia") = "005"
                dr("campo") = txt_convencionalextra.Text
                dtDatos.Rows.Add(dr)
            End If
            If txt_celular.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "TEL"
                dr("referencia") = "004"
                dr("campo") = txt_celular.Text
                dtDatos.Rows.Add(dr)
            End If
            If txt_celularextra.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "TEL"
                dr("referencia") = "006"
                dr("campo") = txt_celularextra.Text
                dtDatos.Rows.Add(dr)
            End If
            If txt_direcdomicilio.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "DOM"
                dr("referencia") = "002"
                dr("campo") = txt_direcdomicilio.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If txt_direcoficina.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "DOM"
                dr("referencia") = "001"
                dr("campo") = txt_direcoficina.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If dtDatos.Rows.Count > 0 Then
                DatosPersonalesAdapter.ModificarClienteWeb(dtDatos, txtcodigo.Text.Trim, lblusuario.Text)
                ConfigMsg(1, "Datos Modificados con exito ")
                Me.BtnGrabarTab2.Enabled = False
                txt_convencional.Enabled = False
                txt_convencionalextra.Enabled = False
                txt_celular.Enabled = False
                txt_celularextra.Enabled = False
                txt_direcdomicilio.Enabled = False
                txt_direcoficina.Enabled = False
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnGrabarTab3_Click(sender As Object, e As EventArgs) Handles BtnGrabarTab3.Click
        Try
            Dim dtDatos As New DataTable
            dtDatos.Columns.Add("tipo")
            dtDatos.Columns.Add("referencia")
            dtDatos.Columns.Add("campo")
            Dim dr As DataRow
            If txt_email.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "MAI"
                dr("referencia") = "004"
                dr("campo") = txt_email.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If txt_emailoficina.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "MAI"
                dr("referencia") = "016"
                dr("campo") = txt_emailoficina.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If txt_emailfactura.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "MAI"
                dr("referencia") = "017"
                dr("campo") = txt_emailfactura.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If Chkfacebook.Checked = True Then
                dr = dtDatos.NewRow()
                dr("tipo") = "RED"
                dr("referencia") = "FAC"
                If txt_facebook.Text <> "" Then
                    dr("campo") = txt_facebook.Text.ToUpper()
                Else
                    dr("campo") = ""
                End If
                dtDatos.Rows.Add(dr)
            End If
            If Chktwiter.Checked = True Then
                dr = dtDatos.NewRow()
                dr("tipo") = "RED"
                dr("referencia") = "TWI"
                If txt_twiter.Text <> "" Then
                    dr("campo") = txt_twiter.Text
                Else
                    dr("campo") = ""
                End If
                dtDatos.Rows.Add(dr)
            End If
            If Chkinstagram.Checked = True Then
                dr = dtDatos.NewRow()
                dr("tipo") = "RED"
                dr("referencia") = "INS"
                If txt_instagram.Text <> "" Then
                    dr("campo") = txt_instagram.Text.ToUpper()
                Else
                    dr("campo") = ""
                End If
                dtDatos.Rows.Add(dr)
            End If
            If Chksnapchat.Checked = True Then
                dr = dtDatos.NewRow()
                dr("tipo") = "RED"
                dr("referencia") = "SNA"
                If txt_snapchat.Text <> "" Then
                    dr("campo") = txt_snapchat.Text.ToUpper()
                Else
                    dr("campo") = ""
                End If
                dtDatos.Rows.Add(dr)
            End If
            If dtDatos.Rows.Count > 0 Then
                DatosPersonalesAdapter.ModificarClienteWeb(dtDatos, txtcodigo.Text.Trim, lblusuario.Text)
                ConfigMsg(1, "Datos Modificados con exito ")
                Me.BtnGrabarTab3.Enabled = False
                txt_email.Enabled = False
                txt_emailoficina.Enabled = False
                txt_emailfactura.Enabled = False
                txt_facebook.Enabled = False
                txt_twiter.Enabled = False
                txt_instagram.Enabled = False
                txt_snapchat.Enabled = False
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnGrabarTab4_Click(sender As Object, e As EventArgs) Handles BtnGrabarTab4.Click
        Try
            If Session("dtVehActualiza") IsNot Nothing Then
                DatosPersonalesAdapter.ModificarClienteWeb(Session("dtVehActualiza"), txtcodigo.Text.Trim, lblusuario.Text)
                Me.BtnGrabarTab4.Enabled = False
                ConfigMsg(1, "Datos Modificados con exito ")
                Session("dtVehActualiza") = Nothing
            Else
                ConfigMsg(2, "No se ha modificado ningun registro")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnCancelarTab4_Click(sender As Object, e As EventArgs) Handles BtnCancelarTab4.Click
        Try
            Dim dTDatosVehiculo As DataSet
            dTDatosVehiculo = DatosPersonalesAdapter.DatosPersonalesCliente(Me.txtcodigo.Text, 116)
            If dTDatosVehiculo.Tables(0).Rows.Count > 0 Then
                Session("DTVehiculo") = dTDatosVehiculo.Tables(0)
                Me.RgdVehiculo.DataSource = Session("DTVehiculo")
                Me.RgdVehiculo.DataBind()
            End If
            ConfigControles(2, False)
            InicializarControles(2)
            Me.BtnGrabarTab4.Enabled = False
            Session("dtVehActualiza") = Nothing
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnAplicarTab4_Click(sender As Object, e As EventArgs) Handles BtnAplicarTab4.Click
        Try
            If lblcodigo.Text <> "" Then
                Dim validadorexpression As Boolean = True
                If Rcbconcesionario.SelectedValue = "" Then
                    ConfigMsg(2, "Verifique el Concesionario, Seleccione correctamente ")
                    validadorexpression = False
                ElseIf Rcbfinanciera.SelectedValue = "" Then
                    ConfigMsg(2, "Verifique la Financiera, Seleccione correctamente ")
                    validadorexpression = False
                ElseIf (txt_placa.Text) <> "S/P" Then
                    If Len(txt_placa.Text) = 8 Then
                        If Not (Regex.IsMatch(txt_placa.Text.Trim().Substring(0, 3), "^[a-zA-Z\s]{1,3}$")) Then
                            ConfigMsg(2, "Verifique la Placa, Mal Ingresado los tres primeros caracteres el Formato: AAA-0999")
                            validadorexpression = False
                        ElseIf Not (txt_placa.Text.Trim().Substring(3, 1) = "-") Then
                            ConfigMsg(2, "Verifique la Placa, el separador esta mal ingresado el Formato: AAA-0999")
                            validadorexpression = False
                        ElseIf Not (Regex.IsMatch(txt_placa.Text.Trim().Substring(4, 4), "^[\d]{1,4}$")) Then
                            ConfigMsg(2, "Verifique la Placa, Mal Ingresado los cuatro ultimos caracteres el Formato: AAA-0999")
                            validadorexpression = False
                        End If
                    ElseIf Len(txt_placa.Text) < 8 Or Len(txt_placa.Text) > 8 Then
                        ConfigMsg(2, "Verifique la Placa, Mal Ingresado el Formato: AAA-0999")
                        validadorexpression = False
                    End If
                End If
                If validadorexpression Then
                    If Rcbaseguradora.SelectedValue <> "" Then
                        Dim dtVehBusq As New DataTable
                        dtVehBusq = CType(Session("DTVehiculo"), DataTable)
                        If dtVehBusq IsNot Nothing Then
                            Dim view As New DataView(dtVehBusq)
                            view.Sort = "CODIGO"
                            If view.Find(lblcodigo.Text) <> -1 Then
                                Dim i As Integer = view.Find(lblcodigo.Text)
                                view.Delete(i)
                            End If
                            Session("DTVehiculo") = dtVehBusq
                            RgdVehiculo.DataSource = Session("DTVehiculo")
                            RgdVehiculo.DataBind()
                        End If
                        Dim dtVehConsc As New DataTable
                        dtVehConsc = CType(Session("DTVehiculo"), DataTable)
                        If dtVehConsc IsNot Nothing Then
                            Dim view2 As New DataView(dtVehConsc)
                            view2.Sort = "CODIGO"
                            If view2.Find(lblcodigo.Text) = -1 Then
                                Dim dr As DataRow
                                dr = dtVehConsc.NewRow()
                                dr("CODIGO") = Me.lblcodigo.Text
                                dr("PLACA") = Me.txt_placa.Text
                                dr("MOTOR") = Me.lblmotor.Text
                                dr("CHASIS") = Me.lblchasis.Text
                                dr("PRODUCTOS") = Me.lblproducto.Text
                                dr("CIA_SEGUROS") = Rcbaseguradora.SelectedValue
                                dr("ASEGURADORA") = Rcbaseguradora.Text
                                dr("CODIGO_CONCESIONARIO") = Rcbconcesionario.SelectedValue
                                dr("CONCESIONARIO") = Rcbconcesionario.Text
                                dr("CODIGO_FINANCIADOR") = Rcbfinanciera.SelectedValue
                                dr("FINANCIERA") = Rcbfinanciera.Text
                                dr("CODIGO_BROKE") = Rcbbroker.SelectedValue
                                dr("BROKE") = Rcbbroker.Text
                                dr("NOMBRE_COMPLETO") = Me.lblnombrecompleto.Text
                                dr("GRABA") = "S"
                                dtVehConsc.Rows.Add(dr)
                                Session("DTVehiculo") = dtVehConsc
                                RgdVehiculo.DataSource = Session("DTVehiculo")
                                RgdVehiculo.DataBind()
                                Dim campo As String
                                campo = "Cod:" & Me.lblcodigo.Text & "|Pla:" & Me.txt_placa.Text & "|Ase:" & Rcbaseguradora.SelectedValue & "|Con:" & Rcbconcesionario.SelectedValue & "|Fin:" & Rcbfinanciera.SelectedValue & "|Bro:" & Rcbbroker.SelectedValue
                                If Session("dtVehActualiza") Is Nothing Then
                                    Dim dtVeh As New DataTable
                                    dtVeh.Columns.Add("tipo")
                                    dtVeh.Columns.Add("referencia")
                                    dtVeh.Columns.Add("campo")
                                    Dim veh As DataRow
                                    veh = dtVeh.NewRow()
                                    veh("tipo") = "VEH"
                                    veh("referencia") = ""
                                    veh("campo") = campo
                                    dtVeh.Rows.Add(veh)
                                    Session("dtVehActualiza") = dtVeh
                                Else
                                    Dim dtVeh As New DataTable
                                    dtVeh = CType(Session("dtVehActualiza"), DataTable)
                                    Dim view As New DataView(dtVeh)
                                    view.Sort = "campo"
                                    If view.Find(campo) = -1 Then
                                        Dim veh As DataRow
                                        veh = dtVeh.NewRow()
                                        veh("tipo") = "VEH"
                                        veh("referencia") = ""
                                        veh("campo") = campo
                                        dtVeh.Rows.Add(veh)
                                        Session("dtVehActualiza") = dtVeh
                                    End If
                                End If
                            End If
                        End If
                        InicializarControles(2)
                        Me.BtnAplicarTab4.Enabled = False
                        Me.BtnGrabarTab4.Enabled = True
                    Else
                        ConfigMsg(2, "Verifique la Aseguradora, seleccione correctamente ")
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnGrabarTab5_Click(sender As Object, e As EventArgs) Handles BtnGrabarTab5.Click
        Try
            Dim dtDatos As New DataTable
            dtDatos.Columns.Add("tipo")
            dtDatos.Columns.Add("referencia")
            dtDatos.Columns.Add("campo")
            Dim dr As DataRow
            If txt_consulta.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "PRE"
                dr("referencia") = "DSP"
                dr("campo") = txt_consulta.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If txt_comentario.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "PRE"
                dr("referencia") = "COM"
                dr("campo") = txt_comentario.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If txt_problemas.Text <> "" Then
                dr = dtDatos.NewRow()
                dr("tipo") = "PRE"
                dr("referencia") = "PRO"
                dr("campo") = txt_problemas.Text.ToUpper()
                dtDatos.Rows.Add(dr)
            End If
            If dtDatos.Rows.Count > 0 Then
                DatosPersonalesAdapter.ModificarClienteWeb(dtDatos, txtcodigo.Text.Trim, lblusuario.Text)
                ConfigMsg(1, "Datos Modificados con exito ")
                Me.BtnGrabarTab5.Enabled = False
                txt_consulta.Enabled = False
                txt_comentario.Enabled = False
                txt_problemas.Enabled = False
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub CargaDatosPersonales(ByVal cliente As String)
        Try
            Dim dTDatosPersonales As DataSet
            dTDatosPersonales = DatosPersonalesAdapter.DatosPersonalesCliente(cliente, 115)
            If dTDatosPersonales.Tables(0).Rows.Count > 0 Then
                '   If dTDatosPersonales.Tables(0).Rows(0)("TIPO_CLIENTE") = "001" And dTDatosPersonales.Tables(0).Rows(0)("TIPO_IDENTIFICACION") = "001" Then
                lbl_nombres.Text = dTDatosPersonales.Tables(0).Rows(0)("NOMBRES")
                lbl_apellidos.Text = dTDatosPersonales.Tables(0).Rows(0)("APELLIDOS")
                txt_auditoria.Text = dTDatosPersonales.Tables(0).Rows(0)("AUDITORIA")
                lblcliente.Text = dTDatosPersonales.Tables(0).Rows(0)("NOMBRE_COMPLETO")
                If (Date.Now.Year - Year(dTDatosPersonales.Tables(0).Rows(0)("FECHA_CREACION"))) > 18 And (Date.Now.Year - Year(dTDatosPersonales.Tables(0).Rows(0)("FECHA_CREACION"))) < 85 Then
                    rdpdtp_fechanacimiento.SelectedDate = dTDatosPersonales.Tables(0).Rows(0)("FECHA_CREACION")
                Else
                    rdpdtp_fechanacimiento.SelectedDate = "1/1/" & Date.Now.Year - 85
                End If
                If dTDatosPersonales.Tables(1).Rows.Count > 0 Then
                    lblconvencional.Text = dTDatosPersonales.Tables(1).Rows(0)("TELEFONO_FIJO")
                    lblcelular.Text = dTDatosPersonales.Tables(1).Rows(0)("MOVIL")
                    lbltelefonoextra.Text = dTDatosPersonales.Tables(1).Rows(0)("TELEFONO_EXTRA")
                    lblcelularextra.Text = dTDatosPersonales.Tables(1).Rows(0)("MOVIL_EXTRA")
                    lbloficina.Text = dTDatosPersonales.Tables(1).Rows(0)("DIREC_OFICINA")
                    lbldomicilio.Text = dTDatosPersonales.Tables(1).Rows(0)("DIREC_DOMICILIO")
                    lblemail.Text = dTDatosPersonales.Tables(1).Rows(0)("EMAIL")
                    lblemailoficina.Text = dTDatosPersonales.Tables(1).Rows(0)("EMAIL_OFICINA")
                    lblemailfactura.Text = dTDatosPersonales.Tables(1).Rows(0)("EMAIL_FACTURA")
                End If
                'Else
                '    ConfigMsg(2, "Solo puede consultar cliente de Tipo Comercial, por favor verificar ")
                'End If
                Session("dtVehActualiza") = Nothing
                Dim dTDatosVehiculo As DataSet
                dTDatosVehiculo = DatosPersonalesAdapter.DatosPersonalesCliente(cliente, 116)
                If dTDatosVehiculo.Tables(0).Rows.Count > 0 Then
                    Session("DTVehiculo") = dTDatosVehiculo.Tables(0)
                    Me.RgdVehiculo.DataSource = Session("DTVehiculo")
                    'Me.RgdProductos.VirtualItemCount = dTCstProducto.Tables(0).Rows.Count
                    Me.RgdVehiculo.DataBind()
                Else
                    Me.RgdVehiculo.DataSource = dTDatosVehiculo.Tables(0).Rows
                    Me.RgdVehiculo.DataBind()
                End If
            Else
                ConfigMsg(2, "No existen datos para la consulta ")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigControles(ByVal valor As Boolean, ByVal opcion As String)
        Try
            If opcion = "1" Then
                rdpdtp_fechanacimiento.Enabled = valor
                txt_convencional.Enabled = valor
                txt_celular.Enabled = valor
                txt_convencionalextra.Enabled = valor
                txt_celularextra.Enabled = valor
                txt_direcoficina.Enabled = valor
                txt_direcdomicilio.Enabled = valor
                txt_email.Enabled = valor
                txt_emailoficina.Enabled = valor
                txt_emailfactura.Enabled = valor
                txt_facebook.Enabled = False
                txt_twiter.Enabled = False
                txt_instagram.Enabled = False
                txt_snapchat.Enabled = False
                Chksnapchat.Enabled = valor
                Chkinstagram.Enabled = valor
                Chktwiter.Enabled = valor
                Chkfacebook.Enabled = valor
                BtnGrabarTab5.Enabled = valor
                BtnGrabarTab3.Enabled = valor
                BtnGrabarTab2.Enabled = valor
                BtnGrabarTab1.Enabled = valor
                txt_consulta.Enabled = valor
                txt_comentario.Enabled = valor
                txt_problemas.Enabled = valor
            End If
            If opcion = "2" Then
                txt_placa.Enabled = valor
                Rcbaseguradora.Enabled = valor
                Rcbconcesionario.Enabled = valor
                Rcbfinanciera.Enabled = valor
                Rcbbroker.Enabled = valor
                BtnAplicarTab4.Enabled = valor
                BtnCancelarTab4.Enabled = valor
                'BtnGrabarTab4.Enabled = valor
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub InicializarControles(ByVal opcion As String)
        Try
            If opcion = "1" Then
                lblcliente.Text = "Modificación de Cliente"
                txtcodigo.Text = ""
                txt_convencional.Text = ""
                txt_celular.Text = ""
                txt_convencionalextra.Text = ""
                txt_celularextra.Text = ""
                txt_direcoficina.Text = ""
                txt_direcdomicilio.Text = ""
                txt_email.Text = ""
                txt_emailoficina.Text = ""
                txt_emailfactura.Text = ""
                txt_facebook.Text = ""
                txt_twiter.Text = ""
                txt_instagram.Text = ""
                txt_snapchat.Text = ""
                txt_placa.Text = ""
                lblplaca.Text = ""
                lblcodigo.Text = ""
                lblmotor.Text = ""
                lblchasis.Text = ""
                lblproducto.Text = ""
                lbl_nombres.Text = ""
                lbl_apellidos.Text = ""
                txt_auditoria.Text = ""
                lblconvencional.Text = ""
                lblcelular.Text = ""
                lbltelefonoextra.Text = ""
                lblcelularextra.Text = ""
                lbloficina.Text = ""
                lbldomicilio.Text = ""
                lblemail.Text = ""
                lblemailoficina.Text = ""
                lblemailfactura.Text = ""
                lblconcesionaria.Text = ""
                lblaseguradora.Text = ""
                lblfinanciera.Text = ""
                lblbroker.Text = ""
                'lblfacebook.Text = ""
                'lbltwiter.Text = ""
                'lblinstagram.Text = ""
                'lblsnapchat.Text = ""
                rdpdtp_fechanacimiento.SelectedDate = "1/1/" & Date.Now.Year - 85
                Chksnapchat.Checked = False
                Chkinstagram.Checked = False
                Chkfacebook.Checked = False
                Chktwiter.Checked = False
                BtnGrabarTab4.Enabled = False
                lblnombrecompleto.Text = ""
                Dim dTDatosVehiculo As DataSet
                dTDatosVehiculo = DatosPersonalesAdapter.DatosPersonalesCliente("0000000000", 116)
                If dTDatosVehiculo.Tables(0).Rows.Count > 0 Then
                    Session("DTVehiculo") = dTDatosVehiculo.Tables(0)
                    Me.RgdVehiculo.DataSource = Session("DTVehiculo")
                    Me.RgdVehiculo.DataBind()
                Else
                    Session("DTVehiculo") = Nothing
                    'Session("DTVehiculoCancelar") = Nothing
                    Me.RgdVehiculo.DataSource = dTDatosVehiculo.Tables(0)
                    Me.RgdVehiculo.DataBind()
                End If
                Session("dtVehActualiza") = Nothing
                CargarComboAse()
                CargarComboFin()
                CargarComboCon()
            End If
            If opcion = "2" Then
                lblcodigo.Text = ""
                lblmotor.Text = ""
                lblchasis.Text = ""
                lblproducto.Text = ""
                lblplaca.Text = ""
                txt_placa.Text = ""
                lblnombrecompleto.Text = ""
                lblconcesionaria.Text = ""
                lblaseguradora.Text = ""
                lblfinanciera.Text = ""
                lblbroker.Text = ""
                Rcbaseguradora.SelectedValue = 0
                Rcbconcesionario.SelectedValue = 0
                Rcbfinanciera.SelectedValue = 0
                Rcbbroker.SelectedValue = 0
            End If
            If opcion = "3" Then
                txt_convencional.Text = ""
                txt_convencionalextra.Text = ""
                txt_celular.Text = ""
                txt_celularextra.Text = ""
                txt_direcdomicilio.Text = ""
                txt_direcoficina.Text = ""
                txt_email.Text = ""
                txt_emailoficina.Text = ""
                txt_facebook.Text = ""
                txt_twiter.Text = ""
                txt_instagram.Text = ""
                txt_snapchat.Text = ""
                Chksnapchat.Checked = False
                Chkinstagram.Checked = False
                Chkfacebook.Checked = False
                Chktwiter.Checked = False
                txt_placa.Text = ""
                Rcbaseguradora.SelectedValue = 0
                Rcbconcesionario.SelectedValue = 0
                Rcbfinanciera.SelectedValue = 0
                Rcbbroker.SelectedValue = 0
                txt_comentario.Text = ""
                txt_consulta.Text = ""
                txt_problemas.Text = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargarComboAse()
        Try
            Dim dTCstTipo As New System.Data.DataSet
            dTCstTipo = DatosPersonalesAdapter.ConsultaTipo("ASE")
            If dTCstTipo.Tables(0).Rows.Count > 0 Then
                Me.Rcbaseguradora.DataSource = dTCstTipo
                Me.Rcbaseguradora.DataTextField = "DESCRIPCION"
                Me.Rcbaseguradora.DataValueField = "CODIGO"
                Me.Rcbaseguradora.DataBind()
            End If
            Rcbaseguradora.AllowCustomText = True
            Rcbaseguradora.MarkFirstMatch = True
            Rcbaseguradora.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargarComboFin()
        Try
            Dim dTCstTipo As New System.Data.DataSet
            dTCstTipo = DatosPersonalesAdapter.ConsultaTipo("OTR")
            If dTCstTipo.Tables(0).Rows.Count > 0 Then
                Me.Rcbfinanciera.DataSource = dTCstTipo
                Me.Rcbfinanciera.DataTextField = "DESCRIPCION"
                Me.Rcbfinanciera.DataValueField = "CODIGO"
                Me.Rcbfinanciera.DataBind()
            End If
            Rcbfinanciera.AllowCustomText = True
            Rcbfinanciera.MarkFirstMatch = True
            Rcbfinanciera.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargarComboCon()
        Try
            Dim dTCstTipo As New System.Data.DataSet
            dTCstTipo = DatosPersonalesAdapter.ConsultaTipo("CON")
            If dTCstTipo.Tables(0).Rows.Count > 0 Then
                Me.Rcbconcesionario.DataSource = dTCstTipo
                Me.Rcbconcesionario.DataTextField = "DESCRIPCION"
                Me.Rcbconcesionario.DataValueField = "CODIGO"
                Me.Rcbconcesionario.DataBind()
                Me.Rcbbroker.DataSource = dTCstTipo
                Me.Rcbbroker.DataTextField = "DESCRIPCION"
                Me.Rcbbroker.DataValueField = "CODIGO"
                Me.Rcbbroker.DataBind()
            End If
            Rcbconcesionario.AllowCustomText = True
            Rcbconcesionario.MarkFirstMatch = True
            Rcbconcesionario.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
            Rcbbroker.AllowCustomText = True
            Rcbbroker.MarkFirstMatch = True
            Rcbbroker.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConfigMsg(ByVal opcion As Integer, ByVal custommsg As String)
        Try
            Select Case opcion
                Case 1
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje del aplicativo HunterOnline"
                    rntMensajes.TitleIcon = "ok"
                    rntMensajes.ContentIcon = "ok"
                    rntMensajes.ShowSound = "ok"
                    rntMensajes.Width = 400
                    rntMensajes.Height = 100
                    rntMensajes.Show()
                Case 2
                    rntMensajes.Text = custommsg
                    rntMensajes.Title = "Mensaje del aplicativo HunterOnline"
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

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

#End Region


End Class