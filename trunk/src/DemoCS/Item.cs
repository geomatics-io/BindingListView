using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// An RSS feed item.
    /// </summary>
    class Item
    {
        private string _title;
        private string _description;
        private DateTime? _pubDate;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        public DateTime? PubDate
        {
            get { return _pubDate; }
            set { _pubDate = value; }
        }

    }
}
