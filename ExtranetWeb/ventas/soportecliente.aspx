<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="soportecliente.aspx.vb" Inherits="ExtranetWeb.soportecliente" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register assembly="DevExpress.Web.v23.2, Version=23.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Soporte Usuario</title>
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estiloregistrousuario.css" rel="stylesheet" type="text/css" />
    <link href="../styles/menunew.css" rel="stylesheet" type="text/css" />
    <link href="../styles/estilocambiocontraseña.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("chk_acuerdo").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }

        function checkExtension(radUpload, eventArgs) {

            var input = eventArgs.get_fileInputField();
            if (!radUpload.isExtensionValid(input.value)) {
                var inputs = radUpload.getFileInputs();
                for (i = 0; inputs.length > i; i++) {
                    if (inputs[i] == input) {
                        alert("Extensión de Archivo no Válida.");
                        radUpload.clearFileInputAt(i);
                        break;
                    }
                }
            }
        }

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/es_ES/sdk.js#xfbml=1&version=v2.0";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));

        !function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (!d.getElementById(id)) {
                js = d.createElement(s);
                js.id = id; js.src = "//platform.twitter.com/widgets.js";
                fjs.parentNode.insertBefore(js, fjs);
            }
        } (document, "script", "twitter-wjs");

    </script>

</head>
<body>
    <form id="form1" runat="server">
    
   <%-- <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>--%>
    
    <div id="container_2">
        <div id="banner4">
           <%-- <div class="logo_image">
            </div>--%>
<%--            <div class="content_user_logo_principal_cabecera">
                <div class="fb-like" data-href="https://es-es.facebook.com/hunterecuador" data-width="100"
                    data-layout="button_count" data-action="like" data-show-faces="false" data-share="false">
                </div>
                <a href="https://twitter.com/hunterEcuador" class="twitter-share-button" data-show-count="true"
                    data-lang="es">Follow @twitterapi</a>
            </div>--%>
            <%--<div class="content_user_logo_principal_new">
            </div>--%>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </div>
<%--        <div id="regusu_content_principal">     
        </div>--%>
       <%-- visibility:hidden;--%>
        <div class="regusu_secc_soporte_regresar">
           <div ID="mensajecontroles" style="margin:0px 250px 0px 5px; visibility:hidden;">
                Máximo 16 caracteres
           </div>
           <div class="content_regresar_soporte_icon"> 
         <%--    <telerik:RadButton ID="btnSalir" runat="server" Width="81px" Height="22px"
                    Text="Regresa" HoveredCssClass="goButtonClassHov" ForeColor="White" ToolTip="Regresar al Inicio">
                   <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                   </Image>
             </telerik:RadButton>--%>

             <telerik:RadButton ID="Btncancelar" runat="server" Width="81px" Height="22px" 
                    Text="Cancela" HoveredCssClass="goButtonClassHov"  ForeColor= "White" ToolTip="Inicializa campos/salir de la opción">
                   <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                   </Image>
             </telerik:RadButton>

             <telerik:RadButton ID="BtnVerificar" runat="server" Width="81px" Height="22px" 
                    Text="Verifica" HoveredCssClass="goButtonClassHov"  ForeColor= "White" ToolTip="Verifica datos">
                   <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                   </Image>
             </telerik:RadButton>

             <telerik:RadButton ID="Btngrabar" runat="server" Width="81px" Height="22px" 
                    Text="Graba" HoveredCssClass="goButtonClassHov"  ForeColor= "White" ToolTip="Envia y graba correo">
                   <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                   </Image>
             </telerik:RadButton>

           </div>
        </div>
        <div class="regusu_content_principal_bloque">
            <div class="regusu_title_03">
                Soporte usuario 
            </div>
            <div class="regusu_title_02">
                Preguntas que registró
            </div>
            <div class="regusu_secc_soporte">
                <div class="regusu_label01">
                    Identificación Cliente&nbsp;
                </div>
               <%-- AutoPostBack="True"--%>
                <div class="regusu_text01">
                    <telerik:RadTextBox ID="txt_regusu_identificacion" runat="server" Width="280px" TabIndex="1"
                         MaxLength="13">
                    </telerik:RadTextBox>
                </div>
                <div class="regusu_bloque_col3_parrafo">
                    <asp:RequiredFieldValidator ID="vld_txt_regusu_identificacion" runat="server" ErrorMessage="Cédula o Ruc no puede quedar vacío"
                        ControlToValidate="txt_regusu_identificacion" ValidationGroup="grupo01" Display="Dynamic"
                        Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"  ToolTip="Cédula o Ruc no puede quedar vacío" Text="*">
                    </asp:RequiredFieldValidator>
                </div>

                <div class="regusu_label01">
                    Clave Cliente&nbsp;
                </div>
                <div class="regusu_text01">
                    <telerik:RadTextBox ID="txt_regusu_clave" runat="server" Width="280px" TabIndex="2"
                         MaxLength="30">
                    </telerik:RadTextBox>
                </div>
                <div class="regusu_bloque_col3_parrafo">
                    <asp:RequiredFieldValidator ID="vld_txt_regusu_clave" runat="server" ErrorMessage="El chasis o motor no puede quedar vacío"
                        ControlToValidate="txt_regusu_clave" ValidationGroup="grupo01" Display="Dynamic"
                        Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"  ToolTip="El chasis o motor no puede quedar vacío" Text="*">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="regusu_label01">
                    Usuario Soporte &nbsp;
                </div>
                <div class="regusu_text01">
                    <telerik:RadTextBox ID="txt_regusu_usuario" runat="server" Width="280px" TabIndex="3"
                        MaxLength="40">
                    </telerik:RadTextBox>
                </div>
                <div class="regusu_bloque_col3_parrafo">
<%--                    <asp:RegularExpressionValidator ID="UsuarioValidator" runat="server" Display="Dynamic"
                        ErrorMessage="Correo eletrónico incorrecto. Formato: tucorreo@tudominio" ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                        ControlToValidate="txt_regusu_usuario" ValidationGroup="grupo01" Font-Bold="True"
                        Font-Size="Small" ForeColor="#AD2D29" 
                        ToolTip="Usuario Soporte incorrecto. ">*</asp:RegularExpressionValidator>
--%>                    <asp:RequiredFieldValidator ID="vld_txt_regusu_usuario" runat="server" Display="Dynamic"
                        ControlToValidate="txt_regusu_usuario" 
                        ErrorMessage="El usuario soporte no puede quedar vacío" ValidationGroup="grupo01"
                        Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" 
                        ToolTip="El usuario soporte no puede quedar vacío" Text="*">*</asp:RequiredFieldValidator>
                </div>
                <div class="regusu_label01">
                    Nombre del Cliente&nbsp;
                </div>
                <div class="regusu_text01">
                    <telerik:RadTextBox ID="txt_regusu_nombre" runat="server" Width="280px" TabIndex="4" Enabled="false"
                        MaxLength="50">
                    </telerik:RadTextBox>
                </div>
<%--                <div class="regusu_bloque_col3_parrafo">
                    <asp:RegularExpressionValidator ID="nombrevalidator" runat="server" Display="Dynamic"
                        ErrorMessage="El nombre no debe contener números ni caracteres especiales" 
                        ValidationExpression="^[a-zA-ZáéíóúàèìòùÁÉÍÓÚÀÈÌÒÙñÑ\s]{1,50}$" ControlToValidate="txt_regusu_nombre"
                        ValidationGroup="grupo01" Font-Bold="True" Font-Size="Small" 
                        ForeColor="#AD2D29" 
                        ToolTip="El nombre no debe contener números ni caracteres especiales">**</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="vld_txt_regusu_nombre" runat="server" ErrorMessage="El nombre no puede quedar vacío"
                        ControlToValidate="txt_regusu_nombre" ValidationGroup="grupo01" Display="Dynamic"
                        Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" 
                        ToolTip="El nombre no puede quedar vacío">*</asp:RequiredFieldValidator>
                </div>
--%>            <div class="soporte_label01">
                    Texto a enviar en correo&nbsp;
                </div>
                <div class="regsoporte_text01">
                    <telerik:RadTextBox ID="txt_regusu_contenido" runat="server" Width="420px" Height="82" TabIndex="5"
                        MaxLength="1000" TextMode="MultiLine">
                    </telerik:RadTextBox>
                </div>
                <div class="regusu_soporte_col3_parrafo">
                 <%--   <asp:RegularExpressionValidator ID="apellidovalidator" runat="server" Display="Dynamic"                        
                        ErrorMessage="El contenido no debe contener caracteres especiales" 
                        ValidationExpression="^[a-zA-ZáéíóúàèìòùÁÉÍÓÚÀÈÌÒÙñÑ\s]{1,50}$" ControlToValidate="txt_regusu_contenido"
                        ValidationGroup="grupo01" Font-Bold="True" Font-Size="Small" 
                        ForeColor="#AD2D29" 
                        ToolTip="El contenido no debe contener caracteres especiales">**</asp:RegularExpressionValidator>--%>
                    <asp:RequiredFieldValidator ID="vld_txt_regusu_contenido" runat="server" ErrorMessage="El contenido no puede quedar vacío"
                        ControlToValidate="txt_regusu_contenido" ValidationGroup="grupo01" Display="Dynamic"
                        Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" 
                        ToolTip="El contenido no puede quedar vacío">*</asp:RequiredFieldValidator>
                </div>

               <%-- <div class ="admin_sec_soporte_004">
                    <asp:Label ID="lblImagenVisualiza" runat="server" Width="90px" Visible="True" Text="Archivo "></asp:Label>    
                </div>--%>

<%--                                  <div class ="admin_sec_control_011">
                                         <div class ="soporte_subtitulo_documento">
                                           <asp:Label ID="lblRadArchivo" runat="server" Text=""></asp:Label>
                                         </div>
                                           <div class ="soporte_subtitulo_documento">
                                               <asp:Label ID="lblExtArchivo" runat="server" Width="200px" Visible="True" ></asp:Label>
                                               <asp:Label ID="lblTamano" runat="server" Width="200px" ForeColor="Red" ></asp:Label>
                                         </div>  
                                          <telerik:RadUpload ID="RadUpArchivo" Runat="server"  ControlObjectsVisibility="ClearButtons" 
                                                Culture="es-ES" InputSize="52"  MaxFileInputsCount="1"  Width="515px"  
                                             onclientfileselected="checkExtension"   OverwriteExistingFiles="True" 
                                             Height="30px" TabIndex="-1" >
                                                <Localization Clear="Limpiar" Select="Buscar" />
                                         </telerik:RadUpload>
                                        
                                        
                                     </div> 
--%>
               <div class="soporte_label01">
                    &nbsp;
                </div>
               <div class="soporte_label01">
                    &nbsp;
                </div>
               <div class="soporte_label01">
                    &nbsp;
                </div>
               <div class="soporte_label01">
                    &nbsp;
                </div>

               <div class="soporte_label01">
                    Archivo adjuntar &nbsp &nbsp &nbsp 
                </div>

                <%--     (Extensiones permitidas .doc .xlsx .png .pdf )
                   <telerik:RadUpload ID="RadUpImagen" Runat="server"  
                                              ControlObjectsVisibility="ClearButtons" Culture="es-ES" InputSize="52" 
                                                MaxFileInputsCount="1" onclientfileselected="checkExtension" Width="580px" 
                                                AllowedFileExtensions=".jpg,.gif,.jpge,.png" 
                                              OverwriteExistingFiles="True"  ReadOnlyFileInputs="True" Visible="True" 
                                              Height="30px" TabIndex="-1">
                                                <Localization Clear="Limpiar" Select="Buscar" />
                                            </telerik:RadUpload>--%>

                <%-- onclientfileselected = "checkExtension"  AllowedFileExtensions=".doc, .xlsx, .png, .pdf"  Visible="True"  ReadOnlyFileInputs = "true"  --%>
                <div class="regusu_soporte_col4_parrafo">
                    <telerik:RadUpload ID="RadUpArchivo" Runat="server"  ControlObjectsVisibility="ClearButtons" 
                        Culture="es-ES" InputSize="52"  MaxFileInputsCount="1"  Width="481px"  
                           OverwriteExistingFiles="True" 
                        Height="30px" TabIndex="-1" >
                        <Localization Clear="Limpiar" Select="Buscar" />
                    </telerik:RadUpload>

                    <telerik:RadUpload ID="RadUpload1" Runat="server" Culture="es-ES" InputSize ="52"
                        ControlObjectsVisibility="ClearButtons" Height="29px" Width="481px">
                      <Localization Clear="Limpiar" Select="Buscar"   />
                    </telerik:RadUpload>
                </div>
                <%--<div class ="admin_sec_soporte_012">       --%>
                <%--  <div class ="soporte_subtitulo_documento">
                        <asp:Label ID="lblRadImagen" runat="server" Width="200px" ></asp:Label>  

                         ReadOnlyFileInputs="True"    Skin="Default"   AllowedFileExtensions=".doc,.xls,.png" 

                    </div> --%>
                  <%--  <div class ="soporte_subtitulo_documento">
                        <asp:Label ID="lblArchivo" runat="server"  Text="Extensión permitida .doc,.xls,.png" Width="200px"  Visible="True"></asp:Label>  
                    </div>   --%>
                    <%--<telerik:RadUpload ID="RadUpArchivo" Runat="server"  ControlObjectsVisibility="ClearButtons"
                         Culture="es-ES" InputSize="42" 
                        MaxFileInputsCount="1" Width="420px"    onclientfileselected="checkExtension" 
                        OverwriteExistingFiles="True" 
                        Height="25px" TabIndex="-1" >
                        <Localization  Clear="Limpiar" Select="Buscar"   />
                    </telerik:RadUpload>--%>
               <%-- </div>--%>  

            </div>


                <div class="regusu_secc_seguridad">
                <div class="regusu_secc_banco_preguntas_02">
                    <div class="regusu_secc_table_label02">
                        <%--<asp:Label ID="lbl_prg_id_01" runat="server" Text="" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_regusu_pregunta01" runat="server" Text="" Visible="False"></asp:Label>--%>
                        <telerik:RadTextBox ID="cbx_regusu_pregunta_011" runat="server" Width="255px" Height="25px" Enabled="false"
                            TabIndex="13" AutoPostBack="True">
                        </telerik:RadTextBox>
                    </div>
                    <div class="regusu_secc_table_text01">
                        <telerik:RadTextBox ID="txt_regusu_respuesta01" runat="server" Width="220px" Height="25px" LabelWidth="112px" Enabled="false"
                            TabIndex="14">
                        </telerik:RadTextBox>
                    </div>
                    <div class="regusu_bloque_col5_parrafo">
                        <asp:RegularExpressionValidator ID="Validator_respuesta01" runat="server" Display="Dynamic"
                            ControlToValidate="txt_regusu_respuesta01" ValidationGroup="grupo01" Font-Bold="True"
                            Font-Size="X-Small" ForeColor="#AD2D29" 
                            ErrorMessage="Verifique la respuesta a su primera pregunta" 
                            ToolTip="Verifique la respuesta a su primera pregunta">**</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vld_txt_regusu_respuesta01" runat="server" ErrorMessage="La respuesta a su primera pregunta no puede quedar vacío"
                            ControlToValidate="txt_regusu_respuesta01" ValidationGroup="grupo01" Display="Dynamic"
                            Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" 
                            ToolTip="La respuesta a su primera pregunta no puede quedar vacío">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="regusu_secc_table_label02">
                        <%--<asp:Label ID="lbl_prg_id_02" runat="server" Text="" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_regusu_pregunta02" runat="server" Text="" Visible="False"></asp:Label>--%>
                        <telerik:RadTextBox ID="cbx_regusu_pregunta_022" runat="server" Width="255px" Height="25px" Enabled="false"
                            TabIndex="15" AutoPostBack="True">
                        </telerik:RadTextBox>
                    </div>
                    <div class="regusu_secc_table_text01">
                        <telerik:RadTextBox ID="txt_regusu_respuesta02" runat="server" Width="220px" Height="25px" TabIndex="16" Enabled="false">
                        </telerik:RadTextBox>
                    </div>
                    <div class="regusu_bloque_col5_parrafo">
                        <asp:RegularExpressionValidator ID="Validator_respuesta02" runat="server" Display="Dynamic"
                            ControlToValidate="txt_regusu_respuesta02" ValidationGroup="grupo01" Font-Bold="True"
                            Font-Size="X-Small" ForeColor="#AD2D29" 
                            ErrorMessage="Verifique la respuesta a su segunda pregunta"
                            ToolTip="Verifique la respuesta a su segunda pregunta">**</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vld_txt_regusu_respuesta02" runat="server" ErrorMessage="La respuesta a su segunda pregunta no puede quedar vacío"
                            ControlToValidate="txt_regusu_respuesta02" ValidationGroup="grupo01" Display="Dynamic"
                            Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" ToolTip="La respuesta a su segunda pregunta no puede quedar vacío" Text="*"> </asp:RequiredFieldValidator>
                    </div>
                    <div class="regusu_secc_table_label02">
                       <%-- <asp:Label ID="lbl_prg_id_03" runat="server" Text="" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_regusu_pregunta03" runat="server" Text="" Visible="False"></asp:Label>--%>
                        <telerik:RadTextBox ID="cbx_regusu_pregunta_033" runat="server" Width="255px" Height="25px" Enabled="false"
                            TabIndex="17" AutoPostBack="True">
                        </telerik:RadTextBox>
                    </div>
                    <div class="regusu_secc_table_text01">
                        <telerik:RadTextBox ID="txt_regusu_respuesta03" runat="server" Width="220px" Height="25px" TabIndex="18" Enabled="false">
                        </telerik:RadTextBox>
                    </div>
                    <div class="regusu_bloque_col5_parrafo">
                        <asp:RegularExpressionValidator ID="Validator_respuesta03" runat="server" Display="Dynamic"
                            ControlToValidate="txt_regusu_respuesta03" ValidationGroup="grupo01" Font-Bold="True"
                            Font-Size="X-Small" ForeColor="#AD2D29" 
                            ErrorMessage="Verifique la respuesta a su tercera pregunta" 
                            ToolTip="Verifique la respuesta a su tercera pregunta">**</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vld_txt_regusu_respuesta03" runat="server" ErrorMessage="La respuesta a su tercera pregunta no puede quedar vacío"
                            ControlToValidate="txt_regusu_respuesta03" ValidationGroup="grupo01" Display="Dynamic"
                            Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" ToolTip="La respuesta a su tercera pregunta no puede quedar vacío" Text="*"> </asp:RequiredFieldValidator>
                    </div>
                </div>
               
                <%--<div class="regusu_secc_login_label01">
                    ¿Ya tiene una cuenta en Hunter?
                </div>
                <div class="regusu_secc_login_label02">
                    <asp:HyperLink ID="hplink" runat="server" NavigateUrl="~/ventas/login.aspx" ForeColor="#3B3B3B">Iniciar Sesión</asp:HyperLink>
                </div>--%>
            </div>
           </div>
              
               
      </div>

        <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                        EnableRoundedCorners="True" Overlay="True">
        </telerik:RadNotification>

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelsRenderMode="Inline">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="BtnVerificar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txt_regusu_nombre" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="cbx_regusu_pregunta_011" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta01" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="cbx_regusu_pregunta_022" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta02" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="cbx_regusu_pregunta_033" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="txt_regusu_respuesta03" 
                            UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Btngrabar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rntMensajes" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

</form>
</body>
</html>
