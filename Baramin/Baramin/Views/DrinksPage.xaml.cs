using Baramin.Models;
using Baramin.ViewModels;
using Baramin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Baramin.Views
{
    public partial class DrinksPage : ContentPage
    {
        DrinksViewModel _viewModel;

        public DrinksPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new DrinksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}