using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Issue2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingList<Person> persons = new BindingList<Person>();

            persons.Add(new Person("Ray", "Rochester", 18));
            persons.Add(new Person("Scott", "Cupertino", 33));
            persons.Add(new Person("Samuel", "Boston", 54));


            BindingListView<Person> blvPersons = new BindingListView<Person>(persons);
            dataGridView1.DataSource = blvPersons;
            dataGridView2.DataSource = blvPersons;

            gridControl1.DataSource = blvPersons;
            gridControl2.DataSource = blvPersons;

            blvPersons.ApplyFilter(delegate (Person customer) { return customer.Age > 20; });
        }
    }
    
    public class Person
    {
        public Person(string name, string city, int age)
        {
            Name = name;
            City = city;
            Age = age;
        }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
}
