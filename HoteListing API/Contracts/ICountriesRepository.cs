using HoteListing_API.Models;

namespace HoteListing_API.Contracts;

public interface ICountriesRepository : IGenericRepository<Country>
{
    Task<Country> GetDetails(int id);
}