Imports Equin.ApplicationFramework

Module Module1

    Sub Main()

        Dim list As New List(Of Foo)
        For i As Integer = 1 To 20000
            list.Add(New Foo())
        Next

        Dim sw As New Stopwatch()

        sw.Start()
        Dim view As New BindingListView(Of Foo)(list)
        sw.Stop()
        Console.WriteLine("Creating BL view " & sw.ElapsedMilliseconds)

        sw.Reset()
        sw.Start()
        'view.ApplySort(New FooComparer())
        'view.Sort = "A"
        view.ApplySort(AddressOf AComp)
        sw.Stop()
        Console.WriteLine("Sorted BLV " & sw.ElapsedMilliseconds)

        sw.Reset()

        Dim dataTable As New DataTable
        dataTable.Columns.Add("A", GetType(Integer))
        dataTable.Columns.Add("B", GetType(String))
        For i As Integer = 0 To 19999
            Dim row As DataRow = dataTable.NewRow()
            row(0) = list(i).A
            row(1) = list(i).B
            dataTable.Rows.Add(row)
        Next

        sw.Start()
        dataTable.DefaultView.Sort = "A"
        sw.Stop()
        Console.WriteLine("sorting data table view " & sw.ElapsedMilliseconds)

        Console.ReadLine()
    End Sub

    Function AComp(ByVal x As Foo, ByVal y As Foo) As Integer
        Return x.A.CompareTo(y.A)
    End Function

    Class FooComparer
        Implements IComparer(Of Foo)

        Public Function Compare(ByVal x As Foo, ByVal y As Foo) As Integer Implements System.Collections.Generic.IComparer(Of Foo).Compare
            Return x.A.CompareTo(x.B)
        End Function
    End Class

    Class Foo

        Private _a As Integer
        Private _b As String

        Public Sub New()
            Dim r As New Random()
            _a = r.Next(0, 100)
            _b = r.Next(100, 1000).ToString()
        End Sub

        Public Property A() As Integer
            Get
                Return _a
            End Get
            Set(ByVal value As Integer)
                _a = value
            End Set
        End Property

        Public Property B() As String
            Get
                Return _b
            End Get
            Set(ByVal value As String)
                _b = value
            End Set
        End Property

    End Class

End Module
