using eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mapfavo : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();
        public mapfavo(List<ParkingGentFavo.Record> record)
        {
            InitializeComponent();
            maps(record);
        }

        public async void maps(List<ParkingGentFavo.Record> record)
        {

            Map kaart = new Map();
            kaart.MapType = MapType.Street;
            foreach(var x in record)
            {
                Position position = new Position(x.Geometry.Coordinates[1], x.Geometry.Coordinates[0]);
                var addresses = await geocoder.GetAddressesForPositionAsync(position);

                Pin pin = new Pin
                {
                    Label = x.Fields.Name,
                    Address = addresses.FirstOrDefault()?.ToString(),
                    Type = PinType.Place,
                    Position = position
                };
                kaart.Pins.Add(pin);
                Content = kaart;
                kaart.MoveToRegion(new MapSpan(position, 0.01, 0.01));
            }
            kaart.IsShowingUser = true;


            
           
                
        }
    }
}