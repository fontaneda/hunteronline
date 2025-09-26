Imports System.Drawing
'Imports Microsoft.Office.Interop.Excel 'Before you add this refrence to your project you need to install Microsoft Office and find last version of this file.
'Imports Microsoft.Office.Interop

Public Class vehiculo
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            metodos_master("Bienes protegidos", 2, "Bienes")
            mensajeria_error("", "")
            If Not IsPostBack Then
                If Session("user") IsNot Nothing And Session("user_netsuite") IsNot Nothing Then
                    CargaDatos("")
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Eventos de los controles"

    Private Sub btnfiltrar_ServerClick(sender As Object, e As System.EventArgs) Handles btnfiltrar.ServerClick
        Try
            Dim filtro As String = txtfiltrar.Text
            Dim dTCstespecifica As New System.Data.DataSet
            If filtro = "" Then
                CargaDatos("")
            Else
                CargaDatos(filtro)
            End If
            If dTCstespecifica.Tables(0).Rows.Count > 0 Then
                Rpt_bienes.DataSource = dTCstespecifica
                Rpt_bienes.DataBind()
            Else
                Rpt_bienes.DataSource = Nothing
                Rpt_bienes.DataBind()
                mensajeria_error("error", "No existen registros relacionados")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

    Protected Sub clk_rpt_item_det(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
        Session("id_vehiculo") = lblvehiculo.Text
        Page.Response.Redirect("./vehiculoespecifico.aspx")
    End Sub

    Protected Sub clk_rpt_item_chk(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
        Session("id_vehiculo") = lblvehiculo.Text
        Page.Response.Redirect("./vehiculochequeo.aspx")
    End Sub

    Protected Sub clk_rpt_item_tur(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
        Session("id_vehiculo") = lblvehiculo.Text
        Page.Response.Redirect("./vehiculoTurno.aspx")
    End Sub

    Private Sub btnexportar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexportar.ServerClick
        '    Try
        '        'declaracion de variables
        '        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
        '        Dim oExcel As Excel.Application
        '        Dim oBook As Excel.Workbook
        '        Dim oSheet As Excel.Worksheet
        '        oExcel = CreateObject("Excel.Application")
        '        oBook = oExcel.Workbooks.Add(Type.Missing)
        '        oSheet = oBook.Worksheets(1)
        '        Dim misValue As Object = System.Reflection.Missing.Value
        '        Dim i As Integer
        '        Dim j As Integer
        '        Dim dc As System.Data.DataColumn
        '        Dim dr As System.Data.DataRow
        '        Dim colIndex As Integer = 0
        '        Dim rowIndex As Integer = 0

        '        'Obtener bienes
        '        Dim dTCstGeneral As New System.Data.DataSet
        '        dTCstGeneral = VehiculoAdapter.ConsultaDatosVehiculossinbaja(Session.Item("user"))

        '        'Exportar los nombres de columnas
        '        For Each dc In dTCstGeneral.Tables(0).Columns
        '            colIndex = colIndex + 1
        '            oSheet.Cells(1, colIndex) = dc.ColumnName
        '        Next

        '        'Exportar las filas
        '        For Each dr In dTCstGeneral.Tables(0).Rows
        '            rowIndex = rowIndex + 1
        '            colIndex = 0
        '            For Each dc In dTCstGeneral.Tables(0).Columns
        '                colIndex = colIndex + 1
        '                oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
        '            Next
        '        Next

        '        Dim ruta As String = "\\colossus\DOCUMENTOS\BIENES\"
        '        Dim nombre As String = "bienes_" & Session("user") & "_" & Date.Now.Hour & Date.Now.Minute & Date.Now.Second
        '        Dim extension As String = ".xls"
        '        oBook.SaveAs(ruta & nombre & extension)

        '        'Liberar objetos
        '        ReleaseObject(oSheet)
        '        oBook.Close(False, Type.Missing, Type.Missing)
        '        ReleaseObject(oBook)
        '        oExcel.Quit()
        '        ReleaseObject(oExcel)

        '        'Descargar documento
        '        If (System.IO.File.Exists(ruta & nombre & extension)) Then
        '            Response.Clear()
        '            Response.ContentType = "Application/Xls"
        '            Response.AppendHeader("Content-Disposition", "attachment; filename=" & nombre & extension)
        '            Response.WriteFile(ruta & nombre & extension)
        '            Response.Flush()
        '            Response.Close()
        '            System.IO.File.Delete(ruta & nombre & extension)
        '        End If

        '        'Mensaje
        '        btnexportar.Disabled = True
        '        mensajeria_error("informacion", "su documento se descargó con éxito")
        '    Catch ex As Exception

        '    End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub mensajeria_error(tipo As String, mensaje As String)
        lblmensajeerror.InnerText = "Estimado Cliente, " & mensaje
        dvdmensajes.Attributes.Add("class", "")
        If tipo = "error" Then
            dvdmensajes.Attributes.Add("class", "messages error")
            dvdmensajes.Visible = True
        ElseIf tipo = "alerta" Then
            dvdmensajes.Attributes.Add("class", "messages alert")
            dvdmensajes.Visible = True
        ElseIf tipo = "informacion" Then
            dvdmensajes.Attributes.Add("class", "messages sucess")
            dvdmensajes.Visible = True
        ElseIf tipo = "" Then
            dvdmensajes.Visible = False
        End If
    End Sub

    Private Sub metodos_master(titulo As String, itemmnu As Integer, ventana As String)
        Dim myMasterPage As master = CType(Page.Master, master)
        myMasterPage.tituloMaster = titulo
        myMasterPage.PintarElementomnu(itemmnu)
        myMasterPage.log_autitoria(ventana)
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub CargaDatos(filtro As String)
        Try
            Dim dTDatosVehiculo As DataTable
            Dim id_script As String = ConfigurationManager.AppSettings.Get("NSConsultaVehiculos").ToString()
            Dim parametro As String = ConfigurationManager.AppSettings.Get("NSParamDatosVehiculos").ToString()
            dTDatosVehiculo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", "", "", "", Session("user_netsuite"), "", filtro, ""))
            If dTDatosVehiculo.Rows.Count > 0 Then
                Rpt_bienes.DataSource = dTDatosVehiculo
                Rpt_bienes.DataBind()
                Rpt_bienes.Visible = True
                For Each item As RepeaterItem In Rpt_bienes.Items
                    Dim lblchequeo As Label = CType(item.FindControl("lblultimochequeveh"), Label)
                    Dim lblvehiculo As Label = CType(item.FindControl("lblcodigo"), Label)
                    Dim dTDatosChequeo As DataTable
                    id_script = ConfigurationManager.AppSettings.Get("NSConsultaChequeos").ToString()
                    parametro = ConfigurationManager.AppSettings.Get("NSParamChequeos").ToString()
                    dTDatosChequeo = ClaseConexionNetsuite.ConsultaNS(id_script, String.Format(parametro, "100", lblvehiculo.Text, "", "", "", "", "", "1"))
                    If dTDatosChequeo.Rows.Count > 0 Then
                        dTDatosChequeo.DefaultView.Sort = "FechaOt DESC"
                        lblchequeo.Text = dTDatosChequeo.Rows(0)("FechaOt").ToString
                    Else
                        lblchequeo.Text = "No registra"
                    End If
                Next
            Else
                Rpt_bienes.DataSource = Nothing
                Rpt_bienes.DataBind()
                Rpt_bienes.Visible = False
                mensajeria_error("error", "No existen vehículos relacionados")
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

End Class
