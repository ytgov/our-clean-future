using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class User
{
    public int Id { get; set; }

    [EmailAddress] public string Email { get; set; } = "";

    public List<Lead> Leads { get; set; } = new();
}
