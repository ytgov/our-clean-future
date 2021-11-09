using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities;

public class Area
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public List<Objective> Objectives { get; set; } = new();
}
