Imports MySql.Data.MySqlClient

Module dbMode
    Public conn As MySqlConnection = Nothing

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
