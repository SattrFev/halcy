Imports System
Imports System.Security.Cryptography
Imports System.Text

Module EncryptionModule
    Private ReadOnly Key As String = "<+yTA;uB^f8Z5^/n"

    Function Encr(ByVal mode As String, ByVal input As String) As String
        If mode.ToLower() = "write" Then
            Return Encrypt(input)
        ElseIf mode.ToLower() = "read" Then
            Return Decrypt(input)
        Else
            Throw New ArgumentException("Mode harus 'write' atau 'read'")
        End If
    End Function

    Private Function Encrypt(ByVal plainText As String) As String
        Dim aes As New AesManaged()
        aes.Key = Encoding.UTF8.GetBytes(Key)
        aes.IV = Encoding.UTF8.GetBytes(Key)

        Dim encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)
        Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
        Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)

        Return Convert.ToBase64String(encryptedBytes)
    End Function

    Private Function Decrypt(ByVal encryptedText As String) As String
        Dim aes As New AesManaged()
        aes.Key = Encoding.UTF8.GetBytes(Key)
        aes.IV = Encoding.UTF8.GetBytes(Key)

        Dim decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)
        Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedText)
        Dim plainBytes As Byte() = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)

        Return Encoding.UTF8.GetString(plainBytes)
    End Function
End Module
