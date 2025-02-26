Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class FormAddNewUser
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByRef pvAttribute As Integer, ByVal cbAttribute As Integer) As Integer
    End Function

    Private Sub FormAddNewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.OSVersion.Version.Major >= 10 Then
            DwmSetWindowAttribute(Me.Handle, 33, 2, Marshal.SizeOf(2))
            DwmSetWindowAttribute(Me.Handle, 38, 1, Marshal.SizeOf(1))
        End If
    End Sub

    Function isallf() As Boolean
        If unameTxt.TextLength > 0 AndAlso pswTxt.TextLength > 0 AndAlso roleCmb.SelectedIndex >= 0 Then
            addBtn.Enabled = True
            Return True
        Else
            addBtn.Enabled = False
        End If
        Return False
    End Function

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        If isallf() = True Then
            Dim qry = $"INSERT INTO users (usn, psw, role) VALUES ('{unameTxt.Text}', '{sha256(pswTxt.Text)}', '{roleCmb.SelectedItem.ToString()}');"
            Dim cmd As New MySqlCommand(qry, conn)
            cmd.ExecuteNonQuery()
            addLog(6, unameTxt.Text)
            Me.Dispose()
        Else
            MessageBox.Show("Semua Field wajib diisi!", "Ada Yang Kurang!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Dispose()
    End Sub

    Private Sub unameTxt_TextChanged(sender As Object, e As EventArgs) Handles unameTxt.TextChanged
        isallf()
    End Sub

    Private Sub pswTxt_TextChanged(sender As Object, e As EventArgs) Handles pswTxt.TextChanged
        isallf()
    End Sub

    Private Sub roleCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles roleCmb.SelectedIndexChanged
        isallf()
    End Sub
End Class