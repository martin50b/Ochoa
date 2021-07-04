
Imports System.Data.SqlClient
Imports dllMsSQL

Public Class CatTipoPrecio

    Public Shared Function GetTipoPrecio()
        Dim dt As New DataTable
        Dim cadena As New AdaptadorSql
        Dim conexion As New SqlConnection(cadena.ObtenerCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg"))
        Dim cmd As New SqlDataAdapter("GetCatTP", conexion)
        cmd.SelectCommand.CommandType = CommandType.StoredProcedure

        cmd.Fill(dt)

        Return dt

    End Function


End Class
