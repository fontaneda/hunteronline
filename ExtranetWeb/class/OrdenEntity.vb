Imports System
'Imports System.Text
'Imports System.Collections.Generic


Public Class OrdenEntity

#Region " Atributtes "

    Private _orden_id As Int64
    Private _cliente_id As String
    Private _numero_meses As Int32
    Private _tipo_tarjeta As String
    Private _subtotal As Decimal
    Private _iva As Decimal
    Private _ice As Decimal
    Private _intereses As Decimal
    Private _total As Decimal
    Private _tipo_pago As Int32
    Private _tipo_credito As String
    Private _codigo_conf_pago As String
    Private _billingname As String
    Private _billingcedula As String
    Private _billingaddress As String
    Private _billingphone As String
    Private _billingmovil As String
    Private _billingemail As String
    Private _billingcardtype As Int32
    Private _convertido As Int32
    Private _estado_web_id As Int32
    Private _estado_envio As String
    Private _fecha_envio As Date
    Private _usuario_proceso_id As Decimal
    Private _fecha_proceso As Date
    Private _idemisor As String
    Private _accion_comercial As String
    Private _clientemonitoreo As String = ""
    Private _usuariosoporte As String
    'Private _tarjeta_da As String
    'Private _expira_tarjeta_da As Date
    Private _orden_detalle_entity_collection As OrdenDetalleEntityCollection

#End Region

#Region " Properties "

    Public Property OrdenId() As Int64
        Get
            Return _orden_id
        End Get
        Set(ByVal value As Int64)
            _orden_id = value
        End Set
    End Property

    Public Property ClienteId() As String
        Get
            Return _cliente_id
        End Get
        Set(ByVal value As String)
            _cliente_id = value
        End Set
    End Property

    Public Property NumeroMeses() As Int32
        Get
            Return _numero_meses
        End Get
        Set(ByVal value As Int32)
            _numero_meses = value
        End Set
    End Property

    Public Property TipoTarjeta() As String
        Get
            Return _tipo_tarjeta
        End Get
        Set(ByVal value As String)
            _tipo_tarjeta = value
        End Set
    End Property

    Public Property SubTotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property

    Public Property Iva() As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
        End Set
    End Property

    Public Property Ice() As Decimal
        Get
            Return _ice
        End Get
        Set(ByVal value As Decimal)
            _ice = value
        End Set
    End Property

    Public Property Interes() As Decimal
        Get
            Return _intereses
        End Get
        Set(ByVal value As Decimal)
            _intereses = value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property

    Public Property TipoPago() As Int32
        Get
            Return _tipo_pago
        End Get
        Set(ByVal value As Int32)
            _tipo_pago = value
        End Set
    End Property

    Public Property TipoCredito() As String
        Get
            Return _tipo_credito
        End Get
        Set(ByVal value As String)
            _tipo_credito = value
        End Set
    End Property

    Public Property CodigoConfPago() As String
        Get
            Return _codigo_conf_pago
        End Get
        Set(ByVal value As String)
            _codigo_conf_pago = value
        End Set
    End Property

    Public Property BillingName() As String
        Get
            Return _billingname
        End Get
        Set(ByVal value As String)
            _billingname = value
        End Set
    End Property

    Public Property BillingCedula() As String
        Get
            Return _billingcedula
        End Get
        Set(ByVal value As String)
            _billingcedula = value
        End Set
    End Property

    Public Property BillingAddress() As String
        Get
            Return _billingaddress
        End Get
        Set(ByVal value As String)
            _billingaddress = value
        End Set
    End Property

    Public Property BillingPhone() As String
        Get
            Return _billingphone
        End Get
        Set(ByVal value As String)
            _billingphone = value
        End Set
    End Property

    Public Property BillingMovil() As String
        Get
            Return _billingmovil
        End Get
        Set(ByVal value As String)
            _billingmovil = value
        End Set
    End Property

    Public Property BillingEmail() As String
        Get
            Return _billingemail
        End Get
        Set(ByVal value As String)
            _billingemail = value
        End Set
    End Property

    Public Property BillingCardType() As Int32
        Get
            Return _billingcardtype
        End Get
        Set(ByVal value As Int32)
            _billingcardtype = value
        End Set
    End Property

    Public Property Convertido() As Int32
        Get
            Return _convertido
        End Get
        Set(ByVal value As Int32)
            _convertido = value
        End Set
    End Property

    Public Property EstadoWebId() As Int32
        Get
            Return _estado_web_id
        End Get
        Set(ByVal value As Int32)
            _estado_web_id = value
        End Set
    End Property

    Public Property EstadoEnvio() As String
        Get
            Return _estado_envio
        End Get
        Set(ByVal value As String)
            _estado_envio = value
        End Set
    End Property

    Public Property FechaEnvio() As Date
        Get
            Return _fecha_envio
        End Get
        Set(ByVal value As Date)
            _fecha_envio = value
        End Set
    End Property

    Public Property UsuarioProcesoId() As Decimal
        Get
            Return _usuario_proceso_id
        End Get
        Set(ByVal value As Decimal)
            _usuario_proceso_id = value
        End Set
    End Property

    Public Property FechaProceso() As Date
        Get
            Return _fecha_proceso
        End Get
        Set(ByVal value As Date)
            _fecha_proceso = value
        End Set
    End Property

    Public Property idemisor() As String
        Get
            Return _idemisor
        End Get
        Set(ByVal value As String)
            _idemisor = value
        End Set
    End Property

    Public Property AccionComercial() As String
        Get
            Return _accion_comercial
        End Get
        Set(ByVal value As String)
            _accion_comercial = value
        End Set
    End Property

    Public Property ClienteMonitoreo() As String
        Get
            Return _clientemonitoreo
        End Get
        Set(ByVal value As String)
            _clientemonitoreo = value
        End Set
    End Property

    Public Property UsuarioSoporte() As String
        Get
            Return _usuariosoporte
        End Get
        Set(ByVal value As String)
            _usuariosoporte = value
        End Set
    End Property

    'Public Property tarjeta_da() As String
    '    Get
    '        Return _tarjeta_da
    '    End Get

    '    Set(ByVal value As String)
    '        _tarjeta_da = value
    '    End Set
    'End Property


    'Public Property expira_tarjeta_da() As Date
    '    Get
    '        Return _expira_tarjeta_da
    '    End Get
    '    Set(ByVal value As Date)
    '        _expira_tarjeta_da = value
    '    End Set
    'End Property

    Public Property OrdenDetalleEntityCollection() As OrdenDetalleEntityCollection
        Get
            Return _orden_detalle_entity_collection
        End Get
        Set(ByVal value As OrdenDetalleEntityCollection)
            _orden_detalle_entity_collection = value
        End Set
    End Property

#End Region

End Class