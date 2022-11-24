using JanamApi.Data;
using JanamApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JanamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OutputsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Output>>> GetOutput(Input input)
        {
            string StoredProc = "exec Display_Client_Category_Analysis " +
            "@FinYear = " + input.FinYear + "," +
            "@FromDate = '" + input.FromDate + "'," +
            "@ToDate= '" + input.ToDate + "'";

            var result = await _context.Output.FromSqlRaw(StoredProc).ToListAsync();
            var strings = JsonConvert.SerializeObject(result);
            //return await _context.output.ToListAsync();
            return Ok(strings);
        }

        /*// GET: api/Outputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Output>>> GetOutput()
        {
            return await _context.Output.ToListAsync();
        }

        // GET: api/Outputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Output>> GetOutput(int id)
        {
            var output = await _context.Output.FindAsync(id);

            if (output == null)
            {
                return NotFound();
            }

            return output;
        }

        // PUT: api/Outputs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutput(int id, Output output)
        {
            if (id != output.client_id)
            {
                return BadRequest();
            }

            _context.Entry(output).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutputExists(id))
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

        // POST: api/Outputs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Output>> PostOutput(Output output)
        {
            _context.Output.Add(output);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOutput", new { id = output.client_id }, output);
        }

        // DELETE: api/Outputs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutput(int id)
        {
            var output = await _context.Output.FindAsync(id);
            if (output == null)
            {
                return NotFound();
            }

            _context.Output.Remove(output);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OutputExists(int id)
        {
            return _context.Output.Any(e => e.client_id == id);
        }*/
    }
}
