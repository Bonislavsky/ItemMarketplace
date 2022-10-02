using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemMarketplace.Database;
using ItemMarketplace.Models;
using ItemMarketplace.Services.Interface;

namespace ItemMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly MarketplaceDbContext _context;
        private readonly IItemService _itemService;

        public ItemsController(MarketplaceDbContext context, IItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _itemService.GetListEntity();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var sale = await _itemService.GetEntityById(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        [HttpPut("{id}")]
        public IActionResult PutItem(int id, Item item)
        {
            if (id != item.Id || !ItemExists(item.Id))
            {
                return BadRequest();
            }

            try
            {
                _itemService.UpdateEntity(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _itemService.CreateEntity(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (await _itemService.GetEntityById(id) == null)
            {
                return NotFound();
            }

            _itemService.DeleteEntityById(id);

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
