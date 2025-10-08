Imports MySql.Data.MySqlClient ' Importa la librería para conexión y manejo de MySQL
Imports System.Text.RegularExpressions ' Para validar formatos con expresiones regulares

Public Class NuevoProveedor
    Public EsActualizar As Boolean = False
    ' Variable que almacena el ID del proveedor: 0 si es nuevo, mayor a 0 si se edita uno existente
    Public idProveedor As Integer = 0

    ' Evento que se ejecuta al cargar el formulario
    Private Sub NuevoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me) ' Aplica el tema visual personalizado

        ' Centra el formulario en la pantalla
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                            (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)

        If EsActualizar Then
            Me.Text = "Actualizar proveedor"
        Else
            Me.Text = "Nuevo proveedor"
        End If
    End Sub

    ' Evento que se ejecuta al hacer clic en el botón para añadir o guardar el proveedor
    Private Sub btnAñadirProv_Click(sender As Object, e As EventArgs) Handles btnAñadirProv.Click
        ' Validaciones antes de guardar

        ' Validar que el nombre no esté vacío ni exceda 50 caracteres
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("El nombre del proveedor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNombre.Focus()
            Exit Sub
        ElseIf txtNombre.Text.Length > 50 Then
            MessageBox.Show("El nombre no puede tener más de 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNombre.Focus()
            Exit Sub
        End If

        ' Validar que el contacto no exceda 50 caracteres (opcional que esté vacío)
        If txtContacto.Text.Length > 50 Then
            MessageBox.Show("El contacto no puede tener más de 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContacto.Focus()
            Exit Sub
        End If

        ' Validar teléfono: no vacío, máximo 21 caracteres y solo caracteres permitidos
        If String.IsNullOrWhiteSpace(txtTelefono.Text) Then
            MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTelefono.Focus()
            Exit Sub
        ElseIf txtTelefono.Text.Length > 21 Then
            MessageBox.Show("El teléfono no puede tener más de 21 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTelefono.Focus()
            Exit Sub
        Else
            ' Expresión regular para validar caracteres válidos en teléfono (números, espacios, signos +, -, paréntesis)
            Dim telefonoRegex As New Regex("^[\d\s\-\+\(\)]+$")
            If Not telefonoRegex.IsMatch(txtTelefono.Text.Trim()) Then
                MessageBox.Show("El teléfono contiene caracteres no válidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTelefono.Focus()
                Exit Sub
            End If
        End If

        ' Validar correo electrónico si se ingresó (formato válido)
        If txtCorreo.Text.Length > 0 Then
            Dim emailRegex As New Regex("^[\w\.-]+@[\w\.-]+\.\w+$")
            If Not emailRegex.IsMatch(txtCorreo.Text.Trim()) Then
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCorreo.Focus()
                Exit Sub
            End If
        End If

        ' Validar que la dirección no exceda 100 caracteres
        If txtDireccion.Text.Length > 100 Then
            MessageBox.Show("La dirección no puede tener más de 100 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDireccion.Focus()
            Exit Sub
        End If

        ' Si pasa todas las validaciones, procede a guardar en la base de datos
        Try
            Conectar() ' Abre la conexión a la base de datos

            Dim consulta As String

            ' Define la consulta SQL según si es nuevo proveedor o actualización
            If idProveedor = 0 Then
                consulta = "INSERT INTO Proveedores (nombre, contacto, telefono, correo, direccion) " &
                           "VALUES (@nombre, @contacto, @telefono, @correo, @direccion)"
            Else
                consulta = "UPDATE Proveedores SET nombre=@nombre, contacto=@contacto, telefono=@telefono, " &
                           "correo=@correo, direccion=@direccion WHERE id_proveedor=@id_proveedor"
            End If

            ' Crea el comando SQL y agrega los parámetros con los valores del formulario
            Dim comando As New MySqlCommand(consulta, conn)
            comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
            comando.Parameters.AddWithValue("@contacto", txtContacto.Text.Trim())
            comando.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim())
            comando.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim())
            comando.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim())

            ' Si es actualización, añade el parámetro del ID para el WHERE
            If idProveedor > 0 Then
                comando.Parameters.AddWithValue("@id_proveedor", idProveedor)
            End If

            comando.ExecuteNonQuery() ' Ejecuta la consulta SQL

            MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close() ' Cierra el formulario después de guardar

        Catch ex As Exception
            ' Muestra mensaje de error si ocurre alguna excepción
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close() ' Cierra la conexión a la base de datos
        End Try
    End Sub

    ' Evento que se ejecuta al cerrar el formulario
    Private Sub NuevoProveedor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Si el formulario propietario es del tipo "Proveedores", llama a su método para recargar los datos
        If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Proveedores Then
            CType(Me.Owner, Proveedores).CargarDatos()
        End If
    End Sub

End Class
