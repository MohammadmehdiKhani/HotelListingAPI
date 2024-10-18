using System.ComponentModel.DataAnnotations;

namespace HoteListing_API.DTOs.Country;

public class CreateCountryDto
{
    [Required] public string Name { get; set; }
    public string ShortName { get; set; }
}