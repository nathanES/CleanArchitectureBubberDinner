using BubberDinner.Api.Mappers;
using BubberDinner.Application.Authentication;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService): ControllerBase
{
   [HttpPost("register")]
   public IActionResult Register(RegisterRequest request)
   {
       var authResult = authenticationService.Register(request.FirstName,
           request.LastName,
           request.Email,
           request.Password);
       
       var response = authResult.MapToResponse();
       return Ok(response);
   }

   [HttpPost("login")]
   public IActionResult Login(LoginRequest request)
   {
       var authResult = authenticationService.Login(request.Email, request.Password);
       
       var response = authResult.MapToResponse();
       return Ok(response);
   }
}