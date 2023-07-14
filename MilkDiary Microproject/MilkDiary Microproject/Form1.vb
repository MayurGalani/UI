Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "harsh" And TextBox2.Text = "Harsh" Then
            MessageBox.Show("Welcome Admin")


            TextBox1.Text = ""
            TextBox2.Text = ""
            Hide()
            Home.ShowDialog()

        Else
            MessageBox.Show("login fail")
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
