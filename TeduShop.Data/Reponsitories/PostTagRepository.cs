using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostTagRepository
    {
    }
    public class PostTagRepository : ReponsitoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
