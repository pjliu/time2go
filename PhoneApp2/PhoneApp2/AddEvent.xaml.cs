using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.MobileServices;

namespace PhoneApp2
{
    public class EventItem
    {
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string EventName { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "date")]
        public string EventDate { get; set; }

        [DataMember(Name = "time")]
        public string EventTime { get; set; }
    }
    public partial class AddEvent : PhoneApplicationPage
    {
        // MobileServiceCollectionView implements ICollectionView (useful for databinding to lists) and 
        // is integrated with your Mobile Service to make it easy to bind your data to the ListView
        private MobileServiceCollection<EventItem, EventItem> items;

        private IMobileServiceTable<EventItem> todoTable = App.MobileService.GetTable<EventItem>();
        

        public AddEvent()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private async void InsertTodoItem(EventItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(todoItem); //
            items.Add(todoItem);
        }


        private void add(object sender, EventArgs e)
        {
            var todoItem = new EventItem { EventName = name.Text };
            InsertTodoItem(todoItem);   

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}