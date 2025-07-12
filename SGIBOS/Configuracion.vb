' Clase del formulario de configuración
Public Class Configuracion

    ' Evento que se ejecuta al hacer clic en el botón para cambiar el logo
    Private Sub btnCambiarLogo_Click(sender As Object, e As EventArgs) Handles btnCambiarLogo.Click
        Try
            Dim url As String = InputBox("Ingrese la URL de la imagen:", "Cambiar Logo")

            If String.IsNullOrWhiteSpace(url) Then
                MessageBox.Show("No se ingresó una URL válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Guardar la URL en un archivo de texto
            Dim rutaArchivo As String = Application.StartupPath & "\logo_url.txt"
            IO.File.WriteAllText(rutaArchivo, url)

            ' Crear una solicitud web para obtener la imagen desde la URL
            Dim request As Net.WebRequest = Net.WebRequest.Create(url)

            ' Obtener la respuesta de la solicitud (la imagen como datos desde internet)
            Dim response As Net.WebResponse = request.GetResponse()

            ' Obtener el flujo de datos (stream) de la respuesta
            Dim stream As IO.Stream = response.GetResponseStream()

            ' Crear un objeto Image a partir del stream (flujo de datos de la imagen)
            Dim imagen As Image = Image.FromStream(stream)

            ' Mostrar la imagen en el PictureBox del formulario 
            Dashboard.picLogo.Image = imagen

            ' Cerrar el flujo de datos
            stream.Close()

            ' Cerrar la respuesta 
            response.Close()


        Catch ex As Exception
            MessageBox.Show("Error al cargar o guardar la imagen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' Evento que se ejecuta al hacer clic en el botón "Editar Usuarios"
    Private Sub btnEditarUsuarios_Click(sender As Object, e As EventArgs) Handles btnEditarUsuarios.Click
        ' Centrar el formulario de usuarios en la pantalla y mostrarlo
        Usuarios.StartPosition = FormStartPosition.CenterScreen
        Usuarios.Show()
    End Sub

    ' Evento que se ejecuta cuando se carga el formulario de configuración
    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Evita que el formulario se abra en una posición aleatoria, se va a ubicar manualmente
        Me.StartPosition = FormStartPosition.Manual

        ' Aplica el tema visual definido en el módulo ModuloVisual
        ModuloVisual.AplicarTemaFormulario(Me)

        ' Centra el formulario en el área visible de la pantalla (excluye la barra de tareas)
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
    End Sub
End Class
