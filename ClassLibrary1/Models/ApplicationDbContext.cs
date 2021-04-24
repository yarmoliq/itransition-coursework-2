using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<NoteItem> NoteItems { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}