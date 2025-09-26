<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="transacciondetalle.aspx.vb" Inherits="ExtranetWeb.transacciondetalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilotransaccion.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilotransacciondetalle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
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
            <div class="content_transaccion_titulo">
                Detalle De Mi Pago
            </div>
            <div class="regusu_secc_table_boton_transaccion">
            </div>
            <div class="content_transacciondetalle_toolbar_icon">
                <telerik:RadButton ID="btnregresaproductos" runat="server" Width="81px" Height="22px"
                    Text="Regresar" HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Regresar a la selección de transacciones">
                    <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                    </Image>
                </telerik:RadButton>
            </div>
            <%--  <div class="content_transacciondetalle_toolbar">
                <div class="content_transacciondetalle_toolbar_icon">
                    <telerik:RadButton ID="btnregresaproductos" runat="server" Text="Nuevo" ForeColor="Black"
                        Style="top: 0px; left: 0px; height: 30px; width: 30px" ToolTip="Regresar a la selección de transacciones">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/go_back32x32.png" />
                    </telerik:RadButton>
                </div>
            </div>--%>
            <div class="content_transacciondetalle_separador1">
            </div>
            <div class="content_transacciondetalle_cabecera">
                <div class="content_transacciondetalle_cabecera_label">
                    No. Orden
                </div>
                <div class="content_transacciondetalle_cabecera_textbox2">
                    <telerik:RadTextBox ID="txtorderid" runat="server" Width="80px" Skin="Default" TabIndex="3"
                        ReadOnly="True">
                    </telerik:RadTextBox>
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Identificación
                </div>
                <div class="content_transacciondetalle_cabecera_textbox">
                    <telerik:RadTextBox ID="txtidentificacion" runat="server" Width="150px" Skin="Default"
                        TabIndex="3" MaxLength="13" AutoPostBack="True" ReadOnly="True">
                    </telerik:RadTextBox>
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Nombre
                </div>
                <div class="content_transacciondetalle_cabecera_textbox3">
                    <telerik:RadTextBox ID="txtnombre" runat="server" Width="320px" Skin="Default" TabIndex="4"
                        ReadOnly="True">
                    </telerik:RadTextBox>
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Fecha Pago
                </div>
                <div class="content_transacciondetalle_cabecera_textbox2">
                    <telerik:RadDatePicker ID="txtfechapago" runat="server" Width="80px" Skin="Default"
                        TabIndex="3" ReadOnly="True" Culture="es-EC" Enabled="False">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Height="18px" Width="70px">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Hora Pago
                </div>
                <div class="content_transacciondetalle_cabecera_textbox">
                    <telerik:RadDateTimePicker ID="txthorapago" runat="server" Width="150px"
                        TabIndex="3" ReadOnly="True" Culture="es-EC" Enabled="False">
                        <TimeView CellSpacing="-1" Culture="es-EC">
                        </TimeView>
                        <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                            ViewSelectorText="x" EnableMonthYearFastNavigation="False">
                        </Calendar>
                        <DateInput DisplayDateFormat="HH:mm" DateFormat="HH:mm" DisplayText="" LabelWidth="40%"
                            type="text" value="" Height="18px" Width="70px">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></DatePopupButton>
                    </telerik:RadDateTimePicker>
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Forma de Pago
                </div>
                <div class="content_transacciondetalle_cabecera_textbox">
                    <telerik:RadTextBox ID="txtformapago" runat="server" Width="150px" Skin="Default"
                        TabIndex="3" AutoPostBack="True" ReadOnly="True">
                    </telerik:RadTextBox>
                </div>
                <div class="content_transacciondetalle_cabecera_separador">
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Tipo Tarjeta
                </div>
                <div class="content_transacciondetalle_cabecera_textbox2">
                    <telerik:RadTextBox ID="txttipotarjeta" runat="server" Width="80px" Skin="Default"
                        TabIndex="3" ReadOnly="True">
                    </telerik:RadTextBox>
                </div>
                <div class="content_transacciondetalle_cabecera_label">
                    Autorización
                </div>
                <div class="content_transacciondetalle_cabecera_textbox3">
                    <telerik:RadTextBox ID="txtnumeroautorizacion" runat="server" Width="255px" Skin="Default"
                        TabIndex="4" ReadOnly="True">
                    </telerik:RadTextBox>
                </div>
            </div>
            <div class="content_transacciondetalle_gridcontrol">
                <telerik:RadGrid ID="rgdcotizadordetalle" runat="server" CellSpacing="0" Culture="es-ES"
                    GridLines="None" AutoGenerateColumns="False" Height="250px" Width="1000px" AllowAutomaticUpdates="True"
                    Skin="MyCustomSkin" EnableEmbeddedSkins="false">
                    <%--<ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                    </ClientSettings>--%>
                    <ClientSettings EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ORDERID" NoDetailRecordsText="" NoMasterRecordsText="">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="VEHICLEID" FilterControlAltText="Filter VEHICLEID column"
                                HeaderText="Vehículo" UniqueName="VEHICLEID" Visible="false">
                                <FooterStyle Width="70px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="70px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="70px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PLACA" FilterControlAltText="Filter PLACA column"
                                HeaderText="Placa" UniqueName="PLACA" Visible="false">
                                <FooterStyle Width="70px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="70px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="70px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MARCA_NOMBRE" FilterControlAltText="Filter MARCA_NOMBRE column"
                                HeaderText="Marca" UniqueName="MARCA_NOMBRE" Visible="false">
                                <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MODELO_NOMBRE" FilterControlAltText="Filter MODELO_NOMBRE column"
                                HeaderText="Modelo" UniqueName="MODELO_NOMBRE" Visible="false">
                                <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="GRUPO_NOMBRE" FilterControlAltText="Filter GRUPO_NOMBRE column"
                                HeaderText="Bien Protegido" UniqueName="GRUPO_NOMBRE">
                                <FooterStyle Width="270px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="270px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="270px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRODUCTONOMBRE" FilterControlAltText="Filter column column"
                                HeaderText="Servicio" UniqueName="PRODUCTONOMBRE">
                                <FooterStyle Width="200px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="200px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="200px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="YEARS" FilterControlAltText="Filter VALORDESCUENTO column"
                                HeaderText="Años Ren." UniqueName="YEARS">
                                <FooterStyle Width="75px" Font-Bold="True" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="75px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="75px" HorizontalAlign="Right" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ANNUALVALUE" FilterControlAltText="Filter column column"
                                HeaderText="P. Sin IVA" UniqueName="ANNUALVALUE" DataFormatString="{0:N2}">
                                <FooterStyle Width="80px" Font-Bold="True" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="80px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="80px" HorizontalAlign="Right" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CODIGO_PROMOCION" FilterControlAltText="Filter column column"
                                HeaderText="Cod.Promo." UniqueName="CODIGO_PROMOCION">
                                <FooterStyle Font-Bold="True" Width="70px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="70px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="70px" HorizontalAlign="Right" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VALOR_PROMOCION" Visible="true" FilterControlAltText="Filter VALOR_PROMOCION column"
                                HeaderText="Val.Promo." UniqueName="VALOR_PROMOCION" DataFormatString="{0:N2}">
                                <FooterStyle Font-Bold="True" Width="70px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="70px" CssClass="estilogridcontrol" />
                                <ItemStyle HorizontalAlign="Right" Width="70px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DISCOUNT" FilterControlAltText="Filter DESCUENTO column"
                                HeaderText="Descuento" UniqueName="DISCOUNT" DataFormatString="{0:N2}" Visible="false">
                                <FooterStyle Width="80px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="80px" CssClass="estilogridcontrol" />
                                <ItemStyle HorizontalAlign="Right" Width="80px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SUBTOTAL" FilterControlAltText="Filter SUBTOTAL column"
                                HeaderText="SubTotal" UniqueName="SUBTOTAL" DataFormatString="{0:N2}">
                                <FooterStyle Width="90px" Font-Bold="True" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="90px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="90px" HorizontalAlign="Right" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TOTAL" FilterControlAltText="Filter PRECIOTOTAL column"
                                HeaderText="Total" UniqueName="TOTAL" DataFormatString="{0:N2}" Visible="false">
                                <FooterStyle Width="80px" Font-Bold="True" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="80px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="80px" HorizontalAlign="Right" CssClass="estilogridcontrol" />
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
            <div class="content_transacciondetalle_totales2">
                <div class="content_transacciondetalle_totales_label3">
                </div>
                <div class="content_transacciondetalle_totales_label">
                    &nbsp;&nbsp;&nbsp;&nbsp; SubTotal
                </div>
                <div class="content_transacciondetalle_totales_calculo">
                    <asp:Label ID="lblsubtotal" runat="server"></asp:Label>
                </div>
                <%--                <div class="content_transacciondetalle_totales_label">
                    (-) Descuentos
                </div>
                <div class="content_transacciondetalle_totales_calculo">
                    <asp:Label ID="lbldescuento" runat="server"></asp:Label>
                </div>--%>
                <div class="content_transacciondetalle_totales_label3">
                </div>
                <div class="content_transacciondetalle_totales_label">
                    &nbsp;&nbsp;&nbsp;&nbsp;(+) I.V.A
                </div>
                <div class="content_transacciondetalle_totales_calculo">
                    <asp:Label ID="lbliva" runat="server"></asp:Label>
                </div>
                <div class="content_transacciondetalle_totales_label3">
                </div>
                <div class="content_transacciondetalle_totales_label">
                    &nbsp;&nbsp;&nbsp;&nbsp;(+) Intereses
                </div>
                <div class="content_transacciondetalle_totales_calculo">
                    <asp:Label ID="lblintereses" runat="server"></asp:Label>
                </div>

                <div class="content_transacciondetalle_totales_label3">
                </div>
                <div class="content_transacciondetalle_totales_label2">
                    &nbsp;&nbsp;&nbsp;&nbsp;Total
                </div>
                <div class="content_transacciondetalle_totales_calculo2">
                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                </div>
            </div>
            <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                EnableRoundedCorners="True" Overlay="True">
            </telerik:RadNotification>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
        </div>
    </div>
</asp:Content>
