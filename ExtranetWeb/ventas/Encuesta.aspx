<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Encuesta.aspx.vb" Inherits="ExtranetWeb.Encuesta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../styles/estiloencuesta.css" />
    <title>Encuesta</title>
</head>
<body>
     <div class="wrap">
        <header class="logo-hunter">
            <img src="../images/encuesta/logo-color.png" alt="Logo Hunter" />
        </header>
        <div class="content">
        <h1 class="question">
         <div class="informacion">
                    <asp:Label ID="lblnombres" runat="server" Text=""></asp:Label>
                    <br /> <br />
                </div>
        </h1>
            
            <div  id="secderecha"  runat="server">
            <h1 class="question">
                <div Id="lblpregunta0" runat="server">
                        <asp:Label ID="Label0" runat="server" Text="Pregunta 1" class="texto"></asp:Label>
                        <asp:Label ID="Codigo0" runat="server" Text="0" Visible="False"></asp:Label>
                    </div>
            </h1>
           
            <div class="action-call">
                <form id="Form1" action="#" runat="server">
                    <div id="debt-amount-slider">
                        <input  type="radio" name="debt-amount" id="chkrespuesta0_1" runat="server" value="1" required />
                        <label  id="lblrespuesta0_1" runat="server" for="chkrespuesta0_1" data-debt-amount="Muy insatisfecho" ></label>
                        <input type="radio" name="debt-amount" id="chkrespuesta0_2" runat="server" value="2" required />
                        <label  id="lblrespuesta0_2" runat="server" for="chkrespuesta0_2" data-debt-amount="Insatisfecho"></label>
                        <input type="radio" name="debt-amount" id="chkrespuesta0_3" runat="server" value="3" required />
                        <label  id="lblrespuesta0_3" runat="server" for="chkrespuesta0_3" data-debt-amount="Neutral"></label>
                        <input type="radio" name="debt-amount" id="chkrespuesta0_4" runat="server" value="4" required />
                        <label id="lblrespuesta0_4" runat="server"  for="chkrespuesta0_4" data-debt-amount="Satisfecho"></label>
                        <input type="radio" name="debt-amount" id="chkrespuesta0_5" runat="server" value="5" required />
                        <label  id="lblrespuesta0_5" runat="server" for="chkrespuesta0_5" data-debt-amount="Muy Satisfecho"></label>
                        <div id="debt-amount-pos"></div>
                    </div>
                     <br /> <br /><br /><br /><br /><br />
                    <div class="informacion">
                        <h1 class="question2">
                            
                            <asp:Label ID="Label1" runat="server" Text="Ingrese sus Comentarios o Sugerencias"></asp:Label>
                            
                        </h1>
                    </div>
                    <div class="column_cell_text2">
                        <asp:TextBox runat="server" ID="txtcontenido" TextMode="MultiLine" Width="560px" MaxLength="1000"  Height="60px"/>
                    </div>
                    <asp:Button id="btnenviar" runat="server" Text="ENVIAR RESPUESTA" CssClass="controlboton" />
                </form>
               


            </div>
            </div>
        </div>

        <footer>
            <p>
                Recuerde que nuestra <b>Central de Control trabaja 24/7</b> atenderá las llamadas de robos<br/> y emergencias a nivel nacional.
            </p>
            <ul>
                <li>
                    <p class="upper">emergencia 24/7</p>
                    <p>
                        <b>098 54 54 544</b>
                    </p>
                </li>
                <li>
                    <p class="upper">whatsapp</p>
                    <p>
                        <b>099 440 8582</b>
                    </p>
                </li>
                <li>
                    <p>@HunterEcuador</p>
                    <ul class="socials">
                        <li>
                            <a href="https://www.facebook.com/hunterecuador">
                                <img src="../images/encuesta/facebook-icon.png" alt="" />
                            </a>
                        </li>
                        <li>
                            <a href="https://twitter.com/hunterecuador">
                                <img src="../images/encuesta/twitter-icon.png" alt="" />
                            </a>
                        </li>
                        <li>
                            <a href="https://www.instagram.com/hunterecuador/">
                                <img src="../images/encuesta/instagram-icon.png" alt="" />
                            </a>
                        </li>
                    </ul>
                </li>
            </ul>
        </footer>
    </div>
</body>
</html>
