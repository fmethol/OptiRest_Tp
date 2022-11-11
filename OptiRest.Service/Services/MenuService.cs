using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Context;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _db;

        public MenuService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MenuDto> GetMenu(int tenantId)
        {
            var tenant = await _db.Tenants.Include(t => t.BusinessConfig).FirstOrDefaultAsync(t => t.Id == tenantId);

            if (tenant == null)
            {
                return null;
            }

            var menu = new MenuDto
            {
                Restaurant = tenant,
                Categories = await _db.ItemCategories.Include(i => i.Items).Where(c => c.TenantId == tenantId).ToListAsync()
            };

            return menu;

        }
    }
}
