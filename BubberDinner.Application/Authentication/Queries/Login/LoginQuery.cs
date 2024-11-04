using BubberDinner.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace BubberDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;