Module Subrutinas
    Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" _
   (ByVal hWnd As Long, ByVal lpOperation As String, ByVal lpFile As String,
   ByVal lpParameters As String, ByVal lpDirectory As String,
   ByVal nShowCmd As Long) As Long
    ' Constant  Value  Description
    ' vbHide 0 Window is hidden and focus is passed to the hidden window.
    ' vbNormalFocus 1 Window has focus and is restored to its original size and position.
    ' vbMinimizedFocus 2 Window is displayed as an icon with focus.
    ' vbMaximizedFocus 3 Window is maximized with focus.
    ' vbNormalNoFocus 4 Window is restored to its most recent size and position. The currently active window remains active.
    ' vbMinimizedNoFocus 6 Window is displayed as an icon. The currently active window remains active.

    ' Opciones propias
    Public strDatosCliente As String ' Datos éxtras del cliente para factura (Tel, Col, Etc.)
    'Public bolDetalleIVA As Boolean  ' ¿DetelleVenta con IVA?
    'Public IconoArt As Integer       ' Icono que se muestra en la barra de herramientas
    Public USD As Decimal            ' Valor del dólar
    Public EUR As Decimal            ' Valor del euro
    'Public bolUsoProd As Boolean     ' Uso del artículo y Art. x caja
    'Public bolSalProd As Boolean     ' Control de salidas de producción
    'Public bolPaquetes As Boolean    ' Venta por paquetes (similar a UsoProd)
    'Public intUsoMat As Integer, intUsoEmp As Integer, intUsoPaq As Integer
    'Public intUsoPaqEsp As Integer   ' Paquete especial para SportPool
    'Public bolAlmacenMultiple As Boolean
    'Public bolAlmacenBD As Boolean   ' Nombre de almacenes en la base de datos
    Public bolSinMovAlmacen As Boolean  ' Sin movimientos de almacén en factura
    'Public bolDescuentos As Boolean  ' Factura con descuentos
    'Public bolImpuestosLocales As Boolean  ' Factura con impuestos locales
    'Public bolPNomina As Boolean     ' Programa Nómina
    'Public bolCargaPT As Boolean     ' Carga programa transportistas
    'Public bolPorceFijo As Boolean   ' Precios con porcentaje fijo
    'Public bolLugarC As Boolean      ' Población del cliente
    Public bolEntregas As Boolean    ' Control de entregas con Lugares y Rutas
    'Public bolConIEPS As Boolean     ' Usar IEPS
    'Public bolConRetISR As Boolean   ' Usar RetISR en fmTrabajo
    'Public bolCuentas As Boolean     ' Cuentas contables para Nómina
    'Public bolCaducidad As Boolean   ' Caducidad para medicamentos
    'Public bolEscalaTP As Boolean    ' Tipo de precios por escala
    'Public bolAduana As Boolean
    'Public bolComercioExt As Boolean
    ' Primeros datos
    Public RutaApp As String
    Public Empresa(4) As String
    Public Emp0 As String
    Public Emp4 As String
    'Public MiPWD As String
    ' Area de trabajo
    Public Ruta As String
    Public Archivo As String
    Public Titulo As String
    'Public ImpRed As Byte
    ' Seguridad
    'Public Candado As Byte
    'Public Clave As String
    'Public ClaveV As String       ' Clave venta
    'Public ClaveAlm As String
    'Public MUsuario As String     ' Clave del Usuario
    ' Cadena de conexión
    'Public CnStr As String
    ' Factura
    Public IVA As Decimal
    Public IEPS As Decimal
    'Public RetIVA As Decimal
    'Public RetISR As Decimal
    'Public CuentaPredial As Byte
    Public PorCrédito As Decimal
    Public Copias As Integer
    Public FacRows As Integer     ' Número de filas para la factura
    Public NotRows As Integer     ' Número de filas para la nota
    Public StockPos As Byte       ' Stock positivo
    Public Eliminar As Byte       ' Ver el botón de "Eliminar"
    'Public Bloqueo As Byte        ' Bloquear precios
    'Public OrigCop As Byte        ' Original y Copias
    Public LUSD As Byte           ' Leer USD al inicio
    ' CFD
    Public CFD As String          ' CFD y CFDI
    Public PAC As String          ' Programa webservice del PAC
    Public RutaCer As String      ' Ruta del certificado
    Public NoKey As Byte          ' Seguridad: Baja = 0, Media = 1, Alta = 2
    ' Datos de control
    Public FPagoFac As String     ' Forma de pago para factura
    Public TCobro As String       ' Tipo de cobro
    Public TCobroCP As String     ' Tipo de cobro complemento pago
    Public FPagoCte As String     ' Forma de pago para clientes
    Public TPago As String        ' Tipo de pago
    ' CFD para uso general
    Public RutaXML As String
    Public NombreXML As String
    Public FolioConector As String ' Se usa en Sub Imp
    Public FPagoImp As String     ' Forma de pago para imprimir
    Public MPago As String        ' Método de pago para CFDI / MPago para imprimir
    Public UsoCFDI As String      ' UsoCFDI para imprimir
    Public TipoRel As String      ' Tipo de relación para imprimir
    'Public VentaTS As Integer     ' Venta táctil (Touch Screen)
    ' MiniSuper
    'Public CopiasT As Integer     ' Copias ticket
    'Public FMostrador As Byte     ' Función mostrador programa SportPool
    'Public StockPosV As Byte      ' Stock positivo
    'Public BloqueoV As Byte       ' Bloquear precios
    'Public DetalleC As Byte       ' Editar cantidad en detalle de venta
    'Public CancelarDetalle As Byte ' Cancelar detalle de la venta en lugar de borrar
    'Public VerStock As Byte       ' Ver el stock del inventario en la venta
    'Public AgruparDV As Byte      ' Agrupar DetalleVenta
    'Public ImpDName As String     ' Controlador de Miniprinter
    'Public PuertoLPT1 As Byte     ' Abrir cajón en el puerto 1
    ' Etiquetas y precios
    Public CostoUtil As String    ' Costo para la utilidad
    Public NPrecios As Integer    ' Número de precios
    Public PrecioTP(10) As String ' Nombre del precio para el cliente (lb.Caption)
    Public PrecioBD(10) As String ' Nombre del precio en la base de datos
    Public Reemplazo As String    ' Reemplazo (NTE)
    ' Control de caja
    'Public RegCaja As Byte        ' Registrar en caja factura
    'Public RegCajaV As Byte       ' Registrar en caja venta
    'Public RegCajaC As Byte       ' Registrar en caja compra
    'Public RegCajaG As Byte       ' Registrar en caja gastos
    ' Venta Touch Screen
    'Public RegVtaTS As Boolean    ' Venta pantalle táctil registrada para control de fmMostrador
    'Public Teclado As String      ' Texto del teclado virtual
    ' Multialmacén
    'Public Almacen(5) As String   ' Nombre del almacén
    'Public AlmacenFac As Integer  ' Almacén para facturación
    'Public AlmacenVta As Integer  ' Almacén para la venta al mostrador
    ' Empleados
    Public Bajas As Byte          ' Bajas de empleados
    ' Báscula
    Public Puerto As Integer      ' Puerto comm
    Public AutoOff As Integer     ' Minutos para auto apagar
    Public SegLec As Decimal     ' Segundos entre lecturas
    Public CodEsc As String       ' Código de escape
    ' Configuración del usuario
    'Public conBusPor As Byte      ' BuscarPor
    'Public OrdenInv As Byte       ' Ordenar inventario
    'Public conIVA As Byte
    'Public conEntero As Byte
    'Public conPagare As Byte
    'Public selDetalle As Byte
    'Public selTitulo As Byte
    'Public CtaEfectivo As String
    ' Datos del correo
    Public Usuario As String      ' Nombre de usuario o LoginName
    Public ClaveU As String       ' Contraseña para accesar la cuenta de correo (AUTENTICACION)
    Public ServidorSMTP As String ' Direccion del SERVIDOR de CORREO (correo que será enviado -saliente-)
    Public PuertoE As String      ' Dirección del Puerto, estos dos datos DEPENDEN del PROVEEDOR de CORREO
    Public Remitente As String    ' Dirección del que envia el correo
    Public CorreoCC As String     ' Correo CC opcional
    Public CorreoCL As String     ' Correo Copia Lugar (sucursal)
    Public AsuntoE As String      ' Asunto o Titulo del correo
    Public MensajeE As String     ' Mensaje o cuerpo del correo
    Public EnvíoPDF As Byte
    Public RutaPDF As String
    ' Edición
    Public Abrir As Boolean
    Public Sub Hola()
        Dim x As Integer
        Dim y As String
        On Error GoTo ConError

        ' *** Revisar Licencia del programa ***

        ' *** Leer Primeros datos ***
        'RutaApp = App.Path & IIf(Right(App.Path, 1) = "\", "", "\")
        ' Valor povisional para hacer pruebas
        RutaApp = "C:\Program Files (x86)\Productos Ochoa"
        For x = 0 To 4
            Empresa(x) = GetSetting(Programa, "Inicio", "Empresa" & CStr(x), Empresa(x))
        Next x
        If Licencia = "Demo" Then
            Emp0 = "Demo Programa Superfácil"
        Else
            If Emp0 = "" Then Emp0 = Empresa(0)
        End If
        If Emp4 = "" Then Emp4 = Empresa(4)

        ' *** Leer variables del Area de trabajo ***
        ' Provisional para hacer pruebas
        Ruta = RutaApp
        Archivo = "Ochoa21A.sbd"
        Titulo = Left(Archivo, Len(Archivo) - 4)
        IVA = 16
        IEPS = 8
        PorCrédito = 0
        Copias = 0
        FacRows = 0
        NotRows = 0
        StockPos = 0
        Eliminar = 1
        LUSD = 0

        ' *** Datos para CFDI ***
        If Dir(Ruta & "CBB.bmp") <> "" Then
            CFD = "CBB"
        ElseIf Dir(Ruta & "Empresa.sra") <> "" Then
            CFD = "CFD"
        ElseIf Dir(Ruta & "EmpresaCFDI.sra") <> "" Then
            CFD = "CFDI"
            ' Seleccionar PAC
            For x = 1 To 4
                y = Choose(x, "SefacturaTestV2.jar", "SefacturaV2.jar", "SefacturaTest.exe", "Sefactura.exe")
                If Dir(RutaApp & "XML Base\" & y) <> "" Then
                    PAC = y
                    Exit For
                End If
            Next x
            If PAC = "" Then MsgBox("No hay un PAC registrado.", 16, Titulo)
        End If
        If CFD <> "" Then
            ' Leer formato de la factura
            y = RutaApp & CFD & ".bmp"
            If Dir(y) = "" Then y = Ruta & CFD & ".bmp"
            ' Cargar formato
            ' fmPrincipal.ilPrincipal.ListImages.Add , "CFD", LoadPicture(y)

            ' Revisar directorio del "Certificado"
            If Left(CFD, 3) = "CFD" Then
                y = RutaApp & "Certificado"
                If Dir(y, vbDirectory) = "" Then y = Ruta & "Certificado"
                If Dir(y, vbDirectory) = "" Then
                    MsgBox("No se encontró el directorio " & y & ".", 16, Titulo)
                Else
                    RutaCer = y
                    ' Aviso vencimiento del certificado
                    ' AvisoVence

                End If
                ' Seguridad
                NoKey = GetSetting(Programa, "Inicio", "NoKey", 0)
            End If
        End If

        ' *** Datos de control ***
        ' Forma de pago para factura
        FPagoFac = "Choose(FPago + 2, '', '01-Efectivo', '02-Cheque nominativo', '03-Transferencia electrónica de fondos', " &
            "'04-Tarjeta de crédito', '28-Tarjeta de débito', '30-Aplicación de anticipos', '99-Por definir') AS FormaPago, "
        ' Tipo de cobro para facturas y notas
        TCobro = "Choose(Tipo + 1, 'Efectivo', 'Cheque', 'Transferencia', 'Tarjeta crédito', " &
            "'Tarjeta débito', 'Nota de crédito', 'Compensación') AS FormaPago, "
        ' Tipo de cobro para el complemento pago
        TCobroCP = "Choose(Tipo + 1, '01-Efectivo', '02-Cheque nominativo', '03-Transferencia electrónica de fondos', " &
            "'04-Tarjeta de crédito', '28-Tarjeta de débito', 'NC', '17-Compensación') AS FormaPago, "
        ' Forma de pago para clientes
        FPagoCte = "Choose(FCPago + 1, 'Efectivo', 'Cheque', 'Transferencia', 'Tarjeta crédito', " &
            "'Tarjeta débito', '', '') AS FormaPago, "
        ' Tipo de pago para compras y gastos
        TPago = "Choose(Tipo + 1, 'Efectivo', 'Cheque', 'Transferencia', 'Tajeta', 'Otro', 'Nota crédito') AS TipoN, "
        ' *** Etiquetas y precios ***
        ' Costo para la utilidad
        CostoUtil = GetSetting(Programa, "Inicio", "CostoUtil", "Costo")
        ' Etiquetas
        Select Case NPrecios
            Case 0, 3
                ' Precios estandar
                NPrecios = 3
                PrecioBD(0) = "Bajo"
                PrecioBD(1) = "Medio"
                PrecioBD(2) = "Normal"
            Case 4
                PrecioBD(0) = "Distribuidor"
                PrecioBD(1) = "Bajo"
                PrecioBD(2) = "Medio"
                PrecioBD(3) = "Normal"
        End Select
        ' Precios definidos por el cliente
        For x = 0 To NPrecios - 1
            PrecioTP(x) = GetSetting(Programa, "Inicio", "Precio" & CStr(x), PrecioBD(x))
        Next x
        Reemplazo = GetSetting(Programa, "Inicio", "Reemplazo", "ClaveA")
        ' *** Empleados ***
        Bajas = GetSetting(Programa, "Inicio", "Bajas", 1)
        ' *** Báscula ***
        Puerto = GetSetting(Programa, "Báscula", "Puerto", 0)
        AutoOff = GetSetting(Programa, "Báscula", "AutoOff", 5)
        SegLec = GetSetting(Programa, "Báscula", "SegLec", 1)
        CodEsc = GetSetting(Programa, "Báscula", "CodEsc", "P")
        ' *** Leer configuración del usuario ***

        ' *** Datos del Correo
        Usuario = GetSetting(Programa, "EMail", "Usuario")
        ClaveU = GetSetting(Programa, "EMail", "ClaveU")
        ServidorSMTP = GetSetting(Programa, "EMail", "ServidorSMTP")
        PuertoE = GetSetting(Programa, "EMail", "Puerto")
        Remitente = GetSetting(Programa, "EMail", "Remitente")
        CorreoCC = GetSetting(Programa, "EMail", "CorreoCC")
        AsuntoE = GetSetting(Programa, "EMail", "Asunto")
        MensajeE = GetSetting(Programa, "EMail", "Mensaje")
        EnvíoPDF = GetSetting(Programa, "EMail", "EnvíoPDF", 0)
        RutaPDF = GetSetting("BasePDF", "EMail", "RutaPDF", RutaApp & "XML Base\")

        ' *** Titulo formulario principal ***
        frmMain.Text = Emp0 & ", " & Titulo

        ' *** Cargar Logotipos

        ' *** Carga Barra de herramientas (tb) ***

        ' *** Revisión final ***
        ' USD opcional, pedir tipo de cambio
        'If USD > 0 Then USD = Val(LeerUSD(Of Date))

        ' Revisar configuración regional
        If InStr(CStr(1 / 2), ",") Then
            MsgBox("La configuración regional de Windows no corresponde a México." & vbCr &
                "Revise su sistema antes de trabajar con el programa.", 16, Titulo)
        End If
        Exit Sub
ConError:
        MsgBox(Err.Description, 16, Titulo)
        Err.Clear()
        Resume Next
    End Sub
    Public Function BuscarArchivo(Nombre As String, S As Double) As Boolean
        Dim t As Double
        t = DateAndTime.Timer + S
        Do Until DateAndTime.Timer > t
            'DoEvents
            If Dir(Nombre) <> "" Then
                ' Esperar para el llenado
                UnMomentito(2)
                ' Archivo encontrado
                Return True
            End If
        Loop
        Return False
    End Function
    Public Sub UnMomentito(S As Single)
        System.Threading.Thread.Sleep(S * 1000)
    End Sub
    Public Function RevisarRFC(ByRef RFC As String) As Boolean
        Dim L As Integer
        Dim M As String, A As String
        Dim x As Integer
        Dim y As String, z As String
        ' Patrón SAT:
        ' [A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]
        ' Explicación:
        ' [A-Z&Ñ]{3,4}: Valores válidos A-Z, &, Ñ / 3 ó 4 caracteres
        ' [0-9]{2}: 00 hasta 99 (año)
        ' (0[1-9]|1[012]): 01 hasta 09 ó 10, 11, 12 (mes)
        ' (0[1-9]|[12][0-9]|3[01]): 01 hasta 09 ó 10-19, 20-29 ó 30, 31 (día)
        ' [A-Z0-9]{2}: Valores válidos A-Z, 0-9 / 2 caracteres (homo clave)
        ' [0-9A]: 0-9, A (dígito verificador)
        ' Revisar RFC
        y = UCase(Trim(RFC)).Replace(" ", "").Replace("-", "")
        '' Eliminar espacios
        'Do Until InStr(y, " ") = 0
        '    x = InStr(y, " ")
        '    y = Strings.Left(y, x - 1) & Mid(y, x + 1)
        'Loop
        '' Eliminar guiones
        'Do Until InStr(y, "-") = 0
        '    x = InStr(y, "-")
        '    y = Strings.Left(y, x - 1) & Mid(y, x + 1)
        'Loop
        ' Revisar longitud
        L = Len(y)
        If (L < 12) Or (L > 13) Then Return False
        ' Revisar siglas
        For x = 1 To L - 9
            z = Mid(y, x, 1)
            ' Rango válido: A-Z, &, Ñ
            Select Case Asc(z)
                Case 65 To 90, 38, 209
                Case Else
                    Return False
            End Select
        Next x
        ' Revisar mes
        M = Mid(y, L - 6, 2)
        If Val(M) < 1 Or Val(M) > 12 Then Return False
        ' Revisar año
        A = Mid(y, L - 8, 2)
        A = IIf(Val(A) > 50, "19", "20") & A
        ' Revisar fecha (dd-mm-yyyy)
        z = Mid(y, L - 4, 2) & "/" & M & "/" & A
        If Not IsDate(z) Then Return False
        ' Revisar dígito verificador
        If InStr("1234567890A", Strings.Right(y, 1)) = 0 Then Return False
        ' RFC correcto
        RFC = y
        Return True
    End Function
    Public Function ValidarDato(Dato As String, Optional Clave As Boolean = False) As String
        Dim x As Integer
        Dim NuevoDato As String = ""
        Dim y As String, z As String
        ' En caso de valor nulo
        y = Trim(Dato & "")
        If y = "" Then Return ""
        ' Revisar doble espacio
        y = y.Replace("  ", " ")
        'Do Until InStr(y, "  ") = 0
        '    x = InStr(y, "  ")
        '    y = Strings.Left(y, x - 1) & Mid(y, x + 1)
        'Loop
        ' Validar dato
        For x = 1 To Len(y)
            z = Mid(y, x, 1)
            ' Revisar caracter
            Select Case Asc(z)
                Case Is < 32
                    ' No es un caracter, sustituirlo por un espacio intermedio que se puede ajustar al final
                    z = " "
                Case 32 To 122
                    ' Rango válido: 32 a 122
                    If Clave Then
                        Select Case z
                            Case "/", "\", "<", ">", "*", "?", Chr(34)
                                ' Caracteres inválidos para una clave
                                MsgBox("El caracter " & z & " no es válido para este tipo de dato.", 64, "SRSystem")
                                z = ""
                        End Select
                    End If
                Case 193, 201, 205, 209, 211, 218, 225, 233, 237, 241, 243, 250
                    '"Á", "É", "Í", "Ñ", "Ó", "Ú", "á", "é", "í", "ñ", "ó", "ú"
                Case Else
                    ' Caracter inválido
                    z = ""
            End Select
            ' Caracteres válidos
            NuevoDato = NuevoDato & z
        Next x
        ' Revisar doble espacio al final por seguridad
        'Do Until InStr(ValidarDato, "  ") = 0
        '    x = InStr(ValidarDato, "  ")
        '    ValidarDato = Strings.Left(ValidarDato, x - 1) & Mid(ValidarDato, x + 1)
        'Loop
        Return Trim(NuevoDato).Replace("  ", " ")
    End Function
    Public Function NLetra(ByVal n As String, Optional Dv As Byte = 0) As String
        Dim Nd(3, 9) As String  ' Todos los números con letra
        Dim Nx(5) As String     ' Números con letra excepciones
        Dim Letra As String     ' Número con letra
        Dim Punto As String     ' Texto de PESOS y decimales
        Dim y As String = ""    ' letra Y para las decenas
        Dim udc As Integer      ' Unidad = 1 /Decena = 2 /Centena = 3
        Dim d As Integer        ' Valor de un dígito
        Dim x As Integer
        ' Leer números con letra
        For x = 1 To 9
            ' Unidades
            Nd(1, x) = Choose(x, "UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE")
            ' Decenas
            Nd(2, x) = Choose(x, "DIECI", "VEINT", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA")
            ' Centenas
            Nd(3, x) = Choose(x, "CIENTO ", "DOSCIENTOS ", "TRESCIENTOS ", "CUATROCIENTOS ", "QUINIENTOS ",
            "SEISCIENTOS ", "SETECIENTOS ", "OCHOCIENTOS ", "NOVECIENTOS ")
        Next x
        ' Excepciones
        For x = 0 To 5
            Nx(x) = Choose(x + 1, "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE")
        Next x
        ' Entrada de datos
        n = Val(n)              ' Solamente valores numéricos
        ' Solamente dos decimales
        n = Format(CDec(n), "0.00")
        ' Punto decimal
        If Val(n) = 1 Then
            ' Para 1
            Select Case Dv
                Case 0 : Letra = "UN PESO " & Strings.Right(n, 2) & "/100 M.N."
                Case 1 : Letra = "UN DOLAR " & Strings.Right(n, 2) & "/100 USD"
                Case 2 : Letra = "UN EURO " & Strings.Right(n, 2) & "/100 E"
            End Select
            Return Letra
        Else
            Select Case Dv
                Case 0 : Punto = " PESOS " & Strings.Right(n, 2) & "/100 M.N."
                Case 1 : Punto = " DOLARES " & Strings.Right(n, 2) & "/100 USD"
                Case 2 : Punto = " EUROS " & Strings.Right(n, 2) & "/100 E"
            End Select
        End If
        ' Número entero
        n = Strings.Left(n, Len(n) - 3)
        ' Barrido del número de derecha a izquierda
        For x = 1 To Len(n)
            udc = udc + 1
            d = Dig(n, x)
            ' Números mayores a Mil
            If x = 4 Then
                ' 6 dígitos a la derecha < 1000, se omite "MIL"
                If (Len(n) > 6) And (Val(Strings.Right(n, 6))) < 1000 Then
                    ' 6 dígitos a la derecha = 0, se agrega "DE"
                    If Val(Strings.Right(n, 6)) = 0 Then Punto = " DE" & Punto
                Else
                    ' 4º dígito, agregar "MIL"
                    Letra = " MIL " & Letra
                End If
            End If
            ' Números mayores a Millón
            If x = 7 Then
                ' Singular para "UN"
                If d = 1 Then Letra = " MILLON " & Letra Else Letra = " MILLONES " & Letra
            End If
            ' Excepciones (10 a 15)
            If (udc = 1) And (d < 6) Then
                If (x < Len(n)) Then
                    If Dig(n, x + 1) = 1 Then
                        Letra = Nx(d) & Letra
                        x = x + 1
                        udc = 2
                        GoTo Seguir
                    End If
                End If
            End If
            If d > 0 Then
                ' Mayor de cero:
                If (udc = 3) And (Mid(n, Len(n) - x + 1, 3) = "100") Then
                    Letra = "CIEN" & Letra
                Else
                    Letra = Nd(udc, d) & y & Letra
                End If
                y = ""
                If (x < Len(n)) And (udc = 1) Then
                    ' Números 16 a 19
                    If (Dig(n, x + 1) = 1) Then y = "" Else y = " Y "
                    ' Números 21 a 29
                    If (Dig(n, x + 1) = 2) Then y = "I"
                End If
            Else
                ' Igual a cero:
                y = ""
                If (x < Len(n)) And (udc = 1) Then
                    ' Número 20
                    If (Dig(n, x + 1) = 2) Then y = "E " Else y = " "
                End If
            End If
            If udc = 3 Then udc = 0
Seguir:
        Next x
        ' Mostrar resultado
        Return Trim(Letra) & Punto
    End Function
    Private Function Dig(Número As String, Dx As Integer) As Integer
        ' Regresa el valor del dígito en la posición Dx
        Dig = Mid(Número, Len(Número) - Dx + 1, 1)
    End Function
    Public Function LeerPeriodo(F1 As Date, F2 As Date) As String
        On Error GoTo ConError
        If F1 = F2 Then
            ' Por día
            LeerPeriodo = Format(F1, "Long Date")
        Else
            ' Entre F1 y F2
            LeerPeriodo = " al " & Format(F2, "dd \d\e MMMM \d\e yyyy")
            If Year(F1) <> Year(F2) Then
                LeerPeriodo = "Del " & Format(F1, "dd \d\e MMMM \d\e yyyy") & LeerPeriodo
            ElseIf Month(F1) <> Month(F2) Then
                LeerPeriodo = "Del " & Format(F1, "dd \d\e MMMM") & LeerPeriodo
            Else
                LeerPeriodo = "Del " & Format(F1, "dd") & LeerPeriodo
            End If
        End If
        Exit Function
ConError:
        MsgBox(Err.Description, 16, "SRSystem")
        Err.Clear()
    End Function
    Public Function FechaSQL(F1 As Date, Intervalo As Integer, Optional f As String = "", Optional F2 As Date = Nothing,
        Optional Dias As Long = 0) As String
        Dim y As String
        ' Intervalo:
        ' 0, Todo
        ' 1, Año
        ' 2, Mes
        ' 3, Día
        ' 4, Hasta la fecha
        ' 5, Desde la fecha
        ' 6, Entre fechas
        ' Dias = Número de días en el periodo
        On Error GoTo ConError
        Select Case Intervalo
            Case 1   ' Por año
                y = Format(F1, "yyyy")
                Dias = DatePart("y", "31/12/" & y)
                y = " Between #01/01/" & y & "# AND #12/31/" & y
            Case 2   ' Por mes
                y = Format(F1, "\0\1/MMMM/yyyy")
                y = DateAdd("m", 1, y).ToString
                y = DateAdd("d", -1, y).ToString
                Dias = DateDiff("d", Format(F1, "\0\1/MMMM/yyyy"), y) + 1
                y = " Between #" & Format(F1, "MM/\0\1/yyyy") & "# AND #" & Format(CDate(y), "MM/dd/yyyy")
            Case 3   ' Por día
                y = " = #" & Format(F1, "MM/dd/yyyy")
            Case 4   ' Hasta la fecha
                y = " <= #" & Format(F1, "MM/dd/yyyy")
            Case 5   ' Desde la fecha
                y = " >= #" & Format(F1, "MM/dd/yyyy")
            Case 6   ' Entre F1 y F2
                Dias = DateDiff("d", F1, F2) + 1
                y = " Between #" & Format(F1, "MM/dd/yyyy") & "# AND #" & Format(F2, "MM/dd/yyyy")
            Case Else
                FechaSQL = ""
                Exit Function
        End Select
        If f = "" Then f = "Fecha"
        FechaSQL = "WHERE " & f & y & "# "
        Exit Function
ConError:
        MsgBox(Err.Description, 16, "SRSystem")
        Err.Clear()
    End Function
    Public Function FechaInicio(F1 As Date, Intervalo As Integer) As String
        ' Intervalo:
        ' 0, Todo
        ' 1, Año
        ' 2, Mes
        ' 3, Día
        ' 4, Hasta la fecha
        ' 5, Desde la fecha
        ' 6, Entre fechas
        On Error GoTo ConError
        ' Fecha saldo inicial
        Select Case Intervalo
            Case 1   ' Por año
                FechaInicio = "#01/01/" & Format(F1, "yyyy") & "# "
            Case 2   ' Por mes
                FechaInicio = "#" & Format(F1, "MM/\0\1/yyyy") & "# "
            Case 3, 5, 6
                ' Por día, Desde la fecha, Entre F1 y F2
                FechaInicio = "#" & Format(F1, "MM/dd/yyyy") & "# "
        End Select
        Exit Function
ConError:
        MsgBox(Err.Description, 16, "SRSystem")
        Err.Clear()
    End Function
    Public Function FechaFinal(F1 As Date, F2 As Date, Intervalo As Integer, Optional f As String = "") As String
        Dim y As String
        On Error GoTo ConError
        ' Fecha saldo final
        Select Case Intervalo
            Case 1   ' Por año
                y = "12/31/" & Format(F1, "yyyy")
            Case 2   ' Por mes
                y = DateAdd("m", 1, Format(F1, "\0\1/MMMM/yyyy")).ToString
                y = Format(DateAdd("d", -1, y), "MM/dd/yyyy")
            Case 3, 4
                ' Por día, Hasta la fecha
                y = Format(F1, "MM/dd/yyyy")
            Case 6
                ' Entre F1 y F2
                y = Format(F2, "MM/dd/yyyy")
            Case Else
                Exit Function
        End Select
        If f = "" Then f = "Fecha"
        FechaFinal = "WHERE " & f & " <= #" & y & "# "
        Exit Function
ConError:
        MsgBox(Err.Description, 16, "SRSystem")
        Err.Clear()
    End Function
    Public Function DaysYear(Fecha As Date) As String
        DaysYear = Format(DatePart("y", Fecha), "000")
    End Function

    '    Public Function Precio(coTP As ComboBox, Campo As Fields,
    '   Optional Divisa As Byte, Optional Cantidad As Decimal, Optional TP As Integer,
    '   Optional PorCred As Integer) As Decimal
    '        Dim x As Integer
    '        Dim y As String
    '        On Error GoTo ConError
    '        ' Revisar modo TP
    '        If EscalaTP Then
    '            ' Si la escala = 0, usar precio seleccionado
    '            If Campo("ENormal") = 0 Then
    '                TP = coTP.ListIndex
    '                GoTo Seguir
    '            End If
    '            ' Revisar escalas
    '            For x = 1 To NPrecios - 1
    '                y = Choose(x, "ENormal", "EMedio", "EBajo")
    '                If Campo(y) = 0 Or Cantidad <= Campo(y) Then Exit For
    '            Next x
    '            ' Precio por escala
    '            TP = NPrecios - x
    '        Else
    '            ' Precio seleccionado
    '            TP = coTP.ListIndex
    '        End If

    'Seguir:
    '        ' Buscar Precio
    '        If TP < 0 Then
    '            ' Precios especiales
    '            If coTP.Text = "" Then
    '                ' Precio = costo
    '                Precio = Campo("Costo")
    '            ElseIf Left(coTP.Text, 1) = "=" Then
    '                ' Precio fijo
    '                Precio = Val(Mid(coTP.Text, 2))
    '            Else
    '                ' Precio con descuento
    '                Precio = Campo("Normal") * (1 + Val(coTP.Text) / 100)
    '            End If
    '            ' Revisar precio + IVA
    '            '   If UCase(Right(TP.Text, 3)) = "IVA" Then
    '            '      Precio = Precio / (1 + IVA / 100)
    '            '   End If

    '            ' Precios por TP
    '        ElseIf InStr(coTP.Text, "Crédito") > 0 Then
    '            ' Precio crédito
    '            Precio = Campo("Normal") * (1 + PorCrédito / 100)
    '        Else
    '            ' Precio normal
    '            Precio = Campo(PrecioBD(TP))
    '            If PorCred > 0 Then Precio = Precio * (1 + PorCred / 100)
    '        End If
    '        ' Revisar el costo
    '        If Precio <= Campo("Costo") Then
    '            MsgBox "El precio es menor o igual al costo.", 64, Titulo
    'End If
    '        ' Divisa opcional
    '        If USD > 0 Then
    '            ' Diferente divisa
    '            If Divisa <> Campo("Dólar") Then
    '                Precio = IIf(Divisa = 0, USD, 1 / USD) * Precio
    '            End If
    '        Else
    '            ' Si hay divisa con USD incorrecto
    '            If Divisa = 1 Then
    '                MsgBox "El valor del dólar debe ser mayor a cero.", 64, Titulo
    '      Precio = 0
    '            End If
    '        End If
    '        Exit Function
    'ConError:
    '        MsgBox Err.Description, 16, Titulo
    'Err.Clear()
    '    End Function
    Public Function CambioDivisa(Importe As Decimal, Dv1 As Byte, Dv2 As Byte,
       Optional tcUSD As Decimal = 0, Optional tcEUR As Decimal = 0) As Decimal
        ' Dv = Divisa
        ' Pesos = 0, USD = 1, EUR = 2, Etc.
        ' Revisar misma divisa
        If Dv1 = Dv2 Then Return Importe
        ' Revisar si hay tipo de cambio (basado en pesos)
        If tcUSD = 0 Then tcUSD = USD
        If tcEUR = 0 Then tcEUR = EUR
        ' Conversión
        If Dv1 = 0 Then
            ' Pesos a USD (EUR)
            Return Importe / Choose(Dv2, tcUSD, tcEUR)
        Else
            ' Dv1 no son pesos
            If Dv2 = 0 Then
                ' USD (EUR) a pesos
                Return Importe * Choose(Dv1, tcUSD, tcEUR)
            Else
                ' USD a EUR ó EUR a USD
                Return Importe * Choose(Dv1, tcUSD, tcEUR) / Choose(Dv2, tcUSD, tcEUR)
            End If
        End If
    End Function
    Public Function DivisaN(BMoneda As Byte) As String
        DivisaN = Choose(BMoneda + 1, "Pesos", "Dólares", "Euros")
    End Function
    Public Function Indice(ByRef coTabla As ComboBox, Id As Integer) As Integer
        Dim x As Integer
        'If IsNull(Id) Then Exit Function
        'If Id = "" Then Exit Function

        For x = 0 To coTabla.Items.Count - 1

            '    If coTabla.ItemData(x) = Id Then Return x

        Next x
        ' Valor no encontrado
        Return -1
    End Function

    '    Public Sub LeerFoto(RutaF As String, Foto As String, imFoto As Image)
    '        Dim y As String
    '        On Error Resume Next
    '        ' Revisar archivo sin extención
    '        If InStr(Foto, ".") = 0 Then y = ".*"
    '        ' Revisar existencia del archivo
    '        Foto = Dir(RutaF & Foto & y)
    '' Limpiar foto primero
    'Set imFoto.Picture = LoadPicture()
    '' Leer foto si hay
    'If Foto <> "" Then Set imFoto.Picture = LoadPicture(RutaF & Foto)
    'End Sub
    Public Function LeerPeso(MSC As Object) As String
        Dim y As String
        ' Enviar
        y = IIf(CodEsc = "P", "P", "IP" & vbCrLf)
        MSC.Output = y
        ' Un momentito...
        UnMomentito(0.3)
        ' Recibir
        y = Trim(MSC.Input)
        ' Revisar lectura
        If y = "" Then
            ' Sin lectura
            Return "**********"
        Else
            ' Eliminar CR
            ' y = "WN000.051kg" & Chr(13) & Chr(10) & "WN000.051kg" & Chr(13) & Chr(10)
            If InStr(y, vbCr) > 0 Then y = Left(y, InStr(y, vbCr) - 1)
            ' Sólo números a la izquierda
            ' y = "WN000.051kg"
            Do Until Asc(y) < 58
                y = Mid(y, 2)
                If y = "" Then Return ""
            Loop
            ' Mostrar lectura
            Return y
        End If
    End Function
    Public Sub MandarCorreo(Ouner As Long, Correo As String, Asunto As String, Mensaje As String,
        Optional Adjunto As String = "")
        Dim Id As Long
        Dim R As String
        Dim Cx As String, Cy As String, CC As String = ""
        Dim x As Integer
        Dim y As String
        Dim Adj As String
        On Error Resume Next
        ' Revisar ruta Blat.exe
        R = Ruta
        If Dir(R & "Blat.exe") = "" Then
            R = RutaApp
            If Dir(R & "Blat.exe") = "" Then
                MsgBox("No se encontró el programa Blat.exe.", 16, Titulo)
                Exit Sub
            End If
        End If
        ' Valores por defecto
        If Asunto = "" Then Asunto = AsuntoE
        If Mensaje = "" Then Mensaje = MensajeE
        ' Revisar adjuntos con comillas y separados por comas
        ' Adj = " -attach " & Chr(34) & Adj1 & "," & Adj2 & Chr(34)
        If Adjunto <> "" Then Adj = " -attach """ & Adjunto & """"
        ' Primer correo
        Cx = Correo
        ' Revisar correo lugar de entrega (sucursal)
        If CorreoCL <> "" Then Cx = Cx & ", " & CorreoCL
        ' Revisar correo CC
        If CorreoCC <> "" Then
            Cx = Cx & ", " & CorreoCC
            ' Agregar al mensaje
            CC = vbCrLf & vbCrLf & "CC: " & CorreoCC
        End If
        ' Revisar correos, reemplazar ";" por ","
        Cx = Cx.Replace(";", ",")
        ' Eliminar "," al final
        Cx = Trim(Cx)
        If Right(Cx, 1) = "," Then Cx = Left(Cx, Len(Cx) - 1)
        ' Revisar varios correos
        Do Until Cx = ""
            x = InStr(Cx, ",")
            If x > 0 Then
                Cy = Left(Cx, x - 1)
                Cx = Trim(Mid(Cx, x + 1))
            Else
                Cy = Cx
                Cx = ""
            End If
            ' Línea de comandos
            y = "-to " & Cy &
                " -subject """ & Asunto & """" &
                " -body """ & Mensaje & CC & """" &
                " -u " & Usuario &
                " -pw " & ClaveU &
                Adj &
                " -serverSMTP " & ServidorSMTP &
                " -port " & PuertoE &
                " -f " & Remitente
            ' Tiempo para nuevo correo
            If Id > 0 Then UnMomentito(2)
            ' Enviar correo, abrir Blat
            Id = ShellExecute(Ouner, "Open", "Blat.exe", y, R, 0)
        Loop
    End Sub
    Public Function LeerDatoXML(ByVal tx As String, Dato As String, Optional Nodo As String = "") As String
        Dim d As String
        Dim x1 As Long, x2 As Long
        Dim y As String
        Dim z As String
        ' Usar una copia del dato para el segundo intento
        ' El espacio al principio evita leer datos con la misma terminación (Ej. SubTotal y Total)
        d = " " & Dato
        ' Restringir la busqueda por nodo
        If Nodo <> "" Then
            x1 = InStr(tx, Nodo) + Len(Nodo)
            x2 = InStr(CInt(x1), tx, ">")
            tx = Mid(tx, x1, x2 - x1)
        End If
        ' Primero revisar tipo de dato
RevTipo:
        If Right(d, 1) = "=" Then
            ' Tipo atributo ya definido
            y = Chr(34)
            d = d & y
        Else
            ' Busacar tipo de dato
            If InStr(tx, d & "=") > 0 Then
                ' Tipo atributo
                y = Chr(34)
                d = d & "=" & y
            Else
                ' Tipo nodo por defecto
                y = "<"
                d = Trim(d) & ">"
            End If
        End If
        ' Revisar dato
        x1 = InStr(tx, d)
        If x1 = 0 Then
            ' Segundo intento
            If x2 = 0 Then
                ' Primera letra mayúscula
                ' El espacio al principio evita leer datos con la misma terminación (Ej. SubTotal y Total)
                d = " " & UCase(Left(Dato, 1)) & Mid(Dato, 2)
                x2 = 1
                GoTo RevTipo
            End If
            ' Dato no encontrado
            Return ""
        End If
        ' Inicio de la cadena
        x1 = x1 + Len(d)
        ' Fin de la cadena
        x2 = InStr(CInt(x1), tx, y)
        ' Leer dato
        d = Mid(tx, x1, x2 - x1)
        ' Revisar UTF8
        If InStr(d, "Ã") > 0 Then
            For x1 = 1 To 12
                y = "Ã" & Choose(x1, Chr(129), Chr(137), Chr(141), Chr(147), Chr(154), "¡", "©", "­", "³", "º", "‘", "±")
                z = Choose(x1, "Á", "É", "Í", "Ó", "Ú", "á", "é", "í", "ó", "ú", "Ñ", "ñ")
                ' Remplazar
                d = d.Replace(y, z)
            Next x1
        End If
        Return d
    End Function
End Module
