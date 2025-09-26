<%@ Language="vb" AutoEventWireup="false" CodeBehind="actualizacliente.aspx.vb" Inherits="ExtranetWeb.actualizacliente" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Hunter Online - Actualizacion de cuenta</title>
        <link rel="stylesheet" href="../styles/css_mkt/main.css">
        <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
        <link rel="shortcut icon" href="../images/favicon.ico" />
    </head>
    <body class="grey-back signup-page">
        <form id="form1" runat="server">
            <section class="singup-header">
                <section class="wrap">
                    <img class="logo-ho" src="../images/img_mkt/logo-hunter-online.png" alt="Logo Hunter Online">
                    <a class="btn-back" id="btnregresareg" runat="server">
                        <img src="../images/img_mkt/arrow_right_alt.png" alt=""> regresar
                    </a>
                </section>
            </section>
            <div id="dvdmensajes" class="messages alert" runat="server">
                <p>
                    <label id="lblmensajeerror" runat="server"></label>    
                </p>
                <label id="close" for="hide-message" class="x-btn">&#10005</label>
            </div>
            <section class="singup-form-container">
                <div class="signup-txt">
                    <h1>
                        Comencemos a<br/>
                        <b>
                            Actualizar su <br/>
                            Cuenta
                        </b>
                    </h1>
                    <ul class="signup-servicios">
                        <li>
                            <img src="../images/img_mkt/pagos-icon-signup.png" alt=""/> Pagos en Línea
                        </li>
                        <li>
                            <img src="../images/img_mkt/bienes-icon-signup.png" alt=""/> Administrar Datos y Bienes
                        </li>
                        <li>
                            <img src="../images/img_mkt/turnos-icon-signup.png" alt=""/> Turnos para Chequeos
                        </li>
                        <li>
                            <img src="../images/img_mkt/facturacion-icon-signup.png" alt=""/> Facturación en Línea
                        </li>
                    </ul>
                </div>
                <div class="signup-form">
                    <div class="signup-input">
                        <label for="txt_regusu_identificacion">
                            Cédula / RUC
                        </label>
                        <asp:TextBox AutoPostBack="true" ID="txt_regusu_identificacion" runat="server" Text="" MaxLength="15"></asp:TextBox>
                    </div>
                    <div class="signup-input">
                        <label for="email">
                            Correo electrónico
                        </label>
                        <asp:TextBox id="txt_regusu_email01" runat="server" maxlength="50"></asp:TextBox>
                    </div>
                    <div class="signup-input">
                        <label for="txt_regusu_nombre">
                            Nombres
                        </label>
                        <asp:TextBox id="txt_regusu_nombre" runat="server" maxlength="50"></asp:TextBox>
                    </div>
                    <div class="signup-input">
                        <label for="txt_regusu_apellido">
                            Apellidos
                        </label>
                        <asp:TextBox id="txt_regusu_apellido" runat="server" maxlength="50"></asp:TextBox>
                    </div>
                    <div class="signup-input">
                        <label for="txt_regusu_contrasenia01">
                            Contraseña
                        </label>
                        <asp:TextBox id="txt_regusu_contrasenia01" runat="server" maxlength="15"></asp:TextBox>
                    </div>
                    <div class="signup-input">
                        <label for="txt_regusu_contrasenia02">
                            Confirmar contraseña
                        </label>
                        <asp:TextBox id="txt_regusu_contrasenia02" runat="server" maxlength="15"></asp:TextBox>
                    </div>
                    <div class="signup-input">
                        <label for="txt_regusu_celular">
                            Celular
                        </label>
                        <asp:TextBox id="txt_regusu_celular" runat="server" maxlength="10"></asp:TextBox>
                    </div>
                    <div class="signup-terms">
                        <div class="item-check">
                            <input type="checkbox" name="chk_acuerdo" id="chk_acuerdo" runat="server"/>
                            <p>
                                Acepto las Condiciones del servicio y la Política de Privacidad de HunterOnLine
                            </p>
                        </div>
                        <div class="item-check">
                            <input type="checkbox" name="chk_suscripcion" id="chk_suscripcion" runat="server"/>
                            <p>
                                Deseo permanecer informado mediante correo electrónico sobre los productos, Servicios y promociones de Hunter
                            </p>
                        </div>
                    </div>
                    <div class="signup-btn">
                        <asp:Button class="signup-create-btn" type="submit" id="btncrearreg" runat="server" Text="crear cuenta"> 
                
                        </asp:Button>
                    </div>
                </div>
            </section>
            <footer class="singup-footer">
                <section class="info-contact">
                    <img src="../images/img_mkt/LOGO-HUNTER.png" alt="Logo Hunter">
                    <div class="footer-text">
                        <ul class="fonos">
                            <li>
                                <p>
                                    call center <br/>
                                    <b>(04) 6004640</b>
                                </p>
                            </li>
                            <li>
                                <p>
                                    EMERGENCIA 24/7 <br/>
                                    <b>098 54 54 544</b>
                                </p>
                            </li>
                        </ul>
                        <ul class="links-footer">
                            <li>
                                <a href="#">
                                    Términos de Uso y Privacidad 
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    | Contáctenos
                                </a>
                            </li>
                        </ul>
                        <p class="copy">
                            Copyright Carseg S.A. Derechos Reservados 2020
                        </p>
                    </div>
                </section>
                    <div class="norton">
                        <img src="../images/img_mkt/LOGO-NORTON.png" alt="Logo Norton">
                    </div>
            </footer>
            <%--

                        <telerik:RadTextBox ID="" runat="server" Width="280px" TabIndex="1"
                        <telerik:RadTextBox ID="" runat="server" Width="280px" TabIndex="4" MaxLength="50" Enabled="false"></telerik:RadTextBox>
                        <telerik:RadTextBox ID="" runat="server" Width="280px" TabIndex="5" MaxLength="50" Enabled="false">
                        <telerik:RadTextBox ID="" runat="server" Width="280px" TabIndex="3" MaxLength="40">
                        <telerik:RadTextBox ID="" runat="server" TextMode="Password"
                        <telerik:RadTextBox ID="" runat="server" TextMode="Password"
                        <telerik:RadTextBox ID="" runat="server" Width="280px" TabIndex="11" MaxLength="10">
                        <input type="checkbox" id="" runat="server" TabIndex="19" onclick="showContent(this);" />
                                <a title="Términos de Uso y Políticas de Privacidad" onclick="openWinContentTemplateTwo();" style="color: #3A3A3A; text-decoration: underline; cursor: pointer;">
                                    Acepto las <strong>Condiciones del servicio</strong> y la Política de Privacidad de HunterOnLine
                                </a>
                        <asp:CheckBox ID="" runat="server" Text="Deseo permanecer informado mediante correo electrónico sobre los productos y servicios de <strong> Hunter </strong>"
                         
                <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True"></telerik:RadNotification>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple"></telerik:RadAjaxLoadingPanel>
                <telerik:RadWindow ID="modalPromocion" runat="server"  Width="788px" Height="600px" Modal="true" Behaviors="Close" CssClass="elementpromocion" Title=""
                    Skin="MyCustomSkin" VisibleStatusbar="False" EnableEmbeddedSkins="False"  >
                    <ContentTemplate>
                        <div id="Div1" class="masterradwindowspromocionimagen" runat="server" >
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <br />
                           <font class="letra_promocion_titulo"><asp:Label ID="lblcodigo" runat="server" Text="Label"></asp:Label></font>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
                <telerik:RadWindow ID="modalPopup" runat="server" Width="900px" Height="400px" Left="510px" Top="195px" OnClientClose="OnClientClose" Skin="MyCustomSkin" EnableEmbeddedSkins="False"
                    Behaviors="Close" CssClass="element" VisibleStatusbar="False" Title="Términos y Condiciones" Modal="True">
                    <ContentTemplate>
                        <div class="elementdetalle">
                            <div style="background-color: white;">
                                <h2>
                                    ACUERDO SOBRE T&Eacute;RMINOS DE USO Y POL&Iacute;TICAS DE PRIVACIDAD
                                </h2>
                                <div>
                                    <br />
                                </div>
                                <div>
                                    El presente acuerdo contiene los t&eacute;rminos y condiciones generales, aplicables
                                    al uso de los servicios ofrecidos por Carro Seguro Carseg S.A. (en adelante Carseg),
                                    dentro de su sitio <b style="font-style: italic; font-weight: bold">www.HunterOnline.com.ec</b> (en adelante el sitio).&nbsp;
                                </div>
                                <div>
                                    <br />
                                </div>
                                <div>
                                    Cualquier persona que desee acceder y/o usar el sitio o los servicios de &eacute;ste,
                                    podr&aacute; hacerlo siempre que se sujete a los t&eacute;rminos y condiciones aqu&iacute;
                                    contenidas, junto con las dem&aacute;s pol&iacute;ticas y principios que rigen el
                                    sitio; por tanto, quien no acepte estos t&eacute;rminos y condiciones generales,
                                    que tienen car&aacute;cter obligatorio y vinculante, deber&aacute; abstenerse de
                                    utilizar el sitio y/o los servicios.
                                </div>
                                <div>
                                    <br />
                                </div>
                                <div>
                                    El Usuario debe leer, entender y aceptar todas las condiciones establecidas en el
                                    presente instrumento, as&iacute; como en los dem&aacute;s documentos incorporados
                                    por referencia, previa a su inscripci&oacute;n como usuario de Carseg.&nbsp;
                                </div>
                                <div>
                                    <br />
                                </div>
                                <div>
                                    1. Los servicios de Carseg s&oacute;lo est&aacute;n disponibles para personas que
                                    tengan capacidad legal para contratar; por tanto, no deben ser utilizados por menores
                                    de edad, personas que no tengan esa capacidad o aquellas que hayan sido suspendidas
                                    o dadas de baja del sistema de Carseg, temporal o definitivamente, por haber incumplido
                                    las disposiciones del presente instrumento, o por haber incurrido a criterio de
                                    Carseg, en conductas o actos dolosos o fraudulentos, mediante el uso del sitio o
                                    de los servicios. Si usted est&aacute; inscribiendo un usuario como persona jur&iacute;dica,
                                    debe tener capacidad para contratar a nombre de la misma, y de obligar a &eacute;sta
                                    en los t&eacute;rminos de este acuerdo.&nbsp;
                                </div>
                                <div>
                                    <br />
                                </div>
                                <div>
                                    2. El usuario se obliga a completar el formulario de inscripci&oacute;n en todos
                                    sus campos, para poder utilizar los servicios que brinda Carseg El usuario se obliga
                                    a consignar su informaci&oacute;n personal de manera exacta, precisa y verdadera,
                                    y asume el compromiso de actualizar sus datos personales cuando sea necesario. Carseg
                                    podr&aacute; utilizar diversos medios para identificar a sus usuarios, pero Carseg
                                    no se responsabiliza por la certeza de los datos personales provistos por sus usuarios.
                                    En consecuencia, los usuarios garantizan y responden, en cualquier caso, de la veracidad,
                                    exactitud, vigencia y autenticidad de los datos personales ingresados.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    3. El usuario acceder&aacute; a su cuenta personal en el sitio, mediante el ingreso
                                    de <b style="font-style: italic; font-weight: bold">Cédula</b> o  <b style="font-style: italic; font-weight: bold">Ruc</b> 
                                    y una clave de seguridad personal elegida por &eacute;ste. El usuario
                                    se obliga a mantener la confidencialidad de su clave de seguridad. El usuario ser&aacute;
                                    responsable por todas las operaciones efectuadas en su cuenta, pues el acceso a
                                    la misma est&aacute; restringido al ingreso y uso de su clave de seguridad, de conocimiento
                                    exclusivo del usuario. El usuario se compromete a notificar a Carseg, en forma inmediata
                                    y por medio id&oacute;neo y fehaciente, cualquier uso no autorizado de su cuenta,
                                    as&iacute; como el ingreso por terceros no autorizados a la misma.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    4. Carseg no vender&aacute;, alquilar&aacute; ni negociar&aacute; con otras empresas
                                    los datos personales de sus usuarios, salvo su autorizaci&oacute;n en contrario.
                                    Estos datos ser&aacute;n usados por Carseg, &uacute;nicamente para perfeccionar
                                    la transacci&oacute;n. La informaci&oacute;n personal de los usuarios se procesa
                                    y almacena en servidores o medios magn&eacute;ticos que mantienen altos est&aacute;ndares
                                    de seguridad y protecci&oacute;n tanto f&iacute;sica como tecnol&oacute;gica.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    5. Carseg no se responsabiliza del entendimiento, interpretaci&oacute;n y/o uso
                                    del contenido del sitio por parte de sus usuarios; por tanto, el uso de la informaci&oacute;n
                                    es responsabilidad exclusiva del usuario. Carseg se reserva la facultad de modificar
                                    el contenido y/o servicio por s&iacute; mismo o mediante un tercero autorizado,
                                    sin que est&eacute; obligado a notificar previamente al usuario.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    6. Carseg no garantiza el acceso permanente e ininterrumpido al sitio, ni que el
                                    servicio o servidor est&eacute; libre de virus. El usuario debe tomar las medidas
                                    necesarias para evitar los efectos del mismo.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    7. No est&aacute; permitido el uso de ning&uacute;n dispositivo, software u otro
                                    medio tendiente a interferir tanto en las actividades y operatividad del sitio de
                                    Carseg, como en las ofertas o en las bases de datos de Carseg. Cualquier intromisi&oacute;n,
                                    tentativa o actividad violatoria o contraria a las leyes sobre derecho de autor
                                    y/o a las prohibiciones estipuladas en este documento, facultar&aacute;n a Carseg
                                    el inicio de las acciones legales pertinentes; la imposici&oacute;n de las sanciones
                                    previstas por este acuerdo; y, demandar una indemnizaci&oacute;n por los da&ntilde;os
                                    y perjuicios irrogados.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    8. En cualquier momento Carseg podr&aacute; advertir, suspender o cancelar, temporal
                                    o definitivamente la cuenta de un usuario o una transacci&oacute;n, e iniciar las
                                    acciones que estime pertinentes, si se quebrantara alguna ley, o cualquiera de las
                                    estipulaciones de este acuerdo, o si se incurriera a criterio de Carseg en conductas
                                    o actos dolosos o fraudulentos, o, si no pudiera verificarse la identidad del usuario,
                                    o cualquier informaci&oacute;n proporcionada por el mismo fuere err&oacute;nea.
                                    En caso de suspensi&oacute;n o inhabilitaci&oacute;n de un usuario, todas las transacciones
                                    u operaciones del usuario ser&aacute;n removidas del sistema.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    9. Carseg se reserva el derecho de cancelar la cuenta del usuario que hubiere incumplido
                                    sus obligaciones derivadas de una transacci&oacute;n, o si se detectara en su conducta
                                    intencionalidad de perjudicar o defraudar a otros usuarios.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    10. Carseg se reserva el derecho a cancelar una transacci&oacute;n por razones no
                                    mencionadas anteriormente, o si considera que el usuario ha incurrido en alg&uacute;n
                                    error involuntario, o por cualquier otra raz&oacute;n que Carseg considere justificada.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    11. Carseg emitirá el comprobante de venta, únicamente con los datos registrados por el usuario en el formulario de inscripción.
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    12. Carseg podr&aacute; modificar en cualquier momento los t&eacute;rminos y condiciones
                                    de este acuerdo, y notificar&aacute; los cambios al usuario, publicando una versi&oacute;n
                                    actualizada de dichos t&eacute;rminos y condiciones en el sitio, con expresi&oacute;n
                                    de la fecha de la &uacute;ltima modificaci&oacute;n. Dentro de los 5 d&iacute;as
                                    siguientes a la publicaci&oacute;n de las modificaciones introducidas, el usuario
                                    deber&aacute; comunicar por e-mail a <b style="font-style: italic; font-weight: bold">SoporteHunterOnline@carsegsa.com</b>, si no acepta las mismas; en ese caso
                                    quedar&aacute; disuelto el v&iacute;nculo contractual y ser&aacute; inhabilitado
                                    como usuario. Vencido este plazo, se considerar&aacute; que el usuario acepta los
                                    nuevos t&eacute;rminos y el acuerdo continuar&aacute; vinculando a ambas partes.&nbsp;
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    13. El usuario autoriza expresamente a Carseg, a enviarle al correo electrónico registrado o vía SMS al número celular registrado, información referente a sus productos o servicios, promociones y avisos de interés. 
                                </div>
                                <div style="text-align: justify;">
                                    <br />
                                </div>
                                <div>
                                    14. Se fija como domicilio de <b style="font-style: italic; font-weight: bold">Carseg Cdla.Vernaza Norte Mz.21 Solar 2,6,7 y 8</b>, Guayaquil, Ecuador. En caso de dudas
                                    sobre el presente acuerdo, y dem&aacute;s pol&iacute;ticas y principios que rigen
                                    el sitio, el usuario deberá comunicar por e-mail a <b style="font-style: italic; font-weight: bold">SoporteHunterOnline@carsegsa.com</b>
                                </div>
                                <div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
                <telerik:RadCodeBlock runat="server" ID="rdbScripts">
                    <script type="text/javascript">
                        function openWinContentTemplate() 
                        {
                            var check = document.getElementById("<%=chk_acuerdo.ClientID %>");
                            if (check.checked)
                                $find("<%= modalPopup.ClientID %>").show();
                        }

                        function openWinContentTemplateTwo() 
                        {
                            $find("<%= modalPopup.ClientID %>").show();
                        }

                        function showContent(check_box) 
                        {
                           if (check_box.checked)
                               $find("<%= modalPopup.ClientID %>").show();
                        }


                        function onClickLink() 
                        {
                            var check = document.getElementById("<%=chk_acuerdo.ClientID %>");
                            check.checked = true;
                        }

                        function OnClientClose(oWnd, args) 
                        {
                            var arg = args.get_argument();
                            if (arg) 
                            {
                                var aceptar = arg.aceptado;
                                var check = document.getElementById("<%=chk_acuerdo.ClientID %>");
                                if (aceptar == "1") 
                                {
                                    check.checked = true;
                                } else 
                                {
                                    check.checked = false;
                                }
                            }
                        }
                        
                        function setCustomPosition(sender, args)
                        {
                            sender.moveTo(sender.get_left(), sender.get_top());
                        }
                    </script>
                    <script type="text/javascript">
                        (function (d, s, id) 
                        {
                            var js, fjs = d.getElementsByTagName(s)[0];
                            if (d.getElementById(id)) return;
                            js = d.createElement(s); js.id = id;
                            js.src = "//connect.facebook.net/es_ES/sdk.js#xfbml=1&version=v2.0";
                            fjs.parentNode.insertBefore(js, fjs);
                        } (document, 'script', 'facebook-jssdk'));

                        !function (d, s, id) 
                        {
                            var js, fjs = d.getElementsByTagName(s)[0];
                            if (!d.getElementById(id)) 
                            {
                                js = d.createElement(s);
                                js.id = id; js.src = "//platform.twitter.com/widgets.js";
                                fjs.parentNode.insertBefore(js, fjs);
                            }
                        } (document, "script", "twitter-wjs");
                    </script>
                </telerik:RadCodeBlock>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" UpdatePanelsRenderMode="Inline">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="txt_regusu_identificacion">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_identificacion" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_nombre"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_apellido"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_contrasenia01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_contrasenia02" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_celular" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="chk_acuerdo" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="chk_suscripcion" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="BtnAceptar" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="lblcodigo" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="BtnAceptar">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_identificacion"   LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="nombrevalidator"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_nombre"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="apellidovalidator"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_apellido"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="emailValidator"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_email01" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_contrasenia01"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="contrasenia01Validator"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_contrasenia01" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_contrasenia02" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="contrasenia02Validator"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_contrasenia02"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="txt_regusu_celular"  LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="celularvalidator"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="vld_txt_regusu_celular" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="chk_acuerdo"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="chk_suscripcion" LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="BtnAceptar"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                                <telerik:AjaxUpdatedControl ControlID="rntMensajes" LoadingPanelID="RadAjaxLoadingPanel1"  />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
            </div>--%>
        </form>
        <script type="text/javascript" src="../js/main.js"></script>
    </body>
</html>