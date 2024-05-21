using FluentValidation;
using Microsoft.AspNetCore.Identity;
using NewsSubscriptionAutomation.Domain.Models;

namespace NewsSubscriptionAutomation.Application.Features.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p=>p.UserNameOrEmail)
            .NotEmpty().WithMessage("Username ya da mail adres kýsmý boþ olamaz");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Þifre kýsmý boþ olamaz");
    }
}

