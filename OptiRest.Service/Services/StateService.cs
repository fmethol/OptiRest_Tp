using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.Service.Services
{
    public class StateService : IStateService
    {
        private readonly AppDbContext _db;

        public StateService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<StateDto>> GetStates()
        {
            var states = await _db.States
                .Select(s => new StateDto
                {
                    Id = s.StateId,
                    Name = s.Name,
                    CountryId = s.CountryId,
                    //Cities = s.Cities
                })
            .ToListAsync();

            return states;
        }

        public async Task<StateDto> GetState(int id)
        {
          
            var state = _db.States.Include(s => s.Cities).FirstOrDefault(s => s.StateId == id);

            if (state == null)
            {
                return null;
            }

            var stateDto = new StateDto
            {
                Id = state.StateId,
                Name = state.Name,
                CountryId = state.CountryId,
                Cities = state.Cities
            };

            return await Task.FromResult(stateDto);
       
        }
    }
}

