<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ventas/master.Master" CodeBehind="RenovacionPago.aspx.vb" Inherits="ExtranetWeb.RenovacionPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <meta charset="UTF-8">
   <title>Hunter Online - Renovaciones</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap" rel="stylesheet">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" action="#" runat="server">
        <section class="info-body">  
            <div id="dvdmensajes" class="messages alert" runat="server">
                <p>
                    <label id="lblmensajeerror" runat="server"></label>    
                </p>
                <label id="close" for="hide-message" class="x-btn">&#10005</label>
            </div>                   
            <ul class="steps">
                <li>
                    <div class="circle">
                        1
                    </div>
                    <p>
                        Seleccionar<br/> Producto
                    </p>
                </li>
                <li class="separator"></li>
                <li>
                    <div class="circle">
                        2
                    </div>
                    <p>
                        Datos de<br/> Factura
                    </p>
                </li>
                <li class="separator"></li>
                <li>
                    <div class="circle current">
                        3
                    </div>
                    <p class="current">
                        Confirmar<br/> Pedido
                    </p>
                </li>
            </ul>
            <div class="total-pagar">
                <p class="numero-orden">
                    Número orden de pago: 
                    <b>
                        <asp:Label ID="lblnumeroorden" runat="server" Text="0">
                        </asp:Label>
                    </b>
                </p>
                <div class="total-container">
                    <h2 class="header-container">
                        Total a Pagar de su Compra
                    </h2>
                    <div class="body-container">
                        <div class="body-container-text">
                            <div class="services-number">
                                <p>
                                    Servicios<br/> Contratados
                                </p>
                                <p class="big-number">
                                    <asp:Label ID="lblresumencantidad" runat="server" Text="0">
                                    </asp:Label>
                                </p>
                            </div>
                            <div class="table-total">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td class="detalle">
                                                P. Unitario
                                            </td>
                                            <td>
                                                <asp:Label ID="lblresumentotal" runat="server" Text="0">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="separator-row">
                                            <td class="detalle">
                                                V. Promoción (-)
                                            </td>
                                            <td>
                                                <asp:Label ID="lblresumenpromocion" runat="server" Text="0">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="detalle">
                                                SubTotal
                                            </td>
                                            <td>
                                                <asp:Label ID="lblresumensubtotal" runat="server" Text="0">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="separator-row">
                                            <td class="detalle">
                                                I.V.A
                                            </td>
                                            <td>
                                                <asp:Label ID="lblresumeniva" runat="server" Text="0">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="detalle">
                                                Total a Pagar
                                            </td>
                                            <td class="valor-final">
                                                <asp:Label ID="lblresumenpreciocliente" runat="server" Text="0">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="btn-pagar">
                            <asp:button id="btnpagar" runat="server" class="btn-class" Text="Pagar">
                            </asp:button>
                        </div>
                        <div class="btn-pagar">
                            <asp:button id="btnlink" runat="server" class="btn-class" Text="Generar link de pago">
                            </asp:button>
                        </div>
                        <div class="btn-pagar">
                            <asp:TextBox ID="txtlinkpago" runat="server" Text="" onfocus="this.select();" ReadOnly="true" Visible="false" Width="100%" Height="20px" TextMode="Url">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
                <p class="aceptar-terminos">
                    *** Al hacer click en pagar acepta nuestros <a href="#Terminos"> términos y condiciones</a>
                </p>
            </div>
            <div class="info-servicios">
                <h1>
                    Confirme la información de sus servicios a renovar
                </h1>
                <div class="services-detail">
                    <ASP:Repeater id="Rpt_resumen_renovacion" runat="server">
                    <ItemTemplate>
                        <div class="service-item">
                            <p>
                                <asp:Label ID="lblresumenvehiculo" runat="server" Text='<%# Eval("VEHICULO_NOMBRE") %>'>
                                </asp:Label>
                            </p>
                            <ul>
                                <ASP:Repeater id="Rpt_resumen_renovacion_itm" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <asp:Label ID="lblresumenvehiculogrupo" runat="server" Text='<%# Eval("GRUPO_DESCRIPCION") %>'>
                                        </asp:Label>
                                    </li>
                                </ItemTemplate>
                                </ASP:Repeater>
                            </ul>
                        </div>
                    </ItemTemplate>
                    </ASP:Repeater>
                </div>
            </div>
            <div id="divp2p" style="width:100%; height:40px;" runat="server">
                <img src="https://static.placetopay.com/placetopay-logo-black.svg" class="attachment-0x0 size-0x0" alt="" loading="lazy">
            </div>
        </section>
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
                    avisos de interés.
                    <br /><br />
                    14. Se fija como domicilio de <b style="font-style: italic; font-weight: bold">Carseg Cdla.Vernaza 
                    Norte Mz.21 Solar 2,6,7 y 8</b>, Guayaquil, Ecuador. En caso de dudas	
                    sobre el presente acuerdo, y dem&aacute;s pol&iacute;ticas y principios que rigen	
                    el sitio, el usuario deberá comunicar por e-mail a <b style="font-style: italic; font-weight: bold">
                    SoporteHunterOnline@carsegsa.com</b>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
