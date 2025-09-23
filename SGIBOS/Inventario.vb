Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO


Public Class Inventario

    ' Variable global en el formulario
    Private valorConfigurado As Integer = 5

    ' Timer para controlar la búsqueda diferida mientras el usuario escribe
    Dim TimerBuscar As New Timer()

    ' Adaptador para traer los datos desde la base de datos MySQL
    Private adaptador As MySqlDataAdapter

    ' Tabla temporal para guardar los datos consultados y mostrarlos en el DataGridView
    Private tabla As DataTable

    ' Variable para guardar el ID del producto seleccionado (se usa para editar o eliminar)
    Private idProducto As Integer

    ' Evento click del botón para añadir un nuevo producto
    Private Sub btnAñadirInv_Click(sender As Object, e As EventArgs) Handles btnAñadirInv.Click
        ' Crea una instancia del formulario NuevoProducto para agregar uno nuevo
        Dim frmNuevoProducto As New NuevoProducto()
        ' Establece el formulario actual como dueño (para control de ventanas)
        frmNuevoProducto.Owner = Me
        ' Muestra el formulario NuevoProducto
        frmNuevoProducto.Show()
    End Sub

    ' Evento que se ejecuta cuando se carga el formulario Inventario
    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga los productos en el DataGridView
        CargarDatos()
        ' Aplica el tema visual personalizado al formulario
        ModuloVisual.AplicarTemaFormulario(Me)

        dgvInventario.AllowUserToOrderColumns = True

        ' Configura el timer para la búsqueda automática con un intervalo de 500 ms
        TimerBuscar.Interval = 500
        TimerBuscar.Enabled = False
        ' Asigna el evento que se disparará cuando el timer se active
        AddHandler TimerBuscar.Tick, AddressOf TimerBuscar_Tick
    End Sub

    ' Evento que se ejecuta cuando cambia el texto del cuadro de búsqueda
    Private Sub txtBuscarInventario_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarInventario.TextChanged
        ' Reinicia el timer para hacer la búsqueda después de que el usuario deje de escribir
        TimerBuscar.Stop()
        TimerBuscar.Start()
    End Sub

    ' Evento del timer que ejecuta la búsqueda cuando el usuario deja de escribir
    Private Sub TimerBuscar_Tick(sender As Object, e As EventArgs)
        TimerBuscar.Stop() ' Detiene el timer para no hacer búsquedas repetidas
        CargarDatos(txtBuscarInventario.Text) ' Carga los datos con el texto de búsqueda actual
    End Sub

    ' Método que carga los datos de productos desde la base de datos
    ' Si recibe un texto como parámetro, lo usa para filtrar por nombre de producto
    Public Sub CargarDatos(Optional ByVal busqueda As String = "")
        Try
            ' Abre la conexión a la base de datos
            Conectar()

            ' Consulta SQL que obtiene información del producto junto con su categoría y proveedor
            Dim consulta As String = "SELECT p.id_producto, p.nombre AS Producto, p.descripcion, p.precio, p.cantidad_stock, " &
                                     "c.nombre AS Categoria, pr.nombre AS Proveedor, p.fecha_creacion " &
                                     "FROM productos p " &
                                     "LEFT JOIN categorias c ON p.id_categoria = c.id_categoria " &
                                     "LEFT JOIN proveedores pr ON p.id_proveedor = pr.id_proveedor"

            ' Si hay texto de búsqueda, agrega una cláusula WHERE para filtrar por nombre
            If Not String.IsNullOrWhiteSpace(busqueda) Then
                consulta &= " WHERE p.nombre LIKE @busqueda"
            End If

            ' Prepara el adaptador con la consulta y la conexión abierta
            adaptador = New MySqlDataAdapter(consulta, conn)

            ' Si hay búsqueda, agrega el parámetro para evitar inyección SQL
            If Not String.IsNullOrWhiteSpace(busqueda) Then
                adaptador.SelectCommand.Parameters.AddWithValue("@busqueda", "%" & busqueda & "%")
            End If

            ' Inicializa la tabla temporal y llena con los datos obtenidos
            tabla = New DataTable()
            adaptador.Fill(tabla)

            ' Si se encontraron productos, los muestra en el DataGridView
            If tabla.Rows.Count > 0 Then
                dgvInventario.DataSource = tabla
            Else
                ' Si no hay resultados, muestra un mensaje y limpia el DataGridView
                MessageBox.Show("No se encontraron productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvInventario.DataSource = Nothing
            End If

        Catch ex As Exception
            ' Muestra un mensaje en caso de error al cargar los productos
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón Buscar
    ' Llama a CargarDatos con el texto ingresado para filtrar la búsqueda
    Private Sub btnBuscarInventario_Click(sender As Object, e As EventArgs) Handles btnBuscarInventario.Click
        CargarDatos(txtBuscarInventario.Text)
    End Sub

    ' Evento para abrir el formulario de gestión de categorías al hacer clic en el botón correspondiente
    Private Sub btnGesCat_Click(sender As Object, e As EventArgs) Handles btnGesCat.Click

        Dim frmCategoria As New Categorias()
        ' Establece el formulario actual como dueño (para control de ventanas)
        frmCategoria.Owner = Me
        ' Muestra el formulario NuevoProducto
        frmCategoria.Show()

        frmCategoria.StartPosition = FormStartPosition.CenterScreen

    End Sub

    ' Evento que detecta clic derecho sobre el DataGridView para mostrar un menú contextual
    Private Sub dgvInventario_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvInventario.MouseClick
        ' Verifica si se hizo clic con el botón derecho del mouse
        If e.Button = MouseButtons.Right Then
            ' Obtiene la fila sobre la que se hizo clic
            Dim hit As DataGridView.HitTestInfo = dgvInventario.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 Then
                ' Limpia cualquier selección previa y selecciona la fila actual
                dgvInventario.ClearSelection()
                dgvInventario.Rows(hit.RowIndex).Selected = True
                ' Muestra el menú contextual en la posición del clic
                cmsActEli2.Show(dgvInventario, e.Location)
            End If
        End If
    End Sub

    ' Opción del menú contextual para actualizar un producto
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        ' Verifica que haya una fila seleccionada
        If dgvInventario.SelectedRows.Count > 0 Then
            ' Obtiene la fila seleccionada
            Dim fila As DataGridViewRow = dgvInventario.SelectedRows(0)
            Dim formulario As New NuevoProducto()

            ' Pasa los datos del producto al formulario para editar
            formulario.idProducto = fila.Cells("id_producto").Value
            formulario.txtNombre.Text = fila.Cells("Producto").Value.ToString()
            formulario.txtDescripcion.Text = fila.Cells("descripcion").Value.ToString()
            formulario.txtPrecio.Text = fila.Cells("precio").Value.ToString()
            formulario.txtCantidadStock.Text = fila.Cells("cantidad_stock").Value.ToString()
            formulario.cmbCategoria.Text = fila.Cells("Categoria").Value.ToString()
            formulario.cmbProveedor.Text = fila.Cells("Proveedor").Value.ToString()
            formulario.EsActualizar = True ' Marca el formulario en modo edición

            ' Muestra el formulario de edición y luego recarga los datos al cerrarlo
            formulario.ShowDialog()
            CargarDatos()
        Else
            MessageBox.Show("Seleccione un producto para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Opción del menú contextual para eliminar un producto
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        ' Verifica que haya una fila seleccionada
        If dgvInventario.SelectedRows.Count > 0 Then
            Dim idProducto As Integer = dgvInventario.SelectedRows(0).Cells("id_producto").Value

            ' Pide confirmación al usuario antes de eliminar el producto
            Dim confirmacion As DialogResult = MessageBox.Show("¿Seguro que desea eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    Conectar() ' Abre la conexión a la base de datos

                    ' Prepara la consulta DELETE para eliminar el producto por su ID
                    Dim consulta As String = "DELETE FROM productos WHERE id_producto = @id"
                    Using comando As New MySqlCommand(consulta, conn)
                        comando.Parameters.AddWithValue("@id", idProducto)
                        comando.ExecuteNonQuery() ' Ejecuta la eliminación
                    End Using

                    MessageBox.Show("Producto eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarDatos() ' Actualiza el DataGridView para reflejar el cambio
                Catch ex As Exception
                    ' Muestra mensaje si hay error al eliminar
                    MessageBox.Show("Error al eliminar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Seleccione un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Evento que genera un reporte con información de inventario y otras tablas relacionadas
    Private Sub btnGenerarReporteInv_Click(sender As Object, e As EventArgs) Handles btnGenerarReporteInv.Click
        ' Obtiene datos de las tablas clientes, proveedores, productos y ventas llamando a funciones externas
        Dim dtClientes As DataTable = ObtenerDatosClientes()
        Dim dtProveedores As DataTable = ObtenerDatosProveedores()
        Dim dtProductos As DataTable = ObtenerDatosProductos()
        Dim dtVentas As DataTable = ObtenerDatosVentas()

        ' Crea el formulario de reportes con los datos obtenidos y lo muestra centrado
        Dim frmReportes As New Reportes(dtClientes, dtProveedores, dtProductos, dtVentas)
        frmReportes.StartPosition = FormStartPosition.CenterScreen
        frmReportes.ShowDialog()
    End Sub

    Private Sub btnReporteStock_Click(sender As Object, e As EventArgs) Handles btnReporteStock.Click
        ' Cuadro para elegir dónde guardar el archivo
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "Archivos PDF|*.pdf"
        saveDialog.Title = "Guardar Reporte de Stock"
        saveDialog.FileName = "Reporte_Stock.pdf"

        If saveDialog.ShowDialog() = DialogResult.OK Then
            Try
                ' 1. Consulta a la BD
                Dim query As String = "SELECT nombre, cantidad_stock FROM Productos WHERE cantidad_stock <= @valor"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@valor", valorConfigurado)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' 2. Crear el PDF
                Dim doc As New Document(PageSize.A4, 40, 40, 40, 40)
                PdfWriter.GetInstance(doc, New FileStream(saveDialog.FileName, FileMode.Create))
                doc.Open()

                ' Título
                Dim titulo As New Paragraph("Reporte de Productos con stock menor o igual a " & valorConfigurado, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))
                titulo.Alignment = Element.ALIGN_CENTER
                doc.Add(titulo)
                doc.Add(New Paragraph(" "))

                ' Tabla
                Dim table As New PdfPTable(2)
                table.WidthPercentage = 100
                table.AddCell("Producto")
                table.AddCell("Stock")

                For Each row As DataRow In dt.Rows
                    table.AddCell(row("nombre").ToString())
                    table.AddCell(row("cantidad_stock").ToString())
                Next

                doc.Add(table)
                doc.Close()

                MessageBox.Show("PDF generado correctamente en: " & saveDialog.FileName, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error al generar PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnConfigurarReporte_Click(sender As Object, e As EventArgs) Handles btnConfigurarReporte.Click
        Dim input As String = InputBox("Ingrese el valor máximo de stock para el reporte:", "Configurar Reporte")

        If Integer.TryParse(input, valorConfigurado) Then
            MessageBox.Show("Valor configurado correctamente: " & valorConfigurado, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Debe ingresar un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
