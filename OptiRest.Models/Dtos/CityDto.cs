using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class CityDto
    {
        public int id { get; set; }
        public int stateId { get; set; }
        public string city { get; set; }
    }
}
