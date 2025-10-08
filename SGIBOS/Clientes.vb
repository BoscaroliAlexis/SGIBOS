Imports MySql.Data.MySqlClient

Public Class Clientes
    ' Variables globales para comandos, adaptadores y tabla
    Dim comando As MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim tabla As DataTable

    ' Timer para búsqueda diferida mientras se escribe
    Dim TimerBuscar As New Timer()

    ' Carga los datos de la tabla "clientes", opcionalmente filtrando por nombre
    Public Sub CargarDatos(Optional ByVal busqueda As String = "")
        Try
            Conectar() ' Abre la conexión global (conn)

            ' Define la consulta SQL con o sin filtro
            Dim consulta As String
            If busqueda = "" Then
                consulta = "SELECT * FROM clientes"
            Else
                consulta = "SELECT * FROM clientes WHERE nombre LIKE '%" & busqueda & "%'"
            End If

            ' Ejecuta la consulta y carga los datos en el DataGridView
            adaptador = New MySqlDataAdapter(consulta, conn)
            tabla = New DataTable()
            adaptador.Fill(tabla)
            dgvClientes.DataSource = tabla

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Cierra conexión después de la operación
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Sub

    ' Abre el formulario para añadir un nuevo cliente
    Private Sub btnAñadirCli_Click(sender As Object, e As EventArgs) Handles btnAñadirCli.Click
        Dim frmNuevoCliente As New NuevoCliente()
        frmNuevoCliente.Owner = Me
        frmNuevoCliente.StartPosition = FormStartPosition.CenterScreen
        frmNuevoCliente.Show()
    End Sub

    ' Carga inicial del formulario
    Public Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me)
        dgvClientes.AllowUserToOrderColumns = True

        ' Permite que el formulario se ajuste automáticamente al contenido
        Me.AutoSize = True
        Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        ' Carga los datos al iniciar
        CargarDatos()

        ' Asocia el menú contextual al DataGridView
        dgvClientes.ContextMenuStrip = cmsActElim

        ' Configura el temporizador para búsqueda inteligente
        TimerBuscar.Interval = 500 ' milisegundos
        TimerBuscar.Enabled = False
        AddHandler TimerBuscar.Tick, AddressOf TimerBuscar_Tick
    End Sub

    ' Cuando se escribe en el TextBox, reinicia el temporizador
    Private Sub txtBuscarCliente_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarCliente.TextChanged
        TimerBuscar.Stop()
        TimerBuscar.Start()
    End Sub

    ' Al cumplirse el tiempo del temporizador, realiza la búsqueda
    Private Sub TimerBuscar_Tick(sender As Object, e As EventArgs)
        TimerBuscar.Stop()
        CargarDatos(txtBuscarCliente.Text)
    End Sub

    ' Búsqueda manual con el botón
    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        CargarDatos(txtBuscarCliente.Text)
    End Sub

    ' Muestra menú contextual al hacer clic derecho en una fila
    Private Sub dgvClientes_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvClientes.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = dgvClientes.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 Then
                dgvClientes.ClearSelection()
                dgvClientes.Rows(hit.RowIndex).Selected = True
                cmsActElim.Show(dgvClientes, e.Location)
            End If
        End If
    End Sub

    ' Opción de menú contextual para actualizar un cliente
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        If dgvClientes.SelectedRows.Count > 0 Then
            ' Extrae los datos del cliente seleccionado
            Dim idCliente As Integer = dgvClientes.SelectedRows(0).Cells("id_cliente").Value
            Dim nombre As String = dgvClientes.SelectedRows(0).Cells("nombre").Value.ToString()
            Dim telefono As String = dgvClientes.SelectedRows(0).Cells("telefono").Value.ToString()
            Dim correo As String = dgvClientes.SelectedRows(0).Cells("correo").Value.ToString()
            Dim direccion As String = dgvClientes.SelectedRows(0).Cells("direccion").Value.ToString()

            ' Carga los datos en el formulario de edición
            Dim formulario As New NuevoCliente()
            formulario.idCliente = idCliente
            formulario.txtNombre.Text = nombre
            formulario.txtTelefono.Text = telefono
            formulario.txtCorreo.Text = correo
            formulario.txtDireccion.Text = direccion
            formulario.EsActualizar = True

            formulario.ShowDialog()
            CargarDatos()
        Else
            MessageBox.Show("Seleccione un cliente para actualizar.")
        End If
    End Sub

    ' Elimina el cliente seleccionado
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If dgvClientes.SelectedRows.Count > 0 Then
            Dim idCliente As Integer = dgvClientes.SelectedRows(0).Cells("id_cliente").Value

            ' Confirmación del usuario
            Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    Conectar()

                    Dim consulta As String = "DELETE FROM Clientes WHERE id_cliente = @id"
                    comando = New MySqlCommand(consulta, conn)
                    comando.Parameters.AddWithValue("@id", idCliente)
                    comando.ExecuteNonQuery()

                    MessageBox.Show("Cliente eliminado correctamente.")
                    CargarDatos()
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar: " & ex.Message)
                Finally
                    If conn IsNot Nothing Then conn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Por favor, seleccione un cliente para eliminar.")
        End If
    End Sub

    ' Convierte los datos del DataGridView en un DataTable (para usarlo en reportes)
    Public Function ObtenerDatosClientes() As DataTable
        Dim dt As New DataTable()

        If dgvClientes.Rows.Count > 0 Then
            ' Agrega las columnas
            For Each col As DataGridViewColumn In dgvClientes.Columns
                dt.Columns.Add(col.HeaderText)
            Next

            ' Agrega las filas
            For Each row As DataGridViewRow In dgvClientes.Rows
                If Not row.IsNewRow Then
                    Dim newRow As DataRow = dt.NewRow()
                    For i As Integer = 0 To dgvClientes.Columns.Count - 1
                        newRow(i) = row.Cells(i).Value?.ToString()
                    Next
                    dt.Rows.Add(newRow)
                End If
            Next
        End If

        Return dt
    End Function

    ' Botón para generar reportes usando varias tablas
    Private Sub btnGenerarReporteCli_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteCli.Click
        ' Obtiene los datos de cada tabla para pasarlos al formulario de reportes
        Dim dtClientes As DataTable = ObtenerDatosClientes()
        Dim dtProveedores As DataTable = ObtenerDatosProveedores()
        Dim dtProductos As DataTable = ObtenerDatosProductos()
        Dim dtVentas As DataTable = ObtenerDatosVentas()

        ' Crea y muestra el formulario de reportes con los datos
        Dim frmReportes As New Reportes(dtClientes, dtProveedores, dtProductos, dtVentas)
        frmReportes.StartPosition = FormStartPosition.CenterScreen
        frmReportes.ShowDialog()
    End Sub
End Class
