using ErrorOr;
using InvenEase.Application.Authentication.Commands.Register;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Authentication.Queries.Login;
using InvenEase.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        return authResult.Match(
             authResult => Ok(MapAuthenticationResult(authResult)),
             errors => Problem(errors)
         );
    }

    private static AuthenticationResponse MapAuthenticationResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.User.Role.ToString(),
            authResult.Token);
    }
}