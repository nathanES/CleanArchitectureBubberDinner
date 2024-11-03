using BubberDinner.Application.Common.Errors;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Check If user already exists
        if (userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();//1. Flow Control Exception
        }

        // 2. Create user(generate unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        userRepository.Add(user);

        // 3. Create JWT Token
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User does not exist");
        }

        // 2. Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Password is incorrect");
        }

        // 3. Generate JWT Token
        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}