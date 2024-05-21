using MediatR;
using NewsSubscriptionAutomation.Domain.Models;

namespace NewsSubscriptionAutomation.Domain.Events;

public class AuthDomainEvent : INotification
{
    public readonly AppUser _user;
    public AuthDomainEvent(AppUser user)
    {
        _user = user;   
    }
}

