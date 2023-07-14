<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Home))
        MenuStrip1 = New MenuStrip()
        MilkDiaryToolStripMenuItem = New ToolStripMenuItem()
        SetFatePriceToolStripMenuItem = New ToolStripMenuItem()
        SearchAccountToolStripMenuItem = New ToolStripMenuItem()
        SearchMilkDiaryRecordToolStripMenuItem = New ToolStripMenuItem()
        NewAccountToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        PictureBox1 = New PictureBox()
        MenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {MilkDiaryToolStripMenuItem, SetFatePriceToolStripMenuItem, SearchAccountToolStripMenuItem, SearchMilkDiaryRecordToolStripMenuItem, NewAccountToolStripMenuItem, ExitToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(736, 51)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"' 
        ' MilkDiaryToolStripMenuItem
        ' 
        MilkDiaryToolStripMenuItem.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        MilkDiaryToolStripMenuItem.Image = CType(resources.GetObject("MilkDiaryToolStripMenuItem.Image"), Image)
        MilkDiaryToolStripMenuItem.Name = "MilkDiaryToolStripMenuItem"
        MilkDiaryToolStripMenuItem.Size = New Size(109, 47)
        MilkDiaryToolStripMenuItem.Text = "Milk Diary"
        MilkDiaryToolStripMenuItem.TextImageRelation = TextImageRelation.TextAboveImage
        ' 
        ' SetFatePriceToolStripMenuItem
        ' 
        SetFatePriceToolStripMenuItem.Image = CType(resources.GetObject("SetFatePriceToolStripMenuItem.Image"), Image)
        SetFatePriceToolStripMenuItem.Name = "SetFatePriceToolStripMenuItem"
        SetFatePriceToolStripMenuItem.Size = New Size(111, 47)
        SetFatePriceToolStripMenuItem.Text = "Set Fate Price"
        SetFatePriceToolStripMenuItem.TextImageRelation = TextImageRelation.TextAboveImage
        ' 
        ' SearchAccountToolStripMenuItem
        ' 
        SearchAccountToolStripMenuItem.Name = "SearchAccountToolStripMenuItem"
        SearchAccountToolStripMenuItem.Size = New Size(125, 47)
        SearchAccountToolStripMenuItem.Text = "Search Account"' 
        ' SearchMilkDiaryRecordToolStripMenuItem
        ' 
        SearchMilkDiaryRecordToolStripMenuItem.Name = "SearchMilkDiaryRecordToolStripMenuItem"
        SearchMilkDiaryRecordToolStripMenuItem.Size = New Size(189, 47)
        SearchMilkDiaryRecordToolStripMenuItem.Text = "Search Milk Diary Record"' 
        ' NewAccountToolStripMenuItem
        ' 
        NewAccountToolStripMenuItem.Name = "NewAccountToolStripMenuItem"
        NewAccountToolStripMenuItem.Size = New Size(111, 47)
        NewAccountToolStripMenuItem.Text = "New Account"' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(47, 47)
        ExitToolStripMenuItem.Text = "Exit"' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(231, 129)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(167, 157)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(736, 423)
        Controls.Add(PictureBox1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Home"
        Text = "Home"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MilkDiaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetFatePriceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchAccountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchMilkDiaryRecordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewAccountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
