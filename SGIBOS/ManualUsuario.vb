Public Class ManualUsuario
    Private Sub ManualUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me)

    End Sub

    Private Sub llblManual_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblManual.LinkClicked
        Try
            Process.Start("https://sgibosweb.vercel.app/manual_usuario.pdf")
        Catch ex As Exception
            MessageBox.Show("No se pudo abrir el enlace. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class