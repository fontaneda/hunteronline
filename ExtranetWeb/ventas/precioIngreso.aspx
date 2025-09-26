<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="precioIngreso.aspx.vb" Inherits="ExtranetWeb.precioIngreso" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>Hunter Online - Modificar precios</title>
    <link rel="stylesheet" href="../styles/css_mkt/int-styles.css" />
	<link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
<%--        <div id="dvdmensajes" class="messages" runat="server" >
            <p>
                <label id="lblmensajeexternoerror" runat="server"></label>    
            </p>
        </div> --%> 
        <section class="info-body">     
            <div class="cliente-form">
		        <div class="input-group d-flex flex-column">  
			        <h2 class="label-input">Cliente</h2>
			        <div class="d-flex">
                        <input class="form-control w-50" type="text" ID="txtIdentificacion" runat="server" maxlength="10" readonly="True" />
                        <input class="form-control search w-50" type="text" ID="txtNombre" runat="server" readonly="True"/>
                        <telerik:RadButton ID="btnCliente" runat="server" Text=" " Style="top: 30px; left: 5px;"
                            ToolTip="Consulta de cliente" Height="23px" Width="23px">
                            <Image IsBackgroundImage="False" ImageUrl="../images/icons/24x24/Lupa_23_23.png" />
                        </telerik:RadButton> 
			        </div>
		        </div>
		        <div class="input-group d-flex flex-column">
			        <h2 class="label-input">Vehículo</h2>
			        <div class="d-flex"> 
				        <input class="form-control w-50" type="text" ID="txtcodigovehiculo" runat="server" maxlength="10" readonly="True"/>
				        <input class="form-control search w-50" type="text" ID="txtdescripcion" runat="server" readonly="True"/>
                        <telerik:RadButton ID="btnVehiculo" runat="server" Text=" " Style="top: 30px; left: 5px;"
                            ToolTip="Consulta de vehículo" Height="23px" Width="23px">
                            <Image IsBackgroundImage="False" ImageUrl="../images/icons/24x24/Lupa_23_23.png" />
                        </telerik:RadButton> 
			        </div>
		        </div>
                <div class="input-group d-flex">
			        <div>
				        <h2 class="label-input">Orden</h2>
				        <input class="form-control" type="text" ID="txtorden" runat="server" maxlength="10" readonly="True"/>
			        </div>
			        <div class="w-100 ml-2">
				        <h2 class="label-input">Producto</h2>
				        <input class="form-control w-100" type="text" ID="txtproducto" runat="server" maxlength="10" readonly="True"/>
			        </div>
		        </div>
                <div class="input-group d-flex flex-align-center flex-justify-between" >
			        <div>
				        <h2 class="label-input">Precio $</h2>
				        <input class="form-control"	type="text"	ID="txtprecio" runat="server" maxlength="13" readonly="True"/>
			        </div>
			        <div>
				        <h2 class="label-input">Propuesta $</h2>
				        <input class="form-control" type="text" ID="txtpropuesta" runat="server" maxlength="7"/>
			        </div>
			        <div
				        class="alert-precio d-flexflex-align-center flex-justify-center">
				        <span>
					        <img src="../images/img_mkt/alert-icon.png" alt="" />
				        </span>
				        El precio a ingresar será sin IVA
			        </div>
		        </div>
                <div class="content_toolbar_textbox" style="width:0px;">
                    <asp:Label ID="lblfecha" runat="server" Text="Label" Visible="False" />
                    <asp:Label ID="lblproducto" runat="server" Text="Label"  Visible="False"/>
                    <asp:Label ID="lblorigen" runat="server" Text="Label"  Visible="False"/>
                    <asp:Label ID="lbltransaccion" runat="server" Text="Label" Visible="False" />
                </div>
            </div>  
            <div class="buttons-section d-flex flex-justify-center flex-align-center" >
			    <button class="btn btn-blue" ID="BtnLimpiar" runat="server">Limpiar</button>
			    <button class="btn btn-green" ID="BtnBuscar" runat="server">Buscar</button>
                <button class="btn btn-green" ID="btnGrabar" runat="server">Grabar</button>
		    </div>
            <div class="table-data thead-grey">
			    <telerik:RadGrid ID="consultacliente" runat="server" AllowCustomPaging="True" AllowPaging="True"
                    Height="420px" PageSize="300" VirtualItemCount="2" ShowStatusBar="True" Width="700px"
                    Skin="MyCustomSkin" EnableEmbeddedSkins="False" CellSpacing="0" Culture="es-ES"
                    GridLines="None" 
                    OnSelectedIndexChanged="consultacliente_SelectedIndexChanged" ShowFooter="True">
                    <GroupingSettings CaseSensitive="false" />
                    <SortingSettings SortedBackColor="BurlyWood" />
                    <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true">
                        <Selecting AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="PRODUCTO"
                        NoDetailRecordsText="" NoMasterRecordsText="" ShowFooter="False">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="CLIENTE" FilterControlAltText="Filter CLIENTE column"
                                HeaderText="Cliente" UniqueName="CLIENTE">
                                <FooterStyle CssClass="estilogridcontrol" Width="220px" />
                                <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="220px" />
                                <ItemStyle CssClass="estilogridcontrol" Width="220px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VEHICULO" FilterControlAltText="Filter VEHICULO column"
                                HeaderText="Bien Protegido" UniqueName="VEHICULO">
                                <FooterStyle CssClass="estilogridcontrol" Width="320px" />
                                <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="320px" />
                                <ItemStyle CssClass="estilogridcontrol" Width="320px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CODIGO_VEHICULO"  FilterControlAltText="Filter CODIGO_VEHICULO column"
                                HeaderText="Cod.Vehículo" UniqueName="CODIGO_VEHICULO">
                                <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CODIGO_CLIENTE" Display="false" FilterControlAltText="Filter CODIGO_CLIENTE column"
                                HeaderText="Cod.Cliente" UniqueName="CODIGO_CLIENTE">
                                <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRODUCTO" Display="false" FilterControlAltText="Filter PRODUCTO column"
                                HeaderText="PRODUCTO" UniqueName="PRODUCTO">
                                <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ORIGEN" Display="false" FilterControlAltText="Filter PRODORIGENUCTO column"
                                HeaderText="ORIGEN" UniqueName="ORIGEN">
                                <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TIPO_TRANSACCION" Display="false" FilterControlAltText="Filter TIPO_TRANSACCION column"
                                HeaderText="Tipo" UniqueName="TIPO_TRANSACCION">
                                <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHA" Display="false" FilterControlAltText="Filter FECHA column"
                                HeaderText="Tipo" UniqueName="FECHA">
                                <FooterStyle Width="0px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="0px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="0px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRODUCTO_NOMBRE" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                                HeaderText="Servicio" UniqueName="PRODUCTO_NOMBRE">
                                <FooterStyle Width="180px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="180px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="180px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TOTAL_ITEM" DataFormatString="{0:N2}" FilterControlAltText="Filter column column"
                                HeaderText="Precio Venta" UniqueName="TOTAL_ITEM">
                                <FooterStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                <ItemStyle HorizontalAlign="Right" Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ITEM_PROPUESTA" DataFormatString="{0:N2}" FilterControlAltText="Filter column column"
                                HeaderText="Propuesta" UniqueName="ITEM_PROPUESTA">
                                <FooterStyle Font-Bold="True" Width="90px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="90px" CssClass="estilogridcontrol" />
                                <ItemStyle HorizontalAlign="Right" Width="90px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NUMERO_GENERAL" FilterControlAltText="Filter NUMERO_GENERAL column"
                                HeaderText="Orden" UniqueName="NUMERO_GENERAL">
                                <FooterStyle Width="100px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="100px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="100px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USUARIO" FilterControlAltText="Filter USUARIO column"
                                HeaderText="Usuario" UniqueName="USUARIO">
                                <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                                <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                                <ItemStyle Width="120px" CssClass="estilogridcontrol" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <PagerStyle PageSizeControlType="RadComboBox" Visible="False">
                        </PagerStyle>
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox" Visible="False"></PagerStyle>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                </telerik:RadGrid> 
		    </div>
        </section>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function VerificaCliente() {
                    __doPostBack('txtIdentificacion', '');
                }
                function OnClientClose(oWnd, args) {
                    var arg = args.get_argument();
                    if (arg) {
                        var codigo = arg.codigo;
                        var nombre = arg.nombre;
                        var txtid = document.getElementById("<%=txtIdentificacion.ClientID %>");
                        txtid.value = codigo;
                        var txtnombre = document.getElementById("<%=txtNombre.ClientID %>");
                        txtnombre.value = nombre;
                    }
                }
                function OnClientCloseVehiculo(oWnd, args) {
                    var arg = args.get_argument();
                    if (arg) {
                        var codigo = arg.codigo;
                        var nombre = arg.nombre;
                        var txtid = document.getElementById("<%=txtcodigovehiculo.ClientID %>");
                        txtid.value = codigo;
                        var txtnombre = document.getElementById("<%=txtdescripcion.ClientID %>");
                        txtnombre.value = nombre;
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadWindow ID="modalpopupcliente" runat="server" Behaviors="Close" OnClientClose="OnClientClose"
            NavigateUrl="busquedacliente.aspx" Opacity="100" Title="Búsqueda de Cliente"
            CssClass="elementsoporte" AutoSize="True">
        </telerik:RadWindow>
        <telerik:RadWindow ID="modalpopupclientevehiculo" runat="server" Behaviors="Close"
            OnClientClose="OnClientCloseVehiculo" NavigateUrl="busquedavehiculo.aspx" Opacity="100"
            Title="Búsqueda de Vehículo" CssClass="element" AutoSize="True">
        </telerik:RadWindow>
        <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="16px"
            Position="Center" Width="358px" ContentIcon="" EnableRoundedCorners="True" EnableShadow="True"
            Font-Bold="True" Font-Size="Medium" Opacity="95" TitleIcon="" ForeColor="Black"
            Overlay="True">
        </telerik:RadNotification>
    
        
    
    <%--
           
            
            
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="BtnBuscar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="consultacliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                            <telerik:AjaxUpdatedControl ControlID="btnGrabar" />
                            <telerik:AjaxUpdatedControl ControlID="lblfecha" />
                            <telerik:AjaxUpdatedControl ControlID="lbltransaccion" />
                            <telerik:AjaxUpdatedControl ControlID="lblproducto" />
                            <telerik:AjaxUpdatedControl ControlID="lblorigen" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btnGrabar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="consultacliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                            <telerik:AjaxUpdatedControl ControlID="btnGrabar" />
                            <telerik:AjaxUpdatedControl ControlID="txtIdentificacion" />
                            <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                            <telerik:AjaxUpdatedControl ControlID="txtcodigovehiculo" />
                            <telerik:AjaxUpdatedControl ControlID="txtdescripcion" />
                            <telerik:AjaxUpdatedControl ControlID="txtorden" />
                            <telerik:AjaxUpdatedControl ControlID="txtproducto" />
                            <telerik:AjaxUpdatedControl ControlID="txtprecio" />
                            <telerik:AjaxUpdatedControl ControlID="txtpropuesta" />
                            <telerik:AjaxUpdatedControl ControlID="lblfecha" />
                            <telerik:AjaxUpdatedControl ControlID="lbltransaccion" />
                            <telerik:AjaxUpdatedControl ControlID="lblproducto" />
                            <telerik:AjaxUpdatedControl ControlID="lblorigen" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="BtnLimpiar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="consultacliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                            <telerik:AjaxUpdatedControl ControlID="btnGrabar" />
                            <telerik:AjaxUpdatedControl ControlID="txtIdentificacion" />
                            <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                            <telerik:AjaxUpdatedControl ControlID="txtcodigovehiculo" />
                            <telerik:AjaxUpdatedControl ControlID="txtdescripcion" />
                            <telerik:AjaxUpdatedControl ControlID="txtorden" />
                            <telerik:AjaxUpdatedControl ControlID="txtproducto" />
                            <telerik:AjaxUpdatedControl ControlID="txtprecio" />
                            <telerik:AjaxUpdatedControl ControlID="txtpropuesta" />
                            <telerik:AjaxUpdatedControl ControlID="lblfecha" />
                            <telerik:AjaxUpdatedControl ControlID="lbltransaccion" />
                            <telerik:AjaxUpdatedControl ControlID="lblproducto" />
                            <telerik:AjaxUpdatedControl ControlID="lblorigen" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="consultacliente">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="consultacliente" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema" />
                            <telerik:AjaxUpdatedControl ControlID="btnGrabar" />
                            <telerik:AjaxUpdatedControl ControlID="txtIdentificacion" />
                            <telerik:AjaxUpdatedControl ControlID="txtNombre" />
                            <telerik:AjaxUpdatedControl ControlID="txtcodigovehiculo" />
                            <telerik:AjaxUpdatedControl ControlID="txtdescripcion" />
                            <telerik:AjaxUpdatedControl ControlID="txtorden" />
                            <telerik:AjaxUpdatedControl ControlID="txtproducto" />
                            <telerik:AjaxUpdatedControl ControlID="txtprecio" />
                            <telerik:AjaxUpdatedControl ControlID="txtpropuesta" />
                            <telerik:AjaxUpdatedControl ControlID="lblfecha" />
                            <telerik:AjaxUpdatedControl ControlID="lbltransaccion" />
                            <telerik:AjaxUpdatedControl ControlID="lblproducto" />
                            <telerik:AjaxUpdatedControl ControlID="lblorigen" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
        </div>
    </section>--%>
    </form>
</asp:Content>
