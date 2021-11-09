using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities;

public class DirectorsCommittee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<Action> Actions { get; set; } = new();
}
