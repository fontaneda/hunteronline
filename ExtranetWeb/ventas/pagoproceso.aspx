<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pagoproceso.aspx.vb" Inherits="ExtranetWeb.pagoproceso" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="stylesheet" href="../styles/css_mkt/int-styles.css">
    <link rel="stylesheet" href="../styles/css_mkt/main.css">
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet"/>
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <title>Hunter Online - Proceso de pago</title>
</head>
<body class="grey-back signup-page">
    <form id="frm1" runat="server" >
        <section class="singup-header">
            <section class="wrap">
                <img class="logo-ho" src="../images/img_mkt/logo-hunter-online.png" alt="Logo Hunter Online">
            </section>
        </section>
        <div id="dvdmensajes" class="messages alert" runat="server">
            <p>
                <label id="lblmensajeerror" runat="server"></label>    
            </p>
            <label id="close" for="hide-message" class="x-btn">&#10005</label>
        </div>
       <section class="singup-form-container">
            <div class="signup-txt">
                <h1>
                    Proceso<br/>
                    <b>
                        de <br/>
                        Pago
                    </b>
                </h1>
                <ul class="signup-servicios">
                    <li>
                        <img src="../images/img_mkt/pagos-icon-signup.png" alt=""/> Pago ágil
                    </li>
                    <li>
                        <img src="../images/img_mkt/bienes-icon-signup.png" alt=""/> Mantenga activo su servicio
                    </li>
                    <li>
                        <img src="../images/img_mkt/facturacion-icon-signup.png" alt=""/> Facturación en Línea
                    </li>
                </ul>
            </div>
            <div style="width:650px;">
                <div class="add-cliente-form">
                    <div class="add-cliente-datos">
                        <h2>
                            Datos del pago a realizar
                        </h2>
                        <div class="add-cliente-input">
                            <label for="identificacion">
                                No. de Identificación
                            </label>
                            <input type="text" id="txtcedulaclientefac" runat="server" disabled/>
                        </div>
                        <div class="add-cliente-input">
                            <label for="txtnombres">
                                Nombres
                            </label>
                            <input type="text" id="txtnombres" runat="server" disabled="disabled"/>
                        </div>
                        <div class="add-cliente-input">
                            <label for="txtemail">
                                Email
                            </label>
                            <input type="text" id="txtemail" runat="server" disabled="disabled"/>
                        </div>
                        <div class="add-cliente-input">
                            <label for="txttipopago">
                                Tipo de pago
                            </label>
                            <input type="text" id="txttipopago" runat="server" disabled="disabled"/>
                        </div>
                        <div class="add-cliente-input">
                            <label for="cmbtipotarjeta">
                                Tipo de tarjeta
                            </label>
                            <asp:DropDownList runat="server" ID="cmbtipotarjeta" Width="100%" Height="50" style="background-color: #FFFACD;"></asp:DropDownList>
                        </div>
                        <div class="add-cliente-input">
                            <label for="txtmonto">
                                Monto Total
                            </label>
                            <input type="text" id="txtmonto" runat="server" style="font-size:3em;" disabled="disabled"/>
                        </div>
                    </div>
                    <div class="separator">
                    </div>
                    <div class="total-container" style="background-color:transparent;">
                        <div class="btn-pagar">
                            <asp:button id="btnpagar" runat="server" class="btn-class" Text="Pagar">
                            </asp:button>
                        </div>
                    </div>


                    <div class="add-cliente-input" style="visibility:hidden;">
                        <label for="txtdireccion">
                            Direccion
                        </label>
                        <input type="text" id="txtdireccion" runat="server" style="font-size:3em;" disabled="disabled"/>
                    </div>
                    <div class="add-cliente-input" style="visibility:hidden;">
                        <label for="txtcelular">
                            Celular
                        </label>
                        <input type="text" id="txtcelular" runat="server" style="font-size:3em;" disabled="disabled"/>
                    </div>
                    <div class="add-cliente-input" style="visibility:hidden;">
                        <label for="txtsubtotal">
                            Subtotal
                        </label>
                        <input type="text" id="txtsubtotal" runat="server" style="font-size:3em;" disabled="disabled"/>
                    </div>
                    <div class="add-cliente-input" style="visibility:hidden;">
                        <label for="txtiva">
                            Iva
                        </label>
                        <input type="text" id="txtiva" runat="server" style="font-size:3em;" disabled="disabled"/>
                    </div>
                    <div class="add-cliente-input" style="visibility:hidden;">
                        <label for="txtemisor">
                            Emisor
                        </label>
                        <input type="text" id="txtemisor" runat="server" style="font-size:3em;" disabled="disabled"/>
                    </div>
                </div>
            </div>
        </section>
        <footer class="singup-footer">
            <section class="info-contact">
                <img src="../images/img_mkt/LOGO-HUNTER.png" alt="Logo Hunter"/>
                <div class="footer-text">
                    <ul class="fonos">
                        <li>
                            <p>
                                call center <br/>
                                <b>(04) 6004640</b>
                            </p>
                        </li>
                        <li>
                            <p>
                                EMERGENCIA 24/7 <br/>
                                <b>098 54 54 544</b>
                            </p>
                        </li>
                    </ul>
                    <ul class="links-footer">
                        <li>
                            <a href="#">
                                Términos de Uso y Privacidad 
                            </a>
                        </li>
                    </ul>
                    <p class="copy">
                        Copyright Carseg S.A. Derechos Reservados 2020
                    </p>
                </div>
            </section>
        </footer>
    </form>
    <script type="text/javascript" src="../js/main.js">
    </script>
</body>
</html>
