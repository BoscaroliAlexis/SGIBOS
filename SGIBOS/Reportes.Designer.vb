<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.cmbOrden = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.btnExportarPDF = New System.Windows.Forms.Button()
        Me.btnExportarCSV = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(78, 179)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(181, 28)
        Me.cmbTipo.TabIndex = 0
        '
        'cmbOrden
        '
        Me.cmbOrden.FormattingEnabled = True
        Me.cmbOrden.Location = New System.Drawing.Point(302, 179)
        Me.cmbOrden.Name = "cmbOrden"
        Me.cmbOrden.Size = New System.Drawing.Size(181, 28)
        Me.cmbOrden.TabIndex = 1
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(531, 179)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(181, 28)
        Me.cmbPeriodo.TabIndex = 2
        '
        'btnExportarPDF
        '
        Me.btnExportarPDF.Location = New System.Drawing.Point(163, 307)
        Me.btnExportarPDF.Name = "btnExportarPDF"
        Me.btnExportarPDF.Size = New System.Drawing.Size(173, 74)
        Me.btnExportarPDF.TabIndex = 3
        Me.btnExportarPDF.Text = "Exportar a PDF"
        Me.btnExportarPDF.UseVisualStyleBackColor = True
        '
        'btnExportarCSV
        '
        Me.btnExportarCSV.Location = New System.Drawing.Point(447, 307)
        Me.btnExportarCSV.Name = "btnExportarCSV"
        Me.btnExportarCSV.Size = New System.Drawing.Size(173, 74)
        Me.btnExportarCSV.TabIndex = 4
        Me.btnExportarCSV.Text = "Exportar a CSV"
        Me.btnExportarCSV.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tipo de reporte:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(370, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Orden:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(586, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Periodo:"
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExportarCSV)
        Me.Controls.Add(Me.btnExportarPDF)
        Me.Controls.Add(Me.cmbPeriodo)
        Me.Controls.Add(Me.cmbOrden)
        Me.Controls.Add(Me.cmbTipo)
        Me.Name = "Reportes"
        Me.Text = "Reportes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents cmbOrden As ComboBox
    Friend WithEvents cmbPeriodo As ComboBox
    Friend WithEvents btnExportarPDF As Button
    Friend WithEvents btnExportarCSV As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
