using ClassLibrary1.Interfaces.EfCore;

namespace ClassLibrary1.Models.EfCore
{
    public class NoteRepository : EfCoreRepository<NoteItem, ApplicationDbContext>
    {
        public NoteRepository(ApplicationDbContext context) : base(context) { }
    }
}
