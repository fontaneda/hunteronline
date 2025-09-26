Imports System

Public Class ClienteEntity

#Region " Atributtes "
    Private _clienteid As String
    Private _clientetipoidentificacion As String
    Private _clientefechanacimiento As Date
    Private _clienteapellidopadre As String
    Private _clienteapellidomadre As String
    Private _clientenombreprimero As String
    Private _clientenombresegundo As String
    Private _clientetipo As String
    Private _clienteactividad As String
    Private _clienteprofesion As String
    Private _clienteestadocivil As String
    Private _clientesexo As String
    Private _cliente_detalle_entity_collection As ClienteDetalleEntityCollection
#End Region

#Region " Properties "

    Public Property ClienteId() As String
        Get
            Return _clienteid
        End Get
        Set(ByVal value As String)
            _clienteid = value
        End Set
    End Property

    Public Property ClienteTipoIdentificacion() As String
        Get
            Return _clientetipoidentificacion
        End Get
        Set(ByVal value As String)
            _clientetipoidentificacion = value
        End Set
    End Property

    Public Property ClienteNacimiento() As Date
        Get
            Return _clientefechanacimiento
        End Get
        Set(ByVal value As Date)
            _clientefechanacimiento = value
        End Set
    End Property

    Public Property ClienteApellidoPadre() As String
        Get
            Return _clienteapellidopadre
        End Get
        Set(ByVal value As String)
            _clienteapellidopadre = value
        End Set
    End Property

    Public Property ClienteApellidoMadre() As String
        Get
            Return _clienteapellidomadre
        End Get
        Set(ByVal value As String)
            _clienteapellidomadre = value
        End Set
    End Property

    Public Property ClienteNombrePrimero() As String
        Get
            Return _clientenombreprimero
        End Get
        Set(ByVal value As String)
            _clientenombreprimero = value
        End Set
    End Property

    Public Property ClienteNombreSegundo() As String
        Get
            Return _clientenombresegundo
        End Get
        Set(ByVal value As String)
            _clientenombresegundo = value
        End Set
    End Property

    Public Property ClienteTipo() As String
        Get
            Return _clientetipo
        End Get
        Set(ByVal value As String)
            _clientetipo = value
        End Set
    End Property

    Public Property ClienteActividad() As String
        Get
            Return _clienteactividad
        End Get
        Set(ByVal value As String)
            _clienteactividad = value
        End Set
    End Property

    Public Property ClienteProfesion() As String
        Get
            Return _clienteprofesion
        End Get
        Set(ByVal value As String)
            _clienteprofesion = value
        End Set
    End Property

    Public Property ClienteEstadocivil() As String
        Get
            Return _clienteestadocivil
        End Get
        Set(ByVal value As String)
            _clienteestadocivil = value
        End Set
    End Property

    Public Property ClienteSexo() As String
        Get
            Return _clientesexo
        End Get
        Set(ByVal value As String)
            _clientesexo = value
        End Set
    End Property

    Public Property ClienteDetalleEntityCollection() As ClienteDetalleEntityCollection
        Get
            Return _cliente_detalle_entity_collection
        End Get
        Set(ByVal value As ClienteDetalleEntityCollection)
            _cliente_detalle_entity_collection = value
        End Set
    End Property

#End Region

End Class
