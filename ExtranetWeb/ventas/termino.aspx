<%@ Page Title="" Language="vb" AutoEventWireup="false" 
    CodeBehind="termino.aspx.vb" Inherits="ExtranetWeb.termino" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Extranet</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
    <link href="../styles/slide.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estiloinicio.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-67324308-1', 'auto');
        ga('send', 'pageview');
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container_termino">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div id="banner4">
        </div>
        <div class="content_principal_termino">
            <div class="content_principal_bloque_termino" style="background-color: white">
                <div style="width: 1000px; height: 400px; background-color: white;">
                    <telerik:RadEditor runat="server" ID="RadEditor1" Width="1000px" Height="550px" BorderStyle="None"
                        EmptyMessage="No existe información por el momento" EnableResize="False" Language="es-ES"
                        Skin="Metro" EditModes="Preview" EnableEmbeddedSkins="False">
                        <Tools>
                            <telerik:EditorToolGroup>
                            </telerik:EditorToolGroup>
                        </Tools>
                        <Content>    
                                        
                        </Content>
                        <TrackChangesSettings CanAcceptTrackChanges="False" />
                    </telerik:RadEditor>
                </div>
                
               
            </div>
        </div>
    </div>
    </form>
</body>
</html>