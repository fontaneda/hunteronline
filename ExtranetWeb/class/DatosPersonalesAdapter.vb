Public Class DatosPersonalesAdapter

#Region "Procedimientos para datos del cliente"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaProvincia() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "103")
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="provinciaid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaCiudad(ByVal provinciaid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "104")
            base.AddParrameter("@PROVINCIAID", provinciaid)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosPersonalesCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@ID_CLIENTE", usuario)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosChequeosCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@CLIENTE", usuario)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_CHEQUEO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <param name="dato1"></param>
    ''' <param name="datonew1"></param>
    ''' <param name="dato3"></param>
    ''' <param name="datonew2"></param>
    ''' <param name="dato5"></param>
    ''' <param name="datonew3"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosPersonalesMail(ByVal cliente As String, ByVal dato1 As String, ByVal datonew1 As String, ByVal dato3 As String, ByVal datonew2 As String, _
                                                       ByVal dato5 As String, ByVal datonew3 As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@COD_REFERENCIAL", cliente)
            base.AddParrameter("@DATOOLD1", dato1)
            base.AddParrameter("@DATONEW1", datonew1)
            base.AddParrameter("@DATOOLD2", dato3)
            base.AddParrameter("@DATONEW2", datonew2)
            base.AddParrameter("@DATOOLD3", dato5)
            base.AddParrameter("@DATONEW3", datonew3)
            ds = base.Consulta("Extranet.EXT_SP_EMAIL_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <param name="dato1"></param>
    ''' <param name="datonew1"></param>
    ''' <param name="dato2"></param>
    ''' <param name="datonew2"></param>
    ''' <param name="dato3"></param>
    ''' <param name="datonew3"></param>
    ''' <param name="dato4"></param>
    ''' <param name="datonew4"></param>
    ''' <param name="dato5"></param>
    ''' <param name="datonew5"></param>
    ''' <param name="dato6"></param>
    ''' <param name="datonew6"></param>
    ''' <param name="dato7"></param>
    ''' <param name="datonew7"></param>
    ''' <param name="dato8"></param>
    ''' <param name="datonew8"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosMail(ByVal cliente As String, ByVal dato1 As String, ByVal datonew1 As String, ByVal dato2 As String, ByVal datonew2 As String, _
                                             ByVal dato3 As String, ByVal datonew3 As String, ByVal dato4 As String, ByVal datonew4 As String, ByVal dato5 As String, _
                                             ByVal datonew5 As String, ByVal dato6 As String, ByVal datonew6 As String, ByVal dato7 As String, ByVal datonew7 As String, _
                                             ByVal dato8 As String, ByVal datonew8 As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@COD_REFERENCIAL", cliente)
            base.AddParrameter("@DATOOLD1", dato1)
            base.AddParrameter("@DATONEW1", datonew1)
            base.AddParrameter("@DATOOLD2", dato2)
            base.AddParrameter("@DATONEW2", datonew2)
            base.AddParrameter("@DATOOLD3", dato3)
            base.AddParrameter("@DATONEW3", datonew3)
            base.AddParrameter("@DATOOLD4", dato4)
            base.AddParrameter("@DATONEW4", datonew4)
            base.AddParrameter("@DATOOLD5", dato5)
            base.AddParrameter("@DATONEW5", datonew5)
            base.AddParrameter("@DATOOLD6", dato6)
            base.AddParrameter("@DATONEW6", datonew6)
            base.AddParrameter("@DATOOLD7", dato7)
            base.AddParrameter("@DATONEW7", datonew7)
            base.AddParrameter("@DATOOLD8", dato8)
            base.AddParrameter("@DATONEW8", datonew8)
            ds = base.Consulta("Extranet.EXT_SP_EMAIL_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <param name="dato1"></param>
    ''' <param name="datonew1"></param>
    ''' <param name="dato2"></param>
    ''' <param name="datonew2"></param>
    ''' <param name="dato3"></param>
    ''' <param name="datonew3"></param>
    ''' <param name="dato4"></param>
    ''' <param name="datonew4"></param>
    ''' <param name="dato5"></param>
    ''' <param name="datonew5"></param>
    ''' <param name="dato6"></param>
    ''' <param name="datonew6"></param>
    ''' <param name="dato7"></param>
    ''' <param name="datonew7"></param>
    ''' <param name="dato8"></param>
    ''' <param name="datonew8"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosFacturacionMail(ByVal cliente As String, ByVal dato1 As String, ByVal datonew1 As String, ByVal dato2 As String, ByVal datonew2 As String, _
                                                        ByVal dato3 As String, ByVal datonew3 As String, ByVal dato4 As String, ByVal datonew4 As String, ByVal dato5 As String, _
                                                        ByVal datonew5 As String, ByVal dato6 As String, ByVal datonew6 As String, ByVal dato7 As String, ByVal datonew7 As String, _
                                                        ByVal dato8 As String, ByVal datonew8 As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@COD_REFERENCIAL", cliente)
            base.AddParrameter("@DATOOLD1", dato1)
            base.AddParrameter("@DATONEW1", datonew1)
            base.AddParrameter("@DATOOLD2", dato2)
            base.AddParrameter("@DATONEW2", datonew2)
            base.AddParrameter("@DATOOLD3", dato3)
            base.AddParrameter("@DATONEW3", datonew3)
            base.AddParrameter("@DATOOLD4", dato4)
            base.AddParrameter("@DATONEW4", datonew4)
            base.AddParrameter("@DATOOLD5", dato5)
            base.AddParrameter("@DATONEW5", datonew5)
            base.AddParrameter("@DATOOLD6", dato6)
            base.AddParrameter("@DATONEW6", datonew6)
            base.AddParrameter("@DATOOLD7", dato7)
            base.AddParrameter("@DATONEW7", datonew7)
            base.AddParrameter("@DATOOLD8", dato8)
            base.AddParrameter("@DATONEW8", datonew8)
            ds = base.Consulta("Extranet.EXT_SP_EMAIL_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosDomicilioCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@TIPODIRECCION", "002") 'DOMICILIO
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosOficinaCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@TIPODIRECCION", "001") 'OFICINA
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosFacturacionCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@TIPODIRECCION", "018") 'DIR. DE FACTURACION
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaPromocion(ByVal fecha As Date, ByVal tipo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@FECHA", fecha)
            base.AddParrameter("@NEMONICO", tipo)
            ds = base.Consulta("Extranet.EXT_SP_PROMOCIONES_WEB")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="idcliente"></param>
    ''' <param name="codigo"></param>
    ''' <param name="tipo"></param>
    ''' <param name="orden"></param>
    ''' <param name="promocion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GeneraEmailPromocion(ByVal idcliente As String, ByVal codigo As String, ByVal tipo As String, ByVal orden As String, ByVal promocion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@CODIGO_CLIENTE", idcliente)
            base.AddParrameter("@TIPO_PROMOCION", tipo)
            base.AddParrameter("@PROMOCION", promocion)
            If tipo = "001" Then
                base.AddParrameter("@PARTICIPACION", codigo)
                base.AddParrameter("@ORDEN_ID", orden)
            Else
                base.AddParrameter("@NUMERO_PARTICIPACION", codigo)
            End If
            ds = base.Consulta("Extranet.EXT_SP_PROMOCIONES_WEB")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosInfoHunterCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@TIPODIRECCION", "003") 'INFO-HUNTER
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosDireccionCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@ESBUSQUEDA", "S")
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosCliente(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "108")
            base.AddParrameter("@CRIT_BUSQ", cliente)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="filtro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosVehiculo(ByVal filtro As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "114")
            base.AddParrameter("@CRIT_BUSQ", filtro)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosTelefonoCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "107")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@ESBUSQUEDA", "S")
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="tipotelefono"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosTelefonoCliente(ByVal usuario As String, ByVal tipotelefono As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "107")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@ESBUSQUEDA", "S")
            base.AddParrameter("@TIPOTELEFONO", tipotelefono)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="secuencial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosDireccionCliente(ByVal usuario As String, ByVal secuencial As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "105")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@SECUENCIAL", secuencial)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaDatosEmailCliente(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "106")
            base.AddParrameter("@ID_CLIENTE", usuario)
            base.AddParrameter("@ESBUSQUEDA", "S")
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaTotalFacturas(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "109")
            base.AddParrameter("@ID_CLIENTE", usuario)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="proceso"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DatosPersonalesCliente(ByVal usuario As String, ByVal proceso As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", proceso)
            base.AddParrameter("@ID_CLIENTE", usuario)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaTipo(ByVal tipo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "117")
            base.AddParrameter("@TIPOCOMPANIA", tipo)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="tabla"></param>
    ''' <param name="clienteId"></param>
    ''' <param name="usuarioId"></param>
    ''' <remarks></remarks>
    Public Shared Sub ModificarClienteWeb(ByVal tabla As DataTable, ByVal clienteId As String, ByVal usuarioId As String)
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
            If tabla.Rows.Count > 0 Then
                For i As Integer = 0 To tabla.Rows.Count - 1
                    base.ClearParrameter(cmd)
                    base.ProcedureName = "Extranet.EXT_SP_GRABA_DATOS_PERSONALES_WEB"
                    base.AddParrameter("@USUARIO_ID", usuarioId)
                    base.AddParrameter("@TIPO", tabla.Rows(i).Item("tipo"))
                    base.AddParrameter("@REFERENCIA", tabla.Rows(i).Item("referencia"))
                    base.AddParrameter("@CAMPO", tabla.Rows(i).Item("campo"))
                    base.AddParrameter("@CLIENTE_ID", clienteId)
                    base.EjecutaTransaction(cmd, tran)
                Next
            End If
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="emisosrid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaBanco(ByVal emisosrid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "125")
            base.AddParrameter("@CRIT_BUSQ", emisosrid)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

#End Region

#Region "Procedimientos cliente monitoreo"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaBusquedaClienteMonitoreo(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "118")
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaBusquedaCatalogosMonitoreo() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "119")
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaBusquedaClienteMonitoreoDatos(ByVal cliente As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "124")
            base.AddParrameter("@ID_CLIENTE", cliente)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <param name="pais"></param>
    ''' <param name="provincia"></param>
    ''' <param name="ciudad"></param>
    ''' <param name="tipoentidad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaBusquedaSubCatalogosMonitoreo(ByVal opcion As String, ByVal pais As String, ByVal provincia As String, _
                                                                 ByVal ciudad As String, ByVal tipoentidad As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", opcion)
            base.AddParrameter("@CRIT_BUSQ", pais)
            base.AddParrameter("@PROVINCIAID", provincia)
            base.AddParrameter("@CIUDADID", ciudad)
            base.AddParrameter("@ESBUSQUEDA", tipoentidad)
            ds = base.Consulta("Extranet.EXT_SP_CONSULTA_DATOS_PERSONALES")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: INGRESOS A BASE
    ''' </summary>
    ''' <param name="ClienteEntity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RegistroCliente(ByVal ClienteEntity As ClienteEntity) As Boolean
        Dim retorno As Boolean = False
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
            base.ProcedureName = "EXTRANET.EXT_SP_INGRESA_DATOS_PERSONALES"
            base.AddParrameter("@OPCION", 1)
            base.AddParrameter("@IDCLIENTE", ClienteEntity.ClienteId)
            base.AddParrameter("@TIPOIDENTIFICACION", ClienteEntity.ClienteTipoIdentificacion)
            base.AddParrameter("@APELLIDOMATERNO", ClienteEntity.ClienteApellidoMadre)
            base.AddParrameter("@APELLIDOPATERNO", ClienteEntity.ClienteApellidoPadre)
            base.AddParrameter("@PRIMERNOMBRE", ClienteEntity.ClienteNombrePrimero)
            base.AddParrameter("@SEGUNDONOMBRE", ClienteEntity.ClienteNombreSegundo)
            base.AddParrameter("@FECHANACIMIENTO", ClienteEntity.ClienteNacimiento)
            base.AddParrameter("@SEXO", ClienteEntity.ClienteSexo)
            base.AddParrameter("@USUARIO", 1)
            'base.AddParrameter("@ACTIVIDADID", ClienteEntity.ClienteActividad)
            'base.AddParrameter("@EXCENTO", "N")
            'base.AddParrameter("@ESTADOCIVIL", ClienteEntity.ClienteEstadocivil)
            'base.AddParrameter("@PROFESION", ClienteEntity.ClienteProfesion)
            'base.AddParrameter("@OFICINA", "001")
            'base.AddParrameter("@FILIAL", "")
            'base.AddParrameter("@TIPOCLIENTE", ClienteEntity.ClienteTipo)
            'base.AddParrameter("@CLIENTEKEEPER", "N")
            'base.AddParrameter("@CLIENTEGEOSYS", "S")
            base.EjecutaTransaction(cmd, tran)
            For Each ClienteDetalleEntity As ClienteDetalleEntity In ClienteEntity.ClienteDetalleEntityCollection
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.EXT_SP_INGRESA_DATOS_PERSONALES"
                base.AddParrameter("@OPCION", 2)
                base.AddParrameter("@IDCLIENTE", ClienteEntity.ClienteId)
                base.AddParrameter("@IDPROVINCIA", ClienteDetalleEntity.DireccionProvinciaId)
                base.AddParrameter("@IDCIUDAD", ClienteDetalleEntity.DireccionCiudadId)
                base.AddParrameter("@IDZONA", "")
                base.AddParrameter("@SECTORCIUDADELA", ClienteDetalleEntity.DireccionSectorId)
                base.AddParrameter("@PRINCIPAL", ClienteDetalleEntity.Direccion)
                base.AddParrameter("@PREDETERMINADA", "S")
                base.AddParrameter("@IDPARROQUIA", ClienteDetalleEntity.DireccionParroquiaId)
                base.AddParrameter("@INTERSECCION", ClienteDetalleEntity.DireccionInterseccion)
                base.AddParrameter("@NUMERO", ClienteDetalleEntity.DireccionNumero)
                base.AddParrameter("@TELEFONO", ClienteDetalleEntity.Telefono)
                base.AddParrameter("@EMAIL_PRINCIPAL", ClienteDetalleEntity.EmailPrincipal)
                base.AddParrameter("@EMAIL_ALERTA", ClienteDetalleEntity.EmailAlerta)
                'base.AddParrameter("@TIPODIRECCION", ClienteDetalleEntity.DireccionTipo)
                'base.AddParrameter("@IDPAIS", ClienteDetalleEntity.DireccionPaisId)
                'base.AddParrameter("@CODIGOTELEFONO", "")
                'base.AddParrameter("@TIPOTELEFONO", ClienteDetalleEntity.TelefonoTipo)
                'ingresos de mail principal y alerta
                'base.AddParrameter("@EXTENSION", ClienteDetalleEntity.TelefonoExtension)
                ''REF BANCARIA
                'base.AddParrameter("@REFERENCIABANCARIA", ClienteDetalleEntity.EntidadTipo)
                'base.AddParrameter("@CODIGOREFERENCIA", ClienteDetalleEntity.Entidad)
                'base.AddParrameter("@NUMEROREFERENCIA", ClienteDetalleEntity.EntidadNumero)
                'base.AddParrameter("@TIPOREFERENCIA", "")
                ''PARIENTE
                'base.AddParrameter("@PARENTEZCO", ClienteDetalleEntity.ParienteTipo)
                'base.AddParrameter("@CONTAPELLIDOPATERNO", ClienteDetalleEntity.ParienteApellidoPaterno)
                'base.AddParrameter("@CONTAPELLIDOMATERNO", ClienteDetalleEntity.ParienteApellidoMaterno)
                'base.AddParrameter("@NOMBRE", ClienteDetalleEntity.ParienteNombres)
                'base.AddParrameter("@FECHANACIMIENTO", ClienteDetalleEntity.ParienteFechaNacimiento)
                'base.AddParrameter("@DIRECCION", ClienteDetalleEntity.ParienteDireccion)
                'base.AddParrameter("@CONTTELEFONO", ClienteDetalleEntity.ParienteTelefono)
                base.EjecutaTransaction(cmd, tran)
            Next
            tran.Commit()
            retorno = True
        Catch ex As Exception
            tran.Rollback()
            retorno = False
            Throw ex
        End Try
        Return retorno
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: INGRESOS A BASE
    ''' </summary>
    ''' <param name="idcliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RegistroClienteSH(ByVal idcliente As String) As Boolean
        Dim retorno As Boolean = False
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
            base.ProcedureName = "EXTRANET.EXT_SP_INGRESA_DATOS_PERSONALES"
            base.AddParrameter("@OPCION", 3)
            base.AddParrameter("@IDCLIENTE", idcliente)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
            retorno = True
        Catch ex As Exception
            tran.Rollback()
            retorno = False
            Throw ex
        End Try
        Return retorno
    End Function

    Public Shared Function RegistroClienteFACTURA(ByVal ClienteEntity As ClienteEntity) As Boolean
        Dim retorno As Boolean = False
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
            base.ProcedureName = "EXTRANET.EXT_SP_INGRESA_DATOS_PERSONALES_FACTURA"
            base.AddParrameter("@OPCION", 1)
            base.AddParrameter("@IDCLIENTE", ClienteEntity.ClienteId)
            base.AddParrameter("@TIPOIDENTIFICACION", ClienteEntity.ClienteTipoIdentificacion)
            base.AddParrameter("@APELLIDOMATERNO", ClienteEntity.ClienteApellidoMadre)
            base.AddParrameter("@APELLIDOPATERNO", ClienteEntity.ClienteApellidoPadre)
            base.AddParrameter("@PRIMERNOMBRE", ClienteEntity.ClienteNombrePrimero)
            base.AddParrameter("@SEGUNDONOMBRE", ClienteEntity.ClienteNombreSegundo)
            base.AddParrameter("@FECHANACIMIENTO", ClienteEntity.ClienteNacimiento)
            base.AddParrameter("@SEXO", ClienteEntity.ClienteSexo)
            base.AddParrameter("@USUARIO", 1)
            'base.AddParrameter("@ACTIVIDADID", ClienteEntity.ClienteActividad)
            'base.AddParrameter("@EXCENTO", "N")
            'base.AddParrameter("@ESTADOCIVIL", ClienteEntity.ClienteEstadocivil)
            'base.AddParrameter("@PROFESION", ClienteEntity.ClienteProfesion)
            'base.AddParrameter("@OFICINA", "001")
            'base.AddParrameter("@FILIAL", "")
            'base.AddParrameter("@TIPOCLIENTE", ClienteEntity.ClienteTipo)
            'base.AddParrameter("@CLIENTEKEEPER", "N")
            'base.AddParrameter("@CLIENTEGEOSYS", "S")
            base.EjecutaTransaction(cmd, tran)
            For Each ClienteDetalleEntity As ClienteDetalleEntity In ClienteEntity.ClienteDetalleEntityCollection
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.EXT_SP_INGRESA_DATOS_PERSONALES_FACTURA"
                base.AddParrameter("@OPCION", 2)
                base.AddParrameter("@IDCLIENTE", ClienteEntity.ClienteId)
                base.AddParrameter("@IDPROVINCIA", ClienteDetalleEntity.DireccionProvinciaId)
                base.AddParrameter("@IDCIUDAD", ClienteDetalleEntity.DireccionCiudadId)
                base.AddParrameter("@IDZONA", "")
                base.AddParrameter("@SECTORCIUDADELA", ClienteDetalleEntity.DireccionSectorId)
                base.AddParrameter("@PRINCIPAL", ClienteDetalleEntity.Direccion)
                base.AddParrameter("@PREDETERMINADA", "S")
                base.AddParrameter("@IDPARROQUIA", ClienteDetalleEntity.DireccionParroquiaId)
                base.AddParrameter("@INTERSECCION", ClienteDetalleEntity.DireccionInterseccion)
                base.AddParrameter("@NUMERO", ClienteDetalleEntity.DireccionNumero)
                base.AddParrameter("@TELEFONO", ClienteDetalleEntity.Telefono)
                base.AddParrameter("@EMAIL_PRINCIPAL", ClienteDetalleEntity.EmailPrincipal)
                base.AddParrameter("@CELULAR", ClienteDetalleEntity.TelefonoCelular)
                'base.AddParrameter("@TIPODIRECCION", ClienteDetalleEntity.DireccionTipo)
                'base.AddParrameter("@IDPAIS", ClienteDetalleEntity.DireccionPaisId)
                'base.AddParrameter("@CODIGOTELEFONO", "")
                'base.AddParrameter("@TIPOTELEFONO", ClienteDetalleEntity.TelefonoTipo)
                'ingresos de mail principal y alerta
                'base.AddParrameter("@EXTENSION", ClienteDetalleEntity.TelefonoExtension)
                ''REF BANCARIA
                'base.AddParrameter("@REFERENCIABANCARIA", ClienteDetalleEntity.EntidadTipo)
                'base.AddParrameter("@CODIGOREFERENCIA", ClienteDetalleEntity.Entidad)
                'base.AddParrameter("@NUMEROREFERENCIA", ClienteDetalleEntity.EntidadNumero)
                'base.AddParrameter("@TIPOREFERENCIA", "")
                ''PARIENTE
                'base.AddParrameter("@PARENTEZCO", ClienteDetalleEntity.ParienteTipo)
                'base.AddParrameter("@CONTAPELLIDOPATERNO", ClienteDetalleEntity.ParienteApellidoPaterno)
                'base.AddParrameter("@CONTAPELLIDOMATERNO", ClienteDetalleEntity.ParienteApellidoMaterno)
                'base.AddParrameter("@NOMBRE", ClienteDetalleEntity.ParienteNombres)
                'base.AddParrameter("@FECHANACIMIENTO", ClienteDetalleEntity.ParienteFechaNacimiento)
                'base.AddParrameter("@DIRECCION", ClienteDetalleEntity.ParienteDireccion)
                'base.AddParrameter("@CONTTELEFONO", ClienteDetalleEntity.ParienteTelefono)
                base.EjecutaTransaction(cmd, tran)
            Next
            tran.Commit()
            retorno = True
        Catch ex As Exception
            tran.Rollback()
            retorno = False
            Throw ex
        End Try
        Return retorno
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' DESCR: CONSULTAS A BASE
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ValidaCedula(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@IDENTIFICACION", usuario)
            base.AddParrameter("@OPCION", 1)
            ds = base.Consulta("DBO.SP_VALIDA_IDENTIFICACION")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function



#End Region

End Class