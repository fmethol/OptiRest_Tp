using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;


namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            var lista = await _tenantService.GetTenants();

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTenant(int id)
        {
            var tenant = await _tenantService.GetTenant(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(tenant);
        }

        [HttpPost]
        public async Task<IActionResult> AddTenant([FromBody] TenantDto tenant)
        {
            if (tenant == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTenant = await _tenantService.AddTenant(tenant);

            return Ok(createdTenant);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTenant(TenantDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTenant = await _tenantService.UpdateTenant(request);

            return Ok(updatedTenant);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            var deletedTenant = await _tenantService.DeleteTenant(id);

            return Ok(deletedTenant);
        }

    }
}
