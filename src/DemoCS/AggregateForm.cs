using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Equin.ApplicationFramework;

namespace Demo
{
    public partial class AggregateForm : Form
    {
        private AggregateBindingListView<Item> itemsView;

        public AggregateForm()
        {
            InitializeComponent();

            itemsView = new AggregateBindingListView<Item>();

            LoadFeeds();

            itemsGrid.DataSource = itemsView;
        }

        private void LoadFeeds()
        {
            string[] urls = { 
                "http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/front_page/rss.xml", 
                "http://channel9.msdn.com/rss.aspx",
                "http://msdn.microsoft.com/rss.xml"
            };
            
            foreach (string url in urls)
            {
                Feed feed = new Feed(url);
                feed.Update();

                // Add to the list box so we can check/uncheck the feed
                feedsListBox.Items.Add(feed);
            }
        }

        private void feedsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the checked/unchecked feed
            Feed feed = feedsListBox.Items[e.Index] as Feed;

            if (e.NewValue == CheckState.Checked)
            {
                // Add the checked feed's items to the aggregate list
                itemsView.SourceLists.Add(feed.Items);
            }
            else
            {
                // Remove the checked feed's items from the aggregate list
                itemsView.SourceLists.Remove(feed.Items);
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            // Change the filter of the view.
            itemsView.Filter = BindingListView<Item>.CreateItemFilter(new Predicate<Item>(
                delegate(Item item)
                {
                    // uses ToLower() to ignore case of text.
                    return item.Title.ToLower().Contains(filterTextBox.Text.ToLower());
                }
            ));
        }
    }
}