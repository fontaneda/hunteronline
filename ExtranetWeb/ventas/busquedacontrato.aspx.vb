Public Class busquedacontrato

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
                BtnAceptar.Enabled = True
                Dim clienteid As String = ""
                Dim cliente As String = ""
                Dim vehiculosid As String = Session("vehiculos_da")
                If Request.QueryString("ID") <> Nothing Then
                    clienteid = Request.QueryString("ID")
                End If
                If Request.QueryString("CLIENTE") <> Nothing Then
                    cliente = Request.QueryString("CLIENTE")
                End If
                If (clienteid = "" Or clienteid Is Nothing) And (cliente = "" Or cliente Is Nothing) Then
                    MostrarMensaje("No se pudo obtner información del cliente.")
                    Me.BtnAceptar.Enabled = False
                Else
                    If vehiculosid = "" Or vehiculosid Is Nothing Then
                        MostrarMensaje("No se pudo obtner identificación del vehículo.")
                        Me.BtnAceptar.Enabled = False
                    Else
                        Dim objDocumento As New DocumentosContratos
                        Dim nombre As String = objDocumento.GenerarDocumento(clienteid, cliente, vehiculosid)
                        myframe.Attributes.Add("src", "https://www.hunteronline.com.ec/IMGCOTIZADORWEB/ImagenesDocumentos/" & nombre)
                    End If
                End If
            End If
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