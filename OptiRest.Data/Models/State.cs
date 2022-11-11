using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
