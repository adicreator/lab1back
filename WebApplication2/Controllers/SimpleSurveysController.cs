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
    public class SimpleSurveysController : ControllerBase
    {
        private readonly PIPOSTEST_Context _context;

        public SimpleSurveysController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: api/SimpleSurveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimpleSurvey>>> GetSimpleSurveys()
        {
            return await _context.SimpleSurveys.ToListAsync();
        }

        // GET: api/SimpleSurveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SimpleSurvey>> GetSimpleSurvey(int id)
        {
            var simpleSurvey = await _context.SimpleSurveys.FindAsync(id);

            if (simpleSurvey == null)
            {
                return NotFound();
            }

            return simpleSurvey;
        }

        // PUT: api/SimpleSurveys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSimpleSurvey(int id, SimpleSurvey simpleSurvey)
        {
            if (id != simpleSurvey.SsurveyId)
            {
                return BadRequest();
            }

            _context.Entry(simpleSurvey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimpleSurveyExists(id))
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

        // POST: api/SimpleSurveys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SimpleSurvey>> PostSimpleSurvey(SimpleSurvey simpleSurvey)
        {
            _context.SimpleSurveys.Add(simpleSurvey);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SimpleSurveyExists(simpleSurvey.SsurveyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSimpleSurvey", new { id = simpleSurvey.SsurveyId }, simpleSurvey);
        }

        // DELETE: api/SimpleSurveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSimpleSurvey(int id)
        {
            var simpleSurvey = await _context.SimpleSurveys.FindAsync(id);
            if (simpleSurvey == null)
            {
                return NotFound();
            }

            _context.SimpleSurveys.Remove(simpleSurvey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SimpleSurveyExists(int id)
        {
            return _context.SimpleSurveys.Any(e => e.SsurveyId == id);
        }
    }
}
