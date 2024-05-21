using MediatR;
using TS.Result;

namespace NewsSubscriptionAutomation.Application.Features.Auth.Login;

public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password):IRequest<Result<string>>;

