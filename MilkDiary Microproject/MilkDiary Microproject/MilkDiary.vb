Imports System.Data.SqlClient

Public Class MilkDiary
    Private con As SqlConnection
    Dim com As SqlCommand
    Dim str As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connectionString As String = "Data Source=mayur\sqlexpress;Initial Catalog=MilkDB;Integrated Security=True"
        Dim connection As New SqlConnection(connectionString)
        con = connection
        con.Open()
        str = "INSERT INTO dairy (acnt_no, name, addr, d_no, liter, fate, pperl, total) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "')"
        com = New SqlCommand(str, con)
        com.ExecuteNonQuery()
        Dim msgBoxResult = MsgBox("Dairy Milk Details Inserted Successfully..")
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox1.Text = ""
        Hide()
        con.Close()

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub MilkDiary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
