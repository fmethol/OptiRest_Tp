using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Code { get; set; }
        public int ItemCategoryId { get; set; }
        public int KitchenId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        
        public ItemCategory? ItemCategory { get; set; }
        //public Kitchen? Kitchen { get; set; }
    }
}
