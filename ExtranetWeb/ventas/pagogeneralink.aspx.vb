Public Class pagogeneralink
    Inherits System.Web.UI.Page


#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("user") = "0916517956"
        Session("user_netsuite") = "421092"
        Session("Administrador") = "ADM"

        If Not IsPostBack Then
            If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                metodos_master("Links de pagos", 7, "Cobro de facturas")
                mensajeria_error("", "")
                consulta_inicial()
            Else
                Response.Redirect("./login.aspx", False)
            End If
        End If
    End Sub

#End Region

#Region "Eventos de los controles"

    Protected Sub clk_rpt_clientefac(ByVal sender As Object, ByVal e As EventArgs)
        'Try
        '    Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
        '    Dim lblcliente As Label = CType(item.FindControl("lblcodigoclientesfac"), Label)
        '    pasar_datos_existe(lblcliente.Text)
        'Catch ex As Exception
        '    ExceptionHandler.Captura_Error(ex)
        'End Try
    End Sub

    Protected Sub clk_rpt_emailfac(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lblemail As Label = CType(item.FindControl("lblemailfac"), Label)
            txtFormaPagoEmail.Text = lblemail.Text
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub



#End Region

#Region "Funciones y procedimientos generales"

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        If tipo = "error" Then
            dvdmensajes.Attributes.Add("class", "messages error")
            dvdmensajes.Visible = True
        ElseIf tipo = "alerta" Then
            dvdmensajes.Attributes.Add("class", "messages alert")
            dvdmensajes.Visible = True
        ElseIf tipo = "informacion" Then
            dvdmensajes.Attributes.Add("class", "messages sucess")
            dvdmensajes.Visible = True
        ElseIf tipo = "" Then
            dvdmensajes.Visible = False
        End If
    End Sub

    Private Sub consulta_inicial()
        Dim identificacion As String = Session("user")
        txtFormaPagoIdentificacion.Text = identificacion
        txtFormaPagoNombre.Text = cliente_ns(identificacion)

        Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Dim parametroCat As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
        Dim dTEMail As New DataTable
        dTEMail = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametroCat, "103", "", Session("user_netsuite"), "", "", ""))
        If dTEMail.Rows.Count > 0 Then
            If dTEMail.Rows.Count > 0 Then
                Rptemailfac.DataSource = dTEMail
                Rptemailfac.DataBind()
            Else
                Rptemailfac.DataSource = Nothing
                Rptemailfac.DataBind()
            End If
        End If

        Dim dTCstProducto As New System.Data.DataSet
        dTCstProducto = RenovacionAdapter.ConsultaProductoClienteAux(Session("user_netsuite"), "", "T")





    End Sub

    Private Function cliente_ns(cliente) As String
        Dim retorno As String = ""
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosPersonales As DataTable
            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", cliente, "", "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                retorno = dTDatosPersonales.Rows(0)("NombreCompleto").ToString
            End If
        Catch ex As Exception
            retorno = ""
        End Try
        Return retorno
    End Function

#End Region

End Class