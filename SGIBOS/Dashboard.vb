Public Class Dashboard

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Clientes.StartPosition = FormStartPosition.CenterScreen
        Clientes.Show()
    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Proveedores.StartPosition = FormStartPosition.CenterScreen
        Proveedores.Show()
    End Sub

    Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
        Inventario.StartPosition = FormStartPosition.CenterScreen
        Inventario.Show()
    End Sub

    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Ventas.StartPosition = FormStartPosition.CenterScreen
        Ventas.Show()
    End Sub

    Private Sub btnManualUsuario_Click(sender As Object, e As EventArgs) Handles btnManualUsuario.Click
        ManualUsuario.StartPosition = FormStartPosition.CenterScreen
        ManualUsuario.Show()
    End Sub
End Class
