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
        itemsView.ApplyFilter(AddressOf TitleFilter)
    End Sub

    Private Function TitleFilter(ByVal item As Item) As Boolean
        Return item.Title.ToLower().Contains(filterTextBox.Text.ToLower())
    End Function

End Class