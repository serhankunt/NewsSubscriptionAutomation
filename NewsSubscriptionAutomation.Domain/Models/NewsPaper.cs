using NewsSubscriptionAutomation.Domain.Enums;

namespace NewsSubscriptionAutomation.Domain.Models;

public class NewsPaper
{
    public int Id { get; set; }
    public NewsPaperEnum Name { get; set; } 
    public SubscriptionType SubscriptionType { get; set; }
    public ICollection<AppUser>? Users { get; set; }
}

