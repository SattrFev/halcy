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
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Panel1 = New Panel()
        closeBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        minBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        maxBtn = New Guna.UI2.WinForms.Guna2CircleButton()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(closeBtn)
        Panel1.Controls.Add(minBtn)
        Panel1.Controls.Add(maxBtn)
        Panel1.Location = New Point(208, -8)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(80, 40)
        Panel1.TabIndex = 8
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
        closeBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges1
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
        minBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges2
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
        maxBtn.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        maxBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        maxBtn.Size = New Size(12, 12)
        maxBtn.TabIndex = 6
        ' 
        ' FormAddNewUser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(250), CByte(249), CByte(246))
        ClientSize = New Size(279, 382)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormAddNewUser"
        Text = "FormAddNewUser"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Panel1 As Panel
    Friend WithEvents closeBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents minBtn As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents maxBtn As Guna.UI2.WinForms.Guna2CircleButton
End Class
