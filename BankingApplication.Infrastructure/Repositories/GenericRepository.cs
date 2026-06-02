using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication.Infrastructure.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T: BaseEntity
{
    protected readonly DbSet<T> _set = context.Set<T>();
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _set.AsNoTracking().ToListAsync();
    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
    }
    public void Update(T entity)
    {
        _set.Update(entity);
    }
    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        _set.Update(entity);
    }
}
