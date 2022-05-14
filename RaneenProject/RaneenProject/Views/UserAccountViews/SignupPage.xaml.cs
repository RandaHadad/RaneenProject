﻿using Firebase.Auth;
using Newtonsoft.Json;
using RaneenProject.Data;
using RaneenProject.Models;
using RaneenProject.Views.ProfilePageViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RaneenProject.Views.UserAccountViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDsFm9Tuv4Brz9WJM4Q-qVLzd5wtLpie80";
        UsersDB firebaseHelper = new UsersDB(); 

        // Launcher.OpenAsync is provided by Xamarin.Essentials.
        public ICommand TapCommand => new Command(loginPage);

        private void loginPage(object obj)
        {
            var targetpage = new LoginPage();
            NavigationPage.SetHasBackButton(targetpage, true);
            NavigationPage.SetHasNavigationBar(targetpage, true);
            Navigation.PushAsync(targetpage);
        }

        public SignupPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void signupbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                //await DisplayAlert($"{UserNewEmail.Text}, {UserNewPassword.Text}", "ok","cancel");
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);

                Product emptyProduct = new Product()
                {
                    Name = string.Empty,
                    ActualPrice = 0,
                    Description = string.Empty,
                    DiscountPercent = 0,
                    DiscountPrice = 0,
                    Id = -1,
                    IsFavourite = false,
                    OverallRating = 0,
                    PreviewImage = "https://cdn3.iconfinder.com/data/icons/shopping-and-ecommerce-29/90/empty_cart-512.png",
                   // PreviewImages = "",
                   // Quantities = new List<object> {""},
                    //Reviews = new ObservableCollection<Review> { new Review()},
                    SellerName = string.Empty,
                    //SizeVariants = new List<string> { },

                };
                //Adding user info to Realtime Database
                Users nuser = new Users()
                {
                    Firstname=UserNewFirstName.Text,
                    Lastname=UserNewLastName.Text,
                    Email= UserNewEmail.Text,
                    Phone = UserNewPhone.Text,
                    Cart = string.Empty,
                    Wishlist = string.Empty,
                };

               bool res = await firebaseHelper.AddUser(nuser);
                ////////////////////////////////
                if (res)
                {
                    string gettoken = auth.FirebaseToken;
                    await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
                }
       
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

        }

        //async void loginbutton_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
        //    try
        //    {
        //        var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
        //        var content = await auth.GetFreshAuthAsync();
        //        var serializedcontnet = JsonConvert.SerializeObject(content);
        //        Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
        //        await Navigation.PushAsync(new ProfilePage());
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
        //    }
        //}
    }
}