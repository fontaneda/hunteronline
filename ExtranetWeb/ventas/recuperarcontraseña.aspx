<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="recuperarcontraseña.aspx.vb" Inherits="ExtranetWeb.recuperarcontraseña" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Recuperar Contraseña</title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilocontraseña.css" rel="stylesheet" type="text/css" />
        <link href="../styles/menunew.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .style1
            {
                width: 9px;
                height: 10px;
            }
        </style>
        <script type="text/javascript">
            (function (i, s, o, g, r, a, m) 
            {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () 
                {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-67324308-1', 'auto');
            ga('send', 'pageview');
        </script>
    </head>
    <body>
        <script type="text/javascript">
            (function (d, s, id) 
            {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) return;
                js = d.createElement(s); js.id = id;
                js.src = "//connect.facebook.net/es_ES/sdk.js#xfbml=1&version=v2.0";
                fjs.parentNode.insertBefore(js, fjs);
            } (document, 'script', 'facebook-jssdk'));

            !function (d, s, id) 
            {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (!d.getElementById(id)) 
                {
                    js = d.createElement(s);
                    js.id = id; js.src = "//platform.twitter.com/widgets.js";
                    fjs.parentNode.insertBefore(js, fjs);
                }
            } (document, "script", "twitter-wjs");
        </script>
        <form id="form1" runat="server">
            <div id="container_2">
                <div id="banner4">
                     <%-- <div class="logo_image"></div>
                    <div class="content_user_logo_principal_cabecera">
                      <div class="fb-like" data-href="https://es-es.facebook.com/hunterecuador" data-width="100" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false">
                        </div>
                        <a href="https://twitter.com/hunterEcuador" class="twitter-share-button" data-show-count="true" data-lang="es">Follow @twitterapi</a>
                    </div>
                    <div class="content_user_logo_principal_new"></div>--%>
                </div>
                <div id="regusu_content_principal">
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                </div>
                <div class="regusu_secc_table_boton04"></div>
                <div class="content_transacciondetalle_toolbar_icon">
                  <%--  <telerik:RadButton ID="btnSalir" runat="server" Text="Nuevo" ForeColor="Black" Style="top: 0px;
                        left: 0px; height: 30px; width: 30px" ToolTip="Regresar a al Inicio">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/go_back32x32.png" />
                    </telerik:RadButton>--%>
                  <%--   <telerik:RadButton ID="btnSalir" runat="server" Text="Regresar" TabIndex="8" ToolTip="Regresar a al Inicio"
                                Width="100px" Height="20px" HoveredCssClass="goButtonClassHov" CssClass="boton_color">
                                <Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>
                            </telerik:RadButton>--%>
                </div>
                <div class="regusu_content_principal_bloque">
                    <div class="regusu_title_01">
                        Recuperación de Contraseña
                    </div>
                    <div class="regusu_title_02">
                        <img alt="" class="style1" src="../images/background/fecha.png" />&nbsp;&nbsp;Paso 1 - Confirmación
                    </div>
                    <div class="regusu_secc_identificacion">
                        <div class="regusu_question_identificacion">
                            <div class="regusu_secc_table_label02">
                                Correo electrónico
                            </div>
                            <div class="regusu_secc_table_text01">
                                <telerik:RadTextBox ID="txt_regusu_email01" runat="server" Width="280px" TabIndex="1" MaxLength="50" AutoPostBack="True">
                                </telerik:RadTextBox>
                            </div>
                            <div class="regusu_secc_table_boton01">
                                <asp:RequiredFieldValidator ID="vld_txt_regusu_email01" runat="server" ErrorMessage="Ingrese email" ControlToValidate="txt_regusu_email01"
                                     ValidationGroup="grupo01" Display="Dynamic" Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29">
                                </asp:RequiredFieldValidator>
                            </div>
                            <%--  <div class="regusu_secc_table_label03">o </div>
                            <div class="regusu_secc_table_text03"></div>
                            --%>
                            <%--<div class="regusu_secc_table_label02">
                               Celular Contacto
                            </div>
                           <div class="regusu_secc_table_text01">
                                 <telerik:RadTextBox ID="txt_regusu_celular" runat="server" Width="280px" TabIndex="2"
                                    AutoPostBack="True">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="vld_txt_regusu_celular" runat="server" ErrorMessage="Ingrese su número celular"
                                    ControlToValidate="txt_regusu_celular" ValidationGroup="grupo01" Display="Dynamic"
                                    Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"></asp:RequiredFieldValidator>
                            </div>--%>
                        </div>
                    </div>
                    <div class="regusu_title_02">
                        <img alt="" class="style1" src="../images/background/fecha.png" /> &nbsp;&nbsp;Paso 2 - Pregunta Secreta
                    </div>
                    <div class="regusu_secc_banco_preguntas">
                        <div class="regusu_question_master">
                            <div class="regusu_secc_table_label02">
                                <asp:Label ID="lbl_prg_id_01" runat="server" Text="" />
                                <asp:Label ID="lbl_regusu_pregunta01" runat="server" Text="" />
                            </div>
                            <div class="regusu_secc_table_text01">
                                <telerik:RadTextBox ID="txt_regusu_respuesta01" runat="server" Width="280px" LabelWidth="112px" TabIndex="3">
                                </telerik:RadTextBox>
                                <%--<asp:RequiredFieldValidator ID="vld_txt_regusu_respuesta01" runat="server" ErrorMessage="Ingrese una respuesta"
                                    ControlToValidate="txt_regusu_respuesta01" ValidationGroup="grupo01" Display="Dynamic"
                                    Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="regusu_secc_table_boton01">
                                <telerik:RadButton ID="Btnproxima" runat="server" Text="Otra Pregunta" TabIndex="4"
                                    ToolTip="Otra Pregunta" Width="100px" Height="20px" HoveredCssClass="goButtonClassHov_contraseña"
                                    CssClass="boton_color_contraseña">
                                    <%--<Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>--%>
                                </telerik:RadButton>
                            </div>
                            <div class="regusu_secc_table_label02">
                            </div>
                            <div class="regusu_secc_table_text01">
                                <asp:RequiredFieldValidator ID="vld_txt_regusu_respuesta01" runat="server" ErrorMessage="Ingrese una respuesta"
                                    ControlToValidate="txt_regusu_respuesta01" ValidationGroup="grupo01" Display="Dynamic"
                                    Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="regusu_secc_table_boton01"></div>
                        </div>
                    </div>
                    <%--<div class="regusu_bloque_col3_parrafo">
                        <telerik:RadButton ID="btproxima" runat="server" Text="Otra Pregunta" Font-Bold="True"
                            TabIndex="4" ToolTip="Otra Pregunta" Width="100px">
                        </telerik:RadButton>
                    </div>
                    <div class="regusu_bloque_col2_parrafo"></div>--%>
                    <div class="regusu_title_02">
                        <img alt="" class="style1" src="../images/background/fecha.png" />&nbsp;&nbsp;Paso 3 - Confirme la Imagen
                    </div>
                    <div class="regusu_question_RadCaptcha">
                        <div class="regusu_secc_table_RadCaptcha02">
                            <%-- <asp:Button ID="Button1" runat="server" Text="Button" ValidationGroup="SubmitGroup">
                             </asp:Button>
                             <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="SubmitGroup" runat="server">
                             </asp:ValidationSummary>--%>
                        </div>
                        <div class="regusu_secc_table_RadCaptcha01">
                            <%--<telerik:RadCaptcha ID="RadCaptcha1" runat="server" 
                                ValidationGroup="grupo01"    ErrorMessage="El texto ingresado no es inválido" 
                                Display="Dynamic" CaptchaLinkButtonText="Generar nuevo texto"
                                EnableRefreshImage="True" CaptchaImage-BackgroundNoise="Extreme" CaptchaImage-EnableCaptchaAudio="True"
                                CaptchaImage-TextColor="Black" CaptchaImage-TextLength="6" CaptchaImage-UseAudioFiles="True"
                                      CaptchaImage-Width="400" Font-Size="11pt" Width="400px" 
                                ForeColor="#990000" ValidatedTextBoxID="txtvalida" >
                             <CaptchaImage  BackgroundNoise="Extreme" EnableCaptchaAudio="false" TextColor="Black" 
                                     TextLength="6" UseAudioFiles="True" Width="180" ></CaptchaImage>
                                 </telerik:RadCaptcha>
                                 <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ValidationGroup="grupo01" 
                                ErrorMessage="El texto ingresado no es inválido"
                                CaptchaTextBoxLabel="" Display="Dynamic" CaptchaLinkButtonText="Generar nuevo texto"
                                EnableRefreshImage="True" CaptchaImage-BackgroundNoise="Extreme" CaptchaImage-EnableCaptchaAudio="false"
                                CaptchaImage-TextColor="Black" CaptchaImage-TextLength="6" CaptchaImage-UseAudioFiles="True"
                                CaptchaImage-Width="400" Font-Size="11pt" Width="400px" ForeColor="#990000" ValidatedTextBoxID="txtvalida"
                                TabIndex="5">
                                <CaptchaImage BackgroundNoise="Extreme" EnableCaptchaAudio="false" TextColor="Black"
                                    TextLength="6" UseAudioFiles="True" Width="180"></CaptchaImage>
                            </telerik:RadCaptcha>
                            --%>
                            <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ValidationGroup="grupo01" ErrorMessage="El texto ingresado no es inválido" CaptchaTextBoxLabel="" Display="Dynamic"
                                CaptchaLinkButtonText="Generar nuevo texto" EnableRefreshImage="false" CaptchaImage-BackgroundNoise="Extreme" CaptchaImage-EnableCaptchaAudio="false"
                                CaptchaImage-TextColor="Black" CaptchaImage-TextLength="6" CaptchaImage-UseAudioFiles="True" CaptchaImage-Width="400" Font-Size="11pt" Width="400px"
                                ForeColor="#990000" ValidatedTextBoxID="txtvalida" TabIndex="5">
                                <CaptchaImage BackgroundNoise="Extreme" EnableCaptchaAudio="false" TextColor="Black" TextLength="6" UseAudioFiles="True" Width="180">
                                </CaptchaImage>
                            </telerik:RadCaptcha>
                            <%-- <asp:Button ID="btn_RadCaptcha" runat="server" Text="Generar nuevo texto" >
                            </asp:Button>--%>
                        </div>
                        <div class="regusu_secc_table_RadCaptcha03">
                            <telerik:RadButton ID="btn_RadCaptcha" runat="server" Text="Generar nuevo texto" TabIndex="6" ToolTip="Generar nuevo texto" 
                                Width="130px" Height="20px" HoveredCssClass="goButtonClassHov_contraseña" CssClass="boton_color_contraseña">
                                <%--<Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>--%>
                            </telerik:RadButton>
                        </div>
                        <%--<div class="regusu_secc_table_RadCaptcha">
                            <strong>Digite el texto mostrado en la imagen: </strong>
                            <telerik:RadTextBox ID="txt_regusu_RadCaptcha" runat="server" Width="260px" LabelWidth="112px"
                                TabIndex="15" MaxLength="6">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese el texto correcto"
                                ControlToValidate="txt_regusu_RadCaptcha" ValidationGroup="grupo01" Display="Dynamic"
                                Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"></asp:RequiredFieldValidator>
                        </div>--%>
                    </div>
                    <div class="regusu_bloque_col2_parrafo">
                        <div class="regusu_secc_table_boton">
                            <%--  <telerik:RadButton ID="btnrecordar" runat="server" Text="Enviar" Font-Bold="True"
                                    TabIndex="6" ToolTip="Enviar Contraseña" Width="80px">
                                </telerik:RadButton>--%>
                           <%-- <telerik:RadButton ID="btnrecordar" runat="server" Text="Enviar" TabIndex="7" ToolTip="Enviar Contraseña"
                                Width="100px" Height="20px" HoveredCssClass="goButtonClassHov" CssClass="boton_color">
                                <Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>
                            </telerik:RadButton>--%>
                            <telerik:RadButton ID="Btnrecordar" runat="server" Width="81px" Height="22px" Text="Enviar" HoveredCssClass="goButtonClassHov" 
                                     ForeColor="White" ToolTip="Enviar Contraseña">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                </Image>
                            </telerik:RadButton>
                        </div>
                        <div class="regusu_secc_table_boton2">
                            <%-- <telerik:RadButton ID="btnlimpiar" runat="server" Text="Limpiar" Font-Bold="True"
                                    TabIndex="7" ToolTip="Limpiar Controles" Width="80px">
                                </telerik:RadButton>--%>
                            <%--<telerik:RadButton ID="btnlimpiar" runat="server" Text="Limpiar" TabIndex="8" ToolTip="Limpiar Controles"
                                Width="100px" Height="20px" HoveredCssClass="goButtonClassHov" CssClass="boton_color">
                                <Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>
                            </telerik:RadButton>--%>
                            <telerik:RadButton ID="Btnlimpiar" runat="server" Width="81px" Height="22px" Text="Limpiar" HoveredCssClass="goButtonClassHov"
                                     ForeColor="White" ToolTip="Limpiar Controles">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                </Image>
                            </telerik:RadButton>
                        </div>
                        <div class="regusu_secc_table_boton1">
                            <telerik:RadButton ID="BtnSalir" runat="server" Width="81px" Height="22px" Text="Regresar" HoveredCssClass="goButtonClassHov"
                                     ForeColor="White" ToolTip="Regresar al Inicio">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                </Image>
                            </telerik:RadButton>
                        </div>
                    </div>
                </div>
                <%-- <div id="footer">
                    <p class="leftt">
                        @ Copyright Carseg S.A. Derechos Reservados 2014<br />
                    </p>
                </div>--%>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="txt_regusu_email01">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="lbl_prg_id_01"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lbl_regusu_pregunta01"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta01"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnproxima"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_respuesta01"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadCaptcha1"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="btn_RadCaptcha"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnrecordar"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="txt_regusu_respuesta01">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="Btnproxima">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="lbl_prg_id_01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lbl_regusu_pregunta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnrecordar" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="btn_RadCaptcha">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadCaptcha1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="Btnrecordar">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lbl_prg_id_01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lbl_regusu_pregunta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnproxima" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadCaptcha1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnrecordar" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="Btnlimpiar">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_email01"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lbl_prg_id_01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lbl_regusu_pregunta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta01"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnproxima"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_respuesta01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadCaptcha1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Btnrecordar"  LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                    EnableRoundedCorners="True" Overlay="True">
                </telerik:RadNotification>
            </div>
        </form>
    </body>
</html>
