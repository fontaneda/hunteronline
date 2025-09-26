Public Class posproceso

    Function PruebaPosProceso(ByVal opcion As Integer) As Int64

        PruebaPosProceso = 0

        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim Tran As SqlClient.SqlTransaction = Nothing
        Dim numcotizacion As Int64 = 0
        Dim codigoerror As Int64 = 0
        Dim msgerror As String = ""

        Try

            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            Tran = cnn.BeginTransaction()

            base.ClearParrameter(cmd)
            base.ProcedureName = "SP_PROCESO_CREACION_ORDEN_ONLINE"
            base.AddParrameter("@OPCION", opcion)
            base.EjecutaTransaction(cmd, Tran)
            'numcotizacion = Convert.ToInt64(cmd.Parameters("@NUMERO_GENERAL").Value)
            'codigoerror = Convert.ToInt64(cmd.Parameters("@CODIGO_ERROR").Value)
            'msgerror = Convert.ToString(cmd.Parameters("@MENSAJE_ERROR").Value)
            'If numcotizacion <> 0 Then
            '    PruebaPosProceso = numcotizacion
            'Else
            '    PruebaPosProceso = codigoerror
            'End If
            Tran.Commit()

        Catch ex As Exception

            PruebaPosProceso = -1
            'CapturaError(ex)
            Tran.Rollback()

            Throw ex
        End Try

    End Function

End Class