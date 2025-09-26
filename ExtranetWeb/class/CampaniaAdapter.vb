Public Class CampaniaAdapter


    Public Shared Function ConsultaDatosCampanias(ByVal identificacion As String, ByVal codigo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@CLIENTE", identificacion)
            'base.AddParrameter("@VEHICULO", codigoveh)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CAMPANIAS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function GrabaDatosCampanias(ByVal codigocam As String, ByVal descripcion As String, ByVal fechaini As String, fechafin As String, ruta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "200")
            base.AddParrameter("@CODIGO", codigocam)
            base.AddParrameter("@DESCRIPCION", descripcion)
            base.AddParrameter("@FECHAINI", fechaini)
            base.AddParrameter("@FECHAFIN", fechafin)
            base.AddParrameter("@RUTA", ruta)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CAMPANIAS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaDatosCampaniaEspecifico(ByVal identificacion As String, ByVal descripcion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@DESCRIPCION", descripcion)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CAMPANIAS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

End Class
