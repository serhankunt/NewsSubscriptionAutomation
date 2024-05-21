using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSubscriptionAutomation.Infrastructure.Context;
using TS.Result;

namespace NewsSubscriptionAutomation.Server.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UserController(ApplicationDbContext context) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> ChangeIsActiveStatus(Guid userId)
    {
        var user = await context.Users.FirstOrDefaultAsync(p => p.Id == userId);
        if (user == null)
        {
            return BadRequest("Kullanıcı bulunamadı");
        }
        if(user.IsActive == true)
        {
            return BadRequest("Kullanıcı onaylanma işlemi daha önce gerçekleştirildi");
        }

        user.IsActive = !user.IsActive;

        context.SaveChanges();
        return Ok("Kullanıcı aktifleştirildi.");
    }
    [HttpGet]
    public IActionResult GetAllUser()
    {
        var userList = context.Users.ToList();

        return Ok(userList);
    }
}