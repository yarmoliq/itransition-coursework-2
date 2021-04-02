using Microsoft.EntityFrameworkCore;

namespace itransition_coursework_2.Models
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