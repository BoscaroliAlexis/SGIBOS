Public Class Inventario
    Private Sub btnGenerarReporteInv_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteInv.Click
        Reportes.StartPosition = FormStartPosition.CenterScreen
        Reportes.Show()
    End Sub

    Private Sub btnAñadirInv_Click(sender As Object, e As EventArgs) Handles btnAñadirInv.Click
        NuevoProducto.StartPosition = FormStartPosition.CenterScreen
        NuevoProducto.Show()
    End Sub
End Class