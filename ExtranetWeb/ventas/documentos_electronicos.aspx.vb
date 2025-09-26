Imports System.Net.Mail
Imports System.Net

Public Class documentos_electronicos
    Inherits System.Web.UI.Page

#Region "Eventos de pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Session("esFiltro") = "0"
                metodos_master("Documentos Electrónicos", 5, "Documentos electronicos")
                mensajeria_error("", "")
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                    '                    Session("anexo_destino_generado") = ""
                    '                    Session("Pantalla_info") = "DocumentosElectronicos"
                    ConsultaRuta()
                    ConsultaAvanzada(Session.Item("user"), "FACTURA")
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los Controles"

    Private Sub btnfiltrofactura_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltrofactura.ServerClick
        Session("esFiltro") = "0"
        ConsultaAvanzada(Session.Item("user"), "FACTURA")
        botones_filtro("factura")
    End Sub

    Private Sub btnfiltrocontrato_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltrocontrato.ServerClick
        Session("esFiltro") = "0"
        ConsultaAvanzada(Session.Item("user"), "CONTRATO")
        botones_filtro("contrato")
    End Sub

    Private Sub btnfiltroguia_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltroguia.ServerClick
        Session("esFiltro") = "0"
        ConsultaAvanzada(Session.Item("user"), "GUIA DE REMISIÓN")
        botones_filtro("guia")
    End Sub

    Private Sub btnfiltroncr_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltroncr.ServerClick
        Session("esFiltro") = "0"
        ConsultaAvanzada(Session.Item("user"), "NOTA DE CRÉDITO")
        botones_filtro("ncr")
    End Sub

    Private Sub btnfiltrondb_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltrondb.ServerClick
        Session("esFiltro") = "0"
        ConsultaAvanzada(Session.Item("user"), "NOTA DE DEBITO")
        botones_filtro("ndb")
    End Sub

    Private Sub btnfiltroretencion_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltroretencion.ServerClick
        Session("esFiltro") = "0"
        ConsultaAvanzada(Session.Item("user"), "RETENCIÓN")
        botones_filtro("retencion")
    End Sub

    Protected Sub clk_rpt_reenviar(ByVal sender As Object, ByVal e As EventArgs)
        If Session("esFiltro") = "0" Then
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
            Dim lblcodigoid As Label = CType(item.FindControl("lblcodigoid"), Label)
            Dim lbltipodocumento As Label = CType(item.FindControl("lbltipodoc"), Label)
            If lbltipodocumento.Text = "FACTURA" Then
                Session("CODIGO_ID") = lblcodigoid.Text

                Try
                    If Session("CODIGO_ID") IsNot Nothing Then
                        If Session("Email") <> "" Then
                            EnvioEmailPdf()
                        Else
                            mensajeria_error("error", "no se puede obtener correo electronico")
                        End If
                    End If
                Catch ex As Exception
                    ExceptionHandler.Captura_Error(ex)
                End Try
            Else
                mensajeria_error("alerta", "documento no se puede reenviar")
            End If
        End If
    End Sub

    Protected Sub clk_rpt_descargar(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblcodigoid As Label = CType(item.FindControl("lblcodigoid"), Label)
        Dim lblfactura As Label = CType(item.FindControl("lblfactura"), Label)
        Dim lbltipodocumento As Label = CType(item.FindControl("lbltipodoc"), Label)
        If lbltipodocumento.Text = "FACTURA" Then
            Session("CODIGO_ID") = lblcodigoid.Text
            obtener_datos_registro(lblcodigoid.Text)
            Try
                If Session("CODIGO_ID") IsNot Nothing Then
                    Dim filePath As String = Session("RutaFile")
                    Dim fileName As String = Session("NombreFactura")
                    Dim script As String = ""
                    Dim factura As String = Session("RutaFactura").ToString & Session("NombreFactura").ToString
                    Dim xml As String = Session("RutaXml").ToString & Session("NombreFacturaXml").ToString
                    If Session("TipoDocumento") = 1 Then
                        Dim anexo As String = ""
                        Dim documento_anexo As Boolean = True
                        Dim origen As String = Session("RutaAnexo") & "Anexo_" & Session("NombreFactura")
                        Dim destino As String = Session("RutaFile") & "Anexo_" & Session("NombreFactura")
                        If (System.IO.File.Exists(origen)) Then
                            If Not (System.IO.File.Exists(destino)) Then
                                System.IO.File.Copy(origen, destino)
                            End If
                        Else
                            If Not (System.IO.File.Exists(destino)) Then
                                documento_anexo = Writefile3()
                                System.IO.File.Copy(origen, destino)
                            End If
                        End If
                        If documento_anexo Then
                            fileName = "Anexo_" & Session("NombreFactura")
                            anexo = filePath + fileName
                            script = "<script language='javascript'>fnOpen('" & Session("NombreFactura").ToString & "','" & factura & "','0','" &
                                                                            Session("NombreFacturaXml").ToString & "','" & xml & "','1','" &
                                                                            fileName & "','" & anexo & "','2');</script>;"
                            script = script.Replace("\", "\\")
                            ClientScript.RegisterStartupScript(Me.GetType(), "key", script)
                        Else
                            script = "<script language='javascript'>fnOpen('" & Session("NombreFactura").ToString & "','" & factura & "','0','" &
                                                                        Session("NombreFacturaXml").ToString & "','" & xml & "','1','','','NO');</script>;"
                            script = script.Replace("\", "\\")
                            ClientScript.RegisterStartupScript(Me.GetType(), "key", script)
                            mensajeria_error("error", "datos de anexo no se pueden obtener, revisar datos internos.")
                            Exit Sub
                        End If
                    Else
                        script = "<script language='javascript'>fnOpen('" & Session("NombreFactura").ToString & "','" & factura & "','0','" &
                                                                        Session("NombreFacturaXml").ToString & "','" & xml & "','1','','','NO');</script>;"
                        script = script.Replace("\", "\\")
                        ClientScript.RegisterStartupScript(Me.GetType(), "key", script)
                    End If

                    ''If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Then
                    ''    DocumentosAdapter.LeerFactura(Session.Item("user"), Session("CODIGO_ID"), 109, Session("usuario"))
                    ''Else
                    ''    DocumentosAdapter.LeerFactura(Session.Item("user"), Session("CODIGO_ID"), 109, "")
                    ''End If

                    mensajeria_error("informacion", "descarga del archivo satisfactoriamente")
                Else
                    mensajeria_error("error", "no a seleccionado un archivo para descargar")
                End If
            Catch ex As Exception
                ExceptionHandler.Captura_Error(ex)
            End Try
        Else
            mensajeria_error("alerta", "documento no se puede descargar")
        End If

    End Sub

    Private Sub txtfiltro_ServerChange(sender As Object, e As System.EventArgs) Handles txtfiltro.ServerChange
        Session("esFiltro") = "1"
        If btnfiltrofactura.Attributes.Item("class") = "show" Then
            ConsultaAvanzadafiltro(Session.Item("user"), "FACTURA", txtfiltro.Value)
            botones_filtro("factura")
        ElseIf btnfiltrocontrato.Attributes.Item("class") = "show" Then
            ConsultaAvanzadafiltro(Session.Item("user"), "CONTRATO", txtfiltro.Value)
            botones_filtro("contrato")
        ElseIf btnfiltroguia.Attributes.Item("class") = "show" Then
            ConsultaAvanzadafiltro(Session.Item("user"), "GUIA DE REMISIÓN", txtfiltro.Value)
            botones_filtro("guia")
        ElseIf btnfiltroncr.Attributes.Item("class") = "show" Then
            ConsultaAvanzadafiltro(Session.Item("user"), "NOTA DE CRÉDITO", txtfiltro.Value)
            botones_filtro("ncr")
        ElseIf btnfiltrondb.Attributes.Item("class") = "show" Then
            ConsultaAvanzadafiltro(Session.Item("user"), "NOTA DE DEBITO", txtfiltro.Value)
            botones_filtro("ndb")
        ElseIf btnfiltroretencion.Attributes.Item("class") = "show" Then
            ConsultaAvanzadafiltro(Session.Item("user"), "RETENCIÓN", txtfiltro.Value)
            botones_filtro("retencion")
        End If
    End Sub

#End Region

#Region "Procesos"

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

    Private Sub ConsultaAvanzada(ByVal usuario As String, ByVal busqueda As String)
        Try
            mensajeria_error("", "")
            Dim dtcstGeneral As New System.Data.DataSet
            dtcstGeneral = DocumentosAdapter.ConsultaAvanzada(usuario, busqueda)
            If dtcstGeneral.Tables(0).Rows.Count > 0 Then
                Rpt_documentos.DataSource = dtcstGeneral
                Rpt_documentos.DataBind()
            Else
                Rpt_documentos.DataSource = Nothing
                Rpt_documentos.DataBind()
                mensajeria_error("error", "No existen documentos registrados")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConsultaAvanzadafiltro(ByVal usuario As String, ByVal busqueda As String, filtro As String)
        Try
            mensajeria_error("", "")
            Dim dtcstGeneral As New System.Data.DataSet
            dtcstGeneral = DocumentosAdapter.ConsultaAvanzada(usuario, busqueda)
            If dtcstGeneral.Tables(0).Rows.Count > 0 Then
                Dim tblitm As New System.Data.DataTable
                tblitm = dtcstGeneral.Tables(0).Clone()
                dtcstGeneral.Tables(0).Select("NUMERO_DOCUMENTO like '%" &
                                              filtro & "%'").CopyToDataTable(tblitm, LoadOption.OverwriteChanges)
                Rpt_documentos.DataSource = tblitm
                Rpt_documentos.DataBind()
            Else
                Rpt_documentos.DataSource = Nothing
                Rpt_documentos.DataBind()
                mensajeria_error("error", "No existen documentos registrados")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub ConsultaRuta()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = DocumentosAdapter.ConsultaRuta()
            Session("RutaFactura") = dTCstGeneral.Tables(0).Rows(0)("RUTA_FACTURA")
            Session("RutaXml") = dTCstGeneral.Tables(0).Rows(0)("RUTA_XML")
            Session("RutaAnexo") = dTCstGeneral.Tables(0).Rows(0)("RUTA_ANEXO")
            Session("RutaFile") = dTCstGeneral.Tables(0).Rows(0)("RUTA_FILE")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub EnvioEmailPdf()
        Dim verAnexo As Boolean = True
        Dim verXml As Boolean = True
        Dim verPdf As Boolean = True
        Try
            If Session("CODIGO_ID") IsNot Nothing Then
                Dim dTCstData As New System.Data.DataSet
                dTCstData = DocumentosAdapter.LeerFacturaEmail(Session.Item("user"), Session("CODIGO_ID"))
                If dTCstData.Tables(0).Rows.Count > 0 Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''
                    ''GENERACIÓN DEL EMAIL A ENVIAR Y ADJUNTO
                    '''''''''''''''''''''''''''''''''''''''''''''''''
                    'Dim filePath As String = "\\10.100.107.14\ImagenesDocumentos\"
                    Dim correo As New System.Net.Mail.MailMessage()
                    correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
                    correo.To.Add(Session("Email"))
                    Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
                    Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
                    For Each mailTooBcc As String In mailToBccCollection
                        If EMailHandler.ValidarEMail(mailTooBcc) Then
                            correo.Bcc.Add(mailTooBcc)
                        End If
                    Next
                    Dim rutafactura As String = Session("RutaFactura")
                    Dim fileName As String = Session("NombreFactura")
                    Dim urlfilename As String = rutafactura & fileName
                    correo.Attachments.Add(New Attachment(urlfilename))
                    verPdf = False
                    Dim rutaxml As String = Session("RutaXml")
                    Dim fileNamexml As String = Session("NombreFacturaXml")
                    Dim urlfilexml As String = rutaxml & fileNamexml
                    correo.Attachments.Add(New Attachment(urlfilexml))
                    verXml = False
                    If dTCstData.Tables(0).Rows(0)("TIPO_DOCUMENTO_ID") = 1 Then
                        Dim destinoAnexo As String = Session("RutaAnexo") & "Anexo_" & Session("NombreFactura")
                        Dim origen As String = Session("RutaFile") & "Anexo_" & Session("NombreFactura")
                        If Not (System.IO.File.Exists(destinoAnexo)) Then
                            If (System.IO.File.Exists(origen)) Then
                                System.IO.File.Copy(origen, destinoAnexo)
                            Else
                                Writefile2()
                            End If
                        End If
                        Dim rutaAnexo As String = Session("RutaAnexo")
                        Dim fileAnexo As String = "Anexo_" & Session("NombreFactura")
                        Dim urlAnexo As String = rutaAnexo & fileAnexo
                        correo.Attachments.Add(New Attachment(urlAnexo))
                        verAnexo = False
                    End If
                    correo.Subject = "Reenvío de Documentos Electronicos de HunterOnline " & dTCstData.Tables(0).Rows(0)("TIPO_DOCUMENTO") & " Nro. " & dTCstData.Tables(0).Rows(0)("NUMERO_DOCUMENTO")
                    Dim htmlbody As String = dTCstData.Tables(0).Rows(0)("HTMLBODY")
                    correo.Body = htmlbody
                    correo.Priority = MailPriority.High
                    correo.IsBodyHtml = True
                    Dim smtp As New System.Net.Mail.SmtpClient
                    '---------------------------------------------
                    '  DATOS DE LA CONFIGURACIÓN DE LA CUENTA ENVÍA
                    '---------------------------------------------
                    smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
                    smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
                    smtp.EnableSsl = False
                    smtp.Send(correo)
                    correo.Dispose()
                    If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Then
                        DocumentosAdapter.EnvioFacturaCorreo(Session.Item("user"), Session("CODIGO_ID"), Session("Email"), 108, Session("usuario"))
                    Else
                        DocumentosAdapter.EnvioFacturaCorreo(Session.Item("user"), Session("CODIGO_ID"), Session("Email"), 108, "")
                    End If
                    mensajeria_error("informacion", "Email enviado satisfactoriamente a: <strong> " & Session("Email") & "</strong>")
                    Dim destino As String = Session("RutaAnexo") & "Anexo_" & Session("NombreFactura")
                    If (System.IO.File.Exists(destino)) Then
                        System.IO.File.Delete(destino)
                    End If
                Else
                    mensajeria_error("error", "no existen Infornación para enviar el Email")
                End If
            End If
        Catch ex As Exception
            If (verPdf) Then
                mensajeria_error("error", "no existen el documento para ser Reenviado PDF")
            ElseIf (verXml) Then
                mensajeria_error("error", "no existen el documento para ser Reenviado Xml")
            ElseIf (verAnexo) Then
                mensajeria_error("error", "no existen el documento para ser Reenviado Anexo")
            Else
                mensajeria_error("error", "no se pudo enviar el correo electrónico")
            End If
            ExceptionHandler.Captura_Error(ex)
            'Throw ex
        End Try
    End Sub

    Public Sub Writefile2()
        Try
            Dim objDocumento As New DocumentosPdf
            objDocumento.GenerarDocumento(Session("CODIGO_ID"), Session("NombreFactura"), Session("RutaAnexo"))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Public Function Writefile3() As Boolean
        Dim retorno As Boolean = True
        Try
            Dim objDocumento As New DocumentosPdf
            retorno = objDocumento.GenerarDocumento2(Session("CODIGO_ID"), Session("NombreFactura"), Session("RutaAnexo"))
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return retorno
    End Function

    Private Sub obtener_datos_registro(codigo_cntrl As String)
        Try
            If codigo_cntrl IsNot Nothing Then
                Dim dtConsulta As New System.Data.DataSet
                dtConsulta = DocumentosAdapter.ConsultaNombre(Session.Item("user"), codigo_cntrl, 103)
                Session("NombreFactura") = dtConsulta.Tables(0).Rows(0)("NOMBRE_FACTURA")
                Session("NombreFacturaXml") = dtConsulta.Tables(0).Rows(0)("NOMBRE_XML")
                Session("TipoDocumento") = dtConsulta.Tables(0).Rows(0)("TIPO_DOCUMENTO_ID")
                If Session("NombreFactura") IsNot Nothing Then
                    If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Or Session("Administrador") = "MOD" Then
                        DocumentosAdapter.LeerFactura(Session.Item("user"), codigo_cntrl, 110, Session("usuario"))
                    Else
                        DocumentosAdapter.LeerFactura(Session.Item("user"), codigo_cntrl, 110, "")
                    End If
                    Dim origen As String = Session("RutaFactura") & Session("NombreFactura")
                    Dim destino As String = Session("RutaFile") & Session("NombreFactura")
                    If (System.IO.File.Exists(origen)) Then
                        If (System.IO.File.Exists(destino)) Then
                            System.IO.File.Delete(destino)
                        End If
                        System.IO.File.Copy(origen, destino)
                        Dim file As String = "https://www.hunteronline.com.ec/IMGCOTIZADORWEB/ImagenesDocumentos/" + Session("NombreFactura") '+ ".pdf"
                        'myframe.Attributes.Add("src", file)
                        Session("boton") = 2
                    Else
                        'ConfigMsgNofitication(1, "No existen el Documento para Visualizarlo " & Session("NombreFactura"))
                        'myframe.Attributes.Add("src", "")
                        codigo_cntrl = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Private Sub descargar(tipo As String, nombre As String, archivo As String)
        'If (System.IO.File.Exists(archivo)) Then
        '    Response.Clear()
        '    If tipo = "1" Then
        '        Response.ContentType = "Application/XML"
        '    Else
        '        Response.ContentType = "Application/PDF"
        '    End If
        '    Response.ContentEncoding = System.Text.Encoding.UTF8
        '    Response.AppendHeader("Content-Disposition", "attachment; filename=" & nombre)
        '    Response.TransmitFile(archivo)
        '    'Response.End()
        '    Response.Flush()
        '    Response.Close()
        'End If
        Dim direccion As String = "descarga_documento.aspx?FILENAME=" & nombre & "&RUTA=" & archivo & "&COD=" & tipo
        Response.Redirect(direccion, False)


    End Sub

    'Private Sub zip

    Private Sub botones_filtro(boton As String)
        btnfiltrofactura.Attributes.Add("class", "")
        btnfiltrocontrato.Attributes.Add("class", "")
        btnfiltroguia.Attributes.Add("class", "")
        btnfiltroncr.Attributes.Add("class", "")
        btnfiltrondb.Attributes.Add("class", "")
        btnfiltroretencion.Attributes.Add("class", "")
        If boton = "factura" Then
            btnfiltrofactura.Attributes.Add("class", "show")
            For Each item As RepeaterItem In Rpt_documentos.Items
                Dim ulbotones As HtmlGenericControl = CType(item.FindControl("divseccionbotones"), HtmlGenericControl)
                ulbotones.Visible = True
            Next
        ElseIf boton = "contrato" Then
            btnfiltrocontrato.Attributes.Add("class", "show")
            For Each item As RepeaterItem In Rpt_documentos.Items
                Dim ulbotones As HtmlGenericControl = CType(item.FindControl("divseccionbotones"), HtmlGenericControl)
                ulbotones.Visible = False
            Next
        ElseIf boton = "guia" Then
            btnfiltroguia.Attributes.Add("class", "show")
            For Each item As RepeaterItem In Rpt_documentos.Items
                Dim ulbotones As HtmlGenericControl = CType(item.FindControl("divseccionbotones"), HtmlGenericControl)
                ulbotones.Visible = False
            Next
        ElseIf boton = "ncr" Then
            btnfiltroncr.Attributes.Add("class", "show")
            For Each item As RepeaterItem In Rpt_documentos.Items
                Dim ulbotones As HtmlGenericControl = CType(item.FindControl("divseccionbotones"), HtmlGenericControl)
                ulbotones.Visible = False
            Next
        ElseIf boton = "ndb" Then
            btnfiltrondb.Attributes.Add("class", "show")
            For Each item As RepeaterItem In Rpt_documentos.Items
                Dim ulbotones As HtmlGenericControl = CType(item.FindControl("divseccionbotones"), HtmlGenericControl)
                ulbotones.Visible = False
            Next
        ElseIf boton = "retencion" Then
            btnfiltroretencion.Attributes.Add("class", "show")
            For Each item As RepeaterItem In Rpt_documentos.Items
                Dim ulbotones As HtmlGenericControl = CType(item.FindControl("divseccionbotones"), HtmlGenericControl)
                ulbotones.Visible = False
            Next
        End If
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

#End Region

End Class