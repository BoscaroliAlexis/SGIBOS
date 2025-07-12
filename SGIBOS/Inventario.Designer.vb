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
        CType(Me.dgvInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActEli2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscarInventario
        '
        Me.txtBuscarInventario.Location = New System.Drawing.Point(38, 41)
        Me.txtBuscarInventario.Multiline = True
        Me.txtBuscarInventario.Name = "txtBuscarInventario"
        Me.txtBuscarInventario.Size = New System.Drawing.Size(334, 48)
        Me.txtBuscarInventario.TabIndex = 2
        '
        'btnBuscarInventario
        '
        Me.btnBuscarInventario.Location = New System.Drawing.Point(392, 41)
        Me.btnBuscarInventario.Name = "btnBuscarInventario"
        Me.btnBuscarInventario.Size = New System.Drawing.Size(92, 48)
        Me.btnBuscarInventario.TabIndex = 3
        Me.btnBuscarInventario.Text = "Buscar"
        Me.btnBuscarInventario.UseVisualStyleBackColor = True
        '
        'btnAñadirInv
        '
        Me.btnAñadirInv.Location = New System.Drawing.Point(505, 41)
        Me.btnAñadirInv.Name = "btnAñadirInv"
        Me.btnAñadirInv.Size = New System.Drawing.Size(92, 48)
        Me.btnAñadirInv.TabIndex = 4
        Me.btnAñadirInv.Text = "Añadir"
        Me.btnAñadirInv.UseVisualStyleBackColor = True
        '
        'dgvInventario
        '
        Me.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventario.Location = New System.Drawing.Point(30, 114)
        Me.dgvInventario.Name = "dgvInventario"
        Me.dgvInventario.RowHeadersWidth = 62
        Me.dgvInventario.RowTemplate.Height = 28
        Me.dgvInventario.Size = New System.Drawing.Size(734, 296)
        Me.dgvInventario.TabIndex = 5
        '
        'btnGenerarReporteInv
        '
        Me.btnGenerarReporteInv.Location = New System.Drawing.Point(287, 432)
        Me.btnGenerarReporteInv.Name = "btnGenerarReporteInv"
        Me.btnGenerarReporteInv.Size = New System.Drawing.Size(207, 46)
        Me.btnGenerarReporteInv.TabIndex = 6
        Me.btnGenerarReporteInv.Text = "Generar reporte"
        Me.btnGenerarReporteInv.UseVisualStyleBackColor = True
        '
        'cmsActEli2
        '
        Me.cmsActEli2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmsActEli2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmsActEli2.Name = "cmsActEli2"
        Me.cmsActEli2.Size = New System.Drawing.Size(161, 68)
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(160, 32)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(160, 32)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'btnGesCat
        '
        Me.btnGesCat.Location = New System.Drawing.Point(612, 41)
        Me.btnGesCat.Name = "btnGesCat"
        Me.btnGesCat.Size = New System.Drawing.Size(171, 48)
        Me.btnGesCat.TabIndex = 8
        Me.btnGesCat.Text = "Gestionar categorias"
        Me.btnGesCat.UseVisualStyleBackColor = True
        '
        'Inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 501)
        Me.Controls.Add(Me.btnGesCat)
        Me.Controls.Add(Me.btnGenerarReporteInv)
        Me.Controls.Add(Me.dgvInventario)
        Me.Controls.Add(Me.btnAñadirInv)
        Me.Controls.Add(Me.btnBuscarInventario)
        Me.Controls.Add(Me.txtBuscarInventario)
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
End Class
