<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="termino_politica.aspx.vb"
    Inherits="ExtranetWeb.termino_politica" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Términos y Condiciones </title>
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
     <%-- <div id="container_termino"> --%>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
       <%--  <div id="banner2"> --%>
      <%--  <div class="logo_image"></div>
             <div class="content_user_logo_principal"></div>
        </div>--%>
        <div class="content_principal_termino">
            <div class="content_principal_bloque_termino" style="background-color: white">
                <div style="width: 900px; height: 400px; background-color: white;">
                    <telerik:RadEditor runat="server" ID="RadEditor1" Width="900px" Height="400px" BorderStyle="None"
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
                <div class="regusu_bloque_col_parrafo_termino">
                    <div class="regusu_bloque_col2_parrafo_termino">
                      <%--  <telerik:RadButton ID="btnaceptar" runat="server" Text="Aceptar" Font-Bold="True">
                        </telerik:RadButton>--%>
                        <asp:Button ID="btnaceptar" Text="Aceptar" runat="server" OnClientClick="populateValue(); return false;" />
                    </div>
                    <div class="regusu_bloque_col3_parrafo_termino">
                       <%-- <telerik:RadButton ID="btncancelar" runat="server" Text="Cancelar" 
                            Font-Bold="True" OnClientClick="closeWin(); return false;" AutoPostBack="False">
                        </telerik:RadButton>--%>
                         <asp:Button ID="btncancelar" Text="Cancelar" runat="server" OnClientClick="closeWin(); return false;" />
          <script type="text/javascript">
              function closeWin() {
                  //GetRadWindow().close();
                  var oArg = new Object();
                  oArg.aceptado = "0";
                  var oWnd = GetRadWindow();
                  oWnd.close(oArg);
              }

              function populateValue() {
                  var oArg = new Object();
                  oArg.aceptado = "1";
                  var oWnd = GetRadWindow();
                  oWnd.close(oArg);

              }

              function GetRadWindow() {
                  var oWindow = null;
                  if (window.radWindow) oWindow = window.radWindow;
                  else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                  return oWindow;
              }

          </script>
                    </div>
                </div>
               
            </div>
        </div>
       <%--</div> --%>
    </form>
</body>
</html>
