using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessConfigController : ControllerBase
    {
        private readonly IBusinessConfigService _businessConfigService;

        public BusinessConfigController(IBusinessConfigService businessConfigService)
        {
            _businessConfigService = businessConfigService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBusinessConfig([FromBody] BusinessConfigDto businessConfigDto)
        {
            if (businessConfigDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBusinessConfig = await _businessConfigService.AddBusinessConfig(businessConfigDto);

            return Ok(createdBusinessConfig);
        }

        [HttpGet("{tenantId:int}")]
        public async Task<IActionResult> GetBusinessConfig(int tenantId)
        {
            var businessConfig = await _businessConfigService.GetBusinessConfig(tenantId);

            if (businessConfig == null)
            {
                return NotFound();
            }

            return Ok(businessConfig);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusinessConfig(BusinessConfigDto request)
        {

            var updatedBusinessConfig = await _businessConfigService.UpdateBusinessConfig(request);

            return Ok(updatedBusinessConfig);
        }

    }
}
