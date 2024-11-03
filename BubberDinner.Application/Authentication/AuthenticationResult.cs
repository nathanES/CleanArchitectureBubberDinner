using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Authentication;

public record AuthenticationResult( 
    User User,
    string Token);