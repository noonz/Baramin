using Baramin.Models;
using Baramin.ViewModels;
using Xamarin.Forms;

namespace Baramin.Views
{
    public partial class CocktailView : ContentPage
    {
        public CocktailView()
        {
            InitializeComponent();
            var vm = BindingContext as FavouriteViewModel;
        }

        void HandleRecipeDetails(object sender, System.EventArgs e)
        {
            var cocktail = (DrinkDetail)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new CocktailDetailsView(cocktail));
        }
    }
}
