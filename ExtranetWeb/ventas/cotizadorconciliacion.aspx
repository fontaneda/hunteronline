<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="cotizadorconciliacion.aspx.vb" Inherits="ExtranetWeb.cotizadorconciliacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_principal">
        <div class="content_principal_bloque">
            <div class="content_cotizadorconciliacion_toolbar">
                <div class="content_cotizadorconciliacion_toolbar_icon">
                    <telerik:RadButton ID="BtnRegresaConsulta" runat="server" Text="Nuevo" ForeColor="Black" Style="top: 0px; left: 0px; height: 32px; width: 32px"
                             ToolTip="Regresar a la consulta general" TabIndex="1">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/previous32x32.png" />
                    </telerik:RadButton>
                </div>
                <div class="content_cotizadorconciliacion_toolbar_icon">
                    <telerik:RadButton ID="BtnBuscar" runat="server" Text="Consultar" ForeColor="Black"
                        Style="top: 0px; left: 0px; height: 32px; width: 32px" ToolTip="Consulta ordenes de pago a generarse en el archivo"
                        Skin="Default">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/search32x32.png" />
                    </telerik:RadButton>
                </div>
                <div class="content_cotizadorconciliacion_toolbar_icon">
                    <telerik:RadButton ID="BtnDescargarCsv" runat="server" Text="Descargar" ForeColor="Black" Style="top: 0px; left: 0px; height: 32px; width: 32px"
                         ToolTip="Genera archivo conciliación para descargar" Skin="Default">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/downloadfile0232x32.png" />
                    </telerik:RadButton>
                </div>
            </div>
            <div class="content_cotizadorconciliacion_detalle">
                <div class="content_cotizadorconciliacion_label">
                    Fecha:
                </div>
                <div class="content_cotizadorconciliacion_textbox">
                    <telerik:RadDatePicker ID="rdpFechaConsulta" runat="server" AutoPostBack="True" Culture="es-EC"
                        FocusedDate="2014-01-01" MaxDate="2015-12-31" MinDate="2014-01-01">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server" AutoPostBack="True">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </div>
            <div class="content_cotizadorconciliacion_separador"></div>
            <div class="content_cotizadorconciliacion_grid">
                <telerik:RadGrid ID="grdinfoconciliacion" runat="server" AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None" Height="520px">
                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="REFERENCIA" FilterControlAltText="Filter REFERENCIA column"
                                HeaderText="No. Orden" UniqueName="REFERENCIA">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TIPO_TARJETA" FilterControlAltText="Filter TIPO_TARJETA column"
                                HeaderText="Tipo Tarjeta" UniqueName="TIPO_TARJETA">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SUBTOTAL" FilterControlAltText="Filter SUBTOTAL column"
                                HeaderText="Subtotal" UniqueName="SUBTOTAL" DataFormatString="{0:N2}">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IVA" FilterControlAltText="Filter IVA column"
                                HeaderText="Iva" UniqueName="IVA" DataFormatString="{0:N2}">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ICE" FilterControlAltText="Filter ICE column"
                                HeaderText="Ice" UniqueName="ICE" DataFormatString="{0:N2}">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="INTERESES" FilterControlAltText="Filter INTERESES column"
                                HeaderText="Interés" UniqueName="INTERESES" DataFormatString="{0:N2}">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MESES" FilterControlAltText="Filter MESES column"
                                HeaderText="No. Meses" UniqueName="MESES">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Font-Bold="True" Width="100px" />
                                <ItemStyle Width="100px" />
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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
        EnableRoundedCorners="True" Overlay="True" Text=" ">
    </telerik:RadNotification>
</asp:Content>
