using Equin.ApplicationFramework;
using System.ComponentModel;

namespace BindingListViewTest
{
    internal interface IModelView
    {
        [DisplayName("Id")]
        public string IdString { get; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    internal class Model : IModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid[] guids { get; set; } // left uninitialized, as added later in the thread

        public string IdString => Id.ToString();
    }

    public partial class Form1 : Form
    {
        // Exposed for the test harness in Program.cs to drive DataGridView.Sort()
        // programmatically (the same call a real header click triggers) since we
        // can't literally click a header without an interactive display.
        internal DataGridView Grid { get; private set; }
        internal BindingListView<IModelView> Source { get; private set; }

        public Form1()
        {
            InitializeComponent();

            var items = new List<Model>() {
                new() { Id = 0, Name = "0" },
                new() { Id = 1, Name = "1" },
                new() { Id = 2, Name = "2" },
                new() { Id = 3, Name = "3" },
            };

            var source = new BindingListView<IModelView>(items);
            var grid = new DataGridView() { DataSource = source, Dock = DockStyle.Fill };
            Controls.Add(grid);
            //source.ApplySort("Name");

            Source = source;
            Grid = grid;
        }
    }
}
