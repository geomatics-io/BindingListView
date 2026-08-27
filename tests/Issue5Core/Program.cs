using System;
using System.Collections.Generic;
using Equin.ApplicationFramework;

namespace Issue5Core
{
    internal interface IModelView
    {
        string IdString { get; }
        string Name { get; set; }
        string Description { get; set; }
        int Id { get; }
        DateTime Created { get; }
    }

    internal class Model : IModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Guid[] guids { get; set; } // left uninitialized, as in the real-world report

        public string IdString => Id.ToString();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Model>
            {
                new Model { Id = 3, Name = "c", Created = new DateTime(2026, 3, 1) }, // guids left null
                new Model { Id = 1, Name = "a", Created = new DateTime(2026, 1, 1), guids = new[] { Guid.NewGuid(), Guid.NewGuid() } },
                new Model { Id = 2, Name = "b", Created = new DateTime(2026, 2, 1), guids = Array.Empty<Guid>() },
            };

            try
            {
                var source = new BindingListView<IModelView>(items);
                Console.WriteLine("Construct BindingListView<IModelView>: ok, count=" + source.Count);

                Try(source, "Name");      // reference-type property (string)
                Try(source, "IdString");  // reference-type property (string), read-only
                Try(source, "Id");        // value-type property (int)
                Try(source, "Created");   // value-type property (DateTime)
            }
            catch (Exception ex)
            {
                Console.WriteLine("Construct BindingListView<IModelView>: ERROR - " + ex);
            }
        }

        static void Try(BindingListView<IModelView> source, string property)
        {
            try
            {
                source.ApplySort(property);
                Console.WriteLine($"ApplySort(\"{property}\") ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ApplySort(\"{property}\"): ERROR - {ex}");
            }
        }
    }
}
