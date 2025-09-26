<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cambiocontrasena.aspx.vb" Inherits="ExtranetWeb.cambiocontrasena" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="../styles/estilo.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilocontraseña.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estiloregistrousuario.css" rel="stylesheet" type="text/css" />
        <link href="../styles/menunew.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilocambiocontraseña.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .style1
            {
                width: 9px;
                height: 10px;
            }
            #cambiocontrasena
            {
                width: 495px;
                height: 231px;
            }
        </style>
    </head>
    <body class="pantalla_clave" style="border-style:double; background-color:White;">
        <form id="cambiocontrasena" runat="server"  class="pantalla_clave">
            
                <script type="text/javascript">
                    function OnFocus(sender, eventArgs) 
                    {
                        var tooltip = document.getElementById("mensajecontroles");
                        tooltip.style.visibility = "visible"
                    }

                    function OnBlur(sender, eventArgs) 
                    {
                        var tooltip = document.getElementById("mensajecontroles");
                        tooltip.style.visibility = "hidden"
                    }

                    function GetRadWindow() 
                    {
                        var oWindow = null;
                        if (window.radWindow) oWindow = window.radWindow;
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                        return oWindow;
                    }

                    function returnParent() 
                    {
                        var oWnd = GetRadWindow();
                        oWnd.close();
                    }

                    function CloseAndRedirect(sender, args) 
                    {
                        GetRadWindow().BrowserWindow.location.href = 'login.aspx';
                        GetRadWindow().close();
                    }

                    function showpass(check_box) 
                    {
                        var spass = document.getElementById("txt_regusu_clave1");
                        if (check_box.checked)
                            spass.setAttribute("type", "text");
                        else
                            spass.setAttribute("type", "password");
                    }

                    function showpass2(check_box) 
                    {
                        var spass = document.getElementById("txt_regusu_clave2");
                        if (check_box.checked)
                            spass.setAttribute("type", "text");
                        else
                            spass.setAttribute("type", "password");
                    }

                    function showpass3(check_box) 
                    {
                        var spass = document.getElementById("txt_regusu_clave3");
                        if (check_box.checked)
                            spass.setAttribute("type", "text");
                        else
                            spass.setAttribute("type", "password");
                    }
                </script>
            
            <div class="cambio_clave_titulo">
                <b>Cambio de contraseña</b>
                <br />
                 <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div class="cambio_clave_linea"></div>
            <div class="cambio_clave_linea"></div>
            <%--<div class="regusu_cambio_clave02" id="div2" runat="server" style="width:172px;" >
                 Ingrese contraseña actual
            </div>
            <div class="regusu_cambio_clave01" id="div1" runat="server">
                <asp:TextBox ID="txt_regusu_clave1" runat="server"  Width="170px" TabIndex="1" CssClass="form-control input_class" 
                    MaxLength="16"  placeholder="(Mínimo 8 caracteres y máximo 16)"  >
                </asp:TextBox>
                <input type="checkbox" id="pass" runat="server"  onclick="showpass(this);" />Mostrar
            </div>
            <div class="cambio_clave_linea" ></div>--%>
            <div class="regusu_cambio_clave02">
                 Ingrese la nueva contraseña 
            </div>
            <div class="regusu_cambio_clave01">
                <asp:TextBox ID="txt_regusu_clave2" runat="server" Width="170px" TabIndex="2" CssClass="form-control input_class"
                    MaxLength="16"  placeholder="(Mínimo 8 caracteres y máximo 16)">
                </asp:TextBox>
                <%--<input type="checkbox" id="pass2" runat="server" onclick="showpass2(this);"  />Mostrar--%>
            </div>
            <div class="cambio_clave_linea"></div>
            <div class="regusu_cambio_clave02">
                Repita la contraseña nueva&nbsp;&nbsp;
            </div>
            <div class="regusu_cambio_clave01">
                <asp:TextBox ID="txt_regusu_clave3" runat="server"  Width="170px" TabIndex="3" CssClass="form-control input_class"
                    MaxLength="16"  placeholder="(Mínimo 8 caracteres y máximo 16)">
                </asp:TextBox>
                <%--<input type="checkbox" id="pass3" runat="server" onclick="showpass3(this);"  />Mostrar--%>
            </div>
            <div class="regusu_bloque_clave2">
                <div class="regusu_secc_clave_boton">
                    <asp:Button ID="BtnGrabar" runat="server" Width="81px" Height="22px" Text="Grabar" ForeColor="black"   AutoPostBack="true" ToolTip="Grabar contraseña nueva">
                        <%--<Image ImageUrl="../images/background/BotonRadwindows1.png" HoveredImageUrl="../images/background/BotonNegro.png"
                               PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />--%>
                    </asp:Button>
                </div>
                <div class="regusu_secc_clave_boton">
                    <asp:Button ID="BtnLimpiar" runat="server" Width="81px" Height="22px" Text="Limpiar"  ForeColor="black" AutoPostBack="true" ToolTip="Limpiar contenido de campos">
                        <%--<Image ImageUrl="../images/background/BotonRadwindows1.png" HoveredImageUrl="../images/background/BotonNegro.png" 
                               PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true" />--%>
                    </asp:Button>
                </div>
            </div>
            
        </form>
    </body>
</html>
