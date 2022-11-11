using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class BusinessConfig
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string DisplayName{ get; set; }
        public string Slogan { get; set; }
        public string Logo { get; set; }
        public string Summary { get; set; }
    }
}
