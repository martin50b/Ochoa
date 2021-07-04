Imports System.Data.SqlClient
Imports System.IO

Public Class AdaptadorSql
    Public sdaGeneral As SqlDataAdapter
    Public dseGeneral As DataSet
    Public strMsgError As String = ""

    ' <summary>Obtiene datos de SQL Server</summary>
    ' <value>Sentencia SQL, Nombre de la Tabla</value>
    ' <returns>DataTable con los resultados de la Sentencia SQL</returns>
    ' <example>ObtenerMSSQL("SELECT * FROM MiTabla","MisDatos")</example>
    ' <remarks>Gustavo Robles</remarks>
    Public Function EjecutarQuery(strSQL As String, strNombreTabla As String) As DataTable
        Dim scnCon As New SqlConnection()
        Dim strCadena As String = ObtenerCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg") 'conCadena
        scnCon.ConnectionString = strCadena
        Dim scmSQL As New SqlCommand()
        scmSQL.Connection = scnCon
        scmSQL.CommandTimeout = Integer.MaxValue
        Dim tblTable As New DataTable()

        ' Determina el tipo de sentencia SQL
        Dim bolSelect As Boolean = False
        Dim bolInsert As Boolean = False
        Dim bolUpdate As Boolean = False
        Dim bolDelete As Boolean = False
        Select Case Left(UCase(Trim(strSQL)), 6)
            Case "SELECT" : bolSelect = True
            Case "INSERT" : bolInsert = True : strSQL = strSQL & " SELECT SCOPE_IDENTITY()"
            Case "UPDATE" : bolUpdate = True
            Case "DELETE" : bolDelete = True
        End Select

        ' Contador de registros
        Dim intRegistros As Integer = 0
        ' Id del Registro insertado
        Dim intIdRegistro As Integer = 0

        Try
            scnCon.Open()
            scmSQL.CommandText = strSQL

            Dim drSQL As SqlDataReader
            If bolSelect Then
                ' Sentencia: SELECT
                drSQL = scmSQL.ExecuteReader()

                ' Coloca el resultado en el Data Table
                tblTable.Load(drSQL)
                If strNombreTabla = "" Then
                    strNombreTabla = "OK"
                End If
                tblTable.TableName = strNombreTabla
            End If


            ' NOTA: Para que funcione el IDENTITY, el campo en la tabla debe tener la propiedad de Identity activada.
            ' Sentencia: INSERT
            If bolInsert Then
                ' Recupera el Id del registro Insertado
                Dim objInsert As Object = scmSQL.ExecuteScalar()
                intIdRegistro = If(objInsert Is DBNull.Value, 1, CInt(objInsert))

                ' En la Tabla Crea un Campo para el Resultado
                tblTable.Columns.Add("Resultado")
                Dim R As DataRow = tblTable.NewRow
                R("Result") = intIdRegistro
                tblTable.Rows.Add(R)

                ' Le coloca nombre a la Tabla
                If strNombreTabla = "" Then
                    strNombreTabla = "OK"
                End If
                tblTable.TableName = strNombreTabla
            End If

            ' Sentencia: UPDATE / DELETE
            If bolUpdate Or bolDelete Then
                ' Devuelve el numero de registros afectados Delete/Update
                intRegistros = scmSQL.ExecuteNonQuery

                ' En la Tabla Crea un Campo para el Resultado
                tblTable.Columns.Add("Resultado")
                Dim R As DataRow = tblTable.NewRow
                R("Result") = intRegistros
                tblTable.Rows.Add(R)

                ' Le coloca nombre a la Tabla
                If strNombreTabla = "" Then
                    strNombreTabla = "OK"
                End If
                tblTable.TableName = strNombreTabla
            End If

        Catch ex As Exception
            strMsgError = ex.Message.ToString
            tblTable = Nothing
            'System.Windows.Forms.MessageBox.Show(strMsgError, "Error de conexión a BD", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try

        scmSQL.Dispose()
        scnCon.Close()
        scnCon.Dispose()

        ' Regresa los resultados en un Data Table
        Return tblTable
    End Function


    ' <summary>Obtiene cadena encriptada desde archivo de configuración y la devuelve desencriptada como cadena de conexion </summary>
    ' <value>sArchivo = Archivo de configuración</value>
    ' <returns>cadena de conexion para usarse en el módulo</returns>
    ' <example>? ObtenerCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg")</example>
    ' <remarks>Gustavo Robles</remarks>
    Public Function ObtenerCadenaConn(strArchivo As String)
        Dim strCadena As String
        Dim p As Encryption.Symmetric.Provider = Encryption.Symmetric.Provider.TripleDES

        Using Lector As New StreamReader(strArchivo)
            strCadena = Lector.ReadLine()

            Dim decryptedData As Encryption.Data
            Dim sym2 As New Encryption.Symmetric(p)
            sym2.Key.Text = "0ch0a08022021-.P"

            Dim encryptedData As New Encryption.Data()
            encryptedData.Base64 = strCadena
            decryptedData = sym2.Decrypt(encryptedData)

            Return decryptedData.Text
        End Using
    End Function

    '
    ' <summary>Encripta la cadena y la escribe en el archivo de configuración </summary>
    ' <value>sArchivo = Archivo de configuración</value>
    ' <returns>cadena de conexion para usarse en el módulo</returns>
    ' <example>GuardarCadenaConn(System.Windows.Forms.Application.StartupPath & "\dllMsSQL.cfg","Data Source=DESKTOP-PIUGBG8\SQLEXPRESS;Initial Catalog=SRSystem;Persist Security Info=True;User ID=sa;password=SQLExpress")</example>
    ' <remarks>Gustavo Robles</remarks>
    Public Sub GuardarCadenaConn(strArchivo As String, strCadena As String)


        'Data Source = ESCRITORIO10;Initial Catalog=Ochoa;Persist Security Info=True;User ID=Ochoa;password=Osql2021

        Dim p As Encryption.Symmetric.Provider = Encryption.Symmetric.Provider.TripleDES
        Dim sym As New Encryption.Symmetric(p)
        sym.Key.Text = "0ch0a08022021-.P"

        Dim encryptedData As Encryption.Data
        encryptedData = sym.Encrypt(New Encryption.Data(strCadena))

        Using Pluma As New StreamWriter(File.Open(strArchivo, FileMode.Append))
            Pluma.WriteLine(encryptedData.Base64)
        End Using
    End Sub

End Class
