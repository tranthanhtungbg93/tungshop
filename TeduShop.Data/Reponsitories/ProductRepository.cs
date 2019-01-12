using System.Collections;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;
using System.Linq;

namespace TeduShop.Data.Reponsitories
{
	public interface IProductRepository : IReponsitory<Product>
	{
		IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);
	}
	public class ProductRepository : ReponsitoryBase<Product>, IProductRepository
	{
		public ProductRepository(IDBFactory dBFactory) : base(dBFactory)
		{

		}

		public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
		{
			var query = from p in DbContext.Products
						join pt in DbContext.ProductTags
						on p.ID equals pt.ProductID
						where pt.TagID == tagId
						select p;
			totalRow = query.Count();
			return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
		}
	}
}
