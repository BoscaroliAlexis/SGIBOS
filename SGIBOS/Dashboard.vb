' Clase principal del menú de navegación del sistema
Public Class Dashboard

    ' Evento que se ejecuta al cargar el formulario
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ruta del ícono personalizado del formulario
        Dim rutaIcono As String = Application.StartupPath & "\icono.ico"

        CargarLogo(picLogo)


        ' Aplica el tema visual definido en el módulo ModuloVisual
        ModuloVisual.AplicarTemaFormulario(Me)

        ' Establece el ícono del formulario
        Me.Icon = New Icon(rutaIcono)

        ' Muestra el nombre del usuario actual en una etiqueta de bienvenida
        lblBienvenide.Text = "Bienvenide, " & Sesion.NombreUsuarioActual

        ' Centra el formulario en la pantalla (posición manual)
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

    ' Abre el Manual de Usuario
    Private Sub btnManualUsuario_Click(sender As Object, e As EventArgs) Handles btnManualUsuario.Click
        ManualUsuario.StartPosition = FormStartPosition.CenterScreen
        ManualUsuario.Show()
    End Sub

    ' Abre el formulario de Configuración
    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        Configuracion.Show()
    End Sub

    ' Genera un informe con los datos de clientes, proveedores, productos y ventas
    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        ' Obtener los datos necesarios para el reporte
        Dim dtClientes As DataTable = ObtenerDatosClientes()
        Dim dtProveedores As DataTable = ObtenerDatosProveedores()
        Dim dtProductos As DataTable = ObtenerDatosProductos()
        Dim dtVentas As DataTable = ObtenerDatosVentas()

        ' Crear y mostrar el formulario de reportes con los datos obtenidos
        Dim frmReportes As New Reportes(dtClientes, dtProveedores, dtProductos, dtVentas)
        frmReportes.StartPosition = FormStartPosition.CenterScreen
        frmReportes.ShowDialog()
    End Sub

    ' Cierra la sesión del usuario actual y vuelve al formulario de inicio de sesión
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        ' Mostrar mensaje de confirmación
        If MessageBox.Show("¿Seguro que desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra la sesión y este formulario
            Sesion.CerrarSesion()
            Me.Close()

            ' Abre el formulario de inicio de sesión
            Dim loginForm As New InicioSesion()
            loginForm.LimpiarCampos()
            loginForm.Show()
        End If
    End Sub

End Class
