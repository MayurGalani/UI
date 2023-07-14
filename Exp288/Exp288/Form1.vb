Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form30
    Dim con As SqlConnection = New SqlConnection("Data Source=MAYUR\SQLEXPRESS;Initial Catalog=exp28;Integrated Security=True")
    Dim q As SqlCommand
Dim a As New DataSet
Dim ad As SqlDataAdapter
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        q = New SqlCommand("select * from e28", con)
        ad = New SqlDataAdapter(q)
        ad.Fill(a, "e28")
        TextBox1.DataBindings.Add("text", a, "e28.sname")
        TextBox2.DataBindings.Add("text", a, "e28.clgname")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
Me.BindingContext(a, "e28").Position = 0
End Sub
Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
Me.BindingContext(a, "e28").Position += 1
End Sub
Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
Me.BindingContext(a, "e28").Position = Me.BindingContext(a, "e28").Count - 1
End Sub
Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
Me.BindingContext(a, "e28").Position -= 1
End Sub
End Class
