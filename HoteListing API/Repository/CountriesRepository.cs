using HoteListing_API.Contracts;
using HoteListing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HoteListing_API.Repository;

public class CountriesRepository: GenericRepository<Country>, ICountriesRepository
{
     public CountriesRepository(ApplicationDbContext context):base(context)
     {
     }
     
     public async Task<List<Country>> GetAsiaCountry()
     {
          var countries = await _context.Countries.Where(x => true).ToListAsync();
          return countries;
     }
}