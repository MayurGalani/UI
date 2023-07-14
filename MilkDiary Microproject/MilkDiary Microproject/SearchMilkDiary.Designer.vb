
Imports System.ComponentModel

Partial Class SearchMilkDiary
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
        components = New Container()
        DataGridView1 = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        Column7 = New DataGridViewTextBoxColumn()
        Column8 = New DataGridViewTextBoxColumn()
        Column9 = New DataGridViewTextBoxColumn()
        DataSet1 = New MilkDiary_Microproject.DataSet1()
        BindingSource1 = New BindingSource(components)
        Label1 = New Label()
        TableAdapterManager1 = New MilkDiary_Microproject.DataSet1TableAdapters.TableAdapterManager()
        DairyTableAdapter1 = New MilkDiary_Microproject.DataSet1TableAdapters.dairyTableAdapter()
        CType(DataGridView1, ISupportInitialize).BeginInit()
        CType(DataSet1, ISupportInitialize).BeginInit()
        CType(BindingSource1, ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9})
        DataGridView1.Location = New Point(-1, 204)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 29
        DataGridView1.Size = New Size(810, 188)
        DataGridView1.TabIndex = 0
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "id"
        Column1.MinimumWidth = 6
        Column1.Name = "Column1"
        Column1.Width = 125
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "acnt_no"
        Column2.MinimumWidth = 6
        Column2.Name = "Column2"
        Column2.Width = 125
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "name"
        Column3.MinimumWidth = 6
        Column3.Name = "Column3"
        Column3.Width = 125
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "addr"
        Column4.MinimumWidth = 6
        Column4.Name = "Column4"
        Column4.Width = 125
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "d_no "
        Column5.MinimumWidth = 6
        Column5.Name = "Column5"
        Column5.Width = 125
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "liter"
        Column6.MinimumWidth = 6
        Column6.Name = "Column6"
        Column6.Width = 125
        ' 
        ' Column7
        ' 
        Column7.HeaderText = "fate"
        Column7.MinimumWidth = 6
        Column7.Name = "Column7"
        Column7.Width = 125
        ' 
        ' Column8
        ' 
        Column8.HeaderText = "pperl"
        Column8.MinimumWidth = 6
        Column8.Name = "Column8"
        Column8.Width = 125
        ' 
        ' Column9
        ' 
        Column9.HeaderText = "total"
        Column9.MinimumWidth = 6
        Column9.Name = "Column9"
        Column9.Width = 125
        ' 
        ' DataSet1
        ' 
        DataSet1.DataSetName = "DataSet1"
        DataSet1.Namespace = "http://tempuri.org/DataSet1.xsd"
        DataSet1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
        ' 
        ' BindingSource1
        ' 
        BindingSource1.DataSource = DataSet1
        BindingSource1.Position = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(326, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(124, 20)
        Label1.TabIndex = 1
        Label1.Text = "Search Milk Diary"' 
        ' TableAdapterManager1
        ' 
        TableAdapterManager1.BackupDataSetBeforeUpdate = False
        TableAdapterManager1.dairyTableAdapter = DairyTableAdapter1
        TableAdapterManager1.UpdateOrder = MilkDiary_Microproject.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        ' 
        ' DairyTableAdapter1
        ' 
        DairyTableAdapter1.ClearBeforeFill = True
        ' 
        ' SearchMilkDiary
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Name = "SearchMilkDiary"
        Text = "SearchMilkDiary"
        CType(DataGridView1, ISupportInitialize).EndInit()
        CType(DataSet1, ISupportInitialize).EndInit()
        CType(BindingSource1, ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents DataSet1 As MilkDiary_Microproject.DataSet1
    Friend WithEvents DataSet11 As MilkDiary_Microproject.DataSet1

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents TableAdapterManager1 As MilkDiary_Microproject.DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents DairyTableAdapter1 As MilkDiary_Microproject.DataSet1TableAdapters.dairyTableAdapter
End Class
