' Importa las clases necesarias para trabajar con MySQL
Imports MySql.Data.MySqlClient

' Formulario para gestionar categorías
Public Class Categorias

    ' Método para cargar los datos de las categorías desde la base de datos
    ' Si se pasa un texto de búsqueda, filtra las categorías por nombre
    Private Sub CargarDatos(Optional ByVal busqueda As String = "")
        Try
            ' Abre la conexión a la base de datos
            Conectar()

            ' Consulta base para obtener todas las categorías
            Dim consulta As String = "SELECT * FROM categorias WHERE id_categoria <> 1"

            ' Si hay texto de búsqueda, agrega condición WHERE con LIKE
            If Not String.IsNullOrWhiteSpace(busqueda) Then
                consulta &= " WHERE nombre LIKE @busqueda WHERE id_categoria <> 1 "
            End If

            ' Usa un adaptador para llenar un DataTable con los resultados de la consulta
            Using adaptador As New MySqlDataAdapter(consulta, conn)
                If Not String.IsNullOrWhiteSpace(busqueda) Then
                    adaptador.SelectCommand.Parameters.AddWithValue("@busqueda", "%" & busqueda & "%")
                End If

                Dim tabla As New DataTable()
                adaptador.Fill(tabla)
                dgvCategorias.DataSource = tabla ' Muestra los datos en el DataGridView
            End Using

        Catch ex As Exception
            ' Muestra un mensaje si hay error al cargar datos
            MessageBox.Show("Error al cargar datos: " & ex.Message)
        End Try
    End Sub

    ' Evento del botón para añadir una nueva categoría
    Private Sub btnAñadirCat_Click(sender As Object, e As EventArgs) Handles btnAñadirCat.Click
        ' Abre el formulario para crear una nueva categoría
        Dim form As New NuevaCategoria()
        form.StartPosition = FormStartPosition.CenterScreen
        form.ShowDialog()
        CargarDatos() ' Refresca la grilla después de cerrar el formulario
    End Sub

    ' Evento que se ejecuta al cargar el formulario de Categorías
    Private Sub Categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aplica el tema visual al formulario
        ModuloVisual.AplicarTemaFormulario(Me)
        dgvCategorias.AllowUserToOrderColumns = True
        ' Asocia el menú contextual al DataGridView
        dgvCategorias.ContextMenuStrip = cmsActEli3

        ' Carga todos los datos de la tabla categorías
        CargarDatos()
    End Sub

    ' Evento del botón de búsqueda
    Private Sub btnBuscarCat_Click(sender As Object, e As EventArgs) Handles btnBuscarCat.Click
        ' Llama a CargarDatos pasando el texto ingresado como criterio de búsqueda
        CargarDatos(txtBuscarCat.Text.Trim())
    End Sub

    ' Evento que se ejecuta al hacer clic derecho sobre una celda del DataGridView
    Private Sub dgvCategorias_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvCategorias.MouseClick
        If e.Button = MouseButtons.Right Then
            ' Detecta en qué fila se hizo clic derecho
            Dim hit As DataGridView.HitTestInfo = dgvCategorias.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 Then
                ' Selecciona la fila clickeada
                dgvCategorias.ClearSelection()
                dgvCategorias.Rows(hit.RowIndex).Selected = True

                ' Muestra el menú contextual en la posición del clic
                cmsActEli3.Show(dgvCategorias, e.Location)
            End If
        End If
    End Sub

    ' Opción del menú contextual para actualizar una categoría
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        If dgvCategorias.SelectedRows.Count > 0 Then
            ' Obtiene los datos de la categoría seleccionada
            Dim fila As DataGridViewRow = dgvCategorias.SelectedRows(0)
            Dim idCategoria As Integer = Convert.ToInt32(fila.Cells("id_categoria").Value)
            Dim nombre As String = fila.Cells("nombre").Value.ToString()

            ' Abre el formulario de edición con los datos cargados
            Dim form As New NuevaCategoria()
            form.idCategoria = idCategoria
            form.txtNombreCat.Text = nombre
            form.ShowDialog()

            ' Refresca los datos después de actualizar
            CargarDatos()
        Else
            MessageBox.Show("Seleccione una categoría para actualizar.")
        End If
    End Sub

    ' Opción del menú contextual para eliminar una categoría
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If dgvCategorias.SelectedRows.Count > 0 Then
            Dim idCategoria As Integer = Convert.ToInt32(dgvCategorias.SelectedRows(0).Cells("id_categoria").Value)

            ' No permitir eliminar la categoría por defecto (id=1)
            If idCategoria = 1 Then
                MessageBox.Show("No se puede eliminar la categoría por defecto.")
                Return
            End If

            Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro que desea eliminar esta categoría? Se reasignarán los productos a la categoría por defecto.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    Conectar()
                    Using transaccion = conn.BeginTransaction()
                        ' Actualizar productos que tienen esta categoría para que apunten a id_categoria = 1
                        Dim actualizarProductos As String = "UPDATE productos SET id_categoria = 1 WHERE id_categoria = @id"
                        Using cmdActualizar As New MySqlCommand(actualizarProductos, conn, transaccion)
                            cmdActualizar.Parameters.AddWithValue("@id", idCategoria)
                            cmdActualizar.ExecuteNonQuery()
                        End Using

                        ' Eliminar la categoría
                        Dim eliminarCategoria As String = "DELETE FROM categorias WHERE id_categoria = @id"
                        Using cmdEliminar As New MySqlCommand(eliminarCategoria, conn, transaccion)
                            cmdEliminar.Parameters.AddWithValue("@id", idCategoria)
                            cmdEliminar.ExecuteNonQuery()
                        End Using

                        transaccion.Commit()
                    End Using

                    MessageBox.Show("Categoría eliminada y productos reasignados correctamente.")
                    CargarDatos()
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Seleccione una categoría para eliminar.")
        End If
    End Sub


    ' Función que convierte los datos del DataGridView a un DataTable
    Public Function ObtenerDatosCategorias() As DataTable
        Dim dt As New DataTable()

        ' Verifica que el DataGridView tenga filas
        If dgvCategorias.Rows.Count > 0 Then
            ' Agrega las columnas al DataTable con los mismos encabezados
            For Each col As DataGridViewColumn In dgvCategorias.Columns
                dt.Columns.Add(col.HeaderText)
            Next

            ' Recorre cada fila del DataGridView y la copia al DataTable
            For Each row As DataGridViewRow In dgvCategorias.Rows
                If Not row.IsNewRow Then
                    Dim nuevaFila As DataRow = dt.NewRow()
                    For i As Integer = 0 To dgvCategorias.Columns.Count - 1
                        nuevaFila(i) = row.Cells(i).Value?.ToString()
                    Next
                    dt.Rows.Add(nuevaFila)
                End If
            Next
        End If

        Return dt
    End Function


    Private Sub Categorias_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Si el formulario dueño es del tipo Productos, recarga su datagridview para actualizar datos
        If Me.Owner IsNot Nothing Then
            CType(Me.Owner, Inventario).CargarDatos()
        End If
    End Sub
End Class
