using System;
using System.Collections.Generic;
using Equin.ApplicationFramework;

namespace Issue5Core
{
    public class Item
    {
        public int SortOrder { get; set; }
        public string Name { get; set; }
        public int? Nullable { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>
            {
                new Item { SortOrder = 3, Name = "c", Nullable = null },
                new Item { SortOrder = 1, Name = "a", Nullable = 5 },
                new Item { SortOrder = 2, Name = "b", Nullable = 1 },
            };

            var view = new BindingListView<Item>(items);

            try
            {
                view.ApplySort("SortOrder");
                Console.WriteLine("ApplySort(\"SortOrder\") ok");
                foreach (var item in view)
                {
                    Console.WriteLine("  " + item.SortOrder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ApplySort(\"SortOrder\"): ERROR - " + ex);
            }

            try
            {
                view.ApplySort("Name");
                Console.WriteLine("ApplySort(\"Name\") ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ApplySort(\"Name\"): ERROR - " + ex);
            }

            try
            {
                view.ApplySort("SortOrder DESC");
                Console.WriteLine("ApplySort(\"SortOrder DESC\") ok");
                foreach (var item in view)
                {
                    Console.WriteLine("  " + item.SortOrder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ApplySort(\"SortOrder DESC\"): ERROR - " + ex);
            }

            try
            {
                view.ApplySort("Nullable");
                Console.WriteLine("ApplySort(\"Nullable\") ok");
                foreach (var item in view)
                {
                    Console.WriteLine("  " + (item.Nullable.HasValue ? item.Nullable.Value.ToString() : "null"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ApplySort(\"Nullable\"): ERROR - " + ex);
            }
        }
    }
}
