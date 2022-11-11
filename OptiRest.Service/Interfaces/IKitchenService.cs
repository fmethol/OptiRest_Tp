using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IKitchenService
    {
        Task<IEnumerable<KitchenDto>> GetKitchens(int tenantId);
        Task<KitchenDto> GetKitchen(int id);
        Task<KitchenDto> CreateKitchen(KitchenDto kitchenDto);
        Task<KitchenDto> UpdateKitchen(KitchenDto kitchenDto);
        Task<int> DeleteKitchen(int id);
    }
}
