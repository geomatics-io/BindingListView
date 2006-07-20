using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;

namespace Demo
{
    class Feed
    {
        private string _url;
        private BindingList<Item> _items;
        private string _title;

        public Feed(string url)
        {
            _url = url;
            _items = new BindingList<Item>();
        }

        public void Update()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_url);

            _title = doc.SelectSingleNode("/rss/channel/title").InnerText;

            foreach (XmlNode node in doc.SelectNodes("//item"))
            {
                Item item = new Item();
                item.Title = node["title"].InnerText;
                item.Description = node["description"].InnerText;
                item.PubDate = DateTime.Parse(node["pubDate"].InnerText);
                Items.Add(item);
            }
        }

        public BindingList<Item> Items
        {
            get
            {
                return _items;
            }
        }

        public override string ToString()
        {
            if (_title == null)
            {
                return _url;
            }
            else
            {
                return _title;
            }

        }
    }
}
