using Firebase.Database;
using RaneenProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaneenProject.Data
{
    public class ProductDB
    {

        ////FirebaseClient firebase = new FirebaseClient("https://raneendb-90788-default-rtdb.europe-west1.firebasedatabase.app/");

        //public static string FirebaseClient = "https://raneendb-90788-default-rtdb.europe-west1.firebasedatabase.app/";
        //public static string FrebaseSecret = "NFnB6WS5ppefCvQNHqQXZTWEP3vbJb424NAsPQjJ";

        //public FirebaseClient firebase = new FirebaseClient(FirebaseClient,
        //                           new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(FrebaseSecret) });

        //public async Task<List<Product>> GetAllProducts()
        //{


        //    //var item = await firebase.Child("Products").OnceAsync<JObject>();
        //    //var itemProperty = item.Object.GetValue("Name");

        //    return (await firebase
        //      .Child("Products")
        //      .OnceAsync<Product>()).Select(item => new Product
        //      {
        //          Name = item.Object.Name,
        //          Id = item.Object.Id
        //      }).ToList();

        //    //return (await firebase
        //    // .Child("Products")
        //    // .OnceAsync<JObject>()).Select(item => new JObject
        //    // {
        //    //     Name = (string)item.Object.GetValue("Name"),
        //    //     Id = (int)item.Object.GetValue("Id")
        //    // }).ToList();

        //    //    var Items = new ObservableCollection<Product>();

        //    //    var GetItems = (await firebase
        //    //                   .Child("Products")
        //    //                   .OnceAsync<Product>().ConfigureAwait(false)).Select(item => new Product
        //    //                   {
        //    //                       Name = item.Object.Name,
        //    //                       Id = item.Object.Id
        //    //                   });

        //    //    foreach (var item in GetItems)
        //    //    {
        //    //        Items.Add(item);
        //    //    }
        //    //    return Items;
        //}


    }
}
