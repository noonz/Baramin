using System;
using System.Collections.Generic;
using System.ComponentModel;
using Baramin.Models;

namespace Baramin.ViewModels
{
    public class FavouriteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static FavouriteViewModel ViewModelInstance;
        Database database = new Database();
        public List<Favourite> FavouriteListView { get; set; }

        public FavouriteViewModel()
        {
            ViewModelInstance = this;
            GetFavourite();
        }

        public void GetFavourite()
        {
            FavouriteListView = database.GetFavourite();
            OnPropertyChanged("FavoriteListView");
        }

        public void InsertFavourite(Favourite fav)
        {
            database.InsertFavourite(fav);
            GetFavourite();
        }

        public void DeleteFavourite(string favoriteId)
        {
            database.DeleteFavourite(favoriteId);
            GetFavourite();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
