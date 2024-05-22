using NewsSubscriptionAutomation.Domain.Enums;

namespace NewsSubscriptionAutomation.Domain.Models;

public class Subscription
{
    public int Id { get; set; }
    public Guid AppUserId { get; set; }
    public AppUser User { get; set; }
    public NewsPaperEnum NewsPaper { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public bool IsApproved { get; set; }
    public Region Region { get; set; }
    public City City { get; set; }
}

