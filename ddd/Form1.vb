Imports System.ComponentModel.DataAnnotations
Imports System.Diagnostics.Eventing.Reader

Public Class Form1
    Dim em As Boolean

    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    'Dim exp As New System.Text.RegularExpressions.Regex("\S+@\S+\.\S")
    'If exp.IsMatch(CType(sender, TextBox).Text) Then
    '       em = True
    'Else
    '       ErrorProvider1.SetError(sender, "Enter Correct Gmail")
    '      TextBox1.Focus()
    'End If
    '
    '  End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        Form2.Show()
    End Sub
End Class
