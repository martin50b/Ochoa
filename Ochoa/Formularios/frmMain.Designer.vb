<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.bvcArchivo = New DevExpress.XtraBars.Ribbon.BackstageViewControl()
        Me.vccCuenta = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.lblSistema = New DevExpress.XtraEditors.LabelControl()
        Me.picLogoOchoa = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTemas = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.bvtCuenta = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.bvbSalir = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.rcoToolBar = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bsiUsuario = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiUsuario1 = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiServidor = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiServidor1 = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiPerfil = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiPerfil1 = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiBaseDatos = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiBaseDatos1 = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiVersion = New DevExpress.XtraBars.BarStaticItem()
        Me.bsiVersion1 = New DevExpress.XtraBars.BarStaticItem()
        Me.rsbStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.imgMenu = New DevExpress.Utils.ImageCollection(Me.components)
        Me.AdornerUIManager1 = New DevExpress.Utils.VisualEffects.AdornerUIManager(Me.components)
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        CType(Me.bvcArchivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bvcArchivo.SuspendLayout()
        Me.vccCuenta.SuspendLayout()
        CType(Me.picLogoOchoa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTemas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rcoToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdornerUIManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bvcArchivo
        '
        Me.bvcArchivo.Controls.Add(Me.vccCuenta)
        Me.bvcArchivo.Items.Add(Me.bvtCuenta)
        Me.bvcArchivo.Items.Add(Me.bvbSalir)
        Me.bvcArchivo.Location = New System.Drawing.Point(812, 81)
        Me.bvcArchivo.Name = "bvcArchivo"
        Me.bvcArchivo.OwnerControl = Me.rcoToolBar
        Me.bvcArchivo.SelectedTab = Me.bvtCuenta
        Me.bvcArchivo.SelectedTabIndex = 0
        Me.bvcArchivo.Size = New System.Drawing.Size(875, 557)
        Me.bvcArchivo.TabIndex = 2
        Me.bvcArchivo.Text = "BackstageViewControl1"
        Me.bvcArchivo.Visible = False
        Me.bvcArchivo.VisibleInDesignTime = True
        '
        'vccCuenta
        '
        Me.vccCuenta.Controls.Add(Me.lblVersion)
        Me.vccCuenta.Controls.Add(Me.lblSistema)
        Me.vccCuenta.Controls.Add(Me.picLogoOchoa)
        Me.vccCuenta.Controls.Add(Me.LabelControl3)
        Me.vccCuenta.Controls.Add(Me.cmbTemas)
        Me.vccCuenta.Controls.Add(Me.LabelControl2)
        Me.vccCuenta.Controls.Add(Me.LabelControl1)
        Me.vccCuenta.Location = New System.Drawing.Point(132, 63)
        Me.vccCuenta.Name = "vccCuenta"
        Me.vccCuenta.Size = New System.Drawing.Size(742, 493)
        Me.vccCuenta.TabIndex = 1
        '
        'lblVersion
        '
        Me.lblVersion.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Appearance.Options.UseBackColor = True
        Me.lblVersion.Appearance.Options.UseFont = True
        Me.lblVersion.Appearance.Options.UseTextOptions = True
        Me.lblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblVersion.Location = New System.Drawing.Point(466, 334)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(244, 19)
        Me.lblVersion.TabIndex = 8
        Me.lblVersion.Text = "Versión 1.0"
        '
        'lblSistema
        '
        Me.lblSistema.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblSistema.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSistema.Appearance.Options.UseBackColor = True
        Me.lblSistema.Appearance.Options.UseFont = True
        Me.lblSistema.Appearance.Options.UseTextOptions = True
        Me.lblSistema.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblSistema.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblSistema.Location = New System.Drawing.Point(466, 305)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(244, 23)
        Me.lblSistema.TabIndex = 7
        Me.lblSistema.Text = "Sistema OCHOA"
        '
        'picLogoOchoa
        '
        Me.picLogoOchoa.EditValue = CType(resources.GetObject("picLogoOchoa.EditValue"), Object)
        Me.picLogoOchoa.Location = New System.Drawing.Point(466, 96)
        Me.picLogoOchoa.Name = "picLogoOchoa"
        Me.picLogoOchoa.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picLogoOchoa.Properties.Appearance.Options.UseBackColor = True
        Me.picLogoOchoa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picLogoOchoa.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picLogoOchoa.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.picLogoOchoa.Size = New System.Drawing.Size(244, 203)
        Me.picLogoOchoa.TabIndex = 6
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseBackColor = True
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(466, 67)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(209, 23)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Información de producto"
        '
        'cmbTemas
        '
        Me.cmbTemas.Location = New System.Drawing.Point(63, 96)
        Me.cmbTemas.Name = "cmbTemas"
        Me.cmbTemas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTemas.Properties.Sorted = True
        Me.cmbTemas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbTemas.Size = New System.Drawing.Size(318, 20)
        Me.cmbTemas.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseBackColor = True
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(63, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(146, 23)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Tema del sistema"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseBackColor = True
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(63, -5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(123, 48)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Cuenta"
        '
        'bvtCuenta
        '
        Me.bvtCuenta.Caption = "Cuenta"
        Me.bvtCuenta.ContentControl = Me.vccCuenta
        Me.bvtCuenta.Name = "bvtCuenta"
        Me.bvtCuenta.Selected = True
        '
        'bvbSalir
        '
        Me.bvbSalir.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[True]
        Me.bvbSalir.Caption = "Salir"
        Me.bvbSalir.ImageOptions.ItemNormal.Image = CType(resources.GetObject("bvbSalir.ImageOptions.ItemNormal.Image"), System.Drawing.Image)
        Me.bvbSalir.Name = "bvbSalir"
        '
        'rcoToolBar
        '
        Me.rcoToolBar.ApplicationButtonDropDownControl = Me.bvcArchivo
        Me.rcoToolBar.ExpandCollapseItem.Id = 0
        Me.rcoToolBar.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.rcoToolBar.ExpandCollapseItem, Me.rcoToolBar.SearchEditItem, Me.bsiUsuario, Me.bsiUsuario1, Me.bsiServidor, Me.bsiServidor1, Me.bsiPerfil, Me.bsiPerfil1, Me.bsiBaseDatos, Me.bsiBaseDatos1, Me.bsiVersion, Me.bsiVersion1})
        Me.rcoToolBar.Location = New System.Drawing.Point(0, 0)
        Me.rcoToolBar.MaxItemId = 128
        Me.rcoToolBar.Name = "rcoToolBar"
        Me.rcoToolBar.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.rcoToolBar.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.rcoToolBar.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcoToolBar.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.rcoToolBar.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcoToolBar.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcoToolBar.ShowToolbarCustomizeItem = False
        Me.rcoToolBar.Size = New System.Drawing.Size(1198, 158)
        Me.rcoToolBar.StatusBar = Me.rsbStatusBar
        Me.rcoToolBar.Toolbar.ShowCustomizeItem = False
        '
        'bsiUsuario
        '
        Me.bsiUsuario.Caption = "Usuario:"
        Me.bsiUsuario.Id = 118
        Me.bsiUsuario.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bsiUsuario.ItemAppearance.Normal.Options.UseFont = True
        Me.bsiUsuario.Name = "bsiUsuario"
        '
        'bsiUsuario1
        '
        Me.bsiUsuario1.Caption = "Usuario1"
        Me.bsiUsuario1.Id = 119
        Me.bsiUsuario1.Name = "bsiUsuario1"
        '
        'bsiServidor
        '
        Me.bsiServidor.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiServidor.Caption = "Servidor:"
        Me.bsiServidor.Id = 120
        Me.bsiServidor.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bsiServidor.ItemAppearance.Normal.Options.UseFont = True
        Me.bsiServidor.Name = "bsiServidor"
        '
        'bsiServidor1
        '
        Me.bsiServidor1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiServidor1.Caption = "Servidor1"
        Me.bsiServidor1.Id = 121
        Me.bsiServidor1.Name = "bsiServidor1"
        '
        'bsiPerfil
        '
        Me.bsiPerfil.Caption = "Perfil:"
        Me.bsiPerfil.Id = 122
        Me.bsiPerfil.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bsiPerfil.ItemAppearance.Normal.Options.UseFont = True
        Me.bsiPerfil.Name = "bsiPerfil"
        '
        'bsiPerfil1
        '
        Me.bsiPerfil1.Caption = "Perfil1"
        Me.bsiPerfil1.Id = 123
        Me.bsiPerfil1.Name = "bsiPerfil1"
        '
        'bsiBaseDatos
        '
        Me.bsiBaseDatos.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiBaseDatos.Caption = "Base de datos:"
        Me.bsiBaseDatos.Id = 124
        Me.bsiBaseDatos.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bsiBaseDatos.ItemAppearance.Normal.Options.UseFont = True
        Me.bsiBaseDatos.Name = "bsiBaseDatos"
        '
        'bsiBaseDatos1
        '
        Me.bsiBaseDatos1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bsiBaseDatos1.Caption = "Base de datos1"
        Me.bsiBaseDatos1.Id = 125
        Me.bsiBaseDatos1.Name = "bsiBaseDatos1"
        '
        'bsiVersion
        '
        Me.bsiVersion.Caption = "Versión:"
        Me.bsiVersion.Id = 126
        Me.bsiVersion.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bsiVersion.ItemAppearance.Normal.Options.UseFont = True
        Me.bsiVersion.Name = "bsiVersion"
        '
        'bsiVersion1
        '
        Me.bsiVersion1.Caption = "Version1"
        Me.bsiVersion1.Id = 127
        Me.bsiVersion1.Name = "bsiVersion1"
        '
        'rsbStatusBar
        '
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiUsuario)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiUsuario1)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiServidor)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiServidor1)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiPerfil)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiPerfil1)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiBaseDatos)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiBaseDatos1)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiVersion)
        Me.rsbStatusBar.ItemLinks.Add(Me.bsiVersion1)
        Me.rsbStatusBar.Location = New System.Drawing.Point(0, 775)
        Me.rsbStatusBar.Name = "rsbStatusBar"
        Me.rsbStatusBar.Ribbon = Me.rcoToolBar
        Me.rsbStatusBar.Size = New System.Drawing.Size(1198, 24)
        '
        'imgMenu
        '
        Me.imgMenu.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgMenu.ImageStream = CType(resources.GetObject("imgMenu.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgMenu.Images.SetKeyName(0, "Default Elote")
        '
        'AdornerUIManager1
        '
        Me.AdornerUIManager1.Owner = Me
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center
        Me.BackgroundImageStore = CType(resources.GetObject("$this.BackgroundImageStore"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1198, 799)
        Me.Controls.Add(Me.bvcArchivo)
        Me.Controls.Add(Me.rsbStatusBar)
        Me.Controls.Add(Me.rcoToolBar)
        Me.IconOptions.Image = CType(resources.GetObject("frmMain.IconOptions.Image"), System.Drawing.Image)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmMain.IconOptions.LargeImage"), System.Drawing.Image)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Ribbon = Me.rcoToolBar
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.rsbStatusBar
        Me.Text = "PRODUCTOS DE MAÍZ OCHOA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.bvcArchivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bvcArchivo.ResumeLayout(False)
        Me.vccCuenta.ResumeLayout(False)
        Me.vccCuenta.PerformLayout()
        CType(Me.picLogoOchoa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTemas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rcoToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdornerUIManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rsbStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents bvcArchivo As DevExpress.XtraBars.Ribbon.BackstageViewControl
    Friend WithEvents bvbSalir As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Friend WithEvents vccCuenta As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents bvtCuenta As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTemas As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents picLogoOchoa As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSistema As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rcoToolBar As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents imgMenu As DevExpress.Utils.ImageCollection
    Friend WithEvents bsiUsuario As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiUsuario1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiServidor As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiServidor1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiPerfil As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiPerfil1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiBaseDatos As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiBaseDatos1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiVersion As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bsiVersion1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents AdornerUIManager1 As DevExpress.Utils.VisualEffects.AdornerUIManager
End Class
