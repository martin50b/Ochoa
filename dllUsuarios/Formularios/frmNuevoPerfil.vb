Imports System.Windows.Forms
Imports dllMsSQL

Public Class frmNuevoPerfil
    Dim dtlPerfil As New DataTable             ' Almacena la informaciòn del Perfil

    Private Sub frmNuevoPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verifica si se trata de un Nuevo Perfil o de una Edición
        If bolNuevoPerfil Then
            ' Titulo
            Me.Text = "Nuevo Perfil"
            ' Nuevo Perfilse
            txtPerfil.Text = ""
            txtDescripcion.Text = ""
            ' Extrae la configuración del Perfil
            Call CargarPerfilNuevo()
            ' Carga la información del Perfil en el TreeView
            Call CargarOpciones()
            ' Se coloca en la caja de Perfil
            txtPerfil.Focus()
        Else
            ' Titulo
            Me.Text = "Editar Perfil"
            ' Edición del Perfil
            txtPerfil.Text = strPerfil
            txtDescripcion.Text = strDescripcion
            ' Extrae la configuración del Perfil
            Call CargarPerfil(strIdPerfil)
            ' Carga la información del Perfil en el TreeView
            Call CargarOpciones()
            ' Se coloca en la caja de Perfil
            txtPerfil.Focus()
        End If
    End Sub

    Sub CargarPerfil(ByVal stridPerfil As String)
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Obtien el Perfil de permisos del usuario
        Dim adsPerfil As New AdaptadorSql
        Dim strQueryPerfiles As String
        strQueryPerfiles = "SELECT " &
                            "	ISNULL( z.idPerfilFunciones, a.idPerfilFunciones) AS idPerfilFunciones, z.idPerfil, b.Tipo, " &
                            "	a.idFuncion, b.Funcion, b.Descripcion, " &
                            "	a.GrupoPadre, isnull(c.Descripcion,'') AS Descripcion_Padre, isnull(b.Imagen, 0) AS Imagen, a.Orden, " &
                            "	isnull(z.Visible, 1) AS Visible, isnull(z.Activo, 0) AS Activo,  " &
                            "	isnull(z.Lectura, 0) AS Lectura, isnull(z.Escritura, 0) AS Escritura, " &
                            "	isnull(z.Modificacion, 0) AS Modificacion, isnull(z.Eliminar, 0) AS Eliminar, " &
                            "	iif(a.GrupoPadre = 20 , 0, isnull(b.BeginGroup,0)) AS BeginGroup " &
                            "FROM PerfilFunciones a " &
                            "LEFT JOIN PerfilFunciones z ON z.idFuncion = a.idFuncion AND z.GrupoPadre = a.GrupoPadre AND z.idPerfil = {0} " &
                            "LEFT JOIN AccesoFunciones b ON b.idFuncion = a.idFuncion " &
                            "LEFT JOIN AccesoFunciones c ON c.idFuncion = a.GrupoPadre " &
                            "WHERE a.idPerfil = 0 " &
                            "ORDER BY a.GrupoPadre, a.Orden"
        strQueryPerfiles = String.Format(strQueryPerfiles, stridPerfil)
        ' Extrae los Perfiles
        dtlPerfil = adsPerfil.EjecutarQuery(strQueryPerfiles, "Perfiles")
        ' Activa las columnas
        dtlPerfil.Columns("Activo").ReadOnly = False
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub CargarPerfilNuevo()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Obtien el Perfil de permisos del usuario
        Dim adsPerfil As New AdaptadorSql
        Dim strQueryPerfiles As String
        strQueryPerfiles = "SELECT " &
                            "	ISNULL( z.idPerfilFunciones, a.idPerfilFunciones) AS idPerfilFunciones, z.idPerfil, b.Tipo, " &
                            "	a.idFuncion, b.Funcion, b.Descripcion, " &
                            "	a.GrupoPadre, isnull(c.Descripcion,'') AS Descripcion_Padre, isnull(b.Imagen, 0) AS Imagen, a.Orden, " &
                            "	1 AS Visible, 0 AS Activo,  " &
                            "	1 AS Lectura, 1 AS Escritura, " &
                            "	1 AS Modificacion, 1 AS Eliminar, " &
                            "	iif(a.GrupoPadre = 20 , 0, isnull(b.BeginGroup,0)) AS BeginGroup " &
                            "FROM PerfilFunciones a " &
                            "LEFT JOIN PerfilFunciones z ON z.idFuncion = a.idFuncion AND z.GrupoPadre = a.GrupoPadre AND z.idPerfil = 0 " &
                            "LEFT JOIN AccesoFunciones b ON b.idFuncion = a.idFuncion " &
                            "LEFT JOIN AccesoFunciones c ON c.idFuncion = a.GrupoPadre " &
                            "WHERE a.idPerfil = 0 " &
                            "ORDER BY a.GrupoPadre, a.Orden"
        strQueryPerfiles = String.Format(strQueryPerfiles, strIdPerfil)
        ' Extrae los Perfiles
        dtlPerfil = adsPerfil.EjecutarQuery(strQueryPerfiles, "Perfiles")
        ' Activa las columnas
        dtlPerfil.Columns("Activo").ReadOnly = False
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub CargarOpciones()
        ' Nodos
        Dim tNodoPrincipal As TreeNode
        Dim tNodoGrupos As TreeNode
        Dim tNodoFuncion As TreeNode

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Limpia el TreeView
        trvPerfiles.Nodes.Clear()

        ' Obtiene las Paginas
        Dim nPaginas() As DataRow = dtlPerfil.Select(String.Format("Tipo = '{0}'", "PGN"))
        If nPaginas.Count > 0 Then
            For Each nPGN As DataRow In nPaginas
                ' Toma el nombre del Documento
                Dim sidFuncionPgn As String = nPGN("idFuncion").ToString
                Dim sDscPagina As String = nPGN("Descripcion").ToString
                Dim bActivoPgn As Boolean = CBool(IIf(nPGN("Activo").ToString.Trim.Equals("1"), True, False))

                ' Crea la Nodo Principal (Pagina)
                trvPerfiles.Nodes.Add(sidFuncionPgn, sDscPagina)
                tNodoPrincipal = trvPerfiles.Nodes(sidFuncionPgn)
                tNodoPrincipal.Checked = bActivoPgn
                ' Guarda en el atributo Tag la llave primaria para ligar con el adaptador.
                tNodoPrincipal.Tag = Convert.ToInt32(nPGN("idPerfilFunciones"))

                ' Obtiene los Grupos por cada Pagina
                Dim nGrupos() As DataRow = dtlPerfil.Select(String.Format("Tipo = '{0}' AND GrupoPadre = {1}", "GRP", sidFuncionPgn))
                If nGrupos.Count > 0 Then
                    For Each nGRP As DataRow In nGrupos
                        Dim sidFuncionGRP As String = nGRP("idFuncion").ToString
                        Dim sDscGrupo As String = ""    'nGRP("Descripcion").ToString
                        Dim bActivoGRP As Boolean = CBool(IIf(nGRP("Activo").ToString.Trim.Equals("1"), True, False))
                        tNodoGrupos = tNodoPrincipal

                        ' Obtiene las Funciones por Grupo
                        Dim nFunciones() As DataRow = dtlPerfil.Select(String.Format("Tipo = '{0}' AND GrupoPadre = {1}", "FUN", sidFuncionGRP))
                        If nFunciones.Count > 0 Then
                            For Each nFUN As DataRow In nFunciones
                                Dim sidFuncionFUN As String = nFUN("idFuncion").ToString
                                Dim sTagFuncion As String = nFUN("Funcion").ToString
                                Dim sDscFuncion As String = nFUN("Descripcion").ToString
                                Dim bVisible As Boolean = CBool(IIf(nFUN("Visible").ToString.Trim.Equals("1"), True, False))
                                Dim bActivo As Boolean = CBool(IIf(nFUN("Activo").ToString.Trim.Equals("1"), True, False))
                                Dim bLectura As Boolean = CBool(IIf(nFUN("Lectura").ToString.Trim.Equals("1"), True, False))
                                Dim iImagen As Integer = CInt(Val(nFUN("Imagen").ToString))

                                ' Crea el segundo nivel del Arbol (Función)
                                tNodoGrupos.Nodes.Add(sidFuncionFUN, sDscFuncion)
                                tNodoFuncion = tNodoGrupos.Nodes(sidFuncionFUN)
                                tNodoFuncion.Checked = bActivo

                                ' Guarda en el atributo Tag la llave primaria para ligar con el adaptador.
                                tNodoFuncion.Tag = Convert.ToInt32(nFUN("idPerfilFunciones"))

                            Next    'nFUN
                        End If  'nFunciones
                    Next    ' nGRP
                End If  'nGrupos
            Next ' nPGN
        End If  ' nPaginas
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub trvPerfiles_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles trvPerfiles.AfterCheck
        If e.Action = TreeViewAction.ByMouse Then
            seleccionar_hijos(e.Node, e.Node.Checked)
            If e.Node.Checked Then
                seleccionar_padre(e.Node, e.Node.Checked)
            End If

            If e.Node.Checked Then
                e.Node.ExpandAll()
            Else
                e.Node.Collapse()
            End If
        End If

        TreeNodeCheckedChanged(e.Node)

        'txtPerfil.Text = e.Node.Tag & "-" & e.Node.Text
    End Sub

    'Private Sub trvPerfiles_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvPerfiles.AfterSelect
    '    txtDescripcion.Text = e.Node.Tag & "-" & e.Node.Text & "-" & e.Node.Checked
    'End Sub

    Sub seleccionar_hijos(ByVal nodo As TreeNode, ByVal bol As Boolean)
        For i = 0 To nodo.Nodes.Count - 1
            nodo.Nodes(i).Checked = bol
            seleccionar_hijos(nodo.Nodes(i), bol)
            If bol Then
                nodo.ExpandAll()
            Else
                nodo.Collapse()
            End If
        Next
    End Sub

    Sub seleccionar_padre(ByVal node As TreeNode, ByVal bol As Boolean)
        If Not node.Parent Is Nothing Then
            node.Parent.Checked = bol
            seleccionar_padre(node.Parent, bol)
        End If
    End Sub

    Private Sub TreeNodeCheckedChanged(nodo As TreeNode)
        Dim iIdPerfilFunciones As Integer = Convert.ToInt32(nodo.Tag)

        If Not dtlPerfil Is Nothing Then
            Dim drsPerfilFunciones() As DataRow = dtlPerfil.Select(String.Format("idPerfilFunciones = {0}", iIdPerfilFunciones))
            If drsPerfilFunciones.Count > 0 Then
                For Each drPerfilFunciones As DataRow In drsPerfilFunciones
                    drPerfilFunciones("Activo") = nodo.Checked
                Next
            End If
        End If
    End Sub

    Private Sub bbiCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCerrar.ItemClick
        ' Cierra el formulario, regresando a la pantalla principal
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub bbiMarcar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiMarcar.ItemClick
        ' Marca todas las opciones del TreeView
        checked_tree(True, False)
    End Sub

    Private Sub bbiDesmarcar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiDesmarcar.ItemClick
        ' Desmarca todas las opciones del TreeView
        checked_tree(False, False)
    End Sub

    Sub checked_tree(ByVal bChecked As Boolean, ByVal bExpand As Boolean)
        ' Rutina para marcar/desmarcar todas las opciones del TreeView
        For i = 0 To trvPerfiles.Nodes.Count - 1
            trvPerfiles.Nodes(trvPerfiles.Nodes(i).Name.ToString).Checked = bChecked
            If bExpand Then trvPerfiles.Nodes(trvPerfiles.Nodes(i).Name.ToString).Expand()
            checked_tree_sub(trvPerfiles.Nodes(trvPerfiles.Nodes(i).Name.ToString), trvPerfiles.Nodes(i), bChecked, bExpand)
        Next
    End Sub

    Shared Function checked_tree_sub(ByVal node As TreeNode, ByVal node_logico As TreeNode, ByVal bChecked As Boolean, ByVal bExpand As Boolean)
        ' Rutina para marcar/desmarcar todas las sub opciones del TreeView
        For j = 0 To node_logico.Nodes.Count - 1
            Try
                node.Nodes(node_logico.Nodes(j).Name.ToString).Checked = bChecked
                If bExpand Then node.Nodes(node_logico.Nodes(j).Name.ToString).Expand()
                checked_tree_sub(node.Nodes(node_logico.Nodes(j).Name.ToString), node_logico.Nodes(j), bChecked, bExpand)

            Catch ex As Exception
            End Try
        Next j
        Return "22"
    End Function

    Private Sub bbiExpandir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExpandir.ItemClick
        ' Expande el TreeView
        trvPerfiles.ExpandAll()
    End Sub

    Private Sub bbiColapsar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiColapsar.ItemClick
        ' Colapsa el TreeView
        trvPerfiles.CollapseAll()
    End Sub

    Private Sub bbiGuardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiGuardar.ItemClick
        ' Verifica que se tenga un nombre de Perfil
        If Trim(txtPerfil.Text) = "" Then
            MessageBox.Show("No ha especificado el nombre del Perfil", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPerfil.Focus()
            Exit Sub
        End If
        ' Verifica que se tenga una Descripción
        If Trim(txtDescripcion.Text) = "" Then
            MessageBox.Show("No ha especificado la Descripción del Perfil", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescripcion.Focus()
            Exit Sub
        End If

        ' Verifica que no exista un Perfil con el mismo nombre
        Dim adsPerfil As New AdaptadorSql
        Dim tblConsultaPerfil As DataTable
        Dim strQuery As String

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        strQuery = "SELECT * " &
                "FROM Perfiles " &
                "WHERE Perfil = '{0}' "
        ' Si es modificación excluye el Perfil que se esta modificando
        If Not bolNuevoPerfil Then strQuery = strQuery & String.Format("AND idPerfil <> {0}", strIdPerfil)

        strQuery = String.Format(strQuery, txtPerfil.Text)
        ' Busca el Perfil
        tblConsultaPerfil = adsPerfil.EjecutarQuery(strQuery, "Perfiles")
        ' Verifica si existe
        If tblConsultaPerfil.Rows.Count > 0 Then
            Cursor = System.Windows.Forms.Cursors.Default
            ' Existe un Perfil con ese Nombre
            MessageBox.Show("Ya existe un Perfil con el nombre especificado, indique otro nombre.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPerfil.Focus()
            Exit Sub
        End If

        ' Guarda el Perfil
        Call GuardarPerfil()

        ' Proceso terminado
        Cursor = System.Windows.Forms.Cursors.Default
        MessageBox.Show("El Perfil ha sido guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Me.Dispose()
    End Sub

    Sub GuardarPerfil()
        Dim adsPerfil As New AdaptadorSql
        Dim tblGuardarPerfil As DataTable
        Dim strQuery As String
        Dim strIdPerfilGuardar As String

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Deshabilita los Group Control, para evitar cambio en los datos.
        gpcPerfil.Enabled = False
        gpcModulos.Enabled = False

        ' Si es una Edición, elimina el Perfil Actual, para crearlo con las modificaciones.
        If Not bolNuevoPerfil Then
            ' Modo Editar: Elimina el Perfil
            strQuery = "DELETE FROM PerfilFunciones " &
                        "WHERE idPerfil = {0}"
            strQuery = String.Format(strQuery, strIdPerfil)
            ' Elimina el Perfil
            tblGuardarPerfil = adsPerfil.EjecutarQuery(strQuery, "Perfiles")

            ' Actualiza los Datos del Perfil (Nombre/Descripción)
            strQuery = "UPDATE Perfiles " &
                    "SET Perfil = '{1}' " &
                    "	, Descripcion = '{2}' " &
                    "WHERE idPerfil = {0}"
            strQuery = String.Format(strQuery, strIdPerfil, txtPerfil.Text, txtDescripcion.Text)
            ' Actualiza el Perfil
            tblGuardarPerfil = adsPerfil.EjecutarQuery(strQuery, "Perfiles")

            ' Toma el IdPerfil que se guardara
            strIdPerfilGuardar = strIdPerfil
        Else
            ' Modo Nuevo: Crea el Perfil
            strQuery = "INSERT INTO Perfiles (idPerfil, Perfil, Descripcion) " &
                        "VALUES ((SELECT max(idPerfil) +1 FROM Perfiles), '{0}', '{1}')"
            strQuery = String.Format(strQuery, txtPerfil.Text, txtDescripcion.Text)
            ' Crea el Perfil
            tblGuardarPerfil = adsPerfil.EjecutarQuery(strQuery, "Perfiles")

            ' Extrae el Folio
            strQuery = "SELECT " &
                        "	max(idPerfil) AS IdPerfil " &
                        "FROM Perfiles"
            ' Extrae el Perfil
            tblGuardarPerfil = adsPerfil.EjecutarQuery(strQuery, "Perfiles")
            strIdPerfilGuardar = tblGuardarPerfil.Rows(0)("IdPerfil").ToString
        End If

        ' Prepara la pantalla de progreso
        ' Centra el Group Control en pantalla
        Call CentrarEnParent(gpcEspera)
        ' Inicializa el ProgressBar
        pbcGuardar.Properties.Maximum = dtlPerfil.Rows.Count
        pbcGuardar.Properties.Minimum = 0
        pbcGuardar.Position = 0
        gpcEspera.Visible = True

        Dim iReg As Integer = 0
        ' Escribe el Perfil en la base de datos
        For Each droRow As DataRow In dtlPerfil.Rows
            ' Arma el Query de INSERT
            strQuery = "INSERT INTO PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar) " &
                    "VALUES ((SELECT max(idPerfilFunciones) + 1 AS idPerfilFunciones FROM PerfilFunciones), {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})"

            'strQuery = "INSERT INTO PerfilFunciones (idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar) " &
            '        "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})"
            strQuery = String.Format(strQuery, strIdPerfilGuardar, droRow("idFuncion").ToString, droRow("GrupoPadre").ToString, droRow("Orden").ToString, droRow("Visible").ToString, droRow("Activo").ToString, droRow("Lectura").ToString, droRow("Escritura").ToString, droRow("Modificacion").ToString, droRow("Eliminar").ToString)
            ' Escribe el Registro
            Dim dtlEjecutar As DataTable = adsPerfil.EjecutarQuery(strQuery, "PerfilDestino")

            ' Incrementa el ProgressBar
            iReg += 1
            pbcGuardar.Position = iReg
            gpcEspera.Refresh()
        Next

        gpcEspera.Visible = False
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

End Class