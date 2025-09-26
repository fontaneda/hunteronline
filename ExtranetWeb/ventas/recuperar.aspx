<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="recuperar.aspx.vb" Inherits="ExtranetWeb.recuperar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
  <head>
    <title>Recuperar contraseña</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="../styles/main.css" />
  </head>
  <body>
    <div class="container pt-4" style="text-align:center;" >
        <header class="mt-5 mb-3 overflow-hidden">
            <h1 class="logo-top text-center">
              <img src="../images/background/loogo-ho-color.png" alt="Logo Hunter Online" />
            </h1>  
        </header>
        <section class="row justify-content-center mt-5">
            <div class="datos-ingreso col-md-5 text-center">
                <p class=" msn-ingreso text-center">
                    Ingrese su No. de cédula
                </p> 
                <form class="px-4" runat="server">
                    <asp:TextBox ID="txtcedula" runat="server" Width="280px" TabIndex="1" AutoPostBack="True" MaxLength="13"></asp:TextBox>
                    <br />
                    <label for="cmbemail">
                        <p class=" msn-ingreso text-center">
                            Seleccione su Email
                        </p> 
                    </label>
                    <br />
                    <select name="cmbemail" id="cmbemail" class="select-css" runat="server">
                    </select>
                    <br />
                    <%--<p class=" msn-ingreso text-center">
                        Ingrese él código de la imagen
                    </p> 
                    <br />--%>
                    <%--<telerik:RadCaptcha ID="RadCaptcha1" runat="server" ValidationGroup="grupo01" ErrorMessage="El texto ingresado no es inválido" CaptchaTextBoxLabel="" Display="Dynamic"
                                        CaptchaLinkButtonText="Generar nuevo texto" EnableRefreshImage="false" CaptchaImage-BackgroundNoise="Extreme" CaptchaImage-EnableCaptchaAudio="false"
                                        CaptchaImage-TextColor="Black" CaptchaImage-TextLength="6" CaptchaImage-UseAudioFiles="True" CaptchaImage-Width="300" Font-Size="11pt" Width="300px"
                                        ForeColor="#990000" ValidatedTextBoxID="txtvalida" TabIndex="5">
                        <CaptchaImage BackgroundNoise="Extreme" EnableCaptchaAudio="false" TextColor="Black" TextLength="6" 
                                      UseAudioFiles="True" Width="150" ImageCssClass="imageClass">
                        </CaptchaImage>
                    </telerik:RadCaptcha>--%>
                    <br />
                    <input class="btn-envio" type="submit" value="Enviar" id="btnenviar" runat="server" />
          
                    
                 
          
                </form>
            </div>
        </section>
        <section class="row justify-content-center">
            <div class="icon-list row row-cols-sm-2 row-cols-md-4 px-2">
                <span class="col"><img src="../images/background/pagos.png" alt="pago" /></span>
                <span class="col"><img src="../images/background/bienes.png" alt="bienes" /></span>
                <span class="col"><img src="../images/background/chequeos.png" alt="chequeos" /></span>
                <span class="col"><img src="../images/background/factura.png" alt="factura" /></span>
            </div>
        </section>
    </div>
 </body>
</html>