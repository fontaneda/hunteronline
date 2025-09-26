<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreacionNuevoCliente.aspx.vb" Inherits="ExtranetWeb.CreacionNuevoCliente" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Hunter Online - Cliente soporte</title>
        <link rel="stylesheet" href="../styles/css_mkt/int-styles.css">
        <link rel="stylesheet" href="../styles/css_mkt/main.css">
        <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
        <link rel="shortcut icon" href="../images/favicon.ico" />
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
                                Creación<br/>
                                <b>
                                    Nuevo <br/>
                                    Cliente
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
                        <div style="width:650px;">
                            <div class="add-cliente-form">
                                <div class="add-cliente-datos">
                                    <h2>
                                        Ingreso de datos de cliente
                                    </h2>
                                    <div class="select-item">
                                        <label for="tipo-identificacion">Tipo de Identificación</label>
                                        <asp:DropDownList ID="cmbcedulaclientefac" runat="server" AutoPostBack="true" class="select-css" Width="400"/>
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="identificacion">
                                            No. de Identificación
                                        </label>
                                        <input type="text" id="txtcedulaclientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="apellido-paterno">
                                            Apellido paterno
                                        </label>
                                        <input type="text" id="txtapellido1clientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="apellido-materno">
                                            Apellido materno
                                        </label>
                                        <input type="text" id="txtapellido2clientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="primer-nombre">
                                            Primer nombre
                                        </label>
                                        <input type="text" id="txtnombre1clientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="segundo-nombre">
                                            Segundo nombre
                                        </label>
                                        <input type="text" id="txtnombre2clientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="email">
                                            Email
                                        </label>
                                        <input type="text" id="txtemailclientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="telefono">
                                            No. Teléfono
                                        </label>
                                        <input type="text" id="txttelefonoclientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="telefono">
                                            No. Celular
                                        </label>
                                        <input type="text" id="txtcelularclientefac" runat="server">
                                    </div>
                                    <div class="add-cliente-input">
                                        <label for="fecha-nacimiento">
                                            Fecha de nacimiento
                                        </label>
                                        <asp:TextBox ID="txtfechanacimientoclientefac" runat="server" TextMode="Date" class="input-style" Width="400" Height="50">
                                        </asp:TextBox>
                                    </div>
                                    <div class="select-item">
                                        <label for="sexo">Sexo</label>
                                        <asp:DropDownList ID="cmbsexoclientefac" runat="server" AutoPostBack="true" class="select-css" Width="400"/>
                                    </div>
                                </div>
                                <div class="separator"></div>
                                <div class="add-cliente-direccion">
                                    <h2>
                                        Ingreso de dirección de domicilio
                                    </h2>
                                    <div class="select-item">
                                        <label for="provincia">Provincia</label>
                                        <asp:DropDownList ID="cmbprovinciaclientefac" runat="server" AutoPostBack="true" class="select-css" Width="400"/>
                                    </div>
                                    <div class="select-item">
                                        <label for="ciudad">Ciudad</label>
                                        <asp:DropDownList ID="cmbciudadclientefac" runat="server" AutoPostBack="true" class="select-css" Width="400"/>
                                    </div>
                                    <div class="select-item">
                                        <label for="parroquia">Parroquia</label>
                                        <asp:DropDownList ID="cmbparroquiaclientefac" runat="server" AutoPostBack="true" class="select-css" Width="400"/>
                                    </div>
                                    <div class="select-item">
                                        <label for="sector">Sector</label>
                                        <asp:DropDownList ID="cmbsectorclientefac" runat="server" AutoPostBack="true" class="select-css" Width="400"/>
                                    </div>
                                    <div class="add-cliente-input span-item" style="margin-left:30px;">
                                        <label for="direccion">
                                            Direccion
                                        </label>
                                        <input type="text" id="txtdireccionclientefac" runat="server">
                                    </div>
                                    <div class="span-item inputs-group" style="margin-left:30px;">
                                        <div class="add-cliente-input">
                                            <label for="interseccion">
                                                Intersección
                                            </label>
                                            <input type="text" id="txtinterseccionclientefac" runat="server">
                                        </div>

                                        <div class="add-cliente-input">
                                            <label for="numero">
                                                Número
                                            </label>
                                            <input type="text" id="txtnumeroclientefac" runat="server">
                                        </div>
                                    </div>
                                </div>
                                <div class="top-tabla-options" style="margin:30px 0px 0px 30px;">
                                    <button class="cliente-nuevo-fact" id="btnnuevocliente" runat="server" >
                                        <img src="../images/img_mkt/add_circle_outline.png" alt="">
                                        AGREGAR USUARIO
                                    </button>
                                </div>
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
            </footer>
        </form>
        <script type="text/javascript" src="../js/main.js">
        </script>
    </body>
</html>
