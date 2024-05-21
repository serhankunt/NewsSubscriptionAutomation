using FluentValidation;
using Microsoft.AspNetCore.Identity;
using NewsSubscriptionAutomation.Domain.Models;

namespace NewsSubscriptionAutomation.Application.Features.Auth.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator(UserManager<AppUser> userManager)
    {
        RuleFor(p => p.Email).EmailAddress().MinimumLength(3)
           .WithMessage("Email address already exists");

        RuleFor(p => p.UserName).MinimumLength(3)
            .WithMessage("Username already exists");

        RuleFor(p => p.FirstName).MinimumLength(3);
        RuleFor(p => p.LastName).MinimumLength(2);
    }
}

