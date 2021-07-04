Module Inicio
    ' Constantes
    Public Const Programa = "Ochoa"
    Public Const Licencia = "SUP210906B"
    ' Opciones extras
    Public FotosEmp As String
    Public FotosEco As String
    Public FotosPro As String
    Public FotosTarjeta As String
    Public FotosSeguro As String
    ' Reparto
    Public Venta As String
    Public Impor As String
    Public TotEfe As String
    Public ImpEfe As String
    Public ConsultaReparto As String
    Public GastosRep As String
    Public Sub Main()
        Dim y As String
        On Error GoTo ConError

        ' Abrir el programa sólo una vez
        'If App.PrevInstance Then
        '    MsgBox("El programa ya está abierto.", 64, "Productos Ochoa")
        '    End
        'End If

        ' Primeros datos
        Empresa(0) = "Productos de Maíz Ochoa, S.A. de C.V."
        Empresa(1) = "Acceso III 16-B Int. 1-B, Zona Industrial Benito Juárez"
        Empresa(2) = "Querétaro, Qro. C.P. 76120"
        Empresa(3) = "Tel. (442) 182-2327 y 182-2328"
        Empresa(4) = "Pablo Ochoa Briseño"
        Emp0 = Empresa(0)
        Emp4 = Empresa(4)
        ' Opciones propias
        strDatosCliente = "(Calle & IIf(NoExterior = '', '', ' No. ' & NoExterior) & " &
           "IIf(NoInterior = '', '', ' interior ' & NoInterior) & " &
           "IIf(Colonia = '', '', ' Col. ' & Colonia)) AS CalleN, " &
           "(Municipio & IIf(Clientes.Ciudad = '', '', ', ' & Clientes.Ciudad) & " &
           "', ' & Clientes.Estado) AS CiudadN, (Pais & ', C.P. ' & CP) AS PaisN, " &
           "('RFC: ' & RFC) AS dRFC, IIf(Teléfono = '', '', 'Tel. ' & Teléfono) AS Tel, "
        'bolDetalleIVA = True
        'IconoArt = 0
        USD = 1
        'bolUsoProd = True
        'intUsoMat = 0
        'intUsoPaq = 1
        'intUsoEmp = 3
        'bolAlmacenMultiple = False
        bolSinMovAlmacen = True
        bolEntregas = True
        'bolConIEPS = True
        'bolCaducidad = True

        ' Entrada al programa
        Hola()

        ' Para producción, usar costo último
        CostoUtil = "CostoU"
        ' Opciones extras
        FotosEmp = "Fotos de empleados\"
        FotosEco = "Fotos de equipos\"
        FotosPro = "Fotos de productos\"
        FotosTarjeta = "Fotos tarjetas\"
        FotosSeguro = "Fotos seguros\"
        ' Reparto
        Venta = "(SobranteC + Carga + RecargaDe - Sobrante - Devolución - Cortesías - RecargaA)"
        ' El importe no es válido porque los créditos tienen diferente precio
        Impor = Venta & " * Precio"
        TotEfe = "(SobranteC + Carga + RecargaDe - Sobrante - Devolución - Cortesías - RecargaA - Créditos)"
        ImpEfe = TotEfe & " * Precio"
        ConsultaReparto = "Sum" & Venta & " AS Venta, Sum(Sobrante) AS Sobra, " &
           "Sum(Devolución) AS Devol, Sum(Cortesías) AS Corte, Sum(" & Impor &
           ") AS Importe FROM Inventario INNER JOIN (DetalleReparto INNER JOIN " &
           "(Repartos INNER JOIN Rutas ON Repartos.Ruta = Rutas.Ruta) ON " &
           "DetalleReparto.Reparto = Repartos.Reparto) ON Inventario.Código = " &
           "DetalleReparto.Código "
        GastosRep = "Choose(GastosReparto.Concepto + 1, 'Gasolina', 'Talachas', 'Comisión por depósito', " &
           "'Diferencias en precio', 'Reparación unidad', 'Diversos') AS ConceptoN "

        ' Tablas de impresión
        'FormaL = "G F C D K N M X V % *"
        'FormaM = "General" & vbCr & "Fecha" & vbCr & "Cantidad (5.50)" & vbCr & "Decimal (5.5)" &
        '   vbCr & "Cantidad sin cero" & vbCr & "Número" & vbCr & "Número sin cero" & vbCr &
        '   "No visible" & vbCr & "Sí/No" & vbCr & "Porcentaje" & vbCr & "No de línea"
        Exit Sub
ConError:
        MsgBox(Err.Description, 16, Titulo)
        Err.Clear()
    End Sub
    Public Sub LeerAlmacén(coVer As Object)
        ' Leer los datos para el almacén en la lista llamada Ver
        Dim coVerItems As Object
        ' Revisar tipo de control
        If TypeOf coVer Is ComboBox Then
            coVerItems = coVer.Items
        ElseIf TypeOf coVer Is DevExpress.XtraEditors.ComboBoxEdit Then
            coVerItems = coVer.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coVerItems.Clear
        ' Llenar dotos
        coVerItems.Add("Compra")
        coVerItems.Add("Producción")
        coVerItems.Add("Reparto")
        coVerItems.Add("Factura")
        coVerItems.Add("Nota")
        coVerItems.Add("Devolución")
        coVerItems.Add("Otros")
    End Sub
    Public Sub LeerReporte(coVer As Object)
        ' Leer los tipos de reportes
        Dim coVerItems As Object
        ' Revisar tipo de control
        If TypeOf coVer Is ComboBox Then
            coVerItems = coVer.Items
        ElseIf TypeOf coVer Is DevExpress.XtraEditors.ComboBoxEdit Then
            coVerItems = coVer.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coVerItems.Clear
        ' Llenar datos
        coVerItems.Add("Facturas")
        coVerItems.Add("Notas")
        coVerItems.Add("Compras")
    End Sub
    Public Sub LeerRepVentas(coVer As Object)
        ' Leer los tipos de reportes de venta
        Dim coVerItems As Object
        ' Revisar tipo de control
        If TypeOf coVer Is ComboBox Then
            coVerItems = coVer.Items
        ElseIf TypeOf coVer Is DevExpress.XtraEditors.ComboBoxEdit Then
            coVerItems = coVer.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coVerItems.Clear
        ' Llenar datos
        coVerItems.Add("Facturas")
        coVerItems.Add("Notas")
    End Sub
    Public Sub LeerCobrosDe(coVer As Object)
        ' Leer los cobros de
        Dim coVerItems As Object
        ' Revisar tipo de control
        If TypeOf coVer Is ComboBox Then
            coVerItems = coVer.Items
        ElseIf TypeOf coVer Is DevExpress.XtraEditors.ComboBoxEdit Then
            coVerItems = coVer.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coVerItems.Clear
        ' Llenar datos
        coVerItems.Add("Facturas")
        coVerItems.Add("Notas")
    End Sub
    Public Sub LeerAddendas(coAdd As Object)
        ' Leer lista de addendas autorizadas
        Dim coAddItems As Object
        ' Revisar tipo de control
        If TypeOf coAdd Is ComboBox Then
            coAddItems = coAdd.Items
        ElseIf TypeOf coAdd Is DevExpress.XtraEditors.ComboBoxEdit Then
            coAddItems = coAdd.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coAddItems.Clear
        ' Llenar datos
        coAddItems.Add("Fresko")
        coAddItems.Add("LaComer")
        coAddItems.Add("SorianaPC")
        coAddItems.Add("SorianaR")
        coAddItems.Add("OXXO")
        ' Addenda ficticia
        coAddItems.Add("Tienda")
    End Sub
    Public Sub LeerUso(coUso As Object, Optional ByRef Uso As String = "")
        ' Leer lista de usos de producción
        Dim coUsoItems As Object
        ' Revisar tipo de control
        If TypeOf coUso Is ComboBox Then
            coUsoItems = coUso.Items
        ElseIf TypeOf coUso Is DevExpress.XtraEditors.ComboBoxEdit Then
            coUsoItems = coUso.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coUsoItems.Clear
        ' Llenar datos
        coUsoItems.Add("0) Material")
        coUsoItems.Add("1) Producto")
        coUsoItems.Add("2) Devolución")
        coUsoItems.Add("3) Empaque")
        ' Para la consulta
        Uso = "Choose(Uso + 2, '', 'Material', 'Producto', 'Devolución', 'Empaque') AS UsoN, "
    End Sub
    Public Sub LeerGastosRep(coGasto As Object)
        ' Lista de gastos autorizados para el reparto
        ' OJO: Revisar variable GastosRep en Sub Main (15/sep20)
        Dim coGastoItems As Object
        ' Revisar tipo de control
        If TypeOf coGasto Is ComboBox Then
            coGastoItems = coGasto.Items
        ElseIf TypeOf coGasto Is DevExpress.XtraEditors.ComboBoxEdit Then
            coGastoItems = coGasto.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coGastoItems.Clear
        ' Llenar datos
        coGastoItems.Add("1) Gasolina")
        coGastoItems.Add("2) Talachas")
        coGastoItems.Add("3) Comisión por depósito")
        coGastoItems.Add("4) Diferencias en precio")
        coGastoItems.Add("5) Reparación unidad")
        coGastoItems.Add("6) Diversos")
    End Sub
    Public Sub LeerClases(coTipoEco As Object, Optional Clase As String = "")
        ' Lista de clases de vehículos
        Dim coTipoEcoItems As Object
        ' Revisar tipo de control
        If TypeOf coTipoEco Is ComboBox Then
            coTipoEcoItems = coTipoEco.Items
        ElseIf TypeOf coTipoEco Is DevExpress.XtraEditors.ComboBoxEdit Then
            coTipoEcoItems = coTipoEco.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coTipoEcoItems.Clear
        ' Llenar datos
        coTipoEcoItems.Add("Compacto")
        coTipoEcoItems.Add("Mediano")
        coTipoEcoItems.Add("Grande")
        ' Para la consulta
        Clase = "Choose(NoClase + 1, 'Compacto', 'Mediano', 'Grande')"
    End Sub

    '    Public Function LeerNombreEmpleado(Número As String) As String
    '        ' Los maestros tienen puesto = 0
    '        Dim Db As Database, Rs As Recordset
    '        Dim Qry As String
    '        On Error GoTo ConError
    '        Qry = "SELECT Nombre FROM Empleados WHERE Número = '" & Número & "'"
    'Set Db = OpenDatabase(Ruta & Archivo, False, False, MiPWD)
    'Set Rs = Db.OpenRecordset(Qry)
    'If Rs.AbsolutePosition = 0 Then LeerNombreEmpleado = Rs(0) & ""
    '        Rs.Close
    '        Db.Close
    '        Exit Function
    'ConError:
    '        MsgBox(Err.Description, 16, Titulo)
    '        Err.Clear()
    '    End Function

    '    Public Sub LeerTablasDat(coTabla As Control)
    '        coTabla.Clear
    '        'coTabla.AddItem "Detalle"
    '        coTabla.AddItem "Areas"
    'coTabla.AddItem "Puestos"
    'End Sub

    '    Public Sub LeerTablaXY(coTabla As ComboBox)
    '        LeerGrupo coTabla, "Cuentas WHERE TablaXY <> ''", "TablaXY"
    'End Sub
    Public Sub ImpEncabezado()
        ' Imprimir encabezado con logotipo de Ochoa
    End Sub
End Module
