using HoteListing_API.Contracts;
using HoteListing_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HoteListing_API.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApplicationDbContext _context { get; set; }

    public GenericRepository(ApplicationDbContext context)
    {
        this._context = context;
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