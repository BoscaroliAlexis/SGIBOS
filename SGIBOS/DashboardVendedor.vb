' Clase que representa el panel principal (Dashboard) para los usuarios con rol de Vendedor
Public Class DashboardVendedor

    ' Evento que se ejecuta cuando se carga el formulario
    Private Sub DashboardVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarLogo(picLogo)


        ' Aplica el tema visual al formulario usando el módulo visual común
        ModuloVisual.AplicarTemaFormulario(Me)



        ' Muestra un mensaje de bienvenida con el nombre del usuario actual
        lblBienvenide.Text = "Bienvenide, " & Sesion.NombreUsuarioActual

        ' Establece la posición inicial del formulario como manual
        Me.StartPosition = FormStartPosition.Manual

        ' Centra el formulario en la pantalla
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Clientes"
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        ' Muestra el formulario de clientes en el centro de la pantalla
        Clientes.StartPosition = FormStartPosition.CenterScreen
        Clientes.Show()
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Ventas"
    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        ' Muestra el formulario de ventas en el centro de la pantalla
        Ventas.StartPosition = FormStartPosition.CenterScreen
        Ventas.Show()
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Manual de Usuario"
    Private Sub btnManualUsuario_Click(sender As Object, e As EventArgs) Handles btnManualUsuario.Click
        ' Muestra el formulario del manual de usuario
        ManualUsuario.StartPosition = FormStartPosition.CenterScreen
        ManualUsuario.Show()
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón "Cerrar Sesión"
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        ' Confirma si el usuario realmente desea cerrar sesión
        If MessageBox.Show("¿Seguro que desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra sesión mediante el módulo Sesion
            Sesion.CerrarSesion()

            ' Cierra el formulario actual
            Me.Close()

            ' Muestra nuevamente el formulario de inicio de sesión
            Dim loginForm As New InicioSesion()
            loginForm.LimpiarCampos()
            loginForm.Show()
        End If
    End Sub

End Class
