﻿Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Web.Services.Description

Public Class VehiculoTurno
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            metodos_master("Generación de turnos", 6, "Turnos")
            mensajeria_error("", "")
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                    If Session("id_vehiculo") = "" Then
                        Session("id_vehiculo") = CargaDatosVehiculo()
                    Else
                        Dim id As String = CargaDatosVehiculo()
                    End If
                    LlenaControles(Session("id_vehiculo"))
                    Session("fecha_turno_calendario") = Date.Now
                    Session("atencion_turno") = 0
                    ControlesTallerFuera(False)
                    PantallaInicial()
                    btnverturno.Visible = False
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            Else
                If Session("user") Is Nothing Then
                    Response.Redirect("login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

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
            Session("fecha_turno_seleccionado") = ""
            Session("Metodo_Turno") = "Borrar"
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
            Session("fecha_turno_seleccionado") = fecha

            ActivaTracking(True, fecha.Day, fecha.Month, fecha.Year)
            If Me.btnverturno.Text = "" Or Me.btnverturno.Text <> DevuelveFormatoFecha(fecha.Day, fecha.Month, fecha.Year, hora) Then
                ActivaTracking(True, fecha.Day, fecha.Month, fecha.Year)
            Else
                ActivaTracking(True, fecha.Day, fecha.Month, fecha.Year)
                Dim dtidTurno As DataSet
                dtidTurno = VehiculoTurnoAdapter.ConsultaTurnoVehiculo(Session("id_vehiculo"), fecha.Year, fecha.Month, fecha.Day, hora)
                If dtidTurno.Tables(0).Rows.Count > 0 Then
                    Session("atencion_turno") = Convert.ToInt64(dtidTurno.Tables(0).Rows(0).Item(0))
                    FocoTurnoControl(CInt(Session("dia")), Session("hora").ToString, True)
                    Try
                        Dim diad As Integer = CInt(Session("dia"))
                        Dim horad As String = Session("hora").ToString
                        Dim fechad As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
                        Dim fechaAnteriord As DateTime = DateAdd(DateInterval.Day, (fechad.DayOfWeek) * -1, fecha)
                        fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
                        If Session("Metodo_Turno").ToString = "Grabar" Then
                            GrabaTurno(fecha.Day, fecha.Month, fecha.Year, horad, Session("id_vehiculo_3s"), Session("user"))
                        ElseIf Session("Metodo_Turno").ToString = "Borrar" Then
                            BorraTurno(fechad.Day, fechad.Month, fechad.Year, horad, Session("id_vehiculo"), Session("user"))
                        End If
                    Catch ex As Exception
                        ExceptionHandler.Captura_Error(ex)
                    End Try
                Else
                    mensajeria_error("error", "no se puede obtener id del turno")
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

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
            EnceraTracking()
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
            Session("Metodo_Turno") = "Grabar"
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            Dim dtidValida As DataSet
            fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
            Dim idTaller As Integer = CInt(Session("id_taller_turno"))
            dtidValida = VehiculoTurnoAdapter.ValidaVehiculo(Session("id_vehiculo"), fecha.Year, fecha.Month, fecha.Day, idTaller, hora)
            If dtidValida.Tables.Count > 0 Then
                If dtidValida.Tables(0).Rows.Count > 0 Then
                    If dtidValida.Tables(0).Rows(0).Item(0).ToString = "1" Then
                        Try
                            Dim diad As Integer = CInt(Session("dia"))
                            Dim horad As String = Session("hora").ToString
                            Dim fechad As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
                            Dim fechaAnteriord As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
                            fecha = DateAdd(DateInterval.Day, dia, fechaAnterior)
                            If Session("Metodo_Turno").ToString = "Grabar" Then
                                GrabaTurno(fecha.Day, fecha.Month, fecha.Year, horad, Session("id_vehiculo_3s"), Session("user"))
                            ElseIf Session("Metodo_Turno").ToString = "Borrar" Then
                                BorraTurno(fechad.Day, fechad.Month, fechad.Year, horad, Session("id_vehiculo"), Session("user"))
                            End If
                        Catch ex As Exception
                            ExceptionHandler.Captura_Error(ex)
                        End Try
                    ElseIf dtidValida.Tables(0).Rows(0).Item(0).ToString = "0" Then
                        mensajeria_error("error", dtidValida.Tables(0).Rows(0).Item(1))
                    End If
                Else
                    mensajeria_error("error", "Error al validar el turno")
                End If
            Else
                mensajeria_error("error", "Error al validar el turno")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnverturno_Click(sender As Object, e As System.EventArgs) Handles btnverturno.Click
        'Try
        'If btnverturno.Text = "Actualizar" Then
        '    If Not ValidaControlesTaller(True) Then
        '        Exit Sub
        '    End If
        '    ActualizaTurno(Convert.ToDateTime(Session("fecha_turno_seleccionado")), Session("hora"))
        'Else
        '    Dim idTaller As Integer = CInt(Session("id_taller_turno"))
        '    RecargarControlFecha(idTaller, Session("id_vehiculo"), Session("user"))
        'End If
        'Catch ex As Exception
        '    ExceptionHandler.Captura_Error(ex)
        'End Try
    End Sub

    Private Sub BtnCalendarioanterior_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnCalendarioanterior.Click
        Try
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Session("fecha_turno_calendario") = DateAdd(DateInterval.Day, -7, fecha)
            PantallaInicial()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BtnCalendariosiguiente_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnCalendariosiguiente.Click
        Try
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            Session("fecha_turno_calendario") = DateAdd(DateInterval.Day, 7, fecha)
            PantallaInicial()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub cmbtallertur_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbtallertur.SelectedIndexChanged
        Try
            Dim dtcVehTaller As DataSet
            dtcVehTaller = Session("id_taller_turno") 'VehiculoTurnoAdapter.ConsultaControles(5, 0)
            For i As Integer = 0 To dtcVehTaller.Tables(0).Rows.Count - 1
                If dtcVehTaller.Tables(0).Rows(i).Item("CODIGO") = cmbtallertur.SelectedValue Then
                    Session("id_taller_turno") = dtcVehTaller.Tables(0).Rows(i).Item("CODIGO")
                    Session("hora_taller_turno") = dtcVehTaller.Tables(0).Rows(i).Item("HORA_LIMITE")
                    Session("hora_taller_turno_fs") = dtcVehTaller.Tables(0).Rows(i).Item("HORA_LIMITE_FS")
                    Session("id_taller_ns") = dtcVehTaller.Tables(0).Rows(i).Item("ID_NETSUITE")
                End If
            Next
            RecargarControlFecha(Session("id_taller_turno"), Session("id_vehiculo"), Session("user"))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btnvergps_Click(sender As Object, e As System.EventArgs) Handles btnvergps.Click
        Response.Redirect("./busquedamapas.aspx", False)
    End Sub

    'HABILITAR CUANDO SE APRUEBE ULTIMA VERSION DE TURNOS.
    'Private Sub cmbproductortur_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproductortur.SelectedIndexChanged
    '    If cmbproductortur.SelectedValue = "BR - 6" _
    '        Or cmbproductortur.SelectedValue = "BS - 6" _
    '        Or cmbproductortur.SelectedValue = "HH - 6" Then
    '        dvopcionescandados.Visible = True
    '    Else
    '        dvopcionescandados.Visible = False
    '    End If
    'End Sub

#End Region

#Region "Estados Controles"

    Private Sub ControlesTallerFuera(ByVal estado As Boolean)
        Try
            'cmbtallertur.Visible = Not estado
            txtdirecciontur.Visible = estado
            txtcontactotur.Visible = estado
            txttelefonotur.Visible = estado
            'HABILITAR CUANDO SE APRUEBE ULTIMA VERSION DE TURNOS.
            txtcomentariotur.Visible = True
            dvgeoreferencia.Visible = estado
            txtdirecciontur.Text = ""
            txtcontactotur.Text = ""
            txttelefonotur.Text = ""
            txtcomentariotur.Value = ""
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub PantallaInicial()
        Try
            SetDiasCalendario(Convert.ToDateTime(Session("fecha_turno_calendario")))
            lblfechacalendario.Text = DevuelveFecha(Convert.ToDateTime(Session("fecha_turno_calendario")))
            EstadosEncerar(False, "#E9E9E9")
            RecargarControlFecha(CInt(Session("id_taller_turno")), Convert.ToInt64(Session("id_vehiculo")), Session("user").ToString)
            EnceraTracking()
            ActivaTracking(True, Date.Now.Day, Date.Now.Month, Date.Now.Year)
            dvopcionescandados.Visible = False
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub RecargarControlFecha(ByVal idTaller As Integer, ByVal idVehiculo As Int64, ByVal cliente As String)
        Try
            EstadosEncerar(False, "#E9E9E9")
            Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
            SetDiasCalendario(Convert.ToDateTime(Session("fecha_turno_calendario")))
            Me.lblfechacalendario.Text = DevuelveFecha(fecha)
            EstadosDiasCalendario(idTaller, fecha)
            EstadosDiasCalendarioTurnos(idTaller, fecha)
            EstadosDiasCalendarioTurnosPropios(idVehiculo, idTaller, fecha)
            EstadosDiasCalendarioTurnosPropiosotros(idVehiculo, idTaller, fecha, cliente)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub LimpiaControles()
        Try
            btnverturno.Visible = False
            txtcontactotur.Text = ""
            txtdirecciontur.Text = ""
            txttelefonotur.Text = ""
            cmbtallertur.SelectedIndex = 0
            txtcomentariotur.Value = ""
            txtlongitudtur.Text = ""
            txtlatitudtur.Text = ""
            cmblugartur.SelectedIndex = 0
            cmbproductortur.SelectedIndex = 0
            ControlesTallerFuera(False)
            chkopcion1.Checked = False
            chkopcion2.Checked = False
            chkopcion3.Checked = False
            chkopcion4.Checked = False
            chkopcion5.Checked = False
            dvopcionescandados.Visible = False
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ActivaTracking(ByVal estado As Boolean, ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer)
        Try
            If estado Then
                Dim dtcTracking As New System.Data.DataSet
                dtcTracking = VehiculoTurnoAdapter.ConsultaDatosTracking(Session("user").ToString, Convert.ToInt64(Session("id_vehiculo")), anio, mes, dia)
                If dtcTracking.Tables.Count > 0 Then
                    If dtcTracking.Tables(0).Rows.Count > 0 Then
                        If CInt(dtcTracking.Tables(0).Rows(0).Item("ETAPA")) = 1 Then
                            divetapa1tur.Attributes.Add("class", "current-state")
                        ElseIf CInt(dtcTracking.Tables(0).Rows(0).Item("ETAPA")) = 2 Then
                            divetapa2tur.Attributes.Add("class", "current-state")
                        ElseIf CInt(dtcTracking.Tables(0).Rows(0).Item("ETAPA")) = 3 Then
                            divetapa3tur.Attributes.Add("class", "current-state")
                        ElseIf CInt(dtcTracking.Tables(0).Rows(0).Item("ETAPA")) = 4 Then
                            divetapa4tur.Attributes.Add("class", "current-state")
                        ElseIf CInt(dtcTracking.Tables(0).Rows(0).Item("ETAPA")) = 5 Then
                            divetapa5tur.Attributes.Add("class", "current-state")
                        End If
                    End If
                End If
            End If
            btnverturno.Text = DevuelveFormatoFecha(dia, mes, anio, "")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub EnceraTracking()
        Try
            divetapa1tur.Attributes.Add("class", "")
            divetapa2tur.Attributes.Add("class", "")
            divetapa3tur.Attributes.Add("class", "")
            divetapa4tur.Attributes.Add("class", "")
            divetapa5tur.Attributes.Add("class", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function DevuelveFecha(ByVal fecha As DateTime) As String
        DevuelveFecha = ""
        Try
            Dim fechaAnterior As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
            Dim fechaIni As DateTime = DateAdd(DateInterval.Day, 1, fechaAnterior)
            Dim fechaFin As DateTime = DateAdd(DateInterval.Day, 7, fechaAnterior)
            DevuelveFecha = DevuelveMes(fechaIni) & " " & Day(fechaIni) & " de " & Year(fechaIni) &
                             " - " & DevuelveMes(fechaFin) & " " & Day(fechaFin) & " de " & Year(fechaFin)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

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

    Private Function ValidaControlesTaller(ByVal fuera As Boolean) As Boolean
        ValidaControlesTaller = True
        Try
            If cmbproductortur.SelectedValue = 0 Then
                mensajeria_error("error", "Por favor selecciones algún producto y servicio")
                ValidaControlesTaller = False
            ElseIf cmblugartur.SelectedIndex < 1 Then
                mensajeria_error("error", "El sitio del turno es obligatorio")
                ValidaControlesTaller = False
            ElseIf cmbtallertur.SelectedIndex = 0 Then
                mensajeria_error("error", "Debe seleccionar un taller")
                ValidaControlesTaller = False
            End If
            If fuera Then
                If txtdirecciontur.Text = "" Then
                    mensajeria_error("error", "La dirección es obligatorio")
                    ValidaControlesTaller = False
                ElseIf txtcontactotur.Text = "" Then
                    mensajeria_error("error", "El contacto es obligatorio")
                    ValidaControlesTaller = False
                ElseIf txttelefonotur.Text = "" Then
                    mensajeria_error("error", "El teléfono contacto es obligatorio")
                    ValidaControlesTaller = False
                ElseIf txtcomentariotur.Value = "" Then
                    mensajeria_error("error", "El comentario es obligatorio")
                    ValidaControlesTaller = False
                ElseIf cmbtallertur.SelectedIndex = 0 Then
                    mensajeria_error("error", "La ciudad es obligatorio")
                    ValidaControlesTaller = False
                ElseIf txtlatitudtur.Text = "" Then
                    mensajeria_error("error", "La latitud es obligatoria, por favor inicie el mapa")
                    ValidaControlesTaller = False
                ElseIf txtlongitudtur.Text = "" Then
                    mensajeria_error("error", "La longitud es obligatoria, por favor inicie el mapa")
                    ValidaControlesTaller = False
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

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

#Region "Acceso a Base"

#Region "Llenar controles desde base"

    Private Sub LlenaControles(ByVal vehiculo As String)
        Try
            Dim dtcVehProducto As New System.Data.DataTable
            Dim dtcVehLugarturno, dtcVehTaller As New System.Data.DataSet
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultacobertura").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosProducto").ToString()
            dtcVehProducto = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", vehiculo, "", "", "", "", "", "", ""))
            cmbproductortur.DataSource = dtcVehProducto
            Session("tabla_productos_turnos") = dtcVehProducto
            cmbproductortur.DataValueField = "CodGrupoProducto"
            cmbproductortur.DataTextField = "GrupoProducto"
            cmbproductortur.DataBind()
            dtcVehLugarturno = VehiculoTurnoAdapter.ConsultaControles(2, 0)
            cmblugartur.DataSource = dtcVehLugarturno
            cmblugartur.DataTextField = "DESCRIPCION"
            cmblugartur.DataValueField = "CODIGO"
            cmblugartur.DataBind()
            dtcVehTaller = VehiculoTurnoAdapter.ConsultaControles(5, 0)
            cmbtallertur.DataSource = dtcVehTaller
            cmbtallertur.DataTextField = "DESCRIPCION"
            cmbtallertur.DataValueField = "CODIGO"
            cmbtallertur.DataBind()
            For i As Integer = 0 To dtcVehTaller.Tables(0).Rows.Count - 1
                If dtcVehTaller.Tables(0).Rows(i).Item("CODIGO") = "38" _
                    Or dtcVehTaller.Tables(0).Rows(i).Item("CODIGO") = "46" Then
                    Session("id_taller_turno") = dtcVehTaller.Tables(0).Rows(i).Item("CODIGO")
                    Session("hora_taller_turno") = dtcVehTaller.Tables(0).Rows(i).Item("HORA_LIMITE")
                    Session("hora_taller_turno_fs") = dtcVehTaller.Tables(0).Rows(i).Item("HORA_LIMITE_FS")
                    Session("id_taller_ns") = dtcVehTaller.Tables(0).Rows(i).Item("ID_NETSUITE")
                    Session("data_talleres") = dtcVehTaller
                    cmbtallertur.SelectedValue = Session("id_taller_turno")
                End If
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function CargaDatosVehiculo() As String
        Dim devolver As String = ""
        Try
            Dim dTDatosVehiculo As DataTable
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosVehiculos").ToString()
            dTDatosVehiculo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", "", "", Session("user_netsuite"), "", "", ""))
            If dTDatosVehiculo.Rows.Count > 0 Then
                lblplacatur.Text = dTDatosVehiculo.Rows(0).Item("Placa").ToString
                lblchasistur.Text = dTDatosVehiculo.Rows(0).Item("Chasis").ToString
                lblmarcatur.Text = dTDatosVehiculo.Rows(0).Item("Marca").ToString
                lblmodelotur.Text = dTDatosVehiculo.Rows(0).Item("Modelo").ToString
                devolver = dTDatosVehiculo.Rows(0)("IdVehiculo").ToString
                Session("id_vehiculo_3s") = VehiculoAdapter.ConsultaCodigoVehiculo(lblchasistur.Text)
            Else
                devolver = ""
                mensajeria_error("error", "No existen vehículos relacionados")
            End If
        Catch ex As Exception
            devolver = ""
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return devolver
    End Function

#End Region

#Region "Calendario"

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

    Private Sub EstadoControlesInternosCalendario(ByVal label As LinkButton, ByVal img As ImageButton, ByVal estado As Boolean, ByVal tooltip As String, ByVal habilitado As Boolean, ByVal otro As Boolean, _
                                                  ByVal propiohoy As Boolean, ByVal horaReal As String)
        Try
            label.Visible = Not estado
            img.Visible = estado
            img.ToolTip = IIf(tooltip.Contains("Turno "), "", tooltip)
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
                'label.Visible = False
                'label.Enabled = False
                img.Visible = True
                'img.Enabled = True
                img.ImageUrl = IIf(otro, CreaPngHora(horaReal, "#FEFFC6", "#85A534"), CreaPngHora(horaReal, "#FFFFFF", "#85A534"))
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

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
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

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
                AsignaTurnoControl(dia, hora, True, String.Format("Turno del vehículo Seleccionado,{0},{3},{1},{2} {5},{4},{6}", taller, ciudad, fechaTurno, placa, trabajos, horaReal, orden),
                                                                    IIf(CInt(diaTabla) = Date.Now.Day, False, True), False,
                                                                    IIf(CInt(diaTabla) = Date.Now.Day, True, False), horaReal)
                If Convert.ToDateTime(fechaTurno).Day = Date.Now.Day _
                    And Convert.ToDateTime(fechaTurno).Month = Date.Now.Month _
                    And Convert.ToDateTime(fechaTurno).Year = Date.Now.Year _
                    And (tallercodigo <> 46 And tallercodigo <> 5000 And tallercodigo <> 1702 And tallercodigo <> 25) Then
                End If
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

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
                AsignaTurnoControl(dia, hora, True, String.Format("Turno de otro Vehículo,{0},{3},{1},{2} {5},{4},{6}",
                                                                    taller, ciudad, fechaTurno, placa, trabajos, horaReal, orden), True, True, False, horaReal)
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

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

    Private Sub FocoLabelControlCalendario(ByVal label As LinkButton, ByVal estado As Boolean)
        Try
            label.BackColor = System.Drawing.ColorTranslator.FromHtml((IIf(estado, "#FFE9C5", "#FFFFFF")))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Acciones principales"

    Private Sub GrabaTurno(ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer, ByVal hora As String,
                           ByVal vehiculo As String, ByVal cliente As String)
        Try
            Dim idtaller As String = cmbtallertur.SelectedValue
            Dim taller As String = cmbtallertur.SelectedItem.Text
            Dim comentario As String = txtcomentariotur.InnerText
            Dim producto As String = cmbproductortur.SelectedValue & " - 10"
            Dim direcciontaller As String = ""
            Dim placa As String = lblplacatur.Text
            If producto = "HU - 10" Then
                If vehiculo <> "" Then
                    Dim retornoturnoid As String = graba_turno_3s(dia, mes, anio, hora, vehiculo, cliente, idtaller, comentario, producto,
                                                                          taller, direcciontaller, placa)
                    Dim datResultado() As String = retornoturnoid.Split("|")
                    Dim dhora As String = datResultado(0)
                    Dim orden_servicio As String = datResultado(1)
                    Dim turnoid As String = datResultado(2)

                    'If turnoid <> "" Then
                    '    graba_turno_ns(dia, anio, mes, hora, turnoid, Session("id_vehiculo"), "", orden_servicio)
                    'End If
                Else

                End If
            End If
        Catch ex As Exception
            FocoTurnoControl(CInt(Session("dia")), hora.Substring(0, 3) & "00", False)
            mensajeria_error("error", ex.Message.ToString)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub BorraTurno(ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer, ByVal hora As String, ByVal vehiculo As Int64, ByVal cliente As String)
        mensajeria_error("informacion", "acción no esta disponible por el momento.")
        'Try
        '    Dim contacto = "", ubicacion = "", telefonocontacto = "", comentario = "", ciudad As String = ""
        '    Dim fuera As Boolean = False
        '    Dim idTaller As Integer = CInt(Session("id_taller_turno"))
        '    Dim placa As String = lblplacatur.Text
        '    If cmblugartur.SelectedValue = 2 Then
        '        contacto = txtcontactotur.Text
        '        telefonocontacto = txttelefonotur.Text
        '        ubicacion = txtdirecciontur.Text
        '        comentario = txtcomentariotur.Value
        '        ciudad = cmbtallertur.SelectedItem.Text
        '        fuera = True
        '    End If
        '    Dim resultado As String = VehiculoTurnoAdapter.DesasignaTurno(vehiculo, Convert.ToInt64(Session("atencion_turno")), cliente)
        '    Dim datResultado() As String = resultado.Split("|")
        '    hora = datResultado(0)
        '    If hora <> "00:00" Then
        '        Dim direcciontaller As String = ConsultaDireccionTaller(idTaller)
        '        Dim fecha As DateTime = Convert.ToDateTime(Session("fecha_turno_calendario"))
        '        Dim fechaA As DateTime = DateAdd(DateInterval.Day, (fecha.DayOfWeek) * -1, fecha)
        '        Dim taller As String = cmbtallertur.SelectedItem.Text
        '        AsignaTurnoControl(dia - fechaA.Day, hora, False, "", False, False, False, "00:00")

        '        Dim objmail As New MailTrabajos
        '        objmail.MailAvisoTurno(fecha.ToString("dd/MMM/yyyy"), hora, taller, ubicacion, comentario, contacto, telefonocontacto,
        '                  placa, False, False, fuera, ciudad, IIf(fuera, taller, direcciontaller), datResultado(2), datResultado(1), cliente, "Chequeo", vehiculo,
        '                               IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE"))
        '        mensajeria_error("informacion", "agenda se actualizó con éxito")
        '        LimpiaControles()
        '        RecargarControlFecha(idTaller, vehiculo, cliente)
        '        FormularioAdapter.RegistroLogFormulario(105, Session.Item("user"), "LOAD", "ELIMINA DE AGENDA TURNO DE VEHICULO", Session("iphost"))
        '    Else
        '        mensajeria_error("error", "no se pudo eliminar turno.")
        '    End If
        'Catch ex As Exception
        '    mensajeria_error("error", ex.Message.ToString)
        '    ExceptionHandler.Captura_Error(ex)
        'End Try
    End Sub

    Private Sub ActualizaTurno(ByVal fecha As DateTime, ByVal hora As String)
        mensajeria_error("informacion", "acción no esta disponible por el momento.")
        'If Not ValidaControlesTaller(IIf(cmblugartur.SelectedIndex <= 1, False, True)) Then
        '    Exit Sub
        'End If
        'Dim ciudad As String = ""
        'Dim contacto = "", ubicacion = "", telefonocontacto = "", comentario As String = ""
        'Dim placa As String = lblplacatur.Text
        'Dim fuera As Boolean = False
        'Dim productoTrabajo As String = cmbproductortur.SelectedValue
        'Dim idTurno As Integer = Convert.ToInt64(Session("atencion_turno"))
        'If cmblugartur.SelectedValue = 2 Then
        '    contacto = txtcontactotur.Text
        '    telefonocontacto = txttelefonotur.Text
        '    ubicacion = txtdirecciontur.Text
        '    ciudad = cmbtallertur.SelectedItem.Text
        '    comentario = txtcomentariotur.Value
        '    fuera = True
        'End If
        'If VehiculoTurnoAdapter.ActualizaTurno(Session("id_vehiculo"), ciudad, txttelefonotur.Text, txtcontactotur.Text, txtdirecciontur.Text, txtcomentariotur.Value, idTurno,
        '                                       CInt(Session("id_taller_turno")), productoTrabajo, Session("user")) > 0 Then
        '    Dim direcciontaller As String = ConsultaDireccionTaller(CInt(Session("id_taller_turno")))
        '    Dim taller As String = cmbtallertur.SelectedItem.Text
        '    mensajeria_error("informacion", "turno se actualizó con éxito.")
        '    Dim objmail As New MailTrabajos
        '    objmail.MailAvisoTurno(fecha.ToString("dd/MMM/yyyy"), hora, taller, ubicacion, comentario, contacto, telefonocontacto, placa,
        '              False, True, fuera, ciudad, IIf(fuera, taller, direcciontaller), 0, 0, Session("user"), "Chequeo", Session("id_vehiculo"),
        '                               IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE"))
        '    LimpiaControles()
        '    FormularioAdapter.RegistroLogFormulario(105, Session.Item("user"), "LOAD", "aCTUALIZA AGENDA DE TURNOS DE VEHICULO", Session("iphost"))
        'Else
        '    mensajeria_error("error", "turno no se actualizó, por favor verificar.")
        'End If
        'btnverturno.Text = "Ver Turno"
        'btnverturno.Visible = False
    End Sub

    'Private Sub graba_turno_ns(dia As String, anio As String, mes As String, hora As String, idturno As String, vehiculo As String, ejecutiva As String, ordenservicio As String)
    'Dim dtcVehProducto As New System.Data.DataTable
    'Dim valor_ejecutiva As String = ""
    'Dim itemturno As String = ConfigurationManager.AppSettings.Get("NSItemChequeoTurno").ToString()
    'dtcVehProducto = Session("tabla_productos_turnos")
    'For i As Integer = 0 To dtcVehProducto.Rows.Count - 1
    '    If dtcVehProducto.Rows(i).Item("CodGrupoProducto") = cmbproductortur.SelectedItem.Value Then
    '        valor_ejecutiva = dtcVehProducto.Rows(i).Item("IdEjecutivo")
    '    End If
    'Next
    'Dim boolean_str As String = "false"
    'Dim usuario_ns As String = Session("user_netsuite")
    'Dim ubicacion As String = extrae_oficina(usuario_ns)
    'Dim fecha_ns As String = fecha_ns_()
    'Dim id_script As String = ConfigurationManager.AppSettings.Get("NSIngresaOrden").ToString()
    'Dim parametroitm3 As String = ConfigurationManager.AppSettings.Get("NSParamInsertOSitem3").ToString()
    'parametroitm3 = String.Format(parametroitm3, itemturno, "1", ubicacion, "2", "1", 0, 0, CodigoIva(), 0, 0, "Chequeo Hunter Online", 1, "1")
    'Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamInsertOS").ToString()
    'parametro = String.Format(parametro, "ordendeservicio", usuario_ns, vehiculo, fecha_ns, "", "HunterOnline", ejecutiva, "", ubicacion, "", "1", "1", "17", parametroitm3)
    'parametro = parametro.Replace("||", "{").Replace("|!", "}")
    'Dim retorno As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro, 1)
    'If retorno.Contains("ordendeservicio") Then
    '    Dim ordengenerada_ns As String = retorno.Replace(Chr(34), "")
    '    ordengenerada_ns = retorno.Substring(retorno.IndexOf("response") + 10, 10)
    '    ordengenerada_ns = ordengenerada_ns.Substring(0, ordengenerada_ns.IndexOf(","))

    '    'id_script = ConfigurationManager.AppSettings.Get("NSIngresaTrabajo").ToString()
    '    'parametro = ConfigurationManager.AppSettings.Get("NSParamInserttrabajo").ToString()
    '    'parametro = String.Format(parametro, "157", usuario_ns, ejecutiva, ordengenerada_ns, vehiculo)
    '    'Dim retorno_ot_ns As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro, 1)
    '    'If retorno_ot_ns.Contains("orden") Then
    '    id_script = ConfigurationManager.AppSettings.Get("NSIngresaTurno").ToString()
    '    parametro = ConfigurationManager.AppSettings.Get("NSParamInsertTurno").ToString()
    '    parametro = String.Format(parametro, ordengenerada_ns, usuario_ns, itemturno, fecha_ns_(anio, mes, dia), hora, Session("id_taller_ns"), idturno, "", "OPERAD", "", vehiculo)
    '    parametro = "{" & parametro & "}"
    '    Dim retorno_turno_ns As String = ClaseConexionNetsuite.enviar_datos_netsuite(id_script, parametro, 1)
    '    Dim cadenastr As String = ""
    '    Dim turno_ns As String = retorno_turno_ns.Replace(Chr(34), "")
    '    turno_ns = turno_ns.Substring(turno_ns.IndexOf("response") + 10, 10)
    '    turno_ns = turno_ns.Substring(0, turno_ns.IndexOf(","))

    '    'If VehiculoTurnoAdapter.ActualizaTurno_3S_NS(vehiculo, idturno, cadenastr, usuario_ns, ordengenerada_ns, turno_ns) Then
    '    '    mensajeria_error("informacion", "Turno generado con éxito")
    '    'Else
    '    '    mensajeria_error("informacion", "Turno no se pudo generar")
    '    'End If
    '    'Else
    '    '    mensajeria_error("informacion", "Turno no se pudo generar")
    '    'End If
    'Else
    '    mensajeria_error("informacion", "Turno no se pudo generar")
    'End If
    'End Sub

    Private Function graba_turno_3s(ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer, ByVal hora As String,
                                    ByVal vehiculo As Int64, ByVal cliente As String, idtaller As String, comentario As String,
                                    productotrabajo As String, taller As String, direcciontaller As String, placa As String) As String
        Dim retorno As String = ""
        Dim contacto As String = ""
        Dim telefonocontacto As String = ""
        Dim ubicacion As String = ""
        Dim ciudad As String = ""
        Dim fuera As String = ""
        Dim latitud As String = ""
        Dim longitud As String = ""

        If cmblugartur.SelectedValue = 2 Then
            contacto = txtcontactotur.Text
            telefonocontacto = txttelefonotur.Text
            ubicacion = txtdirecciontur.Text
            ciudad = cmbtallertur.SelectedItem.Text
            fuera = True
            latitud = txtlatitudtur.Text
            longitud = txtlongitudtur.Text
        End If
        Dim resultado As String = VehiculoTurnoAdapter.AsignaTurno(dia, mes, anio, hora, vehiculo, cliente, contacto, telefonocontacto,
                                                                   ubicacion, idtaller, ciudad, comentario, productotrabajo,
                                                                   "OK", latitud, longitud, "")
        Dim datResultado() As String = resultado.Split("|")
        hora = datResultado(0)
        retorno = resultado ' datResultado(2)
        If hora <> "00:00" Then
            '    Dim taller As String = cmbtallertur.SelectedItem.Text
            '    Dim direcciontaller As String = ConsultaDireccionTaller(idTaller)
            Dim fecha As DateTime = Convert.ToDateTime(String.Format("{0}/{1}/{2}", Convert.ToString(dia), Convert.ToString(mes), Convert.ToString(anio)))
            Dim objmail As New MailTrabajos
            'objmail.MailAvisoTurno(fecha.ToString("dd/MMM/yyyy"), hora, taller, ubicacion, comentario, contacto, telefonocontacto, placa, True, False, fuera,
            '                           ciudad, IIf(fuera, taller, direcciontaller), datResultado(2), datResultado(1), cliente, "Chequeo", vehiculo,
            '                           IIf(Not Session("usuario") Is Nothing, Session("usuario"), ""))
            'mensajeria_error("informacion", "agenda se actualizó con éxito con fecha: " & fecha.ToString("dd/MMM/yyyy") & " | " & hora)
            LimpiaControles()
            RecargarControlFecha(idtaller, vehiculo, cliente)
            FormularioAdapter.RegistroLogFormulario(105, Session.Item("user"), "LOAD", "GRABA AGENDA DE TURNOS DE VEHICULO", Session("iphost"))
        Else
            mensajeria_error("error", "no se pudo guardar turno.")
        End If
        Return retorno
    End Function

#End Region

#End Region

#Region "Procedimientos generales"

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

    Public Shared Function extrae_oficina(id_cliente As String) As String
        Dim retorno As String = ""
        Dim dtresultado As New System.Data.DataTable
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        dtresultado = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", id_cliente, "", "", "", ""))

        If dtresultado.Rows.Count > 0 Then
            retorno = dtresultado.Rows(0)("IdOficina").ToString.ToUpper
        End If

        Return retorno
    End Function

    Public Shared Function extrae_nombre(id_cliente As String) As String
        Dim retorno As String = ""
        Dim dtresultado As New System.Data.DataTable
        Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        dtresultado = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", id_cliente, "", "", "", ""))

        If dtresultado.Rows.Count > 0 Then
            retorno = dtresultado.Rows(0)("NombreCompleto").ToString.ToUpper
        End If

        Return retorno
    End Function

    Public Shared Function fecha_ns_(Optional vanio As Integer = 0, Optional vmes As Integer = 0, Optional vdia As Integer = 0) As String
        Dim anio As String = IIf(vanio = 0, Date.Now.Year.ToString, vanio)
        Dim mes As String = IIf(vmes = 0, Date.Now.Month.ToString, vmes)
        Dim dia As String = IIf(vdia = 0, Date.Now.Day.ToString, vdia)
        mes = IIf(mes.Length = 1, "0", "") & mes
        dia = IIf(dia.Length = 1, "0", "") & dia

        Dim retorno As String = String.Format("{0}/{1}/{2}", anio, mes, dia)
        Return retorno
    End Function

    Private Function CodigoIva() As String
        Dim parametrocat As String
        Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
        CodigoIva = ""
        parametrocat = ConfigurationManager.AppSettings.Get("NSParamCatIva").ToString()

        Dim retorno As DataTable = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametrocat, "IVA", "2"))
        Dim retorno_val As String = retorno.Rows(0).Item("TarifaCodidgoImpuestoVentas")
        Dim retorno_cod As String = retorno.Rows(0).Item("IdCodidgoImpuestoVentas")
        retorno_val = retorno_val.Replace("%", "").Replace(" ", "")
        If retorno_cod <> "" Then
            CodigoIva = retorno_cod
            'Session("DTCodigoIva") = retorno_cod
            'Session("DTPorcentajeIva") = porcentajeIva / 100
        End If
    End Function

#End Region

End Class