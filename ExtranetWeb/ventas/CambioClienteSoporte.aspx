<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambioClienteSoporte.aspx.vb"  Inherits="ExtranetWeb.WebForm2" %>
<html>
    <head>
        <meta charset="UTF-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<title>Hunter Online - Cliente soporte</title>
        <link rel="shortcut icon" href="../images/favicon.ico" />
		<link rel="stylesheet" href="../styles/css_mkt/main.css" />
		<link
			href="https://fonts.googleapis.com/css2?family=Raleway:wght@300;400;700&display=swap"
			rel="stylesheet"
		/>
		<link
			href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap"
			rel="stylesheet"
		/>
    </head>
    <body class="grey-back signup-page">
        <form id="frm1" runat="server" >
            <section class="singup-header">
			    <section class="wrap">
				    <img
					    class="logo-ho"
					    src="../images/img_mkt/logo-hunter-online.png"
					    alt="Logo Hunter Online"
				    />
			    </section>
		    </section>
            <div id="dvdmensajes" class="messages alert" runat="server">
                <p>
                    <label id="lblmensajeerror" runat="server"></label>    
                </p>
                <label id="close" for="hide-message" class="x-btn">&#10005</label>
            </div>
		    <section class="wrap">
			    <div class="signup-txt">
				    <h1 class="text-center">Consulta y Seleccion de<b> Cliente </b></h1>
			    </div>
			    <div class="input-cliente">
				    <div class="signup-input">
					    <label for="cedula"> Cédula / RUC </label>
					    <input type="text" id="txtfiltrocliente" runat="server" name="cedula" />
				    </div>
				    <asp:Button class="btn btn-clean" id="btnactualizar" runat="server" Text="limpiar"></asp:Button>
			    </div>
			    <asp:Button class="btn btn-search" id="btningresar" runat="server" Text="buscar"></asp:Button>
                <asp:Button class="btn btn-search" id="btncrear" runat="server" Text="Crear"></asp:Button>
			    <div class="table-data d-flex">
				    <table>
					    <thead>
						    <tr>
							    <th>Identificación</th>
							    <th>Cliente</th>
							    <th>Email</th>
							    <th>Estado</th>
							    <th></th>
						    </tr>
					    </thead>
					    <tbody>
						    <ASP:Repeater id="Rptclientesoporte" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblidentificacionsoporte" text='<%# Eval("CODIGO_REFERENCIAL")%>' runat="server" Visible="true"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblclientesoporte" text='<%# Eval("CLIENTE")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblemailsoporte" text='<%# Eval("EMAIL1")%>' runat="server"/>
                                            <asp:Label ID="lbltelefonosoporte" text='<%# Eval("TELEFONO1")%>' runat="server" style="visibility:hidden;"/>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblestadosoporte" text='<%# Eval("ESTADO1")%>' runat="server"/>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnnseleccionar" runat="server" Text="..."  OnClick="clk_rpt_clientesoporte"/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </ASP:Repeater>
					    </tbody>
				    </table>
			    </div>
		    </section>
		    <footer class="singup-footer">
			    <section class="info-contact">
				    <img src="../images/img_mkt/LOGO-HUNTER.png" alt="Logo Hunter" />
				    <div class="footer-text">
					    <ul class="fonos">
						    <li>
							    <p>
								    call center <br />
								    <b>(04) 6004640</b>
							    </p>
						    </li>
						    <li>
							    <p>
								    EMERGENCIA 24/7 <br />
								    <b>098 54 54 544</b>
							    </p>
						    </li>
					    </ul>
					    <ul class="links-footer">
						    <li>
							    <a href="#"> Términos de Uso y Privacidad </a>
						    </li>
						    <li>
							    <a href="#"> | Contáctenos </a>
						    </li>
					    </ul>

					    <p class="copy">Copyright Carseg S.A. Derechos Reservados 2020</p>
				    </div>
			    </section>
			    <div class="norton">
				    <img src="../images/img_mkt/LOGO-NORTON.png" alt="Logo Norton" />
			    </div>
		    </footer>
        </form>
        <script type="text/javascript" src="../js/main.js"></script>
    </body>
 </html>