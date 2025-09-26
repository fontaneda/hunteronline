<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="mapasitio.aspx.vb" Inherits="ExtranetWeb.mapasitio" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilomapasitio.css" rel="stylesheet" type="text/css" />
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
    <div class="contactos_maestro">
        <div>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1"></telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
        </div>
        <div class="contactos_titulo">
            <div class="mapa_titulo">
                <h2>
                    Mapa del Sitio
                </h2>
            </div>
            <div class= "mapa_contenido">
                <telerik:RadSiteMap runat="server" ID="SiteMap1" ShowNodeLines="True" MaxDataBindDepth="2" Font-Bold="True">
                    <Nodes>
                        <telerik:RadSiteMapNode runat="server" NavigateUrl="#" Text="Login">
                            <Nodes>
                                <telerik:RadSiteMapNode runat="server" NavigateUrl="#" Text="Registrese"></telerik:RadSiteMapNode>
                                <telerik:RadSiteMapNode runat="server" NavigateUrl="#" Text="Cambiar Contraseña"></telerik:RadSiteMapNode>
                            </Nodes>
                        </telerik:RadSiteMapNode>
                        <telerik:RadSiteMapNode runat="server" NavigateUrl="datospersonales.aspx" Text="Mi Cuenta"></telerik:RadSiteMapNode>
                        <telerik:RadSiteMapNode runat="server" NavigateUrl="vehiculo.aspx" Text="Bienes Protegidos"></telerik:RadSiteMapNode>
                        <telerik:RadSiteMapNode runat="server" NavigateUrl="renovacion.aspx" Text="Pago de Servicios"></telerik:RadSiteMapNode>
                        <telerik:RadSiteMapNode runat="server" NavigateUrl="#" Text="Mis Transacciones">
                            <Nodes>
                                <telerik:RadSiteMapNode runat="server" NavigateUrl="Transaccion.aspx"  Text="Pagos Realizados"></telerik:RadSiteMapNode>
                                <telerik:RadSiteMapNode runat="server" NavigateUrl="MisTransacciones.aspx" Text="Transacciones Realizadas"></telerik:RadSiteMapNode>
                                <telerik:RadSiteMapNode runat="server" NavigateUrl="notificaciones.aspx" Text="Notificaciones"> </telerik:RadSiteMapNode>
                                <telerik:RadSiteMapNode runat="server" NavigateUrl="documentos_electronicos.aspx" Text="Documentos Electrónicos"> </telerik:RadSiteMapNode>
                            </Nodes>
                        </telerik:RadSiteMapNode>
                        <telerik:RadSiteMapNode runat="server" NavigateUrl="Contactenos.aspx" Text="Contactenos"> </telerik:RadSiteMapNode>
                    </Nodes>
                    <LevelSettings>
                        <telerik:SiteMapLevelSetting Level="0">
                            <ListLayout RepeatColumns="0" AlignRows="true"></ListLayout>
                        </telerik:SiteMapLevelSetting>
                    </LevelSettings>
                    <DataBindings>
                        <telerik:RadSiteMapNodeBinding />
                    </DataBindings>
                </telerik:RadSiteMap>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
        EnableRoundedCorners="True" Overlay="True" ContentIcon="">
    </telerik:RadNotification>
</asp:Content>
