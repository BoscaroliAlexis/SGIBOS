Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Text

Public Class Usuarios

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        ModuloVisual.AplicarTemaFormulario(Me)


        CargarUsuarios()

        dgvUsuarios.AllowUserToOrderColumns = True
    End Sub

    Private Sub CargarUsuarios()
        Try
            Dim consulta As String = "SELECT u.id_usuario, u.nombre, u.contrasena, r.titulo AS rol, u.estado " &
                                     "FROM Usuarios u " &
                                     "JOIN Usuarios_roles ur ON u.id_usuario = ur.id_usuario " &
                                     "JOIN Roles r ON ur.id_rol = r.id_rol " &
                                     "WHERE u.id_usuario <> 1"

            Dim adaptador As New MySqlDataAdapter(consulta, conn)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)

            dgvUsuarios.DataSource = tabla
            dgvUsuarios.AllowUserToAddRows = False

            ' Ocultar columna de contraseña
            If dgvUsuarios.Columns.Contains("contrasena") Then
                dgvUsuarios.Columns("contrasena").Visible = False
            End If

            ' Agregar columna de botones si no existe
            If dgvUsuarios.Columns("Acciones") Is Nothing Then
                Dim colBotones As New DataGridViewButtonColumn()
                colBotones.Name = "Acciones"
                colBotones.HeaderText = "Acciones"
                colBotones.UseColumnTextForButtonValue = False
                dgvUsuarios.Columns.Add(colBotones)
            End If

            ' Ajustes visuales
            dgvUsuarios.RowTemplate.Height = 48
            dgvUsuarios.Columns("Acciones").MinimumWidth = 260
            dgvUsuarios.Columns("Acciones").Width = 260
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            'Agregar columna de texto para mostrar el estado
            If dgvUsuarios.Columns("estado_texto") Is Nothing Then
                Dim colEstadoTexto As New DataGridViewTextBoxColumn()
                colEstadoTexto.Name = "estado_texto"
                colEstadoTexto.HeaderText = "Estado"
                colEstadoTexto.ReadOnly = True

                ' Insertamos la columna de texto justo después de la original 'estado'
                If dgvUsuarios.Columns.Contains("estado") Then
                    dgvUsuarios.Columns.Insert(dgvUsuarios.Columns("estado").Index + 1, colEstadoTexto)
                    dgvUsuarios.Columns("estado").Visible = False ' ocultamos la columna original
                Else
                    dgvUsuarios.Columns.Add(colEstadoTexto)
                End If
            End If

            ' Rellenar la columna 'estado_texto' según el valor real de 'estado'
            For Each row As DataGridViewRow In dgvUsuarios.Rows
                If row.IsNewRow Then Continue For
                Dim val = If(dgvUsuarios.Columns.Contains("estado"), row.Cells("estado").Value, 0)
                Dim estadoInt As Integer = 0

                If val IsNot Nothing AndAlso Not Convert.IsDBNull(val) Then
                    If TypeOf val Is Boolean Then
                        estadoInt = If(CBool(val), 1, 0)
                    Else
                        estadoInt = Convert.ToInt32(val)
                    End If
                End If

                row.Cells("estado_texto").Value = If(estadoInt = 1, "Habilitado", "Deshabilitado")
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar usuarios: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvUsuarios.Columns(e.ColumnIndex).Name = "Acciones" Then
            Dim fila = dgvUsuarios.Rows(e.RowIndex)
            Dim id_usuario As Integer = Convert.ToInt32(fila.Cells("id_usuario").Value)
            Dim estado As Integer = If(dgvUsuarios.Columns.Contains("estado"), Convert.ToInt32(fila.Cells("estado").Value), 0)

            Dim mouseX = dgvUsuarios.PointToClient(Cursor.Position).X - dgvUsuarios.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).X
            Dim anchoCelda = dgvUsuarios.Columns("Acciones").Width

            ' Dividir celda en 4 acciones
            If mouseX < anchoCelda / 4 Then
                ' Editar
                Dim nombre = fila.Cells("nombre").Value.ToString()
                Dim contrasena = If(dgvUsuarios.Columns.Contains("contrasena"), fila.Cells("contrasena").Value.ToString(), "")
                Dim rol = fila.Cells("rol").Value.ToString()
                EditarUsuario(id_usuario, nombre, contrasena, rol)

            ElseIf mouseX < 2 * anchoCelda / 4 Then
                ' Eliminar
                Dim confirmacion = MessageBox.Show("¿Desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo)
                If confirmacion = DialogResult.Yes Then
                    EliminarUsuario(id_usuario)
                    CargarUsuarios()
                End If

            ElseIf mouseX < 3 * anchoCelda / 4 Then
                ' Resetear contraseña
                ReiniciarContraseña(id_usuario)

            Else
                ' Habilitar / Deshabilitar
                CambiarEstadoUsuario(id_usuario, estado)
                CargarUsuarios()
            End If
        End If
    End Sub

    Private Sub dgvUsuarios_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvUsuarios.CellPainting
        If e.ColumnIndex >= 0 AndAlso dgvUsuarios.Columns(e.ColumnIndex).Name = "Acciones" AndAlso e.RowIndex >= 0 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            Dim ancho = e.CellBounds.Width
            Dim fuente = e.CellStyle.Font
            Dim padding As Integer = 8
            Dim fila = dgvUsuarios.Rows(e.RowIndex)
            Dim estado As Integer = If(dgvUsuarios.Columns.Contains("estado"), Convert.ToInt32(fila.Cells("estado").Value), 0)
            Dim textoEstado As String = If(estado = 1, "Deshabilitar", "Habilitar")

            Dim cuarto = ancho / 4
            e.Graphics.DrawString("Editar", fuente, Brushes.Black, e.CellBounds.X + padding, e.CellBounds.Y + 5)
            e.Graphics.DrawString("Eliminar", fuente, Brushes.Black, e.CellBounds.X + cuarto + padding, e.CellBounds.Y + 5)
            e.Graphics.DrawString("Reset", fuente, Brushes.Black, e.CellBounds.X + 2 * cuarto + padding, e.CellBounds.Y + 5)
            e.Graphics.DrawString(textoEstado, fuente, Brushes.Black, e.CellBounds.X + 3 * cuarto + padding, e.CellBounds.Y + 5)

            e.Handled = True
        End If
    End Sub

    ' --- Métodos de gestión de usuarios ---
    Private Sub EliminarUsuario(id As Integer)
        Try
            Dim cmd1 As New MySqlCommand("DELETE FROM Usuarios_roles WHERE id_usuario = @id", conn)
            cmd1.Parameters.AddWithValue("@id", id)
            cmd1.ExecuteNonQuery()

            Dim cmd2 As New MySqlCommand("DELETE FROM Usuarios WHERE id_usuario = @id", conn)
            cmd2.Parameters.AddWithValue("@id", id)
            cmd2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el usuario: " & ex.Message)
        End Try
    End Sub

    Private Sub EditarUsuario(id As Integer, nombreActual As String, passActual As String, rolActual As String)
        Dim nuevoNombre = InputBox("Nuevo nombre:", "Editar Usuario", nombreActual)
        If nuevoNombre = "" Then Exit Sub
        Dim nuevaPass = passActual ' No se permite editar contraseña
        Dim nuevoRol = InputBox("Nuevo rol (Administrador, Vendedor, Reportes, Manager):", "Editar Usuario", rolActual)
        If nuevoRol = "" Then Exit Sub

        Try
            Dim cmd As New MySqlCommand("UPDATE Usuarios SET nombre=@nombre, contrasena=@pass WHERE id_usuario=@id", conn)
            cmd.Parameters.AddWithValue("@nombre", nuevoNombre)
            cmd.Parameters.AddWithValue("@pass", nuevaPass)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()

            Dim cmdRol As New MySqlCommand("SELECT id_rol FROM Roles WHERE titulo = @rol", conn)
            cmdRol.Parameters.AddWithValue("@rol", nuevoRol)
            Dim idRol As Object = cmdRol.ExecuteScalar()

            If idRol Is Nothing Then
                MessageBox.Show("El rol ingresado no existe.")
                Exit Sub
            End If

            Dim cmdActualizarRol As New MySqlCommand("UPDATE Usuarios_roles SET id_rol = @idRol WHERE id_usuario = @id", conn)
            cmdActualizarRol.Parameters.AddWithValue("@idRol", idRol)
            cmdActualizarRol.Parameters.AddWithValue("@id", id)
            cmdActualizarRol.ExecuteNonQuery()

            MessageBox.Show("Usuario actualizado correctamente.")
            CargarUsuarios()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el usuario: " & ex.Message)
        End Try
    End Sub

    Private Sub ReiniciarContraseña(idUsuario As Integer)
        Try
            Dim nuevaPass As String = GenerarContraseñaAleatoria()
            Dim hash As String = ObtenerHashSHA256(nuevaPass)

            Dim cmd As New MySqlCommand("UPDATE Usuarios SET contrasena = @hash WHERE id_usuario = @id", conn)
            cmd.Parameters.AddWithValue("@hash", hash)
            cmd.Parameters.AddWithValue("@id", idUsuario)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Nueva contraseña generada: " & nuevaPass & vbCrLf & "¡Copiala ahora! No se puede volver a ver.", "Contraseña reiniciada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al reiniciar la contraseña: " & ex.Message)
        End Try
    End Sub

    Private Sub CambiarEstadoUsuario(idUsuario As Integer, estadoActual As Integer)
        Try
            Dim nuevoEstado As Integer = If(estadoActual = 1, 0, 1)
            Dim cmd As New MySqlCommand("UPDATE Usuarios SET estado = @estado WHERE id_usuario = @id", conn)
            cmd.Parameters.AddWithValue("@estado", nuevoEstado)
            cmd.Parameters.AddWithValue("@id", idUsuario)
            cmd.ExecuteNonQuery()

            Dim mensaje = If(nuevoEstado = 1, "Usuario habilitado.", "Usuario deshabilitado.")
            MessageBox.Show(mensaje, "Estado actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al cambiar el estado del usuario: " & ex.Message)
        End Try
    End Sub

End Class
