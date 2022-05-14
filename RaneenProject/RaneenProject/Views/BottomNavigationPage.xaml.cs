using RaneenProject.Views.ProfilePageViews;
using RaneenProject.Views.UserAccountViews;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace RaneenProject.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavigationPage : Shell
    {

       // TabbedPage tabbedPage = new TabbedPage();
        public BottomNavigationPage()
        {
            this.InitializeComponent();
/*
            tabbedPage.Children.Add(new NavigationPage(new DetailPage()));
            tabbedPage.Children.Add(new NavigationPage(new ProfilePage()));
            tabbedPage.Children.Add(new NavigationPage(new LoginPage()));
            tabbedPage.Children.Add(new NavigationPage(new SignupPage()));
            tabbedPage.Children.Add(new NavigationPage(new AboutUsWithScrollPage()));
            tabbedPage.Children.Add(new NavigationPage(new CatalogTilePage()));*/
        }
    }
}