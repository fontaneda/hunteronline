<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" 
    CodeBehind="Promociones.aspx.vb" Inherits="ExtranetWeb.Promociones" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilopromociones.css" rel="stylesheet" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_principal" runat="server">
        <div id="Promocionesproductosbotonanterior" class="PromocionesContenedoranterior" onmouseover="controlproduccionjs(this);">
            <telerik:RadButton ID="imgleft" runat="server"  Width="100%" Height="100%" Text=""  BackColor="Transparent" BorderWidth="0px" 
                BorderStyle="None"  AutoPostBack="false" ButtonType="ToggleButton">
            </telerik:RadButton>
        </div>
        <div id="Promocionesproductosbotonsiguiente" class="PromocionesContenedorsiguiente" onmouseover="controlproduccionjs(this);">
            <telerik:RadButton ID="imgright" runat="server"  Width="100%" Height="100%" Text=""  BackColor="Transparent" BorderWidth="0px"
                 BorderStyle="None" AutoPostBack="false" ButtonType="ToggleButton">
            </telerik:RadButton>
        </div>
        <div id="Promocionesvendidosbotonanterior" class="PromocionesContenedoranteriordown" onmouseover="controlvendidosjs(this);" >
            <telerik:RadButton ID="img_left" runat="server"  Width="100%" Height="100%" Text=""  BackColor="Transparent" BorderWidth="0px" 
                   BorderStyle="None" AutoPostBack="false" ButtonType="ToggleButton">
            </telerik:RadButton>
        </div>
        <div id="Promocionesvendidosbotonsiguiente" class="PromocionesContenedorsiguientedown" onmouseover="controlvendidosjs(this);" >
            <telerik:RadButton ID="img_right" runat="server"  Width="100%" Height="100%" Text="" BackColor="Transparent" BorderWidth="0px"  
                BorderStyle="None" AutoPostBack="false" ButtonType="ToggleButton">
            </telerik:RadButton>
        </div>
        <div class="PromocionesTitulos" runat="server">
            Promociones Destacadas
        </div>
        <div class="PromocionesProductosInformativo" runat="server">
            Precios solo aplican para web
            <br />
            * Precios no incluyen I.V.A.
        </div>
        <div id="BoxProductosDestacados" class="PromocionesContenedor" runat="server" onmouseover="controlproduccionjs(this);" onmouseleave="controlproduccionoutjs(this);">
            <telerik:RadRotator runat="server" ID="rtrpromociones" OnClientDataBound="rotator_clientDataBound" 
                Width="100%" ItemWidth="309" Height="100%" ItemHeight="180" RotatorType="Buttons" WrapFrames="false">
                <ItemTemplate>
                    <div id="BoxProductos" class="PromocionesProductosBox" runat="server">
                        <div id="BoxProductosImagen" class="PromocionesProductosBoxImagen" runat="server" >
                            <asp:Label ID="lblboxproductosimagen" runat="server" Text="✓" CssClass="PromocionesProductosBoxImagenCSSLabel" />
                            <div id="BoxProductosTitulo" class="PromocionesProductosBoxTitulo" runat="server">
                                <asp:Label ID="lblboxProductostitulo" runat="server" Text="Nombre del producto | caracteristica"  Height="100%"  Width="100%" >
                                </asp:Label>
                            </div>
                        </div>
                        <div id="BoxProductosDetalle" class="PromocionesProductosBoxDetalle" runat="server">
                            <div id="BoxProductosDetalleTitulo" class="PromocionesProductosBoxDetalleTitulo" runat="server">
                                Precio Web:
                            </div>
                            <div id="BoxProductosDetalleValorWeb" class="PromocionesProductosBoxDetalleValorWeb" runat="server">
                                $ 
                                <asp:Label ID="lblboxProductosdetallevalorWeb" runat="server" Text="305.00" />
                            </div>
                            <div id="BoxProductosDetalleValorNormal" class="PromocionesProductosBoxDetalleValorNormal" runat="server">
                                Precio Normal: $ 
                                <asp:Label ID="lblboxProductosdetallevalorNormal" runat="server" Text="382.00" />
                            </div>
                            <div id="BoxProductosDetalleVermas" class="PromocionesProductosBoxDetalleVermas" runat="server">
                                <asp:LinkButton ID="lblboxProductosdetallevermas" runat="server" Text="Ver mas..." ForeColor="#A3C8E1" CommandName="Label" OnCommand="Promociones_Command"
                                        CommandArgument='<%# Eval("CODIGO_PROMOCION") + "/" + Eval("CODIGO_ITEM") + "/" + Eval("GRUPO") + "/" + Eval("PRODUCTO") %>'>
                                </asp:LinkButton>
                            </div>
                            <div id="BoxProductosDetalleComprar" class="PromocionesProductosBoxDetallecomprar" runat="server">
                                <asp:Button ID="btnboxProductosDetalleComprar" runat="server" Width="100%" Height="100%"  BackColor="Transparent" Text=" Comprar" ForeColor="#A5A5A5" BorderStyle="None"
                                    Font-Size="0.8em" CssClass="PromocionesProductosBoxDetallecomprarImagen" CommandName="Boton" OnCommand="Promociones_Command"
                                    CommandArgument='<%# Eval("CODIGO_PROMOCION") + "/" + Eval("CODIGO_ITEM") + "/" + Eval("GRUPO") + "/" + Eval("PRODUCTO") %>'/>
                            </div>
                            <div class="PromocionesProductosBoxDetallevencimiento" runat="server">
                                Válido hasta 
                                <asp:Label ID="lbldetalleproductosvalidohasta" runat="server" Text="01/Ene/1900"> </asp:Label>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <ControlButtons LeftButtonID="imgleft" RightButtonID="imgright" />
            </telerik:RadRotator>
        </div>
        <div class="PromocionesTitulos" runat="server">
            Los más vendidos
        </div>
        <div id="BoxProductosVendidos" class="PromocionesContenedor" runat="server" onmouseover="controlvendidosjs(this);" onmouseleave="controlvendidosoutjs(this);">
            <telerik:RadRotator runat="server" ID="rtrvendidos" OnClientDataBound="rotator_clientDataBound" 
                Width="100%" ItemWidth="309" Height="100%" ItemHeight="180" RotatorType="Buttons" WrapFrames="false">
                <ItemTemplate>
                    <div id="BoxVendidos" class="PromocionesProductosBox" runat="server">
                        <div id="BoxVendidosImagen" class="PromocionesProductosBoxImagen" runat="server">
                            <asp:Label ID="lblboxVendidosimagen" runat="server" Text="✓" CssClass="PromocionesProductosBoxImagenCSSLabel"></asp:Label>
                            <div id="BoxVendidosTitulo" class="PromocionesProductosBoxTitulo" runat="server">
                                <asp:Label ID="lblboxVendidostitulo" runat="server" Text="Nombre del producto | caracteristica" Height="100%" Width="100%"></asp:Label>
                            </div>
                        </div>
                        <div id="BoxVendidosDetalle" class="PromocionesProductosBoxDetalle" runat="server">
                            <div id="BoxVendidosDetalleTitulo" class="PromocionesProductosBoxDetalleTitulo" runat="server">
                                Precio Web:
                            </div>
                            <div id="BoxVendidosDetalleValorWeb" class="PromocionesProductosBoxDetalleValorWeb" runat="server">
                                $ 
                                <asp:Label ID="lblboxVendidosdetallevalorWeb" runat="server" Text="305.00" />
                            </div>
                            <div id="BoxVendidosDetalleValorNormal" class="PromocionesProductosBoxDetalleValorNormal" runat="server">
                                Precio Normal: $ 
                                <asp:Label ID="lblboxVendidosdetallevalorNormal" runat="server" Text="382.00" />
                            </div>
                            <div id="BoxVendidosDetalleVermas" class="PromocionesProductosBoxDetalleVermas" runat="server">
                                <asp:LinkButton ID="lblboxVendidosdetallevermas" runat="server" Text="Ver mas..." ForeColor="#A3C8E1" CommandName="Label" OnCommand="Vendidos_Command" 
                                        CommandArgument='<%# Eval("CODIGO_PROMOCION") + "/" + Eval("CODIGO_ITEM") + "/" + Eval("GRUPO") + "/" + Eval("PRODUCTO") %>'>
                                </asp:LinkButton>
                            </div>
                            <div id="BoxVendidosDetalleComprar" class="PromocionesProductosBoxDetallecomprar" runat="server">
                                <asp:Button ID="btnboxVendidosDetalleComprar" runat="server" Width="100%" Height="100%" BackColor="Transparent" Text=" Comprar" ForeColor="#A5A5A5"
                                    BorderStyle="None" Font-Size="0.8em" CssClass="PromocionesProductosBoxDetallecomprarImagen" CommandName="Boton" OnCommand="Vendidos_Command"
                                    CommandArgument='<%# Eval("CODIGO_PROMOCION") + "/" + Eval("CODIGO_ITEM") + "/" + Eval("GRUPO") + "/" + Eval("PRODUCTO") %>'/>       
                            </div>
                            <div class="PromocionesProductosBoxDetallevencimiento" runat="server">
                                Válido hasta 
                                <asp:Label ID="lbldetallevendidosvalidohasta" runat="server" Text="01/Ene/1900"> </asp:Label>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <ControlButtons LeftButtonID="img_left" RightButtonID="img_right" OnClientButtonClick="" />
            </telerik:RadRotator>
        </div>
    </div>
    <telerik:RadNotification ID="rntmensaje" runat="server" Animation="Fade" Height="12px" Opacity="90" Position="Center" Style="margin-left: 1px"
         Width="400px" EnableRoundedCorners="true" VisibleTitlebar="False" Skin="Simple">
    </telerik:RadNotification>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="modalPopupSeleccion" runat="server" Width="500px" Height="320px" Modal="true" Behaviors="Close" CssClass="element"
                Title="Selección de vehículos" Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False">
                <ContentTemplate>
                    <div class="modalContenedorPrincipal" runat="server">
                        <%--<div class="modalContenedorTitulo" runat="server">
                            <asp:Label ID="txtmodaltitulo" runat="server" Text="Producto">
                            </asp:Label>
                            <br />
                            <br />
                            Seleccione el/los vehículos
                        </div>--%>
                        <div class="modalContenedorControl" runat="server">
                            <telerik:RadGrid ID="grdmodalautos" runat="server" CellSpacing="0" Culture="es-ES" Width="445px" Height="208px" BorderColor="#DFDDDD" BorderWidth="1px"
                                        GridLines="None" AutoGenerateColumns="False" AllowAutomaticUpdates="True">
                                <ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                </ClientSettings>
                                <MasterTableView DataKeyNames="CODIGO_VEHICULO" NoDetailRecordsText="" NoMasterRecordsText="">
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CODIGO_VEHICULO" FilterControlAltText="Filter CODIGO_VEHICULO column"
                                            HeaderText="Código Vehículo" UniqueName="CODIGO_VEHICULO" HeaderStyle-Width="0">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="VEHICULO" FilterControlAltText="Filter VEHICULO column"
                                            HeaderText="Vehículo" UniqueName="VEHICULO"  HeaderStyle-Width="290">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FECHA_FIN" FilterControlAltText="Filter FECHA_FIN column"
                                            HeaderText="Vencimiento" UniqueName="FECHA_FIN"  HeaderStyle-Width="90">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkI" runat="server" AutoPostBack="false"/>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="chkH" runat="server" Text="Marcar" />
                                            </HeaderTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView> 
                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                            </telerik:RadGrid>
                        </div>
                        <div class="modalContenedorBoton" runat="server">
                            <asp:Button ID="Btnmodalacepta" runat="server" Text="Siguiente" Width="100%" BackColor="Transparent" BorderStyle="None" Height="100%" />
                        </div>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager  ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="modalPopupSeleccion">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rntmensaje" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="modalPopupSeleccion" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            var i = 1
            function scrollear() 
            {
                var div = document.getElementById('BoxProductosDestacados');
                alert(div);
                var puntodescroll = div.offsetLeft;
                alert(puntodescroll);
                if (i <= 6 && i >= 1) 
                {
                    document.getElementById('BoxProductosDestacadosInterno').scrollTop = puntodescroll;
                    i++;
                }
            }
        </script>
        <script type="text/javascript">
            function controlproduccionjs(sender) 
            {
                var buttonnext = document.getElementById("Promocionesproductosbotonanterior");
                var buttonprevius = document.getElementById("Promocionesproductosbotonsiguiente");
                buttonnext.style.visibility = "visible";
                buttonprevius.style.visibility = "visible";
            }

            function controlproduccionoutjs(sender) 
            {
                var buttonnext = document.getElementById("Promocionesproductosbotonanterior");
                var buttonprevius = document.getElementById("Promocionesproductosbotonsiguiente");
                buttonnext.style.visibility = "hidden";
                buttonprevius.style.visibility = "hidden";
            }

            function controlvendidosjs(sender) 
            {
                var buttonnext = document.getElementById("Promocionesvendidosbotonsiguiente");
                var buttonprevius = document.getElementById("Promocionesvendidosbotonanterior");
                buttonnext.style.visibility = "visible";
                buttonprevius.style.visibility = "visible";
            }

            function controlvendidosoutjs(sender) 
            {
                var buttonnext = document.getElementById("Promocionesvendidosbotonsiguiente");
                var buttonprevius = document.getElementById("Promocionesvendidosbotonanterior");
                buttonnext.style.visibility = "hidden";
                buttonprevius.style.visibility = "hidden";
            }
        </script>
        <script type="text/javascript">
            function toggleMODAL() 
            {
                var Modal = document.getElementById("modal");
                if (Modal.style.visibility == "visible") 
                {
                    Modal.style.visibility = "hidden";
                } else {
                    Modal.style.visibility = "visible";
                }
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>