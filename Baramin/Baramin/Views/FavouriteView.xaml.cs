using System;
using System.Collections.Generic;
using Baramin.Models;
using Baramin.ViewModels;
using SQLite;
using Xamarin.Forms;

namespace Baramin.Views
{
    public partial class FavouriteView : ContentPage
    {
        public FavouriteView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as FavouriteViewModel;
            vm.GetFavourite();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            // TODO
        }

        void Handle_Clicked_Remove(object sender, System.EventArgs e)
        {
            var menuItem = (Favourite)((MenuItem)sender).CommandParameter;
            var vm = BindingContext as FavouriteViewModel;
            vm.DeleteFavourite(menuItem.Id);
            vm.GetFavourite();
        }
    }
}
