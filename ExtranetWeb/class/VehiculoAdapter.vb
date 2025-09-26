Public Class VehiculoAdapter

    Public Shared Function ConsultaDatosVehiculos(ByVal identificacion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosBienes(ByVal identificacion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "800")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosEspecifico(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            If codigoveh = "" Then
                base.AddParrameter("@PROCESO", "100")
            Else
                base.AddParrameter("@PROCESO", "200")
            End If
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosEspecificosinbaja(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            If codigoveh = "" Then
                base.AddParrameter("@PROCESO", "101")
            Else
                base.AddParrameter("@PROCESO", "201")
            End If
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosEspecificoconfiltro(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            If codigoveh = "" Then
                base.AddParrameter("@PROCESO", "800")
            Else
                base.AddParrameter("@PROCESO", "802")
            End If
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosBienconfiltro(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            If codigoveh = "" Then
                base.AddParrameter("@PROCESO", "800")
            Else
                base.AddParrameter("@PROCESO", "803")
            End If
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosGridBien(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            If codigoveh = "" Then
                base.AddParrameter("@PROCESO", "800")
            Else
                base.AddParrameter("@PROCESO", "900")
            End If
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosGridBienSinBaja(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            If codigoveh = "" Then
                base.AddParrameter("@PROCESO", "800")
            Else
                base.AddParrameter("@PROCESO", "901")
            End If
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosMarca(ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "300")
            'base.AddParrameter("@EMPRESA", "001")
            'base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosModelo(ByVal codigoveh As String, ByVal codigomar As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "400")
            'base.AddParrameter("@EMPRESA", "001")
            'base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            base.AddParrameter("@CODMARCA", codigomar)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosColor(ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "500")
            'base.AddParrameter("@EMPRESA", "001")
            'base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosAseguradora(ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "700")
            'base.AddParrameter("@EMPRESA", "001")
            'base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosProductosVehiculos(ByVal identificacion As String, ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "100")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@VEHICULO", codigoveh)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CHEQUEO_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosChequeosVehiculos(ByVal identificacion As String, ByVal codigoveh As String, ByVal producto As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@PRODUCTO", producto)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CHEQUEO_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosChequeosVehiculosProducto(ByVal identificacion As String, ByVal codigoveh As String, ByVal producto As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "104")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@PRODUCTO", producto)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_CHEQUEO_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaPlaca(ByVal codigoveh As String, ByVal placa As String)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@PLACA", placa)
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaMotor(ByVal codigoveh As String, ByVal motor As String)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "102")
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@MOTOR", motor)
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaChasis(ByVal codigoveh As String, ByVal chasis As String)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "103")
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@CHASIS", chasis)
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function GrabaDatosVehiculo(ByVal script_id As String, ByVal parametro As String) As String
        Dim retorno As String = ClaseConexionNetsuite.ActualizaNs(script_id, parametro)
        Return retorno
    End Function

    Public Shared Function GrabaBajaVehiculo(ByVal codigoveh As String, ByVal estado As Int16, ByVal usuarioId As String)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "200")
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@ESTADO", estado)
            base.AddParrameter("@USUARIO_ID", usuarioId)
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function GrabaNuevoPropietario(ByVal codigoveh As String, ByVal estado As Int16, ByVal usuarioId As String, ByVal nuevoPropietario As String, _
                                                 ByVal telefono As String)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "300")
            base.AddParrameter("@VEHICULO", codigoveh)
            base.AddParrameter("@ESTADO", estado)
            base.AddParrameter("@USUARIO_ID", usuarioId)
            base.AddParrameter("@NUEVO_PROPIETARIO", nuevoPropietario)
            base.AddParrameter("@TELEFONO", telefono)
            ds = base.Consulta("EXTRANET.EXT_SP_GRABA_VEHICULO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosBaja(ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "600")
            'base.AddParrameter("@EMPRESA", "001")
            'base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculoNuevoPropietario(ByVal codigoveh As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "610")
            'base.AddParrameter("@EMPRESA", "001")
            'base.AddParrameter("@CLIENTE", identificacion)
            base.AddParrameter("@CODIGO_VEHICULO", codigoveh.Trim)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaEmail(ByVal vehiculo As Decimal, ByVal proceso As String) As String
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Dim htmlBody As String
        Try
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@PROCESO", proceso)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_EMAIL_ACTUALIZA_VEHICULO")
            htmlBody = Convert.ToString(ds.Tables(0).Rows(0)("HTMLBODY"))
        Catch ex As Exception
            Throw ex
        End Try
        Return htmlBody
    End Function

    Public Shared Function ConsultaCiudad(ByVal vehiculo As Decimal, ByVal proceso As String) As String
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Dim ciudad As String
        Try
            base.AddParrameter("@VEHICULO", vehiculo)
            base.AddParrameter("@PROCESO", proceso)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_EMAIL_ACTUALIZA_VEHICULO")
            ciudad = Convert.ToString(ds.Tables(0).Rows(0)("CIUDAD"))
        Catch ex As Exception
            Throw ex
        End Try
        Return ciudad
    End Function

    Public Shared Function ConsultaDatosVehiculossinbaja(ByVal identificacion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "101")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVehiculosBienessinbaja(ByVal identificacion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "801")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CLIENTE", identificacion)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaCodigoVehiculo(ByVal chasis As String) As String
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Dim codigo As String = ""
        Try
            base.AddParrameter("@PROCESO", "813")
            base.AddParrameter("@EMPRESA", "001")
            base.AddParrameter("@CHASIS", chasis)
            ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VEHICULOS")
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    codigo = ds.Tables(0).Rows(0).Item("CODIGO_VEHICULO")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return codigo
    End Function

    Public Shared Function ConsultaCatalogoVehiculosNuevo() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "2")
            ds = base.Consulta("dbo.sp_carga_vehiculo_honline")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaCatalogoModeloVehiculosNuevo(ByVal marca As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "3")
            base.AddParrameter("@PARAMETRO_MARCA", marca)
            ds = base.Consulta("dbo.sp_carga_vehiculo_honline")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function ConsultaCatalogoTipoVehiculosNuevo(ByVal marca As String, ByVal modelo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "4")
            base.AddParrameter("@PARAMETRO_MARCA", marca)
            base.AddParrameter("@PARAMETRO_MODELO", modelo)
            ds = base.Consulta("dbo.sp_carga_vehiculo_honline")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function GrabaDatosVehiculoVenta(ByVal placa As String, ByVal financiera As String, ByVal aseguradora As String, ByVal concesionario As String, _
                                                   ByVal marca As String, ByVal modelo As String, ByVal tipo As String, ByVal color As String, ByVal motor As String, _
                                                   ByVal chasis As String, ByVal transmision As String, ByVal combustible As String, ByVal version As String, _
                                                   ByVal cabina As String, ByVal cilindraje As String, ByVal traccion As String, ByVal aire As String, _
                                                   ByVal puertas As String, ByVal anio As String, ByVal cliente As String) As Boolean
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@PROCESO", "1")
            base.AddParrameter("@PARAMETRO_PLACA", placa)
            base.AddParrameter("@PARAMETRO_RUCFINANCIERA", financiera)
            base.AddParrameter("@PARAMETRO_RUCASEGURADORA", aseguradora)
            base.AddParrameter("@PARAMETRO_RUCCONCESIONARIO", concesionario)
            base.AddParrameter("@PARAMETRO_MARCA", marca)
            base.AddParrameter("@PARAMETRO_MODELO", modelo)
            base.AddParrameter("@PARAMETRO_TIPO", tipo)
            base.AddParrameter("@PARAMETRO_COLOR", color)
            base.AddParrameter("@PARAMETRO_MOTOR", motor)
            base.AddParrameter("@PARAMETRO_CHASIS", chasis)
            base.AddParrameter("@PARAMETRO_TRANSMISION", transmision)
            base.AddParrameter("@PARAMETRO_TIPOCOMBUSTIBLE", combustible)
            base.AddParrameter("@PARAMETRO_VERSION", version)
            base.AddParrameter("@PARAMETRO_TIPOCABINA", cabina)
            base.AddParrameter("@PARAMETRO_CILINDRAJE", cilindraje)
            base.AddParrameter("@PARAMETRO_TIPOTRACCION", traccion)
            base.AddParrameter("@PARAMETRO_AACONDICIONADO", aire)
            base.AddParrameter("@PARAMETRO_NUMEROPUERTAS", puertas)
            base.AddParrameter("@PARAMETRO_ANIOFABRICA", anio)
            base.AddParrameter("@PARAMETRO_FECHA", Date.Now)
            base.AddParrameter("@CLIENTE_ID", cliente)
            ds = base.Consulta("dbo.sp_carga_vehiculo_honline")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class