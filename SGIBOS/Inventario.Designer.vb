<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario
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
        Me.txtBuscarInventario = New System.Windows.Forms.TextBox()
        Me.btnBuscarInventario = New System.Windows.Forms.Button()
        Me.btnAñadirInv = New System.Windows.Forms.Button()
        Me.dgvInventario = New System.Windows.Forms.DataGridView()
        Me.btnGenerarReporteInv = New System.Windows.Forms.Button()
        Me.cmsActEli2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGesCat = New System.Windows.Forms.Button()
        Me.btnReporteStock = New System.Windows.Forms.Button()
        Me.btnConfigurarReporte = New System.Windows.Forms.Button()
        CType(Me.dgvInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActEli2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscarInventario
        '
        Me.txtBuscarInventario.Location = New System.Drawing.Point(25, 27)
        Me.txtBuscarInventario.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBuscarInventario.Multiline = True
        Me.txtBuscarInventario.Name = "txtBuscarInventario"
        Me.txtBuscarInventario.Size = New System.Drawing.Size(224, 33)
        Me.txtBuscarInventario.TabIndex = 2
        '
        'btnBuscarInventario
        '
        Me.btnBuscarInventario.Location = New System.Drawing.Point(261, 27)
        Me.btnBuscarInventario.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBuscarInventario.Name = "btnBuscarInventario"
        Me.btnBuscarInventario.Size = New System.Drawing.Size(61, 31)
        Me.btnBuscarInventario.TabIndex = 3
        Me.btnBuscarInventario.Text = "Buscar"
        Me.btnBuscarInventario.UseVisualStyleBackColor = True
        '
        'btnAñadirInv
        '
        Me.btnAñadirInv.Location = New System.Drawing.Point(337, 27)
        Me.btnAñadirInv.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAñadirInv.Name = "btnAñadirInv"
        Me.btnAñadirInv.Size = New System.Drawing.Size(61, 31)
        Me.btnAñadirInv.TabIndex = 4
        Me.btnAñadirInv.Text = "Añadir"
        Me.btnAñadirInv.UseVisualStyleBackColor = True
        '
        'dgvInventario
        '
        Me.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventario.Location = New System.Drawing.Point(20, 74)
        Me.dgvInventario.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvInventario.Name = "dgvInventario"
        Me.dgvInventario.RowHeadersWidth = 62
        Me.dgvInventario.RowTemplate.Height = 28
        Me.dgvInventario.Size = New System.Drawing.Size(489, 192)
        Me.dgvInventario.TabIndex = 5
        '
        'btnGenerarReporteInv
        '
        Me.btnGenerarReporteInv.Location = New System.Drawing.Point(191, 281)
        Me.btnGenerarReporteInv.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGenerarReporteInv.Name = "btnGenerarReporteInv"
        Me.btnGenerarReporteInv.Size = New System.Drawing.Size(138, 30)
        Me.btnGenerarReporteInv.TabIndex = 6
        Me.btnGenerarReporteInv.Text = "Generar reporte"
        Me.btnGenerarReporteInv.UseVisualStyleBackColor = True
        '
        'cmsActEli2
        '
        Me.cmsActEli2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmsActEli2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmsActEli2.Name = "cmsActEli2"
        Me.cmsActEli2.Size = New System.Drawing.Size(127, 48)
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'btnGesCat
        '
        Me.btnGesCat.Location = New System.Drawing.Point(408, 27)
        Me.btnGesCat.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGesCat.Name = "btnGesCat"
        Me.btnGesCat.Size = New System.Drawing.Size(114, 31)
        Me.btnGesCat.TabIndex = 8
        Me.btnGesCat.Text = "Gestionar categorias"
        Me.btnGesCat.UseVisualStyleBackColor = True
        '
        'btnReporteStock
        '
        Me.btnReporteStock.Location = New System.Drawing.Point(538, 97)
        Me.btnReporteStock.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReporteStock.Name = "btnReporteStock"
        Me.btnReporteStock.Size = New System.Drawing.Size(73, 55)
        Me.btnReporteStock.TabIndex = 9
        Me.btnReporteStock.Text = "Listado de productos faltantes"
        Me.btnReporteStock.UseVisualStyleBackColor = True
        '
        'btnConfigurarReporte
        '
        Me.btnConfigurarReporte.Location = New System.Drawing.Point(538, 167)
        Me.btnConfigurarReporte.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfigurarReporte.Name = "btnConfigurarReporte"
        Me.btnConfigurarReporte.Size = New System.Drawing.Size(73, 55)
        Me.btnConfigurarReporte.TabIndex = 10
        Me.btnConfigurarReporte.Text = "Configurar stock mínimo"
        Me.btnConfigurarReporte.UseVisualStyleBackColor = True
        '
        'Inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 326)
        Me.Controls.Add(Me.btnConfigurarReporte)
        Me.Controls.Add(Me.btnReporteStock)
        Me.Controls.Add(Me.btnGesCat)
        Me.Controls.Add(Me.btnGenerarReporteInv)
        Me.Controls.Add(Me.dgvInventario)
        Me.Controls.Add(Me.btnAñadirInv)
        Me.Controls.Add(Me.btnBuscarInventario)
        Me.Controls.Add(Me.txtBuscarInventario)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Inventario"
        Me.Text = "Inventario"
        CType(Me.dgvInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActEli2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscarInventario As TextBox
    Friend WithEvents btnBuscarInventario As Button
    Friend WithEvents btnAñadirInv As Button
    Friend WithEvents dgvInventario As DataGridView
    Friend WithEvents btnGenerarReporteInv As Button
    Friend WithEvents cmsActEli2 As ContextMenuStrip
    Friend WithEvents ActualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnGesCat As Button
    Friend WithEvents btnReporteStock As Button
    Friend WithEvents btnConfigurarReporte As Button
End Class
