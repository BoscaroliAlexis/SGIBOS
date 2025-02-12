<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManualUsuario))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblInstruccionesTexto = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(227, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(302, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Instrucciones de uso:"
        '
        'lblInstruccionesTexto
        '
        Me.lblInstruccionesTexto.AutoSize = True
        Me.lblInstruccionesTexto.Location = New System.Drawing.Point(116, 106)
        Me.lblInstruccionesTexto.Name = "lblInstruccionesTexto"
        Me.lblInstruccionesTexto.Size = New System.Drawing.Size(3058, 20)
        Me.lblInstruccionesTexto.TabIndex = 1
        Me.lblInstruccionesTexto.Text = resources.GetString("lblInstruccionesTexto.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(297, 299)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contacto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 371)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(321, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Alexis Boscaroli - boscarolialexis@gmail.com"
        '
        'ManualUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblInstruccionesTexto)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ManualUsuario"
        Me.Text = "Manual de usuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblInstruccionesTexto As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
