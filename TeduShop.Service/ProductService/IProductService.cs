using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Model;

namespace TeduShop.Service.ProductCategoryService
{
    public interface IProductService
    {
        Product Add(Product category);
        void Update(Product category);
		Product Delete(int id);
        IEnumerable<Product> GetAll();
		IEnumerable<Product> GetAll(string keyword);
		IEnumerable<Product> GetAllbyCategoryID(int parentId);

		IEnumerable<Product> GetLastest(int id);
		IEnumerable<Product> GetHotProduct(int id);

		Product GetById(int id);
        void SaveChange();
    }
}
