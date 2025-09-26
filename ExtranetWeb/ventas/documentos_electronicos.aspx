<%@  Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" 
    CodeBehind="documentos_electronicos.aspx.vb" Inherits="ExtranetWeb.documentos_electronicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Hunter Online - Pagos de Servicios Online</title>
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
            <div class="transacciones">
                <h2 class="transac-title documentos">
                    Consulta de Documentos Electrónicos
                </h2>

                <div class="search-bienes">
                    <input type="text" placeholder="Busqueda de documentos" id="txtfiltro" runat="server">
                </div>
                <ul class="tipo-documentos">
                    <li>
                        <a id="btnfiltrofactura" class="show" runat="server">
                            Factura
                        </a>
                    </li>
                    <li>
                        <a id="btnfiltrocontrato" runat="server">
                            Contrato
                        </a>
                    </li>
                    <li>
                        <a id="btnfiltroretencion" runat="server">
                            Retención
                        </a>
                    </li>
                    <li>
                        <a id="btnfiltroguia" runat="server">
                            Guia de Remisión
                        </a>
                    </li>
                    <li>
                        <a id="btnfiltroncr" runat="server">
                            Nota CR
                        </a>
                    </li>
                    <li>
                        <a id="btnfiltrondb" runat="server">
                            Nota DB
                        </a>
                    </li>
                </ul>
                <div class="documentos-wrapper">
                    <ul class="estado-documento">
                        <li>Autorizado</li>
                        <li>Pendiente / Autorización</li>
                    </ul>
                    <ASP:Repeater id="Rpt_documentos" runat="server">
                    <ItemTemplate>
                        <div class="documento-contenedor autorizado">
                            <div class="documento-datos">
                                <h3>
                                    <asp:Label ID="lbltipodoc" runat="server" text='<%# Eval("TIPO_DOCUMENTO") %>'></asp:Label> 
                                    <asp:Label ID="lblfactura" runat="server" text='<%# Eval("NUMERO_DOCUMENTO") %>'></asp:Label>
                                    <asp:Label ID="lblcodigoid" runat="server" text='<%# Eval("CODIGO_ID") %>' Visible="false"></asp:Label>
                                </h3>
                                <p>
                                    <asp:Label ID="lblcliente" runat="server" text='<%# Eval("CLIENTE") %>'></asp:Label>
                                    <span>
                                    <asp:Label ID="lblfecha" runat="server" text='<%# Eval("FECHA") %>'></asp:Label>
                                    </span>
                                </p>
                            </div>
                            <h4 class="valor-documento">
                                <asp:Label ID="lblvalor" runat="server" text='<%# Eval("TOTAL") %>'></asp:Label>
                            </h4>
                            <ul class="documentos-opciones" id ="divseccionbotones" runat="server">
                                <li class="download">
                                    <asp:ImageButton ID="btnreenviar" ImageUrl="../images/img_mkt/reenviar.png"  
                                    AlternateText="" runat="server" OnClick="clk_rpt_reenviar" 
                                    ToolTip="Reenviar al correo" />
                                </li>
                                <li>
                                    <asp:ImageButton ID="btndescargar" ImageUrl="../images/img_mkt/download.png"  
                                    AlternateText="" runat="server" OnClick="clk_rpt_descargar" ToolTip="Descargar"/>
                                </li>
                            </ul>
                        </div>
                    </ItemTemplate>
                    </ASP:Repeater>
                </div>
            </div>
        </section>
        <script type="text/javascript">
            function fnOpen(file1, ruta1, id1, file2, ruta2, id2, file3, ruta3, id3) {
                var dir = 'descarga_documento.aspx?FILENAME=' + file1 + '&RUTA=' + ruta1 + '&COD=' + id1
                window.open(dir, file1);

                dir = 'descarga_documento.aspx?FILENAME=' + file2 + '&RUTA=' + ruta2 + '&COD=' + id2
                window.open(dir, file2);
                if (id3 != 'NO') {
                    dir = 'descarga_documento.aspx?FILENAME=' + file3 + '&RUTA=' + ruta3 + '&COD=' + id3
                    window.open(dir, file3);
                }
            }
        </script>
    </form>
</asp:Content>
