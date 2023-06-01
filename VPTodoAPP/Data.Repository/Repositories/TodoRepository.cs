using Data.Repository.Interfaces;
using Data.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Repositories;

public class TodoRepository : IDataRepository<TodoEntity>
{
    private readonly TodoDbContext _ctx;

    public TodoRepository(TodoDbContext ctx)
    {
        _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
    }


    public async Task<TodoEntity> AddAsync(TodoEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await _ctx.Todos.AddAsync(entity);
        await SaveAsync();
        return entity;
    }

    public async Task DeleteAsync(TodoEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await Task.FromResult(_ctx.Todos.Remove(entity));
        await SaveAsync();
    }

    public async Task<IEnumerable<TodoEntity>> GetAsync()
    {
        return await _ctx.Todos.ToListAsync();
    }

    public async Task<TodoEntity> GetAsync(int id)
    {
        return await _ctx.Todos.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> IsExistingAsync(int id)
    {
        return await _ctx.Todos.AnyAsync(u => u.Id == id);
    }

    public async Task<bool> SaveAsync()
    {
        return (await _ctx.SaveChangesAsync() > 0);
    }

    public async Task UpdateAsync(TodoEntity entity)
    {
        _ctx.Entry(entity).State = EntityState.Modified;
        await SaveAsync();
    }
}
