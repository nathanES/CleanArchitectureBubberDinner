using BubberDinner.Application.Interfaces.Authentication;

namespace BubberDinner.Application.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check If user already exists
        
        //Create user(generate unique ID)
        
        //Create JWT Token
        Guid userId = Guid.NewGuid();
        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstname", "lastname", email, "token");
    }
}