using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;
using System.Linq;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostRepository : IReponsitory<Post>
    {
        IEnumerable<Post> GetAllbyTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }
    public class PostRepository : ReponsitoryBase<Post>, IPostRepository
    {
        public PostRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }

        public IEnumerable<Post> GetAllbyTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagId == tag && p.Status
                        orderby p.CreatedDate descending
                        select p;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}
