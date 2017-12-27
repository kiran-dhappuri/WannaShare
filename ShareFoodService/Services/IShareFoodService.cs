using ShareFoodService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareFoodService.Services
{
    public interface IShareFoodService
    {
        Task<int> SaveFoodItems();
        Task<IEnumerable<FoodItem>> GetFoodItems();
        Task<FoodItem> GetFoodItem();
    }
}