using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface ITenantService
    {
        Task<IEnumerable<TenantDto>> GetTenants();
        Task<TenantDto> GetTenant(int id);
        Task<TenantDto> AddTenant(TenantDto tenant);
        Task<TenantDto> UpdateTenant(TenantDto tenant);
        Task<int> DeleteTenant(int id);
    }
}
