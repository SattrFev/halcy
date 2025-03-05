Imports System.Runtime.InteropServices
Imports Microsoft.EntityFrameworkCore.Diagnostics
Imports Microsoft.EntityFrameworkCore.ValueGeneration.Internal
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Crypto.Generators
Imports System.Media


Public Class Dashboard
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByRef pvAttribute As Integer, ByVal cbAttribute As Integer) As Integer
    End Function
    Dim barangList As New List(Of (Integer, String, String, Decimal, Decimal, String, Integer, Integer, String, String))()
    Dim editmode As Boolean = False
    Dim editmodeuser As Boolean = False
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.OSVersion.Version.Major >= 10 Then
            DwmSetWindowAttribute(Me.Handle, 33, 2, Marshal.SizeOf(2))
            DwmSetWindowAttribute(Me.Handle, 38, 1, Marshal.SizeOf(1))
        End If
        Me.KeyPreview = True
    End Sub

    Private Sub Dashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Width = 1153
        usnLbl.Text = userInfo(1)
        roleLbl.Text = userInfo(2)
        If userInfo(2) = "Administrator" Then
            pfpPct.Image = My.Resources.user__1_
        End If
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Login.Dispose()
    End Sub

    Private Sub minBtn_Click(sender As Object, e As EventArgs) Handles minBtn.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub logoutBtn_Click(sender As Object, e As EventArgs)
        Application.Restart()
    End Sub

    Private Function switchPage(ByVal pages As Integer) As Boolean
        dashBtn.FillColor = Color.Transparent
        logBtn.FillColor = Color.Transparent
        itemsBtn.FillColor = Color.Transparent
        userBtn.FillColor = Color.Transparent
        dashPnl.Visible = False
        logPnlx.Visible = False
        itemsPnl.Visible = False
        userPnl.Visible = False
        If pages = 1 Then
            dashBtn.FillColor = Color.Gainsboro
            If DashDgv.Rows.Count = 0 Then
                lblTotal.Text = "Rp 0"
            End If
            dashPnl.Visible = True
        ElseIf pages = 2 Then
            userBtn.FillColor = Color.Gainsboro
            userPnl.Visible = True
        ElseIf pages = 3 Then
            logBtn.FillColor = Color.Gainsboro
            logPnlx.Visible = True
            logPnlx.BringToFront()
            loadLog()
        ElseIf pages = 4 Then
            itemsBtn.FillColor = Color.Gainsboro
            itemsPnl.Visible = True
        End If
    End Function

    Private Sub dashBtn_Click(sender As Object, e As EventArgs) Handles dashBtn.Click
        switchPage(1)
    End Sub

    Private Sub userBtn_Click(sender As Object, e As EventArgs) Handles userBtn.Click
        switchPage(2)
    End Sub

    Private Sub logBtn_Click(sender As Object, e As EventArgs) Handles logBtn.Click
        switchPage(3)
    End Sub

    Private Sub itemsBtn_Click(sender As Object, e As EventArgs) Handles itemsBtn.Click
        switchPage(4)
    End Sub


    Private Function loadBarang() As Boolean
        Try
            Dim query As String = "SELECT id, barcode, name, category, sell_price, buy_price, unit, stock, min_stock FROM barang"
            Dim cmd = New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ' Pakai List of ValueTuple

            Dim no As Integer = 1

            barangList.Clear()
            While reader.Read()
                barangList.Add((
                no,
                reader("name").ToString(),
                reader("category").ToString(),
                Convert.ToDecimal(reader("sell_price")),
                Convert.ToDecimal(reader("buy_price")),
                reader("unit").ToString(),
                Convert.ToInt32(reader("stock")),
                Convert.ToInt32(reader("min_stock")),
                reader("barcode").ToString(),
                reader("id").ToString()
            ))
                no += 1
            End While
            reader.Close()
            barangDgv.Rows.Clear()

            For Each item In barangList
                barangDgv.Rows.Add(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7, item.Item8, item.Item9, item.Item10)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Function cariBarang(ByVal likex As String) As Boolean
        Try

            barangDgv.Rows.Clear()
            Dim no As Integer = 1

            Dim copybarangList = barangList.ToList()
            Dim hasilCari = copybarangList.Where(Function(item) item.Item2.ToLower().StartsWith(likex.ToLower())).ToList()


            For Each item In hasilCari
                barangDgv.Rows.Add(no, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7, item.Item8, item.Item9, item.Item10)
                no += 1
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub searchTxt_TextChanged(sender As Object, e As EventArgs) Handles searchTxt.TextChanged
        If searchTxt.TextLength > 0 Then
            cariBarang(searchTxt.Text)
        Else
            For Each item In barangList
                barangDgv.Rows.Add(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, item.Item6, item.Item7, item.Item8, item.Item9)
            Next
        End If

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles refreshBarangBtn.Click
        loadBarang()
    End Sub

    Private Sub addItemBtn_Click(sender As Object, e As EventArgs) Handles addItemBtn.Click
        FormAddNewItem.ShowDialog()
    End Sub

    Private Sub Dashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            FormAddNewItem.ShowDialog()
        End If
    End Sub
    Private Sub userDgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles userDgv.CellValueChanged
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            editUser(e.ColumnIndex, userDgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, userDgv.SelectedRows(0).Cells(4).Value.ToString)
        End If
    End Sub
    Private Function editUser(ByVal col As Integer, newval As String, idx As String) As Object
        Dim func As String
        If col = 1 Then
            func = "usn"
        ElseIf col = 2 Then
            func = "role"
        End If
        Dim query As String = $"UPDATE users SET {func} = @newval WHERE id = {idx}"
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@newval", newval)
        cmd.ExecuteNonQuery()
    End Function
    Private Function editBarang(ByVal col As Integer, newval As String, idx As String) As Object
        Dim func As String
        If col = 1 Then
            func = "name"
        ElseIf col = 2 Then
            func = "category"
        ElseIf col = 3 Then
            func = "sell_price"
        ElseIf col = 4 Then
            func = "buy_price"
        ElseIf col = 5 Then
            func = "unit"
        ElseIf col = 6 Then
            func = "stock"
        ElseIf col = 7 Then
            func = "min_stock"
        ElseIf col = 8 Then
            func = "barcode"
        End If
        Dim query As String = $"UPDATE barang SET {func} = @newval WHERE id = {idx}"
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@newval", newval)
        Clipboard.SetText(query)
        cmd.ExecuteNonQuery()
        addLog(4, $"{idx}")
    End Function
    Private Sub editModeBtn_Click(sender As Object, e As EventArgs) Handles editModeBtn.Click
        If editmode = False Then
            editmode = True
            removeItemBtn.Enabled = True
            editModeBtn.Text = "View Mode"
            barangDgv.ReadOnly = False
            barangDgv.Columns("Id").ReadOnly = True
            barangDgv.Columns("no").ReadOnly = True
            barangDgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Alizarin
            editModeBtn.Font = New Font(editModeBtn.Font, FontStyle.Bold)
            refreshBarangBtn.Enabled = False
            editModeBtn.FillColor = Color.FromArgb(210, 102, 90)
        Else
            editmode = False
            removeItemBtn.Enabled = False
            editModeBtn.FillColor = Color.Gray
            barangDgv.ReadOnly = True
            refreshBarangBtn.Enabled = Enabled
            editModeBtn.Text = "Edit Mode"
            barangDgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Blue
            editModeBtn.Font = New Font(editModeBtn.Font, FontStyle.Regular)
        End If
    End Sub



    Private Sub barangDgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles barangDgv.CellValueChanged
        ' Cek biar gak error kalau index -1 (misal pas header berubah)
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Dim rowIndex = e.RowIndex
            Dim columnIndex = e.ColumnIndex
            Dim columnName = barangDgv.Columns(columnIndex).Name
            Dim newValue = barangDgv.Rows(rowIndex).Cells(columnIndex).Value.ToString
            Dim id = barangDgv.Rows(rowIndex).Cells(9).Value.ToString
            editBarang(columnIndex, newValue, id)
        End If
    End Sub



    Private Sub userDeleteBtn_Click(sender As Object, e As EventArgs) Handles userDeleteBtn.Click
        deleteUser()
    End Sub

    Sub deleteUser()
        Dim selectedId As String
        If userDgv.RowCount > 0 Then
            selectedId = userDgv.SelectedRows(0).Cells(4).Value.ToString()
            If selectedId.Length > 0 Then
                Dim res As DialogResult = MessageBox.Show($"Yakin mau ngapus user?", "Yg Bener?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If res = DialogResult.OK Then
                    Dim qry As String = $"DELETE FROM users WHERE id = {selectedId}"
                    Dim cmd As New MySqlCommand(qry, conn)
                    cmd.ExecuteNonQuery()
                    loadUser()
                End If
            End If
        End If
    End Sub


    Sub deleteItem()
        Dim selectedId As New List(Of String)
        Dim selectedItem As New List(Of String)

        For Each row As DataGridViewRow In barangDgv.SelectedRows
            selectedId.Add(barangDgv.Rows(row.Index).Cells(9).Value.ToString())
            selectedItem.Add(barangDgv.Rows(row.Index).Cells(1).Value.ToString())
        Next

        If selectedId.Count > 0 Then
            Dim res As DialogResult = MessageBox.Show($"Apakah kamu yakin ingin menghapus {selectedId.Count} barang?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If res = DialogResult.OK Then
                Dim query As String = "DELETE FROM barang WHERE id IN (" & String.Join(",", selectedId) & ")"
                addLog(2, String.Join(",", selectedItem) & ")")
                Dim cmd As New MySqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                loadBarang()
            End If

            'MessageBox.Show(String.Join(vbCrLf, selectedIndexes), "Selected Row Indexes")
        Else
            MessageBox.Show("Tidak ada barang yang dipilih.", "Info")
        End If
    End Sub

    Private Sub removeItemBtn_Click(sender As Object, e As EventArgs) Handles removeItemBtn.Click
        deleteItem()
    End Sub

    Sub loadLog()
        Dim qry As String = "SELECT * FROM userlog"
        Dim cmd = New MySqlCommand(qry, conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        Dim no As Integer = 1
        logDgv.Rows.Clear()

        While reader.Read()
            logDgv.Rows.Add(no, reader("executor").ToString(), reader("actions").ToString(), reader("time").ToString(), reader("id").ToString())
            no += 1
        End While
        reader.Close()
    End Sub
    Private Sub logRefreshBtn_Click(sender As Object, e As EventArgs) Handles logRefreshBtn.Click
        loadLog()
    End Sub



    Sub loadUser()
        userDgv.Rows.Clear()
        Dim cmd = New MySqlCommand("SELECT * FROM users", conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader
        Dim no As Integer = 1
        While reader.Read
            userDgv.Rows.Add(no, reader("usn").ToString(), reader("role").ToString(), reader("created_at").ToString(), reader("id").ToString())
            no += 1
        End While
        reader.Close()
    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles userRefreshBtn.Click
        loadUser()
    End Sub


    Sub changePass(ByVal idx As Integer)
        If userDgv.RowCount > 0 Then
            Dim cmdx As New MySqlCommand("SELECT * FROM users WHERE id = @id", conn)
            cmdx.Parameters.AddWithValue("@id", idx)
            Dim reader As MySqlDataReader = cmdx.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                Dim userInput As String
                userInput = InputBox($"Enter a new password for {reader("usn")}", "Change Password")
                If userInput <> "" Then
                    reader.Close()
                    Dim qry As String = $"UPDATE users SET psw = @newval WHERE id = {idx}"
                    Dim cmd As New MySqlCommand(qry, conn)
                    cmd.Parameters.AddWithValue("@newval", sha256(userInput))
                    cmd.ExecuteNonQuery()
                    loadUser()
                End If
            Else
                loadUser()
            End If
        End If
    End Sub
    Private Sub addUserBtn_Click(sender As Object, e As EventArgs) Handles addUserBtn.Click
        FormAddNewUser.ShowDialog()
    End Sub

    Private Sub userEditBtn_Click(sender As Object, e As EventArgs) Handles userEditBtn.Click
        If editmodeuser = False Then
            editmodeuser = True
            userRefreshBtn.Enabled = False
            changePwBtn.Enabled = True
            userDgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Alizarin
            userDgv.ReadOnly = False
            userDgv.Columns("userId").ReadOnly = True
            userDeleteBtn.Enabled = True
            userDgv.Columns("userNo").ReadOnly = True
            userDgv.Columns("userCreated").ReadOnly = True
        Else
            editmodeuser = False
            changePwBtn.Enabled = False
            userDgv.ReadOnly = True
            userRefreshBtn.Enabled = True
            userDeleteBtn.Enabled = False
            userDgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Blue
        End If
    End Sub

    Private Sub changePwBtn_Click(sender As Object, e As EventArgs) Handles changePwBtn.Click
        changePass(userDgv.Rows(userDgv.SelectedRows(0).Index).Cells(4).Value.ToString())
    End Sub

    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click
        isloged = False
        userInfo = New String(2) {}
        Me.Dispose()
        Login.Show()
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim query As String = "SELECT * FROM barang WHERE barcode = @barc"
            Dim cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@barc", txtBarcode.Text)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Dim no As Integer
            If Not reader.HasRows Then
                SystemSounds.Hand.Play()
            Else
                While reader.Read()
                    no = DashDgv.Rows.Count + 1
                    DashDgv.Rows.Add(no, reader("name").ToString(), Convert.ToDecimal(reader("sell_price")), 1)
                    sumdgv()
                    txtBarcode.Clear()
                    btnPay.Enabled = True
                    btnDel.Enabled = True
                    btnSetQty.Enabled = True
                End While
            End If
            reader.Close()
            e.Handled = True
        End If
    End Sub

    Function removeItemFromDashDgv(ByVal rowx As Integer)
        DashDgv.Rows.RemoveAt(rowx)
        reorderNum()
        sumdgv()
    End Function
    Function reorderNum()
        For i As Integer = 0 To DashDgv.Rows.Count - 1 ' Fix: Ubah Count jadi Count - 1
            If Not DashDgv.Rows(i).IsNewRow Then ' Hindari baris kosong di akhir
                DashDgv.Rows(i).Cells("dashColNo").Value = i + 1
            End If
        Next
    End Function

    Function sumdgv() As Decimal
        Dim totalHarga As Decimal = 0
        For i As Integer = 0 To DashDgv.Rows.Count - 1
            If Not DashDgv.Rows(i).IsNewRow Then ' Hindari baris kosong di akhir
                Dim hargaitem As Decimal = Convert.ToDecimal(DashDgv.Rows(i).Cells("dashColPrice").Value) * Convert.ToInt16(DashDgv.Rows(i).Cells("dashColQty").Value)
                totalHarga += hargaitem
            End If
        Next
        lblTotal.Text = $"Rp {totalHarga.ToString("N0")}"
        Return totalHarga
    End Function

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim selectedIndex = DashDgv.SelectedRows(0).Index
        removeItemFromDashDgv(selectedIndex)
        If DashDgv.Rows.Count = 0 Then
            btnDel.Enabled = False
            btnPay.Enabled = False
            btnSetQty.Enabled = False
        End If
    End Sub

    Private Sub btnSetQty_Click(sender As Object, e As EventArgs) Handles btnSetQty.Click, btnQrisMethod.Click
        Dim userInput As String
        Dim qty As Integer
        Dim si = DashDgv.SelectedRows(0).Index
        Do
            userInput = InputBox($"Masukkan Kuantitas dari {DashDgv.Rows(si).Cells(1).Value.ToString}", "Change Qty")
            If userInput = "" Then Exit Sub
        Loop Until Integer.TryParse(userInput, qty)
        DashDgv.Rows(si).Cells(3).Value = qty
        sumdgv()

    End Sub
    Function cashPaymentChance(ByVal total As Decimal) As Integer
        Dim userInput As String
        Dim chance As Integer
        Do
            userInput = InputBox($"Masukkan jumlah yang dibayarkan customer!", $"Rp {total.ToString("N0")}")
            If userInput = "" Then Exit Function
        Loop Until Integer.TryParse(userInput, chance) AndAlso (userInput - total) >= 0
        chance = userInput - total
        Dim result As MsgBoxResult

        result = MsgBox("Saldo: " & Convert.ToInt64(userInput).ToString("N0") & vbCrLf &
                "Hutang: " & total.ToString("N0") & vbCrLf &
                "Kembalian: " & chance.ToString("N0") & vbCrLf & "Apakah Ingin Mencetak Struk?",
                vbYesNoCancel + vbInformation, "Detail Pembayaran")

        If result = vbYes Then
            MessageBox.Show("User memilih YES")
        ElseIf result = vbNo Then
            MessageBox.Show("User memilih NO")
        ElseIf result = vbCancel Then
            MessageBox.Show("User membatalkan transaksi")
            Return -1 ' Bisa return -1 untuk indikasi batal
        End If

        Return chance
    End Function


    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        paymentPnl.Location = New Point(616, 24)
        paymentPnl.BringToFront()
        paymentPnl.Visible = True
    End Sub

    Private Sub btnCancelPay_Click(sender As Object, e As EventArgs) Handles btnCancelPay.Click
        paymentPnl.Location = New Point(616, 208)
        paymentPnl.Visible = False
    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        cashPaymentChance(sumdgv())
    End Sub
End Class