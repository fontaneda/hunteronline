<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="busquedaclientefac.aspx.vb" Inherits="ExtranetWeb.busquedaclientefac" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilomodal.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
        </style>
    </head>
    <body style="background:#fff;">
        <form id="form2" method="post" runat="server">
            <div class="contenedor2">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">                
                </telerik:RadScriptManager> 
                <div class="busqueda2">
                    <div class="menu">
                        <div class="icono_texto">
                            <telerik:RadTextBox ID="txtbusqueda" runat="server" Height="22px" Width="280px" EmptyMessage="Búsqueda general"
                                CssClass="content_border">
                            </telerik:RadTextBox>
                        </div>
                        <div class="icono" runat="server" id="divBtnConsulta">
                            <telerik:RadButton ID="BtnConsulta" runat="server" Text="Consultar" ForeColor="Black"
                                Style="top: 0px; left: 0px; height: 32px; width: 32px" ToolTip="Consulta información del cliente">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/search28x28.png" EnableImageButton="true"/>
                            </telerik:RadButton>
                        </div>
                        <div class="icono" runat="server" id="divbtnnuevo">
                            <telerik:RadButton ID="btnnuevo" runat="server" Text="Nuevo" ForeColor="Black" ToolTip="Nuevo cliente" 
                                Style="top: 0px; left: 0px; height: 32px; width: 32px">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/newfile32x32.png" EnableImageButton="true"/>
                            </telerik:RadButton>
                        </div>
                        <div class="icono" runat="server" id="divbtnmodificar">
                            <telerik:RadButton ID="btnmodificar" runat="server" Text="Modificar" ForeColor="Black" ToolTip="Modificar cliente" 
                                Style="top: 0px; left: 0px; height: 32px; width: 32px">
                                <Image IsBackgroundImage="false" ImageUrl="../images/icons/32x32/File_List.png" EnableImageButton="true"/>
                            </telerik:RadButton>
                        </div>
                        <div class="icono" runat="server" id="divBtnAceptar">
                            <telerik:RadButton ID="BtnAceptar" runat="server" Text="Aceptar" ForeColor="Black" ToolTip="Selecciona cliente"
                                Style="top: 0px; left: 0px; height: 32px; width: 32px" AutoPostBack="true">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/check28x28.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="icono" runat="server" id="divbtnguarda">
                            <telerik:RadButton ID="btnguarda" runat="server" Text="Guardar" ForeColor="Black" ToolTip="Guardar Registro" 
                                Style="top: 0px; left: 0px; height: 32px; width: 32px">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/download32x32.png"/>
                            </telerik:RadButton>
                        </div>
                        <div class="icono" runat="server" id="divbtnlimpiar">
                            <telerik:RadButton ID="btnlimpiar" runat="server" Text="Limpiar" ForeColor="Black" ToolTip="Limpiar pantalla" 
                                Style="top: 0px; left: 0px; height: 32px; width: 32px" AutoPostBack="true" Enabled="true">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/32x32/psvt_refresh.png" />
                            </telerik:RadButton>
                        </div>
                        <div id="DivDatosFacturacion" class="clientemonitreo" runat="server">
                            <div class="clientemonitreolabel">
                                Cliente de facturación
                            </div>
                            <div id="Div8" class="clientemonitreotxt" runat="server">
                                <telerik:RadTextBox ID="txtclientefacturacion" runat="server" Width="100%" ReadOnly="true">
                                </telerik:RadTextBox>
                            </div>
                            <div id="Div10" class="clientemonitreochk" runat="server">
                                <asp:checkbox id="chkclientefacturacion" runat="server" Width="200" Text="Mismo cliente de inicio de sesión?"
                                                style="margin: -5px 0px 0px -7px; color:Gray;" AutoPostBack="true">
                                </asp:checkbox>
                            </div>
                        </div>
                    </div>
                    <div class="data2">
                        <telerik:RadGrid ID="rgdconsulta" runat="server" CellSpacing="0" Culture="es-ES"
                            GridLines="None" AutoGenerateColumns="False" Height="140px" Width="930px" AllowAutomaticUpdates="True"
                            Skin="MyCustomSkin" EnableEmbeddedSkins="false">
                            <ClientSettings EnableRowHoverStyle="true">
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="10px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="10px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ID_CLIENTE" HeaderText="Id cliente" UniqueName="ID_CLIENTE">
                                        <FooterStyle Width="60px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="60px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="60px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APELLIDO_PATERNO" HeaderText="Apellido Paterno" UniqueName="APELLIDO_PATERNO">
                                        <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APELLIDO_MATERNO" HeaderText="Apellido Materno" UniqueName="APELLIDO_MATERNO">
                                        <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PRIMER_NOMBRE" HeaderText="Primer Nombre" UniqueName="PRIMER_NOMBRE">
                                        <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SEGUNDO_NOMBRE" HeaderText="Segundo Nombre" UniqueName="SEGUNDO_NOMBRE">
                                        <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FECHA_NACIMIENTO" HeaderText="Fecha Nacimiento" UniqueName="FECHA_NACIMIENTO">
                                        <FooterStyle Width="75px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="75px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="75px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DESC_ESTADO_CIVIL" HeaderText="Estado Civil" UniqueName="DESC_ESTADO_CIVIL">
                                        <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OFICINA" HeaderText="Oficina" UniqueName="OFICINA">
                                        <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                        <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                        <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </div>
                    <div id="Div1" class="data3" runat="server">
                        <div id="Div2" class="datacolunma1" runat="server">
                            <asp:Label ID="lbltitulo1" runat ="server" Text="Ingreso de datos de cliente" Font-Bold="true" Font-Size="Medium"
                                        style="margin-left:10px;" Width="250">
                            </asp:Label>
                            <telerik:RadComboBox ID="cmbdatotipoidcliente" runat="server" CssClass="estilocomboboxmed">
                            </telerik:RadComboBox>
                            <telerik:RadTextBox ID="txtdatoidcliente" runat="server" MaxLength="15" EmptyMessage="Identificación" CssClass="estilotextbox">
                            </telerik:RadTextBox>
                            <telerik:RadTextBox ID="txtdatoapellidopadre" runat="server" MaxLength="50" EmptyMessage="Apellido paterno" CssClass="estilotextboxmedio">
                            </telerik:RadTextBox>
                            <telerik:RadTextBox ID="txtdatoapellidomadre" runat="server" MaxLength="50" EmptyMessage="Apellido materno" CssClass="estilotextboxmedio">
                            </telerik:RadTextBox>
                            <telerik:RadTextBox ID="txtdatonombreprimero" runat="server" MaxLength="50" EmptyMessage="Primer nombre" CssClass="estilotextboxmedio">
                            </telerik:RadTextBox>
                            <telerik:RadTextBox ID="txtdatonombresegundo" runat="server" MaxLength="50" EmptyMessage="Segundo nombre" CssClass="estilotextboxmedio">
                            </telerik:RadTextBox>
                            <br />
                            <telerik:RadDatePicker ID="dtpdatofechanacimiento" runat="server" ToolTip="Seleccione fecha de nacimiento" 
                                                    CssClass="estilocombobox2"  EnableTyping="false" DateInput-DisplayText="F./ nacimiento" 
                                                    MaxDate="2012-12-31" MinDate="1940-01-01">
                                <DateInput DateFormat="MM/dd/yyyy" runat="server"> 
                                </DateInput>
                            </telerik:RadDatePicker>
                            <telerik:RadComboBox ID="cmbdatosexo" runat="server" CssClass="estilocombobox">
                            </telerik:RadComboBox>
                        </div>
                        <div id="Div3" class="datacolunma2" runat="server">
                            <asp:Label ID="lbltitulo2" runat ="server" Text="Ingreso de dirección de domicilio" Font-Bold="true" Font-Size="Medium" 
                                        Width="250" style="margin-left:10px;">
                            </asp:Label>
                            <telerik:RadComboBox ID="cmbdireccionprovincia" runat="server" CssClass="estilocombobox" AutoPostBack="true">
                            </telerik:RadComboBox>
                            <telerik:RadComboBox ID="cmbdireccionciudad" runat="server" CssClass="estilocomboboxmedio" AutoPostBack="true">
                            </telerik:RadComboBox>
                            <telerik:RadComboBox ID="cmbdireccionparroquia" runat="server" CssClass="estilocombobox">
                            </telerik:RadComboBox>
                            <telerik:RadComboBox ID="cmbdireccionsector" runat="server" CssClass="estilocombobox">
                            </telerik:RadComboBox>
                            <telerik:RadTextBox ID="txtdireccionprincipal" runat="server" MaxLength="150" EmptyMessage="Dirección" 
                                                CssClass="estilotextboxmediomulti" TextMode="Multiline">
                            </telerik:RadTextBox>
                            <telerik:RadTextBox ID="txtdireccioninterseccion" runat="server" MaxLength="200" EmptyMessage="Intersección" 
                                                CssClass="estilotextboxaux" Width="210px" style="margin: 14px 0px 0px 10px">
                            </telerik:RadTextBox>
                            <telerik:RadTextBox ID="txtdireccionnumero" runat="server" MaxLength="8" EmptyMessage="Número" 
                                                CssClass="estilotextboxaux" Width="60px" style="margin: 14px 0px 0px 5px"
                                                ClientEvents-OnKeyPress="OnKeyPress">
                            </telerik:RadTextBox>
                        </div> 
                        <div id="Div5" class="datacolunma4" runat="server">
                            <asp:Label ID="lbltitulo5" runat ="server" Text="Ingreso de email principal" Font-Bold="true" Font-Size="Medium"
                                        style="margin-left:10px;" Width="250">
                            </asp:Label>
                            <telerik:RadTextBox ID="txtemailprincipal" runat="server" MaxLength="50" EmptyMessage="Email Principal" CssClass="estilotextboxmedio2">
                            </telerik:RadTextBox>
                        </div>
                        <div id="Div4" class="datacolunma3" runat="server">
                            <asp:Label ID="lbltitulo3" runat ="server" Text="Ingreso de teléfono fijo" Font-Bold="true" Font-Size="Medium"
                                        style="margin-left:10px;" Width="250">
                            </asp:Label>
                            <telerik:RadTextBox ID="txttelefono" runat="server" MaxLength="15" EmptyMessage="Teléfono" 
                                                CssClass="estilotextboxaux" ClientEvents-OnKeyPress="OnKeyPress" 
                                                Width="210px" style="margin: 14px 0px 0px 10px">
                            </telerik:RadTextBox>
                        </div>
                        <div id="Div6" class="datacolunma3" runat="server">
                            <asp:Label ID="lbltitulo4" runat ="server" Text="Ingreso de teléfono celular" Font-Bold="true" Font-Size="Medium"
                                        style="margin-left:10px;" Width="250">
                            </asp:Label>
                            <telerik:RadTextBox ID="txttelefonocelular" runat="server" MaxLength="15" EmptyMessage="Teléfono" 
                                                CssClass="estilotextboxaux" ClientEvents-OnKeyPress="OnKeyPress" 
                                                Width="210px" style="margin: 14px 0px 0px 10px">
                            </telerik:RadTextBox>
                        </div>
                        <telerik:RadTextBox ID="txtregistro" runat="server" MaxLength="10" Visible="false">
                        </telerik:RadTextBox>
                    </div>
                </div>
                <div class="content_renovacion_confirmarpedido_totales_boton">
                    <telerik:RadButton ID="btnConfirmar" runat="server" Text="CONTINUAR" Width="130px"
                        Height="28px" HoveredCssClass="goButtonClassHov" CssClass="boton_color_pagar">
                        <Image ImageUrl="../images/background/BotonPagar.png" HoveredImageUrl="../images/background/BotonPagar.png"
                            PressedImageUrl="../images/background/BotonPagar.png" IsBackgroundImage="true">
                        </Image>
                    </telerik:RadButton>
                </div>
            </div>
            <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
                EnableRoundedCorners="True" Overlay="True">
            </telerik:RadNotification>
        </form>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function OnKeyPress(sender, args) {
                    var keycode = args.get_keyCode()
                    if (!(keycode >= 48 && keycode <= 57) || (keycode >= 96 && keycode <= 105)) {
                        args.set_cancel(true);
                    }
                }
            </script>
            <script type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    return oWindow;
                }
                function AdjustRadWidow() {
                    var oWindow = GetRadWindow();
                    setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
                }
                function ChromeSafariFix(oWindow) {
                    var iframe = oWindow.get_contentFrame();
                    var body = iframe.contentWindow.document.body;
                    setTimeout(function () {
                        var height = body.scrollHeight;
                        var width = body.scrollWidth;
                        var iframeBounds = $telerik.getBounds(iframe);
                        var heightDelta = height - iframeBounds.height;
                        var widthDelta = width - iframeBounds.width;
                        if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                        if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                        oWindow.center();
                    }, 310);
                }
                function returnParent() {
                    var oWnd = GetRadWindow();
                    oWnd.close();
                }
                function returnToParent(valor) {
                    var oArg = new Object();
                    oArg.codigo = valor;
                    var oWnd = GetRadWindow();
                    if (oArg.codigo) {
                        oWnd.close(oArg);
                    } else {
                        alert("Datos no válidos.");
                    }
                }
            </script>  
        </telerik:RadCodeBlock>
    </body>
</html>