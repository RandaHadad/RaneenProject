﻿using Firebase.Auth;
using Newtonsoft.Json;
using RaneenProject.Data;
using RaneenProject.Models;
using RaneenProject.Views.ProfilePageViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            errormssg.IsVisible = false;

            //bool isEmpty = false;
            //if (UserNewFirstName.Text == "" || UserNewFirstName == null || UserNewLastName.Text == "" || UserNewLastName == null || UserNewPhone.Text == "" || UserNewPhone == null)
            //{
            //    isEmpty = true;
            //    return;
            //}

            try
            {               
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
               
                //Adding user info to Realtime Database
                Users nuser = new Users()
                {
                    Firstname = UserNewFirstName.Text,
                    Lastname = UserNewLastName.Text,
                    Email = UserNewEmail.Text,
                    Phone = UserNewPhone.Text,
                    Cart = new List<Product>() { new Product()},
                    Wishlist = new List<Product>() { new Product() },
                };

               bool res = await firebaseHelper.AddUser(nuser);
                if (res)
                {
                    //string gettoken = auth.FirebaseToken;
                    //await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");

                    var targetpage = new LoginPage();
                    NavigationPage.SetHasNavigationBar(targetpage, false);
                    await Navigation.PushAsync(targetpage);
                }
                //TODO: Temp lines
                var targetpageTemp = new LoginPage();
                NavigationPage.SetHasNavigationBar(targetpageTemp, false);
                await Navigation.PushAsync(targetpageTemp);
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                
                //if(isEmpty)
                //    errormssg.Text = "All Data Fields are Required";
                //else
                    errormssg.Text = ex.Message.Split(' ').Last();
                errormssg.IsVisible = true;
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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