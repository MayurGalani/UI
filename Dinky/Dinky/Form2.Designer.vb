<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        TextBox1 = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBox2 = New TextBox()
        ErrorProvider1 = New ErrorProvider(components)
        CType(ErrorProvider1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(191, 113)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(170, 27)
        TextBox1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Button1.Location = New Point(221, 241)
        Button1.Name = "Button1"
        Button1.Size = New Size(159, 37)
        Button1.TabIndex = 1
        Button1.Text = "LOGIN"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label1.Location = New Point(221, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 27)
        Label1.TabIndex = 2
        Label1.Text = "Login Portal"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(486, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(302, 27)
        Label2.TabIndex = 3
        Label2.Text = "BLOOD BANK BY GROUP 10"' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(36, 113)
        Label3.Name = "Label3"
        Label3.Size = New Size(103, 27)
        Label3.TabIndex = 4
        Label3.Text = "Email-ID"' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(36, 183)
        Label4.Name = "Label4"
        Label4.Size = New Size(114, 27)
        Label4.TabIndex = 5
        Label4.Text = "Password"' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(191, 183)
        TextBox2.Name = "TextBox2"
        TextBox2.PasswordChar = "*"c
        TextBox2.Size = New Size(170, 27)
        TextBox2.TabIndex = 6
        ' 
        ' ErrorProvider1
        ' 
        ErrorProvider1.ContainerControl = Me
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        ClientSize = New Size(800, 450)
        Controls.Add(TextBox2)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Name = "Form2"
        Text = "Form2"
        CType(ErrorProvider1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
