using Repository.Pattern.DAL.Base.Implementation;
using Repository.Pattern.DAL.Contexts;
using Repository.Pattern.DAL.Entities;

namespace Repository.Pattern.DAL.Repositories.Implementation
{
    public class ExampleRepository : BaseRepository<ExampleEntity>, IExampleRepository
    {
        public ExampleRepository(PostgresDbContext context) : base(context)
        {
        }
    }
}