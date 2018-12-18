using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostTagRepository : IReponsitory<PostTag>
    {
    }
    public class PostTagRepository : ReponsitoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
