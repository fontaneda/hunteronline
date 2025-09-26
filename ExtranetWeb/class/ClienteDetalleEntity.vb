Imports System

Public Class ClienteDetalleEntity

#Region " Atributtes "
    Private _clienteid As String
    Private _direcciontipo As String
    Private _direccionsectorid As String
    Private _direccionpaisid As String
    Private _direccionprovinciaid As String
    Private _direccionciudadid As String
    Private _direccionparroquiaid As String
    Private _direccion As String
    Private _direccioninterseccion As String
    Private _direccionnumero As String
    Private _telefonotipo As String
    Private _telefono As String
    Private _telefonoextension As String
    Private _parientetipo As String
    Private _parienteapellidopaterno As String
    Private _parienteapellidomaterno As String
    Private _parientefechanacimiento As Date
    Private _parientenombres As String
    Private _parientedireccion As String
    Private _parientetelefono As String
    Private _entidadtipo As String
    Private _entidad As String
    Private _entidadnumero As String
    Private _emailprincipal As String
    Private _emailalerta As String
    Private _telefonocelular As String
#End Region

#Region " Properties "

    Public Property ClienteId() As String
        Get
            Return _clienteid
        End Get

        Set(ByVal Value As String)
            _clienteid = Value
        End Set
    End Property

    Public Property DireccionTipo() As String
        Get
            Return _direcciontipo
        End Get

        Set(ByVal Value As String)
            _direcciontipo = Value
        End Set
    End Property

    Public Property DireccionSectorId() As String
        Get
            Return _direccionsectorid
        End Get

        Set(ByVal Value As String)
            _direccionsectorid = Value
        End Set
    End Property

    Public Property DireccionPaisId() As String
        Get
            Return _direccionpaisid
        End Get

        Set(ByVal Value As String)
            _direccionpaisid = Value
        End Set
    End Property

    Public Property DireccionProvinciaId() As String
        Get
            Return _direccionprovinciaid
        End Get

        Set(ByVal Value As String)
            _direccionprovinciaid = Value
        End Set
    End Property

    Public Property DireccionCiudadId() As String
        Get
            Return _direccionciudadid
        End Get

        Set(ByVal Value As String)
            _direccionciudadid = Value
        End Set
    End Property

    Public Property DireccionParroquiaId() As String
        Get
            Return _direccionparroquiaid
        End Get

        Set(ByVal Value As String)
            _direccionparroquiaid = Value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _direccion
        End Get

        Set(ByVal Value As String)
            _direccion = Value
        End Set
    End Property

    Public Property DireccionInterseccion() As String
        Get
            Return _direccioninterseccion
        End Get

        Set(ByVal Value As String)
            _direccioninterseccion = Value
        End Set
    End Property

    Public Property DireccionNumero() As String
        Get
            Return _direccionnumero
        End Get

        Set(ByVal Value As String)
            _direccionnumero = Value
        End Set
    End Property

    Public Property TelefonoTipo() As String
        Get
            Return _telefonotipo
        End Get

        Set(ByVal Value As String)
            _telefonotipo = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _telefono
        End Get

        Set(ByVal Value As String)
            _telefono = Value
        End Set
    End Property

    Public Property TelefonoExtension() As String
        Get
            Return _telefonoextension
        End Get

        Set(ByVal Value As String)
            _telefonoextension = Value
        End Set
    End Property

    Public Property ParienteTipo() As String
        Get
            Return _parientetipo
        End Get

        Set(ByVal Value As String)
            _parientetipo = Value
        End Set
    End Property

    Public Property ParienteApellidoPaterno() As String
        Get
            Return _parienteapellidopaterno
        End Get

        Set(ByVal Value As String)
            _parienteapellidopaterno = Value
        End Set
    End Property

    Public Property ParienteFechaNacimiento() As String
        Get
            Return _parientefechanacimiento
        End Get

        Set(ByVal Value As String)
            _parientefechanacimiento = Value
        End Set
    End Property

    Public Property ParienteApellidoMaterno() As String
        Get
            Return _parienteapellidomaterno
        End Get

        Set(ByVal Value As String)
            _parienteapellidomaterno = Value
        End Set
    End Property

    Public Property ParienteNombres() As String
        Get
            Return _parientenombres
        End Get

        Set(ByVal Value As String)
            _parientenombres = Value
        End Set
    End Property

    Public Property ParienteDireccion() As String
        Get
            Return _parientedireccion
        End Get

        Set(ByVal Value As String)
            _parientedireccion = Value
        End Set
    End Property

    Public Property ParienteTelefono() As String
        Get
            Return _parientetelefono
        End Get

        Set(ByVal Value As String)
            _parientetelefono = Value
        End Set
    End Property

    Public Property EntidadTipo() As String
        Get
            Return _entidadtipo
        End Get
        Set(ByVal value As String)
            _entidadtipo = value
        End Set
    End Property

    Public Property Entidad() As String
        Get
            Return _entidad
        End Get
        Set(ByVal value As String)
            _entidad = value
        End Set
    End Property

    Public Property EntidadNumero() As String
        Get
            Return _entidadnumero
        End Get

        Set(ByVal Value As String)
            _entidadnumero = Value
        End Set
    End Property

    Public Property EmailPrincipal() As String
        Get
            Return _emailprincipal
        End Get

        Set(ByVal Value As String)
            _emailprincipal = Value
        End Set
    End Property

    Public Property EmailAlerta() As String
        Get
            Return _emailalerta
        End Get

        Set(ByVal Value As String)
            _emailalerta = Value
        End Set
    End Property

    Public Property TelefonoCelular() As String
        Get
            Return _telefonocelular
        End Get

        Set(ByVal Value As String)
            _telefonocelular = Value
        End Set
    End Property

#End Region

End Class
