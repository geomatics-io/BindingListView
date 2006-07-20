Imports System.ComponentModel
Imports System.Xml

Public Class Feed

    Private _url As String
    Private _items As BindingList(Of Item)
    Private _title As String

    Public Sub New(ByVal url As String)
        _url = url
        _items = New BindingList(Of Item)
    End Sub

    Public Sub Update()
        Dim doc As New XmlDocument()
        doc.Load(_url)

        _title = doc.SelectSingleNode("/rss/channel/title").InnerText

        For Each node As XmlNode In doc.SelectNodes("//item")

            Dim item As New Item()
            item.Title = node("title").InnerText
            item.Description = node("description").InnerText
            item.PubDate = DateTime.Parse(node("pubDate").InnerText)
            Items.Add(Item)
        Next
    End Sub

    Public ReadOnly Property Items() As BindingList(Of Item)
        Get
            Return _items
        End Get
    End Property

    Public Overrides Function ToString() As String
        If _title Is Nothing Then
            Return _url
        Else
            Return _title
        End If
    End Function
End Class
