using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IProductTagRepository
    {
    }
    public class ProductTagRepository : ReponsitoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
