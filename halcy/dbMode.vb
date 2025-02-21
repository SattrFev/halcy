Imports System.IO
Imports MySql.Data.MySqlClient

Module dbMode
    Public conn As MySqlConnection = Nothing
    Public userInfo(2) As String
    Public isloged As Boolean = False


    Function addLog(ByVal idx As Integer, Optional ByVal pholder As String = "") As Boolean
        Dim actions As String = "unspecified"
        Select Case idx
            Case 1
                actions = $"menambahkan barang {pholder} ke db"
            Case 2
                actions = $"menghapus barang {pholder} dari db"
            Case 3
                actions = "login"
            Case 4
                actions = $"mengedit barang {pholder}"
            Case 5
                actions = "logout"
        End Select

        actions = actions.Trim()

        Using newConn As New MySqlConnection(conn.ConnectionString & ";Password=1232;")

            Try
                newConn.Open()
                Dim cmd = New MySqlCommand($"INSERT INTO userlog (executor, actions) VALUES ('{userInfo(2)}', '{actions}')", newConn)
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
                Return False
            End Try
        End Using
    End Function



    Function isDbExist() As Boolean
        If conn.State = ConnectionState.Open Then
            Dim qrx As String = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @dbName"
            Using cmd As New MySqlCommand(qrx, conn)
                cmd.Parameters.AddWithValue("@dbName", "halcy")
                Dim ress As Object = cmd.ExecuteScalar()
                If ress IsNot Nothing Then
                    conn.ChangeDatabase("halcy")
                    Return True
                Else
                    Dim sqlPath As String = Application.StartupPath & "\halcy.sql"
                    Dim sqlCmd As String = File.ReadAllText(sqlPath)
                    Try
                        Using cmdx As New MySqlCommand(sqlCmd, conn)
                            cmdx.ExecuteNonQuery()
                            conn.ChangeDatabase("halcy")
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Execution Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            End Using
        Else
            MessageBox.Show("Database connection is not open!", "ERRROOROROROROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return False
    End Function



    Public Function connectDb(constrn As String, showEr As Boolean) As Boolean
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            MessageBox.Show("Theres an active connection!", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Try
            Dim constring As String = constrn
            conn = New MySqlConnection(constring)
            conn.Open()
            Return True
        Catch ex As Exception
            If showEr = True Then
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function disconnectDb() As Boolean
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            MessageBox.Show("Theres no connection alive!", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Try
            conn.Close()
            conn = Nothing
            Return True
        Catch ex As Exception
            MessageBox.Show("Disconneting Failed!" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Module
