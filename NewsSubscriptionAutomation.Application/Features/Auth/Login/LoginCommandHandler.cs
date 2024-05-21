using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsSubscriptionAutomation.Domain.Models;
using TS.Result;

namespace NewsSubscriptionAutomation.Application.Features.Auth.Login;

public sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    IMediator mediator) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        
        var user = await userManager.Users.FirstOrDefaultAsync(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);

        if(user is null)
        {
            return Result<string>.Failure(errorMessage: "Kullanýcý adý veya email adresi bulunamadý");
        }
        

        var passwordCheck = await userManager.CheckPasswordAsync(user, request.Password);

        if (!passwordCheck) 
        {
            return Result<string>.Failure(errorMessage: "Þifre hatalý");
        }

        if (user.IsActive == false)
        {
            return Result<string>.Failure(errorMessage: "Admin onayý bekleniyor");
        }

        return Result<string>.Succeed("Giriþ iþlemi baþarýlý");
       
    }
}

