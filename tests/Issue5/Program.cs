using System;
using System.Collections.Generic;
using System.ComponentModel;
using Equin.ApplicationFramework;

namespace Issue5
{
    public class Item
    {
        public int SortOrder { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>
            {
                new Item { SortOrder = 3, Name = "c" },
                new Item { SortOrder = 1, Name = "a" },
                new Item { SortOrder = 2, Name = "b" },
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
        }
    }
}
