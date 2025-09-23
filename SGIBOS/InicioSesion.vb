Imports MySql.Data.MySqlClient

' Clase para el formulario de inicio de sesión
Public Class InicioSesion

    ' Evento que se ejecuta al cargar el formulario
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conectar() ' Establece la conexión con la base de datos

        ' Configura el color del LinkLabel "Registrarse" en varios estados (normal, visitado, activo, deshabilitado)
        lnkRegistrarse.LinkColor = ColorTranslator.FromHtml("#F15BB5") ' Rosa intenso
        lnkRegistrarse.VisitedLinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkRegistrarse.ActiveLinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkRegistrarse.DisabledLinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkRegistrarse.ForeColor = ColorTranslator.FromHtml("#F15BB5") ' También cambia el color del texto

        ModuloVisual.AplicarTemaFormulario(Me) ' Aplica el tema visual personalizado al formulario

        ' Posiciona el formulario centrado en la pantalla (manual)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                            (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)

        txtContraseña.UseSystemPasswordChar = True ' Oculta el texto del campo contraseña con asteriscos
    End Sub

    ' Evento que se ejecuta al cambiar el estado del checkbox para mostrar/ocultar contraseña
    Private Sub chkMostrarContraseña_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarContraseña.CheckedChanged
        ' Cambia si el campo de contraseña muestra texto plano o asteriscos
        txtContraseña.UseSystemPasswordChar = Not chkMostrarContraseña.Checked
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Iniciar Sesión"
    Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        ' Validar que no haya campos vacíos
        If txtUsuario.Text.Trim() = "" OrElse txtContraseña.Text.Trim() = "" Then
            MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Hashear la contraseña ingresada
            Dim hashIngresado As String = ObtenerHashSHA256(txtContraseña.Text)

            ' Intentar iniciar sesión con contraseña hasheada
            Dim cmd As New MySqlCommand("
            SELECT u.id_usuario, u.nombre, r.titulo AS rol, u.estado 
            FROM Usuarios u
            JOIN Usuarios_roles ur ON u.id_usuario = ur.id_usuario
            JOIN Roles r ON ur.id_rol = r.id_rol
            WHERE u.nombre = @usuario AND u.contrasena = @pass
            LIMIT 1", conn)

            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@pass", hashIngresado)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Verificar si el usuario está habilitado
                Dim estado As Integer = reader.GetInt32("estado")
                If estado = 0 Then
                    reader.Close()
                    MessageBox.Show("Este usuario está deshabilitado. Contacte con el administrador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                ' Login exitoso
                Sesion.IDUsuarioActual = reader.GetInt32("id_usuario")
                Sesion.NombreUsuarioActual = reader.GetString("nombre")
                Sesion.RolUsuarioActual = reader.GetString("rol")

                MessageBox.Show("Inicio de sesión exitoso. Bienvenide " & Sesion.NombreUsuarioActual, "Éxito")

                reader.Close()
                Me.Hide()

                Select Case Sesion.RolUsuarioActual
                    Case "Administrador"
                        Dashboard.Show()
                    Case "Vendedor"
                        DashboardVendedor.Show()
                    Case "Manager"
                        DashboardManager.Show()
                    Case "Reportes"
                        DashboardReporte.Show()
                End Select
            Else
                reader.Close()
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al iniciar sesión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón Cancelar
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Application.Exit() ' Cierra la aplicación completa
    End Sub

    ' Evento que se ejecuta al hacer clic en el LinkLabel "Registrarse"
    Private Sub lnkRegistrarse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRegistrarse.LinkClicked
        Dim frm As New Registracion() ' Crea instancia del formulario de registro
        frm.Show()                    ' Muestra el formulario de registro
        Me.Hide()                     ' Oculta el formulario de inicio de sesión
    End Sub

    ' Método público para limpiar los campos del formulario (usuario, contraseña y checkbox)
    Public Sub LimpiarCampos()
        txtUsuario.Clear()
        txtContraseña.Clear()
        chkMostrarContraseña.Checked = False
        txtContraseña.UseSystemPasswordChar = True ' Asegura que la contraseña esté oculta
    End Sub

End Class
