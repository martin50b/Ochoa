Module SubCatalogos
    ' 12/dic/16 Agregar Sub LeerRegimen para V3.3
    ' 19/ene/18 Agregar catálogos comercio exterior
    ' 23/abr/18 Agregar "15-Condonación" en LeerFormaPago programa Ochoa
    ' 23/jun/18 Agregar Efecto en LeerTipoRelacion
    ' 07/jul/18 Agregar Forma de pago con datos extra opcional
    ' 12/dic/18 Actualización 01/sep/18 SAT en LeerTipoRelacion y LeerFormaPago
    ' 12/jul/19 Agregar "17-Compensación" en Sub LeerFormaPago
    Public Sub SelDatoTabla(coTabla As Object, Dato As String)
        ' Seleccionar un dato dentro de una tabla (ComboBox)
        ' coTabla es un control ComboBox
        ' El dato es la clave de acuerdo a los catálogos del SAT, por ejemplo "P01" para
        ' especificar "Por definir" dentro de la tabla de Uso del CFDI
        Dim coTablaItems As Object
        ' Revisar tipo de control
        If TypeOf coTabla Is ComboBox Then
            coTablaItems = coTabla.Items
        ElseIf TypeOf coTabla Is DevExpress.XtraEditors.ComboBoxEdit Then
            coTablaItems = coTabla.Properties.Items
        Else
            ' Pendiente
        End If
        ' Buscar dato en la tabla
        If Dato <> "" Then
            Dim n As Integer
            ' Los datos de la lista deben tener la misma longitud que el dato buscado 
            n = Len(Dato)
            ' Buscando...
            Dim x As Integer
            For x = 0 To coTablaItems.Count - 1
                If Left(coTablaItems(x), n) = Dato Then
                    ' Seleccionar dato
                    coTabla.SelectedIndex = x
                    'coTabla.DataChanged = False
                    Exit Sub
                End If
            Next x
        End If
        ' Dato no encontrado
        coTabla.SelectedIndex = -1
    End Sub
    Public Sub LeerRegimen(coRegimen As Object, Moral As Boolean)
        ' Catálogo Régimen fiscal
        ' coRegimen es un ComboBox
        ' Persona moral, Moral = True
        ' Persona física, Moral = False
        Dim coRegimenItems As Object
        ' Revisar tipo de control
        If TypeOf coRegimen Is ComboBox Then
            coRegimenItems = coRegimen.Items
        ElseIf TypeOf coRegimen Is DevExpress.XtraEditors.ComboBoxEdit Then
            coRegimenItems = coRegimen.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coRegimenItems.Clear
        ' Llenar datos
        If Moral Then
            ' Persona moral
            coRegimenItems.Add("601-General de Ley Personas Morales")
            coRegimenItems.Add("603-Personas Morales con Fines no Lucrativos")
            coRegimenItems.Add("607-Régimen de Enajenación o Adquisición de Bienes")
            coRegimenItems.Add("609-Consolidación")
            coRegimenItems.Add("620-Sociedades Cooperativas de Producción que optan por diferir sus ingresos")
            coRegimenItems.Add("622-Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras")
            coRegimenItems.Add("623-Opcional para Grupos de Sociedades")
            coRegimenItems.Add("624-Coordinados")
            coRegimenItems.Add("628-Hidrocarburos")
        Else
            ' Persona física
            coRegimenItems.Add("605-Sueldos y Salarios e Ingresos Asimilados a Salarios")
            coRegimenItems.Add("606-Arrendamiento")
            coRegimenItems.Add("608-Demás ingresos")
            coRegimenItems.Add("611-Ingresos por Dividendos (socios y accionistas)")
            coRegimenItems.Add("612-Personas Físicas con Actividades Empresariales y Profesionales")
            coRegimenItems.Add("614-Ingresos por intereses")
            coRegimenItems.Add("615-Régimen de los ingresos por obtención de premios")
            coRegimenItems.Add("616-Sin obligaciones fiscales")
            coRegimenItems.Add("621-Incorporación Fiscal")
            coRegimenItems.Add("622-Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras")
            coRegimenItems.Add("629-De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales")
            coRegimenItems.Add("630-Enajenación de acciones en bolsa de valores")
        End If
    End Sub
    Public Sub LeerFormaPago(coFormaPago As Object, Tipo As Byte)
        ' Catálogo Forma de pago
        ' coFormaPago es un ComboBox
        ' Tipo:
        ' Forma de pago para el cliente = 0
        ' Forma de pago para el cliente con nota de crédito = 1
        ' Forma de pago para facturas = 2
        ' Forma de pago con datos extras para facturas = 3
        ' Forma de pago lista completa = 4
        Dim coFormaPagoItems As Object
        ' Revisar tipo de control
        If TypeOf coFormaPago Is ComboBox Then
            coFormaPagoItems = coFormaPago.Items
        ElseIf TypeOf coFormaPago Is DevExpress.XtraEditors.ComboBoxEdit Then
            coFormaPagoItems = coFormaPago.Properties.Items
        Else
            ' Pendiente
        End If
        On Error GoTo ConError
        ' Primero limpiar lista
        coFormaPagoItems.Clear
        ' Llenar datos
        If Tipo < 2 Then
            ' Forma de pago para el cliente (Tipo = 0)
            coFormaPagoItems.Add("Efectivo")
            coFormaPagoItems.Add("Cheque")
            coFormaPagoItems.Add("Transferencia")
            coFormaPagoItems.Add("Tarjeta crédito")
            coFormaPagoItems.Add("Tarjeta débito")
            ' Tipo de cobro
            If Tipo = 1 Then
                coFormaPagoItems.Add("Nota de crédito")
                ' Prueba para agregar de manera definitiva (Salsas Conmadre-28/may/20)
                coFormaPagoItems.Add("Compensación")

                ' Especial para Ochoa
                'If InStr(Programa, "Ochoa") > 0 Then coFormaPagoItems.Add("Compensación")
            End If
        Else
            ' Forma de pago para facturas (Tipo = 2)
            coFormaPagoItems.Add("01-Efectivo")
            coFormaPagoItems.Add("02-Cheque nominativo")
            coFormaPagoItems.Add("03-Transferencia electrónica de fondos")
            coFormaPagoItems.Add("04-Tarjeta de crédito")
            coFormaPagoItems.Add("28-Tarjeta de débito")
            coFormaPagoItems.Add("30-Aplicación de anticipos")
            coFormaPagoItems.Add("99-Por definir")
            ' Con datos extras
            If Tipo = 3 Then

                'Dim Db As Database, Rs As Recordset
                'Dim Qry As String
                'Qry = "SELECT DISTINCT FPago FROM Facturas WHERE InStr('01 02 03 04 28 30 99', FPago) = 0 ORDER BY FPago"
                'Set Db = OpenDatabase(Ruta & Archivo, False, False, MiPWD)
                'Set Rs = Db.OpenRecordset(Qry)
                'Do Until Rs.EOF
                '    Select Case Rs(0)
                '        Case "05" : Qry = "05-Monedero electrónico"
                '        Case "06" : Qry = "06-Dinero electrónico"
                '        Case "08" : Qry = "08-Vales de despensa"
                '        Case "12" : Qry = "12-Dación en pago"
                '        Case "13" : Qry = "13-Pago por subrogación"
                '        Case "14" : Qry = "14-Pago por consignación"
                '        Case "15" : Qry = "15-Condonación"
                '        Case "17" : Qry = "17-Compensación"
                '        Case "23" : Qry = "23-Novación"
                '        Case "24" : Qry = "24-Confusión"
                '        Case "25" : Qry = "25-Remisión de deuda"
                '        Case "26" : Qry = "26-Prescripción o caducidad"
                '        Case "27" : Qry = "27-A satisfacción del acreedor"
                '        Case "29" : Qry = "29-Tarjeta de servicios"
                '        ' Actualización 01/sep/18 SAT
                '        Case "31" : Qry = "31-Intermediario pagos"
                '    End Select
                '    coFormaPagoItems.Add(Qry)
                '    ' Siguiente
                '    Rs.MoveNext
                'Loop
                '' Ver todo
                coFormaPagoItems.Add("Ver lista completa")
                'Rs.Close
                'Db.Close

            End If
            ' Lista completa
            If Tipo = 4 Then
                coFormaPagoItems.Add("05-Monedero electrónico")
                coFormaPagoItems.Add("06-Dinero electrónico")
                coFormaPagoItems.Add("08-Vales de despensa")
                coFormaPagoItems.Add("12-Dación en pago")
                coFormaPagoItems.Add("13-Pago por subrogación")
                coFormaPagoItems.Add("14-Pago por consignación")
                coFormaPagoItems.Add("15-Condonación")
                coFormaPagoItems.Add("17-Compensación")
                coFormaPagoItems.Add("23-Novación")
                coFormaPagoItems.Add("24-Confusión")
                coFormaPagoItems.Add("25-Remisión de deuda")
                coFormaPagoItems.Add("26-Prescripción o caducidad")
                coFormaPagoItems.Add("27-A satisfacción del acreedor")
                coFormaPagoItems.Add("29-Tarjeta de servicios")
                ' Actualización 01/sep/18 SAT
                coFormaPagoItems.Add("31-Intermediario pagos")
            End If
        End If
        Exit Sub
ConError:
        MsgBox(Err.Description, 16, "SRSystem")
        Err.Clear()
    End Sub
    Public Sub LeerMetodoPago(coMetodoPago As Object)
        ' Catálogo Método de pago
        ' coMetodoPago es un ComboBox
        Dim coMetodoPagoItems As Object
        ' Revisar tipo de control
        If TypeOf coMetodoPago Is ComboBox Then
            coMetodoPagoItems = coMetodoPago.Items
        ElseIf TypeOf coMetodoPago Is DevExpress.XtraEditors.ComboBoxEdit Then
            coMetodoPagoItems = coMetodoPago.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coMetodoPagoItems.Clear
        ' Llenar datos
        coMetodoPagoItems.Add("PUE-Pago en una sola exhibición")
        coMetodoPagoItems.Add("PPD-Pago en parcialidades o diferido")
        'coMetodoPagoItems.Add("PIP-Pago inicial y parcialidades"
    End Sub
    Public Sub LeerTContrato(coContrato As Object)
        ' Catálogo Tipo de contrato
        ' coContrato es un ComboBox
        Dim coContratoItems As Object
        ' Revisar tipo de control
        If TypeOf coContrato Is ComboBox Then
            coContratoItems = coContrato.Items
        ElseIf TypeOf coContrato Is DevExpress.XtraEditors.ComboBoxEdit Then
            coContratoItems = coContrato.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coContratoItems.Clear
        ' Se requiere Registro patronal:
        coContratoItems.Add("01-Contrato de trabajo por tiempo indeterminado")
        coContratoItems.Add("02-Contrato de trabajo para obra determinada")
        coContratoItems.Add("03-Contrato de trabajo por tiempo determinado")
        coContratoItems.Add("04-Contrato de trabajo por temporada")
        coContratoItems.Add("05-Contrato de trabajo sujeto a prueba")
        coContratoItems.Add("06-Contrato de trabajo con capacitación inicial")
        coContratoItems.Add("07-Modalidad de contratación por pago de hora laborada")
        coContratoItems.Add("08-Modalidad de trabajo por comisión laboral")
        Dim x As Integer
        For x = 0 To coContratoItems.Count - 1
            coContratoItems.ItemData(x) = 1
        Next x
        ' No usar Registro patronal:
        coContratoItems.Add("09-Modalidades de contratación donde no existe relación de trabajo")
        coContratoItems.Add("10-Jubilación, pensión, retiro")
        coContratoItems.Add("99-Otro contrato")
    End Sub
    Public Sub LeerJornada(coJornada As Object)
        ' Catálogo Tipo de jornada
        ' coJornada es un ComboBox
        Dim coJornadaItems As Object
        ' Revisar tipo de control
        If TypeOf coJornada Is ComboBox Then
            coJornadaItems = coJornada.Items
        ElseIf TypeOf coJornada Is DevExpress.XtraEditors.ComboBoxEdit Then
            coJornadaItems = coJornada.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coJornadaItems.Clear
        ' Llenar datos
        coJornadaItems.Add("Omitir")
        coJornadaItems.Add("01-Diurna")
        coJornadaItems.Add("02-Nocturna")
        coJornadaItems.Add("03-Mixta")
        coJornadaItems.Add("04-Por hora")
        coJornadaItems.Add("05-Reducida")
        coJornadaItems.Add("06-Continuada")
        coJornadaItems.Add("07-Partida")
        coJornadaItems.Add("08-Por turnos")
        coJornadaItems.Add("99-Otra Jornada")
    End Sub
    Public Sub LeerTRegimen(coRegimen As Object)
        ' Catálogo Tipo de régimen
        ' coRegimen es un ComboBox
        Dim coRegimenItems As Object
        ' Revisar tipo de control
        If TypeOf coRegimen Is ComboBox Then
            coRegimenItems = coRegimen.Items
        ElseIf TypeOf coRegimen Is DevExpress.XtraEditors.ComboBoxEdit Then
            coRegimenItems = coRegimen.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coRegimenItems.Clear
        ' Se requiere Registro patronal:
        coRegimenItems.Add("02-Sueldos (Incluye ingresos señalados en el Art. 94, Fracc. I de LISR)")
        coRegimenItems.Add("03-Jubilados")
        coRegimenItems.Add("04-Pensionados")
        ' Para poder relacionar con el tipo de Regimen
        Dim X As Integer
        For X = 0 To 2
            ' coRegimenItems.ItemData(X) = 1
        Next X
        ' No usar Registro patronal:
        coRegimenItems.Add("05-Asimilados Miembros Sociedades Cooperativas Produccion")
        coRegimenItems.Add("06-Asimilados Integrantes Sociedades Asociaciones Civiles")
        coRegimenItems.Add("07-Asimilados Miembros consejos")
        coRegimenItems.Add("08-Asimilados comisionistas")
        coRegimenItems.Add("09-Asimilados Honorarios")
        coRegimenItems.Add("10-Asimilados acciones")
        coRegimenItems.Add("11-Asimilados otros")
        coRegimenItems.Add("12-Jubilados o Pensionados")  ' Agregado 27/03/17 (02/oct/18)
        coRegimenItems.Add("99-Otro Regimen")
    End Sub
    Public Sub LeerPeriodoPago(coPeriodo As Object)
        ' Catálogo Periodos laborales
        ' coPeriodo es un ComboBox
        Dim coPeriodoItems As Object
        ' Revisar tipo de control
        If TypeOf coPeriodo Is ComboBox Then
            coPeriodoItems = coPeriodo.Items
        ElseIf TypeOf coPeriodo Is DevExpress.XtraEditors.ComboBoxEdit Then
            coPeriodoItems = coPeriodo.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coPeriodoItems.clear
        ' Llenar datos
        coPeriodoItems.add("01-Diario")
        coPeriodoItems.add("02-Semanal")
        coPeriodoItems.add("03-Catorcenal")
        coPeriodoItems.add("04-Quincenal")
        coPeriodoItems.add("05-Mensual")
        coPeriodoItems.add("06-Bimestral")
        coPeriodoItems.add("07-Unidad obra")
        coPeriodoItems.add("08-Comisión")
        coPeriodoItems.add("09-Precio alzado")
        ' Inicio vigencia 19/01/17 (02/oct/18):
        coPeriodoItems.add("10-Decenal")
        ' Para nómina extraordinaria (Seleccionar directamente en la factura):
        ' "99-Otra Periodicidad"
    End Sub
    Public Sub LeerUsoCFDI(coUso As Object, PFisica As Boolean)
        Dim coUsoItems As Object
        ' Revisar tipo de control
        If TypeOf coUso Is ComboBox Then
            coUsoItems = coUso.Items
        ElseIf TypeOf coUso Is DevExpress.XtraEditors.ComboBoxEdit Then
            coUsoItems = coUso.Properties.Items
        Else
            ' Declaras una varible de tipo ArrayList
            coUsoItems = New ArrayList
        End If
        ' Dentro de ese ArrayList agregas los elementos que necesitas en la lista
        ' Aplica para personas Físicas y Morales
        coUsoItems.Add("G01-Adquisición de mercancias")
        coUsoItems.Add("G02-Devoluciones, descuentos o bonificaciones")
        coUsoItems.Add("G03-Gastos en general")
        coUsoItems.Add("I01-Construcciones")
        coUsoItems.Add("I02-Mobilario y equipo de oficina por inversiones")
        coUsoItems.Add("I03-Equipo de transporte")
        coUsoItems.Add("I04-Equipo de computo y accesorios")
        coUsoItems.Add("I05-Dados, troqueles, moldes, matrices y herramental")
        coUsoItems.Add("I06-Comunicaciones telefónicas")
        coUsoItems.Add("I07-Comunicaciones satelitales")
        coUsoItems.Add("I08-Otra maquinaria y equipo")
        If PFisica Then
            ' Aplica sólo para personas fisicas
            coUsoItems.Add("D01-Honorarios médicos, dentales y gastos hospitalarios")
            coUsoItems.Add("D02-Gastos médicos por incapacidad o discapacidad")
            coUsoItems.Add("D03-Gastos funerales")
            coUsoItems.Add("D04-Donativos")
            coUsoItems.Add("D05-Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)")
            coUsoItems.Add("D06-Aportaciones voluntarias al SAR")
            coUsoItems.Add("D07-Primas por seguros de gastos médicos")
            coUsoItems.Add("D08-Gastos de transportación escolar obligatoria")
            coUsoItems.Add("D09-Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones")
            coUsoItems.Add("D10-Pagos por servicios educativos (colegiaturas)")
        End If
        coUsoItems.Add("P01-Por definir")
        ' Asignas la varible ArrayList a la propiedad DataSource del combo
        If TypeOf coUso Is DevExpress.XtraEditors.LookUpEdit Then coUso.Properties.DataSource = coUsoItems
    End Sub
    Public Sub LeerTipoRelacion(coTRel As Object, Efecto As String)
        ' Catálogo Tipo de relación
        ' coTRel es un ComboBox
        ' Efecto "I" = Ingreso
        ' Efecto "E" = Egreso
        ' Efecto "P" = Pago
        ' Efecto "N" = Nómina
        Dim coTRelItems As Object
        ' Revisar tipo de control
        If TypeOf coTRel Is ComboBox Then
            coTRelItems = coTRel.Items
        ElseIf TypeOf coTRel Is DevExpress.XtraEditors.ComboBoxEdit Then
            coTRelItems = coTRel.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coTRelItems.Clear
        ' Tipo de relación
        Select Case Efecto
            Case "E", ""   ' Todos los datos
                coTRelItems.Add("01-Nota de crédito de los documentos relacionados")
                coTRelItems.Add("02-Nota de débito de los documentos relacionados")
                coTRelItems.Add("03-Devolución de mercancía sobre facturas previas")
                'coTRelItems.Add("03-Devolución de mercancía sobre facturas o traslados previos")
                coTRelItems.Add("04-Sustitución de los CFDI previos")
                coTRelItems.Add("07-CFDI por aplicación de anticipo")
            Case "I"
                coTRelItems.Add("04-Sustitución de los CFDI previos")
                coTRelItems.Add("07-CFDI por aplicación de anticipo")
                ' Actualización 01/sep/18 SAT
                coTRelItems.Add("08-Factura generada por pagos en parcialidades")
                coTRelItems.Add("09-Factura generada por pagos diferidos")
            Case "P", "N"
                coTRelItems.Add("04-Sustitución de los CFDI previos")
        End Select

        ' Para transportistas
        ' coTRelItems.Add("05-Traslados de mercancias facturados previamente")
        ' coTRelItems.Add("06-Factura generada por los traslados previos")
    End Sub
    Public Sub LeerCPais(coPais As Object)
        ' Catálogo de Paises para comercio exterior
        ' coPais es un ComboBox
        Dim coPaisItems As Object
        ' Revisar tipo de control
        If TypeOf coPais Is ComboBox Then
            coPaisItems = coPais.Items
        ElseIf TypeOf coPais Is DevExpress.XtraEditors.ComboBoxEdit Then
            coPaisItems = coPais.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coPaisItems.Clear
        ' Llenar datos
        coPaisItems.Add("AFG-Afganistán")
        coPaisItems.Add("ALB-Albania")
        coPaisItems.Add("DEU-Alemania")
        coPaisItems.Add("AND-Andorra")
        coPaisItems.Add("AGO-Angola")
        coPaisItems.Add("AIA-Anguila")
        coPaisItems.Add("ATA-Antártida")
        coPaisItems.Add("ATG-Antigua y Barbuda")
        coPaisItems.Add("SAU-Arabia Saudita")
        coPaisItems.Add("DZA-Argelia")
        coPaisItems.Add("ARG-Argentina")
        coPaisItems.Add("ARM-Armenia")
        coPaisItems.Add("ABW-Aruba")
        coPaisItems.Add("AUS-Australia")
        coPaisItems.Add("AUT-Austria")
        coPaisItems.Add("AZE-Azerbaiyán")
        coPaisItems.Add("BHS-Bahamas(las)")
        coPaisItems.Add("BGD-Bangladés")
        coPaisItems.Add("BRB-Barbados")
        coPaisItems.Add("BHR-Baréin")
        coPaisItems.Add("BEL-Bélgica")
        coPaisItems.Add("BLZ-Belice")
        coPaisItems.Add("BEN-Benín")
        coPaisItems.Add("BMU-Bermudas")
        coPaisItems.Add("BLR-Bielorrusia")
        coPaisItems.Add("BOL-Bolivia, Estado Plurinacional de")
        coPaisItems.Add("BES-Bonaire, San Eustaquio y Saba")
        coPaisItems.Add("BIH-Bosnia y Herzegovina")
        coPaisItems.Add("BWA-Botsuana")
        coPaisItems.Add("BRA-Brasil")
        coPaisItems.Add("BRN-Brunéi Darussalam")
        coPaisItems.Add("BGR-Bulgaria")
        coPaisItems.Add("BFA-Burkina Faso")
        coPaisItems.Add("BDI-Burundi")
        coPaisItems.Add("BTN-Bután")
        coPaisItems.Add("CPV-Cabo Verde")
        coPaisItems.Add("KHM-Camboya")
        coPaisItems.Add("CMR-Camerún")
        coPaisItems.Add("CAN-Canadá")
        coPaisItems.Add("QAT-Catar")
        coPaisItems.Add("TCD-Chad")
        coPaisItems.Add("CHL-Chile")
        coPaisItems.Add("CHN-China")
        coPaisItems.Add("CYP-Chipre")
        coPaisItems.Add("COL-Colombia")
        coPaisItems.Add("COM-Comoras")
        coPaisItems.Add("COG-Congo")
        coPaisItems.Add("COD-Congo (la República Democrática del)")
        coPaisItems.Add("KOR-Corea (la República de)")
        coPaisItems.Add("PRK-Corea (la República Democrática Popular de)")
        coPaisItems.Add("CRI-Costa Rica")
        coPaisItems.Add("CIV-Cote d'Ivoire")
        coPaisItems.Add("HRV-Croacia")
        coPaisItems.Add("CUB-Cuba")
        coPaisItems.Add("CUW-Curaçao")
        coPaisItems.Add("DNK-Dinamarca")
        coPaisItems.Add("DMA-Dominica")
        coPaisItems.Add("ECU-Ecuador")
        coPaisItems.Add("EGY-Egipto")
        coPaisItems.Add("SLV-El Salvador")
        coPaisItems.Add("ARE-Emiratos Árabes Unidos (Los)")
        coPaisItems.Add("ERI-Eritrea")
        coPaisItems.Add("SVK-Eslovaquia")
        coPaisItems.Add("SVN-Eslovenia")
        coPaisItems.Add("ESP-España")
        coPaisItems.Add("USA-Estados Unidos de América")
        coPaisItems.Add("EST-Estonia")
        coPaisItems.Add("ETH-Etiopía")
        coPaisItems.Add("PHL-Filipinas(las)")
        coPaisItems.Add("FIN-Finlandia")
        coPaisItems.Add("FJI-Fiyi")
        coPaisItems.Add("FRA-Francia")
        coPaisItems.Add("GAB-Gabón")
        coPaisItems.Add("GMB-Gambia(la)")
        coPaisItems.Add("GEO-Georgia")
        coPaisItems.Add("SGS-Georgia del sur y las islas sandwich del sur")
        coPaisItems.Add("GHA-Ghana")
        coPaisItems.Add("GIB-Gibraltar")
        coPaisItems.Add("GRD-Granada")
        coPaisItems.Add("GRC-Grecia")
        coPaisItems.Add("GRL-Groenlandia")
        coPaisItems.Add("GLP-Guadalupe")
        coPaisItems.Add("GUM-Guam")
        coPaisItems.Add("GTM-Guatemala")
        coPaisItems.Add("GUF-Guayana Francesa")
        coPaisItems.Add("GGY-Guernsey")
        coPaisItems.Add("GIN-Guinea")
        coPaisItems.Add("GNQ-Guinea Ecuatorial")
        coPaisItems.Add("GNB-Guinea Bisáu")
        coPaisItems.Add("GUY-Guyana")
        coPaisItems.Add("HTI-Haití")
        coPaisItems.Add("HND-Honduras")
        coPaisItems.Add("HKG-Hong Kong")
        coPaisItems.Add("HUN-Hungría")
        coPaisItems.Add("Ind-India")
        coPaisItems.Add("IDN-Indonesia")
        coPaisItems.Add("IRQ-Irak")
        coPaisItems.Add("IRN-Irán (la República Islámica de)")
        coPaisItems.Add("IRL-Irlanda")
        coPaisItems.Add("BVT-Isla Bouvet")
        coPaisItems.Add("IMN-Isla de Man")
        coPaisItems.Add("CXR-Isla de Navidad")
        coPaisItems.Add("HMD-Isla Heard e Islas McDonald")
        coPaisItems.Add("NFK-Isla Norfolk")
        coPaisItems.Add("ISL-Islandia")
        coPaisItems.Add("ALA-Islas Aland")
        coPaisItems.Add("CYM-Islas Caimán (las)")
        coPaisItems.Add("CCK-Islas Cocos (Keeling)")
        coPaisItems.Add("COK-Islas Cook (las)")
        coPaisItems.Add("UMI-Islas de Ultramar Menores de Estados Unidos (las)")
        coPaisItems.Add("FRO-Islas Feroe (las)")
        coPaisItems.Add("FLK-Islas Malvinas [Falkland] (las)")
        coPaisItems.Add("MNP-Islas Marianas del Norte (las)")
        coPaisItems.Add("MHL-Islas Marshall (las)")
        coPaisItems.Add("SLB-Islas Salomón (las)")
        coPaisItems.Add("TCA-Islas Turcas y Caicos (las)")
        coPaisItems.Add("VGB-Islas Vírgenes (Británicas)")
        coPaisItems.Add("VIR-Islas Vírgenes (EE.UU.)")
        coPaisItems.Add("ISR-Israel")
        coPaisItems.Add("ITA-Italia")
        coPaisItems.Add("JAM-Jamaica")
        coPaisItems.Add("JPN-Japón")
        coPaisItems.Add("JEY-Jersey")
        coPaisItems.Add("JOR-Jordania")
        coPaisItems.Add("KAZ-Kazajistán")
        coPaisItems.Add("KEN-Kenia")
        coPaisItems.Add("KGZ-Kirguistán")
        coPaisItems.Add("KIR-Kiribati")
        coPaisItems.Add("KWT-Kuwait")
        coPaisItems.Add("LAO-Lao, (la) República Democrática Popular")
        coPaisItems.Add("LSO-Lesoto")
        coPaisItems.Add("LVA-Letonia")
        coPaisItems.Add("LBN-Líbano")
        coPaisItems.Add("LBR-Liberia")
        coPaisItems.Add("LBY-Libia")
        coPaisItems.Add("LIE-Liechtenstein")
        coPaisItems.Add("LTU-Lituania")
        coPaisItems.Add("LUX-Luxemburgo")
        coPaisItems.Add("Mac-Macao")
        coPaisItems.Add("MKD-Macedonia (la antigua República Yugoslava de)")
        coPaisItems.Add("MDG-Madagascar")
        coPaisItems.Add("MYS-Malasia")
        coPaisItems.Add("MWI-Malaui")
        coPaisItems.Add("MDV-Maldivas")
        coPaisItems.Add("MLI-Malí")
        coPaisItems.Add("MLT-Malta")
        coPaisItems.Add("MAR-Marruecos")
        coPaisItems.Add("MTQ-Martinica")
        coPaisItems.Add("MUS-Mauricio")
        coPaisItems.Add("MRT-Mauritania")
        coPaisItems.Add("MYT-Mayotte")
        coPaisItems.Add("FSM-Micronesia (los Estados Federados de)")
        coPaisItems.Add("MDA-Moldavia (la República de)")
        coPaisItems.Add("MCO-Mónaco")
        coPaisItems.Add("MNG-Mongolia")
        coPaisItems.Add("MNE-Montenegro")
        coPaisItems.Add("MSR-Montserrat")
        coPaisItems.Add("MOZ-Mozambique")
        coPaisItems.Add("MMR-Myanmar")
        coPaisItems.Add("NAM-Namibia")
        coPaisItems.Add("NRU-Nauru")
        coPaisItems.Add("NPL-Nepal")
        coPaisItems.Add("NIC-Nicaragua")
        coPaisItems.Add("NER-Níger(el)")
        coPaisItems.Add("NGA-Nigeria")
        coPaisItems.Add("NIU-Niue")
        coPaisItems.Add("NOR-Noruega")
        coPaisItems.Add("NCL-Nueva Caledonia")
        coPaisItems.Add("NZL-Nueva Zelanda")
        coPaisItems.Add("OMN-Omán")
        coPaisItems.Add("NLD-Países Bajos (los)")
        coPaisItems.Add("PAK-Pakistán")
        coPaisItems.Add("PLW-Palaos")
        coPaisItems.Add("PSE-Palestina, Estado de")
        coPaisItems.Add("PAN-Panamá")
        coPaisItems.Add("PNG-Papúa Nueva Guinea")
        coPaisItems.Add("PRY-Paraguay")
        coPaisItems.Add("PER-Perú")
        coPaisItems.Add("PCN-Pitcairn")
        coPaisItems.Add("PYF-Polinesia Francesa")
        coPaisItems.Add("POL-Polonia")
        coPaisItems.Add("PRT-Portugal")
        coPaisItems.Add("PRI-Puerto Rico")
        coPaisItems.Add("GBR-Reino Unido (el)")
        coPaisItems.Add("CAF-República Centroafricana (la)")
        coPaisItems.Add("CZE-República Checa (la)")
        coPaisItems.Add("DOM-República Dominicana (la)")
        coPaisItems.Add("REU-Reunión")
        coPaisItems.Add("RWA-Ruanda")
        coPaisItems.Add("ROU-Rumania")
        coPaisItems.Add("RUS-Rusia, (la) Federación de")
        coPaisItems.Add("ESH-Sahara Occidental")
        coPaisItems.Add("WSM-Samoa")
        coPaisItems.Add("ASM-Samoa Americana")
        coPaisItems.Add("BLM-San Bartolomé")
        coPaisItems.Add("KNA-San Cristóbal y Nieves")
        coPaisItems.Add("SMR-San Marino")
        coPaisItems.Add("MAF-San Martín (parte francesa)")
        coPaisItems.Add("SPM-San Pedro y Miquelón")
        coPaisItems.Add("VCT-San Vicente y las Granadinas")
        coPaisItems.Add("SHN-Santa Helena, Ascensión y Tristán de Acuña")
        coPaisItems.Add("LCA-Santa Lucía")
        coPaisItems.Add("VAT-Santa Sede (Estado de la Ciudad del Vaticano)")
        coPaisItems.Add("STP-Santo Tomé y Príncipe")
        coPaisItems.Add("SEN-Senegal")
        coPaisItems.Add("SRB-Serbia")
        coPaisItems.Add("SYC-Seychelles")
        coPaisItems.Add("SLE-Sierra leona")
        coPaisItems.Add("SGP-Singapur")
        coPaisItems.Add("SXM-Sint Maarten (parte holandesa)")
        coPaisItems.Add("SYR-Siria, (la) República Árabe")
        coPaisItems.Add("SOM-Somalia")
        coPaisItems.Add("LKA-Sri Lanka")
        coPaisItems.Add("SWZ-Suazilandia")
        coPaisItems.Add("ZAF-Sudáfrica")
        coPaisItems.Add("SDN-Sudán(el)")
        coPaisItems.Add("SSD-Sudán del Sur")
        coPaisItems.Add("SWE-Suecia")
        coPaisItems.Add("CHE-Suiza")
        coPaisItems.Add("SUR-Surinam")
        coPaisItems.Add("SJM-Svalbard y Jan Mayen")
        coPaisItems.Add("THA-Tailandia")
        coPaisItems.Add("TWN-Taiwán (Provincia de China)")
        coPaisItems.Add("TZA-Tanzania, República Unida de")
        coPaisItems.Add("TJK-Tayikistán")
        coPaisItems.Add("IOT-Territorio Británico del Océano Índico (el)")
        coPaisItems.Add("ATF-Territorios Australes Franceses (los)")
        coPaisItems.Add("TLS-Timor Leste")
        coPaisItems.Add("TGO-Togo")
        coPaisItems.Add("TKL-Tokelau")
        coPaisItems.Add("TON-Tonga")
        coPaisItems.Add("TTO-Trinidad y Tobago")
        coPaisItems.Add("TUN-Túnez")
        coPaisItems.Add("TKM-Turkmenistán")
        coPaisItems.Add("TUR-Turquía")
        coPaisItems.Add("TUV-Tuvalu")
        coPaisItems.Add("UKR-Ucrania")
        coPaisItems.Add("UGA-Uganda")
        coPaisItems.Add("URY-Uruguay")
        coPaisItems.Add("UZB-Uzbekistán")
        coPaisItems.Add("VUT-Vanuatu")
        coPaisItems.Add("VEN-Venezuela, República Bolivariana de")
        coPaisItems.Add("VNM-Viet Nam")
        coPaisItems.Add("WLF-Wallis y Futuna")
        coPaisItems.Add("YEM-Yemen")
        coPaisItems.Add("DJI-Yibuti")
        coPaisItems.Add("ZMB-Zambia")
        coPaisItems.Add("ZWE-Zimbabue")
        coPaisItems.Add("ZZZ-Países no declarados")
    End Sub
    Public Sub LeerIncoterm(coIco As Object)
        ' Catálogo Icoterms para comercio exterior
        ' coIco es un ComboBox
        Dim coIcoItems As Object
        ' Revisar tipo de control
        If TypeOf coIco Is ComboBox Then
            coIcoItems = coIco.Items
        ElseIf TypeOf coIco Is DevExpress.XtraEditors.ComboBoxEdit Then
            coIcoItems = coIco.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coIcoItems.Clear
        ' Llenar datos
        coIcoItems.Add("CFR-COSTE Y FLETE (PUERTO DE DESTINO CONVENIDO)")
        coIcoItems.Add("CIF-COSTE, SEGURO Y FLETE (PUERTO DE DESTINO CONVENIDO)")
        coIcoItems.Add("CIP-TRANSPORTE Y SEGURO PAGADOS HASTA (LUGAR DE DESTINO CONVENIDO)")
        coIcoItems.Add("CPT-TRANSPORTE PAGADO HASTA (EL LUGAR DE DESTINO CONVENIDO)")
        coIcoItems.Add("DAF-ENTREGADA EN FRONTERA (LUGAR CONVENIDO)")
        coIcoItems.Add("DAP-ENTREGADA EN LUGAR")
        coIcoItems.Add("DAT-ENTREGADA EN TERMINAL")
        coIcoItems.Add("DDP-ENTREGADA DERECHOS PAGADOS (LUGAR DE DESTINO CONVENIDO)")
        coIcoItems.Add("DDU-ENTREGADA DERECHOS NO PAGADOS (LUGAR DE DESTINO CONVENIDO)")
        coIcoItems.Add("DEQ-ENTREGADA EN MUELLE (PUERTO DE DESTINO CONVENIDO)")
        coIcoItems.Add("DES-ENTREGADA SOBRE BUQUE (PUERTO DE DESTINO CONVENIDO)")
        coIcoItems.Add("EXW-EN FABRICA (LUGAR CONVENIDO)")
        coIcoItems.Add("FAS-FRANCO AL COSTADO DEL BUQUE (PUERTO DE CARGA CONVENIDO)")
        coIcoItems.Add("FCA-FRANCO TRANSPORTISTA (LUGAR DESIGNADO)")
        coIcoItems.Add("FOB-FRANCO A BORDO (PUERTO DE CARGA CONVENIDO)")
    End Sub
    Public Sub LeerUnidadAduana(coUnidad As Object)
        ' Catálogo Unidad aduanera comercio exterior
        ' coUnidad es un ComboBox
        Dim coUnidadItems As Object
        ' Revisar tipo de control
        If TypeOf coUnidad Is ComboBox Then
            coUnidadItems = coUnidad.Items
        ElseIf TypeOf coUnidad Is DevExpress.XtraEditors.ComboBoxEdit Then
            coUnidadItems = coUnidad.Properties.Items
        Else
            ' Pendiente
        End If
        ' Primero limpiar lista
        coUnidadItems.Clear
        ' Llenar datos
        coUnidadItems.Add("01-KILO")
        coUnidaditems.Add("02-GRAMO")
        coUnidaditems.Add("03-METRO LINEAL")
        coUnidaditems.Add("04-METRO CUADRADO")
        coUnidaditems.Add("05-METRO CUBICO")
        coUnidaditems.Add("06-PIEZA")
        coUnidaditems.Add("07-CABEZA")
        coUnidaditems.Add("08-LITRO")
        coUnidaditems.Add("09-PAR")
        coUnidaditems.Add("10-KILOWATT")
        coUnidaditems.Add("11-MILLAR")
        coUnidaditems.Add("12-JUEGO")
        coUnidaditems.Add("13-KILOWATT/HORA")
        coUnidaditems.Add("14-TONELADA")
        coUnidaditems.Add("15-BARRIL")
        coUnidaditems.Add("16-GRAMO NETO")
        coUnidaditems.Add("17-DECENAS")
        coUnidaditems.Add("18-CIENTOS")
        coUnidaditems.Add("19-DOCENAS")
        coUnidaditems.Add("20-CAJA")
        coUnidaditems.Add("21-BOTELLA")
        coUnidaditems.Add("99-SERVICIO")
    End Sub
End Module