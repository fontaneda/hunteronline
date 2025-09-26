<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="CreacionNuevoVehiculo.aspx.vb" Inherits="ExtranetWeb.CreacionNuevoVehiculo" %>
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
                                    <asp:Label ID="lblveh_codigo" runat="server" Enabled="false" />
                                </p>
                            </li>
                            <li>
                                <h4>Motor</h4>
                                <p>
                                    <asp:TextBox ID="txtveh_motor" runat="server" Width="250px" class="input-style">
                                    </asp:TextBox>
                                </p>
                            </li>
                            <li>
                                <h4>Chasis</h4>
                                <p>
                                    <asp:TextBox ID="txtveh_chasis" runat="server" Width="250px" class="input-style">
                                    </asp:TextBox>
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
                                <h4>Año</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_anio" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Color</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_color" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Aire Acondicionado</h4>
                                <p>
                                    <%--<asp:DropDownList ID="cmbveh_aire" runat="server" class="input-style" Width="250"/>--%>
                                    <asp:RadioButton ID="chkveh_airesi" runat="server" Text="Si"
                                        Enabled="true" GroupName="vehaire" AutoPostBack="false" />
                                    <asp:RadioButton ID="chkveh_aireno" runat="server" Text="No"
                                        Enabled="true" GroupName="vehaire" AutoPostBack="false" />
                                </p>
                            </li>
                            <li>
                                <h4>Aseguradora</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_aseguradora" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Financiera</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_financiera" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Concesionario</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_concesionario" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Marca</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_marca" runat="server" AutoPostBack="true" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Modelo</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_modelo" runat="server" AutoPostBack="true" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Tipo de vehículo</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_tipo" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Versión</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_version" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Puertas</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_puertas" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Transmisión</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_transmision" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Tracción</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_traccion" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Cilindraje</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_cilindraje" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Combustible</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_combustible" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                            <li>
                                <h4>Tipo de cabina</h4>
                                <p>
                                    <asp:DropDownList ID="cmbveh_cabina" runat="server" class="input-style" Width="250"/>
                                </p>
                            </li>
                        </ul>
                       
                    </div>
                     <div class="item-check">
                        <p>
                            
                        </p>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
