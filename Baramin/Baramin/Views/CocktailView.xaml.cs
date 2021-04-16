using Baramin.Models;
using Xamarin.Forms;

namespace Baramin.Views
{
    public partial class CocktailView : ContentPage
    {
        public CocktailView()
        {
            InitializeComponent();
        }

        void HandleRecipeDetails(object sender, System.EventArgs e)
        {
            var cocktail = (DrinkDetail)((ListView)sender).SelectedItem;
            Navigation.PushAsync(new CocktailDetailsView(cocktail));
        }
    }
}
