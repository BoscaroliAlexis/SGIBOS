<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracion
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
        Me.btnCambiarLogo = New System.Windows.Forms.Button()
        Me.btnEditarUsuarios = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCambiarLogo
        '
        Me.btnCambiarLogo.Location = New System.Drawing.Point(117, 174)
        Me.btnCambiarLogo.Name = "btnCambiarLogo"
        Me.btnCambiarLogo.Size = New System.Drawing.Size(213, 98)
        Me.btnCambiarLogo.TabIndex = 0
        Me.btnCambiarLogo.Text = "Cambiar logo"
        Me.btnCambiarLogo.UseVisualStyleBackColor = True
        '
        'btnEditarUsuarios
        '
        Me.btnEditarUsuarios.Location = New System.Drawing.Point(411, 174)
        Me.btnEditarUsuarios.Name = "btnEditarUsuarios"
        Me.btnEditarUsuarios.Size = New System.Drawing.Size(213, 98)
        Me.btnEditarUsuarios.TabIndex = 1
        Me.btnEditarUsuarios.Text = "Editar usuarios"
        Me.btnEditarUsuarios.UseVisualStyleBackColor = True
        '
        'Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 449)
        Me.Controls.Add(Me.btnEditarUsuarios)
        Me.Controls.Add(Me.btnCambiarLogo)
        Me.Name = "Configuracion"
        Me.Text = "Configuracion"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCambiarLogo As Button
    Friend WithEvents btnEditarUsuarios As Button
End Class
