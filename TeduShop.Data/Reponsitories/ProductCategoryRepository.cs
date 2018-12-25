using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IProductCategoryRespository : IReponsitory<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository : ReponsitoryBase<ProductCategory>, IProductCategoryRespository
    {
        public ProductCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
