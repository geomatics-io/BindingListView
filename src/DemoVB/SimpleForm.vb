Imports Equin.ApplicationFramework

Public Class SimpleForm
    Private itemsView As BindingListView(Of Item)

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadFeed()
    End Sub

    Private Sub LoadFeed()

        ' Get the BBC news RSS feed
        Dim feed As New Feed("http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/front_page/rss.xml")
        feed.Update()

        ' Create a view of the items
        itemsView = New BindingListView(Of Item)(feed.Items)
        ' Make the grid display this view
        itemsGrid.DataSource = itemsView
    End Sub

    Private Sub filterTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles filterTextBox.TextChanged

        ' Change the filter of the view.
        itemsView.Filter = New ItemFilter(filterTextBox.Text)
    End Sub

    Private Class ItemFilter
        Implements IItemFilter(Of Item)

        Private _title As String

        Public Sub New(ByVal title As String)
            _title = title.ToLower()
        End Sub

        Public Function Include(ByVal item As Item) As Boolean Implements Equin.ApplicationFramework.IItemFilter(Of Item).Include
            Return item.Title.ToLower().Contains(_title)
        End Function
    End Class

End Class