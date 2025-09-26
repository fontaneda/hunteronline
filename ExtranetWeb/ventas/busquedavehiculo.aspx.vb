Imports Telerik.Web.UI

Public Class busquedavehiculo

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

#Region "Eventos de os controles"

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Descr: Evento click del boton consultar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub BtnConsulta_Click(sender As Object, e As EventArgs) Handles BtnConsulta.Click
        Try
            If Len(Me.txtbusquedaclientefac.Value) > 3 Then
                'Dim dTDatosVehiculo As New DataSet
                'dTDatosVehiculo = DatosPersonalesAdapter.ConsultaDatosVehiculo(Me.txtbusquedaclientefac.Value)
                'rgdconsulta.DataSource = dTDatosVehiculo
                'rgdconsulta.DataBind()
                Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
                Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosVehiculos").ToString()
                Dim dTDatosVehiculo As DataTable
                Dim idvehiculo As String = ""
                Dim codcliente As String = ""
                Dim criterios As String = ""
                If IsNumeric(Me.txtbusquedaclientefac.Value) Then
                    If Me.txtbusquedaclientefac.Value.Length < 10 Then
                        idvehiculo = Me.txtbusquedaclientefac.Value.Length
                    Else
                        codcliente = Me.txtbusquedaclientefac.Value
                    End If
                Else
                    criterios = Me.txtbusquedaclientefac.Value
                End If
                '"opcion={0}codigovehiculo={1}idvehiculo={2}codigocliente={3}idcliente={4}indice={5}criterio={6}tipobien={7}" />
                dTDatosVehiculo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", idvehiculo, codcliente, "", "", criterios, ""))
                If dTDatosVehiculo.Rows.Count > 0 Then
                    rgdconsulta.DataSource = dTDatosVehiculo
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

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Fecha: 17/12/2015
    ''' Descr: 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Try
            If Me.rgdconsulta.SelectedItems.Count > 0 Then
                Dim item As GridDataItem = Nothing
                Dim cliente, usuario, sesionAdministrador, nombresCompletos, vehiculo As String
                item = Me.rgdconsulta.SelectedItems(0)
                usuario = Session("usuario")
                sesionAdministrador = Session("Administrador")
                cliente = item("CLIENTE").Text.Trim.ToString
                nombresCompletos = item("NOMBRE_CLIENTE").Text.Trim.ToString
                vehiculo = item("CODIGO").Text.Trim.ToString
                Session.Clear()
                CargaNuevaSesion(usuario, cliente, nombresCompletos, sesionAdministrador, vehiculo)
            Else
                MostrarMensaje("Por favor seleccione un cliente")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Procedimientos Generales"

    ''' <summary>
    ''' Autor: Galo Alvarado
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

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Fecha: 17/12/2015
    ''' Descr: Procedimiento para cargar datos para nueva sesion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaNuevaSesion(ByVal usuario As String, ByVal cliente As String, ByVal nombresCompletos As String, _
                                 ByVal msg As String, ByVal vehiculo As String)
        Try
            InfoUsuario()
            Session("Administrador") = msg
            Session("user") = cliente
            Session("usuario") = usuario
            Session("user_id") = cliente
            Session("display_name") = nombresCompletos
            Session("id_vehiculo") = vehiculo
            Session("TotalMaster") = "0"
            Session("TotalCompraMaster") = "SubTotal  $ &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 0.00"
            Session("SubtotalMaster") = "0"
            Session("CantidadMaster") = "0"
            Session("IvaMaster") = "0"
            Session("PrecioUnitarioMaster") = "0"
            Session("ValorPromocionMaster") = "0"
            Session("Pantalla_info") = ""
            Session("busqueda") = "No"
            If Session("Administrador") = "CON" Then
                FormularioAdapter.RegistroLogFormulario(107, Session("user_id"), Session("usuario"), "CONSULTA DE RELOAD DE VEHICULO ", Session("iphost"))
            Else
                FormularioAdapter.RegistroLogFormulario(107, Session("user_id"), Session("usuario"), "USUARIO CON LOGIN SATISFACTORIO - RELOAD SOPORTE", Session("iphost"))
            End If
            ObtenerDatosCarroCompra()
            Dim script As String = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRedirect());</script>"
            RadScriptManager.RegisterStartupScript(Me, Me.GetType(), "CloseAndRedirect()", script, False)
            '  Response.Redirect("./vehiculoespecifico.aspx", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Fecha: 17/12/2015
    ''' Descr: Procedimiento para cargar datos previos de compra, items seleccionados
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ObtenerDatosCarroCompra()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = CarroCompraAdapter.ConsultaCarroCompra(Session.Item("user"))
            Session("DTCarroCompraCantidadProducto") = 0
            Session("DTCarroCompraPrecioUnitario") = 0
            Session("DTCarroCompraValorPromocion") = 0
            Session("DTCarroCompraSubTotal") = 0
            Session("DTCarroCompraIva") = 0
            Session("DTCarroCompraTotal") = 0
            Session("DTUltimoPedido") = Nothing
            If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                Session("DTCarroCompraCantidadProducto") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_CANTIDAD_PRODUCTO")
                Session("DTCarroCompraPrecioUnitario") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_PRECIO_UNITARIO")
                Session("DTCarroCompraValorPromocion") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_PROMOCION")
                Session("DTCarroCompraSubTotal") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_SUBTOTAL")
                Session("DTCarroCompraIva") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_IVA")
                Session("DTCarroCompraTotal") = dTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("DTUltimoPedido") = dTCstGeneral
                Session("TotalMaster") = dTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("TotalCompraMaster") = "Total &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp $" & dTCstGeneral.Tables(0).Rows(0)("GRAN_TOTAL")
                Session("SubtotalMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_SUBTOTAL")
                Session("CantidadMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_CANTIDAD_PRODUCTO")
                Session("IvaMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_IVA")
                Session("PrecioUnitarioMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_PRECIO_UNITARIO")
                Session("ValorPromocionMaster") = dTCstGeneral.Tables(0).Rows(0)("TOTAL_VALOR_PROMOCION")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Autor: Galo Alvarado
    ''' Fecha: 17/12/2015
    ''' Descr: procedimiento para obtener datos de pc que ingresa
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InfoUsuario()
        Try
            Dim computerName As String()
            Dim valueIphost As String = String.Empty
            Dim valuePchost As String = String.Empty
            valueIphost = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.ServerVariables("REMOTE_ADDR")
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then
                valueIphost = Request.UserHostAddress
            End If
            If Not String.IsNullOrEmpty(valueIphost) Then
                If Not System.Net.Dns.GetHostEntry(valueIphost).HostName Is Nothing Then
                    computerName = System.Net.Dns.GetHostEntry(valueIphost).HostName.Split(New [Char]() {"."c})
                    valuePchost = computerName(0).ToString()
                End If
            Else
                valuePchost = System.Environment.MachineName
            End If
            If valueIphost = "" Or valueIphost Is Nothing Then valueIphost = String.Empty
            If valuePchost = "" Or valuePchost Is Nothing Then valuePchost = String.Empty
            Session("iphost") = valueIphost
            Session("pchost") = valuePchost
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region
End Class