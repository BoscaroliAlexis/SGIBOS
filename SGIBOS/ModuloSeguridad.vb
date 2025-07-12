Imports System.Security.Cryptography
Imports System.Text


Module ModuloSeguridad
    Public Function ObtenerHashSHA256(ByVal texto As String) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytesTexto As Byte() = Encoding.UTF8.GetBytes(texto)
        Dim hash As Byte() = sha256.ComputeHash(bytesTexto)
        Return BitConverter.ToString(hash).Replace("-", "").ToLower()
    End Function

    Public Function GenerarContraseñaAleatoria() As String
        Dim caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim rnd As New Random()
        Dim resultado As String = ""
        For i As Integer = 1 To 8 ' Fijamos la longitud exacta en 8
            resultado &= caracteres(rnd.Next(caracteres.Length))
        Next
        Return resultado
    End Function

End Module

