using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Phone { get; set; }

        public BusinessConfig? BusinessConfig { get; set; }

    }
}
