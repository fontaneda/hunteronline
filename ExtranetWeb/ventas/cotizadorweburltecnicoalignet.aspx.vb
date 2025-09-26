Imports System.IO
Imports VPOS20_PLUGIN

Public Class cotizadorweburltecnicoalignet
    Inherits System.Web.UI.Page

#Region "DECLAREACION DE VARIABLES"
    Dim DTSetInfoURLTecnico As New DataTable()
#End Region

#Region "EVENTOS DE LA PAGINA"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 28/11/2014
    ''' DESCR: EVENTO LOAD DEL PAGE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                GeneraDataPostAlignet()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTOS GENERALES"

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 28/11/2014
    ''' DESCR: FUNCION PARA CARGAR VALOR TOTAL DEL CLIENTE A ENVIAR AL ADQUIRIENTE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CargaTotalCliente() As String
        CargaTotalCliente = "0"
        Try
            DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
            CargaTotalCliente = DTSetInfoURLTecnico.Rows(7)("datatecnica")
            CargaTotalCliente = CargaTotalCliente.Replace(".", "")
            CargaTotalCliente = CargaTotalCliente.Replace(",", "")
            Return CargaTotalCliente
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 20/10/2015
    ''' DESCR: FUNCION PARA CARGAR VALOR DEL IVA DEL CLIENTE A ENVIAR AL ADQUIRIENTE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CargaTotalsinIvaCliente() As String
        CargaTotalsinIvaCliente = "0"
        Try
            DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
            CargaTotalsinIvaCliente = DTSetInfoURLTecnico.Rows(8)("datatecnica")
            CargaTotalsinIvaCliente = CargaTotalsinIvaCliente.Replace(".", "")
            CargaTotalsinIvaCliente = CargaTotalsinIvaCliente.Replace(",", "")
            Return CargaTotalsinIvaCliente
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 20/10/2015
    ''' DESCR: FUNCION PARA CARGAR VALOR DEL IVA DEL CLIENTE A ENVIAR AL ADQUIRIENTE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CargaIvaCliente() As String
        CargaIvaCliente = "0"
        Try
            DTSetInfoURLTecnico = Session("DTGetInfoURLTecnico")
            CargaIvaCliente = DTSetInfoURLTecnico.Rows(11)("datatecnica")
            CargaIvaCliente = CargaIvaCliente.Replace(".", "")
            CargaIvaCliente = CargaIvaCliente.Replace(",", "")
            Return CargaIvaCliente
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA C.
    ''' FECHA: 28/11/2014
    ''' DESCR: PROCEDIMIENTO PARA GENERAR DATA PARA EL VPOS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GeneraDataPostAlignet()
        Try
            Dim oVPOSBean As VPOSBean = New VPOSBean
            Dim R1 As String = Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPublicaAlignet").ToString())
            Dim R2 As String = Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyPrivadaFirmaAlignet").ToString())
            Dim Vector As String = Libreria.ReadFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyVectorAlignet").ToString()))

            Dim srVPOSLlaveCifradoPublica = New StreamReader(R1)
            Dim srComercioLlaveFirmaPrivada = New StreamReader(R2)

            Dim total As String = CargaTotalCliente()
            Dim iva As String = CargaIvaCliente()
            Dim totalsiniva As String = CargaTotalsinIvaCliente()
            Dim lenguaje As String = ConfigurationManager.AppSettings.Get("IdLenguajeALignet").ToString()
            Dim adquiriente As String = ConfigurationManager.AppSettings.Get("IdAquirienteAlignet").ToString()
            Dim comercio As String = ConfigurationManager.AppSettings.Get("IdComercioALignet").ToString()
            Dim comercio_mall As String = ConfigurationManager.AppSettings.Get("IdMallComercio").ToString()
            Dim terminal As String = ConfigurationManager.AppSettings.Get("CodigoTerminal").ToString()
            Dim moneda As String = ConfigurationManager.AppSettings.Get("IdCodigoMonedaALignet").ToString()

            oVPOSBean.acquirerId = adquiriente
            oVPOSBean.commerceId = comercio
            oVPOSBean.purchaseAmount = total
            oVPOSBean.purchaseCurrencyCode = moneda
            oVPOSBean.purchaseOperationNumber = Session("IdOrdenVpos")
            oVPOSBean.language = lenguaje
            'Fontaneda/20/10/2015 - se añaden nuevos parametros al envio, Alignet reporta errores por campos faltantes.
            oVPOSBean.commerceMallId = comercio_mall
            oVPOSBean.terminalCode = terminal
            'Fontaneda/28/04/2016 - se añaden nuevos parametros al envio, Alignet reporta errores por campos faltantes.
            '' '' ''oVPOSBean.reserved1 = totalsiniva
            '' '' ''oVPOSBean.reserved2 = iva
            '' '' ''oVPOSBean.reserved3 = lenguaje
            '' '' ''oVPOSBean.reserved9 = "000"
            '' '' ''oVPOSBean.reserved11 = "000"
            '' '' ''oVPOSBean.reserved12 = "000"
            'Fontaneda 06/05/2016 - se cambian nuevos parametros al envio, Alignet reporta errores por campos faltantes.
            oVPOSBean.reserved1 = lenguaje
            oVPOSBean.reserved2 = totalsiniva
            oVPOSBean.reserved3 = iva
            oVPOSBean.reserved4 = "000"
            oVPOSBean.reserved5 = "000"
            oVPOSBean.reserved9 = "000"
            oVPOSBean.reserved10 = totalsiniva
            'Fin cambios
            '' '' ''oVPOSBean.addTax("Monto fijo", total)
            '' '' ''oVPOSBean.addTax("Monto IVA", iva)
            '' '' ''oVPOSBean.addTax("Adicional", "000")
            '' '' ''oVPOSBean.addTax("Monto No Grava IVA", "000")
            '' '' ''oVPOSBean.addTax("Monto Grava IVA", totalsiniva)
            'Fontaneda 06/05/2016 - se añaden nuevos taxess al envio, solicitado por Alignet.
            oVPOSBean.addTax("Adicional", "000")
            oVPOSBean.addTax("Monto fijo", "000")
            oVPOSBean.addTax("Monto IVA", iva)
            oVPOSBean.addTax("Adicional", "000")
            oVPOSBean.addTax("Adicional", "000")
            oVPOSBean.addTax("Adicional", "000")
            oVPOSBean.addTax("Adicional", "000")
            oVPOSBean.addTax("Adicional", "000")
            oVPOSBean.addTax("Monto No Grava IVA", "000")
            oVPOSBean.addTax("Monto Grava IVA", totalsiniva)
            'Fin cambios

            Dim oVPOSSend = New VPOSSend(srVPOSLlaveCifradoPublica, srComercioLlaveFirmaPrivada, Vector)
            oVPOSSend.execute(oVPOSBean)

            Dim sCipheredSessionKey As String = oVPOSBean.cipheredSessionKey
            Dim sCipheredXML As String = oVPOSBean.cipheredXML
            Dim sCipheredSignature As String = oVPOSBean.cipheredSignature

            IDACQUIRER.Value = ConfigurationManager.AppSettings.Get("IdAquirienteAlignet").ToString()
            IDCOMMERCE.Value = ConfigurationManager.AppSettings.Get("IdComercioALignet").ToString()
            XMLREQ.Value = sCipheredXML
            DIGITALSIGN.Value = sCipheredSignature
            SESSIONKEY.Value = sCipheredSessionKey
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class