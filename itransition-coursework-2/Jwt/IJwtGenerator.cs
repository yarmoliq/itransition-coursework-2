namespace itransition_coursework_2.Jwt
{
    public interface IJwtGenerator
    { 
        string CreateToken(ClassLibrary1.Models.AppUser user);
    }
}
