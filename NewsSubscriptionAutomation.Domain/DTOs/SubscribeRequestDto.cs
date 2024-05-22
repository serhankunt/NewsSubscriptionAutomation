using NewsSubscriptionAutomation.Domain.Enums;

namespace NewsSubscriptionAutomation.Domain.DTOs;

public class SubscribeRequestDto
{
    public Guid UserId { get; set; }
    public NewsPaperEnum NewsPaper { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
}

