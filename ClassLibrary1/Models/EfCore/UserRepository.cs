using ClassLibrary1.Interfaces.EfCore;

namespace ClassLibrary1.Models.EfCore
{
    public class UserRepository : EfCoreRepository<AppUser, ApplicationDbContext>
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
