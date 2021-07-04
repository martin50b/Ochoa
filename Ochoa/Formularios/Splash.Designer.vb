<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.lblCopyright = New DevExpress.XtraEditors.LabelControl()
        Me.lblMensaje = New DevExpress.XtraEditors.LabelControl()
        Me.tmrSplash = New System.Windows.Forms.Timer(Me.components)
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.lblSistema = New DevExpress.XtraEditors.LabelControl()
        Me.lblBienvenida = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'lblCopyright
        '
        Me.lblCopyright.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblCopyright.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblCopyright.Appearance.Options.UseBackColor = True
        Me.lblCopyright.Appearance.Options.UseFont = True
        Me.lblCopyright.Appearance.Options.UseForeColor = True
        Me.lblCopyright.Appearance.Options.UseTextOptions = True
        Me.lblCopyright.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblCopyright.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lblCopyright.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCopyright.Location = New System.Drawing.Point(0, 290)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(510, 18)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "SRSystem Todos los derechos reservados 2021"
        '
        'lblMensaje
        '
        Me.lblMensaje.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblMensaje.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMensaje.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblMensaje.Appearance.Options.UseBackColor = True
        Me.lblMensaje.Appearance.Options.UseFont = True
        Me.lblMensaje.Appearance.Options.UseForeColor = True
        Me.lblMensaje.Appearance.Options.UseTextOptions = True
        Me.lblMensaje.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblMensaje.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblMensaje.Location = New System.Drawing.Point(0, 249)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(510, 23)
        Me.lblMensaje.TabIndex = 1
        Me.lblMensaje.Text = "Preparando el sistema..."
        '
        'tmrSplash
        '
        Me.tmrSplash.Interval = 1000
        '
        'lblVersion
        '
        Me.lblVersion.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblVersion.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Appearance.Options.UseFont = True
        Me.lblVersion.Appearance.Options.UseForeColor = True
        Me.lblVersion.Appearance.Options.UseTextOptions = True
        Me.lblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVersion.Location = New System.Drawing.Point(0, 297)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(62, 13)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "Versión 1.0"
        '
        'lblSistema
        '
        Me.lblSistema.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblSistema.Appearance.Font = New System.Drawing.Font("Book Antiqua", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSistema.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblSistema.Appearance.Options.UseBackColor = True
        Me.lblSistema.Appearance.Options.UseFont = True
        Me.lblSistema.Appearance.Options.UseForeColor = True
        Me.lblSistema.Appearance.Options.UseTextOptions = True
        Me.lblSistema.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblSistema.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblSistema.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblSistema.Location = New System.Drawing.Point(0, 163)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(510, 39)
        Me.lblSistema.TabIndex = 8
        Me.lblSistema.Text = "Sistema OCHOA"
        '
        'lblBienvenida
        '
        Me.lblBienvenida.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblBienvenida.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblBienvenida.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblBienvenida.Appearance.Options.UseBackColor = True
        Me.lblBienvenida.Appearance.Options.UseFont = True
        Me.lblBienvenida.Appearance.Options.UseForeColor = True
        Me.lblBienvenida.Appearance.Options.UseTextOptions = True
        Me.lblBienvenida.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblBienvenida.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblBienvenida.Location = New System.Drawing.Point(0, 220)
        Me.lblBienvenida.Name = "lblBienvenida"
        Me.lblBienvenida.Size = New System.Drawing.Size(510, 23)
        Me.lblBienvenida.TabIndex = 9
        Me.lblBienvenida.Text = "Bienvenido"
        '
        'frmSplash
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.None
        Me.BackgroundImageStore = CType(resources.GetObject("$this.BackgroundImageStore"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(510, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSistema)
        Me.Controls.Add(Me.lblBienvenida)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.lblCopyright)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCopyright As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMensaje As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tmrSplash As Timer
    Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSistema As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBienvenida As DevExpress.XtraEditors.LabelControl
End Class
