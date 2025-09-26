<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConsultaControlTaller.aspx.vb" Inherits="ExtranetWeb.ConsultaControlTaller" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html> 
    <head runat="server">
        <title>Consulta de control de talleres</title>
        <link href="../styles/estiloconsultatalleres.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilodocumentos.css" rel="stylesheet" type="text/css" />
        <link rel="shortcut icon" href="../images/favicon.ico" />
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script type="text/javascript">
            function fnOpen(file1, ruta1, id1) {
                var dir = 'descarga_documento.aspx?FILENAME=' + file1 + '&RUTA=' + ruta1 + '&COD=' + id1
                window.open(dir, file1);
            }
        </script>
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
        <form id="frmprincipal" runat="server">
            <div id="master_container">
                <div id="header">
                </div>
                <div class="content_toolbar_textbox_tall">
                    <div class="sec_division_documento"></div>
                    <div class="sec_division_documento"></div>
                    <div class="sec_busqueda_documento">
                        <asp:LinkButton ID="LinkDescargar" runat="server" CssClass="sec_vinculos" >
                            Descargar
                        </asp:LinkButton>
                    </div>
                    <div class="sec_division_documento">
                        <asp:Label ID="Label11" runat="server" class="sec_division_documento" Text=" |" />
                    </div>
                    <div class="sec_busqueda_documento" >
                        <asp:LinkButton ID="LinkReenviar" runat="server" CssClass="sec_vinculos">Reenviar</asp:LinkButton>
                        <asp:LinkButton ID="LinkEmail" runat="server" CssClass="sec_vinculos">Email</asp:LinkButton>
                    </div>
                </div>
                <div class="content_toolbar_control_tall" id="div_toolbar_2" runat="server">
                    <div class="sec_busqueda_documento"></div>
                    <div class="sec_RadTextBox2">
                        <telerik:RadTextBox ID="txtemail" runat="server" Height="22px" Width="200px" EmptyMessage="Ingrese el e-mail" CssClass="content_border" MaxLength="100" />
                    </div>
                    <div class="sec_division_documento"></div>
                    <div class="sec_division_documento"></div>
                    <div class="sec_RadButton2">
                        <telerik:RadButton ID="BtnEnviar" runat="server" Width="81px" Height="22px" Text="Enviar" ValidationGroup="grupo01"
                            HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Enviar" CssClass="sec_border_boton">
                            <Image ImageUrl="../images/background/verde.png" HoveredImageUrl="../images/background/verde.png"
                                   PressedImageUrl="../images/background/verde.png" IsBackgroundImage="true" />
                        </telerik:RadButton>
                    </div>
                    <div class="sec_RadButton2">
                        <telerik:RadButton ID="BtnCancelar" runat="server" Width="81px" Height="22px" Text="Cancelar"
                            HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Cancelar" CssClass="sec_border_boton">
                            <Image ImageUrl="../images/background/verde.png" HoveredImageUrl="../images/background/verde.png"
                                   PressedImageUrl="../images/background/verde.png" IsBackgroundImage="true" />
                        </telerik:RadButton>
                    </div>
                </div>
                <div style="overflow: auto; -webkit-overflow-scrolling: touch; width:1000px; height:500px; float:left; margin: 15px 12px;">
                    <embed id="myframe" src="" name="myframe" runat="server" width="100%" height="100%"/>
                </div>
            </div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecoratedControls="Fieldset">
            </telerik:RadFormDecorator>
            <telerik:RadNotification ID="RnMensajesError" runat="server" Animation="Slide" Height="100px"
                Position="Center" Width="414px" EnableRoundedCorners="True" EnableShadow="True">
            </telerik:RadNotification>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
             <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="LinkReenviar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="div_toolbar_2" />
                            <telerik:AjaxUpdatedControl ControlID="LinkReenviar" />
                            <telerik:AjaxUpdatedControl ControlID="LinkEmail" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnEnviar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema"/>
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnCancelar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="div_toolbar_2" />
                            <telerik:AjaxUpdatedControl ControlID="LinkReenviar"/>
                            <telerik:AjaxUpdatedControl ControlID="LinkEmail"/>
                        </UpdatedControls>
                    </telerik:AjaxSetting> 
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
        </form>
    </body>
</html>
