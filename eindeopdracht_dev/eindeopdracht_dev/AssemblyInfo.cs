using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont("verdana.tff", Alias = "Mijnfont")]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]