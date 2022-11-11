using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<State> States { get; set; }
    }
}
