using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems(int tenantId)
        {
            var items = await _itemService.GetItems(tenantId);

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _itemService.GetItem(id);
            
            if(item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemDto item)
        {
            if (item == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdItem = await _itemService.CreateItem(item);

            return Ok(createdItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedItem = await _itemService.UpdateItem(request);

            return Ok(updatedItem);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var deletedItem = await _itemService.DeleteItem(id);

            return Ok(deletedItem);
        }
    }
}
