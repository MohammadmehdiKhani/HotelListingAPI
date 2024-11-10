using HoteListing_API.Contracts;
using HoteListing_API.Models;

namespace HoteListing_API.Repository;

public class HotelsRepository: GenericRepository<Hotel>, IHotelsRepository
{
    public HotelsRepository(ApplicationDbContext context) : base(context)
    {
    }
}