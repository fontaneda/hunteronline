<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="vehiculochequeo.aspx.vb" Inherits="ExtranetWeb.vehiculochequeo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Bienes Protegidos</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="grey-back">
    <form id="Form1" action="#" runat="server">
        <section class="info-body"> 
            <div id="dvdmensajes" class="messages alert" runat="server">
                <p>
                    <label id="lblmensajeerror" runat="server"></label>    
                </p>
                <label id="close" for="hide-message" class="x-btn">&#10005</label>
            </div>                   
            <div class="cuenta-datos-item" runat="server">
                <div class="cuenta-item-top">
                    <h2>
                        Vehículo: 
                        <asp:Label ID="lblvehiculochk" text='' runat="server"/>
                    </h2>
                    <asp:Button class="btn-retroceder" id="btnregresar" runat="server" Text="Atras" />
                </div>
            </div>
            <div class="transacciones">
                <div class="cuenta-item-top">
                    <h2>
                        Productos del vehículo
                    </h2>
                </div>
                <table class="table-transacciones" >
                    <thead>
                        <tr>
                            <th>Producto</th>
                            <th>Fecha vcmto.</th>
                            <th>Cliente/servicio</th>
                            <th>Estado</th>
                           <%-- <th>Seleccionar</th>--%>
                        </tr>
                    </thead>
                    <tbody>
                        <ASP:Repeater id="Rpt_productos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblproductonombreitm" text='<%# Eval("GrupoProducto")%>' runat="server"/>
                                </td>
                                <td>
                                    <asp:Label ID="lblfechaitm" text='<%# Eval("CoberturaFinal")%>' runat="server"/>
                                </td>
                                <td>
                                    <asp:Label ID="lblclienteitm" text='<%# Eval("Cliente")%>' runat="server"/>
                                </td>
                                <td>
                                    <asp:Label ID="lblestadoitm" text='<%# Eval("Estado")%>' runat="server"/>
                                </td>
                               <%--<td>
                                    <asp:Button ID="btn_rpt_item_det" runat="server" Text="..." OnClick="clk_rpt_item" />
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                        </ASP:Repeater>
                    </tbody>
                </table>
                <div class="cuenta-item-top">
                    <h2>
                        Ultimos chequeos realizados
                    </h2>
                </div>
                <table class="table-transacciones">
                    <thead>
                        <tr>
                            <th>Producto</th>
                            <th>Fecha chequeo</th>
                            <th>Orden / trabajo</th>
                            <th>Sucursal</th>
                        </tr>
                    </thead>
                    <tbody>
                        <ASP:Repeater id="Rpt_chequeos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>'<%# Eval("Producto")%>'</td>
                                <td>'<%# Eval("FechaOt")%>'</td>
                                <td>'<%# Eval("Ot")%>'</td>
                                <td>'<%# Eval("TallerOt")%>'</td>
                            </tr>
                        </ItemTemplate>
                        </ASP:Repeater>
                    </tbody>
                </table>
            </div>
        </section>
    </form>
</asp:Content>
