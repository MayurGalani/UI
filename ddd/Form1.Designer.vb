<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Button1 = New Button()
        TextBox1 = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBox2 = New TextBox()
        ErrorProvider1 = New ErrorProvider(components)
        CType(ErrorProvider1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(309, 329)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 0
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(220, 147)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(183, 27)
        TextBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        Label1.Location = New Point(257, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(146, 31)
        Label1.TabIndex = 2
        Label1.Text = "Login Portal"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(66, 147)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 20)
        Label2.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(66, 147)
        Label3.Name = "Label3"
        Label3.Size = New Size(133, 21)
        Label3.TabIndex = 5
        Label3.Text = "Enter Gamil ID"' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(66, 216)
        Label4.Name = "Label4"
        Label4.Size = New Size(140, 21)
        Label4.TabIndex = 6
        Label4.Text = "Enter Password"' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(220, 210)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(183, 27)
        TextBox2.TabIndex = 7
        ' 
        ' ErrorProvider1
        ' 
        ErrorProvider1.ContainerControl = Me
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TextBox2)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBox1)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        CType(ErrorProvider1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
