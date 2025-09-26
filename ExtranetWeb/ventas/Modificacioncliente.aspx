<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="Modificacioncliente.aspx.vb" Inherits="ExtranetWeb.Modificacioncliente" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilomodificacion.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function showConfirmRadWindow(sender, args) {
            $find("<%=confirmWindow.ClientID %>").show();
            $find("<%=RadButtonYes.ClientID %>").focus();
            args.set_cancel(true);
        }
        function confirmResult(sender, args) {
            var oWnd = $find("<%=confirmWindow.ClientID %>");
            oWnd.close();
            if (sender.get_text() == "Si") {
                $find("<%=BtnCancelarTab1.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <section class="info-body">
        <div class="transacciones"> 
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
                    <div class="content_crit_info_detalleitems">
                        <div class="content_titulopage">
                            <h2>
                                <asp:Label ID="lblcliente" runat="server" Visible="false" />
                            </h2>
                        </div>
                        <div class="content_tab_modificacion_master">
                            <telerik:RadTabStrip ID="Radtabdatosconsulta" runat="server" AutoPostBack="True"
                                Width="800px" SelectedIndex="4" MultiPageID="RadMultiPage1" Skin="" 
                                CssClass="tab_general">
                                <Tabs>
                                    <telerik:RadTab Text="Datos Personales" ImageUrl="../images/background/icono_identificacion.png"
                                        Font-Size="12px" Height="32px" PageViewID="RadPageView1"
                                        CssClass="tab_individual" Selected="True">
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Teléfono - Dirección" ImageUrl="../images/background/icono_celular.png"
                                        Font-Size="12px" Height="32px" PageViewID="RadPageView2" 
                                        CssClass="tab_individual" >
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Email - Redes Sociales" ImageUrl="../images/background/icono_email.png"
                                        Font-Size="12px" Height="32px" PageViewID="RadPageView3" 
                                        CssClass="tab_individual" >
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Datos Vehículo" ImageUrl="../images/background/icono_vehiculo.png"
                                        Font-Size="12px" Height="32px" PageViewID="RadPageView4" 
                                        CssClass="tab_individual">
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Comentarios" ImageUrl="../images/background/Boton_Datos_Generales.png"
                                        Font-Size="12px" Height="32px" PageViewID="RadPageView5" 
                                        CssClass="tab_individual" >
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="4">
                                <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True">
                                    <div class="content_tab_datos02">
                                        <div class="column06_cell_label"> Cedula/Ruc</div>
                                        <div class="column06_cell_label">
                                            <telerik:RadTextBox ID="txtcodigo" runat="server" Width="120px" MaxLength="13" TabIndex="1"
                                                    Skin="Default" BackColor="Transparent" onKeyDown="submitButton(event)" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_boton02">
                                            <telerik:RadButton ID="BtnBuscar" runat="server" Width="80px" Height="22px"
                                                Text="Buscar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="2"  OnClick="BtnBuscar_Click" >
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                            <telerik:RadButton ID="BtnCancelarTab1" runat="server" Width="80px" Height="22px"
                                                Text="Cancelar" HoveredCssClass="goButtonClassHov" ForeColor="White"  Visible="false" OnClientClicking="showConfirmRadWindow"
                                                    OnClick="BtnCancelarTab1_Click">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="column01_cell_boton02">
                                            <telerik:RadButton ID="BtnGrabarTab1" runat="server" Width="80px" Height="22px"
                                                Text="Grabar" HoveredCssClass="goButtonClassHov" ForeColor="White" ValidationGroup="grupo01">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="column06_cell_label">
                                            <asp:Label ID="lblusuario" runat="server" Visible="False" ></asp:Label>
                                        </div>
                                        <div class="column06_cell_label"> Nombres </div>
                                        <div class="column01_cell_text01">
                                            <%--<asp:Label ID="lbl_nombres" runat="server"></asp:Label>--%>
                                            <telerik:RadTextBox ID="lbl_nombres" runat="server" ReadOnly="True" Width="400px" Enabled="False" BackColor="Transparent" EmptyMessage="Nombres">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column06_cell_label">Apellido</div>
                                        <div class="column01_cell_text01">
                                            <telerik:RadTextBox ID="lbl_apellidos" runat="server" ReadOnly="True" 
                                                    Width="400px" Enabled="False" BackColor="Transparent" EmptyMessage="Apellidos">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column06_cell_label">Fecha Nacimiento</div>
                                        <div class="column01_cell_text" style="margin-right:200px;">
                                            <telerik:RadDatePicker ID="rdpdtp_fechanacimiento" runat="server" ToolTip="Ingrese la fecha de nacimiento"
                                                Width="110px" Height="20px" AutoPostBack="True" TabIndex="3">
                                                <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server" >
                                                </Calendar>
                                                <DateInput ID="DateInput1" DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" runat="server" 
                                                    LabelWidth="40%" type="text" value="" Height="18px" AutoPostBack="True">
                                                </DateInput>
                                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </div>
                                        <div class="column06_cell_label"> Auditoria </div>
                                        <div class="column01_cell_text01">
                                            <telerik:RadTextBox ID="txt_auditoria" runat="server" ReadOnly="True" 
                                                    Width="400px" Enabled="False" BackColor="Transparent" EmptyMessage="Auditoria">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column06_cell_label"></div>
                                        <div class="column01_cell_text"></div>
                                        <div class="column01_cell_text"></div>
                                        <div class="column01_cell_text"></div>
                                        <div class="column01_cell_text"></div>
                                    </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView2" runat="server">
                                    <div class="content_tab_datos02">
                                        <div class="column02_cell_text"></div>
                                        <div class="column01_cell_boton01">
                                            <telerik:RadButton ID="BtnGrabarTab2" runat="server" Width="81px" Height="22px"
                                                Text="Grabar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="10" ValidationGroup="grupo03">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="separador_0020" >
                                            <div class="separador_002" ></div>
                                            <div class="column03_cell_label"> Teléfonos </div>
                                            <div class="separador_001" ></div>
                                        </div>
                                        <div class="column01_cell_label"> Fijo</div>
                                        <div class="column01_cell_label">
                                            <telerik:RadTextBox ID="lblconvencional" runat="server" ReadOnly="True" Width="120px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column03_cell_text" style="width:250px;">
                                            <telerik:RadTextBox ID="txt_convencional" RenderMode="Lightweight" runat="server" Width="240px"   
                                                MaxLength="9" BackColor="Transparent"  TabIndex="4">
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_validator">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_convencional" runat="server" ErrorMessage="Debe empezar con el codigo de área, seguido del número telefonico"
                                                ControlToValidate="txt_convencional" ValidationGroup="grupo03" ValidationExpression="^0[0-9]{8}$"
                                                Display="Dynamic"  ToolTip="Debe empezar con el codigo de área, seguido del número telefonico">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="column01_cell_label"> Fijo (Adicional) </div>
                                        <div class="column01_cell_label">
                                            <telerik:RadTextBox ID="lbltelefonoextra" runat="server" ReadOnly="True" Width="120px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column03_cell_text">
                                           <telerik:RadTextBox ID="txt_convencionalextra" RenderMode="Lightweight" runat="server" 
                                                Width="240px"   MaxLength="9" BackColor="Transparent"  TabIndex="5">
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_validator">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_convencionalextra" runat="server" ErrorMessage="Debe empezar con el codigo de área, seguido del número telefonico"
                                                ControlToValidate="txt_convencionalextra" ValidationGroup="grupo03" ValidationExpression="^0[0-9]{8}$"
                                                Display="Dynamic"  ToolTip="Debe empezar con el codigo de área, seguido del número telefonico">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="column01_cell_label"> Celular </div>
                                        <div class="column01_cell_label">
                                            <telerik:RadTextBox ID="lblcelular" runat="server" ReadOnly="True" Width="120px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column03_cell_text">
                                           <telerik:RadTextBox ID="txt_celular" RenderMode="Lightweight" runat="server" Width="240px"   
                                                MaxLength="10" BackColor="Transparent"  TabIndex="6">
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_validator">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_celular" runat="server" ErrorMessage="El celular debe empezar con 09 y tener 10 números"
                                                ControlToValidate="txt_celular" ValidationGroup="grupo03" ValidationExpression="^0[0-9]{9}$"
                                                Display="Dynamic"  ToolTip="Debe empezar con 09 y tener 10 números">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="column01_cell_label"> Celular (Adicional) </div>
                                        <div class="column01_cell_label">
                                            <telerik:RadTextBox ID="lblcelularextra" runat="server" ReadOnly="True" Width="120px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column03_cell_text">
                                           <telerik:RadTextBox ID="txt_celularextra" RenderMode="Lightweight" runat="server" 
                                                Width="240px"   MaxLength="10" BackColor="Transparent"  TabIndex="7">
                                                <ClientEvents OnKeyPress="keyPress" />
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_validator">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_celularrextra" runat="server" ErrorMessage="El celular debe empezar con 09 y tener 10 números"
                                                ControlToValidate="txt_celularextra" ValidationGroup="grupo03" ValidationExpression="^0[0-9]{9}$"
                                                Display="Dynamic"  ToolTip="Debe empezar con 09 y tener 10 números">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="separador_0020" >
                                            <div class="separador_002" ></div>
                                            <div class="column03_cell_label"> Dirección </div>
                                            <div class="separador_001" ></div>
                                        </div>
                                        <div class="column01_cell_label"> Domicilio </div>
                                        <div class="column05_cell_label">
                                            <telerik:RadTextBox ID="lbldomicilio" runat="server" ReadOnly="True" Width="520px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_label"> </div>
                                        <div class="column05_cell_label">
                                            <telerik:RadTextBox ID="txt_direcdomicilio" runat="server" Width="520px" 
                                                MaxLength="150" BackColor="Transparent"  TabIndex="8" style="text-transform: uppercase;" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_label"> Oficina </div>
                                        <div class="column05_cell_label">
                                            <telerik:RadTextBox ID="lbloficina" runat="server" ReadOnly="True" Width="520px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_label">  </div>
                                        <div class="column05_cell_label">
                                            <telerik:RadTextBox ID="txt_direcoficina" runat="server" Width="520px" 
                                                MaxLength="150" BackColor="Transparent"  TabIndex="9" style="text-transform: uppercase;" >
                                            </telerik:RadTextBox>
                                        </div>
                                    </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView3" runat="server">
                                    <div class="content_tab_datos02">
                                        <div class="column02_cell_text"></div>
                                        <div class="column01_cell_boton01">
                                            <telerik:RadButton ID="BtnGrabarTab3" runat="server" Width="81px" Height="22px"
                                                Text="Grabar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="18" ValidationGroup="grupo02">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="separador_0020" >
                                            <div class="separador_002" ></div>
                                            <div class="column04_cell_label"> Correo Electronico </div>
                                            <div class="separador_003" ></div>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Principal </div>
                                        <div class="column02_cell_label" >
                                            <telerik:RadTextBox ID="lblemail" runat="server" ReadOnly="True" Width="260px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_email" runat="server" 
                                                Width="250px" BackColor="Transparent" TabIndex="11">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column02_cell_validator" style="margin:8px 200px 0px 5px">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_email" runat="server" ErrorMessage="Email Principal ingresado incorrectamente"
                                                ControlToValidate="txt_email" ValidationGroup="grupo02" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                                Display="Dynamic" ToolTip="Formato: tucorreo@tudominio">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Oficina </div>
                                        <div class="column02_cell_label">
                                            <telerik:RadTextBox ID="lblemailoficina" runat="server" ReadOnly="True" 
                                                Width="260px" Enabled="False" BackColor="Transparent" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_emailoficina" runat="server" 
                                                Width="250px" BackColor="Transparent" TabIndex="12">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column02_cell_validator">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_emailoficina" runat="server" ErrorMessage="Email de Oficina ingresado incorrectamente"
                                                ControlToValidate="txt_emailoficina" ValidationGroup="grupo02" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                                Display="Dynamic" ToolTip="Formato: tucorreo@tudominio">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Factura Electronica </div>
                                        <div class="column02_cell_label">
                                            <telerik:RadTextBox ID="lblemailfactura" runat="server" ReadOnly="True" Width="260px" Enabled="False" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_emailfactura" runat="server" 
                                                Width="250px" BackColor="Transparent"  TabIndex="13">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column02_cell_validator">
                                            <asp:RegularExpressionValidator ID="vald_expr_txt_emailfactura" runat="server" ErrorMessage="Email de Factura Electronica ingresado incorrectamente"
                                                ControlToValidate="txt_emailfactura" ValidationGroup="grupo02" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                                Display="Dynamic" ToolTip="Formato: tucorreo@tudominio">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="separador_0020" >
                                            <div class="separador_002" ></div>
                                            <div class="column04_cell_label"> Redes Sociales </div>
                                            <div class="separador_003" ></div>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Facebook </div>
                                        <div class="column02_cell_label">
                                            <asp:Image ID="Image3" runat="server"  ImageUrl="../images/icons/16x16/facebook.png" CssClass="column01_cell_icon" />
                                            <asp:CheckBox  runat="server" Width="20px" ID="Chkfacebook" AutoPostBack="true" TabIndex="14"/>
                                            <telerik:RadTextBox ID="lblfacebook" runat="server" ReadOnly="True" 
                                                Width="220px" Enabled="False" BackColor="Transparent" Visible="False">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_facebook" runat="server" Width="250px" BackColor="Transparent" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Twiter </div>
                                        <div class="column02_cell_label">
                                            <asp:Image ID="Image1" runat="server"  ImageUrl="../images/icons/16x16/twiter.png" CssClass="column01_cell_icon" />
                                            <asp:CheckBox  runat="server" Width="20px" ID="Chktwiter" AutoPostBack="true" TabIndex="15"/>
                                            <telerik:RadTextBox ID="lbltwiter" runat="server" ReadOnly="True" 
                                                Width="220px" Enabled="False" BackColor="Transparent" Visible="False">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_twiter" runat="server" Width="250px" BackColor="Transparent" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Instagram </div>
                                        <div class="column02_cell_label">
                                            <asp:Image ID="Image2" runat="server"  ImageUrl="../images/icons/16x16/instagram.png" CssClass="column01_cell_icon" />
                                            <asp:CheckBox  runat="server" Width="20px" ID="Chkinstagram" AutoPostBack="true" TabIndex="16"/>
                                            <telerik:RadTextBox ID="lblinstagram" runat="server" 
                                                ReadOnly="True" Width="220px" Enabled="False" BackColor="Transparent" Visible="False">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_instagram" runat="server" Width="250px" BackColor="Transparent" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px"> Snapchat </div>
                                        <div class="column02_cell_label">
                                            <asp:Image ID="Image4" runat="server"  ImageUrl="../images/icons/16x16/snapchat.png" CssClass="column01_cell_icon" />
                                            <asp:CheckBox  runat="server" Width="20px" ID="Chksnapchat" AutoPostBack="true" TabIndex="17"/>
                                            <telerik:RadTextBox ID="lblsnapchat" runat="server" 
                                                ReadOnly="True" Width="220px" Enabled="False" BackColor="Transparent" Visible="False">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text">
                                            <telerik:RadTextBox ID="txt_snapchat" runat="server" Width="250px" BackColor="Transparent" >
                                            </telerik:RadTextBox>
                                        </div>
                                    </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView4" runat="server">
                                    <div class="content_tab_datos01">
                                        <div class="column01_cell_label"> Placa </div>
                                        <div class="column07_cell_label">
                                            <telerik:RadTextBox ID="lblplaca" runat="server" ReadOnly="True" Enabled="False" EmptyMessage="Placa" BackColor="Transparent">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column07_cell_label" style="margin-right:100px;">
                                            <telerik:RadTextBox ID="txt_placa" runat="server" MaxLength="8" 
                                                Style="text-transform: uppercase;" EmptyMessage="Placa" TabIndex="19" >
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_boton01" style="margin:5px;">
                                            <telerik:RadButton ID="BtnAplicarTab4" runat="server" Width="81px" Height="22px"
                                                Text="Aplicar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="24" ValidationGroup="grupo04">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="column01_cell_boton01" style="margin:5px;">
                                            <telerik:RadButton ID="BtnCancelarTab4" runat="server" Width="81px" Height="22px"
                                                Text="Cancelar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="25">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="column01_cell_boton01" style="margin:5px 200px 5px 5px;">
                                            <telerik:RadButton ID="BtnGrabarTab4" runat="server" Width="81px" Height="22px" 
                                                Text="Grabar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="26">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="column03_cell_validator" style="margin:5px 200px 5px 5px;">
                                        </div>
                                        <div class="column01_cell_label"> Nombre Completo </div>
                                        <div class="column01_cell_text02">
                                            <%--<asp:Label ID="lblnombrecompleto" runat="server" />--%>
                                            <telerik:RadTextBox ID="lblnombrecompleto" runat="server" ReadOnly="True" 
                                                    Width="400px" Enabled="False" BackColor="Transparent" EmptyMessage="Nombre Completo">
                                            </telerik:RadTextBox>
                                            <asp:Label ID="lblcodigo" runat="server" Visible="False"/>
                                            <asp:Label ID="lblmotor" runat="server" Visible="False"/>
                                            <asp:Label ID="lblchasis" runat="server" Visible="False"/>
                                            <asp:Label ID="lblproducto" runat="server" Visible="False" />
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px;"> Aseguradora </div>
                                        <div class="column01_cell_text03">
                                            <telerik:RadTextBox ID="lblaseguradora" runat="server" ReadOnly="True" 
                                                    Width="300px" Enabled="False" BackColor="Transparent" EmptyMessage="Aseguradora">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text03"> 
                                            <telerik:RadComboBox ID="Rcbaseguradora" runat="server" EnableVirtualScrolling="true"  
                                                    AutoPostBack="True" Culture="es-ES" Height="160px" Width="300px" EmptyMessage="Aseguradora" TabIndex="20">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px;"> Concesionario </div>
                                        <div class="column01_cell_text03">
                                            <telerik:RadTextBox ID="lblconcesionaria" runat="server" ReadOnly="True" 
                                                    Width="300px" Enabled="False" BackColor="Transparent" EmptyMessage="Concesionaria">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text03"> 
                                            <telerik:RadComboBox ID="Rcbconcesionario" runat="server" EnableVirtualScrolling="true"  
                                                    AutoPostBack="True" Culture="es-ES" Height="160px" Width="300px" EmptyMessage="Concesionario" TabIndex="21">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px;"> Financiera </div>
                                        <div class="column01_cell_text03">
                                            <telerik:RadTextBox ID="lblfinanciera" runat="server" ReadOnly="True" 
                                                    Width="300px" Enabled="False" BackColor="Transparent" EmptyMessage="Financiera">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text03"> 
                                            <telerik:RadComboBox ID="Rcbfinanciera" runat="server" EnableVirtualScrolling="true"  
                                                    AutoPostBack="True" Culture="es-ES" Height="160px" Width="300px" EmptyMessage="Financiera" TabIndex="22">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div class="column01_cell_label" style="margin-right:300px;"> Broker </div>
                                        <div class="column01_cell_text03">
                                            <telerik:RadTextBox ID="lblbroker" runat="server" ReadOnly="True" 
                                                    Width="300px" Enabled="False" BackColor="Transparent" EmptyMessage="Broker">
                                            </telerik:RadTextBox>
                                        </div>
                                        <div class="column01_cell_text03"> 
                                            <telerik:RadComboBox ID="Rcbbroker" runat="server" EnableVirtualScrolling="true"  
                                                    AutoPostBack="True" Culture="es-ES" Height="160px" Width="300px" EmptyMessage="Broker" TabIndex="23">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div class="column02_cell_validator"></div>
                                        <div class="grid_datos_vehiculo">
                                            <telerik:RadGrid ID="RgdVehiculo" runat="server" AllowCustomPaging="True" 
                                                Height="185px"  ShowStatusBar="True" Width="750px" GridLines="None" CellSpacing="0"
                                                 Culture="es-ES" OnSelectedIndexChanged="RgdVehiculo_SelectedIndexChanged">
                                                <GroupingSettings CaseSensitive="false" />
                                                <SortingSettings SortedBackColor="BurlyWood" />
                                                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                                </ClientSettings>
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="CODIGO" NoDetailRecordsText="" NoMasterRecordsText="">
                                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="CODIGO" FilterControlAltText="Filter CODIGO column"
                                                            HeaderText="Código" UniqueName="CODIGO" >
                                                            <FooterStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <ItemStyle Width="100px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PLACA" FilterControlAltText="Filter PLACA column"
                                                            HeaderText="Placa" UniqueName="PLACA" >
                                                            <FooterStyle Width="100px" />
                                                            <HeaderStyle Width="100px" />
                                                            <ItemStyle Width="100px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NOMBRE_COMPLETO" FilterControlAltText="Filter NOMBRE_COMPLETO column"
                                                            HeaderText="Nombre Completo" UniqueName="NOMBRE_COMPLETO">
                                                            <FooterStyle Width="360px" />
                                                            <HeaderStyle Width="360px" />
                                                            <ItemStyle Width="360px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="MOTOR" FilterControlAltText="Filter MOTOR column"
                                                            HeaderText="Motor" UniqueName="MOTOR" >
                                                            <FooterStyle Width="160px" />
                                                            <HeaderStyle Width="160px" />
                                                            <ItemStyle Width="160px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CHASIS" FilterControlAltText="Filter CHASIS column"
                                                            HeaderText="Chasis" UniqueName="CHASIS">
                                                            <FooterStyle Width="160px" />
                                                            <HeaderStyle Width="160px" />
                                                            <ItemStyle Width="160px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PRODUCTOS" FilterControlAltText="Filter PRODUCTOS column"
                                                            HeaderText="Productos" UniqueName="PRODUCTOS">
                                                            <FooterStyle Width="300px" />
                                                            <HeaderStyle Width="300px" />
                                                            <ItemStyle Width="300px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CIA_SEGUROS" FilterControlAltText="Filter CIA_SEGUROS column"
                                                            HeaderText="Aseguradora01" UniqueName="CIA_SEGUROS">
                                                            <FooterStyle Width="0px" />
                                                            <HeaderStyle Width="0px" />
                                                            <ItemStyle Width="0px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASEGURADORA" FilterControlAltText="Filter ASEGURADORA column"
                                                            HeaderText="Aseguradora" UniqueName="ASEGURADORA">
                                                            <FooterStyle Width="260px" />
                                                            <HeaderStyle Width="260px" />
                                                            <ItemStyle Width="260px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CODIGO_CONCESIONARIO" FilterControlAltText="Filter CODIGO_CONCESIONARIO column"
                                                            HeaderText="Concesionario01" UniqueName="CODIGO_CONCESIONARIO">
                                                            <FooterStyle Width="0px" />
                                                            <HeaderStyle Width="0px" />
                                                            <ItemStyle Width="0px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CONCESIONARIO" FilterControlAltText="Filter CONCESIONARIO column"
                                                            HeaderText="Concesionario" UniqueName="CONCESIONARIO">
                                                            <FooterStyle Width="260px" />
                                                            <HeaderStyle Width="260px" />
                                                            <ItemStyle Width="260px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CODIGO_FINANCIADOR" FilterControlAltText="Filter CODIGO_FINANCIADOR column"
                                                            HeaderText="Financiera01" UniqueName="CODIGO_FINANCIADOR">
                                                            <FooterStyle Width="0px" />
                                                            <HeaderStyle Width="0px" />
                                                            <ItemStyle Width="0px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FINANCIERA" FilterControlAltText="Filter FINANCIERA column"
                                                            HeaderText="Financiera" UniqueName="FINANCIERA">
                                                            <FooterStyle Width="260px" />
                                                            <HeaderStyle Width="260px" />
                                                            <ItemStyle Width="260px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CODIGO_BROKE" FilterControlAltText="Filter CODIGO_BROKE column"
                                                            HeaderText="Broker01" UniqueName="CODIGO_BROKE">
                                                            <FooterStyle Width="0px" />
                                                            <HeaderStyle Width="0px" />
                                                            <ItemStyle Width="0px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BROKE" FilterControlAltText="Filter BROKE column"
                                                            HeaderText="Broker" UniqueName="BROKE">
                                                            <FooterStyle Width="260px" />
                                                            <HeaderStyle Width="260px" />
                                                            <ItemStyle Width="260px" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="GRABA" FilterControlAltText="Filter GRABA column"
                                                            HeaderText="Graba" UniqueName="GRABA">
                                                            <FooterStyle Width="0px" />
                                                            <HeaderStyle Width="0px" />
                                                            <ItemStyle Width="0px" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>
                                                    <PagerStyle PageSizeControlType="RadComboBox" Mode="NumericPages" ShowPagerText="False"></PagerStyle>
                                                </MasterTableView>
                                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                        </div>
                                    </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView5" runat="server">
                                    <div class="content_tab_datos02">
                                        <div class="column02_cell_text"></div>
                                        <div class="column01_cell_boton01">
                                            <telerik:RadButton ID="BtnGrabarTab5" runat="server" Width="81px" Height="22px"
                                                Text="Grabar" HoveredCssClass="goButtonClassHov" ForeColor="White" TabIndex="29">
                                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                                    PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                                </Image>
                                            </telerik:RadButton>
                                        </div>
                                        <div class="column03_multi_line">
                                            Consulta: ¿Qué servicios adicionales quisiera que le brindara su dispositivo?
                                        </div>
                                        <div class="column01_multi_line">
                                            <telerik:RadTextBox ID="txt_consulta" RenderMode="Lightweight"  Width="430px" runat="server" TextMode="MultiLine"  
                                                Rows="3" AutoPostBack="True"  Enabled="false" MaxLength="200"  style="text-transform: uppercase;" TabIndex="27" />
                                        </div>
                                        <div class="column04_multi_line"></div>
                                        <div class="column03_multi_line">
                                            Comentario
                                        </div>
                                        <div class="column01_multi_line">
                                            <telerik:RadTextBox ID="txt_comentario" RenderMode="Lightweight"  Width="430px" runat="server" TextMode="MultiLine"  
                                                Rows="3" AutoPostBack="True" Enabled="false" MaxLength="200"  style="text-transform: uppercase;" TabIndex="28"/>
                                        </div>
                                        <div class="column04_multi_line"></div>
                                        <div class="column03_multi_line">
                                            Problemas Cliente
                                        </div>
                                        <div class="column01_multi_line">
                                            <telerik:RadTextBox ID="txt_problemas" RenderMode="Lightweight"  Width="530px" 
                                                runat="server" TextMode="MultiLine"  Rows="3" AutoPostBack="True" Enabled="false" MaxLength="200"  
                                                style="text-transform: uppercase;" TabIndex="28" Visible="False"/>
                                        </div>
                                        <div class="column02_multi_line"></div>
                                    </div>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </div>
                    </div>
                    <div >
                        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                            <AjaxSettings>
                                <telerik:AjaxSetting AjaxControlID="BtnBuscar">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="txtcodigo" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnBuscar" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnCancelarTab1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab1" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lbl_nombres"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lbl_apellidos" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rdpdtp_fechanacimiento" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab2" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_convencional" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_convencionalextra" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_celular" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_celularextra" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_direcdomicilio" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_direcoficina" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab3" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_email" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_emailoficina" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_emailfactura" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chkfacebook"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chktwiter"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chkinstagram"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chksnapchat"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="RgdVehiculo" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab5" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_consulta"   LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_comentario" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_problemas" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_auditoria" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblcliente" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_facebook" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_twiter" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_instagram" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_snapchat" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnCancelarTab1">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="confirmWindow" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txtcodigo" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnBuscar" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnCancelarTab1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab1" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lbl_nombres" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lbl_apellidos" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rdpdtp_fechanacimiento" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab2" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_convencional"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_convencionalextra" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_celular" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_celularextra" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_direcdomicilio" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_direcoficina" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab3" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_email" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_emailoficina" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_emailfactura" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chkfacebook"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chktwiter"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chkinstagram"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Chksnapchat"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="RgdVehiculo"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab5"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_consulta" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_comentario"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_problemas" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_auditoria" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblcliente" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblplaca" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnGrabarTab1">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab1" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="rdpdtp_fechanacimiento"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <%--<telerik:AjaxSetting AjaxControlID="Radtabdatosconsulta">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Radtabdatosconsulta" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadPageView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadPageView2" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadPageView3" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadPageView4" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadPageView5" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>--%>
                                <telerik:AjaxSetting AjaxControlID="BtnGrabarTab2">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab2" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_convencional"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_convencionalextra"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_celular" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_celularextra"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_direcdomicilio"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_direcoficina"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnGrabarTab3">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab3" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_email" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_emailoficina" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_emailfactura" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_facebook" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_twiter" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_instagram" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_snapchat" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="Chkfacebook">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="txt_facebook"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="Chktwiter">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="txt_twiter"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="Chkinstagram">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="txt_instagram"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="Chksnapchat">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="txt_snapchat"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnAplicarTab4">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="lblplaca" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_placa" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnAplicarTab4" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab4" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblnombrecompleto"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblcodigo" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblmotor" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblchasis" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblproducto" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblaseguradora" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbaseguradora" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="lblconcesionaria" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="Rcbconcesionario" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="lblfinanciera" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbfinanciera" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="lblbroker" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="Rcbbroker" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="RgdVehiculo" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnCancelarTab4">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="lblplaca" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="txt_placa" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnAplicarTab4" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnCancelarTab4" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab4" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblnombrecompleto"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblcodigo"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblmotor" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblchasis" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblproducto" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblaseguradora" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbaseguradora" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblconcesionaria"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbconcesionario" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblfinanciera" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbfinanciera" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblbroker" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbbroker" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RgdVehiculo" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnGrabarTab4">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="BtnAplicarTab4" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="BtnCancelarTab4"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab4"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RgdVehiculo" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="RgdVehiculo">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="lblplaca"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="txt_placa"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnAplicarTab4"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="BtnCancelarTab4" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblnombrecompleto" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblcodigo" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblmotor" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblchasis" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblproducto" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="lblaseguradora" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbaseguradora"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblconcesionaria"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbconcesionario" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblfinanciera" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbfinanciera" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="lblbroker" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Rcbbroker" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="BtnGrabarTab5">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="BtnGrabarTab5" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_consulta" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_comentario" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                        <telerik:AjaxUpdatedControl ControlID="txt_problemas" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1"/>
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                            </AjaxSettings>
                        </telerik:RadAjaxManager>
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
                        </telerik:RadAjaxLoadingPanel>
                        <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                            EnableRoundedCorners="True" Overlay="True">
                        </telerik:RadNotification>
                        <telerik:RadWindow ID="confirmWindow" runat="server" VisibleTitlebar="true" VisibleStatusbar="false"
                            Modal="true" Behaviors="None" Height="150px" Width="300px">
                            <ContentTemplate>
                                <div style="padding-left: 30px; padding-top: 20px; width: 240px; float: left;">
                                    <asp:Label ID="lblConfirm" Font-Size="14px" Text="Verificando, Estas seguro de haber Guardado todos los datos ?. "  runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    <telerik:RadButton ID="RadButtonYes" runat="server" Width="81px" Height="22px" Text="Si" AutoPostBack="false"
                                        OnClientClicked="confirmResult" HoveredCssClass="goButtonClassHov" ForeColor="White">
                                        <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                            PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                        </Image>
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonNo" runat="server"  Width="81px" Height="22px" Text="No" AutoPostBack="false"
                                        OnClientClicked="confirmResult" HoveredCssClass="goButtonClassHov" ForeColor="White">
                                        <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                            PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                        </Image>
                                    </telerik:RadButton>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
                        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                            <script type="text/javascript">
                                function submitButton(event) 
                                {
                                    if (event.which == 13) 
                                    {
                                        $('#BtnBuscar').trigger('click');
                                    }
                                }

                                function keyPress(sender, args)
                                {
                                    var text = sender.get_value() + args.get_keyCharacter();
                                    if (!text.match('^[0-9]+$'))
                                        args.set_cancel(true);
                                }
                            </script>
                        </telerik:RadCodeBlock>
                    </div>
        </div>
    </section>
</form>
</asp:Content>
