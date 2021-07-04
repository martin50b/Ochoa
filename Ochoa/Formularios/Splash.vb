Imports dllMsSQL

Public Class frmSplash
    Dim iMsg As Integer = 1

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblBienvenida.Text = "Bienvenido " & strCUNombreUsuario
        lblBienvenida.Refresh()

        lblVersion.Text = "Versión " & Application.ProductVersion.ToString()
        lblVersion.Refresh()
    End Sub

    Private Sub frmSplash_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        tmrSplash.Enabled = True
    End Sub

    Private Sub tmrSplash_Tick(sender As Object, e As EventArgs) Handles tmrSplash.Tick
        '** Carga el Perfil del usuario **
        ' Muestra en pantalla la actividad
        lblMensaje.Text = "Cargando permisos del usuario..." : lblMensaje.Refresh()
        ' Obtien el Perfil de permisos del usuario
        Dim adsGeneral As New AdaptadorSql
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
        strQueryPerfiles = String.Format(strQueryPerfiles, strCUIdPerfil)
        ' Extrae los Perfiles
        dtlPerfil = adsGeneral.EjecutarQuery(strQueryPerfiles, "Perfiles")

        ' Carga la Pantalla principal
        frmMain.Show()
        Me.Close()
    End Sub

End Class