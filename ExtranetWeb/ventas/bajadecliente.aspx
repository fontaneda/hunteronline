<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bajadecliente.aspx.vb" Inherits="ExtranetWeb.bajadecliente" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="../styles/estiloregistrousuario.css" rel="stylesheet" type="text/css" />
        <title>Información Recibida</title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="regusu_bloque_col6_parrafo">
                <img src="../images/logo/logo_hunter2.jpg" alt="" />
            </div>
            <div class="regusu_title_03">
            </div>
            <div class="regusu_bloque_col6_parrafo">
                <asp:Label ID="lblinfo" runat="server" Text="Información Recibida" 
                    Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="#990000">
                </asp:Label>
            </div>
        </form>
    </body>
</html>
