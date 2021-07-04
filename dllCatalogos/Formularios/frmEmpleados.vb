Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports dllMsSQL

Public Class frmEmpleados
    Public Sub New(_rowLogin As DataRow, _VersionSistema As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        drwRowLogin = _rowLogin
        VersionSistema = _VersionSistema
    End Sub

    Private Sub frmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga los Empleados
        Call CargarEmpleados()

        ' Adapta el tamaño de la etiqueta Motivo al espacio maximo que puede tomar
        lblMotivo.Width = (xtcEmpleado.Width - lblMotivo.Left) - 20
        lblMotivo.Height = (xtcEmpleado.Height - lblMotivo.Top) - 40
    End Sub

    Private Sub xtcEmpleado_Resize(sender As Object, e As EventArgs) Handles xtcEmpleado.Resize
        ' Adapta el tamaño de la etiqueta Motivo al espacio maximo que puede tomar
        lblMotivo.Width = (xtcEmpleado.Width - lblMotivo.Left) - 20
        lblMotivo.Height = (xtcEmpleado.Height - lblMotivo.Top) - 40
    End Sub

    Private Sub bbiCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCerrar.ItemClick
        Me.Close()
        Me.Dispose()
    End Sub

    Sub CargarEmpleados()
        ' Toma la posición actual en el Grid (Row Actual)
        Dim intPosicion As Integer = grvEmpleados.FocusedRowHandle

        ' Construye el Query y extrae la información BD.
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim strQuery As String
        strQuery = "SELECT " &
                    "	a.idEmpleado, a.Numero, a.Nombre, a.Login, a.Pass, a.idArea, isnull(c.Area, '<Sin Área>') AS Area, a.idPuesto, isnull(d.Puesto, '<Sin Puesto>') AS Puesto, a.idEstatus, isnull(b.Estatus, '<Sin Estatus>') AS Estatus, " &
                    "	isnull(a.Estudios, '-') AS Estudios, isnull(a.RFC, '-') AS RFC, isnull(a.CURP, '-') AS CURP, isnull(a.Licencia, '-') AS Licencia, a.Vigencia, a.Fecha_Alta, a.Fecha_Baja, isnull(a.Motivo, '-') AS Motivo, isnull(a.NSS, '-') AS NSS, " &
                    "   a.AltaIMSS, a.BajaIMSS, isnull(a.Telefono, '-') AS Telefono, isnull(a.Celular, '-') AS Celular, isnull(a.Calle, '-') AS Calle, isnull(a.Colonia, '-') AS Colonia, isnull(a.Ciudad, '-') AS Ciudad, " &
                    "	a.Estatura, a.Peso, a.Nacimiento, isnull(a.EMail, '-') AS EMail, isnull(a.Saldo, 0) as Saldo, a.idPerfil, isnull(e.Perfil, '<Sin Perfil>') AS Perfil, isnull(a.Foto, '') AS Foto, a.Mensaje, a.Actualizar, a.Version " &
                    "FROM Empleados a " &
                    "LEFT JOIN Estatus b ON b.idEstatus = a.idEstatus AND b.Tipo = 'Empleados' " &
                    "LEFT JOIN Areas c ON c.idArea = a.idArea " &
                    "LEFT JOIN Puestos d ON d.idPuesto = a.idPuesto " &
                    "LEFT JOIN Perfiles e ON e.idPerfil = a.idPerfil " &
                    "ORDER BY a.Numero"
        Dim adpEmpleados As New AdaptadorSql
        Dim tblEmpleados As DataTable = adpEmpleados.EjecutarQuery(strQuery, "Perfiles")

        ' Valida si pudo obtener datos
        If tblEmpleados Is Nothing Then
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        ' Coloca los registros
        grcEmpleados.DataSource = tblEmpleados
        grcEmpleados.RefreshDataSource()

        ' Se coloca en la Posición que se tenia antes de cargar los perfiles
        If grvEmpleados.RowCount > 0 Then
            ' Se posiciona en el registros
            If intPosicion > grvEmpleados.RowCount Then
                grvEmpleados.FocusedRowHandle = grvEmpleados.RowCount
            Else
                grvEmpleados.FocusedRowHandle = intPosicion
            End If
        End If

        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub grvEmpleados_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvEmpleados.FocusedRowChanged
        If Not grvEmpleados.GetFocusedRowCellValue("idEmpleado") Is Nothing Then
            If Len(Trim(grvEmpleados.GetFocusedRowCellValue("idEmpleado").ToString)) > 0 Then
                ' Variables
                Dim strFechaAlta As String = ""
                Dim strFechaBaja As String = ""
                Dim strVigencia As String = ""
                Dim strAltaIMSS As String = ""
                Dim strBajaIMSS As String = ""
                Dim strFechaNacimiento As String = ""

                ' IdEmpleado
                strIdEmpleado = grvEmpleados.GetFocusedRowCellValue("idEmpleado").ToString.Trim
                ' General
                lblNumero.Text = grvEmpleados.GetFocusedRowCellValue("Numero").ToString.Trim
                lblNombre.Text = grvEmpleados.GetFocusedRowCellValue("Nombre").ToString.Trim
                lblArea.Text = grvEmpleados.GetFocusedRowCellValue("Area").ToString.Trim
                lblPuesto.Text = grvEmpleados.GetFocusedRowCellValue("Puesto").ToString.Trim
                lblEstatus.Text = grvEmpleados.GetFocusedRowCellValue("Estatus").ToString.Trim
                lblPerfil.Text = grvEmpleados.GetFocusedRowCellValue("Perfil").ToString.Trim

                ' Foto
                Dim strFoto As String = grvEmpleados.GetFocusedRowCellValue("Foto").ToString.Trim
                If strFoto <> "" Then
                    Try
                        ' Carga la Foto almacenada
                        picFotografia.Image = Image.FromFile(strFoto)
                        picFotografia.Tag = strFoto
                    Catch ex As Exception
                        picFotografia.Image = picFotografia2.Image
                        picFotografia.Tag = ""
                    End Try
                Else
                    ' Coloca la imagen por Default
                    picFotografia.Image = picFotografia2.Image
                    picFotografia.Tag = ""
                End If

                If Trim(grvEmpleados.GetFocusedRowCellValue("Fecha_Alta").ToString) = "" Then
                    strFechaAlta = "-"
                Else
                    strFechaAlta = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Fecha_Alta").ToString), "dd/MM/yyyy")
                End If
                lblFechaAlta.Text = strFechaAlta
                If Trim(grvEmpleados.GetFocusedRowCellValue("Fecha_Baja").ToString) = "" Then
                    strFechaBaja = "-"
                Else
                    strFechaBaja = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Fecha_Baja").ToString), "dd/MM/yyyy")
                End If
                lblFechaBaja.Text = strFechaBaja
                lblMotivo.Text = grvEmpleados.GetFocusedRowCellValue("Motivo").ToString.Trim

                ' Personal
                lblEstudios.Text = grvEmpleados.GetFocusedRowCellValue("Estudios").ToString.Trim
                lblRFC.Text = grvEmpleados.GetFocusedRowCellValue("RFC").ToString.Trim
                lblCURP.Text = grvEmpleados.GetFocusedRowCellValue("CURP").ToString.Trim
                lblLicencia.Text = grvEmpleados.GetFocusedRowCellValue("Licencia").ToString.Trim
                If Trim(grvEmpleados.GetFocusedRowCellValue("Vigencia").ToString) = "" Then
                    strVigencia = "-"
                Else
                    strVigencia = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Vigencia").ToString), "dd/MM/yyyy")
                End If
                lblVigencia.Text = strVigencia
                lblNSS.Text = grvEmpleados.GetFocusedRowCellValue("NSS").ToString.Trim
                If Trim(grvEmpleados.GetFocusedRowCellValue("AltaIMSS").ToString) = "" Then
                    strAltaIMSS = "-"
                Else
                    strAltaIMSS = Format(CDate(grvEmpleados.GetFocusedRowCellValue("AltaIMSS").ToString), "dd/MM/yyyy")
                End If
                lblAltaIMSS.Text = strAltaIMSS
                If Trim(grvEmpleados.GetFocusedRowCellValue("BajaIMSS").ToString) = "" Then
                    strBajaIMSS = "-"
                Else
                    strBajaIMSS = Format(CDate(grvEmpleados.GetFocusedRowCellValue("BajaIMSS").ToString), "dd/MM/yyyy")
                End If
                lblBajaIMSS.Text = strAltaIMSS
                lblTelefono.Text = grvEmpleados.GetFocusedRowCellValue("Telefono").ToString.Trim
                lblCelular.Text = grvEmpleados.GetFocusedRowCellValue("Celular").ToString.Trim
                lblCalle.Text = grvEmpleados.GetFocusedRowCellValue("Calle").ToString.Trim
                lblColonia.Text = grvEmpleados.GetFocusedRowCellValue("Colonia").ToString.Trim
                lblCiudad.Text = grvEmpleados.GetFocusedRowCellValue("Ciudad").ToString.Trim
                lblEstatura.Text = grvEmpleados.GetFocusedRowCellValue("Estatura").ToString.Trim
                lblPeso.Text = grvEmpleados.GetFocusedRowCellValue("Peso").ToString.Trim
                If Trim(grvEmpleados.GetFocusedRowCellValue("Nacimiento").ToString) = "" Then
                    strFechaNacimiento = "-"
                Else
                    strFechaNacimiento = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Nacimiento").ToString), "dd/MM/yyyy")
                End If
                lblFechaNacimiento.Text = strFechaNacimiento
                lblCorreoElectronico.Text = grvEmpleados.GetFocusedRowCellValue("EMail").ToString.Trim
                lblSaldo.Text = Format(Val(grvEmpleados.GetFocusedRowCellValue("Saldo").ToString), "Currency")
                lblActualizado.Text = IIf(grvEmpleados.GetFocusedRowCellValue("Actualizar").ToString.Trim = "0", "No", "Si")
                lblVersion.Text = grvEmpleados.GetFocusedRowCellValue("Version").ToString.Trim
                lblMensajeBloqueo.Text = grvEmpleados.GetFocusedRowCellValue("Mensaje").ToString.Trim

                ' Familiares
                Dim strQuery As String
                strQuery = "SELECT " &
                        "	idFamiliar, idEmpleado, Nombre, Parentesco, Edad " &
                        "FROM Familiares " &
                        String.Format("WHERE idEmpleado = {0}", grvEmpleados.GetFocusedRowCellValue("idEmpleado").ToString.Trim)
                Dim adpFamiliares As New AdaptadorSql
                Dim tblFamiliares As DataTable = adpFamiliares.EjecutarQuery(strQuery, "Perfiles")
                ' Valida si pudo obtener datos
                If tblFamiliares Is Nothing Then
                    Cursor = System.Windows.Forms.Cursors.Default
                    MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                ' Muestra la información en el Grid
                grcFamiliares.DataSource = tblFamiliares
                grcFamiliares.RefreshDataSource()
            End If
        End If
    End Sub

    Private Sub bbiActualizar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiActualizar.ItemClick
        ' Actualiza la vista de Empleados
        Call CargarEmpleados()
    End Sub

    Private Sub bbiNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiNuevo.ItemClick
        Dim frmForma As New frmNuevoEmpleado

        ' Flag: Indica que se trata de un Perfil Nuevo
        bolNuevoEmpleado = True

        ' Carga los combos para un Nuevo empleado
        Call NuevoEmpleado(frmForma)

        ' Carga el formulario de Detalle del Perfil
        frmForma.ShowDialog()

        ' Recarga los datos
        Call CargarEmpleados()
    End Sub

    Private Sub bbiEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEditar.ItemClick
        Call EditarEmpleado()
    End Sub

    Private Sub grcEmpleados_DoubleClick(sender As Object, e As EventArgs) Handles grcEmpleados.DoubleClick
        Call EditarEmpleado()
    End Sub

    Sub EditarEmpleado()
        Dim frmForma As New frmNuevoEmpleado

        ' Verifica que este activa la opción de Editar
        If Not bbiEditar.Enabled Then Exit Sub

        ' Flag: Indica que se trata de una edición del Perfil
        bolNuevoEmpleado = False

        ' Carga el formulario de Detalle del Perfil
        Call CargarEdicion(frmForma)

        ' Carga el formulario de Detalle del Perfil
        frmForma.ShowDialog()

        ' Recarga los datos
        Call CargarEmpleados()
    End Sub

    Private Sub grvEmpleados_RowCountChanged(sender As Object, e As EventArgs) Handles grvEmpleados.RowCountChanged
        ' Coloca el numero de Perfiles en el StatusBar
        bsiContador1.Caption = grvEmpleados.RowCount

        ' Activa/Desactiva
        If grvEmpleados.RowCount = 0 Then
            ' Desactiva Editar/Eliminar
            bbiEditar.Enabled = False
            bbiEliminar.Enabled = False
        Else
            ' Activa Editar/Eliminar
            bbiEditar.Enabled = True
            bbiEliminar.Enabled = True
        End If

        ' Si se trata del Empleado Maestro, no se permite Editar y Eliminar
        If Trim(strIdEmpleado) = "1" Then
            bbiEditar.Enabled = False
            bbiEliminar.Enabled = False
        End If

    End Sub

    Sub NuevoEmpleado(ByRef frmForma As frmNuevoEmpleado)
        ' Carga las áreas
        Call ObtenerAreas(frmForma)

        ' Carga los Puestos
        Call ObtenerPuestos(frmForma)

        ' Carga los Estatus
        Call ObtenerEstatus(frmForma)

        ' Carga los Perfiles
        Call ObtenerPerfiles(frmForma)

        ' Fecha de Alta
        frmForma.dteFechaAlta.EditValue = Date.Now
        ' Sistema Actualizado
        frmForma.chkActualizado.Checked = True
        ' Version del sistema
        frmForma.txtVersion.Text = VersionSistema
    End Sub

    Sub CargarEdicion(ByRef frmForma As frmNuevoEmpleado)
        ' General
        frmForma.txtNumero.Text = grvEmpleados.GetFocusedRowCellValue("Numero").ToString.Trim
        frmForma.txtNombre.Text = grvEmpleados.GetFocusedRowCellValue("Nombre").ToString.Trim
        frmForma.txtUsuario.Text = grvEmpleados.GetFocusedRowCellValue("Login").ToString.Trim
        frmForma.txtContrasena.Text = grvEmpleados.GetFocusedRowCellValue("Pass").ToString.Trim

        ' Foto
        Dim strFoto As String = grvEmpleados.GetFocusedRowCellValue("Foto").ToString.Trim
        If strFoto <> "" Then
            Try
                ' Carga la Foto almacenada
                frmForma.picFotografia.Image = Image.FromFile(strFoto)
                frmForma.picFotografia.Tag = strFoto
            Catch ex As Exception
                ' Coloca la foto por Default
                frmForma.picFotografia.Image = frmForma.picFotografia2.Image
                frmForma.picFotografia.Tag = ""
            End Try
        Else
            ' Coloca la foto por Default
            frmForma.picFotografia.Image = frmForma.picFotografia2.Image
            frmForma.picFotografia.Tag = ""
        End If

        ' Carga las áreas
        Call ObtenerAreas(frmForma)
        frmForma.cmbArea.EditValue = grvEmpleados.GetFocusedRowCellValue("idArea").ToString.Trim

        ' Carga los Puestos
        Call ObtenerPuestos(frmForma)
        frmForma.cmbPuesto.EditValue = grvEmpleados.GetFocusedRowCellValue("idPuesto").ToString.Trim

        ' Carga los Estatus
        Call ObtenerEstatus(frmForma)
        frmForma.cmbEstatus.EditValue = grvEmpleados.GetFocusedRowCellValue("idEstatus").ToString.Trim

        ' Carga los Perfiles
        Call ObtenerPerfiles(frmForma)
        frmForma.cmbPerfil.EditValue = grvEmpleados.GetFocusedRowCellValue("idPerfil").ToString.Trim

        ' Fecha de alta
        If Trim(grvEmpleados.GetFocusedRowCellValue("Fecha_Alta").ToString) = "" Then
            frmForma.dteFechaAlta.EditValue = vbNullString
        Else
            frmForma.dteFechaAlta.EditValue = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Fecha_Alta").ToString), "dd/MM/yyyy")
        End If

        ' Fecha de baja
        If Trim(grvEmpleados.GetFocusedRowCellValue("Fecha_Baja").ToString) = "" Then
            frmForma.dteFechaBaja.EditValue = vbNullString
        Else
            frmForma.dteFechaBaja.EditValue = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Fecha_Baja").ToString), "dd/MM/yyyy")
        End If

        ' Motivo
        frmForma.txtMotivo.Text = grvEmpleados.GetFocusedRowCellValue("Motivo").ToString.Trim

        ' Personal
        frmForma.txtEstudios.Text = grvEmpleados.GetFocusedRowCellValue("Estudios").ToString.Trim
        frmForma.txtRFC.Text = grvEmpleados.GetFocusedRowCellValue("RFC").ToString.Trim
        frmForma.txtCURP.Text = grvEmpleados.GetFocusedRowCellValue("CURP").ToString.Trim
        frmForma.txtLicencia.Text = grvEmpleados.GetFocusedRowCellValue("Licencia").ToString.Trim

        ' Vigencia de licencia
        If Trim(grvEmpleados.GetFocusedRowCellValue("Vigencia").ToString) = "" Then
            frmForma.dteVigencia.EditValue = vbNullString
        Else
            frmForma.dteVigencia.EditValue = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Vigencia").ToString), "dd/MM/yyyy")
        End If

        ' Numero de seguridad social
        frmForma.txtNSS.Text = grvEmpleados.GetFocusedRowCellValue("NSS").ToString.Trim

        ' Alta de IMSS
        If Trim(grvEmpleados.GetFocusedRowCellValue("AltaIMSS").ToString) = "" Then
            frmForma.dteAltaIMSS.EditValue = vbNullString
        Else
            frmForma.dteAltaIMSS.EditValue = Format(CDate(grvEmpleados.GetFocusedRowCellValue("AltaIMSS").ToString), "dd/MM/yyyy")
        End If

        ' Baja de IMSS
        If Trim(grvEmpleados.GetFocusedRowCellValue("BajaIMSS").ToString) = "" Then
            frmForma.dteBajaIMSS.EditValue = vbNullString
        Else
            frmForma.dteBajaIMSS.EditValue = Format(CDate(grvEmpleados.GetFocusedRowCellValue("BajaIMSS").ToString), "dd/MM/yyyy")
        End If

        frmForma.txtTelefono.Text = grvEmpleados.GetFocusedRowCellValue("Telefono").ToString.Trim
        frmForma.txtCelular.Text = grvEmpleados.GetFocusedRowCellValue("Celular").ToString.Trim
        frmForma.txtCalle.Text = grvEmpleados.GetFocusedRowCellValue("Calle").ToString.Trim
        frmForma.txtColonia.Text = grvEmpleados.GetFocusedRowCellValue("Colonia").ToString.Trim
        frmForma.txtCiudad.Text = grvEmpleados.GetFocusedRowCellValue("Ciudad").ToString.Trim
        frmForma.txtEstatura.Text = grvEmpleados.GetFocusedRowCellValue("Estatura").ToString.Trim
        frmForma.txtPeso.Text = grvEmpleados.GetFocusedRowCellValue("Peso").ToString.Trim

        ' Fecha de nacimiento
        If Trim(grvEmpleados.GetFocusedRowCellValue("Nacimiento").ToString) = "" Then
            frmForma.dteFechaNacimiento.EditValue = vbNullString
        Else
            frmForma.dteFechaNacimiento.EditValue = Format(CDate(grvEmpleados.GetFocusedRowCellValue("Nacimiento").ToString), "dd/MM/yyyy")
        End If

        frmForma.txtCorreoElectronico.Text = grvEmpleados.GetFocusedRowCellValue("EMail").ToString.Trim
        frmForma.txtSaldo.Text = Val(grvEmpleados.GetFocusedRowCellValue("Saldo").ToString.Trim) 'Format(Val(grvEmpleados.GetFocusedRowCellValue("Saldo").ToString), "Currency")
        frmForma.chkActualizado.Checked = CBool(grvEmpleados.GetFocusedRowCellValue("Actualizar").ToString.Trim)
        frmForma.txtVersion.Text = grvEmpleados.GetFocusedRowCellValue("Version").ToString.Trim
        frmForma.txtMensajeBloqueo.Text = grvEmpleados.GetFocusedRowCellValue("Mensaje").ToString.Trim

        ' Familiares
        Dim tblFamiliares As DataTable = grcFamiliares.DataSource
        frmForma.grcFamiliares.DataSource = tblFamiliares.Copy
    End Sub

    Sub ObtenerAreas(ByRef frmForma As frmNuevoEmpleado)
        Dim strQuery As String

        strQuery = "SELECT " &
                    "	idArea, Area " &
                    "FROM Areas " &
                    "ORDER BY idArea"
        Dim adpAreas As New AdaptadorSql
        Dim tblAreas As DataTable = adpAreas.EjecutarQuery(strQuery, "Areas")

        ' Valida si pudo obtener datos
        If tblAreas Is Nothing Then
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Empleados/Áreas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        frmForma.cmbArea.Properties.DataSource = tblAreas
        frmForma.cmbArea.Properties.DisplayMember = "Area"
        frmForma.cmbArea.Properties.ValueMember = "idArea"
        frmForma.cmbArea.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        frmForma.cmbArea.Properties.SearchMode = SearchMode.AutoComplete
        frmForma.cmbArea.Properties.Columns("idArea").Visible = False

        frmForma.cmbArea.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter
        frmForma.cmbArea.Properties.AutoSearchColumnIndex = 1
    End Sub

    Sub ObtenerEstatus(ByRef frmForma As frmNuevoEmpleado)
        Dim strQuery As String

        strQuery = "SELECT " &
                    "	idEstatus, Estatus " &
                    "FROM Estatus " &
                    "WHERE Tipo = 'Empleados'"
        Dim adpEstatus As New AdaptadorSql
        Dim tblEstatus As DataTable = adpEstatus.EjecutarQuery(strQuery, "Estatus")

        ' Valida si pudo obtener datos
        If tblEstatus Is Nothing Then
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Empleados/Estatus", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        frmForma.cmbEstatus.Properties.DataSource = tblEstatus
        frmForma.cmbEstatus.Properties.DisplayMember = "Estatus"
        frmForma.cmbEstatus.Properties.ValueMember = "idEstatus"
        frmForma.cmbEstatus.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        frmForma.cmbEstatus.Properties.SearchMode = SearchMode.AutoComplete
        frmForma.cmbEstatus.Properties.Columns("idEstatus").Visible = False

        frmForma.cmbEstatus.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter
        frmForma.cmbEstatus.Properties.AutoSearchColumnIndex = 1
    End Sub

    Sub ObtenerPuestos(ByRef frmForma As frmNuevoEmpleado)
        Dim strQuery As String

        strQuery = "SELECT " &
                    "	idPuesto, Puesto " &
                    "FROM Puestos " &
                    "ORDER BY idPuesto"
        Dim adpPuestos As New AdaptadorSql
        Dim tblPuestos As DataTable = adpPuestos.EjecutarQuery(strQuery, "Puestos")

        ' Valida si pudo obtener datos
        If tblPuestos Is Nothing Then
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Empleados/Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        frmForma.cmbPuesto.Properties.DataSource = tblPuestos
        frmForma.cmbPuesto.Properties.DisplayMember = "Puesto"
        frmForma.cmbPuesto.Properties.ValueMember = "idPuesto"
        frmForma.cmbPuesto.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        frmForma.cmbPuesto.Properties.SearchMode = SearchMode.AutoComplete
        frmForma.cmbPuesto.Properties.Columns("idPuesto").Visible = False

        frmForma.cmbPuesto.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter
        frmForma.cmbPuesto.Properties.AutoSearchColumnIndex = 1
    End Sub

    Sub ObtenerPerfiles(ByRef frmForma As frmNuevoEmpleado)
        Dim strQuery As String

        strQuery = "SELECT " &
                    "	idPerfil, Perfil " &
                    "FROM Perfiles " &
                    "ORDER BY Perfil"
        Dim adpPerfiles As New AdaptadorSql
        Dim tblPerfiles As DataTable = adpPerfiles.EjecutarQuery(strQuery, "Perfiles")

        ' Valida si pudo obtener datos
        If tblPerfiles Is Nothing Then
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Empleados/Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        frmForma.cmbPerfil.Properties.DataSource = tblPerfiles
        frmForma.cmbPerfil.Properties.DisplayMember = "Perfil"
        frmForma.cmbPerfil.Properties.ValueMember = "idPerfil"
        frmForma.cmbPerfil.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        frmForma.cmbPerfil.Properties.SearchMode = SearchMode.AutoComplete
        frmForma.cmbPerfil.Properties.Columns("idPerfil").Visible = False

        frmForma.cmbPerfil.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter
        frmForma.cmbPerfil.Properties.AutoSearchColumnIndex = 1
    End Sub

    Private Sub bbiEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEliminar.ItemClick
        ' Solicita confirmación
        Dim strConfirmacion As String = "Se dispone a Eliminar al Empleado{0}Numero: {1}{0}Nombre: {2}{0}¿Desea continuar?"
        strConfirmacion = String.Format(strConfirmacion, vbCrLf, grvEmpleados.GetFocusedRowCellValue("Numero").ToString.Trim, grvEmpleados.GetFocusedRowCellValue("Nombre").ToString.Trim)
        If MessageBox.Show(strConfirmacion, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        ' Elimina el Registro
        Dim strQuery As String
        strQuery = "DELETE " &
                    "FROM Empleados " &
                    "WHERE idEmpleado = " & grvEmpleados.GetFocusedRowCellValue("idEmpleado").ToString.Trim
        Dim adpEmpleado As New AdaptadorSql
        Dim tblEmpleado As DataTable = adpEmpleado.EjecutarQuery(strQuery, "Empleado")

        ' Actualiza la vista de Empleados
        Call CargarEmpleados()
        MessageBox.Show("Empleado eliminado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub grcEmpleados_Click(sender As Object, e As EventArgs) Handles grcEmpleados.Click

    End Sub
End Class