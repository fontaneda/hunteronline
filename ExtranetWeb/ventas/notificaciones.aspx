<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="notificaciones.aspx.vb" Inherits="ExtranetWeb.notificaciones" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilonotificacion.css" rel="stylesheet" type="text/css" />
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
  <%--<div class="content_help">
        <telerik:RadButton ID="btnAyuda" runat="server" Text="" Style="top: 0px; left: 0px;
            height: 32px; width: 32px" OnClientClicked="openWinHelp">
            <Image ImageUrl="../images/icons/32x32/helpNaranja.png" HoveredImageUrl="../images/icons/32x32/helpNaranja.png"
                PressedImageUrl="../images/icons/32x32/helpNaranja.png" IsBackgroundImage="true">
            </Image>
        </telerik:RadButton>
    </div>--%>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function openWinHelp() 
            {
                var oWnd = radopen("", "modalPopupHelp");
                oWnd.set_modal(true);
                if (!oWnd.get_modal()) document.documentElement.focus();
            }
            var imageUrlFormat = "../images/icons/16x16/{0}.png";
            function pageLoad() 
            {
                listView = $find('<%= RadListView1.ClientID %>');
            }
        </script>
    </telerik:RadCodeBlock>
    <div class="content_principal_notificacion">
        <div class="content_principal_bloque_notificacion">
            <div class="content_titulopage">
                <h2>
                    Visualización de Notificaciones
                </h2>
            </div>
            <div class="conten_control">
                <div class="sec_RadTextBox">
                    <telerik:RadTextBox ID="txtbusqueda" runat="server" Height="22px" Width="280px" EmptyMessage="Búsqueda general" CssClass="content_border">
                    </telerik:RadTextBox>
                </div>
                <div class="sec_RadButton">
                    <telerik:RadButton ID="BtnbusquedaAvanzada" runat="server" Text="Buscar" ForeColor="Black"
                        Style="top: 5px; left: 5px;" ToolTip="Consulta de transacciones" Skin="Default" Height="20px" Width="20px">
                        <Image IsBackgroundImage="False" ImageUrl="../images/icons/16x16/Lupa20x20.png" />
                    </telerik:RadButton>
                </div>
            </div>
            <div class="content_toolbar_2">
                <div class="content_toolbar_textbox_2">
                    <telerik:RadDatePicker ID="rdpFechaInicio" runat="server" ToolTip="Ingrese la fecha de inicio"
                        Width="120px" Height="18px" Visible="False">
                        <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                        <DateInput runat="server"  DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%"  Height="18px">
                        </DateInput>
                        <DatePopupButton ImageUrl="../images/icons/16x16/Calendario21x20.png" HoverImageUrl="../images/icons/16x16/Calendario21x20.png">
                        </DatePopupButton>
                    </telerik:RadDatePicker>
                    <telerik:RadButton ID="BtnRegresar" runat="server" Width="81px" Height="22px" Text="Regresar"
                        HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Regresar al Inicio">
                        <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                            PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                        </Image>
                    </telerik:RadButton>
                </div>
                <div class="content_toolbar_textbox_2">
                    <telerik:RadDatePicker ID="rdpFechaFin" runat="server" ToolTip="Ingrese la fecha de fin" Width="120px" Height="18px" Visible="False">
                        <Calendar runat="server"  UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                        <DateInput runat="server"  DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%"  Height="18px">
                        </DateInput>
                        <DatePopupButton ImageUrl="../images/icons/16x16/Calendario21x20.png" HoverImageUrl="../images/icons/16x16/Calendario21x20.png">
                        </DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
                <div class="content_toolbar_textbox_2"></div>
                <div class="content_toolbar_textbox_2">
                    <div class="sec_vigente">
                        <asp:LinkButton ID="LinkVigentes" runat="server" CssClass="sec_vinculos">Vigentes</asp:LinkButton>
                    </div>
                    <div class="sec_division">
                        <%--<asp:LinkButton ID="caracter" runat="server" class="sec_division">|</asp:LinkButton>--%>
                        <asp:Label ID="caracter" runat="server" class="sec_division" Text=" |"></asp:Label>
                    </div>
                    <div class="sec_vencido">
                        <asp:LinkButton ID="LinkVencidos" runat="server" CssClass="sec_vinculos">Vencidos</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="content_detalle_1">
                <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <telerik:RadListView ID="RadListView1" runat="server" AllowPaging="True" PageSize="6"
                        DataKeyNames="NOTIFICACION_ID" OnSelectedIndexChanged="RadListView1_SelectedIndexChanged">
                        <ItemTemplate>
                            <div class="div_principal_listview">
                                <div class="content_principal_div">
                                    <div class="div_secundario_imagen">
                                        <div class="div_imagen">
                                           <img src="<%# Eval("GUSTA") %>" alt="Imagen" />
                                            <%--<asp:ImageButton ID="ImagenGusta" runat="server" alt="Imagen" CommandName="Select" ImageUrl='<%# Eval("GUSTA") %>' />--%>
                                        </div>
                                    </div>
                                    <div class="div_secundario_principal">
                                        <div class="div_secundario_mensaje">
                                            <asp:LinkButton ID="LinkButton1" CssClass="selectedButtons" runat="server" CommandName="Select">
                                                <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Bind("COMENTARIO") %>' />
                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("NOTIFICACION_ID") %>' Visible="False" />
                                                | Categoria : <asp:Label ID="Label4" runat="server" Text='<%# Eval("SUBTIPO_DESCR") %>' CssClass="div_secundario_color" />
                                            </asp:LinkButton>
                                        </div>
                                        <div class="div_secundario_detalle">
                                            Remitente: <asp:Label ID="Label1" runat="server" Text='<%# Eval("REMITENTE") %>' CssClass="div_secundario_color" />
                                            | Fecha Emisión : <asp:Label ID="Label3" runat="server" Text='<%# Eval("FECHA") %>' CssClass="div_secundario_color" />
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("HORA") %>' CssClass="div_secundario_color" />
                                            | Para : <asp:Label ID="Label2" runat="server" Text='<%# Eval("PARA") %>' CssClass="div_secundario_color" Style="text-transform: lowercase;" />
                                        </div>
                                    </div>
                                    <div class="div_secundario_estado">
                                        <div class="div_secundario_estado_linea"></div>
                                        <div class="div_secundario_estado_linea">
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("ESTADO") %>' />
                                        </div>
                                        <div class="div_secundario_estado_linea"></div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div class="empty"> No Existen Datos para la Consulta </div>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <div class="sec_listview">
                                <div class="rlvFloated rlvAutoScroll">
                                    <div id="itemPlaceholder" runat="server"></div>
                                </div>
                                <%--<telerik:RadDataPager ID="RadDataPager1" runat="server" PageSize="6" Culture="es-ES"
                                    PagedControlID="RadListView1" Skin="Metro">
                                    <Fields>
                                        <telerik:RadDataPagerButtonField FieldType="Numeric" PageButtonCount="12"></telerik:RadDataPagerButtonField>
                                       <telerik:RadDataPagerButtonField FieldType="FirstPrev"></telerik:RadDataPagerButtonField>
                                        <telerik:RadDataPagerButtonField FieldType="Numeric" ></telerik:RadDataPagerButtonField>
                                        <telerik:RadDataPagerButtonField FieldType="NextLast"></telerik:RadDataPagerButtonField> 
                                    </Fields>
                                </telerik:RadDataPager>--%>
                                <asp:DataPager runat="server" ID="RadDataPager1" PagedControlID="RadListView1" PageSize="6" class="DataPager-group">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                            ShowNextPageButton="false" ShowLastPageButton="false" FirstPageText="«" PreviousPageText="<" ButtonCssClass="DataPager_next" />
                                        <asp:NumericPagerField ButtonCount="10" ButtonType="Link" CurrentPageLabelCssClass="DataPager_page"
                                            NumericButtonCssClass="DataPager_next" NextPreviousButtonCssClass="DataPager_next_button"/>
                                       <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                            ShowNextPageButton="true" ShowLastPageButton="true" NextPageText=">" LastPageText="»" ButtonCssClass="DataPager_next" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </LayoutTemplate>
                    </telerik:RadListView>
                </telerik:RadAjaxPanel>
                <telerik:RadEditor runat="server" ID="RadEditor1" Width="1000px" Height="480" BorderStyle="None" EmptyMessage="No existe información por el momento"
                    EnableResize="False" Language="es-ES" Skin="Metro" EditModes="Preview" EnableEmbeddedSkins="False">
                    <Tools>
                        <telerik:EditorToolGroup></telerik:EditorToolGroup>
                    </Tools>
                    <Content>    
                    </Content><TrackChangesSettings CanAcceptTrackChanges="False" />
                </telerik:RadEditor>
            </div>
        </div>
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="BtnbusquedaAvanzada">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BtnRegresar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtbusqueda" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnbusquedaAvanzada" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnRegresar" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="LinkVigentes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="caracter" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="LinkVencidos" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="LinkVigentes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl 
                        ControlID="rntMsgSistema" LoadingPanelID="RadAjaxLoadingPanel1" 
                        UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="LinkVencidos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl  ControlID="rntMsgSistema" LoadingPanelID="RadAjaxLoadingPanel1"  />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadListView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtbusqueda" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnbusquedaAvanzada" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnRegresar" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="LinkVigentes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="caracter" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="LinkVencidos" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadListView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="16px"
        Position="Center" Width="358px" ContentIcon="deny" EnableRoundedCorners="True"
        EnableShadow="True" Font-Bold="True" Font-Size="Medium" Opacity="95" TitleIcon="deny"
        ForeColor="Black" Overlay="True">
    </telerik:RadNotification>
</asp:Content>
