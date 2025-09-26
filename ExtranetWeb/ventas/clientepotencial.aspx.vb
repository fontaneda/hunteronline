Public Class clientepotencial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.txt_identificacion.Text = String.Empty
                Me.txt_nombre.Text = String.Empty
                Me.txt_apellido.Text = String.Empty
                Me.txt_celular.Text = String.Empty
                Me.txt_telefono.Text = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Sub Btnaceptar_Click(sender As Object, e As EventArgs) Handles Btnaceptar.Click
        Try
            If Me.txt_nombre.Text = "" Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar el nombre del referido", ProveedorMensaje.MessageStyle.OperacionInvalida)
                txt_nombre.Focus()
                Exit Sub
            End If
            If Me.txt_celular.Text = "" Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar el celular del referido", ProveedorMensaje.MessageStyle.OperacionInvalida)
                txt_celular.Focus()
                Exit Sub
            End If
            'If Me.txt_telefonocontacto.Text = "" Then
            '    ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar el telefono de contacto", ProveedorMensaje.MessageStyle.OperacionInvalida)
            '    txt_telefonocontacto.Focus()
            '    Exit Sub
            'End If
            Dim valueRegistroUsuario As Integer
            Dim objregusu As New RegistroUsuarioAdapter
            valueRegistroUsuario = objregusu.RegistroClientePotencialWeb(Me.txt_identificacion.Text.Trim, Me.txt_nombre.Text.Trim, Me.txt_apellido.Text.Trim, _
                                                                         Me.txt_celular.Text.Trim, Me.txt_telefono.Text.Trim, Session("user").ToString)
            If valueRegistroUsuario = 0 Then
                ProveedorMensaje.ShowMessage(rntMensajes, "<strong>Estimado Cliente</strong></br></br>Su referido fue registrado </br><strong> " + Me.txt_nombre.Text.ToUpper() + " .</strong></br></br>Gracias por preferirnos.", ProveedorMensaje.MessageStyle.OperacionExitosa, 9000)
                Me.txt_nombre.Enabled = False
                Me.txt_identificacion.Enabled = False
                Me.txt_apellido.Enabled = False
                Me.txt_celular.Enabled = False
                Me.txt_telefono.Enabled = False
                Me.Btnaceptar.Enabled = False
            Else
                ProveedorMensaje.ShowMessage(rntMensajes, "No se ha podido registrar el usuario correctamente", ProveedorMensaje.MessageStyle.OperacionInvalida)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class