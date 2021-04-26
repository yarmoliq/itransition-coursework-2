namespace itransition_coursework_2.Jwt
{
    public interface IJwtGenerator
    { 
        string CreateToken(DataAccess.Models.AppUser user);
    }
}
