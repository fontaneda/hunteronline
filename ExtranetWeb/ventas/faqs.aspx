<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="faqs.aspx.vb" Inherits="ExtranetWeb.faqs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contactos_maestro">
        <div class="contactos_titulo">
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function btn1clk() {
                         var div1 = document.getElementById('divRespuesta1');
                         if (div1.style.display == 'block') {
                             div1.style.display = 'none'
                             document.getElementById('divexpandir1').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div1.style.display = 'block'
                             document.getElementById('divexpandir1').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn2clk() {
                         var div2 = document.getElementById('divRespuesta2');
                         if (div2.style.display == 'block') {
                             div2.style.display = 'none'
                             document.getElementById('divexpandir2').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div2.style.display = 'block'
                             document.getElementById('divexpandir2').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn3clk() {
                         var div3 = document.getElementById('divRespuesta3');
                         if (div3.style.display == 'block') {
                             div3.style.display = 'none'
                             document.getElementById('divexpandir3').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div3.style.display = 'block'
                             document.getElementById('divexpandir3').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn4clk() {
                         var div4 = document.getElementById('divRespuesta4');
                         if (div4.style.display == 'block') {
                             div4.style.display = 'none'
                             document.getElementById('divexpandir4').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div4.style.display = 'block'
                             document.getElementById('divexpandir4').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn5clk() {
                         var div5 = document.getElementById('divRespuesta5');
                         if (div5.style.display == 'block') {
                             div5.style.display = 'none'
                             document.getElementById('divexpandir5').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div5.style.display = 'block'
                             document.getElementById('divexpandir5').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn6clk() {
                         var div6 = document.getElementById('divRespuesta6');
                         if (div6.style.display == 'block') {
                             div6.style.display = 'none'
                             document.getElementById('divexpandir6').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div6.style.display = 'block'
                             document.getElementById('divexpandir6').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn7clk() {
                         var div7 = document.getElementById('divRespuesta7');
                         if (div7.style.display == 'block') {
                             div7.style.display = 'none'
                             document.getElementById('divexpandir7').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div7.style.display = 'block'
                             document.getElementById('divexpandir7').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                     function btn8clk() {
                         var div8 = document.getElementById('divRespuesta8');
                         if (div8.style.display == 'block') {
                             div8.style.display = 'none'
                             document.getElementById('divexpandir8').style.backgroundImage = "url(../Images/icons/32x32/expandir31x32.png)";
                         } else {
                             div8.style.display = 'block'
                             document.getElementById('divexpandir8').style.backgroundImage = "url(../Images/icons/32x32/contraer31x32.png)";
                         }
                     }
                </script>
            </telerik:RadCodeBlock>
            <div class="contactos_principal">
                <h2>
                    Preguntas frecuentes
                </h2>
            </div>
            <div class="preguntapanel">
                <div class="preguntacontenido">
                    <div id="divexpandir1" class="preguntacabeceramas" onclick="btn1clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta1">
                        ¿Qué es PlacetoPay?
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta1">
                        PlacetoPay es la plataforma de pagos electrónicos que usa Hunter para procesar en línea las transacciones generadas en la tienda virtual con las formas de pago habilitadas para tal fin.
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir2" class="preguntacabeceramas" onclick="btn2clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta2">
                        ¿Cómo puedo pagar?
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta2">
                        En la tienda virtual de Hunter usted podrá realizar su pago utilizando: Tarjetas de Crédito de las siguientes franquicias: Diners, Visa y MasterCard; de todos los bancos en lo que corresponde a pago corriente y en cuanto a diferido, únicamente las tarjetas emitidas por Banco Pichincha, Loja, BGR y Machala. Pronto extenderemos esta lista de opciones para nuestros clientes.
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir3" class="preguntacabeceramas" onclick="btn3clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta3">
                        ¿Es seguro ingresar mis datos bancarios en este sitio web? 
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta3">
                        Para proteger tus datos Hunter delega en PlacetoPay la captura de la información sensible. Nuestra plataforma de pagos cumple con los estándares exigidos por la norma internacional PCI DSS de seguridad en transacciones con tarjeta de crédito. Además tiene certificado de seguridad SSL expedido por GeoTrust una compañía Verisign, el cual garantiza comunicaciones seguras mediante la encriptación de todos los datos hacia y desde el sitio; de esta manera te podrás sentir seguro a la hora de ingresar la información de su tarjeta. 
                        <br />
                        Durante el proceso de pago, en el navegador se muestra el nombre de la organización autenticada, la autoridad que lo certifica y la barra de dirección cambia a color verde. Estas características son visibles de inmediato, dan garantía y confianza para completar la transacción en PlacetoPay.
                        <br />
                        PlacetoPay también cuenta con el monitoreo constante de McAfee Secure y la firma de mensajes electrónicos con Certicámara.
                        <br />
                        PlacetoPay es una marca de la empresa colombiana EGM Ingeniería Sin Fronteras S.A.S. 
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir4" class="preguntacabeceramas" onclick="btn4clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta4">
                        ¿Puedo realizar el pago cualquier día y a cualquier hora?
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta4">
                        Sí, en Hunter  podrás realizar tus compras en línea los 7 días de la semana, las 24 horas del día a sólo un clic de distancia.
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir5" class="preguntacabeceramas" onclick="btn5clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta5">
                        ¿Puedo cambiar la forma de pago?
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta5">
                        Si aún no has finalizado tu pago, podrás volver al paso inicial y elegir la forma de pago que prefieras. Una vez finalizada la compra no es posible cambiar la forma de pago.
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir6" class="preguntacabeceramas" onclick="btn6clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta6">
                        ¿Pagar electrónicamente tiene algún valor para mí como comprador? 
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta6">
                        No, los pagos electrónicos realizados a través de PlacetoPay no generan costos adicionales para el comprador.
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir7" class="preguntacabeceramas" onclick="btn7clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta7">
                        ¿Qué debo hacer si mi transacción no concluyó?
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta7">
                        En primera instancia deberás revisar si llegó un mail de confirmación del pago en tu cuenta de correo electrónico (la inscrita en el momento de realizar el pago), en caso de no haberlo recibido, deberás contactar a soportehunteronline@carsegsa.com para confirmar el estado de la transacción.
                    </div>
                </div>
                <div class="preguntacontenido">
                    <div id="divexpandir8" class="preguntacabeceramas" onclick="btn8clk();">
                    </div>
                    <div class="preguntacabecera" id="divPregunta8">
                        ¿Qué debo hacer si no recibí el comprobante de pago?
                    </div>
                    <div class="preguntarespuesta" id="divRespuesta8">
                        Por cada transacción aprobada a través de PlacetoPay, recibirás un comprobante del pago con la referencia de compra en la dirección de correo electrónico que indicaste al momento de pagar. Si no lo recibes, podrás contactar a soportehunteronline@carsegsa.com, para solicitar el reenvío del comprobante a la misma dirección de correo electrónico registrada al momento de pagar.
                    </div>
                </div>
            </div>
        </div>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="divexpandir1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="divRespuesta1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="divPregunta1"  LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
    </div>
</asp:Content>