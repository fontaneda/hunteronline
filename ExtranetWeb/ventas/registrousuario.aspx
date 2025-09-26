<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registrousuario.aspx.vb" Inherits="ExtranetWeb.registrousuario" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Hunter Online - Pagos de Servicios Online</title>
        <link rel="stylesheet" href="../styles/css_mkt/main.css">
        <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
        <link rel="shortcut icon" href="../images/favicon.ico" />
    </head>
    <body class="grey-back signup-page">
    <form id="frm1" runat="server" >
        <section class="singup-header">
            <section class="wrap">
                <img class="logo-ho" src="../images/img_mkt/logo-hunter-online.png" alt="Logo Hunter Online">
                <a class="btn-back" id="btnregresareg" runat="server">
                    <img src="../images/img_mkt/arrow_right_alt.png" alt=""> regresar
                </a>
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
                    Comencemos a<br/>
                    <b>
                        Crear  su <br/>
                        Cuenta
                    </b>
                </h1>
                <ul class="signup-servicios">
                    <li>
                        <img src="../images/img_mkt/pagos-icon-signup.png" alt=""> Pagos en Línea
                    </li>
                    <li>
                        <img src="../images/img_mkt/bienes-icon-signup.png" alt=""> Administrar Datos y Bienes
                    </li>
                    <li>
                        <img src="../images/img_mkt/turnos-icon-signup.png" alt=""> Turnos para Chequeos
                    </li>
                    <li>
                        <img src="../images/img_mkt/facturacion-icon-signup.png" alt=""> Facturación en Línea
                    </li>
                </ul>
            </div>
            <div class="signup-form">
                <div class="signup-input">
                    <label for="cedula">
                        Cédula / RUC
                    </label>
                    <asp:TextBox AutoPostBack="true" ID="txtcedula01reg" runat="server" Text="" MaxLength="15"></asp:TextBox>
                </div>
                <div class="signup-input">
                    <label for="email">
                        Correo electrónico
                    </label>
                    <input type="text" name="txtemailreg" id="txtemailreg" runat="server" maxlength="50">
                </div>
                <div class="signup-input">
                    <label for="nombre">
                        Nombres
                    </label>
                    <input type="text" name="txtnombrereg" id="txtnombrereg" runat="server" maxlength="50">
                </div>
                <div class="signup-input">
                    <label for="apellido">
                        Apellidos
                    </label>
                    <input type="text" name="txtapellidoreg" id="txtapellidoreg" runat="server" maxlength="50">
                </div>
                <div class="signup-input">
                    <label for="password">
                        Contraseña
                    </label>
                    <input type="password" name="txtclavereg" id="txtclavereg" runat="server" maxlength="15">
                </div>
                <div class="signup-input">
                    <label for="confirm-pass">
                        Confirmar contraseña
                    </label>
                    <input type="password" name="txtclaveconfirmarreg" id="txtclaveconfirmarreg" runat="server" maxlength="15">
                </div>
                <div class="signup-input">
                    <label for="password">
                        Celular
                    </label>
                    <input type="text" name="txtccelularreg" id="txtccelularreg" runat="server" maxlength="10">
                </div>
                <div class="signup-input">
                    <label for="confirm-pass">
                        Teléfono Contacto
                    </label>
                    <input type="text" name="txttelefonoreg" id="txttelefonoreg" runat="server" maxlength="10">
                </div>
                <div class="signup-select">
                    <p>
                        Fecha de Nacimiento
                    </p>
                    <div class="selects-container">
                        <div class="select-item">
                            <label for="dia">Dia</label>
                            <asp:DropDownList ID="dtpfechadia" runat="server"  class="select-css" AutoPostBack="true"/>
                        </div>
                        <div class="select-item">
                            <label for="mes">Mes</label>
                            <asp:DropDownList ID="dtpfechames" runat="server"  class="select-css" AutoPostBack="true"/>
                        </div>
                        <div class="select-item">
                            <label for="year">Año</label>
                            <asp:DropDownList ID="dtpfechaanio" runat="server"  class="select-css" AutoPostBack="true"/>
                        </div>
                    </div>
                </div>
                <div class="signup-terms">
                    <div class="item-check">
                        <input type="checkbox" name="chkaceptarreg" id="chkaceptarreg" runat="server">
                        <p>
                            Acepto las Condiciones del servicio y la Política de Privacidad de HunterOnLine
                        </p>
                    </div>
                    <div class="item-check">
                        <input type="checkbox" name="chkcorreoreg" id="chkcorreoreg" runat="server">
                        <p>
                            Deseo permanecer informado mediante correo electrónico sobre los productos, Servicios y promociones de Hunter
                        </p>
                    </div>
                </div>
                <div class="signup-btn">
                    <asp:Button class="signup-create-btn" type="submit" id="btncrearreg" runat="server" Text="crear cuenta"> 
                        
                    </asp:Button>
                </div>
            </div>
        </section>
        <footer class="singup-footer">
            <section class="info-contact">
                <img src="../images/img_mkt/LOGO-HUNTER.png" alt="Logo Hunter">
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
                        <li>
                            <a href="#">
                                | Contáctenos
                            </a>
                        </li>
                    </ul>
                    <p class="copy">
                        Copyright Carseg S.A. Derechos Reservados 2020
                    </p>
                </div>
            </section>
                <div class="norton">
                    <img src="../images/img_mkt/LOGO-NORTON.png" alt="Logo Norton">
                </div>
        </footer>
    </form>
    <script type="text/javascript" src="../js/main.js"></script>
</body>
</html>
