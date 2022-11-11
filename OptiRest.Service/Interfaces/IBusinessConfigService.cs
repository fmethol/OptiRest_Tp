using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IBusinessConfigService
    {
        Task<BusinessConfigDto> GetBusinessConfig(int tenantId);
        Task<BusinessConfigDto> AddBusinessConfig(BusinessConfigDto businessConfigDto);
        Task<BusinessConfigDto> UpdateBusinessConfig(BusinessConfigDto businessConfigDto);
    }
}
