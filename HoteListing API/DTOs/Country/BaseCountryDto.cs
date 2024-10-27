using Microsoft.Build.Framework;

namespace HoteListing_API.DTOs.Country;

public abstract class BaseCountryDto
{
    [Required]
    public string Name { get; set; }
    public string ShortName { get; set; }
}