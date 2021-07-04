Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors

Public Class frmMain

    Dim iLogo As Integer = 0

    Private Sub bvbSalir_ItemClick(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles bvbSalir.ItemClick
        Call FuncionSalir()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ajusta el nombre de los Skins
        For Each cnt As SkinContainer In SkinManager.Default.Skins
            If Not cnt.SkinName.Contains("Office") And
                Not cnt.SkinName = "The Bezier" And
                Not cnt.SkinName = "Basic" And
                Not cnt.SkinName = "McSkin" And
                Not cnt.SkinName = "Pumpkin" And
                Not cnt.SkinName = "Springtime" And
                Not cnt.SkinName = "Valentine" Then
                Continue For
            End If

            If cnt.SkinName <> "Office 2019 Black" Then
                Select Case cnt.SkinName
                    Case "The Bezier"
                        cmbTemas.Properties.Items.Add("Básico oscuro")
                    Case "Basic"
                        cmbTemas.Properties.Items.Add("Básico azul")
                    Case "McSkin"
                        cmbTemas.Properties.Items.Add("Modo: Mac")
                    Case "Pumpkin"
                        cmbTemas.Properties.Items.Add("Modo: Halloween")
                    Case "Springtime"
                        cmbTemas.Properties.Items.Add("Modo: Primavera")
                    Case "Valentine"
                        cmbTemas.Properties.Items.Add("Modo: Día del amor")
                    Case Else
                        cmbTemas.Properties.Items.Add(cnt.SkinName)
                End Select
            End If
        Next cnt

        ' Se coloca en el Skin actual
        cmbTemas.Text = "Básico azul"

        ' Carga Perfiles
        Call CargarOpciones()

        ' Muestra la información del usuario en la barra inferior
        Call DatosUsuario()
    End Sub

    Private Sub cmbTemas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTemas.SelectedIndexChanged
        Dim comboBox As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
        Dim skinName As String = comboBox.Text
        Select Case skinName
            Case "Básico oscuro"
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier"
            Case "Básico azul"
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Basic"
            Case "Modo: Mac"
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "McSkin"
            Case "Modo: Halloween"
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Pumpkin"
            Case "Modo: Primavera"
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Springtime"
            Case "Modo: Día del amor"
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Valentine"
            Case Else
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName
        End Select
    End Sub

    Sub CargarOpciones()
        Dim sPaso As String = "Inicio"
        Try
            ' Obtiene las Paginas
            Dim nPaginas() As DataRow = dtlPerfil.Select(String.Format("Tipo = '{0}'", "PGN"))
            If nPaginas.Count > 0 Then
                For Each nPGN As DataRow In nPaginas
                    sPaso = "Grupo"
                    ' Toma el nombre del Documento
                    Dim sidFuncionPgn As String = nPGN("idFuncion").ToString
                    Dim sDscPagina As String = nPGN("Descripcion").ToString
                    ' Crea la Pagina
                    Dim rbnPage As New RibbonPage(sDscPagina)
                    ' Agrega la Pagina al Ribbon
                    rcoToolBar.Pages.Add(rbnPage)

                    ' El menu lo crea en tiempo de diseño ....



                    ' Obtiene los Grupos por cada Pagina
                    Dim nGrupos() As DataRow = dtlPerfil.Select(String.Format("Tipo = '{0}' AND GrupoPadre = {1}", "GRP", sidFuncionPgn))
                    If nGrupos.Count > 0 Then
                        sPaso = "Pagina"
                        For Each nGRP As DataRow In nGrupos
                            Dim sidFuncionGRP As String = nGRP("idFuncion").ToString
                            Dim sDscGrupo As String = ""    'nGRP("Descripcion").ToString
                            ' Crea el Grupo
                            Dim rbnGroup As New RibbonPageGroup(sDscGrupo)
                            rbnGroup.ShowCaptionButton = False
                            ' Agrega el Grupo a la Pagina
                            rbnPage.Groups.Add(rbnGroup)

                            ' Obtiene las Funciones por Grupo
                            Dim nFunciones() As DataRow = dtlPerfil.Select(String.Format("Tipo = '{0}' AND GrupoPadre = {1}", "FUN", sidFuncionGRP))
                            If nFunciones.Count > 0 Then
                                sPaso = "Función"
                                For Each nFUN As DataRow In nFunciones
                                    Dim sidFuncionFUN As String = nFUN("idFuncion").ToString
                                    Dim sTagFuncion As String = nFUN("Funcion").ToString
                                    Dim sDscFuncion As String = nFUN("Descripcion").ToString
                                    Dim bVisible As Boolean = CBool(IIf(nFUN("Visible").ToString.Trim.Equals("1"), True, False))
                                    Dim bActivo As Boolean = CBool(IIf(nFUN("Activo").ToString.Trim.Equals("1"), True, False))
                                    Dim bLectura As Boolean = CBool(IIf(nFUN("Lectura").ToString.Trim.Equals("1"), True, False))
                                    Dim bBeginGroup As Boolean = CBool(IIf(nFUN("BeginGroup").ToString.Trim.Equals("1"), True, False))
                                    Dim iImagen As Integer = CInt(Val(nFUN("Imagen").ToString))
                                    ' Crea la Función
                                    Dim rbnFunction As New BarButtonItem
                                    rbnFunction.Caption = sDscFuncion
                                    'rbnFunction.LargeGlyph = imgMenu.Images(iImagen)
                                    rbnFunction.LargeGlyph = imgMenu.Images(0)
                                    rbnFunction.Tag = sTagFuncion
                                    rbnFunction.Enabled = bActivo
                                    AddHandler rbnFunction.ItemClick, New ItemClickEventHandler(AddressOf clickMenu)
                                    ' Agrega la Función al Grupo
                                    rbnGroup.ItemLinks.Add(rbnFunction)
                                    rbnFunction.Links.Item(0).BeginGroup = bBeginGroup
                                    If bVisible Then rbnFunction.Visibility = BarItemVisibility.Always Else rbnFunction.Visibility = BarItemVisibility.Never
                                Next    'nFUN
                            End If  'nFunciones
                        Next    ' nGRP
                    End If  'nGrupos
                Next ' nPGN
            End If  ' nPaginas

        Catch ex As Exception
            MessageBox.Show("Se genero un problema al construir el menú.", "Menú Principal (" & sPaso & ")", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Sub clickMenu(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        Dim customItem As BarButtonItem = DirectCast(e.Item, BarButtonItem)
        Dim sFuncion As String = customItem.Tag.ToString

        ' Manda llamar la función
        FuncionMenu(sFuncion)
    End Sub

    Sub FuncionMenu(ByVal sFuncion As String)
        Select Case sFuncion
            Case Is = "F000000040"  ' Configurar impresora
            Case Is = "F000000041"  ' Imprimir
            Case Is = "F000000042"  ' Salir
                Call FuncionSalir()

            Case Is = "F000000043"  ' Artículo
            Case Is = "F000000044"  ' Consulta del inventario
            Case Is = "F000000045"  ' Productos con caducidad
            Case Is = "F000000046"  ' Movimientos del almacén
            Case Is = "F000000047"  ' Movimientos por artículo
            Case Is = "F000000048"  ' Salidas
            Case Is = "F000000049"  ' Devoluciones
            Case Is = "F000000050"  ' Reporte del inventario
            Case Is = "F000000051"  ' Actualizar el inventario
            Case Is = "F000000052"  ' Lista de precios

            Case Is = "F000000053"  ' Materia prima
            Case Is = "F000000054"  ' Material requerido
            Case Is = "F000000055"  ' Producción estimada
            Case Is = "F000000056"  ' Reporte de producción
            Case Is = "F000000057"  ' Lista de reporte de producción
            Case Is = "F000000058"  ' Salida de material
            Case Is = "F000000059"  ' Lista de salidas de material

            Case Is = "F000000060"  ' Datos del cliente
            Case Is = "F000000061"  ' Directorio de clientes
            Case Is = "F000000062"  ' Precios por cliente
            Case Is = "F000000063"  ' Cotización
            Case Is = "F000000064"  ' Lista de cotizaciones
            Case Is = "F000000065"  ' Factura
            Case Is = "F000000066"  ' Lista de facturas
            Case Is = "F000000067"  ' Lista de facturas con UUID

            Case Is = "F000000068"  ' Datos del empleado
                Call FuncionEmpleados()
            Case Is = "F000000069"  ' Directorio de empleados
            Case Is = "F000000070"  ' Bajas de empleados
            Case Is = "F000000071"  ' Estado de cuenta del empleado
            Case Is = "F000000072"  ' Comisión por empleado
            Case Is = "F000000073"  ' Listado de comisiones
            Case Is = "F000000074"  ' Control de préstamos

            Case Is = "F000000068"  ' Alta de un equipo
            Case Is = "F000000069"  ' Catálogo de equipos
            Case Is = "F000000070"  ' Inspección
            Case Is = "F000000071"  ' Lista de inspecciones
            Case Is = "F000000072"  ' Rendimientos de equipos

            Case Is = "F000000073"  ' Definición de una ruta
            Case Is = "F000000074"  ' Entregas por día
            Case Is = "F000000075"  ' Precios por ruta
            Case Is = "F000000076"  ' Catálogo de rutas
            Case Is = "F000000077"  ' Salida a reparto
            Case Is = "F000000078"  ' Recarga de
            Case Is = "F000000079"  ' Reporte de venta
            Case Is = "F000000080"  ' Lista de reportes de venta
            Case Is = "F000000081"  ' Venta créditos por reparto
            Case Is = "F000000082"  ' Detalle ventas créditos por reparto
            Case Is = "F000000083"  ' Concentrado detalle de la venta
            Case Is = "F000000084"  ' Depósitos por reparto
            Case Is = "F000000085"  ' Cobros por ruta
            Case Is = "F000000086"  ' Gastos por reparto

            Case Is = "F000000087"  ' Datos del proveedor
            Case Is = "F000000088"  ' Directorio de proveedores
            Case Is = "F000000089"  ' Pedido
            Case Is = "F000000090"  ' Lista de pedidos
            Case Is = "F000000091"  ' Pedidos pendientes
            Case Is = "F000000092"  ' Compra
            Case Is = "F000000093"  ' Lista de compras
            Case Is = "F000000094"  ' Captura de gastos
            Case Is = "F000000095"  ' Lista de gastos caja chica
            Case Is = "F000000096"  ' Lista de gastos y pagos

            Case Is = "F000000097"  ' Reporte de ventas por día de la semana
            Case Is = "F000000098"  ' Concentrado de ventas por semana
            Case Is = "F000000099"  ' Concentrado de ventas por fechas
            Case Is = "F000000100"  ' Repartos
            Case Is = "F000000101"  ' Facturas-Notas por artículo
            Case Is = "F000000102"  ' Reporte IEPS por cliente
            Case Is = "F000000103"  ' Reporte IEPS por cliente-producto
            Case Is = "F000000104"  ' Compras por artículo
            Case Is = "F000000105"  ' Clientes y proveedores
            Case Is = "F000000106"  ' Estado de cuenta del proveedor
            Case Is = "F000000107"  ' Reporte saldo de proveedores
            Case Is = "F000000108"  ' Detalle de cobros
            Case Is = "F000000109"  ' Lista complementos pago
            Case Is = "F000000110"  ' Reporte de facturas e ingresos
            Case Is = "F000000111"  ' Detalle de pagos
            Case Is = "F000000112"  ' Concentrado de pagos por semana
            Case Is = "F000000113"  ' Concentrado de pagos por mes
            Case Is = "F000000114"  ' Concentrado de pagos por fechas
            Case Is = "F000000115"  ' Lista de gastos por tipo
            Case Is = "F000000116"  ' Reporte de producción por día de la semana
            Case Is = "F000000117"  ' Concentrado producción por semana
            Case Is = "F000000118"  ' Concentrado producción entre fechas
            Case Is = "F000000119"  ' Reporte de cargas y producción
            Case Is = "F000000120"  ' Reporte costo de producción
            Case Is = "F000000121"  ' Sobrante de material de producción
            Case Is = "F000000122"  ' Costo del inventario
            Case Is = "F000000123"  ' Reporte costo del inventario

            Case Is = "F000000124"  ' Área de trabajo
            Case Is = "F000000125"  ' Datos CFDI
            Case Is = "F000000126"  ' Editor de menús
            Case Is = "F000000127"  ' Candado fecha contable
            Case Is = "F000000128"  ' USD
            Case Is = "F000000129"  ' Categorías y tipos
            Case Is = "F000000130"  ' Orden del inventario
            Case Is = "F000000131"  ' Caducidad por productos
            Case Is = "F000000132"  ' Definir subproductos
            Case Is = "F000000133"  ' Control de cajas
            Case Is = "F000000134"  ' Áreas y puestos de trabajo
            Case Is = "F000000135"  ' Tipos de gastos
            Case Is = "F000000136"  ' Tipos de gastos por área
            Case Is = "F000000137"  ' Contraseñas de empleados
            Case Is = "F000000138"  ' Tabla de comisiones
            Case Is = "F000000139"  ' Marcas y tipos de equipos
            Case Is = "F000000140"  ' Datos del correo emisor
            Case Is = "F000000141"  ' Definir tablas de impresión
            Case Is = "F000000142"  ' Definir facturas
            Case Is = "F000000143"  ' Restablecer almacén
            Case Is = "F000000144"  ' Editor
            Case Is = "F000000145"  ' Perfiles
                Call FuncionPerfiles()

            Case Is = "F000000146"  ' Cascada
                Me.LayoutMdi(MdiLayout.Cascade)

            Case Is = "F000000147"  ' Mosaico horizontal
                Me.LayoutMdi(MdiLayout.TileHorizontal)

            Case Is = "F000000148"  ' Mosaico vertical
                Me.LayoutMdi(MdiLayout.TileVertical)

            Case Is = "F000000149"  ' Ayuda
            Case Is = "F000000150"  ' Acerca de
                Call FuncionAcercaDe()
        End Select
    End Sub

    Sub DatosUsuario()
        ' Nombre del usuario
        bsiUsuario.Caption = "Usuario:"
        bsiUsuario1.Caption = strCUNombreUsuario
        ' Perfil
        bsiPerfil.Caption = "Perfil:"
        bsiPerfil1.Caption = strCUDscPerfil
        ' Vewrsión
        bsiVersion.Caption = "Versión:"
        bsiVersion1.Caption = strVersionSistema

        ' Servidor
        bsiServidor.Caption = "Servidor:"
        bsiServidor1.Caption = strCUServidor
        ' Base de datos
        bsiBaseDatos.Caption = "Base de datos:"
        bsiBaseDatos1.Caption = strCUBaseDatos
        ' Muestra la Versión en el BackStageView
        lblVersion.Text = "Versión " & Application.ProductVersion.ToString()
    End Sub

    Sub FuncionSalir()
        On Error Resume Next

        ' Solicita confirmación del usuario para salir del sistema
        If MessageBox.Show("¿Desea salir del sistema?", "Salir del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra y elimina de memoria el formulario
            frmLogin.Close()

            ' Hace una pausa de 1/4 segundo
            System.Threading.Thread.Sleep(250)

            ' Cierra el formulario de la pantalla principal
            Me.Close()
            Me.Dispose()

            ' Finaliza la aplicación
            End
        End If
    End Sub

    Sub FuncionPerfiles()
        ' Verifica esta cargado el formulario
        If Not BuscarForma("frmPerfiles") Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim frmPerfiles As New dllUsuarios.frmPerfiles(drwRowLogin, strVersionSistema)

            ' No esta activo el formulario, asi que lo muestra en pantalla
            frmPerfiles.MdiParent = Me
            frmPerfiles.Show()

            Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Sub FuncionEmpleados()
        ' Verifica esta cargado el formulario
        If Not BuscarForma("frmEmpleados") Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim frmEmpleados As New dllCatalogos.frmEmpleados(drwRowLogin, strVersionSistema)

            ' No esta activo el formulario, asi que lo muestra en pantalla
            frmEmpleados.MdiParent = Me
            frmEmpleados.Show()

            Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Sub FuncionAcercaDe()
        ' Verifica esta cargado el formulario
        If Not BuscarForma("frmAcercaDe") Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim frmAcercaDe As New frmAcercaDe

            ' No esta activo el formulario, asi que lo muestra en pantalla
            frmAcercaDe.MdiParent = Me
            frmAcercaDe.Show()

            Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Public Function BuscarForma(ByVal sFormulario As String) As Boolean
        Dim sNomFormulario As String = ""
        Dim sTitulo As String = ""

        For i As Integer = 0 To MdiChildren.Length - 1
            sNomFormulario = MdiChildren(i).Name
            sTitulo = MdiChildren(i).Text
            If sNomFormulario = sFormulario Then
                MdiChildren(i).Focus()
                MdiChildren(i).Activate()
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        On Error Resume Next

        ' Cierra y elimina de memoria el formulario
        frmLogin.Close()

        ' Hace una pausa de 1/4 segundo
        System.Threading.Thread.Sleep(250)

        ' Cierra el formulario de la pantalla principal
        Me.Dispose()

        ' Finaliza la aplicación
        End
    End Sub

    Private Sub frmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        ' Actualiza la pantalla, para que se redibuje el fondo (Logo)
        Me.Refresh()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'My.Forms.p_usr.MdiParent = Me
        'My.Forms.p_usr.Show()
        'My.Forms.p_usr.WindowState = FormWindowState.Maximized

        ' Verifica esta cargado el formulario
        If Not BuscarForma("frmReparto") Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim frmReparto As New dllReparto.frmReparto()

            ' No esta activo el formulario, asi que lo muestra en pantalla
            frmReparto.MdiParent = Me
            frmReparto.Show()

            Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub
End Class