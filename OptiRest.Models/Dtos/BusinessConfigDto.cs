using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class BusinessConfigDto
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string DisplayName { get; set; }
        public string Slogan { get; set; }
        public string Logo { get; set; }
        public string Summary { get; set; }
    }
}
