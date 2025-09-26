Imports Telerik.Web.UI
Imports System
Imports System.IO
Imports System.Net.Security
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Net.Mail
Imports Novacode
Imports System.Drawing
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates


Imports System.Net

Public Class transaccion
    Inherits System.Web.UI.Page

#Region "Declaración de variables"
    Dim origen, secorden As Integer
    Dim estadoOrdenPago As Integer
    Dim valueCampo As Integer
    'Dim rucEmpresa As String = ConfigurationManager.AppSettings.Get("RucEmpresaEnInterDin").ToString()
#End Region

#Region "Eventos de la pagina"

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO LOAD DEL FORMULARIO DE CONSULTA DE TRANSACCIONES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    Divrefound.Visible = False
                    Session("Pantalla_info") = "Transaccion"
                    Me.rdpFechaInicio.MinDate = "1/1/2012"
                    Me.rdpFechaInicio.MaxDate = "31/12/" & Date.Now.Year
                    Me.rdpFechaFin.MinDate = "1/1/2012"
                    Me.rdpFechaFin.MaxDate = "31/12/" & Date.Now.Year
                    Me.rdpFechaInicio.SelectedDate = Now.AddDays((Now.Day - 1) * -1)
                    Me.rdpFechaFin.SelectedDate = Date.Now.Date
                    ConsultaInicial(False)
                    If Session("Administrador") = "ADM" Then
                        FormularioAdapter.RegistroLogFormulario(113, Session.Item("user_ID"), "ADMIN", "PAGOS REALIZADOS", Session("iphost"))
                        Divrefound.Visible = True
                    ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
                        FormularioAdapter.RegistroLogFormulario(113, Session.Item("user_ID"), Session.Item("usuario"), "PAGOS REALIZADOS", Session("iphost"))
                    Else
                        FormularioAdapter.RegistroLogFormulario(113, Session.Item("user_ID"), "LOAD", "PAGOS REALIZADOS", Session("iphost"))
                    End If
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Procedimientos"

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: CONSULTA DE DATOS
    ''' </summary>
    ''' <param name="MostrarMensaje"></param>
    ''' <remarks></remarks>
    Private Sub ConsultaInicial(ByVal mostrarMensaje As Boolean)
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            'dTCstGeneral = TransaccionAdapter.ConsultaOrdenPagoSinVerificar(Session.Item("user"))
            'If dTCstGeneral.Tables(0).Rows.Count > 0 Then
            '    For Each row As DataRow In dTCstGeneral.Tables(0).Rows
            '        valueCampo = row("ORDEN_ID")
            '        ActualizaEstadoOrden(valueCampo)
            '    Next
            'End If
            DTCstGeneral = TransaccionAdapter.ConsultaOrdenPagoConfirmadas(Session.Item("user"), rdpFechaInicio.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""), rdpFechaFin.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", ""))
            If DTCstGeneral.Tables(0).Rows.Count > 0 Then
                rgdverifordenestado.DataSource = DTCstGeneral
                rgdverifordenestado.DataBind()
            Else
                rgdverifordenestado.DataSource = DTCstGeneral
                rgdverifordenestado.DataBind()
                If MostrarMensaje Then
                    rntMsgSistema.Text = "No existen transacciones relacionadas del cliente"
                    rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
                    rntMsgSistema.TitleIcon = "warning"
                    rntMsgSistema.ContentIcon = "warning"
                    rntMsgSistema.ShowSound = "warning"
                    rntMsgSistema.Width = 400
                    rntMsgSistema.Height = 100
                    rntMsgSistema.Show()
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: ACTUALIZA EL ESTADO DE LA ORDEN DE PAGO
    ''' </summary>
    ''' <param name="ordenpago"></param>
    ''' <remarks></remarks>
    'Private Sub ActualizaEstadoOrden(ByVal ordenpago As Integer)
    '    Try
    '        'Dim urlverificaxml As String = "https://www3.interdinmpi.com.ec/webmpi/qvpos?RucEstab=" & ruc_empresa & "&NoTransaccion=" & ordenpago
    '        'Dim urlverificaxml As String = "https://www.optar.com.ec/webmpi/qvpos?RucEstab=" & ruc_empresa & "&NoTransaccion=" & ordenpago
    '        Dim urlverificaxml As String = ConfigurationManager.AppSettings.Get("UrlInterDinQPost").ToString() & "?RucEstab=" & rucEmpresa & "&NoTransaccion=" & ordenpago
    '        secorden = ordenpago
    '        Dim urlString As String = urlverificaxml
    '        Dim resultXml As String
    '        Dim autorzXml As String
    '        ServicePointManager.ServerCertificateValidationCallback = Function() True
    '        Dim reader As XmlTextReader = New XmlTextReader(urlString)
    '        reader.WhitespaceHandling = WhitespaceHandling.Significant
    '        Dim root As XElement = XDocument.Load(reader).Root
    '        If root.<TRANSACCION>.<RESULTADO>.Value Is Nothing Then
    '            'Me.lblresultado.Text = "La orden de pago no existe"
    '            estadoOrdenPago = 1
    '        Else
    '            resultXML = root.<TRANSACCION>.<RESULTADO>.Value
    '            If resultXML = "OK" Then
    '                autorzXML = root.<TRANSACCION>.<NUMAUTORIZA>.Value
    '                'Me.lblresultado.Text = "Transacción correcta, no. autorización " & autorzXML
    '                estadoOrdenPago = 6
    '            End If
    '            If resultXML = "" Then
    '                autorzXML = root.<TRANSACCION>.<NUMAUTORIZA>.Value
    '                'Me.lblresultado.Text = "La orden de pago ha sido cancelada"
    '                estadoOrdenPago = 5
    '            End If
    '            If Len(resultXML) > 3 Then
    '                autorzXML = root.<TRANSACCION>.<RESULTADO>.Value
    '                'Me.lblresultado.Text = autorzXML
    '                estadoOrdenPago = 5
    '            End If
    '        End If
    '        OrdenPagoAdapter.ProcesoActEstOrdenVpos(secorden, 1, 1202, estadoOrdenPago)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    ''' <summary>
    ''' ValidateRemoteCertificate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="certificate"></param>
    ''' <param name="chain"></param>
    ''' <param name="policyErrors"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ValidateRemoteCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, policyErrors As SslPolicyErrors) As Boolean
        If Convert.ToBoolean(ConfigurationManager.AppSettings("IgnoreSslErrors")) Then
            Return True
        Else
            Return policyErrors = SslPolicyErrors.None
        End If
    End Function

    ''' <summary>
    ''' MakeRequest
    ''' </summary>
    ''' <param name="uri"></param>
    ''' <param name="method"></param>
    ''' <param name="proxy"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function MakeRequest(uri As String, method As String, proxy As WebProxy) As String
        Dim webRequest1 As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
        webRequest1.AllowAutoRedirect = True
        webRequest1.Method = method
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateRemoteCertificate)
        If proxy IsNot Nothing Then
            webRequest1.Proxy = proxy
        End If
        Dim response As HttpWebResponse = Nothing
        Try
            response = DirectCast(webRequest1.GetResponse(), HttpWebResponse)
            Using s As Stream = response.GetResponseStream()
                Using sr As New StreamReader(s)
                    Return sr.ReadToEnd()
                End Using
            End Using
        Finally
            If response IsNot Nothing Then
                response.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: ENCRIPTAR METODO SHS256
    ''' </summary>
    ''' <param name="ClearString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' DESCR: SERIALIZAR EN FORMATO JSON
    ''' </summary>
    ''' <param name="firstTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SerializarJson(ByVal firstTable As DataTable) As String
        Try
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))
            Dim row As Dictionary(Of String, Object)
            Dim msginicio As String = "{" & """" & "transaction" & """" & ": "
            Dim msgfinal As String = " }"
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

    Private Sub ReembolsoPaymentez(ByVal transaccion_id As String, pacificard As Boolean)
        Dim url As String = ConfigurationManager.AppSettings.Get("UrlRefoundPaymentez").ToString()
        Dim app_code As String
        Dim app_key As String
        If pacificard Then
            app_code = ConfigurationManager.AppSettings.Get("UsrServerPaymentezPCF").ToString()
            app_key = ConfigurationManager.AppSettings.Get("KeyServerPaymentezPCF").ToString()
        Else
            app_code = ConfigurationManager.AppSettings.Get("UsrServerPaymentez").ToString()
            app_key = ConfigurationManager.AppSettings.Get("KeyServerPaymentez").ToString()
        End If

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
        tabla.Columns.Add("id", GetType(String))
        tabla.Rows.Add(transaccion_id)
        jsonData = SerializarJson(tabla)
        jsonData = jsonData.Replace("[", "").Replace("]", "")

        Try
            Dim jsonhttp As Object
            jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
            jsonhttp.open("POST", url, False)
            jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
            jsonhttp.setRequestHeader("Content-Type", "application/json")
            jsonhttp.setRequestHeader("Auth-Token", auth_token)
            'jsonhttp.setRequestHeader("CharSet", "utf-8")
            'jsonhttp.setRequestHeader("SOAPAction", new_url)
            jsonhttp.send(jsonData)
            objXmlHttp = jsonhttp.Responsetext
            jsonhttp = Nothing
            lblretornorefound.Text = objXmlHttp.ToString

            If objXmlHttp.ToString.Contains("success") And objXmlHttp.ToString.Contains("Completed") Then
                'PROCESOS PARA REVERSO
                OrdenPagoAdapter.Reembolso_transaccion(transaccion_id)
                MostrarMensaje("Transaccion en proceso de rembolso", True)
            Else
                MostrarMensaje("Transaccion no se pudo completar", False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReembolsoDiners()
        Dim app_code As String = ConfigurationManager.AppSettings.Get("DinersLogin").ToString()
        Dim app_key As String = ConfigurationManager.AppSettings.Get("DinersClave").ToString()
        Dim url As String = ConfigurationManager.AppSettings.Get("DinersRuta").ToString()
        Dim jsonData As String = ""

        jsonData = DataJson()
        jsonData = jsonData.Replace("[", "").Replace("]", "")
        Dim objXmlHttp As Object

        Try
            Dim jsonhttp As Object
            jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
            jsonhttp.open("POST", url, False)
            jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
            jsonhttp.setRequestHeader("Content-Type", "application/json")
            jsonhttp.send(jsonData)
            objXmlHttp = jsonhttp.Responsetext

            Dim respuestaHTTP As String = objXmlHttp.ToString
            Dim status As String = descompone_retorno("status", respuestaHTTP)
            Dim message As String = descompone_retorno("message", respuestaHTTP)
            jsonhttp = Nothing
            If status = "OK" Then
                MostrarMensaje("Transaccion reversada con éxito", False)
            ElseIf status <> "" Then
                MostrarMensaje(message, False)
            Else
                MostrarMensaje("No se ha podido enlazar con el banco emisor", False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function DataJson() As String
        DataJson = ""

        Dim tablaAuth As New DataTable
        tablaAuth.Columns.Add("login", GetType(String))
        tablaAuth.Columns.Add("tranKey", GetType(String))
        tablaAuth.Columns.Add("nonce", GetType(String))
        tablaAuth.Columns.Add("seed", GetType(String))
        Dim login As String = ConfigurationManager.AppSettings.Get("DinersLogin").ToString()
        Dim tranKey As String = ConfigurationManager.AppSettings.Get("DinersClave").ToString()
        Dim nonce As String = GetNonce()
        Dim seed As String = FormatoFecha(Date.Now)
        Dim trankeyencr As String = encriptar_sha1_64(String.Format("{0}{1}{2}", nonce, seed, tranKey)) 'EncriptarBase64(EncriptarSHA1(nonce & seed & tranKey))
        Dim nonceencr As String = EncriptarBase64(nonce)
        tablaAuth.Rows.Add(login, trankeyencr, nonceencr, seed)
        Dim auth As String = SerializarJson2(tablaAuth)
        auth = auth.Replace("[", "").Replace("]", "")

        Dim tablaJson As New DataTable
        tablaJson.Columns.Add("internalReference", GetType(String))
        tablaJson.Columns.Add("auth", GetType(String))
        Dim browser As System.Web.HttpBrowserCapabilities = Request.Browser
        tablaJson.Rows.Add(txtidrefound.Text, auth)
        DataJson = SerializarJson2(tablaJson)
        DataJson = DataJson.Replace("[", "").Replace("]", "").Replace("\", "").Replace("}""", "}").Replace("""{", "{")
  
        Return DataJson
    End Function

    Private Function encriptar_sha1_64(ByVal ClearString As String) As String
        encriptar_sha1_64 = ""

        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(ClearString)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        encriptar_sha1_64 = System.Convert.ToBase64String(bytesToHash)

        Return encriptar_sha1_64
    End Function

    Private Function FormatoFecha(ByVal fecha As DateTime) As String
        FormatoFecha = ""
        FormatoFecha = FormatoFecha & Convert.ToString(fecha.Year) & "-"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Month), 2) & "-"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Day), 2) & "T"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Hour), 2) & ":"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Minute), 2) & ":"
        FormatoFecha = FormatoFecha & Right("0" & Convert.ToString(fecha.Second), 2) & "-05:00"
        Return FormatoFecha
    End Function

    Public Function SerializarJson2(ByVal firstTable As DataTable) As String
        Try
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))
            Dim row As Dictionary(Of String, Object)

            For Each dr As DataRow In firstTable.Rows
                row = New Dictionary(Of String, Object)
                For Each col As DataColumn In firstTable.Columns
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function EncriptarSHA1(ByVal ClearString As String) As String
        EncriptarSHA1 = ""
        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(ClearString)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        For Each b As Byte In bytesToHash
            EncriptarSHA1 += b.ToString("x2")
        Next
        Return EncriptarSHA1
    End Function

    Private Function EncriptarBase64(ByVal ClearString As String) As String
        EncriptarBase64 = ""
        ''gethashcode
        'Dim data As Byte()
        'data = System.Text.ASCIIEncoding.ASCII.GetBytes(ClearString)
        'EncriptarBase64 = data.ToString
        'MsgBox(Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("hola")))

        ''System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(String.Format("{0};{1};{2}", app_code, timestamp, textohash)))
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(ClearString)
        EncriptarBase64 = Convert.ToBase64String(byt)

        Return EncriptarBase64
    End Function

    Private Function GetNonce() As String
        GetNonce = ""
        Dim Generator As System.Random = New System.Random()
        Dim randomN As Integer = Generator.Next(Int32.MinValue, Int32.MaxValue)
        GetNonce = randomN.GetHashCode.ToString
        Return GetNonce
    End Function

    Private Function descompone_retorno(ByVal etiqueta As String, ByVal trama As String) As String
        Dim seccion As String = ""
        If trama.IndexOf(etiqueta) > -1 Then
            seccion = trama.Substring(trama.IndexOf(etiqueta), trama.IndexOf(",") - trama.IndexOf(etiqueta))
            seccion = seccion.Replace(etiqueta, "").Replace(Chr(34), "").Replace(":", "").Replace("{", "").Replace("}", "").Replace(" ", "")
        End If
        Return seccion
    End Function

    Private Sub MostrarMensaje(ByVal mensaje As String, ByVal satisfactorio As Boolean)
        Try
            rntMsgSistema.Text = mensaje
            rntMsgSistema.Title = "Mensaje de la Aplicación HunterOnline"
            rntMsgSistema.Width = 400
            rntMsgSistema.Height = 100
            rntMsgSistema.Show()
            If satisfactorio Then
                rntMsgSistema.TitleIcon = "ok"
                rntMsgSistema.ContentIcon = "ok"
                rntMsgSistema.ShowSound = "ok"
            Else
                rntMsgSistema.TitleIcon = "warning"
                rntMsgSistema.ContentIcon = "warning"
                rntMsgSistema.ShowSound = "warning"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Botones"

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: EVENTO CLICK DEL BOTON DE BUSCAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        Try
            If Me.rdpFechaInicio.SelectedDate > Me.rdpFechaFin.SelectedDate Then
                ProveedorMensaje.ShowMessage(rntMsgSistema, "La fecha hasta debe de ser mayor a la fecha desde.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            ConsultaInicial(True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA OBTENER EL KEY O CAMPO DE LA FILA DEL GRID POR MEDIO DEL BOTÓN "VISUALIZAR"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnvisualizar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As GridDataItem = TryCast(TryCast(sender, RadButton).NamingContainer, GridDataItem)
            Dim idorden As Integer = item.GetDataKeyValue("ORDEN_ID")
            Response.Redirect("transacciondetalle.aspx?OrderId=" & idorden, False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Protected Sub rgdverifordenestado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rgdverifordenestado.SelectedIndexChanged
        Try
            Dim item As GridDataItem = Nothing
            Dim idorden As Integer
            item = rgdverifordenestado.SelectedItems(0)
            idorden = item("ORDEN_ID").Text.Trim.ToString
            Response.Redirect("transacciondetalle.aspx?OrderId=" & idorden, False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' DESCR: BOTON PARA REEMBOLSOS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnrefoundorder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnrefoundorder.Click
        If Session.Item("usuario") = "FONTAN" Then
            If txtidrefound.Text.Contains("MD-") Then
                ReembolsoPaymentez(txtidrefound.Text, 0)
            ElseIf txtidrefound.Text.Contains("DF-") Then
                ReembolsoPaymentez(txtidrefound.Text, 1)
            Else
                ReembolsoDiners()
            End If
        End If
    End Sub

    Private Sub btn_inactivos_Click(sender As Object, e As EventArgs) Handles btn_inactivos.Click
        Try
            Dim dTEmailAct As DataSet
            Dim strDominio, strFormulario, strPrm01, strPrm02, strPrm03, valueCfr01, valueCfr02, valueCfr03, urlActivacion, urlFechaparm, urlPromocion, valueFecha As String
            Dim strMailMsg, strMailTitle, strMail As String
            Dim dTLinkActiv As DataSet
            If HttpContext.Current IsNot Nothing Then
                dTLinkActiv = RegistroUsuarioAdapter.GeneraLinkActivacionUsuario
                If dTLinkActiv.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To dTLinkActiv.Tables(0).Rows.Count - 1
                        strDominio = dTLinkActiv.Tables(0).Rows(i)("FORM_DOMINIO")
                        strFormulario = dTLinkActiv.Tables(0).Rows(i)("FORM_ASP")
                        strPrm01 = dTLinkActiv.Tables(0).Rows(i)("FORM_PARAMETRO")
                        strPrm02 = dTLinkActiv.Tables(0).Rows(i)("FORM_PARAMETRO02")
                        strPrm03 = dTLinkActiv.Tables(0).Rows(i)("FORM_PARAMETRO03")
                        valueCfr01 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(i)("CODIGO_REFERENCIAL"))))
                        urlActivacion = strDominio & strFormulario & strPrm01 & valueCfr01
                        valueFecha = FechaSistema()
                        valueCfr02 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(valueFecha)))
                        urlFechaparm = strPrm02 & valueCfr02
                        valueCfr03 = HttpUtility.UrlEncode(EncryptQueryString(String.Format(dTLinkActiv.Tables(0).Rows(i)("PROMOCION"))))
                        urlPromocion = strPrm03 & valueCfr03
                        urlActivacion = urlActivacion & "&" & urlFechaparm & "&" & urlPromocion
                        dTEmailAct = RegistroUsuarioAdapter.GeneraEmailActivacionUsuario(dTLinkActiv.Tables(0).Rows(i)("CODIGO_REFERENCIAL"), dTLinkActiv.Tables(0).Rows(i)("EMAIL1"),
                                                                                         dTLinkActiv.Tables(0).Rows(i)("PRIMER_NOMBRE"), dTLinkActiv.Tables(0).Rows(i)("PRIMER_APELLIDO"),
                                                                                         urlActivacion)
                        If dTEmailAct.Tables(0).Rows.Count > 0 Then
                            strMailMsg = dTEmailAct.Tables(0).Rows(0)("BODY_HTML")
                            strMailTitle = dTEmailAct.Tables(0).Rows(0)("TITLE_HTML")
                            strMail = dTLinkActiv.Tables(0).Rows(i)("EMAIL1")
                            EnvioEmailExterno(strMail, strMailTitle, strMailMsg)
                        Else
                            ProveedorMensaje.ShowMessage(rntMsgSistema, "Ocurrió un inconveniente al enviarse el email de activación", ProveedorMensaje.MessageStyle.OperacionInvalida)
                        End If
                    Next
                    'ConfigMsg(1, "Mensaje enviado correctamente")
                Else
                    ProveedorMensaje.ShowMessage(rntMsgSistema, "Ocurrió un inconveniente al enviarse el email de activación", ProveedorMensaje.MessageStyle.OperacionInvalida)
                End If
            End If
        Catch ex As Exception
            ProveedorMensaje.ShowMessage(rntMsgSistema, "Ocurrió un inconveniente al enviarse el email de activación", ProveedorMensaje.MessageStyle.OperacionInvalida)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Public Function EncryptQueryString(ByVal strQueryString As String) As String
        Dim cifrado As String = String.Empty
        Dim obt As New GeneraDataCphr
        Try
            cifrado = obt.Cifrar(strQueryString, "r0b1nr0y")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return cifrado
    End Function


    Private Function FechaSistema()
        Try
            Dim day, month As Integer
            Dim dayStr, monthStr, yearStr, fechaStr As String
            day = Now.Day
            If day <= 9 Then
                dayStr = "0" & day
            Else
                dayStr = day.ToString
            End If
            month = Now.Month
            If month <= 9 Then
                monthStr = "0" & month
            Else
                monthStr = month.ToString
            End If
            yearStr = Now.Year.ToString
            fechaStr = yearStr & monthStr & dayStr
            Return fechaStr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub EnvioEmailExterno(ByVal email As String, ByVal titulo As String, ByVal bodyhtml As String)
        Dim correo = New System.Net.Mail.MailMessage()
        correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
        correo.To.Add(email)
        Dim mailToBccCollection As [String]() = ConfigurationManager.AppSettings.Get("RegistroUsuarioMailToBcc").ToString().Split(";")
        For Each mailTooBcc As String In mailToBccCollection
            If EMailHandler.ValidarEMail(mailTooBcc) Then
                correo.Bcc.Add(mailTooBcc)
            End If
        Next
        correo.Subject = titulo
        titulo &= vbCrLf & vbCrLf & "Fecha y hora GMT: " & DateTime.Now.ToUniversalTime.ToString("dd/MM/yyyy HH:mm:ss")
        correo.Body = bodyhtml
        correo.IsBodyHtml = True
        Dim smtp As New System.Net.Mail.SmtpClient
        '---------------------------------------------
        ' Estos datos debes rellanarlos correctamente
        '---------------------------------------------
        smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
        smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
        smtp.EnableSsl = False
        Try
            smtp.Send(correo)
            correo.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class