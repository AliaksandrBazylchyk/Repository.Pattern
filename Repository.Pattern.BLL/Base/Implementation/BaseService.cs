using Repository.Pattern.DAL.Base;

namespace Repository.Pattern.BLL.Base.Implementation
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly IBaseRepository<TEntity> _entityRepository;

        public BaseService(
            IBaseRepository<TEntity> entityRepository
        )
        {
            _entityRepository = entityRepository;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _entityRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entityRepository.GetAllAsync();
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            return _entityRepository.CreateAsync(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return _entityRepository.UpdateAsync(entity);
        }

        public Task<TEntity> DeleteAsync(Guid id)
        {
            return _entityRepository.DeleteAsync(id);
        }
    }
}