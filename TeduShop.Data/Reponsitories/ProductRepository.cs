using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IProductRepository : IReponsitory<Product>
    {
    }
    public class ProductRepository : ReponsitoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
