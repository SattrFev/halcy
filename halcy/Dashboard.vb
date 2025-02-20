Imports System.Runtime.InteropServices
Imports Microsoft.EntityFrameworkCore.ValueGeneration.Internal
Imports MySql.Data.MySqlClient

Public Class Dashboard
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByRef pvAttribute As Integer, ByVal cbAttribute As Integer) As Integer
    End Function
    Dim barangList As New List(Of (Integer, String, String, Decimal, Decimal, String, Integer, Integer, String, String))()
    Dim editmode As Boolean = False
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.OSVersion.Version.Major >= 10 Then
            DwmSetWindowAttribute(Me.Handle, 33, 2, Marshal.SizeOf(2))
            DwmSetWindowAttribute(Me.Handle, 38, 1, Marshal.SizeOf(1))
        End If
        Me.KeyPreview = True
    End Sub

    Private Sub Dashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
        If pages = 1 Then
            dashBtn.FillColor = Color.Gainsboro
        ElseIf pages = 2 Then
            userBtn.FillColor = Color.Gainsboro
        ElseIf pages = 3 Then
            logBtn.FillColor = Color.Gainsboro
        ElseIf pages = 4 Then
            itemsBtn.FillColor = Color.Gainsboro
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
    End Function
    Private Sub editModeBtn_Click(sender As Object, e As EventArgs) Handles editModeBtn.Click
        If editmode = False Then
            editmode = True
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
            Dim rowIndex As Integer = e.RowIndex
            Dim columnIndex As Integer = e.ColumnIndex
            Dim columnName As String = barangDgv.Columns(columnIndex).Name
            Dim newValue As String = barangDgv.Rows(rowIndex).Cells(columnIndex).Value.ToString()
            Dim id As String = barangDgv.Rows(rowIndex).Cells(9).Value.ToString()
            editBarang(columnIndex, newValue, id)
        End If
    End Sub

End Class