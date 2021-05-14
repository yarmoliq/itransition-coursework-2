using DataAccess.Interfaces.EfCore;

namespace DataAccess.Models.EfCore
{
    public class NoteRepository : EfCoreRepository<NoteItem, ApplicationDbContext>
    {
        public NoteRepository(ApplicationDbContext context) : base(context) { }
    }
}
