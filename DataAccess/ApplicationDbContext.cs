using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using DataAccess.Interfaces;

namespace DataAccess.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<NoteItem> NoteItems { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public string UserEmail { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected List<EntityEntry> GetAuditValues()
        {
            this.ChangeTracker.DetectChanges();
            return this.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added || t.State == EntityState.Modified)
                //.Select(t => t.Entity)
                //.Cast<IAuditable>()
                .ToList();
        }

        public override int SaveChanges()
        {
            var auditables = GetAuditValues();
            foreach (var auditable in auditables)
            {
                (auditable as IAuditable).Audit(UserEmail, auditable.State == EntityState.Added);
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entityEntries = GetAuditValues();
            foreach (var entityEntry in entityEntries)
            {
                (entityEntry.Entity as IAuditable).Audit(UserEmail, entityEntry.State == EntityState.Added);
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}