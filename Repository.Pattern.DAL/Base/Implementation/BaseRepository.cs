using Microsoft.EntityFrameworkCore;
using Repository.Pattern.DAL.Contexts;

namespace Repository.Pattern.DAL.Base.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly PostgresDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(
            PostgresDbContext context
        )
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id) ?? throw new NullReferenceException("Entity with this ID doesn't exist");
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<TEntity>>(DbSet.AsQueryable());
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            DbSet.Add(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await DbSet.FindAsync(id) ??
                         throw new NullReferenceException("Entity with this ID doesn't exist");

            DbSet.Remove(entity);

            await Context.SaveChangesAsync();

            return entity;
        }
    }
}