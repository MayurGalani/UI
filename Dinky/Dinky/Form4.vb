Public Class Form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form3.Show()
    End Sub
    Private Sub TextBox2_leave(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = " " Then
            ErrorProvider1.SetError(TextBox2, "Please Enter Name")
            TextBox2.Focus()
        Else
            If IsNumeric(TextBox2.Text) Then
                ErrorProvider1.SetError(TextBox2, "Name Contains Alphabets and Special Charaters!")
                Dim n As Boolean
                n = True
            End If
        End If
    End Sub
    Private Sub TextBox3_leave(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = " " Then
            ErrorProvider1.SetError(TextBox3, "Please Enter Gender")
            TextBox3.Focus()
        Else
            Dim g As String
            g = TextBox3.Text()
            If (g <> "male") And (g <> "female") Then
                ErrorProvider1.SetError(TextBox3, "Enter Valid Gender")
                g = True
            End If
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim exp As New System.Text.RegularExpressions.Regex("\d{10}")
        If exp.IsMatch(CType(sender, TextBox).Text) Then
            ErrorProvider1.SetError(sender, "")
            Dim m As Boolean
            m = True
        Else
            ErrorProvider1.SetError(sender, " Enter Digits Only ")
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim exp As New System.Text.RegularExpressions.Regex("\S+@\S+\.\S")
        If exp.IsMatch(CType(sender, TextBox).Text) Then
            ErrorProvider1.SetError(sender, "")
            Dim em As Boolean
            em = True
        Else
            ErrorProvider1.SetError(sender, "Enter Correct Gmail")
            TextBox5.Focus()
        End If
    End Sub
End Class