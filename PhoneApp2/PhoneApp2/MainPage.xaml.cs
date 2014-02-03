using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp2.Resources;
using System.Device.Location;
using Windows.Devices.Geolocation;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Time.Text = (DateTime.Now).ToString();

            // db

        
        }

        public async void getLocations()
        {    
            Geolocator geoloc = new Geolocator();
            Geoposition pos = await geoloc.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(30));

            var gpsCoord = new GeoCoordinate(pos.Coordinate.Latitude, pos.Coordinate.Longitude);

            // get location from database and calculate travel time
        }

        private void addEvent(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddEvent.xaml", UriKind.RelativeOrAbsolute));

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void searchButtonClick(object sender, EventArgs e)
        {
            // search the database
        }

        private void calendarButtonClick(object sender, EventArgs e)
        {
            // open calendar app
        }

        private void mapsButtonClick(object sender, EventArgs e)
        {
            //
        }

    }
}