Imports System.IO
Imports VPOS20_PLUGIN
Imports System.Collections.Specialized
Imports System.Net

Public Class cotizadorurlretornopaymentez
    Inherits System.Web.UI.Page

#Region "DECLARACION DE VARIABLES"
    Dim tNo_value_final As String = "0"
    Dim numero_autorizacion As String
    Dim TransaccionValue As String
    Dim tipo_tarjeta As String
    Dim numero_meses As String
    Dim error_descripcion As String
    Dim error_codigo As String
    Dim resultado_autorizacion As String
    Dim estadoAutorizacion As String
    Dim value_actestadoorden As Integer
    Dim opcion_mail As String
    Dim log_opcion As Integer
    Dim log_mensaje As String
#End Region

#Region "EVENTOS DE LA PAGINA"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 01/11/2017
    ''' DESCR: EVENTO LOAD DEL PAGE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                'Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/yourPage.aspx")
                'Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                'Dim dataStream As Stream = response.GetResponseStream()
                'Dim reader As StreamReader = New StreamReader(dataStream)
                'Dim responseFromServer As String = reader.ReadToEnd()
                'Console.WriteLine(responseFromServer)
                'reader.Close()
                'dataStream.Close()
                'response.Close()


                Dim cadena_resultado As String = "["
                Dim loop1, loop2 As Integer
                Dim coll As NameValueCollection
                coll = Request.Headers
                Dim arr1 As String() = coll.AllKeys

                For loop1 = 0 To arr1.Length - 1
                    'Response.Write("Key: " & arr1(loop1) & "<br>")
                    cadena_resultado += arr1(loop1) & ":"
                    Dim arr2 As String() = coll.GetValues(arr1(loop1))

                    For loop2 = 0 To arr2.Length - 1
                        'Response.Write("Value " & loop2 & ": " & Server.HtmlEncode(arr2(loop2)) & "<br>")
                        cadena_resultado += Server.HtmlEncode(arr2(loop2))
                    Next
                    If loop1 < arr1.Length - 1 Then
                        cadena_resultado += ","
                    End If
                Next
                cadena_resultado += "]"
                OrdenPagoAdapter.GuardaRetornoInternoPaymentez(cadena_resultado)

                'Dim jsonhttp As Object
                'jsonhttp = CreateObject("MSXML2.ServerXMLHTTP")
                'jsonhttp.open("POST", url, False)
                'jsonhttp.setRequestHeader("Man", "POST " & url & " HTTP/1.1")
                'jsonhttp.setRequestHeader("Content-Type", "application/json")
                'jsonhttp.setRequestHeader("Auth-Token", auth_token)
                ''jsonhttp.setRequestHeader("CharSet", "utf-8")
                ''jsonhttp.setRequestHeader("SOAPAction", new_url)
                'jsonhttp.send(jsonData)
                'objXmlHttp = jsonhttp.Responsetext
                'jsonhttp = Nothing
                'lblretornorefound.Text = objXmlHttp.ToString



            End If
        Catch ex As Exception
            'value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(3, estadoAutorizacion, numero_autorizacion, tNo_value_final, 0, "", 0, 0, 0, 0, "")
            ProveedorMensaje.ShowMessage(rntMensajes, String.Format("{1} || orden de pago No: {0}", tNo_value_final, ex), ProveedorMensaje.MessageStyle.OperacionInvalida)
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region




#Region "EVENTO DE LOS CONTROLES"

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 01/11/2017
    ' ''' DESCR: EVENTO CLICK DEL BOTON INICIO PARA RETORNAR AL PAGE DE RENOVACION
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Protected Sub btnregresarinicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnregresarinicio.Click
    '    Try
    '        Response.Redirect("renovacion.aspx", False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 01/11/2017
    ' ''' DESCR: EVENTO CLICK DEL BOTON DE VER PAGO PARA RETORNAR AL DETALLE DE PAGOS
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Protected Sub btnVerPago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerPago.Click
    '    Try
    '        Response.Redirect("transacciondetalle.aspx?OrderId=" + Me.lblordenpago.Text, False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

#End Region

#Region "PROCEDIMIENTOS GENERALES"

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 01/11/2017
    ' ''' DESCR: PROCEDIMIENTO PARA DEVOLVER EL CODIGO DEL TIPO DE TARJETA USADO
    ' ''' </summary>
    ' ''' <param name="tipotarjeta"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Protected Function devuelve_codigo_tipotarjeta(ByVal tipotarjeta As String) As String
    '    devuelve_codigo_tipotarjeta = "ND"
    '    Try
    '        If tipotarjeta = "VISA" Then
    '            devuelve_codigo_tipotarjeta = "VI"
    '        ElseIf tipotarjeta = "MASTERCARD" Then
    '            devuelve_codigo_tipotarjeta = "MC"
    '        End If
    '    Catch ex As Exception
    '        devuelve_codigo_tipotarjeta = "ND"
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    '    Return devuelve_codigo_tipotarjeta
    'End Function

    ' ''' <summary>
    ' ''' AUTOR: FELIX ONTANEDA C.
    ' ''' FECHA: 01/11/2017
    ' ''' DESCR: PROCEDIMIENTO PARA EL ENVIO DE MAIL
    ' ''' </summary>
    ' ''' <param name="Proceso"></param>
    ' ''' <param name="OrdenId"></param>
    ' ''' <remarks></remarks>
    'Private Sub EnvioEmailConfirmaciónPago(ByVal Proceso As String, ByVal OrdenId As Decimal)
    '    Try
    '        Dim EmailBody, EmailBodyCopias As String
    '        Dim EmailAddres, EmailAddresCopias As String
    '        Dim DTCstGeneral, DTCstGeneralCopias As New System.Data.DataSet

    '        'ENVIA EMAIL A CLIENTE
    '        DTCstGeneral = RenovacionAdapter.ConsultaEmail(OrdenId, Proceso, True)
    '        EmailBody = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("HTMLBODY"))
    '        EmailAddres = Convert.ToString(DTCstGeneral.Tables(0).Rows(0)("BILLINGEMAIL"))
    '        EMailHandler.EMailConfirmacionPagoCliente(EmailBody, EmailAddres, Proceso)

    '        'ENVIA MAIL COPIAS
    '        DTCstGeneralCopias = RenovacionAdapter.ConsultaEmail(OrdenId, Proceso, False)
    '        EmailBodyCopias = Convert.ToString(DTCstGeneralCopias.Tables(0).Rows(0)("HTMLBODY"))
    '        EmailAddresCopias = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC")
    '        EMailHandler.EMailConfirmacionPagoCliente(EmailBodyCopias, EmailAddresCopias, Proceso)

    '    Catch ex As Exception
    '        Me.lblemailresult.Text = "Ocurrió un error al enviar el email de confirmación"
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub

#End Region

End Class