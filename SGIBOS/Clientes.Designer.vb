<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clientes
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
        Me.components = New System.ComponentModel.Container()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.btnGenerarReporteCli = New System.Windows.Forms.Button()
        Me.btnAñadirCli = New System.Windows.Forms.Button()
        Me.cmsActElim = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActElim.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.Location = New System.Drawing.Point(64, 71)
        Me.txtBuscarCliente.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtBuscarCliente.Multiline = True
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.Size = New System.Drawing.Size(863, 72)
        Me.txtBuscarCliente.TabIndex = 0
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Location = New System.Drawing.Point(976, 71)
        Me.btnBuscarCliente.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(164, 74)
        Me.btnBuscarCliente.TabIndex = 1
        Me.btnBuscarCliente.Text = "Buscar"
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'dgvClientes
        '
        Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientes.Location = New System.Drawing.Point(64, 208)
        Me.dgvClientes.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.RowHeadersWidth = 62
        Me.dgvClientes.RowTemplate.Height = 28
        Me.dgvClientes.Size = New System.Drawing.Size(1276, 459)
        Me.dgvClientes.TabIndex = 2
        '
        'btnGenerarReporteCli
        '
        Me.btnGenerarReporteCli.Location = New System.Drawing.Point(498, 694)
        Me.btnGenerarReporteCli.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnGenerarReporteCli.Name = "btnGenerarReporteCli"
        Me.btnGenerarReporteCli.Size = New System.Drawing.Size(368, 71)
        Me.btnGenerarReporteCli.TabIndex = 3
        Me.btnGenerarReporteCli.Text = "Generar reporte"
        Me.btnGenerarReporteCli.UseVisualStyleBackColor = True
        '
        'btnAñadirCli
        '
        Me.btnAñadirCli.Location = New System.Drawing.Point(1177, 71)
        Me.btnAñadirCli.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnAñadirCli.Name = "btnAñadirCli"
        Me.btnAñadirCli.Size = New System.Drawing.Size(164, 74)
        Me.btnAñadirCli.TabIndex = 4
        Me.btnAñadirCli.Text = "Añadir"
        Me.btnAñadirCli.UseVisualStyleBackColor = True
        '
        'cmsActElim
        '
        Me.cmsActElim.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmsActElim.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmsActElim.Name = "cmsActElim"
        Me.cmsActElim.Size = New System.Drawing.Size(225, 100)
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(224, 48)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(224, 48)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1422, 800)
        Me.Controls.Add(Me.btnAñadirCli)
        Me.Controls.Add(Me.btnGenerarReporteCli)
        Me.Controls.Add(Me.dgvClientes)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.txtBuscarCliente)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "Clientes"
        Me.Text = "Clientes"
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActElim.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscarCliente As TextBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents btnGenerarReporteCli As Button
    Friend WithEvents btnAñadirCli As Button
    Friend WithEvents cmsActElim As ContextMenuStrip
    Friend WithEvents ActualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
End Class
