using MediatR;
using NewsSubscriptionAutomation.Domain.Enums;
using NewsSubscriptionAutomation.Domain.Models;
using TS.Result;

namespace NewsSubscriptionAutomation.Application.Features.Auth.Register;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password,
    bool IsActive,
    City City,
    ICollection<NewsPaper> NewsPapers
    //Region Region,
  ): IRequest<Result<string>>;

