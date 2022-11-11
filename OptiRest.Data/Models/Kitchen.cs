using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class Kitchen
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        public List<User>? Users { get; set; }

    }
}
