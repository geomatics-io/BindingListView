using System;
using System.Collections.Generic;
using Equin.ApplicationFramework;

namespace FieldProvidedViews
{
    public class Item
    {
        public string Name { get; set; }
    }

    // Mirrors the original Issue #3 YYY class: a public FIELD (not property) holding a list.
    public class FieldModel
    {
        public List<Item> tags;   // field, left null unless explicitly set
        public string Name { get; set; } = "field-model";
    }

    // Vendor-style scenario from the issue #5 thread: caller cannot change the model,
    // and only has access to it through a read-model interface. T is an interface, and
    // the field lives on the concrete class only.
    internal interface IVendorView
    {
        string Name { get; }
    }

    internal class VendorModel : IVendorView
    {
        public List<Item> tags;   // field the caller cannot turn into a property
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Field-based provided view: populated ---");
            var populated = new List<FieldModel>
            {
                new FieldModel { tags = new List<Item> { new Item { Name = "a" }, new Item { Name = "b" } } },
            };
            Try(() =>
            {
                var view = new BindingListView<FieldModel>(populated);
                var tagsView = view[0].GetProvidedView("tagsView") as BindingListView<Item>;
                Console.WriteLine("ok, tagsView count=" + (tagsView == null ? "null (no view created)" : tagsView.Count.ToString()));
            });

            Console.WriteLine("--- Field-based provided view: null (uninitialized) ---");
            var nullField = new List<FieldModel>
            {
                new FieldModel(), // tags left null
            };
            Try(() =>
            {
                var view = new BindingListView<FieldModel>(nullField);
                var tagsView = view[0].GetProvidedView("tagsView") as BindingListView<Item>;
                Console.WriteLine("ok, tagsView count=" + (tagsView == null ? "null (no view created)" : tagsView.Count.ToString()));
            });

            Console.WriteLine("--- Field-based provided view through an interface T (vendor scenario), populated ---");
            var vendorPopulated = new List<VendorModel>
            {
                new VendorModel { Name = "v1", tags = new List<Item> { new Item { Name = "x" }, new Item { Name = "y" }, new Item { Name = "z" } } },
            };
            Try(() =>
            {
                var view = new BindingListView<IVendorView>(vendorPopulated);
                var tagsView = view[0].GetProvidedView("tagsView") as BindingListView<Item>;
                Console.WriteLine("ok, tagsView count=" + (tagsView == null ? "null (no view created)" : tagsView.Count.ToString()));
            });

            Console.WriteLine("--- Field-based provided view through an interface T (vendor scenario), null ---");
            var vendorNull = new List<VendorModel>
            {
                new VendorModel { Name = "v2" }, // tags left null
            };
            Try(() =>
            {
                var view = new BindingListView<IVendorView>(vendorNull);
                var tagsView = view[0].GetProvidedView("tagsView") as BindingListView<Item>;
                Console.WriteLine("ok, tagsView count=" + (tagsView == null ? "null (no view created)" : tagsView.Count.ToString()));
            });
        }

        static void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex);
            }
        }
    }
}
