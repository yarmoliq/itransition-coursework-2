using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ClassLibrary1.Models;
using ClassLibrary1.Models.EfCore;

namespace itransition_coursework_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Note : ControllerBase
    {
        private readonly NoteRepository _repository;

        public Note(NoteRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteItem>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteItem>> Get(int id)
        {
            var note = await _repository.Get(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, NoteItem note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }
            await _repository.Update(note);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<NoteItem>> Post(NoteItem note)
        {
            await _repository.Add(note);
            return CreatedAtAction("Get", new { id = note.Id }, note);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteItem>> Delete(int id)
        {
            var note = await _repository.Delete(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }
    }
}
