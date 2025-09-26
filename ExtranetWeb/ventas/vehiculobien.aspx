<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="vehiculobien.aspx.vb" Inherits="ExtranetWeb.vehiculobien" %>
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
            <div class="bienes-selection">
                <ul>
                    <li>
                        <a class="btn-class btn-disable" href="vehiculo.aspx">
                            Vehiculos
                        </a>
                    </li>
                    <li>
                        <a class="btn-class btn-red current-biene" href="#">
                            Otros Bienes
                        </a>
                    </li>
                </ul>
            </div>
            <div class="search-bienes">
                <input type="text" placeholder="Busqueda de bienes" id="txtfiltroveh" runat="server">
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
                                <asp:Label ID="lblplacaveh" text='<%# Eval("Placa") %>' runat="server"/>
                            </p>
                        </div>
                        <p class="item-desc">
                            <b>
                                <asp:Label ID="lblmarcaveh" text='<%# Eval("Marca") %>' runat="server"/>
                            </b>
                            <br/> 
                            <asp:Label ID="lblmodeloveh" text='<%# Eval("Modelo") %>' runat="server"/>
                            <br/> 
                            <asp:Label ID="lblanioveh" text='<%# Eval("Anio") %>' runat="server"/>
                            <asp:Label ID="lblcodigo" text='<%# Eval("CodigoVehiculo") %>' runat="server" Visible="false"/>
                        </p>
                        <ul>
                            <li>
                                <h4>Chasis:</h4>
                                <p>
                                    <asp:Label ID="lblchasisveh" text='<%# Eval("Chasis") %>' runat="server"/>
                                </p>
                            </li>
                            <li>
                                <h4>Motor:</h4>
                                <p>
                                    <asp:Label ID="lblmotorveh" text='<%# Eval("Motor") %>' runat="server"/>
                                </p>
                            </li>
                            <li>
                                <h4>Último chequeo:</h4>
                                <p>
                                    <asp:Label ID="lblultimochequeveh" text='' runat="server"/>
                                </p>
                            </li>
                        </ul>
                    </div>
                    <nav>
                        <ul>
                            <li>
                                <asp:ImageButton ID="btn_rpt_item_det" ImageUrl="../images/img_mkt/edit-24px 1.png"  AlternateText="" runat="server" OnClick="clk_rpt_item_det" ToolTip="Editar datos"/>
                            </li>
                            <li>
                                <asp:ImageButton ID="btn_rpt_item_chk" ImageUrl="../images/img_mkt/chequeos-icon.png"  AlternateText="" runat="server" OnClick="clk_rpt_item_chk" ToolTip="Consulta chequeos"/>
                            </li>
                            <li>
                                <asp:ImageButton ID="btn_rpt_item_tur" ImageUrl="../images/img_mkt/chequeos-icon-1.png"  AlternateText="" runat="server" OnClick="clk_rpt_item_tur" ToolTip="Generar turno"/>
                            </li>
                        </ul>
                    </nav>
                </div>
            </ItemTemplate>
            </ASP:Repeater>
        </section>
    </form>
</asp:Content>