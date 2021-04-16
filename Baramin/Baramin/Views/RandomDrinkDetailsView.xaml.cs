using Baramin.Models;
using Baramin.ViewModels;
using DLToolkit.Forms.Controls;

using Xamarin.Forms;

namespace Baramin.Views
{
    public partial class RandomDrinkDetailsView : ContentPage
    {
        private DrinkDetail cocktails;
        public RandomDrinkDetailsView()
        {
            InitializeComponent();
            FlowListView.Init();
            BindingContext = RandomDrinkViewModel._viewModelInstance;
        }

        public RandomDrinkDetailsView(DrinkDetail cocktail)
        {
            this.cocktails = cocktail;
            InitializeComponent();
            FlowListView.Init();
            BindingContext = RandomDrinkViewModel._viewModelInstance;
            var vm = BindingContext as RandomDrinkViewModel;
            vm.getCocktailDetails(cocktail);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var vm = BindingContext as RandomDrinkViewModel;
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
