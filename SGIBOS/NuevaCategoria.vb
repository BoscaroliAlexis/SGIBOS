Imports MySql.Data.MySqlClient ' Importa la librería para manejar conexiones y comandos con MySQL

Public Class NuevaCategoria

    Public EsActualizar As Boolean = False
    ' Variable pública que indica si se está creando una nueva categoría (id=0) o editando una existente (id > 0)
    Public idCategoria As Integer = 0

    ' Evento que se ejecuta al hacer clic en el botón "Guardar"
    Private Sub btnGuardarCat_Click(sender As Object, e As EventArgs) Handles btnGuardarCat.Click
        Try
            Conectar() ' Abre la conexión a la base de datos usando el módulo de conexión global

            Dim consulta As String

            ' Define la consulta SQL según si es nuevo registro o actualización
            If idCategoria = 0 Then
                ' Si idCategoria es 0, significa que es una nueva categoría, por eso se usa INSERT
                consulta = "INSERT INTO Categorias (nombre) VALUES (@nombre)"
            Else
                ' Si idCategoria es mayor que 0, es una actualización de categoría existente
                consulta = "UPDATE Categorias SET nombre=@nombre WHERE id_categoria=@id_categoria"
            End If

            ' Crea el comando con la consulta SQL y la conexión abierta
            Dim comando As New MySqlCommand(consulta, conn)

            ' Asigna el valor del parámetro @nombre desde el TextBox txtNombreCat
            comando.Parameters.AddWithValue("@nombre", txtNombreCat.Text)

            ' Si es actualización, se agrega el parámetro del id para el WHERE
            If idCategoria > 0 Then
                comando.Parameters.AddWithValue("@id_categoria", idCategoria)
            End If

            ' Ejecuta la consulta en la base de datos (INSERT o UPDATE)
            comando.ExecuteNonQuery()

            ' Muestra mensaje de éxito
            MessageBox.Show("Categoría guardada correctamente.")

            ' Cierra el formulario actual
            Me.Close()

        Catch ex As Exception
            ' Captura y muestra cualquier error ocurrido durante la operación
            MessageBox.Show("Error al guardar: " & ex.Message)
        End Try
    End Sub

    ' Evento que se ejecuta al cargar el formulario
    Private Sub NuevaCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aplica el tema visual personalizado al formulario y sus controles
        ModuloVisual.AplicarTemaFormulario(Me)
        If EsActualizar Then
            Me.Text = "Actualizar categoria"
        Else
            Me.Text = "Nueva categoria"
        End If
    End Sub

End Class
