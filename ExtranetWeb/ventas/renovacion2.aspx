<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="renovacion2.aspx.vb" Inherits="ExtranetWeb.renovacion2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_principal">
        <!-- Begin Slider Panel -->
        <div id="toppanel">
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
                <telerik:RadTabStrip ID="RadTabPrincipal" runat="server" AutoPostBack="True" Width="930px"
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
                                    Width="900px" Height="410px" GridLines="None" AutoGenerateColumns="False" AllowAutomaticUpdates="True"
                                    Skin="Windows7">
                                    <ClientSettings>
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="CODIGO_VEHICULO">
<%--                                        <GroupByExpressions>
                                            <telerik:GridGroupByExpression>
                                                <SelectFields>
                                                    <telerik:GridGroupByField FieldAlias="GRUPO_NOMBRE" FieldName="GRUPO_NOMBRE" HeaderText="VEHICULO">
                                                    </telerik:GridGroupByField>
                                                </SelectFields>
                                                <GroupByFields>
                                                    <telerik:GridGroupByField FieldName="GRUPO_NOMBRE"></telerik:GridGroupByField>
                                                </GroupByFields>
                                            </telerik:GridGroupByExpression>
                                        </GroupByExpressions>--%>
                                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkI" runat="server" AutoPostBack="true" OnCheckedChanged="chkI_CheckedChanged" />
                                                </ItemTemplate>
                                                <FooterStyle Width="25px" />
                                                <HeaderStyle Width="25px" />
                                                <ItemStyle Width="25px" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CODIGO_VEHICULO" Visible="false" FilterControlAltText="Filter CODIGO_VEHICULO column"
                                                HeaderText="Vehiculo" UniqueName="CODIGO_VEHICULO">
                                                <FooterStyle Width="80px" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle Width="80px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="GRUPO_NOMBRE" Visible="true" FilterControlAltText="Filter GRUPO_NOMBRE column"
                                                HeaderText="Vehiculo" UniqueName="GRUPO_NOMBRE">
                                                <FooterStyle Width="240px" />
                                                <HeaderStyle Font-Bold="True" Width="240px" />
                                                <ItemStyle Width="240px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PLACA" Visible="false" FilterControlAltText="Filter PLACA column"
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
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRODUCTO" Visible="false" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                                                HeaderText="Producto" UniqueName="PRODUCTO">
                                                <FooterStyle Width="40px" />
                                                <HeaderStyle Font-Bold="True" Width="40px" />
                                                <ItemStyle Width="40px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PRODUCTO_NOMBRE" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                                                HeaderText="Producto" UniqueName="PRODUCTO_NOMBRE">
                                                <FooterStyle Width="110px" />
                                                <HeaderStyle Font-Bold="True" Width="110px" />
                                                <ItemStyle Width="110px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FECHA_FIN" FilterControlAltText="Filter FECHA_FIN column"
                                                HeaderText="Fecha de Vencimiento" UniqueName="FECHA_FIN" DataFormatString="{0:dd/MMM/yyyy}">
                                                <FooterStyle Width="80px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="80px" />
                                                <ItemStyle Width="80px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column"
                                                HeaderText="Valor" UniqueName="VALOR" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" HorizontalAlign="Right"/>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SUBTOTAL" FilterControlAltText="Filter SUBTOTAL column"
                                                HeaderText="Sub-Total" UniqueName="SUBTOTAL" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="False" FilterControlAltText="Filter ANIO column"
                                                HeaderText="Años a Renovar" ShowFilterIcon="False" UniqueName="ANIO" ReadOnly="True">
                                                <FooterStyle Width="65px" />
                                                <HeaderStyle Font-Bold="True" Width="65px" />
                                                <ItemStyle Width="65px" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox runat="server" ID="cmbaniorenovar" Width="50px" Filter="Contains"
                                                        OnSelectedIndexChanged="cmbaniorenovar_SelectedIndexChanged" AutoPostBack="True">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="TOTAL" FilterControlAltText="Filter TOTAL column"
                                                HeaderText="Total" UniqueName="TOTAL" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" HorizontalAlign="Right" />
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
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="productsPageView">
                        <div class="content_renovacion_formapago_bloque">
                            <div class="content_renovacion_titulo">
                                Información de Pago</div>
                            <div class="content_renovacion_formapago_informacion">
                                <div class="content_renovacion_formapago_informacion_col">
                                    <div class="content_renovacion_formapago_informacion_logodinners">
                                        <img src="../images/icons/48x48/diners.png" alt="DINERS" />
                                    </div>
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
                                        <telerik:RadTextBox ID="txtFormaPagoNombre" runat="server">
                                        </telerik:RadTextBox>
                                    </div>
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
                                        <telerik:RadTextBox ID="txtFormaPagoIdentificacion" runat="server">
                                        </telerik:RadTextBox>
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Dirección:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoDireccion" runat="server">
                                        </telerik:RadTextBox>
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_label">
                                        Teléfono:
                                    </div>
                                    <div class="content_renovacion_formapago_informacion_textbox">
                                        <telerik:RadTextBox ID="txtFormaPagoTelefono" runat="server">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="content_renovacion_formapago_terminocondicion">
                                <div class="content_renovacion_formapago_terminocondicion_check">
                                    <asp:CheckBox ID="chkTerminosCondiciones" runat="server" Text="Acepto los Términos y condiciones de renovación" />
                                </div>
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
                                    <img src="../images/background/callCenterHunter.png" alt="Call Center Hunter" style="margin: 0 20px 0 0;" />
                                    <img src="../images/background/1800Hunter.png" alt="Call Center Hunter" />
                                </div>
                                <div class="content_renovacion_formapago_banner_col2">
                                    <strong>Seguridad y protección</strong><br />
                                    <br />
                                    <img src="../images/background/verisign.png" alt="VeriSign" />
                                </div>
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
                                    <img src="../images/background/diners2.png" alt="Diners" />
                                </div>
                                <strong>Número de Orden: </strong>9
                            </div>
                            <div class="content_renovacion_confirmarpedido_gridcontrol">
                                <telerik:RadGrid ID="rgdproductoclienterenovacion" runat="server" CellSpacing="0"
                                    Width="870px" Culture="es-ES" Height="130px" GridLines="None" AutoGenerateColumns="False"
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
                                            <telerik:GridBoundColumn DataField="PRODUCTO_NOMBRE" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                                                HeaderText="Producto" UniqueName="PRODUCTO_NOMBRE">
                                                <FooterStyle Width="130px" />
                                                <HeaderStyle Font-Bold="True" Width="130px" />
                                                <ItemStyle Width="130px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FECHA_FIN" FilterControlAltText="Filter FECHA_FIN column"
                                                HeaderText="Fecha de Vencimiento" UniqueName="FECHA_FIN" DataFormatString="{0:dd/MMM/yyyy}">
                                                <FooterStyle Width="90px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="90px" />
                                                <ItemStyle Width="90px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column"
                                                HeaderText="Valor" UniqueName="VALOR" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SUBTOTAL" FilterControlAltText="Filter SUBTOTAL column"
                                                HeaderText="Sub-Total" UniqueName="SUBTOTAL" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ANIO" FilterControlAltText="Filter ANIO column"
                                                HeaderText="Años a Renovar" UniqueName="ANIO">
                                                <FooterStyle Width="65px" />
                                                <HeaderStyle Font-Bold="True" Width="65px" />
                                                <ItemStyle Width="65px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TOTAL" FilterControlAltText="Filter TOTAL column"
                                                HeaderText="Total" UniqueName="TOTAL" DataFormatString="{0:$###,###.##}">
                                                <FooterStyle Width="70px" Font-Bold="True" />
                                                <HeaderStyle Font-Bold="True" Width="70px" />
                                                <ItemStyle Width="70px" HorizontalAlign="Right" />
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
                            <div class="content_renovacion_confirmarpedido_subtotal">
                                <div class="content_renovacion_confirmarpedido_subtotal_col1">
                                    Subtotal:
                                </div>
                                <div class="content_renovacion_confirmarpedido_subtotal_col2">
                                    <asp:Label ID="lblConfirmarPedidoSubtotal" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="content_renovacion_confirmarpedido_subtotal">
                                <div class="content_renovacion_confirmarpedido_subtotal_col1">
                                    IVA 12%:
                                </div>
                                <div class="content_renovacion_confirmarpedido_subtotal_col2">
                                    <asp:Label ID="lblConfirmarPedidoIva" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="content_renovacion_confirmarpedido_total">
                                <div class="content_renovacion_confirmarpedido_total_col1">
                                    Cant. de productos seleccionados:<asp:Label ID="lblConfirmarPedidoCantidadProducto"
                                        runat="server"></asp:Label></div>
                                <div class="content_renovacion_confirmarpedido_total_col2">
                                    Total a Pagar:
                                </div>
                                <div class="content_renovacion_confirmarpedido_total_col3">
                                    <asp:Label ID="lblConfirmarPedidoTotalPagar" runat="server"></asp:Label>
                                </div>
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
                                    <img src="../images/background/callCenterHunter.png" alt="Call Center Hunter" style="margin: 0 20px 0 0;" />
                                    <img src="../images/background/1800Hunter.png" alt="Call Center Hunter" />
                                </div>
                                <div class="content_renovacion_formapago_banner_col2">
                                    <strong>Seguridad y protección</strong>
                                    <img src="../images/background/verisign.png" alt="VeriSign" />
                                </div>
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
    </telerik:RadInputManager>
</asp:Content>
