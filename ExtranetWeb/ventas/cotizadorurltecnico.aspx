<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="cotizadorurltecnico.aspx.vb" Inherits="ExtranetWeb.cotizadorurltecnico" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_article">
        <div class="toolbar2">
            <div class="toolbar_icon_001">
                <telerik:RadButton ID="btnregresadetalleproductos" runat="server" Text="Nuevo" ForeColor="Black"
                    Style="top: 0px; left: 0px; height: 32px; width: 32px" ToolTip="Regresar al detalle de productos">
                    <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/previous32x32.png" />
                </telerik:RadButton>
            </div>
            <div class="toolbar_icon_001">
                <telerik:RadButton ID="btnsiguienteurltecnica" runat="server" Text="Siguiente" ForeColor="Black"
                    Style="top: 0px; left: 0px; height: 32px; width: 32px" ToolTip="Continuar con la pantalla de pago">
                    <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/next32x32.png" />
                </telerik:RadButton>
            </div>
            <div class="toolbar_icon_001">
            </div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                    </asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>
        </div>
        <div class="separador_004">
        </div>
        <div class="content_crit_info_detalleitems3">
            <div class="secc_forma_pago_master">
                <div class="secc_forma_pago_title01">
                    Pago con Tarjeta de Crédito
                </div>
                <div class="secc_forma_pago_prp">
                    Puede pagar de forma segura con las siguientes tarjetas de crédito
                </div>
                <div class="secc_forma_pago_cbx">
                    <telerik:RadComboBox ID="cbxtarjeta" runat="server" Width="190px" AutoPostBack="True"
                        Height="130px">
                        <ItemTemplate>
                            <div class="cbxtarjt_region">
                                <div class="cbxtarjt_img">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Width="42"
                                        Height="29" />
                                </div>
                                <div class="cbxtarjt_txt">
                                    <%# Eval("Text") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </telerik:RadComboBox>
                </div>
                <div class="secc_forma_pago_cbx">
                    <asp:Image ID="imgtarjeta" runat="server" />&nbsp;</div>
                    <div class="secc_forma_pago_cbx"></div>
                    <div class="secc_forma_pago_cbx"></div>
                    <div class="secc_forma_pago_cbx"></div>
                    <div class="secc_forma_pago_cbx"></div>
            </div>
            <div class="secc_datos_orden_master3">
                <div class="secc_forma_pago_title01">
                    Datos de la Cotización
                </div>
                <div class="datagrid">
                    <table>
                        <tfoot>
                            <tr>
                                <td>
                                    <strong>Cotización</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblcotizacion_id" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                        <tbody>
                            <tr>
                                <td>
                                    <strong>Identificación</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblcotizacion_idcliente" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Cliente</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblcotizacion_descliente" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Dirección</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <telerik:RadTextBox ID="txtcotizacion_direccion" runat="server" MaxLength="100">
                                        </telerik:RadTextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Teléfono</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblcotizacion_telf" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Email</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblcotizacion_email" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Orden Pago</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblordenpago" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="secc_datos_orden_master2">
                <div class="secc_datos_orden_title01">
                    Datos de la Orden de Pago</div>
                <div class="datagrid">
                    <table>
                        <tfoot>
                            <tr>
                                <td>
                                    <strong>Total</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblpago_total" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                        <tbody>
                            <tr>
                                <td>
                                    <strong>Subtotal</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblpago_subtotal" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Descuentos</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblpago_descuentos" runat="server" Text=""></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Promociones</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblpago_promociones" runat="server" Text=""></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>I.V.A.</strong>
                                </td>
                                <td>
                                    <div class="celldefault">
                                        <asp:Label ID="lblpago_iva" runat="server" Text=""></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <input type="hidden" name="TRANSACCIONID" value="" />
        <input type="hidden" name="XMLREQUEST" value="e9jNeaymGbE3%2FmQHjuaQVDhmJC5VqyWaLsfRMqFwLVXxvXwZwyr1FZmQXySxyMHzgtKflpQ9WjFNsy1l%2FXWhxlXv6MAHPIefr6%2B6SjxVRPLm0ybxl6SQg%2FVbvyzl1fz24kmdaPi8EnLgkPhFG7QcGWDKunU29bFaw9ssCJJza9JQK%2BrJcc7DBN9tzkwJ%2F3UKKQQTc7DUWH29DiUwBehiB6otVIJxl%2BHFOwdQ8WeUDO4%3D" />
        <input type="hidden" name="XMLDIGITALSIGN" value="HHktYnpYqCzCYOclbMXfBRpqGgqq9my5FXqvcf3Vpb0wrmFl0wlp1LDIeacsArZrNo9XfnVJqM57ptDOYdyh%2FQgccsMODdfHkKqvH7e9x8NxmCStoep9haMUAf%2BNFOIBXuXkHcRxhDfB%2FFd4wgvY%2BEexG1fEmXMM%2FeZtrsyjcJs%3D" />
        <input type="hidden" name="XMLACQUIRERID" value="http://10.100.89.6:8189/PagosDiners/UrlTecnico.aspx;" />
        <input type="hidden" name="XMLMERCHANTID" value="0991259546003" />
        <input type="hidden" name="XMLGENERATEKEY" value="IBgbA%2FW%2FCkCXu2MQJWDRjF9TvQlHmIluoUzAoTuniNs%2BTTHfxJRZmsvQdmEoRsgb3SvWpzFB8bZkYMm0NSCstRDo5CXbmj534PtEm348DlYiJ%2FLOmp5JKgDUSBionAT67e%2FDQ9mmr84GJgeBPPUV8DNn%2BjBNxJcPydATUjW9ZO0%3D" />
    </div>
</asp:Content>
