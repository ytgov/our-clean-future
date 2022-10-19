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

        var result = "";
        foreach (var directorsCommittee in directorsCommittees)
        {
            result += $"{directorsCommittee.Name}, ";
        }

        //Trim the trailing comma and space
        result = result.Remove(result.Length - 2, 2);
        return result;
    }
}
