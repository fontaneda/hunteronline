Imports System.Web.Services
'Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization

' Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebPagoHunterOnline
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function PagoHunterOnline(data As String) As String
        'Dim requestId As String = ""
        Dim referencia As String = ""
        Dim status As String = ""
        Dim estadoOrdenPago As Integer
        status = BusquedaDatosDetalle(data, "status")
        'requestId = BusquedaDatos(data, "requestId")
        referencia = BusquedaDatos(data, "reference")
        If status = "APPROVED" Then
            estadoOrdenPago = 6
        ElseIf status = "OK" Then
            estadoOrdenPago = 6
        Else
            estadoOrdenPago = 5
        End If
        Dim resultObj As Integer = ProcesoActEstOrdenVpos(2, referencia, 2, 1, estadoOrdenPago)
        Dim tabla As New DataTable
        Dim jsonData As String
        tabla.Columns.Add("CODIGO", GetType(Integer))
        tabla.Columns.Add("MENSAJE", GetType(String))
        tabla.Rows.Add(resultObj, "Guardado Exitosamente")
        jsonData = SerializarJson(tabla)
        Return jsonData
    End Function


    Public Shared Function BusquedaDatos(ByVal data As String, ByVal campo As String)
        Dim serializer = New JavaScriptSerializer()
        Dim resultado As Dictionary(Of String, Object) = TryCast(serializer.DeserializeObject(data), Dictionary(Of String, Object))
        Dim id As String = "0"
        If resultado.Values(0).count > 0 Then
            id = resultado(campo)
        End If
        Return id
    End Function


    Public Shared Function BusquedaDatosDetalle(ByVal data As String, ByVal campo As String)
        Dim serializer = New JavaScriptSerializer()
        Dim resultado As Dictionary(Of String, Object) = TryCast(serializer.DeserializeObject(data), Dictionary(Of String, Object))
        Dim id As String = "0"
        If resultado.Values(0).count > 0 Then
            Dim objecto As Object = resultado.Values(0)
            id = objecto(campo)
        End If
        Return id
    End Function


    Public Function SerializarJson(ByVal firstTable As DataTable) As String
        Try
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))
            Dim row As Dictionary(Of String, Object)
            Dim msginicio As String = "{" & """" & "results" & """" & ": " ''[ "
            Dim msgfinal As String = " }" ''" ]}"
            For Each dr As DataRow In firstTable.Rows
                row = New Dictionary(Of String, Object)
                For Each col As DataColumn In firstTable.Columns
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return msginicio & serializer.Serialize(rows).ToString & msgfinal
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Function ProcesoActEstOrdenVpos(ByVal opcion As Integer, ByVal ordensec As Int32, ByVal origen As Integer, ByVal userid As Integer, ByVal estadoid As Integer)
        ProcesoActEstOrdenVpos = 0
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim Tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            Tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "dbo.SP_PROCESO_CREACION_ORDEN_PAGO_DINNER"
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@ORDENSEC", ordensec)
            base.AddParrameter("@ORIGEN", origen)
            base.AddParrameter("@USERID", userid)
            base.AddParrameter("@ESTADOORDEN", estadoid)
            base.EjecutaTransaction(cmd, Tran)
            Tran.Commit()
        Catch ex As Exception
            ProcesoActEstOrdenVpos = -1
            'Captura_Error(ex)
            Tran.Rollback()
            Throw ex
        End Try
    End Function



End Class