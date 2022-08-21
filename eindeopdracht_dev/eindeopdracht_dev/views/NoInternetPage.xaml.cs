using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eindopdracht.Models;
using eindopdracht.REpo;
using eindeopdracht_dev.views;
using eindeopdracht_dev.Models;

namespace eindeopdracht_dev.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nointernet : ContentPage
    {
        public nointernet()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Still not connected internet", "", "ok");
                return;
            }

            else
            {
                Application.Current.MainPage = this;
                await Navigation.PushAsync(new parkinglijst());
                
            }
        }
    }
}