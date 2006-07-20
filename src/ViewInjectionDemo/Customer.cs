using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Equin.ApplicationFramework.Demos.ViewInjectionDemo
{
    class Customer
    {
        public Customer()
            : this(string.Empty)
        {
        }

        public Customer(string name)
        {
            _name = name;
            _orders = new List<Order>();
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Order> _orders;

        public List<Order> Orders
        {
            get { return _orders; }
        }

    }
}
