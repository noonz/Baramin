using Baramin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baramin.Services
{
    public class MockDataStore : IDataStore<Cocktail>
    {
        readonly List<Cocktail> items;

        public MockDataStore()
        {
            items = new List<Cocktail>()
            {
                new Cocktail { IdDrink = Guid.NewGuid().ToString(), DrinkName = "First drink", Instructions="This is a drink description." },
                new Cocktail { IdDrink = Guid.NewGuid().ToString(), DrinkName = "Second drink", Instructions="This is a drink description." },
                new Cocktail { IdDrink = Guid.NewGuid().ToString(), DrinkName = "Third drink", Instructions="This is a drink description." },
                new Cocktail { IdDrink = Guid.NewGuid().ToString(), DrinkName = "Fourth drink", Instructions="This is a drink description." },
                new Cocktail { IdDrink = Guid.NewGuid().ToString(), DrinkName = "Fifth drink", Instructions="This is a drink description." },
                new Cocktail { IdDrink = Guid.NewGuid().ToString(), DrinkName = "Sixth drink", Instructions="This is a drink description." }
            };
        }

        public async Task<bool> AddItemAsync(Cocktail item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Cocktail item)
        {
            var oldItem = items.Where((Cocktail arg) => arg.IdDrink == item.IdDrink).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Cocktail arg) => arg.IdDrink == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Cocktail> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IdDrink == id));
        }

        public async Task<IEnumerable<Cocktail>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}