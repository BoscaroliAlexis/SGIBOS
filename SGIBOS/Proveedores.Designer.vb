<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proveedores
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
        Me.txtBuscarProveedores = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedores = New System.Windows.Forms.Button()
        Me.btnAñadirPro = New System.Windows.Forms.Button()
        Me.dgvProveedores = New System.Windows.Forms.DataGridView()
        Me.btnGenerarReportePro = New System.Windows.Forms.Button()
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBuscarProveedores
        '
        Me.txtBuscarProveedores.Location = New System.Drawing.Point(29, 47)
        Me.txtBuscarProveedores.Multiline = True
        Me.txtBuscarProveedores.Name = "txtBuscarProveedores"
        Me.txtBuscarProveedores.Size = New System.Drawing.Size(506, 48)
        Me.txtBuscarProveedores.TabIndex = 1
        '
        'btnBuscarProveedores
        '
        Me.btnBuscarProveedores.Location = New System.Drawing.Point(555, 47)
        Me.btnBuscarProveedores.Name = "btnBuscarProveedores"
        Me.btnBuscarProveedores.Size = New System.Drawing.Size(92, 48)
        Me.btnBuscarProveedores.TabIndex = 2
        Me.btnBuscarProveedores.Text = "Buscar"
        Me.btnBuscarProveedores.UseVisualStyleBackColor = True
        '
        'btnAñadirPro
        '
        Me.btnAñadirPro.Location = New System.Drawing.Point(671, 47)
        Me.btnAñadirPro.Name = "btnAñadirPro"
        Me.btnAñadirPro.Size = New System.Drawing.Size(92, 48)
        Me.btnAñadirPro.TabIndex = 3
        Me.btnAñadirPro.Text = "Añadir"
        Me.btnAñadirPro.UseVisualStyleBackColor = True
        '
        'dgvProveedores
        '
        Me.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedores.Location = New System.Drawing.Point(29, 118)
        Me.dgvProveedores.Name = "dgvProveedores"
        Me.dgvProveedores.RowHeadersWidth = 62
        Me.dgvProveedores.RowTemplate.Height = 28
        Me.dgvProveedores.Size = New System.Drawing.Size(734, 296)
        Me.dgvProveedores.TabIndex = 4
        '
        'btnGenerarReportePro
        '
        Me.btnGenerarReportePro.Location = New System.Drawing.Point(280, 432)
        Me.btnGenerarReportePro.Name = "btnGenerarReportePro"
        Me.btnGenerarReportePro.Size = New System.Drawing.Size(207, 46)
        Me.btnGenerarReportePro.TabIndex = 5
        Me.btnGenerarReportePro.Text = "Generar reporte"
        Me.btnGenerarReportePro.UseVisualStyleBackColor = True
        '
        'Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 500)
        Me.Controls.Add(Me.btnGenerarReportePro)
        Me.Controls.Add(Me.dgvProveedores)
        Me.Controls.Add(Me.btnAñadirPro)
        Me.Controls.Add(Me.btnBuscarProveedores)
        Me.Controls.Add(Me.txtBuscarProveedores)
        Me.Name = "Proveedores"
        Me.Text = "Proveedores"
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscarProveedores As TextBox
    Friend WithEvents btnBuscarProveedores As Button
    Friend WithEvents btnAñadirPro As Button
    Friend WithEvents dgvProveedores As DataGridView
    Friend WithEvents btnGenerarReportePro As Button
End Class
