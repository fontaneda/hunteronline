﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="renovacion3.aspx.vb" Inherits="ExtranetWeb.renovacion3" %>

<%@ Register Assembly="DevExpress.Web.v23.2, Version=23.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" id="telerikClientEvents1">
//<![CDATA[

        function textbox_OnKeyPress(sender, args) {
            //Add JavaScript handler code here
            if (args.get_keyCode() > 31 && (args.get_keyCode() < 48) || args.get_keyCode() > 57) {
                args.set_cancel(true);
            }
        }
//]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_principal">
        <!-- Begin Slider Panel -->
        <div id="toppanel">
            <div id="panel_left"></div>
            <div id="panel">
                <div class="content clearfix">
                    <div class="content_renovacion_confirmardato_totales">
                        <div class="content_renovacion_confirmardato_totales_grupo">
                            <div class="content_renovacion_confirmardato_totales_icono">
                            </div>
                            <div class="content_renovacion_confirmardato_totales_icono_label">
                                Total de su compra<br />
                            </div>
                        </div>
                        <div class="content_renovacion_confirmardato_totales_labeldivision">
                        </div>
                        <div class="content_renovacion_confirmardato_totales_labelcantidad">
                            Cantidad de productos a renovar:
                        </div>
                        <div class="content_renovacion_confirmardato_totales_textboxcantidad">
                            <asp:Label ID="lblCantidadProducto" runat="server"></asp:Label>
                        </div>
                        <div class="content_renovacion_confirmardato_totales_labeldivision">
                        </div>
                        <div class="content_renovacion_confirmardato_totales_label">
                            SubTotal
                        </div>
                        <div class="content_renovacion_confirmardato_totales_textbox">
                            <asp:Label ID="lblsubtotal" runat="server"></asp:Label>
                        </div>
                        <div class="content_renovacion_confirmardato_totales_label">
                            I.V.A 12%
                        </div>
                        <div class="content_renovacion_confirmardato_totales_textbox">
                            <asp:Label ID="lbliva" runat="server"></asp:Label>
                        </div>
                        <div class="content_renovacion_confirmardato_totales_labeldivision">
                        </div>
                        <div class="content_renovacion_confirmardato_totales_label">
                            Total a Pagar
                        </div>
                        <div class="content_renovacion_confirmardato_totales_textbox">
                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tab_left"></div>
            <div class="tab">
                <ul class="login">
                    <li class="left">&nbsp;</li>
                    <!--<li>Hello Invitado!</li>
                            <li class="sep">|</li>-->
                    <li id="toggle"><a id="open" class="open" href="#">
                        <asp:Label ID="lblTotalCompra1" runat="server"></asp:Label></a><a id="close" style="display: none;"
                            class="close" href="#"><asp:Label ID="lblTotalCompra2" runat="server"></asp:Label></a></li>
                    <li class="right">&nbsp;</li>
                </ul>
            </div>
        </div>
        <!-- End Slider Panel -->
        <div class="content_principal_bloque">
            <div class="content_renovacion_titulopage">
                <h2>
                    Renovación de Productos</h2>
            </div>
            <div class="content_crit_info_detalleitems_productocliente">
                <telerik:RadTabStrip ID="RadTabPrincipal" runat="server" AutoPostBack="True" Width="100%"
                    Skin="Office2010Silver" SelectedIndex="0" MultiPageID="RadMultiPage1">
                    <Tabs>
                        <telerik:RadTab Text="1 | Confirmar Datos" Selected="True" Font-Bold="True" Font-Size="15px"
                            Height="25px">
                        </telerik:RadTab>
                        <telerik:RadTab Text="2 | Formas de Pago" Font-Bold="True" Font-Size="15px" Height="25px"
                            Enabled="False">
                        </telerik:RadTab>
                        <telerik:RadTab Text="3 | Confirmar Pedido" Font-Bold="True" Font-Size="15px" Height="25px"
                            Enabled="False">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Height="390px"
                    Width="100%" CssClass="multiPage">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="corporatePageView">
                        <div class="content_renovacion_confirmardato_bloque">
                            <div class="content_renovacion_titulo">
                                Productos a Renovar</div>
                            <div class="content_renovacion_confirmardato_bloque_col1_parrafo">
                                <p>
                                    Seleccione producto(s) e ingrese la cantidad de años a renovar. El precio total
                                    se
                                    <br />
                                    actualiza automáticamente de acuerdo a la cantidad de años a renovar.</p>
                            </div>
                            <div class="content_renovacion_confirmardato_bloque_col1_botom">
                                <telerik:RadButton ID="btnConfirmarDatoContinuar" runat="server" Text="CONTINUAR">
                                </telerik:RadButton>
                            </div>
                            <div class="content_renovacion_confirmardato_gridcontrol">
                                <telerik:RadGrid ID="productocliente" runat="server" CellSpacing="0" Culture="es-ES"
                                    Width="975px" Height="430px" GridLines="None" AutoGenerateColumns="False" AllowAutomaticUpdates="True"
                                    Skin="Windows7">
                                    <ClientSettings>
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="CODIGO_VEHICULO">
                                        <GroupByExpressions>
                                            <telerik:GridGroupByExpression>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldAlias="GRUPO_NOMBRE" FieldName="GRUPO_NOMBRE" HeaderText="VEHICULO">
                                                    </telerik:GridGroupByField>
                                                </SelectFields>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="GRUPO_NOMBRE"></telerik:GridGroupByField>
                                                </GroupByFields>
                                            </telerik:GridGroupByExpression>
                                            <telerik:GridGroupByExpression>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldAlias="PRODUCTO_NOMBRE_GRUPO" FieldName="PRODUCTO_NOMBRE_GRUPO"
                                                        HeaderText="PRODUCTO" />
                                                </SelectFields>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="PRODUCTO_NOMBRE_GRUPO"></telerik:GridGroupByField>
                                                </GroupByFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <dx:ASPxCheckBox ID="chkI" runat="server" AutoPostBack="true" OnCheckedChanged="chkI_CheckedChanged"
                                                        OnValidation="chkI_Validation">
                                                    </dx:ASPxCheckBox>
                                                </ItemTemplate>
                                                <FooterStyle Width="35px" />
                                                <HeaderStyle Width="35px" />
                                                <ItemStyle Width="35px" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CODIGO_VEHICULO" Visible="false" FilterControlAltText="Filter CODIGO_VEHICULO column"
                                                HeaderText="Vehiculo" UniqueName="CODIGO_VEHICULO">
                                                <FooterStyle Width="80px" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="GRUPO_NOMBRE" Visible="false" FilterControlAltText="Filter GRUPO_NOMBRE column"
                                                HeaderText="Vehiculo" UniqueName="GRUPO_NOMBRE">
                                                <FooterStyle Width="240px" />
                                                <HeaderStyle Font-Bold="True" Width="240px" />
                                                <ItemStyle Width="240px" />
                                            </telerik:GridBoundColumn>
                                            <%--                                            <telerik:GridBoundColumn DataField="PLACA" Visible="false" FilterControlAltText="Filter PLACA column"
                                                HeaderText="Placa" UniqueName="PLACA">
                                                <FooterStyle Width="80px" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="MARCA_NOMBRE" Visible="false" FilterControlAltText="Filter MARCA_NOMBRE column"
                                                HeaderText="Marca" UniqueName="MARCA_NOMBRE">
                                                <FooterStyle Width="120px" />
                                                <HeaderStyle Font-Bold="True" Width="120px" />
                                                <ItemStyle Width="120px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="MODELO_NOMBRE" Visible="false" FilterControlAltText="Filter MODELO_NOMBRE column"
                                                HeaderText="Modelo" UniqueName="MODELO_NOMBRE">
                                                <FooterStyle Width="120px" />
                                                <HeaderStyle Font-Bold="True" Width="120px" />
                                                <ItemStyle Width="120px" />
                                            </telerik:GridBoundColumn>--%><telerik:GridBoundColumn DataField="PRODUCTO_NOMBRE"
                                                FilterControlAltText="Filter PRODUCTO_NOMBRE column" HeaderText="Producto" UniqueName="PRODUCTO_NOMBRE"
                                                Visible="false">
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Font-Bold="True" Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ITEM" FilterControlAltText="Filter ITEM column"
                                                HeaderText="Item" UniqueName="ITEM" Visible="false">
                                                <FooterStyle Width="220px" />
                                                <HeaderStyle Font-Bold="True" Width="220px" />
                                                <ItemStyle Width="220px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ITEM_NOMBRE" FilterControlAltText="Filter ITEM_NOMBRE column"
                                                HeaderText="Años a Renovar" UniqueName="ITEM_NOMBRE" Visible="true">
                                                <FooterStyle Width="130px" />
                                                <HeaderStyle Font-Bold="True" Width="130px" />
                                                <ItemStyle Width="130px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FECHA_FIN" DataFormatString="{0:dd/MMM/yyyy}"
                                                FilterControlAltText="Filter FECHA_FIN column" HeaderText="Fecha de Vencimiento"
                                                UniqueName="FECHA_FIN" Visible="false">
                                                <FooterStyle Font-Bold="True" Width="80px" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <%--                                            <telerik:GridBoundColumn DataField="PRODUCTO" Visible="false" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                                                HeaderText="Producto" UniqueName="PRODUCTO">
                                                <FooterStyle Width="40px" />
                                                <HeaderStyle Font-Bold="True" Width="40px" />
                                                <ItemStyle Width="40px" />
                                            </telerik:GridBoundColumn>--%><telerik:GridTemplateColumn AllowFiltering="False"
                                                FilterControlAltText="Filter ANIO column" HeaderText="Años a Renovar" ReadOnly="True"
                                                ShowFilterIcon="False" UniqueName="ANIO" Visible="false">
                                                <FooterStyle Width="65px" />
                                                <HeaderStyle Font-Bold="True" Width="65px" />
                                                <ItemStyle Width="65px" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="cmbaniorenovar" runat="server" AutoPostBack="True" Filter="Contains"
                                                        OnSelectedIndexChanged="cmbaniorenovar_SelectedIndexChanged" Width="50px">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="ANIO_RENOVACION" FilterControlAltText="Filter column column"
                                                HeaderText="Anio" UniqueName="ANIO_RENOVACION" Visible="false">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRECIO_VENTA" DataFormatString="{0:###,###.##}"
                                                FilterControlAltText="Filter column column" HeaderText="Precio Unitario" UniqueName="PRECIO_VENTA">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="False" FilterControlAltText="Filter PROMOCION column"
                                                HeaderText="Promoción" ShowFilterIcon="False" UniqueName="PROMOCION">
                                                <FooterStyle Width="200px" />
                                                <HeaderStyle Font-Bold="True" Width="200px" />
                                                <ItemStyle Width="200px" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="cmbpromocion" runat="server" AutoPostBack="True" Filter="Contains"
                                                        OnSelectedIndexChanged="cmbpromocion_SelectedIndexChanged" Width="220px">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="VALOR_PROMOCION" DataFormatString="{0:###,###.##}"
                                                EmptyDataText="0" FilterControlAltText="Filter VALOR_PROMOCION column" HeaderText="Valor Prom."
                                                UniqueName="VALOR_PROMOCION">
                                                <FooterStyle Font-Bold="True" Width="50px" />
                                                <HeaderStyle Font-Bold="True" Width="50px" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="DESCUENTO" FilterControlAltText="Filter DESCUENTO column"
                                                HeaderText="% Desc." UniqueName="DESCUENTO">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="txtdescuento" runat="server" AutoPostBack="True" DbValue='<%# Bind("DESCUENTO") %>'
                                                        MaxLength="2" MaxValue="10" MinValue="0" OnTextChanged="txtdescuento_TextChanged"
                                                        Width="40px">
                                                    </telerik:RadNumericTextBox></ItemTemplate>
                                                <FooterStyle Width="50px" />
                                                <HeaderStyle Font-Bold="True" Width="50px" />
                                                <ItemStyle Width="50px" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="VALOR_DESCUENTO" DataFormatString="{0:###,###.##}"
                                                FilterControlAltText="Filter VALOR_DESCUENTO column" HeaderText="Valor Desc."
                                                UniqueName="VALOR_DESCUENTO">
                                                <FooterStyle Font-Bold="True" Width="50px" />
                                                <HeaderStyle Font-Bold="True" Width="50px" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRECIO_TOTAL" DataFormatString="{0:###,###.##}"
                                                FilterControlAltText="Filter PRECIO_TOTAL column" HeaderText="Precio Total" UniqueName="PRECIO_TOTAL">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IVA" DataFormatString="{0:###,###.##}" FilterControlAltText="Filter IVA column"
                                                HeaderText="IVA" UniqueName="IVA">
                                                <FooterStyle Font-Bold="True" Width="40px" />
                                                <HeaderStyle Font-Bold="True" Width="40px" />
                                                <ItemStyle HorizontalAlign="Right" Width="40px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRECIO_CLIENTE" DataFormatString="{0:###,###.##}"
                                                FilterControlAltText="Filter PRECIO_CLIENTE column" HeaderText="Precio Cliente"
                                                UniqueName="PRECIO_CLIENTE">
                                                <FooterStyle Font-Bold="True" Width="70px" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle HorizontalAlign="Right" Width="70px" />
                                            </telerik:GridBoundColumn>
                                            <%--                                            <telerik:GridBoundColumn DataField="VALOR" Visible="false" FilterControlAltText="Filter VALOR column"
                                                HeaderText="Valor" UniqueName="VALOR" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>--%></Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <GroupHeaderItemStyle Font-Bold="True" />
                                    </MasterTableView><FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid></div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="productsPageView">
                        <div class="content_renovacion_formapago_bloque">
                            <div class="content_renovacion_titulo">
                                Información de Pago</div>
                            <div class="content_renovacion_formapago_informacion">
                                <div class="content_renovacion_formapago_informacion_col">
                                    <div class="content_renovacion_formapago_informacion_logodinners">
                                        <img src="../images/icons/48x48/diners.png" alt="DINERS" /></div>
                                </div>
                                <div class="content_renovacion_formapago_informacion_div">
                                </div>
                                <div class="content_renovacion_formapago_informacion_col">
                                    <div class="content_renovacion_formapago_informacion_label_titulo">
                                        Ingrese los datos de su tarjeta
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Nombre Completo:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoNombre" runat="server" Width="195px">
                                        </telerik:RadTextBox></div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Tipo de identificación:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_radio">
                                        <asp:RadioButtonList ID="rblTipoIdentificacion" runat="server" AutoPostBack="True"
                                            CellPadding="-1" CellSpacing="-1" Height="50px">
                                            <asp:ListItem Selected="True" Value="1">Cédula de Identidad</asp:ListItem>
                                            <asp:ListItem Value="2">R.U.C.</asp:ListItem>
                                            <asp:ListItem Value="3">Pasaporte</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        No. Identificación:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoIdentificacion" runat="server" AutoPostBack="true"
                                            MaxLength="10" Width="195px">
                                            <ClientEvents OnKeyPress="textbox_OnKeyPress" />
                                        </telerik:RadTextBox><%--                                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" 
                                            ErrorMessage="*" ControlToValidate="txtFormaPagoIdentificacion"
                                            ValidationGroup="vgSubmit" ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ErrorMessage="Phone Number is not valid"
                                            ValidationGroup="vgSubmit" ControlToValidate="txtFormaPagoIdentificacion" 
                                            ForeColor="Red" ValidationExpression="^[0-9'@&amp;#.\s]+$">
                                        </asp:RegularExpressionValidator>--%></div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Dirección:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoDireccion" runat="server" Width="195px">
                                        </telerik:RadTextBox></div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Teléfono:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoTelefono" runat="server" AutoPostBack="true"
                                            MaxLength="15" Width="195px">
                                            <ClientEvents OnKeyPress="textbox_OnKeyPress" />
                                        </telerik:RadTextBox>
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Email:
                                    </div>
                                     <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoEmail" runat="server" AutoPostBack="true"
                                            MaxLength="50" Width="195px">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="content_renovacion_formapago_terminocondicion">
                                <div class="content_renovacion_formapago_terminocondicion_check">
                                    <asp:CheckBox ID="chkTerminosCondiciones" runat="server" Text=" " />Acepto los <a
                                        style="text-decoration: underline;" href="../forms/termino.aspx" target="_blank">
                                        Términos y condiciones</a> de renovación</div>
                                <div class="content_renovacion_formapago_terminocondicion_button">
                                    <telerik:RadButton ID="btnFormaPagoRegresar" runat="server" Text="REGRESAR">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnFormaPagoContinuar" runat="server" Text="CONTINUAR">
                                    </telerik:RadButton>
                                </div>
                            </div>
                            <div class="content_renovacion_formapago_informacionchequeo">
                                <p style="margin-left: 20px;">
                                    Usted puede realizar chequeos a sus vehículos luego de transcurrir 72 horas a partir
                                    del pago de renovaciones.</p>
                            </div>
                            <div class="content_renovacion_formapago_banner">
                                <div class="content_renovacion_formapago_banner_col1">
                                    <strong>¿Necesita ayuda con su renovación?</strong> <span style="color: #999999;
                                        font-weight: bold;">Llámenos al:</span><br />
                                    <br />
                                    <img src="../images/background/callCenterHunter.png" alt="Call Center Hunter" style="margin: 0 20px 0 0;" /><img
                                        src="../images/background/1800Hunter.png" alt="Call Center Hunter" /></div>
                                <div class="content_renovacion_formapago_banner_col2">
                                    <strong>Seguridad y protección</strong><br />
                                    <br />
                                    <img src="../images/background/verisign.png" alt="VeriSign" /></div>
                            </div>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="servicesPageView">
                        <div class="content_renovacion_confirmarpedido_bloque">
                            <div class="content_renovacion_titulo">
                                Confirme los datos de las renovaciones a realizar</div>
                            <div class="content_renovacion_confirmarpedido_cabecera">
                                <div style="display: block; line-height: 40px; vertical-align: middle; height: 40px;">
                                    <strong>Forma de Pago: </strong>Diners
                                    <img src="../images/background/diners2.png" alt="Diners" /></div>
                                <strong>Número de Orden: </strong>9
                            </div>
                            <div class="content_renovacion_confirmarpedido_gridcontrol">
                                <telerik:RadGrid ID="rgdproductoclienterenovacion" runat="server" CellSpacing="0"
                                    Width="955px" Culture="es-ES" Height="130px" GridLines="None" AutoGenerateColumns="False"
                                    AllowAutomaticUpdates="True" Skin="Windows7">
                                    <ClientSettings>
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="CODIGO_VEHICULO">
                                        <GroupByExpressions>
                                            <telerik:GridGroupByExpression>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldAlias="GRUPO_NOMBRE" FieldName="GRUPO_NOMBRE" HeaderText="VEHICULO">
                                                    </telerik:GridGroupByField>
                                                </SelectFields>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="GRUPO_NOMBRE"></telerik:GridGroupByField>
                                                </GroupByFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <%--                                        <telerik:GridBoundColumn DataField="GRUPO_NOMBRE" FilterControlAltText="Filter GRUPO_NOMBRE column"
                                                HeaderText="Vehiculo" UniqueName="GRUPO_NOMBRE">
                                                <FooterStyle Width="250px" />
                                                <HeaderStyle Font-Bold="True" Width="250px" />
                                                <ItemStyle Width="250px" />
                                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="PRODUCTO_NOMBRE" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                                                HeaderText="Producto" UniqueName="PRODUCTO_NOMBRE">
                                                <FooterStyle Width="80px" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ITEM_NOMBRE" FilterControlAltText="Filter ITEM_NOMBRE column"
                                                HeaderText="Años a Renovar" UniqueName="ITEM_NOMBRE">
                                                <FooterStyle Width="100px" />
                                                <HeaderStyle Font-Bold="True" Width="100px" />
                                                <ItemStyle Width="100px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FECHA_FIN" Visible="false" FilterControlAltText="Filter FECHA_FIN column"
                                                HeaderText="Fecha de Vencimiento" UniqueName="FECHA_FIN" DataFormatString="{0:dd/MMM/yyyy}">
                                                <FooterStyle Width="90px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="90px" />
                                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRECIO_VENTA" DataFormatString="{0:###,###.##}"
                                                FilterControlAltText="Filter column column" HeaderText="Precio Unitario" UniqueName="PRECIO_VENTA">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PROMOCION" FilterControlAltText="Filter column column"
                                                HeaderText="Promoción" UniqueName="PROMOCION">
                                                <FooterStyle Font-Bold="True" Width="80px" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VALOR_PROMOCION" Visible="true" FilterControlAltText="Filter VALOR_PROMOCION column"
                                                HeaderText="Valor Prom." UniqueName="VALOR_PROMOCION" DataFormatString="{0:N2}">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VALOR_DESCUENTO" Visible="true" DataFormatString="{0:N2}"
                                                FilterControlAltText="Filter VALOR_DESCUENTO column" HeaderText="Valor Desc."
                                                UniqueName="VALOR_DESCUENTO">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRECIO_TOTAL" DataFormatString="{0:###,###.##}"
                                                FilterControlAltText="Filter PRECIO_TOTAL column" HeaderText="Precio Total" UniqueName="PRECIO_TOTAL">
                                                <FooterStyle Font-Bold="True" Width="60px" />
                                                <HeaderStyle Font-Bold="True" Width="60px" />
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView><FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid></div>
                            <div class="content_renovacion_confirmarpedido_subtotal">
                                <div class="content_renovacion_confirmarpedido_subtotal_col1">
                                    Subtotal:
                                </div>
                                <div class="content_renovacion_confirmarpedido_subtotal_col2">
                                    <asp:Label ID="lblConfirmarPedidoSubtotal" runat="server"></asp:Label></div>
                            </div>
                            <div class="content_renovacion_confirmarpedido_subtotal">
                                <div class="content_renovacion_confirmarpedido_subtotal_col1">
                                    IVA 12%:
                                </div>
                                <div class="content_renovacion_confirmarpedido_subtotal_col2">
                                    <asp:Label ID="lblConfirmarPedidoIva" runat="server"></asp:Label></div>
                            </div>
                            <div class="content_renovacion_confirmarpedido_total">
                                <div class="content_renovacion_confirmarpedido_total_col1">
                                    Cant. de productos seleccionados:<asp:Label ID="lblConfirmarPedidoCantidadProducto"
                                        runat="server"></asp:Label></div>
                                <div class="content_renovacion_confirmarpedido_total_col2">
                                    Total a Pagar:
                                </div>
                                <div class="content_renovacion_confirmarpedido_total_col3">
                                    <asp:Label ID="lblConfirmarPedidoTotalPagar" runat="server"></asp:Label></div>
                            </div>
                            <div class="content_renovacion_confirmarpedido_bloque_irapagar">
                                <div class="content_renovacion_confirmarpedido_bloque_irapagar_col1">
                                    Hacer clic una sola vez en el botón ir a pagar. Al Hacer clic en el botón Ir a pagar
                                    será re-direccionado al procesador de pago.
                                </div>
                                <div class="content_renovacion_confirmarpedido_bloque_irapagar_col2">
                                    <telerik:RadButton ID="btnConfirmarPedidoRegresar" runat="server" Text="REGRESAR">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnConfirmarPedidoCancelar" runat="server" Text="CANCELAR">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnConfirmarPedidoIrAPagar" runat="server" Text="IR A PAGAR">
                                    </telerik:RadButton>
                                </div>
                            </div>
                            <div class="content_renovacion_formapago_informacionchequeo">
                                <p style="margin-left: 20px;">
                                    Usted puede realizar chequeos a sus vehículos luego de transcurrir 72 horas a partir
                                    del pago de renovaciones.</p>
                            </div>
                            <div class="content_renovacion_formapago_banner">
                                <div class="content_renovacion_formapago_banner_col1">
                                    <strong>¿Necesita ayuda con su renovación?</strong> <span style="color: #999999;
                                        font-weight: bold;">Llámenos al:</span>
                                    <img src="../images/background/callCenterHunter.png" alt="Call Center Hunter" style="margin: 0 20px 0 0;" /><img
                                        src="../images/background/1800Hunter.png" alt="Call Center Hunter" /></div>
                                <div class="content_renovacion_formapago_banner_col2">
                                    <strong>Seguridad y protección</strong>
                                    <img src="../images/background/verisign.png" alt="VeriSign" /></div>
                            </div>
                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="btnregresaproductos">
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadTabPrincipal">
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
            </div>
        </div>
    </div>
    <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center"
        EnableRoundedCorners="True" Overlay="True" ContentIcon="">
    </telerik:RadNotification>
    <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:RegExpTextBoxSetting ValidationExpression="[0-9]{6,}" ErrorMessage="Enter more than 6 figures">
            <TargetControls>
                <%--<telerik:TargetInput ControlID="txtFormaPagoIdentificacion" />--%>
            </TargetControls>
        </telerik:RegExpTextBoxSetting>
    </telerik:RadInputManager>
</asp:Content>
