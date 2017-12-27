using ShareFoodService.Context;
using ShareFoodService.Models;
using ShareFoodService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShareFoodService.Services
{
    public class FoodService : IShareFoodService
    {
        ISharedFoodContext _context;
        public FoodService(ISharedFoodContext context) {
            _context = context;
        }

        public async Task<int> SaveFoodItems()
        {
            var food = new FoodItem()
            {
                Name = "test1", Description = "test description"
            };
            _context?.FoodItems.Add(food);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodItem>> GetFoodItems()
        {
            return await _context?.FoodItems.ToListAsync();
        }

        public async Task<FoodItem> GetFoodItem()
        {
            return await Task.FromResult(new FoodItem());
        }
    }
}
