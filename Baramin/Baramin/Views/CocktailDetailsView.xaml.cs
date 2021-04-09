using Baramin.Models;
using Baramin.ViewModels;
using DLToolkit.Forms.Controls;

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

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var vm = BindingContext as CocktailViewModel;
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
