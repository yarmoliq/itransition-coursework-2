using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DataAccess.Models;
using DataAccess.Models.EfCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteRepository noteRepository;

        public NoteController(NoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteItem>>> Get()
        {
            return await noteRepository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteItem>> Get(Guid id)
        {
            var note = await noteRepository.Get(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, NoteItem note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }
            await noteRepository.Update(note);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<NoteItem>> Post(NoteItem note)
        {
            await noteRepository.Add(note);
            return CreatedAtAction("Get", new { id = note.Id }, note);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteItem>> Delete(Guid id)
        {
            var note = await noteRepository.Delete(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }
    }
}
