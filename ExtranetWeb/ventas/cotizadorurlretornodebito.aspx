<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="cotizadorurlretornodebito.aspx.vb" Inherits="ExtranetWeb.cotizadorurlretornodebito" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/estilorenovacion.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a.linkcss:link
        {
            color: #878787;
        }
        /* unvisited link */
        a.linkcss:visited, a.cssa:active
        {
            color: #006666;
        }
        /* visited link */
        a.linkcss:hover, a.cssa:active
        {
            color: #434141;
        }
        /* mouse over link */
        a.linkcss:active
        {
            color: #878787;
        }
        /* selected link */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_principal">
        <div class="content_principal_bloque">
            <div class="content_renovacion_titulopage">
                <h2>
                    Resultado correcto de transacción No. <asp:Label ID="lblordenpago" runat="server" Text=""></asp:Label>
                    <br />
                </h2>
                <asp:Label ID="lblnombre" runat="server" Text="" style="margin-left:5px; color:Gray"></asp:Label>
            </div>
            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                <script type="text/javascript">
                    function openWinContrato() {
                        var valor = document.getElementById('<%=lblordenpago.ClientID%>').innerText;
                        var oWnd = radopen("busquedadocumentoda.aspx?ORDEN=" + valor, "RadWindow1");
                        oWnd.set_modal(true);
                        if (!oWnd.get_modal()) document.documentElement.focus();
                    }
                    function OnClientCloseContrato(oWnd, args) {
                        var arg = args.get_argument();
                        if (arg) {
                            var resultado = arg.resultado;
                            if (resultado) {
                                alert("Ventana cerrada");
                            } else {
                                alert("Ventana cerrada");
                            }
                        } else {
                            alert("Ventana cerrada");
                        }
                    }
                </script>
            </telerik:RadCodeBlock>
            <div class="content_crit_info_detalleitems_productocliente">
                <div class="content_datospersonales_bloque">
                    <div ID="divpdf" style="width:100%; height:550; margin-top:10px;">
                        <div style="overflow: auto; -webkit-overflow-scrolling: touch;">
                           <embed id="myframe" src="" name="myframe" runat="server" width="100%" height="480" visible="true" ></embed> 
                        </div>
                    </div>
                    <div class="content_cotizadorurlretorno_textbox2">
                        <asp:Image ID="imageResultado" runat="server" 
                            ImageUrl="~/images/icons/24x24/alerterror.png" Visible="false" />
                        <asp:Label ID="lblemailresult" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
        EnableRoundedCorners="True" Overlay="True">
    </telerik:RadNotification>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Behaviors="Close" OnClientClose="OnClientCloseContrato"
                NavigateUrl="busquedadocumentoda.aspx" Opacity="100" Title="Visor de contrato de Débito Automático" CssClass="element_radwindows"
                AutoSize="True">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnVerPago">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindow1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
