<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NuevoVenta
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
        Me.components = New System.ComponentModel.Container()
        Me.btnAñadirVen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPrecioUni = New System.Windows.Forms.Label()
        Me.lblIDdetalle = New System.Windows.Forms.Label()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.llblStockDisp = New System.Windows.Forms.LinkLabel()
        Me.dgvDetalleVenta = New System.Windows.Forms.DataGridView()
        Me.cmsEli = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFechaActual = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.cmbMetodoPago = New System.Windows.Forms.ComboBox()
        Me.btnGuardarSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.llblCliente = New System.Windows.Forms.LinkLabel()
        Me.lblNumVenta = New System.Windows.Forms.Label()
        Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTotalVenta2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesRec = New System.Windows.Forms.TextBox()
        Me.llblMetodoPago = New System.Windows.Forms.LinkLabel()
        Me.lblDR = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEli.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAñadirVen
        '
        Me.btnAñadirVen.Location = New System.Drawing.Point(63, 227)
        Me.btnAñadirVen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnAñadirVen.Name = "btnAñadirVen"
        Me.btnAñadirVen.Size = New System.Drawing.Size(130, 40)
        Me.btnAñadirVen.TabIndex = 0
        Me.btnAñadirVen.Text = "Añadir "
        Me.btnAñadirVen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Producto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ID detalle venta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPrecioUni)
        Me.GroupBox1.Controls.Add(Me.lblIDdetalle)
        Me.GroupBox1.Controls.Add(Me.lblStock)
        Me.GroupBox1.Controls.Add(Me.llblStockDisp)
        Me.GroupBox1.Controls.Add(Me.dgvDetalleVenta)
        Me.GroupBox1.Controls.Add(Me.lblSubtotal)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.cmbProducto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnAñadirVen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 92)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(640, 291)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paso 2. Detalle de venta"
        '
        'lblPrecioUni
        '
        Me.lblPrecioUni.AutoSize = True
        Me.lblPrecioUni.Location = New System.Drawing.Point(117, 154)
        Me.lblPrecioUni.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPrecioUni.Name = "lblPrecioUni"
        Me.lblPrecioUni.Size = New System.Drawing.Size(114, 13)
        Me.lblPrecioUni.TabIndex = 26
        Me.lblPrecioUni.Text = "(Seleccionar producto)"
        '
        'lblIDdetalle
        '
        Me.lblIDdetalle.AutoSize = True
        Me.lblIDdetalle.Location = New System.Drawing.Point(117, 90)
        Me.lblIDdetalle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIDdetalle.Name = "lblIDdetalle"
        Me.lblIDdetalle.Size = New System.Drawing.Size(123, 13)
        Me.lblIDdetalle.TabIndex = 25
        Me.lblIDdetalle.Text = "Numero de detalle venta"
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Location = New System.Drawing.Point(117, 58)
        Me.lblStock.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(114, 13)
        Me.lblStock.TabIndex = 16
        Me.lblStock.Text = "(Seleccionar producto)"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'llblStockDisp
        '
        Me.llblStockDisp.AutoSize = True
        Me.llblStockDisp.Location = New System.Drawing.Point(13, 58)
        Me.llblStockDisp.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.llblStockDisp.Name = "llblStockDisp"
        Me.llblStockDisp.Size = New System.Drawing.Size(88, 13)
        Me.llblStockDisp.TabIndex = 15
        Me.llblStockDisp.TabStop = True
        Me.llblStockDisp.Text = "Stock disponible:"
        '
        'dgvDetalleVenta
        '
        Me.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleVenta.ContextMenuStrip = Me.cmsEli
        Me.dgvDetalleVenta.Location = New System.Drawing.Point(289, 30)
        Me.dgvDetalleVenta.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dgvDetalleVenta.Name = "dgvDetalleVenta"
        Me.dgvDetalleVenta.RowHeadersWidth = 62
        Me.dgvDetalleVenta.RowTemplate.Height = 28
        Me.dgvDetalleVenta.Size = New System.Drawing.Size(322, 190)
        Me.dgvDetalleVenta.TabIndex = 13
        '
        'cmsEli
        '
        Me.cmsEli.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmsEli.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarDeToolStripMenuItem})
        Me.cmsEli.Name = "cmsEli"
        Me.cmsEli.Size = New System.Drawing.Size(156, 26)
        '
        'EliminarDeToolStripMenuItem
        '
        Me.EliminarDeToolStripMenuItem.Name = "EliminarDeToolStripMenuItem"
        Me.EliminarDeToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EliminarDeToolStripMenuItem.Text = "Eliminar detalle"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(115, 194)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(28, 13)
        Me.lblSubtotal.TabIndex = 12
        Me.lblSubtotal.Text = "0.00"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(115, 119)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(128, 20)
        Me.txtCantidad.TabIndex = 10
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(117, 25)
        Me.cmbProducto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(128, 21)
        Me.cmbProducto.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 194)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Subtotal:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 154)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Precio unitario:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cantidad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 36)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Num. de venta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(62, 36)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Fecha de venta:"
        '
        'lblFechaActual
        '
        Me.lblFechaActual.AutoSize = True
        Me.lblFechaActual.Location = New System.Drawing.Point(166, 36)
        Me.lblFechaActual.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFechaActual.Name = "lblFechaActual"
        Me.lblFechaActual.Size = New System.Drawing.Size(91, 13)
        Me.lblFechaActual.TabIndex = 15
        Me.lblFechaActual.Text = "00-00-0000 00.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(411, 64)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Total bruto:"
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.AutoSize = True
        Me.lblTotalVenta.Location = New System.Drawing.Point(496, 64)
        Me.lblTotalVenta.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(28, 13)
        Me.lblTotalVenta.TabIndex = 17
        Me.lblTotalVenta.Text = "0.00"
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.FormattingEnabled = True
        Me.cmbMetodoPago.Location = New System.Drawing.Point(169, 61)
        Me.cmbMetodoPago.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(128, 21)
        Me.cmbMetodoPago.TabIndex = 13
        '
        'btnGuardarSalir
        '
        Me.btnGuardarSalir.Location = New System.Drawing.Point(255, 139)
        Me.btnGuardarSalir.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnGuardarSalir.Name = "btnGuardarSalir"
        Me.btnGuardarSalir.Size = New System.Drawing.Size(130, 40)
        Me.btnGuardarSalir.TabIndex = 13
        Me.btnGuardarSalir.Text = "Guardar y salir"
        Me.btnGuardarSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(467, 22)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(130, 40)
        Me.btnGuardar.TabIndex = 21
        Me.btnGuardar.Text = "Guardar y siguiente"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.llblCliente)
        Me.GroupBox2.Controls.Add(Me.lblNumVenta)
        Me.GroupBox2.Controls.Add(Me.cmbIdCliente)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 18)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(640, 70)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paso 1"
        '
        'llblCliente
        '
        Me.llblCliente.AutoSize = True
        Me.llblCliente.Location = New System.Drawing.Point(242, 32)
        Me.llblCliente.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.llblCliente.Name = "llblCliente"
        Me.llblCliente.Size = New System.Drawing.Size(42, 13)
        Me.llblCliente.TabIndex = 24
        Me.llblCliente.TabStop = True
        Me.llblCliente.Text = "Cliente:"
        '
        'lblNumVenta
        '
        Me.lblNumVenta.AutoSize = True
        Me.lblNumVenta.Location = New System.Drawing.Point(106, 36)
        Me.lblNumVenta.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNumVenta.Name = "lblNumVenta"
        Me.lblNumVenta.Size = New System.Drawing.Size(89, 13)
        Me.lblNumVenta.TabIndex = 23
        Me.lblNumVenta.Text = "Numero de venta"
        '
        'cmbIdCliente
        '
        Me.cmbIdCliente.FormattingEnabled = True
        Me.cmbIdCliente.Location = New System.Drawing.Point(301, 31)
        Me.cmbIdCliente.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbIdCliente.Name = "cmbIdCliente"
        Me.cmbIdCliente.Size = New System.Drawing.Size(128, 21)
        Me.cmbIdCliente.TabIndex = 22
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.lblTotalVenta2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtDesRec)
        Me.GroupBox3.Controls.Add(Me.llblMetodoPago)
        Me.GroupBox3.Controls.Add(Me.lblDR)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.lblFechaActual)
        Me.GroupBox3.Controls.Add(Me.btnGuardarSalir)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cmbMetodoPago)
        Me.GroupBox3.Controls.Add(Me.lblTotalVenta)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 396)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(640, 189)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Paso 3"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(411, 114)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Total neto:"
        '
        'lblTotalVenta2
        '
        Me.lblTotalVenta2.AutoSize = True
        Me.lblTotalVenta2.Location = New System.Drawing.Point(496, 114)
        Me.lblTotalVenta2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotalVenta2.Name = "lblTotalVenta2"
        Me.lblTotalVenta2.Size = New System.Drawing.Size(28, 13)
        Me.lblTotalVenta2.TabIndex = 23
        Me.lblTotalVenta2.Text = "0.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(377, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "% Desc. o recargo:"
        '
        'txtDesRec
        '
        Me.txtDesRec.Location = New System.Drawing.Point(485, 36)
        Me.txtDesRec.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtDesRec.Name = "txtDesRec"
        Me.txtDesRec.Size = New System.Drawing.Size(39, 20)
        Me.txtDesRec.TabIndex = 21
        '
        'llblMetodoPago
        '
        Me.llblMetodoPago.AutoSize = True
        Me.llblMetodoPago.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llblMetodoPago.Location = New System.Drawing.Point(65, 64)
        Me.llblMetodoPago.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.llblMetodoPago.Name = "llblMetodoPago"
        Me.llblMetodoPago.Size = New System.Drawing.Size(88, 13)
        Me.llblMetodoPago.TabIndex = 20
        Me.llblMetodoPago.TabStop = True
        Me.llblMetodoPago.Text = "Metodo de pago:"
        '
        'lblDR
        '
        Me.lblDR.AutoSize = True
        Me.lblDR.Location = New System.Drawing.Point(433, 89)
        Me.lblDR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDR.Name = "lblDR"
        Me.lblDR.Size = New System.Drawing.Size(92, 13)
        Me.lblDR.TabIndex = 19
        Me.lblDR.Text = "Descuento: - 0.00"
        '
        'NuevoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 589)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "NuevoVenta"
        Me.Text = "Venta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEli.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAñadirVen As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFechaActual As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTotalVenta As Label
    Friend WithEvents btnGuardarSalir As Button
    Friend WithEvents cmbMetodoPago As ComboBox
    Friend WithEvents dgvDetalleVenta As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbIdCliente As ComboBox
    Friend WithEvents cmsEli As ContextMenuStrip
    Friend WithEvents EliminarDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStock As Label
    Friend WithEvents llblStockDisp As LinkLabel
    Friend WithEvents lblNumVenta As Label
    Friend WithEvents llblCliente As LinkLabel
    Friend WithEvents lblIDdetalle As Label
    Friend WithEvents lblPrecioUni As Label
    Friend WithEvents lblDR As Label
    Friend WithEvents llblMetodoPago As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDesRec As TextBox
    Friend WithEvents lblTotalVenta2 As Label
    Friend WithEvents Label10 As Label
End Class
