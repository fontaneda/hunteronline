Public Class SolicitudActualizacionAdapter


    Public Shared Sub RegistroDatosPersonales(ByVal idcliente As String, ByVal email1 As String, ByVal email2 As String, ByVal fechanacimiento As DateTime)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        'Dim numcotizacion As Int64 = 0
        'Dim codigoerror As Int64 = 0
        'Dim msgerror As String = ""
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.EXT_SP_GRABA_DATOS_PERSONALES"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@ID_CLIENTE", idcliente)
            base.AddParrameter("@FECHA_NACIMIENTO", fechanacimiento)
            base.AddParrameter("@ORIGEN", "D")
            base.EjecutaTransaction(cmd, tran)
            If Not String.IsNullOrEmpty(email1) Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "Extranet.EXT_SP_GRABA_DATOS_PERSONALES"
                base.AddParrameter("@PROCESO", 101)
                base.AddParrameter("@TIPO_DIRECCION", "004")
                base.AddParrameter("@ID_CLIENTE", idcliente)
                base.AddParrameter("@EMAIL", email1)
                base.AddParrameter("@ORIGEN", "D")
                base.EjecutaTransaction(cmd, tran)
            End If
            If Not String.IsNullOrEmpty(email2) Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "Extranet.EXT_SP_GRABA_DATOS_PERSONALES"
                base.AddParrameter("@PROCESO", 101)
                base.AddParrameter("@TIPO_DIRECCION", "016")
                base.AddParrameter("@ID_CLIENTE", idcliente)
                base.AddParrameter("@EMAIL", email2)
                base.EjecutaTransaction(cmd, tran)
            End If
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub


    Public Shared Function RegistroDatosDireccion(ByVal script_id As String, ByVal parametro As String, transaccion As String) As String
        Dim retorno As String = ""
        If transaccion = "update" Then
            retorno = ClaseConexionNetsuite.ActualizaNs(script_id, parametro)
        ElseIf transaccion = "insert" Then
            retorno = ClaseConexionNetsuite.enviar_datos_netsuite(script_id, parametro, 1)
        End If
        Return retorno
    End Function


    Public Shared Function RegistroPromocion(ByVal idcliente As String, ByVal origen As String, ByVal tipopromocion As String, ByVal promocion As String, ByVal vehiculo As String, ByVal orden As String)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Dim codigo As String = Nothing
        RegistroPromocion = ""
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.EXT_SP_PROMOCIONES_WEB"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@CODIGO_CLIENTE", idcliente)
            base.AddParrameter("@TIPO_PROMOCION", tipopromocion)
            base.AddParrameter("@PROMOCION", promocion)
            base.AddParrameter("@ORIGEN", origen)
            base.AddParrameter("@ORDEN_ID", orden)
            base.AddParrameter("@VEHICULO_ID", vehiculo)
            base.EjecutaTransaction(cmd, tran)
            If tipopromocion = "001" Then
                codigo = Convert.ToString(cmd.Parameters("@PARTICIPACION").Value)
            Else
                codigo = Convert.ToString(cmd.Parameters("@NUMERO_PARTICIPACION").Value)
            End If
            If codigo <> "" Then
                RegistroPromocion = codigo
            Else
                RegistroPromocion = ""
            End If
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Function


End Class
