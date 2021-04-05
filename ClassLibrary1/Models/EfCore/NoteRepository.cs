using System;
using System.Collections.Generic;
using System.Text;

using ClassLibrary1.Interfaces.EfCore;

namespace ClassLibrary1.Models.EfCore
{
    public class NoteRepository : EfCoreRepository<NoteItem, NotesContext>
    {
        public NoteRepository(NotesContext context) : base(context) { }
    }
}
