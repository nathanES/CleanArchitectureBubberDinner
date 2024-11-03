using BubberDinner.Application.Authentication;
using BubberDinner.Contracts.Authentication;

namespace BubberDinner.Api.Mappers;

public static class AuthenticationMapper
{
   public static AuthenticationResponse MapToResponse(this AuthenticationResult authenticationResult)
   {
      return new AuthenticationResponse(authenticationResult.Id,
         authenticationResult.FirstName,
         authenticationResult.LastName,
         authenticationResult.Email,
         authenticationResult.Token);
   }
}