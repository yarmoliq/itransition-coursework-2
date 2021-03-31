using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using itransition_coursework_2.Models;

namespace itransition_coursework_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Note : ControllerBase
    {
        private readonly NotesContext _context;

        public Note(NotesContext context)
        {
            _context = context;
        }

        // GET: api/Note
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteItem>>> GetNoteItems()
        {
            return await _context.NoteItems.ToListAsync();
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteItem>> GetNoteItem(long id)
        {
            var noteItem = await _context.NoteItems.FindAsync(id);

            if (noteItem == null)
            {
                return NotFound();
            }

            return noteItem;
        }

        // PUT: api/Note/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteItem(long id, NoteItem noteItem)
        {
            if (id != noteItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(noteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteItemExists(id))
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

        // POST: api/Note
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NoteItem>> PostNoteItem(NoteItem noteItem)
        {
            _context.NoteItems.Add(noteItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoteItem", new { id = noteItem.Id }, noteItem);
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteItem>> DeleteNoteItem(long id)
        {
            var noteItem = await _context.NoteItems.FindAsync(id);
            if (noteItem == null)
            {
                return NotFound();
            }

            _context.NoteItems.Remove(noteItem);
            await _context.SaveChangesAsync();

            return noteItem;
        }

        private bool NoteItemExists(long id)
        {
            return _context.NoteItems.Any(e => e.Id == id);
        }
    }
}
