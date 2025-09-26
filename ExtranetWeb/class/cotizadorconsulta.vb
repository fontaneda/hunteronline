Public Class cotizadorconsulta

    Function GeneraEmailConfirmacion(ByVal opcion As Integer, ByVal estado As Integer, ByVal ordenpago As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@ESTADO", estado)
            base.AddParrameter("@ORDENSEC", ordenpago)
            ds = base.Consulta("dbo.SP_PROCESO_EMAIL_ORDEN_PAGO")
        Catch ex As Exception

        End Try
        Return ds
    End Function

    Function ConsultaDataCSVConciliacion(ByVal opcion As Integer, ByVal fecha As String)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@FECHACONCLARCHIVO", fecha)
            ds = base.Consulta("SP_PROCESO_CREACION_ORDEN_PAGO_ONLINE")
        Catch ex As Exception

        End Try
        Return ds
    End Function

End Class
