<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="RenovacionFormaPago.aspx.vb" Inherits="ExtranetWeb.RenovacionFormaPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Mi Cuenta</title>
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
      <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="info-body">     
                   <script language=Javascript>
                        function isNumberKey(evt) {
                            var charCode = (evt.which) ? evt.which : evt.keyCode;
                            if (charCode == 46) 
                              return true;
                           
                            if (charCode > 31 && (charCode < 48 || charCode > 57))
                                return false;
                            return true;
                        }

                        function mathRoundForTaxes(source) {
                            var txtBox = document.getElementById(source);
                            var txt = txtBox.value;
                            if (!isNaN(txt) && isFinite(txt) && txt.length != 0) {
                                var rounded = Math.round(txt * 100) / 100;
                                txtBox.value = rounded.toFixed(2);
                            }
                        }

                        function keyPress(evt) {
                            var charCode = (evt.which) ? evt.which : evt.keyCode;
                            if (charCode > 31  &&  (charCode < 48 || charCode > 57))
                                return false;
                            return true;
                        }
                   </script>
                           
                <div class="cuenta-datos-item" id="secciondatospersonales" runat="server">

                    <ul class="steps">
                        <li>
                            <div class="circle">
                                1
                            </div>
                            <p>
                                Seleccionar<br/> Producto
                            </p>
                        </li>
                        <li class="separator"></li>
                        <li>
                            <div class="circle current">
                                2
                            </div>
                            <p class="current">
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

                    <div class="cuenta-item-top">
                        <h2>
                            INFORMACIÓN DE PAGO
                        </h2>
                        <asp:Button class="btn-class btn-next" id="btnagregardatos" runat="server" Text="Agregar" />
                        
                    </div>
                    <div class="cuenta-item-info">
                        <div class="item-info-container">
                            <ul>
                                <li>
                                    <h4>Forma Pago</h4>
                                    <p>
                                         <asp:DropDownList ID="Cbxforma" runat="server" AutoPostBack="true" class="input-style"/>
                                    </p>
                                </li>
                                <li>
                                   <h4><asp:Label ID="lblbanco" runat="server" Text="Banco"  /></h4>
                                    <p>
                                        <asp:DropDownList ID="Cbxbanco" runat="server" AutoPostBack="true" class="input-style"/>
                                    </p>
                                </li>
                                <li>
                                    <h4><asp:Label ID="Label13" runat="server" Text="Plazo" CssClass="content_label05" />
                                    </h4>
                                    <p>
                                        <asp:DropDownList ID="Cbxplazo" runat="server" AutoPostBack="true" class="input-style"/>
                                        <asp:TextBox ID="txtfecha" runat="server" TextMode="Date" Visible=false class="input-style">
                                        </asp:TextBox>
                    
                                    </p>
                                </li>
                                <li>
                                    <h1>Total de Ingreso $ &nbsp;
                                        <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                    </h1>
                                    
                                </li>
                            </ul>
                            <ul>
                                <li>
                                    <h4>Valor</h4>
                                    <p>
                                        <asp:TextBox ID="txtvalor" runat="server" onkeypress="return isNumberKey(event)" onchange="mathRoundForTaxes(this.id)" MaxLength="13" Text="0"  class="input-style">
                                        </asp:TextBox>
                                    </p>
                                </li>
                                <li>
                                    <h4>Nro. Documento</h4>
                                    <p>
                                        <asp:TextBox ID="txtdocumento" runat="server" MaxLength="20"  OnKeyPress="return keyPress(event)" class="input-style">
                                        </asp:TextBox>
                                    </p>
                                </li>
                                <li>
                                    <h4><asp:Label ID="Label1" runat="server" Text="Nro. Voucher" CssClass="content_label05" /></h4>
                                    <p>
                                        <asp:TextBox ID="txtvoucher" runat="server" MaxLength="14" OnKeyPress="return keyPress(event)" class="input-style">
                                        </asp:TextBox>
                                    </p>
                                </li>
                                <li>
                                
                                </li>
                               
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="dvdmensajes" class="messages" runat="server" >
                    <p>
                        <label id="lblmensajeexternoerror" runat="server"></label>    
                    </p>
                </div>  
                
                <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Eliminar</th>
                                    <th>Forma Pago</th>
                                    <th>Banco</th>
                                    <th>Valor</th>
                                    <th>Nro. Documento</th>
                                    <th>Plazo</th>
                                    <th>Nro. Voucher</th>
                                    <th>Fecha Cheque</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="RptdetalleForma" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="..."  OnClick="clk_rpt_eliminar"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldetforma" text='<%# Eval("FORMA_PAGO")%>' runat="server" Visible="true"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldetbanco" text='<%# Eval("BANCO")%>' runat="server"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldetvalor" text='<%# Eval("VALOR")%>' runat="server"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldetdocumento" text='<%# Eval("DOCUMENTO")%>' runat="server"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldetplazo" text='<%# Eval("PLAZO")%>' runat="server"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldetvoucher" text='<%# Eval("VOUCHER")%>' runat="server"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblfechacheque" text='<%# Eval("FECHA_CHEQUE")%>' runat="server"/>
                                            </td>
                                            
                                        </tr>
                                    </ItemTemplate>
                                </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                
                <div class="table-data">
                    <table class="datos-factura">
                        <thead>
                            <tr>
                                <th colspan="3">
                                    Datos para la Factura
                                </th>
                            </tr>
                        </thead>
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
                                    <a href="#openModalidentificacion" id="hrefclientefac">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="service">
                                    <b>Dirección</b>
                                </td>
                                <td>
                                    <asp:Label ID="txtFormaPagoDireccion" runat="server" Text=""/>
                                </td>
                                <td>
                                    <a href="#openModaldireccion">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="service">
                                    <b>Teléfono</b>
                                </td>
                                <td>
                                    <asp:Label ID="txtFormaPagoTelefono" runat="server" Text=""/>
                                </td>
                                <td>
                                    <a href="#openModaltelefono">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="service">
                                    <b>Celular</b>
                                </td>
                                <td>
                                    <asp:Label ID="txtFormaPagoCelular" runat="server" Text=""/>
                                </td>
                                <td>
                                    <a href="#openModalcelular">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="service">
                                    <b>Email de Facturación</b>
                                </td>
                                <td>
                                    <asp:Label ID="txtFormaPagoEmail" runat="server" Text=""/>
                                </td>
                                <td>
                                    <a href="#openModalemail">
                                        <img src="../images/img_mkt/search.png" alt="">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                
                <button class="btn-class btn-next" type="submit" id="btncontinuar" runat="server">
                    continuar
                </button>
            </section>
            <div id="openModalidentificacion" class="modalDialog">
		        <div>
                    <a href="#close" title="Close" class="close">X</a>
		            <h2 class="titulo-section">
                        Seleccione o Registre el Cliente para facturación
                    </h2>
                    <div class="table-data">
                        <div class="top-tabla-options">
                            <div class="search-client">
                                <input type="text" placeholder="Busqueda general" id="txtbusquedaclientefac" runat="server">
                            </div>
                            <button class="cliente-nuevo-fact" id="btnnuevoclientefac" runat="server" >
                                <img src="../images/img_mkt/add_circle_outline.png" alt="">
                                AGREGAR USUARIO
                            </button>
                            
                        </div>
                        <div class="messages ">
                            <label id="lblmensajeerror" runat="server"></label> 
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
                    <div class="add-cliente-form">
                        <div class="add-cliente-datos">
                            <h2>
                                Ingreso de datos de cliente
                            </h2>
                            <div class="select-item">
                                <label for="tipo-identificacion">Tipo de Identificación</label>
                                <asp:DropDownList ID="cmbcedulaclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                            </div>
                            <div class="add-cliente-input">
                                <label for="identificacion">
                                    No. de Identificación
                                </label>
                                <input type="text" id="txtcedulaclientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="apellido-paterno">
                                    Apellido paterno
                                </label>
                                <input type="text" id="txtapellido1clientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="apellido-materno">
                                    Apellido materno
                                </label>
                                <input type="text" id="txtapellido2clientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="primer-nombre">
                                    Primer nombre
                                </label>
                                <input type="text" id="txtnombre1clientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="segundo-nombre">
                                    Segundo nombre
                                </label>
                                <input type="text" id="txtnombre2clientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="email">
                                    Email
                                </label>
                                <input type="text" id="txtemailclientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="telefono">
                                    No. Teléfono
                                </label>
                                <input type="text" id="txttelefonoclientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="telefono">
                                    No. Celular
                                </label>
                                <input type="text" id="txtcelularclientefac" runat="server">
                            </div>
                            <div class="add-cliente-input">
                                <label for="fecha-nacimiento">
                                    Fecha de nacimiento
                                </label>
                                <asp:TextBox ID="txtfechanacimientoclientefac" runat="server" TextMode="Date" class="input-style"> </asp:TextBox>
                            </div>
                            <div class="select-item">
                                <label for="sexo">Sexo</label>
                                <asp:DropDownList ID="cmbsexoclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                            </div>
                        </div>
                        <div class="separator"></div>
                        <div class="add-cliente-direccion">
                            <h2>
                                Ingreso de dirección de domicilio
                            </h2>
                            <div class="select-item">
                                <label for="provincia">Provincia</label>
                                <asp:DropDownList ID="cmbprovinciaclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                            </div>
                            <div class="select-item">
                                <label for="ciudad">Ciudad</label>
                                <asp:DropDownList ID="cmbciudadclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                            </div>
                            <div class="select-item">
                                <label for="parroquia">Parroquia</label>
                                <asp:DropDownList ID="cmbparroquiaclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                            </div>
                            <div class="select-item">
                                <label for="sector">Sector</label>
                                <asp:DropDownList ID="cmbsectorclientefac" runat="server" AutoPostBack="true" class="select-css"/>
                            </div>
                            <div class="add-cliente-input span-item">
                                <label for="direccion">
                                    Direccion
                                </label>
                                <input type="text" id="txtdireccionclientefac" runat="server">
                            </div>
                            <div class="span-item inputs-group">
                                <div class="add-cliente-input">
                                    <label for="interseccion">
                                        Intersección
                                    </label>
                                    <input type="text" id="txtinterseccionclientefac" runat="server">
                                </div>

                                <div class="add-cliente-input">
                                    <label for="numero">
                                        Número
                                    </label>
                                    <input type="text" id="txtnumeroclientefac" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="openModaldireccion" class="modalDialog">
                <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione dirección para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo direccion</th>
                                    <th>Ciudad</th>
                                    <th>Direccion</th>
                                    <th>Interseccion</th>
                                    <th>Número</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rptdireccionfac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipodireccionfac" text='<%# Eval("TIPO_DIRECCION_NOMBRE")%>' runat="server" Visible="false"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblciudadfac" text='<%# Eval("CIUDAD_NOMBRE")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldireccionfac" text='<%# Eval("PRINCIPAL_MANZANA")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblinterseccionfac" text='<%# Eval("INTERSECCION")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblnumerofac" text='<%# Eval("NUMERO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_rpt_direccion_fac" runat="server" Text="..." OnClick="clk_rpt_direccionfac" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="openModaltelefono" class="modalDialog">
		        <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione teléfono para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Número</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rpttelefonofac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipotelefonofac" text='<%# Eval("TIPO_TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltelefonofac" text='<%# Eval("TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_rpt_telefono_fac" runat="server" Text="..." OnClick="clk_rpt_telefonofac" />
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="openModalcelular" class="modalDialog">
		        <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="titulo-section">
                        Seleccione celular para facturación
                    </h2>
                    <div class="table-data">
                        <table>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Numero</th>
                                    <th>Seleccionar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rptcelularfac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbltipocelularfac" text='<%# Eval("TIPO_TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblcelularfac" text='<%# Eval("TELEFONO")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btn_rpt_celular_fac" runat="server" Text="..." OnClick="clk_rpt_celularfac" />
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
                                            <asp:Label ID="lbltipoemailfac" text='<%# Eval("TIPO")%>' runat="server" Visible="true"/>
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
           
        </ContentTemplate>
        </asp:UpdatePanel>   
    </form>
</asp:Content>
