Module General
    ' Login
    Public drwRowLogin As DataRow       ' Todos los datos que se leyeron en el Login
    Public VersionSistema As String     ' Version del sistema

    ' Perfiles
    Public strIdPerfil As String        ' IdPerfil : Toma el IdPerfil para tenerlo disponible en otros formularios
    Public strPerfil As String          ' Perfil : Toma el Perfil para tenerlo disponible en otros formularios
    Public strDescripcion As String     ' Descripcion : Toma la Descripción para tenerla disponible en otros formularios
    Public intAsignados As String       ' Asignados : Extrae el numero de cuentas que tienen asignados el Perfile
    Public bolNuevoPerfil As Boolean    ' Bandera que indica si se trata de un Nuevo Perfil (True) o de una edición (False)

    ' <summary>Centra un 'GroupControl'</summary>
    ' <value>Objeto 'GroupControl'</value>
    ' <returns>N/A</returns>
    ' <example>CentrarEnParent(MiGroupControl)</example>
    ' <remarks>Gustavo Robles</remarks>
    Sub CentrarEnParent(ByRef frm As DevExpress.XtraEditors.GroupControl)
        Try
            frm.Left = Mayor((frm.Parent.ClientSize.Width - frm.Width) / 2, 0)
            frm.Top = Mayor((frm.Parent.ClientSize.Height - frm.Height) / 2, 0)
        Catch ex As Exception
            ' Sin proceso
        End Try
    End Sub
    Function Mayor(ByRef x As Double, ByRef y As Double) As Integer
        Return Convert.ToInt32(IIf(x > y, x, y))
    End Function
End Module
