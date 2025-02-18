<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        usnLbl = New Label()
        Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        permLbl = New Label()
        Panel1 = New Panel()
        closeBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        minBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        maxBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Guna2Panel1.SuspendLayout()
        CType(Guna2CirclePictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Guna2Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.BorderColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Guna2Panel1.Controls.Add(Guna2Button1)
        Guna2Panel1.Controls.Add(usnLbl)
        Guna2Panel1.Controls.Add(Guna2CirclePictureBox1)
        Guna2Panel1.Controls.Add(permLbl)
        Guna2Panel1.CustomBorderColor = Color.Gray
        Guna2Panel1.CustomBorderThickness = New Padding(0, 0, 1, 1)
        CustomizableEdges4.BottomLeft = False
        CustomizableEdges4.BottomRight = False
        CustomizableEdges4.TopLeft = False
        CustomizableEdges4.TopRight = False
        Guna2Panel1.CustomizableEdges = CustomizableEdges4
        Guna2Panel1.Dock = DockStyle.Top
        Guna2Panel1.Location = New Point(0, 0)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges5
        Guna2Panel1.Size = New Size(200, 104)
        Guna2Panel1.TabIndex = 1
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.BorderRadius = 5
        Guna2Button1.CustomizableEdges = CustomizableEdges1
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.FromArgb(CByte(252), CByte(92), CByte(88))
        Guna2Button1.Font = New Font("Poppins Medium", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Location = New Point(72, 64)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Button1.Size = New Size(96, 24)
        Guna2Button1.TabIndex = 14
        Guna2Button1.Text = "Logout"
        ' 
        ' usnLbl
        ' 
        usnLbl.AutoSize = True
        usnLbl.BackColor = Color.Transparent
        usnLbl.FlatStyle = FlatStyle.Flat
        usnLbl.Font = New Font("Poppins Medium", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        usnLbl.Location = New Point(72, 16)
        usnLbl.Name = "usnLbl"
        usnLbl.Size = New Size(98, 26)
        usnLbl.TabIndex = 3
        usnLbl.Text = "Username"
        ' 
        ' Guna2CirclePictureBox1
        ' 
        Guna2CirclePictureBox1.FillColor = Color.Silver
        Guna2CirclePictureBox1.ImageRotate = 0F
        Guna2CirclePictureBox1.Location = New Point(16, 16)
        Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Guna2CirclePictureBox1.Size = New Size(48, 48)
        Guna2CirclePictureBox1.TabIndex = 2
        Guna2CirclePictureBox1.TabStop = False
        ' 
        ' permLbl
        ' 
        permLbl.AutoSize = True
        permLbl.Font = New Font("Poppins", 8.25F)
        permLbl.Location = New Point(72, 40)
        permLbl.Name = "permLbl"
        permLbl.Size = New Size(83, 19)
        permLbl.TabIndex = 2
        permLbl.Text = "Administrator"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(closeBtn)
        Panel1.Controls.Add(minBtn)
        Panel1.Controls.Add(maxBtn)
        Panel1.Location = New Point(1040, -8)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(80, 40)
        Panel1.TabIndex = 6
        ' 
        ' closeBtn
        ' 
        closeBtn.DisabledState.BorderColor = Color.DarkGray
        closeBtn.DisabledState.CustomBorderColor = Color.DarkGray
        closeBtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        closeBtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        closeBtn.FillColor = Color.FromArgb(CByte(252), CByte(92), CByte(88))
        closeBtn.Font = New Font("Segoe UI", 9F)
        closeBtn.ForeColor = Color.White
        closeBtn.Location = New Point(16, 16)
        closeBtn.Name = "closeBtn"
        closeBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        closeBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        closeBtn.Size = New Size(12, 12)
        closeBtn.TabIndex = 6
        ' 
        ' minBtn
        ' 
        minBtn.DisabledState.BorderColor = Color.DarkGray
        minBtn.DisabledState.CustomBorderColor = Color.DarkGray
        minBtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        minBtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        minBtn.FillColor = Color.FromArgb(CByte(253), CByte(190), CByte(70))
        minBtn.Font = New Font("Segoe UI", 9F)
        minBtn.ForeColor = Color.White
        minBtn.Location = New Point(32, 16)
        minBtn.Name = "minBtn"
        minBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges9
        minBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        minBtn.Size = New Size(12, 12)
        minBtn.TabIndex = 6
        ' 
        ' maxBtn
        ' 
        maxBtn.DisabledState.BorderColor = Color.DarkGray
        maxBtn.DisabledState.CustomBorderColor = Color.DarkGray
        maxBtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        maxBtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        maxBtn.FillColor = Color.FromArgb(CByte(57), CByte(201), CByte(78))
        maxBtn.Font = New Font("Segoe UI", 9F)
        maxBtn.ForeColor = Color.White
        maxBtn.Location = New Point(48, 16)
        maxBtn.Name = "maxBtn"
        maxBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        maxBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        maxBtn.Size = New Size(12, 12)
        maxBtn.TabIndex = 6
        ' 
        ' Guna2Panel2
        ' 
        Guna2Panel2.Controls.Add(Guna2Panel1)
        Guna2Panel2.CustomBorderColor = Color.Gray
        Guna2Panel2.CustomBorderThickness = New Padding(0, 0, 1, 0)
        Guna2Panel2.CustomizableEdges = CustomizableEdges6
        Guna2Panel2.Location = New Point(0, 0)
        Guna2Panel2.Name = "Guna2Panel2"
        Guna2Panel2.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        Guna2Panel2.Size = New Size(200, 664)
        Guna2Panel2.TabIndex = 7
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(250), CByte(249), CByte(246))
        ClientSize = New Size(1114, 660)
        Controls.Add(Guna2Panel2)
        Controls.Add(Panel1)
        Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 6, 4, 6)
        Name = "Dashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dashboard"
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        CType(Guna2CirclePictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Guna2Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents usnLbl As Label
    Friend WithEvents permLbl As Label
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents closeBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents minBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents maxBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
End Class
