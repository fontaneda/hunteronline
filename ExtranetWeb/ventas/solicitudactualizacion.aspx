<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="solicitudactualizacion.aspx.vb" Inherits="ExtranetWeb.solicitudactualizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Mi Cuenta</title>
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
                        Datos Personales
                    </h2>
                    <asp:Button class="btn-grabar" id="btngrabardatos" runat="server" Text="Grabar" />
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Identificación</h4>
                                <p>
                                    <asp:Label ID="lbldtp_identificacion" runat="server" />
                                </p>
                            </li>
                            <li>
                                <h4>Nombres</h4>
                                <p>
                                    <asp:Label ID="lbldtp_nombres" runat="server"></asp:Label>
                                </p>
                            </li>
                            <li>
                                <h4>
                                    <asp:Label ID="labeldtp_fechanacimiento" runat="server" Text="Fecha de Nacimiento" />
                                </h4>
                                <p  runat="server" >
                                    <asp:TextBox ID="txtdtp_fechanac01" runat="server" TextMode="Date" class="input-style" Enabled="false" ></asp:TextBox>
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>E-mail</h4>
                                <p>
                                    <asp:TextBox ID="txtdtp_email01" runat="server" class="input-style" Enabled="false" >
                                    </asp:TextBox>
                                </p>
                            </li>
                            <li>
                                <h4>E-mail Oficina</h4>
                                <p>
                                    <asp:TextBox ID="txtdtp_email02" runat="server" class="input-style" Enabled="false" >
                                    </asp:TextBox>
                                </p>
                            </li>
                            <li>
                                <h4>E-mai Registro</h4>
                                <p>
                                    <asp:Label ID="lbl_emailregistro" runat="server" />
                                </p>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="cuenta-datos-item">
                <div class="cuenta-item-top">
                    <h2>
                        Dirección de Domicilio
                    </h2>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container" >
                        <ul>
                            <li>
                                <h4>Provincia</h4>
                                <p>
                                    <asp:DropDownList ID="CbxdmcProvincia01" runat="server" AutoPostBack="true" class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Ciudad</h4>
                                <p>
                                    <asp:DropDownList ID="cbxdmc_ciudad01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Calle Principal</h4>
                                <p>
                                    <asp:TextBox ID="txtdmc_calleprincipal01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li style="visibility:hidden;">
                                <h4>Intersección</h4>
                                <p>
                                    <asp:TextBox ID="txtdmc_interseccion01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Teléfono Fijo</h4>
                                <p>
                                    <asp:TextBox ID="txtdmc_telefono01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Teléfono Celular</h4>
                                <p>
                                    <asp:TextBox ID="txtdmc_telefono02" runat="server"  class="input-style"/>
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li style="visibility:hidden;">
                                <h4>Codificación Domicilio</h4>
                                <p>
                                    <asp:TextBox ID="txtdmc_numerocalle01" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdmc_iddireccion" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdmc_iddirecciondet" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdmc_idtelefono" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdmc_idemail" runat="server"  class="input-style"/>
                                </p>
                            </li>
                        </ul>
                    </div>

                   <%-- <div class="item-check">
                        <asp:RadioButton ID="chkdir_cambiodireccion" runat="server" Text=""
                                Enabled="true" GroupName="grpcorrespondencia" />
                        <p>
                            Quiero que la dirección de Domicilio sea mi Dirección de Correspondencia
                        </p>
                    </div>--%>
                </div>
            </div>
            <div class="cuenta-datos-item">
                <div class="cuenta-item-top">
                    <h2>
                        Dirección de Oficina/Trabajo
                    </h2>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Provincia</h4>
                                <p>
                                    <asp:DropDownList ID="CbxdofProvincia01" runat="server" AutoPostBack="true" class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Ciudad</h4>
                                <p>
                                    <asp:DropDownList ID="cbxdof_ciudad01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Calle Principal</h4>
                                <p>
                                    <asp:TextBox ID="txtdof_calleprincipal01" runat="server" class="input-style" />
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li style="visibility:hidden;">
                                <h4>Intersección</h4>
                                <p>
                                    <asp:TextBox ID="txtdof_interseccion01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Teléfono Fijo</h4>
                                <p>
                                    <asp:TextBox ID="txtdof_telefono01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Teléfono Celular</h4>
                                <p>
                                    <asp:TextBox ID="txtdof_telefono02" runat="server" class="input-style" Enabled="false" />
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li style="visibility:hidden;">
                                <h4>Codificación Domicilio</h4>
                                <p>
                                    <asp:TextBox ID="txtdof_numerocalle01" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdof_iddireccion" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdof_iddirecciondet" runat="server"  class="input-style"/>
                                </p>
                            </li>
                        </ul>
                    </div> 
                    <%--<div class="item-check">
                        <asp:RadioButton ID="chkdofi_cambiodireccion01" runat="server" Text=""
                                Enabled="true" GroupName="grpcorrespondencia"/>
                        <p>
                            Quiero que la dirección de Domicilio sea mi Dirección de Correspondencia
                        </p>
                    </div>--%>
                </div>
            </div>
            <div class="cuenta-datos-item">
                <div class="cuenta-item-top">
                    <h2>
                        Dirección de Facturación
                    </h2>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Provincia</h4>
                                <p>
                                    <asp:DropDownList ID="CbxdfaProvincia01" runat="server" AutoPostBack="true" class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Ciudad</h4>
                                <p>
                                    <asp:DropDownList ID="cbxdfa_ciudad01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Calle Principal</h4>
                                <p>
                                    <asp:TextBox ID="txtdfa_calleprincipal01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li style="visibility:hidden;">
                                <h4>Codificación Domicilio</h4>
                                <p>
                                    <asp:TextBox ID="txtdfa_numerocalle01" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdfa_iddireccion" runat="server"  class="input-style"/>
                                    <asp:TextBox ID="txtdfa_iddirecciondet" runat="server"  class="input-style"/>
                                </p>
                            </li>
                        </ul>
                        <ul>
                            <li style="visibility:hidden;">
                                <h4>Intersección</h4>
                                <p>
                                    <asp:TextBox ID="txtdfa_interseccion01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>E-mail</h4>
                                <p>
                                    <asp:TextBox ID="txtdfa_email01" runat="server"  class="input-style"/>
                                </p>
                            </li>
                            <li>
                                <h4>Teléfono Fijo</h4>
                                <p>
                                    <asp:TextBox ID="txtdfa_telefono01" runat="server" class="input-style"></asp:TextBox>
                                </p>
                            </li>
                            <li>
                                <h4>Teléfono Celular</h4>
                                <p>
                                    <asp:TextBox ID="txtdfa_telefono02" runat="server"  class="input-style" Enabled="false"/>
                                </p>
                            </li>
                        </ul>

                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
