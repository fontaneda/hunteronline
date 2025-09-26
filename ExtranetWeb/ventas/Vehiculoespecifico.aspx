<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="Vehiculoespecifico.aspx.vb" Inherits="ExtranetWeb.Vehiculoespecifico" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Pagos de Servicios Online</title>
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
            <div class="cuenta-datos-item" id="secciondatospersonales" runat="server">
                <div class="cuenta-item-top">
                    <h2>
                        Vehículo a actualizar
                    </h2>
                    <asp:Button class="btn-grabar" id="btngrabardatos" runat="server" Text="Grabar" />
                    <asp:Button class="btn-retroceder" id="btncancelar" runat="server" Text="Regresar" />
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Codigo</h4>
                                <p>
                                    <asp:Label ID="lblveh_codigo" runat="server" />
                                </p>
                            </li>
                            <li>
                                <h4>Motor</h4>
                                <p>
                                    <asp:Label ID="lblveh_motor" runat="server" />
                                </p>
                            </li>
                            <li>
                                <h4>Chasis</h4>
                                <p>
                                    <asp:Label ID="lblveh_chasis" runat="server" />
                                </p>
                            </li>
                            <li>
                                <h4>Placa</h4>
                                <p>
                                    <asp:TextBox ID="txtveh_placa" runat="server" Width="250px" class="input-style">
                                    </asp:TextBox>
                                </p>
                            </li>
                            <li>
                                <h4>Aseguradora</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_aseguradora" runat="server" AutoPostBack="true" class="input-style" Width="250"/>
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Marca</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_marca" runat="server" AutoPostBack="true" class="input-style" Enabled="false"/>
                                </p>
                            </li>
                            <li>
                                <h4>Modelo</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_modelo" runat="server" AutoPostBack="true" class="input-style" Width="250" Enabled="false"/>
                                </p>
                            </li>
                            <li>
                                <h4>Año</h4>
                                <p>
                                    <asp:TextBox ID="txtveh_anio" runat="server" Width="250px" class="input-style">
                                    </asp:TextBox>
                                </p>
                            </li>
                            <li>
                                <h4>Color</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_color" runat="server" AutoPostBack="true" class="input-style"/>
                                </p>
                            </li>
                        </ul>
                       
                    </div>
                     <div class="item-check">
                        <p>
                            * Estimado cliente, para modificar datos de motor y chasis, debe comunicarse con su ejecutiva.
                        </p>
                    </div>
                </div>
            </div>
            <div class="cuenta-datos-item" style="visibility:hidden;">
                <div class="cuenta-item-top">
                    <h2>
                        
                    </h2>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container" >
                        <ul>
                            <li>
                                <h4>Nuevo propietario</h4>
                                <p>
                                    <asp:TextBox ID="txtveh_nuevopropietario" runat="server" Width="250px" class="input-style" Text="">
                                    </asp:TextBox>
                                </p>
                            </li>
                        </ul>
                        <ul>
                           <li>
                                <h4>Celular</h4>
                                <p>
                                    <asp:TextBox ID="txtveh_celular" runat="server" Width="250px" class="input-style" Text="">
                                    </asp:TextBox>
                                </p>
                            </li>
                        </ul>
                    </div>

                    <div class="item-check">
                        <asp:CheckBox ID="chkveh_cambiopropietario" runat="server" Text=""
                                Enabled="true" GroupName="grpcambiopropietario" AutoPostBack="true" />
                        <p>
                            Marque si el vehiculo ya no le pertenece
                        </p>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
