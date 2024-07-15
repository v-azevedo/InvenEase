using ErrorOr;
using InvenEase.Application.Services.Authentication.Commands;
using InvenEase.Application.Services.Authentication.Common;
using InvenEase.Application.Services.Authentication.Queries;
using InvenEase.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("auth")]
public class AuthenticationController(
    IAuthenticationQueryService authenticationQueryService,
    IAuthenticationCommandService authenticationCommandService) : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService = authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService = authenticationQueryService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(
            request.Email,
            request.Password);

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