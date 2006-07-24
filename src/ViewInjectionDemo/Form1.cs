using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Equin.ApplicationFramework.Demos.ViewInjectionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Create view of customers list
            BindingListView<Customer> view = new BindingListView<Customer>(GetCustomers());
            // Data bind to the view
            customerBindingSource.DataSource = view;

            // Change the orders binding source to use the auto provided view
            // instead of the normal list.
            ordersBindingSource.DataMember = "OrdersView";

        }

        private BindingList<Customer> GetCustomers()
        {
            BindingList<Customer> customers = new BindingList<Customer>();
            customers.Add(new Customer("David"));
            customers.Add(new Customer("Andrew"));
            customers.Add(new Customer("Bob"));
            customers.Add(new Customer("Chris"));

            return customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ordersBindingSource.Current.GetType().Name);
        }

    }
}