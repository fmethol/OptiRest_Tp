using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Service.Interfaces;
using OptiRest.Models.Dtos;
using OptiRest.Service.Services;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            var lista = await _stateService.GetStates();

            return Ok(lista);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetState(int id)
        {
            var state = await _stateService.GetState(id);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }
    }
}
