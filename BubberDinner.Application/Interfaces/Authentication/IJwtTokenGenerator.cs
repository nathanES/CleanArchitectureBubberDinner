using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);

}