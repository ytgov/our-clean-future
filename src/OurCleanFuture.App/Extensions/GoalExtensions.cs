using OurCleanFuture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App.Extensions
{
    public static class GoalExtensions
    {
        public static string GetIconPath(this Goal goal)
        {
            if (goal is not null) {
                return goal.Id switch {
                    1 => "/images/reduce-greenhouse-gas-emissions.png",
                    2 => "/images/ensure-yukoners-have-access-to-reliable-affordable-and-renewable-energy.png",
                    3 => "/images/adapt-to-the-impacts-of-climate-change.png",
                    4 => "/images/build-a-green-economy.png",
                    _ => ""
                };
            }
            else {
                return string.Empty;
            }
        }
    }
}
