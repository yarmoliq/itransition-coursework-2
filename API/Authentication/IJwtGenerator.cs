namespace API.Authentication
{
    public interface IJwtGenerator
    { 
        string CreateToken(DataAccess.Models.AppUser user);
    }
}
