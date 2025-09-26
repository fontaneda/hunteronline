<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="busquedacliente.aspx.vb" Inherits="ExtranetWeb.busquedacliente" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="../styles/css_mkt/int-styles.css" />
    </head>
    <body class="body">
        <form id="form1" method="post" runat="server">
            <div class="contenedor">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
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
                        setTimeout(function () 
                        {
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
                    function returnToParent() {
                        var oArg = new Object();
                        oArg.codigo = "";
                        oArg.nombre = "";
                        var grid = $find("<%=rgdconsulta.ClientID %>");
                        var MasterTable = grid.get_masterTableView();
                        var selectedRows = MasterTable.get_selectedItems();
                        for (var i = 0; i < selectedRows.length; i++) 
                        {
                            var row = selectedRows[i];
                            var codigo = MasterTable.getCellByColumnUniqueName(row, "IdCliente")
                            oArg.codigo = codigo.innerHTML; 
                            var nombre = MasterTable.getCellByColumnUniqueName(row, "NombreCompleto")
                            oArg.nombre = nombre.innerHTML;
                        }
                        var oWnd = GetRadWindow();
                        if (oArg.codigo) 
                        {
                            oWnd.close(oArg);
                        } else {
                            alert("Por favor seleccione un cliente.");
                        }
                    }
                </script>
                <div class="table-data">
                    <div class="top-tabla-options">
                        <div class="search-client">
                            <input type="text" placeholder="Busqueda general" id="txtbusquedaclientefac" runat="server"> 
                        </div>
                        <div class="icono">
                            <telerik:RadButton ID="BtnConsulta" runat="server" Text="Consultar" ForeColor="Black"
                                Style="top: 0px; left: 0px; height: 48px; width: 48px" ToolTip="Consulta información del cliente">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/48x48/Lupa.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="icono">
                            <telerik:RadButton ID="BtnAceptar" runat="server" Text="Aceptar" ForeColor="Black" ToolTip="Selecciona cliente"
                                Style="top: 0px; left: 0px; height: 48px; width: 48px" OnClientClicked="returnToParent" AutoPostBack="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/48x48/accept48x48.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="icono">
                            <telerik:RadButton ID="BtnClose" runat="server" Text="Cerrar" ForeColor="Black" ToolTip="Cerrar pantalla" 
                                Style="top: 0px; left: 0px; height: 48px; width: 48px" OnClientClicked="returnParent" AutoPostBack="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/48x48/remove48x48.png" />
                            </telerik:RadButton>
                        </div>
                    </div>
                </div>
                <div class="busqueda">
                    <div class="data">
                        <telerik:RadGrid ID="rgdconsulta" runat="server" CellSpacing="0" Culture="es-ES"
                            GridLines="None" AutoGenerateColumns="False" Height="300px" Width="630px" AllowAutomaticUpdates="True"
                            Skin="MyCustomSkin" EnableEmbeddedSkins="false">
                            <ClientSettings EnableRowHoverStyle="true">
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="10px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="10px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="IdCliente" HeaderText="Id cliente" UniqueName="IdCliente">
                                        <FooterStyle Width="80px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="80px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="80px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreCompleto" HeaderText="Cliente" UniqueName="NombreCompleto">
                                        <FooterStyle Width="200px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="200px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="200px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="email" HeaderText="Email" UniqueName="email">
                                        <FooterStyle Width="140px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="140px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="140px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Telefono" HeaderText="Teléfono" UniqueName="Telefono">
                                        <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado">
                                        <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </div>
                </div>
            </div>
            <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                EnableRoundedCorners="True" Overlay="True">
            </telerik:RadNotification>
        </form>
    </body>
</html>
