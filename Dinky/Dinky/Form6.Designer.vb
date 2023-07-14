<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Label2 = New Label()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        Label3 = New Label()
        TextBox2 = New TextBox()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(486, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(302, 27)
        Label2.TabIndex = 4
        Label2.Text = "BLOOD BANK BY GROUP 10"' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(285, 112)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(152, 27)
        TextBox1.TabIndex = 5
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(440, 392)
        Button1.Name = "Button1"
        Button1.Size = New Size(167, 46)
        Button1.TabIndex = 6
        Button1.Text = "Recieved"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(52, 109)
        Label1.Name = "Label1"
        Label1.Size = New Size(214, 27)
        Label1.TabIndex = 7
        Label1.Text = "Enter Blood Group "' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(71, 170)
        Label3.Name = "Label3"
        Label3.Size = New Size(166, 27)
        Label3.TabIndex = 8
        Label3.Text = "Enter Quantity"' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(285, 173)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(152, 27)
        TextBox2.TabIndex = 9
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.Location = New Point(621, 392)
        Button2.Name = "Button2"
        Button2.Size = New Size(167, 46)
        Button2.TabIndex = 10
        Button2.Text = "Back"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Form6
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
        Name = "Form6"
        Text = "Form6"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button2 As Button
End Class
