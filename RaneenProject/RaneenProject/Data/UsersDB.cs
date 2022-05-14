using Firebase.Database;
using Firebase.Database.Query;
using RaneenProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaneenProject.Data
{
    public class UsersDB
    {

        //FirebaseClient firebase = new FirebaseClient("https://raneendb-90788-default-rtdb.europe-west1.firebasedatabase.app/");

        public static string FirebaseClient = "https://raneendb-90788-default-rtdb.europe-west1.firebasedatabase.app/";
        public static string FrebaseSecret = "NFnB6WS5ppefCvQNHqQXZTWEP3vbJb424NAsPQjJ";

        public FirebaseClient firebase = new FirebaseClient(FirebaseClient,
                                   new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(FrebaseSecret) });

        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                var userlist = (await firebase
              .Child("Users")
              .OnceAsync<Users>()).Select(item => new Users
              {
                  Firstname = item.Object.Firstname,
                  Lastname = item.Object.Lastname,
                  Email = item.Object.Email,
                  Phone = item.Object.Phone,
                  Cart = item.Object.Cart,
                  Wishlist = item.Object.Wishlist
              }).ToList();

                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }


        }
        public async Task<bool> AddUser(Users nuser)
        {
            try
            {
                await firebase
                .Child("Users")
                .PostAsync(
                  new Users()
                  {
                      Firstname = nuser.Firstname,
                      Lastname = nuser.Lastname,
                      Email = nuser.Email,
                      Phone = nuser.Phone,
                      Cart = nuser.Cart,
                      Wishlist = nuser.Wishlist,

                  });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }

        }
        public async Task<Users> GetUser(String email)
        {
            try
            {
                var allUsers = await GetAllUsers();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }


        }

        public async Task<bool> AddToCart(String email, Product product)
        {
            try
            {
                var toUpdatePerson = (await firebase
                .Child("Users")
                .Child("Cart")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();

                if (toUpdatePerson != null)
                {
                    List<Product> p;
                    if (toUpdatePerson.Object.Cart != null)
                    {
                        p = toUpdatePerson.Object.Cart;
                        p.Add(product);
                        await App.Current.MainPage.DisplayAlert("YourApp",p.Count().ToString() , "Ok");

                    }
                    else
                    {
                        p = new List<Product> { product };
                    }

                    await firebase
                      .Child("Users")
                      .Child(toUpdatePerson.Key)
                      .Child("Cart")
                      .PutAsync(new Users()
                      {
                          Firstname = toUpdatePerson.Object.Firstname,
                          Lastname = toUpdatePerson.Object.Lastname,
                          Email = toUpdatePerson.Object.Email,
                          Phone = toUpdatePerson.Object.Phone,
                          Cart = p,
                          Wishlist = toUpdatePerson.Object.Wishlist,

                      });

                      //.PutAsync(p);
                }
                return true;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("YourApp", $"Error:{e}", "Ok");

                return false;
            }


        }
        public async Task<bool> AddToWishlist(String email, Product product)
        {

            try
            {
                var toUpdatePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();

                if (toUpdatePerson != null)
                {
                    List<Product> p;
                    if (toUpdatePerson.Object.Wishlist != null)
                    {
                        p = toUpdatePerson.Object.Wishlist;
                        p.Add(product);
                    }
                    else
                    {
                        p = new List<Product> { product };
                    }

                    await firebase
                      .Child("Users")
                      .Child(toUpdatePerson.Key)
                      .PutAsync(new Users()
                      {
                          Firstname = toUpdatePerson.Object.Firstname,
                          Lastname = toUpdatePerson.Object.Lastname,
                          Email = toUpdatePerson.Object.Email,
                          Phone = toUpdatePerson.Object.Phone,
                          Cart = toUpdatePerson.Object.Cart,
                          Wishlist = p,
                      });

                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        public async Task<bool> DeleteUser(String email)
        {
            try
            {
                var toDeletePerson = (await firebase
          .Child("Users")
          .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }


        }

    }
}
