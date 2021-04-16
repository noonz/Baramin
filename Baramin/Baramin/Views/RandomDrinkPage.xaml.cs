using Baramin.Models;
using Xamarin.Forms;
using DLToolkit.Forms.Controls;
using Baramin.ViewModels;

namespace Baramin.Views
{
    public partial class RandomDrinkPage : ContentPage
    {
        public RandomDrinkPage()
        {
            InitializeComponent();
            BindingContext = RandomDrinkViewModel._viewModelInstance;
        }

        void HandleRecipeDetails(object sender, System.EventArgs e)
        {
            var cocktail = new DrinkDetail();
            BindingContext = RandomDrinkViewModel._viewModelInstance;
            var vm = BindingContext as RandomDrinkViewModel;
            cocktail = vm._cocktail;
            Navigation.PushAsync(new RandomDrinkDetailsView(cocktail));
        }
    }
}