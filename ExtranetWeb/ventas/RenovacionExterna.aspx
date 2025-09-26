<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RenovacionExterna.aspx.vb" Inherits="ExtranetWeb.RenovacionExterna" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Pagos de Servicios Online</title>
    <link rel="stylesheet" href="../styles/css_mkt/int-styles.css">
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
    <style type="text/css">
        .modalDialog {
	        position: fixed;
	        font-family: Arial, Helvetica, sans-serif;
	        top: 0;
	        right: 0;
	        bottom: 0;
	        left: 0;
	        background: rgba(0,0,0,0.8);
	        z-index: 99999;
	        opacity:0;
	        -webkit-transition: opacity 400ms ease-in;
	        -moz-transition: opacity 400ms ease-in;
	        transition: opacity 400ms ease-in;
	        pointer-events: none;
        }
        .modalDialog:target {
	        opacity:1;
	        pointer-events: auto;
        }
        .modalDialog > div {
	        width: 70%;
	        height:70%;
	        position: relative;
	        margin: 5% auto;
	        padding: 5px 20px 13px 20px;
	        border-radius: 10px;
	        background: #f4f7f9;
            -webkit-transition: opacity 400ms ease-in;
            -moz-transition: opacity 400ms ease-in;
            transition: opacity 400ms ease-in;
            overflow-y: scroll;
        }
        .close {
	        background: #606061;
	        color: #FFFFFF;
	        line-height: 25px;
	        position: absolute;
	        right: 10px;
	        text-align: center;
	        top: 10px;
	        width: 24px;
	        text-decoration: none;
	        font-weight: bold;
	        -webkit-border-radius: 12px;
	        -moz-border-radius: 12px;
	        border-radius: 12px;
	        -moz-box-shadow: 1px 1px 3px #000;
	        -webkit-box-shadow: 1px 1px 3px #000;
	        box-shadow: 1px 1px 3px #000;
        }
        .close:hover { background: #00d9ff; }
    </style>
</head>
<body class="grey-back">
    <section class="left-menu">
        <a href="#" class="logo-ho">
            <img src="../images/img_mkt/logo-hunter-online.png" alt="Logo Hunter Online">
        </a>
        <div class="user-info">
            <img src="../images/img_mkt/user-avatar.png" alt="User Avatar">
            <h2>
                <asp:Label ID="lblUserName" runat="server" Text=""/>
            </h2>
            <ul>
                <li>
                    <img src="../images/img_mkt/mail-icon.png" alt=""> 
                    <asp:Label ID="lblUserEmail" runat="server" Text=""/>
                </li>
                <li>
                    <i>
                        <img src="../images/img_mkt/ic_phone_android_48px 1.png" alt="">
                    </i>
                    <asp:Label ID="lblUserCelular" runat="server" Text=""/>
                </li>
            </ul>
        </div>
        <nav class="main-menu">
            <ul>
                <li>
                    <a href="#">
                        <img src="../images/img_mkt/cuenta-icon.png" alt=""> Mi Cuenta
                    </a>
                </li>
                <li>
                    <a href="#">
                        <img src="../images/img_mkt/bienes-icon.png" alt=""> Bienes Protegidos
                    </a>
                </li>
                <li class="current-option pagos-option">
                    <a href="#">
                        <img src="../images/img_mkt/pago-icon.png" alt=""> Pagos de Servicios
                    </a>
                </li>
                <li>
                    <a href="#">
                        <img src="../images/img_mkt/transacciones-icon.png" alt=""> Mis Transacciones
                    </a>
                </li>
                <li id="lielement06" runat="server">
                    <a href="#">
                        <img src="../images/img_mkt/cobros-factura-icon.png" alt=""> 
                        Cobro de Facturas
                    </a>
                </li>
                <li id="lielement07" runat="server" >
                    <a href="#">
                        <img src="../images/img_mkt/ventas-icon.png" alt=""> 
                        Ventas
                    </a>
                </li>
                <li id="lielement04" runat="server">
                    <a href="#">
                        <img src="../images/img_mkt/transacciones-icon.png" alt=""> 
                        Mis Transacciones
                    </a>
                </li>
                <li id="lielement05" runat="server">
                    <a href="#">
                        <img src="../images/img_mkt/documentos-icon.png" alt=""> 
                        Documentos Electrónicos
                    </a>
                </li>
            </ul>
        </nav>
        <button class="turnos-btn">
            <img src="../images/img_mkt/turnos-icon-white.png" alt="">
            generar turno
        </button>
        <button class="salir-btn">
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
            <li id="licellelement01" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/cuenta-icon.png" alt=""> 
                    Mi Cuenta
                </a>
            </li>
            <li id="licellelement02" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/bienes-icon.png" alt=""> 
                    Bienes Protegidos
                </a>
            </li>
            <li id="licellelement03" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/pago-icon.png" alt=""> 
                    Pagos de Servicios
                </a>
            </li>
            <li id="licellelement07" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/cobros-factura-icon.png" alt=""> 
                    Cobro de Facturas
                </a>
            </li>
            <li id="licellelement08" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/ventas-icon.png" alt=""> 
                    Ventas
                </a>
            </li>
            <li id="licellelement04" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/transacciones-icon.png" alt=""> 
                    Mis Transacciones
                </a>
            </li>
            <li id="licellelement05" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/documentos-icon.png" alt=""> 
                    Documentos Electrónicos
                </a>
            </li>
            <li id="licellelement06" runat="server">
                <a href="#">
                    <img src="../images/img_mkt/transacciones-icon.png" alt=""> 
                    Generar Turno
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
        <form id="Form1" action="#" runat="server" >
            <section class="title-content">
                <h1>
                    Pagos de Servicios - Renovación
                </h1>
                <div class="content-top-menu">
                    <ul>
                        <li>
                            <div class="cart-class">
                                <p>
                                    total
                                    <br/> 
                                    <b>
                                        <asp:Label ID="lblTotalCompra" text="0" runat="server"/>
                                    </b>
                                </p>
                                <button class="btn-small cart-btn">
                                    <img src="../images/img_mkt/cart-icon.png" alt="">
                                    <asp:Label ID="lblcantidadcarrito" runat="server" Text="0"/>
                                </button>
                            </div>
                        </li>
                        <li>
                            <button class="btn-small settings-btn">
                                <img src="../images/img_mkt/settings-icon.png" alt="">
                            </button>
                        </li>
                    </ul>
                </div>
            </section>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel runat="server" id="UpdatePanel2" updatemode="Conditional">
                <ContentTemplate>
                    <section class="content-body">
                        <section class="info-body">
                            <div id="dvdmensajes" class="messages alert" runat="server">
                                <p>
                                    <label id="lblmensajeerror" runat="server"></label>    
                                </p>
                                <label id="close" for="hide-message" class="x-btn">&#10005</label>
                            </div> 
                            <div class="filter" >
                                <asp:TextBox ID="txtfiltrar" runat="server" class="filter-input" placeholder="Marca, Modelo, Placa, Motor, Chasis"/>
                                <button type="submit" class="filter-btn" id="btnfiltrar" runat="server">Filtrar</button>
                            </div>
                            <ASP:Repeater id="Rpt_renovacion" runat="server">
                            <ItemTemplate>              
                                <div class="table-data" id="tbl00" runat="server">
                                    <h2>
                                        <asp:Label ID="lblnombreitem0" text='<%# Eval("GRUPO_NOMBRE") %>' runat="server"/>
                                    </h2>
                                    <asp:Label ID="lblgrupoitem0" text='<%# Eval("CODIGO_VEHICULO") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                                    <table>
                                        <thead>
                                            <tr>
                                                <th>Servicios</th>
                                                <th>Años Renov.</th>
                                                <th>Precio sin IVA</th>
                                                <th>Cod.Promo.</th>
                                                <th class="ficha">Ficha</th>
                                                <th>
                                                    <input type="checkbox" name="">
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <ASP:Repeater id="Rpt_renovacion_items" runat="server">
                                            <ItemTemplate>                         
                                                <tr>
                                                    <td class="service">
                                                        <asp:Label ID="lblproductoitem0" text='<%# Eval("PRODUCTO_NOMBRE") %>' runat="server"/>
                                                        <asp:Label ID="lblproductocodigo0" text='<%# Eval("PRODUCTO") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                                                        <asp:Label ID="lblfechavencimiento0" text='<%# Eval("FECHA_FIN") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                    
                                                    </td>
                                                    <td>
                                                        <asp:dropdownlist class="select-css" id="cmbanticipado0" runat="server" OnSelectedIndexChanged="cmbaniorenovar_SelectedIndexChanged">
                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltotalitem0" text="0.00" runat="server"/>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblpromo0" text="" runat="server"/>
                                                    </td>
                                                    <td class="ficha">
                                                        <a id="hrefitem0" HREF='<%# Eval("PRODUCTO_LINK") %>' target="_blank" runat="server">
                                                            <img src="../images/img_mkt/ficha-icon.png" alt="Ficha Tecnica">
                                                        </a>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                    <td>
                                                        <asp:CheckBox id="chkitem00" runat="server" AutoPostBack="True" OnCheckedChanged="chkI_CheckedChanged"/>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            </ASP:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </ItemTemplate>
                            </ASP:Repeater>
                            <div class="info-pago">
                                <h1>
                                    Información de Pago
                                </h1>
                                <div class="tarjetas">
                                    <h4>
                                        Elija su Tarjeta
                                    </h4>
                                    <ul>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisorvisa" runat="server">
                                            <img src="../images/img_mkt/visa.png" alt="">
                                        </li>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisormastercard" runat="server">
                                            <img src="../images/img_mkt/master.png" alt="">
                                        </li>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisordiners" runat="server">
                                            <img src="../images/img_mkt/diners.png" alt="">
                                        </li>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisordiscover" runat="server">
                                            <img src="../images/img_mkt/discover.png" alt="">
                                        </li>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisoramerican" runat="server">
                                            <img src="../images/img_mkt/american.png" alt="">
                                        </li>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisortitanium" runat="server">
                                            <img src="../images/img_mkt/visatitanium.png" alt="">
                                        </li>
                                        <li>
                                            <input type="radio" name="tarjeta" id="chkemisorpacificard" runat="server">
                                            <img src="../images/img_mkt/pacificard.png" alt="">
    
                                        </li>
                                    </ul>
                                </div>
                                <div class="bco-tarjeta-select">
                                    <select class="select-css" id="cmbtipopago" name="combotipopago" runat="server" onChange="cmbtipopago_ServerChange(this, 'cmbtipopago')">
                                        <option value="0">
                                            Tipo de pago
                                        </option>
                                        <option value="1">
                                            Corriente
                                        </option>
                                        <option value="2">
                                            Diferido
                                        </option>
                                    </select>
                                </div>
                            </div>
                            <div class="table-data">
                                <table class="datos-factura">
                                    <thead>
                                        <tr>
                                            <th colspan="3">
                                                Datos para la Factura
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="service">
                                                <b>Nombre Completo</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFormaPagoNombre" runat="server" Text=""/>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="service">
                                                <b>No. Identificación</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFormaPagoIdentificacion" runat="server" Text=""/>
                                            </td>
                                            <td>
                                                <a href="#openModalidentificacion" id="hrefclientefac">
                                                    <img src="../images/img_mkt/search.png" alt="">
                                                </a>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="service">
                                                <b>Dirección</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFormaPagoDireccion" runat="server" Text=""/>
                                            </td>
                                            <td>
                                                <a href="#openModaldireccion">
                                                    <img src="../images/img_mkt/search.png" alt="">
                                                </a>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="service">
                                                <b>Teléfono</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFormaPagoTelefono" runat="server" Text=""/>
                                            </td>
                                            <td>
                                                <a href="#openModaltelefono">
                                                    <img src="../images/img_mkt/search.png" alt="">
                                                </a>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="service">
                                                <b>Celular</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFormaPagoCelular" runat="server" Text=""/>
                                            </td>
                                            <td>
                                                <a href="#openModalcelular">
                                                    <img src="../images/img_mkt/search.png" alt="">
                                                </a>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="service">
                                                <b>Email de Facturación</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtFormaPagoEmail" runat="server" Text=""/>
                                            </td>
                                            <td>
                                                <a href="#openModalemail">
                                                    <img src="../images/img_mkt/search.png" alt="">
                                                </a>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="total-pagar">
                                <p class="numero-orden">
                                    Número orden de pago: 
                                    <b>
                                        <asp:Label ID="lblnumeroorden" runat="server" Text="0">
                                        </asp:Label>
                                    </b>
                                </p>
                                <div class="total-container">
                                    <h2 class="header-container">
                                        Total a Pagar de su Compra
                                    </h2>
                                    <div class="body-container">
                                        <div class="body-container-text">
                                            <div class="services-number">
                                                <p>
                                                    Servicios<br/> Contratados
                                                </p>
                                                <p class="big-number">
                                                    <asp:Label ID="lblresumencantidad" runat="server" Text="0">
                                                    </asp:Label>
                                                </p>
                                            </div>
                                            <div class="table-total">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td class="detalle">
                                                                P. Unitario
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblresumentotal" runat="server" Text="0">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="separator-row">
                                                            <td class="detalle">
                                                                V. Promoción (-)
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblresumenpromocion" runat="server" Text="0">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="detalle">
                                                                SubTotal
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblresumensubtotal" runat="server" Text="0">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="separator-row">
                                                            <td class="detalle">
                                                                I.V.A
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblresumeniva" runat="server" Text="0">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="detalle">
                                                                Total a Pagar
                                                            </td>
                                                            <td class="valor-final">
                                                                <asp:Label ID="lblresumenpreciocliente" runat="server" Text="0">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="btn-pagar">
                                            <asp:button id="btnpagar" runat="server" class="btn-class" Text="Pagar">
                                                </asp:button>
                                        </div>
                                    </div>
                                </div>
                                <p class="aceptar-terminos">
                                    *** Al hacer click en pagar acepta nuestros <a href="#Terminos"> términos y condiciones</a>
                                </p>
                            </div>
                            <div class="info-servicios">
                                <h1>
                                    ConfirConfirme la información de sus servicios a renovar
                                </h1>
                                <div class="services-detail">
                                    <ASP:Repeater id="Rpt_resumen_renovacion" runat="server">
                                    <ItemTemplate>
                                        <div class="service-item">
                                            <p>
                                                <asp:Label ID="lblresumenvehiculo" runat="server" Text='<%# Eval("VEHICULO_NOMBRE") %>'>
                                                </asp:Label>
                                            </p>
                                            <ul>
                                                <ASP:Repeater id="Rpt_resumen_renovacion_itm" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:Label ID="lblresumenvehiculogrupo" runat="server" Text='<%# Eval("GRUPO_DESCRIPCION") %>'>
                                                        </asp:Label>
                                                    </li>
                                                </ItemTemplate>
                                                </ASP:Repeater>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                    </ASP:Repeater>
                                </div>
                            </div>
                        </section>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="openModalidentificacion" class="modalDialog">
                <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
                    <ContentTemplate>
		                <div>
                            <a href="#close" title="Close" class="close">X</a>
		                    <h2 class="titulo-section">
                                Seleccione o Registre el Cliente para facturación
                            </h2>
                            <div class="table-data">
                                <div class="top-tabla-options">
                                    <div class="search-client">
                                        <input type="text" placeholder="Busqueda general" id="txtbusquedaclientefac" runat="server">
                                    </div>
                                    <button class="cliente-nuevo-fact" id="btnnuevoclientefac" runat="server" >
                                        <img src="../images/img_mkt/add_circle_outline.png" alt="">
                                        AGREGAR USUARIO
                                    </button>
                            
                                </div>
                                <div class="messages ">
                                    <label id="Label7" runat="server"></label> 
                                </div>
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Id.Cliente</th>
                                            <th>Nombres y Apellidos</th>
                                            <th>Fecha Nacimiento</th>
                                            <th>Oficina</th>
                                            <th>Seleccionar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <ASP:Repeater id="Rptclientesfac" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcodigoclientesfac" text='<%# Eval("ID_CLIENTE")%>' runat="server"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnombreclientesfac" text='<%# Eval("PRIMER_NOMBRE") + " " + Eval("SEGUNDO_NOMBRE") + " " + Eval("APELLIDO_PATERNO") + " " +Eval("APELLIDO_MATERNO")%>' runat="server"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblfechaclientesfac" text='<%# Eval("FECHA_NACIMIENTO")%>' runat="server"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbloficinaclientesfac" text='<%# Eval("OFICINA")%>' runat="server"/>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_rpt_cliente_fac" runat="server" Text="..." OnClick="clk_rpt_clientefac" />
                                                </td>
                                            </tr>
                                    </ItemTemplate>
                                    </ASP:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <div class="add-cliente-form">
                                <div class="add-cliente-datos">
                                    <h2>
                                        Ingreso de datos de cliente
                                    </h2>
                                    <div class="select-item">
                                        <label for="tipo-identificacion">Tipo de Identificación</label>
                                        <asp:DropDownList ID="cmbcedulaclientefac" runat="server" AutoPostBack="true" class="select-css"/>
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
                                        <asp:TextBox ID="txtfechanacimientoclientefac" runat="server" TextMode="Date" class="input-style">
                                        </asp:TextBox>
                                    </div>
                                    <div class="select-item">
                                        <label for="sexo">Sexo</label>
                                        <asp:DropDownList ID="cmbsexoclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                                    </div>
                                </div>
                                <div class="separator"></div>
                                <div class="add-cliente-direccion">
                                    <h2>
                                        Ingreso de dirección de domicilio
                                    </h2>
                                    <div class="select-item">
                                        <label for="provincia">Provincia</label>
                                        <asp:DropDownList ID="cmbprovinciaclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                                    </div>
                                    <div class="select-item">
                                        <label for="ciudad">Ciudad</label>
                                        <asp:DropDownList ID="cmbciudadclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                                    </div>
                                    <div class="select-item">
                                        <label for="parroquia">Parroquia</label>
                                        <asp:DropDownList ID="cmbparroquiaclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                                    </div>
                                    <div class="select-item">
                                        <label for="sector">Sector</label>
                                        <asp:DropDownList ID="cmbsectorclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                                    </div>
                                    <div class="add-cliente-input span-item">
                                        <label for="direccion">
                                            Direccion
                                        </label>
                                        <input type="text" id="txtdireccionclientefac" runat="server">
                                    </div>
                                    <div class="span-item inputs-group">
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
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="openModaldireccion" class="modalDialog">
                <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione dirección para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo direccion</th>
                                    <th>Ciudad</th>
                                    <th>Direccion</th>
                                    <th>Interseccion</th>
                                    <th>Número</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rptdireccionfac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipodireccionfac" text='<%# Eval("TIPO_DIRECCION_NOMBRE")%>' runat="server" Visible="false"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblciudadfac" text='<%# Eval("CIUDAD_NOMBRE")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldireccionfac" text='<%# Eval("PRINCIPAL_MANZANA")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblinterseccionfac" text='<%# Eval("INTERSECCION")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblnumerofac" text='<%# Eval("NUMERO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_rpt_direccion_fac" runat="server" Text="..." OnClick="clk_rpt_direccionfac" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="openModaltelefono" class="modalDialog">
		        <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione teléfono para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Número</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rpttelefonofac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipotelefonofac" text='<%# Eval("TIPO_TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltelefonofac" text='<%# Eval("TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_rpt_telefono_fac" runat="server" Text="..." OnClick="clk_rpt_telefonofac" />
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="openModalcelular" class="modalDialog">
		        <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione celular para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Numero</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rptcelularfac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipocelularfac" text='<%# Eval("TIPO_TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblcelularfac" text='<%# Eval("TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_rpt_celular_fac" runat="server" Text="..." OnClick="clk_rpt_celularfac" />
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="openModalemail" class="modalDialog">
		        <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione email para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Email</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rptemailfac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipoemailfac" text='<%# Eval("TIPO")%>' runat="server" Visible="true"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblemailfac" text='<%# Eval("EMAIL")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="..." OnClick="clk_rpt_emailfac" />
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="Terminos" class="modalDialog">
                <div >
		            <a href="#close" title="Close" class="close">X                    <h2 class="tituloh2">
                        ACUERDO SOBRE T&Eacute;RMINOS DE USO Y POL&Iacute;TICAS DE PRIVACIDAD
                    </h2>
                    <div id="divterminos" runat="server" style="text-align:justify; font-size:small; color:Black;">
                        El presente acuerdo contiene los t&eacute;rminos y condiciones generales, aplicables al uso de los 
                        servicios ofrecidos por Carro Seguro Carseg S.A. (en adelante Carseg), dentro de su sitio 
                        <b style="font-style: italic; font-weight: bold">www.HunterOnline.com.ec</b> (en adelante el sitio).&nbsp;
                        <br /><br />
                        Cualquier persona que desee acceder y/o usar el sitio o los servicios de &eacute;ste, podr&aacute; 
                        hacerlo siempre que se sujete a los t&eacute;rminos y condiciones aqu&iacute;	")
                        contenidas, junto con las dem&aacute;s pol&iacute;ticas y principios que rigen el sitio; por tanto, 
                        quien no acepte estos t&eacute;rminos y condiciones generales,	")
                        que tienen car&aacute;cter obligatorio y vinculante, deber&aacute; abstenerse de utilizar el sitio y/o los 
                        servicios.
                        <br /><br />
                        El Usuario debe leer, entender y aceptar todas las condiciones establecidas en el presente instrumento, 
                        as&iacute; como en los dem&aacute;s documentos incorporados por referencia, previa a su 
                        inscripci&oacute;n como usuario de Carseg.&nbsp;
                        <br /><br />
                        1. Los servicios de Carseg s&oacute;lo est&aacute;n disponibles para personas que tengan capacidad legal 
                        para contratar; por tanto, no deben ser utilizados por menores de edad, personas que no tengan esa 
                        capacidad o aquellas que hayan sido suspendidas o dadas de baja del sistema de Carseg, temporal o 
                        definitivamente, por haber incumplido las disposiciones del presente instrumento, o por haber incurrido 
                        a criterio de Carseg, en conductas o actos dolosos o fraudulentos, mediante el uso del sitio o
                        de los servicios. Si usted est&aacute; inscribiendo un usuario como persona jur&iacute;dica, debe tener 
                        capacidad para contratar a nombre de la misma, y de obligar a &eacute;sta en los t&eacute;rminos de este 
                        acuerdo.&nbsp;
                        <br /><br />
                        2. El usuario se obliga a completar el formulario de inscripci&oacute;n en todos
                        sus campos, para poder utilizar los servicios que brinda Carseg El usuario se obliga
                        a consignar su informaci&oacute;n personal de manera exacta, precisa y verdadera,
                        y asume el compromiso de actualizar sus datos personales cuando sea necesario. Carseg
                        podr&aacute; utilizar diversos medios para identificar a sus usuarios, pero Carseg
                        no se responsabiliza por la certeza de los datos personales provistos por sus usuarios.
                        En consecuencia, los usuarios garantizan y responden, en cualquier caso, de la veracidad,
                        exactitud, vigencia y autenticidad de los datos personales ingresados.&nbsp;
                        <br /><br />
                        3. El usuario acceder&aacute; a su cuenta personal en el sitio, mediante el ingreso
                        de &hellip; y una clave de seguridad personal elegida por &eacute;ste. El usuario
                        de <b style=""font-style: italic; font-weight: bold"">Cédula</b> o  
                        <b style=""font-style: italic; font-weight: bold"">Ruc</b> y una clave de seguridad personal elegida 
                        por &eacute;ste. El usuario se obliga a mantener la confidencialidad de su clave de seguridad. 
                        El usuario ser&aacute; responsable por todas las operaciones efectuadas en su cuenta, pues el acceso a
                        la misma est&aacute; restringido al ingreso y uso de su clave de seguridad, de conocimiento
                        exclusivo del usuario. El usuario se compromete a notificar a Carseg, en forma inmediata
                        y por medio id&oacute;neo y fehaciente, cualquier uso no autorizado de su cuenta,
                        as&iacute; como el ingreso por terceros no autorizados a la misma.&nbsp;
                        <br /><br />
                        4. Carseg no vender&aacute;, alquilar&aacute; ni negociar&aacute; con otras empresas
                        los datos personales de sus usuarios, salvo su autorizaci&oacute;n en contrario.
                        Estos datos ser&aacute;n usados por Carseg, &uacute;nicamente para perfeccionar
                        la transacci&oacute;n. La informaci&oacute;n personal de los usuarios se procesa
                        y almacena en servidores o medios magn&eacute;ticos que mantienen altos est&aacute;ndares
                        de seguridad y protecci&oacute;n tanto f&iacute;sica como tecnol&oacute;gica.&nbsp;
                        <br /><br />
                        5. Carseg no se responsabiliza del entendimiento, interpretaci&oacute;n y/o uso	
                        del contenido del sitio por parte de sus usuarios; por tanto, el uso de la informaci&oacute;n	
                        es responsabilidad exclusiva del usuario. Carseg se reserva la facultad de modificar	
                        el contenido y/o servicio por s&iacute; mismo o mediante un tercero autorizado,	
                        sin que est&eacute; obligado a notificar previamente al usuario.&nbsp;	
                        <br /><br />
                        6. Carseg no garantiza el acceso permanente e ininterrumpido al sitio, ni que el	
                        servicio o servidor est&eacute; libre de virus. El usuario debe tomar las medidas	
                        necesarias para evitar los efectos del mismo.&nbsp;	
                        <br /><br />
                        7. No est&aacute; permitido el uso de ning&uacute;n dispositivo, software u otro	
                        medio tendiente a interferir tanto en las actividades y operatividad del sitio de	
                        Carseg, como en las ofertas o en las bases de datos de Carseg. Cualquier intromisi&oacute;n,	
                        tentativa o actividad violatoria o contraria a las leyes sobre derecho de autor	
                        y/o a las prohibiciones estipuladas en este documento, facultar&aacute;n a Carseg	
                        el inicio de las acciones legales pertinentes; la imposici&oacute;n de las sanciones	
                        previstas por este acuerdo; y, demandar una indemnizaci&oacute;n por los da&ntilde;os	
                        y perjuicios irrogados.&nbsp;	
                        <br /><br />
                        8. En cualquier momento Carseg podr&aacute; advertir, suspender o cancelar, temporal	
                        o definitivamente la cuenta de un usuario o una transacci&oacute;n, e iniciar las	
                        acciones que estime pertinentes, si se quebrantara alguna ley, o cualquiera de las	
                        estipulaciones de este acuerdo, o si se incurriera a criterio de Carseg en conductas	
                        o actos dolosos o fraudulentos, o, si no pudiera verificarse la identidad del usuario,	
                        o cualquier informaci&oacute;n proporcionada por el mismo fuere err&oacute;nea.	
                        En caso de suspensi&oacute;n o inhabilitaci&oacute;n de un usuario, todas las transacciones	
                        u operaciones del usuario ser&aacute;n removidas del sistema.&nbsp;	
                        <br /><br />
                        9. Carseg se reserva el derecho de cancelar la cuenta del usuario que hubiere incumplido	
                        sus obligaciones derivadas de una transacci&oacute;n, o si se detectara en su conducta	
                        intencionalidad de perjudicar o defraudar a otros usuarios.&nbsp;	
                        <br /><br />
                        10. Carseg se reserva el derecho a cancelar una transacci&oacute;n por razones no	
                        mencionadas anteriormente, o si considera que el usuario ha incurrido en alg&uacute;n	
                        error involuntario, o por cualquier otra raz&oacute;n que Carseg considere justificada.&nbsp;	
                        <br /><br />
                        11. Carseg emitirá el comprobante de venta, únicamente con los datos registrados por el usuario en 
                        el formulario de inscripción.
                        <br /><br />
                        12. Carseg podr&aacute; modificar en cualquier momento los t&eacute;rminos y condiciones	
                        de este acuerdo, y notificar&aacute; los cambios al usuario, publicando una versi&oacute;n	
                        actualizada de dichos t&eacute;rminos y condiciones en el sitio, con expresi&oacute;n	
                        de la fecha de la &uacute;ltima modificaci&oacute;n. Dentro de los 5 d&iacute;as	
                        siguientes a la publicaci&oacute;n de las modificaciones introducidas, el usuario	
                        deber&aacute; comunicar por e-mail a <b style=""font-style: italic; font-weight: bold"">
                        SoporteHunterOnline@carsegsa.com</b>, si no acepta las mismas; en ese caso	
                        quedar&aacute; disuelto el v&iacute;nculo contractual y ser&aacute; inhabilitado	
                        como usuario. Vencido este plazo, se considerar&aacute; que el usuario acepta los	
                        nuevos t&eacute;rminos y el acuerdo continuar&aacute; vinculando a ambas partes.&nbsp;	
                        <br /><br />
                        13. El usuario autoriza expresamente a Carseg, a enviarle al correo electrónico registrado o vía 
                        SMS al número celular registrado, información referente a sus productos o servicios, promociones y 
                        avisos de interés.
                        <br /><br />
                        14. Se fija como domicilio de <b style="font-style: italic; font-weight: bold">Carseg Cdla.Vernaza 
                        Norte Mz.21 Solar 2,6,7 y 8</b>, Guayaquil, Ecuador. En caso de dudas	
                        sobre el presente acuerdo, y dem&aacute;s pol&iacute;ticas y principios que rigen	
                        el sitio, el usuario deberá comunicar por e-mail a <b style="font-style: italic; font-weight: bold">
                        SoporteHunterOnline@carsegsa.com</b>
    
                    </div>
                </div>
            </div>   
        </form>
    </section>
    <script type="text/javascript">
        function ShowPopup() {
            var x = document.getElementById("hrefclientefac");
            x.click();
        }
    </script> 
</body>
</html>