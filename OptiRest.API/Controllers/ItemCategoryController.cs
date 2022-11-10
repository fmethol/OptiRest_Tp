using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemCategory([FromBody] ItemCategoryDto itemCategoryDto)
        {
            if (itemCategoryDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdItemCategory = await _itemCategoryService.AddItemCategory(itemCategoryDto);

            return Ok(createdItemCategory);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItemCategory(int id)
        {
            var deletedItemCategory = await _itemCategoryService.DeleteItemCategory(id);

            return Ok(deletedItemCategory);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItemCategory(int id)
        {
            var itemCategory = await _itemCategoryService.GetItemCategory(id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            return Ok(itemCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemCategories(int tenantId)
        {
            var itemCategories = await _itemCategoryService.GetItemCategories(tenantId);

            return Ok(itemCategories);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemCategory([FromBody] ItemCategoryDto itemCategoryDto)
        {
            if (itemCategoryDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedItemCategory = await _itemCategoryService.UpdateItemCategory(itemCategoryDto);

            return Ok(updatedItemCategory);
        }
    }
}
