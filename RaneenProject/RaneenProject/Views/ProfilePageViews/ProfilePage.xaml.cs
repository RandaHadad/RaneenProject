using RaneenProject.Views.ProfilePageViews;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RaneenProject.Views.ProfilePageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ICommand TapCommandAccount => new Command(AccountInformationPage);
        public ICommand TapCommandWishlist => new Command(WishlistPage);
        public ICommand TapCommandAboutus => new Command(AboutUsPage);

        private void AccountInformationPage(object obj)
        {
            var targetpage = new AccountInformationPage();
            NavigationPage.SetHasBackButton(targetpage, true);
            NavigationPage.SetHasNavigationBar(targetpage, true);
            Navigation.PushAsync(targetpage);
        }

        private void WishlistPage(object obj)
        {
            var targetpage = new WishlistPage();
            NavigationPage.SetHasNavigationBar(targetpage, false);
            Navigation.PushAsync(targetpage);
        }

        private void AboutUsPage(object obj)
        {
            var targetpage = new AboutUsWithScrollPage();
            NavigationPage.SetHasNavigationBar(targetpage, false);
            Navigation.PushAsync(targetpage);
        }

        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}