VERSION 5.00
Object = "{00028C01-0000-0000-0000-000000000046}#1.0#0"; "DBGRID32.OCX"
Begin VB.Form fmReparto 
   Caption         =   "Salida a reparto"
   ClientHeight    =   11115
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   15240
   Icon            =   "Reparto.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MDIChild        =   -1  'True
   ScaleHeight     =   11115
   ScaleWidth      =   15240
   Tag             =   "Reparto.ayd"
   WindowState     =   2  'Maximized
   Begin VB.Data dtCajas 
      Caption         =   "dtCajas"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   2280
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   10680
      Visible         =   0   'False
      Width           =   2175
   End
   Begin MSDBGrid.DBGrid grCarga 
      Bindings        =   "Reparto.frx":164A
      Height          =   2880
      Left            =   360
      OleObjectBlob   =   "Reparto.frx":1676
      TabIndex        =   12
      Top             =   1890
      Width           =   9495
   End
   Begin VB.Data dtInventario 
      Caption         =   "dtInventario"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   2280
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   10320
      Visible         =   0   'False
      Width           =   2175
   End
   Begin VB.Data dtReparto 
      Caption         =   "dtReparto"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   120
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   10320
      Visible         =   0   'False
      Width           =   2175
   End
   Begin VB.Data dtCarga 
      Caption         =   "dtCarga"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   120
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   10680
      Visible         =   0   'False
      Width           =   2175
   End
   Begin VB.CommandButton cbLeer 
      Caption         =   "Leer"
      Height          =   315
      Left            =   2880
      TabIndex        =   4
      Top             =   600
      Width           =   855
   End
   Begin VB.Frame fr 
      Caption         =   "Datos del reparto: "
      Height          =   1815
      Index           =   1
      Left            =   4080
      TabIndex        =   46
      Top             =   0
      Width           =   7695
      Begin VB.CommandButton cbBuscar 
         Height          =   315
         Index           =   1
         Left            =   2280
         Picture         =   "Reparto.frx":26E4
         Style           =   1  'Graphical
         TabIndex        =   7
         ToolTipText     =   "Buscar número del repartidor"
         Top             =   600
         UseMaskColor    =   -1  'True
         Width           =   360
      End
      Begin VB.CommandButton cbBuscar 
         Height          =   315
         Index           =   2
         Left            =   2280
         Picture         =   "Reparto.frx":2A26
         Style           =   1  'Graphical
         TabIndex        =   9
         ToolTipText     =   "Buscar equipo"
         Top             =   960
         UseMaskColor    =   -1  'True
         Width           =   360
      End
      Begin VB.Label lbFecha 
         Alignment       =   2  'Center
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         DataField       =   "Fecha"
         DataSource      =   "dtReparto"
         Height          =   315
         Left            =   1200
         TabIndex        =   10
         ToolTipText     =   "Doble clic para cambiar"
         Top             =   1320
         Width           =   1455
      End
      Begin VB.Label lb 
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Fecha"
         Height          =   315
         Index           =   5
         Left            =   240
         TabIndex        =   34
         ToolTipText     =   "Doble click para reestablecer"
         Top             =   1320
         UseMnemonic     =   0   'False
         Width           =   975
      End
      Begin VB.Label lbHora 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackStyle       =   0  'Transparent
         DataField       =   "Hora"
         DataSource      =   "dtReparto"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   315
         Left            =   4200
         TabIndex        =   11
         Top             =   1320
         Width           =   3375
      End
      Begin VB.Label lbA 
         Appearance      =   0  'Flat
         BackStyle       =   0  'Transparent
         DataField       =   "FechaDía"
         DataSource      =   "dtReparto"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   315
         Index           =   3
         Left            =   2760
         TabIndex        =   42
         Top             =   1320
         Width           =   1335
      End
      Begin VB.Label lbA 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackStyle       =   0  'Transparent
         DataField       =   "Detalle"
         DataSource      =   "dtReparto"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   315
         Index           =   0
         Left            =   240
         TabIndex        =   39
         Top             =   240
         Width           =   7335
      End
      Begin VB.Label lbEco 
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         DataField       =   "Eco"
         DataSource      =   "dtReparto"
         Height          =   315
         Left            =   1200
         TabIndex        =   8
         Top             =   960
         Width           =   1095
      End
      Begin VB.Label lbRepartidor 
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         DataField       =   "Repartidor"
         DataSource      =   "dtReparto"
         Height          =   315
         Left            =   1200
         TabIndex        =   6
         Top             =   600
         Width           =   1095
      End
      Begin VB.Label lb 
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Equipo"
         Height          =   315
         Index           =   4
         Left            =   240
         TabIndex        =   33
         Top             =   960
         UseMnemonic     =   0   'False
         Width           =   975
      End
      Begin VB.Label lb 
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Repartidor"
         Height          =   315
         Index           =   3
         Left            =   240
         TabIndex        =   32
         Top             =   600
         UseMnemonic     =   0   'False
         Width           =   975
      End
      Begin VB.Label lbA 
         Appearance      =   0  'Flat
         BackStyle       =   0  'Transparent
         DataField       =   "Nombre"
         DataSource      =   "dtReparto"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   315
         Index           =   1
         Left            =   2760
         TabIndex        =   40
         Top             =   600
         Width           =   4815
      End
      Begin VB.Label lbA 
         Appearance      =   0  'Flat
         BackStyle       =   0  'Transparent
         DataField       =   "NombreE"
         DataSource      =   "dtReparto"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   315
         Index           =   2
         Left            =   2760
         TabIndex        =   41
         Top             =   960
         Width           =   4815
      End
   End
   Begin VB.CommandButton cbEliminar 
      Caption         =   "Eliminar"
      Height          =   315
      Left            =   2880
      TabIndex        =   5
      Top             =   1320
      Width           =   855
   End
   Begin VB.Frame fr 
      Caption         =   "Datos básicos: "
      Height          =   1815
      Index           =   0
      Left            =   120
      TabIndex        =   45
      Top             =   0
      Width           =   3855
      Begin VB.ComboBox coTP 
         BackColor       =   &H00C0C0FF&
         Height          =   315
         ItemData        =   "Reparto.frx":2D68
         Left            =   1200
         List            =   "Reparto.frx":2D6A
         Style           =   2  'Dropdown List
         TabIndex        =   3
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton cbBuscar 
         Height          =   315
         Index           =   0
         Left            =   2160
         Picture         =   "Reparto.frx":2D6C
         Style           =   1  'Graphical
         TabIndex        =   2
         ToolTipText     =   "Buscar ruta"
         Top             =   960
         UseMaskColor    =   -1  'True
         Width           =   360
      End
      Begin VB.TextBox txReparto 
         Height          =   315
         Left            =   960
         MaxLength       =   10
         TabIndex        =   0
         Top             =   600
         Width           =   1215
      End
      Begin VB.Label lbRuta 
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Height          =   315
         Left            =   960
         TabIndex        =   1
         Top             =   960
         UseMnemonic     =   0   'False
         Width           =   1215
      End
      Begin VB.Label lb 
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Tipo precio"
         Height          =   315
         Index           =   2
         Left            =   240
         TabIndex        =   31
         Top             =   1320
         UseMnemonic     =   0   'False
         Width           =   975
      End
      Begin VB.Label lb 
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Reparto"
         Height          =   315
         Index           =   0
         Left            =   240
         MouseIcon       =   "Reparto.frx":30AE
         MousePointer    =   99  'Custom
         TabIndex        =   29
         ToolTipText     =   "Doble click último reparto"
         Top             =   600
         UseMnemonic     =   0   'False
         Width           =   735
      End
      Begin VB.Label lb 
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Ruta"
         Height          =   315
         Index           =   1
         Left            =   240
         TabIndex        =   30
         Top             =   960
         UseMnemonic     =   0   'False
         Width           =   735
      End
      Begin VB.Label lbTítulo 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         Caption         =   "Ochoa"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   315
         Left            =   120
         TabIndex        =   43
         Top             =   240
         UseMnemonic     =   0   'False
         Width           =   3615
      End
   End
   Begin VB.Frame fr 
      Height          =   5655
      Index           =   2
      Left            =   120
      TabIndex        =   47
      Top             =   1800
      Width           =   9735
      Begin VB.TextBox tx 
         Height          =   315
         Index           =   2
         Left            =   8760
         MaxLength       =   10
         TabIndex        =   20
         ToolTipText     =   "Escriba el número del reparto"
         Top             =   4200
         Width           =   855
      End
      Begin VB.TextBox tx 
         Height          =   315
         Index           =   1
         Left            =   8760
         MaxLength       =   10
         TabIndex        =   19
         ToolTipText     =   "Escriba la cantidad de paquetes"
         Top             =   3840
         Width           =   855
      End
      Begin VB.TextBox tx 
         Height          =   315
         Index           =   0
         Left            =   8760
         MaxLength       =   10
         TabIndex        =   18
         ToolTipText     =   "Escriba el número de cajas"
         Top             =   3480
         Width           =   855
      End
      Begin VB.OptionButton obOrden 
         Alignment       =   1  'Right Justify
         Caption         =   "Código"
         Height          =   195
         Index           =   0
         Left            =   2280
         TabIndex        =   15
         Top             =   5280
         Width           =   975
      End
      Begin VB.OptionButton obOrden 
         Alignment       =   1  'Right Justify
         Caption         =   "Descripción"
         Height          =   195
         Index           =   1
         Left            =   3600
         TabIndex        =   16
         Top             =   5280
         Width           =   1215
      End
      Begin VB.TextBox txBuscar 
         Height          =   315
         Left            =   480
         TabIndex        =   14
         Top             =   5160
         Width           =   1575
      End
      Begin MSDBGrid.DBGrid grInventario 
         Bindings        =   "Reparto.frx":3200
         Height          =   1920
         Left            =   240
         OleObjectBlob   =   "Reparto.frx":3234
         TabIndex        =   13
         Top             =   3120
         Width           =   7335
      End
      Begin VB.CommandButton cbSel 
         Caption         =   "Carga"
         Height          =   315
         Left            =   7680
         TabIndex        =   21
         Top             =   5160
         Width           =   1935
      End
      Begin VB.Label lb 
         Alignment       =   2  'Center
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Recarga de"
         Height          =   315
         Index           =   8
         Left            =   7680
         TabIndex        =   37
         Top             =   4200
         Width           =   1095
      End
      Begin VB.Label lbCódigo 
         Alignment       =   2  'Center
         BackColor       =   &H80000018&
         BorderStyle     =   1  'Fixed Single
         DataField       =   "Código"
         DataSource      =   "dtInventario"
         Height          =   315
         Left            =   7695
         TabIndex        =   17
         Top             =   3120
         Width           =   1935
      End
      Begin VB.Label lb 
         Alignment       =   2  'Center
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Cantidad"
         Height          =   315
         Index           =   7
         Left            =   7680
         TabIndex        =   36
         Top             =   3840
         Width           =   1095
      End
      Begin VB.Label lb 
         Alignment       =   2  'Center
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Cajas"
         Height          =   315
         Index           =   6
         Left            =   7680
         TabIndex        =   35
         Top             =   3480
         Width           =   1095
      End
   End
   Begin VB.Frame fr 
      Height          =   7695
      Index           =   3
      Left            =   9960
      TabIndex        =   48
      Top             =   1800
      Width           =   1815
      Begin VB.TextBox txSuma 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00E0E0E0&
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   315
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   24
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton cbSalir 
         Caption         =   "Salir"
         Height          =   315
         Left            =   360
         TabIndex        =   28
         Top             =   7080
         Width           =   1095
      End
      Begin VB.CommandButton cbInicio 
         Caption         =   "Inicio"
         Height          =   315
         Left            =   360
         TabIndex        =   26
         Top             =   4560
         Width           =   1095
      End
      Begin VB.CommandButton cbRegistrar 
         BackColor       =   &H00C0C0FF&
         Caption         =   "Registrar"
         Height          =   315
         Left            =   360
         Style           =   1  'Graphical
         TabIndex        =   27
         Top             =   5160
         Width           =   1095
      End
      Begin VB.CommandButton cbBorrar 
         Caption         =   "Borrar carga"
         Height          =   555
         Left            =   240
         TabIndex        =   25
         ToolTipText     =   "Borrar la fila seleccionada"
         Top             =   2400
         Width           =   1335
      End
      Begin VB.ListBox lsDetalle 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   540
         ItemData        =   "Reparto.frx":410B
         Left            =   240
         List            =   "Reparto.frx":4115
         TabIndex        =   23
         Top             =   360
         Width           =   1335
      End
      Begin VB.Label lb 
         Alignment       =   2  'Center
         BackColor       =   &H00FFFFC0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Suma de piezas"
         Height          =   315
         Index           =   9
         Left            =   240
         TabIndex        =   38
         Top             =   1080
         UseMnemonic     =   0   'False
         Width           =   1335
      End
      Begin VB.Label lbConsulta 
         Alignment       =   2  'Center
         Caption         =   "Sólo para consulta, oprima el botón ""Inicio"" para continuar"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   885
         Left            =   120
         TabIndex        =   44
         Top             =   3120
         Visible         =   0   'False
         Width           =   1575
      End
   End
   Begin VB.Frame fr 
      Height          =   2055
      Index           =   4
      Left            =   120
      TabIndex        =   49
      Top             =   7440
      Width           =   9735
      Begin MSDBGrid.DBGrid grCajas 
         Bindings        =   "Reparto.frx":412C
         Height          =   1920
         Left            =   0
         OleObjectBlob   =   "Reparto.frx":415C
         TabIndex        =   22
         Top             =   105
         Width           =   4935
      End
   End
End
Attribute VB_Name = "fmReparto"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim Db As Database
Dim kEnt As String   ' Entero para el inventario
Dim Comision As Currency
' Rev. 02/feb/09 DOA3.6
' Rev. 25/jun/09 cbBorrar sin clave de acceso
' Rev. 10/jun/12 Agregar "Créditos" por paquetes / lsDetalle / Nuevo esquema
' Rev. 11/jun/12 Tipo de precio fijo
' Rev. 15/jul/12 Sólo para Carga
' Rev. 29/jul/12 Leer sobrante del reparto anterior de la ruta
' Rev. 23/ago/12 Cargas y DetalleReparto por separado
' Rev. 31/ago/13 cbRegistrar
' Rev. 08/sep/13 No leer sobrante ni DetalleReparto (Eliminar RsDet)
' Rev. 21/oct/13 Suma de cargas en cbRegistrar
' Rev. 24/feb/16 Comisión por ruta
' Rev. 07/abr/16 Control de cajas / Pantalla 1024 x 768
' Rev. 27/mar/18 Copiar cajas en ActualizarDatos
' Rev. 02/ago/18 Agregar suma de piezas
' Rev. 16/ago/18 Ocultar columna de cajas programa NATS / Entero para el inventario
' Rev. 20/ago/18 Agregar Sub SumaPzas
' Rev. 25/ago/18 Agregar MsgBox "Artículo no encontrado." en txBuscar
' 23/sep/19 Actualizar almacén usando la fecha del reparto
' 02/mar/20 Agregar precio para importe de venta preliminar en cbRegistrar

Private Sub Form_Load()
On Error GoTo ConError
LeerTP coTP
' Sin crédito
If PorCrédito > 0 Then coTP.RemoveItem coTP.ListCount - 1
' Ocultar columna de cajas
If Programa = "NATS" Then
   grCarga.Columns("Cajas").AllowSizing = False
   grCarga.Columns("Cajas").Visible = False
   grInventario.Columns("Cajas").AllowSizing = False
   grInventario.Columns("Cajas").Visible = False
   grInventario.Columns("Descripción").Width = grInventario.Columns("Descripción").Width + 600
   tx(0).Visible = False
   lb(6).Visible = False
End If
' Abrir base de datos
Set Db = OpenDatabase(Ruta & Archivo, False, False, MiPWD)
' Revisar stock entero
If BuscarCampo(Db.TableDefs("Inventario"), "Entero") Then
   ' Para consulta
   kEnt = "Entero, "
   Else
   ' No hay stock entero
   kEnt = "False as Entero, "
End If
Inicio
lbTítulo = Título
If fmPrincipal.mnAyuda.Checked Then
   fmAyuda.Tag = Me.Tag
   fmAyuda.SumarListAyuda
End If
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub Inicio()
Dim Qry As String
On Error GoTo ConError
txReparto = UltNo("Repartos") + 1
' Habilitar inicio
HabilitarDatos False
cbEliminar.Enabled = False
lbConsulta.Visible = False
' Mostrar Reparto vacío
Qry = "SELECT * FROM Repartos WHERE Reparto = 0"
Set dtReparto.Recordset = Db.OpenRecordset(Qry)
Set dtCarga.Recordset = Db.OpenRecordset(Qry)
Set dtCajas.Recordset = Db.OpenRecordset(Qry)
' Limpiar inventario
obOrden(OrdenInv).Value = False
' Limpiar datos
lbRuta = ""
coTP.ListIndex = -1
lsDetalle.ListIndex = -1
txSuma = ""
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub HabilitarDatos(V As Boolean)
Dim x As Integer
' Modo
fr(0).Enabled = Not V
cbBuscar(0).Enabled = Not V
coTP.Enabled = Not V
cbLeer.Default = Not V
cbLeer.Enabled = Not V
' Datos del Reparto
fr(1).Enabled = V
cbBuscar(1).Enabled = V
cbBuscar(2).Enabled = V
For x = 3 To lb.UBound
   lb(x).Enabled = V
Next x
' Detalle del Reparto
grCarga.AllowUpdate = V
cbBorrar.Enabled = V
lsDetalle.Enabled = V
' Inventario
fr(2).Enabled = V
obOrden(0).Enabled = V
obOrden(1).Enabled = V
lbCódigo.Enabled = V
cbSel.Enabled = V
' Control de cajas
fr(4).Enabled = V
' Botones
cbInicio.Enabled = V
cbRegistrar.Enabled = V
End Sub

Private Sub cbBuscar_Click(Index As Integer)
On Error GoTo ConError
Select Case Index
   Case 0   ' Rutas
   fmBuscar.Tag = "Rutas"
   fmBuscar.Show 1
   If fmBuscar.Tag <> "" Then
      lbRuta = fmBuscar.Tag
      ' Datos de la ruta
      coTP.ListIndex = fmBuscar.dtBuscar.Recordset("TP")
      lbRepartidor.Tag = fmBuscar.dtBuscar.Recordset("Repartidor")
      lbEco.Tag = fmBuscar.dtBuscar.Recordset("Eco")
      Comision = fmBuscar.dtBuscar.Recordset("Comision")
   End If
   Case 1   ' Repartidor
   If Bajas = 0 Then
      fmBuscar.Tag = "Empleados WHERE IsNull(Baja) "
      Else
      fmBuscar.Tag = "Empleados"
   End If
   fmBuscar.Show 1
   If fmBuscar.Tag <> "" Then
      lbRepartidor = fmBuscar.Tag
      dtReparto.UpdateRecord
   End If
   Case 2   ' Equipos
   fmBuscar.Tag = "Equipos"
   fmBuscar.Show 1
   If fmBuscar.Tag <> "" Then
      lbEco = fmBuscar.Tag
      dtReparto.UpdateRecord
   End If
End Select
Unload fmBuscar
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub coTP_Click()
coTP.BackColor = Choose(coTP.ListIndex + 2, &HC0C0FF, &HC0E0FF, &HC0FFFF, &HFFFFFF, &HFFC0FF)
coTP.Tag = Choose(coTP.ListIndex + 2, "Costo", "Bajo", "Medio", "Normal")
End Sub

Private Sub cbLeer_Click()
Dim Qry As String
On Error GoTo ConError
' Revisar No. de Reparto
txReparto = Val(txReparto)
If txReparto = "0" Then Exit Sub
Qry = "SELECT Repartos.*, Detalle, Format(Fecha, 'dddd') AS FechaDía, Empleados.Nombre, " & _
      "Equipos.Nombre AS NombreE, Comision FROM Rutas INNER JOIN (Empleados INNER JOIN " & _
      "(Repartos INNER JOIN Equipos ON Repartos.Eco = Equipos.Eco) ON Empleados.Número = " & _
      "Repartos.Repartidor) ON Rutas.Ruta = Repartos.Ruta WHERE Reparto = " & txReparto
Set dtReparto.Recordset = Db.OpenRecordset(Qry)
If dtReparto.Recordset.AbsolutePosition < 0 Then
   ' Revisar Ruta
   If lbRuta = "" Then
      MsgBox "Falta seleccionar la ruta del reparto.", 64, Título
      cbBuscar(0).SetFocus
      Exit Sub
   End If
   ' Revisar TP
   If coTP.ListIndex < 0 Then
      MsgBox "Falta el tipo de precio.", 64, Título
      coTP.SetFocus
      Exit Sub
   End If
   ' Abrir nuevo Reparto
   With dtReparto.Recordset
      .AddNew
      .fields("Reparto") = txReparto
      .fields("Ruta") = lbRuta
      .fields("Repartidor") = lbRepartidor.Tag
      .fields("Eco") = lbEco.Tag
      .fields("Fecha") = IIf(lbFecha.Tag = "", Date, lbFecha.Tag)
      .fields("ComisionP") = Comision
      .fields("TPR") = coTP.ListIndex
      .Update
      .Bookmark = .LastModified
   End With
   ' Borrar sólo cuando es nuevo
   cbEliminar.Enabled = True
   Else
   ' Editar Reparto
   lbRuta = dtReparto.Recordset("Ruta")
   coTP.ListIndex = dtReparto.Recordset("TPR")
End If
If lbHora = "" Then
   ' Habilitar datos
   HabilitarDatos True
   grCarga.AllowUpdate = True
   ' Ordenar inventario
   obOrden(OrdenInv).Value = True
   Else
   ' Consulta
   fr(0).Enabled = False
   cbLeer.Default = False
   cbLeer.Enabled = False
   cbBuscar(0).Enabled = False
   lbConsulta.Visible = True
   grCarga.AllowUpdate = False
   lsDetalle.Enabled = True
   cbInicio.Enabled = True
   cbInicio.SetFocus
End If
' Datos del reparto
lbFecha = Format(lbFecha, "dd/mmm/yyyy")
lbFecha.DataChanged = False
lsDetalle.ListIndex = 0
SumaPzas
' Control de cajas
Qry = "SELECT ControlCajas.*, Detalle, Precio FROM ControlCajas INNER JOIN Cajas " & _
      "ON ControlCajas.NoCaja = Cajas.NoCaja WHERE Reparto = " & txReparto & _
      " ORDER BY Cajas.NoCaja"
Set dtCajas.Recordset = Db.OpenRecordset(Qry)
' Control de cajas
If dtCajas.Recordset.RecordCount = 0 Then
   Qry = "INSERT INTO ControlCajas SELECT Reparto, Inventario.NoCaja, Sum(Cantidad / Caja) AS Carga, Precio AS PrecioR " & _
         "FROM Cargas INNER JOIN (Inventario INNER JOIN Cajas ON Inventario.NoCaja = Cajas.NoCaja) " & _
         "ON Cargas.Código = Inventario.Código WHERE Reparto = " & txReparto & _
         " GROUP BY Reparto, Inventario.NoCaja, Precio ORDER BY Inventario.NoCaja"
   Db.Execute Qry
   dtCajas.Recordset.Requery
End If
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub lsDetalle_Click()
Dim Qry As String
On Error GoTo ConError
If lsDetalle.ListIndex < 0 Then Exit Sub
' Seleccionar grCarga
If lsDetalle.ListIndex = 0 Then
   ' Carga
   Qry = "AND RecargaDe = 0 "
   grCarga.Columns("RecargaDe").Visible = False
   tx(2) = ""
   tx(2).Locked = True
   lb(8).Enabled = False
   Else
   ' Recarga De
   Qry = "AND RecargaDe > 0 "
   grCarga.Columns("RecargaDe").Visible = True
   tx(2).Locked = False
   lb(8).Enabled = True
End If
' Nombre de los botones
cbSel.Caption = lsDetalle.Text
grCarga.Caption = UCase(lsDetalle.Text)
cbBorrar.Caption = "Borrar " & lsDetalle.Text
' Abrir base de datos detalle del Reparto
Qry = "SELECT Cargas.*, Format(Cantidad / Caja, '0.00') AS Cajas, Caja, NoCaja, " & kEnt & _
      "Descripción FROM Cargas INNER JOIN Inventario ON Cargas.Código = Inventario.Código " & _
      "WHERE Reparto = " & txReparto & " " & Qry & "ORDER BY FilaC"
Set dtCarga.Recordset = Db.OpenRecordset(Qry)
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub cbEliminar_Click()
Dim x As Integer
On Error GoTo ConError
txBuscar.SetFocus
x = MsgBox("Desea eliminar el Reparto " & txReparto & "?", 276, Título)
If x = vbNo Then Exit Sub
' Borrar
dtReparto.Recordset.Delete
cbInicio.Value = True
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub lbFecha_DblClick()
Dim Cal As New fmCalendario
Dim y As String
' Revisar clave
fmCandado.Show 1
y = fmCandado.txClave
Unload fmCandado
If y <> "ARCHIVO" Then
   MsgBox "La clave de acceso no es correcta.", 64, Título
   Exit Sub
End If
Cal.lbFecha = lbFecha
Cal.Show 1
If Cal.lbFecha <> "" Then
   lbFecha = Cal.lbFecha
   dtReparto.UpdateRecord
End If
Unload Cal
End Sub

Private Sub obOrden_Click(Index As Integer)
Dim Qry As String
Dim y As String
On Error GoTo ConError
' Código
y = grInventario.Columns("Código")
' Buscar por
txBuscar.Tag = obOrden(Index).Caption
txBuscar.ToolTipText = "Buscar por " & txBuscar.Tag
OrdenInv = Index
' Abrir base de datos del inventario
Qry = "SELECT Format(Stock / Caja, '0.00') AS Cajas, Caja, Stock, Código, Descripción, " & kEnt & _
      coTP.Tag & " AS Precio, bIVA FROM Inventario WHERE Uso = 1 AND Código = ClaveA " & _
      "AND Línea AND Fila > 0 ORDER BY Fila"
Set dtInventario.Recordset = Db.OpenRecordset(Qry)
' Regresar código
If (dtInventario.Recordset.RecordCount > 0) And (y <> "") Then
   dtInventario.Recordset.FindFirst "Código = '" & y & "'"
End If
If txBuscar.Enabled Then
   txBuscar.SelStart = 0
   txBuscar.SelLength = Len(txBuscar)
   txBuscar.SetFocus
End If
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub txBuscar_Change()
Dim Bm
On Error GoTo ConError
If txBuscar = "" Then Exit Sub
' Buscar artículo
With dtInventario.Recordset
   If .RecordCount < 2 Then Exit Sub
   Bm = .Bookmark
   .FindFirst txBuscar.Tag & " Like '" & txBuscar & "*'"
   If .NoMatch Then .Bookmark = Bm: Beep
End With
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub txBuscar_KeyPress(KeyAscii As Integer)
On Error GoTo ConError
If txBuscar = "" Then Exit Sub
If KeyAscii = 13 Then
   ' El * indica búsqueda manual
   If Left(txBuscar, 1) = "*" Then
      cbSel.Value = True
      Else
      ' Revisar código
      dtInventario.Recordset.FindFirst "Código = '" & txBuscar & "'"
      If dtInventario.Recordset.NoMatch Then
         MsgBox "Artículo no encontrado.", 64, Título
         txBuscar = ""
         Else
         cbSel.Value = True
      End If
   End If
   KeyAscii = 0
End If
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub grInventario_Click()
tx(1).SetFocus
End Sub

Private Sub cbSel_Click()
Dim Rs As Recordset
Dim P As Long
Dim Qry As String
Dim y As String
On Error GoTo ConError
txBuscar.SetFocus
If dtInventario.Recordset.AbsolutePosition < 0 Then Exit Sub
' Cajas a empaques
If Val(tx(0)) > 0 Then
   tx(1) = dtInventario.Recordset("Caja") * Val(tx(0))
   Else
   ' Revisar cantidad
   tx(1) = Val(tx(1))
   If tx(1) = "0" Then tx(1) = "1"
End If
' Revisar entero
If dtInventario.Recordset("Entero") Then tx(1) = Int(tx(1))
' Buscar reparto
P = 0
If lsDetalle.ListIndex = 1 Then
   ' Revisar reparto
   If Val(tx(2)) = 0 Then
      ' Seleccionar ruta
      fmBuscar.Tag = "Rutas"
      fmBuscar.Show 1
      ' La ruta debe de ser diferente a la ruta actual
      If (fmBuscar.Tag = "") Or (fmBuscar.Tag = lbRuta) Then Exit Sub
      y = fmBuscar.Tag
      Unload fmBuscar
      ' Buscar reparto por día
      Qry = "SELECT Reparto FROM Repartos WHERE Ruta = '" & y & _
            "' AND Fecha = #" & Format(lbFecha, "mm/dd/yyyy") & "#"
      Set Rs = Db.OpenRecordset(Qry)
      If Rs.AbsolutePosition = 0 Then
         P = Rs(0)
         Rs.Close
         Else
         Rs.Close
         MsgBox "No se encontró ningún reparto para la ruta " & y & ".", 64, Título
         Exit Sub
      End If
      Else
      ' Reparto solicitado, revisar
      P = Val(tx(2))
      If RecargaDe(P) = False Then Exit Sub
   End If
End If
' Seleccionar
With dtCarga.Recordset
   .AddNew
   .fields("Reparto") = txReparto
   .fields("Cantidad") = tx(1)
   .fields("Código") = lbCódigo
   .fields("RecargaDe") = P
   .fields("FilaC") = .RecordCount
   .Update
   .Bookmark = .LastModified
   SumaPzas
   ' Cajas
   If Not IsNull(.fields("NoCaja")) Then
      dtCajas.Recordset.FindFirst "NoCaja = " & .fields("NoCaja")
      If dtCajas.Recordset.NoMatch Then
         ' Agregar caja
         dtCajas.Recordset.AddNew
         dtCajas.Recordset("Reparto") = txReparto
         dtCajas.Recordset("NoCaja") = .fields("NoCaja")
         dtCajas.Recordset("Carga") = .fields("Cajas")
         dtCajas.Recordset("PrecioR") = dtCajas.Recordset("Precio")
         dtCajas.Recordset.Update
         dtCajas.Recordset.Bookmark = dtCajas.Recordset.LastModified
      End If
      ' Sumar cajas
      SumaCajas .fields("NoCaja")
   End If
End With
' Limpiar
txBuscar = ""
tx(0) = ""
tx(1) = ""
tx(2) = ""
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Function RecargaDe(NRep As Long) As Boolean
Dim Rs As Recordset
Dim Qry As String
On Error GoTo ConError
' El reparto debe ser mayor de cero y diferente al reparto actual
If (NRep = 0) Or (NRep = Val(txReparto)) Then Exit Function
' Buscar reparto por fecha
Qry = "SELECT Reparto FROM Repartos WHERE Reparto = " & CStr(NRep) & _
      " AND Fecha = #" & Format(lbFecha, "mm/dd/yyyy") & "#"
Set Rs = Db.OpenRecordset(Qry)
If Rs.AbsolutePosition = 0 Then
   RecargaDe = True
   Else
   MsgBox "No se encontró ningún reparto para esta fecha.", 64, Título
End If
Rs.Close
Exit Function
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Function

Private Sub cbBorrar_Click()
Dim x As Integer
Dim y As Variant
On Error GoTo ConError
grCarga.SetFocus
If dtCarga.Recordset.AbsolutePosition < 0 Then Exit Sub
' Revisar candado
'If (Candado = 1) And (Clave <> "") Then
'   fmCandado.Show 1
'   Qry = fmCandado.txClave
'   Unload fmCandado
'   If Qry <> Clave Then
'      MsgBox "La clave de acceso no es correcta", 64, Título
'      Exit Sub
'   End If
'End If
' Confirmación
x = MsgBox("¿Desea borrar la fila seleccionada de " & cbSel.Caption & "?", 276, Título)
If x = vbNo Then Exit Sub
' Guardar NoCaja
y = dtCarga.Recordset("NoCaja")
' Borrar fila
With dtCarga.Recordset
   .Delete
   .MoveNext
   If .EOF And .RecordCount > 0 Then .MoveLast
End With
' Actualizar sumas
SumaPzas
SumaCajas y
' Limpiar
txBuscar = ""
tx(0) = ""
tx(1) = ""
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub grCarga_BeforeColUpdate(ByVal ColIndex As Integer, OldValue As Variant, Cancel As Integer)
On Error GoTo ConError
Select Case ColIndex
   Case 0   ' Cajas
   grCarga.Text = Val(grCarga.Text)
   Cancel = 1
   dtCarga.Recordset.Edit
   dtCarga.Recordset("Cantidad") = Val(grCarga.Text) * dtCarga.Recordset("Caja")
   dtCarga.Recordset.Update
   SumaPzas
   SumaCajas dtCarga.Recordset("NoCaja")
   Case 1   ' Cantidad
   grCarga.Text = Val(grCarga.Text)
   ' Revisar cantidad con valor entero
   If dtCarga.Recordset("Entero") Then grCarga.Text = Int(grCarga.Text)
   Case 4   ' Revisar reparto
   grCarga.Text = Val(grCarga.Text)
   If RecargaDe(Val(grCarga.Text)) = False Then
      grCarga.Text = OldValue
      Beep
   End If
End Select
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub grCarga_AfterColUpdate(ByVal ColIndex As Integer)
On Error GoTo ConError
dtCarga.UpdateRecord
SumaPzas
SumaCajas dtCarga.Recordset("NoCaja")
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub SumaPzas()
Dim Rs As Recordset
Dim Qry As String
On Error GoTo ConError
' Suma de piezas
If dtCarga.Recordset.RecordCount > 0 Then
   Qry = "SELECT Sum(Cantidad) AS S0 FROM Cargas WHERE Reparto = " & txReparto
   Set Rs = Db.OpenRecordset(Qry)
   txSuma = Rs(0) & ""
   Rs.Close
   Else
   txSuma = ""
End If
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub SumaCajas(NoCaja As Variant)
Dim Rs As Recordset
Dim S As Currency
Dim Qry As String
On Error GoTo ConError
If IsNull(NoCaja) Then Exit Sub
If dtCajas.Recordset.RecordCount = 0 Then Exit Sub
' Suma de cajas
If dtCarga.Recordset.RecordCount > 0 Then
   Qry = "SELECT Sum(Cantidad / Caja) AS Cajas FROM Cargas INNER JOIN Inventario " & _
         "ON Cargas.Código = Inventario.Código WHERE Reparto = " & txReparto & _
         " AND NoCaja = " & NoCaja & " GROUP BY NoCaja"
   Set Rs = Db.OpenRecordset(Qry)
   If Rs.AbsolutePosition = 0 Then S = Rs(0)
   Rs.Close
End If
' Actualizar cajas
dtCajas.Recordset.FindFirst "NoCaja = " & NoCaja
If dtCajas.Recordset.NoMatch = False Then
   If S = 0 Then
      ' Borrar caja
      dtCajas.Recordset.Delete
      dtCajas.Recordset.MoveNext
      Else
      ' Actualizar caja
      dtCajas.Recordset.Edit
      dtCajas.Recordset("Carga") = S
      dtCajas.Recordset.Update
   End If
End If
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub grCajas_BeforeColUpdate(ByVal ColIndex As Integer, OldValue As Variant, Cancel As Integer)
' Datos numéricos
grCajas.Text = Val(grCajas.Text)
End Sub

Private Sub grCajas_AfterColUpdate(ByVal ColIndex As Integer)
On Error GoTo ConError
dtCajas.UpdateRecord
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub cbInicio_Click()
' Gurdar para el siguiente reparto
lbFecha.Tag = IIf(lbConsulta.Visible, "", lbFecha)
Inicio
txReparto.SelStart = 0
txReparto.SelLength = 10
txReparto.SetFocus
End Sub

Private Sub cbRegistrar_Click()
Dim RsD As Recordset, RsC As Recordset
Dim S As Currency
Dim Qry As String
Dim x As Integer
On Error GoTo ConError
If dtCarga.Recordset.RecordCount = 0 Then Exit Sub
' Confirmar
x = MsgBox("¿Registrar las cargas del reparto " & txReparto & "?" & vbCr & _
    "Ya no podrá modificarse.", 292, Título)
If x = vbNo Then Exit Sub
' Leer detalle primero
Qry = "SELECT * FROM DetalleReparto WHERE Reparto = " & txReparto
Set RsD = Db.OpenRecordset(Qry)
' Limpiar cargas por seguridad
Do Until RsD.EOF
   RsD.Edit
   RsD("Carga") = 0
   RsD.Update
   RsD.MoveNext
Loop
' Precio según coTP
Qry = PrecioBD(coTP.ListIndex)
' Suma de cargas, precio para importe de venta preliminar
Qry = "SELECT Cargas.Código, Sum(Cantidad) AS Cargas, " & Qry & " AS Precio FROM Cargas INNER JOIN Inventario " & _
      "ON Cargas.Código = Inventario.Código WHERE Reparto = " & txReparto & _
      " AND RecargaDe = 0 GROUP BY Cargas.Código, " & Qry
Set RsC = Db.OpenRecordset(Qry)
' Actualizar cargas
Do Until RsC.EOF
   RsD.FindFirst "Código = '" & RsC("Código") & "'"
   If RsD.NoMatch Then
      ' Nuevo código
      RsD.AddNew
      RsD("Reparto") = txReparto
      RsD("Código") = RsC("Código")
      Else
      ' Editar
      RsD.Edit
   End If
   RsD("Carga") = RsC("Cargas")
   RsD("Precio") = RsC("Precio")
   RsD.Update
   ' Suma
   S = S + RsC("Cargas") * RsC("Precio")
   ' Siguiente dato
   RsC.MoveNext
Loop
' Importe de la venta preliminar
' Acutalizar el inventario Carga
Qry = "UPDATE Inventario INNER JOIN DetalleReparto ON Inventario.Código = " & _
      "DetalleReparto.Código SET Stock = Stock - Carga WHERE Reparto = " & txReparto & _
      " AND Carga > 0"
Db.Execute Qry
' Actualizar almacén usando la fecha del reparto
Qry = "INSERT INTO Almacén (Cantidad, Código, Detalle, Costo, Fecha, Usuario) " & _
      "SELECT - Carga, Inventario.Código, 'Reparto " & txReparto & "', Costo, '" & _
      lbFecha & "', '" & lbRepartidor & "' FROM DetalleReparto INNER JOIN Inventario " & _
      "ON DetalleReparto.Código = Inventario.Código WHERE Reparto = " & txReparto & _
      " AND Carga > 0"
Db.Execute Qry
' Actualizar datos
dtReparto.Recordset.Edit
dtReparto.Recordset("VentaEfectivo") = S
dtReparto.Recordset("Hora") = Now
dtReparto.Recordset.Update
Inicio
Exit Sub
ConError:
MsgBox "El reporte de venta no fué registrado correctamente." & vbCr & Err.Description, 16, Título
Err.Clear
Inicio
End Sub

Private Sub txReparto_KeyPress(KeyAscii As Integer)
If KeyAscii = 8 Then Exit Sub
If KeyAscii < 48 Or KeyAscii > 57 Then KeyAscii = 0
End Sub

Private Sub lb_DblClick(Index As Integer)
Select Case Index
   Case 0
   txReparto = UltNo("Repartos") + 1
End Select
End Sub

Private Sub tx_KeyPress(Index As Integer, KeyAscii As Integer)
If KeyAscii = 8 Then Exit Sub
If KeyAscii = 13 Then
   If Val(tx(Index)) > 0 Then cbSel.Value = True
   KeyAscii = 0
   Exit Sub
End If
If (KeyAscii = 46) And (InStr(tx(0), ".") = 0) Then Exit Sub
If KeyAscii < 48 Or KeyAscii > 57 Then KeyAscii = 0
End Sub

Public Sub Copiar()
On Error Resume Next
Select Case Me.ActiveControl.Name
   Case "grCajas"
   CopiarDatos grCajas, dtCajas.Recordset
   Case Else
   CopiarDatos grCarga, dtCarga.Recordset
End Select
End Sub

Public Sub Imprimir()
On Error GoTo ConError
'If dtCarga.Recordset.RecordCount = 0 Then Exit Sub

ImpOn = False
Exit Sub
ConError:
MsgBox Err.Description, 16, Título
Err.Clear
End Sub

Private Sub cbSalir_Click()
Unload Me
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
Db.Close
End Sub

