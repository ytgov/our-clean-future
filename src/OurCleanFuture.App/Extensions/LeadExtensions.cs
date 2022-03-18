using OurCleanFuture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App.Extensions;
public static class LeadExtensions
{
    public static string ToFriendlyName(this List<Lead> leads)
    {
        if (leads.Count == 0) {
            return "None";
        }
        else {
            var result = "";
            foreach (var lead in leads) {
                result += $"{lead}, ";
            }
            //Trim the trailing comma and space
            result = result.Remove(result.Length - 2, 2);
            return result;
        }
    }
}
