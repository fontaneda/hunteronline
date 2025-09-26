<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="pagogeneralink.aspx.vb" Inherits="ExtranetWeb.pagogeneralink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Link de pagos</title>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" action="#" runat="server">
        <section class="content-body">
            <section class="info-body"> 
                <div id="dvdmensajes" class="messages alert" runat="server">
                    <p>
                        <label id="lblmensajeerror" runat="server"></label>    
                    </p>
                    <label id="close" for="hide-message" class="x-btn">&#10005</label>
                </div> 
                <div class="info-pago mt-0 mt-2">
                    <h1>
                        Información del cliente a generar pago
                    </h1>
                </div>
                <div class="table-data" style="width:800px;">
                    <table class="datos-factura">
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
                                    <%--<a href="#openModalidentificacion" id="hrefclientefac">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="service">
                                    <b>Email</b>
                                </td>
                                <td>
                                    <asp:Label ID="txtFormaPagoEmail" runat="server" Text=""/>
                                </td>
                                <td>
                                    <a href="#openModalemail">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="info-pago mt-0 mt-2">
                    <h1>
                        Información del pago
                    </h1>
                </div>
                <div class="bco-tarjeta-select">
                    <select class="select-css" id="cmbtipopago" name="combotipopago" runat="server" onChange="cmbtipopago_ServerChange(this, 'cmbtipopago')">
                        <option value="0">
                            Tipo de pago
                        </option>
                        <option value="1">
                            Cobro
                        </option>
                        <option value="2">
                            Renovacion
                        </option>
                    </select>
                </div>
                <div class="bco-tarjeta-select">
                    <select class="select-css" id="cmbtipotarjeta" name="cmbtipotarjeta" runat="server">
                        <option value="0">
                            Tarjeta
                        </option>
                        <option value="1">
                            Visa
                        </option>
                        <option value="2">
                            Mastercard
                        </option>
                        <option value="3">
                            Diners/Discover/Titanium
                        </option>
                        <option value="4">
                            Pichincha/American
                        </option>
                        <option value="5">
                            Pacificard
                        </option>
                    </select>
                </div>
                <div class="bco-tarjeta-select">
                    <select class="select-css" id="cmbvehiculo" name="cmbvehiculo" runat="server">
                        <option value="0">
                            Escoja el vehículo a renovar
                        </option>
                    </select>
                </div>
                <div class="bco-tarjeta-select">
                    <select class="select-css" id="cmbanio" name="cmbvehiculo" runat="server">
                        <option value="0">
                            Escoja años a renovar
                        </option>
                        <option value="1">
                            1
                        </option>
                        <option value="2">
                            2
                        </option>
                        <option value="3">
                            3
                        </option>
                        <option value="4">
                            4
                        </option>
                        <option value="5">
                            5
                        </option>
                    </select>
                </div>
                <div class="bco-tarjeta-select">
                    <div class="table-total">
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtmontodescr" runat="server" class="txt-css-clase" Width="175px" Text=" Valor de la transaccion">
                                        </asp:TextBox>
                                       
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtmonto" runat="server" class="txt-css-clase" Width="150px" Text="" placeholder="$ 0.00">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="total-pagar">
                    <div class="total-container">
                        <div class="btn-pagar">
                            <asp:button id="btnpagar" runat="server" class="btn-class" Text="Generar link de pagos">
                            </asp:button>
                        </div>
                    </div>
                </div>
            </section>
        </section>
        <div id="openModalidentificacion" class="modalDialog">
            <div>
                <a href="#close" title="Close" class="close">X</a>
                <h2 class="titulo-section">
                    Seleccione el Cliente de la transaccion
                </h2>
                <div class="table-data">
                    <div class="top-tabla-options">
                        <div class="search-client">
                            <input type="text" placeholder="Busqueda general" id="txtbusquedaclientefac" runat="server">
                        </div>
                        <button class="cliente-nuevo-fact" id="btnbuscacliente" runat="server" disabled >
                            <img src="../images/img_mkt/search.png" alt="">
                        </button>
                    </div>
                    <div class="messages ">
                        <label id="lblmensajeerrormodal" runat="server"></label> 
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
                                        <asp:Label ID="lbltipoemailfac" text='<%# Eval("ID")%>' runat="server" Visible="true"/>
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
    </form>
</asp:Content>
