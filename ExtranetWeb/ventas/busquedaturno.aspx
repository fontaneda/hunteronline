<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="busquedaturno.aspx.vb" Inherits="ExtranetWeb.busquedaturno" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilovehiculoturno.css" rel="stylesheet" type="text/css" />
        <title>Seleccion de turno</title>
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
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }
            function AdjustRadWidow() {
                var oWindow = GetRadWindow();
                setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
            }
            function ChromeSafariFix(oWindow) {
                var iframe = oWindow.get_contentFrame();
                var body = iframe.contentWindow.document.body;
                setTimeout(function () {
                    var height = body.scrollHeight;
                    var width = body.scrollWidth;
                    var iframeBounds = $telerik.getBounds(iframe);
                    var heightDelta = height - iframeBounds.height;
                    var widthDelta = width - iframeBounds.width;
                    if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                    if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                    oWindow.center();
                }, 310);
            }
            function returnParent() {
                var oWnd = GetRadWindow();
                oWnd.close();
            }
            function returnToParent(valor) {
                var oArg = new Object();
                oArg.turno = valor;
                var oWnd = GetRadWindow();
                if (oArg.turno) {
                    oWnd.close(oArg);
                } else {
                    alert("Datos no válidos.");
                }
            }
        </script> 
        <script type="text/javascript">
            var message = "© Carseg S.A. 2020. Todos los derechos reservados..";
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
    <body style="background-color:#fff">
      <form id="form2" method="post" runat="server">
        <div id="tooltipcustom" class="divtooltip_custom" >
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">                
                </telerik:RadScriptManager> 
            <div id="Div1" class="divtooltip_custom_arrowup" runat="server"></div>
        </div>
        <div id="Div10" class="VehiculoTurnoContenidoTitulo" runat="server" >
                Calendario de Turnos
        </div> 
        <div id="Div11" class="VehiculoTurnoContenidoDiv" runat="server" ></div> 
        <div id="Div12" class="VehiculoTurnoPanel" runat="server">
            <div class="VehiculoTurnoPanelTitulo">
                <asp:Label id="lbltitulo" runat="server" Text="Trabajos a realizar" />
            </div>
            <div class="VehiculoTurnoPanelLabel">
                <asp:Label id="lbltipoturno" runat="server" Text="Sitio" />
            </div>
            <div class="VehiculoTurnoPanelCombobox">
                <telerik:RadComboBox ID="CmbTipoturno" runat="server" Width="100%" AutoPostBack="True" EnableTextSelection="False" BorderStyle="None" />
            </div>
            <div id="divtallerlabel" class="VehiculoTurnoPanelLabel" runat="server">
                <asp:Label id="lbltalleres" runat="server" Text="Taller" />
            </div>
            <div id="divtallertext" class="VehiculoTurnoPanelTextboxTaller2" runat="server">
                <telerik:RadComboBox ID="cmbtaller" runat="server" Width="100%" AutoPostBack="True" EnableTextSelection="False" BorderStyle="None" />
            </div>   
            <div ID="divboton" class="VehiculoTurnoPanelButton" runat="server" style="margin:100px 0px 0px 225px;">
                <telerik:RadButton ID="BtnVerturno" runat="server" Width="120px" Height="25px" Text="Confirmar Turno" ForeColor="#3E3E3E" BackColor="Transparent"
                    BorderStyle="None" BorderWidth="0px" ButtonType="ToggleButton">
                </telerik:RadButton>
            </div>
        </div>   
        <div id="Div13" class="VehiculoTurnoContenido" runat="server" >
            <div id="Div14" class="VehiculoTurnoContenidoInfo" runat="server" >
                <div id="Div15" class="VehiculoTurnoContenidoImagenDescriptivoA" runat="server"></div> 
                <div id="Div16" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server" >
                    Mi turno
                </div>
                <div id="Div17" class="VehiculoTurnoContenidoImagenDescriptivoB" runat="server"></div> 
                <div id="Div18" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server" >
                    Libre
                </div>
                <div id="Div19" class="VehiculoTurnoContenidoImagenDescriptivoC" runat="server"></div> 
                <div id="Div20" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server" >
                    Ocupado
                </div>
                <div id="Div21" class="VehiculoTurnoContenidoImagenDescriptivoD" runat="server"></div> 
                <div id="Div22" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server" >
                    Fuera/Horario
                </div>
            </div> 
            <div id="Div23" class="VehiculoTurnoContenidoBotonesCalendario" runat="server"></div>
            <div id="Div24" class="VehiculoTurnoContenidoBotonesCalendario" runat="server">
                <div id="Div25" class="VehiculoTurnoContenidoBotonesCalendarioAnterior" runat="server" title="Anterior">
                    <asp:ImageButton ID="BtnCalendarioanterior" runat="server" BackColor="Transparent"
                        Width="30px" Height="40px" ImageUrl="../images/background/calendarioanterior.png" />
                </div>
            </div>
            <div id="DivCalendario" class="VehiculoTurnoContenidoCalendario" runat="server" >
                <div id="Div26" class="VehiculoTurnoContenidoCalendarioCabecera" runat="server" >
                    <div id="Div27" class="VehiculoTurnoContenidoCalendarioCabeceraHora" runat ="server">
                        Hora
                    </div>
                    <div id="Div28" class="VehiculoTurnoContenidoCalendarioCabeceraFecha" runat ="server">
                        <asp:Label id="lblfechacalendario" runat="server" Text="Agosto 4 de 2014 - 10 de Agosto de 2014" />
                    </div>
                    <div id="Div29" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                        Lun
                        <asp:Label id="lbldia1" runat="server" Text ="1" Width="100%" />
                    </div>
                    <div id="Div30" class="VehiculoTurnoContenidoCalendarioDia" runat="server" >
                        Mar
                        <asp:Label id="lbldia2" runat="server" Text ="2" Width="100%" />
                    </div>
                    <div id="Div31" class="VehiculoTurnoContenidoCalendarioDia" runat="server" >
                        Mie
                        <asp:Label id="lbldia3" runat="server" Text ="3" Width="100%" />
                    </div>
                    <div id="Div32" class="VehiculoTurnoContenidoCalendarioDia" runat="server" >
                        Jue
                        <asp:Label id="lbldia4" runat="server" Text ="4" Width="100%" />
                    </div>
                    <div id="Div33" class="VehiculoTurnoContenidoCalendarioDia" runat="server" >
                        Vie
                        <asp:Label id="lbldia5" runat="server" Text ="5" Width="100%" />
                    </div>
                    <div id="Div34" class="VehiculoTurnoContenidoCalendarioDia" runat="server" >
                        Sab
                        <asp:Label id="lbldia6" runat="server" Text ="6" Width="100%" />
                    </div>
                    <div id="Div35" class="VehiculoTurnoContenidoCalendarioDia" runat="server" >
                        Dom
                        <asp:Label id="lbldia7" runat="server" Text ="7" Width="100%" />
                    </div>
                </div> 
                <div id="Div36" class="VehiculoTurnoContenidoCalendarioespacio" runat="server"></div> 
                <div id="Div37" class="VehiculoTurnoContenidoCalendarioCuerpo" runat="server">
                    <div id="Div38" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        08:00
                    </div>
                    <div id="cal1" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">                    
                        <asp:ImageButton id="imgdia1hora1" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" 
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" OnClientClick="imgdia_Click()" Visible="false" />
                        <asp:LinkButton id="lbldia1hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal2" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png"  BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal3" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal4" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal5" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia5hora1" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal6" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora1" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png"  BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora1" runat="server" Width="100%" Height="100%"  BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal7" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora1" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia7hora1" runat="server" Width="100%" Height="100%"  BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div39" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        09:00
                    </div>
                    <div id="cal8" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia1hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" OnClientClick="imgdia_Click()" Visible="false"/>
                        <asp:LinkButton id="lbldia1hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df"  OnClientClick="lbldia_Click()" Visible="false" />
                    </div>
                    <div id="cal9" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora2" runat="server" Width="100%" Height="100%"  BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal10" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora2" runat="server" Width="100%" Height="100%"  BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal11" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal12" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia5hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal13" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora2" runat="server" Width="100%" Height="100%"  BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal14" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora2" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia7hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div40" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        10:00
                    </div>
                    <div id="cal15" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia1hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" OnClientClick="imgdia_Click()" Visible="false" />
                        <asp:LinkButton id="lbldia1hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" Visible="false" />
                    </div>
                    <div id="cal16" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal17" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal18" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal19" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia5hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal20" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal21" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia7hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div41" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        11:00
                    </div>
                    <div id="cal22" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia1hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia1hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal23" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()" />
                        <asp:LinkButton id="lbldia2hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal24" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()" />
                        <asp:LinkButton id="lbldia3hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal25" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()" />
                        <asp:LinkButton id="lbldia4hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal26" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia5hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()" />
                        <asp:LinkButton id="lbldia5hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal27" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()" />
                        <asp:LinkButton id="lbldia6hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal28" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()" />
                        <asp:LinkButton ID="lbldia7hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div42" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        12:00
                    </div>
                    <div id="cal29" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia1hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia1hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal30" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal31" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal32" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal33" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia5hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora5" runat="server" Width="100%" Height="100%" BackColor="#FFFEEB" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal34" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal35" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora5" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" />
                        <asp:LinkButton id="lbldia7hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div43" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        13:00
                    </div>
                    <div id="cal36" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia1hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png"  BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia1hora6" runat="server" Width="100%" Height="100%"  BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal37" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal38" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal39" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal40" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia5hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora6" runat="server" Width="100%" Height="100%" BackColor="#FFFEEB" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal41" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal42" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia7hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div44" class="VehiculoTurnoContenidoCalendarioHora" runat="server" >
                        14:00
                    </div>
                    <div id="cal43" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia1hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia1hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal44" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia2hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal45" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia3hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal46" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia4hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div ID="cal47" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton ID="imgdia5hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora7" runat="server" Width="100%" Height="100%" BackColor="#FFFEEB" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal48" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia6hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal49" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                        <asp:ImageButton id="imgdia7hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia7hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="Div45" class="VehiculoTurnoContenidoCalendarioHora" runat="server" style="visibility:hidden;">
                        15:00
                    </div>
                    <div id="cal50" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia1hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia1hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal51" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia2hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia2hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal52" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia3hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia3hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal53" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia4hora8" runat="server" Width="100%" Height="100%"  onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia4hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal54" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia5hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia5hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal55" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia6hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia6hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                    <div id="cal56" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                        <asp:ImageButton id="imgdia7hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);"
                            BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false"  OnClientClick="imgdia_Click()"/>
                        <asp:LinkButton id="lbldia7hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                    </div>
                </div>
            </div>
            <div id="Div46" class="VehiculoTurnoContenidoBotonesCalendario" runat="server">
                <div id="Div47" class="VehiculoTurnoContenidoBotonesCalendarioSiguiente" runat="server" title="Siguiente">
                    <asp:ImageButton ID="BtnCalendariosiguiente" runat="server" BackColor="Transparent"
                        Width="30px" Height="40px" ImageUrl="../images/background/calendariosiguiente.png" />
                </div>            
            </div> 
        </div> 
        <div id="Div51" class="VehiculoTurnoContenidoDiv" runat="server" >
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="cmbtaller">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" />
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rntdialog_rbt_si">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="cmbtaller"  UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="CmbTipoturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rntdialog_rbt_no">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="cmbtaller"  UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="CmbTipoturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnCalendarioanterior">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" />
                            <telerik:AjaxUpdatedControl ControlID="cmbtaller" />
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="DivCalendario">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="cmbtaller" />
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntmensaje" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora1">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora1">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" /> 
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora2">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora2">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora2">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora2">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora2">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora2">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora2">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora3">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora3">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora3">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora3">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora3">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora3">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora3">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora4">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora4">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora4">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora4">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora4">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora4">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora4">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora5">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora5">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora5">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora5">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora5">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora5">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>

                    <telerik:AjaxSetting AjaxControlID="imgdia7hora5">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora6">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora6">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora6">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora6">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora6">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora6">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora6">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>

                    <telerik:AjaxSetting AjaxControlID="imgdia1hora7">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia2hora7">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora7">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora7">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora7">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora7">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora7">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia1hora8">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>

                    <telerik:AjaxSetting AjaxControlID="imgdia2hora8">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia3hora8">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia4hora8">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia5hora8">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia6hora8">
                        <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="imgdia7hora8">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" UpdatePanelCssClass="" />
                            <telerik:AjaxUpdatedControl ControlID="rntdialog" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                
                    <telerik:AjaxSetting AjaxControlID="BtnCalendariosiguiente">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" />
                            <telerik:AjaxUpdatedControl ControlID="BtnVerturno" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnVerturno">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="DivCalendario" UpdatePanelCssClass="" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadNotification ID="rntmensaje" runat="server" Animation="Fade" Height="12px" Opacity="90"
                Position="Center" Style="margin-left: 1px" Width="400px" ShowCloseButton="true"
                EnableRoundedCorners="true" VisibleTitlebar="true">
            </telerik:RadNotification>
            <telerik:RadNotification ID="rntdialog" runat="server" Animation="Fade" Height="12px" Opacity="90" Position="Center" Style="margin-left: 1px" Width="400px"
                 ShowCloseButton="true" AutoCloseDelay="0" EnableRoundedCorners="true" VisibleTitlebar="true">
                <ContentTemplate>
                    <asp:Label runat="server" ID="rntdialog_lbl" Text="Aqui va el mensaje" style="margin-left:20px; width:100%"></asp:Label>
                    <telerik:RadButton  ID="rntdialog_rbt_si" Text="Si" CommandName="Si" ButtonType="StandardButton" width="80px" 
                            Font-Bold="true" runat="server" OnClick="RntdialogRbtSiClick" style="margin-top:30px; margin-left:-80px;"/>
                    <telerik:RadButton  ID="rntdialog_rbt_no" Text="No" CommandName="No" ButtonType="StandardButton" width="80px" 
                            Font-Bold="true" runat="server" OnClick="RntdialogRbtNoClick" style="margin-top:30px; margin-left:20px" />
                </ContentTemplate>
            </telerik:RadNotification>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function Tooltipmodaljs(sender) {
                        var arreglotooltip = sender.alt.split(',');
                        var tttitulo = document.getElementById("tooltipcustomtitulo");
                        var ttplaca = document.getElementById("tooltipcustomplaca");
                        var tttaller = document.getElementById("tooltipcustomtaller");
                        var ttciudad = document.getElementById("tooltipcustomciudad");
                        var ttfecha = document.getElementById("tooltipcustomfecha");
                        var tttrabajos = document.getElementById("tooltipcustomtrabajos");
                        var ttorden = document.getElementById("tooltipcustomOrden");

                        tttitulo.innerHTML = arreglotooltip[0];
                        ttplaca.innerHTML = arreglotooltip[2];
                        tttaller.innerHTML = arreglotooltip[1];
                        ttciudad.innerHTML = arreglotooltip[3];
                        ttfecha.innerHTML = arreglotooltip[4];
                        tttrabajos.innerHTML = arreglotooltip[5];
                        ttorden.innerHTML = arreglotooltip[6];

                        var positiontop = sender.offsetTop + 30
                        var positionleft = sender.offsetLeft - 130
                        var tooltip = document.getElementById("tooltipcustom");

                        if (tooltip.style.visibility == "visible") {
                            tooltip.style.visibility = "hidden";
                        } else {
                            var control = sender.name.replace("ctl00$ContentPlaceHolder1$", "");
                            switch (control) {
                                case "imgdia1hora1":
                                    document.getElementById("cal1").title = "";
                                    break;
                                case "imgdia2hora1":
                                    document.getElementById("cal2").title = "";
                                    break;
                                case "imgdia3hora1":
                                    document.getElementById("cal3").title = "";
                                    break;
                                case "imgdia4hora1":
                                    document.getElementById("cal4").title = "";
                                    break;
                                case "imgdia5hora1":
                                    document.getElementById("cal5").title = "";
                                    break;
                                case "imgdia6hora1":
                                    document.getElementById("cal6").title = "";
                                    break;
                                case "imgdia7hora1":
                                    document.getElementById("cal7").title = "";
                                    break;
                                case "imgdia1hora2":
                                    document.getElementById("cal8").title = "";
                                    break;
                                case "imgdia2hora2":
                                    document.getElementById("cal9").title = "";
                                    break;
                                case "imgdia3hora2":
                                    document.getElementById("cal10").title = "";
                                    break;
                                case "imgdia4hora2":
                                    document.getElementById("cal11").title = "";
                                    break;
                                case "imgdia5hora2":
                                    document.getElementById("cal12").title = "";
                                    break;
                                case "imgdia6hora2":
                                    document.getElementById("cal13").title = "";
                                    break;
                                case "imgdia7hora2":
                                    document.getElementById("cal14").title = "";
                                    break;
                                case "imgdia1hora3":
                                    document.getElementById("cal15").title = "";
                                    break;
                                case "imgdia2hora3":
                                    document.getElementById("cal16").title = "";
                                    break;
                                case "imgdia3hora3":
                                    document.getElementById("cal17").title = "";
                                    break;
                                case "imgdia4hora3":
                                    document.getElementById("cal18").title = "";
                                    break;
                                case "imgdia5hora3":
                                    document.getElementById("cal19").title = "";
                                    break;
                                case "imgdia6hora3":
                                    document.getElementById("cal20").title = "";
                                    break;
                                case "imgdia7hora3":
                                    document.getElementById("cal21").title = "";
                                    break;
                                case "imgdia1hora4":
                                    document.getElementById("cal22").title = "";
                                    break;
                                case "imgdia2hora4":
                                    document.getElementById("cal23").title = "";
                                    break;
                                case "imgdia3hora4":
                                    document.getElementById("cal24").title = "";
                                    break;
                                case "imgdia4hora4":
                                    document.getElementById("cal25").title = "";
                                    break;
                                case "imgdia5hora4":
                                    document.getElementById("cal26").title = "";
                                    break;
                                case "imgdia6hora4":
                                    document.getElementById("cal27").title = "";
                                    break;
                                case "imgdia7hora4":
                                    document.getElementById("cal28").title = "";
                                    break;
                                case "imgdia1hora5":
                                    document.getElementById("cal29").title = "";
                                    break;
                                case "imgdia2hora5":
                                    document.getElementById("cal30").title = "";
                                    break;
                                case "imgdia3hora5":
                                    document.getElementById("cal31").title = "";
                                    break;
                                case "imgdia4hora5":
                                    document.getElementById("cal32").title = "";
                                    break;
                                case "imgdia5hora5":
                                    document.getElementById("cal33").title = "";
                                    break;
                                case "imgdia6hora5":
                                    document.getElementById("cal34").title = "";
                                    break;
                                case "imgdia7hora5":
                                    document.getElementById("cal35").title = "";
                                    break;
                                case "imgdia1hora6":
                                    document.getElementById("cal36").title = "";
                                    break;
                                case "imgdia2hora6":
                                    document.getElementById("cal37").title = "";
                                    break;
                                case "imgdia3hora6":
                                    document.getElementById("cal38").title = "";
                                    break;
                                case "imgdia4hora6":
                                    document.getElementById("cal39").title = "";
                                    break;
                                case "imgdia5hora6":
                                    document.getElementById("cal40").title = "";
                                    break;
                                case "imgdia6hora6":
                                    document.getElementById("cal41").title = "";
                                    break;
                                case "imgdia7hora6":
                                    document.getElementById("cal42").title = "";
                                    break;
                                case "imgdia1hora7":
                                    document.getElementById("cal43").title = "";
                                    break;
                                case "imgdia2hora7":
                                    document.getElementById("cal44").title = "";
                                    break;
                                case "imgdia3hora7":
                                    document.getElementById("cal45").title = "";
                                    break;
                                case "imgdia4hora7":
                                    document.getElementById("cal46").title = "";
                                    break;
                                case "imgdia5hora7":
                                    document.getElementById("cal47").title = "";
                                    break;
                                case "imgdia6hora7":
                                    document.getElementById("cal48").title = "";
                                    break;
                                case "imgdia7hora7":
                                    document.getElementById("cal49").title = "";
                                    break;
                                case "imgdia1hora8":
                                    document.getElementById("cal50").title = "";
                                    break;
                                case "imgdia2hora8":
                                    document.getElementById("cal51").title = "";
                                    break;
                                case "imgdia3hora8":
                                    document.getElementById("cal52").title = "";
                                    break;
                                case "imgdia4hora8":
                                    document.getElementById("cal53").title = "";
                                    break;
                                case "imgdia5hora8":
                                    document.getElementById("cal54").title = "";
                                    break;
                                case "imgdia6hora8":
                                    document.getElementById("cal55").title = "";
                                    break;
                                case "imgdia7hora8":
                                    document.getElementById("cal56").title = "";
                                    break;
                                default:
                                    break;
                            }
                            var x = "";
                            var y = "";

                            tooltip.style.visibility = "visible";
                            tooltip.style.top = x.concat(positiontop, "px");
                            tooltip.style.left = y.concat(positionleft, "px");
                        }
                    }

                    function Tooltipmodaloutjs(sender) {
                        var tooltip = document.getElementById("tooltipcustom");
                        if (tooltip.style.visibility == "visible") {
                            tooltip.style.visibility = "hidden";
                        } else {
                            tooltip.style.visibility = "hidden";
                        }
                    }  
                              
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                <script type="text/javascript">
                    function keyPress(sender, args) {
                        var text = sender.get_value() + args.get_keyCharacter();
                        if (!text.match('^[0-9]+$'))
                            args.set_cancel(true);
                    }

                    function nodeClicked(sender, args) {
                        var node = args.get_node();
                        if (node.get_checked()) {
                            node.uncheck();
                        } else {
                            node.check();
                        }
                        nodeChecked(sender, args)
                    }
                </script>
            </telerik:RadCodeBlock>
        </div>
      </form>
    </body>
</html>
