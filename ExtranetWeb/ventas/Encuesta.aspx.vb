Public Class Encuesta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            'if Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
            'Else
            '    Response.Redirect("./login.aspx", False)
            'End If
            Session("userkey") = Session("user")
            Session("keyveh") = ""
            Session("keycod") = "2"
            secderecha.Visible = False
            lblpregunta0.Visible = False
            If Not (Session("userkey") = Nothing Or Session("keycod") = Nothing) Then
                lblnombres.Text = ""
                Dim dTConsultar As New System.Data.DataSet
                dTConsultar = clsencuesta.ConsultaEncuesta(Session("keycod"), Session("userkey"), Session("keyveh"))
                If dTConsultar.Tables(0).Rows.Count > 1 Then
                    lblnombres.Text = "Encuesta ya realizada"
                Else
                    lblnombres.Text = ""
                    ConsultaDatos()
                End If
            End If
        End If
    End Sub



    Private Sub ConsultaDatos()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = clsencuesta.ConsultaPregunta(Session("keycod"))
            If dTCstGeneral.Tables.Count > 0 Then
                If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To dTCstGeneral.Tables(0).Rows.Count - 1
                        Dim texto As String = dTCstGeneral.Tables(0).Rows(i).Item("PREGUNTA").ToString
                        Dim id As String = dTCstGeneral.Tables(0).Rows(i).Item("CODIGO_PREGUNTA").ToString
                        HabilitaPregunta(i)
                        LlenaPreguntas(i, texto, id)
                        Dim dTCstDetalle As New System.Data.DataSet
                        dTCstDetalle = clsencuesta.ConsultaDetallePregunta(Session("keycod"), id)
                        If dTCstDetalle.Tables(0).Rows.Count > 0 Then
                            For b As Integer = 0 To dTCstDetalle.Tables(0).Rows.Count - 1
                                Dim texto2 As String = dTCstDetalle.Tables(0).Rows(b).Item("RESPUESTA").ToString
                                Dim id2 As String = dTCstDetalle.Tables(0).Rows(b).Item("CODIGO_RESPUESTA").ToString
                                checkboxes(b, texto2, id2, i)
                            Next
                        End If
                    Next
                End If
                secderecha.Visible = True
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub HabilitaPregunta(indice As Integer)
        If indice = 0 Then
            lblpregunta0.Visible = True
        End If
    End Sub


    Private Sub LlenaPreguntas(indice As Integer, texto As String, id As String)
        If indice = 0 Then
            Label0.Text = texto
            Codigo0.Text = id
        End If
    End Sub

    Private Sub checkboxes(ByVal opcion As Integer, ByVal texto As String, ByVal id As String, ByVal indice As String)
        If indice = 0 Then
            If opcion = 0 Then
                lblrespuesta0_1.InnerText = ""
                lblrespuesta0_1.Visible = True
            ElseIf opcion = 1 Then
                lblrespuesta0_2.InnerText = ""
                lblrespuesta0_2.Visible = True
            ElseIf opcion = 2 Then
                lblrespuesta0_3.InnerText = ""
                lblrespuesta0_3.Visible = True
            ElseIf opcion = 3 Then
                lblrespuesta0_4.InnerText = ""
                lblrespuesta0_4.Visible = True
            ElseIf opcion = 4 Then
                lblrespuesta0_5.InnerText = ""
                lblrespuesta0_5.Visible = True
            End If
        End If
    End Sub



    Private Sub btnenviar_Click(sender As Object, e As System.EventArgs) Handles btnenviar.Click
        If Validar() Then
            If Codigo0.Text <> "0" Then
                Dim resp1 As Integer = 0
                Dim comentario As String = ""
                resp1 = IIf(chkrespuesta0_1.Checked, 1, IIf(chkrespuesta0_2.Checked, 2, IIf(chkrespuesta0_3.Checked, 3, IIf(chkrespuesta0_4.Checked, 4, IIf(chkrespuesta0_5.Checked, 5, 0)))))
                Try
                    If Len(txtcontenido.Text) <> 0 Then
                        comentario = txtcontenido.Text
                    End If
                    If clsencuesta.Grabaparticipante(Session("userkey"), comentario, Session("keycod"), resp1, Codigo0.Text, "", "0", "", "0", "", "0", "", "0", "", "0") Then
                        lblnombres.Text = "Encuesta registrada con éxito"
                        btnenviar.Enabled = False
                        secderecha.Visible = False
                    Else
                        lblnombres.Text = "Ocurrió un error por favor intente en unos minutos"
                        btnenviar.Enabled = True
                        secderecha.Visible = True
                    End If
                Catch ex As Exception
                    lblnombres.Text = "Ocurrió un error por favor intente en unos minutos"
                End Try

            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        Validar = False
        If chkrespuesta0_1.Checked = False And chkrespuesta0_2.Checked = False And chkrespuesta0_3.Checked = False And _
           chkrespuesta0_4.Checked = False And chkrespuesta0_5.Checked = False And Codigo0.Text <> "0" Then
            lblnombres.Text = "Falta respuesta pregunta 1"
        Else
            Validar = True
        End If
    End Function


End Class