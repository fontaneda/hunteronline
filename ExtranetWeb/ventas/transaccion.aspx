<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="transaccion.aspx.vb" Inherits="ExtranetWeb.transaccion" %>

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
<form id="Form1" action="#" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
    <div class="content_help">
        <telerik:RadButton ID="btnAyuda" runat="server" Text="" Style="top: 0px; left: 0px;
            height: 32px; width: 32px" OnClientClicked="openWinHelp">
            <Image ImageUrl="../images/icons/32x32/helpverde.png" HoveredImageUrl="../images/icons/32x32/helpverde.png"
                PressedImageUrl="../images/icons/32x32/helpverde.png" IsBackgroundImage="true">
            </Image>
        </telerik:RadButton>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function openWinHelp() {
                var oWnd = radopen("", "modalPopupHelp");
                oWnd.set_modal(true);
                if (!oWnd.get_modal()) document.documentElement.focus();
            }
        </script>
    </telerik:RadCodeBlock>
    <div class="content_principal">
        <div class="content_principal_bloque">
            <div class="content_transaccion_titulo">
                Pagos Realizados
            </div>
            <%-- <div class="content_transaccion_espacio">
            </div>--%>
            <div class="content_transaccion_toolbar">
                
                <div class="content_transaccion_toolbar_separador">
                </div>
                 
                <div class="content_transaccion_toolbar_textbox">
                    <div class="sec03">
                        <%-- <strong>Desde:&nbsp;</strong>--%>
                        Desde
                    </div>
                    <telerik:RadDatePicker ID="rdpFechaInicio" runat="server" ToolTip="Ingrese la fecha de inicio"
                        Width="120px" Height="18px">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Height="18px">
                        </DateInput>
                        <%--<DatePopupButton ImageUrl="../images/icons/32x32/Calendario.png" HoverImageUrl="../images/icons/32x32/Calendario.png" ></DatePopupButton>--%>
                        <DatePopupButton ImageUrl="../images/icons/16x16/Calendario21x20.png" HoverImageUrl="../images/icons/16x16/Calendario21x20.png">
                        </DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
                <div class="content_transaccion_toolbar_separador">
                </div>
                <div class="content_transaccion_toolbar_textbox">
                    <div class="sec03">
                        <%--<strong>Hasta:&nbsp;&nbsp;</strong>--%>
                        Hasta
                    </div>
                    <telerik:RadDatePicker ID="rdpFechaFin" runat="server" ToolTip="Ingrese la fecha de fin"
                        Width="120px" Height="18px">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Height="18px">
                        </DateInput>
                        <%-- <DatePopupButton ImageUrl="../images/icons/32x32/Calendario.png" HoverImageUrl="../images/icons/32x32/Calendario.png"></DatePopupButton>--%>
                        <DatePopupButton ImageUrl="../images/icons/16x16/Calendario21x20.png" HoverImageUrl="../images/icons/16x16/Calendario21x20.png">
                        </DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
                <div class="content_transaccion_toolbar_icon">
                    <telerik:RadButton ID="btnBuscar" runat="server" Text="Buscar" ForeColor="Black"
                        Style="top: 0px; left: 0px;" ToolTip="Consulta de transacciones de pago" Skin="Default"
                        Height="20px" Width="20px">
                        <%--<Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/Lupa.png" />--%>
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/16x16/Lupa20x20.png" />
                    </telerik:RadButton>
                </div>
                <div class="content_transaccion_toolbar_separador">
                </div>
                
                
                <div class="content_transaccion_toolbar_textbox" id="Divrefound" runat="server" style="width:450px; height:45px; 
                    margin-left:10px; background-color:#EDF7DF;" visible="false">
                    <center>
                        <asp:Label ID="lblrefoundtext" runat="server" Text="Transacción">
                        </asp:Label>
                        <asp:TextBox name="txtidrefound" id="txtidrefound" type="text" runat="server" ReadOnly="false" Width="127" style="margin:0px 0px 0px 7px;"/>
                        <telerik:RadButton ID="btnrefoundorder" runat="server" Text="Reembolso" 
                            Height="28px" Width="130" ForeColor="White">
                            <Image ImageUrl="../images/background/BotonPagar.png" HoveredImageUrl="../images/background/BotonPagar.png"
                                PressedImageUrl="../images/background/BotonPagar.png" IsBackgroundImage="true">
                            </Image>
                        </telerik:RadButton>
                        <br />
                        <asp:Label ID="lblretornorefound" runat="server">
                        </asp:Label>
                        <telerik:RadButton ID="btn_inactivos" runat="server" Text="Reenviar EMAIL a INACTIVOS" 
                            Height="28px" Width="130" ForeColor="White">
                            <Image ImageUrl="../images/background/BotonPagar.png" HoveredImageUrl="../images/background/BotonPagar.png"
                                PressedImageUrl="../images/background/BotonPagar.png" IsBackgroundImage="true">
                            </Image>
                        </telerik:RadButton>
                    </center>
                </div>

                 
            </div>
            <div class="content_transaccion_separador">
            </div>
            <div class="content_transaccion_detalle">
                <telerik:RadGrid ID="rgdverifordenestado" runat="server" CellSpacing="0" Culture="es-ES"
                    Skin="MyCustomSkin" EnableEmbeddedSkins="False" GridLines="None" AutoGenerateColumns="False"
                    Height="440px" Width="1002px" AllowAutomaticUpdates="True" OnSelectedIndexChanged="rgdverifordenestado_SelectedIndexChanged">
                    <%--<ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>--%>
                    <GroupingSettings CaseSensitive="false" />
                    <SortingSettings SortedBackColor="BurlyWood" />
                    <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ORDEN_ID" NoDetailRecordsText="" NoMasterRecordsText="">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="ORDEN_ID" FilterControlAltText="Filter column column"
                                HeaderText="Referencia" UniqueName="ORDEN_ID">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TIPO_TARJETA_DESC" FilterControlAltText="Filter column column"
                                HeaderText="Fecha" UniqueName="TIPO_TARJETA_DESC">
                                <FooterStyle Width="150px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="150px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TOTAL" FilterControlAltText="Filter column column"
                                HeaderText="Total" UniqueName="TOTAL" DataFormatString="{0:N2}">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CODIGO_CONF_PAGO" FilterControlAltText="Filter column column"
                                HeaderText="Código Conf. Pago" UniqueName="CODIGO_CONF_PAGO">
                                <FooterStyle Width="130px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="130px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="130px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ESTADO_WEB_DESC" FilterControlAltText="Filter column column"
                                HeaderText="Estado" UniqueName="ESTADO_WEB_DESC">
                                <FooterStyle Width="150px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="150px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHA_VERIFICACION" FilterControlAltText="Filter column column" Visible="false"
                                HeaderText="Fecha Verificación" UniqueName="FECHA_VERIFICACION" DataFormatString="{0:dd/MMM/yyyy HH:mm}">
                                <FooterStyle Width="150px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="150px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                           <%-- <telerik:GridTemplateColumn FilterControlAltText="Filter BTN_DETALLE column" UniqueName="BTN_DETALLE">
                                <ItemTemplate>
                                    <telerik:RadButton ID="btnvisualizar" runat="server" Text="Visualizar" ForeColor="Black"
                                        Style="top: 0px; left: 0px; height: 20px; width: 16px" ToolTip="Visualiza el detalle de la transacción de pago"
                                        OnClick="btnvisualizar_Click">
                                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/16x16/checklist16x20.png" />
                                    </telerik:RadButton>
                                </ItemTemplate>
                                <FooterStyle Width="30px" CssClass="estilogridcontrol" />
                                <HeaderStyle Width="30px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="estilogridcontrol" />
                            </telerik:GridTemplateColumn>--%>
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
                    <HeaderContextMenu EnableEmbeddedSkins="False">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
            <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="16px"
                Position="Center" Width="358px" ContentIcon="deny" EnableRoundedCorners="True"
                EnableShadow="True" Font-Bold="True" Font-Size="Medium" Opacity="95" TitleIcon="deny"
                ForeColor="Black" Overlay="True">
            </telerik:RadNotification>
        </div>
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnBuscar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgdverifordenestado" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbxestadopago">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgdverifordenestado" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAyuda">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAyuda" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
        <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="modalPopupHelp" runat="server" Width="500px" Height="220px"
                Modal="true" Behaviors="Close" CssClass="element" Title="Aviso Importante" Skin="MyCustomSkin"
                VisibleStatusbar="False" EnableEmbeddedSkins="False">
                <ContentTemplate>
                    <div class="renovacionradwindowsdetalle">
                        Pagos Realizados
                        <br />
                        <br />
                        Para consultar sus pagos realizados, por favor seleccionamos un rango de fechas
                        <br />
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    </form>
</asp:Content>
