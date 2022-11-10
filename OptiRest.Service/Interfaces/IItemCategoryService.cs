using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IItemCategoryService
    {
        Task<ItemCategoryDto> AddItemCategory(ItemCategoryDto itemCategoryDto);
        Task<int> DeleteItemCategory(int id);
        Task<ItemCategoryDto> UpdateItemCategory(ItemCategoryDto itemCategoryDto);
        Task<ItemCategoryDto> GetItemCategory(int id);
        Task<IEnumerable<ItemCategoryDto>> GetItemCategories(int tenantId);
    }
}
