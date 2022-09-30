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
using ItemMarketplace.Domain.Enum;

namespace ItemMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly MarketplaceDbContext _context;
        private readonly IAuctionService _auctionService;

        public AuctionsController(MarketplaceDbContext context, IAuctionService auctionService)
        {
            _context = context;
            _auctionService = auctionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetSales()
        {
            return await _auctionService.GetSales();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _auctionService.GetSale(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        /// <summary>
        /// something text 
        /// </summary>
        /// <param name="marketStatus"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<List<Sale>> GetSortedSales(MarketStatus marketStatus)
        {           
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutSale(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            try
            {
                _auctionService.UpdateSale(sale);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            await _auctionService.CreateSale(sale);

            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            if (await _auctionService.GetSale(id) == null)
            {
                return NotFound();
            }

            _auctionService.DeleteSale(id);

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
