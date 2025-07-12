Imports MySql.Data.MySqlClient

' Clase para gestionar los detalles de una venta específica
Public Class DetallesVenta

    ' Variable para almacenar el ID de la venta cuyos detalles se mostrarán
    Private idVenta As Integer

    ' Constructor que recibe el ID de la venta
    Public Sub New(id As Integer)
        InitializeComponent()   ' Inicializa los componentes del formulario
        idVenta = id            ' Guarda el ID de la venta recibido
    End Sub

    ' Evento que se ejecuta al cargar el formulario
    Private Sub DetallesVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDetallesVenta()          ' Carga los detalles de la venta desde la base de datos
        ModuloVisual.AplicarTemaFormulario(Me)   ' Aplica el tema visual al formulario
    End Sub

    ' Método que carga los detalles de la venta en el DataGridView
    Private Sub CargarDetallesVenta()
        Try
            Conectar()  ' Abre la conexión a la base de datos
            Dim query As String = "
            SELECT dv.id_detalle_ventas, p.nombre AS 'Producto', dv.cantidad AS 'Cantidad', dv.precio_unitario AS 'Precio Unitario'
            FROM Detalle_ventas dv
            INNER JOIN Productos p ON dv.id_producto = p.id_producto
            WHERE dv.id_venta = @idVenta"   ' Consulta para obtener detalles de la venta

            Dim cmd As New MySqlCommand(query, conn)  ' Comando con la consulta y conexión
            cmd.Parameters.AddWithValue("@idVenta", idVenta)  ' Parámetro para evitar inyección SQL

            Dim adapter As New MySqlDataAdapter(cmd)  ' Adaptador para llenar la tabla
            Dim dt As New DataTable()
            adapter.Fill(dt)  ' Llena el DataTable con los datos obtenidos

            dgvDetallesVenta.DataSource = dt  ' Asigna la tabla como fuente de datos del DataGridView

            ' Oculta la columna que contiene el ID del detalle para no mostrarla al usuario
            If dgvDetallesVenta.Columns.Contains("id_detalle_ventas") Then
                dgvDetallesVenta.Columns("id_detalle_ventas").Visible = False
            End If

            ' Configurar el DataGridView como solo lectura y visual
            dgvDetallesVenta.ReadOnly = True
            dgvDetallesVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvDetallesVenta.MultiSelect = False
            dgvDetallesVenta.AllowUserToAddRows = False
            dgvDetallesVenta.AllowUserToDeleteRows = False
            dgvDetallesVenta.AllowUserToOrderColumns = True
            dgvDetallesVenta.AllowUserToResizeRows = False
            dgvDetallesVenta.AllowUserToResizeColumns = False
            dgvDetallesVenta.RowHeadersVisible = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar detalles de venta: " & ex.Message) ' Manejo de errores
        End Try
    End Sub

    ' Evento que se ejecuta cuando el formulario se cierra
    Private Sub DetallesVenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Si el formulario dueño es del tipo Ventas, recarga su lista de ventas para actualizar datos
        If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Ventas Then
            CType(Me.Owner, Ventas).CargarVentas()
        End If
    End Sub

End Class
