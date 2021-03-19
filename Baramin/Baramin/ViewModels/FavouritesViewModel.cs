using Baramin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Baramin.ViewModels
{
    public class FavouritesViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public FavouritesViewModel()
        {
            Title = "Favourite Drinks";
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(RandomDrinkPage)}");
        }
    }
}
