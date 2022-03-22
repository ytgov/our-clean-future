using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities;
public class User
{
    public int Id { get; set; }
    public string PrincipalName { get; set; } = "";
    public List<Role> Roles { get; set; } = new();
}
