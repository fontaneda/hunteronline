<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="vehiculorol.aspx.vb" Inherits="ExtranetWeb.vehiculorol" MaintainScrollPositionOnPostback="true"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Pagos de Servicios Online</title>
    <link rel="stylesheet" href="../styles/css_mkt/int-styles.css">
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
    <link rel="shortcut icon" href="../images/favicon.ico" />
</head>
<body class="grey-back">
    <input type="checkbox" class="checkbox" id="click" hidden>
    <section class="left-menu">
        <label for="click">
            <div class="menu-icon">
                <div class="line line-1"></div>
                <div class="line line-2"></div>
                <div class="line line-3"></div>
            </div>
        </label>
        <a href="#" class="logo-ho">
            <img src="../images/img_mkt/logo-hunter-online.svg" alt="Logo Hunter Online">
        </a>
        <div class="user-info">
            <img src="../images/img_mkt/user-avatar.png" alt="User Avatar">
            <h2>
                <asp:Label ID="lblnombresmaster" Text="Nombres" runat="server" /> 
            </h2>
            <ul>
                <li>
                    <img src="../images/img_mkt/mail-icon.png" alt=""> 
                    <asp:Label ID="lblemailmaster" Text="Email" runat="server" />
                </li>
                <%--<li id="imgcabeceracelular">
                    <i>
                        <img src="../images/img_mkt/ic_phone_android_48px 1.png" alt="">
                    </i> 
                    <asp:Label ID="lblcelularmaster" Text="0900000000" runat="server" />
                </li>--%>
            </ul>
        </div>
        <nav class="main-menu">
            <ul>
                <li id="lielement02" runat="server">
                    <a href="vehiculorol.aspx">
                        <img src="../images/img_mkt/bienes-icon.png" alt=""> 
                        Bienes Protegidos
                    </a>
                </li>
            </ul>
        </nav>
        <button id="btnsalirweb" runat="server" class="salir-btn" >
            <img src="../images/img_mkt/salir-icon.png" alt="">
            salir
        </button>
        <section class="socials-copy">
            <ul class="socials">
                <li>
                    <a href="https://www.facebook.com/hunterecuador/">
                        <img src="../images/img_mkt/fb.png" alt="">
                    </a>
                </li>
                <li>
                    <a href="https://www.instagram.com/hunterecuador">
                        <img src="../images/img_mkt/ig.png" alt="">
                    </a>
                </li>
                <li>
                    <a href="https://twitter.com/hunterecuador">
                        <img src="../images/img_mkt/tweet.png" alt="">
                    </a>
                </li>
            </ul>
            <p class="copy">
                Copyright Carseg S.A.<br/> Derechos Reservados 2020
            </p>
        </section>
    </section>
    <nav class=" nav-responsive">
        <ul>
            <li id="licellelement02" runat="server">
                <a href="vehiculorol.aspx">
                    <img src="../images/img_mkt/bienes-icon.png" alt=""> 
                    Bienes Protegidos
                </a>
            </li>
            <li>
                <a href="#" id="hrefsalir" runat="server">
                    <img src="../images/img_mkt/salir-icon.png" alt="">
                    Salir
                </a>
            </li>
        </ul>
    </nav>
    <section class="content">
        <section id="sectiontitulomaster" class="title-content red-border" runat="server">
            <!-- Clase que se aplica a los titulos quitarla para el master -->
            <h1 id="h1titulomaster" runat="server" >
                <asp:Label ID="lbltitulomaster" Text="Titulo" runat="server" />
            </h1>
            <div class="content-top-menu">
                <ul>
                    <li>
                        <div class="cart-class">
                            <p>
                                total<br/> 
                                <b>
                                    <asp:Label ID="lbltotalmaster" Text="0.00" runat="server" />
                                </b>
                            </p>
                            <button class="btn-small cart-btn">
                                <img src="../images/img_mkt/cart-icon.png" alt="">
                                    <asp:Label ID="lblcantidadmaster" Text="0" runat="server" />
                            </button>
                        </div>
                    </li>
                </ul>
            </div>
        </section>
        <%--<section class="content-body">--%>
            <form id="Form1" action="#" runat="server">
                <section class="info-body">                    
                    <div id="dvdmensajes" class="messages alert" runat="server">
                        <p>
                            <label id="lblmensajeerror" runat="server"></label>    
                        </p>
                        <label id="close" for="hide-message" class="x-btn">&#10005</label>
                    </div>
                    <div class="bienes-selection">
                        <ul>
                            <li>
                                <a class="btn-class btn-red current-bien" href="#">
                                    Vehiculos
                                </a>
                            </li>
                            <li>
                                <a class="btn-class btn-disable" href="vehiculorolbien.aspx">
                                    Otros Bienes
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="filter" >
                        <asp:TextBox ID="txtfiltrar" runat="server" class="filter-input" placeholder="Placa, Marca, Modelo, Chasis, Motor"/>
                        <button type="submit" class="filter-btn-bienes" id="btnfiltrar" runat="server">Filtrar</button>
                
                    </div>
                    <div class="separator" >
                    </div>
                    <ASP:Repeater id="Rpt_bienes" runat="server">
                    <ItemTemplate>  
                        <div class="bienes-items activo">
                            <div class="bienes-item-info">
                                <div class="bien-item-title">
                                    <h4>
                                        Placa:
                                    </h4>
                                    <p>
                                        <asp:Label ID="lblplacaveh" text='<%# Eval("PLACA") %>' runat="server"/>
                                    </p>
                                </div>
                                <p class="item-desc">
                                    <b>
                                        <asp:Label ID="lblmarcaveh" text='<%# Eval("DESC_MARCA") %>' runat="server"/>
                                    </b>
                                    <br/> 
                                    <asp:Label ID="lblmodeloveh" text='<%# Eval("DESC_MODELO") %>' runat="server"/>
                                    <br/> 
                                    <asp:Label ID="lblanioveh" text='<%# Eval("ANIO") %>' runat="server"/>
                                </p>
                                <ul>
                                    <li>
                                        <h4>Chasis:</h4>
                                        <p>
                                            <asp:Label ID="lblchasisveh" text='<%# Eval("CHASIS") %>' runat="server"/>
                                        </p>
                                    </li>
                                    <li>
                                        <h4>Motor:</h4>
                                        <p>
                                            <asp:Label ID="lblmotorveh" text='<%# Eval("MOTOR") %>' runat="server"/>
                                        </p>
                                    </li>
                                    <li>
                                        <h4>Último chequeo:</h4>
                                        <p>
                                            <asp:Label ID="lblultimochequeveh" text='<%# Eval("ULTIMO_CHEQUEO") %>' runat="server"/>
                                        </p>
                                    </li>
                                </ul>
                            </div>
                            <nav>
                                <ul>
                                    <li>
                                        <asp:ImageButton ID="btn_rpt_item_tur" ImageUrl="../images/img_mkt/chequeos-icon-1.png"  AlternateText="" runat="server" OnClick="clk_rpt_item_tur" ToolTip="Generar turno"/>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </ItemTemplate>
                    </ASP:Repeater>
                    <button type="submit" class="filter-btn-bienes" id="btnexportar" runat="server">Exportar</button>
                </section>
            </form>
        <%--</section> --%>
    </section>
    <script type="text/javascript">
        function ShowPopup() {
            var x = document.getElementById("hrefclientefac");
            x.click();
        }
    </script> 
    <script type="text/javascript" src="../js/main.js">
    </script> 
</body>
</html>
