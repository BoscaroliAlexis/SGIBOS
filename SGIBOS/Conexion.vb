' Importa la biblioteca necesaria para trabajar con MySQL
Imports MySql.Data.MySqlClient

' Define un módulo que puede ser accedido globalmente en el proyecto
Module Conexion

    ' Variable pública para manejar la conexión MySQL (se comparte en todo el proyecto)
    Public conn As MySqlConnection

    ' Cadena de conexión para conectarse a la base de datos MySQL
    Public cadenaConexion As String = "Server=localhost;Database=tiendadb;Uid=root;Pwd=mysql;"

    ' Subrutina pública que inicializa y abre la conexión
    Public Sub Conectar()
        ' Se define localmente la misma cadena
        Dim cadena As String = "Server=localhost;Database=tiendadb;Uid=root;Pwd=mysql;"

        ' Crea una nueva instancia de conexión MySQL
        conn = New MySqlConnection(cadena)

        ' Intenta abrir la conexión, y si falla, muestra un mensaje de error
        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos: " & ex.Message)
        End Try
    End Sub
End Module
