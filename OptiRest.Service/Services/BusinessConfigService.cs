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
    public class BusinessConfigService : IBusinessConfigService
    {
        private readonly AppDbContext _db;

        public BusinessConfigService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<BusinessConfigDto> AddBusinessConfig(BusinessConfigDto businessConfigDto)
        {
            if (businessConfigDto == null)
            {
                return null;
            }

            var businessConfig= new BusinessConfig
            {
                TenantId = businessConfigDto.TenantId,
                DisplayName = businessConfigDto.DisplayName,
                Slogan = businessConfigDto.Slogan,
                Logo = businessConfigDto.Logo,
                Summary = businessConfigDto.Summary
            };

            await _db.AddAsync(businessConfig);
            await _db.SaveChangesAsync();

            businessConfigDto.Id = businessConfig.Id;

            return businessConfigDto;


        }

        public async Task<BusinessConfigDto> GetBusinessConfig(int tenantId)
        {
            var businessConf = _db.BusinessConfigs.FirstOrDefault(b => b.TenantId == tenantId);

            if (businessConf == null)
            {
                return null;
            }

            var businessConfDto = new BusinessConfigDto
            {
                TenantId = businessConf.TenantId,
                DisplayName = businessConf.DisplayName,
                Slogan = businessConf.Slogan,
                Logo = businessConf.Logo,
                Summary = businessConf.Summary
            };

            return await Task.FromResult(businessConfDto);
        }
        
        public async Task<BusinessConfigDto> UpdateBusinessConfig(BusinessConfigDto request)
        {
            var businessConf = _db.BusinessConfigs.FirstOrDefault(b => b.TenantId == request.TenantId);

            if (businessConf == null)
            {
                return null;
            }

            businessConf.DisplayName = request.DisplayName;
            businessConf.Slogan = request.Slogan;
            businessConf.Logo = request.Logo;
            businessConf.Summary = request.Summary;

            await _db.SaveChangesAsync();

            return request;
        }
    }
}
