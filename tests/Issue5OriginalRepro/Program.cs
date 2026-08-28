using System;
using System.Collections.Generic;
using System.ComponentModel;
using Equin.ApplicationFramework;

namespace Issue5OriginalRepro
{
    // The Dapper-style scenario described in the issue: the query/consumer only ever
    // sees the model through a "human-readable view" interface, not the concrete type.
    internal interface IModel
    {
        int SortOrder { get; }
        string Name { get; }
    }

    internal class Model : IModel
    {
        public int SortOrder { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Model>
            {
                new Model { SortOrder = 3, Name = "c" },
                new Model { SortOrder = 1, Name = "a" },
                new Model { SortOrder = 2, Name = "b" },
            };

            // T is IModel, not Model - exactly the reported "interface as return type" case.
            var view = new BindingListView<IModel>(items);

            Console.WriteLine("--- \"I programmatically call ApplySort(\\\"sort column name\\\")\" ---");
            try
            {
                view.ApplySort("SortOrder");
                Console.WriteLine("ok");
                foreach (var item in view)
                {
                    Console.WriteLine("  " + item.SortOrder + " " + item.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex);
            }

            Console.WriteLine();
            Console.WriteLine("--- \"click the sortable columns on a bound data grid view\" (same call a DataGridView makes internally) ---");
            try
            {
                // A DataGridView asks the view (via ITypedList, since BindingListView
                // implements it) for the column's PropertyDescriptor, then calls
                // IBindingList.ApplySort(PropertyDescriptor, ListSortDirection) on
                // header click - this is that exact call, not a shortcut through the
                // string-based ApplySort overload used above.
                ITypedList typedList = view;
                PropertyDescriptorCollection props = typedList.GetItemProperties(null);
                PropertyDescriptor sortOrderProp = props["SortOrder"];
                Console.WriteLine("Resolved PropertyDescriptor: Name=" + sortOrderProp.Name + " ComponentType=" + sortOrderProp.ComponentType + " PropertyType=" + sortOrderProp.PropertyType);

                IBindingList bindingList = view;
                bindingList.ApplySort(sortOrderProp, ListSortDirection.Descending);
                Console.WriteLine("ok");
                foreach (var item in view)
                {
                    Console.WriteLine("  " + item.SortOrder + " " + item.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex);
            }
        }
    }
}
