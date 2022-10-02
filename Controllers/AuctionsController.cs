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
            try
            {
                return await _auctionService.GetListEntity();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            try
            {
                var sale = await _auctionService.GetEntityById(id);

                if (sale == null)
                {
                    return NotFound();
                }

                return sale;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>Get Sorting Sales</summary>
        /// <remarks></remarks>
        /// <param name="salesNames">
        /// sales names.
        /// </param>
        /// <param name="status">
        /// 1 - None 2 - Canceled 3 - Finished 4 - Active
        /// </param>
        /// <param name="sort_key">
        /// 1 - CreatedDt 2 - Price
        /// </param>
        /// <param name="sort_order">
        /// 1 - ASC 2 - DESC
        /// </param>
        /// <returns>Sorting List Sales(by key: CreatedDt, Price, by order: ASC, DESC)</returns>
        /// <response code="400">no options selected:status/sort_key/sort_order</response>    
        [ProducesResponseType(400)]
        [HttpGet("SortedSales/{salesNames}")]
        public async Task<ActionResult<List<Sale>>> GetSortedSales(string salesNames, MarketStatus status, SortingBy sort_key, OrderBy sort_order)
        {
            if (status == 0 || sort_key == 0 || sort_order == 0)
            {
                return BadRequest();
            }
            try
            {
                return await _auctionService.GetSortingSales(salesNames, status, sort_key, sort_order);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutSale(int id, Sale sale)
        {
            if (id != sale.Id || !SaleExists(sale.Id))
            {
                return BadRequest();
            }

            try
            {
                _auctionService.UpdateEntity(sale);
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
            try
            {
                await _auctionService.CreateEntity(sale);

                return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            try
            {
                if (await _auctionService.GetEntityById(id) == null)
                {
                    return NotFound();
                }

                _auctionService.DeleteEntityById(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
