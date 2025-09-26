Imports System

Public Class OrdenDetalleEntity

#Region " Atributtes "

    Private _orden_detalle_id As Int64
    Private _orden_id As Int64
    Private _vehiculo_id As String
    Private _transaccion_id As String
    Private _fecha_vencimiento As Date
    Private _anios As Int32
    Private _valor_anual As Decimal
    Private _codigo_promocion As String
    Private _valor_promocion As Decimal
    Private _porcentaje_descuento As Decimal
    Private _descuento As Decimal
    Private _subtotal As Decimal
    Private _iva As Decimal
    Private _total As Decimal
    Private _usuario_proceso_id As Decimal
    Private _fecha_proceso As Date
    Private _marcado_lojack As String
    Private _item As Int32 = 0
    Private _transaccion As String = ""
    Private _es_debito As String
    Private _producto_debito As String
    Private _fechaini_debito As String
    Private _fechafin_debito As String
    Private _ejecutiva As String


#End Region

#Region " Properties "

    Public Property OrdenDetalleId() As Int64
        Get
            Return _orden_detalle_id
        End Get

        Set(ByVal Value As Int64)
            _orden_detalle_id = Value
        End Set
    End Property
    Public Property OrdenId() As Int64
        Get
            Return _orden_id
        End Get

        Set(ByVal Value As Int64)
            _orden_id = Value
        End Set
    End Property
    Public Property VehiculoId() As String
        Get
            Return _vehiculo_id
        End Get

        Set(ByVal Value As String)
            _vehiculo_id = Value
        End Set
    End Property
    Public Property TransaccionId() As String
        Get
            Return _transaccion_id
        End Get

        Set(ByVal Value As String)
            _transaccion_id = Value
        End Set
    End Property
    Public Property FechaVencimiento() As Date
        Get
            Return _fecha_vencimiento
        End Get

        Set(ByVal Value As Date)
            _fecha_vencimiento = Value
        End Set
    End Property
    Public Property Anios() As Int32
        Get
            Return _anios
        End Get

        Set(ByVal Value As Int32)
            _anios = Value
        End Set
    End Property
    Public Property ValorAnual() As Decimal
        Get
            Return _valor_anual
        End Get

        Set(ByVal Value As Decimal)
            _valor_anual = Value
        End Set
    End Property
    Public Property CodigoPromocion() As String
        Get
            Return _codigo_promocion
        End Get

        Set(ByVal Value As String)
            _codigo_promocion = Value
        End Set
    End Property
    Public Property ValorPromocion() As Decimal
        Get
            Return _valor_promocion
        End Get

        Set(ByVal Value As Decimal)
            _valor_promocion = Value
        End Set
    End Property
    Public Property PorcentajeDescuento() As Decimal
        Get
            Return _porcentaje_descuento
        End Get

        Set(ByVal Value As Decimal)
            _porcentaje_descuento = Value
        End Set
    End Property
    Public Property Descuento() As Decimal
        Get
            Return _descuento
        End Get

        Set(ByVal Value As Decimal)
            _descuento = Value
        End Set
    End Property
    Public Property SubTotal() As Decimal
        Get
            Return _subtotal
        End Get

        Set(ByVal Value As Decimal)
            _subtotal = Value
        End Set
    End Property
    Public Property Iva() As Decimal
        Get
            Return _iva
        End Get

        Set(ByVal Value As Decimal)
            _iva = Value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _total
        End Get

        Set(ByVal Value As Decimal)
            _total = Value
        End Set
    End Property
    Public Property MarcadoLojack() As String
        Get
            Return _marcado_lojack
        End Get

        Set(ByVal Value As String)
            _marcado_lojack = Value
        End Set
    End Property
    Public Property UsuarioProcesoId() As Decimal
        Get
            Return _usuario_proceso_id
        End Get

        Set(ByVal Value As Decimal)
            _usuario_proceso_id = Value
        End Set
    End Property
    Public Property FechaProceso() As Date
        Get
            Return _fecha_proceso
        End Get

        Set(ByVal Value As Date)
            _fecha_proceso = Value
        End Set
    End Property
    Public Property Item() As Int32
        Get
            Return _item
        End Get
        Set(ByVal value As Int32)
            _item = value
        End Set
    End Property
    Public Property Transaccion() As String
        Get
            Return _transaccion
        End Get
        Set(ByVal value As String)
            _transaccion = value
        End Set
    End Property
    Public Property EsDebito() As String
        Get
            Return _es_debito
        End Get

        Set(ByVal Value As String)
            _es_debito = Value
        End Set
    End Property
    Public Property Producto_Debito() As String
        Get
            Return _producto_debito
        End Get

        Set(ByVal Value As String)
            _producto_debito = Value
        End Set
    End Property
    Public Property Fecha_Ini_Debito() As String
        Get
            Return _fechaini_debito
        End Get

        Set(ByVal Value As String)
            _fechaini_debito = Value
        End Set
    End Property
    Public Property Fecha_Fin_Debito() As String
        Get
            Return _fechafin_debito
        End Get

        Set(ByVal Value As String)
            _fechafin_debito = Value
        End Set
    End Property
    Public Property Ejecutiva() As String
        Get
            Return _ejecutiva
        End Get
        Set(ByVal value As String)
            _ejecutiva = value
        End Set
    End Property

#End Region

End Class