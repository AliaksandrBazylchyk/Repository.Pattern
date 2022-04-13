using Repository.Pattern.DAL.Base;

namespace Repository.Pattern.BLL.Base
{
    public interface IBaseService<TEntity> 
        where TEntity : class, IBaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Guid id);
    }
}