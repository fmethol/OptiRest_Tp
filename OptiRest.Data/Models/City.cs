using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class City
    {
        [Key]
        public int cityId { get; set; }
        [Required]
        public string city { get; set; }
        public int stateId { get; set; }
    }
}
