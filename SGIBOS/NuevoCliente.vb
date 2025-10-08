Imports MySql.Data.MySqlClient ' Importa la librería para trabajar con MySQL
Imports System.Text.RegularExpressions ' Importa para usar expresiones regulares (validaciones)

Public Class NuevoCliente

    ' Variable pública que indica si se está creando un cliente nuevo (0) o editando uno existente (>0)
    Public idCliente As Integer = 0

    Public EsActualizar As Boolean = False
    ' Variable para el comando SQL (insert/update)
    Dim comando As MySqlCommand

    ' Evento que se ejecuta al hacer clic en el botón "Añadir" o "Guardar"
    Private Sub btnAñadirCli_Click(sender As Object, e As EventArgs) Handles btnAñadirCli.Click

        ' VALIDACIONES DE DATOS ANTES DE GUARDAR

        ' Validar que el nombre no esté vacío
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("El nombre es obligatorio.")
            txtNombre.Focus()
            Exit Sub ' Sale del procedimiento si falla la validación
        End If

        ' Validar que el teléfono no esté vacío, no supere 21 caracteres y tenga formato válido
        If String.IsNullOrWhiteSpace(txtTelefono.Text) Then
            MessageBox.Show("El teléfono es obligatorio.")
            txtTelefono.Focus()
            Exit Sub
        ElseIf txtTelefono.Text.Length > 21 Then
            MessageBox.Show("El teléfono no puede tener más de 21 caracteres.")
            txtTelefono.Focus()
            Exit Sub
        Else
            ' Regex para permitir solo dígitos, espacios, guiones, paréntesis y signos +
            Dim telefonoRegex As New Regex("^[\d\s\-\+\(\)]+$")
            If Not telefonoRegex.IsMatch(txtTelefono.Text.Trim()) Then
                MessageBox.Show("El teléfono contiene caracteres no válidos.")
                txtTelefono.Focus()
                Exit Sub
            End If
        End If

        ' Validar correo solo si el campo tiene texto, debe tener formato válido
        If txtCorreo.Text.Length > 0 Then
            Dim emailRegex As New Regex("^[\w\.-]+@[\w\.-]+\.\w+$")
            If Not emailRegex.IsMatch(txtCorreo.Text.Trim()) Then
                MessageBox.Show("El correo electrónico no tiene un formato válido.")
                txtCorreo.Focus()
                Exit Sub
            End If
        End If

        ' Validar longitud máxima de dirección (100 caracteres)
        If txtDireccion.Text.Length > 100 Then
            MessageBox.Show("La dirección no puede tener más de 100 caracteres.")
            txtDireccion.Focus()
            Exit Sub
        End If

        ' SI PASAN LAS VALIDACIONES, CONTINÚA CON LA OPERACIÓN DE GUARDADO

        Try
            Conectar() ' Abre la conexión global a la base de datos

            Dim consulta As String

            ' Si idCliente es 0, se inserta un nuevo cliente
            ' Si es mayor a 0, se actualiza el cliente existente con ese ID
            If idCliente = 0 Then
                consulta = "INSERT INTO Clientes (nombre, telefono, correo, direccion) VALUES (@nombre, @telefono, @correo, @direccion)"
            Else
                consulta = "UPDATE Clientes SET nombre=@nombre, telefono=@telefono, correo=@correo, direccion=@direccion WHERE id_cliente=@id_cliente"
            End If

            ' Crea el comando con la consulta y conexión activa
            comando = New MySqlCommand(consulta, conn)

            ' Asigna los parámetros con los valores ingresados (recortando espacios al inicio y fin)
            comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
            comando.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim())
            comando.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim())
            comando.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim())

            ' Si es actualización, agrega el parámetro del id para el WHERE
            If idCliente > 0 Then
                comando.Parameters.AddWithValue("@id_cliente", idCliente)
            End If

            comando.ExecuteNonQuery() ' Ejecuta la consulta (INSERT o UPDATE)
            MessageBox.Show("Cliente guardado correctamente.") ' Mensaje de éxito
            Me.Close() ' Cierra el formulario

        Catch ex As Exception
            ' Muestra cualquier error ocurrido
            MessageBox.Show("Error al guardar: " & ex.Message)
        Finally
            ' Cierra la conexión aunque haya ocurrido error o no
            conn.Close()
        End Try
    End Sub

    ' Evento que se ejecuta al cargar el formulario
    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me) ' Aplica tema visual personalizado

        ' Centra manualmente el formulario en la pantalla principal
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2,
                                (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) \ 2)
        If EsActualizar Then
            Me.Text = "Actualizar cliente"
        Else
            Me.Text = "Nuevo cliente"
        End If
    End Sub

    ' Evento que se ejecuta cuando se cierra el formulario
    Private Sub NuevoCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Si el formulario propietario es de tipo Clientes, recarga sus datos para refrescar la lista
        If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Clientes Then
            CType(Me.Owner, Clientes).CargarDatos()
        End If
    End Sub

End Class
