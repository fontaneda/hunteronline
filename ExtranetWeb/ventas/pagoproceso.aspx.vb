Imports System.Security.Cryptography
Imports Org.BouncyCastle.Asn1
Imports System.Web.Services
Imports Org.BouncyCastle.Asn1.Crmf

Public Class pagoproceso
    Inherits System.Web.UI.Page

#Region "Evento del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("respuesta_link") = ""
            Dim retorno_orden As String = Request.QueryString("ow")
            Dim retorno_tipo As String = Request.QueryString("tp")
            Dim decryptedOrden As String = Decrypt(retorno_orden)
            Dim decryptedTipo As String = Decrypt(retorno_tipo)
            If decryptedOrden <> "" And decryptedTipo <> "" Then
                mensajeria_error("", "")
                consulta_inicial(decryptedOrden, decryptedTipo)
            Else
                mensajeria_error("error", "Datos incorrectos")
            End If
        End If
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btnpagar_Click(sender As Object, e As EventArgs) Handles btnpagar.Click
        Try
            Dim origen As String = ""
            If txttipopago.Value = "COBRO DE FACTURAS" Then
                origen = "COB"
            ElseIf txttipopago.Value = "RENOVACION DE SERVICIOS" Then
                origen = "REN"
                tabla_sesion_renovacion(Session("OrdenID"))
            End If

            tabla_sesion_orden(origen)

            If cmbtipotarjeta.SelectedValue = "PC" Then
                Session("Pacificard") = "1"
            Else
                Session("Pacificard") = "0"
            End If

            If cmbtipotarjeta.SelectedValue = "VI" Or cmbtipotarjeta.SelectedValue = "MC" _
                Or cmbtipotarjeta.SelectedValue = "PC" Then
                Response.Redirect("cotizadorweburltecnicopaymentez.aspx", False)
            ElseIf cmbtipotarjeta.SelectedValue = "PI" Or cmbtipotarjeta.SelectedValue = "DN" _
            Or cmbtipotarjeta.SelectedValue = "DI" Or cmbtipotarjeta.SelectedValue = "AM" _
            Or cmbtipotarjeta.SelectedValue = "TI" Then
                Response.Redirect("cotizadorweburltecnico.aspx", False)
            End If
        Catch ex As Exception
            mensajeria_error("error", "no se puede continuar, intente en unos minutos")
        End Try

    End Sub

#End Region

#Region "Funciones/Procedimientos generales"

    Public Sub consulta_inicial(orden As String, tipo As String)
        Try
            Dim dTDatos As New DataSet
            dTDatos = RenovacionAdapter.ConsultaOrden(orden)
            If dTDatos.Tables(0).Rows.Count > 0 Then
                Dim valido As String = dTDatos.Tables(0).Rows(0).Item("VALIDO")
                If valido = "S" Then
                    txtcedulaclientefac.Value = dTDatos.Tables(0).Rows(0).Item("IDENTIFICACION")
                    txtnombres.Value = dTDatos.Tables(0).Rows(0).Item("NOMBRE")
                    txtemail.Value = dTDatos.Tables(0).Rows(0).Item("EMAIL")
                    txttipopago.Value = dTDatos.Tables(0).Rows(0).Item("TIPO_PAGO")
                    'txttipotarjeta.Value = dTDatos.Tables(0).Rows(0).Item("TARJETA")
                    txtmonto.Value = dTDatos.Tables(0).Rows(0).Item("TOTAL")
                    txtdireccion.Value = dTDatos.Tables(0).Rows(0).Item("DIRECCION")
                    txtcelular.Value = dTDatos.Tables(0).Rows(0).Item("TELEFONO")
                    txtsubtotal.Value = dTDatos.Tables(0).Rows(0).Item("SUBTOTAL")
                    txtiva.Value = dTDatos.Tables(0).Rows(0).Item("IVA")
                    txtemisor.Value = dTDatos.Tables(0).Rows(0).Item("IDEMISOR")

                    Session("OrdenID") = orden
                    Session("IdTipoPagoVpos") = tipo
                    Session("ClienteFac") = dTDatos.Tables(0).Rows(0).Item("CLIENTEFACTURA")
                    Session("user") = dTDatos.Tables(0).Rows(0).Item("IDENTIFICACION")
                    Session("IdOrdenVpos") = Session("OrdenID")

                    If txttipopago.Value = "RENOVACION DE SERVICIOS" Then
                        porcentajeIva()
                    End If
                    usuario_ns(Session("user"))
                    secuencial_emisor(txtemisor.Value)
                    btnpagar.Enabled = True
                Else
                    mensajeria_error("error", "link ha caducado, por favor solicitar uno nuevo")
                    cmbtipotarjeta.Enabled = False
                    btnpagar.Enabled = False
                End If
            Else
                mensajeria_error("error", "link ya tuvo acceso, no se puede volver a cargar")
                btnpagar.Enabled = False
            End If
            Dim dTdatosTarjeta As New DataSet
            dTdatosTarjeta = RenovacionAdapter.ConsultaPagoTarjeta()
            cmbtipotarjeta.DataSource = dTdatosTarjeta
            cmbtipotarjeta.DataTextField = "DESCRIPCION"
            cmbtipotarjeta.DataValueField = "CODIGO"
            cmbtipotarjeta.DataBind()
        Catch ex As Exception
            mensajeria_error("error", "no se puede obtener los datos")
            btnpagar.Enabled = False
        End Try
    End Sub

    Public Sub tabla_sesion_orden(origen As String)
        Dim dTGetInfoUrlTecnico As New DataTable()
        dTGetInfoUrlTecnico.Columns.Add("datatecnica", GetType(String))
        dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))                '0
        dTGetInfoUrlTecnico.Rows.Add(txtcedulaclientefac.Value)         '1
        dTGetInfoUrlTecnico.Rows.Add(txtnombres.Value)                  '2
        dTGetInfoUrlTecnico.Rows.Add(txtdireccion.Value)                '3
        dTGetInfoUrlTecnico.Rows.Add(txtcelular.Value)                  '4
        dTGetInfoUrlTecnico.Rows.Add(txtemail.Value)                    '5
        dTGetInfoUrlTecnico.Rows.Add(Session("OrdenID"))                '6
        dTGetInfoUrlTecnico.Rows.Add(txtmonto.Value)                    '7
        dTGetInfoUrlTecnico.Rows.Add(txtsubtotal.Value)                 '8
        dTGetInfoUrlTecnico.Rows.Add(0) 'descuentos                     '9
        dTGetInfoUrlTecnico.Rows.Add(0) 'promociones                    '10
        dTGetInfoUrlTecnico.Rows.Add(txtiva.Value)                      '11
        dTGetInfoUrlTecnico.Rows.Add(txtemisor.Value)                   '12
        dTGetInfoUrlTecnico.Rows.Add(origen)                            '13
        dTGetInfoUrlTecnico.Rows.Add(Date.Now)                          '14
        dTGetInfoUrlTecnico.Rows.Add("00:00")                           '15
        dTGetInfoUrlTecnico.Rows.Add(0)                                 '16
        dTGetInfoUrlTecnico.Rows.Add(Session("IdTipoPagoVpos"))         '17
        dTGetInfoUrlTecnico.Rows.Add("LINK")                            '18
        Session("DTGetInfoURLTecnico") = dTGetInfoUrlTecnico

        Dim table As New System.Data.DataTable
        Dim row As DataRow
        table = Tablafacturacion()
        row = table.NewRow()
        Dim clientefact As String = IIf(Session("ClienteFac") = "", Session("ClienteFac"), txtcedulaclientefac.Value)
        row("FormaPagoIdentificacion") = clientefact
        row("FormaPagoNombre") = ""
        row("FormaPagoDireccion") = ""
        row("FormaPagoTelefono") = ""
        row("FormaPagoCelular") = ""
        row("FormaPagoEmail") = ""
        table.Rows.Add(row)
        Session("tblfacturacion") = table

        EMailHandler.EMailGeneracionOrdenPago("Hunter Online", "Registro de orden de pago exitoso <<inicio boton de pago - Link>>.", Session("OrdenID"), Session("iphost"))
    End Sub

    Public Sub tabla_sesion_renovacion(orden As String)
        Dim table As New System.Data.DataTable
        Dim row As DataRow
        table = TablaRenovaciones()
        Dim dTDatos As New DataSet
        dTDatos = RenovacionAdapter.ConsultaOrdenDetalle(orden)
        For i As Integer = 0 To dTDatos.Tables(0).Rows.Count - 1
            row = table.NewRow()
            row("INDICE") = dTDatos.Tables(0).Rows(i).Item("INDICE")
            row("VEHICULO") = dTDatos.Tables(0).Rows(i).Item("VEHICULO")
            row("PRODUCTO") = dTDatos.Tables(0).Rows(i).Item("PRODUCTO")
            row("PRECIO_VENTA") = dTDatos.Tables(0).Rows(i).Item("PRECIO_VENTA")
            row("CODIGO_PROMOCION") = dTDatos.Tables(0).Rows(i).Item("CODIGO_PROMOCION")
            row("VALOR_PROMOCION") = dTDatos.Tables(0).Rows(i).Item("VALOR_PROMOCION")
            row("VALOR_DESCUENTO") = dTDatos.Tables(0).Rows(i).Item("VALOR_DESCUENTO")
            row("PRECIO_TOTAL") = dTDatos.Tables(0).Rows(i).Item("PRECIO_TOTAL")
            row("IVA") = dTDatos.Tables(0).Rows(i).Item("IVA")
            row("PRECIO_CLIENTE") = dTDatos.Tables(0).Rows(i).Item("PRECIO_CLIENTE")
            row("VEHICULO_NOMBRE") = ""
            row("GRUPO_DESCRIPCION") = ""
            row("ANIO") = dTDatos.Tables(0).Rows(i).Item("ANIO")
            row("FECHAFIN") = ""
            row("FECHAINIDA") = ""
            row("FECHAFINDA") = ""
            row("PRODUCTODA") = ""
            row("IDITEM") = dTDatos.Tables(0).Rows(i).Item("IDITEM")
            row("IDEJECUTIVO") = dTDatos.Tables(0).Rows(i).Item("IDEJECUTIVO")
            table.Rows.Add(row)
        Next
        Session("tblrenovaciones") = table
    End Sub

    Private Function TablaRenovaciones() As DataTable
        Dim table As New System.Data.DataTable
        Dim column As DataColumn
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Int32")
        column.ColumnName = "INDICE"
        column.AutoIncrement = True
        column.Caption = "INDICE"
        column.[ReadOnly] = True
        column.Unique = True
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "VEHICULO"
        column.AutoIncrement = False
        column.Caption = "VEHICULO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "PRODUCTO"
        column.AutoIncrement = False
        column.Caption = "PRODUCTO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "PRECIO_VENTA"
        column.AutoIncrement = False
        column.Caption = "PRECIO_VENTA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "CODIGO_PROMOCION"
        column.AutoIncrement = False
        column.Caption = "CODIGO_PROMOCION"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "VALOR_PROMOCION"
        column.AutoIncrement = False
        column.Caption = "VALOR_PROMOCION"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "VALOR_DESCUENTO"
        column.AutoIncrement = False
        column.Caption = "VALOR_DESCUENTO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "PRECIO_TOTAL"
        column.AutoIncrement = False
        column.Caption = "PRECIO_TOTAL"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "IVA"
        column.AutoIncrement = False
        column.Caption = "IVA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Decimal")
        column.ColumnName = "PRECIO_CLIENTE"
        column.AutoIncrement = False
        column.Caption = "PRECIO_CLIENTE"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "VEHICULO_NOMBRE"
        column.AutoIncrement = False
        column.Caption = "VEHICULO_NOMBRE"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "GRUPO_DESCRIPCION"
        column.AutoIncrement = False
        column.Caption = "GRUPO_DESCRIPCION"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.Int32")
        column.ColumnName = "ANIO"
        column.AutoIncrement = False
        column.Caption = "ANIO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FECHAFIN"
        column.AutoIncrement = False
        column.Caption = "FECHAFIN"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FECHAINIDA"
        column.AutoIncrement = False
        column.Caption = "FECHAINIDA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FECHAFINDA"
        column.AutoIncrement = False
        column.Caption = "FECHAFINDA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "PRODUCTODA"
        column.AutoIncrement = False
        column.Caption = "PRODUCTODA"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "IDITEM"
        column.AutoIncrement = False
        column.Caption = "IDITEM"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "IDEJECUTIVO"
        column.AutoIncrement = False
        column.Caption = "IDEJECUTIVO"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)

        Return table
    End Function

    Private Function Tablafacturacion() As DataTable
        Dim table As New System.Data.DataTable
        Dim column As DataColumn
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoIdentificacion"
        column.AutoIncrement = False
        column.Caption = "FormaPagoIdentificacion"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoNombre"
        column.AutoIncrement = False
        column.Caption = "FormaPagoNombre"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoDireccion"
        column.AutoIncrement = False
        column.Caption = "FormaPagoDireccion"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoTelefono"
        column.AutoIncrement = False
        column.Caption = "FormaPagoTelefono"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoCelular"
        column.AutoIncrement = False
        column.Caption = "FormaPagoCelular"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.[GetType]("System.String")
        column.ColumnName = "FormaPagoEmail"
        column.AutoIncrement = False
        column.Caption = "FormaPagoEmail"
        column.[ReadOnly] = False
        column.Unique = False
        table.Columns.Add(column)
        Return table
    End Function

    Public Function Decrypt(cipherText As String) As String
        Dim keystr As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
        Try
            Dim var_key As String = ConfigurationManager.AppSettings.Get("KeyEncr").ToString()
            Dim EncryptionKey As String = var_key
            cipherText = cipherText.Replace(" ", "+")
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New System.IO.MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using

        Catch ex As Exception
            cipherText = ""
        End Try
        Return cipherText
    End Function

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
            If valueIphost = "" Or valueIphost Is Nothing Then valueIphost = String.Empty
            If valuePchost = "" Or valuePchost Is Nothing Then valuePchost = String.Empty
            Session("iphost") = valueIphost
            Session("pchost") = valuePchost
        Catch ex As Exception
            'ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Function usuario_ns(usuario) As Boolean
        Dim retorno As Boolean = False
        Try
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaClientes").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosClientes").ToString()
            Dim dTDatosPersonales As DataTable

            dTDatosPersonales = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", usuario, "", "", "", ""))
            If dTDatosPersonales.Rows.Count > 0 Then
                Session("user_netsuite") = dTDatosPersonales.Rows(0)("IdCliente").ToString
                retorno = True
            End If
        Catch ex As Exception
            retorno = False
        End Try
        Return retorno
    End Function

    Private Function secuencial_emisor(id_emisor As String) As String
        Dim retorno As String = ""

        Dim dTCstEmisor As New System.Data.DataSet
        dTCstEmisor = RenovacionAdapter.ConsultaEmisorDetalleVpos2(id_emisor, "NO")
        If dTCstEmisor.Tables(0).Rows.Count > 0 Then
            retorno = dTCstEmisor.Tables(0).Rows(0).Item("SECUENCIAL")
            Session("id_metodopago_ns") = dTCstEmisor.Tables(0).Rows(0).Item("RELACION_NS")
            Session("id_emisor_ns") = dTCstEmisor.Tables(0).Rows(0).Item("EMISOR_NS")
        Else
            retorno = ""
        End If

        Return retorno
    End Function

    Private Function porcentajeIva() As Decimal
        Dim parametrocat As String
        Dim id_scriptCat As String = ConfigurationManager.AppSettings.Get("NSConsultaCatalogos").ToString()
        porcentajeIva = 0
        parametrocat = ConfigurationManager.AppSettings.Get("NSParamCatIva").ToString()

        Dim retorno As DataTable = ClaseConexionNetsuite.ConsultaNS(id_scriptCat, String.Format(parametrocat, "IVA", "2"))
        Dim retorno_val As String = retorno.Rows(0).Item("TarifaCodidgoImpuestoVentas")
        Dim retorno_cod As String = retorno.Rows(0).Item("IdCodidgoImpuestoVentas")
        retorno_val = retorno_val.Replace("%", "").Replace(" ", "")
        If retorno_val <> "" Then
            porcentajeIva = CDbl(retorno_val)
            Session("DTCodigoIva") = retorno_cod
            Session("DTPorcentajeIva") = porcentajeIva / 100
        End If
    End Function

#End Region


End Class