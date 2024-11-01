using HoteListing_API.Contracts;
using HoteListing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HoteListing_API.Repository;

public class CountriesRepository: GenericRepository<Country>, ICountriesRepository
{
     public CountriesRepository(ApplicationDbContext context):base(context)
     {
     }

     public async Task<Country> GetDetails(int id)
     {
          return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);

     }
}