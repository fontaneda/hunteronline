<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cotizadorweburldebito.aspx.vb" Inherits="ExtranetWeb.cotizadorweburldebito" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Débitos Recurrentes</title>
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <script src="https://code.jquery.com/jquery-1.11.3.min.js" charset="UTF-8"></script>
    <link href="../styles/estilocotizadorweburltecnico.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.paymentez.com/ccapi/sdk/payment_stable.min.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.paymentez.com/ccapi/sdk/payment_stable.min.js" charset="UTF-8"></script>
    <%--<link rel="stylesheet" href="../styles/css_mkt/int-styles.css">--%>
    <style>
        .cuerpopago{
            background: #eeeeee;
            background: -moz-linear-gradient(-45deg,  #eeeeee 0%, #cccccc 100%);
            background: -webkit-linear-gradient(-45deg,  #eeeeee 0%,#cccccc 100%);
            background: linear-gradient(135deg,  #eeeeee 0%,#cccccc 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#eeeeee', endColorstr='#cccccc',GradientType=1 );
            width:400px; 
            height:335px;
            text-align:left;
            border-radius: 10px 10px 10px 10px;
            -moz-border-radius: 10px 10px 10px 10px;
            -webkit-border-radius: 10px 10px 10px 10px;
            border: 1px solid #bfbfbf;
            -webkit-box-shadow: 4px 4px 0px 0px rgba(235,235,235,0.74);
            -moz-box-shadow: 4px 4px 0px 0px rgba(235,235,235,0.74);
            box-shadow: 4px 4px 0px 0px rgba(235,235,235,0.74);
            padding:15px;}
        .imagencabecera{
            width:100%; 
            text-align:center;}
        .btn {
            background: rgb(140, 197, 65); /* Old browsers */
            background: -moz-linear-gradient(top, rgba(140, 197, 65, 1) 0%, rgba(20, 167, 81, 1) 100%);
            background: -webkit-linear-gradient(top, rgba(140, 197, 65, 1) 0%, rgba(20, 167, 81, 1) 100%);
            background: linear-gradient(to bottom, rgba(140, 197, 65, 1) 0%, rgba(20, 167, 81, 1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#44afe7', endColorstr='#3198df', GradientType=0);
            color: #fff;
            display: block;
            width: 100%;
            border: 1px solid rgba(46, 86, 153, 0.0980392);
            border-bottom-color: rgba(46, 86, 153, 0.4);
            border-top: 0;
            border-radius: 4px;
            text-shadow: rg5ba(46, 86, 153, 0.298039) 0px -1px 0px;
            line-height: 34px;
            -webkit-font-smoothing: antialiased;
            font-weight: bold;
            display: block;
            margin-top: 20px;}
        .btn:disabled,
        .btn[disabled]{
            background: -moz-linear-gradient(-45deg,  rgba(0,0,0,0.65) 0%, rgba(0,0,0,0.29) 100%); /* FF3.6-15 */
            background: -webkit-linear-gradient(-45deg,  rgba(0,0,0,0.65) 0%,rgba(0,0,0,0.29) 100%); /* Chrome10-25,Safari5.1-6 */
            background: linear-gradient(135deg,  rgba(0,0,0,0.65) 0%,rgba(0,0,0,0.29) 100%); /* W3C, IE10+, FF16+, Chrome26+, Opera12+, Safari7+ */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#a6000000', endColorstr='#4a000000',GradientType=1 ); /* IE6-9 fallback on horizontal gradient */
            color: #000;}
        .btn:hover {
            cursor: pointer;}
        .messages {
            display: flex;
            margin: 2rem auto 0;
            min-width: 75%;
            max-width: 90%;
            text-align: center;
            background: #fff;
            box-shadow: rgba(107, 107, 107, 0.1) 0 0.2rem 1.1rem;
            padding: 2rem 3rem 2rem 4rem;
            border-radius: 7rem;
            font-size: 1.2rem;
            color: #717780;
            letter-spacing: 0.1rem;
            transition: all 0.2s linear;
            justify-content: space-between;
            align-items: center;}
        .messages b {
            font-weight: 400;}
        .messages.alert {
            background: #FDF9F5 url("../images/alert-icon.png") no-repeat 1.5rem center;}
        .messages.error {
            background: #FBF9F9 url("../images/error-icon.png") no-repeat 1.5rem center;}
        .messages.sucess {
            background: #F5FCF6 url("../images/sucess-icon.png") no-repeat 1.5rem center;}
        .messages .x-btn {
            font-size: 1.7rem;
            margin-left: 2rem;
            cursor: pointer;
            color: black;
            justify-self: flex-end;}
        .close-message {
            opacity: 0;
            margin: 0;
            padding: 0;}
        .table-data {
            width: 90%;
            margin-top: 5.5rem;
            transition: all 1s;
            font-family:Arial;}
        .table-data h2 {
            font-size: 1.75rem;}
        .table-data table {
            width: 100%;
            margin-top: 1.2rem;
            border-collapse: collapse;
            font-size: 0.9rem;}
        .table-data table input[type=checkbox] {
            transform: scale(1.8);
            border: none;
            border-radius: .8rem;}
        .table-data table td,
        .table-data table th {
            text-align: center;
            padding: 8px;}
        .table-data table th {
            height: 2.0rem;
            background: #06BBAB;
            color: #F4F7F9;
            font-weight: 200;
            letter-spacing: .1rem;
            font-size: 1rem;
            font-weight: 200;}
        .table-data table td {
            border-bottom: 1px solid #ddd;
            background: #fff;
            height: 5rem;}
        .table-data table td.service {
            font-size: 1.2rem;
            text-transform: uppercase;
            text-align: left;}
        .table-data table td.service b {
            font-weight: 900;
            letter-spacing: 0.1rem;}
        .table-data table td .cod-prom {
            width: 8.7rem;
            height: 3.8rem;
            padding: 0 0.8rem;
            font-size: 1.6rem;
            text-align: center;}
        .name{
            padding-left:38px;
            padding-right:5px;
            width:89%; 
            height:32px; 
            border-color:#D9D9D9;
            font-family:Arial;
            font-size:0.9em;
            border-width:1px;
            margin-bottom:10px;
            border-radius: 4px 4px 4px 4px;
            -moz-border-radius: 4px 4px 4px 4px;
            -webkit-border-radius: 4px 4px 4px 4px;}
        .cuerpopago2{
            width:75%;}
        .cuerpopago2 .btn{
            margin:15px 7px 15px 7px;
            width:27%;
            height:35px;
            position:relative;
            float:left;
            }
    </style>
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
	        width: 430px;
	        height:375px;
	        position: relative;
	        margin: 5% auto;
	        padding: 5px 20px 13px 20px;
	        border-radius: 10px;
	        background: rgba(0,0,0,0.0);
            -webkit-transition: opacity 400ms ease-in;
            -moz-transition: opacity 400ms ease-in;
            transition: opacity 400ms ease-in;
        }
        .close {
	        background: #606061;
	        color: #FFFFFF;
	        line-height: 25px;
	        position: absolute;
	        right: 25px;
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
</head>
<body>
    <center>
        <div id="banner2">
            <div class="logo_image">
            </div>
        </div>
        <div id="dvdmensajes" class="messages alert" runat="server">
            <p>
                <label id="lblmensajeerror" runat="server"></label>    
            </p>
            <label id="close" for="hide-message" class="x-btn">&#10005</label>
        </div>
        <div class="cuerpopago2">
            <form id="frmitms"  runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel runat="server" id="UpdatePanel2" updatemode="Conditional">
                <ContentTemplate>
                    <div class="table-data" id="tbl00" runat="server">
                        <h2>
                            Tarjetas Matriculadas
                        </h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>Alias</th>
                                    <th>Banco</th>
                                    <th>Tipo Tarjeta</th>
                                    <th>Fecha Ingreso</th>
                                    <th>Estado</th>
                                    <th>Procesar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <ASP:Repeater id="Rpt_tarjetas_items" runat="server">
                                <ItemTemplate>                         
                                    <tr>
                                        <td class="service" id="tdcelda1" runat="server">
                                            <asp:Label ID="lblnumtrajeta" text='<%# Eval("ALIASID") %>' runat="server"/>
                                            <asp:Label ID="lbltoken" text='<%# Eval("TOKEN_DEBITO") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                                            <asp:Label ID="lblorden" text='<%# Eval("ORDEN_REFERENCIA") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                                            <asp:Label ID="lblsecuencia" text='<%# Eval("SECUENCIA") %>' runat="server" Visible="false" ForeColor="Transparent"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblbanco" text='<%# Eval("BANCO") %>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbltipo" text='<%# Eval("TIPO_TARJETA") %>' runat="server"/>
                                        </td>
                                        <td class="ficha">
                                            <asp:Label ID="lblfecha" text='<%# Eval("FECHA_INGRESO_DEBITO") %>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblestado" text='<%# Eval("ESTADO") %>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnprocesar" runat="server" Text="..." OnClick="clk_rpt_procesar" Enabled='<%# Eval("HABILITADO") %>'/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                </ASP:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div style="margin: auto auto; padding-left:10%; width:auto; height:50px;">
                        <a href="#openModaltarjeta" id="hreftarjeta" class="btn">
                            Agregar
                        </a>
                        <asp:Button id="btneliminar" class="btn" runat="server" Text="Eliminar" />
                        <asp:Button id="btngenerar" class="btn" runat="server" Text="Generar"/>
                     </div>
                </ContentTemplate>
                </asp:UpdatePanel>
                <div style="margin:auto auto;width:515px;height:70px;">
                    <img src="../images/background/PiePagoDebito.png" alt=""/>
                </div>
            </form> 
            <div id="openModaltarjeta" class="modalDialog">
		        <div>
                    <a href="#close" title="Close" class="close">X</a>
                    <div class="cuerpopago">
                        <div class="imagencabecera">
                            <img src="../images/background/CabeceraPagoDebito.png" alt=""/>
                        </div>
                        <form id="add-card-form">
                            <input class="name" type="text" name="aliasid" id="aliasid" placeholder="Ingrese Alias " style="font-size:1.5em;"/>
                            <div ID="my-card" class="payment-form" data-capture-name="true" data-use-dropdowns="true">
                                <input class="cvc" id="cvc" name="cvc">
                            </div>
                            <button class="btn" style="margin:15px 0px 0px 150px;">
                                Agregar
                            </button>
                            <br/>
                            <div id="messages">
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </center>
</body>
<script type="text/javascript" src="../js/main.js">
</script>
<script type="text/javascript">
    $(function () {
        Payment.init('stg', '<%=appcod%>', '<%=appkey%>');
        let form = $("#add-card-form");
        let submitButton = form.find("button");
        let submitInitialText = submitButton.text();

        $("#add-card-form").submit(function (e) {
            let myCard = $('#my-card');
            $('#messages').text("");
            let cardToSave = myCard.PaymentForm('card');
            if (cardToSave == null) {
                alert("Tarjeta no válida...");
            } else {
                submitButton.attr("disabled", "disabled").text("Procesando tarjeta...");
                let uid = '<%=userid%>';
                let email = '<%=email%>';
                Payment.addCard(uid, email, cardToSave, successHandler, errorHandler);
            }
            e.preventDefault();
        });

        let successHandler = function (cardResponse) {
            console.log(cardResponse.card);
            var aliasid = document.getElementById("aliasid").value;
            var cvc = document.getElementById("cvc").value;
            var response_ = cardResponse.card.status
                        + '*'
                        + cardResponse.card.token
                        + '*'
                        + cardResponse.card.transaction_reference
                        + '*'
                        + cardResponse.card.message
                        + '*'
                        + cardResponse.card.bin
                        + 'XXXXXX'
                        + cardResponse.card.number
                        + '*'
                        + cardResponse.card.type
                        + '*'
                        + aliasid
                        + '*'
                        + cvc;
            if (cardResponse.card.status === 'valid') {
                var btn = document.getElementById("<%=btngenerar.ClientID %>");
                __doPostBack('btn', response_);
            } else if (cardResponse.card.status === 'review') {
                var btn = document.getElementById("<%=btngenerar.ClientID %>");
                __doPostBack('btn', response_);
            } else {
                submitButton.text(submitInitialText);
            }
        };

        let errorHandler = function (err) {
            console.log(err.error);
            $('#messages').html(err.error.type);
            submitButton.removeAttr("disabled");
            submitButton.text(submitInitialText);
        };
    });
</script>
</html>
