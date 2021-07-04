<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUsuario = New DevExpress.XtraEditors.TextEdit()
        Me.txtContraseña = New DevExpress.XtraEditors.TextEdit()
        Me.btnIngresar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContraseña.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(213, 45)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Usuario"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(213, 87)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Contraseña:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(294, 44)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtUsuario.Properties.MaxLength = 30
        Me.txtUsuario.Size = New System.Drawing.Size(180, 18)
        Me.txtUsuario.TabIndex = 0
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(294, 84)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtContraseña.Properties.MaxLength = 30
        Me.txtContraseña.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(180, 18)
        Me.txtContraseña.TabIndex = 1
        '
        'btnIngresar
        '
        Me.btnIngresar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnIngresar.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnIngresar.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnIngresar.Appearance.Options.UseBackColor = True
        Me.btnIngresar.Appearance.Options.UseBorderColor = True
        Me.btnIngresar.Appearance.Options.UseForeColor = True
        Me.btnIngresar.Location = New System.Drawing.Point(289, 179)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(97, 25)
        Me.btnIngresar.TabIndex = 2
        Me.btnIngresar.Text = "Ingresar"
        '
        'btnSalir
        '
        Me.btnSalir.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnSalir.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSalir.Appearance.Options.UseBackColor = True
        Me.btnSalir.Appearance.Options.UseForeColor = True
        Me.btnSalir.Location = New System.Drawing.Point(404, 179)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(97, 25)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseBackColor = True
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl3.Location = New System.Drawing.Point(292, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(210, 24)
        Me.LabelControl3.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseBackColor = True
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl4.Location = New System.Drawing.Point(291, 81)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(210, 24)
        Me.LabelControl4.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.LabelControl5.Appearance.Options.UseBackColor = True
        Me.LabelControl5.ImageOptions.Image = Global.Ochoa.My.Resources.Resources.BO_Person
        Me.LabelControl5.Location = New System.Drawing.Point(481, 45)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(16, 16)
        Me.LabelControl5.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseBackColor = True
        Me.LabelControl6.ImageOptions.Image = Global.Ochoa.My.Resources.Resources.BO_Security_Permission
        Me.LabelControl6.Location = New System.Drawing.Point(481, 84)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(16, 16)
        Me.LabelControl6.TabIndex = 7
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.SimpleButton1.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseBorderColor = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(37, 213)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(97, 25)
        Me.SimpleButton1.TabIndex = 8
        Me.SimpleButton1.Text = "Ingresar"
        '
        'frmLogin
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.None
        Me.BackgroundImageStore = Global.Ochoa.My.Resources.Resources.Login
        Me.ClientSize = New System.Drawing.Size(510, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl4)
        Me.DoubleBuffered = True
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IconOptions.Image = CType(resources.GetObject("frmLogin.IconOptions.Image"), System.Drawing.Image)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmLogin.IconOptions.LargeImage"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(217, Byte), Integer))
        CType(Me.txtUsuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContraseña.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUsuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtContraseña As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnIngresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
