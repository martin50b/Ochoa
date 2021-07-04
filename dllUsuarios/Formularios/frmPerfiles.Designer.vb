<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPerfiles
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfiles))
        Me.bmaPerfiles = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barToolBar = New DevExpress.XtraBars.Bar()
        Me.bbiNuevo = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiActualizar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCerrar = New DevExpress.XtraBars.BarButtonItem()
        Me.barStatusBar = New DevExpress.XtraBars.Bar()
        Me.bsiContador = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiContador1 = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.grvPerfiles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcoDescripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcoIdPerfil = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcoPerfil = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcoAsignados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grcPerfiles = New DevExpress.XtraGrid.GridControl()
        CType(Me.bmaPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grcPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bmaPerfiles
        '
        Me.bmaPerfiles.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barToolBar, Me.barStatusBar})
        Me.bmaPerfiles.DockControls.Add(Me.barDockControlTop)
        Me.bmaPerfiles.DockControls.Add(Me.barDockControlBottom)
        Me.bmaPerfiles.DockControls.Add(Me.barDockControlLeft)
        Me.bmaPerfiles.DockControls.Add(Me.barDockControlRight)
        Me.bmaPerfiles.Form = Me
        Me.bmaPerfiles.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiNuevo, Me.bbiEditar, Me.bbiEliminar, Me.bbiCerrar, Me.bsiContador, Me.bsiContador1, Me.bbiActualizar})
        Me.bmaPerfiles.MaxItemId = 7
        Me.bmaPerfiles.StatusBar = Me.barStatusBar
        '
        'barToolBar
        '
        Me.barToolBar.BarName = "Herramientas"
        Me.barToolBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.barToolBar.DockCol = 0
        Me.barToolBar.DockRow = 0
        Me.barToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiNuevo), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiActualizar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiCerrar, True)})
        Me.barToolBar.OptionsBar.AllowQuickCustomization = False
        Me.barToolBar.OptionsBar.DisableClose = True
        Me.barToolBar.OptionsBar.DisableCustomization = True
        Me.barToolBar.OptionsBar.DrawBorder = False
        Me.barToolBar.Text = "Herramientas"
        '
        'bbiNuevo
        '
        Me.bbiNuevo.Caption = "Nuevo"
        Me.bbiNuevo.Id = 0
        Me.bbiNuevo.ImageOptions.Image = CType(resources.GetObject("bbiNuevo.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiNuevo.ImageOptions.LargeImage = CType(resources.GetObject("bbiNuevo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiNuevo.Name = "bbiNuevo"
        Me.bbiNuevo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiEditar
        '
        Me.bbiEditar.Caption = "Editar"
        Me.bbiEditar.Id = 1
        Me.bbiEditar.ImageOptions.Image = CType(resources.GetObject("bbiEditar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiEditar.ImageOptions.LargeImage = CType(resources.GetObject("bbiEditar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiEditar.Name = "bbiEditar"
        Me.bbiEditar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiEliminar
        '
        Me.bbiEliminar.Caption = "Eliminar"
        Me.bbiEliminar.Id = 2
        Me.bbiEliminar.ImageOptions.Image = CType(resources.GetObject("bbiEliminar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiEliminar.ImageOptions.LargeImage = CType(resources.GetObject("bbiEliminar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiEliminar.Name = "bbiEliminar"
        Me.bbiEliminar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiActualizar
        '
        Me.bbiActualizar.Caption = "Actualizar"
        Me.bbiActualizar.Id = 6
        Me.bbiActualizar.ImageOptions.Image = CType(resources.GetObject("bbiActualizar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiActualizar.ImageOptions.LargeImage = CType(resources.GetObject("bbiActualizar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiActualizar.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5)
        Me.bbiActualizar.Name = "bbiActualizar"
        Me.bbiActualizar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.bbiActualizar.ShortcutKeyDisplayString = "F5"
        '
        'bbiCerrar
        '
        Me.bbiCerrar.Caption = "Cerrar"
        Me.bbiCerrar.Id = 3
        Me.bbiCerrar.ImageOptions.Image = CType(resources.GetObject("bbiCerrar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiCerrar.ImageOptions.LargeImage = CType(resources.GetObject("bbiCerrar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiCerrar.Name = "bbiCerrar"
        Me.bbiCerrar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'barStatusBar
        '
        Me.barStatusBar.BarName = "Barra de estado"
        Me.barStatusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.barStatusBar.DockCol = 0
        Me.barStatusBar.DockRow = 0
        Me.barStatusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.barStatusBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bsiContador), New DevExpress.XtraBars.LinkPersistInfo(Me.bsiContador1)})
        Me.barStatusBar.OptionsBar.AllowQuickCustomization = False
        Me.barStatusBar.OptionsBar.DrawDragBorder = False
        Me.barStatusBar.OptionsBar.UseWholeRow = True
        Me.barStatusBar.Text = "Barra de estado"
        '
        'bsiContador
        '
        Me.bsiContador.Caption = "Perfiles:"
        Me.bsiContador.Id = 4
        Me.bsiContador.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bsiContador.ItemAppearance.Normal.Options.UseFont = True
        Me.bsiContador.Name = "bsiContador"
        '
        'bsiContador1
        '
        Me.bsiContador1.Caption = "0"
        Me.bsiContador1.Id = 5
        Me.bsiContador1.Name = "bsiContador1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.bmaPerfiles
        Me.barDockControlTop.Size = New System.Drawing.Size(998, 32)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 506)
        Me.barDockControlBottom.Manager = Me.bmaPerfiles
        Me.barDockControlBottom.Size = New System.Drawing.Size(998, 22)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 32)
        Me.barDockControlLeft.Manager = Me.bmaPerfiles
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 474)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(998, 32)
        Me.barDockControlRight.Manager = Me.bmaPerfiles
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 474)
        '
        'grvPerfiles
        '
        Me.grvPerfiles.AutoFillColumn = Me.gcoDescripcion
        Me.grvPerfiles.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcoIdPerfil, Me.gcoPerfil, Me.gcoDescripcion, Me.gcoAsignados})
        Me.grvPerfiles.GridControl = Me.grcPerfiles
        Me.grvPerfiles.Name = "grvPerfiles"
        Me.grvPerfiles.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        '
        'gcoDescripcion
        '
        Me.gcoDescripcion.Caption = "Descripción"
        Me.gcoDescripcion.FieldName = "Descripcion"
        Me.gcoDescripcion.Name = "gcoDescripcion"
        Me.gcoDescripcion.OptionsColumn.AllowEdit = False
        Me.gcoDescripcion.Visible = True
        Me.gcoDescripcion.VisibleIndex = 1
        '
        'gcoIdPerfil
        '
        Me.gcoIdPerfil.Caption = "Id Perfil"
        Me.gcoIdPerfil.FieldName = "idPerfil"
        Me.gcoIdPerfil.Name = "gcoIdPerfil"
        Me.gcoIdPerfil.OptionsColumn.AllowEdit = False
        '
        'gcoPerfil
        '
        Me.gcoPerfil.Caption = "Perfil"
        Me.gcoPerfil.FieldName = "Perfil"
        Me.gcoPerfil.Name = "gcoPerfil"
        Me.gcoPerfil.OptionsColumn.AllowEdit = False
        Me.gcoPerfil.Visible = True
        Me.gcoPerfil.VisibleIndex = 0
        '
        'gcoAsignados
        '
        Me.gcoAsignados.Caption = "Usuarios asignados"
        Me.gcoAsignados.FieldName = "UsuariosAsignados"
        Me.gcoAsignados.Name = "gcoAsignados"
        Me.gcoAsignados.Visible = True
        Me.gcoAsignados.VisibleIndex = 2
        '
        'grcPerfiles
        '
        Me.grcPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grcPerfiles.Location = New System.Drawing.Point(0, 32)
        Me.grcPerfiles.MainView = Me.grvPerfiles
        Me.grcPerfiles.MenuManager = Me.bmaPerfiles
        Me.grcPerfiles.Name = "grcPerfiles"
        Me.grcPerfiles.Size = New System.Drawing.Size(998, 474)
        Me.grcPerfiles.TabIndex = 4
        Me.grcPerfiles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPerfiles})
        '
        'frmPerfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 528)
        Me.Controls.Add(Me.grcPerfiles)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Image = CType(resources.GetObject("frmPerfiles.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "frmPerfiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Perfiles"
        CType(Me.bmaPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grcPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bmaPerfiles As DevExpress.XtraBars.BarManager
    Friend WithEvents barToolBar As DevExpress.XtraBars.Bar
    Friend WithEvents barStatusBar As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbiNuevo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCerrar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grcPerfiles As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvPerfiles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcoDescripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcoIdPerfil As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcoPerfil As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcoAsignados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bsiContador As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiContador1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bbiActualizar As DevExpress.XtraBars.BarButtonItem
End Class
