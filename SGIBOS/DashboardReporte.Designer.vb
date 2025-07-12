<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardReporte))
        Me.btnCerrarSesion = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.lblBienvenide = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnManualUsuario = New System.Windows.Forms.Button()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrarSesion
        '
        Me.btnCerrarSesion.Location = New System.Drawing.Point(52, 137)
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.Size = New System.Drawing.Size(330, 50)
        Me.btnCerrarSesion.TabIndex = 23
        Me.btnCerrarSesion.Text = "Cerrar sesión"
        Me.btnCerrarSesion.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.Location = New System.Drawing.Point(483, 170)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(268, 68)
        Me.btnReportes.TabIndex = 22
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'lblBienvenide
        '
        Me.lblBienvenide.AutoSize = True
        Me.lblBienvenide.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBienvenide.Location = New System.Drawing.Point(56, 68)
        Me.lblBienvenide.Name = "lblBienvenide"
        Me.lblBienvenide.Size = New System.Drawing.Size(160, 29)
        Me.lblBienvenide.TabIndex = 21
        Me.lblBienvenide.Text = "lblBienvenide"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 20)
        Me.Label1.TabIndex = 20
        '
        'picLogo
        '
        Me.picLogo.BackgroundImage = CType(resources.GetObject("picLogo.BackgroundImage"), System.Drawing.Image)
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.InitialImage = CType(resources.GetObject("picLogo.InitialImage"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(52, 220)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(330, 206)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 19
        Me.picLogo.TabStop = False
        '
        'btnManualUsuario
        '
        Me.btnManualUsuario.Location = New System.Drawing.Point(483, 296)
        Me.btnManualUsuario.Name = "btnManualUsuario"
        Me.btnManualUsuario.Size = New System.Drawing.Size(268, 68)
        Me.btnManualUsuario.TabIndex = 17
        Me.btnManualUsuario.Text = "Manual de usuario"
        Me.btnManualUsuario.UseVisualStyleBackColor = True
        '
        'DashboardReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 463)
        Me.Controls.Add(Me.btnCerrarSesion)
        Me.Controls.Add(Me.btnReportes)
        Me.Controls.Add(Me.lblBienvenide)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.btnManualUsuario)
        Me.Name = "DashboardReporte"
        Me.Text = "DashboardReporte"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents btnReportes As Button
    Friend WithEvents lblBienvenide As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents btnManualUsuario As Button
End Class
