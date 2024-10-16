using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NapiViccekController : ControllerBase
    {

        private readonly ViccDbContext _context;

        public NapiViccekController(ViccDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        //public ActionResult<List<Vicc>> GetViccek()
        //{
        //    return _context.Viccek.Where(x=>x.Aktiv).ToList();
        //}

        public async Task<ActionResult<List<Vicc>>> GetViccek()
        {
            return await _context.Viccek.Where(x => x.Aktiv).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vicc>> GetVicc(int id)
        {
            var vicc = await _context.Viccek.FindAsync(id);
            return vicc == null ? NotFound() : vicc;
        }

        [HttpPost]
        public async Task<ActionResult<Vicc>> PostVIcc(Vicc vicc)
        {
            _context.Viccek.Add(vicc);
            await _context.SaveChangesAsync();
            //return Ok(); //A válasz: 200 kód

            //A válasz maga a vicc
            return CreatedAtAction("GetVicc", new { id = vicc.Id }, vicc);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutVicc(int id, Vicc vicc)
        {
            if (id != vicc.Id)
                return BadRequest();

            _context.Entry(vicc).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteVicc(int id)
        {
            var vicc = await _context.Viccek.FindAsync(id);
            if (vicc == null)
                return NotFound();

            if (vicc.Aktiv == true)
            {
                vicc.Aktiv = false;
                _context.Entry(vicc).State = EntityState.Modified;
            }
            else
                _context.Viccek.Remove(vicc);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Route("{id}/like")]
        [HttpPatch("{id}")]

        public async Task<ActionResult<string>> Tetszik(int id)
        {
            var vicc = _context.Viccek.Find(id);
            if (vicc == null)
                return NotFound();

            vicc.Tetszik++;
            _context.Entry(vicc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok($"tdb: {vicc.Tetszik}");
        }

        [Route("{id}/dislike")]
        [HttpPatch("{id}")]

        public async Task<ActionResult> NemTetszik(int id)
        {
            var vicc = _context.Viccek.Find(id);
            if (vicc == null)
                return NotFound();

            vicc.NemTetszik++;
            _context.Entry(vicc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
