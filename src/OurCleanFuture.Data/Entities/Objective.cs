using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities
{
    public class Objective
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int AreaId { get; set; }
        public Area Area { get; set; } = null!;
        public List<Goal> Goals { get; set; } = new();
        public List<Action> Actions { get; set; } = new();
        public List<Indicator> Indicators { get; set; } = new();
    }
}
