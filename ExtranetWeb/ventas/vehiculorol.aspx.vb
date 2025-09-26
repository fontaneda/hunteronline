Imports System.Drawing
Imports Microsoft.Office.Interop.Excel 'Before you add this refrence to your project you need to install Microsoft Office and find last version of this file.
Imports Microsoft.Office.Interop

Public Class vehiculorol
    Inherits System.Web.UI.Page

#Region "Eventos de la pagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'Session("user") = "0916517956"
            'Session("id_vehiculo") = ""
            'Session("Administrador") = "USR"
            'Session("display_name") = "Felix Alejandro"

            llena_info()
            PintarElementomnu()
            mensajeria_error("", "")
            If Not IsPostBack Then
                If Session("user_id") IsNot Nothing Then
                    Dim dTCstGeneral As New System.Data.DataSet
                    dTCstGeneral = VehiculoAdapter.ConsultaDatosVehiculossinbaja(Session("user_id"))
                    If dTCstGeneral.Tables(0).Rows.Count > 0 Then
                        Rpt_bienes.DataSource = dTCstGeneral
                        Rpt_bienes.DataBind()
                        Rpt_bienes.Visible = True
                    Else
                        Rpt_bienes.DataSource = Nothing
                        Rpt_bienes.DataBind()
                        Rpt_bienes.Visible = False
                        mensajeria_error("error", "No existen vehículos relacionadas")
                    End If
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

    Private Sub btnfiltrar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfiltrar.ServerClick
        Try
            Dim filtro As String = txtfiltrar.Text
            Dim dTCstespecifica As New System.Data.DataSet
            If filtro = "" Then
                ' cuando no ha ingresado ningún dato, va a buscar todos los vehiculos del cliente
                dTCstespecifica = VehiculoAdapter.ConsultaDatosVehiculosEspecifico(Session("user_id"), "")
            Else
                'cuando ha ingresado algun dato, va a buscar los vehiculos que concuerden con el filtro ingresado
                dTCstespecifica = VehiculoAdapter.ConsultaDatosVehiculosEspecifico(Session("user_id"), filtro)
            End If
            If dTCstespecifica.Tables(0).Rows.Count > 0 Then
                'Session("DTTransaccion") = dTCstespecifica
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

    Protected Sub clk_rpt_item_tur(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)
        Dim lblchasis As System.Web.UI.WebControls.Label = CType(item.FindControl("lblchasisveh"), System.Web.UI.WebControls.Label)
        Dim codigo As String = VehiculoAdapter.ConsultaCodigoVehiculo(lblchasis.Text)
        Session("id_vehiculo") = codigo
        Page.Response.Redirect("./vehiculoTurnorol.aspx")
    End Sub

    Private Sub btnexportar_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexportar.ServerClick
        Try
            'declaracion de variables
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            Dim oExcel As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add(Type.Missing)
            oSheet = oBook.Worksheets(1)
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            'Obtener bienes
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = VehiculoAdapter.ConsultaDatosVehiculossinbaja(Session("user_id"))

            'Exportar los nombres de columnas
            For Each dc In dTCstGeneral.Tables(0).Columns
                colIndex = colIndex + 1
                oSheet.Cells(1, colIndex) = dc.ColumnName
            Next

            'Exportar las filas
            For Each dr In dTCstGeneral.Tables(0).Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dTCstGeneral.Tables(0).Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next

            Dim ruta As String = "\\colossus\DOCUMENTOS\BIENES\"
            Dim nombre As String = "bienes_" & Session("user_id") & "_" & Date.Now.Hour & Date.Now.Minute & Date.Now.Second
            Dim extension As String = ".xls"
            oBook.SaveAs(ruta & nombre & extension)

            'Liberar objetos
            ReleaseObject(oSheet)
            oBook.Close(False, Type.Missing, Type.Missing)
            ReleaseObject(oBook)
            oExcel.Quit()
            ReleaseObject(oExcel)

            'Descargar documento
            If (System.IO.File.Exists(ruta & nombre & extension)) Then
                Response.Clear()
                Response.ContentType = "Application/Xls"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" & nombre & extension)
                Response.WriteFile(ruta & nombre & extension)
                Response.Flush()
                Response.Close()
                System.IO.File.Delete(ruta & nombre & extension)
            End If

            'Mensaje
            btnexportar.Disabled = True
            mensajeria_error("informacion", "su documento se descargó con éxito")
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Procedimientos"

    Private Sub mensajeria_error(ByVal tipo As String, ByVal mensaje As String)
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

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub salida()
        Try
            If Session("Administrador") <> "ADM" And Session("Administrador") <> "USR" And Session("Administrador") <> "MOD" Then
                FormularioAdapter.RegistroLog(18, Session("user_id"), 7)
            End If
            If Session("Administrador") = "USR" Or Session("Administrador") = "ADM" Or Session("Administrador") = "MOD" Or Session("Administrador") = "APV" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("LoginSoporte.aspx", False)
            ElseIf Session("Administrador") = "CON" Then
                Session.Clear()
                Session.Abandon()
                Response.Redirect("login.aspx", False)
            Else
                Session.Clear()
                Session.Abandon()
                Response.Redirect("login.aspx", False)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

#End Region

#Region "Propiedades Texto del Masterform"

    Public Sub PintarElementomnu()
        lielement02.Attributes.Add("class", "")
        licellelement02.Attributes.Add("class", "")
        h1titulomaster.Attributes.Add("class", "")
        sectiontitulomaster.Attributes.Add("class", "")
        lielement02.Attributes.Add("class", "current-option bienes-option")
        licellelement02.Attributes.Add("class", "current-option bienes-option")
        h1titulomaster.Attributes.Add("class", "mis-bienes")
        sectiontitulomaster.Attributes.Add("class", "title-content orange-border")
        lblcantidadmaster.Text = "0"
        lbltotalmaster.Text = "0"
        lbltitulomaster.Text = ""
        lbltitulomaster.Text = "Bienes Protegidos"
    End Sub

    Public Sub log_autitoria(ByVal pantalla As String)
        If Session("Administrador") = "ADM" Then
            FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), "ADMIN", pantalla, Session("iphost"))
        ElseIf Session("Administrador") = "USR" Or Session("Administrador") = "UNA" Then
            FormularioAdapter.RegistroLogFormulario(103, Session("user_id"), Session("usuario"), pantalla, Session("iphost"))
        Else
            FormularioAdapter.RegistroLogFormulario(103, Session.Item("user"), "LOAD", pantalla, Session("iphost"))
        End If
    End Sub

    Private Sub llena_info()
        Dim dTCstFactura As New System.Data.DataSet
        dTCstFactura = RenovacionAdapter.ConsultaDatosCliente(Session("user_id"))
        If dTCstFactura.Tables(0).Rows.Count > 0 Then
            lblnombresmaster.Text = Session("display_name")
            lblemailmaster.Text = dTCstFactura.Tables(0).Rows(0)("NOMBRE_SOPORTE")
            'lblcelularmaster.Text = dTCstFactura.Tables(0).Rows(0)("CELULAR")
        End If
    End Sub

    Private Sub btnsalirweb_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsalirweb.ServerClick
        salida()
    End Sub

    Private Sub hrefsalir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrefsalir.ServerClick
        salida()
    End Sub

#End Region

End Class