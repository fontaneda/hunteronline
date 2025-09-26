Public Class TransaccionAdapter


    Public Shared Function ConsultaOrdenPagoCabecera(ByVal ordenpago As Decimal) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@ORDERID", ordenpago)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_TRANSACCION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaOrdenPagoDetalle(ByVal ordenpago As Decimal) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "106")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@ORDERID", ordenpago)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_TRANSACCION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaOrdenServicioGenerada(ByVal ordenpago As Decimal) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "107")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@ORDERID", ordenpago)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_TRANSACCION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaOrdenPagoSinVerificar(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "108")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", cliente)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_TRANSACCION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaOrdenPagoConfirmadas(ByVal cliente As String, ByVal fechadesde As String, ByVal fechahasta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "110")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@FECHADESDE", fechadesde)
            base.AddParrameter("@FECHAHASTA", fechahasta)
            base.AddParrameter("@CLIENTE", cliente)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_TRANSACCION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


End Class