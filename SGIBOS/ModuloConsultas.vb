Imports MySql.Data.MySqlClient ' Importa librería para trabajar con MySQL

' Módulo que contiene funciones para consultar datos de diferentes tablas
Module ModuloConsultas

    ' Función que obtiene todos los registros de la tabla Clientes
    Public Function ObtenerDatosClientes() As DataTable
        Dim dt As New DataTable() ' Crea un DataTable para guardar los resultados
        Try
            Conectar()
            Dim query As String = "SELECT * FROM Clientes" ' Consulta SQL para obtener todos los clientes
            Using da As New MySqlDataAdapter(query, conn) ' Adaptador que ejecuta la consulta
                da.Fill(dt) ' Llena el DataTable con los resultados
            End Using
        Catch ex As Exception
            ' Muestra un mensaje si ocurre un error
            MessageBox.Show("Error al obtener datos de Clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt ' Devuelve el DataTable con los datos
    End Function

    ' Función que obtiene todos los registros de la tabla Proveedores
    Public Function ObtenerDatosProveedores() As DataTable
        Dim dt As New DataTable()
        Try
            Conectar()
            Dim query As String = "SELECT * FROM Proveedores"
            Using da As New MySqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener datos de Proveedores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    ' Función que obtiene todos los registros de la tabla Productos
    Public Function ObtenerDatosProductos() As DataTable
        Dim dt As New DataTable()
        Try
            Conectar()
            Dim query As String = "SELECT * FROM Productos"
            Using da As New MySqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener datos de Productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    ' Función que obtiene todos los registros de la tabla Ventas
    Public Function ObtenerDatosVentas() As DataTable
        Dim dt As New DataTable()
        Try
            Conectar()
            Dim query As String = "SELECT * FROM Ventas"
            Using da As New MySqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener datos de Ventas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

End Module
