using ShareFoodService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFoodService.Context
{
    public class ShareFoodContext : DbContext, ISharedFoodContext
    {
        public ShareFoodContext()
        {

        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
