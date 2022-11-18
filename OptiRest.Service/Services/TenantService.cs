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
    public class TenantService : ITenantService
    {
        private readonly AppDbContext _db;

        public TenantService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TenantDto>> GetTenants()
        {
            var tenants = await _db.Tenants
                .Select(t => new TenantDto
                {
                    Id = t.Id,
                    BusinessName = t.BusinessName,
                    Address = t.Address,
                    CountryId = t.CountryId,
                    StateId = t.StateId,
                    CityId = t.CityId,
                    Email = t.Email,
                    Web = t.Web,
                    Phone = t.Phone,
                    BusinessConfig = t.BusinessConfig
                }).ToListAsync();

            return tenants;
        }

        public async Task<TenantDto> GetTenant(int id)
        {

            var tenant =  _db.Tenants.Include(t => t.BusinessConfig).FirstOrDefault(t => t.Id == id);

            if (tenant == null)
            {
                return null;
            }

            var tenantDto = new TenantDto
            {
                Id = tenant.Id,
                BusinessName = tenant.BusinessName,
                Address = tenant.Address,
                CountryId = tenant.CountryId,
                StateId = tenant.StateId,
                CityId = tenant.CityId,
                Email = tenant.Email,
                Web = tenant.Web,
                Phone = tenant.Phone,
                BusinessConfig = tenant.BusinessConfig
            };

            return await Task.FromResult(tenantDto);
        }

        public async Task<TenantDto> AddTenant(TenantDto tenantDto)
        {
            if (tenantDto == null)
            {
                return null;
            }

            var tenant = new Tenant
            {
                BusinessName = tenantDto.BusinessName,
                Address = tenantDto.Address,
                CountryId = tenantDto.CountryId,
                StateId = tenantDto.StateId,
                CityId = tenantDto.CityId,
                Email = tenantDto.Email,
                Web = tenantDto.Web,
                Phone = tenantDto.Phone
            };

            await _db.AddAsync(tenant);
            await _db.SaveChangesAsync();

            tenantDto.Id = tenant.Id;

            return tenantDto;


        }

        public async Task<TenantDto> UpdateTenant(TenantDto request)
        {
            var tenant = await _db.Tenants.FirstOrDefaultAsync(t => t.Id == request.Id);

            if (tenant == null)
            {
                return null;
            }

            tenant.BusinessName = request.BusinessName;
            tenant.Address = request.Address;
            tenant.CountryId = request.CountryId;
            tenant.StateId = request.StateId;
            tenant.CityId = request.CityId;
            tenant.Email = request.Email;
            tenant.Web = request.Web;
            tenant.Phone = request.Phone;

            await _db.SaveChangesAsync();

            return request;
        }



        public async Task<int> DeleteTenant(int id)
        {
            var tenant = await _db.Tenants.FirstOrDefaultAsync(t => t.Id == id);

            if (tenant == null)
            {
                return 0;
            }

            _db.Tenants.Remove(tenant);
            await _db.SaveChangesAsync();

            return tenant.Id;
        }

    }

      
}
