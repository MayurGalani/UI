Imports System.Security.Principal

Public Class Home



    Private Sub pictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()

    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MilkDiaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MilkDiaryToolStripMenuItem.Click
        MilkDiary.ShowDialog()
    End Sub

    Private Sub SearchMilkDiaryRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchMilkDiaryRecordToolStripMenuItem.Click
        SearchMilkDiary.ShowDialog()
    End Sub
End Class