using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<NoteItem> NoteItems { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}