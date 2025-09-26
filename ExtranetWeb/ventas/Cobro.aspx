<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="Cobro.aspx.vb" Inherits="ExtranetWeb.Cobro" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Cobros</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
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
            <div class="transacciones">
                <%--<div class="filter-date">
                    <label for="sucursal">Sucursal / No. Factura</label>
                    <asp:TextBox ID="txtfiltrar" runat="server" class="input-style" />
                </div>
                <div class="filter-date">
                    <label for="desde">
                        desde
                    </label>
                    <asp:TextBox ID="txtdesdemtr" runat="server" TextMode="Date" class="input-style">
                    </asp:TextBox>
                    <label for="hasta">
                        hasta
                    </label>
                    <asp:TextBox ID="txthastamtr" runat="server" TextMode="Date" class="input-style">
                    </asp:TextBox>
                </div>
                <button class="btn-class btn-next mt-2" type="submit" id="btnfiltro" runat="server">
                    Buscar
                </button>--%>
                <table class="table-cobros mt-4">
                    <thead>
                        <tr>
                            <th>Número</th>
                            <th>Total</th>
                            <th>Pagado</th>
                            <th>Saldo</th>
                        </tr>
                    </thead>
                    <tbody>
                        <ASP:Repeater id="Rpt_cobros" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("internarlidcli")%></td>
                                <td><%# Eval("importetotal")%></td>
                                <td><%# Eval("importepagado")%></td>
                                <td><%# Eval("importeporpagar")%></td>
                            </tr>
                        </ItemTemplate>
                        </ASP:Repeater>
                    </tbody>
                </table>
            </div>    
            <div class="separator"></div>    
            <div class="info-pago mt-0 mt-2">
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
            <div class="total-pagar">
                <div class="total-container">
                    <h2 class="header-container">
                        Total a Pagar de su Compra
                    </h2>
                    <div class="body-container">
                        <div class="body-container-text">
                            <div class="services-number">
                                <p>
                                    Deuda Total
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
                                                Monto Abonar
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtmonto" runat="server" Text="" placeholder="$ 0.00">
                                                </asp:TextBox>
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
                        <div class="btn-pagar">
                            <asp:button id="btnlink" runat="server" class="btn-class" Text="Generar link de pago">
                            </asp:button>
                        </div>
                        <div class="btn-pagar">
                            <asp:TextBox ID="txtlinkpago" runat="server" Text="" onfocus="this.select();" ReadOnly="true" Visible="false" Width="100%" Height="20px" TextMode="Url">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <p class="aceptar-terminos">
                *** Al hacer click en pagar acepta nuestros <a href="#"> términos y condiciones</a>
            </p>
            <p class="aceptar-terminos">
                *** Su valor abonado se verá reflejado en 
                <a style="color:Red;">
                    24 horas hábiles 
                </a>
            </p>
            <p class="aceptar-terminos">
                *** Estimado cliente, los valores indicados,  
                <a style="color:Red;">
                    ya incluyen I.V.A.
                </a>
            </p>
        </section> 
    </section>
    </form>
</asp:Content>

