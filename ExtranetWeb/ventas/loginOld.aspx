<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="loginOld.aspx.vb" Inherits="ExtranetWeb.loginOld" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HunterOnline Ecuador| Pagos de Servicios www.hunteronline.com.ec </title>
    <meta name="title" content="HunterOnline Ecuador |  Pagos de Servicios www.hunteronline.com.ec" />
    <meta name="description" content="HunterOnline Ecuador | Pagos de Servicios renovación de servicios online, Rastreo, ubicación y recuperación de vehículos robados; control y monitoreo de vehículos, motos, taxis, flotas, containers, camiones, carga, personal, aviones, barcos; desde cualquier lugar y a cualquier hora." />
    <meta name="keywords" content="HunterOnline Ecuador | Pagos de Servicios renovación de servicios online, Rastreo, ubicación y recuperación de vehículos robados; control y monitoreo de vehículos, motos, taxis, flotas, containers, camiones, carga, personal, aviones, barcos; desde cualquier lugar y a cualquier hora." />
    <meta name="robots" content="ALL" />
    <meta name="revisit-after" content="1 days" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0;" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <link href="../styles/menunew.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilologinnew.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" media="screen and ( min-width:751px) and ( max-width:1250px)" href="../styles/estilologinnewTablet.css" />
    <link rel="stylesheet" media="screen and ( min-width:501px) and (max-width:750px)" href="../styles/estilologinnewMobil.css" />
    <link rel="stylesheet" media="screen and (max-width: 500px)" href="../styles/estilologinnewMini.css" />
    <link href="../styles/estiloinicio.css" rel="stylesheet" type="text/css" />
    <script src="../script/jquery.js" type="text/javascript"></script>
    <script src="../script/jqueryui.js" type="text/javascript"></script>
    <script type="text/javascript" id="telerikClientEvents1">
//<![CDATA[

        function txtUsuario_OnKeyPress(sender, args) {
            //Add JavaScript handler code here
            if (args.get_keyCode() > 31 && (args.get_keyCode() < 48) || args.get_keyCode() > 57) {
                args.set_cancel(true);
            }
        }
//]]>
    </script>


     <script language="javascript" type="text/javascript">
         var message = "© Carseg S.A. 2020. Todos los derechos reservados";

         function clickIE4() {
             if (event.button == 2) {
                 alert(message);
                 return false;
             }
         }

         function clickNS4(e) {
             if (document.layers || document.getElementById && !document.all) {
                 if (e.which == 2 || e.which == 3) {
                     alert(message);
                     return false;
                 }
             }
         }

         if (document.layers) {
             document.captureEvents(Event.MOUSEDOWN);
             document.onmousedown = clickNS4;
         }
         else if (document.all && !document.getElementById) {
             document.onmousedown = clickIE4;
         }

         document.oncontextmenu = new Function("alert(message);return false")
          
    </script>
</head>
<body id="body2">
    <script type="text/javascript">
        if (typeof em5 === 'undefined') {
            var em5 = window.addEventListener ? "addEventListener" : "attachEvent";
            var er5 = window[em5]; var me5 = em5 == "attachEvent" ? "onmessage" : "message";
            er5(me5, function (e) {
                var s5 = e.data;
                if (s5.substring(0, 10) == "changeSize") {
                    document.getElementById(s5.substring(s5.indexOf("html5maker") + 10)).style.height = s5.substring(10, s5.indexOf("html5maker"));
                }
            }, false);
        }
    </script>
    <%--    <script type="text/javascript">
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/es_ES/sdk.js#xfbml=1&version=v2.0";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));

        !function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (!d.getElementById(id)) {
                js = d.createElement(s);
                js.id = id; js.src = "//platform.twitter.com/widgets.js";
                fjs.parentNode.insertBefore(js, fjs);
            }
        } (document, "script", "twitter-wjs");
    </script>--%>
    <form id="form1" runat="server">
    <div>
        <div class="inhalt">
            <div id="banner2">
                <div>
                    <div class="banner3">
                        <div class="animacion_carga_inicial">
                             <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%">
                             </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="login_sec">
              <%-- <div class="login_sec_004_1" runat="server" id="navegatorwrong" visible="false">
                    <asp:Label ID="lblMsg002" runat="server" CssClass="login_sec_004_2"></asp:Label>
                    <a href="http://www.google.com/intl/es-419/chrome/business/browser/" target="_blank">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/background/google_chrome.jpg"
                            BorderColor="Transparent" Width="20" />
                    </a><a href="http://www.mozilla.org/es-ES/firefox/new/" target="_blank">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/background/firefox.jpg"
                            BorderColor="Transparent" Width="20" />
                    </a>
                </div>--%>
                <%--<div class="login_sec_animation">
                </div>--%>
                <div class="login_sec_006">
                    <div class="login_sec_001">
                        <div class="login_sec_003">
                            <asp:Label ID="lblMsg001" runat="server"></asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txtUsuario" >* Debe de ingresar Ruc o Cédula
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txtPassword" >* Debe de ingresar el password
                            </asp:RequiredFieldValidator>
                            <br />
                        </div>
                        <div class="login_sec_002">
                            <div style="width: 220px; height: 45px;">
                                <h3 style="color: #FFFFFF">
                                    Usuario
                                </h3>
                                <telerik:RadTextBox ID="txtUsuario" runat="server" DisplayText="" LabelWidth="64px" EmptyMessage="Ingrese Ruc o Cédula"
                                    type="text" value="" Width="140px" MaxLength="13" Rows="1" Skin="Default" TabIndex="1">
                                </telerik:RadTextBox>
                            </div>
                            <div style="width: 220px; height: 45px;">
                                <h3 style="color: #FFFFFF">
                                    Password
                                </h3>
                                <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" Width="140px" MaxLength="16"
                                    Skin="Default" TabIndex="2">
                                </telerik:RadTextBox>
                            </div>
                            <div class="login_sec_011">
                                <telerik:RadButton ID="btnLogin" runat="server" Width="80px" Height="26px" Text="Ingresar"
                                    HoveredCssClass="goButtonloginHov" CssClass="boton_login" TabIndex="3"
                                    style="margin-left:-62px !important;">
                                    <%-- <Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image> --%>
                                </telerik:RadButton>
                            </div>
                        </div>
                        <div class="login_sec_005">
                           <%-- <div class="login_sec_009">
                            </div>--%>
                            <div class="login_sec_008">
                                <asp:HyperLink ID="hyplink" runat="server" NavigateUrl="~/ventas/registrousuario.aspx"
                                    ForeColor="White"> Cree su cuenta 
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div class="login_sec_005">
                            <div class="login_sec_007">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ventas/recuperarcontraseña.aspx"
                                    ForeColor="White"> Recuperar Contraseña
                                </asp:HyperLink>
                            </div>
                        </div>
                      
                    </div>
                </div>
            </div>
            <div id="footer">
                <div class="copyright">
                    <a title="Términos de Uso y Políticas de Privacidad" href="termino.aspx" target="_parent"
                        style="color: #FFFFFF">Términos de Uso y Privacidad</a>
                        | 
                     <a title="Contactenos Clientes" href="ContactenosCliente.aspx" target="_parent" style="color: #FFFFFF">Contáctenos </a>
                        | 
                     <a title="Manual de Usuario" href="../manual/ManualUsuarioHOnline.pdf" target="_parent" style="color: #FFFFFF">Descargar Manual de Usuario </a>
                    <br />
                    Copyright Carseg S.A. Derechos Reservados 2020
                </div>
                <div class="login_secc_ssl_certificado">
                    <table width="100%" border="0" cellpadding="0" cellspacing="5" title="Haga clic para verificar: este sitio elige SSL de Symantec para las comunicaciones confidenciales y el comercio electrónico seguro">
                        <tr>
                            <td width="95%" align="center" valign="top">
                                <script type="text/javascript" src="https://seal.verisign.com/getseal?host_name=www.hunteronline.com.ec&amp;size=XS&amp;use_flash=YES&amp;use_transparent=SI&amp;lang=es"></script>
<%--                                <br />
                                <a href="https://www.symantec.com/es/es/verisign/ssl-certificates" target="_blank"
                                    style="color: white; text-decoration: none; font: bold 8px verdana; letter-spacing: 0px;
                                    text-align: center; margin: 0px; padding: 0px;">Acerca de los Certificados SSL
                                </a>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel1" runat="server">
        <asp:Image ID="myImage" runat="server" Width="128px" Height="26px" AlternateText="Loading..."
            ImageAlign="Middle" ImageUrl="../images/gif/loading3.gif" />
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnLogin">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg001" UpdatePanelHeight="2px" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <%--<telerik:AjaxUpdatedControl ControlID="Image4" LoadingPanelID="LoadingPanel1" />--%>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="LoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Button1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Button1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="80px"
        Position="Center" Width="358px" EnableRoundedCorners="True" EnableShadow="True"
        Font-Bold="True" Font-Size="Medium" Opacity="95" ForeColor="Black" Overlay="True">
    </telerik:RadNotification>
    <telerik:RadWindow ID="modalPopupNavegador" runat="server" Width="500px" Height="240px"
        Modal="true" Behaviors="Close" CssClass="element1" Title="Sugerencia de Navegación"
        Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False">
        <ContentTemplate>
            <div class="masterradwindowsdetalle_login">
                <br />
                <font class="letra_login">Estimado Cliente</font>
                <br />
                <br />
                Para una mejor experiencia en la ejecución de nuestro sitio <font class="letra_subrayado">
                    www.hunterOnLine.com.ec</font> le sugerimos utilizar los siguientes navegadores:
                Google Chrome o Mozilla.
                <br />
                <br />
                <div class="masterradwindowsdetalle_login_center">
                    <font class="letra_login">Descargar</font>
                    <br />
                    <br />
                    <a href="http://www.google.com/intl/es-419/chrome/business/browser/" target="_blank">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/background/chome.png" BorderColor="Transparent"
                            Width="32" /></a> <a href="http://www.mozilla.org/es-ES/firefox/new/" target="_blank">
                                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/background/Mozilla.png"
                                    BorderColor="Transparent" Width="32" /></a>
                </div>
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadWindow ID="modalPopupIE" runat="server" Width="500px" Height="220px"
        Modal="true" Behaviors="Close" CssClass="element" Title="Aviso Importante" Skin="MyCustomSkin"
        VisibleStatusbar="False" EnableEmbeddedSkins="False">
        <ContentTemplate>
            <div class="masterradwindowsdetalle_login">
                <font class="letra_login">Estimado Cliente</font>
                <br />
                <br />
                Usted está usando una <strong>versión inferior </strong>de Internet Explorer
                <br />
                Por favor actualicela para que el portal web funcione correctamente
                <br />
            </div>
        </ContentTemplate>
    </telerik:RadWindow>
    </form>
</body>
</html>
