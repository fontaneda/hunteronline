﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pagoretorno.aspx.vb" Inherits="ExtranetWeb.pagoretorno" %>
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
                            Proceso de pago ha concluido.
                        </h2>
                        <h2 style="font-weight:500">
                            <asp:Label ID="lblretorno" runat="server" Text=""></asp:Label>
                        </h2>
                    </div>
                    <div class="separator">
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
