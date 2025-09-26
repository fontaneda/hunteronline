 <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" 
    CodeBehind="estadocuenta.aspx.vb" Inherits="ExtranetWeb.estadocuenta" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilotransaccion.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilotransacciondetalle.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estiloestadocuenta.css" rel="stylesheet" type="text/css" />
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
                Estados de cuenta
            </div>
            <div class="content_estado_toolbar">
                <div class="content_transaccion_toolbar_separador">
                </div>
                <div class="content_transaccion_toolbar_textbox">
                    <div class="sec03">
                        Desde
                    </div>
                    <telerik:RadDatePicker ID="rdpFechaInicio" runat="server" ToolTip="Ingrese la fecha de inicio"
                        Width="120px" Height="18px">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Height="18px">
                        </DateInput>
                        <DatePopupButton ImageUrl="../images/icons/16x16/Calendario21x20.png" HoverImageUrl="../images/icons/16x16/Calendario21x20.png">
                        </DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
                <div class="content_transaccion_toolbar_separador">
                </div>
                <div class="content_transaccion_toolbar_textbox">
                    <div class="sec03">
                        Hasta
                    </div>
                    <telerik:RadDatePicker ID="rdpFechaFin" runat="server" ToolTip="Ingrese la fecha de fin"
                        Width="120px" Height="18px">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Height="18px">
                        </DateInput>
                        <DatePopupButton ImageUrl="../images/icons/16x16/Calendario21x20.png" HoverImageUrl="../images/icons/16x16/Calendario21x20.png">
                        </DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
                <div class="content_transaccion_toolbar_icon">
                    <telerik:RadButton ID="btnBuscar" runat="server" Text="Buscar" ForeColor="Black"
                        Style="top: 0px; left: 0px;" ToolTip="Consulta de transacciones de pago" Skin="Default"
                        Height="20px" Width="20px">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/16x16/Lupa20x20.png" />
                    </telerik:RadButton>
                </div>
                <div class="content_transaccion_toolbar_separador">
                </div>
                <div class="content_estado_toolbar_mail" id="control_email" runat="server">
                    <telerik:RadTextBox ID="txtemail" runat="server" Height="22px" Width="230px" EmptyMessage="Ingrese el e-mail" CssClass="content_border" MaxLength="100" />
                    <telerik:RadButton ID="BtnEnviar" runat="server" Width="81px" Height="22px" Text="Enviar" ValidationGroup="grupo01"
                            HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Enviar" CssClass="sec_border_boton">
                            <Image ImageUrl="../images/background/verde.png" HoveredImageUrl="../images/background/verde.png"
                                   PressedImageUrl="../images/background/verde.png" IsBackgroundImage="true" />
                    </telerik:RadButton>
                    <telerik:RadButton ID="BtnCancelar" runat="server" Width="81px" Height="22px" Text="Cancelar"
                            HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Cancelar" CssClass="sec_border_boton">
                            <Image ImageUrl="../images/background/verde.png" HoveredImageUrl="../images/background/verde.png"
                                   PressedImageUrl="../images/background/verde.png" IsBackgroundImage="true" />
                    </telerik:RadButton>
                </div>
            </div>
            <div class="content_transaccion_separador">
            </div>
            <div class="content_estado_grid">
                <telerik:RadGrid ID="rgdverifordenestado" runat="server" CellSpacing="0" Culture="es-ES"
                    Skin="MyCustomSkin" EnableEmbeddedSkins="False" GridLines="None" AutoGenerateColumns="False"
                    Height="130px" Width="1002px" AllowAutomaticUpdates="True">
                    <GroupingSettings CaseSensitive="false" />
                    <SortingSettings SortedBackColor="BurlyWood" />
                    <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="DOCUMENTO" NoDetailRecordsText="" NoMasterRecordsText="">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="DOCUMENTO" FilterControlAltText="Filter column column"
                                HeaderText="Referencia" UniqueName="DOCUMENTO">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CLIENTE_NOMBRE" FilterControlAltText="Filter column column"
                                HeaderText="Cliente" UniqueName="CLIENTE_NOMBRE">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHA" FilterControlAltText="Filter column column"
                                HeaderText="Fecha" UniqueName="FECHA">
                                <FooterStyle Width="150px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="150px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter column column"
                                HeaderText="Total" UniqueName="VALOR" DataFormatString="{0:N2}">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TIPO_DOCUMENTO" FilterControlAltText="Filter column column"
                                HeaderText="Tipo Documento" UniqueName="TIPO_DOCUMENTO" Visible="true">
                                <FooterStyle Width="130px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="130px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="130px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SUCURSAL" FilterControlAltText="Filter column column"
                                HeaderText="Sucursal" UniqueName="SUCURSAL" Visible="true">
                                <FooterStyle Width="150px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="150px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="150px" CssClass="estilogridcontrol" />
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
                    <HeaderContextMenu EnableEmbeddedSkins="False">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
            <div class="content_transaccion_separador">
            </div>
            <div class="content_estado_documento" >
                <embed id="myframe" src="" name="myframe" runat="server" width="100%" height="360px"></embed> 
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
            <telerik:AjaxSetting AjaxControlID="btnAyuda">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAyuda" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnBuscar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgdverifordenestado" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgdverifordenestado">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgdverifordenestado" 
                        UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="myframe" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="control_email" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BtnEnviar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgdverifordenestado" 
                        LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" UpdatePanelCssClass="" />
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
                        Estados de cuenta
                        <br />
                        <br />
                        Para consultar sus pagos estados de cuenta, por favor seleccionamos un rango de fechas
                        <br />
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
