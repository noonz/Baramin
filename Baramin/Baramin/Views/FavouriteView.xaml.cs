using System;
using System.Collections.Generic;
using System.Linq;
using Baramin.Models;
using Baramin.ViewModels;
using Firebase.Database;
using Firebase.Database.Query;
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

            // firebase
            //FirebaseClient fc = new FirebaseClient("https://baraminfirebase-default-rtdb.firebaseio.com/");
            //var GetFavs = (await fc
            //    .Child("Favourites")
            //    .OnceAsync<Favourite>()).Select(item => new Favourite
            //    {
            //        Id = item.Object.Id,
            //        Name = item.Object.Name,
            //        PhotoUrl = item.Object.PhotoUrl,
            //        Type = item.Object.Type
            //    }).ToList().OrderBy(i => i.Name);
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

            // remove from firebase database
            DeleteFromFirebase(menuItem.Id);
        }

        private async void DeleteFromFirebase(string menuItem)
        {
            FirebaseClient fc = new FirebaseClient("https://baraminfirebase-default-rtdb.firebaseio.com/");
            await fc
                .Child("Favourites")
                .Child(menuItem)
                .DeleteAsync();
        }
    }
}
