using eindeopdracht_dev.Models;
using eindopdracht.Models;
using eindopdracht.REpo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class parkingdetails : ContentPage
    {

       
        public ParkingGent.Record records = new ParkingGent.Record();
        public parkingdetails(ParkingGent.Record record)
        {
            InitializeComponent();

            BindingContext = record;
            records = record;
            //imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");
            favorieten();
            

        }

        private async void favorieten()
        {
            Debug.WriteLine($"{ records.Fields.Name} tekst");
            List<favoriet> favo = await ParkingRepo.IsFavoriet();
            if (favo.Count != 0)
            {
                foreach (var item in favo)
                {
                    Debug.WriteLine(item.parkingid);
                    if (item.parkingid != records.Fields.Name)
                    {
                        imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");

                    }

                    else
                    {
                        imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.stergeel.png");
                        break;

                    }
                }

            }
            else
            {
                imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //ParkingGent.Record sele = lblcordinaten as ParkingGent.Geometry;
            
            await Navigation.PushAsync(new map(records));
        }

                public favoriet favor = new favoriet();
        private async void imgfavoriet_Clicked(object sender, EventArgs e)
        {

            List<favoriet> favo = await ParkingRepo.IsFavoriet();


            if (favo.Count != 0)
            {
                foreach (var item in favo)
                {
                    Debug.WriteLine(item.parkingid);

                    if (item.parkingid == records.Fields.Name)
                    {

                        await ParkingRepo.Deletefavo(records.Fields.Name);
                        imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.sterwit.png");
                        break;

                    }

                    else
                    {
                        item.parkingid = records.Fields.Name;
                        await ParkingRepo.UpdateFavo(item);
                        imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.stergeel.png");



                    }
                }
            }

            else
            {
                
                 favor.parkingid = records.Fields.Name;
                 await ParkingRepo.UpdateFavo(favor);
                 imgfavoriet.Source = ImageSource.FromResource("eindeopdracht_dev.Assets.stergeel.png");
                
            }



        }
    }
}