Public Class busquedacliente

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                BtnConsulta.Enabled = True
                BtnAceptar.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        Try
            If Len(Me.txtbusquedaclientefac.Value) > 2 Then
                Dim dTDatosCliente As New DataSet



                'dTDatosCliente = DatosPersonalesAdapter.ConsultaDatosCliente(Me.txtbusquedaclientefac.Value)
                'rgdconsulta.DataSource = dTDatosCliente
                'rgdconsulta.DataBind()



                Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
                Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
                Dim dTDatosPersonales As DataTable
                dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", Me.txtbusquedaclientefac.Value, "", "", "", ""))
                If dTDatosPersonales.Rows.Count > 0 Then
                    rgdconsulta.DataSource = dTDatosPersonales
                    rgdconsulta.DataBind()
                End If


            Else
                MostrarMensaje("Por favor ingresar al menos tres caracteres para iniciar la busqueda")
                Me.rgdconsulta.DataSource = ""
                Me.rgdconsulta.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


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