<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="Ventas.aspx.vb" Inherits="ExtranetWeb.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Ventas</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" action="#" runat="server">
        <section class="info-body"> 
            <div id="dvdmensajes" class="messages alert" runat="server">
                <p>
                    <label id="lblmensajeerror" runat="server"></label>    
                </p>
                <label id="close" for="hide-message" class="x-btn">&#10005</label>
            </div>                     
            <ul class="steps">
                <li>
                    <div class="circle current">
                        1
                    </div>
                    <p class="current">
                        Seleccionar<br/> Producto
                    </p>
                </li>
                <li class="separator"></li>
                <li>
                    <div class="circle">
                        2
                    </div>
                    <p>
                        Datos de<br/> Factura
                    </p>
                </li>
                <li class="separator"></li>
                <li>
                    <div class="circle">
                        3
                    </div>
                    <p>
                        Confirmar<br/> Pedido
                    </p>
                </li>
            </ul>
            <div class="filter" >
                    <asp:TextBox ID="txtfiltrar" runat="server" class="filter-input" placeholder="Marca, Modelo, Placa, Motor, Chasis"/>
                    <button type="submit" class="filter-btn" id="btnfiltrar" runat="server">Filtrar</button>
                    <button type="submit" class="filter-btn" style="background-color:Red" id="btncrearvehiculo" runat="server">Nuevo Vehiculo</button>
            </div>
            <ASP:Repeater id="Rpt_venta" runat="server" >
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
                                <th>Precio sin IVA</th>
                                <th>Cod.Promo.</th>
                                <th class="ficha">Ficha</th>
                                <th>
                                    <input type="checkbox" name="chktitem0">
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <ASP:Repeater id="Rpt_venta_items" runat="server">
                            <ItemTemplate>                         
                                <tr>
                                    <td class="service">
                                        <asp:Label ID="lblproductoitem0" text='<%# Eval("GRUPO_DESCRIPCION") %>' runat="server"/>
                                        <asp:Label ID="lblproductocodigo0" text='<%# Eval("GRUPO") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                                        <asp:Label ID="lblproductoprecio0" text='<%# Eval("PRECIO_VENTA") %>' runat="server" Visible="false" ForeColor="Transparent"/>
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
                                    </td>
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
            <button class="btn-class btn-next" type="submit" id="btncontinuar" runat="server">
                continuar
            </button>
        </section>
    </form>
</asp:Content>