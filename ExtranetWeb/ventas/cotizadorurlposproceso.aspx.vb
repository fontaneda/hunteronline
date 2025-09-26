Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports PlugInClient

Public Class cotizadorweburlretorno

    'Inherits System.Web.UI.Page
    'Public pluginr As PlugInClientRecive
    'Public firmaCorrecta As Boolean
    'Dim opcion, valueop As Integer
    'Dim lsdata As String
    'Dim lsdata_div As String()
    'Dim lsdata_value As String = ""
    'Dim str_datos As String()
    'Dim datos_value As String
    'Dim datos_value_final As String = ""
    'Dim str_aut As String()
    'Dim aut_value As String
    'Dim aut_value_final As String = ""
    'Dim str_cre As String()
    'Dim cre_value As String
    'Dim cre_value_final As String = ""
    'Dim str_mes As String()
    'Dim mes_value As String
    'Dim mes_value_final As String = ""
    'Dim str_ttar As String()
    'Dim ttar_value As String
    'Dim ttar_value_final As String = ""
    'Dim str_sub As String()
    'Dim sub_value As String
    'Dim sub_value_final As String = ""
    'Dim str_iva As String()
    'Dim iva_value As String
    'Dim iva_value_final As String = ""
    'Dim str_ice As String()
    'Dim ice_value As String
    'Dim ice_value_final As String = ""
    'Dim str_int As String()
    'Dim int_value As String
    'Dim int_value_final As String = ""
    'Dim str_tot As String()
    'Dim tot_value As String
    'Dim tot_value_final As String = ""
    'Dim str_tNo As String()
    'Dim tNo_value As String
    'Dim tNo_value_final As String = ""
    'Dim str_cDt As String()
    'Dim cDt_value As String
    'Dim cDt_value_final As String = ""
    'Dim str_Tipo As String()
    'Dim Tipo_value As String
    'Dim Tipo_value_final As String = ""
    'Dim valueresponse As String
    'Dim cadena_url_retorno As String = ""
    'Dim value_actestadoorden As Integer
    'Dim subtotal_dec As Decimal
    'Dim iva_dec As Decimal
    'Dim int_dec As Decimal
    'Dim ice_dec As Decimal
    'Dim total_dec As Decimal
    'Dim mes_int As Integer

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ''If Not IsPostBack Then
    'Dim lsdata As [String] = Request.Params.[Get]("xmlReq")
    ''Dim lsdata As [String] = urldata
    'Dim lsdatos As [String]() = lsdata.Split(",")
    'lsdata = lsdatos(0)
    ''Dim llave As [String] = "g0yoaxPT4GQmvKIf7wcCV3Uv1SDgp9n0"
    ''Dim llave As [String] = ConfigurationManager.AppSettings.Get("LlaveSimetrica").ToString()
    'Dim llave As [String] = Libreria.ReadFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyLlaveSimetrica").ToString()))
    ''Dim iv As [String] = ConfigurationManager.AppSettings.Get("Vector").ToString()
    'Dim iv As [String] = Libreria.ReadFile(Server.MapPath(ConfigurationManager.AppSettings.Get("RutaKeyVector").ToString()))
    'Try
    '    lsdata = TripleDESEncryption.decrypt(lsdata, llave, iv)
    '    EMailHandler.EMailProcesoPago("EMAIL 1 ºº POSPROCESO // " & lsdata, Nothing, Session("iphost"), Session("iphost"))
    '    'JCOLOMA    17/02/2014      CODIGO PARA IMPLEMENTAR EN POSPROCESO
    '    lsdata_div = lsdata.Split("&")
    '    For count = 0 To lsdata_div.Length - 1
    '        If count = 0 Then
    '            datos_value = lsdata_div.GetValue(count)
    '            str_datos = datos_value.Split("=")
    '            For count2 = 0 To str_datos.Length - 1
    '                If count2 = 1 Then
    '                    datos_value_final = str_datos.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 1 Then
    '            aut_value = lsdata_div.GetValue(count)
    '            str_aut = aut_value.Split("=")
    '            For count2 = 0 To str_aut.Length - 1
    '                If count2 = 1 Then
    '                    aut_value_final = str_aut.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 2 Then
    '            cre_value = lsdata_div.GetValue(count)
    '            str_cre = cre_value.Split("=")
    '            For count2 = 0 To str_cre.Length - 1
    '                If count2 = 1 Then
    '                    cre_value_final = str_cre.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 3 Then
    '            mes_value = lsdata_div.GetValue(count)
    '            str_mes = mes_value.Split("=")
    '            For count2 = 0 To str_mes.Length - 1
    '                If count2 = 1 Then
    '                    mes_value_final = str_mes.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 4 Then
    '            ttar_value = lsdata_div.GetValue(count)
    '            str_ttar = ttar_value.Split("=")
    '            For count2 = 0 To str_ttar.Length - 1
    '                If count2 = 1 Then
    '                    ttar_value_final = str_ttar.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 5 Then
    '            sub_value = lsdata_div.GetValue(count)
    '            str_sub = sub_value.Split("=")
    '            For count2 = 0 To str_sub.Length - 1
    '                If count2 = 1 Then
    '                    sub_value_final = str_sub.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 6 Then
    '            iva_value = lsdata_div.GetValue(count)
    '            str_iva = iva_value.Split("=")
    '            For count2 = 0 To str_iva.Length - 1
    '                If count2 = 1 Then
    '                    iva_value_final = str_iva.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 7 Then
    '            ice_value = lsdata_div.GetValue(count)
    '            str_ice = ice_value.Split("=")
    '            For count2 = 0 To str_ice.Length - 1
    '                If count2 = 1 Then
    '                    ice_value_final = str_ice.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 8 Then
    '            int_value = lsdata_div.GetValue(count)
    '            str_int = int_value.Split("=")
    '            For count2 = 0 To str_int.Length - 1
    '                If count2 = 1 Then
    '                    int_value_final = str_int.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 9 Then
    '            tot_value = lsdata_div.GetValue(count)
    '            str_tot = tot_value.Split("=")
    '            For count2 = 0 To str_tot.Length - 1
    '                If count2 = 1 Then
    '                    tot_value_final = str_tot.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 10 Then
    '            tNo_value = lsdata_div.GetValue(count)
    '            str_tNo = tNo_value.Split("=")
    '            For count2 = 0 To str_tNo.Length - 1
    '                If count2 = 1 Then
    '                    tNo_value_final = str_tNo.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 11 Then
    '            cDt_value = lsdata_div.GetValue(count)
    '            str_cDt = cDt_value.Split("=")
    '            For count2 = 0 To str_cDt.Length - 1
    '                If count2 = 1 Then
    '                    cDt_value_final = str_cDt.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '        If count = 12 Then
    '            Tipo_value = lsdata_div.GetValue(count)
    '            str_Tipo = Tipo_value.Split("=")
    '            For count2 = 0 To str_Tipo.Length - 1
    '                If count2 = 1 Then
    '                    Tipo_value_final = str_Tipo.GetValue(count2)
    '                End If
    '            Next
    '        End If
    '    Next
    '    EMailHandler.EMailProcesoPago("EMAIL ESPECIAL" & Len(Tipo_value_final) & " // " & "Estado: " & Tipo_value_final, Nothing, Session("iphost"), Session("iphost"))
    '    cadena_url_retorno = datos_value_final & " / " & aut_value_final & " / " & cre_value_final & " / " & mes_value_final & " / " & ttar_value_final & " / " & sub_value_final _
    '                         & " / " & iva_value_final & " / " & ice_value_final & " / " & int_value_final & " / " & tot_value_final & " / " & tNo_value_final _
    '                         & " / " & cDt_value_final & " / " & Tipo_value_final
    '    EMailHandler.EMailProcesoPago("EMAIL 2 ºº POSPROCESO// " & cadena_url_retorno, Nothing, Session("iphost"), Session("iphost"))
    '    mes_int = CType(mes_value_final, Integer)
    '    If mes_int > 1 Then
    '        ice_dec = (CType(ice_value_final, Decimal) / 100)
    '        int_dec = (CType(int_value_final, Decimal) / 100)
    '        total_dec = (CType(tot_value_final, Decimal) / 100)
    '    Else
    '        total_dec = (CType(tot_value_final, Decimal) / 100)
    '    End If
    '    'JCOLOMA        19/02/2014      FUNCIÓN PARA ACTUALIZAR EL REGISTRO DE LA ORDEN DE PAGO ONLINE
    '    opcion = 3
    '    'value_actestadoorden = obj_act_pago_online.ActualizaEstadoPagoOnline(opcion, Tipo_value_final, aut_value_final, tNo_value_final, mes_value_final, ttar_value_final, ice_value_final, _
    '    '                                                                     int_value_final, tot_value_final, cre_value_final, 0)
    '    value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(opcion, Tipo_value_final, aut_value_final, tNo_value_final, mes_value_final, ttar_value_final, ice_dec, _
    '                                                                         int_dec, total_dec, cre_value_final, 0, "", "", "")
    '    EMailHandler.EMailProcesoPago("EMAIL 3 ºº POSPROCESO// " & Tipo_value_final, Nothing, Session("iphost"), Session("iphost"))
    '    'If Tipo_value_final <> "p" Then
    '    If aut_value_final = "0" Then
    '        Response.Write("ESTADO=KO")
    '        EMailHandler.EMailProcesoPago("EMAIL 5 ºº POSPROCESO - ES KO// NO. AUT.:" & aut_value_final & "ESTADO=KO", Nothing, Session("iphost"), Session("iphost"))
    '    Else
    '        Response.Write("ESTADO=OK")
    '        EMailHandler.EMailProcesoPago("EMAIL 4 ºº POSPROCESO - ES OK// NO. AUT.:" & aut_value_final & "ESTADO=OK", Nothing, Session("iphost"), Session("iphost"))
    '    End If
    'Catch ex As Exception
    '    ExceptionHandler.Captura_Error(ex)
    '    opcion = 3
    '    'value_actestadoorden = obj_act_pago_online.ActualizaEstadoPagoOnline(opcion, Tipo_value_final, aut_value_final, tNo_value_final, mes_value_final, ttar_value_final, ice_value_final, _
    '    '                                                                     int_value_final, tot_value_final, cre_value_final, 0)
    '    value_actestadoorden = OrdenPagoAdapter.ActualizaEstadoPagoOnline(opcion, Tipo_value_final, aut_value_final, tNo_value_final, mes_value_final, ttar_value_final, ice_dec, _
    '                                                                         int_dec, total_dec, cre_value_final, 0, "", "", "")
    '    EMailHandler.EMailProcesoPago("EMAIL 6 ºº POSPROCESO// " & Tipo_value_final, Nothing, Session("iphost"), Session("iphost"))
    '    Response.Write("ESTADO=KO")
    'End Try
    ''End If
    'End Sub

End Class