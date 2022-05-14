using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RaneenProject.Views.ProfilePageViews;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace RaneenProject.Views.UserAccountViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDsFm9Tuv4Brz9WJM4Q-qVLzd5wtLpie80";

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

        async void loginbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

                var targetpage = new ProfilePage();
                NavigationPage.SetHasBackButton(targetpage, false);
                NavigationPage.SetHasNavigationBar(targetpage, true);
                await Navigation.PushAsync(targetpage);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
        }
    }
}