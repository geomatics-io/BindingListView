using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SimpleForm f = new SimpleForm())
            {
                f.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (AggregateForm f = new AggregateForm())
            {
                f.ShowDialog(this);
            }
        }
    }
}