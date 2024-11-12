using System.ComponentModel.DataAnnotations;

namespace HoteListing_API.DTOs.Users;

public class ApiUserDto : LoginDto
{
    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }
}