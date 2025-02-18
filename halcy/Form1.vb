Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices


Public Class Login
    Public isloged As Boolean = False
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByRef pvAttribute As Integer, ByVal cbAttribute As Integer) As Integer
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(295, 276)
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height
        Dim x As Integer = (screenWidth - formWidth) / 2
        Dim y As Integer = (screenHeight - formHeight) / 2
        Me.Location = New Point(x, y)
        If Environment.OSVersion.Version.Major >= 10 Then
            DwmSetWindowAttribute(Me.Handle, 33, 2, Marshal.SizeOf(2))
        End If
    End Sub

    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtUsn.Focus()
        Dim isrem As Integer = readini(iniPath, "saved-auth", "remember", "")
        If isrem = 1 Then
            txtUsn.Text = readini(iniPath, "saved-auth", "usn", "")
            txtPsw.Text = Encr("Read", readini(iniPath, "saved-auth", "psw", ""))
            keepChk.Checked = True
            loginBtn.Focus()
        End If
        dbMode.SelectedIndex = 0
        Dim portDb As Integer = readini(iniPath, "saved-db", "port", "")
        Dim serverDb As String = readini(iniPath, "saved-db", "server", "")
        Dim usnDb As String = readini(iniPath, "saved-db", "usn", "")
        Dim dbpsw As String = readini(iniPath, "saved-db", "psw", "")
        Dim databaseDb As String = readini(iniPath, "saved-db", "dbdb", "")
        portTxt.Text = portDb
        serverTxt.Text = serverDb
        dbUsnTxt.Text = usnDb
        databaseTxt.Text = databaseDb

        If dbpsw.Length >= 16 Then
            dbPswTxt.Text = Encr("read", dbpsw)
        Else
            dbpsw = "yOHYxrJApm5I75qsqne3qw=="
        End If
        If connectDb($"server={serverDb};port={portDb};user={usnDb};password={Encr("read", dbpsw)};database={databaseDb}", False) = True Then
            confDbBtn.FillColor = Color.FromArgb(157, 192, 139)
            connectBtn.FillColor = Color.FromArgb(157, 192, 139)
            dbStatPnl.FillColor = Color.FromArgb(157, 192, 139)
            dbStatPnl.FillColor2 = Color.FromArgb(170, 191, 159)
            connectBtn.Text = "Disconnect"

            'Enabling Login-Fields
            txtUsn.Enabled = True
            txtPsw.Enabled = True
            loginBtn.Enabled = True
            keepChk.Enabled = True

            'Disabling Db-Fields
            serverTxt.Enabled = False
            portTxt.Enabled = False
            dbUsnTxt.Enabled = False
            dbPswTxt.Enabled = False
            dbMode.Enabled = False
            databaseTxt.Enabled = False
        Else
            confDbBtn.FillColor = Color.FromArgb(210, 102, 90)
            connectBtn.FillColor = Color.FromArgb(210, 102, 90)
            dbStatPnl.FillColor = Color.FromArgb(210, 102, 90)
            dbStatPnl.FillColor2 = Color.FromArgb(209, 130, 121)
        End If
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        If txtUsn.TextLength > 0 AndAlso txtPsw.TextLength > 0 Then
            Dim cmdq = "SELECT COUNT(*) FROM user WHERE usn = @usn AND psw = @psw"
            Using cmd As New MySqlCommand(cmdq, conn)
                cmd.Parameters.AddWithValue("@usn", txtUsn.Text)
                cmd.Parameters.AddWithValue("@psw", txtPsw.Text)
                Try
                    Dim res = Convert.ToInt32(cmd.ExecuteScalar)
                    If res > 0 Then
                        isloged = True
                        writeini(iniPath, "saved-auth", "usn", txtUsn.Text)
                        writeini(iniPath, "saved-auth", "psw", Encr("Write", txtPsw.Text))
                        Me.Hide()
                        Dashboard.Visible = True
                    Else
                        MessageBox.Show("Username atau Password" & vbCrLf & "Salah!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Terjadi kesalahan: " & ex.Message)
                End Try
            End Using
        Else
            MessageBox.Show("Username dan Password" & vbCrLf & "tidak boleh kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub closeBtn_Click_1(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Dispose()
    End Sub

    Private Sub minBtn_Click(sender As Object, e As EventArgs) Handles minBtn.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub confDbBtn_Click(sender As Object, e As EventArgs) Handles confDbBtn.Click
        loginPnl.Visible = False
        Size = New Size(295, 384)
        dbPnl.Location = loginPnl.Location
        dbPnl.Visible = True
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        dbPnl.Visible = False
        loginPnl.Visible = True
        Size = New Size(295, 276)
    End Sub

    Private Sub connectBtn_Click(sender As Object, e As EventArgs) Handles connectBtn.Click
        If conn.State = ConnectionState.Open Then
            conn.Close()
            connectBtn.FillColor = Color.FromArgb(210, 102, 90)
            connectBtn.Text = "Connect"
            confDbBtn.FillColor = Color.FromArgb(210, 102, 90)
            dbStatPnl.FillColor = Color.FromArgb(210, 102, 90)
            dbStatPnl.FillColor2 = Color.FromArgb(209, 130, 121)

            'Disabling Login-Fields
            txtUsn.Enabled = False
            txtPsw.Enabled = False
            loginBtn.Enabled = False
            keepChk.Enabled = False

            'Enbaling Db-Fields
            serverTxt.Enabled = True
            portTxt.Enabled = True
            dbUsnTxt.Enabled = True
            dbPswTxt.Enabled = True
            dbMode.Enabled = True
            databaseTxt.Enabled = True
        Else
            If serverTxt.TextLength > 0 AndAlso portTxt.TextLength > 0 AndAlso dbUsnTxt.TextLength > 0 AndAlso dbPswTxt.TextLength > 0 AndAlso dbMode.SelectedIndex = 0 AndAlso databaseTxt.TextLength > 0 Then
                If connectDb($"server={serverTxt.Text};port={portTxt.Text};user={dbUsnTxt.Text};password={dbPswTxt.Text};database={databaseTxt.Text}", True) = True Then
                    confDbBtn.FillColor = Color.FromArgb(157, 192, 139)
                    connectBtn.FillColor = Color.FromArgb(157, 192, 139)
                    dbStatPnl.FillColor = Color.FromArgb(157, 192, 139)
                    dbStatPnl.FillColor2 = Color.FromArgb(170, 191, 159)
                    connectBtn.Text = "Disconnect"

                    'Enabling Login-Fields
                    txtUsn.Enabled = True
                    txtPsw.Enabled = True
                    loginBtn.Enabled = True
                    keepChk.Enabled = True

                    'Disabling Db-Fields
                    serverTxt.Enabled = False
                    portTxt.Enabled = False
                    dbUsnTxt.Enabled = False
                    dbPswTxt.Enabled = False
                    dbMode.Enabled = False
                    databaseTxt.Enabled = False

                    writeini(iniPath, "saved-db", "usn", dbUsnTxt.Text)
                    writeini(iniPath, "saved-db", "psw", Encr("write", dbPswTxt.Text))
                    writeini(iniPath, "saved-db", "port", portTxt.Text)
                    writeini(iniPath, "saved-db", "server", serverTxt.Text)
                    writeini(iniPath, "saved-db", "dbdb", databaseTxt.Text)
                End If
            Else
                MessageBox.Show("Tidak boleh ada" & vbCrLf & "field yang kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Sub keepChk_CheckedChanged(sender As Object, e As EventArgs) Handles keepChk.CheckedChanged
        If keepChk.Checked = True Then
            writeini(iniPath, "saved-auth", "remember", "1")
        Else
            writeini(iniPath, "saved-auth", "remember", "0")
        End If
    End Sub
End Class
