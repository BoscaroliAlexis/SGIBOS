Imports MySql.Data.MySqlClient

Public Class Ventas

    Public EsActualizar As Boolean = False
    Dim adaptador As MySqlDataAdapter
    Dim tabla As DataTable
    Dim TimerBuscarVentas As New Timer()

    Public Sub CargarVentas(Optional filtro As String = "")
        Try
            Conectar()

            Dim query As String = "
            SELECT v.id_venta AS 'ID Venta', v.fecha_venta AS 'Fecha', c.nombre AS 'Cliente', 
                   v.total_venta AS 'Total', v.descuento AS 'Descuento' , v.recargo AS 'Recargo', v.metodo_pago AS 'Método de Pago', u.nombre AS 'Vendedor'
            FROM Ventas v
            INNER JOIN Clientes c ON v.id_cliente = c.id_cliente
            INNER JOIN Usuarios u ON v.id_usuario = u.id_usuario"

            If filtro <> "" Then
                query &= " WHERE c.nombre LIKE @filtro"
            End If

            Dim cmd As New MySqlCommand(query, conn)

            If filtro <> "" Then
                cmd.Parameters.AddWithValue("@filtro", filtro & "%")
            End If

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvVentas.DataSource = dt

            If dgvVentas.Columns.Contains("ID Venta") Then
                Dim linkCol As New DataGridViewLinkColumn()
                linkCol.DataPropertyName = "ID Venta"
                linkCol.HeaderText = "ID Venta"
                linkCol.Name = "ID Venta"
                linkCol.LinkColor = ColorTranslator.FromHtml("#F15BB5")
                linkCol.ActiveLinkColor = ColorTranslator.FromHtml("#F15BB5")

                Dim colIndex As Integer = dgvVentas.Columns("ID Venta").Index
                dgvVentas.Columns.Remove("ID Venta")
                dgvVentas.Columns.Insert(colIndex, linkCol)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar ventas: " & ex.Message)
        End Try
    End Sub

    Private Sub btnGenerarReporteVen_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteVen.Click
        Dim dtClientes As DataTable = ObtenerDatosClientes()
        Dim dtProveedores As DataTable = ObtenerDatosProveedores()
        Dim dtProductos As DataTable = ObtenerDatosProductos()
        Dim dtVentas As DataTable = ObtenerDatosVentas()

        Dim frmReportes As New Reportes(dtClientes, dtProveedores, dtProductos, dtVentas)
        frmReportes.StartPosition = FormStartPosition.CenterScreen
        frmReportes.ShowDialog()
    End Sub

    Private Sub btnAñadirVen_Click(sender As Object, e As EventArgs) Handles btnAñadirVen.Click
        Dim frmNuevoVenta As New NuevoVenta()
        frmNuevoVenta.Owner = Me
        frmNuevoVenta.Show()
        frmNuevoVenta.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me)
        CargarVentas()

        dgvVentas.AllowUserToOrderColumns = True

        ' Temporizador para búsqueda
        TimerBuscarVentas.Interval = 500
        TimerBuscarVentas.Enabled = False
        AddHandler TimerBuscarVentas.Tick, AddressOf TimerBuscarVentas_Tick
    End Sub

    Private Sub TimerBuscarVentas_Tick(sender As Object, e As EventArgs)
        TimerBuscarVentas.Stop()
        CargarVentas(txtBuscarVentas.Text)
    End Sub

    Private Sub txtBuscarVentas_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarVentas.TextChanged
        TimerBuscarVentas.Stop()
        TimerBuscarVentas.Start()
    End Sub

    Private Sub dgvVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentas.CellContentClick
        If dgvVentas.Columns(e.ColumnIndex).Name = "ID Venta" AndAlso e.RowIndex >= 0 Then
            Dim idVenta As Integer = CInt(dgvVentas.Rows(e.RowIndex).Cells("ID Venta").Value)
            Dim frmDetalles As New DetallesVenta(idVenta)
            frmDetalles.Owner = Me
            frmDetalles.ShowDialog()
        End If
    End Sub

    Public Function ObtenerDatosVentas() As DataTable
        Dim dt As New DataTable()

        If dgvVentas.Rows.Count > 0 Then
            For Each col As DataGridViewColumn In dgvVentas.Columns
                dt.Columns.Add(col.HeaderText)
            Next

            For Each row As DataGridViewRow In dgvVentas.Rows
                If Not row.IsNewRow Then
                    Dim newRow As DataRow = dt.NewRow()
                    For i As Integer = 0 To dgvVentas.Columns.Count - 1
                        newRow(i) = row.Cells(i).Value?.ToString()
                    Next
                    dt.Rows.Add(newRow)
                End If
            Next
        End If

        Return dt
    End Function

End Class
