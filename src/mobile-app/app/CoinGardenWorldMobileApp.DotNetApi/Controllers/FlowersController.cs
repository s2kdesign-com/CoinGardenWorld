using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.DotNetApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [ApiController]
    [Route("api/[controller]")]
    public class FlowersController : ControllerBase
    {
        private readonly MobileAppDbContext _context;

        public FlowersController(MobileAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Flowers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlowerDTO>>> GetFlowers()
        {
          if (_context.Flowers == null)
          {
              return NotFound();
          }
            return await _context.Flowers.ToListAsync();
        }

        // GET: api/Flowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlowerDTO>> GetFlowerDTO(Guid id)
        {
          if (_context.Flowers == null)
          {
              return NotFound();
          }
            var flowerDTO = await _context.Flowers.FindAsync(id);

            if (flowerDTO == null)
            {
                return NotFound();
            }

            return flowerDTO;
        }

        // PUT: api/Flowers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlowerDTO(Guid id, FlowerDTO flowerDTO)
        {
            if (id != flowerDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(flowerDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerDTOExists(id))
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

        // POST: api/Flowers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlowerDTO>> PostFlowerDTO(FlowerDTO flowerDTO)
        {
          if (_context.Flowers == null)
          {
              return Problem("Entity set 'MobileAppDbContext.Flowers'  is null.");
          }
            _context.Flowers.Add(flowerDTO);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlowerDTOExists(flowerDTO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlowerDTO", new { id = flowerDTO.Id }, flowerDTO);
        }

        // DELETE: api/Flowers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlowerDTO(Guid id)
        {
            if (_context.Flowers == null)
            {
                return NotFound();
            }
            var flowerDTO = await _context.Flowers.FindAsync(id);
            if (flowerDTO == null)
            {
                return NotFound();
            }

            _context.Flowers.Remove(flowerDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlowerDTOExists(Guid id)
        {
            return (_context.Flowers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
