using Baramin.Views;
using Xamarin.Forms;

namespace Baramin.ViewModels
{
    public class FavouritesViewModel
    {
        public Command LoginCommand { get; }

        public FavouritesViewModel()
        {

        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(RandomDrinkPage)}");
        }
    }
}
