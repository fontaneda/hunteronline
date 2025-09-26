<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="contrato.aspx.vb" Inherits="ExtranetWeb.contrato" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HunterOnline</title>
    <meta name="robots" content="ALL" />
    <meta name="revisit-after" content="1 days" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=9; IE=10; IE=EmulateIE8; IE=7; IE=EmulateIE7 ; IE=edge" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
   <%-- <link href="../styles/menunew.css" rel="stylesheet" type="text/css" />
    <link href="../styles/slidenew.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estiloinicio.css" rel="stylesheet" type="text/css" />--%>
    <link href="../styles/estilocontrato.css" rel="stylesheet" type="text/css" />
    <script src="../script/js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../script/js/jquery.js" type="text/javascript"></script>
    <%--<script src="../script/js/slider/slide.js" type="text/javascript"></script>
    <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
    <script language="javascript" type="text/javascript">
        var message = "© Carseg S.A. 2020. Todos los derechos reservados.";
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
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-67324308-1', 'auto');
        ga('send', 'pageview');
    </script>
    <script type="text/javascript">
        function checkKey(evt) {
            if (evt.ctrlKey)
                alert(message);
        }
    </script>
</head>
<body onload="actualizaReloj();" onkeydown="checkKey(event)">
    <form id="form1" runat="server">
    <div id="container_contrato">
        <div id="banner5">
            <div class="logo_image">
            </div>
            <div class="content_user">
                <div class="content_user_info">
                    <h4>
                        Hola!
                    </h4>
                    <h5>
                        <asp:Label ID="lblUserName" runat="server" Text="" CssClass="content_user_label content_user_contrato"
                            Width="240" />
                    </h5>
                </div>
                 <div class="content_user_info">
                    <h4><asp:Label ID="Lblfecha" runat="server" Text="fecha" CssClass="content_user_label content_user_contrato"/>  </h4>
                 </div>
            </div>
            <div style="display: none">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
            </div>
        </div>
        
        <div class="content_principal_contrato">
            <div class="content_principal_bloque_contrato">
                <div id="divlistas" class="content_detalle_2" runat="server">
                    <div style="overflow: auto; -webkit-overflow-scrolling: touch;">
                       <%-- <embed id="myframe" src="" name="myframe" runat="server" width="100%" height="420"
                            visible="false"></embed>--%>
                        <iframe id="myframe" src="" name="myframe" runat="server" width="100%" height="420"
                            visible="false"    ></iframe>
                    </div>
                </div>
                 <div class="regusu_bloque_col8_parrafo">
                    <br />
                </div>
                <div class="regusu_bloque_col8_parrafo">
                    <br />
                </div>
               <%-- <div class="regusu_bloque_col8_parrafo">
                    <br />
                </div>
                <div class="regusu_bloque_col8_parrafo">
                    <br />
                </div>--%>
                <div class="column01_cell_boton01"></div>
                <div class="column01_cell_boton01"></div>
                <%--<div class="column01_cell_boton01"></div>--%>
                <div class="regusu_bloque_col9_parrafo"> 
                    <strong> Al hacer clic en "Aceptar", acepta los términos y condiciónes del contrato del producto adquirido. </strong>
                </div>
                <div class="column01_cell_boton02">
                    <%--<div class="column01_cell_boton01"></div>
                    <div class="column01_cell_boton01"></div>
                    <div class="column01_cell_boton01">
                        <telerik:RadButton ID="Btncancelar" runat="server" Width="80px" Height="22px" Text="Cancelar"
                            HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Cancelar"
                            TabIndex="21" ValidationGroup="grupo01">
                            <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                            </Image>
                        </telerik:RadButton>
                     </div>
                     --%>
                    
                     <div class="column01_cell_boton01">
                        <telerik:RadButton ID="Btnaceptar" runat="server" Width="80px" Height="22px" Text="Aceptar"
                            HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Aceptar Contrato"
                            TabIndex="21" ValidationGroup="grupo01">
                            <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                            </Image>
                        </telerik:RadButton>   
                     </div>
                </div>
                
            </div>
        </div>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1"
            UpdatePanelsRenderMode="Inline">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="Btnaceptar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Btnaceptar" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="Btncancelar" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function actualizaReloj() {
                marcacion = new Date();
                Hora = marcacion.getHours();
                Minutos = marcacion.getMinutes();
                Segundos = marcacion.getSeconds();
                if (Hora <= 9)
                    Hora = "0" + Hora;
                if (Minutos <= 9)
                    Minutos = "0" + Minutos;
                if (Segundos <= 9)
                    Segundos = "0" + Segundos;
                var Dia = new Array("Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom");
                var Mes = new Array("Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic");
                var Hoy = new Date();
                var Anio = Hoy.getFullYear();
                var Fecha = Dia[Hoy.getDay()] + ", " + Hoy.getDate() + "/" + Mes[Hoy.getMonth()] + "/" + Anio + " ";
                var Inicio, Script, Final, Total;
                Inicio = " ";
                Script = Fecha + Hora + ":" + Minutos;
                Final = " ";
                Total = Inicio + Script + Final;
                document.getElementById('Fecha_Reloj').innerHTML = Total;
                setTimeout("actualizaReloj()", 1000);
            }
        </script>
        <script type="text/javascript">
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
        </script>
    </telerik:RadCodeBlock>
       <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
            EnableRoundedCorners="True" Overlay="True">
        </telerik:RadNotification>
    </form>
</body>
</html>
