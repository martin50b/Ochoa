Imports System.Windows.Forms
Imports Microsoft.Win32

' NOTA: Todos los registro se generan dentro de "HKEY_CURRENT_USER", para hacerlo dentro de otra llave, 
' por ejemplo :  ""HKEY_LOCAL_MACHINE", se debe cambiar en el codigo "Registry.CurrentUser" por "Registry.LocalMachine"

Module RegistroWin
    Sub CrearKey(ByVal strKeyPath As String)
        ' Parametros ejemplo:
        'strKeyPath = "Software\Test"

        ' Crea un Key dentro del Registro de Windows
        Registry.CurrentUser.CreateSubKey(strKeyPath)

    End Sub

    Sub CrearValor(ByVal strKeyPath As String, ByVal strValueName As String, ByVal strValor As String)
        ' Parametros ejemplo:
        'strKeyPath = "Software\Test"
        'strValueName = "TestValue"

        ' True indica que se abre para escritura
        Dim rekKey As RegistryKey = Registry.CurrentUser.OpenSubKey(strKeyPath, True)

        ' Si rekKey es Nothing significa que no se encontró
        If rekKey IsNot Nothing Then
            rekKey.SetValue(strValueName, strValor, RegistryValueKind.String)
        Else
            If MessageBox.Show(String.Format("No se encontró la clave 'HKCU\{0}'. Desea crearla?", strKeyPath), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ' Crea la clave
                Call CrearKey(strKeyPath)
                ' Intentar nuevamente crear el valor
                Call CrearValor(strKeyPath, strValueName, strValor)
            End If
        End If
    End Sub

    Sub EliminarValor(ByVal strKeyPath As String, ByVal strValueName As String)
        ' Parametros ejemplo:
        'strKeyPath = "Software\Test"
        'strValueName = "TestValue"

        ' True indica que se abre para escritura
        Dim rekKey As RegistryKey = Registry.CurrentUser.OpenSubKey(strKeyPath, True)

        ' Si rekKey es Nothing significa que no se encontró
        If rekKey IsNot Nothing Then
            ' Busca el nombre del valor en la lista de todos los valores de la clave
            If rekKey.GetValueNames().Contains(strValueName) Then
                ' Borra el valor
                rekKey.DeleteValue(strValueName)
            Else
                MessageBox.Show(String.Format("No se encontró el valor '{0}'.", strValueName))
            End If
        Else
            MessageBox.Show(String.Format("No se encontró la clave 'HKCU\{0}'.", strKeyPath))
        End If
    End Sub

    Sub EliminarKey(ByVal strKeyPath As String)
        ' Parametros ejemplo:
        'strKeyPath = "Software\Test"

        ' True indica que se abre para escritura
        Dim rekKey As RegistryKey = Registry.CurrentUser.OpenSubKey(strKeyPath, True)

        ' Si rekKey es Nothing significa que no se encontró
        If rekKey IsNot Nothing Then
            ' Borra la sub clave
            Registry.CurrentUser.DeleteSubKey(strKeyPath)
        Else
            MessageBox.Show(String.Format("No se encontró la clave 'HKCU\{0}'.", strKeyPath))
        End If
    End Sub

    Function LeerRegistro(ByVal strKeyPath As String, ByVal strValueName As String) As String
        ' Parametros ejemplo:
        'strKeyPath = "Software\Test"
        'strValueName = "TestValue"

        ' Se abre para sólo lectura
        Dim rekKey As RegistryKey = Registry.CurrentUser.OpenSubKey(strKeyPath, False)

        ' Si rekKey es Nothing significa que no se encontró
        If rekKey IsNot Nothing Then
            ' Obtiene los nombres de todos los valores en la key
            Dim strValores As String() = rekKey.GetValueNames()
            For Each strValor As String In strValores
                ' Verifica si se trata del Valor que se esta buscando
                If Trim(UCase(strValor)) = Trim(UCase(strValueName)) Then
                    ' Si necesitas el Tipo de valor, esta linea te lo devuelve.
                    'rekKey.GetValueKind(value).ToString()

                    ' Devuelve el valor
                    Return rekKey.GetValue(strValor)
                End If
            Next
        End If

        ' Devuelve un valor en blanco en caso de error
        Return ""
    End Function

End Module
