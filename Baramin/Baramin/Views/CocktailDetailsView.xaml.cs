using Baramin.Models;
using Baramin.ViewModels;
using DLToolkit.Forms.Controls;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace Baramin.Views
{
    public partial class CocktailDetailsView : ContentPage
    {
        private DrinkDetail cocktails;
        public CocktailDetailsView()
        {
            InitializeComponent();
            FlowListView.Init();
            BindingContext = CocktailViewModel._viewModelInstance;
        }

        public CocktailDetailsView(DrinkDetail cocktail)
        {
            this.cocktails = cocktail;
            InitializeComponent();
            FlowListView.Init();
            BindingContext = CocktailViewModel._viewModelInstance;
            var vm = BindingContext as CocktailViewModel;
            vm.getCocktailDetails(cocktail);
        }

        public async void Handle_Clicked(object sender, System.EventArgs e)
        {
            // save data to firebase
            FirebaseClient fc = new FirebaseClient("https://baraminfirebase-default-rtdb.firebaseio.com/");
            await fc
                .Child("Favourites")
                .Child(cocktails.IdDrink)
                .PostAsync(new Favourite() { 
                    Id = cocktails.IdDrink, 
                    Name = cocktails.StrDrink, 
                    PhotoUrl = cocktails.StrDrinkThumb.ToString(), 
                    Type = cocktails.StrCategory });

            var vm = BindingContext as CocktailViewModel;




            // create model data to save to sqlite
            var fav = new Favourite
            {
                Id = cocktails.IdDrink,
                Name = cocktails.StrDrink,
                PhotoUrl = cocktails.StrDrinkThumb.ToString(),
                Type = "Cocktail"
            };
            vm.AddToFavourite(fav);
        }
    }
}
