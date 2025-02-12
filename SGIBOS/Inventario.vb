Public Class Inventario
    Private Sub btnGenerarReporteInv_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteInv.Click
        Reportes.StartPosition = FormStartPosition.CenterScreen
        Reportes.Show()
    End Sub
End Class