<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="inicio.aspx.vb" Inherits="ExtranetWeb.inicio" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_help">
        <telerik:RadButton ID="btnAyuda" runat="server" Text="" Style="top: 0px; left: 0px;
            height: 32px; width: 32px" OnClientClicked="openWinHelp">
            <Image ImageUrl="../images/icons/32x32/helprojo.png" HoveredImageUrl="../images/icons/32x32/helprojo.png"
                PressedImageUrl="../images/icons/32x32/helprojo.png" IsBackgroundImage="true">
            </Image>
        </telerik:RadButton>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function openWinHelp() 
            {
                var oWnd = radopen("", "modalPopupHelp");
                oWnd.set_modal(true);
                if (!oWnd.get_modal()) document.documentElement.focus();
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAyuda">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAyuda" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="content_principal">
        <div class="content_principal_bloque">
            <div class="content_inicio">
                <%--<img src="../images/background/wallpaper1.jpg" alt="wallpaper" />--%>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True" ContentIcon="">
    </telerik:RadNotification>
    <telerik:RadAjaxPanel runat="server" ID="rapConfiguration" LoadingPanelID="RadAjaxLoadingPanel1" CssClass="element2">
        <%--CssClass="content_cotizadorurlretorno_toolbar" >--%>
        <telerik:RadWindow ID="modalPopup" runat="server" Width="500px" Height="220px" Modal="true" Behaviors="Close" CssClass="element" 
            Title="Aviso Importante" Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False">
            <ContentTemplate>
                <div class="vehiculoradwindowsdetalle">
                    <br />
                    Estimado cliente
                    <br />
                    <br />
                    Hemos detectado que <font class="numero"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></font> de sus
                    <font class="letra">bienes protegidos</font> de un total de 
                    <font class="numero"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></font> , no
                    han ingresado a nuestros talleres para el chequeo semestral de los <font class="letra">productos</font>, 
                    que por su seguridad debe realizar. Para su mayor comodidad puede solicitar un turno a nuestro 
                    <font class="letra">Call Center (04-600-4640)</font>o acercarse a cualquiera de nuestras oficinas a nivel nacional.
                </div>
            </ContentTemplate>
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function togglePopupModality() 
            {
                var wnd = $find("<%= modalPopup.ClientID %>");
                wnd.set_modal(!wnd.get_modal());
                if (!wnd.get_modal()) document.documentElement.focus();
            }

            function showDialogInitially() 
            {
                var wnd = $find("<%= modalPopup.ClientID %>");
//                wnd.show();
//                Sys.Application.remove_load(showDialogInitially);
            }
            Sys.Application.add_load(showDialogInitially);
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="modalPopupHelp" runat="server" Width="500px" Height="220px" Modal="true" Behaviors="Close"
                CssClass="element" Title="Aviso Importante" Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False">
                <ContentTemplate>
                    <div class="renovacionradwindowsdetalle">
                        Inicio
                        <br />
                        <br />
                        Infórmese
                        <br />
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
