using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IProductTagRepository : IReponsitory<ProductTag>
    {
    }
    public class ProductTagRepository : ReponsitoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
