<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevaCategoria
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreCat = New System.Windows.Forms.TextBox()
        Me.btnGuardarCat = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'txtNombreCat
        '
        Me.txtNombreCat.Location = New System.Drawing.Point(145, 55)
        Me.txtNombreCat.Name = "txtNombreCat"
        Me.txtNombreCat.Size = New System.Drawing.Size(203, 26)
        Me.txtNombreCat.TabIndex = 1
        '
        'btnGuardarCat
        '
        Me.btnGuardarCat.Location = New System.Drawing.Point(112, 142)
        Me.btnGuardarCat.Name = "btnGuardarCat"
        Me.btnGuardarCat.Size = New System.Drawing.Size(145, 50)
        Me.btnGuardarCat.TabIndex = 2
        Me.btnGuardarCat.Text = "Guardar"
        Me.btnGuardarCat.UseVisualStyleBackColor = True
        '
        'NuevaCategoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 233)
        Me.Controls.Add(Me.btnGuardarCat)
        Me.Controls.Add(Me.txtNombreCat)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NuevaCategoria"
        Me.Text = "Nueva categoria"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombreCat As TextBox
    Friend WithEvents btnGuardarCat As Button
End Class
