using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IItemService
    {
        Task<int> DeleteItem(int id);
        Task<ItemDto> CreateItem(ItemDto item);
        Task<ItemDto> GetItem(int id);
        Task<IEnumerable<ItemDto>> GetItems(int tenantId);
        Task<ItemDto> UpdateItem(ItemDto request);
    }
}
