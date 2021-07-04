<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoPerfil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoPerfil))
        Me.trvPerfiles = New System.Windows.Forms.TreeView()
        Me.gpcModulos = New DevExpress.XtraEditors.GroupControl()
        Me.gpcPerfil = New DevExpress.XtraEditors.GroupControl()
        Me.txtDescripcion = New DevExpress.XtraEditors.MemoEdit()
        Me.bmaPerfil = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barToolBar = New DevExpress.XtraBars.Bar()
        Me.bbiGuardar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiMarcar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDesmarcar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiExpandir = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiColapsar = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiCerrar = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.txtPerfil = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.gpcEspera = New DevExpress.XtraEditors.GroupControl()
        Me.lblEspera = New DevExpress.XtraEditors.LabelControl()
        Me.pbcGuardar = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.gpcModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpcModulos.SuspendLayout()
        CType(Me.gpcPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpcPerfil.SuspendLayout()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bmaPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPerfil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpcEspera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpcEspera.SuspendLayout()
        CType(Me.pbcGuardar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trvPerfiles
        '
        Me.trvPerfiles.CheckBoxes = True
        Me.trvPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvPerfiles.Location = New System.Drawing.Point(2, 23)
        Me.trvPerfiles.Name = "trvPerfiles"
        Me.trvPerfiles.Size = New System.Drawing.Size(994, 319)
        Me.trvPerfiles.TabIndex = 2
        '
        'gpcModulos
        '
        Me.gpcModulos.Controls.Add(Me.trvPerfiles)
        Me.gpcModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpcModulos.Location = New System.Drawing.Point(0, 174)
        Me.gpcModulos.Name = "gpcModulos"
        Me.gpcModulos.Size = New System.Drawing.Size(998, 344)
        Me.gpcModulos.TabIndex = 3
        Me.gpcModulos.Text = "Módulos"
        '
        'gpcPerfil
        '
        Me.gpcPerfil.Controls.Add(Me.txtDescripcion)
        Me.gpcPerfil.Controls.Add(Me.txtPerfil)
        Me.gpcPerfil.Controls.Add(Me.LabelControl2)
        Me.gpcPerfil.Controls.Add(Me.LabelControl1)
        Me.gpcPerfil.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpcPerfil.Location = New System.Drawing.Point(0, 32)
        Me.gpcPerfil.Name = "gpcPerfil"
        Me.gpcPerfil.Size = New System.Drawing.Size(998, 142)
        Me.gpcPerfil.TabIndex = 4
        Me.gpcPerfil.Text = "Perfil"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(76, 72)
        Me.txtDescripcion.MenuManager = Me.bmaPerfil
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Properties.MaxLength = 1000
        Me.txtDescripcion.Size = New System.Drawing.Size(797, 52)
        Me.txtDescripcion.TabIndex = 1
        '
        'bmaPerfil
        '
        Me.bmaPerfil.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barToolBar})
        Me.bmaPerfil.DockControls.Add(Me.barDockControlTop)
        Me.bmaPerfil.DockControls.Add(Me.barDockControlBottom)
        Me.bmaPerfil.DockControls.Add(Me.barDockControlLeft)
        Me.bmaPerfil.DockControls.Add(Me.barDockControlRight)
        Me.bmaPerfil.Form = Me
        Me.bmaPerfil.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiGuardar, Me.bbiCerrar, Me.bbiMarcar, Me.bbiDesmarcar, Me.bbiExpandir, Me.bbiColapsar})
        Me.bmaPerfil.MaxItemId = 6
        '
        'barToolBar
        '
        Me.barToolBar.BarName = "Herramientas"
        Me.barToolBar.DockCol = 0
        Me.barToolBar.DockRow = 0
        Me.barToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiGuardar), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiMarcar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiDesmarcar), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiExpandir, True), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiColapsar), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiCerrar, True)})
        Me.barToolBar.OptionsBar.AllowQuickCustomization = False
        Me.barToolBar.OptionsBar.DisableClose = True
        Me.barToolBar.OptionsBar.DisableCustomization = True
        Me.barToolBar.OptionsBar.DrawBorder = False
        Me.barToolBar.Text = "Herramientas"
        '
        'bbiGuardar
        '
        Me.bbiGuardar.Caption = "Guardar"
        Me.bbiGuardar.Id = 0
        Me.bbiGuardar.ImageOptions.Image = CType(resources.GetObject("bbiGuardar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiGuardar.ImageOptions.LargeImage = CType(resources.GetObject("bbiGuardar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiGuardar.Name = "bbiGuardar"
        Me.bbiGuardar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiMarcar
        '
        Me.bbiMarcar.Caption = "Marcar todo"
        Me.bbiMarcar.Id = 2
        Me.bbiMarcar.ImageOptions.Image = CType(resources.GetObject("bbiMarcar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiMarcar.ImageOptions.LargeImage = CType(resources.GetObject("bbiMarcar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiMarcar.Name = "bbiMarcar"
        Me.bbiMarcar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiDesmarcar
        '
        Me.bbiDesmarcar.Caption = "Desmarcar todo"
        Me.bbiDesmarcar.Id = 3
        Me.bbiDesmarcar.ImageOptions.Image = CType(resources.GetObject("bbiDesmarcar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiDesmarcar.ImageOptions.LargeImage = CType(resources.GetObject("bbiDesmarcar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiDesmarcar.Name = "bbiDesmarcar"
        Me.bbiDesmarcar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiExpandir
        '
        Me.bbiExpandir.Caption = "Expandir"
        Me.bbiExpandir.Id = 4
        Me.bbiExpandir.ImageOptions.Image = CType(resources.GetObject("bbiExpandir.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiExpandir.ImageOptions.LargeImage = CType(resources.GetObject("bbiExpandir.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiExpandir.Name = "bbiExpandir"
        Me.bbiExpandir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiColapsar
        '
        Me.bbiColapsar.Caption = "Colapsar"
        Me.bbiColapsar.Id = 5
        Me.bbiColapsar.ImageOptions.Image = CType(resources.GetObject("bbiColapsar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiColapsar.ImageOptions.LargeImage = CType(resources.GetObject("bbiColapsar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiColapsar.Name = "bbiColapsar"
        Me.bbiColapsar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'bbiCerrar
        '
        Me.bbiCerrar.Caption = "Cerrar"
        Me.bbiCerrar.Id = 1
        Me.bbiCerrar.ImageOptions.Image = CType(resources.GetObject("bbiCerrar.ImageOptions.Image"), System.Drawing.Image)
        Me.bbiCerrar.ImageOptions.LargeImage = CType(resources.GetObject("bbiCerrar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.bbiCerrar.Name = "bbiCerrar"
        Me.bbiCerrar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.bmaPerfil
        Me.barDockControlTop.Size = New System.Drawing.Size(998, 32)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 518)
        Me.barDockControlBottom.Manager = Me.bmaPerfil
        Me.barDockControlBottom.Size = New System.Drawing.Size(998, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 32)
        Me.barDockControlLeft.Manager = Me.bmaPerfil
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 486)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(998, 32)
        Me.barDockControlRight.Manager = Me.bmaPerfil
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 486)
        '
        'txtPerfil
        '
        Me.txtPerfil.Location = New System.Drawing.Point(76, 34)
        Me.txtPerfil.MenuManager = Me.bmaPerfil
        Me.txtPerfil.Name = "txtPerfil"
        Me.txtPerfil.Properties.MaxLength = 100
        Me.txtPerfil.Size = New System.Drawing.Size(493, 20)
        Me.txtPerfil.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 73)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Descripción:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 37)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Perfil:"
        '
        'gpcEspera
        '
        Me.gpcEspera.Controls.Add(Me.lblEspera)
        Me.gpcEspera.Controls.Add(Me.pbcGuardar)
        Me.gpcEspera.Location = New System.Drawing.Point(250, 300)
        Me.gpcEspera.Name = "gpcEspera"
        Me.gpcEspera.Size = New System.Drawing.Size(405, 100)
        Me.gpcEspera.TabIndex = 9
        Me.gpcEspera.Text = "Guardando..."
        Me.gpcEspera.Visible = False
        '
        'lblEspera
        '
        Me.lblEspera.Appearance.Options.UseTextOptions = True
        Me.lblEspera.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblEspera.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblEspera.Location = New System.Drawing.Point(22, 65)
        Me.lblEspera.Name = "lblEspera"
        Me.lblEspera.Size = New System.Drawing.Size(365, 13)
        Me.lblEspera.TabIndex = 1
        Me.lblEspera.Text = "Guardando el Perfil, espere un momento por favor..."
        '
        'pbcGuardar
        '
        Me.pbcGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbcGuardar.EditValue = 50
        Me.pbcGuardar.Location = New System.Drawing.Point(22, 41)
        Me.pbcGuardar.MenuManager = Me.bmaPerfil
        Me.pbcGuardar.Name = "pbcGuardar"
        Me.pbcGuardar.Properties.EndColor = System.Drawing.Color.DodgerBlue
        Me.pbcGuardar.Properties.StartColor = System.Drawing.Color.SteelBlue
        Me.pbcGuardar.ShowToolTips = False
        Me.pbcGuardar.Size = New System.Drawing.Size(365, 18)
        Me.pbcGuardar.TabIndex = 0
        '
        'frmNuevoPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 518)
        Me.Controls.Add(Me.gpcEspera)
        Me.Controls.Add(Me.gpcModulos)
        Me.Controls.Add(Me.gpcPerfil)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Image = CType(resources.GetObject("frmNuevoPerfil.IconOptions.Image"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoPerfil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevo Perfil"
        CType(Me.gpcModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpcModulos.ResumeLayout(False)
        CType(Me.gpcPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpcPerfil.ResumeLayout(False)
        Me.gpcPerfil.PerformLayout()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bmaPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPerfil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpcEspera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpcEspera.ResumeLayout(False)
        CType(Me.pbcGuardar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents trvPerfiles As Windows.Forms.TreeView
    Friend WithEvents gpcModulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gpcPerfil As DevExpress.XtraEditors.GroupControl
    Friend WithEvents bmaPerfil As DevExpress.XtraBars.BarManager
    Friend WithEvents barToolBar As DevExpress.XtraBars.Bar
    Friend WithEvents bbiGuardar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiCerrar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescripcion As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtPerfil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents bbiMarcar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDesmarcar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiExpandir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiColapsar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents gpcEspera As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pbcGuardar As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents lblEspera As DevExpress.XtraEditors.LabelControl
End Class
