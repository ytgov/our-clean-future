using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Extensions;

public static class AreaExtensions
{
    public static string GetIconPath(this Area area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return area.Id switch
        {
            1 => "/images/transportation.png",
            2 => "/images/homes-and-buildings.png",
            3 => "/images/energy-production.png",
            4 => "/images/people-and-the-environment.png",
            5 => "/images/communities.png",
            6 => "/images/innovation.png",
            7 => "/images/leadership.png",
            _ => ""
        };
    }

    public static string GetCssClass(this Area area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area));
        }

        return area.Id switch
        {
            1 => "transportation",
            2 => "homes-and-buildings",
            3 => "energy-production",
            4 => "people-and-the-environment",
            5 => "communities",
            6 => "innovation",
            7 => "leadership",
            _ => ""
        };
    }
}
