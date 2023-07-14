<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MilkDiary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        TextBox5 = New TextBox()
        TextBox6 = New TextBox()
        TextBox7 = New TextBox()
        TextBox8 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(359, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 20)
        Label1.TabIndex = 0
        Label1.Text = "Milk Diary"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(100, 76)
        Label2.Name = "Label2"
        Label2.Size = New Size(121, 20)
        Label2.TabIndex = 1
        Label2.Text = "Account Number"' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(100, 118)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 20)
        Label3.TabIndex = 2
        Label3.Text = "Name"' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(100, 167)
        Label4.Name = "Label4"
        Label4.Size = New Size(62, 20)
        Label4.TabIndex = 3
        Label4.Text = "Address"' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(100, 215)
        Label5.Name = "Label5"
        Label5.Size = New Size(99, 20)
        Label5.TabIndex = 4
        Label5.Text = "Diary number"' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(100, 262)
        Label6.Name = "Label6"
        Label6.Size = New Size(38, 20)
        Label6.TabIndex = 5
        Label6.Text = "Liter"' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(100, 301)
        Label7.Name = "Label7"
        Label7.Size = New Size(36, 20)
        Label7.TabIndex = 6
        Label7.Text = "Fate"' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(100, 342)
        Label8.Name = "Label8"
        Label8.Size = New Size(73, 20)
        Label8.TabIndex = 7
        Label8.Text = "Price/liter"' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(100, 385)
        Label9.Name = "Label9"
        Label9.Size = New Size(42, 20)
        Label9.TabIndex = 8
        Label9.Text = "Total"' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(283, 76)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(125, 27)
        TextBox1.TabIndex = 9
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(283, 118)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(125, 27)
        TextBox2.TabIndex = 10
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(283, 167)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(125, 27)
        TextBox3.TabIndex = 11
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(283, 215)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(125, 27)
        TextBox4.TabIndex = 12
        ' 
        ' TextBox5
        ' 
        TextBox5.Location = New Point(283, 262)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(125, 27)
        TextBox5.TabIndex = 13
        ' 
        ' TextBox6
        ' 
        TextBox6.Location = New Point(283, 298)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(125, 27)
        TextBox6.TabIndex = 14
        ' 
        ' TextBox7
        ' 
        TextBox7.Location = New Point(283, 339)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(125, 27)
        TextBox7.TabIndex = 15
        ' 
        ' TextBox8
        ' 
        TextBox8.Location = New Point(283, 378)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(125, 27)
        TextBox8.TabIndex = 16
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(469, 158)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 17
        Button1.Text = "Add"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(469, 253)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 18
        Button2.Text = "Reset"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' MilkDiary
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox8)
        Controls.Add(TextBox7)
        Controls.Add(TextBox6)
        Controls.Add(TextBox5)
        Controls.Add(TextBox4)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "MilkDiary"
        Text = "MilkDiary"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
