<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="clientepotencial.aspx.vb" Inherits="ExtranetWeb.clientepotencial" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilomodal.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .regusu_secc
            {
                float: left;
                padding-left: 55px;
                padding-top: 5px;
                padding-bottom: 2px;
                width: 550px;
                height: 300px;
            }
            .regusu_label_01
            {
                float: left;
                width: 140px;
                height: 22px;
                text-align:right;
                font-weight: bold;
                margin-bottom: 5px;
                color: #3A3A3A
            }
            .regusu_text_01
            {
                float: left;
                width: 290px;
                height: 22px;
                margin-bottom: 5px;
                margin-left: 5px;
            }
            .regusu_bloque_01
            {
                float: left;
                width: 70px;
                height: 22px;
                margin-bottom: 5px;
                margin-left: 5px;
            }
            .regusu_bloque
            {
                float: left;
                width: 100%;
                height: auto;
                padding-left: 2px;
                padding-top: 2px;
                padding-bottom: 2px;
                text-align: center;
            }
            .regusu_bloque_col8
            {
                float: left;
                width: 480px;
                height: auto;
                padding-left: 5px;
                padding-top: 2px;
                padding-bottom: 2px;
                text-align: right;
            }
            .regusu_title_03_01
            {
                float: left;
                height: 30px;
                width: 435px;
                padding-left: 200px;
                padding-top: 8px;
                font-size: 24px;
                font-weight: bold;
                padding-bottom: 2px;
                color: #3A3A3A;
            }
            .regusu_bloque_col9
            {
                float: left;
                width: 100%;
                height: auto;
                padding-left: 5px;
                padding-top: 2px;
                padding-bottom: 2px;
                text-align: center;
                font-size: small;
                font-weight: bold;
                color: #AD2D29;
            }

        </style>
    </head>
    <body class="body">
        <form id="form1" method="post" runat="server">
            <div class="contenedor">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                <script type="text/javascript">
                    function GetRadWindow() 
                    {
                        var oWindow = null;
                        if (window.radWindow) oWindow = window.radWindow;
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                        return oWindow;
                    }

                    function AdjustRadWidow() 
                    {
                        var oWindow = GetRadWindow();
                        setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
                    }

                    function ChromeSafariFix(oWindow) 
                    {
                        var iframe = oWindow.get_contentFrame();
                        var body = iframe.contentWindow.document.body;
                        setTimeout(function () 
                        {
                            var height = body.scrollHeight;
                            var width = body.scrollWidth;
                            var iframeBounds = $telerik.getBounds(iframe);
                            var heightDelta = height - iframeBounds.height;
                            var widthDelta = width - iframeBounds.width;
                            if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                            if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                            oWindow.center();
                        }, 310);
                    }


                    function returnParent() 
                    {
                        var oWnd = GetRadWindow();
                        oWnd.close();
                    }

                </script>
                <div class="busqueda">
                    <div class="regusu_title_03_01">Ingresa los datos de tu referido</div>
                    <div class="regusu_secc">
                        <div class="regusu_label_01">&nbsp;</div>
                        <div class="regusu_text_01">&nbsp;</div>
                        <div class="regusu_bloque_01">&nbsp;</div>
                        <div class="regusu_label_01">Cédula / Ruc&nbsp;</div>
                        <div class="regusu_text_01">
                            <telerik:RadTextBox ID="txt_identificacion" runat="server" Width="280px" TabIndex="1" MaxLength="13" EmptyMessage="Cédula/ Ruc de referencia" >
                            </telerik:RadTextBox>
                        </div>
                        <div class="regusu_bloque_01">
                           <%-- <asp:RequiredFieldValidator ID="vld_txt_regusu_identificacion" runat="server" ErrorMessage="Cédula o Ruc no puede quedar vacío"
                                ControlToValidate="txt_identificacion" ValidationGroup="grupo01" Display="Dynamic"
                                Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"  ToolTip="Cédula o Ruc no puede quedar vacío" Text="*">
                            </asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="regusu_label_01">Nombres&nbsp;</div>
                        <div class="regusu_text_01">
                            <telerik:RadTextBox ID="txt_nombre" runat="server" Width="280px" TabIndex="4" MaxLength="50" EmptyMessage="Nombre Referencia" Style="text-transform: uppercase;"></telerik:RadTextBox>
                        </div>
                        <div class="regusu_bloque_01">
                            <asp:RequiredFieldValidator ID="vld_txt_regusu_nombre" runat="server" ErrorMessage="El nombre no puede quedar vacío"
                                ControlToValidate="txt_nombre" ValidationGroup="grupo01" Display="Dynamic"
                                Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" ToolTip="El nombre no puede quedar vacío">*
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="regusu_label_01">Apellidos&nbsp;</div>
                        <div class="regusu_text_01">
                            <telerik:RadTextBox ID="txt_apellido" runat="server" Width="280px" TabIndex="5" MaxLength="50" EmptyMessage="Apellido de referencia" Style="text-transform: uppercase;">
                            </telerik:RadTextBox>
                        </div>
                       <div class="regusu_bloque_01">
                            <asp:RequiredFieldValidator ID="vld_txt_regusu_apellido" runat="server" ErrorMessage="El apellido no puede quedar vacío"
                                ControlToValidate="txt_apellido" ValidationGroup="grupo01" Display="Dynamic"
                                Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29"  ToolTip="El apellido no puede quedar vacío" Text="*">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="regusu_label_01">Celular&nbsp;</div>
                        <div class="regusu_text_01">
                            <telerik:RadTextBox ID="txt_celular" runat="server" Width="280px" TabIndex="11" MaxLength="10" EmptyMessage="Celular de referencia">
                            </telerik:RadTextBox>
                        </div>
                        <div class="regusu_bloque_01">
                            <asp:RegularExpressionValidator ID="celularvalidator" runat="server" Display="Dynamic" ErrorMessage="El celular de referencia debe empezar con 09 y tener 10 números" 
                                ValidationExpression="^0[0-9]{9}$" ControlToValidate="txt_celular" ValidationGroup="grupo01" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#AD2D29" ToolTip="El celular de referencia debe empezar con 09 y tener 10 números">**
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="vld_txt_regusu_celular" runat="server" ErrorMessage="El celular de referencia no puede quedar vacío" ControlToValidate="txt_celular"
                                ValidationGroup="grupo01" Display="Dynamic" Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" ToolTip="El celular de referencia no puede quedar vacío">*
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="regusu_label_01">Teléfono&nbsp;</div>
                        <div class="regusu_text_01">
                            <telerik:RadTextBox ID="txt_telefono" runat="server" Width="280px" TabIndex="12" MaxLength="9" EmptyMessage="Teléfono de referencia"></telerik:RadTextBox>
                        </div>
                        <div class="regusu_bloque_01">
                            <asp:RegularExpressionValidator ID="telefonovalidator" runat="server" Display="Dynamic" ErrorMessage="El teléfono de referencia debe empezar con el código de área seguido del número de teléfono" 
                                ValidationExpression="^0[0-9]{8}$" ControlToValidate="txt_telefono" ValidationGroup="grupo01" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#AD2D29" ToolTip="El teléfono de referencia debe empezar con el código de área seguido del número de teléfono">**
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="vld_txt_regusu_telefono" runat="server" ErrorMessage="El teléfono de referencia no puede quedar vacío" ControlToValidate="txt_telefono"
                                ValidationGroup="grupo01" Display="Dynamic" Font-Bold="True" Font-Size="Small" ForeColor="#AD2D29" ToolTip="El teléfono de referencia no puede quedar vacío">*
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="regusu_bloque">&nbsp;</div>
                        <div class="regusu_bloque">&nbsp;</div>
                        <div class="regusu_bloque_col8">
                            <telerik:RadButton ID="Btnaceptar" runat="server" Width="81px" Height="22px" Text="Enviar" HoveredCssClass="goButtonClassHov"
                                        ForeColor="White" ToolTip="Enviar" TabIndex="21" ValidationGroup="grupo01">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                                </Image>
                            </telerik:RadButton>
                            &nbsp;
                            &nbsp;
                            &nbsp;
                           <%-- <telerik:RadButton ID="Btnclose" runat="server" Text="Cerrar"  ToolTip="Cerrar pantalla" ForeColor="White" 
                                  Width="81px" Height="22px"  HoveredCssClass="goButtonClassHov" OnClientClicked="returnParent" AutoPostBack="False">
                                <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                                        PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />
                            </telerik:RadButton>--%>
                        </div>
                        <div class="regusu_bloque_col9">
                            <asp:ValidationSummary ID="validationSummary" runat="server"  ValidationGroup="grupo01" HeaderText="Por favor verifique su información"/>
                        </div>
                    </div>
                </div>
            </div>
            <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                EnableRoundedCorners="True" Overlay="True">
            </telerik:RadNotification>
        </form>
    </body>
</html>
