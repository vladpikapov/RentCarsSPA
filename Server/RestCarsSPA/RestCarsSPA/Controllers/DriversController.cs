using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestCarsSPA;

namespace RestCarsSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly RestCarsDBContext _context;

        public DriversController(RestCarsDBContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drivers>>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drivers>> GetDrivers(string id)
        {
            var drivers = await _context.Drivers.FindAsync(id);

            if (drivers == null)
            {
                return NotFound();
            }

            return drivers;
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrivers(string id, Drivers drivers)
        {
            if (id != drivers.NumberDriverLicense)
            {
                return BadRequest();
            }

            _context.Entry(drivers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriversExists(id))
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

        // POST: api/Drivers
        [HttpPost]
        public async Task<ActionResult<Drivers>> PostDrivers(Drivers drivers)
        {
            _context.Drivers.Add(drivers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriversExists(drivers.NumberDriverLicense))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDrivers", new { id = drivers.NumberDriverLicense }, drivers);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drivers>> DeleteDrivers(string id)
        {
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(drivers);
            await _context.SaveChangesAsync();

            return drivers;
        }

        private bool DriversExists(string id)
        {
            return _context.Drivers.Any(e => e.NumberDriverLicense == id);
        }
    }
}
