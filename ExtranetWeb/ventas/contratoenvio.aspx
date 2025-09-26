<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="contratoenvio.aspx.vb" Inherits="ExtranetWeb.contratoenvio" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilodatospersonales.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estiloaprobacion.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
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
<form id="form1" runat="server">
    <section class="info-body">
        <div class="transacciones">    
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <div class="content_principal">
                <div class="content_principal_bloque">
                    <div class="content_toolbar">
                        <div class="content_toolbar_icon2">
                            <telerik:RadButton ID="BtnProcesar" runat="server" Text="Buscar" ForeColor="Black"
                                Style="top: 1px; left: 1px;" ToolTip="Procesar Contratos" Skin="Default"
                                Height="32px" Width="32px" Visible="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/Processok32x32.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="content_toolbar_icon2">
                            <telerik:RadButton ID="BtnCancelar" runat="server" Text="Buscar" ForeColor="Black"
                                Style="top: 1px; left: 1px;" ToolTip="Cancelar" Skin="Default"
                                Height="32px" Width="32px" Visible="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/remove32x32.png" />
                            </telerik:RadButton>
                        </div>
                       <%-- <div class="content_toolbar_icon2">
                            <telerik:RadButton ID="BtnBusquedaAvanzada"  runat="server" Text="Buscar" ForeColor="Black"
                                Style="top: 1px; left: 1px;" ToolTip="Cancelar" Skin="Default"
                                Height="32px" Width="32px" Visible="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/Lupa.png" />
                            </telerik:RadButton>
                        </div>--%>
                        <div class="content_toolbar_icon"> </div>
                        <div id="busqueda" class="conten_control_nuevo">
                            <div class="sec_RadTextBox_nuevo">
                                  <telerik:RadTextBox ID="txtbusqueda" runat="server" Height="22px" Width="250px" EmptyMessage="Búsqueda general" CssClass="content_border" />
                                  <telerik:RadButton ID="BtnBusquedaAvanzada" runat="server" Text="Buscar" ForeColor="Black" Style="top: 0; left: 10px;" 
                                    ToolTip="Consulta de datos" Skin="Default" Height="20px" Width="20px">
                                    <Image IsBackgroundImage="False" ImageUrl="../images/icons/16x16/Lupa20x20.png" />
                                  </telerik:RadButton>
                            </div>
                    
                        </div>
                        <%--<div class="content_toolbar_textbox2"></div>
                        <div class="content_toolbar_textbox2"></div>
                        <div class="content_toolbar_textbox"></div>       
                        <div class="content_toolbar_textbox"></div>       --%>
               
                    </div>
                    <div class="content_confirmardato_gridcontrol">
                        <telerik:RadGrid ID="contratocliente"  runat="server" CellSpacing="0" Culture="es-ES"
                            Width="850px" Height="620px" GridLines="None" AutoGenerateColumns="False" Skin="MyCustomSkin"
                            EnableEmbeddedSkins="False">
                            <ClientSettings EnableRowHoverStyle="true">
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="CODIGO_VEHICULO" NoDetailRecordsText="" NoMasterRecordsText="">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkI" runat="server" AutoPostBack="true" OnCheckedChanged="chkI_CheckedChanged" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkH" runat="server" AutoPostBack="true" OnCheckedChanged="chkH_CheckedChanged" />
                                        </HeaderTemplate>
                                        <FooterStyle CssClass="estilogridcontrol" Width="60px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Width="60px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="60px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="CODIGO_VEHICULO" FilterControlAltText="Filter CODIGO_VEHICULO column"
                                        HeaderText="Cod.Vehículo" UniqueName="CODIGO_VEHICULO">
                                        <FooterStyle Width="90px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="90px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="90px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CLIENTE" FilterControlAltText="Filter CLIENTE column"
                                        HeaderText="Cliente" UniqueName="CLIENTE">
                                        <FooterStyle CssClass="estilogridcontrol" Width="240px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="240px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="240px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NOMBRE_COMPLETO" FilterControlAltText="Filter NOMBRE_COMPLETO column"
                                        HeaderText="Vehículo" UniqueName="NOMBRE_COMPLETO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="240px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="240px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="240px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PRODUCTO" FilterControlAltText="Filter PRODUCTO column"
                                        HeaderText="Producto" UniqueName="PRODUCTO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="120px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="120px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="120px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FECHA_CHEQUEO" FilterControlAltText="Filter FECHA_CHEQUEO column"
                                        HeaderText="Fecha Chequeo" UniqueName="FECHA_CHEQUEO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="120px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="120px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="120px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ORDEN_SERVICIO" FilterControlAltText="Filter ORDEN_SERVICIO column"
                                        HeaderText="Orden Servicio" UniqueName="ORDEN_SERVICIO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="100px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="100px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="100px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EMAIL" FilterControlAltText="Filter EMAIL column"
                                        HeaderText="Email" UniqueName="EMAIL">
                                        <FooterStyle CssClass="estilogridcontrol" Width="140px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="140px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="140px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ESTADO" FilterControlAltText="Filter ESTADO column"
                                        HeaderText="Estado" UniqueName="ESTADO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="80px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="80px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="80px" />
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="FECHA_REENVIO" FilterControlAltText="Filter FECHA_REENVIO column"
                                        HeaderText="Fecha Reenvío" UniqueName="FECHA_REENVIO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="100px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="100px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="100px" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="GRUPO" Display="false" FilterControlAltText="Filter GRUPO column"
                                        HeaderText="GRUPO" UniqueName="GRUPO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="0px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="0px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="0px" />
                                    </telerik:GridBoundColumn>
                           
                                    <telerik:GridBoundColumn DataField="CODIGO_CLIENTE" Display="false" FilterControlAltText="Filter CODIGO_CLIENTE column"
                                        HeaderText="Cod.Cliente" UniqueName="CODIGO_CLIENTE">
                                        <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ORDEN_TRABAJO" Display="false" FilterControlAltText="Filter ORDEN_TRABAJO column"
                                        HeaderText="Orden Trabajo" UniqueName="ORDEN_TRABAJO">
                                        <FooterStyle CssClass="estilogridcontrol" Width="0px" />
                                        <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="0px" />
                                        <ItemStyle CssClass="estilogridcontrol" Width="0px" />
                                    </telerik:GridBoundColumn>

                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                            <HeaderContextMenu EnableEmbeddedSkins="False">
                            </HeaderContextMenu>
                        </telerik:RadGrid>

                    </div>
                    <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="16px"
                        Position="Center" Width="358px" ContentIcon="" EnableRoundedCorners="True" EnableShadow="True"
                        Font-Bold="True" Font-Size="Medium" Opacity="95" TitleIcon="" ForeColor="Black"
                        Overlay="True">
                    </telerik:RadNotification>
                 </div>
            </div>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="BtnProcesar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="txtbusqueda" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="contratocliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnCancelar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnCancelar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="txtbusqueda" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="contratocliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                     <telerik:AjaxSetting AjaxControlID="txtbusqueda">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnCancelar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="txtbusqueda" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="contratocliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnBusquedaAvanzada">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnCancelar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="txtbusqueda" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="contratocliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                     <telerik:AjaxSetting AjaxControlID="contratocliente">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="BtnCancelar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                            <telerik:AjaxUpdatedControl ControlID="contratocliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>

                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
        </div>
    </section>
</form>
</asp:Content>