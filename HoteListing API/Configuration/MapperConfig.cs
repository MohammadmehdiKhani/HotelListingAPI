using AutoMapper;
using HoteListing_API.DTOs.Country;
using HoteListing_API.DTOs.Hotel;
using HoteListing_API.Models;

namespace HoteListing_API.Configuration;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();
        
        CreateMap<Hotel, HotelDto>().ReverseMap();
    }
}