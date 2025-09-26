<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="cotizadorurlretorno.aspx.vb" Inherits="ExtranetWeb.cotizadorurlretorno" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/estilorenovacion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function impre(num) {
            document.getElementById(num).className = "ver";
            print();
            document.getElementById(num).className = "nover";
        }
    </script>
    <div class="content_principal">
        <div class="content_principal_bloque">
            <div class="content_renovacion_titulopage">
                <h2>
                    Resultado de Transacción
                </h2>
            </div>
            <div class="content_crit_info_detalleitems_productocliente">
                <div class="content_datospersonales_bloque">
                    <div class="content_cotizadorurlretorno_bloque">
                        <div class="content_cotizadorurlretorno_titulo">
                            <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurlretorno_label">
                            Orden de Pago
                        </div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lblordenpago" runat="server" Text=""></asp:Label>
                             &nbsp; &nbsp;
                            <telerik:RadButton ID="BtnVerPago" runat="server" Text="Ver Pago" Width="81px" Height="22px" HoveredCssClass="goButtonClassHov" ForeColor="White" >
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                </Image>
                            </telerik:RadButton>
                        </div>
                        <div class="content_cotizadorurlretorno_label" hidden="true">
                            Cotización
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true">
                            <asp:Label ID="lblcotizacion" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_label">
                            Identificación
                        </div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lblidentificacion" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_label">
                            Nombre
                        </div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lblnombre" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_label">
                            Subtotal</div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lblsubtotal" runat="server"></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_label">
                            Iva</div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lbliva" runat="server"></asp:Label>
                        </div>
                       <div class="content_cotizadorurlretorno_label">
                            Total
                        </div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_label">
                            Código. Conf. Pago
                        </div>
                        <div class="content_cotizadorurlretorno_textbox">
                            <asp:Label ID="lblcodcnfpago" runat="server"></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurlretorno_textbox2">
                            <asp:Image ID="imageResultado" runat="server" 
                                ImageUrl="~/images/icons/24x24/alerterror.png" Visible="false" />
                            <asp:Label ID="lblemailresult" runat="server"></asp:Label>
                        </div>
                        <div class="content_cotizadorurlretorno_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurlretorno_textbox2">
                        </div>
                        <div class="content_cotizadorurlretorno_textbox2">
                            <telerik:RadButton ID="Btnregresarinicio" runat="server" Text="Regresar al Inicio"
                                Width="110px" Height="22px" Visible="False">
                            </telerik:RadButton>
                        </div>
                        <div class="content_cotizadorurlretorno_textbox2">
                            <input type="button" onclick="impre('container');return false" style="background-image: url('../images/icons/32x32/icon_print.png');
                                background-repeat: no-repeat; background-position: center center; height: 29px;
                                width: 35px; background-color: #FFFFFF; border: none;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
        EnableRoundedCorners="True" Overlay="True">
    </telerik:RadNotification>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow7" runat="server" Behaviors="Close" Width="300px" Height="300px" NavigateUrl="clientepotencial.aspx"
                Opacity="100" Title="Registro de Referidos" CssClass="element_radwindows" AutoSize="True">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>