using Microsoft.AspNetCore.Identity;
using NewsSubscriptionAutomation.Domain.Enums;
using NewsSubscriptionAutomation.Domain.Mapper;

namespace NewsSubscriptionAutomation.Domain.Models;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => GetName();
    public bool IsActive { get; set; } = false;
    //public Region Region => CityRegionMapper.GetRegion(City);
    public City City {  get; set; }
    public ICollection<NewsPaper>? NewsPapers {  get; set; }

    public string GetName()
    {
        return string.Join(" ",FirstName,LastName);
    }
}

