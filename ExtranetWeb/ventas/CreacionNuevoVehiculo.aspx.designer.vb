'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class CreacionNuevoVehiculo

    '''<summary>
    '''Control Form1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Form1 As Global.System.Web.UI.HtmlControls.HtmlForm

    '''<summary>
    '''Control dvdmensajes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dvdmensajes As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control lblmensajeerror.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblmensajeerror As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control secciondatospersonales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents secciondatospersonales As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control btngrabardatos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btngrabardatos As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control btncancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btncancelar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control lblveh_codigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblveh_codigo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txtveh_motor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtveh_motor As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtveh_chasis.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtveh_chasis As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtveh_placa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtveh_placa As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control cmbveh_anio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_anio As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_color.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_color As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control chkveh_airesi.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chkveh_airesi As Global.System.Web.UI.WebControls.RadioButton

    '''<summary>
    '''Control chkveh_aireno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chkveh_aireno As Global.System.Web.UI.WebControls.RadioButton

    '''<summary>
    '''Control cmbveh_aseguradora.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_aseguradora As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_financiera.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_financiera As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_concesionario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_concesionario As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_marca.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_marca As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_modelo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_modelo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_tipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_tipo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_version.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_version As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_puertas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_puertas As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_transmision.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_transmision As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_traccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_traccion As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_cilindraje.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_cilindraje As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_combustible.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_combustible As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cmbveh_cabina.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbveh_cabina As Global.System.Web.UI.WebControls.DropDownList
End Class
