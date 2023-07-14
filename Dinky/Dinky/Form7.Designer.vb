<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        components = New ComponentModel.Container()
        Button2 = New Button()
        TextBox2 = New TextBox()
        Label3 = New Label()
        Label1 = New Label()
        Button1 = New Button()
        TextBox1 = New TextBox()
        Label2 = New Label()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.Location = New Point(601, 394)
        Button2.Name = "Button2"
        Button2.Size = New Size(167, 46)
        Button2.TabIndex = 17
        Button2.Text = "Back"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(265, 175)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(152, 27)
        TextBox2.TabIndex = 16
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(51, 172)
        Label3.Name = "Label3"
        Label3.Size = New Size(166, 27)
        Label3.TabIndex = 15
        Label3.Text = "Enter Quantity"' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(32, 111)
        Label1.Name = "Label1"
        Label1.Size = New Size(214, 27)
        Label1.TabIndex = 14
        Label1.Text = "Enter Blood Group "' 
        ' Button1
        ' 
        Button1.Font = New Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(420, 394)
        Button1.Name = "Button1"
        Button1.Size = New Size(167, 46)
        Button1.TabIndex = 13
        Button1.Text = "Donated"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(265, 114)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(152, 27)
        TextBox1.TabIndex = 12
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(466, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(302, 27)
        Label2.TabIndex = 11
        Label2.Text = "BLOOD BANK BY GROUP 10"' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Name = "Form7"
        Text = "Form7"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
End Class
