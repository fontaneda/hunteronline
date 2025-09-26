<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="Vehiculoespecificobien.aspx.vb" Inherits="ExtranetWeb.Vehiculoespecificobien" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilovehiculoespecificobien.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) 
        {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () 
            {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-67324308-1', 'auto');
        ga('send', 'pageview');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="vehespbiencontenedor_maestro">
        <div class="vehespbientitulo">
            <div class="chequeo_tit1">
                <h2>Actualización de Bienes</h2>
            </div>
            <div class="vehesppiepagina_botones">
                <telerik:RadButton ID="BtnEnviar" runat="server" Width="81px" Height="22px" Text="Grabar" HoveredCssClass="goButtonClassHov" ForeColor="White">
                   <%--CssClass="boton_color" <Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>--%>
                     <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                     </Image>
                </telerik:RadButton>
                <telerik:RadButton ID="BtnDetalle" runat="server" Width="81px" Height="22px" Text="Detalle" HoveredCssClass="goButtonClassHov" ForeColor="White">
                   <%--CssClass="boton_color" <Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>--%>
                     <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                     </Image>
                </telerik:RadButton>
                <telerik:RadButton ID="BtnCancelar" runat="server" Width="81px" Height="22px" Text="Regresar" HoveredCssClass="goButtonClassHov" ForeColor="White">
                    <%--CssClass="boton_color"<Image ImageUrl="img/cb_empty_02.png" IsBackgroundImage="true"></Image>--%>
                     <Image ImageUrl="../images/background/BotonNegro.png" HoveredImageUrl="../images/background/BotonNegro.png"
                          PressedImageUrl="../images/background/BotonNegro.png" IsBackgroundImage="true">
                     </Image>
                </telerik:RadButton>
            </div>
        </div>
        <div class="vehespbieninformacion">
            <%-- <div class="titulocabecerabien">
                   Los datos enviados para actualización serán procesados en línea.
         </div>--%>
            <%-- <div class="vehespbientitulo_informacion_2">
            </div>--%>
            <div class="vehespbientitulo_informacion">
                Bien a actualizar
                <telerik:RadTextBox ID="Txtconcesionario" runat="server" ReadOnly="True" Enabled="False" Width="150px" BackColor="Transparent" />
                Fecha creación
                <telerik:RadTextBox ID="Txtfechacreacion" runat="server" ReadOnly="True" Enabled="False" Width="200px" BackColor="Transparent" />
                Ultima actualización
                <telerik:RadTextBox ID="Txtfechaactualizacion" runat="server" ReadOnly="True" Enabled="False" Width="200px" BackColor="Transparent" />
            </div>
            <div class="vehespbieninformacion_1">
                <div class="bientitulo_11">
                    Código
                </div>
                <div class="biendato_11">
                    <telerik:RadTextBox ID="txtcodigo" runat="server" ReadOnly="True" Enabled="False" BackColor="Transparent" />
                </div>
                <div class="bientitulo_11">
                    Referencia
                </div>
                <div class="biendato_12">
                    <telerik:RadTextBox ID="txtplacabien" runat="server" MaxLength="10" />
                </div>
                <div class="bientitulo_13">
                    Tipo del Bien
                </div>
                <div class="biendato_13">
                    <telerik:RadTextBox ID="txtmotorbien" runat="server" MaxLength="30" Enabled="False" Visible="True" ReadOnly="True" BackColor="Transparent" />
                </div>
                <div class="bientitulo_11">
                    Año
                </div>
                <div class="biendato_11">
                    <telerik:RadTextBox ID="txtaniobien" runat="server" />
                </div>
                <div class="bientitulo_24">
                </div>
                <div class="biendato_24">
                    <telerik:RadTextBox ID="txtobservacionbien" runat="server" Width="460px" Visible="False" />
                </div>
                <telerik:RadNotification ID="rntmensaje" runat="server" Animation="Fade" Height="12px" Position="Center" Style="margin-left: 1px" Width="400px">
                </telerik:RadNotification>
                <%--<div class="vehespbiendar_baja">
                    <asp:CheckBox ID="Chkbdarbaja" runat="server" Text="Marque el bien si ya no le pertenece" />
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>
