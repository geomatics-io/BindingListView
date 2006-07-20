<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleForm
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
        Me.filterTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.itemsGrid = New System.Windows.Forms.DataGridView
        CType(Me.itemsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'filterTextBox
        '
        Me.filterTextBox.Location = New System.Drawing.Point(136, 46)
        Me.filterTextBox.Name = "filterTextBox"
        Me.filterTextBox.Size = New System.Drawing.Size(100, 21)
        Me.filterTextBox.TabIndex = 7
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(118, 13)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Filter the items by title:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(218, 26)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Below is a list of RSS feed items." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can click on the column headers to sort."
        '
        'itemsGrid
        '
        Me.itemsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.itemsGrid.Location = New System.Drawing.Point(12, 73)
        Me.itemsGrid.Name = "itemsGrid"
        Me.itemsGrid.RowTemplate.Height = 23
        Me.itemsGrid.Size = New System.Drawing.Size(469, 347)
        Me.itemsGrid.TabIndex = 4
        '
        'SimpleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 430)
        Me.Controls.Add(Me.filterTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.itemsGrid)
        Me.Name = "SimpleForm"
        Me.Text = "SimpleForm"
        CType(Me.itemsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents filterTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents itemsGrid As System.Windows.Forms.DataGridView
End Class
