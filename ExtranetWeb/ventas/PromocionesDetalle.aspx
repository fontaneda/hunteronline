<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="PromocionesDetalle.aspx.vb" Inherits="ExtranetWeb.PromocionesDetalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilopromocionesdetalle.css" rel="stylesheet" type="text/css" />
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
    <div class="Promocionesdetallepagineo" runat="server">
        <div class="Promocionesdetalleanterior" runat="server">
            <asp:Button ID="btndetalleanterior" runat="server" Width="100%" Height="100%" BorderStyle="None" BackColor="Transparent" />
        </div>
        <div class="Promocionesdetallemensajeanterior" runat="server">
            Producto Anterior
        </div>
        <div class="Promocionesdetallesiguiente" runat="server">
            <asp:Button ID="btndetallesiguiente" runat="server" Width="24px" Height="100%" BorderStyle="None" BackColor="Transparent" Text=""/>
        </div>
        <div class="Promocionesdetallemensajesiguiente" runat="server">
            Producto Siguiente
        </div>
    </div>
    <div id="DetallerImagen" class="PromocionesdetalleImagen" runat="server">
        <div id="DetalleImagenInfo" class="PromocionesdetalleImagenInfocodigo" runat="server">
            <div class="PromocionesdetalleImagenInfocodigoflechaizquierda" runat="server"></div>
            <div id="DetalleImagenDetalle" class="PromocionesdetalleImagenInfodetalle" runat="server">
                <asp:Label ID="lbldetalleimagen" runat="server" Text="✓" CssClass="PromocionesdetalleImagenInfodetalleImagen"></asp:Label>
                <div id="DetalleImagenTexto" class="PromocionesdetalleImagenInfodetalletexto" runat="server">
                    COD.PROMO
                </div>
                <div id="DetalleImagenCodigo" class="PromocionesdetalleImagenInfodetallePromo" runat="server">
                    <asp:Label ID="lbldetalleCodigo" runat="server" Text="0000" />
                </div>
            </div>
        </div>
        <div id="DetalleInfo" class="PromocionesdetalleImagenInfo" runat="server">
            <asp:Label ID="lbldetalletituloimagen" runat="server" Text="Nombre del producto | caracteristica" Height="100%" Width="100%" />
        </div>
    </div>
    <div class="Promocionesdetalleinformacion" runat="server">
        <div class="PromocionesdetalleTitulo" runat="server">
            <asp:Label ID="lbldetalletitulo" runat="server" Text="Nombre del producto | caracteristica caracteristica caracteristica" Height="100%" Width="100%" /> 
        </div>
        <div class="Promocionesdetallevalortitulo" runat="server">
            Precio Web:
        </div>
        <div class="Promocionesdetallevalor" runat="server">
            $ 
            <asp:Label ID="lbldetallevalorWeb" runat="server" Text="000.00" /> 
        </div>
        <div class="PromocionesdetalleValorNormal" runat="server">
            Precio Normal: $ 
            <asp:Label ID="lbldetallevalorNormal" runat="server" Text="000.00" /> 
        </div>
        <div class="Promocionesdetallecantidadtitulo" runat="server">
            Cantidad
        </div>
        <div class="Promocionesdetallecantidad" runat="server">
            <asp:TextBox ID="txtdetallecantidad" runat="server" Text="0" CssClass="PromocionesdetallecantidadTextbox" MaxLength="3"
                        onkeypress="return numbersonly(event);"> 
            </asp:TextBox>
        </div>
        <div class="Promocionesdetallecomprar" runat="server">
            <asp:Button ID="btnDetalleComprar" runat="server" Width="100%" Height="100%" BackColor="Transparent" Text=" Comprar" BorderStyle="None"
                 CssClass="PromocionesdetallecomprarImagen"/>       
        </div>
        <div class="Promocionesdetallevalidohasta" runat="server">
            Válido hasta 
            <asp:Label ID="lbldetallevalidohasta" runat="server" Text="01/Ene/1900" /> 
        </div>
    </div>
    <div class="Promocionesdetallezonamensajes" runat="server">
        <br />
        <img src="../images/background/tarjetas_promociones.gif" alt="" style="margin-left:-5px;" />
        <br />
        <br />
        <asp:LinkButton ID="lbldetallecatalogo" runat="server" Text="Ir a catálogo..."  ForeColor="#006EB6" style="margin:0px 0px 0px 0px; font-size:12px;"> 
        </asp:LinkButton>
    </div>
    <div class="PromocionesdetalleTab" runat="server">
        <telerik:RadTabStrip ID="tabdetalledatos" runat="server" AutoPostBack="True" MultiPageID="RadMultiPage1"  SelectedIndex="0"  EnableEmbeddedSkins="False" 
            Height="30px" Align="Right" BorderColor="#C3DBEB" style="border-bottom-width:1px;border-bottom-style:solid;">
            <Tabs>
                <%--<telerik:RadTab runat="server" Text="Descripción"  Selected="True"  CssClass="PromocionesdetalleTabinactivo" 
                                SelectedCssClass="PromocionesdetalleTabactivo">
                </telerik:RadTab>--%>
                <telerik:RadTab runat="server" Text="Ficha Técnica" CssClass="PromocionesdetalleTabinactivo" SelectedCssClass="PromocionesdetalleTabactivo">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Width="920px" Height="210px" ScrollBars="Both" BorderColor="#C3DBEB" 
                        style="border-left-width:1px;border-left-style:solid;">
             <%--<telerik:RadPageView runat="server" ID="RadPageView1" Selected="True">
                <asp:TextBox ID="txtdetallefichatecnica" runat="server" Text="123" Width="880px" 
                                Height="200px" BorderColor="White" TextMode="MultiLine" Font-Names="Arial">
                </asp:TextBox>
            </telerik:RadPageView>--%>
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <asp:Image ID="imgdetallefichatecnica" runat="server"  Width="880px" ImageUrl="../images/background/promo.png" Height="1000px" BorderWidth="0px" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <telerik:RadNotification ID="rntmensaje" runat="server" Animation="Fade" Height="12px" Opacity="90" Position="Center" Style="margin-left: 1px" Width="400px" 
             EnableRoundedCorners="true" VisibleTitlebar="False" Skin="Simple">
    </telerik:RadNotification>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function numbersonly(e) 
            {
                var unicode = e.charCode ? e.charCode : e.keyCode
                if (unicode != 8 && unicode != 44) 
                {
                    if (unicode < 48 || unicode > 57) 
                    { return false } 
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="modalPopupSeleccion" runat="server" Width="500px" Height="320px" Modal="true" Behaviors="Close" CssClass="element"
                Title="Asignacion de vehículos" Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False">
                <ContentTemplate>
                    <div class="modalContenedorPrincipal" runat="server">
                        <div class="modalContenedorTitulo" runat="server">
                            <asp:Label ID="txtmodaltitulo" runat="server" Text="Producto" />
                            <br />
                            Seleccione el/los vehículos
                            <br />
                        </div>
                        <div class="modalContenedorControl" runat="server">
                            <telerik:RadGrid ID="grdmodalautos" runat="server" CellSpacing="0" Culture="es-ES" Width="400px" Height="180px"
                                     GridLines="None" AutoGenerateColumns="False" AllowAutomaticUpdates="True">
                                <ClientSettings EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                </ClientSettings>
                                <MasterTableView DataKeyNames="CODIGO_VEHICULO" NoDetailRecordsText="" NoMasterRecordsText="">
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    </RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CODIGO_VEHICULO" FilterControlAltText="Filter CODIGO_VEHICULO column"
                                            HeaderText="Código Vehículo" UniqueName="CODIGO_VEHICULO" HeaderStyle-Width="0">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="VEHICULO" FilterControlAltText="Filter VEHICULO column"
                                            HeaderText="Vehículo" UniqueName="VEHICULO"  HeaderStyle-Width="270">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkI" runat="server" AutoPostBack="false"/>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="chkH" runat="server" Text="Marcar" />
                                            </HeaderTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="FECHA_FIN" FilterControlAltText="Filter FECHA_FIN column"
                                            HeaderText="Vencimiento" UniqueName="FECHA_FIN"  HeaderStyle-Width="80">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                            </telerik:RadGrid>
                        </div>
                        <div class="modalContenedorBoton" runat="server">
                            <asp:Button ID="btnmodalacepta" runat="server" Text="Siguiente" Width="100%" BackColor="Transparent" BorderStyle="None" Height="100%" />
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
</asp:Content>
