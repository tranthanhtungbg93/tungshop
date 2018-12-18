using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface ITagRepository : IReponsitory<Tag>
    {
    }
    public class TagRepository : ReponsitoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
