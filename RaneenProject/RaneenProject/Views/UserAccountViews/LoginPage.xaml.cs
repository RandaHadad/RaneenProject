using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RaneenProject.Views.ProfilePageViews;

namespace RaneenProject.Views.UserAccountViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        // Launcher.OpenAsync is provided by Xamarin.Essentials.
        public ICommand TapCommand => new Command(SignupPage);

        private void SignupPage(object obj)
        {
            var targetpage = new SignupPage();
            NavigationPage.SetHasBackButton(targetpage, true);
            NavigationPage.SetHasNavigationBar(targetpage, true);
            Navigation.PushAsync(targetpage);
        }

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void ProfilePage(object sender, EventArgs e)
        {
            var targetpage = new ProfilePage();
            NavigationPage.SetHasNavigationBar(targetpage, false);
            Navigation.PushAsync(targetpage);
        }
    }
}