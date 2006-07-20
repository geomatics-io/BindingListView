Imports Equin.ApplicationFramework

Public Class AggregateForm
    Private itemsView As AggregateBindingListView(Of Item)

    Public Sub New()

        InitializeComponent()

        itemsView = New AggregateBindingListView(Of Item)()

        LoadFeeds()

        itemsGrid.DataSource = itemsView
    End Sub

    Private Sub LoadFeeds()

        Dim urls As String() = { _
            "http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/front_page/rss.xml", _
            "http://channel9.msdn.com/rss.aspx", _
            "http://msdn.microsoft.com/rss.xml" _
        }

        For Each url As String In urls

            Dim feed As New Feed(url)
            feed.Update()

            ' Add to the list box so we can check/uncheck the feed
            feedsListBox.Items.Add(feed)
        Next
    End Sub

    Private Sub feedsListBox_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles feedsListBox.ItemCheck
        ' Get the checked/unchecked feed
        Dim feed As Feed = DirectCast(feedsListBox.Items(e.Index), Feed)

        If e.NewValue = CheckState.Checked Then
            ' Add the checked feed's items to the aggregate list
            itemsView.SourceLists.Add(feed.Items)
        Else
            ' Remove the checked feed's items from the aggregate list
            itemsView.SourceLists.Remove(feed.Items)
        End If
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