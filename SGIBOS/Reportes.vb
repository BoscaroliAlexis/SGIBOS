Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

' Clase Reportes que permite generar reportes en formatos PDF y CSV
Public Class Reportes

    Private cadenaConexion As String = "Server=localhost;Database=tiendadb;Uid=root;Pwd=mysql;"

    ' Variables que contienen los datos de los clientes, proveedores, productos y ventas
    Private dtClientes As DataTable = New DataTable()
    Private dtProveedores As DataTable = New DataTable()
    Private dtProductos As DataTable = New DataTable()
    Private dtVentas As DataTable = New DataTable()

    ' Constructor de la clase Reportes que recibe los datos de los diferentes tipos de reportes (opcionalmente)
    Public Sub New(ByVal datosClientes As DataTable, Optional ByVal datosProveedores As DataTable = Nothing, Optional ByVal datosProductos As DataTable = Nothing, Optional ByVal datosVentas As DataTable = Nothing)
        InitializeComponent() ' Inicializa los componentes de la interfaz de usuario
        dtClientes = datosClientes
        dtProveedores = datosProveedores
        dtProductos = datosProductos
        dtVentas = datosVentas
    End Sub

    ' Evento que se dispara cuando se carga el formulario
    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloVisual.AplicarTemaFormulario(Me)


        ' Añade las opciones de tipo de reporte al ComboBox
        cmbTipo.Items.AddRange(New String() {"Inventario", "Ventas", "Clientes", "Proveedores"})
        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList ' Configura el ComboBox para que solo se pueda seleccionar un elemento de la lista
        cmbTipo.SelectedIndex = 0 ' Establece "Inventario" como la opción por defecto
    End Sub

    ' Evento que se dispara cuando se hace clic en el botón para exportar a PDF
    Private Sub btnExportarPDF_Click(sender As Object, e As EventArgs) Handles btnExportarPDF.Click
        Dim dataTable As New DataTable()
        Dim tituloReporte As String = ""
        Dim nombreArchivo As String = ""
        Dim consulta As String = ""

        Select Case cmbTipo.SelectedItem.ToString()
            Case "Clientes"
                dataTable = dtClientes
                tituloReporte = "Reporte de Clientes"
                nombreArchivo = "Reporte_Clientes.pdf"
            Case "Proveedores"
                dataTable = dtProveedores
                tituloReporte = "Reporte de Proveedores"
                nombreArchivo = "Reporte_Proveedores.pdf"
            Case "Inventario"
                consulta = "
                SELECT p.id_producto AS ID, p.nombre AS Producto, p.precio, p.cantidad_stock AS Stock, c.nombre AS Categoria
                FROM productos p
                INNER JOIN categorias c ON p.id_categoria = c.id_categoria"
                tituloReporte = "Reporte de Inventario"
                nombreArchivo = "Reporte_Inventario.pdf"
            Case "Ventas"
                consulta = "
            SELECT v.id_venta AS 'ID Venta', v.fecha_venta AS 'Fecha', c.nombre AS 'Cliente', 
                   v.total_venta AS 'Total', v.metodo_pago AS 'Método de Pago', u.nombre AS 'Vendedor'
            FROM Ventas v
            INNER JOIN Clientes c ON v.id_cliente = c.id_cliente
            INNER JOIN Usuarios u ON v.id_usuario = u.id_usuario"
                tituloReporte = "Reporte de Ventas"
                nombreArchivo = "Reporte_Ventas.pdf"
            Case Else
                MessageBox.Show("Seleccione un tipo de reporte válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
        End Select

        ' Si corresponde hacer una consulta, la ejecutamos
        If consulta <> "" Then
            Try
                Using conn As New MySqlConnection(cadenaConexion)
                    conn.Open()
                    Using cmd As New MySqlCommand(consulta, conn)
                        Using da As New MySqlDataAdapter(cmd)
                            da.Fill(dataTable)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al obtener los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        ' Verifica si hay datos
        If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Cuadro de diálogo para guardar
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivo PDF|*.pdf"
        saveFileDialog.Title = "Guardar Reporte PDF"
        saveFileDialog.FileName = nombreArchivo

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim doc As New Document(PageSize.A4)
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveFileDialog.FileName, FileMode.Create))
                doc.Open()

                Dim titulo As New Paragraph(tituloReporte & vbCrLf & vbCrLf, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK))
                titulo.Alignment = Element.ALIGN_CENTER
                doc.Add(titulo)

                Dim pdfTable As New PdfPTable(dataTable.Columns.Count)
                pdfTable.WidthPercentage = 100

                ' Encabezados
                For Each column As DataColumn In dataTable.Columns
                    Dim cell As New PdfPCell(New Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE)))
                    cell.BackgroundColor = BaseColor.DARK_GRAY
                    pdfTable.AddCell(cell)
                Next

                ' Filas
                For Each row As DataRow In dataTable.Rows
                    For Each item In row.ItemArray
                        pdfTable.AddCell(New Phrase(item.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK)))
                    Next
                Next

                doc.Add(pdfTable)
                doc.Close()

                MessageBox.Show("PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error al generar el PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    ' Evento que se dispara cuando se hace clic en el botón para exportar a CSV
    Private Sub btnExportarCSV_Click(sender As Object, e As EventArgs) Handles btnExportarCSV.Click
        Dim tablaSeleccionada As String = ""
        Dim nombreArchivo As String = ""
        Dim query As String = ""

        ' Determina el tipo de tabla seleccionada
        Select Case cmbTipo.SelectedItem.ToString()
            Case "Inventario"
                tablaSeleccionada = "Productos"
                nombreArchivo = "reporte_inventario.csv"
            Case "Clientes"
                tablaSeleccionada = "Clientes"
                nombreArchivo = "reporte_clientes.csv"
            Case "Proveedores"
                tablaSeleccionada = "Proveedores"
                nombreArchivo = "reporte_proveedores.csv"
            Case "Ventas"
                tablaSeleccionada = "Ventas"
                nombreArchivo = "reporte_ventas.csv"
            Case Else
                MessageBox.Show("Por favor, selecciona una opción válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
        End Select

        ' Genera la consulta SQL según la tabla seleccionada
        Select Case tablaSeleccionada
            Case "Productos"
                query = "SELECT p.id_producto, p.nombre_producto, c.nombre_categoria AS categoria, p.precio_unitario, p.cantidad_stock " &
                        "FROM Productos p " &
                        "LEFT JOIN Categorias c ON p.id_categoria = c.id_categoria"
            Case "Ventas"
                query = "SELECT v.id_venta, v.fecha_venta, c.nombre_cliente, u.nombre_usuario, v.total_venta " &
                        "FROM Ventas v " &
                        "LEFT JOIN Clientes c ON v.id_cliente = c.id_cliente " &
                        "LEFT JOIN Usuarios u ON v.id_usuario = u.id_usuario"
            Case Else
                query = "SELECT * FROM " & tablaSeleccionada
        End Select

        ' Diálogo para guardar el archivo CSV
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "Archivos CSV (*.csv)|*.csv"
        saveDialog.Title = "Guardar archivo CSV"
        saveDialog.FileName = nombreArchivo

        If saveDialog.ShowDialog() = DialogResult.OK Then
            Dim savePath As String = saveDialog.FileName
            Try
                Using conn As New MySqlConnection(cadenaConexion)
                    conn.Open()
                    Using cmd As New MySqlCommand(query, conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                Using writer As New StreamWriter(savePath, False, System.Text.Encoding.UTF8)
                                    Dim columnCount As Integer = reader.FieldCount
                                    Dim header As String = ""
                                    For i As Integer = 0 To columnCount - 1
                                        header &= reader.GetName(i) & If(i < columnCount - 1, ",", "")
                                    Next
                                    writer.WriteLine(header)

                                    While reader.Read()
                                        Dim row As String = ""
                                        For i As Integer = 0 To columnCount - 1
                                            row &= reader(i).ToString().Replace(",", ";") & If(i < columnCount - 1, ",", "")
                                        Next
                                        writer.WriteLine(row)
                                    End While
                                End Using
                                MessageBox.Show("Datos exportados correctamente a: " & savePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                ' Abre el archivo automáticamente si existe
                                If File.Exists(savePath) Then
                                    Process.Start(savePath)
                                End If
                            Else
                                MessageBox.Show("No hay datos en la tabla " & tablaSeleccionada & ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


End Class
