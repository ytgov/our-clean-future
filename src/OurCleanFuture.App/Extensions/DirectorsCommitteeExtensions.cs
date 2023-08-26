using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Extensions;

public static class DirectorsCommitteeExtensions
{
    public static string ToFriendlyName(this List<DirectorsCommittee> directorsCommittees)
    {
        if (directorsCommittees.Count == 0)
        {
            return "None";
        }

        return string.Join(", ", directorsCommittees.Select(x => x.Name));
    }
}
