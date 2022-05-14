using RaneenProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace RaneenProject
{
    public partial class App : Application
    {
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjMyODA3QDMyMzAyZTMxMmUzMGh5eWJ3N3FheHRqb0V2RllqT08xcXB0SnJYWktEa2ZpQ2VPRmJiNlV3WWc9");

            InitializeComponent();

<<<<<<< HEAD
            //MainPage = new CartPage();
            MainPage = new BottomNavigationPage();

=======
            MainPage = new NavigationPage(new BottomNavigationPage());
            //TODO: BtmNavBar always maps to landingpage
>>>>>>> d4c915bc7c66b5422d2ca4f768226b89abaa1b1e
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
