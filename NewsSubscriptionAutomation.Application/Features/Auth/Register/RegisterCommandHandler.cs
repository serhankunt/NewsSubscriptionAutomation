using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsSubscriptionAutomation.Domain.Enums;
using NewsSubscriptionAutomation.Domain.Events;
using NewsSubscriptionAutomation.Domain.Models;
using TS.Result;

namespace NewsSubscriptionAutomation.Application.Features.Auth.Register;

public class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMediator mediator) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool isUserNameExists = await userManager.Users.AnyAsync(p=>p.UserName == request.UserName,cancellationToken);
        if(isUserNameExists)
        {
            return Result<string>.Failure(errorMessage: "Kullanýcý adý daha önce kullanýldý");
        }

        bool isEmailExist = await userManager.Users.AnyAsync(p=>p.Email == request.Email,cancellationToken);

        if(isEmailExist)
        {
            return Result<string>.Failure(errorMessage: "Mail adresi daha önce kullanýldý");
        }

        bool isCity = await userManager.Users.AnyAsync(p => p.City == request.City, cancellationToken);

        if (isCity)
        {
            return Result<string>.Failure(errorMessage: "Lütfen geçerli bir þehir giriniz.");
        }
       
        AppUser user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email.ToLower().Trim(),
            UserName = request.UserName,
            City = request.City,    
        };

       
            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if(!result.Succeeded)
            {
                List<string> errorMessages = result.Errors.Select(s=>s.Description).ToList();
                return Result<string>.Failure(errorMessages);
            }

            await mediator.Publish(new AuthDomainEvent(user));

        return Result<string>.Succeed("Kullanýcý baþarýlý bir þekilde oluþturuldu");
        

    }
}

