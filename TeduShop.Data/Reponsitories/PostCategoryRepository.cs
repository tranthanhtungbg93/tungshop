using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostCategoryReposiroty : IReponsitory<PostCategory>
    {
    }
    public class PostCategoryRepository : ReponsitoryBase<PostCategory>, IPostCategoryReposiroty
    {
        public PostCategoryRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
