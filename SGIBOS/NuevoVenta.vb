Imports MySql.Data.MySqlClient

Public Class NuevoVenta
    Private ventaID As Integer = -1
    Public Property VentaSeleccionada As Integer
    Public Property EsActualizar As Boolean
    Private cargandoProductos As Boolean = False

    Private descuentoAplicado As Decimal = 10
    Private recargoAplicado As Decimal = 10
    Private totalFinalVenta As Decimal = 0

    Private Sub NuevoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
        Me.AutoSize = True
        Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        ModuloVisual.AplicarTemaFormulario(Me)

        txtDesRec.Text = "10"


        cmbIdCliente.DropDownStyle = ComboBoxStyle.DropDownList
        cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList



        llblStockDisp.LinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblStockDisp.VisitedLinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblStockDisp.ActiveLinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblStockDisp.DisabledLinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblStockDisp.ForeColor = ColorTranslator.FromHtml("#F15BB5")

        llblCliente.LinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblCliente.VisitedLinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblCliente.ActiveLinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblCliente.DisabledLinkColor = ColorTranslator.FromHtml("#F15BB5")
        llblCliente.ForeColor = ColorTranslator.FromHtml("#F15BB5")


        CargarClientes()
        CargarDetalleVenta()

        If EsActualizar = False Then
            ObtenerSiguienteNumeroVenta()
            ObtenerSiguienteNumeroDetalleVenta()
        End If

        CargarProductos()
        ventaID = Integer.Parse(lblNumVenta.Text)

        CargarMetodosPago()

        lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
    End Sub

    Private Sub txtDesRec_TextChanged(sender As Object, e As EventArgs) Handles txtDesRec.TextChanged
        AplicarDescuentoORecargo()
    End Sub



    Private Sub btnAñadirVen_Click(sender As Object, e As EventArgs) Handles btnAñadirVen.Click
        Try
            Conectar()
            Dim idDetalle As Integer = Integer.Parse(lblIDdetalle.Text)
            Dim idVenta As Integer = Integer.Parse(lblNumVenta.Text)
            Dim idProducto As Integer = Integer.Parse(cmbProducto.SelectedValue.ToString())
            Dim cantidad As Integer = Integer.Parse(txtCantidad.Text)
            Dim precioUnitario As Decimal = Decimal.Parse(lblPrecioUni.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            Dim subtotal As Decimal = cantidad * precioUnitario

            Dim queryStock As String = "SELECT cantidad_stock FROM Productos WHERE id_producto = @idProducto"
            Dim cmdStock As New MySqlCommand(queryStock, conn)
            cmdStock.Parameters.AddWithValue("@idProducto", idProducto)
            Dim stockDisponible As Integer = Convert.ToInt32(cmdStock.ExecuteScalar())

            If cantidad > stockDisponible Then
                MessageBox.Show("No hay suficiente stock disponible. Stock actual: " & stockDisponible,
                            "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim query As String = "INSERT INTO Detalle_ventas (id_detalle_ventas, id_venta, id_producto, cantidad, precio_unitario, subtotal) " &
                                  "VALUES (@idDetalle, @idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@idDetalle", idDetalle)
            cmd.Parameters.AddWithValue("@idVenta", idVenta)
            cmd.Parameters.AddWithValue("@idProducto", idProducto)
            cmd.Parameters.AddWithValue("@cantidad", cantidad)
            cmd.Parameters.AddWithValue("@precioUnitario", precioUnitario)
            cmd.Parameters.AddWithValue("@subtotal", subtotal)
            cmd.ExecuteNonQuery()

            Dim queryUpdateStock As String = "UPDATE Productos SET cantidad_stock = cantidad_stock - @cantidad WHERE id_producto = @idProducto"
            Dim cmdUpdateStock As New MySqlCommand(queryUpdateStock, conn)
            cmdUpdateStock.Parameters.AddWithValue("@cantidad", cantidad)
            cmdUpdateStock.Parameters.AddWithValue("@idProducto", idProducto)
            cmdUpdateStock.ExecuteNonQuery()

            ObtenerSiguienteNumeroDetalleVenta()
            CargarDetalleVenta()
            ActualizarTotalVenta()
            AplicarDescuentoORecargo()


            txtCantidad.Clear()
            lblPrecioUni.Text = "0.00"
            lblSubtotal.Text = "0.00"

            MessageBox.Show("Detalle agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al agregar detalle de venta: " & ex.Message)
        End Try
    End Sub

    Public Sub SetVentaID(id As Integer)
        ventaID = id
    End Sub

    Private Sub CargarClientes()
        Try
            Conectar()
            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter("SELECT id_cliente, nombre FROM Clientes", conn)
            da.Fill(dt)
            cmbIdCliente.DataSource = dt
            cmbIdCliente.DisplayMember = "nombre"
            cmbIdCliente.ValueMember = "id_cliente"
        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarDetalleVenta()
        Try
            Conectar()
            Dim query As String =
                "SELECT " &
                "dv.id_detalle_ventas AS 'ID Detalle', " &
                "p.nombre AS 'Producto', " &
                "dv.cantidad AS 'Cantidad', " &
                "dv.precio_unitario AS 'Precio Unitario', " &
                "dv.subtotal AS 'Subtotal' " &
                "FROM detalle_ventas dv " &
                "INNER JOIN productos p ON dv.id_producto = p.id_producto " &
                "WHERE dv.id_venta = @idVenta"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@idVenta", ventaID)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvDetalleVenta.DataSource = dt
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MessageBox.Show("Error al cargar detalles: " & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If cmbMetodoPago.SelectedItem Is Nothing Then
                MessageBox.Show("Seleccione un método de pago antes de guardar la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Conectar()

            Dim idVenta As Integer = Integer.Parse(lblNumVenta.Text)
            Dim idCliente As Integer = Integer.Parse(cmbIdCliente.SelectedValue.ToString())
            Dim metodoPago As String = cmbMetodoPago.Text
            Dim fechaVenta As DateTime = DateTime.Now
            Dim idUsuario As Integer = Sesion.IDUsuarioActual

            Dim consultaTotal As String = "SELECT SUM(subtotal) FROM Detalle_ventas WHERE id_venta = @id_venta"
            Dim cmdTotal As New MySqlCommand(consultaTotal, conn)
            cmdTotal.Parameters.AddWithValue("@id_venta", idVenta)
            Dim totalVentaObj As Object = cmdTotal.ExecuteScalar()
            Dim totalVenta As Decimal = If(IsDBNull(totalVentaObj), 0D, Convert.ToDecimal(totalVentaObj))

            Dim query As String = "INSERT INTO Ventas (id_venta, fecha_venta, id_cliente, total_venta, metodo_pago, id_usuario) " &
                                  "VALUES (@idVenta, @fechaVenta, @idCliente, @totalVenta, @metodoPago, @idUsuario)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@idVenta", idVenta)
            cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta)
            cmd.Parameters.AddWithValue("@idCliente", idCliente)
            cmd.Parameters.AddWithValue("@totalVenta", totalVenta)
            cmd.Parameters.AddWithValue("@metodoPago", metodoPago)
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Venta guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al guardar la venta: " & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardarSalir_Click(sender As Object, e As EventArgs) Handles btnGuardarSalir.Click
        Try
            If cmbMetodoPago.SelectedItem Is Nothing Then
                MessageBox.Show("Seleccione un método de pago antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Conectar()
            Dim idVenta As Integer = Integer.Parse(lblNumVenta.Text)
            Dim metodoPago As String = cmbMetodoPago.Text
            Dim totalVenta As String = lblTotalVenta2.Text.ToString()

            ' Variables para descuento y recargo
            Dim descuento As Decimal = 0
            Dim recargo As Decimal = 0

            If metodoPago = "Efectivo" Then
                descuento = descuentoAplicado
            ElseIf metodoPago = "Tarjeta" Then
                recargo = recargoAplicado
            End If

            Dim updateQuery As String = "UPDATE Ventas SET metodo_pago = @metodo_pago, total_venta = @total_venta, descuento = @descuento, recargo = @recargo WHERE id_venta = @id_venta"
            Dim cmdUpdate As New MySqlCommand(updateQuery, conn)
            cmdUpdate.Parameters.AddWithValue("@metodo_pago", metodoPago)
            cmdUpdate.Parameters.AddWithValue("@total_venta", totalVenta)
            cmdUpdate.Parameters.AddWithValue("@descuento", descuento)
            cmdUpdate.Parameters.AddWithValue("@recargo", recargo)
            cmdUpdate.Parameters.AddWithValue("@id_venta", idVenta)
            cmdUpdate.ExecuteNonQuery()

            MessageBox.Show("Venta actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al actualizar la venta: " & ex.Message)
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub ActualizarTotalVenta()
        Try
            Conectar()
            Dim idVenta As Integer
            If Not Integer.TryParse(lblNumVenta.Text, idVenta) Then
                MessageBox.Show("Número de venta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblTotalVenta.Text = "0.00"
                Return
            End If

            Dim query As String = "SELECT IFNULL(SUM(subtotal), 0) FROM Detalle_ventas WHERE id_venta = @idVenta"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@idVenta", idVenta)
                Dim resultado As Object = cmd.ExecuteScalar()
                Dim total As Decimal = Convert.ToDecimal(resultado)
                lblTotalVenta.Text = total.ToString("0.00")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al calcular el total de venta: " & ex.Message)
        End Try
    End Sub

    Private Sub AplicarDescuentoORecargo()
        Try
            Dim totalBase As Decimal
            If Not Decimal.TryParse(lblTotalVenta.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, totalBase) Then
                MessageBox.Show("Total de venta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim porcentaje As Decimal
            If Not Decimal.TryParse(txtDesRec.Text, porcentaje) Then
                lblDR.Text = "Porcentaje inválido"
                Return
            End If

            Dim metodoPago As String = cmbMetodoPago.Text.Trim().ToLower()

            ' Resetear valores globales
            descuentoAplicado = 0
            recargoAplicado = 0
            totalFinalVenta = totalBase

            If metodoPago = "efectivo" Then
                descuentoAplicado = totalBase * (porcentaje / 100)
                totalFinalVenta = totalBase - descuentoAplicado
                lblDR.Text = $"Descuento: -{descuentoAplicado.ToString("0.00")}"
                lblTotalVenta2.Text = totalFinalVenta.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)


            ElseIf metodoPago = "tarjeta" Then
                recargoAplicado = totalBase * (porcentaje / 100)
                totalFinalVenta = totalBase + recargoAplicado
                lblDR.Text = $"Recargo: +{recargoAplicado.ToString("0.00")}"
                lblTotalVenta2.Text = totalFinalVenta.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)

            Else
                lblDR.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("Error al aplicar descuento o recargo: " & ex.Message)
        End Try
    End Sub




    Private Sub CargarProductos()
        Try
            cargandoProductos = True
            Conectar()
            Dim query As String = "SELECT id_producto, nombre FROM Productos"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            cmbProducto.DisplayMember = "nombre"
            cmbProducto.ValueMember = "id_producto"
            cmbProducto.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        Finally
            cargandoProductos = False
        End Try
    End Sub

    Private Sub CargarMetodosPago()
        Try
            cmbMetodoPago.Items.Clear()
            cmbMetodoPago.Items.Add("Efectivo")
            cmbMetodoPago.Items.Add("Tarjeta")
            cmbMetodoPago.SelectedIndex = 0 ' Selecciona el primero por defecto
        Catch ex As Exception
            MessageBox.Show("Error al cargar métodos de pago: " & ex.Message)
        End Try
    End Sub


    Private Sub ObtenerSiguienteNumeroVenta()
        Try
            Conectar()
            Dim query As String = "SELECT IFNULL(MAX(id_venta), 0) + 1 FROM Ventas"
            Dim cmd As New MySqlCommand(query, conn)
            Dim resultado As Object = cmd.ExecuteScalar()
            lblNumVenta.Text = resultado.ToString()
        Catch ex As Exception
            MessageBox.Show("Error al obtener número de venta: " & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerSiguienteNumeroDetalleVenta()
        Try
            Conectar()
            Dim query As String = "SELECT IFNULL(MAX(id_detalle_ventas), 0) + 1 FROM Detalle_ventas"
            Dim cmd As New MySqlCommand(query, conn)
            Dim resultado As Object = cmd.ExecuteScalar()
            lblIDdetalle.Text = resultado.ToString()
        Catch ex As Exception
            MessageBox.Show("Error al obtener número de detalle: " & ex.Message)
        End Try
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
        If cargandoProductos Then Return

        Try
            Conectar()
            Dim idProducto As Integer = Integer.Parse(cmbProducto.SelectedValue.ToString())
            Dim query As String = "SELECT precio, cantidad_stock FROM Productos WHERE id_producto = @idProducto"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@idProducto", idProducto)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                lblPrecioUni.Text = Convert.ToDecimal(reader("precio")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                lblStock.Text = reader("cantidad_stock").ToString()
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error al obtener datos del producto: " & ex.Message)
        End Try
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        CalcularSubtotal()
    End Sub

    Private Sub CalcularSubtotal()
        Try
            Dim cantidad As Integer = If(Integer.TryParse(txtCantidad.Text, cantidad), cantidad, 0)
            Dim precio As Decimal = If(Decimal.TryParse(lblPrecioUni.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, precio), precio, 0)
            Dim subtotal As Decimal = cantidad * precio
            lblSubtotal.Text = subtotal.ToString("0.00")
        Catch ex As Exception
            lblSubtotal.Text = "0.00"
        End Try
    End Sub

    Private Sub llblCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblCliente.LinkClicked
        Clientes.Show()
    End Sub

    Private Sub llblStockDisp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblStockDisp.LinkClicked
        Inventario.Show()
    End Sub




    Private Sub cmbMetodoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMetodoPago.SelectedIndexChanged
        AplicarDescuentoORecargo()

    End Sub

    Private Sub llblMetodoPago_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblMetodoPago.LinkClicked
        Dim esAdmin As Boolean = RolUsuarioActual.Trim().ToLower() = "administrador"

        If esAdmin Then
            Dim frm As New AgregarMetodoPago()
            If frm.ShowDialog() = DialogResult.OK Then
                Dim nuevoMetodo As String = frm.Controls("txtNuevoMetodo").Text.Trim()
                If Not String.IsNullOrEmpty(nuevoMetodo) Then
                    ' Evitar duplicados
                    If Not cmbMetodoPago.Items.Contains(nuevoMetodo) Then
                        cmbMetodoPago.Items.Add(nuevoMetodo)
                        cmbMetodoPago.SelectedItem = nuevoMetodo
                    Else
                        MessageBox.Show("Este método ya está en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Else
            MessageBox.Show("No tienes permisos para agregar métodos de pago.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub NuevoVenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Si el formulario propietario es del tipo Inventario, llama a su método para recargar datos
        If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Ventas Then
            CType(Me.Owner, Ventas).CargarVentas()
        End If
    End Sub

End Class