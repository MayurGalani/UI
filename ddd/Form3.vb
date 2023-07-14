Imports System.Data.SqlClient
Imports System.ComponentModel.DataAnnotations.RegularExpressionAttribute
Public Class Form3
    Dim con As SqlConnection
    Dim query As SqlCommand
    Dim adp As SqlDataAdapter
    Dim ds As New DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con = New SqlConnection("Data Source=MAYUR\SQLEXPRESS;Integrated Security=True")
        con.Open()
        query = New SqlCommand("insert into donor1 values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox6.Text & "', '" & TextBox7.Text & "')", con)
        query.ExecuteNonQuery()
        MessageBox.Show("Added Successfully!")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Hide()
        Form2.Show()
    End Sub
    Dim n As Boolean
    'Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    'If TextBox2.Text = "" Then
    '       ErrorProvider1.SetError(sender, "Enter Name")
    '      TextBox2.Focus()
    'Else
    'If IsNumeric(TextBox2.Text) Then
    '           ErrorProvider1.SetError(TextBox2, " Name Contains Alphabets")
    '          n = True
    'End If
    'End If


    'End Sub
    'Dim g As String
    'Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
    '   g = TextBox3.Text
    'If TextBox3.Text = "" Then
    '       ErrorProvider1.SetError(sender, "Enter gender")
    '      TextBox3.Focus()
    'Else
    'If g <> "female" And g <> "male" Then
    '           ErrorProvider1.SetError(TextBox3, " Enter Valid Gender")
    '
    '  End If
    ' End If
    'End Sub
    'Dim mo As Boolean
    'Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
    '
    'Dim exp As New System.Text.RegularExpressions.Regex("\d{10}")
    'If exp.IsMatch(CType(sender, TextBox).Text) Then
    '       mo = True
    'Else
    '       ErrorProvider1.SetError(sender, "Enter Digits only!")
    '      TextBox6.Focus()
    'End If
    '
    'End Sub
End Class