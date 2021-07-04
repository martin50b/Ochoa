Module General
    ' Login
    Public drwRowLogin As DataRow       ' Todos los datos que se leyeron en el Login
    Public VersionSistema As String     ' Version del sistema

    ' Empleados
    Public bolNuevoEmpleado As Boolean    ' Bandera que indica si se trata de un Nuevo Empleado (True) o de una edición (False)
    Public strIdEmpleado As String        ' IdEmpleado : Toma el IdEmpleado para tenerlo disponible en otros formularios
End Module
