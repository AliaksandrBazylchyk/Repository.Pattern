using Repository.Pattern.DAL.Base;

namespace Repository.Pattern.DAL.Entities
{
    public class ExampleEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}