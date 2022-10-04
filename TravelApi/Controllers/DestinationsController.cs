using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TravelApi.Models;
using System.Linq;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController :Controller
    {
        private readonly TravelApiContext _db;

        public DestinationsController(TravelApiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> Get(string city , string country , double overallRating)
        {
            var query = _db.Destination.AsQueryable();
            if(city != null)
            {
                query = query.Where(que => que.City == city);
            }
            if(country != null)
            {
                query = query.Where(que => que.Country == country);
            }
            if(overallRating != 0)
            {
                query = query.Where(que => que.OverallRating == overallRating);
            }

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(Destination destination)
        {
            _db.Destination.Add(destination);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDestination) , new {id = destination.DestinationId} , destination);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            var destination = await _db.Destination.FindAsync(id);

            if(destination == null)
            {
                return NotFound();
            }

            return destination;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Destination>> PutDestination(int id , Destination destination)
        {
            if(id != destination.DestinationId)
            {
                return BadRequest();
            }

            _db.Entry(destination).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!DestinationExists(id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Destination>> DeleteDestination(int id)
        {
            var destination = await _db.Destination.FindAsync(id);
            if(destination == null)
            {
                return NotFound();
            }

            _db.Destination.Remove(destination);
            await _db.SaveChangesAsync();
            
            return NoContent();
        }

        private bool DestinationExists(int id)
        {
            return _db.Destination.Any(dest => dest.DestinationId == id);
        }
    }
}