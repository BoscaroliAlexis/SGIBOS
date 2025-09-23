Imports MySql.Data.MySqlClient

Public Class Registracion
    ' Evento que se ejecuta cuando se carga el formulario de registro
    Private Sub FormRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aplicar un tema visual personalizado al formulario
        ModuloVisual.AplicarTemaFormulario(Me)

        ' Configurar colores del LinkLabel lnkIniciarSesion a un tono rosa intenso
        lnkIniciarSesion.LinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkIniciarSesion.VisitedLinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkIniciarSesion.ActiveLinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkIniciarSesion.DisabledLinkColor = ColorTranslator.FromHtml("#F15BB5")
        lnkIniciarSesion.ForeColor = ColorTranslator.FromHtml("#F15BB5")

        ' Abrir la conexión global a la base de datos
        Conectar()

        ' Posicionar el formulario en el centro de la pantalla manualmente
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón Registrar
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim usuario As String = txtNuevoUsuario.Text
        Dim pass1 As String = txtContraseña.Text
        Dim pass2 As String = txtConfirmar.Text

        ' Validar que los campos no estén vacíos
        If usuario = "" Or pass1 = "" Or pass2 = "" Then
            MessageBox.Show("Completa todos los campos.")
            Exit Sub
        End If

        ' Validar que las contraseñas coincidan
        If pass1 <> pass2 Then
            MessageBox.Show("Las contraseñas no coinciden.")
            Exit Sub
        End If

        ' Hashear la contraseña antes de guardarla
        Dim hash As String = ObtenerHashSHA256(pass1)

        ' Verificar si el usuario ya existe en la base de datos
        Dim cmdCheck As New MySqlCommand("SELECT * FROM Usuarios WHERE nombre=@usuario", conn)
        cmdCheck.Parameters.AddWithValue("@usuario", usuario)
        Dim reader As MySqlDataReader = cmdCheck.ExecuteReader()

        If reader.HasRows Then
            reader.Close()
            MessageBox.Show("El usuario ya existe.")
            Exit Sub
        End If
        reader.Close()

        ' Insertar el nuevo usuario en la tabla Usuarios con estado habilitado (1)
        Dim cmdInsert As New MySqlCommand("INSERT INTO Usuarios (nombre, contrasena, estado) VALUES (@nombre, @pass, 1)", conn)
        cmdInsert.Parameters.AddWithValue("@nombre", usuario)
        cmdInsert.Parameters.AddWithValue("@pass", hash)
        cmdInsert.ExecuteNonQuery()

        ' Obtener el ID generado automáticamente para el usuario insertado
        Dim userID As Integer = cmdInsert.LastInsertedId

        ' Asignar directamente el rol Reportes (id_rol = 3)
        Dim cmdAssignRole As New MySqlCommand("INSERT INTO Usuarios_roles (id_usuario, id_rol) VALUES (@id_usuario, 3)", conn)
        cmdAssignRole.Parameters.AddWithValue("@id_usuario", userID)
        cmdAssignRole.ExecuteNonQuery()

        ' Confirmar registro exitoso al usuario
        MessageBox.Show("Usuario registrado exitosamente con el rol Reportes.")

        ' Abrir el formulario de inicio de sesión y cerrar el formulario actual
        Dim frm As New InicioSesion()
        frm.Show()
        Me.Close()
    End Sub

    ' Evento para cancelar el registro y volver al inicio de sesión
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim frm As New InicioSesion()
        frm.Show()
        Me.Close()
    End Sub

    ' Evento que se activa al hacer clic en el link "Iniciar Sesión"
    Private Sub lnkIniciarSesion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIniciarSesion.LinkClicked
        Dim frm As New InicioSesion()
        frm.Show()
        Me.Close()
    End Sub
End Class
