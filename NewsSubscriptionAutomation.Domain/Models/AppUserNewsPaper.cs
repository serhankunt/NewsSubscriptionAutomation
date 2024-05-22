namespace NewsSubscriptionAutomation.Domain.Models;

public class AppUserNewsPaper
{
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int NewsPaperId { get; set; }
    public NewsPaper NewsPaper { get; set; }
}

