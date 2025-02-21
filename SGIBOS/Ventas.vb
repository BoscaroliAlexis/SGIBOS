Public Class Ventas
    Private Sub btnGenerarReporteVen_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteVen.Click
        Reportes.StartPosition = FormStartPosition.CenterScreen
        Reportes.Show()
    End Sub

    Private Sub btnAñadirVen_Click(sender As Object, e As EventArgs) Handles btnAñadirVen.Click
        NuevoVenta.StartPosition = FormStartPosition.CenterScreen
        NuevoVenta.Show()
    End Sub
End Class