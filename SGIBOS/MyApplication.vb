Imports System
Imports System.Windows.Forms

Namespace My
    Partial Friend Class MyApplication
        Protected Overrides Sub OnCreateMainForm()
            ' Aquí asignamos el formulario de inicio
            Me.MainForm = New InicioSesion()
        End Sub
    End Class
End Namespace
