<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddNewUser
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        addBtn = New Guna.UI2.WinForms.Guna2Button()
        roleCmb = New Guna.UI2.WinForms.Guna2ComboBox()
        pswTxt = New Guna.UI2.WinForms.Guna2TextBox()
        dbStatPnl = New Guna.UI2.WinForms.Guna2GradientPanel()
        Label1 = New Label()
        closeBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        minBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        maxBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        Panel1 = New Panel()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        unameTxt = New Guna.UI2.WinForms.Guna2TextBox()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' addBtn
        ' 
        addBtn.BorderRadius = 19
        addBtn.CustomizableEdges = CustomizableEdges1
        addBtn.DisabledState.BorderColor = Color.DarkGray
        addBtn.DisabledState.CustomBorderColor = Color.DarkGray
        addBtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        addBtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        addBtn.Enabled = False
        addBtn.FillColor = Color.FromArgb(CByte(157), CByte(192), CByte(139))
        addBtn.Font = New Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        addBtn.ForeColor = Color.White
        addBtn.Location = New Point(24, 168)
        addBtn.Margin = New Padding(4, 6, 4, 6)
        addBtn.Name = "addBtn"
        addBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        addBtn.Size = New Size(232, 38)
        addBtn.TabIndex = 9
        addBtn.Text = "Add"
        ' 
        ' roleCmb
        ' 
        roleCmb.BackColor = Color.Transparent
        roleCmb.BorderRadius = 10
        roleCmb.CustomizableEdges = CustomizableEdges3
        roleCmb.DrawMode = DrawMode.OwnerDrawFixed
        roleCmb.DropDownHeight = 100
        roleCmb.DropDownStyle = ComboBoxStyle.DropDownList
        roleCmb.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        roleCmb.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        roleCmb.Font = New Font("Poppins", 9.75F)
        roleCmb.ForeColor = Color.Black
        roleCmb.IntegralHeight = False
        roleCmb.ItemHeight = 30
        roleCmb.Items.AddRange(New Object() {"admin", "user"})
        roleCmb.Location = New Point(24, 120)
        roleCmb.MinimumSize = New Size(10, 0)
        roleCmb.Name = "roleCmb"
        roleCmb.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        roleCmb.Size = New Size(232, 36)
        roleCmb.TabIndex = 3
        ' 
        ' pswTxt
        ' 
        pswTxt.BorderRadius = 10
        pswTxt.CustomizableEdges = CustomizableEdges5
        pswTxt.DefaultText = ""
        pswTxt.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        pswTxt.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        pswTxt.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        pswTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        pswTxt.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        pswTxt.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pswTxt.ForeColor = Color.Black
        pswTxt.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        pswTxt.Location = New Point(24, 80)
        pswTxt.Margin = New Padding(3, 5, 3, 5)
        pswTxt.Name = "pswTxt"
        pswTxt.PasswordChar = ChrW(0)
        pswTxt.PlaceholderForeColor = Color.Gray
        pswTxt.PlaceholderText = "Password"
        pswTxt.SelectedText = ""
        pswTxt.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        pswTxt.Size = New Size(232, 36)
        pswTxt.TabIndex = 2
        ' 
        ' dbStatPnl
        ' 
        dbStatPnl.CustomizableEdges = CustomizableEdges7
        dbStatPnl.FillColor = Color.FromArgb(CByte(157), CByte(192), CByte(139))
        dbStatPnl.FillColor2 = Color.FromArgb(CByte(170), CByte(191), CByte(159))
        dbStatPnl.GradientMode = Drawing2D.LinearGradientMode.Vertical
        dbStatPnl.Location = New Point(-13, 248)
        dbStatPnl.Name = "dbStatPnl"
        dbStatPnl.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        dbStatPnl.Size = New Size(304, 32)
        dbStatPnl.TabIndex = 18
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(24, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(115, 26)
        Label1.TabIndex = 17
        Label1.Text = "Add New User"
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
        closeBtn.Location = New Point(16, 17)
        closeBtn.Name = "closeBtn"
        closeBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges9
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
        minBtn.Location = New Point(32, 17)
        minBtn.Name = "minBtn"
        minBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges10
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
        maxBtn.Location = New Point(48, 17)
        maxBtn.Name = "maxBtn"
        maxBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges11
        maxBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        maxBtn.Size = New Size(12, 12)
        maxBtn.TabIndex = 6
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(closeBtn)
        Panel1.Controls.Add(minBtn)
        Panel1.Controls.Add(maxBtn)
        Panel1.Location = New Point(208, -9)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(80, 40)
        Panel1.TabIndex = 16
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' unameTxt
        ' 
        unameTxt.BorderRadius = 10
        unameTxt.CustomizableEdges = CustomizableEdges12
        unameTxt.DefaultText = ""
        unameTxt.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        unameTxt.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        unameTxt.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        unameTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        unameTxt.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        unameTxt.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        unameTxt.ForeColor = Color.Black
        unameTxt.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        unameTxt.Location = New Point(24, 64)
        unameTxt.Margin = New Padding(3, 5, 3, 5)
        unameTxt.Name = "unameTxt"
        unameTxt.PasswordChar = ChrW(0)
        unameTxt.PlaceholderForeColor = Color.Gray
        unameTxt.PlaceholderText = "Username"
        unameTxt.SelectedText = ""
        unameTxt.ShadowDecoration.CustomizableEdges = CustomizableEdges13
        unameTxt.Size = New Size(232, 36)
        unameTxt.TabIndex = 15
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(addBtn)
        Panel2.Controls.Add(roleCmb)
        Panel2.Controls.Add(pswTxt)
        Panel2.Location = New Point(0, 23)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(280, 233)
        Panel2.TabIndex = 19
        ' 
        ' FormAddNewUser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(250), CByte(249), CByte(246))
        ClientSize = New Size(279, 256)
        Controls.Add(dbStatPnl)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Controls.Add(unameTxt)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormAddNewUser"
        StartPosition = FormStartPosition.CenterParent
        Text = "FormAddNewUser"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents addBtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents roleCmb As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents pswTxt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dbStatPnl As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents closeBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents minBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents maxBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents unameTxt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Panel2 As Panel
End Class
