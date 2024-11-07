using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Queries.Login;
using BubberDinner.Contracts.Authentication;
using BubberDinner.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController( ISender mediator, IMapper mapper) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request); 
        var registerResult = await mediator.Send(command);
        return registerResult.Match(
            result => Ok(mapper.Map<AuthenticationResponse>(result)),
            errors =>  Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var authResult = await mediator.Send(query);

        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        } 
        return authResult.Match(
            result => Ok(mapper.Map<AuthenticationResponse>(result)),
            errors =>  Problem(errors));
    }
}