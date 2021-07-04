Imports System.Drawing
Imports System.Windows.Forms
Imports dllMsSQL

Public Class frmNuevoEmpleado
    Private Sub frmNuevoEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verifica si se trata de un Nuevo Perfil o de una Edición
        If bolNuevoEmpleado Then
            ' Titulo
            Me.Text = "Nuevo Empleado"

        Else
            ' Titulo
            Me.Text = "Editar Empleado"

        End If
    End Sub

    Private Sub bbiCerrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiCerrar.ItemClick
        ' Cierra el formulario, regresando a la pantalla principal
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub bbiGuardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiGuardar.ItemClick
        ' Verifica que la información este completa
        If Not ValidarDatos() Then Exit Sub

        ' Solicita confirmación
        If MessageBox.Show("Se dispone a guardar la información. ¿Desea continuar?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        ' Almacena la información
        Call GuardarEmpleado()
        MessageBox.Show("La información ha sido guardada", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Cierra el formulario
        Me.Close()
        Me.Dispose()
    End Sub

    Sub GuardarEmpleado()
        Dim strQuery As String = ""
        Dim adsEmpleado As New AdaptadorSql
        Dim tblGuardarEmpleado As DataTable

        ' Nuevo registro
        If bolNuevoEmpleado Then
            ' Genera el INSERT
            strQuery = "INSERT INTO Empleados " &
                        "	(idEmpleado, Numero, Nombre, Login, Pass, idArea, idPuesto, idEstatus, Estudios, RFC, CURP, " &
                        "	 Licencia, Vigencia, Fecha_Alta, Fecha_Baja, Motivo, NSS, AltaIMSS, BajaIMSS, Telefono, Celular, " &
                        "	 Calle, Colonia, Ciudad, Estatura, Peso, Nacimiento, EMail, Saldo, idPerfil, " &
                        "    Foto, Mensaje, Actualizar, Version) " &
                        "VALUES ((SELECT isnull(max(idEmpleado) + 1,1) AS idEmpleado FROM Empleados) " &
                        "		, '{0}' " &
                        "		, '{1}' " &
                        "		, '{2}' " &
                        "		, '{3}' " &
                        "		, {4} " &
                        "		, {5} " &
                        "		, {6} " &
                        "		, '{7}' " &
                        "		, '{8}' " &
                        "		, '{9}' " &
                        "		, '{10}' " &
                        "		, {11} " &
                        "		, {12} " &
                        "		, {13} " &
                        "		, '{14}' " &
                        "		, '{15}' " &
                        "		, {16} " &
                        "		, {17} " &
                        "		, '{18}' " &
                        "		, '{19}' " &
                        "		, '{20}' " &
                        "		, '{21}' " &
                        "		, '{22}' " &
                        "		, {23} " &
                        "		, {24} " &
                        "		, {25} " &
                        "		, '{26}' " &
                        "		, {27} " &
                        "		, {28} " &
                        "		, '{29}' " &
                        "		, '{30}' " &
                        "		, '{31}' " &
                        "		, '{32}')"

        Else
            ' Genera el UPDATE
            strQuery = "UPDATE Empleados " &
                        "SET Numero = '{0}' " &
                        "	, Nombre = '{1}' " &
                        "	, Login = '{2}' " &
                        "	, Pass = '{3}' " &
                        "	, idArea = {4} " &
                        "	, idPuesto = {5} " &
                        "	, idEstatus = {6} " &
                        "	, Estudios = '{7}' " &
                        "	, RFC = '{8}' " &
                        "	, CURP = '{9}' " &
                        "	, Licencia = '{10}' " &
                        "	, Vigencia = {11} " &
                        "	, Fecha_Alta = {12} " &
                        "	, Fecha_Baja = {13} " &
                        "	, Motivo = '{14}' " &
                        "	, NSS = '{15}' " &
                        "	, AltaIMSS = {16} " &
                        "	, BajaIMSS = {17} " &
                        "	, Telefono = '{18}' " &
                        "	, Celular = '{19}' " &
                        "	, Calle = '{20}' " &
                        "	, Colonia = '{21}' " &
                        "	, Ciudad = '{22}' " &
                        "	, Estatura = {23} " &
                        "	, Peso = {24} " &
                        "	, Nacimiento = {25} " &
                        "	, EMail = '{26}' " &
                        "	, Saldo = {27} " &
                        "	, idPerfil = {28} " &
                        "	, Foto = '{29}' " &
                        "	, Mensaje = '{30}' " &
                        "	, Actualizar = '{31}' " &
                        "	, Version = '{32}' " &
                        "WHERE idEmpleado = " & strIdEmpleado
        End If

        ' Pasa los datos al Query
        Dim strVigencia As String
        Dim strFechaAlta As String
        Dim strFechaBaja As String
        Dim strAltaIMSS As String
        Dim strBajaIMSS As String
        Dim strFechaNacimiento As String
        Dim strActualizado As String

        ' Vigencia
        If dteVigencia.EditValue Is vbNullString Then
            strVigencia = "NULL"
        Else
            strVigencia = String.Format("'{0}'", Format(CDate(dteVigencia.EditValue), "yyyy-MM-dd"))
        End If
        ' Fecha de Alta
        If dteFechaAlta.EditValue Is vbNullString Then
            strFechaAlta = "NULL"
        Else
            strFechaAlta = String.Format("'{0}'", Format(CDate(dteFechaAlta.EditValue), "yyyy-MM-dd"))
        End If
        ' Fecha de Baja
        If dteFechaBaja.EditValue Is vbNullString Then
            strFechaBaja = "NULL"
        Else
            strFechaBaja = String.Format("'{0}'", Format(CDate(dteFechaBaja.EditValue), "yyyy-MM-dd"))
        End If
        ' Alta IMSS
        If dteAltaIMSS.EditValue Is vbNullString Then
            strAltaIMSS = "NULL"
        Else
            strAltaIMSS = String.Format("'{0}'", Format(CDate(dteAltaIMSS.EditValue), "yyyy-MM-dd"))
        End If
        ' Baja IMSS
        If dteBajaIMSS.EditValue Is vbNullString Then
            strBajaIMSS = "NULL"
        Else
            strBajaIMSS = String.Format("'{0}'", Format(CDate(dteBajaIMSS.EditValue), "yyyy-MM-dd"))
        End If
        ' Fecha de Nacimiento
        If dteFechaNacimiento.EditValue Is vbNullString Then
            strFechaNacimiento = "NULL"
        Else
            strFechaNacimiento = String.Format("'{0}'", Format(CDate(dteFechaNacimiento.EditValue), "yyyy-MM-dd"))
        End If
        ' Actualizado
        If chkActualizado.Checked Then strActualizado = "1" Else strActualizado = "0"

        strQuery = String.Format(strQuery, txtNumero.Text, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, cmbArea.EditValue, cmbPuesto.EditValue, cmbEstatus.EditValue, txtEstudios.Text, txtRFC.Text, txtCURP.Text,
                                 txtLicencia.Text, strVigencia, strFechaAlta, strFechaBaja, txtMotivo.Text, txtNSS.Text, strAltaIMSS, strBajaIMSS, txtTelefono.Text, txtCelular.Text,
                                 txtCalle.Text, txtColonia.Text, txtCiudad.Text, Val(txtEstatura.Text), Val(txtPeso.Text), strFechaNacimiento, txtCorreoElectronico.Text, Val(txtSaldo.EditValue), cmbPerfil.EditValue,
                                 picFotografia.Tag, txtMensajeBloqueo.Text, strActualizado, txtVersion.Text)
        ' Ejecuta el Query
        tblGuardarEmpleado = adsEmpleado.EjecutarQuery(strQuery, "Empleado")


        ' FAMILIARES
        ' Si esta editando elimina los registros existentes
        If Not bolNuevoEmpleado Then
            ' Editar: Elimina los Familiares registrados
            strQuery = "DELETE " &
                    "FROM Familiares " &
                    "WHERE idEmpleado = " & strIdEmpleado
            tblGuardarEmpleado = adsEmpleado.EjecutarQuery(strQuery, "Empleado")
        Else
            ' Nuevo: Obtiene el folio del ultimo Empleado registrado
            strQuery = "SELECT " &
                "	max(idEmpleado) AS idEmpleado " &
                "FROM Empleados"
            tblGuardarEmpleado = adsEmpleado.EjecutarQuery(strQuery, "Empleado")
            If Not tblGuardarEmpleado Is Nothing Then
                strIdEmpleado = tblGuardarEmpleado.Rows(0)("idEmpleado").ToString
            End If
        End If

        ' Guarda los Familiares
        Dim tblFamiliares As DataTable = grcFamiliares.DataSource
        ' Verifica que el Datatable de Familiares no sea Nothing.
        If Not tblFamiliares Is Nothing Then
            ' Inserta los registros
            If tblFamiliares.Rows.Count > 0 Then
                For intRow = 0 To tblFamiliares.Rows.Count - 1
                    strQuery = "INSERT INTO Familiares (idFamiliar, idEmpleado, Nombre, Parentesco, Edad) " &
                                "VALUES ((SELECT isnull(max(idFamiliar),1) + 1 AS idFamiliar FROM Familiares) " &
                                "		, {0} " &
                                "		, '{1}' " &
                                "		, '{2}' " &
                                "		, {3})"
                    strQuery = String.Format(strQuery, strIdEmpleado, tblFamiliares.Rows(intRow)("Nombre").ToString.Trim, tblFamiliares.Rows(intRow)("Parentesco").ToString.Trim, Val(tblFamiliares.Rows(intRow)("Edad").ToString.Trim))
                    tblGuardarEmpleado = adsEmpleado.EjecutarQuery(strQuery, "Familiar")
                Next
            End If
        End If

    End Sub

    Function ValidarDatos() As Boolean
        ' Numero del empleado
        If Trim(txtNumero.Text) = "" Then
            MessageBox.Show("No ha especificado el Numero del empleado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            txtNumero.Focus()
            Return False
        End If
        ' Nombre del empleado
        If Trim(txtNombre.Text) = "" Then
            MessageBox.Show("No ha especificado el Nombre del empleado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            txtNombre.Focus()
            Return False
        End If
        ' Usuario
        If Trim(txtUsuario.Text) = "" Then
            MessageBox.Show("No ha especificado el Usuario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            txtUsuario.Focus()
            Return False
        End If
        ' Contraseña
        If Trim(txtContrasena.Text) = "" Then
            MessageBox.Show("No ha especificado la Contraseña", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            txtContrasena.Focus()
            Return False
        End If
        ' Área
        If cmbArea.EditValue Is vbNullString Then
            MessageBox.Show("No ha especificado el Área", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            cmbArea.Focus()
            Return False
        End If
        ' Puesto
        If cmbPuesto.EditValue Is vbNullString Then
            MessageBox.Show("No ha especificado el Puesto", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            cmbPuesto.Focus()
            Return False
        End If
        ' Estatus
        If cmbEstatus.EditValue Is vbNullString Then
            MessageBox.Show("No ha especificado el Estatus", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            cmbEstatus.Focus()
            Return False
        End If
        ' Perfil
        If cmbPerfil.EditValue Is vbNullString Then
            MessageBox.Show("No ha especificado el Perfil", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 0
            cmbPerfil.Focus()
            Return False
        End If

        ' Licencia / Vigencia
        If Trim(txtLicencia.Text) <> "" Then
            ' Verifica que exista una fecha de Vigencia
            If dteVigencia.EditValue Is vbNullString Then
                MessageBox.Show("No ha especificado la Fecha de Vigencia", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                dteVigencia.Focus()
                Return False
            End If
        End If

        ' NSS / ALta IMSS
        If Trim(txtNSS.Text) <> "" Then
            ' Verifica que exista una fecha de Alta
            If dteAltaIMSS.EditValue Is vbNullString Then
                MessageBox.Show("No ha especificado la Fecha de Alta IMSS", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                dteAltaIMSS.Focus()
                Return False
            End If
        End If

        ' Calle / Colonia / Ciudad
        If Trim(txtCalle.Text) <> "" Then
            ' Colonia
            If Trim(txtColonia.Text) = "" Then
                MessageBox.Show("No ha especificado la Colonia", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                txtColonia.Focus()
                Return False
            End If
            ' Ciudad
            If Trim(txtCiudad.Text) = "" Then
                MessageBox.Show("No ha especificado la Ciudad", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                txtCiudad.Focus()
                Return False
            End If
        End If

        ' Calle / Colonia / Ciudad
        If Trim(txtColonia.Text) <> "" Then
            ' Colonia
            If Trim(txtCalle.Text) = "" Then
                MessageBox.Show("No ha especificado la Calle", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                txtCalle.Focus()
                Return False
            End If
            ' Ciudad
            If Trim(txtCiudad.Text) = "" Then
                MessageBox.Show("No ha especificado la Ciudad", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                txtCiudad.Focus()
                Return False
            End If
        End If

        ' Calle / Colonia / Ciudad
        If Trim(txtCiudad.Text) <> "" Then
            ' Colonia
            If Trim(txtCalle.Text) = "" Then
                MessageBox.Show("No ha especificado la Calle", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                txtCalle.Focus()
                Return False
            End If
            ' Ciudad
            If Trim(txtColonia.Text) = "" Then
                MessageBox.Show("No ha especificado la Colonia", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 1
                txtColonia.Focus()
                Return False
            End If
        End If

        ' Verifica que el Usuario no exista
        Dim strQuery As String
        strQuery = "SELECT " &
                    "	* " &
                    "FROM Empleados " &
                    "WHERE Login = '{0}' " &
                    "AND idEmpleado <> {1} "
        strQuery = String.Format(strQuery, txtUsuario.Text.Trim, strIdEmpleado)
        Dim adpUsuario As New AdaptadorSql
        Dim tblUsuario As DataTable = adpUsuario.EjecutarQuery(strQuery, "Usuario")
        ' Valida si pudo obtener datos
        If Not tblUsuario Is Nothing Then
            ' Ya existe el usuario
            If tblUsuario.Rows.Count > 0 Then
                MessageBox.Show("Ya existe el Usuario, indique otro Usuario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 0
                txtUsuario.Focus()
                Return False
            End If
        End If

        ' Verifica que no exista el Numero
        strQuery = "SELECT " &
                "	* " &
                "FROM Empleados " &
                "WHERE Numero = '{0}' " &
                "AND idEmpleado <> {1}"
        If bolNuevoEmpleado Then
            ' Nuevo
            strQuery = String.Format(strQuery, txtNumero.Text.Trim, 0)
        Else
            ' Modificar
            strQuery = String.Format(strQuery, txtNumero.Text.Trim, strIdEmpleado)
        End If

        Dim tblNumero As DataTable = adpUsuario.EjecutarQuery(strQuery, "Numero")
        ' Valida si pudo obtener datos
        If Not tblNumero Is Nothing Then
            ' Ya existe el usuario
            If tblNumero.Rows.Count > 0 Then
                MessageBox.Show("Ya existe el Número de Usuario, indique otro Número", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                xtcEmpleado.SelectedTabPageIndex = 0
                txtNumero.Focus()
                Return False
            End If
        End If

        ' La información esta completa
        Return True
    End Function

    Private Sub btnCargarFoto_Click(sender As Object, e As EventArgs) Handles btnCargarFoto.Click
        ofdAbrirArchivo.ShowDialog()

        If (ofdAbrirArchivo.FileName) <> "" Then
            Try
                ' Carga el archivo de imagen seleccionado
                picFotografia.Image = Image.FromFile(ofdAbrirArchivo.FileName)
                picFotografia.Tag = ofdAbrirArchivo.FileName

            Catch ex As Exception
                ' No se puede cargar la imagen
                MessageBox.Show("No se puede leer el archivo", "Subir foto", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub btnQuitarFoto_Click(sender As Object, e As EventArgs) Handles btnQuitarFoto.Click
        ' Coloca la imagen por Default
        picFotografia.Image = picFotografia2.Image
        picFotografia.Tag = ""
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Verifica el Nombre del pariente
        If Trim(txtNombrePariente.Text) = "" Then
            MessageBox.Show("No ha especificado Nombre del pariente", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 2
            txtNombrePariente.Focus()
            Exit Sub
        End If
        ' Verifica el Parentesco
        If Trim(txtParentesco.Text) = "" Then
            MessageBox.Show("No ha especificado Parentesco", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 2
            txtParentesco.Focus()
            Exit Sub
        End If
        ' Verifica la edad
        If Trim(txtEdad.Text) = "" Or Val(txtEdad.Text) = 0 Then
            MessageBox.Show("No ha especificado la Edad", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            xtcEmpleado.SelectedTabPageIndex = 2
            txtEdad.Focus()
            Exit Sub
        End If

        ' Toma la información del Grid
        Dim tblTemp As DataTable = grcFamiliares.DataSource

        ' Verifica que no exista el elemento en la lista
        If Not tblTemp Is Nothing Then
            If tblTemp.Rows.Count > 0 Then
                For intRow = 0 To tblTemp.Rows.Count - 1
                    If UCase(tblTemp.Rows(intRow)("Nombre").ToString.Trim) = txtNombrePariente.Text.Trim And
                    UCase(tblTemp.Rows(intRow)("Parentesco").ToString.Trim) = txtParentesco.Text.Trim And
                    Val(tblTemp.Rows(intRow)("Edad").ToString.Trim) = Val(txtEdad.Text) Then
                        ' Ya existe un registro identico
                        MessageBox.Show("El Pariente ya esta en la lista", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        xtcEmpleado.SelectedTabPageIndex = 2
                        txtNombrePariente.Focus()
                        Exit Sub
                    End If
                Next
            End If
        Else
            ' Arma la estructura del DataTable
            Dim strQuery As String
            strQuery = "SELECT " &
                        "	idFamiliar, idEmpleado, Nombre, Parentesco, Edad " &
                        "FROM Familiares " &
                        "WHERE idFamiliar = 0"
            Dim adpFamiliar As New AdaptadorSql
            tblTemp = adpFamiliar.EjecutarQuery(strQuery, "Numero")
        End If

        ' Agrega información al DataTable
        Dim dtrRegistro As DataRow = tblTemp.NewRow
        dtrRegistro("idFamiliar") = 0
        dtrRegistro("idEmpleado") = strIdEmpleado
        dtrRegistro("Nombre") = txtNombrePariente.Text.Trim
        dtrRegistro("Parentesco") = txtParentesco.Text.Trim
        dtrRegistro("Edad") = Val(txtEdad.Text)
        tblTemp.Rows.Add(dtrRegistro)

        ' Actualiza la información en el Grid
        grcFamiliares.DataSource = tblTemp
        grcFamiliares.RefreshDataSource()

        ' Limpia las cajas de texto
        txtNombrePariente.Text = ""
        txtParentesco.Text = ""
        txtEdad.Text = ""

        ' Restablece los botones
        btnEditar.Visible = True
        btnQuitar.Visible = True
        btnCancelar.Visible = False
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        ' Toma los registros del Grid
        Dim tblTemp As DataTable = grcFamiliares.DataSource

        ' Verifica que el DataTable contenga información
        If tblTemp Is Nothing Then Exit Sub

        ' Verifica que contenga Registros
        If tblTemp.Rows.Count > 0 Then
            ' Confirmación
            Dim strConfirmacion As String = "Se dispone a quitar al familiar{0}Nombre: {1}{0}Parentesco: {2}{0}Edad: {3}{0}¿Desea continuar?"
            strConfirmacion = String.Format(strConfirmacion, vbCrLf, grvFamiliares.GetFocusedRowCellValue("Nombre").ToString.Trim, grvFamiliares.GetFocusedRowCellValue("Parentesco").ToString.Trim, grvFamiliares.GetFocusedRowCellValue("Edad").ToString.Trim)
            If MessageBox.Show(strConfirmacion, "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            ' Elimina el Registro
            Call QuitarFamiliar(tblTemp)

            'For intRow = 0 To tblTemp.Rows.Count - 1
            '    If tblTemp.Rows(intRow)("Nombre").ToString.Trim = grvFamiliares.GetFocusedRowCellValue("Nombre").ToString.Trim And
            '        tblTemp.Rows(intRow)("Parentesco").ToString.Trim = grvFamiliares.GetFocusedRowCellValue("Parentesco").ToString.Trim And
            '        Val(tblTemp.Rows(intRow)("Edad").ToString.Trim) = Val(grvFamiliares.GetFocusedRowCellValue("Edad").ToString.Trim) Then
            '        ' Eimina el Registro
            '        tblTemp.Rows(intRow).Delete()
            '        tblTemp.AcceptChanges()
            '        ' Sale del For
            '        Exit For
            '    End If
            'Next
        End If

        ' Actualiza la información en el Grid
        grcFamiliares.DataSource = tblTemp
        grvFamiliares.RefreshData()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        ' Toma los registros del Grid
        Dim tblTemp As DataTable = grcFamiliares.DataSource

        ' Verifica que el DataTable contenga información
        If tblTemp Is Nothing Then Exit Sub

        ' Verifica que contenga Registros
        If tblTemp.Rows.Count > 0 Then
            ' Coloca la información en las cajas de texto
            txtNombrePariente.Text = grvFamiliares.GetFocusedRowCellValue("Nombre").ToString.Trim
            txtNombrePariente.Tag = grvFamiliares.GetFocusedRowCellValue("Nombre").ToString.Trim
            txtParentesco.Text = grvFamiliares.GetFocusedRowCellValue("Parentesco").ToString.Trim
            txtParentesco.Tag = grvFamiliares.GetFocusedRowCellValue("Parentesco").ToString.Trim
            txtEdad.Text = Val(grvFamiliares.GetFocusedRowCellValue("Edad").ToString.Trim)
            txtEdad.Tag = Val(grvFamiliares.GetFocusedRowCellValue("Edad").ToString.Trim)

            ' Quita el elemento del Grid
            Call QuitarFamiliar(tblTemp)

            ' Oculta los controles
            btnEditar.Visible = False
            btnQuitar.Visible = False
            btnCancelar.Visible = True
        End If
    End Sub

    Sub QuitarFamiliar(ByVal tblFamiliares As DataTable)
        ' Elimina el Registro
        For intRow = 0 To tblFamiliares.Rows.Count - 1
            If tblFamiliares.Rows(intRow)("Nombre").ToString.Trim = grvFamiliares.GetFocusedRowCellValue("Nombre").ToString.Trim And
                tblFamiliares.Rows(intRow)("Parentesco").ToString.Trim = grvFamiliares.GetFocusedRowCellValue("Parentesco").ToString.Trim And
                Val(tblFamiliares.Rows(intRow)("Edad").ToString.Trim) = Val(grvFamiliares.GetFocusedRowCellValue("Edad").ToString.Trim) Then

                ' Eimina el Registro
                tblFamiliares.Rows(intRow).Delete()
                tblFamiliares.AcceptChanges()

                ' Sale del For
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Coloca la información Original en las cajas
        txtNombrePariente.Text = txtNombrePariente.Tag
        txtNombrePariente.Text = txtNombrePariente.Tag
        txtEdad.Text = txtEdad.Tag

        ' Registra el registro al Grid
        Call btnAgregar_Click(Nothing, Nothing)

        ' Restablece los botones
        btnEditar.Visible = True
        btnQuitar.Visible = True
        btnCancelar.Visible = False
    End Sub

    Private Sub grcFamiliares_DoubleClick(sender As Object, e As EventArgs) Handles grcFamiliares.DoubleClick
        ' Edita el registro, dando doble clic sobre el Grid
        Call btnEditar_Click(Nothing, Nothing)
    End Sub
End Class