Public Class Form2
    Dim em As Boolean
    Dim p As Boolean
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim exp As New System.Text.RegularExpressions.Regex("\S+@\S+\.\S")
        If exp.IsMatch(CType(sender, TextBox).Text) Then
            ErrorProvider1.SetError(sender, "")
            em = True
        Else
            ErrorProvider1.SetError(sender, "Enter Correct Gmail")
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (em = True) Then
            Me.Hide()
            Form3.Show()
        Else
            MessageBox.Show("Enter all Detials!")
        End If

    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class