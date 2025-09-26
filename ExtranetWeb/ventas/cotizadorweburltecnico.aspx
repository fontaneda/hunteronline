<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cotizadorweburltecnico.aspx.vb" Inherits="ExtranetWeb.cotizadorweburltecnico" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Transacción en proceso</title>
        <link href="../styles/estilocotizadorweburltecnico.css" rel="stylesheet" type="text/css" />
        <link rel="shortcut icon" href="../images/favicon.ico" />
        <script type="text/javascript" src="https://checkout.placetopay.ec/lightbox.min.js"></script>
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
                <div id="Div0" class="contenedor" runat="server">
                    <form name="form1" id="cart_form" method="post" action="" runat="server" >
                        <div class="content_cotizadorurl_titulo">
                            <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="content_cotizadorurl_cabecera_separador">
                        </div>
                        <div id="Div11" class="content_cotizadorurl_label" runat="server">
                            Fecha
                        </div>
                        <div id="Div12" class="content_cotizadorurlretorno_textbox" runat="server" >
                            <asp:Label ID="lblfecha" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div1" class="content_cotizadorurl_label" runat="server">
                            Referencia
                        </div>
                        <div id="Div2" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obordennumero" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div3" class="content_cotizadorurl_label" runat="server">
                            Cliente
                        </div>
                        <div id="Div4" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obcliennombre" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div5" class="content_cotizadorurl_label" hidden="true" runat="server">
                            Id Cliente
                        </div>
                        <div id="Div6" class="content_cotizadorurlretorno_textbox" hidden="true" runat="server">
                            <asp:Label ID="obidencliente" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div7" class="content_cotizadorurl_label" runat="server">
                            Mail Cliente
                        </div>
                        <div id="Div8" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obmailcliente" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div15" class="content_cotizadorurl_label" runat="server">
                            Valor sin iva
                        </div>
                        <div id="Div16" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obvalorclient" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div17" class="content_cotizadorurl_label" runat="server">
                            Iva
                        </div>
                        <div id="Div18" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obimpuestoval" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div13" class="content_cotizadorurl_label" runat="server">
                            Valor total
                        </div>
                        <div id="Div14" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obvalorconiva" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_label" hidden="true" runat="server" style="color:White;">
                            Url
                        </div>
                        <div class="content_cotizadorurlretorno_textbox" style="color:White;" hidden="true" >
                            <input type="url" id="urlproceso" name="urlproceso" class="form-control" value="<%=turl%>"
                                   aria-label="URL de procesamiento" />
                        </div>
                        <div id="Div9" class="content_cotizadorurl_label" runat="server">
                            Código Confirmación
                        </div>
                        <div id="Div10" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obcodconf" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div id="Div19" class="content_cotizadorurl_label" runat="server">
                            Estado
                        </div>
                        <div id="Div20" class="content_cotizadorurlretorno_textbox" runat="server">
                            <asp:Label ID="obestadoconf" runat="server" Text="">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_cabecera_separador">
                        </div>
                        <div id="Div21" class="content_cotizadorurl_textbox2" runat="server">
                            <asp:Image ID="imageResultado" runat="server" 
                                ImageUrl="~/images/icons/24x24/checklist.png"/>
                            <asp:Label ID="lblemailresult" runat="server">
                            </asp:Label>
                        </div>
                        <div class="content_cotizadorurl_cabecera_separador">
                        </div>
                        <div class="content_cotizadorurl_textbox2">
                        </div>
                        <div id="Div28" class="content_cotizadorurl_textbox2" runat="server">
                            <button ID="btnregresoinicio" runat="server" style="width:100px; height:35px; color:Black !important;  
                                    background-color:#E1F3C7;" Visible="true" onserverclick="btnregresoinicio_Click">
                                Continuar
                            </button>
                            <asp:Image ID="imgregresoinicio" runat="server" Width="128px" Height="26px" AlternateText="Loading..." ImageAlign="Middle" ImageUrl="../images/gif/loading3.gif" />
                        </div>
                        <div class="content_cotizadorurl_textbox2">
                            <input type="button" onclick="impre('container');return false" style="background-image: url('../images/icons/32x32/icon_print.png');
                                background-repeat: no-repeat; background-position: center center; height: 29px;
                                width: 35px; background-color: #FFFFFF; border: none;" />
                        </div>
                        <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">                
                        </telerik:RadScriptManager>
                        <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True">
                        </telerik:RadNotification>--%>
                    </form>
                    <div class="content_cotizadorweburltecnico_textbox" hidden="true">
                        <button class="btn btn-secondary" type="button" id="lightboxIt">Lightbox!</button>
                        <pre id="lightbox-response"></pre>
                        <button id="btngenerar" runat="server" onclick="btngenerar_ServerClick" style="width:100px; height:100px; visibility:hidden;">
                            ...
                        </button>
                    </div>
                </div>
            </center>
        </div>
        <script type="text/javascript">
            window.onload = function () {
                var postbk = '<%=postbk%>';
                if (postbk == 0) {
                    document.getElementById("lightboxIt").click();
                }
            };
        </script>
        <script src="../script/jquery-1.12.4.min.js"></script>
        <script src="../script/jquery.form.min.js"></script>
        <script>
            $(document).on('ready', function () {
                // Configuro el listener
                P.on('response', function (data) {

                    var btn = document.getElementById("<%=btngenerar.ClientID %>");
                    __doPostBack('btn', JSON.stringify(data, null, 2));
                });

                $("#lightboxIt").on('click', function () {
                    P.init($("#urlproceso").val(), { opacity: 0.7 });
                });

                $("#cart_form").ajaxForm({
                    url: 'checkout.php',
                    success: function (data) {
                        var processUrl = data.processUrl;
                        P.init(processUrl);
                        $("#urlproceso").val(processUrl);
                    },
                    error: function (data) {
                        alert(data.responseJSON.status.message);
                    }
                });
            });
        </script>
    </body>
</html>