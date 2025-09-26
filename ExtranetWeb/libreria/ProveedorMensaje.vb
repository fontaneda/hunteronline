Imports Telerik.Web.UI

''' <summary>
''' AUTOR: RONALD OCHOA
''' COMENTARIO: PROVEEDOR DE MENSAJES DEL SISTEMA
''' </summary>
''' <remarks></remarks>
Public Class ProveedorMensaje


#Region "Constantes"

    ''' <summary>
    ''' Enumerador para el estilo del mensaje
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum MessageStyle
        AvisoImportante
        OperacionExitosa
        OperacionInvalida
    End Enum


   
    'Private Const TitleMessageSystem As String = "Mensaje del Sistema"
    'Private Const TitleResultConsults As String = "Resultados de Consulta"
    Private Const TitleSuccessfulOperation As String = "Operación Exitosa"
    Private Const TitleAvisoImportante As String = "Aviso Importante"
    'Private Const TitleConfirmationAction As String = "Confirmación de Operación"
    'Private Const TitleConfirmationEliminaTion As String = "Confirmación de Eliminación"
    'Private Const TitleValidationError As String = "Mensaje del Sistema"
    'Private Const TitleInesperateError As String = "Mensaje del Sistema"
    'Private Const TitleFatalError As String = "Mensaje del Sistema"

    ''' <summary>
    ''' Constantes utilizadas para los Iconos de los mensajes
    ''' </summary>
    ''' <remarks></remarks>
    Private Const IconMessageSystem As String = "info"
    'Private Const IconResultConsults As String = "info"
    Private Const IconSuccessfulOperation As String = "ok"
    'Private Const IconInvalidOperation As String = "warning"
    'Private Const IconConfirmationAction As String = "info"
    'Private Const IconConfirmationEliminaTion As String = "icon"
    'Private Const IconValidationError As String = "icon"
    'Private Const IconInesperateError As String = "deny"
    'Private Const IconFatalError As String = "deny"

#End Region


    Public Shared Function ShowMessage(ByVal control As RadNotification, ByVal texto As String, ByVal tipoMensaje As MessageStyle) As Boolean
        ShowMessage = True
        'Dim titulo As String = String.Empty
        'Dim icono As String = String.Empty
        Select Case tipoMensaje
            Case MessageStyle.OperacionExitosa
                control.Title = TitleSuccessfulOperation
                control.TitleIcon = IconSuccessfulOperation
                control.ContentIcon = IconSuccessfulOperation
                control.ShowSound = "../sonidos/notificar.wav"
            Case MessageStyle.OperacionInvalida
                control.Title = TitleAvisoImportante
                control.TitleIcon = IconMessageSystem
                control.ContentIcon = IconMessageSystem
                control.ShowSound = "../sonidos/error.wav"
            Case MessageStyle.AvisoImportante
                control.Title = TitleAvisoImportante
                control.TitleIcon = IconMessageSystem
                control.ContentIcon = IconMessageSystem
                control.ShowSound = "../sonidos/error.wav"
            Case Else
                control.Title = TitleSuccessfulOperation
                control.TitleIcon = IconSuccessfulOperation
                control.ContentIcon = IconSuccessfulOperation
                control.ShowSound = "../sonidos/notificar.wav"
        End Select
        Control.Text = Texto
        Control.Show()
    End Function


    Public Shared Function ShowMessage(ByVal control As RadNotification, ByVal texto As String, ByVal tipoMensaje As MessageStyle, ByVal autoCloseDelay As Integer) As Boolean
        ShowMessage = True
        control.AutoCloseDelay = autoCloseDelay
        ShowMessage(control, texto, tipoMensaje)
    End Function

End Class