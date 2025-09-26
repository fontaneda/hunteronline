Imports System.Data

Public Class ControlTaller

    Function Datos_Login_Usuario(ByVal usuario As String) As DataSet
        Datos_Login_Usuario = Nothing
        Try
            Dim base As New DataBaseApp.CommandApp
            Dim ds As New DataSet
            base.AddParrameter("@samaccountname", usuario)
            'ds = base.Consulta("Intranet.SP_USUARIOS_DOMINIO")
            ds = base.Consulta("Intranet.SP_USUARIOS_DOMINIO2")
            If ds.Tables.Count > 0 Then
                ds.Tables(0).TableName = "DATOS_USUARIO_LOGIN"
            End If
            Datos_Login_Usuario = ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ConsultaGeneral(opcion As Integer, fecha_ini As Date, fecha_fin As Date, _
                         parametro As String) As DataSet
        ConsultaGeneral = Nothing
        Try
            Dim base As New DataBaseApp.CommandApp
            Dim ds As New DataSet
            base.AddParrameter("@PROCESO", 1)
            'base.AddParrameter("@USUARIO_ID", usuario)
            If opcion = 1 Then
                base.AddParrameter("@FECHA_INI", fecha_ini)
                base.AddParrameter("@FECHA_FIN", fecha_fin)
            ElseIf opcion = 2 Then
                base.AddParrameter("@ORDEN_NUMERO", parametro)
            ElseIf opcion = 3 Then
                base.AddParrameter("@VEHICULO_ID", parametro)
            ElseIf opcion = 4 Then
                base.AddParrameter("@PLACA", parametro)
            ElseIf opcion = 5 Then
                base.AddParrameter("@CLIENTE_ID", parametro)
            End If

            ds = base.Consulta("DBO.SP_CONSULTA_WEB_TALLER_CONTROL_CALIDAD")
            If ds.Tables.Count > 0 Then
                ds.Tables(0).TableName = "ConsultaGeneral"
            End If
            ConsultaGeneral = ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ConsultaDetalle(codigo As Integer) As DataSet
        ConsultaDetalle = Nothing
        Try
            Dim base As New DataBaseApp.CommandApp
            Dim ds As New DataSet
            base.AddParrameter("@PROCESO", 2)
            'base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@CODIGO_CONTROLCAL", codigo)

            ds = base.Consulta("DBO.SP_CONSULTA_WEB_TALLER_CONTROL_CALIDAD")
            If ds.Tables.Count > 0 Then
                ds.Tables(0).TableName = "ConsultaGeneral"
            End If
            ConsultaDetalle = ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ConsultaImagen(codigo As Integer) As DataSet
        ConsultaImagen = Nothing
        Try
            Dim base As New DataBaseApp.CommandApp
            Dim ds As New DataSet
            base.AddParrameter("@PROCESO", 3)
            'base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@CODIGO_CONTROLCAL", codigo)

            ds = base.Consulta("DBO.SP_CONSULTA_WEB_TALLER_CONTROL_CALIDAD")
            If ds.Tables.Count > 0 Then
                ds.Tables(0).TableName = "ConsultaGeneral"
            End If
            ConsultaImagen = ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ConsultaDocumento(opcion As Integer, parametro As String) As DataSet
        ConsultaDocumento = Nothing
        Try
            Dim base As New DataBaseApp.CommandApp
            Dim ds As New DataSet
            base.AddParrameter("@PROCESO", opcion)
            base.AddParrameter("@ORDEN_NUMERO", parametro)
            ds = base.Consulta("DBO.SP_CONSULTA_WEB_TALLER_CONTROL_CALIDAD")
            ConsultaDocumento = ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
