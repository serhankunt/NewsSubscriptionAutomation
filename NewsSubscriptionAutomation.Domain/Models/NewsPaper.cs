using NewsSubscriptionAutomation.Domain.Enums;

namespace NewsSubscriptionAutomation.Domain.Models;

public class NewsPaper
{
    public string Name { get; set; } = string.Empty;
    public bool IsSubscriber { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
}

