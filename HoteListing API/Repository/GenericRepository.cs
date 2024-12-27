using AutoMapper;
using AutoMapper.QueryableExtensions;
using HoteListing_API.Contracts;
using HoteListing_API.DTOs;
using HoteListing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HoteListing_API.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApplicationDbContext _context { get; set; }
    private readonly IMapper _mapper;

    public GenericRepository(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<T> GetAsync(int? id)
    {
        if (id == null)
            return null;
        return await _context.Set<T>().FindAsync(id);
    }

    public Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().ToListAsync();
    }

    public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
    {
        var totalSize = await _context.Set<T>().CountAsync();
        var items = await _context.Set<T>()
            .Skip(queryParameters.StartIndex + queryParameters.PageSize * (queryParameters.PageNumber - 1))
            .Take(queryParameters.PageSize)
            .ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
        return new PagedResult<TResult>()
        {
            Items = items,
            PageNumber = queryParameters.PageNumber,
            RecordNumber = queryParameters.PageSize,
            TotalCount = totalSize
        };
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync((id));
        return entity != null;
    }
}