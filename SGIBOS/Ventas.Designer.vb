<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ventas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtBuscarVentas = New System.Windows.Forms.TextBox()
        Me.btnBuscarVentas = New System.Windows.Forms.Button()
        Me.btnAñadirVen = New System.Windows.Forms.Button()
        Me.dgvVentas = New System.Windows.Forms.DataGridView()
        Me.btnGenerarReporteVen = New System.Windows.Forms.Button()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBuscarVentas
        '
        Me.txtBuscarVentas.Location = New System.Drawing.Point(38, 37)
        Me.txtBuscarVentas.Multiline = True
        Me.txtBuscarVentas.Name = "txtBuscarVentas"
        Me.txtBuscarVentas.Size = New System.Drawing.Size(506, 49)
        Me.txtBuscarVentas.TabIndex = 3
        '
        'btnBuscarVentas
        '
        Me.btnBuscarVentas.Location = New System.Drawing.Point(560, 37)
        Me.btnBuscarVentas.Name = "btnBuscarVentas"
        Me.btnBuscarVentas.Size = New System.Drawing.Size(92, 48)
        Me.btnBuscarVentas.TabIndex = 4
        Me.btnBuscarVentas.Text = "Buscar"
        Me.btnBuscarVentas.UseVisualStyleBackColor = True
        '
        'btnAñadirVen
        '
        Me.btnAñadirVen.Location = New System.Drawing.Point(658, 37)
        Me.btnAñadirVen.Name = "btnAñadirVen"
        Me.btnAñadirVen.Size = New System.Drawing.Size(92, 48)
        Me.btnAñadirVen.TabIndex = 5
        Me.btnAñadirVen.Text = "Añadir"
        Me.btnAñadirVen.UseVisualStyleBackColor = True
        '
        'dgvVentas
        '
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentas.Location = New System.Drawing.Point(28, 112)
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.RowHeadersWidth = 62
        Me.dgvVentas.RowTemplate.Height = 28
        Me.dgvVentas.Size = New System.Drawing.Size(734, 295)
        Me.dgvVentas.TabIndex = 6
        '
        'btnGenerarReporteVen
        '
        Me.btnGenerarReporteVen.Location = New System.Drawing.Point(285, 428)
        Me.btnGenerarReporteVen.Name = "btnGenerarReporteVen"
        Me.btnGenerarReporteVen.Size = New System.Drawing.Size(207, 46)
        Me.btnGenerarReporteVen.TabIndex = 7
        Me.btnGenerarReporteVen.Text = "Generar reporte"
        Me.btnGenerarReporteVen.UseVisualStyleBackColor = True
        '
        'Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 485)
        Me.Controls.Add(Me.btnGenerarReporteVen)
        Me.Controls.Add(Me.dgvVentas)
        Me.Controls.Add(Me.btnAñadirVen)
        Me.Controls.Add(Me.btnBuscarVentas)
        Me.Controls.Add(Me.txtBuscarVentas)
        Me.Name = "Ventas"
        Me.Text = "Ventas"
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscarVentas As TextBox
    Friend WithEvents btnBuscarVentas As Button
    Friend WithEvents btnAñadirVen As Button
    Friend WithEvents dgvVentas As DataGridView
    Friend WithEvents btnGenerarReporteVen As Button
End Class
