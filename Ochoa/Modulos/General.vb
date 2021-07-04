Module General
    ' Login / Perfil
    Public strCUIdUsuario As String = ""          ' Id. del Usuario
    Public strCUNombreUsuario As String = ""      ' Nombre completo del usuario
    Public strCUIdPerfil As String = ""           ' Id. del Perfil (Nivel)
    Public strCUDscPerfil As String = ""          ' Descripción del Perfil (Nivel)
    Public strCUEmail As String = ""              ' Correo Electronico
    Public strCUServidor As String = ""           ' Servidor
    Public strCUBaseDatos As String = ""          ' Base de Datos
    Public strVersionSistema As String            ' Versión del sistemas

    Public drwRowLogin As DataRow                 ' Todos los datos que se leyeron en el Login
    Public dtlPerfil As New DataTable             ' Almacena la informaciòn del Perfil

End Module
