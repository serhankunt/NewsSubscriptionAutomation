using NewsSubscriptionAutomation.Domain.Enums;

namespace NewsSubscriptionAutomation.Domain.Mapper;

public static class CityRegionMapper
{
    public static Region GetRegion(City city)
    {
        // Basit bir örnek haritalama
        return city switch
        {
            City.Istanbul or City.Bursa => Region.Marmara,
            City.Izmir or City.Manisa => Region.Ege,
            City.Antalya or City.Adana => Region.Akdeniz,
            City.Trabzon or City.Samsun => Region.Karadeniz,
            City.Ankara or City.Konya => Region.IcAnadolu,
            City.Erzurum or City.Van => Region.DoguAnadolu,
            City.Diyarbakir or City.Gaziantep => Region.GüneydoguAnadolu,
            _ => throw new ArgumentOutOfRangeException(nameof(city), city, null)
        };
    }
}

