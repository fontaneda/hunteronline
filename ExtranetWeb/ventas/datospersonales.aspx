<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="datospersonales.aspx.vb" Inherits="ExtranetWeb.datospersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Mi Cuenta</title>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="grey-back">
    <form id="Form1" action="#" runat="server">
        <section class="info-body">                    
            <div class="cuenta-datos-item">
                <div class="cuenta-item-top">
                    <h2>
                        Datos Personales
                    </h2>
                    <a href="solicitudactualizacion.aspx">
                        <img src="../images/img_mkt/edit-icon.png" alt="">
                    </a>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Identificación</h4>
                                <p><asp:Label ID="lbldtp_identificacion" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Nombres</h4>
                                <p><asp:Label ID="lbldtp_nombres" runat="server"></asp:Label></p>
                            </li>
                            <li>
                                <h4><asp:Label ID="labeldtp_fechanacimiento" runat="server" Text="Fecha de Nacimiento" /></h4>
                                <p><asp:Label ID="lbldtp_fechanacimiento" runat="server" /></p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>E-mail</h4>
                                <p><asp:Label ID="lbldtp_email1" runat="server" /></p>
                            </li>
                            <li>
                                <h4>E-mail Oficina</h4>
                                <p><asp:Label ID="lbldtp_email2" runat="server" /></p>
                            </li>
                            <li>
                                <h4>E-mai Registro</h4>
                                <p><asp:Label ID="lbl_emailregistro" runat="server" /></p>
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
                    <a href="solicitudactualizacion.aspx">
                        <img src="../images/img_mkt/edit-icon.png" alt="">
                    </a>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Provincia</h4>
                                <p><asp:Label ID="lbldmc_provincia" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Ciudad</h4>
                                <p><asp:Label ID="lbldmc_ciudad" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Calle Principal</h4>
                                <p><asp:Label ID="lbldmc_calleprincipal" runat="server" /></p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Intersección</h4>
                                <p><asp:Label ID="lbldmc_calleinterseccion" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Teléfono Fijo</h4>
                                <p><asp:Label ID="lbldmc_telefonofijo" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Teléfono Celular</h4>
                                <p><asp:Label ID="lbldmc_telefonocelular" runat="server" /></p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Codificación Domicilio</h4>
                                <p><asp:Label ID="lbldmc_callenumero" runat="server" /></p>
                            </li>
                        </ul>
                    </div>
                    <%--<div class="item-check">
                        <asp:CheckBox ID="chkdmc_cambiodireccion" runat="server" Text=""
                                Enabled="False" />
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
                    <a href="solicitudactualizacion.aspx">
                        <img src="../images/img_mkt/edit-icon.png" alt="">
                    </a>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Provincia</h4>
                                <p><asp:Label ID="lbldof_provincia" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Ciudad</h4>
                                <p><asp:Label ID="lbldof_ciudad" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Calle Principal</h4>
                                <p><asp:Label ID="lbldof_calleprincipal" runat="server" /></p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Intersección</h4>
                                <p><asp:Label ID="lbldof_calleinterseccion" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Teléfono Fijo</h4>
                                <p><asp:Label ID="lbldof_telefonofijo" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Teléfono Celular</h4>
                                <p><asp:Label ID="lbldof_telefonocelular" runat="server" /></p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Codificación Domicilio</h4>
                                <p><asp:Label ID="lbldof_callenumero" runat="server" /></p>
                            </li>
                        </ul>
                    </div>
                    <%--<div class="item-check">
                        <asp:CheckBox ID="chkdof_cambiodireccion" runat="server" Text=""
                                Enabled="False" />
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
                    <a href="solicitudactualizacion.aspx">
                        <img src="../images/img_mkt/edit-icon.png" alt="">
                    </a>
                </div>
                <div class="cuenta-item-info">
                    <div class="item-info-container">
                        <ul>
                            <li>
                                <h4>Provincia</h4>
                                <p><asp:Label ID="lbldfa_provincia" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Ciudad</h4>
                                <p><asp:Label ID="lbldfa_ciudad" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Calle Principal</h4>
                                <p><asp:Label ID="lbldfa_calleprincipal" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Codificación Domicilio</h4>
                                <p><asp:Label ID="lbldfa_callenumero" runat="server" /></p>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <h4>Intersección</h4>
                                <p><asp:Label ID="lbldfa_calleinterseccion" runat="server" /></p>
                            </li>
                            <li>
                                <h4>E-mail</h4>
                                <p><asp:Label ID="lbldfa_email1" runat="server" /></p>
                            </li>
                            <li>
                                <h4>Teléfono Fijo</h4>
                                <p><asp:Label ID="lbldfa_telefonofijo" runat="server"></asp:Label></p>
                            </li>
                            <li>
                                <h4>Teléfono Celular</h4>
                                <p><asp:Label ID="lbldfa_telefonocelular" runat="server" /></p>
                            </li>
                        </ul>

                    </div>
                </div>

            </div>
        </section>
    </form>
</asp:Content>