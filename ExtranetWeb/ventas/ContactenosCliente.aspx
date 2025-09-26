<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContactenosCliente.aspx.vb" Inherits="ExtranetWeb.ContactenosCliente" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Contactos Cliente</title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
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
                            Contáctenos
                        </h2>
                    </div>
                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                        <script type="text/javascript">
                            function openWinHelp() 
                            {
                                var oWnd = radopen("", "modalPopupHelp");
                                oWnd.set_modal(true);
                                if (!oWnd.get_modal()) document.documentElement.focus();
                            }
                        </script>
                        <script type="text/javascript" language="javascript">
                            function contadorTitulo(countfield, maxlimit) 
                            {
                                field = $get('<%=txtcontenido.clientID %>');
                                if (field.value.length > maxlimit)
                                    field.value = field.value.substring(0, maxlimit)
                                else
                                    countfield.value = maxlimit - field.value.length;
                            } 
                        </script>
                    </telerik:RadCodeBlock>
                    <div class="contactos_subprincipal">
                        <div class ="column_cell_label_espacio"></div>
                        <div class="column_cell_label">
                            Apellidos y Nombres&nbsp;
                        </div>
                        <div class="column_cell_text">
                            <telerik:RadTextBox ID="txt_regusu_identificacion" runat="server" Width="280px" TabIndex="1" Visible="True"
                                    AutoPostBack="True" MaxLength="200" placeholder="Ingrese Apellidos y Nombres">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="vld_txt_regusu_identificacion" runat="server" ErrorMessage="Nombres no puede quedar vacío"
                                ControlToValidate="txt_regusu_identificacion" ValidationGroup="grupo01" Display="Dynamic"
                                ToolTip="Nombres no puede quedar vacío" Text="Nombres no puede quedar vacío">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="column_cell_label_espacio"></div>
                        <div class="column_cell_label">
                            Factura&nbsp;
                        </div>
                        <div class="column_cell_text">
                            <telerik:RadTextBox ID="txt_regusu_factura" runat="server" Width="280px" TabIndex="1" Visible="True"
                                AutoPostBack="True" MaxLength="20" placeholder="Número Factura ES OPCIONAL">
                            </telerik:RadTextBox>
                            <%--    <asp:RequiredFieldValidator ID="vld_txt_regusu_factura" runat="server" ErrorMessage="Solo debe ingresar números"
                                ControlToValidate="txt_regusu_factura" ValidationGroup="grupo01" Display="Dynamic"
                                ToolTip="Solo debe ingresar números" Text="Solo debe ingresar números">
                            </asp:RequiredFieldValidator> --%>
                        </div>
                        <div class ="column_cell_label_espacio"></div>
                        <div class="column_cell_label">
                            Correo eletrónico&nbsp;
                        </div>
                        <div class="column_cell_text">
                            <telerik:RadTextBox ID="txt_regusu_email01" runat="server" Width="280px" TabIndex="2"
                                MaxLength="50" placeholder="Ingrese su e-mail">
                            </telerik:RadTextBox>
                            <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
                                ErrorMessage="Correo eletrónico incorrecto. Formato: tucorreo@tudominio" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                ControlToValidate="txt_regusu_email01" ValidationGroup="grupo01" Text="Correo eletrónico incorrecto. Formato: tucorreo@tudominio"
                                ToolTip="Correo eletrónico incorrecto. Formato: tucorreo@tudominio" />
                            <asp:RequiredFieldValidator ID="vld_txt_regusu_email01" runat="server" Display="Dynamic"
                                ControlToValidate="txt_regusu_email01" ErrorMessage="El correo eletrónico no puede quedar vacío"
                                ValidationGroup="grupo01" ToolTip="El correo eletrónico no puede quedar vacío"
                                Text="El correo eletrónico no puede quedar vacío" />
                        </div>
                        <div class ="column_cell_label_espacio"></div>
                        <div class="column_cell_label2">
                            Contenido del Mensaje
                        </div>
                        <%--  Style="text-transform: uppercase;"--%>
                        <div class="column_cell_text2">
                            <telerik:RadTextBox ID="txtcontenido" runat="server" Width="480px" MaxLength="1000" TextMode="MultiLine"  Height="120px">
                            </telerik:RadTextBox>
                            <asp:RequiredFieldValidator ID="vald_oblig_txtcontenido" runat="server" Display="Dynamic"
                                ErrorMessage="Campo obligatorio" ControlToValidate="txtcontenido" ValidationGroup="grupo01"> 
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="column_cell_label"></div>
                        <div class="column_cell_label3">
                            Caracteres Disponibles
                            <input readonly="readonly" disabled="disabled" type="text" name="lbl_caracteres"
                                size="5" value="1000" style="border-color: transparent; background-color: transparent" />
                        </div>
                        <div class="botenviar">
                            <telerik:RadButton ID="BtnEnviar" runat="server" Width="81px" Height="22px" Text="Enviar"
                                ValidationGroup="grupo01" HoveredCssClass="goButtonClassHov" ForeColor="White">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                </Image>
                            </telerik:RadButton>
                        </div>
                        <div class="botenviar"></div>
                        <div class="column_cell_text3"></div>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text3"></div>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text3"></div>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text3"></div>
                        <div class="column_cell_label4"></div>
                        <div class="column_cell_text5"></div>
                        <div class="column_cell_label5"></div>
                    </div>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="BtnEnviar">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="txt_regusu_identificacion" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_identificacion" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="txt_regusu_email01"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="emailValidator" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="txtcontenido" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="vald_oblig_txtcontenido" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="txt_regusu_factura" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <%--<telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_factura" LoadingPanelID="RadAjaxLoadingPanel1"/>--%>
                                    <telerik:AjaxUpdatedControl ControlID="BtnEnviar" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    <telerik:AjaxUpdatedControl ControlID="rntMensajes"  LoadingPanelID="RadAjaxLoadingPanel1"/>
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
