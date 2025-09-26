Imports System.Net
Imports RestSharp

Public Class ClaseConexionNetsuite

    Public Shared Function ConsultaNS(script_id As String, parametros As String) As DataTable
        Dim tabla As New DataTable
        tabla = ClaseConexionNetsuite.obtener_datos_netsuite(parametros, script_id)
        Return tabla
    End Function

    Public Shared Function obtener_datos_netsuite(parametros As String, scriptid As String) As DataTable
        Dim tabla As New DataTable
        Dim retorno As String = ""

        'Obtencion de datos de conexion
        Dim entorno As String = ConfigurationManager.AppSettings.Get("NSentorno").ToString()
        Dim oauthConsumerKey As String = ConfigurationManager.AppSettings.Get("NSConsumerKey").ToString()
        Dim oauthConsumerSecret As String = ConfigurationManager.AppSettings.Get("NSConsumerSecret").ToString()
        Dim oauthToken As String = ConfigurationManager.AppSettings.Get("NSToken").ToString()
        Dim oauthTokenSecret As String = ConfigurationManager.AppSettings.Get("NSTokenSecret").ToString()

        'Variables
        Dim realm As String = entorno.Replace("-", "_").ToUpper
        'Dim valor3 As Date = "01/10/2023"
        Dim HMACSHA256SignatureType As String = "HMAC-SHA256"
        Dim OAuthVersion As String = "1.0"
        Dim httpMethod As String = "GET"

        'Configuraciones
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3

        'Conexion
        Dim API_URL As String = String.Format("https://{0}.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script={1}&deploy=1{2}", entorno, scriptid, parametros)
        Dim auth As OAuthBase = New OAuthBase()
        Dim timestamp As String = auth.GenerateTimeStamp()
        Dim nonce As String = auth.GenerateNonce()
        Dim client As RestClient = New RestClient(API_URL)
        client.Timeout = -1
        Dim request = New RestRequest(Method.GET)
        Dim url As Uri = New Uri(API_URL)
        Dim signature = auth.GenerateSignature(url, oauthConsumerKey, oauthConsumerSecret, oauthToken, oauthTokenSecret, httpMethod, timestamp, nonce)
        request.AddHeader("Authorization", "OAuth realm=""" & realm & """, oauth_token=""" & oauthToken & """, oauth_consumer_key=""" & oauthConsumerKey & """," & " oauth_nonce=""" & nonce & """, oauth_timestamp=""" & timestamp & """, oauth_signature_method=""" & HMACSHA256SignatureType & """, oauth_version=""" & OAuthVersion & """, oauth_signature=""" & signature & """")
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("Cookie", "NS_ROUTING_VERSION=LAGGING")
        Dim response As IRestResponse = client.Execute(request)

        'Retorno
        retorno = response.Content

        'Conversion
        tabla = convierte_a_tabla(retorno)

        'Dim API_URL As String = "https://7451241-sb1.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=1188&deploy=1&opcion=100&CodigoCliente=" & valor1 & "&CodigoVehiculo=" & valor2
        'Dim API_URL As String = "https://7451241-sb1.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=1194&deploy=1&fecha=" '& valor3
        'Dim API_URL As String = "https://7451241-sb1.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=1194&codigotabla=iva&deploy=1&fecha=28-10-2023=&codigo=" '& valor3
        'Dim API_URL As String = "https://7451241-sb1.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=1194&codigotabla=iva&deploy=1&fecha=" & Chr(34) & "28-10-2023" & Chr(34) & "&codigo=" '& valor3

        Return tabla
    End Function

    Private Shared Function convierte_a_tabla(cadena As String) As DataTable
        'Variables
        Dim tabla As New DataTable

        If cadena.Length > 40 Then
            cadena = cadena.Replace("""ResultadoConsulta""", "").Replace("[", "").Replace("]", "").Replace("{:", "").Replace("}}", "}")
            Dim registros() As String = Split(cadena, "},")
            Dim registro As String = ""
            'Verifica que existen registros en la cadena
            If registros.Length > 0 Then
                'Descompone las filas
                For i As Integer = 0 To registros.Length - 1
                    If registros(i) <> "" Then
                        registro = registros(i)
                        Dim items() As String = Split(registro, """,")
                        Dim item As String = ""
                        Dim _row As DataRow = tabla.NewRow
                        Dim indice_columna As Integer = 0
                        'Descompone las columnas
                        For j As Integer = 0 To items.Length - 1
                            If items(j) <> "" Then
                                item = items(j)
                                Dim columna() As String = Split(item, """:")
                                Dim campo As String = ""
                                'Descompone los items
                                For k As Integer = 0 To columna.Length - 1
                                    If columna(k) <> "" Then
                                        campo = columna(k).Replace("{", "").Replace("}", "").Replace(Chr(34), "")
                                        If i = 0 And k = 0 Then
                                            tabla.Columns.Add(campo, GetType(String))
                                        ElseIf k = 1 Then
                                            _row(indice_columna) = campo
                                            indice_columna += 1
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        tabla.Rows.Add(_row)
                    End If
                Next
            End If
        End If

        Return tabla
    End Function

    Public Shared Function extraer_item(cadena As String, columna As String) As String
        Dim registro As String = ""
        If cadena.Length > 15 Then
            cadena = cadena.Replace("[", "").Replace("]", "").Replace("{:", "").Replace("}", "")
            Dim registros() As String = Split(cadena, ",")
            If registros.Length > 0 Then
                For i As Integer = 0 To registros.Length - 1
                    registro = registros(i)
                    If registro <> "" And registro.Contains(columna) Then
                        registro = registro.Replace(columna, "").Replace(":", "").Replace(",", "")
                        registro = registro.TrimStart.TrimEnd
                    End If
                Next
            End If
        End If

        Return registro
    End Function

    Public Shared Function IngresaNs(scriptid As String, parametros As String, deploy As String) As String
        Dim retorno As String = ""
        Dim respuesta As String = enviar_datos_netsuite(scriptid, parametros, deploy)
        If respuesta <> "" Then
            If IsNumeric(respuesta) Then
                retorno = respuesta
            Else
                retorno = ""
            End If
        Else
            retorno = ""
        End If
        Return retorno
    End Function

    Public Shared Function ActualizaNs(scriptid As String, parametros As String) As String
        Dim retorno As String = ""
        Dim respuesta As String = actualizar_datos_netsuite(scriptid, parametros)
        If respuesta <> "" Then
            If respuesta.Contains("Registro Actualizado") Then
                retorno = respuesta
            Else
                retorno = "Datos no se enviaron correctamente"
            End If
        Else
            retorno = ""
        End If
        Return retorno
    End Function

    Public Shared Function enviar_datos_netsuite(scriptid As String, parametros As String, deploy As String) As String
        Dim retorno As String = ""
        Try
            Dim tabla As New DataTable
            'Obtencion de datos de conexion
            Dim entorno As String = ConfigurationManager.AppSettings.Get("NSentorno").ToString()
            Dim oauthConsumerKey As String = ConfigurationManager.AppSettings.Get("NSConsumerKey").ToString()
            Dim oauthConsumerSecret As String = ConfigurationManager.AppSettings.Get("NSConsumerSecret").ToString()
            Dim oauthToken As String = ConfigurationManager.AppSettings.Get("NSToken").ToString()
            Dim oauthTokenSecret As String = ConfigurationManager.AppSettings.Get("NSTokenSecret").ToString()
            'Variables
            Dim realm As String = entorno.Replace("-", "_").ToUpper
            Dim HMACSHA256SignatureType As String = "HMAC-SHA256"
            Dim OAuthVersion As String = "1.0"
            Dim httpMethod As String = "POST"
            'Configuraciones
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3
            'Conexion
            Dim API_URL As String = String.Format("https://{0}.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script={1}&deploy=" & deploy, entorno, scriptid)
            Dim auth As OAuthBase = New OAuthBase()
            Dim timestamp As String = auth.GenerateTimeStamp()
            Dim nonce As String = auth.GenerateNonce()
            Dim client As RestClient = New RestClient(API_URL)
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            Dim url As Uri = New Uri(API_URL)
            Dim signature = auth.GenerateSignature(url, oauthConsumerKey, oauthConsumerSecret, oauthToken, oauthTokenSecret, httpMethod, timestamp, nonce)
            request.AddHeader("Authorization", "OAuth realm=""" & realm & """, oauth_token=""" & oauthToken & """, oauth_consumer_key=""" & oauthConsumerKey & """," & " oauth_nonce=""" & nonce & """, oauth_timestamp=""" & timestamp & """, oauth_signature_method=""" & HMACSHA256SignatureType & """, oauth_version=""" & OAuthVersion & """, oauth_signature=""" & signature & """")
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("Cookie", "NS_ROUTING_VERSION=LAGGING")
            request.AddParameter("application/json", parametros, ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            retorno = response.Content
        Catch ex As Exception
            retorno = ""
        End Try

        Return retorno
    End Function

    Public Shared Function actualizar_datos_netsuite(scriptid As String, parametros As String) As String
        Dim retorno As String = ""
        Try
            Dim tabla As New DataTable
            'Obtencion de datos de conexion
            Dim entorno As String = ConfigurationManager.AppSettings.Get("NSentorno").ToString()
            Dim oauthConsumerKey As String = ConfigurationManager.AppSettings.Get("NSConsumerKey").ToString()
            Dim oauthConsumerSecret As String = ConfigurationManager.AppSettings.Get("NSConsumerSecret").ToString()
            Dim oauthToken As String = ConfigurationManager.AppSettings.Get("NSToken").ToString()
            Dim oauthTokenSecret As String = ConfigurationManager.AppSettings.Get("NSTokenSecret").ToString()
            'Variables
            Dim realm As String = entorno.Replace("-", "_").ToUpper
            Dim HMACSHA256SignatureType As String = "HMAC-SHA256"
            Dim OAuthVersion As String = "1.0"
            Dim httpMethod As String = "PUT"
            'Configuraciones
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3
            'Conexion
            Dim API_URL As String = String.Format("https://{0}.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script={1}&deploy=1", entorno, scriptid)
            Dim auth As OAuthBase = New OAuthBase()
            Dim timestamp As String = auth.GenerateTimeStamp()
            Dim nonce As String = auth.GenerateNonce()
            Dim client As RestClient = New RestClient(API_URL)
            client.Timeout = -1
            Dim request = New RestRequest(Method.PUT)
            Dim url As Uri = New Uri(API_URL)
            Dim signature = auth.GenerateSignature(url, oauthConsumerKey, oauthConsumerSecret, oauthToken, oauthTokenSecret, httpMethod, timestamp, nonce)
            request.AddHeader("Authorization", "OAuth realm=""" & realm & """, oauth_token=""" & oauthToken & """, oauth_consumer_key=""" & oauthConsumerKey & """," & " oauth_nonce=""" & nonce & """, oauth_timestamp=""" & timestamp & """, oauth_signature_method=""" & HMACSHA256SignatureType & """, oauth_version=""" & OAuthVersion & """, oauth_signature=""" & signature & """")
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("Cookie", "NS_ROUTING_VERSION=LAGGING")
            request.AddParameter("application/json", parametros, ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            retorno = response.Content
        Catch ex As Exception
            retorno = ""
        End Try

        Return retorno
    End Function

End Class
