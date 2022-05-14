using Newtonsoft.Json;
using RaneenProject.Data;
using RaneenProject.Models;
using RaneenProject.Views;
using RaneenProject.Views.UserAccountViews;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace RaneenProject.ViewModels
{
   

    /// <summary>
    /// ViewModel for catalog page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CatalogPageViewModel : BaseViewModel
    {
        private UsersDB dB;
        #region Fields

        private ObservableCollection<Category> filterOptions;

        private ObservableCollection<string> sortOptions;

        private Command addFavouriteCommand;

        private Command itemSelectedCommand;

        private Command sortCommand;

        private Command filterCommand;

        private Command addToCartCommand;

        private Command cardItemCommand;

        private string cartItemCount;

        INavigation Navigation => Application.Current.MainPage.Navigation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CatalogPageViewModel" /> class.
        /// </summary>
        public CatalogPageViewModel()
        {
            this.FilterOptions = new ObservableCollection<Category>
            {
                new Category
                {
                    Name = "Gender",
                    SubCategories = new List<string>
                    {
                        "Men",
                        "Women",
                    },
                },
                new Category
                {
                    Name = "Brand",
                    SubCategories = new List<string>
                    {
                        "Brand A",
                        "Brand B",
                    },
                },
                new Category
                {
                    Name = "Categories",
                    SubCategories = new List<string>
                    {
                        "Category A",
                        "Category B",
                    },
                },
                new Category
                {
                    Name = "Color",
                    SubCategories = new List<string>
                    {
                        "Maroon",
                        "Pink",
                    },
                },
                new Category
                {
                    Name = "Price",
                    SubCategories = new List<string>
                    {
                        "Above 3000",
                        "1000 to 3000",
                        "Below 1000",
                    },
                },
                new Category
                {
                    Name = "Size",
                    SubCategories = new List<string>
                    {
                        "S", "M", "L", "XL", "XXL",
                    },
                },
                new Category
                {
                    Name = "Patterns",
                    SubCategories = new List<string>
                    {
                        "Pattern 1", "Pattern 2",
                    },
                },
                new Category
                {
                    Name = "Offers",
                    SubCategories = new List<string>
                    {
                        "Buy 1 Get 1", "Buy 1 Get 2",
                    },
                },
                new Category
                {
                    Name = "Coupons",
                    SubCategories = new List<string>
                    {
                        "Coupon 1", "Coupon 2",
                    },
                },
            };

            this.SortOptions = new ObservableCollection<string>
            {
                "New Arrivals",
                "Price - high to low",
                "Price - Low to High",
                "Popularity",
                "Discount",
            };
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the item details in tile.
        /// </summary>
        [DataMember(Name = "products")]
        public ObservableCollection<Product> Products
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the filter options.
        /// </summary>
        public ObservableCollection<Category> FilterOptions
        {
            get
            {
                return this.filterOptions;
            }

            private set
            {
                if (this.filterOptions == value)
                {
                    return;
                }

                this.SetProperty(ref this.filterOptions, value);
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with a list view, which displays the sort details.
        /// </summary>
        public ObservableCollection<string> SortOptions
        {
            get
            {
                return this.sortOptions;
            }

            private set
            {
                if (this.sortOptions == value)
                {
                    return;
                }

                this.SetProperty(ref this.sortOptions, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public string CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }

            set
            {
                this.SetProperty(ref this.cartItemCount, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the sort button is clicked.
        /// </summary>
        public Command SortCommand
        {
            get { return this.sortCommand ?? (this.sortCommand = new Command(this.SortClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the filter button is clicked.
        /// </summary>
        public Command FilterCommand
        {
            get { return this.filterCommand ?? (this.filterCommand = new Command(this.FilterClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand
        {
            get
            {
                return this.addFavouriteCommand ?? (this.addFavouriteCommand = new Command(this.AddFavouriteClickedAsync));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand
        {
            get { return this.addToCartCommand ?? (this.addToCartCommand = new Command(this.AddToCartClickedAsync)); }
        }

        /// <summary>
        /// Gets or sets the command will be executed when the cart icon button has been clicked.
        /// </summary>
        public Command CardItemCommand
        {
            get { return this.cardItemCommand ?? (this.cardItemCommand = new Command(this.CartClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ItemSelected(object attachedObject)
        {
           
            Navigation.PushAsync(new DetailPage(attachedObject as Product));
            // Do something
        }

        /// <summary>
        /// Invoked when the items are sorted.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void SortClicked(object attachedObject)
        {
           
            // Do something
        }

        /// <summary>
        /// Invoked when the filter button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FilterClicked(object obj)
        {
            // Do something
        }



        /// <summary>
        /// Invoked when the favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void AddFavouriteClickedAsync(object obj)
        {
            var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
            if (savedfirebaseauth != null)
            {
                Product p = obj as Product;
                

                dB = new UsersDB();
                bool res = await dB.AddToWishlist(savedfirebaseauth.User.Email, p);
                if (res == true)
                {
                    if (obj is Product product)
                    {
                        product.IsFavourite = !product.IsFavourite;
                    }
                }


            }
            else if (savedfirebaseauth == null)
            {
                var targetpage = new LandingPage();
                NavigationPage.SetHasBackButton(targetpage, false);
                NavigationPage.SetHasNavigationBar(targetpage, true);
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(targetpage);

            }
          
        }

        /// <summary>
        /// Invoked when the cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void AddToCartClickedAsync(object obj)
        {
            var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));

            if (savedfirebaseauth != null)
            {
                Product p = obj as Product;
          
                dB = new UsersDB();
                bool res = await dB.AddToCart(savedfirebaseauth.User.Email, p);

            }
            else if (savedfirebaseauth == null)
            {
                var targetpage = new LandingPage();
                NavigationPage.SetHasBackButton(targetpage, false);
                NavigationPage.SetHasNavigationBar(targetpage, true);
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(targetpage);

            }
        }

        /// <summary>
        /// Invoked when cart icon button is clicked.
        /// </summary>
        /// <param name="obj"></param>
        private void CartClicked(object obj)
        {
            var targetpage = new CartPage();
            NavigationPage.SetHasNavigationBar(targetpage, false);
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(targetpage);
        }

        #endregion
    }
}