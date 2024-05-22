using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSubscriptionAutomation.Domain.DTOs;
using NewsSubscriptionAutomation.Domain.Enums;
using NewsSubscriptionAutomation.Domain.Models;
using NewsSubscriptionAutomation.Infrastructure.Context;

namespace NewsSubscriptionAutomation.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubscriptionController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost("subscribe")]
    public async Task<IActionResult> Subscribe(SubscribeRequestDto request)
    {
        //var user = await context.Users.FindAsync(request.UserId);

        var user = await context.Users.Include(u => u.UserNewsPapers)
                                      .Include(u => u.Subscriptions)
                                      .FirstOrDefaultAsync(u => u.Id == request.UserId);
        if (user == null)
        {
            return BadRequest("Kullanıcı bulunamadı");
        }

        if (!Enum.IsDefined(typeof(NewsPaperEnum), request.NewsPaper))
        {
            return BadRequest("Invalid newspaper");
        }

        var newspaper = await context.NewsPapers.FirstOrDefaultAsync(p => p.Name == request.NewsPaper);
        if (newspaper == null)
        {
            newspaper = new NewsPaper
            {
                Name = request.NewsPaper,
                SubscriptionType = request.SubscriptionType
            };
            context.NewsPapers.Add(newspaper);
        }

        var subscription = new Subscription
        {
            AppUserId = request.UserId,
            NewsPaper = request.NewsPaper,
            SubscriptionType = request.SubscriptionType,
            IsApproved = false,
            Region = user.Region,
            City = user.City,
        };
        context.Subscriptions.Add(subscription);

        var userNewsPaper = new AppUserNewsPaper
        {
            AppUserId = user.Id,
            NewsPaperId = newspaper.Id
        };

        context.AppUserNewsPapers.Add(userNewsPaper);

        await context.SaveChangesAsync();

        return Ok("Abonelik isteği gönderildi");
    }

    [HttpPost("approve")]
    public async Task<IActionResult> ApproveSubscription(ApproveSubscriptionRequestDto request)
    {
        var subscription = await context.Subscriptions.FindAsync(request.SubscriptionId);
        if (subscription == null)
        {
            return BadRequest("Abonelik talebi bulunamadı");
        }

        subscription.IsApproved = true;
        await context.SaveChangesAsync();

        return Ok("Abonelik başvurusu onaylandı");
    }

    [HttpGet("subscriptionsByRegion")]
    public async Task<IActionResult> GetSubscriptionsByRegion(Region region)
    {
        var subscriptions = await context.Subscriptions
            .Where(s => s.Region == region)
            .ToListAsync();
        var count = subscriptions.Count();

        return Ok($"{region} bölgesinde {count}  abone mevcut.");
    }

    [HttpGet("subscriotionsByCity")]
    public async Task<IActionResult> GetSubscriptionsByCity(City city)
    {
        var subscriptions = await context.Subscriptions
            .Where(s=>s.City == city)
            .ToListAsync();
        var count = subscriptions.Count();

        return Ok($"{city} şehrinde {count} abone mevcut.");
    }
}
