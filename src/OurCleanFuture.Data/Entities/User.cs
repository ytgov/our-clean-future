using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities;
public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = "";
    public List<Lead> Leads { get; set; } = new();
}
