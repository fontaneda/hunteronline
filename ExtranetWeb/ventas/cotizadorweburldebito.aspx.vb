Public Class cotizadorweburldebito
    Inherits System.Web.UI.Page

    Public appcod As String
    Public appkey As String
    Public userid As String
    Public email As String
    Public orden As String
    Public tarjeta As String
    Public origen As String

#Region "Eventos del formulario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Page.Request.Params("__EVENTTARGET") = "btn" Then
                If Not Page.Request.Params("__EVENTARGUMENT") Is Nothing Then
                    If Page.Request.Params("__EVENTARGUMENT") <> "" Then
                        genera_referencia(Page.Request.Params("__EVENTARGUMENT"))
                    End If
                End If
            End If
        Else
            dvdmensajes.Visible = False
            appcod = ConfigurationManager.AppSettings.Get("UsrClientPaymentez").ToString()
            appkey = ConfigurationManager.AppSettings.Get("KeyClientPaymentez").ToString()
            userid = Session("user_id")
            email = Session("Email")
            orden = Session("OrdenID")
            tarjeta = Session("IdTarjetaVpos")
            origen = Session("IdTarjetaVposAnterior")
            listado_tarjetas(userid)
            mensajeria_error("", "")
            btneliminar.Enabled = False
            btngenerar.Enabled = False
            'ListCardsPaymentez(userid)
        End If
    End Sub

#End Region

#Region "Eventos de los controles"

    Protected Sub clk_rpt_procesar(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Session("procesa_orden") = ""
            Session("procesa_alias") = ""
            Session("procesa_token") = ""
            Session("procesa_secuencia") = ""
            For Each itm As RepeaterItem In Rpt_tarjetas_items.Items
                Dim lblalias_ As Label = CType(itm.FindControl("lblnumtrajeta"), Label)
                Dim lblbanco_ As Label = CType(itm.FindControl("lblbanco"), Label)
                Dim lbltipo_ As Label = CType(itm.FindControl("lbltipo"), Label)
                Dim lblfecha_ As Label = CType(itm.FindControl("lblfecha"), Label)
                Dim lblestado_ As Label = CType(itm.FindControl("lblestado"), Label)
                lblalias_.ForeColor = Drawing.Color.Black
                lblbanco_.ForeColor = Drawing.Color.Black
                lbltipo_.ForeColor = Drawing.Color.Black
                lblfecha_.ForeColor = Drawing.Color.Black
                lblestado_.ForeColor = Drawing.Color.Black
            Next

            Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
            Dim lbltoken As Label = CType(item.FindControl("lbltoken"), Label)
            Dim lblorden As Label = CType(item.FindControl("lblorden"), Label)
            Dim lblalias As Label = CType(item.FindControl("lblnumtrajeta"), Label)
            Dim lblbanco As Label = CType(item.FindControl("lblbanco"), Label)
            Dim lbltipo As Label = CType(item.FindControl("lbltipo"), Label)
            Dim lblfecha As Label = CType(item.FindControl("lblfecha"), Label)
            Dim lblestado As Label = CType(item.FindControl("lblestado"), Label)
            Dim lblsecuencia As Label = CType(item.FindControl("lblsecuencia"), Label)
            lblalias.ForeColor = Drawing.ColorTranslator.FromHtml("#4DB64A")
            lblbanco.ForeColor = Drawing.ColorTranslator.FromHtml("#4DB64A")
            lbltipo.ForeColor = Drawing.ColorTranslator.FromHtml("#4DB64A")
            lblfecha.ForeColor = Drawing.ColorTranslator.FromHtml("#4DB64A")
            lblestado.ForeColor = Drawing.ColorTranslator.FromHtml("#4DB64A")
            Session("procesa_orden") = lblorden.Text
            Session("procesa_alias") = lblalias.Text
            Session("procesa_token") = lbltoken.Text
            Session("procesa_secuencia") = lblsecuencia.Text
            btneliminar.Enabled = True
            btngenerar.Enabled = True
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub btneliminar_ServerClick(ByVal sender As Object, ByVal e As EventArgs) Handles btneliminar.Click
        userid = Session("user_id")
        Dim value_ingresodebito As Integer = 0
        Dim lblorden As String = Session("procesa_orden")
        Dim lblalias As String = Session("procesa_alias")
        Dim lbltoken As String = Session("procesa_token")
        Try
            If lblorden <> "" And lblalias <> "" And lbltoken <> "" Then
                If DeleteCardsPaymentez(lbltoken, userid) = 1 Then
                    value_ingresodebito = OrdenPagoAdapter.EliminaTarjetasDebito(userid, lblalias, lblorden)
                    listado_tarjetas(userid)
                    mensajeria_error("informacion", "tarjeta desvinculada con éxito")
                End If
            End If
        Catch ex As Exception
            mensajeria_error("error", "no se pudo desvincular")
        End Try
    End Sub

    Private Sub btngenerar_ServerClick(sender As Object, e As EventArgs) Handles btngenerar.Click
        userid = Session("user_id")
        Dim lblorden As String = Session("OrdenID")
        Dim lblalias As String = Session("procesa_alias")
        Dim lbltoken As String = Session("procesa_token")
        Dim lblsecuencia As String = Session("procesa_secuencia")
        Try
            If lblorden <> "" And lblalias <> "" And lbltoken <> "" And lblsecuencia <> "" Then
                Dim codigo_extra As String = ""
                Dim dTCstTarjetas As New System.Data.DataSet
                dTCstTarjetas = OrdenPagoAdapter.ConsultaExtra(userid, lblsecuencia)
                If dTCstTarjetas.Tables.Count > 0 Then
                    If dTCstTarjetas.Tables(0).Rows.Count > 0 Then
                        codigo_extra = dTCstTarjetas.Tables(0).Rows(0).Item(0)
                        If genera_orden_pago(lblalias, lblsecuencia, userid) Then
                            mensajeria_error("informacion", "proceso para el débito recurrente generado con éxito")
                            Response.Redirect("mistransacciones.aspx", False)
                        Else
                            mensajeria_error("error", "no se puede generar proceso para el débito recurrente")
                        End If
                    Else
                        mensajeria_error("error", "no se puede procesar, por favor elimine y agregue nuevamente")
                    End If
                Else
                    mensajeria_error("error", "no se puede procesar, por favor elimine y agregue nuevamente")
                End If

            End If
        Catch ex As Exception
            mensajeria_error("error", "no se pudo generar proceso automatico")
        End Try
    End Sub

#End Region

#Region "Procedimientos generales"

    Private Sub genera_referencia(ByVal response As String)
        userid = Session("user_id")
        orden = Session("OrdenID")
        origen = "PM"
        Dim Coleccion_Response As [String]() = response.Split("*")
        Dim estado As String = Coleccion_Response(0)
        Dim token As String = Coleccion_Response(1)
        Dim referencia As String = Coleccion_Response(2)
        Dim mensaje As String = Coleccion_Response(3)
        Dim numero As String = Coleccion_Response(4)
        Dim tipo As String = Coleccion_Response(5)
        Dim aliasid As String = Coleccion_Response(6)
        Dim cvc As String = Coleccion_Response(7)
        Dim usuario As String = IIf(Not Session("usuario") Is Nothing, Session("usuario"), "CLIENTE")
        Dim value_ingresodebito As Integer = 0

        value_ingresodebito = OrdenPagoAdapter.IngresaDebito(orden, userid, estado, token, referencia, tipo, origen, _
                                                             aliasid, numero, mensaje, usuario, cvc)
        If value_ingresodebito > 0 Then
            mensajeria_error("informacion", "tarjeta matriculada con éxito")
        Else
            mensajeria_error("error", "ocurrió un problema al matricular la tarjeta")
        End If
        listado_tarjetas(userid)
    End Sub

    Private Sub listado_tarjetas(ByVal clienteid As String)
        Dim dTCstTarjetas As New System.Data.DataSet
        dTCstTarjetas = OrdenPagoAdapter.ConsultaTarjetasDebito(clienteid)
        If dTCstTarjetas.Tables(0).Rows.Count > 0 Then
            Me.Rpt_tarjetas_items.DataSource = dTCstTarjetas.Tables(0)
            Me.Rpt_tarjetas_items.DataBind()
        Else
            mensajeria_error("error", "no tiene tarjetas ingresadas previamente")
        End If
    End Sub

    Private Sub mensajeria_error(ByVal tipo As String, ByVal mensaje As String)
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

    Private Function genera_orden_pago(aliass As String, secuencia As String, clienteid As String) As Boolean
        Dim devolver As Boolean = False
        Try
            Dim objmail As New MailTrabajos
            Dim orden As String = Session("OrdenID")

            EMailHandler.EMailProcesoPago(asunto("2", orden), Nothing, Session("iphost"), Session("iphost"))
            OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, "Q", aliass, orden, "1", "VI", 0, 0, 0, 0, clienteid, secuencia, "", "", "")
            EMailHandler.EMailProcesoPago(asunto("3", orden), Nothing, Session("iphost"), Session("iphost"))
            RenovacionAdapter.GeneraOrdenServicio(orden)
            EMailHandler.EMailProcesoPago(asunto("4", orden), Nothing, Session("iphost"), Session("iphost"))
            objmail.EnvioEmailConfirmaciónPago("100", orden)
            EMailHandler.EMailProcesoPago(asunto("5", orden), Nothing, Session("iphost"), Session("iphost"))
            devolver = True
        Catch ex As Exception
            devolver = False
            Throw ex
        End Try
        Return devolver
    End Function

    Private Function asunto(ByVal numero As String, ByVal orden As String) As String
        Dim resultado As String = ""
        resultado = String.Format("EMAIL {0}ºº - ENVIADO - Pmtz D.A. ({1})", orden)

        Return resultado
    End Function

#End Region

#Region "Eventos pasarela"

    Private Sub ListCardsPaymentez(ByVal cliente As String)
        Dim url As String = ConfigurationManager.AppSettings.Get("UrlListCardDAPaymentez").ToString() & "?uid=" & cliente
        Dim app_code As String
        Dim app_key As String
        app_code = ConfigurationManager.AppSettings.Get("UsrServerPaymentez").ToString()
        app_key = ConfigurationManager.AppSettings.Get("KeyServerPaymentez").ToString()
        Dim fecha_actual As DateTime = Date.Now
        Dim jsonData As String
        Dim DateToConvert As Date = Date.UtcNow
        Dim mdtIniUnixDate As New DateTime(1970, 1, 1, 0, 0, 0)
        Dim timestamp As Integer = CLng((DateToConvert.ToUniversalTime.Subtract(mdtIniUnixDate)).TotalSeconds)
        Dim tokenstring As String = app_key & timestamp
        Dim textohash As String = EncriptarSHA256(tokenstring)
        Dim auth_token As String = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(String.Format("{0};{1};{2}", app_code, timestamp, textohash)))
        Dim tabla As New DataTable
        Dim objXmlHttp As Object
        tabla.Columns.Add("uid", GetType(String))
        tabla.Rows.Add(cliente)
        jsonData = SerializarJson(tabla)
        jsonData = jsonData.Replace("[", "").Replace("]", "")

        Try
            Dim jsonhttp As Object
            jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
            jsonhttp.open("GET", url, False)
            jsonhttp.setRequestHeader("Man", "GET " & url & " HTTP/1.1")
            jsonhttp.setRequestHeader("Content-Type", "application/json")
            jsonhttp.setRequestHeader("Auth-Token", auth_token)
            jsonhttp.send(jsonData)
            objXmlHttp = jsonhttp.Responsetext
            jsonhttp = Nothing
            'If objXmlHttp.ToString.Contains("success") And objXmlHttp.ToString.Contains("Completed") Then
            '    mensajeria_error("informacion", "Transaccion en proceso de rembolso")
            'Else
            '    mensajeria_error("error", "Transaccion no se pudo completar")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function DeleteCardsPaymentez(ByVal token As String, ByVal cliente As String) As Integer
        Dim retorno As Integer = 0
        Dim url As String = ConfigurationManager.AppSettings.Get("UrlDeleteDAPaymentez").ToString()
        Dim app_code As String
        Dim app_key As String
        app_code = ConfigurationManager.AppSettings.Get("UsrServerPaymentez").ToString()
        app_key = ConfigurationManager.AppSettings.Get("KeyServerPaymentez").ToString()
        Dim fecha_actual As DateTime = Date.Now
        Dim jsonData As String
        Dim DateToConvert As Date = Date.UtcNow
        Dim mdtIniUnixDate As New DateTime(1970, 1, 1, 0, 0, 0)
        Dim timestamp As Integer = CLng((DateToConvert.ToUniversalTime.Subtract(mdtIniUnixDate)).TotalSeconds)
        Dim tokenstring As String = app_key & timestamp
        Dim textohash As String = EncriptarSHA256(tokenstring)
        Dim auth_token As String = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(String.Format("{0};{1};{2}", app_code, timestamp, textohash)))
        Dim objXmlHttp As Object
        jsonData = "{""card"": {""token"": """ & token & """},""user"": {""id"": """ & cliente & """}}"

        Try
            Dim jsonhttp As Object
            jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
            jsonhttp.open("POST", url, False)
            jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
            jsonhttp.setRequestHeader("Content-Type", "application/json")
            jsonhttp.setRequestHeader("Auth-Token", auth_token)
            jsonhttp.send(jsonData)
            objXmlHttp = jsonhttp.Responsetext
            jsonhttp = Nothing
            If objXmlHttp.ToString.Contains("card deleted") Then
                retorno = 1
            Else
                retorno = 0
            End If
        Catch ex As Exception
            retorno = 0
        End Try
        Return retorno
    End Function

    Public Function EncriptarSHA256(ByVal ClearString As String) As String
        Dim sourceBytes = ASCIIEncoding.ASCII.GetBytes(ClearString)
        Dim SHA256Obj As New System.Security.Cryptography.SHA256CryptoServiceProvider
        Dim byteHash = SHA256Obj.ComputeHash(sourceBytes)
        Dim result As String = ""
        For Each b As Byte In byteHash
            result += b.ToString("x2")
        Next
        Return result

    End Function

    Public Function SerializarJson(ByVal firstTable As DataTable) As String
        Try
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))
            Dim row As Dictionary(Of String, Object)
            Dim msginicio As String '= "{" '& """" & "transaction" & """" & ": "
            Dim msgfinal As String '= " }"
            For Each dr As DataRow In firstTable.Rows
                row = New Dictionary(Of String, Object)
                For Each col As DataColumn In firstTable.Columns
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return msginicio & serializer.Serialize(rows).ToString & msgfinal
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class