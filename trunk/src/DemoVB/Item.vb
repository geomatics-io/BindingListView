Public Class Item

    Private _title As String
    Private _description As String
    Private _pubDate As DateTime

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Public Property PubDate() As DateTime
        Get
            Return _pubDate
        End Get
        Set(ByVal value As DateTime)
            _pubDate = value
        End Set
    End Property

End Class
