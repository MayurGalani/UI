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
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.Location = New Point(144, 133)
        Button1.Name = "Button1"
        Button1.Size = New Size(141, 45)
        Button1.TabIndex = 0
        Button1.Text = "Add Donor"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.Location = New Point(499, 133)
        Button2.Name = "Button2"
        Button2.Size = New Size(141, 45)
        Button2.TabIndex = 1
        Button2.Text = "View Donor"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Button3.Location = New Point(144, 317)
        Button3.Name = "Button3"
        Button3.Size = New Size(141, 56)
        Button3.TabIndex = 2
        Button3.Text = "Add Recepient"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Button4.Location = New Point(499, 317)
        Button4.Name = "Button4"
        Button4.Size = New Size(141, 54)
        Button4.TabIndex = 3
        Button4.Text = "View Recepient"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
