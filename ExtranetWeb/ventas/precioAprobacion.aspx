<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master"
    CodeBehind="precioAprobacion.aspx.vb" Inherits="ExtranetWeb.precioAprobacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>Hunter Online - Aprobar precios</title>
    <link rel="stylesheet" href="../styles/css_mkt/int-styles.css" />
    <link rel="stylesheet" href="../styles/estiloaprobacion.css" />
	<link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <section class="info-body">
            <div class="transacciones"> 
                <div class="content_toolbar" style="height:40px; margin-top:-20px;">
                    <div class="input-group d-flex flex-column">
                        <div class="filter-date">
                            <label for="desde">
                                desde
                            </label>
                            <asp:TextBox ID="rdpFechaInicio" runat="server" TextMode="Date" class="input-style">
                            </asp:TextBox>
                            <label for="hasta">
                                hasta
                            </label>
                            <asp:TextBox ID="rdpFechaFin" runat="server" TextMode="Date" class="input-style">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group d-flex flex-column">  
                        <div class="bco-tarjeta-select">
                            <label for="cbxcliente">
                                Cliente
                            </label>
                            <select class="select-css" id="cbxcliente" runat="server" onChange="cbxcliente_ServerChange(this, 'cmbtipopago')">
                            </select>
                        
                            <label for="cbxcliente">
                                Ejecutiva
                            </label>
                            <select class="select-css" id="cbxusuario" runat="server" onChange="cbxcliente_ServerChange(this, 'cmbtipopago')">
                            </select>
                        </div>
                        <div class="bco-tarjeta-select">
                            <label for="cbxcliente">
                                Estado
                            </label>
                            <select class="select-css" id="cbxestado" runat="server" onChange="cbxcliente_ServerChange(this, 'cmbtipopago')">
                            </select>
                        </div>
                    </div> 
                    <div class="buttons-section d-flex flex-justify-center flex-align-center" >
			            <button class="btn btn-blue" type="submit" id="BtnCancelar" runat="server">Limpiar</button>
                        <button class="btn btn-green" type="submit" id="BtnBuscar" runat="server">Buscar</button>
                        <button class="btn btn-green" type="submit" id="BtnProcesar" runat="server">Grabar</button>
                         
		            </div>          
                </div>
            </div>
        </section>
        <div class="content_confirmardato_gridcontrol">
            <telerik:RadGrid ID="productocliente" runat="server" CellSpacing="0" Culture="es-ES"
                Width="750px" Height="420px" GridLines="None" AutoGenerateColumns="False" Skin="MyCustomSkin"
                EnableEmbeddedSkins="False">
                <ClientSettings EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
                </ClientSettings>
                <MasterTableView DataKeyNames="CODIGO_VEHICULO" NoDetailRecordsText="" NoMasterRecordsText="">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkI" runat="server" AutoPostBack="true" OnCheckedChanged="chkI_CheckedChanged" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkH" runat="server" AutoPostBack="true" OnCheckedChanged="chkH_CheckedChanged" />
                            </HeaderTemplate>
                            <FooterStyle CssClass="estilogridcontrol" Width="60px" />
                            <HeaderStyle CssClass="estilogridcontrol" Width="60px" />
                            <ItemStyle CssClass="estilogridcontrol" Width="60px" />
                        </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="CLIENTE" FilterControlAltText="Filter CLIENTE column"
                            HeaderText="Cliente" UniqueName="CLIENTE">
                            <FooterStyle CssClass="estilogridcontrol" Width="220px" />
                            <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="220px" />
                            <ItemStyle CssClass="estilogridcontrol" Width="220px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GRUPO_NOMBRE" FilterControlAltText="Filter GRUPO_NOMBRE column"
                            HeaderText="Bien Protegido" UniqueName="GRUPO_NOMBRE">
                            <FooterStyle CssClass="estilogridcontrol" Width="220px" />
                            <HeaderStyle CssClass="estilogridcontrol" Font-Bold="True" Width="220px" />
                            <ItemStyle CssClass="estilogridcontrol" Width="220px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CODIGO_VEHICULO" Display="false" FilterControlAltText="Filter CODIGO_VEHICULO column"
                            HeaderText="Vehículo" UniqueName="CODIGO_VEHICULO">
                            <FooterStyle Width="80px" CssClass="estilogridcontrol" />
                            <HeaderStyle Font-Bold="True" Width="80px" CssClass="estilogridcontrol" />
                            <ItemStyle Width="80px" CssClass="estilogridcontrol" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CODIGO_CLIENTE" Display="false" FilterControlAltText="Filter CODIGO_CLIENTE column"
                            HeaderText="Cod.Cliente" UniqueName="CODIGO_CLIENTE">
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
                        <telerik:GridBoundColumn DataField="PRODUCTO_NOMBRE" FilterControlAltText="Filter PRODUCTO_NOMBRE column"
                            HeaderText="Servicio" UniqueName="PRODUCTO_NOMBRE">
                            <FooterStyle Width="180px" CssClass="estilogridcontrol" />
                            <HeaderStyle Font-Bold="True" Width="180px" CssClass="estilogridcontrol" />
                            <ItemStyle Width="180px" CssClass="estilogridcontrol" />
                        </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column"
                            HeaderText="Producto" UniqueName="DESCRIPCION">
                            <FooterStyle Width="180px" CssClass="estilogridcontrol" />
                            <HeaderStyle Font-Bold="True" Width="180px" CssClass="estilogridcontrol" />
                            <ItemStyle Width="180px" CssClass="estilogridcontrol" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TOTAL_ITEM" DataFormatString="{0:N2}" FilterControlAltText="Filter column column"
                            HeaderText="Precio Venta" UniqueName="TOTAL_ITEM">
                            <FooterStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                            <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="estilogridcontrol" />
                        </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ITEM_PROPUESTA" DataFormatString="{0:N2}" FilterControlAltText="Filter column column"
                            HeaderText="Precio Propuesta" UniqueName="ITEM_PROPUESTA">
                            <FooterStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                            <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                            <ItemStyle HorizontalAlign="Right" Width="120px" CssClass="estilogridcontrol" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ESTADO" FilterControlAltText="Filter ESTADO column"
                            HeaderText="Estado" UniqueName="ESTADO">
                            <FooterStyle Width="120px" CssClass="estilogridcontrol" />
                            <HeaderStyle Font-Bold="True" Width="120px" CssClass="estilogridcontrol" />
                            <ItemStyle Width="120px" CssClass="estilogridcontrol" />
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
                    <PagerStyle PageSizeControlType="RadComboBox" />
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox" />
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu EnableEmbeddedSkins="False">
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="16px"
            Position="Center" Width="358px" ContentIcon="" EnableRoundedCorners="True" EnableShadow="True"
            Font-Bold="True" Font-Size="Medium" Opacity="95" TitleIcon="" ForeColor="Black"
            Overlay="True">
        </telerik:RadNotification>
    </form>
</asp:Content>

