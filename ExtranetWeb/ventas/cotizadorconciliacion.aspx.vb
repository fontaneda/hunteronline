Public Class cotizadorconciliacion

    Inherits System.Web.UI.Page
    Dim rucEmpresa As String = ConfigurationManager.AppSettings.Get("RucEmpresaEnInterDin").ToString()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ControlFecha()
                SetFecha()
                ConsultaInfoCsv()
                ConfigButtonBar(1)
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub ControlFecha()
        Try
            Me.rdpFechaConsulta.MinDate = "1/1/2014"
            Me.rdpFechaConsulta.MaxDate = "31/12/" & Date.Now.Year
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub SetFecha()
        Try
            Me.rdpFechaConsulta.SelectedDate = Date.Now
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Function ObtenerFechaInicio()
        Dim fechaInicio As String = ""
        Dim fechaString As String = ""
        Try
            fechaString = Me.rdpFechaConsulta.SelectedDate.Value.ToString("yyyy/MM/dd")
            fechaInicio = fechaString.Replace("/", "")
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
        Return fechaInicio
    End Function


    Private Sub ConsultaInfoCsv()
        Try
            Dim dtConsultaInfoCsv As DataSet
            dtConsultaInfoCsv = ConciliacionPagoAdapter.ConsultaDataCSVConciliacion(rucEmpresa, ObtenerFechaInicio())
            Me.grdinfoconciliacion.DataSource = dtConsultaInfoCsv
            Me.grdinfoconciliacion.DataBind()
            If dtConsultaInfoCsv.Tables(0).Rows.Count > 0 Then
                ConfigButtonBar(2)
            Else
                rntMensajes.Text = "No existen ordenes de pago registradas en la fecha indicada"
                rntMensajes.Title = "Mensaje de la Aplicación Cotizador Web"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Sub GeneraCsvFinal()
        Try
            Dim dtConsultaInfoCsv As DataSet
            Dim csvfilename As String
            dtConsultaInfoCsv = ConciliacionPagoAdapter.ConsultaDataCSVConciliacion(rucEmpresa, ObtenerFechaInicio())
            If dtConsultaInfoCsv.Tables(0).Rows.Count > 0 Then
                csvfilename = rucEmpresa & "_" & ObtenerFechaInicio() & ".csv"
                Response.ContentType = "Application/x-msexcel"
                Response.AddHeader("content-disposition", "attachment;filename=" & csvfilename)
                Response.Write(ExportToCsvFile(dtConsultaInfoCsv.Tables(0)))
                Response.End()
                HttpContext.Current.ApplicationInstance.CompleteRequest()
            Else
                rntMensajes.Text = "Ocurrió un inconveniente al generar el archivo, comuníquese con el Dtpo. de Sistemas"
                rntMensajes.Title = "Mensaje de la Aplicación Cotizador Web"
                rntMensajes.TitleIcon = "warning"
                rntMensajes.ContentIcon = "warning"
                rntMensajes.ShowSound = "warning"
                rntMensajes.Width = 400
                rntMensajes.Height = 100
                rntMensajes.Show()
            End If
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Private Function ExportToCsvFile(ByVal dtTable As DataTable) As String
        Dim columnMax, columnNow As Integer
        Dim sbldr As New StringBuilder()
        columnMax = dtTable.Columns.Count
        columnNow = 0
        If dtTable.Columns.Count <> 0 Then
            For Each row As DataRow In dtTable.Rows
                For Each column As DataColumn In dtTable.Columns
                    If columnNow = columnMax - 1 Then
                        sbldr.Append(row(column).ToString())
                        columnNow += 1
                    Else
                        sbldr.Append(row(column).ToString() + ","c)
                        columnNow += 1
                    End If
                Next
                columnNow = 0
                sbldr.Append(vbCr & vbLf)
            Next
        End If
        Return sbldr.ToString()
    End Function


    Private Sub ConfigButtonBar(ByVal opcion As Integer)
        Try
            Select Case opcion
                Case 1
                    'Cuando se carga por primera vez la pantalla
                    Me.btnDescargarCsv.Enabled = False
                    Me.btnBuscar.Enabled = True
                    Me.BtnRegresaConsulta.Enabled = True

                Case 2
                    'Cuando se emite información del día seleccionado para emitir un archivo
                    Me.btnDescargarCsv.Enabled = True
                    Me.btnBuscar.Enabled = True
                    Me.BtnRegresaConsulta.Enabled = True
            End Select
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnRegresaConsulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnRegresaConsulta.Click
        Try
            Response.Redirect("inicio.aspx", False)
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBuscar.Click
        Try
            ConsultaInfoCsv()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnDescargarCsv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDescargarCsv.Click
        Try
            GeneraCsvFinal()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class