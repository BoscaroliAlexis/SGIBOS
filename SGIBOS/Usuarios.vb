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
            Dim consulta As String = "SELECT u.id_usuario, u.nombre, u.contrasena, r.titulo AS rol " &
                         "FROM Usuarios u " &
                         "JOIN Usuarios_roles ur ON u.id_usuario = ur.id_usuario " &
                         "JOIN Roles r ON ur.id_rol = r.id_rol " &
                         "WHERE u.id_usuario <> 1"


            Dim adaptador As New MySqlDataAdapter(consulta, conn)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)

            dgvUsuarios.DataSource = tabla
            dgvUsuarios.AllowUserToAddRows = False

            dgvUsuarios.Columns("contrasena").Visible = False


            If dgvUsuarios.Columns("Acciones") Is Nothing Then
                Dim colBotones As New DataGridViewButtonColumn()
                colBotones.Name = "Acciones"
                colBotones.HeaderText = "Acciones"
                colBotones.UseColumnTextForButtonValue = False
                dgvUsuarios.Columns.Add(colBotones)
            End If

            dgvUsuarios.RowTemplate.Height = 48
            dgvUsuarios.Columns("Acciones").MinimumWidth = 180
            dgvUsuarios.Columns("Acciones").Width = 200
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        Catch ex As Exception
            MessageBox.Show("Error al cargar usuarios: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvUsuarios.Columns(e.ColumnIndex).Name = "Acciones" Then
            Dim fila = dgvUsuarios.Rows(e.RowIndex)
            Dim id_usuario As Integer = Convert.ToInt32(fila.Cells("id_usuario").Value)

            Dim mouseX = dgvUsuarios.PointToClient(Cursor.Position).X - dgvUsuarios.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).X
            Dim anchoCelda = dgvUsuarios.Columns("Acciones").Width

            If mouseX < anchoCelda / 3 Then
                Dim nombre = fila.Cells("nombre").Value.ToString()
                Dim contrasena = fila.Cells("contrasena").Value.ToString()
                Dim rol = fila.Cells("rol").Value.ToString()
                EditarUsuario(id_usuario, nombre, contrasena, rol)

            ElseIf mouseX < 2 * anchoCelda / 3 Then
                Dim confirmacion = MessageBox.Show("¿Desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo)
                If confirmacion = DialogResult.Yes Then
                    EliminarUsuario(id_usuario)
                    CargarUsuarios()
                End If

            Else
                ReiniciarContraseña(id_usuario)
            End If
        End If
    End Sub

    Private Sub dgvUsuarios_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvUsuarios.CellPainting
        If e.ColumnIndex >= 0 AndAlso dgvUsuarios.Columns(e.ColumnIndex).Name = "Acciones" AndAlso e.RowIndex >= 0 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            Dim ancho = e.CellBounds.Width
            Dim alto = e.CellBounds.Height
            Dim fuente = e.CellStyle.Font

            e.Graphics.DrawString("Editar", fuente, Brushes.Black, e.CellBounds.X + 10, e.CellBounds.Y + 5)
            e.Graphics.DrawString("Eliminar", fuente, Brushes.Black, e.CellBounds.X + ancho / 3 + 10, e.CellBounds.Y + 5)
            e.Graphics.DrawString("Reset", fuente, Brushes.Black, e.CellBounds.X + 2 * ancho / 3 + 10, e.CellBounds.Y + 5)

            e.Handled = True
        End If
    End Sub



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

        ' No permitir editar contraseña
        Dim nuevaPass = passActual

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

End Class
