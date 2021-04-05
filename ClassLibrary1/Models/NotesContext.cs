using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Models
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<NoteItem> NoteItems { get; set; }
    }
}