using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly AppDbContext _db;

        public ItemCategoryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ItemCategoryDto> AddItemCategory(ItemCategoryDto itemCategoryDto)
        {
            if (itemCategoryDto == null)
            {
                return null;
            }

            var itemCategory = new ItemCategory
            {
                Id = itemCategoryDto.Id,
                TenantId = itemCategoryDto.TenantId,
                Name = itemCategoryDto.Name
            };

            await _db.AddAsync(itemCategory);
            await _db.SaveChangesAsync();

            itemCategoryDto.Id = itemCategory.Id;

            return itemCategoryDto;
        }

        public async Task<int> DeleteItemCategory(int id)
        {
            var itemCategory = _db.ItemCategories.FirstOrDefault(i => i.Id == id);

            if (itemCategory == null)
            {
                return 0;
            }

            _db.ItemCategories.Remove(itemCategory);
            await _db.SaveChangesAsync();

            return itemCategory.Id;
        }

        public async Task<ItemCategoryDto> GetItemCategory(int id)
        {
            var itemCategory = _db.ItemCategories.Include(i => i.Items).FirstOrDefault(i => i.Id == id);

            if (itemCategory == null)
            {
                return null;
            }

            var itemCategoryDto = new ItemCategoryDto
            {
                Id = itemCategory.Id,
                TenantId = itemCategory.TenantId,
                Name = itemCategory.Name,
                Items = itemCategory.Items
            };

            return await Task.FromResult(itemCategoryDto);
        }

        public async Task<IEnumerable<ItemCategoryDto>> GetItemCategories(int tenantId)
        {
            var itemCategories = await _db.ItemCategories
                .Where(i => i.TenantId == tenantId)
                .Select(i => new ItemCategoryDto
                {
                    Id = i.Id,
                    TenantId = i.TenantId,
                    Name = i.Name,
                    Items = i.Items
                }).ToListAsync();


            return itemCategories;
        }

        public async Task<ItemCategoryDto> UpdateItemCategory(ItemCategoryDto itemCategoryDto)
        {
            if (itemCategoryDto == null)
            {
                return null;
            }

            var itemCategory = _db.ItemCategories.FirstOrDefault(i => i.Id == itemCategoryDto.Id);

            if (itemCategory == null)
            {
                return null;
            }

            itemCategory.Id = itemCategoryDto.Id;
            itemCategory.TenantId = itemCategoryDto.TenantId;
            itemCategory.Name = itemCategoryDto.Name;

            await _db.SaveChangesAsync();

            return itemCategoryDto;
        }
    }
}
