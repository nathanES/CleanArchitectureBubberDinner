using BubberDinner.Api.Mappers;
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Contracts.Authentication;
using BubberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = authenticationService.Register(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        return registerResult.Match(
            result => Ok(result.MapToResponse()),
            errors =>  Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = authenticationService.Login(request.Email, request.Password);

        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        } 
        return authResult.Match(
            result => Ok(result.MapToResponse()),
            errors =>  Problem(errors));
    }
}