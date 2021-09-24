using OurCleanFuture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App.Helpers
{
    public static class ImageHelpers
    {
        public static string GetAreaIconPath(Area area)
        {
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
        public static string GetGoalIconPath(Goal goal)
        {
            return goal.Id switch {
                1 => "/images/reduce-greenhouse-gas-emissions.png",
                2 => "/images/ensure-yukoners-have-access-to-reliable-affordable-and-renewable-energy.png",
                3 => "/images/adapt-to-the-impacts-of-climate-change.png",
                4 => "/images/build-a-green-economy.png",
                _ => ""
            };
        }
    }
}
