using System.ComponentModel;
using Equin.ApplicationFramework;

namespace BindingListViewTest
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var form = new Form1())
            {
                Console.WriteLine("Form1 constructed (grid bound to BindingListView<IModelView>): ok");

                // DataGridView defers auto-column-generation until its window handle
                // exists, which normally happens when the form becomes visible.
                // Force that here without actually showing a window.
                form.CreateControl();
                _ = form.Grid.Handle;

                Console.WriteLine("Columns: " + string.Join(", ", form.Grid.Columns.Cast<DataGridViewColumn>().Select(c => c.Name)));

                Console.WriteLine();
                Console.WriteLine("--- Simulating a header click on each column via DataGridView.Sort(column, direction) ---");
                Console.WriteLine("(this is the exact public method a real header click invokes internally)");
                foreach (DataGridViewColumn column in form.Grid.Columns)
                {
                    try
                    {
                        form.Grid.Sort(column, ListSortDirection.Ascending);
                        Console.WriteLine($"Sort by \"{column.Name}\": ok");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Sort by \"{column.Name}\": ERROR - {ex}");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- AmbiguousMatchException repro: uninitialized Guid[] guids property on Model ---");
            try
            {
                var itemsWithGuids = new List<Model>
                {
                    new() { Id = 0, Name = "0" }, // guids left null
                    new() { Id = 1, Name = "1", guids = new[] { Guid.NewGuid(), Guid.NewGuid() } },
                    new() { Id = 2, Name = "2", guids = Array.Empty<Guid>() },
                };
                var source2 = new BindingListView<IModelView>(itemsWithGuids);
                Console.WriteLine("Construction with mixed null/populated/empty guids[]: ok, count=" + source2.Count);
                for (int i = 0; i < source2.Count; i++)
                {
                    var guidsView = source2[i].GetProvidedView("guidsView") as BindingListView<Guid>;
                    Console.WriteLine($"  item {i}: guidsView count=" + (guidsView == null ? "null (no view)" : guidsView.Count.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex);
            }

            Console.WriteLine();
            Console.WriteLine("--- \"the exception will be thrown if you un-comment the last line\" (source.ApplySort(\"Name\") during construction) ---");
            using (var form2 = new Form1())
            {
                try
                {
                    form2.Source.ApplySort("Name");
                    Console.WriteLine("source.ApplySort(\"Name\"): ok");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("source.ApplySort(\"Name\"): ERROR - " + ex);
                }
            }
        }
    }
}
