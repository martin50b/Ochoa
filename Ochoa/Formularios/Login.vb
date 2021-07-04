Imports dllMsSQL

Public Class frmLogin
    Dim DX, DY As Integer

    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown, txtContraseña.KeyDown
        ' Presionan la tecla ENTER
        If e.KeyCode = Keys.Enter Then
            Select Case sender.name.ToString
                Case "txtUsuario"
                    txtContraseña.Focus()

                Case "txtContraseña"
                    If txtUsuario.Text.Trim <> "" And txtContraseña.Text.Trim <> "" Then
                        btnIngresar_Click(Nothing, Nothing)
                    Else
                        btnIngresar.Focus()
                    End If
            End Select
        End If
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Verifica que se tenga un Usuario
        If txtUsuario.Text.Trim = "" Then
            MessageBox.Show("No ha especificado un Usuario", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtUsuario.Focus()
            Exit Sub
        End If
        ' Verifica que se tenga una Contraseña
        If txtContraseña.Text.Trim = "" Then
            MessageBox.Show("No ha especificado una Contraseña", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtContraseña.Focus()
            Exit Sub
        End If

        ' Busca el registro en la base de datos, con el Usuario y Contraseña
        Dim strQuery As String
        strQuery = "SELECT " &
                    "	a.idEmpleado, a.Nombre, a.Login, a.Pass, a.idArea, c.Area, a.idPuesto, d.Puesto, " &
                    "    a.idEstatus, e.Estatus ,a.Estudios, a.RFC, a.CURP, " &
                    "    a.Licencia, a.Vigencia, a.Fecha_Alta, a.Fecha_Baja, a.Motivo, a.NSS, a.AltaIMSS, a.BajaIMSS, " &
                    "    a.Telefono, a.Celular, a.Calle, a.Colonia, a.Ciudad, a.Estatura, a.Peso, a.Nacimiento, " &
                    "    a.EMail, a.Saldo, a.idPerfil, a.Mensaje, a.Actualizar, a.Version, " &
                    "    b.Perfil AS DscPerfil " &
                    "FROM Empleados a " &
                    "LEFT JOIN Perfiles b ON b.idPerfil = a.idPerfil " &
                    "LEFT JOIN Areas c ON c.idArea = a.idArea " &
                    "LEFT JOIN Puestos d ON d.idPuesto = a.idPuesto " &
                    "LEFT JOIN Estatus e ON e.idEstatus = a.idEstatus AND e.Tipo = 'Empleados' " &
                    "WHERE a.Login = '{0}' " &
                    "AND a.Pass = '{1}'"
        strQuery = String.Format(strQuery, txtUsuario.Text, txtContraseña.Text)
        Dim adpUsuarios As New AdaptadorSql
        Dim tblLogin As DataTable = adpUsuarios.EjecutarQuery(strQuery, "Login")
        ' Valida si pudo obtener datos
        If tblLogin Is Nothing Then
            MessageBox.Show(String.Format("Se generó un problema al intentar acceder al servidor.{0}Por favor Intente nuevamente.", vbCrLf), "Login", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If tblLogin.Rows.Count > 0 Then
            ' Verifica si esta activa la cuenta
            If tblLogin.Rows(0)("idEstatus").ToString.Trim = "0" Then
                MessageBox.Show("La cuenta esta deshabilitada", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                txtUsuario.Focus()
                Exit Sub
            End If
            ' Verifica si esta bloqueada la cuenta
            If tblLogin.Rows(0)("idEstatus").ToString.Trim = "2" Then
                MessageBox.Show(tblLogin.Rows(0)("Mensaje").ToString.Trim, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                txtUsuario.Focus()
                Exit Sub
            End If
            ' Verifica si tiene Perfil existente
            If tblLogin.Rows(0)("idPerfil").ToString.Trim = "" Then
                MessageBox.Show(String.Format("La cuenta no tiene asignado un Perfil.{0}Contacte al Administrador del sistema.", vbCrLf), "Login", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                txtUsuario.Focus()
                Exit Sub
            End If

            ' ACTUALIZAR LA APLICACIÓN
            'Dim strVersionLocal() As String = Application.ProductVersion.ToString.Split(CChar("."))
            Dim strVersionDB As String = tblLogin.Rows(0)("Version").ToString.Trim
            strVersionSistema = Application.ProductVersion.ToString 'strVersionLocal(0)

            ' Verifica si debe ejecutarse la actualización
            If strVersionSistema <> strVersionDB Then
                Dim sRuta As String = System.AppDomain.CurrentDomain.BaseDirectory
                If sRuta.Substring(sRuta.Length - 1, 1) <> "\" Then sRuta = sRuta & "\"
                Dim sRutaActualizador As String = String.Format("{0}Actualizador.exe", sRuta)

                ' Verifica que exista el Actualizador
                If Not My.Computer.FileSystem.FileExists(sRutaActualizador) Then
                    MessageBox.Show(String.Format("No se encontró el actualizador.{0}Contacte a su administrador del sistema.", vbCrLf), "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                    Me.Dispose()
                    End
                End If

                ' Marca el perfil como actualizado
                strQuery = "UPDATE Empleados " &
                            "SET Actualizar = '0' " &
                String.Format("WHERE idEmpleado = {0} ", tblLogin.Rows(0)("idEmpleado").ToString)
                Dim tblActualizar As DataTable = adpUsuarios.EjecutarQuery(strQuery, "Actualizador")

                ' Ejecuta el Actualizador de la Aplicación
                Try
                    Dim Proceso As New Process()
                    Proceso.StartInfo.FileName = sRutaActualizador
                    Proceso.StartInfo.Arguments = ""
                    Proceso.Start()
                    End

                Catch ex As Exception
                    MessageBox.Show(String.Format("Error al ejecutar el actualizador.{0}Contacte a su administrador del sistema.", vbCrLf), "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End
                End Try
            End If

            ' Toma los datos del usuario que se firmo
            strCUIdUsuario = tblLogin.Rows(0)("idEmpleado").ToString
            strCUNombreUsuario = tblLogin.Rows(0)("Nombre").ToString
            strCUIdPerfil = tblLogin.Rows(0)("idPerfil").ToString
            strCUDscPerfil = tblLogin.Rows(0)("DscPerfil").ToString
            strCUEmail = tblLogin.Rows(0)("EMail").ToString

            ' Obtiene el Servidor/Base de datos
            Dim sServidor() As String = adpUsuarios.ObtenerCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg").ToString.Split(CChar(";"))
            strCUServidor = sServidor(0).ToUpper.Replace("DATA SOURCE=", "").Trim
            strCUBaseDatos = sServidor(1).ToUpper.Replace("INITIAL CATALOG=", "").Trim

            ' Respalda toda la fila en un objeto global para compartirlo con otros modulos
            drwRowLogin = tblLogin.Rows(0)

            ' Manda llamar Splash
            frmSplash.Show()
            Me.Visible = False
            Exit Sub
        Else
            ' No se encontro al usuario
            MessageBox.Show("Usuario y/o Contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtUsuario.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Try
            ' Cierra y elimina de memoria el formulario
            Me.Close()
            Me.Dispose()

            ' Hace una pausa de 1/4 segundo
            System.Threading.Thread.Sleep(250)

            ' Finaliza la aplicación
            End

        Catch ex As Exception
            ' Sin procesos
        End Try
    End Sub

    Private Sub frmLogin_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ' Cuando se mueve el ratón y se pulsa el botón izquierdo... mover el control
        If e.Button = MouseButtons.Left Then
            CType(sender, Control).Left = e.X + CType(sender, Control).Left - DX
            CType(sender, Control).Top = e.Y + CType(sender, Control).Top - DY
        End If
    End Sub

    Private Sub frmLogin_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ' Cuando se pulsa con el ratón
        DX = e.X
        DY = e.Y
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ' en terioria eso nos cambia la cadena de conexion ..

        Dim cambiar_cadena As New AdaptadorSql
        cambiar_cadena.GuardarCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg", "Data Source=192.168.0.204;Initial Catalog=ochoa;Persist Security Info=True;User ID=ochoa;password=ochoa_mexico")
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Crear el archivo con la cadena de conexión
        'Dim adpConexion As New AdaptadorSql
        'adpConexion.GuardarCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg", "Data Source=PMOSRV\SQLEXPRESSKAS;Initial Catalog=Ochoa;Persist Security Info=True;User ID=Ochoa;password=Osql2021")
        'adpConexion.GuardarCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg", "Data Source=189.141.106.110;Initial Catalog=Ochoa;Persist Security Info=True;User ID=Ochoa;password=Osql2021")
        'adpConexion.GuardarCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg", "Data Source=192.168.1.8;Initial Catalog=Ochoa;Persist Security Info=True;User ID=Ochoa;password=Osql2021")
        'adpConexion.GuardarCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg", "Data Source=ESCRITORIO10;Initial Catalog=Ochoa;Persist Security Info=True;User ID=Ochoa;password=Osql2021")
    End Sub

End Class