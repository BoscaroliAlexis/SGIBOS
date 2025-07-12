' Importa las clases necesarias para trabajar con MySQL
Imports MySql.Data.MySqlClient

' Clase del formulario para actualizar una venta existente
Public Class ActualizarVenta

    ' Propiedad pública para recibir el ID de la venta a actualizar
    Public Property IdVenta As Integer

    ' Evento que se ejecuta al cargar el formulario
    Private Sub ActualizarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aplica el tema visual del sistema al formulario
        ModuloVisual.AplicarTemaFormulario(Me)

        ' Carga la lista de clientes en el ComboBox correspondiente
        CargarClientes()
        ' Carga los métodos de pago en el ComboBox correspondiente
        CargarMetodosPago()
    End Sub

    ' Método que carga los métodos de pago existentes en la base de datos
    Private Sub CargarMetodosPago()
        Try
            ' Abre conexión con la base de datos
            Conectar()
            ' Crea un DataTable para guardar los datos obtenidos
            Dim dt As New DataTable()
            ' Consulta SQL para obtener los métodos de pago distintos
            Dim da As New MySqlDataAdapter("SELECT DISTINCT metodo_pago FROM Ventas", conn)
            ' Llena el DataTable con los resultados de la consulta
            da.Fill(dt)
            ' Asocia el DataTable al ComboBox y define qué columna mostrar
            cmbMetodoPago.DataSource = dt
            cmbMetodoPago.DisplayMember = "metodo_pago"
        Catch ex As Exception
            ' Muestra un mensaje de error si algo sale mal
            MessageBox.Show("Error al cargar métodos de pago: " & ex.Message)
        End Try
    End Sub

    ' Método que carga la lista de clientes en el ComboBox
    Private Sub CargarClientes()
        Try
            ' Abre conexión con la base de datos
            Conectar()
            ' Crea un DataTable para guardar los datos obtenidos
            Dim dt As New DataTable()
            ' Consulta SQL para obtener los IDs y nombres de los clientes
            Dim da As New MySqlDataAdapter("SELECT id_cliente, nombre FROM Clientes", conn)
            ' Llena el DataTable con los resultados de la consulta
            da.Fill(dt)
            ' Asocia el DataTable al ComboBox y define qué columna mostrar y cuál usar como valor
            cmbCliente.DataSource = dt
            cmbCliente.DisplayMember = "nombre"
            cmbCliente.ValueMember = "id_cliente"
        Catch ex As Exception
            ' Muestra un mensaje de error si algo sale mal
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Guardar"
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Verifica que el ID de la venta sea válido (mayor a 0)
        If IdVenta <= 0 Then
            MessageBox.Show("ID de venta no válido.")
            Return
        End If

        Try
            ' Abre conexión con la base de datos
            Conectar()

            ' Consulta SQL para actualizar la venta
            Dim query As String = "UPDATE Ventas SET id_cliente = @idCliente, metodo_pago = @metodoPago WHERE id_venta = @idVenta"
            ' Crea el comando SQL con parámetros para evitar inyección SQL
            Dim cmd As New MySqlCommand(query, conn)

            ' Asigna valores a los parámetros desde los controles del formulario
            cmd.Parameters.AddWithValue("@idCliente", cmbCliente.SelectedValue)
            cmd.Parameters.AddWithValue("@metodoPago", cmbMetodoPago.Text)
            cmd.Parameters.AddWithValue("@idVenta", IdVenta)

            ' Ejecuta la consulta
            cmd.ExecuteNonQuery()

            ' Muestra mensaje de éxito y cierra el formulario
            MessageBox.Show("Venta actualizada correctamente.")
            Me.Close()
        Catch ex As Exception
            ' Muestra un mensaje de error si ocurre una excepción
            MessageBox.Show("Error al actualizar la venta: " & ex.Message)
        End Try
    End Sub

End Class
