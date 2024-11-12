using Microsoft.AspNetCore.Identity;

namespace HoteListing_API.Models;

public class ApiUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}