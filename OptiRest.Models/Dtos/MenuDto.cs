using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class MenuDto
    {
        public Tenant Restaurant { get; set; }
        public IEnumerable<ItemCategory> Categories { get; set; }

    }
}
