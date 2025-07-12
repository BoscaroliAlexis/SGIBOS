Public Class AgregarMetodoPago

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If String.IsNullOrWhiteSpace(txtNuevoMetodo.Text) Then
            MessageBox.Show("Ingrese un método de pago válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub AgregarMetodoPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me)

    End Sub
End Class