<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Button1 = New Button()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        Label2.Location = New Point(486, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(302, 27)
        Label2.TabIndex = 4
        Label2.Text = "BLOOD BANK BY GROUP 10"' 
        ' Button1
        ' 
        Button1.Font = New Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(113, 125)
        Button1.Name = "Button1"
        Button1.Size = New Size(215, 123)
        Button1.TabIndex = 5
        Button1.Text = "Add Donor"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.Location = New Point(486, 125)
        Button2.Name = "Button2"
        Button2.Size = New Size(196, 123)
        Button2.TabIndex = 6
        Button2.Text = "Add Recepient"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Name = "Form3"
        Text = "Form3"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
