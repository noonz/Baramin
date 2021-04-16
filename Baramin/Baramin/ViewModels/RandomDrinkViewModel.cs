using Baramin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Baramin.ViewModels
{
    public class RandomDrinkViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static RandomDrinkViewModel _viewModelInstance;
        Database database = new Database();

        private string _apiAdressRecipe = "https://www.thecocktaildb.com/api/json/v1/1/random.php";

        public DrinkDetail _cocktail { get; set; }
        public string _mainLabel { get; set; }
        public DrinkDetail _recipeDetails { get; set; }
        public string _recipeImage { get; set; }
        public string _recipeTitle { get; set; }
        public string _recipeCategory { get; set; }
        public List<string> _recipeIngredients { get; set; }
        public List<string> _recipeMeasures { get; set; }
        public string _recipeInstructions { get; set; }
        public string _recipeIsAlcoholic { get; set; }

        public RandomDrinkViewModel()
        {
            _viewModelInstance = this;
            _cocktail = new DrinkDetail();
            _mainLabel = "Random Cocktail!";
            _ = SearchBestRecipes();
        }

        public void getCocktailDetails(DrinkDetail cocktail)
        {
            _recipeDetails = cocktail;
            _recipeImage = cocktail.StrDrinkThumb.ToString();
            _recipeTitle = cocktail.StrDrink;
            if (cocktail.StrCategory != null)
                _recipeCategory = cocktail.StrCategory;
            _recipeIngredients = new List<string>();
            _recipeMeasures = new List<string>();


            if (cocktail.StrIngredient1 != null)
                _recipeIngredients.Add(cocktail.StrIngredient1);
            if (cocktail.StrIngredient2 != null)
                _recipeIngredients.Add(cocktail.StrIngredient2);
            if (cocktail.StrIngredient3 != null)
                _recipeIngredients.Add(cocktail.StrIngredient3);
            if (cocktail.StrIngredient4 != null)
                _recipeIngredients.Add(cocktail.StrIngredient4);
            if (cocktail.StrIngredient5 != null)
                _recipeIngredients.Add(cocktail.StrIngredient5);
            if (cocktail.StrIngredient6 != null)
                _recipeIngredients.Add(cocktail.StrIngredient6);
            if (cocktail.StrIngredient7 != null)
                _recipeIngredients.Add(cocktail.StrIngredient7);
            if (cocktail.StrIngredient8 != null)
                _recipeIngredients.Add(cocktail.StrIngredient8);
            if (cocktail.StrIngredient9 != null)
                _recipeIngredients.Add(cocktail.StrIngredient9);


            if (cocktail.StrMeasure1 != null)
                _recipeMeasures.Add(cocktail.StrMeasure1);
            if (cocktail.StrMeasure2 != null)
                _recipeMeasures.Add(cocktail.StrMeasure2);
            if (cocktail.StrMeasure3 != null)
                _recipeMeasures.Add(cocktail.StrMeasure3);
            if (cocktail.StrMeasure4 != null)
                _recipeMeasures.Add(cocktail.StrMeasure4);
            if (cocktail.StrMeasure5 != null)
                _recipeMeasures.Add(cocktail.StrMeasure5);
            if (cocktail.StrMeasure6 != null)
                _recipeMeasures.Add(cocktail.StrMeasure6);
            if (cocktail.StrMeasure7 != null)
                _recipeMeasures.Add(cocktail.StrMeasure7);
            if (cocktail.StrMeasure8 != null)
                _recipeMeasures.Add(cocktail.StrMeasure8);
            if (cocktail.StrMeasure9 != null)
                _recipeMeasures.Add(cocktail.StrMeasure9);


            if (cocktail.StrInstructions != null)
                _recipeInstructions = cocktail.StrInstructions;

            if (cocktail.StrAlcoholic != null)
                _recipeIsAlcoholic = cocktail.StrAlcoholic;

            OnPropertyChanged("_recipeImage");
            OnPropertyChanged("_recipeTitle");
            OnPropertyChanged("_recipeIngredients");
            OnPropertyChanged("_recipeCategory");
            OnPropertyChanged("_recipeMeasures");
            OnPropertyChanged("_recipeInstructions");
            OnPropertyChanged("_recipeIsAlcoholic");
        }

        async Task SearchBestRecipes()
        {
            await GetBestRecipes();
        }

        async Task GetBestRecipes()
        {
            var client = new HttpClient();
            var apiAddress = _apiAdressRecipe;
            var uri = new Uri(apiAddress);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CocktailDetail>(jsonContent);
                if (data.Drinks[0] != null)
                {
                    _cocktail = data.Drinks[0];
                }
            }
        }

        protected void PropertiesChanged(string[] properties)
        {
            foreach (string p in properties)
            {
                OnPropertyChanged(p);
            }
        }

        public void IsFavourite(String favouriteId)
        {
            database.CheckIsFavourite(favouriteId);
        }

        public void AddToFavourite(Favourite fav)
        {
            database.InsertFavourite(fav);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

