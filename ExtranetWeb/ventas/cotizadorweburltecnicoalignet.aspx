<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cotizadorweburltecnicoalignet.aspx.vb" Inherits="ExtranetWeb.cotizadorweburltecnicoalignet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" language="Javascript">
    function enviar() {
        document.f1.action = document.f1.URLVPOS.value; document.f1.boton01.disabled = true;
        document.f1.submit();
    }
</script>
<head runat="server">
    <title></title>
    <link href="../styles/estilocotizadorweburltecnico.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 345px;
            height: 27px;
        }
        .style3
        {
            height: 27px;
        }
        .style1
        {
            width: 345px;
        }
        #Select1
        {
            width: 165px;
        }
    </style>
</head>
<body onload="document.createElement('form').submit.call(document.getElementById('form1'))">
    <form name="form1" id="form1" action="https://vpayment.verifika.com/VPOS/MM/transactionStart20.do" method="post">
    <div style="visibility:hidden;">
        <strong>Datos de Cliente Vpos - Paso 2</strong><br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    IDACQUIRER:</td>
                <td>
                    <input name="IDACQUIRER" id="IDACQUIRER" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td class="style1">
                    COMMERCE:</td>
                <td>
                    <input name="IDCOMMERCE" id="IDCOMMERCE" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td class="style1">
                    XML:</td>
                <td>
                    <input  name="XMLREQ" id="XMLREQ" type="text"  runat="server"/></td>
            </tr>
            <tr>
                <td class="style2">
                    SIGNATURE:</td>
                <td class="style3">
                    <input name="DIGITALSIGN" id="DIGITALSIGN" runat="server" /></td>
            </tr>
            <tr>
                <td class="style1">
                    SESSIONKEY:</td>
                <td>
                    <input name="SESSIONKEY" id="SESSIONKEY" type="text" runat="server" /></td>
            </tr>
           <tr>
                <td class="style2">
                    URL VPOS</td>
                <td class="style3">
                    <select name="URLVPOS" id="URLVPOS" runat="server">
                        <option value="https://vpayment.verifika.com/VPOS/MM/transactionStart20.do">PRODUCCION</option>
                        <%--<option value="https://test2.alignetsac.com/VPOS/MM/transactionStart20.do">test2.alignetsac.com</option>--%>
                        <%--<option value="https://vpayment.verifika.com/VPOS/MM/transactionStart.do">PRODUCCION</option>--%>
                    </select>                    
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <input id="Button1" type="button" name="boton01" value="Enviar" onclick="enviar();" ondblclick="enviar();" /></td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>