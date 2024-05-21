using NewsSubscriptionAutomation.Domain.Enums;

namespace NewsSubscriptionAutomation.Domain.Mapper;

public static class CityRegionMapper
{
    private static readonly Dictionary<City, Region> cityRegionMap = new Dictionary<City, Region>
    {
        { City.Istanbul, Region.Marmara },
        { City.Bursa, Region.Marmara },
        { City.Izmir, Region.Ege },
        { City.Manisa, Region.Ege },
        { City.Antalya, Region.Akdeniz },
        { City.Adana, Region.Akdeniz },
        { City.Trabzon, Region.Karadeniz },
        { City.Samsun, Region.Karadeniz },
        { City.Ankara, Region.IcAnadolu },
        { City.Konya, Region.IcAnadolu },
        { City.Erzurum, Region.DoguAnadolu },
        { City.Van, Region.DoguAnadolu },
        { City.Diyarbakir, Region.GüneydoguAnadolu },
        { City.Gaziantep, Region.GüneydoguAnadolu }
    };

    public static Region GetRegion(City city)
    {
        if (cityRegionMap.TryGetValue(city, out Region region))
        {
            return region;
        }
        throw new ArgumentException("Invalid city", nameof(city));
    }
}

