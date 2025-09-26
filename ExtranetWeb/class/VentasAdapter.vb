Public Class VentasAdapter

    ''' <summary>
    ''' AUTOR: FELIX ONTANEDA
    ''' COMENTARIO: CONSULTA PARA GRID DE VENTAS
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <param name="filtro"></param>
    ''' <param name="opcion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConsultaProductoCliente(ByVal cliente As String, ByVal filtro As String, ByVal opcion As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        'Try
        '    base.AddParrameter("@PROCESO", opcion)
        '    base.AddParrameter("@CLIENTE", cliente)
        '    base.AddParrameter("@FILTROLIKE", filtro)
        '    ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VENTA")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Return ds
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ordenpagoid"></param>
    ''' <remarks></remarks>
    Public Shared Function GeneraOrdenServicio(ByVal ordenpagoid As Decimal, ByVal hora As String, ByVal fecha As Date, ByVal taller As Integer) As Boolean
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        'Try
        '    cmd = New SqlClient.SqlCommand
        '    cnn = base.Connection
        '    cnn.Open()
        '    cmd.CommandTimeout = 1000
        '    cmd.Connection = cnn
        '    tran = cnn.BeginTransaction()
        '    base.ClearParrameter(cmd)
        '    base.ProcedureName = "EXTRANET.EXT_SP_GRABA_ORDEN_SERVICIO"
        '    base.AddParrameter("@PROCESO", "100")
        '    base.AddParrameter("@EMPRESA", "001")
        '    base.AddParrameter("@SUCURSAL", "001")
        '    base.AddParrameter("@ORDENID", ordenpagoid)
        '    base.AddParrameter("@HORA_TURNO", hora)
        '    base.AddParrameter("@FECHA_TURNO", fecha)
        '    base.AddParrameter("@TALLER_TURNO", taller)
        '    base.EjecutaTransaction(cmd, tran)
        '    tran.Commit()
        '    'Generacion de comprobante de facturacion
        '    'GeneraComprobante(ordenpagoid)
        '    Return True
        'Catch ex As Exception
        '    Return False
        '    tran.Rollback()
        '    Throw ex
        'End Try
    End Function

    Public Shared Function GeneraComprobante(ByVal ordenpagoid As Decimal) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        'Try
        '    base.AddParrameter("@ORDENID", ordenpagoid)
        '    base.AddParrameter("@EMPRESA", "001")
        '    base.AddParrameter("@SUCURSAL", "001")
        '    base.AddParrameter("@PROCESO", "100")
        '    ds = base.Consulta("EXTRANET.EXT_SP_GRABA_ORDEN_SERVICIO_COMPROBANTE")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Return ds
    End Function

    Public Shared Function ConsultaDatosVenta(ByVal orden As String, ByVal cliente As String, ByVal opcion As Integer) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        'Try
        '    base.AddParrameter("@PROCESO", opcion)
        '    base.AddParrameter("@CLIENTE", cliente)
        '    base.AddParrameter("@ORDEN_ID", orden)
        '    ds = base.Consulta("EXTRANET.EXT_SP_CONSULTA_VENTA")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Return ds
    End Function

End Class
