using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostRepository
    {
    }
    public class PostRepository : ReponsitoryBase<Post>, IPostRepository
    {
        public PostRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
