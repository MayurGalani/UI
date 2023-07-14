Public Class Form7
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MessageBox.Show("Stock Updated!!")
        Me.Hide()
        Form8.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim text As String = Label1.Text
        Label1.Text = text.Substring(1) & text(0)
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class