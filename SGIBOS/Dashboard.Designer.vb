<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.btnInventario = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnProveedores = New System.Windows.Forms.Button()
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.btnManualUsuario = New System.Windows.Forms.Button()
        Me.btnConfiguracion = New System.Windows.Forms.Button()
        Me.lblVentasRecientes = New System.Windows.Forms.Label()
        Me.lblVentasRecientesResumen = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInventario
        '
        Me.btnInventario.Location = New System.Drawing.Point(497, 31)
        Me.btnInventario.Name = "btnInventario"
        Me.btnInventario.Size = New System.Drawing.Size(268, 68)
        Me.btnInventario.TabIndex = 0
        Me.btnInventario.Text = "Inventario"
        Me.btnInventario.UseVisualStyleBackColor = True
        '
        'btnClientes
        '
        Me.btnClientes.Location = New System.Drawing.Point(497, 120)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(124, 68)
        Me.btnClientes.TabIndex = 1
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnProveedores
        '
        Me.btnProveedores.Location = New System.Drawing.Point(641, 120)
        Me.btnProveedores.Name = "btnProveedores"
        Me.btnProveedores.Size = New System.Drawing.Size(124, 68)
        Me.btnProveedores.TabIndex = 2
        Me.btnProveedores.Text = "Proveedores"
        Me.btnProveedores.UseVisualStyleBackColor = True
        '
        'btnVentas
        '
        Me.btnVentas.Location = New System.Drawing.Point(497, 210)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(268, 68)
        Me.btnVentas.TabIndex = 3
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'btnManualUsuario
        '
        Me.btnManualUsuario.Location = New System.Drawing.Point(497, 298)
        Me.btnManualUsuario.Name = "btnManualUsuario"
        Me.btnManualUsuario.Size = New System.Drawing.Size(268, 68)
        Me.btnManualUsuario.TabIndex = 4
        Me.btnManualUsuario.Text = "Manual de usuario"
        Me.btnManualUsuario.UseVisualStyleBackColor = True
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Location = New System.Drawing.Point(497, 392)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(268, 68)
        Me.btnConfiguracion.TabIndex = 5
        Me.btnConfiguracion.Text = "Configuracion"
        Me.btnConfiguracion.UseVisualStyleBackColor = True
        '
        'lblVentasRecientes
        '
        Me.lblVentasRecientes.AutoSize = True
        Me.lblVentasRecientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentasRecientes.Location = New System.Drawing.Point(87, 255)
        Me.lblVentasRecientes.Name = "lblVentasRecientes"
        Me.lblVentasRecientes.Size = New System.Drawing.Size(295, 40)
        Me.lblVentasRecientes.TabIndex = 6
        Me.lblVentasRecientes.Text = "Ventas recientes:"
        '
        'lblVentasRecientesResumen
        '
        Me.lblVentasRecientesResumen.AutoSize = True
        Me.lblVentasRecientesResumen.Location = New System.Drawing.Point(27, 322)
        Me.lblVentasRecientesResumen.Name = "lblVentasRecientesResumen"
        Me.lblVentasRecientesResumen.Size = New System.Drawing.Size(92, 20)
        Me.lblVentasRecientesResumen.TabIndex = 7
        Me.lblVentasRecientesResumen.Text = "Placeholder"
        '
        'picLogo
        '
        Me.picLogo.BackgroundImage = CType(resources.GetObject("picLogo.BackgroundImage"), System.Drawing.Image)
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.InitialImage = CType(resources.GetObject("picLogo.InitialImage"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(68, 31)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(330, 206)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 8
        Me.picLogo.TabStop = False
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 498)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.lblVentasRecientesResumen)
        Me.Controls.Add(Me.lblVentasRecientes)
        Me.Controls.Add(Me.btnConfiguracion)
        Me.Controls.Add(Me.btnManualUsuario)
        Me.Controls.Add(Me.btnVentas)
        Me.Controls.Add(Me.btnProveedores)
        Me.Controls.Add(Me.btnClientes)
        Me.Controls.Add(Me.btnInventario)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInventario As Button
    Friend WithEvents btnClientes As Button
    Friend WithEvents btnProveedores As Button
    Friend WithEvents btnVentas As Button
    Friend WithEvents btnManualUsuario As Button
    Friend WithEvents btnConfiguracion As Button
    Friend WithEvents lblVentasRecientes As Label
    Friend WithEvents lblVentasRecientesResumen As Label
    Friend WithEvents picLogo As PictureBox
End Class
