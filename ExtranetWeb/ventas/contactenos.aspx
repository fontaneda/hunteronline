<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="contactenos.aspx.vb" Inherits="ExtranetWeb.contactenos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script type="text/javascript">
        function openWinHelp() {
            var oWnd = radopen("", "modalPopupHelp");
            oWnd.set_modal(true);
            if (!oWnd.get_modal()) document.documentElement.focus();
        }
    </script>
    <script type="text/javascript" language="javascript">
        function contadorTitulo(countfield, maxlimit) {
            field = $get('<%=txtcontenido.ClientID %>');
            if (field.value.length > maxlimit)
                field.value = field.value.substring(0, maxlimit)
            else
                countfield.value = maxlimit - field.value.length;
        } 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

    <div class="content_help">
        <asp:Button ID="BtnAyuda" runat="server" Text="" Style="top: 0px; left: 0px; height: 32px; width: 32px" OnClientClicked="openWinHelp">
            <%--<Image ImageUrl="../images/icons/32x32/helpamarillo.png" HoveredImageUrl="../images/icons/32x32/helpamarillo.png"
                PressedImageUrl="../images/icons/32x32/helpamarillo.png" IsBackgroundImage="true">
            </Image>--%>
        </asp:Button>
    </div>
    <div class="contactos_maestro">
        <div class="contactos_titulo">
            <div class="contactos_principal">
                <h2>
                    Contáctenos
                </h2>
            </div>
            <div class="contactos_subprincipal">
                <div class="column_cell_label">
                    Motivo
                </div>
                <div class="column_cell_text">
                    <%--                    <telerik:RadTextBox ID="txt_asunto" runat="server" Width="500px" MaxLength="200"
                        Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="vald_oblig_txt_asunto" runat="server" Display="Dynamic"
                        ErrorMessage="Campo obligatorio" ControlToValidate="txt_asunto" ValidationGroup="grupo01"> </asp:RequiredFieldValidator>--%>
                    <telerik:RadComboBox ID="cbm_motivo" runat="server" Width="250px" Height="150px"></telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="vald_oblig_txt_asunto" runat="server" Display="Dynamic"
                        ErrorMessage="Campo obligatorio" ControlToValidate="cbm_motivo" ValidationGroup="grupo01"> 
                    </asp:RequiredFieldValidator>
                </div>
                <%--<div class="column_cell_label">
                    Celular a Contactar
                </div>
                <div class="column_cell_text">
                    <telerik:RadTextBox ID="txt_telefono" runat="server" Width="200px" MaxLength="10">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="vald_oblig_txt_telefono" runat="server" ErrorMessage="Campo obligatorio"
                        ControlToValidate="txt_telefono" ValidationGroup="grupo01" Display="Dynamic"> </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="vald_expr_txt_telefono" runat="server" ErrorMessage=" Teléfono ingresado incorrectamente"
                        ControlToValidate="txt_telefono" ValidationGroup="grupo01" ValidationExpression="^0[0-9]{9}$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </div>--%>
                <div class="column_cell_label2">
                    Contenido del Mensaje
                </div>
                <div class="column_cell_text2">
                    <telerik:RadTextBox ID="txtcontenido" runat="server" Width="480px" MaxLength="1000" TextMode="MultiLine" Height="120px">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="vald_oblig_txtcontenido" runat="server" Display="Dynamic"
                        ErrorMessage="Campo obligatorio" ControlToValidate="txtcontenido" ValidationGroup="grupo01"> 
                    </asp:RequiredFieldValidator>
                </div>
                <div class="column_cell_label"></div>
                <div class="column_cell_label3">
                    Caracteres Disponibles
                    <input readonly="readonly" disabled="disabled" type="text" name="lbl_caracteres" 
                        size="5" value="1000" style="border-color: transparent; background-color: transparent"  />
                    <%--<div class = "botenviar">--%>
                    <%-- </div>--%>
                    <%-- <asp:Label ID="lbl_caracteres" runat="server"></asp:Label>--%>
                </div>
                <div class="botenviar">
                    <%--  <telerik:RadButton ID="Btn_enviar" runat="server" Text="Enviar"  buttoncolor="blue"  ValidationGroup="grupo01" style="colorbutton: #00FFFF"  >
                </telerik:RadButton>--%>
                    <telerik:RadButton ID="BtnEnviar" runat="server" Width="81px" Height="22px" Text="Enviar" ValidationGroup="grupo01" HoveredCssClass="goButtonClassHov" ForeColor="White">
                        <%--CssClass="boton_color"<Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>--%>
                         <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />
                    </telerik:RadButton>
                </div>
                <div class="botenviar">
                    <telerik:RadButton ID="BtnMail" runat="server" Width="81px" Height="22px" Text="Generar Mail" HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Generar Mail">
                        <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                               PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />
                    </telerik:RadButton>
                </div>
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
        </div>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" EnableShadow="true" runat="server">
        <Windows>
            <telerik:RadWindow ID="modalPopupHelp" runat="server" Width="500px" Height="220px" Modal="true" Behaviors="Close" CssClass="element" 
                Title="Aviso Importante" Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False">
                <ContentTemplate>
                    <div class="renovacionradwindowsdetalle">
                        Contactenos
                        <br />
                        <br />
                        Llene y envíe éste formulario en el caso de que necesite alguna <font class="letra_contacto">ayuda o alguna asistencia</font> sobre el sitio web.
                        Esta información será revisada por nuestros ejecutivos el cual se pondrá en contacto con usted al celular que no indica. Gracias por sus comentarios.
                        <br />
                        <br />
                        Estimado Cliente un Ejecutivo de Hunter se pondrá en contacto con usted en un tiempo de 24 horas.
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <%--<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
             <script type="text/javascript" language="javascript">
                 function contadorTexto(campo, cuentaCampos, limiteMaximo) {
                     if (campo.value.length > limiteMaximo) //Si muy largo, cortar.
                         campo.value = campo.value.substring(0, limiteMaximo);
                     else
                         cuentaCampos.value = (limiteMaximo - campo.value.length);
                 }
     </script>                       
    </telerik:RadCodeBlock>--%>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True" ContentIcon="">
    </telerik:RadNotification>
</form>
</asp:Content>
