<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Categorias
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
        Me.txtBuscarCat = New System.Windows.Forms.TextBox()
        Me.btnBuscarCat = New System.Windows.Forms.Button()
        Me.btnAñadirCat = New System.Windows.Forms.Button()
        Me.dgvCategorias = New System.Windows.Forms.DataGridView()
        Me.cmsActEli3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsActEli3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscarCat
        '
        Me.txtBuscarCat.Location = New System.Drawing.Point(35, 42)
        Me.txtBuscarCat.Multiline = True
        Me.txtBuscarCat.Name = "txtBuscarCat"
        Me.txtBuscarCat.Size = New System.Drawing.Size(481, 48)
        Me.txtBuscarCat.TabIndex = 3
        '
        'btnBuscarCat
        '
        Me.btnBuscarCat.Location = New System.Drawing.Point(546, 42)
        Me.btnBuscarCat.Name = "btnBuscarCat"
        Me.btnBuscarCat.Size = New System.Drawing.Size(92, 48)
        Me.btnBuscarCat.TabIndex = 4
        Me.btnBuscarCat.Text = "Buscar"
        Me.btnBuscarCat.UseVisualStyleBackColor = True
        '
        'btnAñadirCat
        '
        Me.btnAñadirCat.Location = New System.Drawing.Point(662, 42)
        Me.btnAñadirCat.Name = "btnAñadirCat"
        Me.btnAñadirCat.Size = New System.Drawing.Size(92, 48)
        Me.btnAñadirCat.TabIndex = 5
        Me.btnAñadirCat.Text = "Añadir"
        Me.btnAñadirCat.UseVisualStyleBackColor = True
        '
        'dgvCategorias
        '
        Me.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategorias.Location = New System.Drawing.Point(35, 122)
        Me.dgvCategorias.Name = "dgvCategorias"
        Me.dgvCategorias.RowHeadersWidth = 62
        Me.dgvCategorias.RowTemplate.Height = 28
        Me.dgvCategorias.Size = New System.Drawing.Size(719, 296)
        Me.dgvCategorias.TabIndex = 6
        '
        'cmsActEli3
        '
        Me.cmsActEli3.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmsActEli3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmsActEli3.Name = "cmsActEli3"
        Me.cmsActEli3.Size = New System.Drawing.Size(241, 101)
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(240, 32)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(240, 32)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'Categorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvCategorias)
        Me.Controls.Add(Me.btnAñadirCat)
        Me.Controls.Add(Me.btnBuscarCat)
        Me.Controls.Add(Me.txtBuscarCat)
        Me.Name = "Categorias"
        Me.Text = "Categorias"
        CType(Me.dgvCategorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsActEli3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtBuscarCat As TextBox
    Friend WithEvents btnBuscarCat As Button
    Friend WithEvents btnAñadirCat As Button
    Friend WithEvents dgvCategorias As DataGridView
    Friend WithEvents cmsActEli3 As ContextMenuStrip
    Friend WithEvents ActualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
End Class
