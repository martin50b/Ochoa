Imports System.Windows.Forms
Imports dllMsSQL

Public Class frmPerfiles
    Public Sub New(_rowLogin As DataRow, _VersionSistema As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        drwRowLogin = _rowLogin
        VersionSistema = _VersionSistema
    End Sub

    Sub CargarPerfiles()
        ' Toma la posición actual en el Grid
        Dim intPosicion As Integer = grvPerfiles.FocusedRowHandle

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim strQuery As String
        strQuery = "SELECT " &
                    "	a.idPerfil, a.Perfil, a.Descripcion, " &
                    "(SELECT Count(b.idPerfil) FROM Empleados b WHERE b.idPerfil = a.idPerfil) AS UsuariosAsignados " &
                    "FROM Perfiles a " &
                    "ORDER BY a.Perfil"
        Dim adpPerfiles As New AdaptadorSql
        Dim tblPerfiles As DataTable = adpPerfiles.EjecutarQuery(strQuery, "Perfiles")

        ' Valida si pudo obtener datos
        If tblPerfiles Is Nothing Then
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        ' Muestra la información en el Grid
        grcPerfiles.DataSource = tblPerfiles
        ' Se coloca en la Posición que se tenia antes de cargar los perfiles
        If grvPerfiles.RowCount > 0 Then
            If intPosicion > grvPerfiles.RowCount Then
                grvPerfiles.FocusedRowHandle = grvPerfiles.RowCount
            Else
                grvPerfiles.FocusedRowHandle = intPosicion
            End If
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub bbiCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCerrar.ItemClick
        ' Solicita confirmación del usuario para salir del sistema
        If MessageBox.Show("¿Desea cerrar la ventana?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Cierra el formulario
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub frmPerfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargarPerfiles()
    End Sub

    Private Sub grvPerfiles_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvPerfiles.FocusedRowChanged
        If Not grvPerfiles.GetFocusedRowCellValue("idPerfil") Is Nothing Then
            If Len(Trim(grvPerfiles.GetFocusedRowCellValue("idPerfil").ToString)) > 0 Then
                ' Extrae los datos del Perfil
                strIdPerfil = grvPerfiles.GetFocusedRowCellValue("idPerfil").ToString
                strPerfil = grvPerfiles.GetFocusedRowCellValue("Perfil").ToString
                strDescripcion = grvPerfiles.GetFocusedRowCellValue("Descripcion").ToString
                intAsignados = CInt(grvPerfiles.GetFocusedRowCellValue("UsuariosAsignados").ToString)
                ' Si se trata del Perfil Maestro, no se permite Editar y Eliminar
                If Trim(strIdPerfil) = "0" Then
                    bbiEditar.Enabled = False
                    bbiEliminar.Enabled = False
                Else
                    bbiEditar.Enabled = True
                    bbiEliminar.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub grvPerfiles_RowCountChanged(sender As Object, e As EventArgs) Handles grvPerfiles.RowCountChanged
        ' Coloca el numero de Perfiles en el StatusBar
        bsiContador1.Caption = grvPerfiles.RowCount

        ' Activa/Desactiva
        If grvPerfiles.RowCount = 0 Then
            ' Desactiva Editar/Eliminar
            bbiEditar.Enabled = False
            bbiEliminar.Enabled = False
        Else
            ' Activa Editar/Eliminar
            bbiEditar.Enabled = True
            bbiEliminar.Enabled = True
        End If

        ' Si se trata del Perfil Maestro, no se permite Editar y Eliminar
        If Trim(strIdPerfil) = "0" Then
            bbiEditar.Enabled = False
            bbiEliminar.Enabled = False
        End If
    End Sub

    Private Sub bbiNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiNuevo.ItemClick
        Dim frmForma As New frmNuevoPerfil

        ' Flag: Indica que se trata de un Perfil Nuevo
        bolNuevoPerfil = True

        ' Carga el formulario de Detalle del Perfil
        frmForma.ShowDialog()

        ' Recarga los datos
        Call CargarPerfiles()
    End Sub

    Private Sub bbiEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEditar.ItemClick
        ' Edita el Perfil
        Call EditarPerfil()
    End Sub

    Private Sub bbiActualizar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiActualizar.ItemClick
        ' Recarga los datos
        Call CargarPerfiles()
    End Sub

    Sub EditarPerfil()
        Dim frmForma As New frmNuevoPerfil

        ' Verifica que este activa la opción de Editar
        If Not bbiEditar.Enabled Then Exit Sub

        ' Flag: Indica que se trata de una edición del Perfil
        bolNuevoPerfil = False

        ' Carga el formulario de Detalle del Perfil
        frmForma.ShowDialog()

        ' Recarga los datos
        Call CargarPerfiles()
    End Sub

    Private Sub grcPerfiles_DoubleClick(sender As Object, e As EventArgs) Handles grcPerfiles.DoubleClick
        ' Edita el Perfil
        Call EditarPerfil()
    End Sub

    Private Sub bbiEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEliminar.ItemClick
        ' Verifica que no este asignado ha alguna cuenta
        If intAsignados > 0 Then
            MessageBox.Show(String.Format("El perfil esta asignado a {0} Cuentas, no puede eliminarse", intAsignados), "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Confirmación para Eliminar
        If MessageBox.Show(String.Format("¿Desea eliminar el Perfil '{0}?'", strPerfil), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim strQuery As String

        ' Verifica que el perfil no este asignado a un Empleado
        strQuery = "SELECT " &
                "	Count(idEmpleado) AS Empleados " &
                "FROM Empleados " &
                "WHERE idPerfil = {0}"
        strQuery = String.Format(strQuery, strIdPerfil)
        Dim adpUsuarios As New AdaptadorSql
        Dim tblPerfiles As DataTable = adpUsuarios.EjecutarQuery(strQuery, "Perfiles")
        If Not tblPerfiles Is Nothing Then
            If Val(tblPerfiles.Rows(0)("Empleados").ToString) > 0 Then
                MessageBox.Show(String.Format("Existen {0} Empleados que tienen asignado este Perfil, debe quitar esas asignaciones antes de eliminar el perfil.", tblPerfiles.Rows(0)("Empleados").ToString.Trim), "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

            ' Elimina el Perfil
            strQuery = "DELETE FROM Perfiles " &
                    "WHERE idPerfil = {0}"
        strQuery = String.Format(strQuery, strIdPerfil)
        tblPerfiles = adpUsuarios.EjecutarQuery(strQuery, "Perfiles")

        ' Elimina las Funciones del Perfil
        strQuery = "DELETE FROM PerfilFunciones " &
                    "WHERE idPerfil = {0} "
        strQuery = String.Format(strQuery, strIdPerfil)
        tblPerfiles = adpUsuarios.EjecutarQuery(strQuery, "Perfiles")

        ' Recarga los datos
        Call CargarPerfiles()

        ' Proceso terminado
        MessageBox.Show("El Perfil ha sido eliminado.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class