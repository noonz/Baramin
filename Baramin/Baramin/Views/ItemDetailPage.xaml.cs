using Baramin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Baramin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}