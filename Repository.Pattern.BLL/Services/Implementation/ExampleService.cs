using Repository.Pattern.BLL.Base.Implementation;
using Repository.Pattern.DAL.Base;
using Repository.Pattern.DAL.Entities;

namespace Repository.Pattern.BLL.Services.Implementation
{
    public class ExampleService : BaseService<ExampleEntity>, IExampleService
    {
        public ExampleService(IBaseRepository<ExampleEntity> entityRepository) : base(entityRepository)
        {
        }
    }
}
