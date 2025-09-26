
Imports System.Net.Mail


Public Class master1
    Inherits System.Web.UI.MasterPage
    Dim clase As String


    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: EVENTO LOAD DEL FORMULARIO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing 
                    If (Session("Administrador") = "ADM" Or Session("Administrador") = "USR" Or Session("Administrador") = "CON") Then
                        divcambiausuario.Visible = True
                    ElseIf (Session("Administrador") = "MOD") Then
                        Session("display_name") = Session("display_soporte")
                        divcambiausuario.Visible = False
                    ElseIf (Session("Administrador") = "APV") Then
                        Session("user") = ""
                        Session("display_name") = Session("display_soporte")
                        '*divcambiausuario.Visible = False
                        divcambiausuario.Visible = True
                    Else
                        divcambiausuario.Visible = False
                    End If
                    Me.lblUserName.Text = Session("display_name")
                    Me.Llena_Menu()
                    Me.Habilita_Menu(Session("user"))
                    Me.lblTotalCompraMasterA.Text = Session("TotalCompraMaster")
                    Me.lblTotalCompraMasterB.Text = "Cerrar"
                    Me.lblCantidadProductoMaster.Text = Session("CantidadMaster")
                    Me.lblpreciounitarioMaster.Text = Session("PrecioUnitarioMaster")
                    Me.lblvalorpromocionMaster.Text = Session("ValorPromocionMaster")
                    Me.lblsubtotalMaster.Text = Session("SubtotalMaster")
                    Me.lblivaMaster.Text = Session("IvaMaster")
                    Me.lbltotalMaster.Text = Session("TotalMaster")
                    Me.lblcantidadcarrito.Text = Session("CantidadMaster")
                Else
                    Session("error") = "Debe de iniciar sesión en el sistema"
                    'Response.Redirect("./login.aspx", False)
                End If
            Else
                'Dim cadena As String = Request.Params("__EVENTTARGET")
                'Dim a As Integer = 1
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: MÉTODO PARA LLENAR EL MENÚ CON LOS ELEMENTOS DEFINIDOS EN LA BASE DE DATOS
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Llena_Menu()
        Try
            Dim itemsMenu As New DataSet
            If IsNothing(Session("menu_general")) Then
                If Session("Administrador") = "MOD" Or Session("Administrador") = "ADM" Then
                    Session("menu_general") = LoginAdapter.DatosMenuExtranet(Session("user"), "103")
                ElseIf Session("Administrador") = "APV" Then
                    Session("menu_general") = LoginAdapter.DatosMenuExtranet(Session("user"), "105")
                Else
                    Session("menu_general") = LoginAdapter.DatosMenuExtranet(Session("user"), "102")
                End If
            End If
            itemsMenu = Session("menu_general")
            RadMenu1.DataSource = itemsMenu.Tables(0)
            RadMenu1.DataFieldID = "CODIGO_MENU"
            RadMenu1.DataFieldParentID = "CODIGO_PADRE"
            RadMenu1.DataTextField = "CAPTION_FORMA"
            RadMenu1.DataNavigateUrlField = "ASSEMBLY"
            RadMenu1.DataValueField = "CODIGO_MENU"
            'RadMenu1.Enabled = False
            'RadMenu1.CssClass = "menu1"
            RadMenu1.DataBind()
            For i As Integer = 0 To itemsMenu.Tables(0).Rows.Count - 1
                For j As Integer = 0 To RadMenu1.Items.Count - 1
                    RadMenu1.Items(j).Enabled = False
                    'RadMenu1.Items(j).ImageUrl = "../images/background/Boton_Inicio.png"
                    ' RadMenu1.Items(j).CssClass = "menu1"
                    For k As Integer = 0 To RadMenu1.Items(j).Items.Count - 1
                        RadMenu1.Items(j).Items(k).Enabled = False
                    Next
                Next
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: MÉTODO PARA HABILITAR LOS ELEMENTOS DEL MENÚ EN BASE A LOS PERFILES ASIGNADOS AL USUARIO
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <remarks></remarks>
    Protected Sub Habilita_Menu(ByVal usuario As String)
        Try
            Dim itemsMenu As New DataSet
            If IsNothing(Session("menu_usuario")) Then
                'Session("menu_usuario") = LoginAdapter.DatosMenuExtranet(Session("user"), "102")
                If Session("Administrador") = "MOD" Then
                    Session("menu_usuario") = LoginAdapter.DatosMenuExtranet(Session("user"), "103")
                ElseIf Session("Administrador") = "APV" Then
                    Session("menu_usuario") = LoginAdapter.DatosMenuExtranet(Session("user"), "105")
                Else
                    Session("menu_usuario") = LoginAdapter.DatosMenuExtranet(Session("user"), "102")
                End If
            End If
            itemsMenu = Session("menu_usuario")
            For i As Integer = 0 To itemsMenu.Tables(0).Rows.Count - 1
                Dim valor As Integer = itemsMenu.Tables(0).Rows(i).Item(2)
                For j As Integer = 0 To RadMenu1.Items.Count - 1
                    If RadMenu1.Items(j).Value = valor Then
                        If Session("Administrador") = "CON" Then
                            'If RadMenu1.Items(j).Value = "8930" Then
                            '    RadMenu1.Items(j).Enabled = False
                            'Else
                            If RadMenu1.Items(j).Value = "8940" Or RadMenu1.Items(j).Value = "8970" Then
                                RadMenu1.Items(j).Enabled = False
                            Else
                                RadMenu1.Items(j).Enabled = True
                            End If
                        Else
                            If Session("Administrador") = "MOD" Then
                                If RadMenu1.Items(j).Value = "8920" Or RadMenu1.Items(j).Value = "8930" Or RadMenu1.Items(j).Value = "8940" Or RadMenu1.Items(j).Value = "8990" Then
                                    RadMenu1.Items(j).Enabled = False
                                Else
                                    RadMenu1.Items(j).Enabled = True
                                End If
                            Else
                                RadMenu1.Items(j).Enabled = True
                            End If
                        End If
                        'RadMenu1.Items(j).Enabled = True
                    End If
                    For k As Integer = 0 To RadMenu1.Items(j).Items.Count - 1
                        If RadMenu1.Items(j).Items(k).Value = valor Then
                            RadMenu1.Items(j).Items(k).Enabled = True
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' COMENTARIO: EVENTO CLICK DEL BOTÓN LOGOUT
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Try
            'Try
            '    If Session("Administrador") <> "ADM" And Session("Administrador") <> "USR" Then
            '            renovacion.RegistroCarroCompra()
            '    End If
            'Catch ex As Exception
            '    ExceptionHandler.Captura_Error(ex)
            'End Try
            If Session("Administrador") <> "ADM" And Session("Administrador") <> "USR" And Session("Administrador") <> "MOD" Then
                FormularioAdapter.RegistroLog(18, Session("user_id"), 7)
            End If
            If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Or Session("Administrador") = "MOD" Or Session("Administrador") = "APV" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("LoginSoporte.aspx", False)
            ElseIf Session("Administrador") = "CON" Then
                Session.Clear()
                Session.Abandon()
                'Response.Redirect("login.aspx", False)
                Response.Redirect("LoginSoporte.aspx", False)
            Else
                Session.Clear()
                Session.Abandon()
                'Response.Redirect("login.aspx", False)
                Response.Redirect("LoginSoporte.aspx", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' Evento del menu para asignar su clase respectiva
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RadMenu1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemDataBound
        Try
            If e.Item.Level = 0 Then
                clase = "Item" & e.Item.Index
            End If
            e.Item.CssClass = clase
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' Evento click del menu de ayuda
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnAyudaMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAyudaMaster.Click
        Try
            If Session("Pantalla_info") = "Inicio" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterInicio.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "DatosPersonales" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterDatos.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "Vehiculo" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterVehiculo.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "Renovacion" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterRenovacion.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "Transaccion" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterTransaccion.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "MisTransacciones" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterMistransacciones.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "Contactenos" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterContactenos.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "Mapa" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterMapa.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "Notificaciones" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterNotificaciones.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            ElseIf Session("Pantalla_info") = "DocumentosElectronicos" Then
                Dim script As String = "function f(){$find(""" + modalPopupHelpMasterDocumentosElectronicos.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' FECHA: 14/01/2015
    ''' DESCR: Evento click para cambiar usuario para soporte
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClientesoporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClientesoporte.Click
        Try
            If Session("Administrador") = "CON" Then
                Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", modalpopupclientevehiculo.ClientID)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            Else
                Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", modalpopupclientesoporte.ClientID)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
            End If

        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub LnkCambiarPwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkCambiarPwd.Click
        Try
            Dim script As String = "function f(){$find(""" + cambioclavecliente.ClientID + """).show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Try
            Me.txt_regusu_clave2.Text = ""
            Me.txt_regusu_clave3.Text = ""
            Me.txt_regusu_clave1.Text = ""
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub Btngrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Try
            Me.Label1.Text = ""
            If Me.txt_regusu_clave1.Text.Trim() = "" Then
                Me.Label1.Text = "Contraseña actual, no debe estar en blanco"
                Me.Label1.Visible = "true"
                Me.BtnGrabar.AutoPostBack.Equals("true")
                Me.RadWindowManager1.DataBind()
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña actual, no deben estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            If Me.txt_regusu_clave2.Text.Trim() = "" Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña nueva, no deben estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            If Me.txt_regusu_clave3.Text.Trim() = "" Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar contraseña nueva, no deben estar en blanco", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            If Me.txt_regusu_clave2.Text <> Me.txt_regusu_clave3.Text Then
                ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Por favor verificar las contraseñas nuevas no son iguales", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            Dim dTCliente As DataSet
            dTCliente = Contraseña.ConsultaClave(Session.Item("user"))
            If Me.txt_regusu_clave1.Text <> dTCliente.Tables(0).Rows(0)("CLAVE") Then
                'If DTCliente.Tables(0).Rows.Count > 0 Then
                'ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br>Esta cuenta de correo <b style=""font-weight: bold"">" + txt_regusu_email01.Text.Trim + "</b> ya se encuentra registrada.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                ProveedorMensaje.ShowMessage(rntMensajes, "Estimado Cliente,</br> contraseña actual es incorrecta.", ProveedorMensaje.MessageStyle.OperacionInvalida)
                Exit Sub
            End If
            RegistroClaveNuevo()
            GeneraEmail()
            Me.txt_regusu_clave2.Text = ""
            Me.txt_regusu_clave3.Text = ""
            Me.txt_regusu_clave1.Text = ""
            Me.Label1.Text = ""
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub RegistroClaveNuevo()
        'Dim objregusu As New Contraseña
        Dim valueRegistro As Integer
        valueRegistro = Contraseña.RegistroClaveNueva(Session.Item("user"), Me.txt_regusu_clave1.Text, Me.txt_regusu_clave2.Text)
        If valueRegistro = 0 Then
            ProveedorMensaje.ShowMessage(rntMensajes, "Cambio Contraseña realizado con éxito, Gracias por preferirnos.", ProveedorMensaje.MessageStyle.OperacionExitosa, 2000)
        Else
            ProveedorMensaje.ShowMessage(rntMensajes, "No se ha podido registrar el usuario correctamente", ProveedorMensaje.MessageStyle.OperacionInvalida)
        End If

    End Sub


    Private Sub GeneraEmail()
        Try
            Dim mailMessage As New MailMessage()
            Dim mailAddress As New MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
            mailMessage.From = mailAddress
            mailMessage.IsBodyHtml = True
            'Dim mailToCollection As [String]() = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString().Split(";")
            Dim mailToCollection As [String]() = CType(Application("soporteextranet"), String).Split(",")
            For Each mailTo As String In mailToCollection
                mailMessage.To.Add(mailTo)
            Next
            'mailMessage.Subject = Me.txt_asunto.Text.ToUpper()
            mailMessage.Subject = "Cambio Contraseña"
            mailMessage.Body = MailBody(Me.lblUserName.Text.ToUpper())
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString())
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Shared Function MailBody(username As String) As String
        Dim builder As New StringBuilder()
        Try
            builder.Append("<html><head><title>")
            builder.Append("</title><meta http-equiv=""Content-Type""")
            builder.Append("</head><body>")
            builder.Append("<h2 class=""h2"">Cambio de Contraseña</h2> <p><strong>Señor(a)(ita)</strong>  <strong>")
            builder.Append("</strong> </p> <p> <strong>" + username)
            'builder.Append("HttpContext.Current.Session(""user"").ToString()")
            builder.Append("</strong> <br/> </p> <p><br/> <strong>Estimado(a) Cliente:</strong> <br/> Usted a modificado su contraseña satisfactoriamente.")
            builder.Append("</strong> <br/> </p> <p><br/> <strong>Su usuario registrado es: </strong> " + HttpContext.Current.Session("user").ToString())
            'builder.Append("S&#237;guenos en Twitter</a> </div> </td> </tr> <tr mc:hideable> <td align=""left"" valign=""middle"" width=""32""> <br/>")
            builder.Append("<br/><br/><br/> <a title=""Descargar Manual de Usuario"" href=""https://www.hunteronline.com.ec/extranet/manual/ManualUsuarioHOnline.pdf"" target=""_blank"">Descargar Manual de Usuario de HunterOnline </a>")
            '<a class="linkmanualcss" href="https://www.hunteronline.com.ec/extranet/manual/ManualUsuarioHOnline.pdf" target="_blank">
            builder.Append("<br/> <br/> <h2 class=""h2"">Nota: Favor no responder este email.</h2> <p> <br/> <br/> ")
            builder.Append("Copyright &copy; 2020 Carseg S.A., Todos los derechos reservados.")
            builder.Append("</body></html>")
            ' o con tilde  &#243;
            'builder.Append("<html><head><title>")
            'builder.Append("</title><meta http-equiv=""Content-Type""")
            'builder.Append("content=""text/html"";charset=""iso-8859-1""><style type=""text/css"">")
            'builder.Append("<!--.basix {font-family: Verdana, Arial, Helvetica, sans-serif;font-size: 9px;")
            'builder.Append("}.header1 {font-family: Verdana, Arial, Helvetica, sans-serif;")
            'builder.Append("font-size: 11px; color: #000000;}.tlbbkground1")
            'builder.Append(" {background-color: #EDEADF;border: 1px solid #EDEADF;}--></style></head><body>")
            'builder.Append("<table width=""70%"" border=""0"" align=""center"" cellpadding = ""5""")
            'builder.Append("cellspacing=""1"" class=""tlbbkground1""><tr bgcolor=""#EDEADF"">")
            'builder.Append("<td colspan=""2"" class=""header1""><div align=""center"">")
            'builder.Append("Soporte al Cliente : '").Append(ConfigurationManager.AppSettings.Get("ProyectName").ToString()).Append("', Cliente sin autenticar</div></tr>")
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Fecha y Hora</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"))
            'builder.Append("</td></tr>")
            'If HttpContext.Current.Session("Idcliente").ToString() <> "0000000000000" Then
            '    builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            '    builder.Append(" nowrap>Usuario</td>")
            '    builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Idcliente").ToString() + " " + HttpContext.Current.Session("cliente").ToString())
            '    builder.Append("</td></tr>")
            'End If
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Asunto</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Asunto").ToString())
            'builder.Append("</td></tr>")
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Correo</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Correo").ToString())
            'builder.Append("</td></tr>")
            'builder.Append("<tr><td width=""100"" align=""right"" bgcolor=""#EDEADF""class=""header1""")
            'builder.Append(" nowrap>Comentario</td>")
            'builder.Append("<td bgcolor=""#FFFFFF"" class=""basix"">").Append(HttpContext.Current.Session("Comentario").ToString())
            'builder.Append("</td></tr>")
            'builder.Append("</table></body></html>")
        Catch exc As Exception
            Throw exc
        End Try
        Return builder.ToString()
    End Function


    Private Sub BtnSalirCambioClave_Click(sender As Object, e As System.EventArgs) Handles BtnSalirCambioClave.Click
        Me.Label1.Text = ""
        Me.txt_regusu_clave2.Text = ""
        Me.txt_regusu_clave3.Text = ""
    End Sub

End Class