Imports System.Net.Mail
Imports Telerik.Web.UI
'Imports System.Drawing.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing.Imaging

Public Class busquedaturno
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    Session("id_taller_turno") = 0
                    Session("fecha_turno_calendario") = Date.Now
                    Session("hora_turno_calendario") = 0
                    LlenaControles()
                    AutoCargaTaller()
                    PantallaInicial()
                    BtnVerturno.Enabled = False
                    Session("Turno tomado") = "0"
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            Else
                If Session("user") Is Nothing Then
                    Session("error") = "Debe de iniciar sesión en el sistema"
                    Response.Redirect("login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: CONTROLA CLICK EN CADA ITEM DEL CALENDARIO PARA BORRA TURNO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub imgdia_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgdia1hora1.Click, imgdia1hora2.Click, imgdia1hora3.Click, imgdia1hora4.Click, imgdia1hora5.Click, imgdia1hora6.Click, imgdia1hora7.Click, imgdia1hora8.Click, _
                                                                                                           imgdia2hora1.Click, imgdia2hora2.Click, imgdia2hora3.Click, imgdia2hora4.Click, imgdia2hora5.Click, imgdia2hora6.Click, imgdia2hora7.Click, imgdia2hora8.Click, _
                                                                                                           imgdia3hora1.Click, imgdia3hora2.Click, imgdia3hora3.Click, imgdia3hora4.Click, imgdia3hora5.Click, imgdia3hora6.Click, imgdia3hora7.Click, imgdia3hora8.Click, _
                                                                                                           imgdia4hora1.Click, imgdia4hora2.Click, imgdia4hora3.Click, imgdia4hora4.Click, imgdia4hora5.Click, imgdia4hora6.Click, imgdia4hora7.Click, imgdia4hora8.Click, _
                                                                                                           imgdia5hora1.Click, imgdia5hora2.Click, imgdia5hora3.Click, imgdia5hora4.Click, imgdia5hora5.Click, imgdia5hora6.Click, imgdia5hora7.Click, imgdia5hora8.Click, _
                                                                                                           imgdia6hora1.Click, imgdia6hora2.Click, imgdia6hora3.Click, imgdia6hora4.Click, imgdia6hora5.Click, imgdia6hora6.Click, imgdia6hora7.Click, imgdia6hora8.Click, _
                                                                                                           imgdia7hora1.Click, imgdia7hora2.Click, imgdia7hora3.Click, imgdia7hora4.Click, imgdia7hora5.Click, imgdia7hora6.Click, imgdia7hora7.Click, imgdia7hora8.Click
        Try
            Dim hora As String = "00:00"
            Dim dia As Integer
            If sender.ID = "imgdia1hora1" Then
                dia = 1
                hora = "08:00"
            ElseIf sender.ID = "imgdia1hora2" Then
                dia = 1
                hora = "09:00"
            ElseIf sender.ID = "imgdia1hora3" Then
                dia = 1
                hora = "10:00"
            ElseIf sender.ID = "imgdia1hora4" Then
                dia = 1
                hora = "11:00"
            ElseIf sender.ID = "imgdia1hora5" Then
                dia = 1
                hora = "12:00"
            ElseIf sender.ID = "imgdia1hora6" Then
                dia = 1
                hora = "13:00"
            ElseIf sender.ID = "imgdia1hora7" Then
                dia = 1
                hora = "14:00"
            ElseIf sender.ID = "imgdia1hora8" Then
                dia = 1
                hora = "15:00"
            ElseIf sender.ID = "imgdia2hora1" Then
                dia = 2
                hora = "08:00"
            ElseIf sender.ID = "imgdia2hora2" Then
                dia = 2
                hora = "09:00"
            ElseIf sender.ID = "imgdia2hora3" Then
                dia = 2
                hora = "10:00"
            ElseIf sender.ID = "imgdia2hora4" Then
                dia = 2
                hora = "11:00"
            ElseIf sender.ID = "imgdia2hora5" Then
                dia = 2
                hora = "12:00"
            ElseIf sender.ID = "imgdia2hora6" Then
                dia = 2
                hora = "13:00"
            ElseIf sender.ID = "imgdia2hora7" Then
                dia = 2
                hora = "14:00"
            ElseIf sender.ID = "imgdia2hora8" Then
                dia = 2
                hora = "15:00"
            ElseIf sender.ID = "imgdia3hora1" Then
                dia = 3
                hora = "08:00"
            ElseIf sender.ID = "imgdia3hora2" Then
                dia = 3
                hora = "09:00"
            ElseIf sender.ID = "imgdia3hora3" Then
                dia = 3
                hora = "10:00"
            ElseIf sender.ID = "imgdia3hora4" Then
                dia = 3
                hora = "11:00"
            ElseIf sender.ID = "imgdia3hora5" Then
                dia = 3
                hora = "12:00"
            ElseIf sender.ID = "imgdia3hora6" Then
                dia = 3
                hora = "13:00"
            ElseIf sender.ID = "imgdia3hora7" Then
                dia = 3
                hora = "14:00"
            ElseIf sender.ID = "imgdia3hora8" Then
                dia = 3
                hora = "15:00"
            ElseIf sender.ID = "imgdia4hora1" Then
                dia = 4
                hora = "08:00"
            ElseIf sender.ID = "imgdia4hora2" Then
                dia = 4
                hora = "09:00"
            ElseIf sender.ID = "imgdia4hora3" Then
                dia = 4
                hora = "10:00"
            ElseIf sender.ID = "imgdia4hora4" Then
                dia = 4
                hora = "11:00"
            ElseIf sender.ID = "imgdia4hora5" Then
                dia = 4
                hora = "12:00"
            ElseIf sender.ID = "imgdia4hora6" Then
                dia = 4
                hora = "13:00"
            ElseIf sender.ID = "imgdia4hora7" Then
                dia = 4
                hora = "14:00"
            ElseIf sender.ID = "imgdia4hora8" Then
                dia = 4
                hora = "15:00"
            ElseIf sender.ID = "imgdia5hora1" Then
                dia = 5
                hora = "08:00"
            ElseIf sender.ID = "imgdia5hora2" Then
                dia = 5
                hora = "09:00"
            ElseIf sender.ID = "imgdia5hora3" Then
                dia = 5
                hora = "10:00"
            ElseIf sender.ID = "imgdia5hora4" Then
                dia = 5
                hora = "11:00"
            ElseIf sender.ID = "imgdia5hora5" Then
                dia = 5
                hora = "12:00"
            ElseIf sender.ID = "imgdia5hora6" Then
                dia = 5
                hora = "13:00"
            ElseIf sender.ID = "imgdia5hora7" Then
                dia = 5
                hora = "14:00"
            ElseIf sender.ID = "imgdia5hora8" Then
                dia = 5
                hora = "15:00"
            ElseIf sender.ID = "imgdia6hora1" Then
                dia = 6
                hora = "08:00"
            ElseIf sender.ID = "imgdia6hora2" Then
                dia = 6
                hora = "09:00"
            ElseIf sender.ID = "imgdia6hora3" Then
                dia = 6
                hora = "10:00"
            ElseIf sender.ID = "imgdia6hora4" Then
                dia = 6
                hora = "11:00"
            ElseIf sender.ID = "imgdia6hora5" Then
                dia = 6
                hora = "12:00"
            ElseIf sender.ID = "imgdia6hora6" Then
                dia = 6
                hora = "13:00"
            ElseIf sender.ID = "imgdia6hora7" Then
                dia = 6
                hora = "14:00"
            ElseIf sender.ID = "imgdia6hora8" Then
                dia = 6
                hora = "15:00"
            ElseIf sender.ID = "imgdia7hora1" Then
                dia = 7
                hora = "08:00"
            ElseIf sender.ID = "imgdia7hora2" Then
                dia = 7
                hora = "09:00"
            ElseIf sender.ID = "imgdia7hora3" Then
                dia = 7
                hora = "10:00"
            ElseIf sender.ID = "imgdia7hora4" Then
                dia = 7
                hora = "11:00"
            ElseIf sender.ID = "imgdia7hora5" Then
                dia = 7
                hora = "12:00"
            ElseIf sender.ID = "imgdia7hora6" Then
                dia = 7
                hora = "13:00"
            ElseIf sender.ID = "imgdia7hora7" Then
                dia = 7
                hora = "14:00"
            ElseIf sender.ID = "imgdia7hora8" Then
                dia = 7
                hora = "15:00"
            End If
            Session("dia") = dia
            Session("hora") = hora
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
            Session("fecha_turno_seleccionado") = fecha
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: CONTROLA CLICK EN CADA ITEM DEL CALENDARIO PARA GRABAR TURNO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lbldia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbldia1hora1.Click, lbldia1hora2.Click, lbldia1hora3.Click, lbldia1hora4.Click, lbldia1hora5.Click, lbldia1hora6.Click, lbldia1hora7.Click, lbldia1hora8.Click, _
                                                                                          lbldia2hora1.Click, lbldia2hora2.Click, lbldia2hora3.Click, lbldia2hora4.Click, lbldia2hora5.Click, lbldia2hora6.Click, lbldia2hora7.Click, lbldia2hora8.Click, _
                                                                                          lbldia3hora1.Click, lbldia3hora2.Click, lbldia3hora3.Click, lbldia3hora4.Click, lbldia3hora5.Click, lbldia3hora6.Click, lbldia3hora7.Click, lbldia3hora8.Click, _
                                                                                          lbldia4hora1.Click, lbldia4hora2.Click, lbldia4hora3.Click, lbldia4hora4.Click, lbldia4hora5.Click, lbldia4hora6.Click, lbldia4hora7.Click, lbldia4hora8.Click, _
                                                                                          lbldia5hora1.Click, lbldia5hora2.Click, lbldia5hora3.Click, lbldia5hora4.Click, lbldia5hora5.Click, lbldia5hora6.Click, lbldia5hora7.Click, lbldia5hora8.Click, _
                                                                                          lbldia6hora1.Click, lbldia6hora2.Click, lbldia6hora3.Click, lbldia6hora4.Click, lbldia6hora5.Click, lbldia6hora6.Click, lbldia6hora7.Click, lbldia6hora8.Click, _
                                                                                          lbldia7hora1.Click, lbldia7hora2.Click, lbldia7hora3.Click, lbldia7hora4.Click, lbldia7hora5.Click, lbldia7hora6.Click, lbldia7hora7.Click, lbldia7hora8.Click
        Try
            Dim hora As String = "00:00"
            Dim dia As Integer
            If sender.ID = "lbldia1hora1" Then
                dia = 1
                hora = "08:00"
            ElseIf sender.ID = "lbldia1hora2" Then
                dia = 1
                hora = "09:00"
            ElseIf sender.ID = "lbldia1hora3" Then
                dia = 1
                hora = "10:00"
            ElseIf sender.ID = "lbldia1hora4" Then
                dia = 1
                hora = "11:00"
            ElseIf sender.ID = "lbldia1hora5" Then
                dia = 1
                hora = "12:00"
            ElseIf sender.ID = "lbldia1hora6" Then
                dia = 1
                hora = "13:00"
            ElseIf sender.ID = "lbldia1hora7" Then
                dia = 1
                hora = "14:00"
            ElseIf sender.ID = "lbldia1hora8" Then
                dia = 1
                hora = "15:00"
            ElseIf sender.ID = "lbldia2hora1" Then
                dia = 2
                hora = "08:00"
            ElseIf sender.ID = "lbldia2hora2" Then
                dia = 2
                hora = "09:00"
            ElseIf sender.ID = "lbldia2hora3" Then
                dia = 2
                hora = "10:00"
            ElseIf sender.ID = "lbldia2hora4" Then
                dia = 2
                hora = "11:00"
            ElseIf sender.ID = "lbldia2hora5" Then
                dia = 2
                hora = "12:00"
            ElseIf sender.ID = "lbldia2hora6" Then
                dia = 2
                hora = "13:00"
            ElseIf sender.ID = "lbldia2hora7" Then
                dia = 2
                hora = "14:00"
            ElseIf sender.ID = "lbldia2hora8" Then
                dia = 2
                hora = "15:00"
            ElseIf sender.ID = "lbldia3hora1" Then
                dia = 3
                hora = "08:00"
            ElseIf sender.ID = "lbldia3hora2" Then
                dia = 3
                hora = "09:00"
            ElseIf sender.ID = "lbldia3hora3" Then
                dia = 3
                hora = "10:00"
            ElseIf sender.ID = "lbldia3hora4" Then
                dia = 3
                hora = "11:00"
            ElseIf sender.ID = "lbldia3hora5" Then
                dia = 3
                hora = "12:00"
            ElseIf sender.ID = "lbldia3hora6" Then
                dia = 3
                hora = "13:00"
            ElseIf sender.ID = "lbldia3hora7" Then
                dia = 3
                hora = "14:00"
            ElseIf sender.ID = "lbldia3hora8" Then
                dia = 3
                hora = "15:00"
            ElseIf sender.ID = "lbldia4hora1" Then
                dia = 4
                hora = "08:00"
            ElseIf sender.ID = "lbldia4hora2" Then
                dia = 4
                hora = "09:00"
            ElseIf sender.ID = "lbldia4hora3" Then
                dia = 4
                hora = "10:00"
            ElseIf sender.ID = "lbldia4hora4" Then
                dia = 4
                hora = "11:00"
            ElseIf sender.ID = "lbldia4hora5" Then
                dia = 4
                hora = "12:00"
            ElseIf sender.ID = "lbldia4hora6" Then
                dia = 4
                hora = "13:00"
            ElseIf sender.ID = "lbldia4hora7" Then
                dia = 4
                hora = "14:00"
            ElseIf sender.ID = "lbldia4hora8" Then
                dia = 4
                hora = "15:00"
            ElseIf sender.ID = "lbldia5hora1" Then
                dia = 5
                hora = "08:00"
            ElseIf sender.ID = "lbldia5hora2" Then
                dia = 5
                hora = "09:00"
            ElseIf sender.ID = "lbldia5hora3" Then
                dia = 5
                hora = "10:00"
            ElseIf sender.ID = "lbldia5hora4" Then
                dia = 5
                hora = "11:00"
            ElseIf sender.ID = "lbldia5hora5" Then
                dia = 5
                hora = "12:00"
            ElseIf sender.ID = "lbldia5hora6" Then
                dia = 5
                hora = "13:00"
            ElseIf sender.ID = "lbldia5hora7" Then
                dia = 5
                hora = "14:00"
            ElseIf sender.ID = "lbldia5hora8" Then
                dia = 5
                hora = "15:00"
            ElseIf sender.ID = "lbldia6hora1" Then
                dia = 6
                hora = "08:00"
            ElseIf sender.ID = "lbldia6hora2" Then
                dia = 6
                hora = "09:00"
            ElseIf sender.ID = "lbldia6hora3" Then
                dia = 6
                hora = "10:00"
            ElseIf sender.ID = "lbldia6hora4" Then
                dia = 6
                hora = "11:00"
            ElseIf sender.ID = "lbldia6hora5" Then
                dia = 6
                hora = "12:00"
            ElseIf sender.ID = "lbldia6hora6" Then
                dia = 6
                hora = "13:00"
            ElseIf sender.ID = "lbldia6hora7" Then
                dia = 6
                hora = "14:00"
            ElseIf sender.ID = "lbldia6hora8" Then
                dia = 6
                hora = "15:00"
            ElseIf sender.ID = "lbldia7hora1" Then
                dia = 7
                hora = "08:00"
            ElseIf sender.ID = "lbldia7hora2" Then
                dia = 7
                hora = "09:00"
            ElseIf sender.ID = "lbldia7hora3" Then
                dia = 7
                hora = "10:00"
            ElseIf sender.ID = "lbldia7hora4" Then
                dia = 7
                hora = "11:00"
            ElseIf sender.ID = "lbldia7hora5" Then
                dia = 7
                hora = "12:00"
            ElseIf sender.ID = "lbldia7hora6" Then
                dia = 7
                hora = "13:00"
            ElseIf sender.ID = "lbldia7hora7" Then
                dia = 7
                hora = "14:00"
            ElseIf sender.ID = "lbldia7hora8" Then
                dia = 7
                hora = "15:00"
            End If
            Session("dia") = dia
            Session("hora") = hora
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
            Dim idTaller As Integer = CInt(Session("id_taller_turno"))
            Session("fecha_turno_seleccionado") = fecha
            If Session("Turno tomado") = "1" Then
                ConfigMsg("Ya posee un turno seleccionado", 2)
            Else
                ConfigDialog("Está seguro de solicitar el turno?")
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 06/08/2014
    ''' DESCR: PERMITE CARGAR TURNOS DE OTRO TALLER
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnVerturno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVerturno.Click
        Dim fecha_turno As Date = Session("fecha_turno_seleccionado")
        Dim fecha_obtenida As Date = Session("fecha_turno_calendario")
        Dim texto_envio As String = String.Format("{0}/{1}/{2} {3}" _
                                                  , fecha_turno.Day _
                                                  , DevuelveMes(fecha_turno) _
                                                  , fecha_turno.Year _
                                                  , Session("hora_turno_seleccionado"))

        Dim script As String = "function f(){returnToParent('" & texto_envio & "'); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 08/08/2014
    ''' DESCR: CONTROL PARA PODER RETROCEDER EL CALENDARIO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCalendarioanterior_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCalendarioanterior.Click
        Try
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Session("fecha_turno_calendario") = DateAdd(DateInterval.Day, -7, fecha)
            PantallaInicial()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 09/08/2014
    ''' DESCR: CONTROL PARA PODER AVANZAR EL CALENDARIO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCalendariosiguiente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCalendariosiguiente.Click
        Try
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Session("fecha_turno_calendario") = DateAdd(DateInterval.Day, 7, fecha)
            PantallaInicial()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 05/08/2015
    ''' DESCR: EVENTO PARA DETECTAR EL CLICK DEL BOTON SI EN LA VENTANA DE DIALOGO
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RntdialogRbtSiClick()
        Try
            Dim dia As Integer = CInt(Session("dia"))
            Dim hora As String = Session("hora").ToString
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
            AsignaTurnoControl(dia, hora, True, "Turno seleccionado", _
                                                              IIf(dia = Date.Now.Day, False, True), False, _
                                                              IIf(dia = Date.Now.Day, True, False), hora)
            Session("Turno tomado") = "1"
            BtnVerturno.Enabled = True
            Session("hora_turno_seleccionado") = hora
            Session("id_taller_turno") = cmbtaller.SelectedValue
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 05/08/2015
    ''' DESCR: EVENTO PARA DETECTAR EL CLICK DEL BOTON NO EN LA VENTANA DE DIALOGO
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RntdialogRbtNoClick()
        Try
            FocoTurnoControl(CInt(Session("dia")), Session("hora").ToString, False)
            Session("atencion_turno") = ""
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 12/08/2014
    ''' DESCR: AUTO CARGA DATOS DEL TALLER QUE CORRESPONDA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AutoCargaTaller()
        Try
            Dim dtcDatosTaller As New System.Data.DataSet
            dtcDatosTaller = VehiculoTurnoAdapter.ConsultaDatosTaller(19, Session("user_id").ToString)
            If dtcDatosTaller.Tables(0).Rows.Count > 0 Then
                cmbtaller.SelectedValue = dtcDatosTaller.Tables(0).Rows(0).Item("CODIGO")
                Session("id_taller_turno") = dtcDatosTaller.Tables(0).Rows(0).Item("CODIGO")
                Session("hora_taller_turno") = dtcDatosTaller.Tables(0).Rows(0).Item("HORA_LIMITE")
                Session("hora_taller_turno_fs") = dtcDatosTaller.Tables(0).Rows(0).Item("HORA_LIMITE_FS")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos generales"

#Region "Llenar controles desde base"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 30/07/2014
    ''' DESCR: LLENA LOS COMBOS DEL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LlenaControles()
        Try
            'Dim dtcVehTipoturno, dtcVehProducto, dtcVehCiudad As New System.Data.DataSet
            Dim dtcVehTipoturno, dtcVehProducto As New System.Data.DataSet
            dtcVehProducto = VehiculoTurnoAdapter.ConsultaControles(5, 0)
            Me.cmbtaller.DataSource = dtcVehProducto
            Me.cmbtaller.DataTextField = "DESCRIPCION"
            Me.cmbtaller.DataValueField = "CODIGO"
            Me.cmbtaller.DataBind()
            dtcVehTipoturno = VehiculoTurnoAdapter.ConsultaControles(2, 0)
            Me.CmbTipoturno.DataSource = dtcVehTipoturno
            Me.CmbTipoturno.DataTextField = "DESCRIPCION"
            Me.CmbTipoturno.DataValueField = "CODIGO"
            Me.CmbTipoturno.DataBind()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Estados Controles"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: ESTADO INICIAL DE CONTROLES
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PantallaInicial()
        Try
            SetDiasCalendario(Convert.ToDateTime(Session("fecha_turno_calendario")))
            Me.lblfechacalendario.Text = DevuelveFecha(Convert.ToDateTime(Session("fecha_turno_calendario")))
            EstadosEncerar(False, "#E9E9E9")
            RecargarControlFecha(CInt(cmbtaller.SelectedValue), 0, 0)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 06/08/2014
    ''' DESCR: RECARGA LOS DATOS DEL CONTROL FECHA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RecargarControlFecha(ByVal idTaller As Integer, ByVal idVehiculo As Int64, ByVal cliente As String)
        Try
            EstadosEncerar(False, "#E9E9E9")
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            SetDiasCalendario(Convert.ToDateTime(Session("fecha_turno_calendario")))
            Me.lblfechacalendario.Text = DevuelveFecha(fecha)
            Session("id_taller_turno") = idTaller
            'Session("hora_taller_turno") = 14
            'Session("hora_taller_turno_fs") = 12
            EstadosDiasCalendario(idTaller, fecha)
            EstadosDiasCalendarioTurnos(idTaller, fecha)
            'EstadosDiasCalendarioTurnosPropios(idVehiculo, idTaller, fecha)
            'EstadosDiasCalendarioTurnosPropiosotros(idVehiculo, idTaller, fecha, cliente)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: ENVIO DE MENSAJES A PANTALLA
    ''' </summary>
    ''' <param name="custommsg"></param>
    ''' <param name="tipo"></param>
    ''' <remarks></remarks>
    Private Sub ConfigMsg(ByVal custommsg As String, ByVal tipo As Integer)
        Try
            If tipo = 1 Then
                rntmensaje.Text = custommsg
                rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
                rntmensaje.TitleIcon = "info"
                rntmensaje.ContentIcon = "info"
                rntmensaje.ShowSound = "info"
                rntmensaje.AutoCloseDelay = "1700"
                rntmensaje.Width = 400
                rntmensaje.Height = 100
                rntmensaje.Show()
            ElseIf tipo = 2 Then
                rntmensaje.Text = custommsg
                rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
                rntmensaje.TitleIcon = "warning"
                rntmensaje.ContentIcon = "warning"
                rntmensaje.ShowSound = "warning"
                rntmensaje.AutoCloseDelay = "1700"
                rntmensaje.Width = 400
                rntmensaje.Height = 100
                rntmensaje.Show()
            ElseIf tipo = 3 Then
                rntmensaje.Text = custommsg
                rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
                'rntmensaje.TitleIcon = "delete"
                'rntmensaje.ContentIcon = "delete"
                'rntmensaje.ShowSound = "delete"
                rntmensaje.TitleIcon = "warning"
                rntmensaje.ContentIcon = "warning"
                rntmensaje.ShowSound = "warning"
                rntmensaje.AutoCloseDelay = "1700"
                rntmensaje.Width = 400
                rntmensaje.Height = 100
                rntmensaje.Show()
            ElseIf tipo = 4 Then
                rntmensaje.Text = custommsg
                rntmensaje.Title = "Mensaje de la Aplicación HunterOnline"
                'rntmensaje.TitleIcon = "deny"
                'rntmensaje.ContentIcon = "deny"
                'rntmensaje.ShowSound = "deny"
                rntmensaje.TitleIcon = "warning"
                rntmensaje.ContentIcon = "warning"
                rntmensaje.ShowSound = "warning"
                rntmensaje.AutoCloseDelay = "1700"
                rntmensaje.Width = 400
                rntmensaje.Height = 100
                rntmensaje.Show()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 05/08/2015
    ''' DESCR: ENVIO DE MENSAJES A PANTALLA
    ''' </summary>
    ''' <param name="custommsg"></param>
    ''' <remarks></remarks>
    Private Sub ConfigDialog(ByVal custommsg As String)
        Try
            Me.rntdialog_lbl.Text = custommsg
            rntdialog.Title = "Mensaje de la Aplicación HunterOnline"
            rntdialog.TitleIcon = "info"
            rntdialog.ContentIcon = "info"
            rntdialog.ShowSound = "info"
            rntdialog.Width = 400
            rntdialog.Height = 100
            rntdialog.Show()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 08/08/2014
    ''' DESCR: DEVUELVE CADENA DE FECHA
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DevuelveFecha(ByVal fecha As DateTime) As String
        DevuelveFecha = ""
        Try
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            Dim fechaIni As DateTime = DateAdd(DateInterval.Day, 1, fechaAnterior)
            Dim fechaFin As DateTime = DateAdd(DateInterval.Day, 7, fechaAnterior)
            DevuelveFecha = DevuelveMes(fechaIni) & " " & Day(fechaIni) & " de " & Year(fechaIni) & _
                             " - " & DevuelveMes(fechaFin) & " " & Day(fechaFin) & " de " & Year(fechaFin)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 08/08/2014
    ''' DESCR: DEVUELVE MES EN LETRAS
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DevuelveMes(ByVal fecha As DateTime) As String
        DevuelveMes = ""
        Try
            Select Case fecha.Month
                Case 1
                    DevuelveMes = "Enero"
                Case 2
                    DevuelveMes = "Febrero"
                Case 3
                    DevuelveMes = "Marzo"
                Case 4
                    DevuelveMes = "Abril"
                Case 5
                    DevuelveMes = "Mayo"
                Case 6
                    DevuelveMes = "Junio"
                Case 7
                    DevuelveMes = "Julio"
                Case 8
                    DevuelveMes = "Agosto"
                Case 9
                    DevuelveMes = "Septiembre"
                Case 10
                    DevuelveMes = "Octubre"
                Case 11
                    DevuelveMes = "Noviembre"
                Case 12
                    DevuelveMes = "Diciembre"
                Case Else
                    DevuelveMes = ""
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    '    ''' <summary>
    '    ''' AUTOR: FELIX ONTANEDA
    '    ''' FECHA: 11/08/2014
    '    ''' DESCR: LIMPIA CONTROLES
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub LimpiaControles()
    '        Try
    '            divboton.Visible = False
    '            txtcontacto.Text = ""
    '            txtubicacion.Text = ""
    '            txttelefonocontacto.Text = ""
    '            txtciudad.Text = ""
    '            txtcomentario.Text = ""
    '            CmbTipoturno.SelectedIndex = 0
    '            Dim prjTree As RadTreeView = TryCast(CmbProducto_servicio.Items(0).FindControl("tvwservicio"), RadTreeView)
    '            prjTree.UncheckAllNodes()
    '            CmbProducto_servicio.Text = "Seleccionar Producto/Servicio"
    '            ControlesTallerFuera(False)
    '            'activa_tracking(False, 1, 1, 1900)
    '        Catch ex As Exception
    '            ExceptionHandler.Captura_Error(ex)
    '        End Try
    '    End Sub

    '    ''' <summary>
    '    ''' AUTOR: FELIX ONTANEDA
    '    ''' FECHA: 12/08/2014
    '    ''' DESCR: CARGA DATOS DEL TURNO QUE TENGA
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Sub CargaDatosTurno()
    '        Try
    '            Dim dtcDatosTurno As New System.Data.DataSet
    '            dtcDatosTurno = VehiculoTurnoAdapter.ConsultaDatosTurno(12, Convert.ToInt64(Session("id_vehiculo_turno")), CInt(Session("atencion_turno")))
    '            If dtcDatosTurno.Tables(0).Rows.Count > 0 Then
    '                If dtcDatosTurno.Tables(0).Rows(0).Item("TIPO_TALLER") = "1" Then
    '                    ControlesTallerFuera(False)
    '                ElseIf dtcDatosTurno.Tables(0).Rows(0).Item("TIPO_TALLER") = "2" Then
    '                    ControlesTallerFuera(True)
    '                End If
    '                SetSelectedNodes(Trim(dtcDatosTurno.Tables(0).Rows(0).Item("GRUPO_PRODUCTO").ToString))
    '                CmbTipoturno.SelectedValue = Trim(dtcDatosTurno.Tables(0).Rows(0).Item("TIPO_TALLER").ToString)
    '                Txttalleres.Text = dtcDatosTurno.Tables(0).Rows(0).Item("PUNTO_VENTA")
    '                Session("id_taller_turno") = dtcDatosTurno.Tables(0).Rows(0).Item("PUNTO_VENTA_ID")
    '                txtubicacion.Text = dtcDatosTurno.Tables(0).Rows(0).Item("UBICACION")
    '                txtcontacto.Text = dtcDatosTurno.Tables(0).Rows(0).Item("CONTACTO")
    '                txttelefonocontacto.Text = dtcDatosTurno.Tables(0).Rows(0).Item("CONTACTO_TELEFONO")
    '                txtciudad.Text = dtcDatosTurno.Tables(0).Rows(0).Item("UBICACION_CIUDAD")
    '                txtcomentario.Text = dtcDatosTurno.Tables(0).Rows(0).Item("COMENTARIO")
    '                divboton.Visible = True
    '                Me.BtnVerturno.Text = "Actualizar"
    '            End If
    '        Catch ex As Exception
    '            ExceptionHandler.Captura_Error(ex)
    '        End Try
    '    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 20/08/2014
    ''' DESCR: SETEA AJAX A BOTONES CREADOS
    ''' </summary>
    ''' <param name="boton"></param>
    ''' <remarks></remarks>
    Private Sub ImplementaAjax(ByVal boton As Button)
        Try
            Dim ram As RadAjaxManager = Me.RadAjaxManager1
            ram.AjaxSettings.AddAjaxSetting(boton, CmbTipoturno)
            ram.AjaxSettings.AddAjaxSetting(boton, divtallerlabel)
            ram.AjaxSettings.AddAjaxSetting(boton, divtallertext)
            ram.AjaxSettings.AddAjaxSetting(boton, DivCalendario)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/11/2014
    ''' DESCR: CREA IMAGEN EN FORMATO PNG
    ''' </summary>
    ''' <param name="hora"></param>
    ''' <param name="colorfondo"></param>
    ''' <param name="colortexto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreaPngHora(ByVal hora As String, ByVal colorfondo As String, ByVal colortexto As String) As String
        Dim rutaWeb As String = "https://www.hunteronline.com.ec/imgcotizadorweb/HoraGeneradaExtranet/" & hora.Replace(":", "") & ".png"
        'Dim rutaPc As String = "C:\IMGCOTIZADORWEB\HoraGeneradaExtranet\" & hora.Replace(":", "") & ".png"
        Dim rutaPc As String = "D:\Compartidos\IMGCOTIZADORWEB\HoraGeneradaExtranet\" & hora.Replace(":", "") & ".png"
        Try
            If Not File.Exists(rutaPc) Then
                Const FontSize As Integer = 13
                Const Width As Integer = 39
                Const Height As Integer = 30
                Dim rectangleFont As New Font("DS-Digital", FontSize, FontStyle.Bold)
                Dim bitmap As New Bitmap(Width, Height, PixelFormat.Format24bppRgb)
                Dim g As Graphics = Graphics.FromImage(bitmap)
                Dim backgroundColor As Color = System.Drawing.ColorTranslator.FromHtml(colorfondo)
                Dim colorText As Brush = New SolidBrush(System.Drawing.ColorTranslator.FromHtml(colortexto))
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.Clear(backgroundColor)
                g.DrawString(hora, rectangleFont, colorText, New PointF(-3, 7))
                bitmap.Save(rutaPc, ImageFormat.Png)
                g.Dispose()
                bitmap.Dispose()
                Response.Flush()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return rutaWeb
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 05/08/2015
    ''' DESCR: DEVUELVE STRING DE FECHA EN FORMATO DD/MMM/YYYY
    ''' </summary>
    ''' <param name="dia"></param>
    ''' <param name="mes"></param>
    ''' <param name="anio"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DevuelveFormatoFecha(dia As Integer, mes As Integer, anio As Integer, hora As String) As String
        DevuelveFormatoFecha = ""
        Dim strDia As String = IIf(dia < 10, "0", "") & dia
        Dim strMes As String = ""
        Select Case mes
            Case 1
                strMes = "Ene"
            Case 2
                strMes = "Feb"
            Case 3
                strMes = "Mar"
            Case 4
                strMes = "Abr"
            Case 5
                strMes = "May"
            Case 6
                strMes = "Jun"
            Case 7
                strMes = "Jul"
            Case 8
                strMes = "Ago"
            Case 9
                strMes = "Sep"
            Case 10
                strMes = "Oct"
            Case 11
                strMes = "Nov"
            Case 12
                strMes = "Dic"
            Case Else
                strMes = ""
        End Select
        DevuelveFormatoFecha = strDia & "/" & strMes & "/" & anio & " | " & hora
        Return DevuelveFormatoFecha
    End Function

#End Region

#Region "Calendario"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: HABILITA O DESHABILITA LOS DIAS DEL CALENDARIO SEGUN 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosDiasCalendario(ByVal tallerId As Integer, ByVal fecha As DateTime)
        Try
            Dim dtcDiasCalendario As New System.Data.DataSet
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            Dim estado As Boolean
            Dim color = "", hora, diaTabla, mesTabla, anioTabla, tooltiptext As String
            Dim dia As Integer = 1
            Dim estadoRegistro As String = "1"
            dtcDiasCalendario = VehiculoTurnoAdapter.ConsultaCalendario(6, fechaAnterior.Day, fechaAnterior.Month, fechaAnterior.Year, 0, tallerId, 0)
            If dtcDiasCalendario.Tables(0).Rows.Count > 0 Then
                diaTabla = dtcDiasCalendario.Tables(0).Rows(0).Item("DIA").ToString
                mesTabla = dtcDiasCalendario.Tables(0).Rows(0).Item("MES").ToString
                anioTabla = dtcDiasCalendario.Tables(0).Rows(0).Item("ANIO").ToString
                For i As Integer = 0 To dtcDiasCalendario.Tables(0).Rows.Count - 1
                    If diaTabla <> dtcDiasCalendario.Tables(0).Rows(i).Item("DIA").ToString Then
                        diaTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("DIA").ToString
                        mesTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("MES").ToString
                        anioTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("ANIO").ToString
                        dia += 1
                    End If
                    hora = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA").ToString
                    estadoRegistro = dtcDiasCalendario.Tables(0).Rows(i).Item("ESTADO_ID").ToString
                    Dim fechaAuxiliar As Date = diaTabla & "/" & mesTabla & "/" & anioTabla
                    If fechaAuxiliar.DayOfWeek = DayOfWeek.Saturday Or fechaAuxiliar.DayOfWeek = DayOfWeek.Sunday Then
                        If CInt(hora.Substring(0, 2)) > CInt(Session("hora_taller_turno_fs").ToString) And estadoRegistro = "1" Then
                            estadoRegistro = "2"
                        End If
                    Else
                        If CInt(hora.Substring(0, 2)) > CInt(Session("hora_taller_turno").ToString) And estadoRegistro = "1" Then
                            estadoRegistro = "2"
                        End If
                    End If
                    If estadoRegistro = "1" Then
                        estado = True
                        color = "#FFFFFF"
                        tooltiptext = "Libre"
                        EstadosPorDia(estado, dia, color, hora, tooltiptext)
                    ElseIf estadoRegistro = "2" Then
                        AsignaTurnoControl(dia, hora, True, "No Disponible", False, False, False, "00:00")
                    ElseIf estadoRegistro = "3" Then
                        AsignaTurnoControl(dia, hora, True, "Ocupado", False, False, False, "00:00")
                    End If
                Next
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: LLENA LOS DIAS A MOSTRAR EN EL CALENDARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDiasCalendario(ByVal fecha As DateTime)
        Try
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            Me.lbldia1.Text = Day(DateAdd(DateInterval.Day, 1, fechaAnterior))
            Me.lbldia2.Text = Day(DateAdd(DateInterval.Day, 2, fechaAnterior))
            Me.lbldia3.Text = Day(DateAdd(DateInterval.Day, 3, fechaAnterior))
            Me.lbldia4.Text = Day(DateAdd(DateInterval.Day, 4, fechaAnterior))
            Me.lbldia5.Text = Day(DateAdd(DateInterval.Day, 5, fechaAnterior))
            Me.lbldia6.Text = Day(DateAdd(DateInterval.Day, 6, fechaAnterior))
            Me.lbldia7.Text = Day(DateAdd(DateInterval.Day, 7, fechaAnterior))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: HABILITA O DESHABILITA LOS DIAS DEL CALENDARIO SEGUN TABLA TURNOS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosDiasCalendarioTurnos(ByVal tallerId As Integer, ByVal fecha As DateTime)
        Try
            Dim dtcDiasCalendario As New System.Data.DataSet
            Dim hora, diaTabla, mesTabla, anioTabla As String
            Dim dia = 1, totalTurnos, capacidad, horanormal, capacidadfs, horafs As Integer
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            dtcDiasCalendario = VehiculoTurnoAdapter.ConsultaCalendario(7, fechaAnterior.Day, fechaAnterior.Month, fechaAnterior.Year, 0, tallerId, 0)
            For i As Integer = 0 To dtcDiasCalendario.Tables(0).Rows.Count - 1
                diaTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("DIA").ToString
                mesTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("MES").ToString
                anioTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("ANIO").ToString
                totalTurnos = dtcDiasCalendario.Tables(0).Rows(i).Item("TOTAL_TURNOS").ToString
                capacidad = dtcDiasCalendario.Tables(0).Rows(i).Item("CAPACIDAD").ToString
                capacidadfs = dtcDiasCalendario.Tables(0).Rows(i).Item("CAPACIDAD_FS").ToString
                hora = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA").ToString
                horanormal = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA_NORMAL").ToString
                horafs = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA_FS").ToString
                Dim maximoXHora As Integer = capacidad / horanormal
                Dim maximoXHoraFs As Integer = capacidadfs / horafs
                Dim fechaAuxiliar As Date = diaTabla & "/" & mesTabla & "/" & anioTabla
                If Convert.ToString(fechaAnterior.Day + 1) = diaTabla Then
                    dia = 1
                ElseIf Convert.ToString(fechaAnterior.Day + 2) = diaTabla Then
                    dia = 2
                ElseIf Convert.ToString(fechaAnterior.Day + 3) = diaTabla Then
                    dia = 3
                ElseIf Convert.ToString(fechaAnterior.Day + 4) = diaTabla Then
                    dia = 4
                ElseIf Convert.ToString(fechaAnterior.Day + 5) = diaTabla Then
                    dia = 5
                ElseIf Convert.ToString(fechaAnterior.Day + 6) = diaTabla Then
                    dia = 6
                ElseIf Convert.ToString(fechaAnterior.Day + 7) = diaTabla Then
                    dia = 7
                End If
                If fechaAuxiliar > Date.Now Then
                    If fechaAuxiliar.DayOfWeek = DayOfWeek.Saturday Or fechaAuxiliar.DayOfWeek = DayOfWeek.Sunday Then
                        If totalTurnos < maximoXHoraFs Then
                            EstadosPorDia(True, dia, "#FFFFFF", hora, "Libre")
                        Else
                            AsignaTurnoControl(dia, hora, True, "Ocupado", False, False, False, hora)
                        End If
                    Else
                        If totalTurnos < maximoXHora Then
                            EstadosPorDia(True, dia, "#FFFFFF", hora, "Libre")
                        Else
                            AsignaTurnoControl(dia, hora, True, "Ocupado", False, False, False, hora)
                        End If
                    End If
                Else
                    AsignaTurnoControl(dia, hora, True, "Ocupado", False, False, False, "00:00")
                End If
                'If total_turnos = -1 Then
                '    asigna_turno_control(dia, hora, True, "Ocupado", False, False, False, "00:00")
                'ElseIf total_turnos >= 6 Then
                '    'estados_por_dia(False, dia, "#E9E9E9", hora, "Ocupado")
                '    asigna_turno_control(dia, hora, True, "Ocupado", False, False, False, hora)
                'Else
                '    estados_por_dia(True, dia, "#FFFFFF", hora, "Libre")
                'End If
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: HABILITA O DESHABILITA LOS DIAS DEL CALENDARIO SEGUN TABLA TURNOS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosDiasCalendarioTurnosPropios(ByVal idVehiculo As Int64, ByVal tallerId As Integer, ByVal fecha As DateTime)
        Try
            Dim dtcDiasCalendario As New System.Data.DataSet
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            dtcDiasCalendario = VehiculoTurnoAdapter.ConsultaCalendario(8, fechaAnterior.Day, fechaAnterior.Month, fechaAnterior.Year, idVehiculo, tallerId, 0)
            Dim hora, diaTabla, fechaTurno, taller, ciudad, placa, trabajos, tallercodigo, horaReal, orden As String
            Dim dia = 1, turnoId As Integer
            Session("atencion_turno") = 0
            For i As Integer = 0 To dtcDiasCalendario.Tables(0).Rows.Count - 1
                hora = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA").ToString
                diaTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("DIA").ToString
                turnoId = dtcDiasCalendario.Tables(0).Rows(i).Item("ATENCION_TURNO_ID").ToString
                fechaTurno = Convert.ToDateTime(dtcDiasCalendario.Tables(0).Rows(i).Item("FECHA_ATENCION")).ToString("dd/MMM/yyyy")
                ciudad = dtcDiasCalendario.Tables(0).Rows(i).Item("CIUDAD").ToString
                tallercodigo = dtcDiasCalendario.Tables(0).Rows(i).Item("PUNTO_VENTA_ID").ToString
                taller = dtcDiasCalendario.Tables(0).Rows(i).Item("PUNTO_VENTA").ToString
                placa = dtcDiasCalendario.Tables(0).Rows(i).Item("PLACA").ToString
                trabajos = dtcDiasCalendario.Tables(0).Rows(i).Item("TRABAJOS").ToString
                horaReal = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA_REAL").ToString
                orden = dtcDiasCalendario.Tables(0).Rows(i).Item("ORDEN_SERVICIO").ToString
                Session("atencion_turno") = turnoId
                If Convert.ToString(DateAdd(DateInterval.Day, 1, fechaAnterior).Day) = diaTabla Then
                    dia = 1
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 2, fechaAnterior).Day) = diaTabla Then
                    dia = 2
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 3, fechaAnterior).Day) = diaTabla Then
                    dia = 3
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 4, fechaAnterior).Day) = diaTabla Then
                    dia = 4
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 5, fechaAnterior).Day) = diaTabla Then
                    dia = 5
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 6, fechaAnterior).Day) = diaTabla Then
                    dia = 6
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 7, fechaAnterior).Day) = diaTabla Then
                    dia = 7
                End If
                AsignaTurnoControl(dia, hora, True, String.Format("Turno del vehículo Seleccionado,{0},{3},{1},{2} {5},{4},{6}", taller, ciudad, fechaTurno, placa, trabajos, horaReal, orden), _
                                                                    IIf(CInt(diaTabla) = Date.Now.Day, False, True), False, _
                                                                    IIf(CInt(diaTabla) = Date.Now.Day, True, False), horaReal)
                If Convert.ToDateTime(fechaTurno).Day = Date.Now.Day _
                    And Convert.ToDateTime(fechaTurno).Month = Date.Now.Month _
                    And Convert.ToDateTime(fechaTurno).Year = Date.Now.Year _
                    And (tallercodigo <> 46 And tallercodigo <> 5000 And tallercodigo <> 1702 And tallercodigo <> 25) Then
                    'activa_tracking(True, Convert.ToDateTime(fecha_turno).Day, Convert.ToDateTime(fecha_turno).Month, Convert.ToDateTime(fecha_turno).Year)
                End If
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 12/08/2014
    ''' DESCR: HABILITA O DESHABILITA LOS DIAS DEL CALENDARIO SEGUN TABLA TURNOS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosDiasCalendarioTurnosPropiosotros(ByVal idVehiculo As Int64, ByVal tallerId As Integer, ByVal fecha As DateTime, ByVal cliente As String)
        Try
            Dim dtcDiasCalendario As New System.Data.DataSet
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            dtcDiasCalendario = VehiculoTurnoAdapter.ConsultaCalendario(15, fechaAnterior.Day, fechaAnterior.Month, fechaAnterior.Year, idVehiculo, tallerId, cliente)
            Dim hora, diaTabla, fechaTurno, taller, ciudad, placa, trabajos, horaReal, orden As String
            Dim dia = 1, turnoId As Integer
            For i As Integer = 0 To dtcDiasCalendario.Tables(0).Rows.Count - 1
                hora = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA").ToString
                diaTabla = dtcDiasCalendario.Tables(0).Rows(i).Item("DIA").ToString
                turnoId = dtcDiasCalendario.Tables(0).Rows(i).Item("ATENCION_TURNO_ID").ToString
                fechaTurno = Convert.ToDateTime(dtcDiasCalendario.Tables(0).Rows(i).Item("FECHA_ATENCION")).ToString("dd/MMM/yyyy")
                ciudad = dtcDiasCalendario.Tables(0).Rows(i).Item("CIUDAD").ToString
                taller = dtcDiasCalendario.Tables(0).Rows(i).Item("PUNTO_VENTA").ToString
                horaReal = dtcDiasCalendario.Tables(0).Rows(i).Item("HORA_REAL").ToString
                placa = dtcDiasCalendario.Tables(0).Rows(i).Item("PLACA").ToString
                trabajos = dtcDiasCalendario.Tables(0).Rows(i).Item("TRABAJOS").ToString
                orden = dtcDiasCalendario.Tables(0).Rows(i).Item("ORDEN_SERVICIO").ToString
                If Convert.ToString(DateAdd(DateInterval.Day, 1, fechaAnterior).Day) = diaTabla Then
                    dia = 1
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 2, fechaAnterior).Day) = diaTabla Then
                    dia = 2
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 3, fechaAnterior).Day) = diaTabla Then
                    dia = 3
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 4, fechaAnterior).Day) = diaTabla Then
                    dia = 4
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 5, fechaAnterior).Day) = diaTabla Then
                    dia = 5
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 6, fechaAnterior).Day) = diaTabla Then
                    dia = 6
                ElseIf Convert.ToString(DateAdd(DateInterval.Day, 7, fechaAnterior).Day) = diaTabla Then
                    dia = 7
                End If
                AsignaTurnoControl(dia, hora, True, String.Format("Turno de otro Vehículo,{0},{3},{1},{2} {5},{4},{6}", _
                                                                    taller, ciudad, fechaTurno, placa, trabajos, horaReal, orden), True, True, False, horaReal)
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: PINTA LAS CELDAS DEPENDIENDO SI EL TURNO ESTA DISPONIBLE O NO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosPorDia(ByVal estado As Boolean, ByVal dia As Integer, ByVal color As String, ByVal hora As String, ByVal tooltiptext As String)
        Try
            If dia = 1 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia1hora8, color, estado, tooltiptext)
                End If
            ElseIf dia = 2 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia2hora8, color, estado, tooltiptext)
                End If
            ElseIf dia = 3 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia3hora8, color, estado, tooltiptext)
                End If
            ElseIf dia = 4 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia4hora8, color, estado, tooltiptext)
                End If
            ElseIf dia = 5 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia5hora8, color, estado, tooltiptext)
                End If
            ElseIf dia = 6 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia6hora8, color, estado, tooltiptext)
                End If
            ElseIf dia = 7 Then
                If hora = "08:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora1, color, estado, tooltiptext)
                ElseIf hora = "09:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora2, color, estado, tooltiptext)
                ElseIf hora = "10:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora3, color, estado, tooltiptext)
                ElseIf hora = "11:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora4, color, estado, tooltiptext)
                ElseIf hora = "12:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora5, color, estado, tooltiptext)
                ElseIf hora = "13:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora6, color, estado, tooltiptext)
                ElseIf hora = "14:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora7, color, estado, tooltiptext)
                ElseIf hora = "15:00" Then
                    EstadosLabelControlCalendario(Me.lbldia7hora8, color, estado, tooltiptext)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: ENCERA EL PINTADO DE CELDAS DEL CALENDARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosEncerar(ByVal estado As Boolean, ByVal color As String)
        Try
            Me.imgdia1hora1.Visible = False
            Me.imgdia1hora2.Visible = False
            Me.imgdia1hora3.Visible = False
            Me.imgdia1hora4.Visible = False
            Me.imgdia1hora5.Visible = False
            Me.imgdia1hora6.Visible = False
            Me.imgdia1hora7.Visible = False
            Me.imgdia1hora8.Visible = False
            Me.imgdia2hora1.Visible = False
            Me.imgdia2hora2.Visible = False
            Me.imgdia2hora3.Visible = False
            Me.imgdia2hora4.Visible = False
            Me.imgdia2hora5.Visible = False
            Me.imgdia2hora6.Visible = False
            Me.imgdia2hora7.Visible = False
            Me.imgdia2hora8.Visible = False
            Me.imgdia3hora1.Visible = False
            Me.imgdia3hora2.Visible = False
            Me.imgdia3hora3.Visible = False
            Me.imgdia3hora4.Visible = False
            Me.imgdia3hora5.Visible = False
            Me.imgdia3hora6.Visible = False
            Me.imgdia3hora7.Visible = False
            Me.imgdia3hora8.Visible = False
            Me.imgdia4hora1.Visible = False
            Me.imgdia4hora2.Visible = False
            Me.imgdia4hora3.Visible = False
            Me.imgdia4hora4.Visible = False
            Me.imgdia4hora5.Visible = False
            Me.imgdia4hora6.Visible = False
            Me.imgdia4hora7.Visible = False
            Me.imgdia4hora8.Visible = False
            Me.imgdia5hora1.Visible = False
            Me.imgdia5hora2.Visible = False
            Me.imgdia5hora3.Visible = False
            Me.imgdia5hora4.Visible = False
            Me.imgdia5hora5.Visible = False
            Me.imgdia5hora6.Visible = False
            Me.imgdia5hora7.Visible = False
            Me.imgdia5hora8.Visible = False
            Me.imgdia6hora1.Visible = False
            Me.imgdia6hora2.Visible = False
            Me.imgdia6hora3.Visible = False
            Me.imgdia6hora4.Visible = False
            Me.imgdia6hora5.Visible = False
            Me.imgdia6hora6.Visible = False
            Me.imgdia6hora7.Visible = False
            Me.imgdia6hora8.Visible = False
            Me.imgdia7hora1.Visible = False
            Me.imgdia7hora2.Visible = False
            Me.imgdia7hora3.Visible = False
            Me.imgdia7hora4.Visible = False
            Me.imgdia7hora5.Visible = False
            Me.imgdia7hora6.Visible = False
            Me.imgdia7hora7.Visible = False
            Me.imgdia7hora8.Visible = False
            Me.lbldia1hora1.Visible = True
            Me.lbldia1hora2.Visible = True
            Me.lbldia1hora3.Visible = True
            Me.lbldia1hora4.Visible = True
            Me.lbldia1hora5.Visible = True
            Me.lbldia1hora6.Visible = True
            Me.lbldia1hora7.Visible = True
            Me.lbldia1hora8.Visible = True
            Me.lbldia2hora1.Visible = True
            Me.lbldia2hora2.Visible = True
            Me.lbldia2hora3.Visible = True
            Me.lbldia2hora4.Visible = True
            Me.lbldia2hora5.Visible = True
            Me.lbldia2hora6.Visible = True
            Me.lbldia2hora7.Visible = True
            Me.lbldia2hora8.Visible = True
            Me.lbldia3hora1.Visible = True
            Me.lbldia3hora2.Visible = True
            Me.lbldia3hora3.Visible = True
            Me.lbldia3hora4.Visible = True
            Me.lbldia3hora5.Visible = True
            Me.lbldia3hora6.Visible = True
            Me.lbldia3hora7.Visible = True
            Me.lbldia3hora8.Visible = True
            Me.lbldia4hora1.Visible = True
            Me.lbldia4hora2.Visible = True
            Me.lbldia4hora3.Visible = True
            Me.lbldia4hora4.Visible = True
            Me.lbldia4hora5.Visible = True
            Me.lbldia4hora6.Visible = True
            Me.lbldia4hora7.Visible = True
            Me.lbldia4hora8.Visible = True
            Me.lbldia5hora1.Visible = True
            Me.lbldia5hora2.Visible = True
            Me.lbldia5hora3.Visible = True
            Me.lbldia5hora4.Visible = True
            Me.lbldia5hora5.Visible = True
            Me.lbldia5hora6.Visible = True
            Me.lbldia5hora7.Visible = True
            Me.lbldia5hora8.Visible = True
            Me.lbldia6hora1.Visible = True
            Me.lbldia6hora2.Visible = True
            Me.lbldia6hora3.Visible = True
            Me.lbldia6hora4.Visible = True
            Me.lbldia6hora5.Visible = True
            Me.lbldia6hora6.Visible = True
            Me.lbldia6hora7.Visible = True
            Me.lbldia6hora8.Visible = True
            Me.lbldia7hora1.Visible = True
            Me.lbldia7hora2.Visible = True
            Me.lbldia7hora3.Visible = True
            Me.lbldia7hora4.Visible = True
            Me.lbldia7hora5.Visible = True
            Me.lbldia7hora6.Visible = True
            Me.lbldia7hora7.Visible = True
            Me.lbldia7hora8.Visible = True
            Me.lbldia1hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora1.Enabled = estado
            Me.lbldia1hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora2.Enabled = estado
            Me.lbldia1hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora3.Enabled = estado
            Me.lbldia1hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora4.Enabled = estado
            Me.lbldia1hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora5.Enabled = estado
            Me.lbldia1hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora6.Enabled = estado
            Me.lbldia1hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora7.Enabled = estado
            Me.lbldia1hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia1hora8.Enabled = estado
            Me.lbldia2hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora1.Enabled = estado
            Me.lbldia2hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora2.Enabled = estado
            Me.lbldia2hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora3.Enabled = estado
            Me.lbldia2hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora4.Enabled = estado
            Me.lbldia2hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora5.Enabled = estado
            Me.lbldia2hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora6.Enabled = estado
            Me.lbldia2hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora7.Enabled = estado
            Me.lbldia2hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia2hora8.Enabled = estado
            Me.lbldia3hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora1.Enabled = estado
            Me.lbldia3hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora2.Enabled = estado
            Me.lbldia3hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora3.Enabled = estado
            Me.lbldia3hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora4.Enabled = estado
            Me.lbldia3hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora5.Enabled = estado
            Me.lbldia3hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora6.Enabled = estado
            Me.lbldia3hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora7.Enabled = estado
            Me.lbldia3hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia3hora8.Enabled = estado
            Me.lbldia4hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora1.Enabled = estado
            Me.lbldia4hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora2.Enabled = estado
            Me.lbldia4hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora3.Enabled = estado
            Me.lbldia4hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora4.Enabled = estado
            Me.lbldia4hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora5.Enabled = estado
            Me.lbldia4hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora6.Enabled = estado
            Me.lbldia4hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora7.Enabled = estado
            Me.lbldia4hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia4hora8.Enabled = estado
            Me.lbldia5hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora1.Enabled = estado
            Me.lbldia5hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora2.Enabled = estado
            Me.lbldia5hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora3.Enabled = estado
            Me.lbldia5hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora4.Enabled = estado
            Me.lbldia5hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora5.Enabled = estado
            Me.lbldia5hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora6.Enabled = estado
            Me.lbldia5hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora7.Enabled = estado
            Me.lbldia5hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia5hora8.Enabled = estado
            Me.lbldia6hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora1.Enabled = estado
            Me.lbldia6hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora2.Enabled = estado
            Me.lbldia6hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora3.Enabled = estado
            Me.lbldia6hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora4.Enabled = estado
            Me.lbldia6hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora5.Enabled = estado
            Me.lbldia6hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora6.Enabled = estado
            Me.lbldia6hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora7.Enabled = estado
            Me.lbldia6hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia6hora8.Enabled = estado
            Me.lbldia7hora1.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora1.Enabled = estado
            Me.lbldia7hora2.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora2.Enabled = estado
            Me.lbldia7hora3.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora3.Enabled = estado
            Me.lbldia7hora4.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora4.Enabled = estado
            Me.lbldia7hora5.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora5.Enabled = estado
            Me.lbldia7hora6.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora6.Enabled = estado
            Me.lbldia7hora7.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora7.Enabled = estado
            Me.lbldia7hora8.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            Me.lbldia7hora8.Enabled = estado
            Me.lbldia1hora1.ToolTip = ""
            Me.lbldia1hora2.ToolTip = ""
            Me.lbldia1hora3.ToolTip = ""
            Me.lbldia1hora4.ToolTip = ""
            Me.lbldia1hora5.ToolTip = ""
            Me.lbldia1hora6.ToolTip = ""
            Me.lbldia1hora7.ToolTip = ""
            Me.lbldia1hora8.ToolTip = ""
            Me.lbldia2hora1.ToolTip = ""
            Me.lbldia2hora2.ToolTip = ""
            Me.lbldia2hora3.ToolTip = ""
            Me.lbldia2hora4.ToolTip = ""
            Me.lbldia2hora5.ToolTip = ""
            Me.lbldia2hora6.ToolTip = ""
            Me.lbldia2hora7.ToolTip = ""
            Me.lbldia2hora8.ToolTip = ""
            Me.lbldia3hora1.ToolTip = ""
            Me.lbldia3hora2.ToolTip = ""
            Me.lbldia3hora3.ToolTip = ""
            Me.lbldia3hora4.ToolTip = ""
            Me.lbldia3hora5.ToolTip = ""
            Me.lbldia3hora6.ToolTip = ""
            Me.lbldia3hora7.ToolTip = ""
            Me.lbldia3hora8.ToolTip = ""
            Me.lbldia4hora1.ToolTip = ""
            Me.lbldia4hora2.ToolTip = ""
            Me.lbldia4hora3.ToolTip = ""
            Me.lbldia4hora4.ToolTip = ""
            Me.lbldia4hora5.ToolTip = ""
            Me.lbldia4hora6.ToolTip = ""
            Me.lbldia4hora7.ToolTip = ""
            Me.lbldia4hora8.ToolTip = ""
            Me.lbldia5hora1.ToolTip = ""
            Me.lbldia5hora2.ToolTip = ""
            Me.lbldia5hora3.ToolTip = ""
            Me.lbldia5hora4.ToolTip = ""
            Me.lbldia5hora5.ToolTip = ""
            Me.lbldia5hora6.ToolTip = ""
            Me.lbldia5hora7.ToolTip = ""
            Me.lbldia5hora8.ToolTip = ""
            Me.lbldia6hora1.ToolTip = ""
            Me.lbldia6hora2.ToolTip = ""
            Me.lbldia6hora3.ToolTip = ""
            Me.lbldia6hora4.ToolTip = ""
            Me.lbldia6hora5.ToolTip = ""
            Me.lbldia6hora6.ToolTip = ""
            Me.lbldia6hora7.ToolTip = ""
            Me.lbldia6hora8.ToolTip = ""
            Me.lbldia7hora1.ToolTip = ""
            Me.lbldia7hora2.ToolTip = ""
            Me.lbldia7hora3.ToolTip = ""
            Me.lbldia7hora4.ToolTip = ""
            Me.lbldia7hora5.ToolTip = ""
            Me.lbldia7hora6.ToolTip = ""
            Me.lbldia7hora7.ToolTip = ""
            Me.lbldia7hora8.ToolTip = ""
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 04/08/2014
    ''' DESCR: DESHABILITA LABEL Y HABILITA PICTURE BOX
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AsignaTurnoControl(ByVal dia As Integer, ByVal hora As String, ByVal estado As Boolean, ByVal tooltip As String, ByVal habilitado As Boolean, ByVal otro As Boolean, _
                                   ByVal propiohoy As Boolean, ByVal horaReal As String)
        Try
            If dia = 1 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora1, imgdia1hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora2, imgdia1hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora3, imgdia1hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora4, imgdia1hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora5, imgdia1hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora6, imgdia1hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora7, imgdia1hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia1hora8, imgdia1hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            ElseIf dia = 2 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora1, imgdia2hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora2, imgdia2hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora3, imgdia2hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora4, imgdia2hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora5, imgdia2hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora6, imgdia2hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora7, imgdia2hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia2hora8, imgdia2hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            ElseIf dia = 3 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora1, imgdia3hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora2, imgdia3hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora3, imgdia3hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora4, imgdia3hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora5, imgdia3hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora6, imgdia3hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora7, imgdia3hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia3hora8, imgdia3hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            ElseIf dia = 4 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora1, imgdia4hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora2, imgdia4hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora3, imgdia4hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora4, imgdia4hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora5, imgdia4hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora6, imgdia4hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora7, imgdia4hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia4hora8, imgdia4hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            ElseIf dia = 5 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora1, imgdia5hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora2, imgdia5hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora3, imgdia5hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora4, imgdia5hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora5, imgdia5hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora6, imgdia5hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora7, imgdia5hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia5hora8, imgdia5hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            ElseIf dia = 6 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora1, imgdia6hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora2, imgdia6hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora3, imgdia6hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora4, imgdia6hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora5, imgdia6hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora6, imgdia6hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora7, imgdia6hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia6hora8, imgdia6hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            ElseIf dia = 7 Then
                If hora = "08:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora1, imgdia7hora1, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "09:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora2, imgdia7hora2, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "10:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora3, imgdia7hora3, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "11:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora4, imgdia7hora4, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "12:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora5, imgdia7hora5, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "13:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora6, imgdia7hora6, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "14:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora7, imgdia7hora7, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                ElseIf hora = "15:00" Then
                    EstadoControlesInternosCalendario(lbldia7hora8, imgdia7hora8, estado, tooltip, habilitado, otro, propiohoy, horaReal)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 28/08/2014
    ''' DESCR: HABILITA Y DESHABILITA FOCODEL CONTROL
    ''' </summary>
    ''' <param name="dia"></param>
    ''' <param name="hora"></param>
    ''' <param name="estado"></param>
    ''' <remarks></remarks>
    Private Sub FocoTurnoControl(ByVal dia As Integer, ByVal hora As String, ByVal estado As Boolean)
        Try
            If dia = 1 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia1hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia1hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia1hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia1hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia1hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia1hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia1hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia1hora8, estado)
                End If
            ElseIf dia = 2 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia2hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia2hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia2hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia2hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia2hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia2hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia2hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia2hora8, estado)
                End If
            ElseIf dia = 3 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia3hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia3hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia3hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia3hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia3hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia3hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia3hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia3hora8, estado)
                End If
            ElseIf dia = 4 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia4hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia4hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia4hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia4hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia4hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia4hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia4hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia4hora8, estado)
                End If
            ElseIf dia = 5 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia5hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia5hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia5hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia5hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia5hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia5hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia5hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia5hora8, estado)
                End If
            ElseIf dia = 6 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia6hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia6hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia6hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia6hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia6hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia6hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia6hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia6hora8, estado)
                End If
            ElseIf dia = 7 Then
                If hora = "08:00" Then
                    FocoLabelControlCalendario(lbldia7hora1, estado)
                ElseIf hora = "09:00" Then
                    FocoLabelControlCalendario(lbldia7hora2, estado)
                ElseIf hora = "10:00" Then
                    FocoLabelControlCalendario(lbldia7hora3, estado)
                ElseIf hora = "11:00" Then
                    FocoLabelControlCalendario(lbldia7hora4, estado)
                ElseIf hora = "12:00" Then
                    FocoLabelControlCalendario(lbldia7hora5, estado)
                ElseIf hora = "13:00" Then
                    FocoLabelControlCalendario(lbldia7hora6, estado)
                ElseIf hora = "14:00" Then
                    FocoLabelControlCalendario(lbldia7hora7, estado)
                ElseIf hora = "15:00" Then
                    FocoLabelControlCalendario(lbldia7hora8, estado)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 19/08/2014
    ''' DESCR: SETEA LA IMAGEN, EL ESTADO Y CURSOR DE CADA UNO DE LOS ITEMS DEL CALENDARIO
    ''' </summary>
    ''' <param name="label"></param>
    ''' <param name="img"></param>
    ''' <param name="estado"></param>
    ''' <param name="otro"></param>
    ''' <param name="tooltip"></param>
    ''' <remarks></remarks>
    Private Sub EstadoControlesInternosCalendario(ByVal label As LinkButton, ByVal img As ImageButton, ByVal estado As Boolean, ByVal tooltip As String, ByVal habilitado As Boolean, ByVal otro As Boolean, _
                                                  ByVal propiohoy As Boolean, ByVal horaReal As String)
        Try
            label.Visible = Not estado
            img.Visible = estado
            img.ToolTip = tooltip 'IIf(tooltip.Contains("Turno "), "", tooltip)
            img.AlternateText = tooltip
            If propiohoy Then
                img.Enabled = True
                img.Style.Add(HtmlTextWriterStyle.Cursor, "default")
                img.OnClientClick = "return false;"
            Else
                img.Enabled = habilitado
                img.Style.Add(HtmlTextWriterStyle.Cursor, IIf(habilitado, "hand", "default"))
            End If
            If otro Then
                img.Enabled = True
                img.Style.Add(HtmlTextWriterStyle.Cursor, "default")
                img.OnClientClick = "return false;"
            End If
            If tooltip = "Ocupado" Then
                img.ImageUrl = "../images/background/nodisponible.png"
            ElseIf tooltip = "No Disponible" Then
                img.ImageUrl = "../images/background/ocupado.png"
            Else
                img.ImageUrl = IIf(otro, CreaPngHora(horaReal, "#FEFFC6", "#85A534"), CreaPngHora(horaReal, "#FFFFFF", "#85A534"))
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 19/08/2014
    ''' DESCR: SETEA EL LABEL DE CADA UNO DE LOS ITEMS DEL CALENDARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EstadosLabelControlCalendario(ByVal label As LinkButton, ByVal color As String, ByVal estado As Boolean, ByVal tooltiptext As String)
        Try
            label.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
            label.Enabled = estado
            label.ToolTip = tooltiptext
            label.Visible = estado
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 28/08/2014
    ''' DESCR: PINTA EL FOCO DEL CONTROL
    ''' </summary>
    ''' <param name="label"></param>
    ''' <param name="estado"></param>
    ''' <remarks></remarks>
    Private Sub FocoLabelControlCalendario(ByVal label As LinkButton, ByVal estado As Boolean)
        Try
            label.BackColor = System.Drawing.ColorTranslator.FromHtml((IIf(estado, "#FFE9C5", "#FFFFFF")))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#End Region


    Private Sub cmbtaller_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbtaller.SelectedIndexChanged
        RecargarControlFecha(cmbtaller.SelectedValue, 0, 0)
    End Sub

End Class