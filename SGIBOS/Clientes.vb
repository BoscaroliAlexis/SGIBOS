Public Class Clientes
    Private Sub btnGenerarReporteCli_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteCli.Click
        Reportes.StartPosition = FormStartPosition.CenterScreen
        Reportes.Show()
    End Sub

    Private Sub btnAñadirCli_Click(sender As Object, e As EventArgs) Handles btnAñadirCli.Click
        NuevoCliente.StartPosition = FormStartPosition.CenterScreen
        NuevoCliente.Show()
    End Sub
End Class