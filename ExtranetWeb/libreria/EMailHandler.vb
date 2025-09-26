Imports System
'Imports System.Web
'Imports System.Net
'Imports System.Net.NetworkInformation
Imports System.Net.Mail

Public Class EMailHandler

    Public Shared Sub EMailGeneracionOrdenPago(ByVal asunto As String, ByVal mensaje As String, ByVal ordenId As String, ByVal iP As String)
        Try
            Dim mensajeBody As String = "ORDEN: " & ordenId.ToString() & Chr(13) & "IP: " & iP & Chr(13) & "FECHA: " & DateTime.Now.ToString("HH:mm:ss.ffffff") & Chr(13) & mensaje
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("ErrorMailAddress").ToString()
            Dim mailTo As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, String.Empty, String.Empty, String.Empty, asunto, mensajeBody, False)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailProcesoPago(ByVal mensaje As String, ByVal usuario As String, ByVal iP As String, ByVal pC As String)
        Try
            Dim asunto As String = "Mensaje Pago HunterOnline"
            Dim mensajeBody As String = "Usuario Conectado:" & usuario & Chr(13) & "IP: " & iP & Chr(13) & "PC: " & pC & Chr(13) & "FECHA: " & DateTime.Now.ToString("HH:mm:ss.ffffff") & Chr(13) & mensaje
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("ErrorMailAddress").ToString()
            Dim mailTo As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, String.Empty, String.Empty, String.Empty, asunto, mensajeBody, False)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailConfirmacionPagoCliente(ByVal mensaje As String, ByVal mailTo As String, ByVal proceso As String)
        Try
            Dim asunto As String
            If proceso = "100" Then
                asunto = "Confirmación de Pago Online realizado desde el aplicativo HunterOnline"
            ElseIf proceso = "300" Then
                asunto = "Transacción pendiente de Pago Online realizado desde el aplicativo HunterOnline"
            Else
                asunto = "Cancelación/Reverso de Pago Online realizado desde el aplicativo HunterOnline"
            End If
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString()
            Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
            'Dim MailToBcc As String = ConfigurationManager.AppSettings.Get("PagoConfirmacionBCC").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, mailToBcc, String.Empty, String.Empty, asunto, mensaje, True)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailLink(ByVal mensaje As String, ByVal mailTo As String)
        Try
            Dim asunto As String = "Link de pago - Hunter Online"

            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString()
            Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, mailToBcc, String.Empty, String.Empty, asunto, mensaje, True)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailGeneracionOrdenServicio(ByVal mensaje As String, ByVal ordenId As String)
        Try
            Dim asunto As String = "Generación de O/S con ORDEN: " & ordenId.ToString()
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("ErrorMailAddress").ToString()
            Dim mailTo As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, String.Empty, String.Empty, String.Empty, asunto, mensaje, False)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailProductoError(ByVal mensaje As String, ByVal usuario As String, ByVal iP As String, ByVal pC As String)
        Try
            Dim asunto As String = "Error en Consulta de Productos a Renovar"
            Dim mensajeBody As String = "Usuario Conectado:" & usuario & Chr(13) & "IP: " & iP & Chr(13) & "PC: " & pC & Chr(13) & "FECHA: " & DateTime.Now.ToString("HH:mm:ss.ffffff") & Chr(13) & mensaje
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("ErrorMailAddress").ToString()
            Dim mailTo As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, String.Empty, String.Empty, String.Empty, asunto, mensajeBody, False)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailActivacionVehiculo(ByVal mensaje As String, ByVal ciudad As String)
        Try
            Dim asunto As String = "Actualización de Datos de Vehículos"
            If ciudad <> "" Then
                asunto = ciudad + ": " + asunto
            End If
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString()
            Dim mailTo As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, String.Empty, String.Empty, String.Empty, asunto, mensaje, True)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EMailModificacion(ByVal mensaje As String, ByVal titulo As String, ByVal mail As String)
        Try
            Dim asunto As String = titulo
            Dim smptCliente As String = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
            Dim mailAddress As String = ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString()
            'Dim MailTo As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            Dim mailTo As String = mail
            'Dim MailTo As String = "galvarado@carsegsa.com;rochoa@carsegsa.com"
            'Dim MailToBcc As String = ConfigurationManager.AppSettings.Get("ErrorMailTo").ToString()
            EMailHandler.EnviarEMail(smptCliente, mailAddress, mailTo, String.Empty, String.Empty, String.Empty, String.Empty, asunto, mensaje, True)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub EnviarEMail(ByVal smptCliente As String, ByVal mailAddress As String, ByVal mailTo As String, _
                                  ByVal mailToCC As String, ByVal mailToBcc As String, ByVal userName As String, _
                                  ByVal password As String, ByVal asunto As String, ByVal mensaje As String, ByVal isHtml As Boolean)
        Try
            mailTo = mailTo
            Dim mailMessage As New MailMessage()
            Dim mailAddresss As New MailAddress(mailAddress)
            mailMessage.From = mailAddresss
            mailMessage.IsBodyHtml = isHtml
            Dim mailToCollection As [String]() = mailTo.Split(";")
            For Each mailToo As String In mailToCollection
                If EMailHandler.ValidarEMail(mailToo) Then
                    mailMessage.To.Add(mailToo)
                End If
            Next
            Dim mailToCCCollection As [String]() = mailToCC.Split(";")
            For Each mailTooCC As String In mailToCCCollection
                If EMailHandler.ValidarEMail(mailTooCC) Then
                    mailMessage.CC.Add(mailTooCC)
                End If
            Next
            Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
            For Each mailTooBcc As String In mailToBccCollection
                If EMailHandler.ValidarEMail(mailTooBcc) Then
                    mailMessage.Bcc.Add(mailTooBcc)
                End If
            Next
            mailMessage.Subject = asunto
            mailMessage.Body = mensaje
            mailMessage.Priority = MailPriority.High
            Dim smtpClient As New SmtpClient(smptCliente)
            If Not String.IsNullOrEmpty(userName) Then
                smtpClient.Credentials = New System.Net.NetworkCredential(userName, password)
            End If
            smtpClient.Send(mailMessage)
            mailMessage.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function ValidarEMail(ByVal email As String) As Boolean
        Dim expresion As String = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        If Regex.IsMatch(email, expresion) Then
            If Regex.Replace(email, expresion, [String].Empty).Length = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

End Class