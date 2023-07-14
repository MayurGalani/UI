Imports System.Data.SqlClient

Friend Class SqlDataAdapter
    Private com As SqlCommand

    Public Sub New(com As SqlCommand)
        Me.com = com
    End Sub

    Friend Sub Fill(dt As DataTable)
        Throw New NotImplementedException()
    End Sub
End Class
