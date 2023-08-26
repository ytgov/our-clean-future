using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Extensions;

public static class LeadExtensions
{
    public static string ToFriendlyName(this List<Lead> leads)
    {
        if (leads.Count == 0)
        {
            return "None";
        }

        return string.Join(", ", leads.Select(l => l));
    }
}
