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
    public class KitchenService : IKitchenService
    {
        private readonly AppDbContext _db;

        public KitchenService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<KitchenDto>> GetKitchens(int tenantId)
        {
            var kitchens = await _db.Kitchens
                .Where(k => k.TenantId == tenantId)
                .Select(k => new KitchenDto
                {
                    Id = k.Id,
                    TenantId = k.TenantId,
                    Name = k.Name,
                    Summary = k.Summary
                })
                .ToListAsync();

            return kitchens;
        }

        public async Task<KitchenDto> GetKitchen(int id)
        {
            var kitchen = _db.Kitchens.Include(k => k.Users)
                .FirstOrDefault(k => k.Id == id);

            if (kitchen == null)
            {
                return null;
            }

            var kitchenDto = new KitchenDto
            {
                Id = kitchen.Id,
                TenantId = kitchen.TenantId,
                Name = kitchen.Name,
                Summary = kitchen.Summary,
                Users = kitchen.Users.ToList()
            };

            return await Task.FromResult(kitchenDto);
        }

        public async Task<KitchenDto> CreateKitchen(KitchenDto kitchenDto)
        {
            if (kitchenDto == null)
            {
                return null;
            }

            var kitchen = new Kitchen
            {
                Id = kitchenDto.Id,
                Name = kitchenDto.Name,
                TenantId = kitchenDto.TenantId,
                Summary = kitchenDto.Summary
            };

            await _db.AddAsync(kitchen);
            await _db.SaveChangesAsync();

            kitchenDto.Id = kitchen.Id;

            return kitchenDto;
        }

        public async Task<KitchenDto> UpdateKitchen(KitchenDto kitchenDto)
        {

            var kitchen = _db.Kitchens.FirstOrDefault(k => k.Id == kitchenDto.Id);

            if (kitchen == null)
            {
                return null;
            }

            kitchen.Name = kitchenDto.Name;
            kitchen.TenantId = kitchenDto.TenantId;
            kitchen.Users = kitchenDto.Users;

            await _db.SaveChangesAsync();

            return kitchenDto;
        }

        public async Task<int> DeleteKitchen(int id)
        {
            var kitchen = _db.Kitchens.FirstOrDefault(k => k.Id == id);

            if (kitchen == null)
            {
                return 0;
            }

            _db.Kitchens.Remove(kitchen);
            await _db.SaveChangesAsync();

            return id;
        }
    }
}

