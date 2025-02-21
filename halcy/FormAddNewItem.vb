Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class FormAddNewItem
    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal dwAttribute As Integer, ByRef pvAttribute As Integer, ByVal cbAttribute As Integer) As Integer
    End Function
    Private Sub FormAddNewItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.OSVersion.Version.Major >= 10 Then
            DwmSetWindowAttribute(Me.Handle, 33, 2, Marshal.SizeOf(2))
            DwmSetWindowAttribute(Me.Handle, 38, 1, Marshal.SizeOf(1))
        End If
    End Sub

    Private Function isAllFieldDone() As Boolean
        If pswTxt.TextLength > 0 AndAlso buyPricetxt.TextLength > 0 AndAlso nameTxt.TextLength > 0 AndAlso sellPriceTxt.TextLength > 0 AndAlso StockTxt.TextLength > 0 AndAlso buyPricetxt.TextLength > 0 AndAlso unitCmb.SelectedIndex >= 0 AndAlso roleCmb.SelectedIndex >= 0 Then
            addBtn.Enabled = True
            Return True
        End If
        addBtn.Enabled = False
        Return False
    End Function

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Dispose()
    End Sub

    Sub loadCategory()
        Try
            Dim cmd As New MySqlCommand("SELECT ctg FROM category", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            roleCmb.Items.Clear() ' Bersihin dulu biar ga dobel

            While reader.Read()
                roleCmb.Items.Add(reader("ctg").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Sub LoadUnits()

        Try
            Dim cmd As New MySqlCommand("SELECT unit FROM units", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            unitCmb.Items.Clear() ' Bersihin dulu biar ga dobel

            While reader.Read()
                unitCmb.Items.Add(reader("unit").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub FormAddNewItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadUnits()
        loadCategory()
        nameTxt.Focus()
    End Sub

    Private Sub nameTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nameTxt.KeyPress
        If e.KeyChar = Chr(13) Then
            pswTxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub codeTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pswTxt.KeyPress, sellPriceTxt.KeyPress
        If e.KeyChar = Chr(13) Then
            roleCmb.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub categoryCmb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles roleCmb.KeyPress, unitCmb.KeyPress
        If e.KeyChar = Chr(13) Then
            unitCmb.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub StockTxt_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            buyPricetxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub minStockTxt_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            addBtn.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub sellTxt_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            StockTxt.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub buyTxt_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            sellPriceTxt.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub unitCmb_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            buyPricetxt.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub unitCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles roleCmb.SelectedIndexChanged, unitCmb.SelectedIndexChanged
        isAllFieldDone()
    End Sub

    Private Sub TextChangedx(sender As Object, e As EventArgs) Handles nameTxt.TextChanged, pswTxt.TextChanged, sellPriceTxt.TextChanged
        isAllFieldDone()
    End Sub

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        If isAllFieldDone() = True Then
            Dim qry = $"INSERT INTO barang (barcode, name, category, unit, buy_price, sell_price, stock, min_stock) VALUES ('{pswTxt.Text}', '{nameTxt.Text}', '{roleCmb.SelectedItem.ToString()}','{unitCmb.SelectedItem.ToString()}' ,'{buyPricetxt.Text}', '{sellPriceTxt.Text}', '{StockTxt.Text}', '{buyPricetxt.Text}')"
            Clipboard.SetText(qry)
            Try
                Dim cmd As New MySqlCommand(qry, conn)
                cmd.ExecuteNonQuery()
                addLog(1, nameTxt.Text)
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If
    End Sub
End Class