using System;

namespace Equin.ApplicationFramework.Demos.ViewInjectionDemo
{
    class Order
    {
        public Order()
        {
            _details = string.Empty;
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _details;

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

    }
}
