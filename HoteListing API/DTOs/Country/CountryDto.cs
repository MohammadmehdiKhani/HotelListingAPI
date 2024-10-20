using HoteListing_API.DTOs.Hotel;
using HoteListing_API.Models;

namespace HoteListing_API.DTOs.Country;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }

    public List<HotelDto> Hotels { get; set; }
}