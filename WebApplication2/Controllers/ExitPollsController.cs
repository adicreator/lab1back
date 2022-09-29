using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExitPollsController : ControllerBase
    {
        private readonly PIPOSTEST_Context _context;

        public ExitPollsController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: api/ExitPolls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExitPoll>>> GetExitPolls()
        {
            return await _context.ExitPolls.ToListAsync();
        }

        // GET: api/ExitPolls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExitPoll>> GetExitPoll(int id)
        {
            var exitPoll = await _context.ExitPolls.FindAsync(id);

            if (exitPoll == null)
            {
                return NotFound();
            }

            return exitPoll;
        }

        // PUT: api/ExitPolls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExitPoll(int id, ExitPoll exitPoll)
        {
            if (id != exitPoll.EpollId)
            {
                return BadRequest();
            }

            _context.Entry(exitPoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExitPollExists(id))
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

        // POST: api/ExitPolls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExitPoll>> PostExitPoll(ExitPoll exitPoll)
        {
            _context.ExitPolls.Add(exitPoll);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExitPollExists(exitPoll.EpollId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExitPoll", new { id = exitPoll.EpollId }, exitPoll);
        }

        // DELETE: api/ExitPolls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExitPoll(int id)
        {
            var exitPoll = await _context.ExitPolls.FindAsync(id);
            if (exitPoll == null)
            {
                return NotFound();
            }

            _context.ExitPolls.Remove(exitPoll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExitPollExists(int id)
        {
            return _context.ExitPolls.Any(e => e.EpollId == id);
        }
    }
}
