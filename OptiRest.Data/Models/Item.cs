using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Code { get; set; }
        public int ItemCategoryId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        [JsonIgnore]
        public ItemCategory? ItemCategory { get; set; }
    }
}
