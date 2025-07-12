Imports System.IO
Imports System.Net


Public Module ModuloVisual
    ' Definición de colores personalizados para la interfaz
    Public ColorFondo As Color = Color.FromArgb(249, 243, 255)       ' Color de fondo: blanco cálido
    Public ColorBotonFondo As Color = Color.FromArgb(155, 89, 182)   ' Color de fondo para botones: violeta medio
    Public ColorBotonTexto As Color = Color.White                    ' Color del texto en botones: blanco
    Public ColorLink As Color = Color.FromArgb(241, 91, 181)         ' Color para enlaces (LinkLabel): rosa intenso
    Public ColorTexto As Color = Color.Black                         ' Color general del texto: negro

    ' Procedimiento público que aplica el tema de colores al formulario y a todos sus controles
    Public Sub AplicarTemaFormulario(form As Form)
        ' Cambia el color de fondo del formulario
        form.BackColor = ColorFondo

        ' Aplica el tema a todos los controles contenidos en el formulario
        AplicarTemaAControles(form)

        ' Establece el ícono del formulario
        ' El archivo "icono.ico" debe estar ubicado en la carpeta bin\Debug del proyecto
        form.Icon = New Icon(Application.StartupPath & "\icono.ico")
    End Sub

    ' Procedimiento privado que aplica estilos a todos los controles dentro de un contenedor dado (puede ser un formulario o cualquier control contenedor)
    Private Sub AplicarTemaAControles(contenedor As Control)
        ' Recorre cada control dentro del contenedor
        For Each ctrl As Control In contenedor.Controls
            ' Evalúa el tipo de control para aplicar el estilo correspondiente
            Select Case True
                Case TypeOf ctrl Is Label
                    ' Para etiquetas (Label), cambia el color del texto
                    ctrl.ForeColor = ColorTexto

                Case TypeOf ctrl Is LinkLabel
                    ' Para enlaces (LinkLabel), aplica el color definido para links
                    ctrl.ForeColor = ColorLink

                Case TypeOf ctrl Is Button
                    ' Para botones, cambia color de fondo y texto, y quita borde
                    ctrl.BackColor = ColorBotonFondo
                    ctrl.ForeColor = ColorBotonTexto
                    CType(ctrl, Button).FlatAppearance.BorderSize = 0

                Case TypeOf ctrl Is DataGridView
                    ' Para DataGridView, ajusta colores de fondo, texto y encabezados
                    Dim dgv As DataGridView = CType(ctrl, DataGridView)
                    dgv.BackgroundColor = ColorFondo
                    dgv.DefaultCellStyle.BackColor = ColorFondo
                    dgv.DefaultCellStyle.ForeColor = ColorTexto
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorBotonFondo
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorBotonTexto
                    dgv.EnableHeadersVisualStyles = False ' Para que se usen los colores personalizados y no el estilo por defecto del sistema

                Case TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox
                    ' Para cuadros de texto y combos, color de fondo blanco y texto negro
                    ctrl.BackColor = Color.White
                    ctrl.ForeColor = ColorTexto
            End Select

            ' Si el control actual tiene controles hijos, aplica el tema recursivamente
            If ctrl.HasChildren Then
                AplicarTemaAControles(ctrl)
            End If
        Next
    End Sub

    Public Sub CargarLogo(pic As PictureBox)
        Try
            Dim rutaArchivo As String = Application.StartupPath & "\logo_url.txt"

            If File.Exists(rutaArchivo) Then
                Dim url As String = File.ReadAllText(rutaArchivo)

                Dim request As WebRequest = WebRequest.Create(url)
                Dim response As WebResponse = request.GetResponse()
                Dim stream As Stream = response.GetResponseStream()
                pic.Image = Image.FromStream(stream)
                stream.Close()
                response.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo cargar el logo guardado: " & ex.Message)
        End Try
    End Sub
End Module
