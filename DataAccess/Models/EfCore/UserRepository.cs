using DataAccess.Interfaces.EfCore;

namespace DataAccess.Models.EfCore
{
    public class UserRepository : EfCoreRepository<AppUser, ApplicationDbContext>
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
