using System;
using System.Collections.Generic;

namespace Equin.ApplicationFramework.Demos.ViewInjectionDemo
{
    class Order
    {
        public Order()
        {
            _details = new List<OrderDetail>();
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<OrderDetail> _details;

        public List<OrderDetail> Details
        {
            get { return _details; }
        }

    }

    class OrderDetail
    {
        public OrderDetail()
        {
            _message = string.Empty;
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        
    }
}
