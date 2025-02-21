<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoVenta
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
        Me.btnAñadirVen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumVenta = New System.Windows.Forms.TextBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.txtIDdetalle = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecioUni = New System.Windows.Forms.TextBox()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumVenta2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFechaActual = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbMetodoPago = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnGuardarSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAñadirVen
        '
        Me.btnAñadirVen.Location = New System.Drawing.Point(94, 359)
        Me.btnAñadirVen.Name = "btnAñadirVen"
        Me.btnAñadirVen.Size = New System.Drawing.Size(195, 61)
        Me.btnAñadirVen.TabIndex = 0
        Me.btnAñadirVen.Text = "Añadir "
        Me.btnAñadirVen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Num. de venta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Producto:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ID detalle venta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSubtotal)
        Me.GroupBox1.Controls.Add(Me.txtPrecioUni)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.txtIDdetalle)
        Me.GroupBox1.Controls.Add(Me.cmbProducto)
        Me.GroupBox1.Controls.Add(Me.txtNumVenta)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnAñadirVen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 448)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de venta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cantidad:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Precio unitario:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 298)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Subtotal:"
        '
        'txtNumVenta
        '
        Me.txtNumVenta.Location = New System.Drawing.Point(172, 46)
        Me.txtNumVenta.Name = "txtNumVenta"
        Me.txtNumVenta.Size = New System.Drawing.Size(190, 26)
        Me.txtNumVenta.TabIndex = 7
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(172, 86)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(190, 28)
        Me.cmbProducto.TabIndex = 8
        '
        'txtIDdetalle
        '
        Me.txtIDdetalle.Location = New System.Drawing.Point(172, 138)
        Me.txtIDdetalle.Name = "txtIDdetalle"
        Me.txtIDdetalle.Size = New System.Drawing.Size(190, 26)
        Me.txtIDdetalle.TabIndex = 9
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(172, 183)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(190, 26)
        Me.txtCantidad.TabIndex = 10
        '
        'txtPrecioUni
        '
        Me.txtPrecioUni.Location = New System.Drawing.Point(172, 231)
        Me.txtPrecioUni.Name = "txtPrecioUni"
        Me.txtPrecioUni.Size = New System.Drawing.Size(190, 26)
        Me.txtPrecioUni.TabIndex = 11
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(172, 298)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(40, 20)
        Me.lblSubtotal.TabIndex = 12
        Me.lblSubtotal.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(552, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 20)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Num. de venta:"
        '
        'txtNumVenta2
        '
        Me.txtNumVenta2.Location = New System.Drawing.Point(708, 41)
        Me.txtNumVenta2.Name = "txtNumVenta2"
        Me.txtNumVenta2.Size = New System.Drawing.Size(190, 26)
        Me.txtNumVenta2.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(552, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Fecha de venta:"
        '
        'lblFechaActual
        '
        Me.lblFechaActual.AutoSize = True
        Me.lblFechaActual.Location = New System.Drawing.Point(708, 106)
        Me.lblFechaActual.Name = "lblFechaActual"
        Me.lblFechaActual.Size = New System.Drawing.Size(135, 20)
        Me.lblFechaActual.TabIndex = 15
        Me.lblFechaActual.Text = "00-00-0000 00.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(552, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Total de venta:"
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.AutoSize = True
        Me.lblTotalVenta.Location = New System.Drawing.Point(708, 220)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(40, 20)
        Me.lblTotalVenta.TabIndex = 17
        Me.lblTotalVenta.Text = "0.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(552, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 20)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Metodo de pago:"
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.FormattingEnabled = True
        Me.cmbMetodoPago.Location = New System.Drawing.Point(708, 268)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(190, 28)
        Me.cmbMetodoPago.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(567, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 20)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(708, 161)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(190, 26)
        Me.txtCliente.TabIndex = 20
        '
        'btnGuardarSalir
        '
        Me.btnGuardarSalir.Location = New System.Drawing.Point(648, 371)
        Me.btnGuardarSalir.Name = "btnGuardarSalir"
        Me.btnGuardarSalir.Size = New System.Drawing.Size(195, 61)
        Me.btnGuardarSalir.TabIndex = 13
        Me.btnGuardarSalir.Text = "Guardar y salir"
        Me.btnGuardarSalir.UseVisualStyleBackColor = True
        '
        'NuevoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 495)
        Me.Controls.Add(Me.btnGuardarSalir)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbMetodoPago)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblTotalVenta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblFechaActual)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNumVenta2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "NuevoVenta"
        Me.Text = "Venta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAñadirVen As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents txtPrecioUni As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtIDdetalle As TextBox
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents txtNumVenta As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNumVenta2 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFechaActual As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTotalVenta As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents btnGuardarSalir As Button
    Friend WithEvents cmbMetodoPago As ComboBox
End Class
