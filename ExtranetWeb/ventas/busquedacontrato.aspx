<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="busquedacontrato.aspx.vb" Inherits="ExtranetWeb.busquedacontrato" EnableSessionState="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilomodal.css" rel="stylesheet" type="text/css" />
        <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton.rbImageButton
            {
                border: 0 none;
                outline: 0 none;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .RadButton_Default
            {
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
                font-size: 12px;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbImageButton
            {
                position: relative;
                display: inline-block;
                cursor: pointer;
                text-decoration: none;
                text-align: center;
            }
            .RadButton
            {
                cursor: pointer;
            }
            .RadButton
            {
                font-size: 12px;
                font-family: "Segoe UI" ,Arial,Helvetica,sans-serif;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
            .rbHideElement
            {
                display: none;
                width: 0 !important;
                height: 0 !important;
                overflow: hidden !important;
            }
            .rbText
            {
                display: inline-block;
            }
        </style>
    </head>
    <%--<body onload="AdjustRadWidow();" class="body">--%>
    <body class="body">
        <form id="form1" method="post" runat="server">
            <div class="contenedor">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                <script type="text/javascript">
                    function GetRadWindow() 
                    {
                        var oWindow = null;
                        if (window.radWindow) oWindow = window.radWindow;
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                        return oWindow;
                    }

                    function AdjustRadWidow() 
                    {
                        var oWindow = GetRadWindow();
                        setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
                    }

                    function ChromeSafariFix(oWindow) 
                    {
                        var iframe = oWindow.get_contentFrame();
                        var body = iframe.contentWindow.document.body;
                        setTimeout(function () 
                        {
                            var height = body.scrollHeight;
                            var width = body.scrollWidth;
                            var iframeBounds = $telerik.getBounds(iframe);
                            var heightDelta = height - iframeBounds.height;
                            var widthDelta = width - iframeBounds.width;
                            if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                            if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                            oWindow.center();
                        }, 310);
                    }

                    function returnParent() 
                    {
                        var oWnd = GetRadWindow();
                        alert("Usted no ha aceptado los términos.");
                        oWnd.close();
                    }

                    function returnToParent() 
                    {
                        var oArg = new Object();
                        var oWnd = GetRadWindow();
                        oArg.resultado = "true";
                        oWnd.close(oArg);
                    } 
                </script>
                <div class="busqueda">
                    <div class="menu">
                        <div class="icono">
                            <telerik:RadButton ID="BtnAceptar" runat="server" Text="Aceptar" ForeColor="Black"
                                Style="top: 0px; left: 0px; height: 28px; width: 28px" ToolTip="Aceptar Términos"
                                OnClientClicked="returnToParent" AutoPostBack="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/check28x28.png" />
                            </telerik:RadButton>
                        </div>
                        <div class="icono">
                            <telerik:RadButton ID="BtnClose" runat="server" Text="Cerrar" ForeColor="Black" Style="top: 0px;
                                left: 0px; height: 28px; width: 28px" ToolTip="Cerrar pantalla" OnClientClicked="returnParent"
                                AutoPostBack="False">
                                <Image IsBackgroundImage="False" ImageUrl="../images/icons/28x28/turnoffwin28x28.jpg" />
                            </telerik:RadButton>
                        </div>
                    </div>
                    <div class="data" style="width:900px; height:700;">
                        <div style="overflow: auto; -webkit-overflow-scrolling: touch;">
                           <embed id="myframe" src="" name="myframe" runat="server" width="100%" height="480" visible="true" ></embed> 
                        </div>
                    </div>
                </div>
            </div>
            <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True">
            </telerik:RadNotification>
        </form>
    </body>
</html>
