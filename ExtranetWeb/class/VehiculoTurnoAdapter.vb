Public Class VehiculoTurnoAdapter

    Public Shared Function ConsultaDatosVehiculo(ByVal vehiculo As Int64) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 1)
            base.AddParrameter("@VEHICULO", vehiculo)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaTurnoVehiculo(ByVal vehiculo As Int64, ByVal anio As Integer, ByVal mes As Integer, ByVal dia As Integer, ByVal hora As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 17)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@ANIO", anio)
            base.AddParrameter("@MES", mes)
            base.AddParrameter("@DIA", dia)
            base.AddParrameter("@HORA", hora)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ValidaVehiculo(ByVal vehiculo As Int64, ByVal anio As Integer, ByVal mes As Integer, ByVal dia As Integer, ByVal taller As Integer, ByVal hora As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 18)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@ANIO", anio)
            base.AddParrameter("@MES", mes)
            base.AddParrameter("@DIA", dia)
            base.AddParrameter("@TALLER_ID", taller)
            base.AddParrameter("@HORA", hora)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaControles(ByVal proceso As Integer, ByVal vehiculo As Int64) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@VEHICULO", vehiculo)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaCalendario(ByVal proceso As Integer, ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer, ByVal vehiculo As Int64, _
                                              ByVal taller As Integer, ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@MES", mes)
            base.AddParrameter("@ANIO", anio)
            base.AddParrameter("@DIA", dia)
            base.AddParrameter("@TALLER_ID", taller)
            base.AddParrameter("@CLIENTE_ID", cliente)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosTurno(ByVal proceso As Integer, ByVal vehiculo As Int64, ByVal atencionTurno As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@ATENCION_TURNO_ID", atencionTurno)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosTaller(ByVal proceso As Integer, ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CLIENTE_ID", cliente)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosTracking(ByVal cliente As String, ByVal vehiculo As Int64, ByVal anio As Integer, ByVal mes As Integer, ByVal dia As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 20)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@MES", mes)
            base.AddParrameter("@ANIO", anio)
            base.AddParrameter("@DIA", dia)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosDireccionTaller(ByVal tallerid As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 21)
            base.AddParrameter("@TALLER_ID", tallerid)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPLaca(ByVal placa As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 23)
            base.AddParrameter("@PLACA", placa)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaTurnosVehiculoHoy(ByVal vehiculo As Int64) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 22)
            base.AddParrameter("@VEHICULO", vehiculo)
            ds = base.Consulta("EXTRANET.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function AsignaTurno(ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer, ByVal hora As String, ByVal vehiculo As Int64, ByVal cliente As String, _
                                       ByVal contacto As String, ByVal telefonocontacto As String, ByVal ubicacion As String, ByVal tallerId As Integer, ByVal ciudad As String, _
                                       ByVal comentario As String, ByVal grupo As String, ByVal placa As String, ByVal latitud As String, ByVal longitud As String, ByVal user_soporte As String) As String
        AsignaTurno = "00:00"
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Dim horaGenerada As String = "00:00"
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.SP_MANTENIMIENTO_TURNOS_WEB"
            base.AddParrameter("@PROCESO", 9)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@MES", mes)
            base.AddParrameter("@ANIO", anio)
            base.AddParrameter("@DIA", dia)
            base.AddParrameter("@HORA", hora)
            base.AddParrameter("@TALLER_ID", tallerId)
            base.AddParrameter("@CONTACTO", contacto)
            base.AddParrameter("@TELEFONO", telefonocontacto)
            base.AddParrameter("@UBICACION", ubicacion)
            base.AddParrameter("@COMENTARIO", comentario)
            base.AddParrameter("@CIUDAD", ciudad)
            base.AddParrameter("@GRUPO_PRODUCTO", grupo)
            base.AddParrameter("@PLACA", placa)
            base.AddParrameter("@ORIGEN", "HO")
            base.AddParrameter("@LATITUD", latitud)
            base.AddParrameter("@LONGITUD", longitud)
            base.AddParrameter("@USUARIO_SOPORTE", user_soporte)
            base.EjecutaTransaction(cmd, tran)
            horaGenerada = Convert.ToString(cmd.Parameters("@HORA_GENERADA").Value)
            If horaGenerada <> "" Then
                AsignaTurno = horaGenerada
                tran.Commit()
            Else
                AsignaTurno = "00:00"
                tran.Rollback()
            End If
        Catch ex As Exception
            AsignaTurno = "00:00"
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Public Shared Function DesasignaTurno(ByVal vehiculo As Int64, ByVal turno As Int64, ByVal cliente As String) As String
        DesasignaTurno = "00:00"
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Dim horaGenerada As String = "00:00"
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.SP_MANTENIMIENTO_TURNOS_WEB"
            base.AddParrameter("@PROCESO", 10)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@ATENCION_TURNO_ID", turno)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.EjecutaTransaction(cmd, Tran)
            horaGenerada = Convert.ToString(cmd.Parameters("@HORA_GENERADA").Value)
            If horaGenerada <> "" Then
                DesasignaTurno = horaGenerada
                tran.Commit()
            Else
                DesasignaTurno = "00:00"
                tran.Rollback()
            End If
        Catch ex As Exception
            DesasignaTurno = "00:00"
            Tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Public Shared Function ActualizaTurno(ByVal vehiculo As Int64, ByVal ciudad As String, ByVal telefono As Integer, ByVal contacto As String, ByVal ubicacion As String, _
                                          ByVal comentario As String, ByVal atencionTurno As Integer, ByVal tallerId As Integer, ByVal grupo As String, ByVal cliente As String) As Int64
        ActualizaTurno = 1
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.SP_MANTENIMIENTO_TURNOS_WEB"
            base.AddParrameter("@PROCESO", 13)
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@CIUDAD", ciudad)
            base.AddParrameter("@TELEFONO", telefono)
            base.AddParrameter("@CONTACTO", contacto)
            base.AddParrameter("@UBICACION", ubicacion)
            base.AddParrameter("@COMENTARIO", comentario)
            base.AddParrameter("@TALLER_ID", tallerId)
            'base.AddParrameter("@TIPO_TRABAJO", tipotrabajo)
            base.AddParrameter("@GRUPO_PRODUCTO", grupo)
            base.AddParrameter("@ATENCION_TURNO_ID", atencionTurno)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            ActualizaTurno = -1
            tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    Public Shared Function GuardaLogMail(ByVal cliente As String, ByVal mailbody As String, ByVal titulo As String, ByVal para As String) As Integer
        GuardaLogMail = 0
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.EXT_SP_NOTIFICACION"
            base.AddParrameter("@PROCESO", 1)
            base.AddParrameter("@SUBTIPO", "TURNO")
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@BODY_HTML", mailbody)
            base.AddParrameter("@TITULO", titulo)
            base.AddParrameter("@TIPO", "CLIENTE")
            base.AddParrameter("@PARA", para)
            base.EjecutaTransaction(cmd, tran)
            Tran.Commit()
            GuardaLogMail = 1
        Catch ex As Exception
            GuardaLogMail = 0
            Tran.Rollback()
            Throw ex
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 27/07/2015
    ''' DESCR: FUNCION PARA CONSULTAR RUTA PARA GUARDAR PDF GENERADO EN EL SERVER
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ConsultaRuta() As String
        Dim ds As New DataSet
        Dim ruta As String = ""
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 27)
            ds = base.Consulta("Extranet.SP_MANTENIMIENTO_TURNOS_WEB")
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ruta = ds.Tables(0).Rows(0).Item("RUTA_GUIA")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ruta
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 27/07/2015
    ''' DESCR: FUNCION PARA CONSULTAR RUTA PARA GUARDAR PDF GENERADO EN EL SERVER
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ConsultaDatosRecepcion(cliente As String, orden As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 28)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@NUMERO_O_S", orden)
            ds = base.Consulta("Extranet.SP_MANTENIMIENTO_TURNOS_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    'Public Shared Function ActualizaTurno_3S_NS(ByVal vehiculo As String, ByVal turno_3s As String, ByVal cadena As String, ByVal cliente_ns As String,
    '                                            ByVal orden_ns As String, ByVal turno_ns As String) As Boolean
    '    ActualizaTurno_3S_NS = True
    '    Dim base As New DataBaseApp.CommandApp
    '    Dim cnn As SqlClient.SqlConnection = Nothing
    '    Dim cmd As SqlClient.SqlCommand = Nothing
    '    Dim tran As SqlClient.SqlTransaction = Nothing
    '    Try
    '        cmd = New SqlClient.SqlCommand
    '        cnn = base.Connection
    '        cnn.Open()
    '        cmd.CommandTimeout = 1000
    '        cmd.Connection = cnn
    '        tran = cnn.BeginTransaction()
    '        base.ClearParrameter(cmd)
    '        base.ProcedureName = "Extranet.SP_MANTENIMIENTO_TURNOS_WEB"
    '        base.AddParrameter("@PROCESO", 29)
    '        base.AddParrameter("@VEHICULO", vehiculo)
    '        base.AddParrameter("@ATENCION_TURNO_ID", turno_3s)
    '        base.AddParrameter("@CADENA_NETSUITE", cadena)
    '        base.AddParrameter("@CUSTOMER_NETSUITE", cliente_ns)
    '        base.AddParrameter("@ORDEN_NETSUITE", orden_ns)
    '        base.AddParrameter("@TURNO_NETSUITE", turno_ns)
    '        base.EjecutaTransaction(cmd, tran)
    '        tran.Commit()
    '    Catch ex As Exception
    '        ActualizaTurno_3S_NS = False
    '        tran.Rollback()
    '        Throw ex
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Function

End Class
