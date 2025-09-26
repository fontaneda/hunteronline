<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="mistransacciones.aspx.vb" Inherits="ExtranetWeb.mistransacciones" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Mis transacciones</title>
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
            <div class="transacciones">
                <h2 class="transac-title">
                    Transacciones Realizadas
                </h2>
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
                    <button id="btnfiltro" runat="server" class="btn-search-rounded">
                        <img src="../images/img_mkt/search-icon-white.png" alt="">
                    </button>
                </div>
                <ul class="tipo-documentos">
                    <li>
                        <a id="btnfiltrotransacciones" class="show" runat="server">
                            Transacciones
                        </a>
                    </li>
                    <li>
                        <a id="btnfiltroaccesos" runat="server">
                            Accesos
                        </a>
                    </li>
                </ul>
                <div id="divpagos" runat="server">
                <table class="table-transacciones" >
                    <thead>
                        <tr>
                            <th>Referencia</th>
                            <th>Tarjeta</th>
                            <th>Fecha</th>
                            <th>Total</th>
                            <th>Código Conf. Pago</th>
                            <th>Estado</th>
                            <th>Operación</th>
                        </tr>
                    </thead>
                    <tbody>
                        <ASP:Repeater id="Rpt_transacciones" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ORDEN_ID")%></td>
                                <td><%# Eval("TIPO_TARJETA")%></td>
                                <td><%# Eval("FECHA_VERIFICACION")%></td>
                                <td><%# Eval("TOTAL")%></td>
                                <td><%# Eval("CODIGO_CONF_PAGO")%></td>
                                <td><%# Eval("ESTADO_WEB_DESC")%></td>
                                <td><%# Eval("TIPO")%></td>
                            </tr>
                        </ItemTemplate>
                        </ASP:Repeater>
                    </tbody>
                </table>
                </div>
                <div id="divaccesos" runat="server">
                <table class="table-transacciones" >
                    <thead>
                        <tr>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Tipo Transaccion</th>
                            <th>Comentario</th>
                        </tr>
                    </thead>
                    <tbody>
                        <ASP:Repeater id="Rpt_accesos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("FECHA")%></td>
                                <td><%# Eval("HORA")%></td>
                                <td><%# Eval("TIPO_TRANSACCION")%></td>
                                <td><%# Eval("COMENTARIO")%></td>
                            </tr>
                        </ItemTemplate>
                        </ASP:Repeater>
                    </tbody>
                </table>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
