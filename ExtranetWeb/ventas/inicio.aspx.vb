Public Class inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim dTDatos As DataSet
                dTDatos = DatosPersonalesAdapter.ConsultaDatosChequeosCliente(Session.Item("user"))
                Session("Pantalla_info") = "Inicio"
                If dTDatos.Tables(0).Rows.Count > 0 Then
                    If dTDatos.Tables(0).Rows(0)("VALOR") = 0 Then
                        modalPopup.OnClientClose = True
                    Else
                        Label1.Text = dTDatos.Tables(0).Rows(0)("VALOR")
                        Label2.Text = dTDatos.Tables(0).Rows(0)("VEHICULO")
                        Dim script As String = "function f(){$find(""" + modalPopup.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                    End If
                End If
                If Not RenovacionAdapter.EsValidaInformacionCliente(Session.Item("user")) Then
                    ProveedorMensaje.ShowMessage(rntMensajes, "Debe completar su informacion para facturación en la opción de Datos Personales.", ProveedorMensaje.MessageStyle.OperacionInvalida, 9000)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class