<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="ExtranetWeb.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Hunter Online - Pagos de Servicios Online</title>
        <link rel="stylesheet" href="../styles/css_mkt/main.css">
        <link href="https://fonts.googleapis.com/css2?family=Raleway:wght@300;400;700&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
        <link rel="shortcut icon" href="../images/favicon.ico" />
        <script  src="https://code.jquery.com/jquery-3.2.1.min.js"></script>  
        <script type="text/javascript">
            var your_site_key = '6Lcqj9oaAAAAAELr_GJYIsHdvq_lAKjHLy_K51B9';
            var renderRecaptcha = function () {
                grecaptcha.render('ReCaptchContainer', { 
                    'sitekey': your_site_key,
                    'callback': reCaptchaCallback,
                    theme: 'light', //light or dark    
                    type: 'image',  // image or audio    
                    size: 'normal'  //normal or compact    
                });
            };
            var reCaptchaCallback = function (response) {
                if (response !== '') {
                    $('#<%=Btn_Login.ClientID %>').prop("disabled", false);
                }
            };
            jQuery('button[type="button"]').click(function (e) {
                var message = 'Please checck the checkbox';
                if (typeof (grecaptcha) != 'undefined') {
                    var response = grecaptcha.getResponse();
                    (response.length === 0) ? (message = 'Captcha verification failed') : (message = 'Success!');
                }
            });
        </script>
        <script type="text/javascript">
            (function () {
                var ldk = document.createElement('script');
                ldk.type = 'text/javascript';
                ldk.async = true;
                ldk.src = 'https://s.cliengo.com/weboptimizer/60ad0079029bad002aa75194/60ed9e00c6117c002ac53bf0.js?platform=onboarding_modular';
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(ldk, s);
            })();
        </script>
        <style type="text/css">
            .modalDialog {
	            position: fixed;
	            font-family: Arial, Helvetica, sans-serif;
	            top: 0;
	            right: 0;
	            bottom: 0;
	            left: 0;
	            background: rgba(0,0,0,0.8);
	            z-index: 99999;
	            opacity:0;
	            -webkit-transition: opacity 400ms ease-in;
	            -moz-transition: opacity 400ms ease-in;
	            transition: opacity 400ms ease-in;
	            pointer-events: none;
            }
            .modalDialog:target {
	            opacity:1;
	            pointer-events: auto;
            }
            .modalDialog > div {
	            width: 70%;
	            height:70%;
	            position: relative;
	            margin: 5% auto;
	            padding: 5px 20px 13px 20px;
	            border-radius: 10px;
	            background: #f4f7f9;
                -webkit-transition: opacity 400ms ease-in;
                -moz-transition: opacity 400ms ease-in;
                transition: opacity 400ms ease-in;
                overflow-y: scroll;
            }
            .close {
	            background: #606061;
	            color: #FFFFFF;
	            line-height: 25px;
	            position: absolute;
	            right: 10px;
	            text-align: center;
	            top: 10px;
	            width: 24px;
	            text-decoration: none;
	            font-weight: bold;
	            -webkit-border-radius: 12px;
	            -moz-border-radius: 12px;
	            border-radius: 12px;
	            -moz-box-shadow: 1px 1px 3px #000;
	            -webkit-box-shadow: 1px 1px 3px #000;
	            box-shadow: 1px 1px 3px #000;
            }
            .close:hover { background: #00d9ff; }
            .tituloh2 {
                font-size: 2.2rem;
                color: #000;
                font-weight: 700;
                text-align: center;
                margin-bottom: 1.2rem;
            }
        </style>
        <style type="text/css">
            .modalseleccioningreso{
                width:80%;
                height:80%;
                background: rgba(0,0,0,0.77);
                background: -moz-linear-gradient(-45deg, rgba(0,0,0,0.77) 0%, rgba(19,19,19,0.77) 100%);
                background: -webkit-gradient(left top, right bottom, color-stop(0%, rgba(0,0,0,0.77)), color-stop(100%, rgba(19,19,19,0.77)));
                background: -webkit-linear-gradient(-45deg, rgba(0,0,0,0.77) 0%, rgba(19,19,19,0.77) 100%);
                background: -o-linear-gradient(-45deg, rgba(0,0,0,0.77) 0%, rgba(19,19,19,0.77) 100%);
                background: -ms-linear-gradient(-45deg, rgba(0,0,0,0.77) 0%, rgba(19,19,19,0.77) 100%);
                background: linear-gradient(135deg, rgba(0,0,0,0.77) 0%, rgba(19,19,19,0.77) 100%);
                filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#000000', endColorstr='#131313', GradientType=1 );
                position:fixed;
                margin: 5% 10%;
            }
            .botonesseleccioningreso{
                width:30%;
                height:50%;
                margin:12% 10% 5% 10%;
                float:left;
                position:relative;
                background-color:Gray;
                font-size:2em;
            }
            .h1custom{
                margin: 30px 0px -30px 0px;
                color:White;
                text-align:center;
                font-size:3em;
            }
        </style>
    </head>
    <body class="red-back">
        
        <div id="dvseleccioningreso" class="modalseleccioningreso" runat="server">
            <h1 class="h1custom">Selección de perfil de usuario</h1>
            <a href="vehiculorol.aspx">
                <button id="btnenlacechequeo" runat="server" class="botonesseleccioningreso" onclick="">
                    <img src="../images/img_mkt/home-turnos-icon.png" alt="" />
                    <br />
                    <br />
                    Gestión de carga (Terceros)
                </button>
            </a>
            <a href="renovacion.aspx">
                <button id="btnenlacenormal" runat="server" class="botonesseleccioningreso">
                    <img src="../images/img_mkt/admin-bienes-icon.png" alt="" />
                    <br />
                    <br />
                    Mis Bienes
                </button>
            </a>
        </div>
        
        
        
        <header>
            <div class="socials">
                <p>HunterEcuador</p>
                <ul class="socials-icons">
                    <li>
                        <a href="https://twitter.com/hunterecuador">
                            <img src="../images/img_mkt/tweet.png" alt="Tweeter">
                        </a>
                    </li>
                    <li>
                        <a href="https://www.facebook.com/hunterecuador/">
                            <img src="../images/img_mkt/fb.png" alt="Facebook">
                        </a>
                    </li>
                    <li>
                        <a href="https://www.instagram.com/hunterecuador">
                            <img src="../images/img_mkt/ig.png" alt="Instagram">
                        </a>
                    </li>
                </ul>
            </div>
            <section class="wrap">
                <div class="top-header">
                    <img class="logo-ho" src="../images/img_mkt/logo-hunter-online2.png" alt="Logo Hunter Online">
                    <a href="registrousuario.aspx" class="btn-create">
                        crear cuenta
                    </a>
                    <a href="creacionnuevocliente.aspx" class="btn-create">
                        crear cliente
                    </a>
                </div>
                <div class="login-section">
                    <h1>
                        Bienvenidos a nuestras<br/> <strong>Soluciones</strong>
                        <br/> <b>en Línea</b> <br/>
                    </h1>
                    <form class="sign-form" runat="server" action="" onsubmit="miFuncion()">

                        <p>Ingrese sus datos</p>
                        <asp:TextBox ID="txt_Usuario" runat="server" class="input-field"
                                type="text" MaxLength="13" TabIndex="1" placeholder="Usuario">
                        </asp:TextBox>
                        <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" MaxLength="16"
                            TabIndex="2" class="input-field" placeholder="Contraseña">
                        </asp:TextBox>
                        <a href="recuperar.aspx">Olvidó su contraseña?</a>
                        <p id="diverror" runat="server" class="error-login">
                            <asp:Label ID="txtmensajeerror" Text="" runat="server"></asp:Label>
                        </p>
                        <asp:Button ID="Btn_Login" runat="server" Text="Ingresar" CssClass="form-submit-btn"
                            TabIndex="3" onclick="BtnLogin_Click" ><%--Enabled="true"--%>
                        </asp:Button>
                        <a href="registrousuario.aspx" class="btn-create btn-create-device">
                            crear cuenta
                        </a>
                    </form>
                </div>
            </section>
            <div class="arrow">
                <img src="../images/img_mkt/arrow.png">
            </div>
        </header>
        <section class="features">
            <div class="pagos">
                <i>
                    <img src="../images/img_mkt/pagos-icon.png" alt="" >
                </i>
                <h2>
                    Pagos<br/> <span> en Línea </span>
                </h2>
                <p>Renueva tu contrato y realiza pagos pendientes, <br/> a través de nuestro portal web.</p>
            </div>
            <div class="administrar">
                <i>
                    <img src="../images/img_mkt/admin-bienes-icon.png" alt="" >
                </i>
                <h2>
                    Administrar<br/> <span> Datos y Bienes </span>
                </h2>
                <p>Registro actualizado de tus activos protegidos, <br/> con el detalle del estado y mantenimientos de tus dispositivos.</p>
            </div>
            <div class="turnos">
                <i>
                    <img src="../images/img_mkt/home-turnos-icon.png" alt="" >
                </i>
                <h2>
                    Turnos<br/> <span> para chequeos </span>
                </h2>
                <p>Agenda tu turno en nuestros talleres <br/> para el mantenimiento del dispositivo.</p>
            </div>
            <div class="facturacion">
                <i>
                    <img src="../images/img_mkt/facturacion-icon.png" alt="" >
                </i>
                <h2>
                    Facturación<br/> <span> en Línea </span>
                </h2>
                <p>Revisa tus facturas y comprobantes <br/> emitidos con tus pagos.</p>
            </div>
        </section>
        <footer>
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
                            <a href="#Terminos">
                                Términos de Uso y Privacidad 
                            </a>
                        </li>
                        <li>
                            <a href="ContactenosCliente.aspx">
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
            <div id="Terminos" class="modalDialog">
                <div >
		            <a href="#close" title="Close" class="close">X</a>
                    <h2 class="tituloh2">
                        ACUERDO SOBRE T&Eacute;RMINOS DE USO Y POL&Iacute;TICAS DE PRIVACIDAD
                    </h2>
                    <div id="divterminos" runat="server" style="text-align:justify; font-size:small; color:Black;">
                        El presente acuerdo contiene los t&eacute;rminos y condiciones generales, aplicables al uso de los 
                        servicios ofrecidos por Carro Seguro Carseg S.A. (en adelante Carseg), dentro de su sitio 
                        <b style="font-style: italic; font-weight: bold">www.HunterOnline.com.ec</b> (en adelante el sitio).&nbsp;
                        <br /><br />
                        Cualquier persona que desee acceder y/o usar el sitio o los servicios de &eacute;ste, podr&aacute; 
                        hacerlo siempre que se sujete a los t&eacute;rminos y condiciones aqu&iacute;	")
                        contenidas, junto con las dem&aacute;s pol&iacute;ticas y principios que rigen el sitio; por tanto, 
                        quien no acepte estos t&eacute;rminos y condiciones generales,	")
                        que tienen car&aacute;cter obligatorio y vinculante, deber&aacute; abstenerse de utilizar el sitio y/o los 
                        servicios.
                        <br /><br />
                        El Usuario debe leer, entender y aceptar todas las condiciones establecidas en el presente instrumento, 
                        as&iacute; como en los dem&aacute;s documentos incorporados por referencia, previa a su 
                        inscripci&oacute;n como usuario de Carseg.&nbsp;
                        <br /><br />
                        1. Los servicios de Carseg s&oacute;lo est&aacute;n disponibles para personas que tengan capacidad legal 
                        para contratar; por tanto, no deben ser utilizados por menores de edad, personas que no tengan esa 
                        capacidad o aquellas que hayan sido suspendidas o dadas de baja del sistema de Carseg, temporal o 
                        definitivamente, por haber incumplido las disposiciones del presente instrumento, o por haber incurrido 
                        a criterio de Carseg, en conductas o actos dolosos o fraudulentos, mediante el uso del sitio o
                        de los servicios. Si usted est&aacute; inscribiendo un usuario como persona jur&iacute;dica, debe tener 
                        capacidad para contratar a nombre de la misma, y de obligar a &eacute;sta en los t&eacute;rminos de este 
                        acuerdo.&nbsp;
                        <br /><br />
                        2. El usuario se obliga a completar el formulario de inscripci&oacute;n en todos
                        sus campos, para poder utilizar los servicios que brinda Carseg El usuario se obliga
                        a consignar su informaci&oacute;n personal de manera exacta, precisa y verdadera,
                        y asume el compromiso de actualizar sus datos personales cuando sea necesario. Carseg
                        podr&aacute; utilizar diversos medios para identificar a sus usuarios, pero Carseg
                        no se responsabiliza por la certeza de los datos personales provistos por sus usuarios.
                        En consecuencia, los usuarios garantizan y responden, en cualquier caso, de la veracidad,
                        exactitud, vigencia y autenticidad de los datos personales ingresados.&nbsp;
                        <br /><br />
                        3. El usuario acceder&aacute; a su cuenta personal en el sitio, mediante el ingreso
                        de &hellip; y una clave de seguridad personal elegida por &eacute;ste. El usuario
                        de <b style=""font-style: italic; font-weight: bold"">Cédula</b> o  
                        <b style=""font-style: italic; font-weight: bold"">Ruc</b> y una clave de seguridad personal elegida 
                        por &eacute;ste. El usuario se obliga a mantener la confidencialidad de su clave de seguridad. 
                        El usuario ser&aacute; responsable por todas las operaciones efectuadas en su cuenta, pues el acceso a
                        la misma est&aacute; restringido al ingreso y uso de su clave de seguridad, de conocimiento
                        exclusivo del usuario. El usuario se compromete a notificar a Carseg, en forma inmediata
                        y por medio id&oacute;neo y fehaciente, cualquier uso no autorizado de su cuenta,
                        as&iacute; como el ingreso por terceros no autorizados a la misma.&nbsp;
                        <br /><br />
                        4. Carseg no vender&aacute;, alquilar&aacute; ni negociar&aacute; con otras empresas
                        los datos personales de sus usuarios, salvo su autorizaci&oacute;n en contrario.
                        Estos datos ser&aacute;n usados por Carseg, &uacute;nicamente para perfeccionar
                        la transacci&oacute;n. La informaci&oacute;n personal de los usuarios se procesa
                        y almacena en servidores o medios magn&eacute;ticos que mantienen altos est&aacute;ndares
                        de seguridad y protecci&oacute;n tanto f&iacute;sica como tecnol&oacute;gica.&nbsp;
                        <br /><br />
                        5. Carseg no se responsabiliza del entendimiento, interpretaci&oacute;n y/o uso	
                        del contenido del sitio por parte de sus usuarios; por tanto, el uso de la informaci&oacute;n	
                        es responsabilidad exclusiva del usuario. Carseg se reserva la facultad de modificar	
                        el contenido y/o servicio por s&iacute; mismo o mediante un tercero autorizado,	
                        sin que est&eacute; obligado a notificar previamente al usuario.&nbsp;	
                        <br /><br />
                        6. Carseg no garantiza el acceso permanente e ininterrumpido al sitio, ni que el	
                        servicio o servidor est&eacute; libre de virus. El usuario debe tomar las medidas	
                        necesarias para evitar los efectos del mismo.&nbsp;	
                        <br /><br />
                        7. No est&aacute; permitido el uso de ning&uacute;n dispositivo, software u otro	
                        medio tendiente a interferir tanto en las actividades y operatividad del sitio de	
                        Carseg, como en las ofertas o en las bases de datos de Carseg. Cualquier intromisi&oacute;n,	
                        tentativa o actividad violatoria o contraria a las leyes sobre derecho de autor	
                        y/o a las prohibiciones estipuladas en este documento, facultar&aacute;n a Carseg	
                        el inicio de las acciones legales pertinentes; la imposici&oacute;n de las sanciones	
                        previstas por este acuerdo; y, demandar una indemnizaci&oacute;n por los da&ntilde;os	
                        y perjuicios irrogados.&nbsp;	
                        <br /><br />
                        8. En cualquier momento Carseg podr&aacute; advertir, suspender o cancelar, temporal	
                        o definitivamente la cuenta de un usuario o una transacci&oacute;n, e iniciar las	
                        acciones que estime pertinentes, si se quebrantara alguna ley, o cualquiera de las	
                        estipulaciones de este acuerdo, o si se incurriera a criterio de Carseg en conductas	
                        o actos dolosos o fraudulentos, o, si no pudiera verificarse la identidad del usuario,	
                        o cualquier informaci&oacute;n proporcionada por el mismo fuere err&oacute;nea.	
                        En caso de suspensi&oacute;n o inhabilitaci&oacute;n de un usuario, todas las transacciones	
                        u operaciones del usuario ser&aacute;n removidas del sistema.&nbsp;	
                        <br /><br />
                        9. Carseg se reserva el derecho de cancelar la cuenta del usuario que hubiere incumplido	
                        sus obligaciones derivadas de una transacci&oacute;n, o si se detectara en su conducta	
                        intencionalidad de perjudicar o defraudar a otros usuarios.&nbsp;	
                        <br /><br />
                        10. Carseg se reserva el derecho a cancelar una transacci&oacute;n por razones no	
                        mencionadas anteriormente, o si considera que el usuario ha incurrido en alg&uacute;n	
                        error involuntario, o por cualquier otra raz&oacute;n que Carseg considere justificada.&nbsp;	
                        <br /><br />
                        11. Carseg emitirá el comprobante de venta, únicamente con los datos registrados por el usuario en 
                        el formulario de inscripción.
                        <br /><br />
                        12. Carseg podr&aacute; modificar en cualquier momento los t&eacute;rminos y condiciones	
                        de este acuerdo, y notificar&aacute; los cambios al usuario, publicando una versi&oacute;n	
                        actualizada de dichos t&eacute;rminos y condiciones en el sitio, con expresi&oacute;n	
                        de la fecha de la &uacute;ltima modificaci&oacute;n. Dentro de los 5 d&iacute;as	
                        siguientes a la publicaci&oacute;n de las modificaciones introducidas, el usuario	
                        deber&aacute; comunicar por e-mail a <b style=""font-style: italic; font-weight: bold"">
                        SoporteHunterOnline@carsegsa.com</b>, si no acepta las mismas; en ese caso	
                        quedar&aacute; disuelto el v&iacute;nculo contractual y ser&aacute; inhabilitado	
                        como usuario. Vencido este plazo, se considerar&aacute; que el usuario acepta los	
                        nuevos t&eacute;rminos y el acuerdo continuar&aacute; vinculando a ambas partes.&nbsp;	
                        <br /><br />
                        13. El usuario autoriza expresamente a Carseg, a enviarle al correo electrónico registrado o vía 
                        SMS al número celular registrado, información referente a sus productos o servicios, promociones y 
                        avisos de interés. El usuario podrá revocar en cualquier momento esta autorización, al correo 
                        electrónico <b style="font-style: italic; font-weight: bold"> SoporteHunterOnline@carsegsa.com</b>
                        <br /><br />
                        14. Se fija como domicilio de <b style="font-style: italic; font-weight: bold">Carseg Cdla.Vernaza 
                        Norte Mz.10 Solar 19</b>, Guayaquil, Ecuador. En caso de dudas	
                        sobre el presente acuerdo, y dem&aacute;s pol&iacute;ticas y principios que rigen	
                        el sitio, el usuario deberá comunicar por e-mail a <b style="font-style: italic; font-weight: bold">
                        SoporteHunterOnline@carsegsa.com</b>
                    </div>
                </div>
            </div>
        </footer>
    </body>
</html>
