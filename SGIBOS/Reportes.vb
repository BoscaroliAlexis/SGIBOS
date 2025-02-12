Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Reportes
    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTipo.Items.AddRange(New String() {"Inventario", "Ventas", "Clientes", "Proveedores"})
        cmbOrden.Items.AddRange(New String() {"Mayor a menor", "Menor a mayor"})
        cmbPeriodo.Items.AddRange(New String() {"Ultimo mes", "Ultimos 3 meses", "Ultimos 6 meses", "Ultimo año"})

        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOrden.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList


        cmbTipo.SelectedIndex = 0
        cmbOrden.SelectedIndex = 0
        cmbPeriodo.SelectedIndex = 0
    End Sub
End Class