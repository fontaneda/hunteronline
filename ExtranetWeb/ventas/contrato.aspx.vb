Imports System.Net

Public Class contrato
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim dtdatos As New System.Data.DataSet
                Dim cliente As String
                Dim vehiculo As String
                Dim producto As String
                Dim contrato As String = ""
                Dim bandera As Boolean = True
                Lblfecha.Text = ""
                If Request.QueryString("userkey") <> Nothing Or Request.QueryString("asset") <> Nothing Or Request.QueryString("producto") <> Nothing Then
                    cliente = Request.QueryString("userkey").ToString
                    vehiculo = Request.QueryString("asset").ToString
                    producto = Request.QueryString("producto").ToString
                    If Request.QueryString("contrato") <> Nothing Then
                        contrato = Request.QueryString("contrato").ToString
                    End If
                    If Not cliente.Equals("") Or Not vehiculo.Equals("") Or Not producto.Equals("") Then
                        Session("cliente") = DecryptQueryString(cliente)
                        Session("Vehiculo") = DecryptQueryString(vehiculo)
                        Session("producto") = DecryptQueryString(producto)
                        If Not contrato.Equals("") Then
                            Session("contrato") = DecryptQueryString(contrato)
                        End If
                        dtdatos = ClsContrato.DatosCliente(Session("cliente"), Session("Vehiculo"), 2, "", Session("producto"), "")
                        If dtdatos.Tables(0).Rows.Count <= 0 Then
                            bandera = False
                        Else
                            bandera = True
                            Session("email") = dtdatos.Tables(0).Rows(0)("EMAIL").ToString()
                            lblUserName.Text = dtdatos.Tables(0).Rows(0)("DISPLAYNAME").ToString()
                            Lblfecha.Text = dtdatos.Tables(0).Rows(0)("FECHASISTEMA").ToString()
                        End If
                    End If
                Else
                    bandera = False
                End If
                If bandera Then
                    Dim file As String = ""
                    If Session("contrato") <> "" Then
                        file = "https://www.hunteronline.com.ec/ContratosComerciales/" & Session("contrato") & ".pdf"
                    Else
                        If Session("producto") = "HU" Then
                            file = "https://www.hunteronline.com.ec/ContratosComerciales/" & dtdatos.Tables(0).Rows(0)("CODIGO_CONTRATO").ToString() & ".pdf"
                        ElseIf Session("producto") = "CM" Then
                            file = "https://www.hunteronline.com.ec/ContratosComerciales/" & dtdatos.Tables(0).Rows(0)("CODIGO_CONTRATO").ToString() & ".pdf"
                        ElseIf Session("producto") = "CH" Then
                            file = "https://www.hunteronline.com.ec/ContratosComerciales/" & dtdatos.Tables(0).Rows(0)("CODIGO_CONTRATO").ToString() & ".pdf"
                        End If
                    End If
                    'myframe.Attributes.Add("src", file)
                    'Dim myUrl As String = "http://docs.google.com/viewer?embedded=true&pid=explorer&efh=false&a=v&url=" + file
                    Dim myUrl As String = "https://docs.google.com/viewer?pid=explorer&efh=false&a=v&chrome=false&embedded=true&url=" + file
                    myframe.Attributes.Add("src", myUrl)
                    myframe.Visible = True
                    Btnaceptar.Visible = True
                    If dtdatos.Tables(0).Rows(0)("CONTRATO").ToString() = "S" Then
                        Btnaceptar.Enabled = False
                        ProveedorMensaje.ShowMessage(rntMensajes, "<strong>Estimado Cliente</strong></br></br>Su contrato ya fue aceptado opcion no disponible</br></br>Gracias por preferirnos.", ProveedorMensaje.MessageStyle.OperacionExitosa, 9000)
                    Else
                        Btnaceptar.Enabled = True
                    End If
                    'Btncancelar.Visible = True
                    dtdatos = ClsContrato.DatosCliente(Session("cliente"), Session("Vehiculo"), 5, "", Session("producto"), "001")
                Else
                    myframe.Visible = False
                    Btnaceptar.Visible = False
                    'Btncancelar.Visible = False
                    ProveedorMensaje.ShowMessage(rntMensajes, "<strong>Estimado Cliente</strong></br></br>No esta utilizando el link correcto, por favor intente de nuevo</br></br>Gracias por preferirnos.", ProveedorMensaje.MessageStyle.OperacionExitosa, 9000)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' FECHA: 17/12/2012
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: FUNCIÓN PARA ENVIAR EL PARÁMETRO A DESENCRIPTAR
    ''' </summary>
    ''' <param name="strQueryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DecryptQueryString(strQueryString As String) As String
        Dim qs As String = ""
        Try
            Dim obt As New GeneraDataCphr
            qs = obt.Descifrar(strQueryString, "r0b1nr0y")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return qs
    End Function


    Private Sub ClientMachineName()
        Try
            Dim computerName As String() = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName.Split(New [Char]() {"."c})
            Session("clientMachineName") = computerName(0).ToString()
            If Session("clientMachineName") Is Nothing Then
                Session("clientMachineName") = HttpContext.Current.Request.UserHostAddress
            End If
            If Session("clientMachineName") Is Nothing Then
                Session("clientMachineName") = (Dns.GetHostEntry(Request.UserHostAddress).HostName)
            End If
        Catch ex As Exception
            '
        End Try
    End Sub

    Protected Sub Btnaceptar_Click(sender As Object, e As EventArgs) Handles Btnaceptar.Click
        Try
            Dim dtdatos As New System.Data.DataSet
            'Dim clientMachineName As String
            ''clientMachineName = (Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName)
            'clientMachineName = (Dns.GetHostEntry(Request.UserHostAddress).HostName)
            clientMachineName()
            If Session("clientMachineName") Is Nothing Then
                Session("clientMachineName") = ""
            End If
            'dtdatos = ClsContrato.DatosCliente(Session("cliente"), Session("Vehiculo"), 4, clientMachineName, Session("producto"), "001")
            dtdatos = ClsContrato.DatosCliente(Session("cliente"), Session("Vehiculo"), 4, Session("clientMachineName"), Session("producto"), "001")
            'InfoUsuario()
            'dtdatos = ClsContrato.DatosCliente(Session("cliente"), Session("Vehiculo"), 4, Session("iphost") + "-" + Session("pchost"), Session("producto"))
            If dtdatos.Tables(0).Rows.Count > 0 Then
                ProveedorMensaje.ShowMessage(rntMensajes, "<strong>Estimado Cliente</strong></br></br>Su contrato fue aceptado con exito, confirme el correo que hemos enviado a su e-mail</br><strong>" + Session("email") + ".</strong></br></br>Gracias por preferirnos.", ProveedorMensaje.MessageStyle.OperacionExitosa, 9000)
                Btnaceptar.Visible = False
                'txt_regusu_email01.Text.Trim +
                Session("cliente") = ""
                Session("Vehiculo") = ""
                Session("email") = ""
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    'Protected Sub Btncancelar_Click(sender As Object, e As EventArgs) Handles Btncancelar.Click
    '    Try
    '        Session.Clear()
    '        Session.Abandon()
    '        Response.Redirect("login.aspx", False)
    '    Catch ex As Exception
    '        ExceptionHandler.Captura_Error(ex)
    '    End Try
    'End Sub


    ''' <summary>
    ''' AUTOR: RONALD OCHOA
    ''' COMENTARIO: MÉTODO PARA OBTENER LA IP Y HOSTNAME DEL EQUIPO VISITANTE
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


End Class