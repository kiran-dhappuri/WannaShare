using ShareFoodService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShareFoodService.Context
{
    public interface ISharedFoodContext
    {
        DbSet<FoodItem> FoodItems { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }
        


        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}
