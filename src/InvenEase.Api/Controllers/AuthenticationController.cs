using ErrorOr;

using InvenEase.Application.Authentication.Commands.Register;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Authentication.Queries.Login;
using InvenEase.Contracts.Authentication;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        return authResult.Match(
             authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
             errors => Problem(errors));
    }
}