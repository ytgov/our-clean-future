using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Extensions;

public static class AreaExtensions
{
    public static string GetIconPath(this Area area)
    {
        if (area is not null) {
            return area.Id switch {
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
        else {
            return string.Empty;
        }
    }
}