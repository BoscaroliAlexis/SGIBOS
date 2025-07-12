Imports MySql.Data.MySqlClient ' Importa la librería para trabajar con bases de datos MySQL

Public Class NuevoProducto

    ' Indica si el formulario está en modo actualización (True) o nuevo producto (False)
    Public EsActualizar As Boolean = False

    ' Guarda el ID del producto si se está editando uno existente
    Public idProducto As Integer = 0

    ' Método que llena un ComboBox con datos provenientes de una consulta SQL
    Sub LlenarComboBox(ByVal consulta As String, ByVal combo As ComboBox, ByVal idCampo As String, ByVal nombreCampo As String)
        Try
            Conectar() ' Abre la conexión a la base de datos
            Dim comando As New MySqlCommand(consulta, conn) ' Crea el comando con la consulta SQL
            Dim adaptador As New MySqlDataAdapter(comando) ' Adaptador para llenar un DataTable con los datos
            Dim tabla As New DataTable() ' Tabla temporal para cargar datos

            adaptador.Fill(tabla) ' Llena la tabla con los resultados de la consulta

            ' Asigna la tabla como origen de datos del ComboBox
            combo.DataSource = tabla
            combo.DisplayMember = nombreCampo ' Campo que se mostrará en la lista
            combo.ValueMember = idCampo       ' Campo que será el valor real seleccionado
        Catch ex As Exception
            MessageBox.Show("Error al llenar el ComboBox: " & ex.Message) ' Muestra error si falla
        End Try
    End Sub

    ' Carga las categorías disponibles en el ComboBox de categorías
    Sub CargarComboCategoria()
        LlenarComboBox("SELECT id_categoria, nombre FROM Categorias", cmbCategoria, "id_categoria", "nombre")
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList ' No permite que el usuario escriba texto, solo seleccionar
    End Sub

    ' Carga los proveedores disponibles en el ComboBox de proveedores
    Sub CargarComboProveedor()
        LlenarComboBox("SELECT id_proveedor, nombre FROM Proveedores", cmbProveedor, "id_proveedor", "nombre")
        cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' Evento que se ejecuta al cargar el formulario
    Private Sub NuevoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me) ' Aplica el tema visual personalizado

        ' Centra el formulario manualmente en la pantalla
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)

        'cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        'cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList

        ' Si no se está actualizando un producto, carga los ComboBox con categorías y proveedores
        If Not EsActualizar Then
            CargarComboProveedor()
            CargarComboCategoria()
        End If
    End Sub

    ' Evento que se ejecuta cuando se despliega la lista de categorías para actualizarla dinámicamente
    Private Sub cmbCategoria_DropDown(sender As Object, e As EventArgs) Handles cmbCategoria.DropDown
        CargarComboCategoria()
    End Sub

    ' Evento que se ejecuta cuando se despliega la lista de proveedores para actualizarla dinámicamente
    Private Sub cmbProveedor_DropDown(sender As Object, e As EventArgs) Handles cmbProveedor.DropDown
        CargarComboProveedor()
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón para añadir o guardar el producto
    Private Sub btnAñadirPro_Click(sender As Object, e As EventArgs) Handles btnAñadirPro.Click
        Try
            Conectar() ' Abre la conexión a la base de datos

            Dim consulta As String

            ' Define la consulta SQL según si se está insertando o actualizando un producto
            If idProducto = 0 Then
                consulta = "INSERT INTO Productos (nombre, descripcion, precio, cantidad_stock, id_categoria, id_proveedor, fecha_creacion) " &
                       "VALUES (@nombre, @descripcion, @precio, @cantidad_stock, @id_categoria, @id_proveedor, NOW())"
            Else
                consulta = "UPDATE Productos SET nombre=@nombre, descripcion=@descripcion, precio=@precio, cantidad_stock=@cantidad_stock, " &
                       "id_categoria=@id_categoria, id_proveedor=@id_proveedor WHERE id_producto=@id_producto"
            End If

            Dim comando As New MySqlCommand(consulta, conn)

            ' Reemplaza coma por punto y convierte a Double
            Dim precioCorrecto As Double = Double.Parse(txtPrecio.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)

            comando.Parameters.AddWithValue("@nombre", txtNombre.Text)
            comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text)
            comando.Parameters.AddWithValue("@precio", precioCorrecto)
            comando.Parameters.AddWithValue("@cantidad_stock", txtCantidadStock.Text)
            comando.Parameters.AddWithValue("@id_categoria", cmbCategoria.SelectedValue)
            comando.Parameters.AddWithValue("@id_proveedor", cmbProveedor.SelectedValue)

            If idProducto > 0 Then
                comando.Parameters.AddWithValue("@id_producto", idProducto)
            End If

            comando.ExecuteNonQuery()
            MessageBox.Show("Producto guardado correctamente.")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message)
        End Try
    End Sub


    ' Evento que se ejecuta cuando se cierra el formulario
    Private Sub NuevoProducto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Si el formulario propietario es del tipo Inventario, llama a su método para recargar datos
        If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Inventario Then
            CType(Me.Owner, Inventario).CargarDatos()
        End If
    End Sub

End Class
