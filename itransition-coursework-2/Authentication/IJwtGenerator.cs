namespace itransition_coursework_2.Authentication
{
    public interface IJwtGenerator
    { 
        string CreateToken(DataAccess.Models.AppUser user);
    }
}
