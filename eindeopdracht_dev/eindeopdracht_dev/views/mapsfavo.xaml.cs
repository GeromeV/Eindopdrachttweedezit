﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eindopdracht.Models;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mapsfavo : ContentPage
    {
        private readonly Geocoder geocoder = new Geocoder();
        public mapsfavo(ParkingGentFavo.Record record)
        {
            mapopvullen(record);
            InitializeComponent();
        }

        public async void mapopvullen(ParkingGentFavo.Record record)
        {

            Map kaart = new Map();
            kaart.MapType = MapType.Street;
            Position position = new Position(record.Geometry.Coordinates[1], record.Geometry.Coordinates[0]);
            var addresses = await geocoder.GetAddressesForPositionAsync(position);

            Pin pin = new Pin
            {
                Label = record.Fields.Name,
                Address = addresses.FirstOrDefault()?.ToString(),
                Type = PinType.Place,
                Position = position
            };
            kaart.Pins.Add(pin);
            kaart.IsShowingUser = true;



            Content = kaart;

            kaart.MoveToRegion(new MapSpan(position, 0.01, 0.01));
        }
    }
}