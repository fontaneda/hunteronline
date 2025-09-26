Public Class clsencuesta

    Public Shared Function ConsultaPregunta(ByVal codigo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 1)
            base.AddParrameter("@CODIGO_ENCUESTA", codigo)
            ds = base.Consulta("EXTRANET.ENC_SP_ENCUESTA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaDetallePregunta(ByVal codigo As String, ByVal preguntaid As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 3)
            base.AddParrameter("@CODIGO_ENCUESTA", codigo)
            base.AddParrameter("@CODIGO_PREGUNTA", preguntaid)
            ds = base.Consulta("EXTRANET.ENC_SP_ENCUESTA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function ConsultaEncuesta(ByVal codigo As String, ByVal cliente As String, ByVal vehiculo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 9)
            'base.AddParrameter("@OPCION", 8)
            base.AddParrameter("@CODIGO_ENCUESTA", codigo)
            base.AddParrameter("@CODIGO_CLIENTE", cliente)
            base.AddParrameter("@CODIGO_VEHICULO", vehiculo)
            ds = base.Consulta("EXTRANET.ENC_SP_ENCUESTA")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

    Public Shared Function Grabaparticipante(ByVal cedula As String, ByVal comentario As String, ByVal codEncuesta As String, ByVal resp0 As String, ByVal codigoresp0 As String, _
                                             ByVal resp1 As String, ByVal codigoresp1 As String, ByVal resp2 As String, ByVal codigoresp2 As String, ByVal resp3 As String, ByVal codigoresp3 As String, _
                                             ByVal resp4 As String, ByVal codigoresp4 As String, ByVal resp5 As String, ByVal codigoresp5 As String) As Boolean
        Grabaparticipante = False
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
            base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
            base.AddParrameter("@OPCION", 4)
            base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
            base.AddParrameter("@CODIGO_CLIENTE", cedula)
            base.EjecutaTransaction(cmd, tran)
            Dim resultado As String = ""
            resultado = Convert.ToString(cmd.Parameters("@ID_RESPUESTA").Value)

            If codigoresp0 <> "0" Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
                base.AddParrameter("@OPCION", 5)
                base.AddParrameter("@ID_RESULTADO", resultado)
                base.AddParrameter("@CODIGO_PREGUNTA", codigoresp0)
                base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
                base.AddParrameter("@COMENTARIO", comentario)
                base.AddParrameter("@COD_PRD_RESPUESTA", "001")
                base.AddParrameter("@CODIGO_RESPUESTA", resp0)
                base.EjecutaTransaction(cmd, tran)

            End If
            If codigoresp1 <> "0" Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
                base.AddParrameter("@OPCION", 5)
                base.AddParrameter("@ID_RESULTADO", resultado)
                base.AddParrameter("@CODIGO_PREGUNTA", codigoresp1)
                base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
                base.AddParrameter("@COMENTARIO", comentario)
                base.AddParrameter("@COD_PRD_RESPUESTA", "001")
                base.AddParrameter("@CODIGO_RESPUESTA", resp1)
                base.EjecutaTransaction(cmd, tran)
            End If
            If codigoresp2 <> "0" Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
                base.AddParrameter("@OPCION", 5)
                base.AddParrameter("@ID_RESULTADO", resultado)
                base.AddParrameter("@CODIGO_PREGUNTA", codigoresp2)
                base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
                base.AddParrameter("@COMENTARIO", comentario)
                base.AddParrameter("@COD_PRD_RESPUESTA", "001")
                base.AddParrameter("@CODIGO_RESPUESTA", resp2)
                base.EjecutaTransaction(cmd, tran)
            End If
            If codigoresp3 <> "0" Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
                base.AddParrameter("@OPCION", 5)
                base.AddParrameter("@ID_RESULTADO", resultado)
                base.AddParrameter("@CODIGO_PREGUNTA", codigoresp3)
                base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
                base.AddParrameter("@COMENTARIO", comentario)
                base.AddParrameter("@COD_PRD_RESPUESTA", "001")
                base.AddParrameter("@CODIGO_RESPUESTA", resp3)
                base.EjecutaTransaction(cmd, tran)
            End If
            If codigoresp4 <> "0" Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
                base.AddParrameter("@OPCION", 5)
                base.AddParrameter("@ID_RESULTADO", resultado)
                base.AddParrameter("@CODIGO_PREGUNTA", codigoresp4)
                base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
                base.AddParrameter("@COMENTARIO", comentario)
                base.AddParrameter("@COD_PRD_RESPUESTA", "001")
                base.AddParrameter("@CODIGO_RESPUESTA", resp4)
                base.EjecutaTransaction(cmd, tran)
            End If
            If codigoresp5 <> "0" Then
                base.ClearParrameter(cmd)
                base.ProcedureName = "EXTRANET.ENC_SP_ENCUESTA"
                base.AddParrameter("@OPCION", 5)
                base.AddParrameter("@ID_RESULTADO", resultado)
                base.AddParrameter("@CODIGO_PREGUNTA", codigoresp5)
                base.AddParrameter("@CODIGO_ENCUESTA", codEncuesta)
                base.AddParrameter("@COMENTARIO", comentario)
                base.AddParrameter("@COD_PRD_RESPUESTA", "001")
                base.AddParrameter("@CODIGO_RESPUESTA", resp5)
                base.EjecutaTransaction(cmd, tran)
            End If


            tran.Commit()
            Grabaparticipante = True
        Catch ex As Exception
            Grabaparticipante = False
            tran.Rollback()
            Throw ex
        End Try
    End Function


 
End Class
