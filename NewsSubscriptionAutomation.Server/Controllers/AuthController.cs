using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSubscriptionAutomation.Application.Features.Auth.Login;
using NewsSubscriptionAutomation.Application.Features.Auth.Register;

namespace NewsSubscriptionAutomation.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request,CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);

        return StatusCode(response.StatusCode,response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request,CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode,response);
    }
}
