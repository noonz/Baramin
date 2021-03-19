using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Baramin.ViewModels
{
    public class RandomDrinkViewModel : BaseViewModel
    {
        public RandomDrinkViewModel()
        {
            Title = "Random Drink";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}