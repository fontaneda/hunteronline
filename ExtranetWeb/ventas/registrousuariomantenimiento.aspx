<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="registrousuariomantenimiento.aspx.vb" Inherits="ExtranetWeb.registrousuariomantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Pagos de Servicios Online</title>
    <link rel="stylesheet" href="../styles/css_mkt/main.css">
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="frm1" runat="server" >
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
                        Crear  la <br/>
                        Cuenta <br/>
                    </b>
                </h1>
                <ul class="signup-servicios">
                    <li>
                        <img src="../images/img_mkt/turnos-icon-signup.png" alt=""> Turnos para Chequeos
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
                    <label for="password">
                        Fecha de expiración
                    </label>
                    <asp:TextBox ID="txtfechaexpira" runat="server" TextMode="Date" class="input-style" Width="400" Height="50">
                    </asp:TextBox>
                </div>
                <div class="signup-terms">
                    <div class="item-check">
                        <input type="checkbox" name="chkaceptarreg" id="chkaceptarreg" runat="server">
                        <p>
                            Acepto las Condiciones del servicio y la Política de Privacidad de HunterOnLine
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
</asp:Content>
