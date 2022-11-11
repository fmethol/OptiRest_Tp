using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("{tenantId:int}")]
        public async Task<IActionResult> GetMenu(int tenantId)
        {
            var menu = await _menuService.GetMenu(tenantId);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
    }
}
