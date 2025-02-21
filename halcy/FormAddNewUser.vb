Imports System.Runtime.InteropServices
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
End Class