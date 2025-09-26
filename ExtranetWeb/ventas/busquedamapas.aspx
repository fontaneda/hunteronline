<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="busquedamapas.aspx.vb" Inherits="ExtranetWeb.busquedamapas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=yes" />
        <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
        <title>Seleccion de turno</title>
        <link rel="stylesheet" type="text/javascript" href="../script/ApiHereMin.js" />
        <link rel="stylesheet" type="text/css" href="../styles/mapadefault.css" />
        <link rel="stylesheet" type="text/css" href="../styles/mapastyles.css" />
        <script type="text/javascript" src="https://js.api.here.com/v3/3.1/mapsjs-core.js"></script>
        <script type="text/javascript" src="https://js.api.here.com/v3/3.1/mapsjs-service.js"></script>
        <script type="text/javascript" src="https://js.api.here.com/v3/3.1/mapsjs-ui.js"></script>
        <script type="text/javascript" src="https://js.api.here.com/v3/3.1/mapsjs-mapevents.js"></script>
        <style type="text/css">
            .log {
                position: absolute;
                top: 5px;
                left: 5px;
                height: 150px;
                width: 250px;
                overflow: scroll;
                background: white;
                margin: 0;
                padding: 0;
                list-style: none;
                font-size: 12px;}
            .log-entry {
                padding: 5px;
                border-bottom: 1px solid #d0d9e9;}
            .log-entry:nth-child(odd) {
                background-color: #e1e7f1;}
        </style>
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
    <body id="markers-on-the-map">
        
        <div class="page-header">
            <h1>Por favor seleccione su ubicación con un click</h1>
        </div>
        <div id="map">
        </div>
        <form id="form1" method="post" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">                
            </telerik:RadScriptManager> 
            <br />
            <div style="height:50px;width:480px;background-color:Silver;padding:0px 0px 0px 122px;">
                <telerik:RadTextBox ID="txtlatitud" runat="server" Label="Latitud">
                </telerik:RadTextBox>
                <telerik:RadTextBox ID="txtlongitud" runat="server" Label="Longitud">
                </telerik:RadTextBox>
                <telerik:RadButton ID="btncontinuar" runat="server" Text="Aceptar" ForeColor="Black" ToolTip="Click para continuar"
                    Style="top: 10px; left: 0px; height: 32px; width: 32px; background-color:White;"  OnClientClicked="returnToParent" AutoPostBack="False">
                    <Image IsBackgroundImage="False" ImageUrl="../images/favicon.ico" />
                </telerik:RadButton>
            </div>
        </form>
        <script type="text/javascript">
            function setUpClickListener(map) {
                map.addEventListener('tap', function (evt) {
                var coord = map.screenToGeo(evt.currentPointer.viewportX,
                                            evt.currentPointer.viewportY);
                var txtlati = document.getElementById("<%=txtlatitud.ClientID %>");
                var txtlong = document.getElementById("<%=txtlongitud.ClientID %>");
                txtlati.value = coord.lat;
                txtlong.value = coord.lng;
                addMarkersToMap(map,coord.lat,coord.lng);
              });
            }

            function addMarkersToMap(map, latitud, longitud) {
                var pMarker = new H.map.Marker({lat:latitud, lng:longitud});
                map.removeObjects(map.getObjects ());
                map.addObject(pMarker);
            }

            var platform = new H.service.Platform({
                apikey: 'M8iySFedDKlFPqj200tdSwaK2CLKs9FOEuN9hZgevrE'
            });
            var defaultLayers = platform.createDefaultLayers();
            var map = new H.Map(document.getElementById('map'),
                                defaultLayers.vector.normal.map,{
                                center: {lat:-2.235104, 
                                        lng: -79.891516},
                                        zoom: 15,
                                        pixelRatio: window.devicePixelRatio || 1
            });
            window.addEventListener('resize', () => map.getViewPort().resize());

            var behavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(map));

            function logEvent(str) {
                var entry = document.createElement('li');
                entry.className = 'log-entry';
                entry.textContent = str;
                logContainer.insertBefore(entry, logContainer.firstChild);
            }

            setUpClickListener(map);
        
        </script>
        <script type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }
            function returnParent() {
                var oWnd = GetRadWindow();
                oWnd.close();
            }
            function returnToParent() {
                var oArg = new Object();
                var txtlati = document.getElementById("<%=txtlatitud.ClientID %>");
                var txtlong = document.getElementById("<%=txtlongitud.ClientID %>");
                oArg.latitud = txtlati.value;
                oArg.longitud = txtlong.value;
                var oWnd = GetRadWindow();
                if (oArg.latitud) {
                    oWnd.close(oArg);
                } else {
                    alert("Por favor seleccione una ubicación");
                }
            }
        </script>
    </body>
</html>
