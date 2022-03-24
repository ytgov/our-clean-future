using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities;
public class User
{
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; } = "";
    public List<Lead> Leads { get; set; } = new();
}
