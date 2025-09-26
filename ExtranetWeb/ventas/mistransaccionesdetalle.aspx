<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="mistransaccionesdetalle.aspx.vb" Inherits="ExtranetWeb.mistransaccionesdetalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <meta http-equiv="x-ua-compatible" content="IE=9"/>
   <meta name="viewport" content="width=device-width, initial-scale=1" />
   <link href="../styles/estilotransaccion.css" rel="stylesheet" type="text/css" />
   <link href="../styles/estilotransacciondetalle.css" rel="stylesheet" type="text/css" />
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
    <div class="content_principal">
        <div class="content_principal_bloque">
            <div class="content_transacciondetalle_toolbar">
                <div class="content_transacciondetalle_toolbar_icon">
                    <telerik:RadButton ID="btnregresaproductos" runat="server" Text="Nuevo" ForeColor="Black"
                        Style="top: 0px; left: 0px; height: 30px; width: 30px" ToolTip="Regresar a la selección de transacciones">
                        <%--<Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/previous32x32.png" />--%>
                         <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/go_back32x32.png" />
                    </telerik:RadButton>
                </div>
            </div>
            <div class="content_transacciondetalle_separador"></div>
            <div class="content_transacciondetalle_gridcontrol">
                <telerik:RadGrid ID="rgdcotizadordetalle" runat="server" CellSpacing="0" Culture="es-ES" GridLines="None" AutoGenerateColumns="False" Height="315px"
                     Width="1000px" AllowAutomaticUpdates="True" Skin="Windows7">
                    <ClientSettings EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="NUMERO">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="NUMERO" FilterControlAltText="Filter GRUPO_NOMBRE column" HeaderText="No." UniqueName="NUMERO">
                                <FooterStyle Width="50px" CssClass="estilogridcontrol"/>
                                <HeaderStyle Font-Bold="True" Width="80px" CssClass="estilogridcontrol"/>
                                <ItemStyle Width="80px" CssClass="estilogridcontrol"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHA" FilterControlAltText="Filter column column" HeaderText="Fecha" UniqueName="FECHA">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol"/>
                                <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol"/>
                                <ItemStyle Width="100px" CssClass="estilogridcontrol"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HORA" FilterControlAltText="Filter VALORDESCUENTO column" HeaderText="Hora" UniqueName="HORA">
                                <FooterStyle Width="60px" CssClass="estilogridcontrol" Font-Bold="True"/>
                                <HeaderStyle Font-Bold="True" Width="60px" CssClass="estilogridcontrol"/>
                                <ItemStyle Width="60px" CssClass="estilogridcontrol" HorizontalAlign="Left"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TIPO_TRANSACCION" FilterControlAltText="Filter column column"
                                HeaderText="Tipo de Transacción" UniqueName="TIPO_TRANSACCION" DataFormatString="{0:N2}">
                                <FooterStyle Width="275px" CssClass="estilogridcontrol" Font-Bold="True"/>
                                <HeaderStyle Font-Bold="True" Width="275px" CssClass="estilogridcontrol"/>
                                <ItemStyle Width="275px" CssClass="estilogridcontrol" HorizontalAlign="Left"/>
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </div>
            <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True">
            </telerik:RadNotification>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
        </div>
    </div>
</asp:Content>

