using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RaneenProject.Views.ProfilePageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountInformationPage : ContentPage
    {
        public AccountInformationPage()
        {
            InitializeComponent();
        }

        private void EditEmail(object sender, EventArgs e)
        {
            var targetpage = new EditEmail();
            NavigationPage.SetHasBackButton(targetpage, true);
            NavigationPage.SetHasNavigationBar(targetpage, true);
            Navigation.PushAsync(targetpage);
        }

        private void EditInfo(object sender, EventArgs e)
        {
            var targetpage = new EditInfo();
            NavigationPage.SetHasBackButton(targetpage, true);
            NavigationPage.SetHasNavigationBar(targetpage, true);
            Navigation.PushAsync(targetpage);
        }
    }
}