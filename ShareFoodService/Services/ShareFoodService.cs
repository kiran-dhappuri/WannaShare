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

        public async Task<int> SaveFoodItems(IEnumerable<FoodItem> items)
        {
            foreach(var item in items)
            {
                SaveFoodItem(item);
            }
            return await _context.SaveChangesAsync();
        }
        private void SaveFoodItem(FoodItem item)
        {
            _context?.FoodItems.Add(item);
        }

        public async Task<IEnumerable<FoodItem>> GetFoodItems()
        {
            return await _context?.FoodItems.Include(x=>x.Address).Include(x => x.PhoneNumbers).ToListAsync();
        }

        public async Task<FoodItem> GetFoodItem()
        {
            return await Task.FromResult(new FoodItem());
        }
    }
}
