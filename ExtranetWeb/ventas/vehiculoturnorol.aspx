<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="vehiculoturnorol.aspx.vb" Inherits="ExtranetWeb.vehiculoturnorol" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Hunter Online - Pagos de Servicios Online</title>
    <link rel="stylesheet" href="../styles/css_mkt/int-styles.css" />
    <link rel="stylesheet" href="../styles/css_mkt/estilovehiculoturno.css" />
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
</head>
<body class="grey-back">
    <input type="checkbox" class="checkbox" id="click" hidden />
    <section class="left-menu">
        <label for="click">
            <div class="menu-icon">
                <div class="line line-1"></div>
                <div class="line line-2"></div>
                <div class="line line-3"></div>
            </div>
        </label>
        <a href="#" class="logo-ho">
            <img src="../images/img_mkt/logo-hunter-online.svg" alt="Logo Hunter Online" />
        </a>
        <div class="user-info">
            <img src="../images/img_mkt/user-avatar.png" alt="User Avatar" />
            <h2>
                <asp:Label ID="lblnombresmaster" Text="Nombres" runat="server" /> 
            </h2>
            <ul>
                <li>
                    <img src="../images/img_mkt/mail-icon.png" alt="" /> 
                    <asp:Label ID="lblemailmaster" Text="Email" runat="server" />
                </li>
                <%--<li>
                    <i>
                        <img src="../images/img_mkt/ic_phone_android_48px 1.png" alt="">
                    </i> 
                    <asp:Label ID="lblcelularmaster" Text="0900000000" runat="server" />
                </li>--%>
            </ul>
        </div>
        <nav class="main-menu">
            <ul>
                <li id="lielement02" runat="server">
                    <a href="vehiculorol.aspx">
                        <img src="../images/img_mkt/bienes-icon.png" alt="" /> 
                        Bienes Protegidos
                    </a>
                </li>
            </ul>
        </nav>
        <button id="btnsalirweb" runat="server" class="salir-btn" >
            <img src="../images/img_mkt/salir-icon.png" alt="" />
            salir
        </button>
        <section class="socials-copy">
            <ul class="socials">
                <li>
                    <a href="https://www.facebook.com/hunterecuador/">
                        <img src="../images/img_mkt/fb.png" alt="" />
                    </a>
                </li>
                <li>
                    <a href="https://www.instagram.com/hunterecuador">
                        <img src="../images/img_mkt/ig.png" alt=""/>
                    </a>
                </li>
                <li>
                    <a href="https://twitter.com/hunterecuador">
                        <img src="../images/img_mkt/tweet.png" alt=""/>
                    </a>
                </li>
            </ul>
            <p class="copy">
                Copyright Carseg S.A.<br/> Derechos Reservados 2020
            </p>
        </section>
    </section>
    <nav class=" nav-responsive">
        <ul>
            <li id="licellelement02" runat="server">
                <a href="vehiculorol.aspx">
                    <img src="../images/img_mkt/bienes-icon.png" alt=""/> 
                    Bienes Protegidos
                </a>
            </li>
            <li>
                <a href="#" id="hrefsalir" runat="server">
                    <img src="../images/img_mkt/salir-icon.png" alt=""/>
                    Salir
                </a>
            </li>
        </ul>
    </nav>
    <section class="content">
        <section id="sectiontitulomaster" class="title-content red-border" runat="server">
            <!-- Clase que se aplica a los titulos quitarla para el master -->
            <h1 id="h1titulomaster" runat="server" >
                <asp:Label ID="lbltitulomaster" Text="Titulo" runat="server" />
            </h1>
            <div class="content-top-menu">
                <ul>
                    <li>
                        <div class="cart-class">
                            <p>
                                total<br/> 
                                <b>
                                    <asp:Label ID="lbltotalmaster" Text="0.00" runat="server" />
                                </b>
                            </p>
                            <button class="btn-small cart-btn">
                                <img src="../images/img_mkt/cart-icon.png" alt="" />
                                    <asp:Label ID="lblcantidadmaster" Text="0" runat="server" />
                            </button>
                        </div>
                    </li>
                </ul>
            </div>
        </section>
        <%--<section class="content-body">--%>
            <form id="Form1" action="#" runat="server">
                 <section class="info-body">
                    <div id="dvdmensajes" class="messages alert" runat="server">
                        <p>
                            <label id="lblmensajeerror" runat="server"></label>    
                        </p>
                        <label id="close" for="hide-message" class="x-btn">&#10005</label>
                    </div>                    
                    <div class="item-turno-info">
                        <div class="placa-modelo">
                            <h4>
                                Placa:
                                <b>
                                    <asp:Label ID="lblplacatur" text='' runat="server"/>
                                </b>
                            </h4>
                            <h5>
                                <b>
                                    <asp:Label ID="lblmarcatur" text='' runat="server"/>
                                </b>
                                <br/> 
                                <asp:Label ID="lblmodelotur" text='' runat="server"/>
                            </h5>

                        </div>
                        <div class="chasis">
                            <h3>
                                Chasis<br/>
                                <b>
                                    <asp:Label ID="lblchasistur" text='' runat="server"/>
                                </b>
                            </h3>
                        </div>
                    </div>
                    <div class="select-group" >
                        <asp:DropDownList ID="cmbproductortur" runat="server" AutoPostBack="true" class="select-css"/>
                        <asp:DropDownList ID="cmblugartur" runat="server" AutoPostBack="true" class="select-css"/>
                        <asp:DropDownList ID="cmbtallertur" runat="server" AutoPostBack="true" class="select-css"/>
                    </div>
                    <div class="select-group" id ="dvopcionescandados" runat="server">
                        <asp:RadioButton ID="chkopcion1" GroupName="opnovedad" Text="Daño de carcasa" runat="server" />
                        <asp:RadioButton ID="chkopcion2" GroupName="opnovedad" Text="No reporta recorrido en un periodo de tiempo" runat="server" />
                        <asp:RadioButton ID="chkopcion3" GroupName="opnovedad" Text="No reporta el candado" runat="server" />
                        <asp:RadioButton ID="chkopcion4" GroupName="opnovedad" Text="No muestra apertura y cierre de barra" runat="server" />
                        <asp:RadioButton ID="chkopcion5" GroupName="opnovedad" Text="Otro / Por favor indicar en comentario..." runat="server" />
                    </div>
                    <div class="input-group">
                        <div class="left-inputs"> 
                            <asp:TextBox ID="txtdirecciontur" runat="server" class="input-style" placeholder="Dirección"></asp:TextBox>
                            <asp:TextBox ID="txttelefonotur" runat="server" class="input-style" placeholder="Teléfono"></asp:TextBox>
                            <asp:TextBox ID="txtcontactotur" runat="server" class="input-style" placeholder="Contácto"></asp:TextBox>
                        </div>
                        <div class="comment">
                            <textarea id="txtcomentariotur" name="mensaje" placeholder="Comentario" runat="server"></textarea>
                        </div>
                    </div>
                    <div class="calendar-container">
                    <div id="Div0" class="VehiculoTurnoContenido" runat="server">
                            <div id="Div1" class="VehiculoTurnoContenidoInfo" runat="server">
                                <div id="Div2" class="VehiculoTurnoContenidoImagenDescriptivoA" runat="server"></div>
                                <div id="Div3" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server">
                                    Mi turno
                                </div>
                                <div id="Div4" class="VehiculoTurnoContenidoImagenDescriptivoB" runat="server"></div>
                                <div id="Div5" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server">
                                    Libre
                                </div>
                                <div id="Div6" class="VehiculoTurnoContenidoImagenDescriptivoC" runat="server"></div>
                                <div id="Div7" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server">
                                    Ocupado
                                </div>
                                <div id="Div8" class="VehiculoTurnoContenidoImagenDescriptivoD" runat="server"></div>
                                <div id="Div9" class="VehiculoTurnoContenidoTextoDescriptivo" runat="server">
                                    Fuera/Horario
                                </div>
                            </div>
                            <div class="calendar-body">
                                <div id="DivCalendario" class="VehiculoTurnoContenidoCalendario" runat="server">
                                                                                                                                                                                <div id="Div10" class="VehiculoTurnoContenidoCalendarioCabecera" runat="server">
                                    <div id="Div11" class="VehiculoTurnoContenidoCalendarioCabeceraHora" runat="server">
                                        Hora
                                    </div>
                                    <div id="Div12" class="VehiculoTurnoContenidoCalendarioCabeceraFecha" runat="server">
                                        <asp:Label id="lblfechacalendario" runat="server" Text="Agosto 4 de 2014 - 10 de Agosto de 2014" />
                                    </div>
                                    <div id="Div13" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Lun
                                        <asp:Label id="lbldia1" runat="server" Text="1" Width="100%" />
                                    </div>
                                    <div id="Div14" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Mar
                                        <asp:Label id="lbldia2" runat="server" Text="2" Width="100%" />
                                    </div>
                                    <div id="Div15" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Mie
                                        <asp:Label id="lbldia3" runat="server" Text="3" Width="100%" />
                                    </div>
                                    <div id="Div16" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Jue
                                        <asp:Label id="lbldia4" runat="server" Text="4" Width="100%" />
                                    </div>
                                    <div id="Div17" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Vie
                                        <asp:Label id="lbldia5" runat="server" Text="5" Width="100%" />
                                    </div>
                                    <div id="Div18" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Sab
                                        <asp:Label id="lbldia6" runat="server" Text="6" Width="100%" />
                                    </div>
                                    <div id="Div19" class="VehiculoTurnoContenidoCalendarioDia" runat="server">
                                        Dom
                                        <asp:Label id="lbldia7" runat="server" Text="7" Width="100%" />
                                    </div>
                                </div>
                                    <div id="Div20" class="VehiculoTurnoContenidoCalendarioespacio" runat="server"></div>
                                    <div id="Div21" class="VehiculoTurnoContenidoCalendarioCuerpo" runat="server">
                                        <div id="Div22" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            08:00
                                        </div>
                                        <div id="cal1" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" OnClientClick="imgdia_Click()"
                                                Visible="false" />
                                            <asp:LinkButton id="lbldia1hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal2" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal3" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal4" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal5" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia5hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="true" OnClientClick="imgdia_Click()"
                                            />
                                           <asp:LinkButton id="lbldia5hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal6" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal7" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora1" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia7hora1" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div23" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            09:00
                                        </div>
                                        <div id="cal8" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" OnClientClick="imgdia_Click()"
                                                Visible="false" />
                                            <asp:LinkButton id="lbldia1hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" Visible="false" />
                                        </div>
                                        <div id="cal9" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal10" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal11" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal12" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia5hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal13" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal14" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora2" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia7hora2" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div24" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            10:00
                                        </div>
                                        <div id="cal15" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" OnClientClick="imgdia_Click()"
                                                Visible="false" />
                                            <asp:LinkButton id="lbldia1hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" Visible="false" />
                                        </div>
                                        <div id="cal16" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal17" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal18" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal19" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia5hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal20" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal21" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora3" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia7hora3" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div25" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            11:00
                                        </div>
                                        <div id="cal22" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia1hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal23" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal24" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal25" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal26" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia5hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal27" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal28" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora4" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton ID="lbldia7hora4" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div26" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            12:00
                                        </div>
                                        <div id="cal29" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia1hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal30" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal31" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal32" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal33" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia5hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora5" runat="server" Width="100%" Height="100%" BackColor="#FFFEEB" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal34" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal35" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora5" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" />
                                            <asp:LinkButton id="lbldia7hora5" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div27" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            13:00
                                        </div>
                                        <div id="cal36" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia1hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal37" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal38" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal39" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal40" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia5hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora6" runat="server" Width="100%" Height="100%" BackColor="#FFFEEB" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal41" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal42" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora6" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia7hora6" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div28" class="VehiculoTurnoContenidoCalendarioHora" runat="server">
                                            14:00
                                        </div>
                                        <div id="cal43" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia1hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia1hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal44" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia2hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal45" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia3hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal46" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia4hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div ID="cal47" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton ID="imgdia5hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora7" runat="server" Width="100%" Height="100%" BackColor="#FFFEEB" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal48" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia6hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal49" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario">
                                            <asp:ImageButton id="imgdia7hora7" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia7hora7" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="Div29" class="VehiculoTurnoContenidoCalendarioHora" runat="server" style="visibility:hidden;">
                                            15:00
                                        </div>
                                        <div id="cal50" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia1hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia1hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal51" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia2hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia2hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal52" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia3hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia3hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal53" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia4hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia4hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal54" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia5hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia5hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal55" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia6hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia6hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                        <div id="cal56" class="VehiculoTurnoContenidoCalendarioContenido" title="Fuera de Horario" style="visibility:hidden;">
                                            <asp:ImageButton id="imgdia7hora8" runat="server" Width="100%" Height="100%" onmouseover="Tooltipmodaljs(this);" onmouseleave="Tooltipmodaloutjs(this);" BorderWidth="0px" ImageUrl="../images/background/visto.png" BorderStyle="None" Visible="false" OnClientClick="imgdia_Click()"
                                            />
                                            <asp:LinkButton id="lbldia7hora8" runat="server" Width="100%" Height="100%" BackColor="#e0e5df" OnClientClick="lbldia_Click()" />
                                        </div>
                                    </div>
                                </div>
                                <div class="calendar-control-wrapper">
                                    <div id="Div30" class="VehiculoTurnoContenidoBotonesCalendario" runat="server">
                                        <div id="Div31" class="VehiculoTurnoContenidoBotonesCalendarioAnterior" runat="server" title="Anterior">
                                            <asp:ImageButton ID="BtnCalendarioanterior" runat="server" BackColor="Transparent" Width="30px" Height="40px" ImageUrl="../images/img_mkt/navigate_before.svg" />
                                        </div>
                                    </div>

                                    <div id="Div32" class="VehiculoTurnoContenidoBotonesCalendario" runat="server">
                                        <div id="Div33" class="VehiculoTurnoContenidoBotonesCalendarioSiguiente" runat="server" title="Siguiente">
                                            <asp:ImageButton ID="BtnCalendariosiguiente" runat="server" BackColor="Transparent" Width="30px" Height="40px" ImageUrl="../images/img_mkt/navigate_next.svg" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="btnverturno" class="btn-class btn-ver-turno" runat="server" Text="Ver Turno">                    
                            </asp:Button>
                            <div id="dvgeoreferencia" runat="server" class="lat-lon-wrapper">
                                <div class="latitud-input">
                                    <asp:TextBox id="txtlatitudtur" runat="server" placeholder="Latitud" class="input-style" Enabled="false" />
                                </div>
                                <div class="longitud-input">
                                    <asp:TextBox id="txtlongitudtur" runat="server" placeholder="Longitud" class="input-style" Enabled="false" />
                                </div>
                                <asp:Button ID="btnvergps" class="btn-search-rounded" runat="server" Text="Marque su ubicación"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <section class="estado-vehiculo">
                        <h2>
                            ESTADO DEL VEHÍCULO
                        </h2>
                        <div class="estados">
                            <ul>
                                <li>
                                    <div id="divetapa1tur" runat="server" class="current-state"></div>
                                    <p>RECIBIDO</p>
                                </li>
                                <li>
                                    <div id="divetapa2tur" runat="server" ></div>
                                    <p>TRABAJANDO</p>
                                </li>
                                <li>
                                    <div id="divetapa3tur" runat="server" ></div>
                                    <p>TEST</p>
                                </li>
                                <li>
                                    <div id="divetapa4tur" runat="server" ></div>
                                    <p>CALIDAD OK</p>
                                </li>
                                <li>
                                    <div id="divetapa5tur" runat="server" ></div>
                                    <p>LISTO</p>
                                </li>
                            </ul>
                        </div>
                    </section>
                </section>
            </form>
        <%--</section> --%>
    </section>
    <script type="text/javascript">
        function ShowPopup() {
            var x = document.getElementById("hrefclientefac");
            x.click();
        }
    </script> 
    <script type="text/javascript" src="../js/main.js">
    </script> 
</body>
</html>