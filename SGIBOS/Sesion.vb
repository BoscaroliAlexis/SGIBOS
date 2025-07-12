' Módulo público para manejar la sesión del usuario en la aplicación
Public Module Sesion

    ' Variable pública que almacena el ID del usuario actualmente logueado
    Public IDUsuarioActual As Integer = -1

    ' Variable pública que almacena el nombre del usuario actualmente logueado
    Public NombreUsuarioActual As String = ""

    ' Variable pública que almacena el rol del usuario actualmente logueado
    Public RolUsuarioActual As String = ""

    ' Método público para cerrar sesión, que reinicia los datos de usuario actual
    Public Sub CerrarSesion()
        ' Se resetean los valores para indicar que no hay usuario logueado
        IDUsuarioActual = -1
        NombreUsuarioActual = ""
        RolUsuarioActual = ""
    End Sub

End Module

