Imports MySql.Data.MySqlClient

Public Class Proveedores

    ' Timer para manejar la búsqueda con retardo (500 ms)
    Private TimerBuscar As New Timer()

    ' Método para cargar los datos de proveedores en el DataGridView
    ' Parámetro opcional "busqueda" para filtrar por nombre
    Public Sub CargarDatos(Optional ByVal busqueda As String = "")
        Try
            Conectar() ' Abrir conexión global (módulo externo)

            Dim consulta As String
            If busqueda = "" Then
                ' Si no hay texto de búsqueda, traer todos los proveedores
                consulta = "SELECT * FROM proveedores WHERE id_proveedor <> 1"
            Else
                ' Si hay búsqueda, filtrar por nombre con LIKE y comodines
                consulta = "SELECT * FROM proveedores WHERE nombre LIKE @busqueda AND id_proveedor <> 1"
            End If

            ' Crear comando SQL con la consulta y la conexión
            Dim comando As New MySqlCommand(consulta, conn)

            ' Si hay búsqueda, añadir el parámetro con el texto para la consulta
            If busqueda <> "" Then
                comando.Parameters.AddWithValue("@busqueda", "%" & busqueda & "%")
            End If

            ' Crear adaptador y tabla para llenar datos
            Dim adaptador As New MySqlDataAdapter(comando)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla) ' Ejecutar consulta y llenar tabla

            ' Asignar tabla al DataGridView para mostrar datos
            dgvProveedores.DataSource = tabla

        Catch ex As Exception
            ' Mostrar error si ocurre algún problema
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Evento del botón para generar reporte de proveedores
    Private Sub btnGenerarReportePro_Click(sender As Object, e As EventArgs) Handles btnGenerarReportePro.Click
        ' Recorrer formularios abiertos para encontrar el formulario Proveedores
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is Proveedores Then
                Dim frmProveedores As Proveedores = CType(frm, Proveedores)

                ' Obtener datos actuales mostrados en el DataGridView como DataTable
                Dim dtProveedores As DataTable = frmProveedores.ObtenerDatosProveedores()

                ' Crear instancia del formulario Reportes y pasar los datos
                Dim frmReportes As New Reportes(Nothing, dtProveedores)
                frmReportes.ShowDialog()
                frmReportes.StartPosition = FormStartPosition.CenterScreen
                Exit For ' Salir del ciclo después de mostrar el reporte
            End If
        Next
    End Sub

    ' Evento para abrir formulario de nuevo proveedor
    Private Sub btnAñadirPro_Click(sender As Object, e As EventArgs) Handles btnAñadirPro.Click
        Dim frmNuevoProveedor As New NuevoProveedor()
        frmNuevoProveedor.Owner = Me ' Establecer propietario (para control modal)
        frmNuevoProveedor.Show()
        frmNuevoProveedor.StartPosition = FormStartPosition.CenterScreen
    End Sub

    ' Evento al cargar el formulario Proveedores
    Private Sub Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me) ' Aplicar tema visual personalizado

        CargarDatos() ' Cargar proveedores sin filtro al iniciar
        dgvProveedores.ContextMenuStrip = cmsActEli4 ' Asignar menú contextual al DataGridView

        dgvProveedores.AllowUserToOrderColumns = True

        ' Configurar Timer para búsqueda diferida
        TimerBuscar.Interval = 500 ' 500 ms de retardo
        TimerBuscar.Enabled = False
        AddHandler TimerBuscar.Tick, AddressOf TimerBuscar_Tick ' Asignar evento Tick
    End Sub

    ' Evento cuando cambia el texto en el cuadro de búsqueda
    Private Sub txtBuscarProveedores_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProveedores.TextChanged
        TimerBuscar.Stop() ' Detener timer si estaba corriendo
        TimerBuscar.Start() ' Iniciar timer para búsqueda diferida
    End Sub

    ' Evento Tick del Timer para realizar la búsqueda después del retardo
    Private Sub TimerBuscar_Tick(sender As Object, e As EventArgs)
        TimerBuscar.Stop() ' Detener timer para que no se dispare más veces
        CargarDatos(txtBuscarProveedores.Text) ' Cargar datos filtrando por texto buscado
    End Sub

    ' Evento para buscar proveedores manualmente al hacer clic en el botón buscar
    Private Sub btnBuscarProveedores_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedores.Click
        CargarDatos(txtBuscarProveedores.Text) ' Cargar datos con filtro
    End Sub

    ' Evento para mostrar menú contextual al hacer clic derecho en el DataGridView
    Private Sub dgvProveeedores_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvProveedores.MouseClick
        If e.Button = MouseButtons.Right Then
            ' Detectar fila donde se hizo clic
            Dim hit As DataGridView.HitTestInfo = dgvProveedores.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 Then
                dgvProveedores.ClearSelection() ' Quitar selección previa
                dgvProveedores.Rows(hit.RowIndex).Selected = True ' Seleccionar fila clickeada
                cmsActEli4.Show(dgvProveedores, e.Location) ' Mostrar menú contextual en la posición
            End If
        End If
    End Sub

    ' Evento para actualizar proveedor seleccionado desde menú contextual
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If dgvProveedores.SelectedRows.Count > 0 Then
            ' Obtener datos de la fila seleccionada
            Dim idProveedor As Integer = dgvProveedores.SelectedRows(0).Cells("id_proveedor").Value
            Dim nombre As String = dgvProveedores.SelectedRows(0).Cells("nombre").Value.ToString()
            Dim contacto As String = dgvProveedores.SelectedRows(0).Cells("contacto").Value.ToString()
            Dim telefono As String = dgvProveedores.SelectedRows(0).Cells("telefono").Value.ToString()
            Dim correo As String = dgvProveedores.SelectedRows(0).Cells("correo").Value.ToString()
            Dim direccion As String = dgvProveedores.SelectedRows(0).Cells("direccion").Value.ToString()

            ' Crear formulario NuevoProveedor para editar
            Dim formulario As New NuevoProveedor()
            formulario.idProveedor = idProveedor
            formulario.txtNombre.Text = nombre
            formulario.txtContacto.Text = contacto
            formulario.txtTelefono.Text = telefono
            formulario.txtCorreo.Text = correo
            formulario.txtDireccion.Text = direccion

            formulario.ShowDialog() ' Mostrar formulario como modal
            CargarDatos() ' Recargar datos tras posible actualización
        Else
            MessageBox.Show("Seleccione un proveedor para actualizar.")
        End If
    End Sub

    ' Evento para eliminar proveedor seleccionado desde menú contextual
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If dgvProveedores.SelectedRows.Count > 0 Then
            Dim idProveedor As Integer = dgvProveedores.SelectedRows(0).Cells("id_proveedor").Value

            Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este proveedor?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    Conectar() ' Abrir conexión

                    ' Primero actualizar productos para que queden "sin proveedor"
                    Dim actualizarProductos As String = "UPDATE Productos SET id_proveedor = 1 WHERE id_proveedor = @idProveedor"
                    Dim cmdActualizar As New MySqlCommand(actualizarProductos, conn)
                    cmdActualizar.Parameters.AddWithValue("@idProveedor", idProveedor)
                    cmdActualizar.ExecuteNonQuery()

                    ' Ahora eliminar el proveedor
                    Dim eliminarProveedor As String = "DELETE FROM Proveedores WHERE id_proveedor = @idProveedor"
                    Dim cmdEliminar As New MySqlCommand(eliminarProveedor, conn)
                    cmdEliminar.Parameters.AddWithValue("@idProveedor", idProveedor)
                    cmdEliminar.ExecuteNonQuery()

                    MessageBox.Show("Proveedor eliminado correctamente.")
                    CargarDatos() ' Recargar datos

                Catch ex As Exception
                    MessageBox.Show("Error al eliminar: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Por favor, seleccione un proveedor para eliminar.")
        End If
    End Sub


    ' Método para obtener los datos actuales del DataGridView en un DataTable
    Public Function ObtenerDatosProveedores() As DataTable
        Dim dt As New DataTable()

        ' Verificar que haya filas en el DataGridView
        If dgvProveedores.Rows.Count > 0 Then
            ' Crear columnas en el DataTable según los encabezados del DataGridView
            For Each col As DataGridViewColumn In dgvProveedores.Columns
                dt.Columns.Add(col.HeaderText)
            Next

            ' Agregar filas de datos al DataTable
            For Each row As DataGridViewRow In dgvProveedores.Rows
                If Not row.IsNewRow Then ' Ignorar la fila nueva para agregar
                    Dim newRow As DataRow = dt.NewRow()
                    For i As Integer = 0 To dgvProveedores.Columns.Count - 1
                        ' Asignar cada celda al DataTable convirtiendo a texto
                        newRow(i) = row.Cells(i).Value?.ToString()
                    Next
                    dt.Rows.Add(newRow)
                End If
            Next
        End If

        Return dt ' Retornar DataTable con los datos actuales
    End Function

End Class
