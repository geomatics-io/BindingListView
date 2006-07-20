<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AggregateForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.label3 = New System.Windows.Forms.Label
        Me.filterTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.itemsGrid = New System.Windows.Forms.DataGridView
        Me.label1 = New System.Windows.Forms.Label
        Me.feedsListBox = New System.Windows.Forms.CheckedListBox
        CType(Me.itemsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(345, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(212, 48)
        Me.label3.TabIndex = 11
        Me.label3.Text = "You can still sort the columns - but now the sort is across all the items from ch" & _
            "ecked feeds."
        '
        'filterTextBox
        '
        Me.filterTextBox.Location = New System.Drawing.Point(422, 25)
        Me.filterTextBox.Name = "filterTextBox"
        Me.filterTextBox.Size = New System.Drawing.Size(135, 21)
        Me.filterTextBox.TabIndex = 10
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(345, 28)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(71, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Filter by title:"
        '
        'itemsGrid
        '
        Me.itemsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.itemsGrid.Location = New System.Drawing.Point(15, 115)
        Me.itemsGrid.Name = "itemsGrid"
        Me.itemsGrid.RowTemplate.Height = 23
        Me.itemsGrid.Size = New System.Drawing.Size(542, 243)
        Me.itemsGrid.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(186, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Check the feeds you want to display."
        '
        'feedsListBox
        '
        Me.feedsListBox.CheckOnClick = True
        Me.feedsListBox.FormattingEnabled = True
        Me.feedsListBox.Location = New System.Drawing.Point(15, 25)
        Me.feedsListBox.Name = "feedsListBox"
        Me.feedsListBox.Size = New System.Drawing.Size(324, 84)
        Me.feedsListBox.TabIndex = 6
        '
        'AggregateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 370)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.filterTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.itemsGrid)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.feedsListBox)
        Me.Name = "AggregateForm"
        Me.Text = "Aggregate List View"
        CType(Me.itemsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents filterTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents itemsGrid As System.Windows.Forms.DataGridView
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents feedsListBox As System.Windows.Forms.CheckedListBox
End Class
