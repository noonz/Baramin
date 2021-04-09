using Baramin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Baramin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        public FavouritesPage()
        {
            InitializeComponent();
            this.BindingContext = new FavouritesViewModel();
        }
    }
}