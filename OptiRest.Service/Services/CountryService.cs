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
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _db;

        public CountryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            var countries = await _db.Countries
                .Select(c => new CountryDto
            {
                Id = c.CountryId,
                Name = c.Name,
                //States = c.States
        })
            .ToListAsync();
            
            return countries;
        }

        public async Task<CountryDto> GetCountry(int countryId)
        {

            var country = _db.Countries.Include(c => c.States).FirstOrDefault(c => c.CountryId == countryId);

            if (country == null)
            {
                return null;
            }

            var countryDto = new CountryDto
                {
                Id = country.CountryId,
                Name = country.Name,
                States = country.States
            };

            return await Task.FromResult(countryDto);

        }
    }
}
