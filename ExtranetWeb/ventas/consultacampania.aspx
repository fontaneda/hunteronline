<%@ Page title="" Language="vb" AutoEventWireup="false"  CodeBehind="consultacampania.aspx.vb" Inherits="ExtranetWeb.consultacampania" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
           <title>Campañas</title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilovehiculochequeo.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilocampania.css" rel= "stylesheet" type="text/css" />
        <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilorenovacion.css" rel="stylesheet" type="text/css" />
        <script>
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
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="container_2">
                <div id="banner4">
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                </div>
                <div class="contactos_titulo">
                    <div class="contactos_principal">
                        <h2>
                            Campañas Registradas
                        </h2>
                    </div>
                    <%--<div class="conten_boton">--%>
                    <%--</div>--%>
                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                        <script type="text/javascript">
                            function openWinHelp() 
                            {
                                var oWnd = radopen("", "modalPopupHelp");
                                oWnd.set_modal(true);
                                if (!oWnd.get_modal()) document.documentElement.focus();
                            }
                        </script>
        <%--                <script type="text/javascript" language="javascript">
                            function contadorTitulo(countfield, maxlimit) {
                                field = $get('<%=txtcontenido.clientID %>');
                                if (field.value.length > maxlimit)
                                    field.value = field.value.substring(0, maxlimit)
                                else
                                    countfield.value = maxlimit - field.value.length;
                            } 
                        </script>
        --%>        </telerik:RadCodeBlock>
                    <div class="contactos_subprincipal">
                        <div class ="column_cell_label_espacio"></div>
                        <div class="column_cell_label">
                            Nombre&nbsp;
                        </div>
                        <div class="column_cell_text">
                            <Telerik:RadTextBox ID="txt_regusu_identificacion" runat="server" Width="280px" TabIndex="1" Visible="True" Enabled = "false"
                                    AutoPostBack="True" MaxLength="200" placeholder=" ">
                            </Telerik:RadTextBox>
                            <%--<asp:RequiredFieldValidator ID="vld_txt_regusu_identificacion" runat="server" ErrorMessage="Nombres no puede quedar vacío"
                                ControlToValidate="txt_regusu_identificacion" ValidationGroup="grupo01" Display="Dynamic"
                                ToolTip="Nombres no puede quedar vacío" Text="Nombres no puede quedar vacío">
                            </asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="column_cell_label_espacio"> </div>
                        <div class="column_cell_label">
                            Fecha Vigencia&nbsp;
                        </div>
                        <div class="column_cell_text">
                            <telerik:RadTextBox ID="txt_regusu_fecha" runat="server" Width="200px" TabIndex="1" Visible="True" Enabled = "false"
                                AutoPostBack="True" MaxLength="15" placeholder=" " style="text-align:left">
                            </telerik:RadTextBox>
                            <%--    <asp:RequiredFieldValidator ID="vld_txt_regusu_fecha" runat="server" ErrorMessage="Solo debe ingresar números"
                                ControlToValidate="txt_regusu_fecha" ValidationGroup="grupo01" Display="Dynamic"
                                ToolTip="Solo debe ingresar números" Text="Solo debe ingresar números">
                            </asp:RequiredFieldValidator> --%>
                            <telerik:RadTextBox ID="Txt_regusu_fecha_f" runat="server" Width="200px" TabIndex="1" Visible="True" Enabled = "false"
                                AutoPostBack="True" MaxLength="15" placeholder=" " style="float:right">
                            </telerik:RadTextBox>
                            <telerik:RadDatePicker ID="rdpdtp_fecha_Ini" runat="server" ToolTip="Ingrese fecha" Visible="false" 
                                Width="110px" Height="18px" AutoPostBack="True">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server">
                                </Calendar>
                                <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" runat="server"
                                    LabelWidth="40%" type="text" value="" Height="18px" AutoPostBack="True">
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            <telerik:RadDatePicker ID="rdpdtp_fecha_fin" runat="server" ToolTip="Ingrese fecha" Visible="false" 
                                Width="110px" Height="18px" AutoPostBack="True">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server">
                                </Calendar>
                                <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" runat="server"
                                    LabelWidth="40%" type="text" value="" Height="18px" AutoPostBack="True">
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </div>
                        <div class ="column_cell_label_espacio"></div>
                        <div class="column_cell_label">
                            Ruta imagen &nbsp;
                        </div>
                        <div class="column_cell_text">
                            <telerik:RadTextBox ID="txt_regusu_ruta" runat="server" Width="600px" TabIndex="2" Enabled = "false"
                                MaxLength="100" placeholder=" ">
                            </telerik:RadTextBox>
                            <%--   <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
                                ErrorMessage="Correo eletrónico incorrecto. Formato: tucorreo@tudominio" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                ControlToValidate="txt_regusu_email01" ValidationGroup="grupo01" Text="Correo eletrónico incorrecto. Formato: tucorreo@tudominio"
                                ToolTip="Correo eletrónico incorrecto. Formato: tucorreo@tudominio" />--%>
                            <%--<asp:RequiredFieldValidator ID="vld_txt_regusu_email01" runat="server" Display="Dynamic"
                                ControlToValidate="txt_regusu_email01" ErrorMessage="El correo eletrónico no puede quedar vacío"
                                ValidationGroup="grupo01" ToolTip="El correo eletrónico no puede quedar vacío"
                                Text="El correo eletrónico no puede quedar vacío" />--%>
                            <telerik:RadUpload ID="RadUpDocumento" runat="server" ControlObjectsVisibility="ClearButtons" Visible = "false"
                                Culture="es-ES" Height="25px" InputSize="52" MaxFileInputsCount="1" OnClientFileSelected="checkExtension"
                                OverwriteExistingFiles="True" ReadOnlyFileInputs="True" Width="500px">
                                <Localization Clear="Limpiar" Select="Buscar" />
                            </telerik:RadUpload>
                        </div>
                        <div class ="column_cell_label_espacio"></div>
                        <div class="column_cell_label2">
                            I m a g e n
                        </div>
                        <%--  Style="text-transform: uppercase;"--%>
                        <div class="column_cell_text2">
        <%--                <telerik:RadTextBox ID="txtcontenido" runat="server" Width="480px" MaxLength="1000"
                                    TextMode="MultiLine"  Height="120px">
                            </telerik:RadTextBox>  --%>
                            <div style="position: absolute;">
                                    <img id="img_promo" runat="server" src=" " alt="" />
                            </div>
        <%--                <asp:RequiredFieldValidator ID="vald_oblig_txtcontenido" runat="server" Display="Dynamic"
                                ErrorMessage="Campo obligatorio" ControlToValidate="txtcontenido" ValidationGroup="grupo01"> 
                            </asp:RequiredFieldValidator> 
                            src="../images/background_nuevo/promo_rumbo_rusia_p.png"--%>
                        </div>
                        <div class="column_cell_label"></div>
                        <div class="column_cell_label3">
        <%--                    <input readonly="readonly" disabled="disabled" type="text" name="lbl_caracteres"
                                size="5" value="1000" style="border-color: transparent; background-color: transparent" />
        --%>            </div>
                        <div class="botenviar">
                            <telerik:RadButton ID="Btn_enviar" runat="server" Width="81px" Height="22px" Text="Enviar"  Visible ="false" Enabled = "false" 
                                ValidationGroup="grupo01" HoveredCssClass="goButtonClassHov" ForeColor="White">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />
                            </telerik:RadButton>
                        </div>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text3"></div>
                        <div class="grid_datos">
                            <telerik:RadGrid ID="RgdProductos" runat="server" AllowCustomPaging="False" AllowPaging="False" Height="90px" PageSize="2" VirtualItemCount="2" ShowStatusBar="True" Width="980px"
                                    Skin="MyCustomSkin" EnableEmbeddedSkins="false" CellSpacing="0" Culture="es-ES" GridLines="None" OnSelectedIndexChanged="rgdproductos_SelectedIndexChanged">
                            <%-- <ClientSettings>
                                    <Scrolling EnableVirtualScrollPaging="True" />
                                 </ClientSettings>--%>
                                <ClientSettings EnableRowHoverStyle="true">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <GroupingSettings CaseSensitive="false" />
                                <SortingSettings SortedBackColor="BurlyWood" />
                                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="CODIGO" PageSize="5"
                                    NoDetailRecordsText="" NoMasterRecordsText="">
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CODIGO" FilterControlAltText="Filter CODIGO column"
                                            HeaderText="Código" UniqueName="CODIGO" Visible = "true">
                                            <FooterStyle Width="0px" />
                                            <HeaderStyle Width="0px" />
                                            <ItemStyle Width="0px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NOMBRE_CAMPANIA " FilterControlAltText="Filter NOMBRE_CAMPANIA column"
                                            HeaderText="Campaña" UniqueName="NOMBRE_CAMPANIA">
                                            <FooterStyle Width="160px" />
                                            <HeaderStyle Width="160px" />
                                            <ItemStyle Width="160px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FECHA_INICIAL" FilterControlAltText="Filter FECHA_INICIAL column"
                                            HeaderText="Fec.Inicio" UniqueName="FECHA_INICIAL" DataFormatString="{0:dd/MMM/yyyy}">
                                            <FooterStyle Width="60px" />
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FECHA_FINAL" FilterControlAltText="Filter FECHA_FINAL column"
                                            HeaderText="Fec.Final" UniqueName="FECHA_FINAL" DataFormatString="{0:dd/MMM/yyyy}">
                                            <FooterStyle Width="60px" />
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RUTA_IMAGEN" FilterControlAltText="Filter RUTA_IMAGEN column"
                                            HeaderText="Ruta imagen" UniqueName="RUTA_IMAGEN">
                                            <FooterStyle Width="400px" />
                                            <HeaderStyle Width="400px" />
                                            <ItemStyle Width="400px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ESTADO" FilterControlAltText="Filter ESTADO column"
                                            HeaderText="Estado" UniqueName="ESTADO">
                                            <FooterStyle Width="50px" />
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </telerik:GridBoundColumn>
                                        <%--<telerik:GridBoundColumn DataField="BOT" FilterControlAltText = "Filter BOT column"
                                            HeaderText="Editar" UniqueName="BOT" > 
                                            <asp:LinkButton ID="LinkButton4" CssClass="selectedButtons" CommandArgument='<%# Bind("CODIGO") %>'
                                                    runat="server" CommandName="Editar">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="../images/icons/12x12/edit12x12.png"
                                                        ToolTip="Permite editar datos" />
                                            </asp:LinkButton>
                                            </telerik:GridBoundColumn>--%>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkI" runat="server" AutoPostBack="true" OnCheckedChanged="chkI_CheckedChanged"/>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkH" runat="server" AutoPostBack="true" OnCheckedChanged="chkH_CheckedChanged" />
                                            </HeaderTemplate>
                                            <FooterStyle CssClass="estilogridcontrol" Width="35px" />
                                            <HeaderStyle CssClass="estilogridcontrol" Width="35px" />
                                            <ItemStyle   CssClass="estilogridcontrol" Width="35px" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="FEC_I" FilterControlAltText="Filter FEC_I column" Visible="false"
                                            HeaderText="Fec.I" UniqueName="FEC_I" DataFormatString="{0:dd/MMM/yyyy}">
                                            <FooterStyle Width="60px" />
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle Width="60px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FEC_F" FilterControlAltText="Filter FEC_F column" Visible="false"
                                            HeaderText="Fec.F" UniqueName="FEC_F" DataFormatString="{0:dd/MMM/yyyy}">
                                            <FooterStyle Width="60px" />
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle Width="60px" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <PagerStyle PageSizeControlType="RadComboBox" Mode="NumericPages" ShowPagerText="False">
                                    </PagerStyle>
                                </MasterTableView>
                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </div>
                        <%--<div class="botenviar">
                        </div>
                        <div class="column_cell_text3">
                        </div>
                        <div class="column_cell_label4">
                        </div>
                        <div class="column_cell_text3">
                        </div>--%>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text3">
                            <telerik:RadButton ID="BtnNuevo" runat="server" Width="81px" Height="22px" Text="Nuevo" HoveredCssClass="goButtonClassHov" ForeColor="White">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                       PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />
                            </telerik:RadButton>
                            <%--<div class="content_boton_campania">
                            BackgroudTitulo
                            </div>--%>
                            <telerik:RadButton ID="BtnGraba" runat="server" Width="81px" Height="22px" Visible ="false" Text="Graba" HoveredCssClass="goButtonClassHov" ForeColor="White" Enabled="true" >
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                       PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />
                            </telerik:RadButton>
                        </div>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text5"></div>
                        <div class="column_cell_label5"></div>
                    </div>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="Btn_enviar">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="txt_regusu_identificacion" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <%--<telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_identificacion" LoadingPanelID="RadAjaxLoadingPanel1"/>--%>
                                    <telerik:AjaxUpdatedControl ControlID="txt_regusu_ruta"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="emailValidator" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="txtcontenido" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="vald_oblig_txtcontenido" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="txt_regusu_fecha" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="Btn_enviar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="rntMensajes"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="RadUpDocumento" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
                    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                        EnableRoundedCorners="True" Overlay="True" ContentIcon="">
                    </telerik:RadNotification>
                </div>
            </div>
        </form>
    </body>
</html>
