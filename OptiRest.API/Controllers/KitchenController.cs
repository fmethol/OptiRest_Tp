using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private readonly IKitchenService _kitchenService;

        public KitchenController(IKitchenService kitchenService)
        {
            _kitchenService = kitchenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetKitchens(int tenantId)
        {
            var kitchens = await _kitchenService.GetKitchens(tenantId);
            return Ok(kitchens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKitchen(int id)
        {
            var kitchen = await _kitchenService.GetKitchen(id);
            return Ok(kitchen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKitchen(KitchenDto kitchenDto)
        {
            var kitchen = await _kitchenService.CreateKitchen(kitchenDto);
            return Ok(kitchen);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKitchen(KitchenDto kitchenDto)
        {
            var kitchen = await _kitchenService.UpdateKitchen(kitchenDto);
            return Ok(kitchen);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitchen(int id)
        {
            var kitchen = await _kitchenService.DeleteKitchen(id);
            return Ok(kitchen);
        }
        
    }
}
