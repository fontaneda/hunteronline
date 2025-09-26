<%@ Page Language="vb" AutoEventWireup="false" 
    CodeBehind="cotizadorweburltecnicopaymentez.aspx.vb" Inherits="ExtranetWeb.cotizadorweburltecnicopaymentez" %>
<html>
    <head id="Head1" runat="server">
        <title>Transacción en proceso</title>
        <link href="../styles/estilocotizadorweburltecnico.css" rel="stylesheet" type="text/css" />
        <link rel="shortcut icon" href="../images/favicon.ico" />
        <script type="text/javascript">
            window.onload = function () {
                var postbk = '<%=postbk%>';
                if (postbk == 0) {
                    document.getElementById("btnpagar").click();
                }
            };
        </script>
        <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/crypto-js/4.2.0/crypto-js.min.js"></script>--%>
        <script src="../js/Crypto.js"></script>
    </head>
    <body>
        <div id="container">
            <div id="banner2">
                <div class="logo_image">
                </div>
            </div>
            <div class="content_titulopage">
                <h2>
                    Resultado de Transacción
                </h2>
            </div>
            <center id="Center1" runat="server">
                <div id="Div1" class="contenedor" runat="server">
                    <form name="form1" id="form1" method="post" action="" runat="server">
                        <div class="content_cotizadorurl_titulo">
                            <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="content_cotizadorurl_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurl_label" runat="server">
                            Orden de Pago
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obordennumero" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" runat="server">
                            Cliente
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obcliennombre" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Id Cliente
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obidencliente" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Mail Cliente
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obmailcliente" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Celular Cliente
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obcellcliente" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Descripcion
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obdescrproduc" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" runat="server">
                            Valor
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obvalorconiva" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Valor sin iva
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obvalorclient" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Iva
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obimpuestoval" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server">
                            Tasa Iva
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obimpuestopor" runat="server" Text="">
                            </asp:Label>
                        </div>
                         <div class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obtipdiferido" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurl_textbox2" runat="server">
                            <asp:Image ID="imageResultado" runat="server" 
                                ImageUrl="~/images/icons/24x24/checklist.png"/>
                            <asp:Label ID="lblemailresult" runat="server">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurl_textbox2">
                        </div>
                        <div class="content_cotizadorurl_textbox2" runat="server">
                            <button ID="btnregresoinicio" runat="server" style="width:100px; height:35px; color:Black !important; background-color:#E1F3C7;" Visible="False" 
                                    onserverclick="btnregresoinicio_Click">
                                Continuar
                            </button>
                            <asp:Image ID="imgregresoinicio" runat="server" Width="128px" Height="26px" AlternateText="Loading..." ImageAlign="Middle" ImageUrl="../images/gif/loading3.gif" />
                        </div>
                        <div class="content_cotizadorurl_textbox2">
                            <input type="button" onclick="impre('container');return false" style="background-image: url('../images/icons/32x32/icon_print.png');
                                background-repeat: no-repeat; background-position: center center; height: 29px;
                                width: 35px; background-color: #FFFFFF; border: none;" />
                        </div>
                            <button id="btngenerar" runat="server" onclick="btngenerar_ServerClick" style="width:100px; height:100px; visibility:hidden;">
                                ...
                            </button>
                    </form>
                    <div class="content_cotizadorurl_textbox2" runat="server">
                        <%--<script type="text/javascript" src="https://cdn.paymentez.com/checkout/1.0.1/paymentez-checkout.min.js"></script>--%>
                        <%--<button id="btnpagar" class="js-paymentez-checkout" runat="server">
                            Comprar
                        </button>--%>
                        <script src="https://code.jquery.com/jquery-3.5.0.min.js"></script>
                        <script src="https://cdn.paymentez.com/ccapi/sdk/payment_checkout_3.0.0.min.js"></script>
                        <button id="btnpagar" class="js-payment-checkout">Pagar</button>
                    </div>
                </div>
            </center>
        </div>
        <div id="response"></div>
        <script>
            let paymentCheckout = new PaymentCheckout.modal({
                env_mode: '<%=entorno%>',
                onOpen: function () {
                    console.log("modal open");
                },
                onClose: function () {
                    console.log("modal closed");
                },
                onResponse: function (response) {
                    console.log("modal response");
                    let responseText = JSON.stringify(response);
                    //document.getElementById("response").innerText = responseText;
                    var btn = document.getElementById("<%=btngenerar.ClientID %>");
                    __doPostBack('btn', JSON.stringify(responseText));
                }
            });
            let btnOpenCheckout = document.querySelector('.js-payment-checkout');
            btnOpenCheckout.addEventListener('click', function () {
               // Credenciales de Paymentez
                const app_code = '<%=appcod%>'
                const app_key = '<%=appkey%>'
                const app_url = '<%=appurl%>'
                // Variables con datos de transaccion
                var idencliente = document.getElementById('<%= obidencliente.ClientID %>');
                var mailcliente = document.getElementById('<%= obmailcliente.ClientID %>');
                var cellcliente = document.getElementById('<%= obcellcliente.ClientID %>');
                var valorconiva = document.getElementById('<%= obvalorconiva.ClientID %>');
                var valor_toval = document.getElementById('<%= obvalorclient.ClientID %>');
                var impuestopor = document.getElementById('<%= obimpuestopor.ClientID %>');
                var valordeliva = document.getElementById('<%= obimpuestoval.ClientID %>');
                var descrproduc = document.getElementById('<%= obdescrproduc.ClientID %>');
                var ordennumero = document.getElementById('<%= obordennumero.ClientID %>');
                var tipdiferido = document.getElementById('<%= obtipdiferido.ClientID %>');
                // Función para generar el Auth-Token
                const unix_timestamp = Math.floor(Date.now() / 1000); // Tiempo actual en formato UNIX
                const hash = CryptoJS.SHA256(app_key + unix_timestamp).toString(CryptoJS.enc.Hex);
                var encriptado = btoa(app_code + ";" + unix_timestamp + ";" + hash);
                // Datos de la solicitud para Init Reference
                const data = {
                    user: {
                        id: idencliente.innerHTML,
                        email: mailcliente.innerHTML,
                        phone: cellcliente.innerHTML
                    },
                    order: {
                        amount: parseFloat(valorconiva.innerHTML),
                        taxable_amount: parseFloat(valor_toval.innerHTML),
                        tax_percentage: parseFloat(impuestopor.innerHTML), // Porcentaje de impuesto (opcional)
                        vat: parseFloat(valordeliva.innerHTML), // IVA (opcional)
                        description: descrproduc.innerHTML,
                        dev_reference: ordennumero.innerHTML, // Referencia interna
                        installments_type: tipdiferido.innerHTML // Número de cuotas: 2 con intereses, 3 sin intereses
                    },
                    conf: {
                        theme: {
                            logo: "https://www.hunteronline.com.ec/imgcotizadorweb/imgaux/logo-color.png", 
                            primary_color: "#d31f10"
                        }
                    }
                };
                if (window.XMLHttpRequest) {
                    const xhr = new XMLHttpRequest();
                    xhr.open("POST", app_url, true);
                    xhr.setRequestHeader("Content-Type", "application/json");
                    xhr.setRequestHeader("Auth-Token", encriptado);
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState === XMLHttpRequest.DONE) {
                            const response_data = JSON.parse(xhr.responseText);
                            if (response_data.reference) {
                                paymentCheckout.open({ reference: response_data.reference });
                            } else {
                                console.log(JSON.stringify({ error: "Error al generar la referencia" }));
                            }
                        }
                    };
                    xhr.send(JSON.stringify(data));
                }
            });
            window.addEventListener('popstate', function () {
                paymentCheckout.close();
            });
        </script>
        <%--<script type="text/javascript">
            var paymentezCheckout = new PaymentezCheckout.modal({
                client_app_code: '<%=appcod%>',     //'HUNTER-EC-CLIENT',                   //
                client_app_key: '<%=appkey%>',      //'1oBYk80jcYaytpFL4FNCWAGMgXqEwZ',     //
                locale: '<%=lenguaje%>',
                env_mode: '<%=entorno%>',
                onOpen: function () {
                    console.log('modal open');
                },
                onClose: function () {
                    console.log('modal closed');
                },
                onResponse: function (response) {
                    console.log('modal response');
                    //document.getElementById('lblemailresult').innerHTML = JSON.stringify(response);
                    var btn = document.getElementById("<%=btngenerar.ClientID %>");
                    __doPostBack('btn', JSON.stringify(response));
                }
            });

            var btnOpenCheckout = document.querySelector('.js-paymentez-checkout');
            btnOpenCheckout.addEventListener('click', function () {
                var idencliente = document.getElementById('<%= obidencliente.ClientID %>');
                var mailcliente = document.getElementById('<%= obmailcliente.ClientID %>');
                var cellcliente = document.getElementById('<%= obcellcliente.ClientID %>');
                var ordennumero = document.getElementById('<%= obordennumero.ClientID %>');
                var valorclient = document.getElementById('<%= obvalorconiva.ClientID %>');
                var valordeliva = document.getElementById('<%= obimpuestoval.ClientID %>');
                var descrproduc = document.getElementById('<%= obdescrproduc.ClientID %>');
                var taxmontoval = document.getElementById('<%= obvalorclient.ClientID %>');
                var taxmontopor = document.getElementById('<%= obimpuestopor.ClientID %>');
                var tipdiferido = document.getElementById('<%= obtipdiferido.ClientID %>');

                paymentezCheckout.open({
                    user_id: idencliente.innerHTML,
                    user_email: mailcliente.innerHTML,
                    user_phone: cellcliente.innerHTML,
                    order_description: descrproduc.innerHTML,
                    order_amount: parseFloat(valorclient.innerHTML),
                    order_vat: parseFloat(valordeliva.innerHTML),
                    order_reference: ordennumero.innerHTML,
                    order_installments_type: parseInt(tipdiferido.innerHTML), //tipdiferido.innerHTML,
                    order_taxable_amount: parseFloat(taxmontoval.innerHTML),
                    order_tax_percentage: parseFloat(taxmontopor.innerHTML)
                });
            });

            window.addEventListener('popstate', function () {
                paymentezCheckout.close();
            });
        </script>--%>
    </body>
</html>