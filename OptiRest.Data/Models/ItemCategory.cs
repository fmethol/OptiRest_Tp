using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}
