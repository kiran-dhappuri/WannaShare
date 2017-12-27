using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFoodService.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO: currently only one number supported
        public PhoneNumber PhoneNumbers { get; set; }
        public Address Address { get; set; }
    }
}
