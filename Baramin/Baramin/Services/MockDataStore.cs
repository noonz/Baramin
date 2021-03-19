using Baramin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baramin.Services
{
    public class MockDataStore : IDataStore<Drink>
    {
        readonly List<Drink> items;

        public MockDataStore()
        {
            items = new List<Drink>()
            {
                new Drink { Id = Guid.NewGuid().ToString(), Text = "First drink", Description="This is a drink description." },
                new Drink { Id = Guid.NewGuid().ToString(), Text = "Second drink", Description="This is a drink description." },
                new Drink { Id = Guid.NewGuid().ToString(), Text = "Third drink", Description="This is a drink description." },
                new Drink { Id = Guid.NewGuid().ToString(), Text = "Fourth drink", Description="This is a drink description." },
                new Drink { Id = Guid.NewGuid().ToString(), Text = "Fifth drink", Description="This is a drink description." },
                new Drink { Id = Guid.NewGuid().ToString(), Text = "Sixth drink", Description="This is a drink description." }
            };
        }

        public async Task<bool> AddItemAsync(Drink item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Drink item)
        {
            var oldItem = items.Where((Drink arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Drink arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Drink> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Drink>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}