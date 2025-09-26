<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginExterno.aspx.vb"
    Inherits="ExtranetWeb.LoginExterno" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <title>Iniciar sesion</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
        crossorigin="anonymous" />
    <link rel="stylesheet" href="../styles/main.css" />
</head>
<body>
    <div class="container pt-4" style="text-align: center;">
        <header class="mt-5 mb-3 overflow-hidden">
        <h1 class="logo-top text-center">
          <img src="../images/background/loogo-ho-color.png" alt="Logo Hunter Online" />
        </h1>  
      </header>
        <section class="row justify-content-center mt-5">
        <div class="datos-ingreso col-md-5 text-center">
          <p class=" msn-ingreso">
            Bienvenido 
            <span>
                <label id="lblusuario" runat="server"></label>
            </span>
          </p> 
          <form class="px-4" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                    <input type="password" class="form-control mb-4" placeholder="password" id="txt_password" runat="server" />
                   <input class="btn-envio" type="submit" value="Ingresar" id="btningresa" runat="server" />
            
                    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                        EnableRoundedCorners="True" Overlay="True">
                    </telerik:RadNotification>
          </form>
        </div>
      </section>
        <section class="row justify-content-center">
        <div class="icon-list row row-cols-sm-2 row-cols-md-4 px-2">
          <span class="col"><img src="../images/background/pagos.png" alt="pago" /></span>
          <span class="col"><img src="../images/background/bienes.png" alt="bienes" /></span>
          <span class="col"><img src="../images/background/chequeos.png" alt="chequeos" /></span>
          <span class="col"><img src="../images/background/factura.png" alt="factura" /></span>
        </div>
      </section>
    </div>
</body>
</html>
