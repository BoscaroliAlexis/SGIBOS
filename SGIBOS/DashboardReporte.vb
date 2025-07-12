' Clase que representa el panel principal para el perfil de Reportes
Public Class DashboardReporte

    ' Evento que se ejecuta al cargar el formulario
    Private Sub DashboardReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarLogo(picLogo)


        ' Define la ruta del ícono del formulario
        Dim rutaIcono As String = Application.StartupPath & "\icono.ico"

        ' Aplica el tema visual personalizado al formulario usando el módulo visual
        ModuloVisual.AplicarTemaFormulario(Me)

        ' Establece el ícono de la ventana
        Me.Icon = New Icon(rutaIcono)

        ' Muestra un mensaje de bienvenida con el nombre del usuario actual
        lblBienvenide.Text = "Bienvenide, " & Sesion.NombreUsuarioActual

        ' Centra el formulario manualmente en la pantalla del usuario
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón de Manual de Usuario
    Private Sub btnManualUsuario_Click(sender As Object, e As EventArgs) Handles btnManualUsuario.Click
        ' Muestra el formulario del manual de usuario en el centro de la pantalla
        ManualUsuario.StartPosition = FormStartPosition.CenterScreen
        ManualUsuario.Show()
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón de Reportes
    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        ' Obtiene los datos de las tablas principales desde la base de datos
        Dim dtClientes As DataTable = ObtenerDatosClientes()
        Dim dtProveedores As DataTable = ObtenerDatosProveedores()
        Dim dtProductos As DataTable = ObtenerDatosProductos()
        Dim dtVentas As DataTable = ObtenerDatosVentas()

        ' Crea el formulario de reportes pasando los datos y lo muestra 
        Dim frmReportes As New Reportes(dtClientes, dtProveedores, dtProductos, dtVentas)
        frmReportes.StartPosition = FormStartPosition.CenterScreen
        frmReportes.ShowDialog()
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón de Cerrar Sesión
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        ' Confirma si el usuario realmente quiere cerrar sesión
        If MessageBox.Show("¿Seguro que desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra sesión y limpia los datos del usuario
            Sesion.CerrarSesion()

            ' Cierra este formulario
            Me.Close()

            ' Muestra nuevamente el formulario de inicio de sesión
            Dim loginForm As New InicioSesion()
            loginForm.LimpiarCampos()
            loginForm.Show()
        End If
    End Sub

End Class
