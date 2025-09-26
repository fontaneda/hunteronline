<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="busquedataller.aspx.vb" Inherits="ExtranetWeb.busquedataller" EnableSessionState="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilomodal.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
        </style>
    </head>
    <body>
        <form id="form1" method="post" runat="server">
            <div class="contenedor">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                <script type="text/javascript">
                    function GetRadWindow() 
                    {
                        var oWindow = null;
                        if (window.radWindow) oWindow = window.radWindow;
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                        return oWindow;
                    }

                    function AdjustRadWidow() 
                    {
                        var oWindow = GetRadWindow();
                        setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
                    }

                    function ChromeSafariFix(oWindow) 
                    {
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

                    function consultacliente() 
                    {
                        document.getElementById('BtnConsulta').addEventListener("click", function (e) 
                        {
                            e.preventDefault();
                            alert("No se pudo cargar el método");
                        });
                    }

                    function returnParent() 
                    {
                        var oWnd = GetRadWindow();
                        oWnd.close();
                    }

                    function returnToParent() 
                    {
                        var oArg = new Object();
                        oArg.taller         = "";
                        var grid            = $find("<%=rgdconsulta.ClientID %>");
                        var MasterTable     = grid.get_masterTableView();
                        var selectedRows    = MasterTable.get_selectedItems();
                        var spacio          = "";
                        for (var j = 0; j < 100; j++) 
                        {
                            spacio = spacio + " ";
                        }
                        for (var i = 0; i < selectedRows.length; i++) 
                        {
                            var row     = selectedRows[i];
                            var cell    = MasterTable.getCellByColumnUniqueName(row, "CODIGO");
                            var taller  = MasterTable.getCellByColumnUniqueName(row, "DESCRIPCION");
                            var hora    = MasterTable.getCellByColumnUniqueName(row, "HORA_LIMITE");
                            var horafs  = MasterTable.getCellByColumnUniqueName(row, "HORA_LIMITE_FS");
                            oArg.taller = taller.innerHTML + spacio + cell.innerHTML + "/" + hora.innerHTML + "/" + horafs.innerHTML;
                            //oArg.taller = cell.innerHTML + " - " + hora.innerHTML + " / " + direc.taller;
                        }
                        var oWnd = GetRadWindow();
                        if (oArg.taller) 
                        {
                            oWnd.close(oArg);
                        } else {
                            alert("Por favor seleccione un taller");
                        }
                    }
                </script>
                <div class="busqueda">
                    <div class="menu">
                        <div class="icono">
                            <telerik:RadButton ID="BtnConsulta" runat="server" Text="Consultar" ForeColor="Black" ToolTip="Consulta información de dirección"
                                Style="top: 0px; left: 0px; height: 28px; width: 28px"  OnClientClicked="consultacliente">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/search28x28.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="icono">
                            <telerik:RadButton ID="BtnAceptar" runat="server" Text="Aceptar" ForeColor="Black" ToolTip="Selecciona dirección"
                                Style="top: 0px; left: 0px; height: 28px; width: 28px"  OnClientClicked="returnToParent" AutoPostBack="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/check28x28.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="icono">
                            <telerik:RadButton ID="BtnClose" runat="server" Text="Cerrar" ForeColor="Black" Style="top: 0px;
                                left: 0px; height: 28px; width: 28px" ToolTip="Cerrar pantalla" OnClientClicked="returnParent"
                                AutoPostBack="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/turnoffwin28x28.jpg" />
                            </telerik:RadButton>
                        </div>
                    </div>
                    <div class="data">
                        <telerik:RadGrid ID="rgdconsulta" runat="server" CellSpacing="0" Culture="es-ES"
                            GridLines="None" AutoGenerateColumns="False" Height="300px" Width="630px" AllowAutomaticUpdates="True"
                            Skin="MyCustomSkin" EnableEmbeddedSkins="false">
                            <ClientSettings EnableRowHoverStyle="true">
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="CODIGO">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="10px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="10px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="CODIGO" HeaderText="Código" UniqueName="CODIGO" Visible="true">
                                        <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CIUDAD_NOMBRE" HeaderText="Ciudad" UniqueName="CIUDAD_NOMBRE">
                                        <FooterStyle Width="170px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="170px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="170px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DESCRIPCION" HeaderText="Taller" UniqueName="DESCRIPCION">
                                        <FooterStyle Width="170px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="170px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="170px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DIRECCION" HeaderText="Dirección" UniqueName="DIRECCION">
                                        <FooterStyle Width="270px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="270px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="270px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HORA_LIMITE" HeaderText="Limite" UniqueName="HORA_LIMITE">
                                        <FooterStyle Width="1px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="1px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="1px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HORA_LIMITE_FS" HeaderText="Limite fs" UniqueName="HORA_LIMITE_FS">
                                        <FooterStyle Width="1px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="1px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="1px" CssClass="estilogridcontrol" />
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
