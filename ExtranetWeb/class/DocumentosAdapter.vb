Public Class DocumentosAdapter

    Public Shared Function ConsultaDocumentos(ByVal usuario As String, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 101)
            base.AddParrameter("@CODIGO_REFERENCIAL", usuario)
            base.AddParrameter("@FECHA_INI", fechaini)
            base.AddParrameter("@FECHA_FIN", fechafin)
            ds = base.Consulta("EXTRANET.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaData(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@CODIGO_REFERENCIAL", usuario)
            ds = base.Consulta("EXTRANET.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaAvanzada(ByVal usuario As String, ByVal criterio As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 102)
            base.AddParrameter("@CODIGO_REFERENCIAL", usuario)
            base.AddParrameter("@CRIT_BUSQ", criterio)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaNombre(ByVal usuario As String, ByVal documentoId As String, ByVal proceso As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@DOCUMENTO_ID", documentoId)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaRuta() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", 114)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function LeerFactura(ByVal usuario As String, ByVal documentoId As String, ByVal proceso As String, ByVal usuarioid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CODIGO_REFERENCIAL", usuario)
            base.AddParrameter("@DOCUMENTO_ID", documentoId)
            base.AddParrameter("@USUARIO", usuarioid)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function EnvioFacturaCorreo(ByVal usuario As String, ByVal documentoId As String, ByVal mail As String, ByVal proceso As String, ByVal usuarioid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@DOCUMENTO_ID", documentoId)
            base.AddParrameter("@ENVIO_MAIL", mail)
            base.AddParrameter("@CODIGO_REFERENCIAL", usuario)
            base.AddParrameter("@USUARIO", usuarioid)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function LeerFacturaEmail(ByVal usuario As String, ByVal documentoId As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@CODIGO_REFERENCIAL", usuario)
            base.AddParrameter("@DOCUMENTO_ID", documentoId)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO_EMAIL")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaSucursal(ByVal proceso As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaParametrosFactura(ByVal proceso As String, ByVal codigo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CODIGO_ID", codigo)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO_DATOS_FACTURA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaFactura(ByVal proceso As String, ByVal sucursal As String, ByVal empresa As String, ByVal movimiento As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CODIGO_EMPRESA", empresa)
            base.AddParrameter("@SUCURSAL_OPERACION", sucursal)
            base.AddParrameter("@NUMERO_MOVIMIENTO", movimiento)
            ds = base.Consulta("Extranet.EXT_SP_DOCUMENTO_ELECTRONICO_DATOS_FACTURA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosDA(proceso As String, clienteid As String, vehiculoid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@CLIENTE", clienteid)
            base.AddParrameter("@VEHICULOS_DA", vehiculoid)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaRutaPdfDA() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@PROCESO", "108")
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosDocDA(proceso As String, orden As String, vehiculoid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@FILTROLIKE", orden)
            base.AddParrameter("@VEHICULOS_DA", vehiculoid)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_RENOVACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' FECHA: 04/04/2018
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: CONSULTA PARA LA PAGINA DE EMISION DE CERTIFICADOS
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="contrato"></param>
    ''' <param name="opcion"></param>
    ''' <param name="texto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDocumentosMaresa(ByVal usuario As String, ByVal contrato As Integer, ByVal opcion As Integer, Optional ByVal texto As String = "") As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@IDCLIENTE", usuario)
            base.AddParrameter("@CONTRATO", contrato)
            base.AddParrameter("@TEXTO", texto)
            ds = base.Consulta("VENTA.SP_CONSULTA_CERTIFICADO_MARESA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

End Class
