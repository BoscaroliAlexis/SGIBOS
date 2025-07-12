' Clase que representa el panel principal del sistema para usuarios con perfil de Manager
Public Class DashboardManager

    ' Evento que se ejecuta cuando se carga el formulario
    Private Sub DashboardManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarLogo(picLogo)

        ' Define la ruta del ícono del formulario
        Dim rutaIcono As String = Application.StartupPath & "\icono.ico"

        ' Aplica el tema visual al formulario usando el módulo ModuloVisual
        ModuloVisual.AplicarTemaFormulario(Me)

        ' Establece el ícono del formulario
        Me.Icon = New Icon(rutaIcono)

        ' Muestra el nombre del usuario logueado en la etiqueta de bienvenida
        lblBienvenide.Text = "Bienvenide, " & Sesion.NombreUsuarioActual

        ' Posiciona el formulario en el centro de la pantalla
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
    End Sub

    ' Abre el formulario de Clientes al hacer clic en el botón correspondiente
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Clientes.StartPosition = FormStartPosition.CenterScreen
        Clientes.Show()
    End Sub

    ' Abre el formulario de Proveedores
    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Proveedores.StartPosition = FormStartPosition.CenterScreen
        Proveedores.Show()
    End Sub

    ' Abre el formulario de Inventario
    Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
        Inventario.StartPosition = FormStartPosition.CenterScreen
        Inventario.Show()
    End Sub

    ' Abre el formulario de Ventas
    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Ventas.StartPosition = FormStartPosition.CenterScreen
        Ventas.Show()
    End Sub

    ' Abre el formulario del Manual de Usuario
    Private Sub btnManualUsuario_Click(sender As Object, e As EventArgs) Handles btnManualUsuario.Click
        ManualUsuario.StartPosition = FormStartPosition.CenterScreen
        ManualUsuario.Show()
    End Sub

    ' Abre el formulario de reportes y le pasa los datos de las distintas tablas
    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        ' Obtiene los datos desde la base de datos
        Dim dtClientes As DataTable = ObtenerDatosClientes()
        Dim dtProveedores As DataTable = ObtenerDatosProveedores()
        Dim dtProductos As DataTable = ObtenerDatosProductos()
        Dim dtVentas As DataTable = ObtenerDatosVentas()

        ' Crea el formulario de reportes con los datos obtenidos
        Dim frmReportes As New Reportes(dtClientes, dtProveedores, dtProductos, dtVentas)
        frmReportes.StartPosition = FormStartPosition.CenterScreen
        frmReportes.ShowDialog() ' Abre el formulario como cuadro de diálogo (bloquea la ventana actual)
    End Sub

    ' Maneja el cierre de sesión del usuario
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        ' Muestra un mensaje de confirmación
        If MessageBox.Show("¿Seguro que desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra sesión (limpia datos del usuario actual)
            Sesion.CerrarSesion()

            ' Cierra el formulario actual
            Me.Close()

            ' Muestra el formulario de inicio de sesión nuevamente
            Dim loginForm As New InicioSesion()
            loginForm.LimpiarCampos()
            loginForm.Show()
        End If
    End Sub

End Class
