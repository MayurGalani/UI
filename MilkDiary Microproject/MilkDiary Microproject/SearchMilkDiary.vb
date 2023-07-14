Imports System.Data.SqlClient

Public Class SearchMilkDiary
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim gen As String
    Dim str As String
    Dim getuser As String
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dv As DataView
    Dim addmilk As Object
    Public Property DairyDataSet1 As Object

    Private Sub SearchMilkDiary_Load(sender As Object, e As EventArgs, con As SqlConnection) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DairyDataSet2.dairy' table. You can move, or remove it, as needed.

        Me.DairyTableAdapter1.Fill(Me.DairyDataSet1.dairy)
        Using con = New SqlConnection("Data Source=mayur\sqlexpress;Initial Catalog=MilkDB;Integrated Security=True")

            con.Open()
            str = "select * from dairy"
            com = New SqlCommand(str, con)
            da = New SqlDataAdapter(com)
            dt = New DataTable()
            dv = New DataView()
            da.Fill(dt)
            DataGridView1.DataSource = New BindingSource(dt, addmilk)
        End Using


    End Sub

    Private Sub SearchMilkDiary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class


