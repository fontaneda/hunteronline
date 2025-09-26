Public Class busquedaemail

    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Descr: Evento load de la pagina
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                BtnConsulta.Enabled = True
                BtnAceptar.Enabled = True
                BtnConsulta_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Descr: Evento click del boton consultar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConsulta.Click
        Try
            Dim dTDatosEMail As New DataSet
            dTDatosEMail = DatosPersonalesAdapter.ConsultaDatosEmailCliente(Session.Item("user"))
            rgdconsulta.DataSource = dTDatosEMail
            rgdconsulta.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Autor: Felix Ontaneda
    ''' Descr: Procedimiento para llamar a ventana personalizada con mensaje de notificacion
    ''' </summary>
    ''' <param name="mensaje"></param>
    ''' <remarks></remarks>
    Private Sub MostrarMensaje(ByVal mensaje As String)
        Try
            rntMensajes.Text = mensaje
            rntMensajes.Title = "Mensaje de la Aplicación HunterOnline"
            rntMensajes.TitleIcon = "warning"
            rntMensajes.ContentIcon = "warning"
            rntMensajes.ShowSound = "warning"
            rntMensajes.Width = 400
            rntMensajes.Height = 100
            rntMensajes.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class